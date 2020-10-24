using BackendApi.DataAccessLayer.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.Concrete
{
    public sealed class AdminRepos : CrudGenericRepos<Admin, PostgresContext>/* , IAdminRepos*/
    {
        public AdminRepos(PostgresContext _Context) : base(_Context)
        {

        }

        //public async Task<IEnumerable<Admin>> GetAllAsync()
        //{
        //    return await Context.Admins
        //        .ToListAsync();
        //}

        //public async Task<Admin> GetByIdAsync(short IdData)
        //{
        //    return await Context.Admins
        //        .Where(p => p.Admin_Id == IdData)
        //        .FirstOrDefaultAsync();
        //}
    }
}
