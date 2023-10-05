using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utilities;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        private Category() { }
        public Category(string title, string slug, CeoData ceoData, ICategoryDomainService domainService)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, domainService);
            Title = title;
            Slug = slug.ToSlug();
            CeoData = ceoData;
        }

        public long? ParentId { get; private set; }
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public CeoData CeoData { get; private set; }
        public List<Category> Childs { get; private set; }

        public void Edit(string title, string slug, CeoData ceoData, ICategoryDomainService domainService)
        {
            slug = slug?.ToSlug();
            Guard(title, slug, domainService);
            Title = title;
            Slug = slug;
            CeoData = ceoData;
            Childs = new();
        }

        public void AddChild(string title, string slug, CeoData ceoData, ICategoryDomainService domainService)
        {
            Childs.Add(new Category(title, slug, ceoData, domainService)
            {
                ParentId = Id,
            });
        }

        public void Guard(string title, string slug, ICategoryDomainService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
            if (slug != Slug)
                if (domainService.SlugIsExist(slug))
                    throw new SlugIsDuplicateException();
        }
    }
}
