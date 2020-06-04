namespace ProyectiFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BarberWorks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barbers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        Horary = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Day = c.DateTime(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        BarberId = c.Int(nullable: false),
                        CorteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Barbers", t => t.BarberId, cascadeDelete: true)
                .ForeignKey("dbo.Cortes", t => t.CorteId, cascadeDelete: true)
                .Index(t => t.BarberId)
                .Index(t => t.CorteId);
            
            CreateTable(
                "dbo.Cortes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Citas", "CorteId", "dbo.Cortes");
            DropForeignKey("dbo.Citas", "BarberId", "dbo.Barbers");
            DropIndex("dbo.Citas", new[] { "CorteId" });
            DropIndex("dbo.Citas", new[] { "BarberId" });
            DropTable("dbo.Cortes");
            DropTable("dbo.Citas");
            DropTable("dbo.Barbers");
        }
    }
}
