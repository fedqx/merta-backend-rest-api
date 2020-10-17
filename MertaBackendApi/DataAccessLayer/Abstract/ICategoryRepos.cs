using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Abstract
{
    interface ICategoryRepos : ICrudRepos<Category>
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category> GetByIdAsync(short IdData);
    }
}
