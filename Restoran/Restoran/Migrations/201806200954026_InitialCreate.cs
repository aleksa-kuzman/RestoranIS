namespace Restoran.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImePrezime = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rezervacijas",
                c => new
                    {
                        BrojStola = c.Int(nullable: false),
                        GostId = c.Int(nullable: false),
                        DatumVreme = c.DateTime(nullable: false),
                        BrojRezervacije = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BrojStola, t.GostId, t.DatumVreme })
                .ForeignKey("dbo.Gosts", t => t.GostId, cascadeDelete: true)
                .ForeignKey("dbo.Stoes", t => t.BrojStola, cascadeDelete: true)
                .Index(t => t.BrojStola)
                .Index(t => t.GostId);
            
            CreateTable(
                "dbo.Stoes",
                c => new
                    {
                        BrojStola = c.Int(nullable: false, identity: true),
                        SektorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrojStola)
                .ForeignKey("dbo.Sektors", t => t.SektorId, cascadeDelete: true)
                .Index(t => t.SektorId);
            
            CreateTable(
                "dbo.Racuns",
                c => new
                    {
                        SifraRacuna = c.Int(nullable: false, identity: true),
                        BrojStola = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SifraRacuna)
                .ForeignKey("dbo.Stoes", t => t.BrojStola, cascadeDelete: true)
                .Index(t => t.BrojStola);
            
            CreateTable(
                "dbo.StavkaRacunas",
                c => new
                    {
                        StavkaId = c.Int(nullable: false, identity: true),
                        SifraRacuna = c.Int(nullable: false),
                        ProizvodId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StavkaId)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId, cascadeDelete: true)
                .ForeignKey("dbo.Racuns", t => t.SifraRacuna, cascadeDelete: true)
                .Index(t => t.SifraRacuna)
                .Index(t => t.ProizvodId);
            
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
                "dbo.StavkaPorudzbenices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProizvodId = c.Int(nullable: false),
                        PorudzbenicaId = c.Int(nullable: false),
                        Kolicina = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Porudzbenicas", t => t.PorudzbenicaId, cascadeDelete: true)
                .ForeignKey("dbo.Proizvods", t => t.ProizvodId, cascadeDelete: true)
                .Index(t => t.ProizvodId)
                .Index(t => t.PorudzbenicaId);
            
            CreateTable(
                "dbo.Porudzbenicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DobavljacId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dobavljacs", t => t.DobavljacId, cascadeDelete: true)
                .Index(t => t.DobavljacId);
            
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
                "dbo.Sektors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Stoes", "SektorId", "dbo.Sektors");
            DropForeignKey("dbo.Rezervacijas", "BrojStola", "dbo.Stoes");
            DropForeignKey("dbo.Racuns", "BrojStola", "dbo.Stoes");
            DropForeignKey("dbo.StavkaRacunas", "SifraRacuna", "dbo.Racuns");
            DropForeignKey("dbo.StavkaRacunas", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.StavkaPorudzbenices", "ProizvodId", "dbo.Proizvods");
            DropForeignKey("dbo.StavkaPorudzbenices", "PorudzbenicaId", "dbo.Porudzbenicas");
            DropForeignKey("dbo.Porudzbenicas", "DobavljacId", "dbo.Dobavljacs");
            DropForeignKey("dbo.Rezervacijas", "GostId", "dbo.Gosts");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Porudzbenicas", new[] { "DobavljacId" });
            DropIndex("dbo.StavkaPorudzbenices", new[] { "PorudzbenicaId" });
            DropIndex("dbo.StavkaPorudzbenices", new[] { "ProizvodId" });
            DropIndex("dbo.StavkaRacunas", new[] { "ProizvodId" });
            DropIndex("dbo.StavkaRacunas", new[] { "SifraRacuna" });
            DropIndex("dbo.Racuns", new[] { "BrojStola" });
            DropIndex("dbo.Stoes", new[] { "SektorId" });
            DropIndex("dbo.Rezervacijas", new[] { "GostId" });
            DropIndex("dbo.Rezervacijas", new[] { "BrojStola" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Sektors");
            DropTable("dbo.Dobavljacs");
            DropTable("dbo.Porudzbenicas");
            DropTable("dbo.StavkaPorudzbenices");
            DropTable("dbo.Proizvods");
            DropTable("dbo.StavkaRacunas");
            DropTable("dbo.Racuns");
            DropTable("dbo.Stoes");
            DropTable("dbo.Rezervacijas");
            DropTable("dbo.Gosts");
        }
    }
}
