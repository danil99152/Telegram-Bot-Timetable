using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using TimetableBot;
using TimetableBot.Models;
using TimetableBot.Models.Commands;

namespace CommandLibrary
{
    [Command]
    public class StartCommand : Command
    {
        public override string Name => "/start";

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            string replayes = "Введите ваш номер телефона для аутентификации";
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await client.SendTextMessageAsync(chatId, replayes);

            var connectionString = ConfigurationManager.ConnectionStrings["Timetable"];
            if (connectionString == null)
            {
                throw new Exception("Не найдена строка соединения");
            }
            using (var connection = new SqlConnection(connectionString.ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var studentList = new List<Student>();
                    command.CommandText = "select [Id], [UserName], [Phone] from [Student]";
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentList.Add(new Student
                            {
                                Phone = message.Chat.Id
                            });
                        }
                    }
                    foreach (var student in studentList)
                    {
                       replayes = ($" Вы {student.UserName}, телефон: {student.Phone}");
                    }
                }
            }
        }
    }
}