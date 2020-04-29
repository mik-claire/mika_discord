using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class Pso2Day : ScheduleBase
    {
        private const int morningHour = 7;
        private const int eveningHour = 19;
        private const int nightHour = 23;

        private static readonly string morningMessage =
            "みんなおはよう！今日はPSO2の日…いろんな特典があるから、ログオンして確認してみてね！";
        private static readonly string eveningMessage =
            "お仕事おつかれさま！今日はPSO2の日だから、忘れずにプレイするよーに！";
        private static readonly string nightMessage =
            "PSO2の日終了まであと1時間…もう特典はしっかり受け取ったかな？まだの人は急いで急いでー！！";

        public Pso2Day()
        {
            this.day = new List<int>() { 2 };
            this.hour = new List<int>() { morningHour, eveningHour, nightHour };
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

            switch (now.Hour)
            {
                case morningHour:
                    sb.Append(morningMessage);
                    break;
                case eveningHour:
                    sb.Append(eveningMessage);
                    break;
                case nightHour:
                    sb.Append(nightMessage);
                    break;
                default:
                    return;
            }

            await channel.SendMessageAsync(sb.ToString());
        }
    }
}
