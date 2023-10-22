using Common.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.RemoveImage;
using Shop.Presentation.facade.Products;
using Shop.Query.Products.DTOs;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Shop.Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProductByFilter([FromQuery] ProductFilterParams filterParams)
        {
            return QueryResult(await _productFacade.GetByFilter(filterParams));
        }

        [HttpGet("{productId}")]
        public async Task<ApiResult<ProductDto?>> GetProductById(long productId)
        {
            return QueryResult(await _productFacade.GetById(productId));
        }

        [HttpGet("{productSlug}")]
        public async Task<ApiResult<ProductDto?>> GetProductBySlug(string productSlug)
        {
            return QueryResult(await _productFacade.GetBySlug(productSlug));
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm] CreateProductCommand command)
        {
            var result = await _productFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPost("images")]
        public async Task<ApiResult> AddProductImage(AddImageProductCommand command)
        {
            var result = await _productFacade.AddImage(command);
            return CommandResult(result);
        }

        [HttpDelete("images")]
        public async Task<ApiResult> RemoveProductImage(RemoveImageProductCommand command)
        {
            var result = await _productFacade.RemoveImage(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm] EditProductCommand command)
        {
            var result = await _productFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
