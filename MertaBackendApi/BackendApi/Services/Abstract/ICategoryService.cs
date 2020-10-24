using BackendApi.DataAccessLayer.Concrete;
using Entities;
using BackendApi.Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.Services.Abstract
{
    public interface ICategoryService
    {
        public Task<CategoryListResponse> GetCategoryAllAsync();
        public Task<CategoryResponse> GetCategoryByIdAsync(short IdData);
        public Task<CategoryResponse> CreateCategoryAsync(Category CategoryData);
        public Task<CategoryResponse> DeleteCategoryAsync(short IdData);
        public Task<CategoryResponse> UpdateCategoryAsync(short IdData , Category CategoryData);
    }
}
