namespace ProjectRuleEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UpdatedDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Signal = c.String(),
                        Value = c.String(),
                        Value_type = c.String(),
                        CorrectSignal = c.Boolean(nullable: false),
                        ErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UpdatedDatas");
        }
    }
}
