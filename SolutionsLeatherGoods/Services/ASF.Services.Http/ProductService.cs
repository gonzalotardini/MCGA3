using ASF.Business;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Product")]
    public class ProductService : ApiController
    {

        [HttpGet]
        [Route("All")]
        public AllResponse SelectAll()

        {
            try
            {
                var response = new AllResponse();
                var productBusiness = new ProductBusiness();
                response.ResultProduct = productBusiness.SelectAll();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }
    }

}

