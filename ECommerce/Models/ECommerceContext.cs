using System.Data.Entity;

namespace ECommerce.Models
{
    public class ECommerceContext : DbContext
    {
        //this method you can connect to a your database
        public ECommerceContext() : base("DefaultConnection")
        {
                
        }

        public System.Data.Entity.DbSet<ECommerce.Models.Deparment> Deparments { get; set; }
        public System.Data.Entity.DbSet<ECommerce.Models.City> Cities { get; set; }
    }
}