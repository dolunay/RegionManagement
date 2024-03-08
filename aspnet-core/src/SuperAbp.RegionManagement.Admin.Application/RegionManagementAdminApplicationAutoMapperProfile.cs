using SuperAbp.RegionManagement.Admin.Villages;
using SuperAbp.RegionManagement.Admin.Streets;
using SuperAbp.RegionManagement.Admin.Districts;
using SuperAbp.RegionManagement.Admin.Cities;
using SuperAbp.RegionManagement.Admin.Provinces;
using AutoMapper;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;

namespace SuperAbp.RegionManagement.Admin;

public class RegionManagementAdminApplicationAutoMapperProfile : Profile
{
    public RegionManagementAdminApplicationAutoMapperProfile()
    {
        #region 省

        CreateMap<Province, GetProvinceForEditorOutput>();
        CreateMap<Province, ProvinceListDto>();

        #endregion 省

        #region 市

        CreateMap<City, GetCityForEditorOutput>();
        CreateMap<City, CityListDto>();

        #endregion 市

        #region 地区

        CreateMap<District, GetDistrictForEditorOutput>();
        CreateMap<District, DistrictListDto>();

        #endregion 地区

        #region 镇

        CreateMap<Street, GetStreetForEditorOutput>();
        CreateMap<Street, StreetListDto>();

        #endregion 镇

        #region 乡

        CreateMap<Village, GetVillageForEditorOutput>();
        CreateMap<Village, VillageListDto>();

        #endregion 乡
    }
}