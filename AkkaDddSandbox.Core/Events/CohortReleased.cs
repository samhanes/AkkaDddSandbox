using System;
using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Events
{
    public class CohortReleased : IDomainEvent
    {
        public CohortReleased(DateTime dateTimeReleased)
        {
            DateTimeReleased = dateTimeReleased;
        }

        public DateTime DateTimeReleased { get; }
    }
}