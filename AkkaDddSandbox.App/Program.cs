using System;
using Akka.Actor;
using Akka.Configuration;
using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Commands;

namespace AkkaDddSandbox.App
{
    class Program
    {
        private static void Main(string[] args)
        {
            var config = ConfigurationFactory.ParseString(@"akka.persistence{
  journal {
    plugin = ""akka.persistence.journal.sql-server""
    sql-server {
        class = ""Akka.Persistence.SqlServer.Journal.SqlServerJournal, Akka.Persistence.SqlServer""
        schema-name = dbo
        auto-initialize = on
        connection-string = ""Data Source=(LocalDB)\\mssqllocaldb;database=AkkaDdd;Integrated Security=True""
    }
}
snapshot-store{
    plugin = ""akka.persistence.snapshot-store.sql-server""
    sql-server {
        class = ""Akka.Persistence.SqlServer.Snapshot.SqlServerSnapshotStore, Akka.Persistence.SqlServer""
        schema-name = dbo
        auto-initialize = on
        connection-string = ""Data Source=(LocalDB)\\mssqllocaldb;database=AkkaDdd;Integrated Security=True""
    }
  }
}");

            var system = ActorSystem.Create("MySystem", config);
            var sl = system.ActorOf(Props.Create(() => new Respondent("slId")));
            //sl.Tell(new InitializeRespondent("Sam", "Schmanes", "EST"));

            var state = sl.Ask(new AskState()).Result;

            sl.Tell(new UpdateName("Joe", "Hanes"));
            sl.Tell(new UpdateTimeZone("PST"));
            sl.Tell(new UpdateName("Ben", "Hanes"));
            //sl.Tell(new UpdateName("Sam", "Hanes"));
            //sl.Tell(new AskState());

            Console.ReadKey();

            // state machine in aggregate?
            // complex, multi aggregate root workflows?
            // containing domain model actor/caching or whatever ensures that aggregate roots are singletons
            // producing read models - how can a handler listen for the equivalent of aggregatemodified events?
        }
    }
}
