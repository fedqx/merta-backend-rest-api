using BackendApi.DataAccessLayer.Abstract;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Concrete
{
    public sealed class ImageRepos: IImageRepos
    {
        private readonly IWebHostEnvironment WHEnviroment;
        private readonly PostgresContext Context;
        public ImageRepos(PostgresContext _Context, IWebHostEnvironment _WHEnviroment)
        {
            this.Context = _Context;
            this.WHEnviroment = _WHEnviroment;
        }

        public async Task CreateAsync(Image ImageData)
        {
            ImageData.Image_Name = Path.GetFileNameWithoutExtension(ImageData.Image_File.FileName)
                + DateTime.Now.Ticks + Path.GetExtension(ImageData.Image_File.FileName);
            var Image = ImageData.Image_File;
            string ImagePath = Path.Combine(WHEnviroment.ContentRootPath, "Images", ImageData.Image_Name);
            using (FileStream _Stream = new FileStream(ImagePath , FileMode.Create))
            {
                await Image.CopyToAsync(_Stream);
            }
            await Context.Images.AddAsync(ImageData);
        }

        public async Task CreateRangeAsync(IEnumerable<Image> ImagesData)
        {
            foreach (var ImageData in ImagesData)
            {
                ImageData.Image_Name = Path.GetFileNameWithoutExtension(ImageData.Image_File.FileName)
                    + DateTime.Now.Ticks + Path.GetExtension(ImageData.Image_File.FileName);
                
                var Image = ImageData.Image_File;
                string ImagePath = Path.Combine(WHEnviroment.ContentRootPath, "Images", ImageData.Image_Name);
                using (FileStream _Stream = new FileStream(ImagePath , FileMode.Create))
                {
                    await Image.CopyToAsync(_Stream);
                }
                await Task.Delay(1000);
            }
            await Context.Images.AddRangeAsync(ImagesData);
        }
        public async Task<IEnumerable<Image>> GetAllAsync(short IdData)
        {
            return await Context.Images.Where(p => p.ImageWorksite_Id == IdData)
                .ToListAsync();
        }

        public async Task<Image> GetByIdAsync(short IdData)
        {
            return await Context.Images
                .Where(p => p.Image_Id == IdData)
                .FirstOrDefaultAsync();
        }

        public Task UpdateAsync(short IdData, Image ImageData)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(short IdData)
        {
            var ImageData = await Context.Images.FindAsync(IdData);
            string ImagePath = Path.Combine(WHEnviroment.ContentRootPath, "Images", ImageData.Image_Name); 
            if (File.Exists(ImagePath))
            {
                File.Delete(ImagePath);
                Context.Images.Remove(ImageData);
            }


        }
    }
}
