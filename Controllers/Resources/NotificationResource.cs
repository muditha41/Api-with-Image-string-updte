using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers.Resources
{
    public class NotificationResource
    {
        public int UserNotificationId { get; set; }
        public string UserId { get; set; }

        public UserResource User { get; set; }

        public DateTime TimeStamp { get; set; }
        public string Time { get; set; }
        public bool State { get; set; }
        public UserResource Friend { get; set; }
        public string Notification { get; set; }
        public void GenarateTime()
        {
            var hours = (DateTime.Now - this.TimeStamp).TotalHours;
            if (hours > 24)
            {
                this.Time = TimeStamp.ToString("MM/dd/yy");
            }
            else
            {
                this.Time = TimeStamp.ToString("h:mm tt");
            }
        }
    }
}
