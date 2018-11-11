namespace DateContext.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DateContext.ProductDBcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DateContext.ProductDBcontext context)
        {
            //context.Database.ExecuteSqlCommand("delete products");
            //context.Database.ExecuteSqlCommand("delete categories");
            SeedMethod.CategoryandProductSeed(context);
        }
    }
}
