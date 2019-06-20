namespace BeautyServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "Mail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Providers", "Mail");
        }
    }
}
