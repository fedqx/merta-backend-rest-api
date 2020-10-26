using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackendApi.Services.Abstract;
using BackendApi.Services.Responses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IActionResult> GetList(short IdData)
        {
            ImageListResponse _ImageListResponse = await ImageService.GetImagesAllAsync(IdData);
            if (_ImageListResponse.Success)
            {
                _ImageListResponse.ILR_Image
                    .Select(x => x.Image_Source == string.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, x.Image_Name));
                return Ok(_ImageListResponse.ILR_Image);
            }
            else
            {
                return BadRequest(_ImageListResponse.SuccessFailMessage);
            }
        }
        

    }
}
