using App.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers.Resources
{
    public class UserFriendResource
    {
        public UserFriendResource()
        {
      //      this.User = new UserResource();
        }
       
        public string UserFriendId { get; set; }
     
        public string UserId { get; set; }
        public UserResource User { get; set; }

        public string FriendId { get; set; }
        public UserResource Friend { get; set; }
        public string InviteStatus { get; set; }
 
        public UserStatusResource UserStatus { get; set; }


    }
}
