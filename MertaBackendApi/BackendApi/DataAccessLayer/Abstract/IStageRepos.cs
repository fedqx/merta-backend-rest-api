using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Abstract
{
    public interface IStageRepos : ICrudRepos<Stage>
    {
        Task<IEnumerable<Stage>> GetAllAsync();
        Task<Stage> GetByIdAsync(short IdData);
    }
}
