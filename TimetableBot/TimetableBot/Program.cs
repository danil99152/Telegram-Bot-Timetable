using System;
using Telegram.Bot;
using System.Net;
using Telegram.Bot.Args;
using System.Threading;

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
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);
        }

        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }
    }
}

