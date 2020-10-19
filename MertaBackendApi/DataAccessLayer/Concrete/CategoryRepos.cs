using DataAccessLayer.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public sealed class CategoryRepos : CrudGenericRepos<Category , PostgresContext> , ICategoryRepos
    {
        public CategoryRepos(PostgresContext _Context) : base(_Context)
        {

        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await Context.Categories
                .Include(p => p.CategoryWorksites)
                .ThenInclude(p => p.WorksiteImages)
                .Include(p => p.CategoryWorksites)
                .ThenInclude(p => p.WorksiteFlatInfos)
                .Include(p => p.CategoryWorksites)
                .ThenInclude(p => p.WorksiteStage)
                .ToListAsync();
        }

        public async Task<Category> GetByIdAsync(short IdData)
        {
            return await Context.Categories
                .Where(p => p.Category_Id == IdData)
                .Include(p => p.CategoryWorksites)
                .ThenInclude(p => p.WorksiteImages)
                .Include(p => p.CategoryWorksites)
                .ThenInclude(p => p.WorksiteFlatInfos)
                .Include(p =>  p.CategoryWorksites)
                .ThenInclude(p => p.WorksiteStage)
                .FirstOrDefaultAsync();
        }

    }
}
