using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using videoChat.Views.Models;

namespace videoChat.Controllers
{
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

    }
}