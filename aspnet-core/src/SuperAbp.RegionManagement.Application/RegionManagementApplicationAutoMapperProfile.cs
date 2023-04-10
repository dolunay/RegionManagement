using AutoMapper;
using SuperAbp.RegionManagement.Cities;
using SuperAbp.RegionManagement.Districts;
using SuperAbp.RegionManagement.Locations;
using SuperAbp.RegionManagement.Provinces;
using SuperAbp.RegionManagement.Streets;
using SuperAbp.RegionManagement.Villages;

namespace SuperAbp.RegionManagement;

public class RegionManagementApplicationAutoMapperProfile : Profile
{
    public RegionManagementApplicationAutoMapperProfile()
    {
        CreateMap<Province, ProvinceListDto>();
        CreateMap<City, CityListDto>();
        CreateMap<District, DistrictListDto>();
        CreateMap<Street, StreetListDto>();
        CreateMap<Village, VillageListDto>();

        CreateMap<RegionLocation, LocationListDto>();
    }
}