using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BackendApi.DataAccessLayer.Abstract
{
    public interface ICampaignRepos : ICrudRepos<Campaign>
    {
        public Task<IEnumerable<Campaign>> GetAllAsync();
        public Task<Campaign> GetByIdAsync(short IdData);
    }
}
