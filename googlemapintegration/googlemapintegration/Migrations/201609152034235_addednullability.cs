namespace googlemapintegration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednullability : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Lat", c => c.Single());
            AlterColumn("dbo.Addresses", "Lng", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Lng", c => c.Single(nullable: false));
            AlterColumn("dbo.Addresses", "Lat", c => c.Single(nullable: false));
        }
    }
}
