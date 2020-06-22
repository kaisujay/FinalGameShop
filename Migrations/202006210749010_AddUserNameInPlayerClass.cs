namespace FinalGameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNameInPlayerClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Players", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Players", "UserName");
        }
    }
}
