using CodeFirstDemo.CodeFirsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Migrations
{
    public class StudentSeed
    {
        public static void Seed(CourseContext context)
        {
            var stu1 = new Student()
            {
                StudentCode = "0001",
                Name = "张翠山",
                Address = "武当山",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13746498526",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu2 = new Student()
            {
                StudentCode = "0002",
                Name = "谢广坤",
                Address = "光明顶",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13746491204",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu3 = new Student()
            {
                StudentCode = "0003",
                Name = "灭绝",
                Address = "峨眉山",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13746498451",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            var stu4 = new Student()
            {
                StudentCode = "0004",
                Name = "成昆",
                Address = "空洞",
                Birthday = DateTime.Parse("2000-01-01"),
                Phone = "13746478451",
                Department = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Students.Add(stu1);
            context.Students.Add(stu2);
            context.Students.Add(stu3);
            context.Students.Add(stu4);
            context.SaveChanges();
        }
    }
}
