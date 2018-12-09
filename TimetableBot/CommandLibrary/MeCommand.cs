using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TimetableBot;
using TimetableBot.Models;
using TimetableBot.Models.Commands;

namespace CommandLibrary
{
    [Command]
    public class MeCommand : Command
    {
        public override string Name => "/Me";

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            string replayes = "";
            var connectionString = ConfigurationManager.ConnectionStrings["DbConnectionName"];
            if (connectionString == null)
            {
                replayes = "Нет строки подключения к БД";
                return;
            }
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var studentList = new List<Student>();
                    command.CommandText = "select [Id], [UserName], [FIO] from [User]";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentList.Add(new Student
                            {
                                Id = reader.GetGuid(0),
                                FIO = reader.GetString(2),
                                Phone = reader.GetString(3),
                                Group = reader.GetString(0)
                            });
                        }
                    }
                    foreach (var student in studentList)
                    {
                        replayes = $"Id: {student.Id}, FIO: {student.FIO}, Phone: {student.Phone}, Группа: {student.Group}";
                    }
                    var chatId = message.Chat.Id;
                    var messageId = message.MessageId;
                    await client.SendTextMessageAsync(chatId, replayes);
                }
            }
        }
    }
}
