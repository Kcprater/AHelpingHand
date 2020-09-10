namespace AHelpingHand.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foobar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "Category", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "Subcategory", c => c.String(nullable: false));
            DropColumn("dbo.Customer", "CustCat");
            DropColumn("dbo.Customer", "CustSubcat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customer", "CustSubcat", c => c.String(nullable: false));
            AddColumn("dbo.Customer", "CustCat", c => c.String(nullable: false));
            DropColumn("dbo.Customer", "Subcategory");
            DropColumn("dbo.Customer", "Category");
        }
    }
}
