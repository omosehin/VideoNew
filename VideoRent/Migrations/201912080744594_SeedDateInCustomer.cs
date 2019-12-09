namespace VideoRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDateInCustomer : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = CAST('2019-08-12' AS DATETIME)  WHERE Id = 2");

        }

        public override void Down()
        {
        }
    }
}
