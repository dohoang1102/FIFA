namespace Fifa.Core.Migrations
{
    using System.Data.Entity.Migrations;
    
    /// <summary>
    /// Adds Color columnt to Users table.
    /// </summary>
    public partial class AddUserColorColumn : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddColumn("Users", "Color", c => c.String(false, 10, defaultValue: "#ffae00"));
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            DropColumn("Users", "Color");
        }
    }
}
