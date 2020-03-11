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
    [RoutePrefix("api/Message")]
    public class MessageController : ApiController
    {

        // POST api/Message/RegisterMessage
        [HttpPost]
        public IHttpActionResult RegisterMessage(MessageModel message)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = "INSERT INTO dbo.Messages(Id, Message) " +
                    $"VALUES('{message.Id}','{message.Message}')";
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

        // GET api/Message/GetMessage
        [HttpGet]
        public MessageModel GetMessage()
        {
            string authenticatedAspNetUserId = RequestContext.Principal.Identity.GetUserId();
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = $"SELECT Id, Message FROM dbo.Messages";
                var message = cnn.Query<MessageModel>(sql).Last();
                return message;
            }
        }

    }
}
