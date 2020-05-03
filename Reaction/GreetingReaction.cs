using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.WebSocket;
using mika_discord.Action;

namespace mika_discord.Reaction
{
    public class GreetingReaction : ReactionBase
    {
        public GreetingReaction()
        {
            Keywords = new List<string>() { string.Empty };
        }

        public override async Task Execute(ISocketMessageChannel channel, SocketUser user, params string[] args)
        {
            await channel.SendMessageAsync(GetMentionPrefix(user) + Greeting.GetGreeting());
        }
    }
}
