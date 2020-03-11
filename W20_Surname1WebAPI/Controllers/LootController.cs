using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using W20_Surname1WebAPI.Models;

namespace W20_Surname1WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Loot")]
    public class LootController : ApiController
    {
        // POST api/Loot/RegisterLoot
        [HttpPost]
        public IHttpActionResult RegisterLoot(LootModel loot)
        {
            using (IDbConnection cnn = new ApplicationDbContext().Database.Connection)
            {
                string sql = "INSERT INTO dbo.Loot(Loot) " +
                    $"VALUES('{loot.Value}')";
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
    }
}