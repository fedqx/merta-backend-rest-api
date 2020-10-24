﻿using BackendApi.DataAccessLayer.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Concrete
{
    public sealed class ImageRepos : CrudGenericRepos<Image , PostgresContext> , IImageRepos
    {
        public ImageRepos(PostgresContext _Context) : base(_Context)
        {

        }

        public async Task CreateRangeAsync(IEnumerable<Image> ImagesData)
        {
            await Context.Images.AddRangeAsync(ImagesData);
        }

        public async Task<IEnumerable<Image>> GetAllAsync(short IdData)
        {
            return await Context.Images
                .Include(p => p.ImageWorksite)
                    .ThenInclude(p => p.Worksite_Id == IdData)
                .ToListAsync();
        }

        public async Task<Image> GetByIdAsync(short IdData)
        {
            return await Context.Images
                .Where(p => p.Image_Id == IdData)
                .Include(p => p.ImageWorksite)
                .FirstOrDefaultAsync();
        }
    }
}
