using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Dialect;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Configuration;
using System.Net;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using TimetableBot.Models;

namespace TimetableBot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static void Main()
        {
            var httpProxy = new WebProxy(Address: "HSI-KBW-109-192-091-198.hsi6.kabel-badenwuerttemberg.de:53701") { };
            botClient = new TelegramBotClient("715240208:AAHS-H8AUdR2Wr4eOm4wdJKPWNle7CI4V1E", httpProxy);
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $" Bot start.\n IdBot-> {me.Id} \n NameBot -> {me.FirstName}");
            //обновление базы данных через mapping
            var connectionString = ConfigurationManager.ConnectionStrings["Timetable"];
            var cfg = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012
                        .ConnectionString(connectionString.ConnectionString)
                        .Dialect<MsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
                    .ExposeConfiguration(c => {
                        SchemaMetadataUpdater.QuoteTableAndColumns(c);
                    })
                    .CurrentSessionContext("call");
            var conf = cfg.BuildConfiguration();
            var schemaExport = new SchemaUpdate(conf);
            schemaExport.Execute(true, true);
            cfg.BuildSessionFactory();
            ///////////////////////////////////////
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            var repository = new MainRepository();
            repository.Init();


            var message = e.Message;
            DateTime localTime = e.Message.Date.ToLocalTime();// подключение времени от компа 

            if (message.Text != null)
            {
                Console.WriteLine($"New message in chat " +
                    $"\nText->{message.Text} " +
                    $"\nIdChat->{message.Chat.Id} " +
                    $"\nTime->{localTime}" +
                    $"\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

                foreach (var command in repository.FindAllCommands())
                {
                    if (command.Contains(message.Text))
                    {
                        command.Execute(message, botClient);
                        break;
                    }
                }
            }
        }
    }
}