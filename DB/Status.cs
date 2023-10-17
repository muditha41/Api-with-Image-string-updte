using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.DB
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        [JsonIgnore]
        public UserStatus UserStatus { get; set; }
        [JsonIgnore]
        public UserStatus FriendStatus { get; set; }
    }
}
