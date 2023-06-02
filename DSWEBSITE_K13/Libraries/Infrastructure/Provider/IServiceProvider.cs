using System;
namespace DSWEBSITE_K13.Libraries.Infrastructure
{

    public interface IServiceProvider
    {
        ClassObject CreateServiceInstance<ClassObject>() where ClassObject : new();
    }

}
