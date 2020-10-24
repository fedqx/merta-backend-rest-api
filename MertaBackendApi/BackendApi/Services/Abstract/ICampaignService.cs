using DataAccessLayer.Concrete;
using Entities;
using ServiceLayer.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstract
{
    interface ICampaignService
    {
        Task<CampaignResponse> GetCampaignByIdAsync(short IdData);
        Task<CampaignListResponse> GetCampaignAllAsync();
        Task<CampaignResponse> CreateCampaignAsync(Campaign CampaignData);
        Task<CampaignResponse> DeleteCampaignAsync(short IdData);
        Task<CampaignResponse> UpdateCampaignAsync(short IdData , Campaign CampaignData);
    }
}
