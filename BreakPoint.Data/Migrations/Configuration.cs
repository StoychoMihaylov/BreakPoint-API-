namespace BreakPoint.Data.Migrations
{
    using BreakPoint.Data.EntityModels;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BreakPointDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BreakPointDBContext context)
        {

        }
    }
}

