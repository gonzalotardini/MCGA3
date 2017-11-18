using ASF.Services.Contracts;
using ASF.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using System.Net;

namespace ASF.Services.Http
{
    [RoutePrefix("rest/Country")]
    public class CountryService:ApiController
    {

        [HttpGet]
        [Route("All")]      
        public AllResponse All()
        {

            try
            {
                var response = new AllResponse();
                var bcountry = new CountryBusiness();
                response.ResultCountry = bcountry.All();
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
