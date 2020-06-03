using InnovativeProduct.DomainObjects;
using InnovativeProduct.ApplicationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeProduct.ApplicationServices.GetProductListUseCase
{
    public class GetProductListUseCaseResponse : UseCaseResponse
    {
        public IEnumerable<Product> Products { get; }

        public GetProductListUseCaseResponse(IEnumerable<Product> products) => Products = products;
    }
}
