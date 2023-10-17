using App.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class AccountServices
    {
       public void ReverseMapping(List<UserFriendResource> Resources)
        {
            foreach (var Resource in Resources)
            {
                var friend = Resource.Friend;

            }
        }
    }
}
