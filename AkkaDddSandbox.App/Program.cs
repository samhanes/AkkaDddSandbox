using System;
using AkkaDddSandbox.Core.Commands;
using AkkaDddSandbox.Core.Domain;
using AkkaDddSandbox.Core.Models;

namespace AkkaDddSandbox.App
{
    class Program
    {
        private static void Main(string[] args)
        {
            var model = new DomainModel("akkaDddSandbox");
            //model.Dispatch(new InitializeRespondent(new RespondentId("sam"), "Sam", "Hanes", "EST"));
            //model.Dispatch(new UpdateName(new RespondentId("sam"),"Schmam", "Schmanes"));
            model.Dispatch(new UpdateTimeZone(new RespondentId("sam"),"AST"));
            
            Console.WriteLine("Press a key to terminate...");
            Console.ReadKey();

            // producing read models - how can a handler listen for the equivalent of aggregatemodified events?            
        }
    }
}
