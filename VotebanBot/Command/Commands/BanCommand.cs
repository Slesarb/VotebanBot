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
        public Dictionary<int, int> banVotes = new Dictionary<int, int>();

        public override void Execute(Message message, TelegramBotClient client)
        {
            string username = "";
            foreach (var name in Names)
            {
                if (message.Text.Contains(name))
                    username = message.Text.Replace(name, "");
            }
            var admins = client.GetChatAdministratorsAsync(message.Chat.Id).Result;
            int memberCount = client.GetChatMembersCountAsync(message.Chat.Id).Result;
            username = username.Trim();
       //     username = username.Replace("", "");
            Console.WriteLine(message.Text);
            foreach (var user in BotConfig.users)
            {
                if (user.Key.Contains(username, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    ChatMember userToBan = client.GetChatMemberAsync(message.Chat.Id, user.Value).Result;
                    //client.KickChatMemberAsync(message.Chat.Id, user.Value);
                    foreach (var admin in admins)
                    {
                        if (user.Value == admin.User.Id)
                        {
                            client.SendTextMessageAsync(message.Chat.Id, "Щупальца убрал, он тут босс"); 
                            return;
                        }
                            
                    }
                    if (!banVotes.ContainsKey(userToBan.User.Id))
                        banVotes.Add(userToBan.User.Id, 0);
                    banVotes[userToBan.User.Id] += 1;
                    if (banVotes[userToBan.User.Id] >= memberCount)
                    {
                        client.SendTextMessageAsync(message.Chat.Id, $"user {userToBan.User.FirstName + " " + userToBan.User.LastName} banned");
                        client.KickChatMemberAsync(message.Chat.Id, user.Value);
                        //client.SendTextMessageAsync(message.Chat.Id, $"{banVotes[userToBan.User.Id]} / {memberCount} users has voted to ban {userToBan.User.FirstName + " " + userToBan.User.LastName}");
                    }
                    else
                    {
                        client.SendTextMessageAsync(message.Chat.Id, $"{banVotes[userToBan.User.Id]} / {memberCount} users has voted to ban {userToBan.User.FirstName + " " + userToBan.User.LastName}");
                    }
                }
              //  else
                    //client.SendTextMessageAsync(message.Chat.Id, "no such user with username: " + username);

            }
            //client.KickChatMemberAsync(message.Chat.Id, 1428996229);
        }
    }
}
