namespace FinalGameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        Publisher = c.String(),
                        PlayTime = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        GameType = c.String(),
                        Price = c.Single(nullable: false),
                        ConsoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameConsoles", t => t.ConsoleId, cascadeDelete: true)
                .Index(t => t.ConsoleId);
            
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
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        DiscountPrice = c.Single(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Gender = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Orders", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "ConsoleId", "dbo.GameConsoles");
            DropIndex("dbo.Orders", new[] { "PlayerId" });
            DropIndex("dbo.Orders", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "ConsoleId" });
            DropTable("dbo.Players");
            DropTable("dbo.Orders");
            DropTable("dbo.GameConsoles");
            DropTable("dbo.Games");
        }
    }
}
