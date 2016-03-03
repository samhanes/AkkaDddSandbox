using System;
using Akka.Actor;
using Akka.Configuration;
using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Domain;
using AkkaDddSandbox.Core.Models;

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
            //var system = ActorSystem.Create("MySystem", config);
            //var sl = system.ActorOf(Props.Create(() => new Respondent(new RespondentId("slId"))));
            //sl.Tell(new InitializeRespondent(new RespondentId("slId"), "Sam", "Schmanes", "EST"));

            var model = new DomainModel("akkaDddSandbox", config);
            //model.Dispatch(new InitializeRespondent(new RespondentId("sam"), "Sam", "Hanes", "EST"));
            model.Dispatch(new UpdateName(new RespondentId("sam"),"Schmam", "Schmanes"));
            
            Console.WriteLine("Press a key to terminate...");
            Console.ReadKey();

            // producing read models - how can a handler listen for the equivalent of aggregatemodified events?
            // plumbing: config file, etc
            
        }
    }
}
