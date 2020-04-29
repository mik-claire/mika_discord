using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class Pso2DayNight : ScheduleBase
    {
        public Pso2DayNight()
        {
            this.day = new List<int>() { 2 };
            this.hour = new List<int>() { 23 };
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

            await channel.SendMessageAsync(sb.ToString() + "PSO2の日終了まであと1時間…もう特典はしっかり受け取ったかな？まだの人は急いで急いでー！！");
        }
    }
}
