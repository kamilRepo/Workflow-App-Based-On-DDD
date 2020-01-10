namespace Workflow.Base.DDD.Sagas
{
    public interface ISagaManager
    {
        void ProcessMessage<T>(T message);
    }
}