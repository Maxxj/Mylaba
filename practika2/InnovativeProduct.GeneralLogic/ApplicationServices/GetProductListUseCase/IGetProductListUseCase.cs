using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InnovativeProduct.ApplicationServices.Interfaces;

namespace InnovativeProduct.ApplicationServices.GetProductListUseCase
{
    public interface IGetProductListUseCase : IUseCase<GetProductListUseCaseRequest, GetProductListUseCaseResponse>
    {
    }
}
