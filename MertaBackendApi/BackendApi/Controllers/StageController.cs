using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendApi.AutoMapper.Resources;
using BackendApi.DataAccessLayer.Abstract;
using BackendApi.Extentions;
using BackendApi.Services.Abstract;
using BackendApi.Services.Responses;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IStageService StageService;
        private readonly IMapper Mapper;
        public StageController(IStageService _StageService , IMapper _Mapper)
        {
            this.StageService = _StageService;
            this.Mapper = _Mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList() // EVRE BİLGİLERİNİ GETİR
        {
            StageListResponse _StageListResponse = await StageService.GetStageAllAsync();
            if (_StageListResponse.Success)
            {
                IEnumerable<StageGetDto> _StageGetDto = Mapper.Map<IEnumerable<Stage> , IEnumerable<StageGetDto>>(_StageListResponse.SLR_Stage);
                return Ok(_StageGetDto);
            }
            else
            {
                return BadRequest(_StageListResponse.SuccessFailMessage);
            }
        }

        [HttpGet("{IdData}")]
        public async Task<IActionResult> GetById(short IdData) // EVRE BİLGİSİNİ ID`YE GÖRE GETİR
        {
            StageResponse _StageResponse = await StageService.GetStageByIdAsync(IdData);
            if (_StageResponse.Success)
            {
                StageGetDto _StageGetDto = Mapper.Map<Stage, StageGetDto>(_StageResponse.SR_Stage);
                return Ok(_StageGetDto);
            }
            else
            {
                return BadRequest(_StageResponse.SuccessFailMessage);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(StageCreateDto _StageResource) // YENİ EVRE BİLGİSİ OLUŞTUR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                Stage _Stage = Mapper.Map<StageCreateDto, Stage>(_StageResource);
                StageResponse _StageResponse = await StageService.CreateStageAsync(_Stage);
                if (_StageResponse.Success)
                {
                    return Ok(_StageResource);
                }
                else
                {
                    return BadRequest(_StageResponse.SuccessFailMessage);
                }
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteById(short IdData) // EVRE BİLGİSİNİ SİL
        {
            StageResponse _StageResponse = await StageService.DeleteStageAsync(IdData);
            if (_StageResponse.Success)
            {
                StageGetDto _StageGetDto = Mapper.Map<Stage, StageGetDto>(_StageResponse.SR_Stage);
                return Ok(_StageGetDto);
            }
            else
            {
                return BadRequest(_StageResponse.SuccessFailMessage);
            }
        }

    }
}
