using ASF.Data.DbContext;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASF.Data
{
    public class DealerDAC : DataAccessComponent
    {
        public List<Entities.Dealer> SelectAll()
        {
            var Context = new LeatherGoodsEntities();
            var listaDealers = from dealers in Context.Dealer
                               select dealers;
            var ListaDevuelta = new List<Entities.Dealer>();

            ListaDevuelta = MapperDealer(listaDealers);
            return ListaDevuelta;
        }

        public Entities.Dealer SelectOne(int id)
        {
            var context = new LeatherGoodsEntities();

            var listaDealer = from dealers in context.Dealer
                              where dealers.Id == id
                              select dealers;

            return MapperDealer(listaDealer)[0];
        }

        private List<Entities.Dealer> MapperDealer(IQueryable<DbContext.Dealer> ListaRecibida)
        {
            List<Entities.Dealer> ListaDealer = new List<Entities.Dealer>();

            foreach (DbContext.Dealer i in ListaRecibida)
            {
                var Dealer = new Entities.Dealer();

                Dealer.CategoryId = i.CategoryId;
                Dealer.ChangedBy = i.ChangedBy;
                Dealer.ChangedOn = i.ChangedOn;
                Dealer.CountryId = i.CountryId;
                Dealer.CreatedBy = i.CreatedBy;
                Dealer.CreatedOn = i.CreatedOn;
                Dealer.Description = i.Description;
                Dealer.FirstName = i.FirstName;
                Dealer.LastName = i.LastName;
                Dealer.Id = i.Id;
                //Dealer.Rowid = i.Rowid;
                Dealer.TotalProducts = i.TotalProducts;
                Dealer.Countrydesc = i.Country.Name;
                Dealer.CategoryDesc = i.Category.Name;

                ListaDealer.Add(Dealer);
            }

            return ListaDealer;
        }
    }
}

