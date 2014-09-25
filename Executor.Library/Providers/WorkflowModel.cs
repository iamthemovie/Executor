namespace Executor.Library.Providers
{
    using System.Collections.Generic;

    public class WorkflowModel
    {
        /// <summary>
        /// Gets or sets the ordered list of jobs.
        /// </summary>
        public List<string> Jobs { get; set; }

        /// <summary>
        /// Gets or sets the workflow name.
        /// </summary>
        public string Name { get; set; }
    }
}
