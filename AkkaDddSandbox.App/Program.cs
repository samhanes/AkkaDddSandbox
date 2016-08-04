using System;
using System.Linq;
using System.Threading;
using Akka.Actor;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Domain;
using AkkaDddSandbox.Core.Models;
using AkkaDddSandbox.Read;

namespace AkkaDddSandbox.App
{
    class Program
    {
        private static void Main(string[] args)
        {
            var system = ActorSystem.Create("sandbox");
            system.ActorOf<RespondentInfoEventDispatcher>();
            
            var aggregateTypeProvider = new AggregateTypeProvider();
            var commandDispatcher = system.ActorOf(Props.Create<CommandDispatcher>(aggregateTypeProvider), "commandDispatcher");
            
            //var model = new DomainModel("akkaDddSandbox");
            //model.RegisterHandler<RespondentInfoEventDispatcher>();

            //commandDispatcher.Tell(new CreateRespondent(new RespondentId("sam20"), "Sam", "Hanes", "EST"));
            //commandDispatcher.Tell(new UpdateName(new RespondentId("sam20"),"Schmam", "Schmanes"));
            //model.Dispatch(new UpdateTimeZone(new RespondentId("sam20"),"AST"));
            //model.Dispatch(new CreateTask(new TaskId("sam20", "doSurvey")));
            //model.Dispatch(new UpdateTaskStatus(new TaskId("sam20", "doSurvey"), "Paused"));

            Thread.Sleep(2000);
            
            var query = new RespondentInfoQuery();
            var results = query.All().ToList();

            Console.WriteLine("Press a key to terminate...");
            Console.ReadKey();
        }
    }
}
