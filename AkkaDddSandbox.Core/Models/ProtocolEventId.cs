using System;

namespace AkkaDddSandbox.Core.Models
{
    public class ProtocolEventId : AggregateId
    {
        public ProtocolEventId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}