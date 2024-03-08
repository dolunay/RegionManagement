using FluentValidation;
using Microsoft.Extensions.Localization;
using SuperAbp.RegionManagement.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperAbp.RegionManagement.Admin.Cities;

public class CityCreateOrUpdateDtoBaseValidator : AbstractValidator<CityCreateOrUpdateDtoBase>
{
    public CityCreateOrUpdateDtoBaseValidator(IStringLocalizer<RegionManagementResource> local)
    {
        RuleFor(p => p.Name)
        .NotNull()
        .WithMessage(local["The {0} field is required.", "{PropertyName}"])
        .NotEmpty()
        .WithMessage(local["The {0} field is required.", "{PropertyName}"]);
        RuleFor(p => p.Code)
        .NotNull()
        .WithMessage(local["The {0} field is required.", "{PropertyName}"])
        .NotEmpty()
        .WithMessage(local["The {0} field is required.", "{PropertyName}"]);
    }
}