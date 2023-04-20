namespace app2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookrecs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        ISBN = c.String(maxLength: 13),
                        Creation = c.DateTime(),
                        PageNo = c.Int(nullable: false),
                        BarCode = c.String(maxLength: 12),
                        PublishDate = c.DateTime(nullable: false),
                        Publisher = c.String(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bookrecs");
        }
    }
}
