using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Library
{
    using Executor.Library.Attributes;
    using Executor.Library.Base;

    /* IN HERE FOR NOW, TAKE IT OUT.
     * Loaded inside the Library assembly so we have a test point.
     */
    [Executor(Name = "ExampleExecutor")]
    public class Example : ExecutorBase
    {
        public override void Run()
        {
            throw new NotImplementedException("I AM AN EXECUTOR!!");
        }
    }
}
