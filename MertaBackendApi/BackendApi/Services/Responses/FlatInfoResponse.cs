using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApi.Services.Responses
{
    public class FlatInfoResponse : BaseResponse
    {
        public FlatInfo FIR_FlatInfo { get; set; }
        private FlatInfoResponse(bool _Success , string _SuccessFailMessage , FlatInfo  _FIR_FlatInfo ) : base(_Success , _SuccessFailMessage)
        {
            this.FIR_FlatInfo = _FIR_FlatInfo;
        }
        public FlatInfoResponse(FlatInfo _FIR_FlatInfo) : this(true , string.Empty , _FIR_FlatInfo)
        {
            
        }
        public FlatInfoResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {
            
        }
    }

    public class FlatInfoListResponse : BaseResponse
    {
        public IEnumerable<FlatInfo> FILR_FlatInfo { get; set; }
        public FlatInfoListResponse(bool _Success , string _SuccessFailMessage , IEnumerable<FlatInfo> _FILR_FlatInfo) : base(_Success , _SuccessFailMessage)
        {
            this.FILR_FlatInfo = _FILR_FlatInfo;
        }
        public FlatInfoListResponse(IEnumerable<FlatInfo> _FILR_FlatInfo) : this(true , string.Empty , _FILR_FlatInfo)
        {   
            
        }
        public FlatInfoListResponse(string  _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {

        }
    }
}
