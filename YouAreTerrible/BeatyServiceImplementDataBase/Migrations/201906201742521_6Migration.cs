namespace BeautyServiceImplementDataBase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6Migration : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ApplicationResourses", "ApplicationId");
            CreateIndex("dbo.ApplicationResourses", "ResourseId");
            AddForeignKey("dbo.ApplicationResourses", "ApplicationId", "dbo.Applications", "ApplicationId", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationResourses", "ResourseId", "dbo.Resourses", "ResourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationResourses", "ResourseId", "dbo.Resourses");
            DropForeignKey("dbo.ApplicationResourses", "ApplicationId", "dbo.Applications");
            DropIndex("dbo.ApplicationResourses", new[] { "ResourseId" });
            DropIndex("dbo.ApplicationResourses", new[] { "ApplicationId" });
        }
    }
}
