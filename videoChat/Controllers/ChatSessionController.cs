using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OpenTokSDK;

namespace videoChat.Controllers
{
    public class ChatSessionController : ApiController
    {
        static int  ApiKey = 000000; // YOUR API KEY
        static string ApiSecret = "YOUR API SECRET";
        OpenTok OpenTok = new OpenTok(ApiKey, ApiSecret);

        [HttpGet, Route("GenerateSession")]
        public IHttpActionResult GenerateSession()
        {
            // Create a session that will attempt to transmit streams directly between clients
            var session = OpenTok.CreateSession();
           
            // Store this sessionId in the database for later use:
            string sessionId = session.Id;

            return Ok(sessionId);
        }
    }
}
