using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using VidChat.Models;
using videoChat.Views.Models;

namespace videoChat.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        [Route("getUserProfile/{id}"), HttpGet]
        public IHttpActionResult GetUserProfile(Guid id)
        {
            try
            {
                using (var ctx = new videoConEntities1())
                {
                    var user = (from u in ctx.Users
                                where u.UserId == id
                                select new
                                {u.LastName_,
                                u.FirstName,
                                    u.Email}).FirstOrDefault();
                    if (user == null)
                        return Ok("User with " + id + " id doesn't exist");
                    else
                        return Ok(user);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
          
        }

        [Route("IsUserAvailable/{id}"), HttpGet]
        public IHttpActionResult IsUserAvailable(Guid id)
        {
            try
            {
                using (var ctx = new videoConEntities1())
                {
                    var user = (from u in ctx.loggedUsers
                                where u.userId == id
                                select new { u.email }).Any();

                    var CallInfo = (from u in ctx.callInfoes
                                    where u.ReceiverId == id
                                    join m in ctx.Users on u.ReceiverId equals m.UserId 
                                    select new {  m.FirstName, m.LastName_,m.Email,u.ReceiverId, u.SessionId,u.Token }).FirstOrDefault();
                    if (user == false || CallInfo == null)
                        return Ok("User isn't available");
                    else
                        return Ok(CallInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }

           
    }
}