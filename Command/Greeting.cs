using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mika_discord.Command
{
    public class Greeting : ModuleBase
    {
        private static Logger log = Logger.GetInstance("");
        private static Random rand = new Random();
        private List<string> randomMessages = new List<string>
        {
            "ふふ、呼びました？",
            "はーい！何か御用ですか？",
            "ｚｚｚ…はっ！お、お呼びでしょうかっ！？"
        };

        [Command("mika")]
        public async Task ReturnGreeting(params string[] args)
        {
            await ReplyAsync(Context.User.Mention + " " + this.randomMessages[getRandom(this.randomMessages)]);
        }

        private int getRandom(List<string> randomMessages)
        {
            int result = rand.Next(0, randomMessages.Count);
            log.Debug("/mika result: {0}", result);
            return result;
        }
    }
}
