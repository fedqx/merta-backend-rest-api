using DataAccessLayer.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
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

        public async Task<IEnumerable<FlatInfo>> GetAllAsync()
        {
            return await Context.FlatInfos
                .Include(p => p.FlatInfoWorksite)
                .ToListAsync();
        }

        public async Task<FlatInfo> GetByIdAsync(short IdData)
        {
            return await Context.FlatInfos
                .Where(p => p.FlatInfo_Id == IdData)
                .Include(p => p.FlatInfoWorksite)
                .FirstOrDefaultAsync();
        }
    }
}
