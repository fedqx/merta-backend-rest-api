using BackendApi.DataAccessLayer.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Concrete
{
    public sealed class FlatInfoRepos : CrudGenericRepos<FlatInfo , PostgresContext> , IFlatInfoRepos
    {
        public FlatInfoRepos(PostgresContext _Context) : base(_Context)
        {

        }

        public async Task CreateRangeAsync(IEnumerable<FlatInfo> FlatInfosData)
        {
            await Context.FlatInfos.AddRangeAsync(FlatInfosData);
        } 

        public async Task<IEnumerable<FlatInfo>> GetAllAsync(short IdData)
        {
            return await Context.FlatInfos
                .Where(p => p.FlatInfoWorksite_Id == IdData)
                .Include(p => p.FlatInfoWorksite)
                .ToListAsync();
        }

        public async Task<FlatInfo> GetById(short IdData)
        {
            return await Context.FlatInfos
                .Where(p => p.FlatInfoWorksite_Id == IdData)
                .Include(p => p.FlatInfoWorksite)
                .FirstOrDefaultAsync();
        }
    }
}
