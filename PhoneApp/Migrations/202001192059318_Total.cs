namespace PhoneApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Total : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Comments", new[] { "phone_id1" });
            DropColumn("dbo.Comments", "phone_id");
            RenameColumn(table: "dbo.Comments", name: "phone_id1", newName: "phone_id");
            AlterColumn("dbo.Comments", "phone_id", c => c.Int());
            CreateIndex("dbo.Comments", "phone_id");
            
            
            
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Comments", new[] { "phone_id" });
            AlterColumn("dbo.Comments", "phone_id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "phone_id", newName: "phone_id1");
            AddColumn("dbo.Comments", "phone_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "phone_id1");

        }
    }
}
