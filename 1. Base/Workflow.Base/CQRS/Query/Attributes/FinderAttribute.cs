using System;

namespace Workflow.Base.CQRS.Query.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FinderAttribute : Attribute
    {
    }
}
