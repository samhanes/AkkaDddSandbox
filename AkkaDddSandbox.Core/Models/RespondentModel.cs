namespace AkkaDddSandbox.Core.Models
{
    public class RespondentModel
    {
        public RespondentModel(string firstName, string lastName, string timeZone, string taskRulesState)
        {
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
            TaskRulesState = taskRulesState;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
        public string TaskRulesState { get; }
    }
}