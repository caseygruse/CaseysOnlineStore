namespace CaseysOnlineStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        MobilePhone = c.String(),
                        FullName = c.String(),
                        CreditCard = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
