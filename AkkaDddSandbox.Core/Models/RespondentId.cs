namespace AkkaDddSandbox.Core.Models
{
    public class RespondentId : AggregateId
    {
        public RespondentId(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public override string ToString()
        {
            return Id;
        }
    }
}