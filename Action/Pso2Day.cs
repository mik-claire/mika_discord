using mika_discord.Enum;
using System.Collections.Generic;

namespace mika_discord.Action
{
    public static class Pso2Day
    {
        private static readonly string morningMessage =
            "みんなおはよう！今日はPSO2の日…いろんな特典があるから、ログオンして確認してみてね！";
        private static readonly string eveningMessage =
            "お仕事おつかれさま！今日はPSO2の日だから、忘れずにプレイするよーに！";
        private static readonly string nightMessage =
            "PSO2の日終了まであと1時間…もう特典はしっかり受け取ったかな？まだの人は急いで急いでー！！";

        private static readonly Dictionary<Pso2DayTiming, string> messageMap = new Dictionary<Pso2DayTiming, string>()
        {
            { Pso2DayTiming.Morning, morningMessage },
            { Pso2DayTiming.Evening, eveningMessage },
            { Pso2DayTiming.Night, nightMessage }
        };

        public static string GetMessage(Pso2DayTiming timing)
        {
            if (!messageMap.ContainsKey(timing))
            {
                return string.Empty;
            }

            return messageMap[timing];
        }
    }
}
