using ASF.Data;
using ASF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.Business
{
    public class DealerBusiness
    {
        public List<Dealer> SelectAll()
        {
            var DealerDac = new DealerDAC();

            return DealerDac.SelectAll();
        }

        public Dealer SelectOne(int id)
        {
            var DealerDac = new DealerDAC();

            return DealerDac.SelectOne(id);
        }
    }
}

