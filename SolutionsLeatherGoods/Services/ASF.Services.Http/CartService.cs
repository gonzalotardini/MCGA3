using ASF.Entities;
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
    [RoutePrefix("rest/Order")]
    public class CartService : ApiController
    {
        //[HttpPost]
        //[Route("AddOrder")]
        //public Order AddOder(Order order)
        //{
        //    try
        //    {
        //        var bc = new CategoryBusiness();
        //        return bc.Add(category);
        //    }
        //    catch (Exception ex)
        //    {
        //        var httpError = new HttpResponseMessage()
        //        {
        //            StatusCode = (HttpStatusCode)422,
        //            ReasonPhrase = ex.Message
        //        };

        //        throw new HttpResponseException(httpError);
        //    }
        //}

    }
}
