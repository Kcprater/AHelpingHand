namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "CustCat", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "CustSubcat", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Skill", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customer", "Skill");
            DropColumn("dbo.Customer", "CustSubcat");
            DropColumn("dbo.Customer", "CustCat");
        }
    }
}
