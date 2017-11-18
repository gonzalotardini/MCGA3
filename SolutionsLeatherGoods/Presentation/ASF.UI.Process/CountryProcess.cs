using ASF.Entities;
using ASF.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASF.UI.Process
{
   public class CountryProcess:ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> SelectList()
        {
            var response = HttpGet<AllResponse>("rest/Country/All", new Dictionary<string, object>(), MediaType.Json);
            return response.ResultCountry;
        }

        //public void Create(Category Category)
        //{
        //    var response = HttpPost<Category>("rest/Category/Add", Category, MediaType.Json);


        //}

        //public Category SelectOne(Category category)
        //{
        //    var response = HttpGet<Category>("rest/Category/Find/" + category.Id, new Dictionary<string, object>(), MediaType.Json);
        //    return response;
        //}


        //public void Delete(Category category)
        //{
        //    var responde = HttpPost<Category>("rest/Category/Find/" + category.Id, category, MediaType.Json);

        //}

    }
}

