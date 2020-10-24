using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BackendApi.Services.Responses;
using Entities;

namespace BackendApi.Services.Abstract
{
    public interface IWorksiteService
    {
        Task<WorksiteListResponse> GetWorksiteByCategoryStageAsync(short IdData , short? IdData2);
        Task<WorksiteListResponse> GetWorksiteAllAsync();
        Task<WorksiteResponse> GetWorksiteByIdAsync(short IdData);
        Task<WorksiteResponse> CreateWorksiteAsync(Worksite WorksiteData , IEnumerable<Image> ImagesData ,IEnumerable<FlatInfo> FlatInfosData);
        Task<WorksiteResponse> DeleteWorksiteAsync(short IdData);
        Task<WorksiteResponse> UpdateWorksiteAsync(short IdData, Worksite WorksiteData);
    }
}
