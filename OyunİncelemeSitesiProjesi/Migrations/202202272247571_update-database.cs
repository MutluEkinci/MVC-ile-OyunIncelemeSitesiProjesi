namespace OyunİncelemeSitesiProjesi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uyes", "Mail", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Uyes", "Sifre", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Uyes", "Sifre", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Uyes", "Mail");
        }
    }
}
