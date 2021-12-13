using BusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BusAPI.Controllers
{
    [Route("api/Admin")]
    public class AdminController : ApiController
    {
        BusDBEntities db = new BusDBEntities();
        admin admin = new admin();

        [HttpPost]
        [Route("api/Admin/BusOwnerRequest")]
        public IQueryable<busowner> GetBusOwnerRequest(int name)
        {
            return db.busowners.Where(x => x.ApprovedByAdmin == name);
        }

        [HttpPost]
        [Route("api/Admin/CreateBusOwner")]
        public HttpResponseMessage CreateBusOwner(busowner owner)
        {
            db.busowners.Add(owner);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/Admin/ModifyBusOwner")]
        public HttpResponseMessage ModifyBusOwner(busowner ownerDetails, int id)
        {
            var Details = db.busowners.Find(id);
            Details.Name = ownerDetails.Name;
            Details.PhoneNumber = ownerDetails.PhoneNumber;
            Details.Email = ownerDetails.Email;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/Admin/DeleteBus")]
        public HttpResponseMessage DeleteBus(int ownerId)
        {
            var busDetails = db.busowners.Find(ownerId);
            db.busowners.Remove(busDetails);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

    }
}
