using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models
{
    public class UserModel
    {
        [JsonProperty("UserId")]
        public Guid UserId { get; set; }

        [JsonProperty("UserEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("UserPassword")]
        public string UserPassword { get; set; }

        [JsonProperty("UserCreateDate")]
        public DateTime UserCreateDate { get; set; }

    }
}
