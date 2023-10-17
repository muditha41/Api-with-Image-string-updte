using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App.Authentication;
using App.Controllers.Resources;
using App.DB;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
  //  [Authorize]

    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ApplicationIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountController(ApplicationIdentityDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{userId}/profile")]
        public async Task<IActionResult> GetAccountDetails(string userId)
        {
            //  var contentType = this.Request;

            var user = await _userManager.FindByIdAsync(userId);
            var userResource = _mapper.Map<UserResource>(user);
            if (userResource != null)
            {
                return Ok(userResource);

            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Doesn't Exist" });
            }
            //return Unauthorized();
        }

        [HttpPut]
        [Route("updatedetails")]
        public async Task<IActionResult> UpdateDetails([FromBody] UserUpdateResource userUpdateRecource)
        {
            var userExists= _context.Users.Where(i => i.Id == userUpdateRecource.Id).SingleOrDefault();
            if (userExists != null && userUpdateRecource.Column<6)
            {

                switch (userUpdateRecource.Column)
                {
                    case 1:
                        userExists.Description = userUpdateRecource.Value;
                        break;
                    case 2:
                        userExists.FullName = userUpdateRecource.Value;
                        break;
                    case 3:
                        userExists.Location = userUpdateRecource.Value;
                        break;
                    case 4:
                        userExists.WorkPlace = userUpdateRecource.Value;
                        break;
                    case 5:
                        userExists.RelationshipStatus = userUpdateRecource.Value;
                        break;
                }
               
                 
                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(new Response { Status = "Success", Message = "User Details Successfully Updated!" });

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to Update!" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User doesn't exists!" });
            }
            
        }

        [HttpPut]
        [Route("updateimage")]
        public async Task<IActionResult> UpdateImage(UpdateUserImageResource updateUserImageResource)
        {
           
            

            var userExists = _context.Users.Where(i => i.Id == updateUserImageResource.Id).SingleOrDefault();
            if (userExists != null)
            {
               userExists.Image = updateUserImageResource.Value;

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(new Response { Status = "Success", Message = "User Image Successfully Updated!" });

                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Image Update Failed !" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User doesn't exists!" });
            }

        }

        [HttpGet]
        [Route("{userId}/notification")]
        public async Task<IActionResult> GetNotifications(string userId)
        {
            //  var contentType = this.Request;

            var userNotification = await _context.UserNotification.AsNoTracking().Include(x=>x.User).Include(y=>y.Friend).Where(i=>i.UserId==userId).ToArrayAsync();
            var notificationResource = _mapper.Map<List<NotificationResource>>(userNotification);
            if (notificationResource.Count>0)
            {
                notificationResource.ForEach(x =>
                {
                    x.GenarateTime();
                });
                var sortedList = notificationResource.OrderBy(x => x.TimeStamp).ToList();
                return Ok(sortedList);
              }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "No new notifications. Invite friends to my list." });
            }
            //return Unauthorized();
        }


        [HttpGet]
        [Route("{userId}/notificationCount")]
        public async Task<IActionResult> GetNotificationsCount(string userId)
        {
            //  var contentType = this.Request;

            var userNotification = await _context.UserNotification.AsNoTracking().Where(i => i.UserId == userId && i.State == true).ToArrayAsync();

            if (userNotification.Length > 0)
            {

                return Ok(userNotification.Length);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "No new notifications. Invite friends to my list." });
            }
            //return Unauthorized();
        }


        [HttpPut]
        [Route("{userId}/notificationchecked")]
        public async Task<IActionResult> ChackedNotifications(string userId)
        {
            //  var contentType = this.Request;

            var userNotifications = await _context.UserNotification.Where(i => i.UserId == userId).ToArrayAsync();
            foreach (var userNotification in userNotifications)
            {
                userNotification.State = false;
            }
          
            if (await _context.SaveChangesAsync() > 0)
            {
                return Ok(new Response { Status = "Success", Message = "Notification Checked!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Notification Checked Failed" });
            }
        }


    }
}