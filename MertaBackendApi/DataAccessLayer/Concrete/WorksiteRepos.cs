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
    public sealed class WorksiteRepos : CrudGenericRepos<Worksite , PostgresContext>,IWorksiteRepos
    {
        public WorksiteRepos(PostgresContext _Context) : base(_Context)
        {

        }

        public async Task<IEnumerable<Worksite>> GetAllAsync()
        {
            return await Context.Worksites
                .Include(p => p.WorksiteCampaigns)
                .Include(p => p.WorksiteImages)
                .Include(p => p.WorksiteFlatInfos)
                .ToListAsync();
        }

        public async Task<Worksite> GetByIdAsync(short IdData)
        {

            return await Context.Worksites
                .Where(p => p.Worksite_Id == IdData)
                .Include(p => p.WorksiteCampaigns)
                .Include(p => p.WorksiteImages)
                .Include(p => p.WorksiteFlatInfos)
                .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Worksite>> GetWorksiteByCategoryStage(short IdData , short? IdData2)
        {
            if (IdData2 != null)
            {
                return await Context.Worksites
                    .Where(p => p.WorksiteCategory_Id == IdData && p.WorksiteStage_Id == IdData2)
                    .Include(p => p.WorksiteCampaigns)
                    .Include(p => p.WorksiteImages)
                    .Include(p => p.WorksiteFlatInfos)
                    .ToListAsync();
            }
            else
            {
                return await Context.Worksites
                    .Where(p => p.WorksiteCategory_Id == IdData)
                    .Include(p => p.WorksiteCampaigns)
                    .Include(p => p.WorksiteImages)
                    .Include(p => p.WorksiteFlatInfos)
                    .ToListAsync();
            }

        }
    }
}
