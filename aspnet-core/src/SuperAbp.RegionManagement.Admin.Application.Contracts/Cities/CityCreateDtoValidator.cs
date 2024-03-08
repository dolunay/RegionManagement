using FluentValidation;
using Microsoft.Extensions.Localization;
using SuperAbp.RegionManagement.Localization;
using System;

namespace SuperAbp.RegionManagement.Admin.Cities;

public class CityCreateDtoValidator : AbstractValidator<CityCreateDto>
{
    public CityCreateDtoValidator(IStringLocalizer<RegionManagementResource> local)
    {
        Include(new CityCreateOrUpdateDtoBaseValidator(local));
        RuleFor(p => p.ProvinceId)
        .NotNull()
        .WithMessage(local["The {0} field is required.", "{PropertyName}"])
        .NotEqual(Guid.Empty)
        .WithMessage(local["The field {0} is invalid.", "{PropertyName}"]);
    }
}