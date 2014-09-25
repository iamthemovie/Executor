using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Examples
{
    using Executor.Library.Attributes;
    using Executor.Library.Base;
    using Executor.Library.Interfaces;

    [Executor(Name = "Test Executor")]
    public class TestExecutor : ExecutorBase
    {
        public override void Run()
        {
            Console.WriteLine("HI!");
        }
    }
}
