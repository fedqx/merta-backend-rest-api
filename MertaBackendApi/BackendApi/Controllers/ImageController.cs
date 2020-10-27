using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendApi.AutoMapper.Resources;
using BackendApi.Extentions;
using BackendApi.Services.Abstract;
using BackendApi.Services.Responses;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService ImageService;
        private readonly IMapper Mapper;
        public ImageController(IImageService _ImageService , IMapper _Mapper)
        {
            this.ImageService = _ImageService;
            this.Mapper = _Mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ImageCreateDto _ImageCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                var Image = Mapper.Map<ImageCreateDto, Image>(_ImageCreateDto);
                ImageResponse _ImageResponse = await ImageService.CreateImageAsync(Image);
                if (_ImageResponse.Success)
                {
                    ImageGetDto _ImageGetDto = Mapper.Map<Image, ImageGetDto>(_ImageResponse.IR_Image);
                    _ImageGetDto.Image_Source = string.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host
                        , Request.PathBase, _ImageResponse.IR_Image.Image_Name);
                    return Ok(_ImageGetDto);
                }
                else
                {
                    return BadRequest(_ImageResponse.SuccessFailMessage);
                }
            }
        } 
        [HttpPost]
        public async Task<IActionResult> CreateRange([FromForm]IEnumerable<ImageCreateDto> _ImageCreateDtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessage());
            }
            else
            {
                var Images = Mapper.Map<IEnumerable<ImageCreateDto>, IEnumerable<Image>>(_ImageCreateDtos);
                ImageListResponse _ImageListResponse = await ImageService.CreateRangeImageAsync(Images);
                if (_ImageListResponse.Success)
                {
                    IEnumerable<ImageGetDto> _ImageGetDtos = Mapper.Map<IEnumerable<Image> , IEnumerable<ImageGetDto>>(_ImageListResponse.ILR_Image);
                    foreach (var Image in _ImageGetDtos)
                    {
                        Image.Image_Source = string.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, Image.Image_Name);
                    }
                    return Ok(_ImageGetDtos);
                }
                else
                {
                    return BadRequest(_ImageListResponse.SuccessFailMessage);
                }
            }
        }
        [HttpDelete("{IdData}")]
        public async Task<IActionResult> DeleteById(short IdData)
        {
            ImageResponse _ImageResponse = await ImageService.DeleteImageAsync(IdData);
            if (_ImageResponse.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(_ImageResponse.SuccessFailMessage);
            }
        }
        [HttpGet("{IdData}")]
        public async Task<IActionResult> GetById(short IdData)
        {
            ImageResponse _ImageResponse = await ImageService.GetImageByIdAsync(IdData);
            if (_ImageResponse.Success)
            {
                ImageGetDto _ImageGetDto = Mapper.Map<Image, ImageGetDto>(_ImageResponse.IR_Image);
                _ImageGetDto.Image_Source = string.Format("{0}://{1}{2}/Images/{3}" , Request.Scheme,Request.Host,Request.PathBase,_ImageResponse.IR_Image.Image_Name);
                return Ok(_ImageGetDto);
            }
            else
            {
                return BadRequest(_ImageResponse.SuccessFailMessage);
            }
        }
        [HttpGet("{IdData}")]
        public async Task<IActionResult> GetList(short IdData)
        {
            ImageListResponse _ImageListResponse = await ImageService.GetImagesAllAsync(IdData);
            if (_ImageListResponse.Success)
            {
                IEnumerable<ImageGetDto> _ImageGetDtos = Mapper.Map<IEnumerable<Image>, IEnumerable<ImageGetDto>>(_ImageListResponse.ILR_Image);
                foreach (var Image in _ImageGetDtos)
                {
                    Image.Image_Source = string.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, Image.Image_Name);
                }
                return Ok(_ImageGetDtos);
            }
            else
            {
                return BadRequest(_ImageListResponse.SuccessFailMessage);
            }
        }

        

    }
}
