using System;
using System.Collections.Generic;
using System.Linq;
using AkkaDddSandbox.Core.Aggregates;
using AkkaDddSandbox.Core.Interfaces;

namespace AkkaDddSandbox.Core.Domain
{
    public class AggregateTypeProvider : IAggregateTypeProvider
    {
        private static readonly Dictionary<Type, Type> CommandAggregateDictionary;  // <commandType, aggregateType>

        static AggregateTypeProvider()
        {
            CommandAggregateDictionary = BuildCommandAggregateDictionary(FindAllAggregates(), FindAllCommands());
        }

        public Type GetAggregateType(Type commandType)
        {
            if (!CommandAggregateDictionary.ContainsKey(commandType))
                throw new KeyNotFoundException($"Handler not found for command type {commandType}");

            return CommandAggregateDictionary[commandType];
        }

        private static Dictionary<Type, Type> BuildCommandAggregateDictionary(IEnumerable<Type> aggregateTypes, List<Type> commandTypes)
        {
            var dict = new Dictionary<Type, Type>();

            foreach (var aggregateType in aggregateTypes)
            {
                foreach (var command in FindCommandsHandledByAggregate(aggregateType, commandTypes))
                    dict.Add(command, aggregateType);
            }

            return dict;
        }

        private static IEnumerable<Type> FindAllAggregates()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(AggregateRoot).IsAssignableFrom(p))
                .Where(t => !t.IsAbstract);
        }

        private static List<Type> FindAllCommands()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => typeof(IDomainCommand).IsAssignableFrom(t))
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .ToList();
        }

        private static IEnumerable<Type> FindCommandsHandledByAggregate(Type aggregateType, List<Type> commandTypes)
        {
            var handledCommandTypes =
                aggregateType.GetInterfaces()
                    .Where(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
                    .Select(ch => ch.GetGenericArguments().First());

            return commandTypes.Where(ct => handledCommandTypes.Any(hct => hct.IsAssignableFrom(ct)));
        }
    }
}