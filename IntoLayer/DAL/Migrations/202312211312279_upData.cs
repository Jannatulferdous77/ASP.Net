namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Password", c => c.String());
            AlterColumn("dbo.Students", "Username", c => c.String());
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
