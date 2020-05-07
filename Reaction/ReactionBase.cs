using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mika_discord.Reaction
{
    public abstract class ReactionBase
    {
        protected List<string> Keywords = new List<string>();

        public abstract Task Execute(ISocketMessageChannel channel, SocketUser user, params string[] args);

        public bool Hit(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                target = string.Empty;
            }

            foreach (var keyword in Keywords)
            {
                if (target.StartsWith(keyword))
                {
                    return true;
                }
            }

            return false;
        }

        protected string GetMentionPrefix(SocketUser user)
        {
            return user.Mention + " ";
        }
    }
}
