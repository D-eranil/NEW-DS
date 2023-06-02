using DSWEBSITE_K13.Services.Interface;
using DSWEBSITE_K13.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Services.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        public IPageService PageService { get; private set; }
       

        public UnitOfWork()
        {
            InitializeRepositories();
        }

        private void InitializeRepositories()
        {
            PageService = new PageService();
           
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
