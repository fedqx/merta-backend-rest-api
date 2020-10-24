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
    public sealed class CampaignRepos : CrudGenericRepos<Campaign , PostgresContext> , ICampaignRepos
    {
        public CampaignRepos(PostgresContext _Context) : base(_Context)
        {

        }

        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            return await Context.Campaigns
                .Include(p => p.CampaignWorksite)
                .ToListAsync();
        }

        public async Task<Campaign> GetByIdAsync(short IdData)
        {
            return await Context.Campaigns
                .Where(p => p.Campaign_Id == IdData)
                .Include(p => p.CampaignWorksite)
                .FirstOrDefaultAsync();
        } 

    }
}
