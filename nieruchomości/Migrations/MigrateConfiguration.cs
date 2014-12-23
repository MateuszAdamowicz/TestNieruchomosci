using System.CodeDom;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Model;
using Context;

namespace nieruchomości.Migrations
{
    public class MigrateConfiguration : DbMigrationsConfiguration<ApplicationContext>
    {
        public MigrateConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}