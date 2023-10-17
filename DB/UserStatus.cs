using App.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.DB
{
    public class UserStatus
    {
        [Key]
        public int UserStatusId { get; set; }
        public int? StatusId { get; set; }
        public DateTime StatusTimeStamp { get; set; }
        public string StatusState { get; set; }
        public Status Status { get; set; }
        public int? FriendStatusId { get; set; }
        public DateTime FriendStatusTimeStamp { get; set; }
        public Status FriendStatus { get; set; }
        [JsonIgnore]
        public UserFriends UserFriend { get; set; }
        public UserStatus()
        {
            StatusId = 1;
            FriendStatusId = 1;
        }
        
    }
}
