using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using App.DB;
using Microsoft.AspNetCore.Identity;

namespace App.Authentication
{
    public class ApplicationUser : IdentityUser 
    {

        public string FullName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string WorkPlace { get; set; }
        public string RelationshipStatus { get; set; }
        public string Image { get; set; }

        [InverseProperty("User")]
        public UserFriends User { get; set; }
        [InverseProperty("User")]
        public UserFriends Friend { get; set; }
        [JsonIgnore]
        public virtual UserNotification UserNotification { get; set; }
        [JsonIgnore]
        public virtual UserNotification FriendNotification { get; set; }
        
    }
}

