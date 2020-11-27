namespace Sem3_backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class touristDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Content = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quality = c.Double(nullable: false),
                        Location = c.String(),
                        TouristSpotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelID)
                .ForeignKey("dbo.TouristSpots", t => t.TouristSpotID, cascadeDelete: true)
                .Index(t => t.TouristSpotID);
            
            CreateTable(
                "dbo.TouristSpots",
                c => new
                    {
                        TouristSpotID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Destination = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.TouristSpotID);
            
            CreateTable(
                "dbo.Resorts",
                c => new
                    {
                        ResortID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Content = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quality = c.Double(nullable: false),
                        Location = c.String(),
                        TouristSpotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResortID)
                .ForeignKey("dbo.TouristSpots", t => t.TouristSpotID, cascadeDelete: true)
                .Index(t => t.TouristSpotID);
            
            CreateTable(
                "dbo.Restaurents",
                c => new
                    {
                        RestaurentID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Content = c.String(),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Quality = c.Double(nullable: false),
                        Location = c.String(),
                        TouristSpotID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RestaurentID)
                .ForeignKey("dbo.TouristSpots", t => t.TouristSpotID, cascadeDelete: true)
                .Index(t => t.TouristSpotID);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        TravelID = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Name = c.String(),
                        Content = c.String(),
                        TouristSportID = c.Int(nullable: false),
                        TouristSpot_TouristSpotID = c.Int(),
                    })
                .PrimaryKey(t => t.TravelID)
                .ForeignKey("dbo.TouristSpots", t => t.TouristSpot_TouristSpotID)
                .Index(t => t.TouristSpot_TouristSpotID);
            
            CreateTable(
                "dbo.Transports",
                c => new
                    {
                        TransportID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ImageUrl = c.String(),
                        Content = c.String(),
                        TravelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransportID)
                .ForeignKey("dbo.Travels", t => t.TravelID, cascadeDelete: true)
                .Index(t => t.TravelID);
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Transports", "TravelID", "dbo.Travels");
            DropForeignKey("dbo.Travels", "TouristSpot_TouristSpotID", "dbo.TouristSpots");
            DropForeignKey("dbo.Restaurents", "TouristSpotID", "dbo.TouristSpots");
            DropForeignKey("dbo.Resorts", "TouristSpotID", "dbo.TouristSpots");
            DropForeignKey("dbo.Hotels", "TouristSpotID", "dbo.TouristSpots");
            DropIndex("dbo.Transports", new[] { "TravelID" });
            DropIndex("dbo.Travels", new[] { "TouristSpot_TouristSpotID" });
            DropIndex("dbo.Restaurents", new[] { "TouristSpotID" });
            DropIndex("dbo.Resorts", new[] { "TouristSpotID" });
            DropIndex("dbo.Hotels", new[] { "TouristSpotID" });
            DropTable("dbo.Transports");
            DropTable("dbo.Travels");
            DropTable("dbo.Restaurents");
            DropTable("dbo.Resorts");
            DropTable("dbo.TouristSpots");
            DropTable("dbo.Hotels");
            DropTable("dbo.FeedBacks");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
