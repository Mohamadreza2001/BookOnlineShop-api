using Common.Application;
using Shop.Domain.CategoryAgg.Repository;

namespace Shop.Application.Categories.Remove
{
    internal class RemoveCategoryCommandHandler : IBaseCommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public RemoveCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteCategory(request.CategoryId);
            if (result)
                return OperationResult.Success();
            return OperationResult.Error("Delete this category is forbiden");
        }
    }
}
