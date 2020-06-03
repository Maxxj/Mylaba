using System;
using System.Collections.Generic;
using System.Text;

namespace InnovativeProduct.DomainObjects
{
    public class Product : DomainObject 
    {
        public string Name { get; set; }

        public string Tasks { get; set; }

        public string Specifications { get; set; }

        public string Indicators { get; set; }

        public string ExpectedEffects { get; set; }
    }
}
