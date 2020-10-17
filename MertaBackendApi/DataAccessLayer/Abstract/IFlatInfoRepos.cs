using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Abstract
{
    interface IFlatInfoRepos : ICrudRepos<FlatInfo>
    {
        public Task<IEnumerable<FlatInfo>> GetAllAsync();
        public Task<FlatInfo> GetByIdAsync(short IdData);
    }
}
