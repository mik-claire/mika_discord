using Discord.Commands;
using mika_discord.Action;
using System.Threading.Tasks;

namespace mika_discord.Command
{
    public class GreetingCommand : ModuleBase
    {
        [Command("mika")]
        public async Task ReturnGreeting()
        {
            int argPos = 0;
            if (Context.Message.HasMentionPrefix(Context.Client.CurrentUser, ref argPos))
            {
                return;
            }

            await ReplyAsync(Context.User.Mention + " " + Greeting.GetGreeting());
        }
    }
}
