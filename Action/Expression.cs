using System;
using System.Collections.Generic;

namespace mika_discord.Action
{
    public static class Expression
    {
        private static Random rand = new Random();
        private static readonly List<string> randomMessages = new List<string>
        {
            "どういたしましてっ！",
            "わーい！ふふ、もっと褒めてくださっても良いんですよ？"
        };

        public static string GetExpression()
        {
            return randomMessages[getRandom(randomMessages)];
        }

        private static int getRandom(List<string> randomMessages)
        {
            return rand.Next(0, randomMessages.Count);
        }
    }
}
