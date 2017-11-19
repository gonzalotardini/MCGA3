using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
    public class ProductProcess : ProcessComponent
    {
        public List<Entities.Product> SelectAll()
        {
            var response = HttpGet<AllResponse>("rest/Product/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultProduct;
        }
    }
}

