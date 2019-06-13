namespace LibraryASP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        Author = c.String(maxLength: 50),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Fname = c.String(maxLength: 50),
                        Lname = c.String(maxLength: 50),
                        B_borrowed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Book", t => t.B_borrowed, cascadeDelete: true)
                .Index(t => t.B_borrowed);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "B_borrowed", "dbo.Book");
            DropIndex("dbo.User", new[] { "B_borrowed" });
            DropTable("dbo.User");
            DropTable("dbo.Book");
        }
    }
}
