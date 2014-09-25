using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Library.Base
{
    using Executor.Library.Interfaces;

    public abstract class ExecutorBase : IExecutor
    {
        public string[] Arguments { get; protected set; }

        public abstract void Run();

        public void SetArguments(string[] arguments)
        {
            /* This needs to be immutable after setting it... todo.
             */
            this.Arguments = arguments;
        }
    }
}
