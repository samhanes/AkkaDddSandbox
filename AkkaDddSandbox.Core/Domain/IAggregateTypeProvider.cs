using System;

namespace AkkaDddSandbox.Core.Domain
{
    public interface IAggregateTypeProvider
    {
        /// <summary>
        /// Finds type of aggregate that accepts commands of the supplied type.  Throws if no handler is found.
        /// </summary>
        /// <param name="commandType">The type of the command to be handled.</param>
        /// <returns>The type of the AggregateRoot actor.</returns>
        Type GetAggregateType(Type commandType);
    }
}