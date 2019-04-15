namespace ThemePark.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterSPHLoginTableKey : DbMigration
    {
        public override void Up()
        {
            Sql("alter table ThemePark.SPHLogin drop constraint PK__SPHLogin__F5B26A771EFE9958");
            //DropPrimaryKey("ThemePark.SPHLogin__F5B26A771EFE9958");
            AddColumn("ThemePark.SPHLogin", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("ThemePark.SPHLogin", "LoginEmail", c => c.String(maxLength: 40));
            AddPrimaryKey("ThemePark.SPHLogin", "Id");
        }
        
        public override void Down()
        {
            
        }
    }
}
