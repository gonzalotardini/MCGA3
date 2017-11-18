using ASF.Entities;
using ASF.Data.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Data
{
    public class ProductDAC : DataAccessComponent
    {
        public List<Entities.Product> SelectAll()
        {
            var contexto = new LeatherGoodsEntities();

            var ListProducts = from products in contexto.Product
                               select products;

            return MapperProduct(ListProducts);
        }

        private List<Entities.Product> MapperProduct(IQueryable<DbContext.Product> ListaRecibida)
        {
            var listaProduct = new List<Entities.Product>();

            foreach (DbContext.Product i in ListaRecibida)
            {
                var product = new Entities.Product();

                product.AvgStars = i.AvgStars;
                product.ChangedBy = i.ChangedBy;
                product.ChangedOn = i.ChangedOn;
                product.CreatedBy = i.CreatedBy;
                product.CreatedOn = i.CreatedOn;
                product.DealerDesc = i.Dealer.Description;
                product.DealerId = i.DealerId;
                product.Description = i.Description;
                product.Id = i.Id;
                product.Price = i.Price;
                product.QuantitySold = i.QuantitySold;
                product.Title = i.Title;

                listaProduct.Add(product);

            }

            return listaProduct;

        }
    }
}
