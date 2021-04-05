using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VotebanBot.Command.Commands
{
    public class HelpCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "help", "Помощь" };

        public override void Execute(Message message, TelegramBotClient client)
        {
            client.SendTextMessageAsync(message.Chat.Id, "Welcome to Voteban bot! A simple bot that bans the users by your request.\nType /voteban @username if you want to kick this user from a groupchat");
        }
    }
}
