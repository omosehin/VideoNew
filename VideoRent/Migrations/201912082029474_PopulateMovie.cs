namespace VideoRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovie : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('HangOver',1,  CAST('2017-05-1' AS DATETIME), CAST('2019-05-10' AS DATETIME),1)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Die Hard',3,  CAST('2014-05-1' AS DATETIME), CAST('2017-05-10' AS DATETIME),4)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Terminator',4,  CAST('2016-05-1' AS DATETIME), CAST('2019-05-10' AS DATETIME),5)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Tor Story',5,  CAST('2018-05-1' AS DATETIME), CAST('2019-05-10' AS DATETIME),3)");
            Sql("INSERT INTO Movies (Name,GenreId,DateAdded,ReleaseDate,NumberInStock) VALUES ('Titanic',2,  CAST('2013-05-1' AS DATETIME), CAST('2015-05-10' AS DATETIME),6)");

        }

        public override void Down()
        {
        }
    }
}
