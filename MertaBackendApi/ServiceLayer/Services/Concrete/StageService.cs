using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using Entities;
using ServiceLayer.Abstract;
using ServiceLayer.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public sealed class StageService : IStageService
    {
        private readonly IStageRepos StageRepos;
        private readonly IUnitOfWork UnitOfWork;

        public StageService(IStageRepos _StageRepos , IUnitOfWork _UnitOfWork)
        {
            this.StageRepos = _StageRepos;
            this.UnitOfWork = _UnitOfWork;
        }

        public async Task<StageResponse> CreateStageAsync(Stage StageData)
        {
            try
            {
                await StageRepos.CreateAsync(StageData);
                await UnitOfWork.CompleteAsync();
                return new StageResponse(StageData);
            }
            catch (Exception Ex)
            {
                return new StageResponse($"Aşama Yüklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<StageResponse> DeleteStageAsync(short IdData)
        {
            try
            {
                var Stage = await StageRepos.GetByIdAsync(IdData);
                if (Stage == null)
                {
                    return new StageResponse("Herhangi Bir Aşama Bulunamadı");
                }
                await StageRepos.DeleteAsync(IdData);
                return new StageResponse(Stage);
            }
            catch (Exception Ex)
            {
                return new StageResponse($"Aşama Silinirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<StageListResponse> GetStageAllAsync()
        {
            try
            {
                var Stages = await StageRepos.GetAllAsync();
                if (Stages.Count() == 0)
                {
                    return new StageListResponse("Herhangi Bir Aşama Bulunamadı");
                }
                return new StageListResponse(Stages);
            }
            catch (Exception Ex)
            {
                return new StageListResponse($"Aşamalar Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<StageResponse> GetStageByIdAsync(short IdData)
        {
            try
            {
                var Stage = await StageRepos.GetByIdAsync(IdData);
                if (Stage == null)
                {
                    return new StageResponse("Herhangi Bir Aşama Bulunamadı");
                }
                return new StageResponse(Stage);
            }
            catch (Exception Ex)
            {
                return new StageResponse($"Aşamalar Aranırken Bir Sorun Oluştu : {Ex.Message}");
            }
        }

        public Task<StageResponse> UpdateStageAsync(short IdData, Stage StageData)
        {
            throw new NotImplementedException();
        }
    }
}
