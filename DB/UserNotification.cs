using App.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.DB
{
    public class UserNotification
    {
        [Key]
        public int UserNotificationId { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string FriendId { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool State { get; set; }
        public ApplicationUser Friend { get; set; }
        public string Notification { get; set; }
    }
}
