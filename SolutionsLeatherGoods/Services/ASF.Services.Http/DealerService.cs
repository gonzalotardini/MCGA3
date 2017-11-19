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
    [RoutePrefix("rest/Dealer")]
    public class DealerService : ApiController
    {
        [HttpGet]
        [Route("All")]
        public AllResponse SelectAll()

        {
            try
            {
                var response = new AllResponse();
                var Dbusiness = new DealerBusiness();
                response.ResultDealer = Dbusiness.SelectAll();
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


        [HttpGet]
        [Route("Find")]
        public FindResponse Find(int id)
        {
            try
            {
                var response = new FindResponse();
                var bc = new DealerBusiness();
                response.ResultDealer = bc.SelectOne(id);
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

