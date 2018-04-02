namespace HandIn2_2RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyAltAdress4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "primAdresse_adresseId", "dbo.Adresses");
            DropIndex("dbo.People", new[] { "primAdresse_adresseId" });
            DropPrimaryKey("dbo.Adresses");
            CreateTable(
                "dbo.AlternativeAdresser",
                c => new
                    {
                        adresseId = c.Int(nullable: false),
                        by = c.String(),
                        land = c.String(),
                        postnummer = c.String(),
                        vejnavn = c.String(),
                        vejnummer = c.Int(nullable: false),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.adresseId);
            
            AlterColumn("dbo.Adresses", "adresseId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Adresses", "adresseId");
            DropColumn("dbo.Adresses", "type");
            DropColumn("dbo.Adresses", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adresses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Adresses", "type", c => c.String());
            DropPrimaryKey("dbo.Adresses");
            AlterColumn("dbo.Adresses", "adresseId", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.AlternativeAdresser");
            AddPrimaryKey("dbo.Adresses", "adresseId");
            CreateIndex("dbo.People", "primAdresse_adresseId");
            AddForeignKey("dbo.People", "primAdresse_adresseId", "dbo.Adresses", "adresseId");
        }
    }
}
