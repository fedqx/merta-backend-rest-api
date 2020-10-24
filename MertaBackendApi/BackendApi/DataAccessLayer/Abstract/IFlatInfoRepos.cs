using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BackendApi.DataAccessLayer.Abstract
{
    public interface IFlatInfoRepos : ICrudRepos<FlatInfo>
    {
        public Task<IEnumerable<FlatInfo>> GetAllAsync(short IdData);
        public Task CreateRangeAsync(IEnumerable<FlatInfo> FlatInfosData);
        public Task<FlatInfo> GetById(short IdData);
    }
}
