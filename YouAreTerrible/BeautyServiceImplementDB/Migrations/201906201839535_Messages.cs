namespace BeautyServiceImplementDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Messages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        ProviderId = c.Int(nullable: false, identity: true),
                        ProviderName = c.String(),
                        ProviderSurname = c.String(),
                        ProviderPatronymic = c.String(),
                        Mail = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ProviderId);
            
            CreateTable(
                "dbo.MessageInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.String(),
                        FromMailAddress = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        DateDelivery = c.DateTime(nullable: false),
                        ProviderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.ProviderId);
            
            AddColumn("dbo.Applications", "Provider_ProviderId", c => c.Int());
            CreateIndex("dbo.Applications", "Provider_ProviderId");
            AddForeignKey("dbo.Applications", "Provider_ProviderId", "dbo.Providers", "ProviderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageInfoes", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.Applications", "Provider_ProviderId", "dbo.Providers");
            DropIndex("dbo.MessageInfoes", new[] { "ProviderId" });
            DropIndex("dbo.Applications", new[] { "Provider_ProviderId" });
            DropColumn("dbo.Applications", "Provider_ProviderId");
            DropTable("dbo.MessageInfoes");
            DropTable("dbo.Providers");
        }
    }
}
