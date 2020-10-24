using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.Services.Responses
{
    public class StageResponse : BaseResponse
    {
        public Stage SR_Stage { get; set; }
        private StageResponse(bool _Success , string _SuccessFailMessage , Stage _SR_Stage) : base(_Success , _SuccessFailMessage)
        {
            this.SR_Stage = _SR_Stage;
        }

        public StageResponse(Stage _SR_Stage) : this(true , string.Empty , _SR_Stage)
        {
            
        }
        public StageResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {

        }
    }
    public class StageListResponse : BaseResponse
    {
        public IEnumerable<Stage> SLR_Stage { get; set; }
        private StageListResponse(bool _Success , string _SuccessFailMessage , IEnumerable<Stage> _SLR_Stage) : base(_Success , _SuccessFailMessage)
        {
            this.SLR_Stage = _SLR_Stage;
        }
        public StageListResponse(IEnumerable<Stage> _SLR_Stage) : this(true, string.Empty, _SLR_Stage)
        {
            
        }
        public StageListResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {

        }
    }
}
