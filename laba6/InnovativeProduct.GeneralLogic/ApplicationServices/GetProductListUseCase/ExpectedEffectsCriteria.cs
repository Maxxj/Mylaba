using InnovativeProduct.DomainObjects;
using InnovativeProduct.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace InnovativeProduct.ApplicationServices.GetProductListUseCase
{
    public class ExpectedEffectsCriteria : ICriteria<Product>
    {
        public string ExpectedEffects { get; }

        public ExpectedEffectsCriteria(string expectedEffects)
            => ExpectedEffects = expectedEffects;

        public Expression<Func<Product, bool>> Filter
            => (s => s.ExpectedEffects == ExpectedEffects);
    }
}
