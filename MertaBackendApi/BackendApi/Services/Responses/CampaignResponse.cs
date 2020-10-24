using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.Services.Responses
{
    public class CampaignResponse : BaseResponse
    {
        public Campaign  CR_Campaign { get; set; }

        private CampaignResponse(bool _Success , string _SuccessFailMessage , Campaign _CR_Campaign)  : base(_Success , _SuccessFailMessage)
        {
            this.CR_Campaign = _CR_Campaign;
        }

        public CampaignResponse(Campaign _CR_Campaign) : this(true , string.Empty , _CR_Campaign)
        {
            
        }

        public CampaignResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {
            
        }
    }

    public class CampaignListResponse : BaseResponse
    {
        public IEnumerable<Campaign> CLR_Campaign { get; set; }
        public CampaignListResponse(bool _Success , string _SuccessFailMessage , IEnumerable<Campaign> _CLR_Campaign) : base(_Success , _SuccessFailMessage)
        {
            this.CLR_Campaign = _CLR_Campaign;
        }

        public CampaignListResponse(IEnumerable<Campaign> _CLR_Campaign) : this(true , string.Empty , _CLR_Campaign)
        {
            
        }

        public CampaignListResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {
            
        }
    }
}
