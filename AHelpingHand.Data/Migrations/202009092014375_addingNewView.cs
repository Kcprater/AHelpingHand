namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingNewView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Help_HelpID", c => c.Int());
            CreateIndex("dbo.Customer", "Help_HelpID");
            AddForeignKey("dbo.Customer", "Help_HelpID", "dbo.Help", "HelpID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "Help_HelpID", "dbo.Help");
            DropIndex("dbo.Customer", new[] { "Help_HelpID" });
            DropColumn("dbo.Customer", "Help_HelpID");
        }
    }
}
