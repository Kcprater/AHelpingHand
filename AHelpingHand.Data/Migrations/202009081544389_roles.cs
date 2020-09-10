namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "UserRole");
        }
    }
}
