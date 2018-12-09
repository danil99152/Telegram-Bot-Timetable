using Telegram.Bot;
using Telegram.Bot.Types;
using TimetableBot.Models;
using TimetableBot.Models.Commands;

namespace CommandLibrary
{
    [Command]
    public class HelpCommand : Command
    {
        public override string Name => "/help";

        public override async void Execute(Message message, ITelegramBotClient client)
        {
            string replayes = "Привет! Я бот, который показывает расписание, и вот что я умею: " +
                "\n/Me" +
                "\n/MyId " + //Что за MyId, Влад? 
                "\n/ScheduleToday" +
                "\n/ScheduleInWeek";
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            await client.SendTextMessageAsync(chatId, replayes);
        }
    }
}