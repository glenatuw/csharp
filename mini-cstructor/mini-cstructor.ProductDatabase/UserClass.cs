using System;
using System.Collections.Generic;

namespace mini_cstructor.ProductDatabase
{
    public partial class UserClass
    {
        public int ClassId { get; set; }
        public int UserId { get; set; }

        public Class Class { get; set; }
        public User User { get; set; }
    }
}
