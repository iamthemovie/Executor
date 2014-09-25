using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Library.Attributes
{
    public class ExecutorAttribute : Attribute
    {
        public string Name { get;  set; }
        public ExecutorAttribute()
        {
        }
    }
}
