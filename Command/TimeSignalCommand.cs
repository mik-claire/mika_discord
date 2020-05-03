using Discord.Commands;
using mika_discord.Action;
using System.Threading.Tasks;

namespace mika_discord.Command
{
    public class TimeSignalCommand : ModuleBase
    {
        private static readonly string on = "ON";
        private static readonly string off = "OFF";

        [Command("timesignal")]
        public async Task TimeSignalOnOff(params string[] args)
        {
            if (args.Length < 1)
            {
                // check status
                await ReplyAsync(TimeSignal.TimeSignalStatus());
                return;
            }

            if (args[0].ToUpper() == on)
            {
                // on
                await ReplyAsync(TimeSignal.TimeSignalOn());
                return;
            }
            if (args[0].ToUpper() == off)
            {
                // off
                await ReplyAsync(TimeSignal.TimeSignalOff());
                return;
            }

            // error
            await ReplyAsync(TimeSignal.Error());
        }
    }
}
