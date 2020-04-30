using Discord.Commands;
using mika_discord.Schedule;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Command
{
    public class TimeSignalControl : ModuleBase
    {
        private static readonly string statusMessageFormat = "現在、時報は {0} になってますよ。";
        private static readonly string errorMessage =
@"時報の状態を確認する場合は指定なしで。
ON / OFF を切り替える場合は、on / off のどちらかを指定してくださいね！";
        private static readonly string onMessage = "時報をONにしました！キリのいい時間にお知らせしますねーっ。";
        private static readonly string offMessage = "時報をOFFにしました！ONにしたいときはまた教えてくださいね！";
        private static readonly string on = "on";
        private static readonly string off = "off";
        private static Logger log = Logger.GetInstance("");
        private static TimeSignal schedule;

        public TimeSignalControl()
        {
            schedule = SchedulerService.GetInstance().GetSchedule(typeof(TimeSignal)) as TimeSignal;
        }

        [Command("timesignal")]
        public async Task TimeSignalOnOff(params string[] args)
        {
            if (args.Length < 1)
            {
                // check status
                await ReplyAsync(string.Format(statusMessageFormat, schedule.Enabled ? "ON" : "OFF"));
                return;
            }

            if (args[0] == on)
            {
                // on
                schedule.Enabled = true;
                await ReplyAsync(onMessage);
                return;
            }
            if (args[0] == off)
            {
                // off
                schedule.Enabled = false;
                await ReplyAsync(offMessage);
                return;
            }

            // error
            await ReplyAsync(errorMessage);
        }
    }
}
