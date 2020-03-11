using Dapper;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Linq;
using System.Web.Http;
using W20_Surname1WebAPI.Models;

namespace W20_Surname1WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/LastMessage")]
    public class LastMessageController : ApiController
    {

        // POST api/LastMessage/RegisterMessage
        [HttpPost]
        public IHttpActionResult RegisterLastMessage(LastMessageModel lastMessage)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = "INSERT INTO dbo.Messages(Id, Message) " +
                    $"VALUES('{lastMessage.Id}','{lastMessage.LastMessage}')";
                try
                {
                    cnn.Execute(sql);
                }
                catch (Exception ex)
                {
                    return BadRequest("Error inserting player in database: " + ex.Message);
                }

                return Ok();
            }
        }

        // GET api/LastMessage/GetMessage
        [HttpGet]
        public LastMessageModel GetMessage()
        {
            string authenticatedAspNetUserId = RequestContext.Principal.Identity.GetUserId();
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"SELECT Id, Message FROM dbo.Messages";
                var message = cnn.Query<LastMessageModel>(sql).Last();
                return message;
            }
        }

    }
}
