using Discord.WebSocket;
using mika_discord.Action;
using mika_discord.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class Pso2DaySchedule : ScheduleBase
    {
        public Pso2DaySchedule()
        {
            this.day = new List<int>() { 2 };
            this.hour = Pso2DayTiming.GetAll().Select(e => e.hour).ToList();
            this.minute = new List<int>() { 0 };
            this.second = new List<int>() { 0 };
        }

        public override async Task Execute(SocketTextChannel channel, DateTime now)
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

            string message = Pso2Day.GetMessage(Pso2DayTiming.Get(now.Hour));
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            sb.Append(message);
            await channel.SendMessageAsync(sb.ToString());
        }
    }
}
