using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Util
{
    static class ConnectionStringWithPassword
    {
        //connection string n-are password din motive de securitate deci trebe pus din cod
        public static string doIt()
        {
            var oldConString = ConfigurationManager.ConnectionStrings["ISSEntities2"].ConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder(oldConString);
            var factory = System.Data.Common.DbProviderFactories.GetFactory(entityBuilder.Provider);
            var provBuilder = factory.CreateConnectionStringBuilder();

            provBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
            provBuilder.Add("password", "Castor211211");

            entityBuilder.ProviderConnectionString = provBuilder.ToString();

            return entityBuilder.ToString();
        }
    }
}
