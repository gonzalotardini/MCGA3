using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class OrderBusiness
    {
        
        //public List<OrderDetail> ObtenerDetalle(string email)
        //{
        //    var cartBll = new CartBusiness();
        //    var lista = cartBll.ObtenerCartDetalle(email);

        //}

        public int ObtenerClientId(string email)
        {
            var cartDac = new CartDAC();
            var orderDac = new OrderDAC();
            var userId = cartDac.ObtenerUserID(email);

            var clientId = orderDac.ObtenerClientID(userId);

            return clientId; 
        }

        //private List<OrderDetail> MapperCartToOrder( List<Data.DbContext.CartItem> listaRecibida)
        //{
        //    var listaDevuelta = new List<OrderDetail>();
        //    foreach (Data.DbContext.CartItem item in listaRecibida)
        //    {
        //        var orderDetail = new OrderDetail();

        //        orderDetail.ProductId = item.ProductId;

        //    }

        //}

    }
}
