using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;

namespace BackendApi.DataAccessLayer.Abstract
{
    public interface IImageRepos
    {
        public Task<IEnumerable<Image>> GetAllAsync(short IdData);
        public Task<Image> GetByIdAsync(short IdData);
        public Task CreateRangeAsync(IEnumerable<Image> ImagesData);
        public Task CreateAsync(Image ImageData);
        public Task UpdateAsync(short IdData, Image ImageData);
        public Task DeleteAsync(short IdData);
    }
}
