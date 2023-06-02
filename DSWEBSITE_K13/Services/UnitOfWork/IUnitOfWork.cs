using DSWEBSITE_K13.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Services.UnitOfWork
{
    /// <summary>
    /// this interface for Uint of work for all exist reposiltory.
    /// </summary>
    interface IUnitOfWork :
       IDependencyConfiguration,
       IDisposable
    {
        IPageService PageService { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    interface IDependencyConfiguration
    {

    }
}
