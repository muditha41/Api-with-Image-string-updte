using App.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers.Resources
{
    public class UserStatusResource
    {
        public int UserStatusId { get; set; }
        public int StatusId { get; set; }
        public DateTime StatusTimeStamp { get; set; }
        public string StatusState { get; set; }
        public Status Status { get; set; }
        public int FriendStatusId { get; set; }
        public DateTime FriendStatusTimeStamp { get; set; }
        public Status FriendStatus { get; set; }
        public string Time { get; set; }
       

        public void GenarateTime()
        {
            var hours = (  DateTime.Now - this.FriendStatusTimeStamp).TotalHours;
            if (hours > 24)
            {
               this.Time=FriendStatusTimeStamp.ToString("MM/dd/yy");
            }
            else
            {
                this.Time=FriendStatusTimeStamp.ToString("h:mm tt");
            }
        }
    }
}
