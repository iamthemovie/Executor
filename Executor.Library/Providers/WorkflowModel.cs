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
        public List<string> Arguments { get; set; }

        /// <summary>
        /// Gets or sets the ordered list of jobs.
        /// </summary>
        [JsonProperty("jobs")]
        public List<string> Jobs { get; set; }
    }

    //public class JobModel
    //{
    //    /// <summary>
    //    /// Gets or sets the job name.
    //    /// </summary>
    //    [JsonProperty("name")]
    //    public string Name { get; set; }

    //    /// <summary>
    //    /// Gets or sets the job arguments.
    //    /// </summary>
    //    [JsonProperty("arguments")]
    //    public List<string> Arguments { get; set; }
    //}

    //public class WorkflowModelConverter : JsonConverter
    //{
    //    public override bool CanConvert(System.Type objectType)
    //    {
    //        return objectType.IsSubclassOf(typeof(WorkflowModel));
    //    }

    //    public override object ReadJson(JsonReader reader, System.Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        var job = new JobModel();
    //        job.Name = reader.ReadAsString();
    //        job.Arguments = reader.Array
    //    }
    //}
}
