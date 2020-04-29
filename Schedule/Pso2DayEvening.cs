using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class Pso2DayEvening : ScheduleBase
    {
        public Pso2DayEvening()
        {
            this.day = new List<int>() { 2 };
            this.hour = new List<int>() { 19 };
            this.minute = new List<int>() { 0 };
            this.second = new List<int>() { 0 };
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

            await channel.SendMessageAsync(sb.ToString() + "お仕事おつかれさま！今日はPSO2の日だから、忘れずにプレイするよーに！");
        }
    }
}
