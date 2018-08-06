namespace CaseysOnlineStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CommereceDBContext : DbContext
    {
        // Your context has been configured to use a 'CommereceDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CaseysOnlineStore.Models.CommereceDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CommereceDBContext' 
        // connection string in the application configuration file.
        public CommereceDBContext()
            : base("name=CommereceDBContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Product> Products { get; set; }                                                ////////////////////////////////////////this is where you add product class into db
        public virtual DbSet<Member> Members { get; set; }                                                                                                                                          //and calls the table products

                                                                                                                /// Code first migration commands
                                                                                                                /// Enable-migrations   - (run once per project to enable code first migrations
                                                                                                                /// add-migration       - (Detects changes in your classes that are tracked by the DBContext
                                                                                                                /// for above type   Add-Migration "the name of the class you specifey in the context as a string"
                                                                                                                ///                        and creates a file to update your database)
                                                                                                                /// Update-database      - (Runs all pending migrations)   
                                                                                                                /// run update-database after the first two commands
                                                                                                                /// ---- in tools go to nuget package console
    }
}