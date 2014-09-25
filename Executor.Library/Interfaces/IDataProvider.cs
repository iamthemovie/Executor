namespace Executor.Library.Interfaces
{
    using System.Collections.Generic;

    using Executor.Library.Providers;

    internal interface IDataProvider
    {
        IEnumerable<WorkflowModel> GetWorkflows();

        WorkflowModel GetWorkflow(int index);
    }
}
