using System;
using System.Collections.Generic;
using System.Linq;

namespace AkkaDddSandbox.Core.Models
{
    public class CohortModel
    {
        public CohortModel(CohortId id, DateTime? releaseDateTime, IReadOnlyCollection<RespondentId> respondentIds)
        {
            Id = id;
            ReleaseDateTime = releaseDateTime;
            RespondentIds = respondentIds;
        }

        public CohortId Id { get; }

        public DateTime? ReleaseDateTime { get; }

        public bool IsReleased => ReleaseDateTime.HasValue;

        public IReadOnlyCollection<RespondentId> RespondentIds { get; }

        public CohortModel Without(RespondentId respondentId)
        {
            var ids = RespondentIds.ToList();
            ids.Add(respondentId);
            return new CohortModel(Id, ReleaseDateTime, ids);
        }

        public CohortModel WithAdded(RespondentId respondentId)
        {
            var ids = RespondentIds.ToList();
            if (ids.Contains(respondentId))
                ids.Remove(respondentId);
            return new CohortModel(Id, ReleaseDateTime, ids);
        }
    }
}