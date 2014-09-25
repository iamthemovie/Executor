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
            this.Executors = new List<IExecutor>();
        }

        public void Bootstrap(WorkflowModel model)
        {
            this.Name = model.Name;
            this.SetArguments(model.Arguments.ToArray());
            this.Executors.AddRange(model.Jobs.Select(j => ExecutorFactory.Create(j, new string[] {} )));
        }

        public override void Run()
        {
            Executors.ForEach(e => e.Run());
        }

        public string Name { get; set; }

        protected List<IExecutor> Executors { get; set; } 
    }
}
