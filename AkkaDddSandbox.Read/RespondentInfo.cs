using System.Collections.Generic;
using AkkaDddSandbox.Core.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace AkkaDddSandbox.Read
{
    public class RespondentInfo
    {
        public RespondentInfo()
        {
            AuthorizedTaskDefinitionIds = new HashSet<string>();
        }
        
        [BsonId]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TimeZone { get; set; }
        public bool IsReleased { get; set; }
        public int AuthorizedTasks => AuthorizedTaskDefinitionIds.Count;

        public HashSet<string> AuthorizedTaskDefinitionIds { get; set; }

        public void AddAuthorizedTask(TaskId id)
        {
            if (!AuthorizedTaskDefinitionIds.Contains(id.TaskDefinitionId))
                AuthorizedTaskDefinitionIds.Add(id.TaskDefinitionId);
        }

        public void RemoveAuthorizedTask(TaskId id)
        {
            if (AuthorizedTaskDefinitionIds.Contains(id.TaskDefinitionId))
                AuthorizedTaskDefinitionIds.Remove(id.TaskDefinitionId);
        }

        public RespondentInfoModel ToModel()
        {
            return new RespondentInfoModel
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                TimeZone = TimeZone,
                IsReleased = IsReleased,
                AuthorizedTasks = AuthorizedTasks
            };
        }
    }
}