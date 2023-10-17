using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers.Resources
{
    public class UserStatusUpdateResource
    {
        public int UserStatusId { get; set; }
        public String UserId { get; set; }
        public String FriendId { get; set; }
        public int StatusId { get; set; }
        
    }
}
