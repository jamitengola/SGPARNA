namespace SGPARNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Documentoes", "Categoria_Id", c => c.Int());
            CreateIndex("dbo.Documentoes", "Categoria_Id");
            AddForeignKey("dbo.Documentoes", "Categoria_Id", "dbo.Categorias", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documentoes", "Categoria_Id", "dbo.Categorias");
            DropIndex("dbo.Documentoes", new[] { "Categoria_Id" });
            DropColumn("dbo.Documentoes", "Categoria_Id");
            DropTable("dbo.Categorias");
        }
    }
}
