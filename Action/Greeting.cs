using System;
using System.Collections.Generic;

namespace mika_discord.Action
{
    public static class Greeting
    {
        private static Random rand = new Random();
        private static readonly List<string> randomMessages = new List<string>
        {
            "ふふ、呼びました？",
            "はーい！何か御用ですか？",
            "ｚｚｚ…はっ！お、お呼びでしょうかっ！？"
        };

        public static string GetGreeting()
        {
            return randomMessages[getRandom(randomMessages)];
        }

        private static int getRandom(List<string> randomMessages)
        {
            return rand.Next(0, randomMessages.Count);
        }
    }
}
