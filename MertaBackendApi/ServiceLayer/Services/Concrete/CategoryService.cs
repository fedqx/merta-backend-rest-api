using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using Entities;
using ServiceLayer.Abstract;
using ServiceLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepos CategoryRepos;
        private readonly IUnitOfWork UnitOfWork;
        public CategoryService(ICategoryRepos _CategoryRepos , IUnitOfWork _UnitOfWork)
        {
            this.CategoryRepos = _CategoryRepos;
            this.UnitOfWork = _UnitOfWork;
        }


        public async Task<CategoryResponse> CreateCategoryAsync(Category CategoryData)
        {
            try
            {
                await CategoryRepos.CreateAsync(CategoryData);
                await UnitOfWork.CompleteAsync();
                return new CategoryResponse(CategoryData);
            }
            catch (Exception Ex)
            {
                return new CategoryResponse($"Kategori Eklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteCategoryAsync(short IdData)
        {
            try
            {
                var Category = await CategoryRepos.GetByIdAsync(IdData);
                if (Category == null)
                {
                    return new CategoryResponse("Herhangi Bir Kategori Bulunamadı");
                }
                await CategoryRepos.DeleteAsync(IdData);
                await UnitOfWork.CompleteAsync();
                return new CategoryResponse(Category);
            }
            catch (Exception Ex)
            {
                return new CategoryResponse($"Kategori Silinirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<CategoryListResponse> GetCategoryAllAsync()
        {
            try
            {
                var Categories = await CategoryRepos.GetAllAsync();
                if (Categories.Count() == 0)
                {
                    return new CategoryListResponse("Herhangi Bir Kategori Bulunamadı");
                }
                return new CategoryListResponse(Categories);
            }
            catch (Exception Ex)
            {
                return new CategoryListResponse($"Kategoriler Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<CategoryResponse> GetCategoryByIdAsync(short IdData)
        {
            try
            {
                var Category = await CategoryRepos.GetByIdAsync(IdData);
                if (Category == null)
                {
                    return new CategoryResponse("Herhangi Bir Kategori Bulunamadı");
                }
                return new CategoryResponse(Category);
            }
            catch (Exception Ex)
            {
                return new CategoryResponse($"Kategori Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public Task<CategoryResponse> UpdateCategoryAsync(short IdData, Category CategoryData)
        {
            throw new NotImplementedException();
        }
    }
}
