using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace mini_cstructor.Repository
{
    public interface IUserClassesRepository
    {
        UserClassModel Add(int UserId, int ClassId);

        ClassModel[] EnrolledClasses(int UserId);
    }

    public class UserClassModel
    {
        public int UserId { get; set; }

        public int ClassId { get; set; }
    }

    public class UserClassesRepository : IUserClassesRepository
    {
        public UserClassModel Add(int UserId, int ClassId)
        {
            var classFound = DatabaseAccessor.Instance.UserClass
            .FirstOrDefault(t => t.ClassId == ClassId && t.UserId == UserId);

            if (classFound != null)
            {
                return null;
            }

            var userClass = DatabaseAccessor.Instance.UserClass
                            .Add(new mini_cstructor.ProductDatabase.UserClass
                            {
                                UserId = UserId,
                                ClassId = ClassId
                            });

            DatabaseAccessor.Instance.SaveChanges();

            return new UserClassModel { UserId = userClass.Entity.UserId, ClassId = userClass.Entity.ClassId };

        }

        public ClassModel[] EnrolledClasses(int UserId)
        {
            return DatabaseAccessor.Instance.UserClass
                    .Where(t => UserId == t.UserId)
                    .Join(DatabaseAccessor.Instance.Class, userclass => userclass.ClassId, aclass => aclass.ClassId, (userclass, aclass) => new ClassModel { ClassId = aclass.ClassId, ClassName = aclass.ClassName, ClassDescription = aclass.ClassDescription, ClassPrice = aclass.ClassPrice })
                    .ToArray();
        }
    }

}