namespace SGPARNA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tipo_Documento", "Imagem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tipo_Documento", "Imagem");
        }
    }
}
