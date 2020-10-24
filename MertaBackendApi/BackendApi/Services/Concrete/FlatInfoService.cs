using BackendApi.DataAccessLayer.Abstract;
using BackendApi.DataAccessLayer.UnitOfWork;
using Entities;
using BackendApi.Services.Abstract;
using BackendApi.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Services.Concrete
{
    public sealed class FlatInfoService : IFlatInfoService
    {
        private readonly IFlatInfoRepos FlatInfoRepos;
        private readonly IUnitOfWork UnitOfWork;

        public FlatInfoService(IFlatInfoRepos _FlatInfoRepos , IUnitOfWork _UnitOfWork)
        {
            this.FlatInfoRepos = _FlatInfoRepos;
            this.UnitOfWork = _UnitOfWork;
        }

        public async Task<FlatInfoResponse> CreateFlatInfoAsync(FlatInfo FlatInfoData)
        {
            try
            {
                await FlatInfoRepos.CreateAsync(FlatInfoData);
                await UnitOfWork.CompleteAsync();
                return new FlatInfoResponse(FlatInfoData);
            }
            catch (Exception Ex)
            {
                return new FlatInfoResponse($"Daire Bilgisi Eklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<FlatInfoListResponse> CreateFlatInfoRangeAsync(IEnumerable<FlatInfo> FlatInfosData)
        {
            try
            {
                await FlatInfoRepos.CreateRangeAsync(FlatInfosData);
                await UnitOfWork.CompleteAsync();
                return new FlatInfoListResponse(FlatInfosData);
            }
            catch (Exception Ex)
            {
                return new FlatInfoListResponse($"Daire Bilgileri Yüklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<FlatInfoResponse> DeleteFlatInfoAsync(short IdData)
        {
            try
            {
                var FlatInfo = await FlatInfoRepos.GetById(IdData);
                if (FlatInfo == null)
                {
                    return new FlatInfoResponse("Herhangi Bir Daire Bulunamadı");
                }
                await FlatInfoRepos.DeleteAsync(IdData);
                await UnitOfWork.CompleteAsync();
                return new FlatInfoResponse(FlatInfo);
            }
            catch (Exception Ex)
            {
                return new FlatInfoResponse($"Daire Silinirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<FlatInfoListResponse> GetFlatInfoAllAsync(short IdData)
        {
            try
            {
                var FlatInfos = await FlatInfoRepos.GetAllAsync(IdData);
                if (FlatInfos.Count() == 0)
                {
                    return new FlatInfoListResponse("Herhangi Bir Daire Bilgisi Bulunamadı");
                }
                return new FlatInfoListResponse(FlatInfos);
            }
            catch (Exception Ex)
            {
                return new FlatInfoListResponse($"Daireler Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public Task<FlatInfoResponse> UpdateFlatInfoAsync(short IdData, FlatInfo FlatInfoData)
        {
            throw new NotImplementedException();
        }
    }
}
