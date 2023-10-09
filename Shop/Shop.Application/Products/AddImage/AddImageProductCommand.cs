using Common.Application;
using Microsoft.AspNetCore.Http;

namespace Shop.Application.Products.AddImage
{
    public record AddImageProductCommand(long ProductId, int Sequence, IFormFile ImageFile) : IBaseCommand;
}
