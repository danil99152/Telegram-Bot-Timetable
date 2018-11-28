using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TimetableBot.Commands
{
    public class WhatsupCommand : Command
    {
        public override string Name => "Как дела?";

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            string replayes = "Я спал 3ч сегодня, просто убейте";
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await client.SendTextMessageAsync(chatId, replayes);
        }
    }
}