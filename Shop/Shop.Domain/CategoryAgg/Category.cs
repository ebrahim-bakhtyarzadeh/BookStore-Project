﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Domain.CategoryAgg;

public class Category : AggregateRoot
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParentId { get; private set; }
    public List<Category> Childs { get; private set; }
    public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, categoryService);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, categoryService);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService categoryService)
    {
        Childs.Add(new Category(title, slug, seoData, categoryService)
        {
            ParentId = Id
        });
    }
    public void Guard(string title, string slug, ICategoryDomainService categoryService)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
        if (Slug != slug)
        {
            if (categoryService.IsSlugExist(slug))
                throw new SlugIsDuplicateException();
        }
    }
}