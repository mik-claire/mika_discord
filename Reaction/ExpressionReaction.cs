using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.WebSocket;
using mika_discord.Action;

namespace mika_discord.Reaction
{
    public class ExpressionReaction : ReactionBase
    {
        public ExpressionReaction()
        {
            Keywords = new List<string>() { "ありがと", "thx", "thanks" };
        }

        public override async Task Execute(ISocketMessageChannel channel, SocketUser user, params string[] args)
        {
            await channel.SendMessageAsync(GetMentionPrefix(user) + Expression.GetExpression());
        }
    }
}
