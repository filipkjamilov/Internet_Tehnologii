namespace PhoneApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        country = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        img = c.String(),
                        price = c.Int(nullable: false),
                        review = c.Int(nullable: false),
                        manufacturer_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Manufacturers", t => t.manufacturer_id)
                .Index(t => t.manufacturer_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "manufacturer_id", "dbo.Manufacturers");
            DropIndex("dbo.Phones", new[] { "manufacturer_id" });
            DropTable("dbo.Phones");
            DropTable("dbo.Manufacturers");
        }
    }
}
