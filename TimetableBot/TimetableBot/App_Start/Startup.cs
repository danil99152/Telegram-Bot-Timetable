using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TimetableBot.App_Start;
using Autofac;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

[assembly: OwinStartup(typeof(Startup))]
namespace TimetableBot.App_Start
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Timetable"];
            var builder = new ContainerBuilder();
            var modelsAssembly = Assembly.GetAssembly(typeof(Student));
            builder.Register(x =>
            {
                var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
                    .ExposeConfiguration(c => {
                        SchemaMetadataUpdater.QuoteTableAndColumns(c);
                        c.EventListeners.PreInsertEventListeners = x.Resolve<IPreInsertEventListener[]>();
                        c.EventListeners.PreUpdateEventListeners = x.Resolve<IPreUpdateEventListener[]>();
                    })
                    .CurrentSessionContext("call");
                var conf = cfg.BuildConfiguration();
                var schemaExport = new SchemaUpdate(conf);
                schemaExport.Execute(true, true);
                return cfg.BuildSessionFactory();
            }).As<ISessionFactory>().SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession())
                .As<ISession>()
                .InstancePerRequest()
                .InstancePerDependency();

            foreach (var type in modelsAssembly.GetTypes())
            {
                var attr = type.GetCustomAttribute<RepositoryAttribute>();
                if (attr == null)
                {
                    continue;
                }
                builder.RegisterType(type);
            }
            if (connectionString == null)
            {
                throw new Exception("Не найдена строка соединения");
            }
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    //Создание новых записей
                    /*using (var tran = connection.BeginTransaction())
                    {
                        try
                        {
                            command.Transaction = tran;
                            command.CommandText = $@"
insert into [User] ([Id], [UserName], [FIO]) 
values ('{Guid.NewGuid()}', 'ivanov', 'Иванов Иван Иванович')";                            
                            command.ExecuteNonQuery();
                           

                            command.CommandText = $@"
insert into [User] ([Id], [UserName], [FIO]) 
values ('{Guid.NewGuid()}', 'petrov', 'Петров Петр Петрович')";
                            command.ExecuteNonQuery();

                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            tran.Rollback();
                        }
                    }*/
                    //Чтение данных из БД
                    var studentList = new List<Student>();
                    command.CommandText = "select [Id], [UserName], [Phone] from [Student]";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentList.Add(new Student
                            {
                                Id = reader.GetInt64(0),
                                UserName = reader.GetString(2),
                                Phone = reader.GetString(3)
                            });
                        }
                    }
                    foreach (var student in studentList)
                    {
                        Console.WriteLine($"Id: {student.Id}, UserName: {student.UserName}, Phone: {student.Phone}");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}