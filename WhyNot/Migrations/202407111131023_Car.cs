namespace WhyNot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Car : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        carId = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.carId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
