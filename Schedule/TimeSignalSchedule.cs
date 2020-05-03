using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord.WebSocket;
using mika_discord.Action;

namespace mika_discord.Schedule
{
    public class TimeSignalSchedule : ScheduleBase
    {
        public TimeSignalSchedule()
        {
            this.minute = new List<int>() { 0 };
            this.second = new List<int>() { 0 };
        }

        public override async Task Execute(SocketTextChannel channel, DateTime now)
        {
            string message = TimeSignal.GetTimeSignalMessage(now.Hour);
            if (string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            await channel.SendMessageAsync(message);
        }
    }
}
