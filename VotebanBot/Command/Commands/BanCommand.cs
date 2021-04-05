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
        private Dictionary<int, HashSet<int>> usersVoted = new Dictionary<int, HashSet<int>>();

        public override void Execute(Message message, TelegramBotClient client)
        {
            ChatMember bot = client.GetChatMemberAsync(message.Chat.Id, 1735511247).Result;
            if (!(bot.Status.ToString() == "Administrator"))
                client.SendTextMessageAsync(message.Chat.Id, "I'm not an Admin of this chat. so i can't kick the other users");
            string username = "";
            foreach (var name in Names)
            {
                if (message.Text.Contains(name))
                    username = message.Text.Replace(name, "");
            }
            int memberCount = client.GetChatMembersCountAsync(message.Chat.Id).Result;
            username = username.Replace("/", "");
            username = username.Trim();
            Console.WriteLine(message.Text);
            foreach (var user in BotConfig.users)
            {
                if (user.Key.Contains(username, StringComparison.InvariantCultureIgnoreCase)) 
                {
                    ChatMember userToBan = client.GetChatMemberAsync(message.Chat.Id, user.Value).Result;
                    if (userToBan.User.Id == 374758888)
                        client.SendTextMessageAsync(message.Chat.Id, "Пошли нахуй, да? Неблагодарные");
                    //client.KickChatMemberAsync(message.Chat.Id, user.Value);
                    if (userToBan.Status.ToString() == "Creator")
                    {
                        client.SendTextMessageAsync(message.Chat.Id, "Щупальца убрал, он тут босс");
                        return;
                    }
                    if (!usersVoted.ContainsKey(userToBan.User.Id))
                        usersVoted.Add(userToBan.User.Id, new HashSet<int>());

                    if (usersVoted[userToBan.User.Id].Contains(message.From.Id))
                    {
                        client.SendTextMessageAsync(message.Chat.Id, "You've already voted to ban this user");
                        return;
                    }
                        
                    else
                        usersVoted[userToBan.User.Id].Add(message.From.Id);
                    if (usersVoted[userToBan.User.Id].Count >= memberCount / 2 + 1)
                    {
                        client.SendTextMessageAsync(message.Chat.Id, $"user {userToBan.User.FirstName + " " + userToBan.User.LastName} banned");
                        client.KickChatMemberAsync(message.Chat.Id, user.Value);
                        //client.SendTextMessageAsync(message.Chat.Id, $"{banVotes[userToBan.User.Id]} / {memberCount} users has voted to ban {userToBan.User.FirstName + " " + userToBan.User.LastName}");
                    }
                    else
                    {
                        client.SendTextMessageAsync(message.Chat.Id, $"{usersVoted[userToBan.User.Id].Count} / {memberCount / 2 + 1} users has voted to ban {userToBan.User.FirstName + " " + userToBan.User.LastName}");
                    }
                }

            }
        }
    }
}
