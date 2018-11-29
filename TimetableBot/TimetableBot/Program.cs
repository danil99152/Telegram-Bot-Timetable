using System;
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