using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Abstract
{
    public interface IAdminRepos
    {
        public Task<IEnumerable<Admin>> GetAllAsync();
        public Task<Admin> GetByIdAsync(short IdData);
    }
}
