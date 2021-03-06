using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_cstructor.WebSite.Models
{
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }

        public ClassModel(int id, string name, string desc, decimal price)
        {
            ClassId = id;
            ClassName = name;
            ClassDescription = desc;
            ClassPrice = price;
        }

        public ClassModel()
        {
        }
    }
}
