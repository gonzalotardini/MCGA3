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

        public void CreateOrder(string email)
        {
            
                Order order = new Order();
                order.ClientId = ObtenerClientId(email);
                order.TotalPrice = 0;
                order.State = "Reviewed";
                order.ChangedOn = DateTime.Now;
                order.CreatedOn = DateTime.Now;
                order.ItemCount = 0;
                order.OrderDate = DateTime.Now;

                var orderDac = new OrderDAC();
                var orderId = orderDac.CreateOrder(order);
                var listaDetalles = new List<Data.DbContext.OrderDetail>();

                listaDetalles = ObtenerDetails(email, orderId);

                orderDac.AddOrderDetails(listaDetalles);

                order.TotalPrice = CalcularTotal(listaDetalles);
                order.ItemCount = listaDetalles.Count;
                order.Id = orderId;
                orderDac.UpdateOrder(order);
                orderDac.DeleteCartDetail(email);       
                      
            
        }

        private List<Data.DbContext.OrderDetail> ObtenerDetails(string email, int OrderId)
        {
            CartDAC cartdac = new CartDAC();
            CartItem cartItem = new CartItem();

            var userId = cartdac.ObtenerUserID(email);
            var cartId = cartdac.ObtenerIdCart(userId);
            var orderDetails = new List<Data.DbContext.OrderDetail>();
            var lista = cartdac.detalleEF(cartId);

            orderDetails = MapperCartItemToOrderDetail(lista, OrderId);
            return orderDetails;
        }

        public double CalcularTotal(List<Data.DbContext.OrderDetail> lista)
        {
            double total = 0;
            double subtotal;
            int cantidad;
            double precio;
            foreach (Data.DbContext.OrderDetail i in lista)
            {
                precio = i.Price;
                cantidad = i.Quantity;
                subtotal = precio * cantidad;
                total = total + subtotal;
            }

            return total;
        }

        public List<Data.DbContext.Order> ObtenerOrders(string email)
        {
            var clientId = ObtenerClientId(email);
            var orderDac = new OrderDAC();
           return orderDac.ObtenerOrdenes(clientId);

        }
       

        private List<Data.DbContext.OrderDetail> MapperCartItemToOrderDetail(List<Data.DbContext.CartItem> listarecibida, int orderId)
        {
            var listaDevuelta = new List<Data.DbContext.OrderDetail>();

            foreach (Data.DbContext.CartItem item in listarecibida)
            {
                var Detail = new Data.DbContext.OrderDetail();


                Detail.ChangedOn = DateTime.Now;
                Detail.CreatedOn = DateTime.Now;
                Detail.OrderId = orderId;
                Detail.Price = item.Price;
                Detail.ProductId = item.ProductId;
                Detail.Quantity = item.Quantity;

                listaDevuelta.Add(Detail);
            }

            return listaDevuelta;

        }
   

    }
}
