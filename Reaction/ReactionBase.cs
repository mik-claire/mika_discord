using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mika_discord.Reaction
{
    public abstract class ReactionBase
    {
        protected static List<string> Keywords = new List<string>();
        public abstract Task Execute(ISocketMessageChannel channel, SocketUser user, params string[] args);

        public bool Hit(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                keyword = string.Empty;
            }
            return Keywords.Contains(keyword);
        }

        protected string GetMentionPrefix(SocketUser user)
        {
            return user.Mention + " ";
        }
    }
}
