namespace BeautyServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Providers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Providers", "Password");
        }
    }
}
