using System;

namespace Workflow.Base.CQRS.Commands.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandHandlerAttribute : Attribute
    {
    }
}