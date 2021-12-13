using BusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusAPI.Controllers
{
   
    [Route("api/User")]
    public class UserController : ApiController
    {
        BusDBEntities db = new BusDBEntities();
        user userTable = new user();

        [HttpPost]
        [Route("api/User/BookTicket")]
        public HttpResponseMessage BookTicket(user user)
        {
            db.users.Add(user);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/User/ModifyTicket")]
        public HttpResponseMessage ModifyTicket(user user, int userid)
        {
            var userDetails = db.users.Find(userid);
            userDetails.Source = user.Source;
            userDetails.Destination = user.Destination;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/User/CancelTicket")]
        public HttpResponseMessage CancelTicket(int userid)
        {
            var userDetails = db.users.Find(userid);
            db.users.Remove(userDetails);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/User/GetDetails")]
        public IQueryable<user> GetDetails(int userId)
        {
            return db.users.Where(x => x.Id == userId);
        }
    


    }
}
