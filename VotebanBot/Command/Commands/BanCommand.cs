using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VotebanBot.Command.Commands
{
    public class BanCommand : Command
    {
        public override string[] Names { get; set; } = new string[] { "voteban", "пошел нахуй", "иди нахуй" };

        public override void Execute(Message message, TelegramBotClient client)
        {
            string username = "";
            foreach (var name in Names)
            {
                if (message.Text.Contains(name))
                    username = message.Text.Replace(name, "");
            }
            var admins = client.GetChatAdministratorsAsync(message.Chat.Id).Result;
            username = username.Trim();
            Console.WriteLine(message.Text);
            foreach (var user in BotConfig.users)
            {
                if (user.Key.Contains(username, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    //client.KickChatMemberAsync(message.Chat.Id, user.Value);
                    foreach (var admin in admins)
                    {
                        if (user.Value == admin.User.Id)
                        {
                            client.SendTextMessageAsync(message.Chat.Id, "Щупальца убрал, he's the Owner");
                            return;
                        }
                            
                    }
                    
                    client.SendTextMessageAsync(message.Chat.Id, $"user {username.TrimEnd()} banned");
                }
              //  else
                    //client.SendTextMessageAsync(message.Chat.Id, "no such user with username: " + username);

            }
            //client.KickChatMemberAsync(message.Chat.Id, 1428996229);
        }
    }
}
