using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace ServiceLayer.Responses
{
    public class WorksiteResponse : BaseResponse
    {
        public Worksite WR_Worksite { get; set; }

        private WorksiteResponse(bool _Success, string _SuccessFailMessage, Worksite _WR_Worksite) : base(_Success, _SuccessFailMessage)
        {
            this.WR_Worksite = _WR_Worksite;
        }
        public WorksiteResponse(Worksite _WR_Worksite) : this(true, string.Empty, _WR_Worksite) //Successfull
        {

        }
        public WorksiteResponse(string _SuccessFailMessage) : this(false, _SuccessFailMessage, null) //Failed
        {

        }
    }

    public class WorksiteListResponse : BaseResponse
    {
        public IEnumerable<Worksite> WLR_Worksite { get; set; }
        public WorksiteListResponse(bool _Success, string _SuccessFailMessage, IEnumerable<Worksite> _WLR_Worksite) : base(_Success, _SuccessFailMessage)
        {
            this.WLR_Worksite = _WLR_Worksite;
        }
        public WorksiteListResponse(IEnumerable<Worksite> _WLR_Worksite) : this(true, string.Empty, _WLR_Worksite)
        {

        }
        public WorksiteListResponse(string _SuccessFailMessage) : this(false, _SuccessFailMessage, null)
        {

        }
    }
}
