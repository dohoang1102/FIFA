using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Fifa.Models;

namespace Fifa.Repositories
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public MainContext()
            : base("name=Fifa")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
    }
}
