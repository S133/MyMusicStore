using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1027EF代码优先作业
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new DBContext();
            var courses = context.Courses.ToList();
            foreach (var c in courses)
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            Console.WriteLine("================添加三门课程================");


            var c1 = new Courses()
            {
                ID = Guid.NewGuid(),
                Title = "软件工程项目组织管理",
                Credit = 17,
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")

            };
            context.Courses.Add(c1);
            context.SaveChanges();
            var c2 = new Courses()
            {
                ID = Guid.NewGuid(),
                Title = "算法与数据结构",
                Credit = 2,
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Courses.Add(c2);
            context.SaveChanges();
            var c3 = new Courses()
            {
                ID = Guid.NewGuid(),
                Title = "C#团像处理",
                Credit = 2,
                Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院")
            };
            context.Courses.Add(c3);
            context.SaveChanges();
            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            Console.WriteLine("================修改一门课程================");
            var obj = context.Courses.SingleOrDefault(x => x.Title == "C#图像处理");
            if (obj != null)
            {
                obj.Title = "C#图像处理";
                obj.Credit = 2;
                obj.Departments = context.Departments.SingleOrDefault(x => x.Name == "电子信息工程学院");
                context.SaveChanges();
            }
            else
                Console.WriteLine("未找到该课程,不能修改！");
            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);
            Console.WriteLine("================删除一门课程================");
            var delobj = context.Courses.Find(Guid.Parse("bb73230c-40b9-47d9-aa62-8a5818f0dfc7"));
            context.Courses.Remove(delobj);
            context.SaveChanges();
            foreach (var c in context.Courses.ToList())
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);

            Console.ReadKey();
        }
    }
}
