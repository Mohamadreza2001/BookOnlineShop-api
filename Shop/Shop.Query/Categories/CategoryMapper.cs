using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;
using System.Runtime.CompilerServices;

namespace Shop.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null)
                return null;
            return new CategoryDto()
            {
                Title = category.Title,
                Slug = category.Slug,
                Id = category.Id,
                CeoData = category.CeoData,
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapChildren()
            };
        }

        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var model = new List<CategoryDto>();
            categories.ForEach(i =>
            {
                model.Add(new CategoryDto()
                {
                    Title = i.Title,
                    Slug = i.Slug,
                    Id = i.Id,
                    CeoData = i.CeoData,
                    CreationDate = i.CreationDate,
                    Childs = i.Childs.MapChildren()
                });
            });
            return model;
        }

        public static List<ChildCategoryDto> MapChildren(this List<Category> children)
        {
            var model = new List<ChildCategoryDto>();
            children.ForEach(i =>
            {
                model.Add(new ChildCategoryDto()
                {
                    Title = i.Title,
                    Slug = i.Slug,
                    Id = i.Id,
                    CeoData = i.CeoData,
                    CreationDate = i.CreationDate,
                    ParentId = (long)i.ParentId,
                    Childs = i.Childs.MapSecondaryChild()
                });
            });
            return model;
        }

        private static List<SecondaryChildCategoryDto> MapSecondaryChild(this List<Category> children)
        {
            var model = new List<SecondaryChildCategoryDto>();
            children.ForEach(i =>
            {
                model.Add(new SecondaryChildCategoryDto()
                {
                    Title = i.Title,
                    Slug = i.Slug,
                    Id = i.Id,
                    CeoData = i.CeoData,
                    CreationDate = i.CreationDate,
                    ParentId = (long)i.ParentId,
                });
            });
            return model;
        }

    }
}
