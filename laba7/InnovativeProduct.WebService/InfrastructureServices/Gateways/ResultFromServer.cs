using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnovativeProduct.WebService.InfrastructureServices.Gateways
{
    public class Cells
    {
        public string Effects { get; set; }
        public string Name { get; set; }
        public string Indicators { get; set; }
        public string Tasks { get; set; }
        public string TechnicalCharacteristics { get; set; }
    }

    public class ResultFromServer
    {
        public int Number { get; set; }
        public Cells Cells { get; set; }
    }
}
