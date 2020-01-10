namespace Workflow.Base.DDD.Infrastructure.Sagas
{
    public interface ISagaAction<in TMessage>
    {
        void Handle(TMessage message);
    }
}