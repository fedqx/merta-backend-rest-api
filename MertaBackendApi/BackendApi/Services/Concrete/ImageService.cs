using BackendApi.DataAccessLayer.Abstract;
using BackendApi.DataAccessLayer.UnitOfWork;
using Entities;
using BackendApi.Services.Abstract;
using BackendApi.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BackendApi.Services.Concrete
{
    public sealed class ImageService : IImageService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IImageRepos ImageRepos;
 
        public ImageService(IImageRepos _ImageRepos, IUnitOfWork _UnitOfWork)
        {
            this.ImageRepos = _ImageRepos;
            this.UnitOfWork = _UnitOfWork;
        }

        public Task<ImageResponse> CreateImageAsync(Image ImageData, IFormFile ImageFile)
        {
            throw new NotImplementedException();
        }

        public Task<ImageListResponse> CreateRangeImageAsync(IEnumerable<Image> ImagesData, IFormFileCollection ImagesFile)
        {
            throw new NotImplementedException();
        }

        public Task<ImageResponse> DeleteImageAsync(short IdData)
        {
            throw new NotImplementedException();
        }

        public Task<ImageResponse> GetImageByIdAsync(short IdData)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageListResponse> GetImagesAllAsync(short IdData)
        {
            try
            {
                var Images = await ImageRepos.GetAllAsync(IdData);
                if (Images.Count() == 0)
                {
                    return new ImageListResponse("Herhangi Bir Resim Bulunamadı");
                }
                return new ImageListResponse(Images);
            }
            catch (Exception Ex)
            {
                return new ImageListResponse($"Resimler Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public Task<ImageResponse> UpdateImageAsync(short IdData, Image ImageData, IFormFile ImageFile)
        {
            throw new NotImplementedException();
        }
    }
}
