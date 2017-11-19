using ASF.Business;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process

  {

    public class CartCompleta : EntityBase
    {
        public Cart cart { get; set; }
        public List<Data.DbContext.CartItem> detalle { get; set; }
    }

    public class CartProcess : ProcessComponent
    {
        public void AddToCart(int cantidad, int ProductId, string email, double price)
        {
            var cartBussines = new CartBusiness();

            cartBussines.AddToCart(cantidad, ProductId, email, price);
        }

        public CartCompleta ObtenerCartCompleta(string email)
        {
            var cartCompleta = new CartCompleta();
            CartBusiness cartBusiness = new CartBusiness();
            List<Data.DbContext.CartItem> listaDetalle = new List<Data.DbContext.CartItem>();

            listaDetalle = cartBusiness.ObtenerCartDetalle(email);
            cartCompleta.detalle = listaDetalle;
            return cartCompleta;
        }
    }
}
