using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TimetableBot.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            string[] replayes = { "Hello!", "СапБой", "Я в УдГУ всё могу!"};
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //логика бота

            await client.SendTextMessageAsync(chatId, replayes[new Random().Next(0, replayes.Length)]);
        }
    }
}