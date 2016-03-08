using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.Core.Events
{
    public class CohortReleased : CohortEvent
    {
        public CohortReleased(DateTime dateTimeReleased, IReadOnlyCollection<RespondentId> respondentIds)
        {
            DateTimeReleased = dateTimeReleased;
            RespondentIds = respondentIds;
        }

        public DateTime DateTimeReleased { get; }

        public IReadOnlyCollection<RespondentId> RespondentIds { get; }
    }
}