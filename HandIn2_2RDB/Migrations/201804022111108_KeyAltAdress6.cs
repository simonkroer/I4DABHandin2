namespace HandIn2_2RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyAltAdress6 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Adresses");
            AddColumn("dbo.Adresses", "altAdresseId", c => c.Int());
            AddColumn("dbo.Adresses", "type", c => c.String());
            AddColumn("dbo.Adresses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Adresses", "adresseId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Adresses", "adresseId");
            CreateIndex("dbo.People", "primAdresse_adresseId");
            AddForeignKey("dbo.People", "primAdresse_adresseId", "dbo.Adresses", "adresseId");
            DropTable("dbo.AlternativeAdresser");
        }
        
        public override void Down()
        {
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
            
            DropForeignKey("dbo.People", "primAdresse_adresseId", "dbo.Adresses");
            DropIndex("dbo.People", new[] { "primAdresse_adresseId" });
            DropPrimaryKey("dbo.Adresses");
            AlterColumn("dbo.Adresses", "adresseId", c => c.Int(nullable: false));
            DropColumn("dbo.Adresses", "Discriminator");
            DropColumn("dbo.Adresses", "type");
            DropColumn("dbo.Adresses", "altAdresseId");
            AddPrimaryKey("dbo.Adresses", "adresseId");
        }
    }
}
