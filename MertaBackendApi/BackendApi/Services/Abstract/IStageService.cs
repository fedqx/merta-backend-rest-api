using BackendApi.DataAccessLayer.Concrete;
using Entities;
using BackendApi.Services.Responses;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Services.Abstract
{
    public interface IStageService
    {
        Task<StageResponse> GetStageByIdAsync(short IdData);
        Task<StageListResponse> GetStageAllAsync();
        Task<StageResponse> CreateStageAsync(Stage StageData);
        Task<StageResponse> DeleteStageAsync(short IdData);
        Task<StageResponse> UpdateStageAsync(short IdData, Stage StageData);
    }
}
