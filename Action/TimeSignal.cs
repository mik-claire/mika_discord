using mika_discord.Schedule;
using System.Collections.Generic;

namespace mika_discord.Action
{
    public static class TimeSignal
    {
        private static readonly string statusMessageFormat = "現在、時報は {0} になってますよ。";
        private static readonly string errorMessage =
@"時報の状態を確認する場合は指定なしで。
ON / OFF を切り替える場合は、on / off のどちらかを指定してくださいね！";
        private static readonly string onMessage = "時報をONにしました！キリのいい時間にお知らせしますねーっ。";
        private static readonly string offMessage = "時報をOFFにしました！ONにしたいときはまた教えてくださいね！";
        private static readonly string on = "ON";
        private static readonly string off = "OFF";
        private static readonly Dictionary<int, string> messageMap = new Dictionary<int, string>()
        {
            { 0, "0時、日付が変わったね！更新されたデイリーミッションでも見に行こうかな？" },
            { 1, "1時、まだ寝ないのかな？夜ふかしは程々にねー？" },
            { 2, "2時…私はそろそろお布団に入るね、おやすみなさーい…。" },
            { 3, "" },
            { 4, "" },
            { 5, "" },
            { 6, "" },
            { 7, "7時！起きて起きて、朝だよー！しっかり朝ごはん食べて、出撃の準備しなきゃ！" },
            { 8, "8時、そろそろ出撃の時間だね！今日も1日、元気に出撃しようね！" },
            { 9, "" },
            { 10, "" },
            { 11, "" },
            { 12, "12時、お昼ごはんの時間だよ！今日は何食べようかなー…？" },
            { 13, "13時。お昼ごはんも食べて、眠くなってきちゃった…。" },
            { 14, "" },
            { 15, "15時、おやつの時間だね！お仕事休憩してティータイムにしない？" },
            { 16, "16時、お外も薄暗くなってくる時間かなー、そろそろカーテン閉めたりしないとね！" },
            { 17, "17時！カラスが鳴いてるねー…ゆーやけこやけで日が暮れて…。" },
            { 18, "18時、お仕事もあとちょっと！がんばれーっ！" },
            { 19, "19時、今日もお仕事おつかれさま！夜ご飯食べてのんびりしよう？" },
            { 20, "" },
            { 21, "21時！デイリーミッション消化がまだの人は、そろそろ確認しておいたほうがいいかも？" },
            { 22, "" },
            { 23, "23時！そろそろ日付変わっちゃうね…デイリーミッションはちゃんと消化した？" }
        };

        public static string GetTimeSignalMessage(int hour)
        {
            if (!messageMap.ContainsKey(hour))
            {
                return string.Empty;
            }

            return messageMap[hour];
        }

        public static string TimeSignalStatus()
        {
            return string.Format(statusMessageFormat,
                (SchedulerService.GetInstance().GetSchedule(typeof(TimeSignalSchedule)) as TimeSignalSchedule)
                    .Enabled ? on : off);
        }

        public static string TimeSignalOn()
        {
            (SchedulerService.GetInstance().GetSchedule(typeof(TimeSignalSchedule)) as TimeSignalSchedule)
                .Enabled = true;
            return onMessage;
        }

        public static string TimeSignalOff()
        {
            (SchedulerService.GetInstance().GetSchedule(typeof(TimeSignalSchedule)) as TimeSignalSchedule)
                .Enabled = false;
            return offMessage;
        }

        public static string Error()
        {
            return errorMessage;
        }
    }
}
