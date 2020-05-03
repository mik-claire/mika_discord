using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace mika_discord.Reaction
{
    public class ReactionService
    {
        private static List<ReactionBase> reactions = new List<ReactionBase>();

        private static ReactionService singletonInstance = null;
        public static ReactionService GetInstance()
        {
            return singletonInstance;
        }

        public static void Init()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new ReactionService();
            }
        }

        private ReactionService()
        {
            IEnumerable<Type> reactionTypes = Assembly.GetAssembly(typeof(ReactionBase)).GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ReactionBase)) && !t.IsAbstract);
            foreach (var type in reactionTypes)
            {
                reactions.Add((ReactionBase)Activator.CreateInstance(type));
            }
        }

        public static async Task Reaction(ISocketMessageChannel channel, SocketUser user, params string[] args)
        {
            string keyword = args.Length < 1 ? string.Empty : args[0];
            foreach (ReactionBase reaction in reactions)
            {
                if (!reaction.Hit(keyword))
                {
                    continue;
                }
                await reaction.Execute(channel, user, args);
                return;
            }
        }
    }
}
