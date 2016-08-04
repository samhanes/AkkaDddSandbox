using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Commands
{
    public class CreateRespondent : RespondentCommand
    {
        public CreateRespondent(RespondentId id, string firstName, string lastName, string timeZone) 
            : base(id)
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