using App.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class ServiceManager : Service
    {

      public UserStatusResource GenarateTimeType(UserStatusResource userStatusResource)
        {
            var ts = new TimeSpan(DateTime.UtcNow.Ticks - userStatusResource.FriendStatusTimeStamp.Ticks);
            double delta = Math.Abs(ts.Days);
            if (delta > 0)
            {
           
            }
            return userStatusResource;
        }
    }
}
