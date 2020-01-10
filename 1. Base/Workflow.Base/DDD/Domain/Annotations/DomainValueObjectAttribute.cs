using System;

namespace Workflow.Base.DDD.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Class| AttributeTargets.Struct)]
    public class DomainValueObjectAttribute : Attribute
    {
    }
}