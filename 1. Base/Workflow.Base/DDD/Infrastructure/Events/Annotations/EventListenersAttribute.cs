using System;

namespace Workflow.Base.DDD.Infrastructure.Events
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EventListenersAttribute : Attribute
    {

    }
}