using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using mika_discord.Schedule;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace mika_discord.Core
{
    public class MainLogic
    {
        private static Logger log;
        private static readonly string settingFilePath = "./setting.yml";
        private static Setting setting;

        public static DiscordSocketClient Client;
        public static IServiceProvider Provider;
        public static CommandService Commands;

        /// <summary>
        /// activate process
        /// </summary>
        public async Task MainAsync()
        {
            Logger.Init(@"./mika_pso2_bot.log", true);
            log = Logger.GetInstance("");
            setting = new DeserializerBuilder()
                    .WithNamingConvention(CamelCaseNamingConvention.Instance)
                    .Build()
                    .Deserialize<Setting>(File.ReadAllText(settingFilePath, Encoding.UTF8));

            Client = new DiscordSocketClient();
            Client.MessageReceived += CommandRecieved;
            Client.Log += msg =>
            {
                Console.WriteLine(msg.ToString());
                return Task.CompletedTask;
            };

            string token = setting.Token;
            Client.Ready += ServiceInit;
            await Client.LoginAsync(Discord.TokenType.Bot, token);
            await Client.StartAsync();
            
            log.Info("activated.");
            await Task.Delay(-1);
        }

        public async Task ServiceInit()
        {
            SchedulerService.Init(Client.GetGuild(setting.ServerId).GetTextChannel(setting.ChannelId));
            SchedulerService.GetInstance().Start();

            Provider = new ServiceCollection().BuildServiceProvider();
            Commands = new CommandService();
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly(), Provider);
        }

        public async Task CommandRecieved(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message == null)
            {
                return;
            }

            log.Debug("#{0} {1}: {2}", message.Channel.Name, message.Author.Username, message);
            if (message?.Author.IsBot ?? true)
            {
                return;
            }

            int argPos = 0;
            if (message.HasMentionPrefix(Client.CurrentUser, ref argPos))
            {

            }

            if (!message.HasCharPrefix('/', ref argPos))
            {
                return;
            }

            var context = new CommandContext(Client, message);
            IResult result = await Commands.ExecuteAsync(context, argPos, Provider);

            if (!result.IsSuccess)
            {
                await context.Channel.SendMessageAsync(getErrorMessage(result));
            }
        }

        private static string getErrorMessage(IResult result)
        {
            log.Warn(result.ErrorReason);
            if (result.ErrorReason == "Unknown command.")
            {
                return "ごめんなさい、そのコマンドは登録されてないみたいです…。";
            }
            return result.ErrorReason;
        }
    }
}
