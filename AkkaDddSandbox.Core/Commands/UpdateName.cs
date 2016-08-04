using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class UpdateName : RespondentCommand
    {
        public UpdateName(RespondentId id, string firstName, string lastName) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        
        public string FirstName { get; }
        public string LastName { get; }
    }
}