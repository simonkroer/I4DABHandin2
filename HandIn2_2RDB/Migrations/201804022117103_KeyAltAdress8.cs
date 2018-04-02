namespace HandIn2_2RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeyAltAdress8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlternativAdresses",
                c => new
                    {
                        altAdresseId = c.Int(nullable: false, identity: true),
                        by = c.String(),
                        land = c.String(),
                        postnummer = c.String(),
                        vejnavn = c.String(),
                        vejnummer = c.Int(nullable: false),
                        type = c.String(),
                    })
                .PrimaryKey(t => t.altAdresseId);
            
            DropColumn("dbo.Adresses", "altAdresseId");
            DropColumn("dbo.Adresses", "type");
            DropColumn("dbo.Adresses", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adresses", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Adresses", "type", c => c.String());
            AddColumn("dbo.Adresses", "altAdresseId", c => c.Int());
            DropTable("dbo.AlternativAdresses");
        }
    }
}
