using Discord.WebSocket;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class Pso2DayMorning : ScheduleBase
    {
        public Pso2DayMorning()
        {
            this.day = new List<int>() { 2 };
            this.hour = new List<int>() { 7 };
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

            await channel.SendMessageAsync(sb.ToString() + "みんなおはよう！今日はPSO2の日…いろんな特典があるから、ログオンして確認してみてね！");
        }
    }
}
