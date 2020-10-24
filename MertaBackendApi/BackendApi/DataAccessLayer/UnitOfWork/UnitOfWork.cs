using BackendApi.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgresContext Context;
        public UnitOfWork(PostgresContext _Context)
        {
            this.Context = _Context;
        }

        public async Task CompleteAsync()
        {
            await this.Context.SaveChangesAsync();
        }
    }
}
