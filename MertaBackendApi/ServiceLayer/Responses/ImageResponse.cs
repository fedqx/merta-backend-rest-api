using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Responses
{
    public class ImageResponse : BaseResponse
    {
        public Image IR_Image { get; set; }
        public ImageResponse(bool _Success , string _SuccessFailMessage , Image _IR_Image) : base(_Success , _SuccessFailMessage)
        {
            this.IR_Image = _IR_Image;
        }
        public ImageResponse(Image _IR_Image) : this(true , string.Empty , _IR_Image)
        {

        }
        public ImageResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {

        }
    }

    public class ImageListResponse : BaseResponse
    {
        public IEnumerable<Image> ILR_Image { get; set; }
        public ImageListResponse(bool _Success , string _SuccessFailMessage , IEnumerable<Image> _ILR_Image) : base(_Success , _SuccessFailMessage)
        {
            this.ILR_Image = _ILR_Image;
        }
        public ImageListResponse(IEnumerable<Image> _ILR_Image) : this(true , string.Empty , _ILR_Image)
        {

        }
        public ImageListResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage  , null)
        {

        }
    }
}
