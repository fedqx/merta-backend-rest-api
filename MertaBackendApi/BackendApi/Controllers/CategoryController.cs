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
        public async Task<IActionResult> GetList() // KATEGORİ BİLGİLERİNİ GETİR
        {
            CategoryListResponse _CategoryListResponse = await CategoryService.GetCategoryAllAsync();
            if (_CategoryListResponse.Success)
            {
                IEnumerable<CategoryGetDto> _CategoryGetDto = Mapper.Map<IEnumerable<Category>,IEnumerable<CategoryGetDto>>(_CategoryListResponse.CLR_Category);
                return Ok(_CategoryGetDto);
            }
            else
            {
                return BadRequest(_CategoryListResponse.SuccessFailMessage);
            }
        }

        [HttpGet("{IdData:short}")]
        public async Task<IActionResult> GetById(short IdData) // KATEGORİ BİLGİSİNİ ID`YE GÖRE GETİR
        {
            CategoryResponse _CategoryResponse = await CategoryService.GetCategoryByIdAsync(IdData);
            if (_CategoryResponse.Success)
            {
                CategoryGetDto _CategoryGetDto = Mapper.Map<Category, CategoryGetDto>(_CategoryResponse.CR_Category);
                return Ok(_CategoryGetDto);
            }
            else
            {
                return BadRequest(_CategoryResponse.SuccessFailMessage);
            }
        }
        
        [HttpDelete("{IdData:Short}")]
        public async Task<IActionResult> DeleteById(short IdData) // KATEGORİ BİLGİSİNİ SİL
        {
            CategoryResponse _CategoryResponse = await CategoryService.DeleteCategoryAsync(IdData);
            if (_CategoryResponse.Success)
            {
                CategoryGetDto _CategoryGetDto = Mapper.Map<Category, CategoryGetDto>(_CategoryResponse.CR_Category);
                return Ok(_CategoryGetDto);
            }
            else
            {
                return BadRequest(_CategoryResponse.SuccessFailMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto _CategoryResource) // YENİ KATEGORİ BİLGİSİ OLUŞTUR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Category _Category =Mapper.Map<CategoryCreateDto, Category>(_CategoryResource);

                CategoryResponse _CategoryResponse = await CategoryService.CreateCategoryAsync(_Category);
                if (_CategoryResponse.Success)
                {
                    return Ok(_CategoryResource);
                }
                else
                {
                    return BadRequest(_CategoryResponse.SuccessFailMessage);
                }
            }

        }



    }
}
