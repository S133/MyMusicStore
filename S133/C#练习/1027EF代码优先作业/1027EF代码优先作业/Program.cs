﻿using System;
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
            foreach (var c in courses)
                Console.WriteLine("课程名称：{0} 课程学分：{1} 所属学院：{2}", c.Title, c.Credit, c.Departments.Name);
            Console.ReadKey();
        }
    }
}
