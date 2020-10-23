using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ServiceLayer.AutoMapper.Resources;

namespace ServiceLayer.AutoMapper.Profiles
{
    public class AllProfiles 
    {
    }

    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryGetDto>();
            CreateMap<CategoryGetDto, Category>();
            CreateMap<Category, CategoryCreateDto>();
            CreateMap<CategoryCreateDto, Category>();
        }
    }

    public class StageProfile : Profile
    {
        public StageProfile()
        {
            CreateMap<Stage, StageGetDto>();
            CreateMap<StageGetDto, Stage>();
            CreateMap<Stage, StageCreateDto>();
            CreateMap<StageCreateDto, Stage>();
        }
    }

    public class WorksiteProfile : Profile
    {
        public WorksiteProfile()
        {
            CreateMap<Worksite, WorksiteGetDto>();
            CreateMap<WorksiteGetDto, Worksite>();
            CreateMap<WorksiteCreateDto, Worksite>();
            CreateMap<Worksite, WorksiteCreateDto>();
        }
    }

    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageGetDto>();
            CreateMap<ImageGetDto, Image>();
            CreateMap<Image, ImageCreateDto>();
            CreateMap<ImageCreateDto, Image>();
        }
    }

    public class FlatInfoProfile : Profile
    {
        public FlatInfoProfile()
        {
            CreateMap<FlatInfo, FlatInfoGetDto>();
            CreateMap<FlatInfoGetDto, FlatInfo>();
            CreateMap<FlatInfo, FlatInfoCreateDto>();
            CreateMap<FlatInfoCreateDto, FlatInfo>();
        }
    }

    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CampaignGetDto>();
            CreateMap<CampaignGetDto , Campaign>();
            CreateMap<Campaign, CampaignCreateDto>();
            CreateMap<CampaignCreateDto, Campaign>();
        }
    }


}
