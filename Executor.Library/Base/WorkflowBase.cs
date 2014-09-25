namespace Executor.Library.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Executor.Library.Factories;
    using Executor.Library.Interfaces;
    using Executor.Library.Providers;

    public class WorkflowBase : ExecutorBase, IWorkflow
    {
        public WorkflowBase()
        {
        }

        public WorkflowBase(WorkflowModel model)
        {
            Executors = new List<IExecutor>();
            this.Bootstrap(model);
        }

        public void Bootstrap(WorkflowModel model)
        {
            this.Name = model.Name;
            this.SetArguments(model.Arguments.ToArray());
            this.Executors.AddRange(model.Jobs.Select(j => ExecutorFactory.Create(j, null)));
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public string Name { get; set; }

        protected List<IExecutor> Executors { get; set; } 
    }
}
