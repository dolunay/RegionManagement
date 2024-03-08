using FluentValidation;
using Microsoft.Extensions.Localization;
using SuperAbp.RegionManagement.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAbp.RegionManagement.Admin.Cities;

public class CityUpdateDtoValidator : AbstractValidator<CityUpdateDto>
{
    public CityUpdateDtoValidator(IStringLocalizer<RegionManagementResource> local)
    {
        Include(new CityCreateOrUpdateDtoBaseValidator(local));
        RuleFor(p => p.ProvinceId)
            .NotEqual(Guid.Empty)
            .WithMessage(local["The field {0} is invalid.", "{PropertyName}"]);
    }
}