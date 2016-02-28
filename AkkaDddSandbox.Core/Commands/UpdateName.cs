using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateName : IDomainCommand
    {
        public UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; }
        public string LastName { get; }
    }
}