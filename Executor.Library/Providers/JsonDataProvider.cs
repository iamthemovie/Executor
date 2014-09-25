namespace Executor.Library.Providers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Executor.Library.Interfaces;

    using Newtonsoft.Json;
    using System;

    public class JsonDataProvider : IDataProvider
    {
        public JsonDataProvider(string directory)
        {
            this.Directory = directory;
        }

        /// <summary>
        /// Gets or sets the file system directory to parse JSON files.
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Retrieves a collection of workflows from a directory containing JSON files.
        /// </summary>
        /// <returns>The collection of workflow models.</returns>
        public IEnumerable<WorkflowModel> GetWorkflows()
        {
            /* Null reference exceptions dude...
             */
            if (string.IsNullOrEmpty(this.Directory))
            {
                return new List<WorkflowModel>();
            }

            return System.IO.Directory.GetFiles(this.Directory, "*.json").Select(
                f =>
                    {
                        using (var reader = new StreamReader(f))
                        {
                            return JsonConvert.DeserializeObject<WorkflowModel>(reader.ReadToEnd());
                        }
                    });
        }

        public WorkflowModel GetWorkflow(int index)
        {
            using (var reader = new StreamReader(System.IO.Directory.GetFiles(this.Directory, "*.json").First()))
            {
                return JsonConvert.DeserializeObject<WorkflowModel>(reader.ReadToEnd());
            }
        }
    }
}
