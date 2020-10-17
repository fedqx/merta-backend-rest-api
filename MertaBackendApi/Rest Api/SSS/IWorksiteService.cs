using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_Api.Responses;

namespace Rest_Api.Services
{
    public interface IWorksiteService
    {
        Task<WorksiteListResponse> ListAllAsync();
        Task<WorksiteResponse> GetByIdAsync(short IdData);
        Task<WorksiteListResponse> GetByCategoryStageAsync(short IdData , short? IdData2);
        Task<WorksiteResponse> AddAsync(Worksite Entity);
        Task<WorksiteResponse> DeleteAsync(short IdData);
        Task<WorksiteResponse> UpdateAsync(short IdData, Worksite Entity);
    }
}
