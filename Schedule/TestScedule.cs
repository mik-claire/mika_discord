using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mika_discord.Schedule
{
    public class TestScedule : ScheduleBase
    {
        private const int zero = 0;
        private const int half = 30;
        private static readonly string message = "{0}秒のスケジュール実行！ちゃんと発言できてるかな…？";

        public TestScedule()
        {
            this.second = new List<int>() { zero, half };
            this.enable = false;
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
            switch (now.Second)
            {
                case zero:
                    sb.AppendFormat(message, zero);
                    break;
                case half:
                    sb.AppendFormat(message, half);
                    break;
                default:
                    return;
            }

            await channel.SendMessageAsync(sb.ToString());
        }
    }
}
