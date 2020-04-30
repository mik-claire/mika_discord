using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace mika_discord.Schedule
{
    public class TimeSignal : ScheduleBase
    {
        private Dictionary<int, string> messageMap = new Dictionary<int, string>()
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

        public TimeSignal()
        {
            this.minute = new List<int>() { 0 };
            this.second = new List<int>() { 0 };
        }

        public override async Task Execute(SocketTextChannel channel, DateTime now)
        {
            if (!this.messageMap.ContainsKey(now.Hour) ||
                string.IsNullOrEmpty(this.messageMap[now.Hour]))
            {
                return;
            }

            await channel.SendMessageAsync(this.messageMap[now.Hour]);
        }
    }
}
