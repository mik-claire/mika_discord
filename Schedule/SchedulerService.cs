using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Timers;

namespace mika_discord.Schedule
{
    public class SchedulerService
    {
        private static Timer timer;
        private static readonly int interval = 1000;
        private static List<ScheduleBase> schedules = new List<ScheduleBase>();
        private static SocketTextChannel channel;

        private static SchedulerService singletonInstance = null;
        public static SchedulerService GetInstance()
        {
            return singletonInstance;
        }

        public static void Init(SocketTextChannel targetChannel)
        {
            if (singletonInstance == null)
            {
                singletonInstance = new SchedulerService(targetChannel);
            }
        }

        private SchedulerService(SocketTextChannel targetChannel)
        {
            setup(targetChannel);
            timer = new Timer(interval);
            timer.Elapsed += Timer_Elapsed;
        }

        public void Start()
        {
            timer.Enabled = true;
            timer.Start();
        }

        public ScheduleBase GetSchedule(Type scheduleType)
        {
            return schedules.Where(s => !s.GetType().IsAbstract && scheduleType.IsInstanceOfType(s)).First();
        }

        private static void setup(SocketTextChannel targetChannel)
        {
            channel = targetChannel;
            IEnumerable<Type> scheduleTypes = Assembly.GetAssembly(typeof(ScheduleBase)).GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ScheduleBase)) && !t.IsAbstract);
            foreach (var type in scheduleTypes)
            {
                schedules.Add((ScheduleBase)Activator.CreateInstance(type));
            }
        }

        private static async void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;
            foreach (ScheduleBase schedule in schedules)
            {
                if (isNow(now, schedule))
                {
                    await schedule.Execute(channel, now);
                }
            }
        }

        private static bool isNow(DateTime now, ScheduleBase schedule)
        {
            if (!schedule.Enabled)
            {
                return false;
            }
            if (schedule.Year().Count > 0 && !schedule.Year().Contains(now.Year))
            {
                return false;
            }
            if (schedule.Month().Count > 0 && !schedule.Month().Contains(now.Month))
            {
                return false;
            }
            if (schedule.Day().Count > 0 && !schedule.Day().Contains(now.Day))
            {
                return false;
            }
            if (schedule.DayOfWeek().Count > 0 && !schedule.DayOfWeek().Contains(now.DayOfWeek))
            {
                return false;
            }
            if (schedule.Hour().Count > 0 && !schedule.Hour().Contains(now.Hour))
            {
                return false;
            }
            if (schedule.Minute().Count > 0 && !schedule.Minute().Contains(now.Minute))
            {
                return false;
            }
            if (schedule.Second().Count > 0 && !schedule.Second().Contains(now.Second))
            {
                return false;
            }

            return true;
        }
    }
}
