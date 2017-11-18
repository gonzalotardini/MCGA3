using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASF.Entities;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace ASF.Data
{
    public class CountryDAC:DataAccessComponent
    {
        public List<Country> All()
        {

            const string sqlStatement = "SELECT [Id], [Name], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Country order by Name ";

            var result = new List<Country>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var country = LoadCountry(dr); // Mapper
                        result.Add(country);
                    }
                }
            }

            return result;

        }

        private static  Country LoadCountry(IDataReader dr)
        {
            var country = new Country
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };
            return country;
        }

        
    }
}
