using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class CartBusiness
    {
        public void AddToCart(int cantidad, int productId, string email, double price)
        {

            CartDAC cartdac = new CartDAC();

            var userId = cartdac.ObtenerUserID(email);
            var cartId = cartdac.ObtenerIdCart(userId);

            CartItem cartItem = new CartItem();

            cartItem.ProductId = productId;
            cartItem.Quantity = cantidad;
            cartItem.CartId = cartId;
            cartItem.Price = Convert.ToDouble(price);
            cartdac.InsertCartItem(cartItem);

            var lista = cartdac.ObtenerDetalleCart(cartItem.CartId);
            var total = CalcularTotal(lista);
        }

        public List<Data.DbContext.CartItem> ObtenerCartDetalle(string email)
        {
            CartDAC cartdac = new CartDAC();
            CartItem cartItem = new CartItem();

            var userId = cartdac.ObtenerUserID(email);
            var cartId = cartdac.ObtenerIdCart(userId);

            var lista = cartdac.detalleEF(cartId);

            return lista;

        }

        private double CalcularTotal(List<CartItem> listaRecibida)
        {
            double total = 0;
            double subtotal;
            int cantidad;
            double precio;
            foreach (CartItem i in listaRecibida)
            {
                precio = i.Price;
                cantidad = i.Quantity;
                subtotal = precio * cantidad;
                total = total + subtotal;
            }

            return total;
        }

        public void Remove(int id)
        {
            var cartDac = new CartDAC();

            cartDac.RemoveItem(id);
        }


    }
}
