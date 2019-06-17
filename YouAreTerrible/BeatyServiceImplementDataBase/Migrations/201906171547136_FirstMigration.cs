namespace BeatyServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
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
                    })
                .PrimaryKey(t => t.ProviderId);
            
            CreateTable(
                "dbo.Resourses",
                c => new
                    {
                        ResourseId = c.Int(nullable: false, identity: true),
                        ResourseName = c.String(),
                        ResoursePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ResourseId);
            
            CreateTable(
                "dbo.ServiceResourses",
                c => new
                    {
                        ServiceResourseId = c.Int(nullable: false, identity: true),
                        ServiceId = c.Int(nullable: false),
                        ResourseId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ServiceResourseId);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            CreateTable(
                "dbo.Sklads",
                c => new
                    {
                        SkladId = c.Int(nullable: false, identity: true),
                        SkladName = c.String(),
                    })
                .PrimaryKey(t => t.SkladId);
            
            CreateTable(
                "dbo.SkladResourses",
                c => new
                    {
                        SkladResourseId = c.Int(nullable: false, identity: true),
                        SkladId = c.Int(nullable: false),
                        ResourseId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkladResourseId)
                .ForeignKey("dbo.Resourses", t => t.ResourseId, cascadeDelete: true)
                .ForeignKey("dbo.Sklads", t => t.SkladId, cascadeDelete: true)
                .Index(t => t.SkladId)
                .Index(t => t.ResourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkladResourses", "SkladId", "dbo.Sklads");
            DropForeignKey("dbo.SkladResourses", "ResourseId", "dbo.Resourses");
            DropIndex("dbo.SkladResourses", new[] { "ResourseId" });
            DropIndex("dbo.SkladResourses", new[] { "SkladId" });
            DropTable("dbo.SkladResourses");
            DropTable("dbo.Sklads");
            DropTable("dbo.Services");
            DropTable("dbo.ServiceResourses");
            DropTable("dbo.Resourses");
            DropTable("dbo.Providers");
        }
    }
}
