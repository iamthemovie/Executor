using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Executor.Library
{
    using Executor.Library.Attributes;
    using Executor.Library.Interfaces;

    public static class Extentions
    {
        public static bool HasAttribute(this Type t, Type attr)
        {
            return t.GetCustomAttributes(attr, true).Any();
        }

        public static bool IsOf(this Type t, Type it)
        {
            return t.GetInterfaces().Any(x => x == it);
        }

        public static string GetExecutorName(this Type type)
        {
            var attr =
                Attribute.GetCustomAttributes(type)
                         .FirstOrDefault(t => t.GetType() == typeof(ExecutorAttribute)) 
                as ExecutorAttribute;

            return attr != null ? attr.Name : string.Empty;
        }

        public static IExecutor CreateInstance(this Type type)
        {
            return (IExecutor)Activator.CreateInstance(type);
        }
    }
}
