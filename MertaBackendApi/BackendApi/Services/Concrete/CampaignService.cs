using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.UnitOfWork;
using Entities;
using ServiceLayer.Abstract;
using ServiceLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public sealed class CampaignService : ICampaignService
    {
        private readonly ICampaignRepos CampaignRepos;
        private readonly IUnitOfWork UnitOfWork;
        public CampaignService(IUnitOfWork _UnitOfWork , ICampaignRepos _CampaignRepos)
        {
            this.UnitOfWork = _UnitOfWork;
            this.CampaignRepos = _CampaignRepos;
        }

        public async Task<CampaignResponse> CreateCampaignAsync(Campaign CampaignData)
        {
            try
            {
                await CampaignRepos.CreateAsync(CampaignData);
                await UnitOfWork.CompleteAsync();
                return new CampaignResponse(CampaignData);
            }
            catch (Exception Ex)
            {

                return new CampaignResponse($"Kampanya Oluşturulurken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<CampaignResponse> DeleteCampaignAsync(short IdData)
        {
            try
            {
                var Campaign = await CampaignRepos.GetByIdAsync(IdData);
                if (Campaign == null)
                {
                    return new CampaignResponse("Herhangi Bir Kampanya Bulunamadı");
                }
                await CampaignRepos.DeleteAsync(IdData);
                await UnitOfWork.CompleteAsync();
                return new CampaignResponse(Campaign);
            }
            catch (Exception Ex)
            {
                return new CampaignResponse($"Kampanya Silinirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<CampaignListResponse> GetCampaignAllAsync()
        {
            try
            {
                var Campaigns = await CampaignRepos.GetAllAsync();
                if (Campaigns.Count() == 0)
                {
                    return new CampaignListResponse("Herhangi Bir Kampanya Bulunamadı");
                }
                return new CampaignListResponse(Campaigns);
            }
            catch (Exception Ex)
            {
                return new CampaignListResponse($"Kampanyalar Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<CampaignResponse> GetCampaignByIdAsync(short IdData)
        {
            try
            {
                var Campaign = await CampaignRepos.GetByIdAsync(IdData);
                if (Campaign == null)
                {
                    return new CampaignResponse("Herhangi Bir Kampanya Bulunamadı");
                }
                return new CampaignResponse(Campaign);
            }
            catch (Exception Ex)
            {
                return new CampaignResponse($"Kampanyalar Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public Task<CampaignResponse> UpdateCampaignAsync(short IdData, Campaign CampaignData)
        {
            throw new NotImplementedException();
        }
    }
}
