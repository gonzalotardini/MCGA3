using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class CountryBusiness
    {

        public List<Country> All()
        {
            var CountryDac = new CountryDAC();
            var ListCountry = new List<Country>();

            ListCountry = CountryDac.All();

            return ListCountry;
        }



    }
}
