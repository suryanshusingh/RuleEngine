namespace ProjectRuleEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatatime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UpdatedDatas", "IncomingTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UpdatedDatas", "IncomingTime");
        }
    }
}
