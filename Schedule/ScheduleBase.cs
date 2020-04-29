using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public abstract class ScheduleBase
    {
        protected bool enable = true;
        public bool Enable { get { return this.enable; } }

        protected List<int> year = new List<int>();
        public IList<int> Year()
        {
            return this.year.AsReadOnly();
        }

        protected List<int> month = new List<int>();
        public IList<int> Month()
        {
            return this.month.AsReadOnly();
        }

        protected List<int> day = new List<int>();
        public IList<int> Day()
        {
            return this.day.AsReadOnly();
        }

        protected List<DayOfWeek> dayOfWeek = new List<DayOfWeek>();
        public IList<DayOfWeek> DayOfWeek()
        {
            return this.dayOfWeek.AsReadOnly();
        }

        protected List<int> hour = new List<int>();
        public IList<int> Hour()
        {
            return this.hour.AsReadOnly();
        }

        protected List<int> minute = new List<int>();
        public IList<int> Minute()
        {
            return this.minute.AsReadOnly();
        }

        protected List<int> second = new List<int>();
        public IList<int> Second()
        {
            return this.second.AsReadOnly();
        }

        public abstract Task Execute(SocketTextChannel channel);
    }
}
