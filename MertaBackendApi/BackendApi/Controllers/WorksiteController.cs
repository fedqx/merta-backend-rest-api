using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendApi.AutoMapper.Resources;
using BackendApi.Extentions;
using BackendApi.Services.Abstract;
using BackendApi.Services.Responses;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorksiteController : ControllerBase
    {
        private readonly IWorksiteService WorksiteService;
        private readonly IMapper Mapper;
        public WorksiteController(IWorksiteService _WorksiteService , IMapper _Mapper)
        {
            this.WorksiteService = _WorksiteService;
            this.Mapper = _Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList() // SAHA BİLGİLERİNİ GETİR
        {
            WorksiteListResponse _WorksiteListResponse = await WorksiteService.GetWorksiteAllAsync();
            if (_WorksiteListResponse.Success)
            {
                IEnumerable <WorksiteGetDto> _WorksiteGetDto= Mapper.Map<IEnumerable<Worksite>, IEnumerable<WorksiteGetDto>>(_WorksiteListResponse.WLR_Worksite);
                return Ok(_WorksiteGetDto);
            }
            else
            {
                return BadRequest(_WorksiteListResponse.SuccessFailMessage);
            }
        }
        [HttpGet("{IdData}")]
        public async Task<IActionResult> GetById(short IdData) // SAHA BİLGİSİNİ ID`YE GÖRE GETİR
        {
            WorksiteResponse _WorksiteResponse = await WorksiteService.GetWorksiteByIdAsync(IdData);
            if (_WorksiteResponse.Success)
            {
                WorksiteGetDto _WorksiteGetDto = Mapper.Map<Worksite, WorksiteGetDto>(_WorksiteResponse.WR_Worksite);
                return Ok(_WorksiteGetDto);
            }
            else
            {
                return BadRequest(_WorksiteResponse.SuccessFailMessage);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(short IdData) // SAHA BİLGİSİNİ SİL
        {
            WorksiteResponse _WorksiteResponse = await WorksiteService.DeleteWorksiteAsync(IdData);
            if (_WorksiteResponse.Success)
            {
                WorksiteGetDto _WorksiteGetDto = Mapper.Map<Worksite, WorksiteGetDto>(_WorksiteResponse.WR_Worksite);
                return Ok(_WorksiteGetDto);
            }
            else
            {
                return BadRequest(_WorksiteResponse.SuccessFailMessage);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorksiteCreateDto _WorksiteResource , IEnumerable<Image> _ImagesResource , IEnumerable<FlatInfo> _FlatInfosResource)// YENİ SAHA BİLGİSİ OLUŞTUR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Worksite _Worksite = Mapper.Map<WorksiteCreateDto, Worksite>(_WorksiteResource);
                WorksiteResponse _WorksiteResponse = await WorksiteService.CreateWorksiteAsync(_Worksite, _ImagesResource, _FlatInfosResource);
                if (_WorksiteResponse.Success)
                {
                    WorksiteGetDto _WorksiteGetDto = Mapper.Map<Worksite, WorksiteGetDto>(_Worksite);
                    return Ok(_WorksiteGetDto);
                }
                else
                {
                    return BadRequest(_WorksiteResponse.SuccessFailMessage);
                }
            }
        }
        [HttpGet("{IdData}/{IdData2}?")]
        public async Task<IActionResult> GetByCategoryStage(short IdData, short? IdData2) // SAHA BİLGİSİNİ KATEGORİ VE/VEYA EVREYE GÖRE GETİR 
        {
            WorksiteListResponse _WorksiteListResponse = await WorksiteService.GetWorksiteByCategoryStageAsync(IdData, IdData2);
            if (_WorksiteListResponse.Success)
            {
                IEnumerable<WorksiteGetDto> _WorksiteGetDto = Mapper.Map<IEnumerable<Worksite>, IEnumerable<WorksiteGetDto>>(_WorksiteListResponse.WLR_Worksite);
                return Ok(_WorksiteGetDto);
            }
            else
            {
                return BadRequest(_WorksiteListResponse.SuccessFailMessage);
            }
        }
    }
}
