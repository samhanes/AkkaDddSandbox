using System;

namespace AkkaDddSandbox.Core.Models
{
    public class ProtocolEventModel
    {
        public ProtocolEventModel(string eventType, DateTime dateTime, string recordedBy)
        {
            EventType = eventType;
            DateTime = dateTime;
            RecordedBy = recordedBy;
        }

        public string EventType { get; }
        public DateTime DateTime { get; }
        public string RecordedBy { get; }
    }
}