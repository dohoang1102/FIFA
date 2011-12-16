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

        // TODO: remove this hack
#if DEBUG
        static  MainContext()
        {
            //не надо так делать. потому что кто-то может зайте в дебаге на продакшин базу и пипец всем данным.
            //Database.SetInitializer(new DropCreateDatabaseAlways<MainContext>());
        }
#endif

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
