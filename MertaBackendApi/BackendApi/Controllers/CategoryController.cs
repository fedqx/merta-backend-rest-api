using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendApi.Services.Abstract;
using AutoMapper;

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


    }
}
