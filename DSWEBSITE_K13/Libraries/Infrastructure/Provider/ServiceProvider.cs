using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Libraries.Infrastructure
{
    /// <summary>
    /// this is unit of service access classes 
    /// </summary>
    public sealed class ServiceProvider<Object> : Infrastructure.IServiceProvider where Object : class
    {
        public ClassObject CreateServiceInstance<ClassObject>() where ClassObject : new()
        {
            return (ClassObject)Activator.CreateInstance(typeof(ClassObject), new object[] { });
        }
    }
}
