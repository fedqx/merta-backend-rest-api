using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_Api.Responses
{
    public class BaseResponse
    {
        public BaseResponse(bool _Success , string _SuccessFailMessage)
        {
            this.Success = _Success;
            this.SuccessFailMessage = _SuccessFailMessage;
        }

        public bool Success { get; set; }
        public string SuccessFailMessage { get; set; }


    }
}
