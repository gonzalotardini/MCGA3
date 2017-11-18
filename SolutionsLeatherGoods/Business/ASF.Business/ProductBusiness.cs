using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class ProductBusiness
    {
        public List<Product> SelectAll()
        {
            var productDac = new ProductDAC();

            return productDac.SelectAll();
        }
    }
}
