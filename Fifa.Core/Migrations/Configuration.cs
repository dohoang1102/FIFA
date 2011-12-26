namespace Fifa.Core.Migrations
{
    using System.Data.Entity.Migrations;
    using Fifa.Core.Repositories.Impl;

    /// <summary>
    /// Provides configuring migration for the EF CodeFirst approach.
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<MainContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Configuration"/> class.
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
