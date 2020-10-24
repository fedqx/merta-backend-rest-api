using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Abstract
{
    public class CrudGenericRepos<TEntity , TContext> : ICrudRepos<TEntity> 
        where TEntity : class 
        where TContext : DbContext
    {
        protected readonly TContext Context;
        public CrudGenericRepos(TContext _Context)
        {
            this.Context = _Context;
        }

        public async Task CreateAsync(TEntity Entity)
        {
            await Context.Set<TEntity>().AddAsync(Entity);
        }

        public async Task DeleteAsync(short IdData)
        {
            var Entity = await Context.Set<TEntity>().FindAsync(IdData);
            Context.Set<TEntity>().Remove(Entity);
        }

        public async Task UpdateAsync(short IdData, TEntity Entity)
        {
            var _Entity = await Context.Set<TEntity>().FindAsync(IdData);
            Context.Set<TEntity>().Attach(_Entity);
            _Entity = Entity;
            Context.Set<TEntity>().Update(_Entity);

        }
    }
}
