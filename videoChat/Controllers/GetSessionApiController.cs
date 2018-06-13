using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenTokSDK;
using videoChat.Models;

namespace videoChat.Controllers
{
    [RoutePrefix("api")]
    public class GetSessionApiController : ApiController
    {

       static int ApiKey = 46135162; // YOUR API KEY
        static string ApiSecret = "ba51037c2dc7056236c572e4f4e187b1f9899bff";
       
        OpenTok penTok = new OpenTok(ApiKey, ApiSecret);
       static string sessionId;

        [Route("CreateSession/GenerateToken"), HttpGet]
        public IHttpActionResult CreateSession(CallerViewModel data)
        {

            if (data.CallerId != null)
            {
                try
                {
                    var GenerateToken = new GenerateToken();
                    //Creating a session
                    var session = penTok.CreateSession();
                    var token = session.GenerateToken();
                    GenerateToken.SessionId = session.Id;
                    GenerateToken.Token = token;
                    return Ok(GenerateToken);
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
            return Ok();
        }

        [Route("GenerateToken/{id}"), HttpGet]
        public IHttpActionResult generateToken(string id)
        {


            try
            {
                //Creating a session
                string token = penTok.GenerateToken(id);
               
                return Ok(token);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
