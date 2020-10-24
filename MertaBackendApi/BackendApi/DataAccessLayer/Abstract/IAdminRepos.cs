using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BackendApi.DataAccessLayer.Abstract
{
    public interface IAdminRepos : ICrudRepos<Admin>
    {
        public Task<Admin> GetByIdAsync(short IdData);
    }
}
