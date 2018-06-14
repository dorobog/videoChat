﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using videoChat.Views.Models;

namespace videoChat.Controllers
{
    [RoutePrefix("api")]
    public class UserController : ApiController
    {
        [Route("getUserProfile/{id}"), HttpGet]
        public IHttpActionResult GetUserProfile(Guid id)
        {
            try
            {
                using (var ctx = new videoConEntities())
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
    }
}