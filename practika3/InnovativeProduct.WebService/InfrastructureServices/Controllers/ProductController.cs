using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.ApplicationServices.GetProductListUseCase;
using InnovativeProduct.InfrastructureServices.Presenters;

namespace InnovativeProduct.WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGetProductListUseCase _getProductListUseCase;

        public ProductController(ILogger<ProductController> logger, IGetProductListUseCase getProductListUseCase)
        {
            _logger = logger;
            _getProductListUseCase = getProductListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var presenter = new ProductListPresenter();
            await _getProductListUseCase.Handle(GetProductListUseCaseRequest.CreateAllProductsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{routeId}")]
        public async Task<ActionResult> GetProduct(long productId)
        {
            var presenter = new ProductListPresenter();
            await _getProductListUseCase.Handle(GetProductListUseCaseRequest.CreateProductRequest(productId), presenter);
            return presenter.ContentResult;
        }
    }
}
