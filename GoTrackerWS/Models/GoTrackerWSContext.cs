using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoTrackerWS.Models
{
    public class GoTrackerWSContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GoTrackerWSContext() : base("name=GoTrackerWSContext")
        {
        }

        public System.Data.Entity.DbSet<GoTrackerWS.Models.Equipamento> Equipamentoes { get; set; }

        public System.Data.Entity.DbSet<GoTrackerWS.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<GoTrackerWS.Models.Motorista> Motoristas { get; set; }

        public System.Data.Entity.DbSet<GoTrackerWS.Models.SimCard> SimCards { get; set; }

        public System.Data.Entity.DbSet<GoTrackerWS.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<GoTrackerWS.Models.Veiculo> Veiculoes { get; set; }
    
    }
}
