using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using Entities;
using ServiceLayer.Abstract;
using ServiceLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Concrete
{
    public sealed class ImageService : IImageService
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IImageRepos ImageRepos;
        private readonly IWorksiteRepos WorksiteRepos;

        public ImageService(IWorksiteRepos _WorksiteRepos, IImageRepos _ImageRepos, IUnitOfWork _UnitOfWork)
        {
            this.WorksiteRepos = _WorksiteRepos;
            this.ImageRepos = _ImageRepos;
            this.UnitOfWork = _UnitOfWork;
        }

        public async Task<ImageResponse> CreateImageAsync(Image ImageData)
        {
            try
            {
                await ImageRepos.CreateAsync(ImageData);
                await UnitOfWork.CompleteAsync();
                return new ImageResponse(ImageData);
            }
            catch (Exception Ex)
            {
                return new ImageResponse($"Resim Yüklenirken Bir Hata Oluştu : {Ex.Message}");
                
            }
        }

        public async Task<ImageListResponse> CreateRangeImageAsync(IEnumerable<Image> ImagesData)
        {
            try
            {
                await ImageRepos.CreateRangeAsync(ImagesData);
                await UnitOfWork.CompleteAsync();
                return new ImageListResponse(ImagesData);
            }
            catch (Exception Ex)
            {
                return new ImageListResponse($"Resimler Yüklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<ImageResponse> DeleteImageAsync(short IdData)
        {
            try
            {
                var Image = await ImageRepos.GetByIdAsync(IdData);
                if (Image == null)
                {
                    return new ImageResponse("Herhangi Bir Resim Bulunamadı");
                }
                await ImageRepos.DeleteAsync(IdData);
                await UnitOfWork.CompleteAsync();
                return new ImageResponse(Image);

            }
            catch (Exception Ex)
            {

                return new ImageResponse($"Resim Silmeye Çalışılırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<ImageResponse> GetImageByIdAsync(short IdData)
        {
            try
            {
                var Image = await ImageRepos.GetByIdAsync(IdData);
                if (Image == null)
                {
                    return new ImageResponse("Herhangi Bir Resim Bulunamadı");
                }
                return new ImageResponse(Image);
            }
            catch (Exception Ex)
            {
                return new ImageResponse($"Resim Yüklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<ImageListResponse> GetImagesAllAsync(short IdData)
        {
            try
            {
                var Images = await ImageRepos.GetAllAsync(IdData);
                if (Images.Count() == 0)
                {
                    return new ImageListResponse("Projeye Ait Herhangi Bir Resim Bulnamadı"); ;
                }
                return new ImageListResponse(Images);
            }
            catch (Exception Ex)
            {
                return new ImageListResponse($"Resimler Yüklenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public Task<ImageResponse> UpdateImageAsync(short IdData , Image ImageData)
        {
            throw new NotImplementedException();
        }
    }
}
