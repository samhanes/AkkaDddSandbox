using System;
using System.Linq;
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
            var model = new DomainModel("akkaDddSandbox");
            model.RegisterHandler<RespondentInfoEventDispatcher>();

            model.Dispatch(new CreateRespondent(new RespondentId("sam7"), "Sam", "Hanes", "EST"));
            //model.Dispatch(new UpdateName(new RespondentId("sam6"),"Schmam", "Schmanes"));
            //model.Dispatch(new UpdateTimeZone(new RespondentId("sam6"),"AST"));
            
            var query = new RespondentInfoQuery();
            var results = query.All().ToList();

            Console.WriteLine("Press a key to terminate...");
            Console.ReadKey();

            // producing read models - how can a handler listen for the equivalent of aggregatemodified events?            
        }
    }
}
