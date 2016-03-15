using System.Collections.Generic;
using System.Security.Policy;
using Akka.Actor;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace AkkaDddSandbox.Core
{
    public class ProtocolRulesEventDispatcher : ReceiveActor
    {
        // listen to events that could trigger task rules
        // run rules
        // dispatch commands to create transition events, update respondent rules state, perform entry actions

        public ProtocolRulesEventDispatcher()
        {
            Context.System.EventStream.Subscribe(Self, typeof (RespondentEvent));
        }
    }

    public class ProtocolRulesRespondentModel
    {
        [BsonId]
        public RespondentId RespondentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TimeZone { get; set; }
        public bool IsReleased { get; set; }
        public List<ProtocolRulesTaskModel> Tasks { get; }
    }

    public class ProtocolRulesTaskModel
    {
        [BsonId]
        public TaskId Id { get; set; }
    }
}
