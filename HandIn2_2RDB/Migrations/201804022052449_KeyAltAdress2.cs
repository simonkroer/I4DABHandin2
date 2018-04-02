namespace HandIn2_2RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyAltAdress2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adresses", "altAddId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adresses", "altAddId", c => c.Int());
        }
    }
}
