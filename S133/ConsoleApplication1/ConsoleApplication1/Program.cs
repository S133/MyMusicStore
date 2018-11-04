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
                var departments = context.Departments.Where(n => n.Name.Contains("工程")).OrderBy(n => n.SortCode).ToList();

                foreach (var d in departments)
                    Console.WriteLine("编号{0},部门名称{1},说明{2}", d.SortCode, d.Name, d.Dscn);
                Console.ReadKey();
            }
        }
    }
}
