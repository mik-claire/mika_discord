using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class TestScedule : ScheduleBase
    {
        public TestScedule()
        {
            this.hour = new List<int>() { 0 };
            this.second = new List<int>() { 30 };
            this.enable = false;
        }

        public override async Task Execute(SocketTextChannel channel)
        {
            var sb = new StringBuilder();
            foreach (var user in channel.Guild.Users)
            {
                if (user.IsBot)
                {
                    continue;
                }
                sb.Append(user.Mention);
                sb.Append(" ");
            }

            await channel.SendMessageAsync(sb.ToString() + "毎分のスケジュール実行！ちゃんと発言できてるかな…？");
        }
    }
}
