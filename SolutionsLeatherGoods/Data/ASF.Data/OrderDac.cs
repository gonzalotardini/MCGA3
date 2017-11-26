using ASF.Data.DbContext;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
    public class OrderDAC :DataAccessComponent
    {
        public int ObtenerClientID(string userId)
        {
            var context = new LeatherGoodsEntities();


            var client = from u in context.Client
                       where u.AspNetUsers == userId
                       select u;

            var id = client.First().Id;

            return id;
        }

        public int CreateOrder(Entities.Order order)
        {
            var dbContext = new LeatherGoodsEntities();
            var orderhead = new Data.DbContext.Order();
            var OrderHead = MapperOrderEFtoEntite(order);
            
                dbContext.Order.Add(OrderHead);
                dbContext.SaveChanges();               


            int id = OrderHead.Id;
            return id;
        }

        public void AddOrderDetails(List<OrderDetail> lista)
        {
            var dbContext = new LeatherGoodsEntities();
            foreach (OrderDetail i in lista)
            {
                dbContext.OrderDetail.Add(i);
                dbContext.SaveChanges();

            }

        }

        public void UpdateOrder(Entities.Order order)
        {
            var orderEF = new Data.DbContext.Order();
            var context = new LeatherGoodsEntities();
            orderEF.Id = order.Id;           

            var orderbd = context.Order.Where(a => a.Id == orderEF.Id).First();

            orderbd.ChangedBy = order.ChangedBy;
            orderbd.ChangedOn = order.ChangedOn;
            orderbd.ClientId = order.ClientId;
            orderbd.CreatedBy = order.CreatedBy;
            orderbd.CreatedOn = order.CreatedOn;
            orderbd.ItemCount = order.ItemCount;
            orderbd.OrderDate = order.OrderDate;
            orderbd.OrderNumber = order.OrderNumber;
            orderbd.State = order.State;
            orderbd.TotalPrice = order.TotalPrice;

            context.SaveChanges();
        }

        public int ObtenerCartId(string email)
        {
            CartDAC cartdac = new CartDAC();
            CartItem cartItem = new CartItem();
            var context = new LeatherGoodsEntities();

            var userId = cartdac.ObtenerUserID(email);
            var cartId = cartdac.ObtenerIdCart(userId);
            return cartId;
        }

        public void DeleteCartDetail(string email)
        {
            var cartId = ObtenerCartId(email);
            

                const string sqlStatement = "DELETE dbo.CartItem WHERE [CartId]=@cartId ";
                var db = DatabaseFactory.CreateDatabase(ConnectionName);
                using (var cmd = db.GetSqlStringCommand(sqlStatement))
                {
                    db.AddInParameter(cmd, "@cartId", DbType.Int32, cartId);
                    db.ExecuteNonQuery(cmd);
                }
           
           

        }
        private DbContext.Order MapperOrderEFtoEntite(Entities.Order order)
        {
            

                var OrderC = new DbContext.Order();

                OrderC.ChangedBy = order.ChangedBy;
                OrderC.ChangedOn = order.ChangedOn;
                OrderC.ClientId = order.ClientId;
                OrderC.CreatedOn = order.CreatedOn;
                OrderC.ItemCount = order.ItemCount;
                OrderC.OrderDate = order.OrderDate;
                OrderC.OrderNumber = order.OrderNumber;
                OrderC.State = "Reviewed";               
                OrderC.TotalPrice = order.TotalPrice;

                return OrderC;
                                 
        }

        public List<Data.DbContext.Order> ObtenerOrdenes(int clientId)
        {
            
            var context = new LeatherGoodsEntities();

           var  orders = context.Order.Where(a => a.ClientId == clientId).ToList();

            return orders;
        }
                

    }
}
