using Entities;
using ServiceLayer.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Abstract
{
    public interface IFlatInfoService
    {
        public Task<FlatInfoListResponse> CreateFlatInfoRangeAsync(IEnumerable<FlatInfo> FlatInfosData);
        public Task<FlatInfoListResponse> GetFlatInfoAllAsync(short IdData);
        public Task<FlatInfoResponse> CreateFlatInfoAsync(FlatInfo FlatInfoData);
        public Task<FlatInfoResponse> DeleteFlatInfoAsync(short IdData);
        public Task<FlatInfoResponse> UpdateFlatInfoAsync(short IdData , FlatInfo FlatInfoData);
    }
}
