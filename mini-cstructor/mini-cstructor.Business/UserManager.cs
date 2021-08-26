using System;
using System.Collections.Generic;
using System.Text;
using mini_cstructor.Repository;

namespace mini_cstructor.Business
{
    public interface IUserManager
    {
        UserModel LogIn(string email, string password);
        UserModel Register(string email, string password);
        UserClassModel AddClass(int UserId, int ClassId);
        ClassModel[] EnrolledClasses(int UserId);
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserClassModel
    {
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }

    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly IUserClassesRepository userClassesRepository;

        public UserManager(IUserRepository userRepository, IUserClassesRepository userClassesRepository)
        {
            this.userRepository = userRepository;
            this.userClassesRepository = userClassesRepository;
        }

        public UserModel LogIn(string email, string password)
        {
            var user = userRepository.LogIn(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        public UserModel Register(string email, string password)
        {
            var user = userRepository.Register(email, password);

            if (user == null)
            {
                return null;
            }

            return new UserModel { Id = user.Id, Name = user.Name };
        }

        public UserClassModel AddClass(int UserId, int ClassId)
        {
            var userclass = userClassesRepository.Add(UserId, ClassId);

            if (userclass != null)
            {
                return new UserClassModel { ClassId = userclass.ClassId, UserId = userclass.UserId, };
            }
            else
            {
                return null;
            }
        }

        public ClassModel[] EnrolledClasses(int UserId)
        {
            return Array.ConvertAll(userClassesRepository.EnrolledClasses(UserId), t => new Business.ClassModel(t.ClassId, t.ClassName, t.ClassDescription, t.ClassPrice));
        }
    }
}