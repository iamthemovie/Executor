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
        public List<JobModel> Jobs { get; set; }
    }

    public class JobModel
    {
        /// <summary>
        /// Gets or sets the job name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the job arguments.
        /// </summary>
        [JsonProperty("args")]
        public string Arguments { get; set; }
    }
}
