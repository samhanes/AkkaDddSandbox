using System;
using System.Collections.Generic;
using Akka.Actor;
using AkkaDddSandbox.Core.Events;

namespace AkkaDddSandbox.Core.EventHandlers
{
    public class RespondentProjectionHandler : ReceiveActor, IEventHandler
    {
        private static readonly ICollection<Type> EventTypesToHandle = new[]
        {
            typeof (RespondentCreated),
            typeof (RespondentNameUpdated),
            typeof (RespondentTimeZoneUpdated)
        };

        public RespondentProjectionHandler()
        {
            foreach (var type in EventTypesToHandle)
            {
                Context.System.EventStream.Subscribe(Self, type);
            }

            Receive<RespondentCreated>(msg =>
            {
                
            });

            Receive<RespondentNameUpdated>(msg =>
            {

            });

            Receive<RespondentTimeZoneUpdated>(msg =>
            {

            });
        }
    }

    public interface IEventHandler
    {
    }
}
