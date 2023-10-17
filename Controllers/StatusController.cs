using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using App.Authentication;
using App.Controllers.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    //  [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class StatusController : Controller
    {
        private readonly ApplicationIdentityDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public StatusController(ApplicationIdentityDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }


        [HttpPut]
        [Route("statusupdate")]
        public async Task<IActionResult> PostStatus([FromBody]  UserStatusUpdateResource userStatusUpdateRecource)
        {
            var userStatusExists = await _context.UserStatus.Where(x => x.UserStatusId == userStatusUpdateRecource.UserStatusId).SingleOrDefaultAsync();
            if (userStatusExists != null)
            {
             
                //getting userFrien from friend-end
                var userFrindRevert = await _context.UserFriends.Include(s => s.UserStatus).Where(
                     x=>x.UserId == userStatusUpdateRecource.FriendId 
                     && x.FriendId== userStatusUpdateRecource.UserId 
                     && x.InviteStatus==true)
                       .SingleOrDefaultAsync();
                if (userFrindRevert != null)
                {
                    //updating user status
                    var dateTimeNow = DateTime.Now;
                    userStatusExists.StatusId = userStatusUpdateRecource.StatusId;
                    userStatusExists.StatusTimeStamp = dateTimeNow;

                    //updating user status on frind-end
                    userFrindRevert.UserStatus.FriendStatusId = userStatusUpdateRecource.StatusId;
                    userFrindRevert.UserStatus.FriendStatusTimeStamp = dateTimeNow;
                    userFrindRevert.UserStatus.StatusState = "New Status";

                    if (userStatusExists.StatusState =="Checked")
                    {
                        userStatusExists.StatusState = "Replied";
                    }
                        
                 
                    
                }

                    if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(new Response { Status = "Success", Message = "Status Updated!" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Status Update Failed" });
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Not Found" });
            }

          
        }

        [HttpPut]
        [Route("statuschecked")]
        public async Task<IActionResult> StatusChecked([FromBody] UserStatusUpdateResource userStatusUpdateRecource)
        {
            var userStatusExists = await _context.UserStatus.Where(x => x.UserStatusId == userStatusUpdateRecource.UserStatusId).SingleOrDefaultAsync();
            if (userStatusExists != null)
            {

              if (userStatusExists.StatusState == "New Status")
                    userStatusExists.StatusState = "Checked";
                   

              

                if (await _context.SaveChangesAsync() > 0)
                {
                    return Ok(new Response { Status = "Success", Message = "Status Updated!" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Status Update Failed" });
                }

            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = "Not Found" });
            }

        }
    }
}
