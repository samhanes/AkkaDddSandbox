using Akka.Actor;
using Akka.Persistence;
using AkkaDddSandbox.Core.Events;
using AkkaDddSandbox.Core.Models;
using MongoDB.Driver;

namespace AkkaDddSandbox.Read
{
    public class RespondentInfoProjectionHandler : ReceiveActor
    {
        private readonly RespondentInfo _state;
        private readonly IMongoCollection<RespondentInfo> _collection;

        public RespondentInfoProjectionHandler(RespondentId id)
        {
            var db = new MongoClient().GetDatabase("AkkaDddRead");
            _collection = db.GetCollection<RespondentInfo>("respondentInfo");

            _state = FetchFromDb(id) ?? new RespondentInfo { Id = id.Id };
            
            Receive<RespondentCreated>(msg =>
            {
                _state.FirstName = msg.FirstName;
                _state.LastName = msg.LastName;
                _state.TimeZone = msg.TimeZone;
                Publish();
            });

            Receive<RespondentNameUpdated>(msg =>
            {
                _state.FirstName = msg.UpdatedFirst;
                _state.LastName = msg.UpdatedLast;
                Publish();
            });

            Receive<RespondentTimeZoneUpdated>(msg =>
            {
                _state.TimeZone = msg.UpdatedTimeZone;
                Publish();
            });

            Receive<TaskCreated>(msg =>
            {
                _state.AuthorizedTaskDefinitionIds.Add(msg.Id.TaskDefinitionId);
                Publish();
            });

            Receive<TaskStatusUpdated>(msg =>
            {
                if (msg.NewStatus == "Authorized")
                    _state.AddAuthorizedTask(msg.Id);
                else
                    _state.RemoveAuthorizedTask(msg.Id);
                Publish();
            });

            Receive<RespondentAddedToCohort>(msg =>
            {
                _state.IsReleased = msg.IsCohortReleased;
                Publish();
            });

            Receive<RespondentRemovedFromCohort>(msg =>
            {
                _state.IsReleased = false;
                Publish();
            });

            Receive<CohortReleased>(msg =>
            {
                _state.IsReleased = true;
                Publish();
            });
        }

        private RespondentInfo FetchFromDb(RespondentId id)
        {
            return _collection.Find(info => info.Id == id.Id).FirstOrDefault();
        }

        private void Publish()
        {
            _collection.ReplaceOne(info => info.Id == _state.Id, _state, new UpdateOptions { IsUpsert = true });
        }
    }

    public class RespondentInfoRebuilder : ReceiveActor
    {
        private IActorRef _journal;

        public RespondentInfoRebuilder()
        {
            var ext = Persistence.Instance.Apply(Context.System);
            _journal = ext.JournalFor(null);

            Receive<RebuildRespondentInfo>(msg =>
            {
                //var query = new Query(new PersistenceIdRange());
            });
        }
    }

    public class RebuildRespondentInfo
    {
        public RebuildRespondentInfo(RespondentId id)
        {
            Id = id;
        }

        public RespondentId Id { get; }
    }
}