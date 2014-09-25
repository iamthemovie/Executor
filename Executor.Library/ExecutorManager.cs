using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Library
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    using Executor.Library.Attributes;
    using Executor.Library.Interfaces;

    public static class ExecutorManager
    {
        static ExecutorManager()
        {
            CompatibleTypes = new List<Type>();
        }

        private static List<Type> CompatibleTypes { get; set; } 

        /// <summary>
        /// Loads all the DLLs into the App Domain from the specified directory
        /// path.
        /// </summary>
        /// <param name="directory">Path to plugins directory.</param>
        public static void LoadPluginsDirectory(string directory)
        {
            /* We'll ensure we're checking all the directories, not just the 
             * top level so we can nest plugins.
             */
            foreach (var dll in Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    Assembly.LoadFile(Path.Combine(Environment.CurrentDirectory, dll));
                }
                catch (FileLoadException)
                {
                }
                catch (BadImageFormatException)
                {
                }
            }

            /* Load all the types from the current app domain into a type cache.
             */
            var types =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .Where(t => t.HasAttribute(typeof(ExecutorAttribute)) && t.IsOf(typeof(IExecutor)));

            CompatibleTypes.AddRange(types);
        }

        public static void Run(string name)
        {
            var type = CompatibleTypes.FirstOrDefault(t => t.GetExecutorName() == name);
            if (type == null)
            {
                throw new Exception("Executor not found execption!");
            }           
        }


    }
}
