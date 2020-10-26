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
    public class FlatInfoController : ControllerBase
    {
        private readonly IFlatInfoService FlatInfoService;
        private readonly IMapper Mapper;
        public FlatInfoController(IFlatInfoService _FlatInfoService, IMapper _Mapper)
        {
            this.FlatInfoService = _FlatInfoService;
            this.Mapper = _Mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlatInfoCreateDto _FlatInfoCreateDto) // YENİ DAİRE BİLGİSİ OLUŞTUR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                FlatInfo _FlatInfo = Mapper.Map<FlatInfoCreateDto, FlatInfo>(_FlatInfoCreateDto);
                FlatInfoResponse _FlatInfoResponse = await FlatInfoService.CreateFlatInfoAsync(_FlatInfo);
                if (_FlatInfoResponse.Success)
                {
                    FlatInfoGetDto _FlatInfoGetDto = Mapper.Map<FlatInfo, FlatInfoGetDto>(_FlatInfo);
                    return Ok(_FlatInfoGetDto);
                }
                else
                {
                    return BadRequest(_FlatInfoResponse.SuccessFailMessage);
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateRange(ICollection<FlatInfoCreateDto> _FlatInfoCreateDtos) // YENİ DAİRE BİLGİLERİ OLUŞTUR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                IEnumerable<FlatInfo> _FlatInfos = Mapper.Map<IEnumerable<FlatInfoCreateDto>, IEnumerable<FlatInfo>>(_FlatInfoCreateDtos);
                FlatInfoListResponse _FlatInfoListResponse = await FlatInfoService.CreateFlatInfoRangeAsync(_FlatInfos);
                if (_FlatInfoListResponse.Success)
                {
                    IEnumerable<FlatInfoGetDto> _FlatInfoGetDtos = Mapper.Map<IEnumerable<FlatInfo>, IEnumerable<FlatInfoGetDto>>(_FlatInfos);
                    return Ok(_FlatInfoGetDtos);
                }
                else
                {
                    return BadRequest(_FlatInfoListResponse.SuccessFailMessage);
                }
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(short IdData) // DAİRE BİLGİSİNİ SİL
        {
            FlatInfoResponse _FlatInfoResponse = await FlatInfoService.DeleteFlatInfoAsync(IdData);
            if (_FlatInfoResponse.Success)
            {
                FlatInfoGetDto _FlatInfoGetDto = Mapper.Map<FlatInfo, FlatInfoGetDto>(_FlatInfoResponse.FIR_FlatInfo);
                return Ok(_FlatInfoGetDto);
            }
            else
            {
                return BadRequest(_FlatInfoResponse.SuccessFailMessage);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetList(short IdData) // DAİRE BİLGİLERİNİ GETİR
        {
            FlatInfoListResponse _FlatInfoListResponse = await FlatInfoService.GetFlatInfoAllAsync(IdData);
            if (_FlatInfoListResponse.Success)
            {
                IEnumerable<FlatInfoGetDto> _FlatInfoGetDtos = Mapper.Map<IEnumerable<FlatInfo>, IEnumerable<FlatInfoGetDto>>(_FlatInfoListResponse.FILR_FlatInfo);
                return Ok(_FlatInfoGetDtos);
            }
            else
            {
                return BadRequest(_FlatInfoListResponse.SuccessFailMessage);
            }
        }
        
    }
}
