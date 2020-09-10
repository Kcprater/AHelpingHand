namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoolTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Help", "NewClients", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Help", "NewClients");
        }
    }
}
