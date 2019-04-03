namespace LTM.Teste.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Usuario = c.String(),
                        DataUpload = c.DateTime(nullable: false),
                        DataUltimoAcesso = c.DateTime(nullable: false),
                        TamanhoArquivo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Arquivo = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Documento");
        }
    }
}
