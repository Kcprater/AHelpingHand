namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcompanytoprovider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provider", "Company", c => c.String());
            DropColumn("dbo.Help", "ProviderID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Help", "ProviderID", c => c.Int(nullable: false));
            DropColumn("dbo.Provider", "Company");
        }
    }
}
