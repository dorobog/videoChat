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

        [Route("PickCall/{id}"), HttpPost]
        public IHttpActionResult PickCall(Guid id)
         {
            using (var ctx = new videoConEntities1())
            {
                var PickCall = ctx.callInfoes
                    .Where(a => a.ReceiverId == id)
                    .FirstOrDefault();

                if (PickCall != null)
                {
                    try
                    {
                        PickCall.TimeCallPicked = DateTime.Now;
                        var callInfo = ctx.CallHistories.Add(new CallHistory
                        {
                            CallHistoryId = Guid.NewGuid(),
                            CallerId = PickCall.CallerId.ToString(),
                            ReceiverId = PickCall.ReceiverId.ToString(),
                            TimeCallBegan = DateTime.Now
                        });
                        var result1 = ctx.SaveChanges();
                        if (result1 < 1)
                            return Ok("Call Failed");

                        var call = (from c in ctx.callInfoes
                                    where c.ReceiverId == id 
                                    join ca in ctx.CallHistories on c.ReceiverId.ToString() equals ca.ReceiverId
                                    select new {
                                    c.CallInfoId,
                                    c.SessionId,
                                    c.Token,
                                    ca.CallHistoryId,
                                    ca.CallerId,
                                    ca.ReceiverId,
                                    ca.TimeCallBegan
                                    }).FirstOrDefault();
                       
                        return Ok(call);
                        
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                }
            }

            return Ok();
        }

        [Route("EndCall/{id}"), HttpPost]
        public IHttpActionResult EndCall(Guid id)
        {
            using (var ctx = new videoConEntities1())
            {
                var EndCall = ctx.callInfoes
                    .Where(a => a.ReceiverId == id || a.CallerId == id)
                    .FirstOrDefault();
                if (EndCall != null)
                {
                    try
                    {
                        EndCall.TimeCallPicked = DateTime.Now;
                        ctx.callInfoes.Remove(EndCall);

                        var result = ctx.SaveChanges();

                        if (result > 0)
                        { 
                        var updateTime = ctx.CallHistories.Where(a => a.CallHistoryId == id).FirstOrDefault();
                        updateTime.TimeCallEnded = DateTime.Now;
                            return Ok("Call Ended");
                        }
                        else
                            return Ok("Call Not Ended");
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                }
            }

            return Ok("Incorrect Id");
        }

        [Route("IsCallPicked/{id}"), HttpGet]
        public IHttpActionResult IsCallPicked(Guid id)
        {
            using (var ctx = new videoConEntities1())
            {
                var recId = ctx.callInfoes
                    .Where(a => a.ReceiverId == id)
                    .FirstOrDefault();
                if (recId.TimeCallPicked != null)
                {
                    try
                    {

                        var call = (from receiver in ctx.callInfoes
                                    where receiver.ReceiverId == id
                                    join callHistory in ctx.CallHistories on receiver.ReceiverId.ToString() equals callHistory.ReceiverId
                                    select new
                                    {
                                        receiver.CallerId,
                                        receiver.Token,
                                        receiver.SessionId,
                                        callHistory.TimeCallBegan
                                    }).SingleOrDefault();


                        if (call != null)
                        {

                            return Ok(call);
                        }
                        else
                            return Ok("Call Has not been picked for this User");
                    }
                    catch (Exception ex)
                    {
                        throw ex.InnerException;
                    }
                }
            }

            return Ok("Incorrect Id");
        }
    }
}
