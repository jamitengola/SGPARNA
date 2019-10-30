namespace SGPARNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contacto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contactoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroTelefone = c.String(),
                        Email = c.String(),
                        Usuario_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PrimeiroNome = c.String(),
                        UltimoNome = c.String(),
                        MyProperty = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Documentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documentos_Achados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documentoes", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
            CreateTable(
                "dbo.Documentos_Perdidos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documentoes", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
            CreateTable(
                "dbo.Estado_Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documentoes", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
            CreateTable(
                "dbo.Processos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documentoes", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
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
                "dbo.Servicos_de_utildidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documentoes", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
            CreateTable(
                "dbo.Tipo_Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Numero = c.String(),
                        Documento_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Documentoes", t => t.Documento_Id)
                .Index(t => t.Documento_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tipo_Documento", "Documento_Id", "dbo.Documentoes");
            DropForeignKey("dbo.Servicos_de_utildidade", "Documento_Id", "dbo.Documentoes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Processos", "Documento_Id", "dbo.Documentoes");
            DropForeignKey("dbo.Estado_Documento", "Documento_Id", "dbo.Documentoes");
            DropForeignKey("dbo.Documentos_Perdidos", "Documento_Id", "dbo.Documentoes");
            DropForeignKey("dbo.Documentos_Achados", "Documento_Id", "dbo.Documentoes");
            DropForeignKey("dbo.Contactoes", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tipo_Documento", new[] { "Documento_Id" });
            DropIndex("dbo.Servicos_de_utildidade", new[] { "Documento_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Processos", new[] { "Documento_Id" });
            DropIndex("dbo.Estado_Documento", new[] { "Documento_Id" });
            DropIndex("dbo.Documentos_Perdidos", new[] { "Documento_Id" });
            DropIndex("dbo.Documentos_Achados", new[] { "Documento_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Contactoes", new[] { "Usuario_Id" });
            DropTable("dbo.Tipo_Documento");
            DropTable("dbo.Servicos_de_utildidade");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Processos");
            DropTable("dbo.Estado_Documento");
            DropTable("dbo.Documentos_Perdidos");
            DropTable("dbo.Documentos_Achados");
            DropTable("dbo.Documentoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Contactoes");
        }
    }
}
