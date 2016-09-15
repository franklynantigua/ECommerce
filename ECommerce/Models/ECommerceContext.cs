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

        public DbSet <Deparment> Deparments { get; set; }
        public DbSet< City> Cities { get; set; }

        public  DbSet< Company> Companies { get; set; }

        public    DbSet< User> Users { get; set; }

        public  DbSet<Category> Categories { get; set; }

        public DbSet<Tax> Taxes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Inventory>  Inventories { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ECommerce.Models.State> States { get; set; }
        public DbSet<OrderDetailTmp> OrderDetailTmps { get; set; }
        public DbSet<OrderDetail> OrderDetails{ get; set; }
        public DbSet<Order> Orders{ get; set; }

        public DbSet<CompanyCustomer> CompanyCustomers { get; set; }
         
    }
}