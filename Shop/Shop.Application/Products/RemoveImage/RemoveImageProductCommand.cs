using Common.Application;
using FluentValidation;

namespace Shop.Application.Products.RemoveImage
{
    public record RemoveImageProductCommand(long ProductId, long ImageId) : IBaseCommand;
}
