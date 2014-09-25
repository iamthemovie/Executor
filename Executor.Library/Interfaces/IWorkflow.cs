namespace Executor.Library.Interfaces
{
    using Executor.Library.Providers;

    interface IWorkflow
    {
        string Name { get; set; }

        void Bootstrap(WorkflowModel model);
    }
}
