using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Responses
{
    public class WorksiteResponse : BaseResponse
    {
        public WorksiteResponse(bool _Success , string _SuccessFailMessage , Worksite _WR_Worksite ) : base(_Success , _SuccessFailMessage)
        {
            this.WR_Worksite = _WR_Worksite;
        }

        public Worksite WR_Worksite { get; set; }

        public WorksiteResponse(Worksite _WR_Worksite) : this(true , string.Empty , _WR_Worksite) //Successfull
        {

        }
        //public WorksiteResponse(Worksite _WR_Worksite) : this(false , "HATA") //Failed
        //{

        //}
    }
}
