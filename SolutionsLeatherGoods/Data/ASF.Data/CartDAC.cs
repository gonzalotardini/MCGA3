using ASF.Data.DbContext;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
    public class CartDAC : DataAccessComponent
    {

        public void UpdateCartCabecera(Entities.Cart cart)
        {
            var context = new LeatherGoodsEntities();
            var cartef = context.Cart.Where(c => c.IdUser == cart.IdUser);
        }

        public void InsertCartItem(Entities.CartItem cartItem)
        {
            var context = new LeatherGoodsEntities();
            DbContext.CartItem contextCartItem = new DbContext.CartItem();

            contextCartItem.Price = cartItem.Price;
            contextCartItem.ProductId = cartItem.ProductId;
            contextCartItem.CartId = cartItem.CartId;
            contextCartItem.Quantity = cartItem.Quantity;
            contextCartItem.CreatedOn = DateTime.Now;
            contextCartItem.ChangedOn = DateTime.Now;

            context.CartItem.Add(contextCartItem);
            context.SaveChanges();


        }

        public string ObtenerUserID(string email)
        {
            var context = new LeatherGoodsEntities();


            var user = from u in context.AspNetUsers
                       where u.Email == email
                       select u;

            var id = user.First().Id;

            return id;
        }

        public int ObtenerIdCart(string idUser)
        {
            var context = new LeatherGoodsEntities();


            var cart = from c in context.Cart
                       where c.IdUser == idUser
                       select c;

            var cartId = cart.First().Id;

            return cartId;

        }

        public List<Entities.CartItem> ObtenerDetalleCart(int id)
        {
            var context = new LeatherGoodsEntities();

            var listItems = from c in context.CartItem
                            where c.CartId == id
                            select c;

            return MapperCartItem(listItems);
        }

        public List<DbContext.CartItem> detalleEF (int id)
        {
            var context = new LeatherGoodsEntities();

            var listItems = from c in context.CartItem
                            where c.CartId == id
                            select c;

            return (MapperIQaDB(listItems));
        }


        private List<Entities.CartItem> MapperCartItem(IQueryable<DbContext.CartItem> ListaRecibida)
        {
            List<Entities.CartItem> listaItems = new List<Entities.CartItem>();

            foreach (DbContext.CartItem i in ListaRecibida)
            {
                var cartItem = new Entities.CartItem();

                cartItem.Id = i.Id;
                cartItem.CartId = i.CartId;
                cartItem.ProductId = i.ProductId;
                cartItem.Price = i.Price;
                cartItem.Quantity = i.Quantity;
                cartItem.CreatedOn = i.CreatedOn;
                cartItem.CreatedBy = i.CreatedBy;
                cartItem.ChangedOn = i.ChangedOn;
                cartItem.ChangedBy = i.ChangedBy;

                listaItems.Add(cartItem);
            }

            return listaItems;
        }


        private List<DbContext.CartItem> MapperIQaDB(IQueryable<DbContext.CartItem> ListaRecibida)
        {
            List<DbContext.CartItem> listaItems = new List<DbContext.CartItem>();

            foreach (DbContext.CartItem i in ListaRecibida)
            {
                var cartItem = new DbContext.CartItem();

                cartItem.Id = i.Id;
                cartItem.CartId = i.CartId;
                cartItem.ProductId = i.ProductId;
                cartItem.Pdescripcion = i.Product.Description;
                cartItem.Price = i.Price;
                cartItem.Quantity = i.Quantity;
                cartItem.CreatedOn = i.CreatedOn;
                cartItem.CreatedBy = i.CreatedBy;
                cartItem.ChangedOn = i.ChangedOn;
                cartItem.ChangedBy = i.ChangedBy;

                listaItems.Add(cartItem);
            }

            return listaItems;
        }




    }
}
