using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            if (product == null)
                return null;

            return new ProductDto()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                Description = product.Description,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
                CeoData = product.CeoData,
                Specifications = product.Specifications.Select(i => new ProductSpecificationDto()
                {
                    Value = i.Value,
                    Key = i.Key,
                }).ToList(),
                Images = product.Images.Select(i => new ProductImageDto()
                {
                    Id = i.Id,
                    CreationDate = i.CreationDate,
                    ImageName = i.ImageName,
                    ProductId = i.ProductId,
                    Sequence = i.Sequence,
                }).ToList(),
                Category = new()
                {
                    Id = product.CategoryId
                },
                SubCategory = new()
                {
                    Id = product.SubCategoryId
                },
                SecondarySubCategory = product.SecondarySubCategoryId != null ? new()
                {
                    Id = (long)product.SecondarySubCategoryId
                } : null
            };
        }

        public static ProductFilterData MapListData(this Product product)
        {
            return new ProductFilterData()
            {
                Id = product.Id,
                CreationDate = product.CreationDate,
                ImageName = product.ImageName,
                Slug = product.Slug,
                Title = product.Title,
            };
        }

        public static async Task SetCategories(this ProductDto product, ShopContext context)
        {
            var category = await context.Categories
                .Where(i => i.Id == product.Category.Id)
                .Select(i => new ProductCategoryDto()
                {
                    Id = i.Id,
                    Slug = i.Slug,
                    ParentId = i.ParentId,
                    CeoData = i.CeoData,
                    Title = i.Title,
                })
                .FirstOrDefaultAsync();

            var subCategory = await context.Categories.Where(i => i.Id == product.SubCategory.Id)
                .Select(i => new ProductCategoryDto()
                {
                    Id = i.Id,
                    Slug = i.Slug,
                    ParentId = i.ParentId,
                    CeoData = i.CeoData,
                    Title = i.Title,
                })
                .FirstOrDefaultAsync();

            if (product.SecondarySubCategory != null)
            {
                var secondarySubCategory = await context.Categories.Where(i => i.Id == product.SecondarySubCategory.Id)
                .Select(i => new ProductCategoryDto()
                {
                    Id = i.Id,
                    Slug = i.Slug,
                    ParentId = i.ParentId,
                    CeoData = i.CeoData,
                    Title = i.Title,
                })
                .FirstOrDefaultAsync();

                if (secondarySubCategory != null)
                    product.SecondarySubCategory = secondarySubCategory;
            }

            if (category != null)
                product.Category = category;

            if (subCategory != null)
                product.SubCategory = subCategory;
        }
    }
}
