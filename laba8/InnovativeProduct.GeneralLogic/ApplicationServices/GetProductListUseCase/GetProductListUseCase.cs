using System.Threading.Tasks;
using System.Collections.Generic;
using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using InnovativeProduct.ApplicationServices.Ports;

namespace InnovativeProduct.ApplicationServices.GetProductListUseCase
{
    public class GetProductListUseCase : IGetProductListUseCase
    {
        private readonly IReadOnlyProductRepository _readOnlyProductRepository;

        public GetProductListUseCase(IReadOnlyProductRepository readOnlyProductRepository)
            => _readOnlyProductRepository = readOnlyProductRepository;

        public async Task<bool> Handle(GetProductListUseCaseRequest request, IOutputPort<GetProductListUseCaseResponse> outputPort)
        {
            IEnumerable<Product> products = null;
            if (request.ProductId != null)
            {
                var product = await _readOnlyProductRepository.GetProduct(request.ProductId.Value);
                products = (product != null) ? new List<Product>() { product } : new List<Product>();

            }
            else
            {
                products = await _readOnlyProductRepository.GetAllProducts();
            }
            outputPort.Handle(new GetProductListUseCaseResponse(products));
            return true;
        }
    }
}
