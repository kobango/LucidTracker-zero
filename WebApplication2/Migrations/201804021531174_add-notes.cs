namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotesViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Thema = c.String(),
                        Text = c.String(),
                        UserID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);           
        }
        
        public override void Down()
        {           
            DropTable("dbo.NotesViewModels");
        }
    }
}
