using Telegram.Bot.Types;
using Telegram.Bot;

namespace TimetableBot.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, ITelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
    }
}