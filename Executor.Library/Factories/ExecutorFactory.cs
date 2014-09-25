namespace Executor.Library.Factories
{
    using System;
    using System.Linq;

    using Executor.Library.Base;
    using Executor.Library.Interfaces;

    public static class ExecutorFactory
    {
        public static IExecutor Create(string name, string[] args)
        {
            var type = ExecutorManager.CompatibleTypes.FirstOrDefault(t => t.GetExecutorName() == name);
            if (type == null)
            {
                throw new Exception("Executor not found exception!");
            }

            /* Create and instance and run it, but if it has a base somewhere
             * underneath of the ExecutorBase then we can inject settings and
             * other things into.
             */
            var instance = type.CreateExecutorInstance();
            if (instance.GetType().IsSubclassOf(typeof(ExecutorBase)))
            {
                var executor = (ExecutorBase)instance;
                executor.SetArguments(args);
                return executor;
            }

            throw new Exception("Invalid Executor Type!");
        }
    }
}
