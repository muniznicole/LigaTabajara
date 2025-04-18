namespace LigaTabajara.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPartidaEGol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gols",
                c => new
                    {
                        GolId = c.Int(nullable: false, identity: true),
                        PartidaId = c.Int(nullable: false),
                        JogadorId = c.Int(nullable: false),
                        Minuto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GolId)
                .ForeignKey("dbo.Jogadors", t => t.JogadorId, cascadeDelete: true)
                .ForeignKey("dbo.Partidas", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId)
                .Index(t => t.JogadorId);
            
            CreateTable(
                "dbo.Partidas",
                c => new
                    {
                        PartidaId = c.Int(nullable: false, identity: true),
                        TimeCasaId = c.Int(nullable: false),
                        TimeForaId = c.Int(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        Estadio = c.String(),
                        PlacarTimeCasa = c.Int(nullable: false),
                        PlacarTimeFora = c.Int(nullable: false),
                        Rodada = c.Int(nullable: false),
                        TimeCasa_TimeId = c.Int(),
                        TimeFora_TimeId = c.Int(),
                    })
                .PrimaryKey(t => t.PartidaId)
                .ForeignKey("dbo.Times", t => t.TimeCasa_TimeId)
                .ForeignKey("dbo.Times", t => t.TimeFora_TimeId)
                .Index(t => t.TimeCasa_TimeId)
                .Index(t => t.TimeFora_TimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partidas", "TimeFora_TimeId", "dbo.Times");
            DropForeignKey("dbo.Partidas", "TimeCasa_TimeId", "dbo.Times");
            DropForeignKey("dbo.Gols", "PartidaId", "dbo.Partidas");
            DropForeignKey("dbo.Gols", "JogadorId", "dbo.Jogadors");
            DropIndex("dbo.Partidas", new[] { "TimeFora_TimeId" });
            DropIndex("dbo.Partidas", new[] { "TimeCasa_TimeId" });
            DropIndex("dbo.Gols", new[] { "JogadorId" });
            DropIndex("dbo.Gols", new[] { "PartidaId" });
            DropTable("dbo.Partidas");
            DropTable("dbo.Gols");
        }
    }
}
