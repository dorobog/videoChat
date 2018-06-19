using System;
using System.Linq;
using System.Web.Http;
using videoChat.Models;
using videoChat.Views.Models;
using System.Web.Http.Cors;
using VidChat.Models;
using OpenTokSDK;

namespace videoChat.Controllers
{
    [EnableCors("*", "*", "*"),RoutePrefix("api")]
    public class GetSessionApiController : ApiController
    {

       static int ApiKey = 46135162; // YOUR API KEY
        static string ApiSecret = "ba51037c2dc7056236c572e4f4e187b1f9899bff";
       
        OpenTok penTok = new OpenTok(ApiKey, ApiSecret);


        [Route("InitiateCall"), HttpPost]
        public IHttpActionResult IntiateCall(CallerViewModel data)
        {
            using (var ctx = new videoConEntities1())
            {
                var caller = ctx.Users
                    .Where(a => a.UserId == data.CallerId)
                    .FirstOrDefault();
                if (caller.UserId != null)
                {
                    try
                    {

                        var session = penTok.CreateSession();
                        var token = session.GenerateToken();

                        var callInfo = ctx.callInfoes.Add(new callInfo
                        {
                            CallInfoId = Guid.NewGuid(),
                            CallerId = data.CallerId,
                            ReceiverId = data.ReceiverId,
                            SessionId = session.Id,
                            Token = token
                        });

                        var newInfo = new callInfo();
                        newInfo.CallerId = callInfo.CallerId;
                        newInfo.ReceiverId = callInfo.CallerId;
                        newInfo.SessionId = callInfo.SessionId;
                        newInfo.CallInfoId = callInfo.CallInfoId;
                        newInfo.Token = callInfo.Token;

                        var result = ctx.SaveChanges();
                        if (result == 1)
                            return Ok(newInfo);
                        else
                            return Ok("Call failed");
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                }
            }

            return Ok();
        }


    }
}
