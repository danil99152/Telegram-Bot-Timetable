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
        public override string Name => "/help";

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            string replayes = "Привет я бот который показывает расписание вот что я умею: " +
                "\n/Me" +
                "\n/MyId " +
                "\n/ScheduleToday" +
                "\n/ScheduleInWeek";
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await client.SendTextMessageAsync(chatId, replayes);
        }
    }
}