namespace LTM.Teste.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipodadoscolunaarquivo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documento", "Arquivo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documento", "Arquivo", c => c.Binary());
        }
    }
}
