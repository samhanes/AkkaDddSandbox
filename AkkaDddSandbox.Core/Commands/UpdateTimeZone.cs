using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateTimeZone : RespondentCommand
    {
        public UpdateTimeZone(RespondentId id, string timeZone) : base(id)
        {
            TimeZone = timeZone;
        }

        public string TimeZone { get; }
    }
}