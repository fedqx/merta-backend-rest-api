using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendApi.Services.Abstract;
using AutoMapper;
using BackendApi.Services.Responses;
using Entities;
using BackendApi.AutoMapper.Resources;
using BackendApi.Extentions;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;
        private readonly IMapper Mapper;
        public CategoryController(ICategoryService _CategoryService , IMapper _Mapper)
        {
            this.CategoryService = _CategoryService;
            this.Mapper = _Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            CategoryListResponse _CategoryListResponse = await CategoryService.GetCategoryAllAsync();
            if (_CategoryListResponse.Success)
            {
                return Ok(_CategoryListResponse.CLR_Category);
            }
            else
            {
                return BadRequest(_CategoryListResponse.SuccessFailMessage);
            }
        }

        [HttpGet("{IdData:short}")]
        public async Task<IActionResult> GetById(short IdData)
        {
            CategoryResponse _CategoryResponse = await CategoryService.GetCategoryByIdAsync(IdData);
            if (_CategoryResponse.Success)
            {
                return Ok(_CategoryResponse.CR_Category);
            }
            else
            {
                return BadRequest(_CategoryResponse.SuccessFailMessage);
            }
        }
        
        [HttpDelete("{IdData:Short}")]
        public async Task<IActionResult> DeleteById(short IdData)
        {
            CategoryResponse _CategoryResponse = await CategoryService.DeleteCategoryAsync(IdData);
            if (_CategoryResponse.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(_CategoryResponse.SuccessFailMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto _CategoryResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Category _Category =Mapper.Map<CategoryCreateDto, Category>(_CategoryResource);

                CategoryResponse CategoryResponse = await CategoryService.CreateCategoryAsync(_Category);
                if (CategoryResponse.Success)
                {
                    return Ok(CategoryResponse.CR_Category);
                }
                else
                {
                    return BadRequest(CategoryResponse.SuccessFailMessage);
                }
            }

        }



    }
}
