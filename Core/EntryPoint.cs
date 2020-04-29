namespace mika_discord.Core
{
    public class EntryPoint
    {
        public static void Main() => new MainLogic().MainAsync().GetAwaiter().GetResult();
    }
}
