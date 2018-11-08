using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.CodeFirsModels
{
    public class Department
    {
        //实体的主键,属性的命名规则ID、id、类名+ID、类名+id
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public Department()
        {
            ID = Guid.NewGuid();
        }
    }
}
