using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Fifa.Models;

namespace Fifa.Repositories
{
    public class MainContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }

        static  MainContext()
        {
            // TODO: Remove when will have data.
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MainContext>());
        }
        
        public MainContext()
            : base("name=fifa")
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
