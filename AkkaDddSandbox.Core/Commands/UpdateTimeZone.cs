using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateTimeZone : IDomainCommand
    {
        public UpdateTimeZone(string timeZone)
        {
            TimeZone = timeZone;
        }

        public string TimeZone { get; }
    }
}