using App.Authentication;
using App.Controllers.Resources;
using App.DB;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
 

            CreateMap<ApplicationUser, UserResource>();
            CreateMap<UserResource, ApplicationUser>();

            CreateMap<UserFriendResource, UserFriends>();
            CreateMap<UserFriends, UserFriendResource>();
            



            CreateMap<Task<UserFriendResource>, Task<UserFriends>>();
            CreateMap<Task<UserFriends>, Task<UserFriendResource>>();


            CreateMap<UserFriendResource, PendingUserFriends>()
               .ForMember(s => s.Friend, opt => opt.MapFrom(c => c.User))
               .ForMember(s => s.FriendId, opt => opt.MapFrom(c => c.UserId));

            CreateMap<UserStatus, UserStatusResource>();
             CreateMap<UserStatusResource, UserStatus>();

            CreateMap<NotificationResource, UserNotification>();
            CreateMap<UserNotification, NotificationResource>();



        }
    }
}
