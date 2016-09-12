using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        //this method you can connect to a your database
        public ECommerceContext() : base("DefaultConnection")
        {
                
        }
        //------------------------------------------------------------------------------------------------------------
        // DESABILITAR LAS ELIMINACIONES EN CASCADA, ES DECIR, NO SE PUEDE BORRAR REGISTROS RELACIONADO
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        //-------------------------------------------------------------------------------------------------------------

        public System.Data.Entity.DbSet<ECommerce.Models.Deparment> Deparments { get; set; }
        public System.Data.Entity.DbSet<ECommerce.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.User> Users { get; set; }
    }
}