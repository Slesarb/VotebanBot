using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using VotebanBot.Command.Commands;

namespace VotebanBot
{
    class Programm
    {
        private static TelegramBotClient client;
        private static List<Command.Command> commands = new List<Command.Command>();
        static void Main(string[] args)
        {
            client = new TelegramBotClient(BotConfig.botToken);
            commands.Add(new HelpCommand());
            commands.Add(new BanCommand());
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.WriteLine("Hello World!");
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            if (message.Text != null)
            {
                foreach (var cmd in commands)
                {
                    if (cmd.Contains(message.Text))
                    {
                        cmd.Execute(message, client);
                    }
                        
                }
            }
        }
    }
}
