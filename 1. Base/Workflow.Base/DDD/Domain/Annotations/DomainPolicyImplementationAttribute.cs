using System;

namespace Workflow.Base.DDD.Domain.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DomainPolicyImplementationAttribute : Attribute
    {
    }
}