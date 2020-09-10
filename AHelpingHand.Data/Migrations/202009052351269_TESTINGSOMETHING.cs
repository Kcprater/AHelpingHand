namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TESTINGSOMETHING : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Provider", "HelpID", "dbo.Help");
            DropIndex("dbo.Provider", new[] { "HelpID" });
            AddColumn("dbo.Help", "ProviderID", c => c.Int(nullable: false));
            AddColumn("dbo.Help", "Provider_ProviderID", c => c.Int());
            AddColumn("dbo.Help", "Provider_ProviderID1", c => c.Int());
            AddColumn("dbo.Provider", "Help_HelpID", c => c.Int());
            AddColumn("dbo.Provider", "Help_HelpID1", c => c.Int());
            CreateIndex("dbo.Help", "Provider_ProviderID");
            CreateIndex("dbo.Help", "Provider_ProviderID1");
            CreateIndex("dbo.Provider", "Help_HelpID");
            CreateIndex("dbo.Provider", "Help_HelpID1");
            AddForeignKey("dbo.Help", "Provider_ProviderID", "dbo.Provider", "ProviderID");
            AddForeignKey("dbo.Help", "Provider_ProviderID1", "dbo.Provider", "ProviderID");
            AddForeignKey("dbo.Provider", "Help_HelpID1", "dbo.Help", "HelpID");
            AddForeignKey("dbo.Provider", "Help_HelpID", "dbo.Help", "HelpID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provider", "Help_HelpID", "dbo.Help");
            DropForeignKey("dbo.Provider", "Help_HelpID1", "dbo.Help");
            DropForeignKey("dbo.Help", "Provider_ProviderID1", "dbo.Provider");
            DropForeignKey("dbo.Help", "Provider_ProviderID", "dbo.Provider");
            DropIndex("dbo.Provider", new[] { "Help_HelpID1" });
            DropIndex("dbo.Provider", new[] { "Help_HelpID" });
            DropIndex("dbo.Help", new[] { "Provider_ProviderID1" });
            DropIndex("dbo.Help", new[] { "Provider_ProviderID" });
            DropColumn("dbo.Provider", "Help_HelpID1");
            DropColumn("dbo.Provider", "Help_HelpID");
            DropColumn("dbo.Help", "Provider_ProviderID1");
            DropColumn("dbo.Help", "Provider_ProviderID");
            DropColumn("dbo.Help", "ProviderID");
            CreateIndex("dbo.Provider", "HelpID");
            AddForeignKey("dbo.Provider", "HelpID", "dbo.Help", "HelpID", cascadeDelete: true);
        }
    }
}
