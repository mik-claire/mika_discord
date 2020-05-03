using System.Collections.Generic;
using System.Linq;

namespace mika_discord.Enum
{
    public class Pso2DayTiming
    {
        public static readonly Pso2DayTiming Morning = new Pso2DayTiming(7);
        public static readonly Pso2DayTiming Evening = new Pso2DayTiming(19);
        public static readonly Pso2DayTiming Night = new Pso2DayTiming(23);

        public int hour;
        private Pso2DayTiming(int hour)
        {
            this.hour = hour;
        }

        public static List<Pso2DayTiming> GetAll()
        {
            return new List<Pso2DayTiming>() { Morning, Evening, Night};
        }

        public static Pso2DayTiming Get(int hour)
        {
            return GetAll().Where(e => hour == e.hour).First();
        }
    }
}
