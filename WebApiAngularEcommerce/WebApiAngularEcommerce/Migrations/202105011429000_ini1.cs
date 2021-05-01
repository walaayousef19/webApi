namespace WebApiAngularEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Color");
        }
    }
}
