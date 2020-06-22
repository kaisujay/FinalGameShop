namespace FinalGameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteGameConsole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "ConsoleId", "dbo.GameConsoles");
            DropIndex("dbo.Games", new[] { "ConsoleId" });
            DropColumn("dbo.Games", "ConsoleId");
            DropTable("dbo.GameConsoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GameConsoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConsoleName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "ConsoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "ConsoleId");
            AddForeignKey("dbo.Games", "ConsoleId", "dbo.GameConsoles", "Id", cascadeDelete: true);
        }
    }
}
