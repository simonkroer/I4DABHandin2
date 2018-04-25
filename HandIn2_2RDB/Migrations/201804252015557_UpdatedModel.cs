namespace HandIn2_2RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AlternativAdresses", "Person_personId", c => c.Int());
            AddColumn("dbo.People", "Personkartotek_personKartotekId", c => c.Int());
            AddColumn("dbo.Telefons", "Person_personId", c => c.Int());
            CreateIndex("dbo.AlternativAdresses", "Person_personId");
            CreateIndex("dbo.People", "Personkartotek_personKartotekId");
            CreateIndex("dbo.Telefons", "Person_personId");
            AddForeignKey("dbo.AlternativAdresses", "Person_personId", "dbo.People", "personId");
            AddForeignKey("dbo.Telefons", "Person_personId", "dbo.People", "personId");
            AddForeignKey("dbo.People", "Personkartotek_personKartotekId", "dbo.Personkartoteks", "personKartotekId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Personkartotek_personKartotekId", "dbo.Personkartoteks");
            DropForeignKey("dbo.Telefons", "Person_personId", "dbo.People");
            DropForeignKey("dbo.AlternativAdresses", "Person_personId", "dbo.People");
            DropIndex("dbo.Telefons", new[] { "Person_personId" });
            DropIndex("dbo.People", new[] { "Personkartotek_personKartotekId" });
            DropIndex("dbo.AlternativAdresses", new[] { "Person_personId" });
            DropColumn("dbo.Telefons", "Person_personId");
            DropColumn("dbo.People", "Personkartotek_personKartotekId");
            DropColumn("dbo.AlternativAdresses", "Person_personId");
        }
    }
}
