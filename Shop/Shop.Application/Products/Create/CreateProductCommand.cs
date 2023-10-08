using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.ProductAgg;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommand : IBaseCommand
    {
        public CreateProductCommand(string title, IFormFile imageFile, string description, long categoryId, long subCategoryId,
            long secondarySubCategoryId, string slug, CeoData ceoData, Dictionary<string, string> specifications)
        {
            Title = title;
            ImageFile = imageFile;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug;
            CeoData = ceoData;
            Specifications = specifications;
        }

        public string Title { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public long SubCategoryId { get; set; }
        public long SecondarySubCategoryId { get; set; }
        public string Slug { get; set; }
        public CeoData CeoData { get; set; }
        public Dictionary<string, string> Specifications { get; set; }
    }
}
