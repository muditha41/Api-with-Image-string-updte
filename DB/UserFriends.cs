using App.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Authentication
{
    public class UserFriends
    {


        [Key]
        public int UserFriendId { get; set; }
       
        public string UserId { get; set; }
        public  ApplicationUser User {get;set;}
     
        public string FriendId { get; set; }
        public  ApplicationUser Friend { get; set; }

        public Boolean InviteStatus { get; set; }
        public int UserStatusId { get; set; }
        public virtual UserStatus UserStatus { get; set; }

        public UserFriends()
        {
            UserStatus = new UserStatus();
            UserStatus.FriendStatusTimeStamp = DateTime.Now;
            UserStatus.StatusTimeStamp = DateTime.Now;
        }

    }
}
