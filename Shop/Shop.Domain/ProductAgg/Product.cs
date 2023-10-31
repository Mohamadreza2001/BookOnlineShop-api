using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        private Product() { }
        public Product(string title, string imageName, string description, long categoryId, long subCategoryId,
            long? secondarySubCategoryId, string slug, CeoData ceoData, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            Guard(title, description, slug, domainService);
            Title = title;
            ImageName = imageName;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            CeoData = ceoData;
            Specifications = new();
            Images = new();
        }

        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public string Description { get; private set; }
        public long CategoryId { get; private set; }
        public long SubCategoryId { get; private set; }
        public long? SecondarySubCategoryId { get; private set; }
        public string Slug { get; private set; }
        public CeoData CeoData { get; private set; }
        public List<ProductSpecification> Specifications { get; private set; }
        public List<ProductImage> Images { get; private set; }

        public void Edit(string title, string description, long categoryId, long subCategoryId,
            long secondarySubCategoryId, string slug, CeoData ceoData, IProductDomainService domainService)
        {
            Guard(title, description, slug, domainService);
            Title = title;
            Description = description;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
            SecondarySubCategoryId = secondarySubCategoryId;
            Slug = slug.ToSlug();
            CeoData = ceoData;
        }

        public void SetProductImage(string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
            ImageName = imageName;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            Images.Add(image);
        }

        public string RemoveImage(long imageId)
        {
            var oldImage = Images.FirstOrDefault(i => i.Id == imageId);
            if (oldImage == null)
                throw new NullOrEmptyDomainDataException("Image not found");
            Images.Remove(oldImage);
            return oldImage.ImageName;
        }

        public void SetSpecification(List<ProductSpecification> specifications)
        {
            specifications.ForEach(i => i.ProductId = Id);
            Specifications = specifications;
        }

        public void Guard(string title, string description, string slug, IProductDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(description, nameof(description));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));

            if (Slug != slug)
                if (domainService.SlugIsExist(slug.ToSlug()))
                    throw new SlugIsDuplicateException();
        }
    }
}
