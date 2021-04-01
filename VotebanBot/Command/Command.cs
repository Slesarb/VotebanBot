using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VotebanBot.Command
{
    public abstract class Command
    {
        public abstract string[] Names { get; set; }
        public abstract void Execute(Message message, TelegramBotClient client);
        public bool Contains(string message)
        {
            foreach (var msg in Names)
                if (message.Contains(msg))
                    return true;
            return false;
        }
    }
}
