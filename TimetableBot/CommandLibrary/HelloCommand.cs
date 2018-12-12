using System;
using Telegram.Bot;
using Telegram.Bot.Types;
using TimetableBot.Models;
using TimetableBot.Models.Commands;

namespace CommandLibrary
{
    [Command]
    public class HelloCommand : Command
    {
        public override string Name => "/hello";

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            string[] replayes = { "Hello!", "Здравие желаю"};
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //логика бота

            await client.SendTextMessageAsync(chatId, replayes[new Random().Next(0, replayes.Length)]);
        }
    }
}