namespace HandIn2_2RDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        adresseId = c.Int(nullable: false, identity: true),
                        by = c.String(),
                        land = c.String(),
                        postnummer = c.String(),
                        vejnavn = c.String(),
                        vejnummer = c.Int(nullable: false),
                        altAddId = c.Int(),
                        type = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.adresseId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        personId = c.Int(nullable: false, identity: true),
                        fornavn = c.String(),
                        mellemnavn = c.String(),
                        efternavn = c.String(),
                        email = c.String(),
                        type = c.String(),
                        primAdresse_adresseId = c.Int(),
                    })
                .PrimaryKey(t => t.personId)
                .ForeignKey("dbo.Adresses", t => t.primAdresse_adresseId)
                .Index(t => t.primAdresse_adresseId);
            
            CreateTable(
                "dbo.Personkartoteks",
                c => new
                    {
                        personKartotekId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.personKartotekId);
            
            CreateTable(
                "dbo.Telefons",
                c => new
                    {
                        telefonId = c.Int(nullable: false, identity: true),
                        nummer = c.String(),
                        type = c.String(),
                        teleselskab = c.String(),
                    })
                .PrimaryKey(t => t.telefonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "primAdresse_adresseId", "dbo.Adresses");
            DropIndex("dbo.People", new[] { "primAdresse_adresseId" });
            DropTable("dbo.Telefons");
            DropTable("dbo.Personkartoteks");
            DropTable("dbo.People");
            DropTable("dbo.Adresses");
        }
    }
}
