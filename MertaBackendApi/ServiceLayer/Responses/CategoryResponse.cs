using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Responses
{
    public class CategoryResponse : BaseResponse
    {
        public Category CR_Category{ get; set; }
        public CategoryResponse(bool _Success , string _SuccessFailMessage , Category _CR_Category) : base(_Success , _SuccessFailMessage)
        {
            this.CR_Category = _CR_Category;
        }

        public CategoryResponse(Category CR_Category) : this(true , string.Empty , CR_Category)
        {

        }
        public CategoryResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {

        }
    }

    public class CategoryListResponse : BaseResponse
    {
        public IEnumerable<Category> CLR_Category { get; set; }

        public CategoryListResponse(bool _Success , string _SuccessFailMessage , IEnumerable<Category> _CLR_Category) : base(_Success , _SuccessFailMessage)
        {
            this.CLR_Category = _CLR_Category;
        }

        public CategoryListResponse(IEnumerable<Category> _CLR_Category) : this(true , string.Empty , _CLR_Category)
        {

        }

        public CategoryListResponse(string _SuccessFailMessage) : this(false , _SuccessFailMessage , null)
        {

        }
    }
}
