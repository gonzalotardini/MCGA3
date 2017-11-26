using ASF.Data.DbContext;
using System;
using System.Collections.Generic;
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
    }
}
