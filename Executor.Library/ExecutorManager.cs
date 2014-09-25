namespace Executor.Library
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Executor.Library.Attributes;
    using Executor.Library.Base;
    using Executor.Library.Factories;
    using Executor.Library.Interfaces;

    public static class ExecutorManager
    {
        static ExecutorManager()
        {
            CompatibleTypes = new List<Type>();
        }

        internal static List<Type> CompatibleTypes { get; set; }

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

        public static void LoadWorkflowsDirectory(string directory)
        {
            /*  TODO: Refactor the data provider config
             */

            var instance =
                AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(a => a.GetTypes())
                    .FirstOrDefault(t => t.Name == ConfigurationManager.AppSettings["DataProvider"] && t.IsOf(typeof(IDataProvider)));

            if (instance == null)
            {
                throw new Exception("Invalid data provider");
            }

            /* Initialise/bootstrap the workflows from the models then add to the executors
             */
            var types =
                instance.CreateDataProviderInstance()
                    .GetWorkflows()
                    .Select(m => new WorkflowBase(m))
                    .Select(w => w.GetType())
                    .Where(t => t.IsOf(typeof(IExecutor)));

            CompatibleTypes.AddRange(types);
        }

        private static void Run(string name, string[] args)
        {
            ExecutorFactory.Create(name, args).Run();
        }

        public static void Run(string[] args)
        {
            if (!args.Any())
            {
                return; // throw an exception?
            }

            if (string.IsNullOrEmpty(args[0]))
            {
                return; // and here?
            }

            Run(args[0], args);
        }
    }
}
