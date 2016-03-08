namespace AkkaDddSandbox.Core.Models
{
    public class RespondentModel
    {
        public RespondentModel(string firstName, 
            string lastName, 
            string timeZone, 
            string taskRulesState)
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
        
        public RespondentModel With(string firstName = null,
            string lastName = null,
            string timeZone = null,
            string taskRulesState = null)
        {
            return new RespondentModel(firstName ?? FirstName, lastName ?? LastName, timeZone ?? TimeZone,
                taskRulesState ?? TaskRulesState);
        }
    }
}