using System.Collections.ObjectModel;

namespace AkkaDddSandbox.Core.Models
{
    public class RespondentModel
    {
        public RespondentModel(string firstName, 
            string lastName, 
            string timeZone, 
            string taskRulesState, 
            ReadOnlyDictionary<TaskId, TaskModel> tasks, 
            ReadOnlyDictionary<ProtocolEventId, ProtocolEventModel> protocolEvents)
        {
            FirstName = firstName;
            LastName = lastName;
            TimeZone = timeZone;
            TaskRulesState = taskRulesState;
            Tasks = tasks;
            ProtocolEvents = protocolEvents;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string TimeZone { get; }
        public string TaskRulesState { get; }

        public ReadOnlyDictionary<TaskId, TaskModel> Tasks { get; }
        public ReadOnlyDictionary<ProtocolEventId, ProtocolEventModel> ProtocolEvents { get; }
        //public ReadOnlyCollection<Appointment> Appointments { get; }
        //public ReadOnlyCollection<Assignment> Assignments { get; }
        //public ReadOnlyCollection<InstrumentResultModel> InstrumentResults {get;}    

        public RespondentModel With(string firstName = null,
            string lastName = null,
            string timeZone = null,
            string taskRulesState = null,
            ReadOnlyDictionary<TaskId, TaskModel> tasks = null,
            ReadOnlyDictionary<ProtocolEventId, ProtocolEventModel> protocolEvents = null)
        {
            return new RespondentModel(firstName ?? FirstName, lastName ?? LastName, timeZone ?? TimeZone,
                taskRulesState ?? TaskRulesState, tasks ?? Tasks, protocolEvents ?? ProtocolEvents);
        }
    }
}