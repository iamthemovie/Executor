namespace Executor.Library.Providers
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class WorkflowModel
    {
        /// <summary>
        /// Gets or sets the workflow name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the workflow arguments
        /// </summary>
        [JsonProperty("args")]
        public string Arguments { get; set; }

        /// <summary>
        /// Gets or sets the ordered list of jobs.
        /// </summary>
        [JsonProperty("jobs")]
        public List<WorkflowModel> Jobs { get; set; }
    }
}
