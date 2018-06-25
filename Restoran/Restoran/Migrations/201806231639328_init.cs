namespace Restoran.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rezervacijas", "GostId", "dbo.Gosts");
            DropForeignKey("dbo.Porudzbenicas", "DobavljacId", "dbo.Dobavljacs");
            DropForeignKey("dbo.StavkaPorudzbenices", "PorudzbenicaId", "dbo.Porudzbenicas");
            DropForeignKey("dbo.StavkaPorudzbenices", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.StavkaRacunas", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.StavkaRacunas", "SifraRacuna", "dbo.Racuns");
            DropForeignKey("dbo.Racuns", "BrojStola", "dbo.Stoes");
            DropForeignKey("dbo.Rezervacijas", "BrojStola", "dbo.Stoes");
            DropForeignKey("dbo.Stoes", "SektorId", "dbo.Sektors");
            DropIndex("dbo.Rezervacijas", new[] { "BrojStola" });
            DropIndex("dbo.Rezervacijas", new[] { "GostId" });
            DropIndex("dbo.Stoes", new[] { "SektorId" });
            DropIndex("dbo.Racuns", new[] { "BrojStola" });
            DropIndex("dbo.StavkaRacunas", new[] { "SifraRacuna" });
            DropIndex("dbo.StavkaRacunas", new[] { "ProizvodId" });
            DropIndex("dbo.StavkaPorudzbenices", new[] { "ProizvodId" });
            DropIndex("dbo.StavkaPorudzbenices", new[] { "PorudzbenicaId" });
            DropIndex("dbo.Porudzbenicas", new[] { "DobavljacId" });
            DropTable("dbo.Gosts");
            DropTable("dbo.Rezervacijas");
            DropTable("dbo.Stoes");
            DropTable("dbo.Racuns");
            DropTable("dbo.StavkaRacunas");
            DropTable("dbo.Proizvods");
            DropTable("dbo.StavkaPorudzbenices");
            DropTable("dbo.Porudzbenicas");
            DropTable("dbo.Dobavljacs");
            DropTable("dbo.Sektors");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Sektors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dobavljacs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Porudzbenicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DobavljacId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StavkaPorudzbenices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProizvodId = c.Int(nullable: false),
                        PorudzbenicaId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proizvods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Lager = c.Int(nullable: false),
                        Cena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StavkaRacunas",
                c => new
                    {
                        StavkaId = c.Int(nullable: false, identity: true),
                        SifraRacuna = c.Int(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StavkaId);
            
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        SifraRacuna = c.Int(nullable: false, identity: true),
                        BrojStola = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SifraRacuna);
            
            CreateTable(
                "dbo.Stoes",
                c => new
                    {
                        BrojStola = c.Int(nullable: false, identity: true),
                        SektorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrojStola);
            
            CreateTable(
                "dbo.Rezervacijas",
                c => new
                    {
                        BrojStola = c.Int(nullable: false),
                        GostId = c.Int(nullable: false),
                        DatumVreme = c.DateTime(nullable: false),
                        BrojRezervacije = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrojStola, t.GostId, t.DatumVreme });
            
            CreateTable(
                "dbo.Gosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImePrezime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Porudzbenicas", "DobavljacId");
            CreateIndex("dbo.StavkaPorudzbenices", "PorudzbenicaId");
            CreateIndex("dbo.StavkaPorudzbenices", "ProizvodId");
            CreateIndex("dbo.StavkaRacunas", "ProizvodId");
            CreateIndex("dbo.StavkaRacunas", "SifraRacuna");
            CreateIndex("dbo.Racuns", "BrojStola");
            CreateIndex("dbo.Stoes", "SektorId");
            CreateIndex("dbo.Rezervacijas", "GostId");
            CreateIndex("dbo.Rezervacijas", "BrojStola");
            AddForeignKey("dbo.Stoes", "SektorId", "dbo.Sektors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rezervacijas", "BrojStola", "dbo.Stoes", "BrojStola", cascadeDelete: true);
            AddForeignKey("dbo.Racuns", "BrojStola", "dbo.Stoes", "BrojStola", cascadeDelete: true);
            AddForeignKey("dbo.StavkaRacunas", "SifraRacuna", "dbo.Racuns", "SifraRacuna", cascadeDelete: true);
            AddForeignKey("dbo.StavkaRacunas", "ProizvodId", "dbo.Proizvods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StavkaPorudzbenices", "ProizvodId", "dbo.Proizvods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StavkaPorudzbenices", "PorudzbenicaId", "dbo.Porudzbenicas", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Porudzbenicas", "DobavljacId", "dbo.Dobavljacs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Rezervacijas", "GostId", "dbo.Gosts", "Id", cascadeDelete: true);
        }
    }
}
