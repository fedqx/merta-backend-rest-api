using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using DataAccessLayer;
using ServiceLayer.Abstract;
using System.Threading.Tasks;
using ServiceLayer.Responses;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using System.Linq;

namespace ServiceLayer.Concrete
{
    public class WorksiteService : IWorksiteService
    {
        private readonly IWorksiteRepos WorksiteRepos;
        private readonly IImageRepos ImageRepos;
        private readonly IFlatInfoRepos FlatInfoRepos;
        private readonly IUnitOfWork UnitOfWork;
        public WorksiteService(IWorksiteRepos _WorksiteRepos ,IImageRepos _ImageRepos, IFlatInfoRepos _IFlatInfoRepos, IUnitOfWork _UnitOfWork)
        {
            this.WorksiteRepos = _WorksiteRepos;
            this.ImageRepos = _ImageRepos;
            this.FlatInfoRepos = _IFlatInfoRepos;
            this.UnitOfWork = _UnitOfWork;
        }

        public async Task<WorksiteResponse> CreateWorksiteAsync(Worksite WorksiteData, IEnumerable<Image> ImagesData, IEnumerable<FlatInfo> FlatInfosData)
        {
            try
            {
                await WorksiteRepos.CreateAsync(WorksiteData);
                await ImageRepos.CreateRangeAsync(ImagesData);
                await FlatInfoRepos.CreateRangeAsync(FlatInfosData);
                await UnitOfWork.CompleteAsync();
                return new WorksiteResponse(WorksiteData);
            }
            catch (Exception Ex)
            {
                return new WorksiteResponse($"Proje Eklenirken Bir Hata Oluştu : {Ex.Message}");   
            }
        }

        public async Task<WorksiteResponse> DeleteWorksiteAsync(short IdData)
        {
            try
            {
                var Worksite = await WorksiteRepos.GetByIdAsync(IdData);
                if (Worksite == null)
                {
                    return new WorksiteResponse("Herhangi Bir Proje Bulunamadı");
                }
                await WorksiteRepos.DeleteAsync(IdData);
                await UnitOfWork.CompleteAsync();
                return new WorksiteResponse(Worksite);
               
            }
            catch (Exception Ex)
            {
                return new WorksiteResponse($"Ürün Silmeye Çalışılırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<WorksiteListResponse> GetWorksiteAllAsync()
        {
            try
            {
                var Worksites = await WorksiteRepos.GetAllAsync();
                if (Worksites.Count() == 0)
                {
                    return new WorksiteListResponse("Herhangi Bir Proje Bulunamadı");
                }
                return new WorksiteListResponse(Worksites);
            }
            catch (Exception Ex)
            {
                return new WorksiteListResponse($"Projeler Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<WorksiteListResponse> GetWorksiteByCategoryStageAsync(short IdData, short? IdData2)
        {
            try
            {
                var Worksites = await WorksiteRepos.GetByCategoryStageAsync(IdData, IdData2);
                if (Worksites.Count() == 0)
                {
                    return new WorksiteListResponse("Herhangi Bir Proje Bulunamadı");
                }
                return new WorksiteListResponse(Worksites);
            }
            catch (Exception Ex)
            {
                return new WorksiteListResponse($"Projeler Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<WorksiteResponse> GetWorksiteByIdAsync(short IdData)
        {
            try
            {
                var Worksite =await WorksiteRepos.GetByIdAsync(IdData);
                if (Worksite == null)
                {
                    return new WorksiteResponse("Herhangi Bir Proje Bulunamadı");
                }
                return new WorksiteResponse(Worksite);
            }
            catch (Exception Ex)
            {
                return new WorksiteResponse($"Proje Aranırken Bir Hata Oluştu : {Ex.Message}");
            }
        }

        public async Task<WorksiteResponse> UpdateWorksiteAsync(short IdData, Worksite WorksiteData)
        {
            try
            {
                var OldWorksite = await WorksiteRepos.GetByIdAsync(IdData);
                if (OldWorksite == null)
                {
                    return new WorksiteResponse("Herhangi Bir Proje Bulunamadı");
                }
                await WorksiteRepos.UpdateAsync(IdData, WorksiteData);
                await UnitOfWork.CompleteAsync();
                var NewWorksite = await WorksiteRepos.GetByIdAsync(IdData);
                return new WorksiteResponse(NewWorksite);
            }
            catch (Exception Ex)
            {
                return new WorksiteResponse($"Proje Güncellenirken Bir Hata Oluştu : {Ex.Message}");
            }
        }
    }
}
