using SuperAbp.RegionManagement.Admin.Villages;
using SuperAbp.RegionManagement.Admin.Streets;
using SuperAbp.RegionManagement.Admin.Districts;
using SuperAbp.RegionManagement.Admin.Cities;
using SuperAbp.RegionManagement.Admin.Provinces;
using AutoMapper;
using SuperAbp.RegionManagement.Admin.Regions;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;

namespace SuperAbp.RegionManagement.Admin;

public class RegionManagementApplicationAutoMapperProfile : Profile
{
    public RegionManagementApplicationAutoMapperProfile()
    {
        CreateMap<Province, RegionNodeDto>()
            .ForMember(entity => entity.IsLeaf,
                opt => opt.Ignore())
            .ForMember(entity => entity.Children,
                opt => opt.Ignore());
        CreateMap<City, RegionNodeDto>()
            .ForMember(entity => entity.IsLeaf,
                opt => opt.Ignore())
            .ForMember(entity => entity.Children,
                opt => opt.Ignore());
        CreateMap<District, RegionNodeDto>()
            .ForMember(entity => entity.IsLeaf,
                opt => opt.Ignore())
            .ForMember(entity => entity.Children,
                opt => opt.Ignore());
        CreateMap<Street, RegionNodeDto>()
            .ForMember(entity => entity.IsLeaf,
                opt => opt.Ignore())
            .ForMember(entity => entity.Children,
                opt => opt.Ignore());
        CreateMap<Village, RegionNodeDto>()
            .ForMember(entity => entity.IsLeaf,
                opt => opt.Ignore())
            .ForMember(entity => entity.Children,
                opt => opt.Ignore());

        #region 省

        CreateMap<Province, GetProvinceForEditorOutput>();
        CreateMap<Province, ProvinceListDto>();
        CreateMap<Province, ProvinceDetailDto>();
        CreateMap<ProvinceCreateDto, Province>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());
        CreateMap<ProvinceUpdateDto, Province>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());

        #endregion 省

        #region 市

        CreateMap<City, GetCityForEditorOutput>();
        CreateMap<City, CityListDto>();
        CreateMap<City, CityDetailDto>();
        CreateMap<CityCreateDto, City>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());
        CreateMap<CityUpdateDto, City>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());

        #endregion 市

        #region 地区

        CreateMap<District, GetDistrictForEditorOutput>();
        CreateMap<District, DistrictListDto>();
        CreateMap<District, DistrictDetailDto>();
        CreateMap<DistrictCreateDto, District>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());
        CreateMap<DistrictUpdateDto, District>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());

        #endregion 地区

        #region 镇

        CreateMap<Street, GetStreetForEditorOutput>();
        CreateMap<Street, StreetListDto>();
        CreateMap<Street, StreetDetailDto>();
        CreateMap<StreetCreateDto, Street>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());
        CreateMap<StreetUpdateDto, Street>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());

        #endregion 镇

        #region 乡

        CreateMap<Village, GetVillageForEditorOutput>();
        CreateMap<Village, VillageListDto>();
        CreateMap<Village, VillageDetailDto>();
        CreateMap<VillageCreateDto, Village>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());
        CreateMap<VillageUpdateDto, Village>()
            .ForMember(entity => entity.Id,
                opt => opt.Ignore());

        #endregion 乡
    }
}