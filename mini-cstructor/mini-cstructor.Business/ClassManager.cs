using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using mini_cstructor.Repository;


namespace mini_cstructor.Business
{
     public interface IClassManager
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int ClassId);
    }

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
    }

    public class ClassManager : IClassManager
    {
        private readonly IClassRepository classRepository;

        public ClassManager(IClassRepository classRepository)
        {
            this.classRepository = classRepository;
        }

        public ClassModel[] Classes
        {
            get
            {
                return classRepository.Classes
                                         .Select(t => new ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice))
                                         .ToArray();
            }
        }

        public ClassModel Class(int ClassId)
        {
            var classModel = classRepository.Class(ClassId);
            return new ClassModel(classModel.ClassId, classModel.ClassName, classModel.ClassDescription, classModel.ClassPrice);
        }
    }
}

