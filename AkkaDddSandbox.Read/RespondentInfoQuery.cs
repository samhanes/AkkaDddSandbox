using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace AkkaDddSandbox.Read
{
    public class RespondentInfoQuery
    {
        private readonly IMongoCollection<RespondentInfo> _collection;

        public RespondentInfoQuery()
        {
            var db = new MongoClient().GetDatabase("AkkaDddRead");
            _collection = db.GetCollection<RespondentInfo>("respondentInfo");
        }

        public IEnumerable<RespondentInfoModel> All()
        {
            return
                _collection.FindSync(FilterDefinition<RespondentInfo>.Empty)
                    .ToEnumerable()
                    .Select(info => info.ToModel());
        } 
    }
}
