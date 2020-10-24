using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Abstract
{
    public interface IWorksiteRepos : ICrudRepos<Worksite>
    {
        Task<IEnumerable<Worksite>> GetByCategoryStageAsync(short IdData , short? IdData2);
        Task<Worksite> GetByIdAsync(short IdData);
        Task<IEnumerable<Worksite>> GetAllAsync();
    }
}
