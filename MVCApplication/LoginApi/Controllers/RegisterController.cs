using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using EntityData.Models;
using System.Web.Http.Description;
using EntityData;
using EntityData.Repositories;
using System.Web;

namespace MVCApplication.Controllers
{
    [RoutePrefix("register")]
    public class RegisterController : ApiController
    {
        [HttpPost, ResponseType(typeof(Guid))]//Session token to return
        public IHttpActionResult RegisterAccount(User user)
        {
            var context = new LoginContext();
            var userRepo = new UserRepository(context);

            if (userRepo.Add(user) == 0)
                return InternalServerError();

            var sessionRepo = new SessionRepository(context);
            var sessionId = sessionRepo.AddForUser(user);

            HttpContext.Current.Response.SetCookie(new HttpCookie("sessionId", sessionId.ToString()));


            return Ok(sessionId);
        }
    }
}
