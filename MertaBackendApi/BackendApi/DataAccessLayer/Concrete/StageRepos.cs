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
    public sealed class StageRepos : CrudGenericRepos<Stage , PostgresContext> , IStageRepos
    {
        public StageRepos(PostgresContext _Context) : base(_Context)
        {

        }

        public async Task<IEnumerable<Stage>> GetAllAsync()
        {
            return await Context.Stages
                .ToListAsync();
        }

        public async Task<Stage> GetByIdAsync(short IdData)
        {
            return await Context.Stages
                .Where(e => e.Stage_Id == IdData)
                .FirstOrDefaultAsync();

        }
    }
}
