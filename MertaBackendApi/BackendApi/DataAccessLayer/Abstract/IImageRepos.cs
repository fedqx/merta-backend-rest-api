using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer.Abstract
{
    public interface IImageRepos : ICrudRepos<Image>
    {
        public Task<IEnumerable<Image>> GetAllAsync(short IdData);
        public Task<Image> GetByIdAsync(short IdData);
        public Task CreateRangeAsync(IEnumerable<Image> ImagesData);
    }
}
