using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using videoChat.Models;
using videoChat.Views.Models;

namespace videoChat.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Api")]
    public class AccountController : ApiController
    {
        [HttpPost, Route("RegisterUseer")]
        public IHttpActionResult RegisterUser(RegisterUserModel User)
        {
            try
            {
                using (var ctx = new videoConEntities())
                {
                    if (User == null)
                        return Ok("No Request Data");

                    var newUser = ctx.Users.Add(new User
                    {
                        UserId = Guid.NewGuid(),
                        FirstName = User.FirstName,
                        LastName_ = User.LastName,
                        Email = User.Email,
                        Password = User.Password
                    });

                    int result = ctx.SaveChanges();
                    if (result == 1)
                        return Ok(newUser);
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return Ok(" Save not completed");
        }

        [HttpPost, Route("Login")]
        public IHttpActionResult Login(LoginViewModel User)
        {
            try
            {
                using (var ctx = new videoConEntities())
                {
                    if (User == null)
                        return Ok("No Request Data");

                    var loginUser = ctx.Users
                        .Where(a => a.Email == User.Email)
                        .FirstOrDefault();
                    if(loginUser == null)
                        return Ok("User with this mail "+ User.Email+" those not exit.");
                    var LoggedUser = ctx.loggedUsers.Add(new loggedUser
                    {
                        userId = loginUser.UserId,
                        loggedTime = DateTime.Now,
                        email = loginUser.Email
                    });
                    int result = ctx.SaveChanges();
                    if (result == 1)
                        return Ok(LoggedUser);
                }

            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
            return Ok(" Save not completed");
        }
    }

}