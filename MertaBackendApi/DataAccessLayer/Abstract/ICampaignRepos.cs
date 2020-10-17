using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Abstract
{
    public interface ICampaignRepos
    {
        public Task<IEnumerable<Campaign>> GetAllAsync();
        public Task<Campaign> GetByIdAsync(short IdData);
    }
}
