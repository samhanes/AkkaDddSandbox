using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Commands
{
    public class InitializeRespondent : IDomainCommand
    {
        public InitializeRespondent(string firstName, string lastName, string timeZone)
        {
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
    }
}