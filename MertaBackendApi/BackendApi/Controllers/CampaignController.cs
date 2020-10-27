using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendApi.AutoMapper.Resources;
using BackendApi.DataAccessLayer.Abstract;
using BackendApi.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService CampaignService;
        private readonly IMapper Mapper;
        public CampaignController(ICampaignService _CampaignService, IMapper _Mapper)
        {
            this.CampaignService = _CampaignService;
            this.Mapper = _Mapper;
        }

        //[HttpGet("{IdData}")]
        //public async Task<IActionResult> GetById(short IdData)
        //{

        //}

        //[HttpGet]
        //public async Task<IActionResult> GetList()
        //{

        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(CampaignCreateDto _CampaignResource)
        //{

        //}

        //public async Task<IActionResult> Delete(short IdData)
        //{

        //}


    }
}
