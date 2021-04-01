using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VotebanBot.Command.Commands
{
    public class BanCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "voteban", "banserge" };

        public override void Execute(Message message, TelegramBotClient client)
        {
            client.KickChatMemberAsync(message.Chat.Id, 1428996229);
        }
    }
}
