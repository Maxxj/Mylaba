using InnovativeProduct.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeProduct.ApplicationServices.GetProductListUseCase
{
    public class GetProductListUseCaseRequest : IUseCaseRequest<GetProductListUseCaseResponse>
    {
        public long? ProductId { get; private set; }

        private GetProductListUseCaseRequest()
        { }

        public static GetProductListUseCaseRequest CreateAllProductsRequest()
        {
            return new GetProductListUseCaseRequest();
        }

        public static GetProductListUseCaseRequest CreateProductRequest(long productId)
        {
            return new GetProductListUseCaseRequest() { ProductId = productId };

        }
    }
}

