using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CourseContext())
            {
                var departments = context.Departments.OrderBy(n => n.SortCode).ToList();

                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);

                //Console.WriteLine("修改记录");

                //var editDepartment = context.Departments.SingleOrDefault(x => x.Name == "环境与食品学院");
                //if (editDepartment != null)
                //{
                //    editDepartment.Name = "环境与食品检测学院";
                //    editDepartment.SortCode = "007";
                //    context.SaveChanges();
                //}
                //else
                //    Console.WriteLine("未找到该记录，不能修改");

                //Console.WriteLine("删除记录");
                //Console.WriteLine("====================================");
                //var deIDept = context.Departments.SingleOrDefault(x => x.ID == id);
                
                var departments1 = context.Departments.OrderBy(n => n.SortCode).ToList();
                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();
            }
        }
    }
}
