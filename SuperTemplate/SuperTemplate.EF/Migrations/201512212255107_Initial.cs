namespace SuperTemplate.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.Location_Id)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.Invitations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        Appointment_Id = c.Guid(),
                        Person_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointments", t => t.Appointment_Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Appointment_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        LocationDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "Location_Id", "dbo.Rooms");
            DropForeignKey("dbo.Invitations", "Person_Id", "dbo.People");
            DropForeignKey("dbo.Invitations", "Appointment_Id", "dbo.Appointments");
            DropIndex("dbo.Invitations", new[] { "Person_Id" });
            DropIndex("dbo.Invitations", new[] { "Appointment_Id" });
            DropIndex("dbo.Appointments", new[] { "Location_Id" });
            DropTable("dbo.Rooms");
            DropTable("dbo.People");
            DropTable("dbo.Invitations");
            DropTable("dbo.Appointments");
        }
    }
}
