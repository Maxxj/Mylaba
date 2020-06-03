using System.Net;
using Newtonsoft.Json;
using InnovativeProduct.ApplicationServices.Ports;
using InnovativeProduct.ApplicationServices.GetProductListUseCase;

namespace InnovativeProduct.InfrastructureServices.Presenters
{
    public class ProductListPresenter : IOutputPort<GetProductListUseCaseResponse>
    {
        public JsonContentResult ContentResult { get; }

        public ProductListPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GetProductListUseCaseResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.NotFound);
            ContentResult.Content = response.Success ? JsonConvert.SerializeObject(response.Products) : JsonConvert.SerializeObject(response.Message);
        }
    }
}
