namespace CodeFirstDemo.Migrations
{
    using CodeFirsModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstDemo.CodeFirsModels.CourseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirstDemo.CodeFirsModels.CourseContext context)
        {
            context.Database.ExecuteSqlCommand("delete courses");
            context.Database.ExecuteSqlCommand("delete departments");
            context.Database.ExecuteSqlCommand("delete students");

            DepartmentSeed.Seed(context);
            CourseSeed.Seed(context);
            StudentSeed.Seed(context);
        }
    }
}
