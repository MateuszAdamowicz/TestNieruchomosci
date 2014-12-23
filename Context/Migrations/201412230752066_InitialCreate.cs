namespace Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Flat",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        Area = c.String(),
                        Storey = c.String(),
                        TechnicalCondition = c.String(),
                        Rooms = c.String(),
                        Heating = c.String(),
                        Rent = c.String(),
                        Ownership = c.String(),
                        PricePerMeter = c.String(),
                        ToLet = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Details = c.String(),
                        City = c.String(),
                        Price = c.String(),
                        Visible = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Counter = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Worker", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Link = c.String(),
                        AdType = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Flat_Id = c.Int(),
                        House_Id = c.Int(),
                        Land_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flat", t => t.Flat_Id)
                .ForeignKey("dbo.House", t => t.House_Id)
                .ForeignKey("dbo.Land", t => t.Land_Id)
                .Index(t => t.Flat_Id)
                .Index(t => t.House_Id)
                .Index(t => t.Land_Id);
            
            CreateTable(
                "dbo.House",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                        LandArea = c.String(),
                        UsableArea = c.String(),
                        TechnicalCondition = c.String(),
                        Rooms = c.String(),
                        Heating = c.String(),
                        Rent = c.String(),
                        Ownership = c.String(),
                        PricePerMeter = c.String(),
                        ToLet = c.Boolean(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        Details = c.String(),
                        City = c.String(),
                        Price = c.String(),
                        Visible = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Counter = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Worker", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Worker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneFirst = c.String(),
                        PhoneSecond = c.String(),
                        Email = c.String(),
                        HasPhoto = c.Boolean(nullable: false),
                        Photo = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Land",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.String(),
                        Ownership = c.String(),
                        Location = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Details = c.String(),
                        City = c.String(),
                        Price = c.String(),
                        Visible = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        Counter = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Worker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Worker", t => t.Worker_Id)
                .Index(t => t.Worker_Id);
            
            CreateTable(
                "dbo.Mail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Body = c.String(),
                        OrderLink = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Offer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Price = c.String(),
                        AdType = c.Int(nullable: false),
                        City = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        Status = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Statistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Statistics_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statistics", t => t.Statistics_Id)
                .Index(t => t.Statistics_Id);
            
            CreateTable(
                "dbo.Visit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Count = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Statistics_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Statistics", t => t.Statistics_Id)
                .Index(t => t.Statistics_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visit", "Statistics_Id", "dbo.Statistics");
            DropForeignKey("dbo.Session", "Statistics_Id", "dbo.Statistics");
            DropForeignKey("dbo.Flat", "Worker_Id", "dbo.Worker");
            DropForeignKey("dbo.Land", "Worker_Id", "dbo.Worker");
            DropForeignKey("dbo.Photo", "Land_Id", "dbo.Land");
            DropForeignKey("dbo.House", "Worker_Id", "dbo.Worker");
            DropForeignKey("dbo.Photo", "House_Id", "dbo.House");
            DropForeignKey("dbo.Photo", "Flat_Id", "dbo.Flat");
            DropIndex("dbo.Visit", new[] { "Statistics_Id" });
            DropIndex("dbo.Session", new[] { "Statistics_Id" });
            DropIndex("dbo.Land", new[] { "Worker_Id" });
            DropIndex("dbo.House", new[] { "Worker_Id" });
            DropIndex("dbo.Photo", new[] { "Land_Id" });
            DropIndex("dbo.Photo", new[] { "House_Id" });
            DropIndex("dbo.Photo", new[] { "Flat_Id" });
            DropIndex("dbo.Flat", new[] { "Worker_Id" });
            DropTable("dbo.Visit");
            DropTable("dbo.Session");
            DropTable("dbo.Statistics");
            DropTable("dbo.Offer");
            DropTable("dbo.Mail");
            DropTable("dbo.Land");
            DropTable("dbo.Worker");
            DropTable("dbo.House");
            DropTable("dbo.Photo");
            DropTable("dbo.Flat");
        }
    }
}
