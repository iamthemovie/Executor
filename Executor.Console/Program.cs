using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Console
{
    using Executor.Library;

    using Console = System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            /* Create an instance of the ExecutorManager
             */
            ExecutorManager.LoadPluginsDirectory("plugins");

            /* Load assemblies into it from configuration.
             */
            ExecutorManager.Run("Test Executor");

            /* Take
             */
            Console.ReadLine();
        }
    }
}
