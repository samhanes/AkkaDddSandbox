namespace AkkaDddSandbox.Core.Models
{
    public class TaskId : AggregateId
    {
        public TaskId(string respondentId, string taskDefinitionId)
        {
            RespondentId = respondentId;
            TaskDefinitionId = taskDefinitionId;
        }

        public string RespondentId { get; }
        public string TaskDefinitionId { get; }

        public override string ToString()
        {
            return $"{RespondentId}:{TaskDefinitionId}";
        }
    }
}