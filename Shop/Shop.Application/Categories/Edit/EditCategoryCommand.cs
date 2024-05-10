﻿using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id, string title, string slug, SeoData seoData) : IBaseCommand;
}
