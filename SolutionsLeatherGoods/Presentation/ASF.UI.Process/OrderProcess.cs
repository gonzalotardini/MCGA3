using ASF.Business;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
   public class OrderProcess:ProcessComponent
    {

        public CartCompleta ObtenerCart(string email)
        {
            var cartCompleta = new CartCompleta();
            CartBusiness cartBusiness = new CartBusiness();
            List<Data.DbContext.CartItem> listaDetalle = new List<Data.DbContext.CartItem>();

            listaDetalle = cartBusiness.ObtenerCartDetalle(email);
            cartCompleta.detalle = listaDetalle;

            return cartCompleta;
        }


        public void CrearOrderCabecera(string email)
        {
            var orderBll = new OrderBusiness();
            var order = new Order();

            order.ClientId = orderBll.ObtenerClientId(email);


        }

        public void CreateOrder(Order order, OrderDetail orderdetail)
        {
            var response = HttpPost<Order>("rest/Order/Add", order, MediaType.Json);


        }

    }

    }

