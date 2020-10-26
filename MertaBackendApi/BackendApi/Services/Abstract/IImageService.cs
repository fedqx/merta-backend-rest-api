﻿using Entities;
using BackendApi.Services.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendApi.Services.Abstract
{
    public interface IImageService
    {
        Task<ImageResponse> CreateImageAsync(Image ImageData , IFormFile ImageFile);
        Task<ImageListResponse> CreateRangeImageAsync(IEnumerable<Image> ImagesData , IFormFileCollection ImagesFile);
        Task<ImageResponse> DeleteImageAsync(short IdData);
        Task<ImageResponse> GetImageByIdAsync(short IdData);
        Task<ImageListResponse> GetImagesAllAsync(short IdData);
        Task<ImageResponse> UpdateImageAsync(short IdData , Image ImageData , IFormFile ImageFile);
    }
}
