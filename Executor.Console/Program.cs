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
            /* Load the plugins directory.
             * - this wont be static
             * - also the examples are loaded in by reference.
             */
            ExecutorManager.LoadPluginsDirectory("plugins");

            /* For now just have the manager deal with everything but we'll
             * switch this out for a better command line parsing in later
             * updates.
             */
            ExecutorManager.Run(args);

            /* remove this
             */
            Console.ReadLine();
        }
    }
}
