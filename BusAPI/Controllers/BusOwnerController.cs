using BusAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusAPI.Controllers
{
    
    [Route("api/BusOwner")]
    public class BusOwnerController : ApiController
    {


        BusDBEntities db = new BusDBEntities();
        busowner ownerTable = new busowner();
        bus busTable = new bus();

        [HttpPost]
        [Route("api/BusOwner/RequestOwner")]
        public HttpResponseMessage RequestOwner(busowner owner)
        {
            db.busowners.Add(owner);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/BusOwner/CreateBus")]
        public HttpResponseMessage CreateBus(bus busDetails)
        {
            db.buses.Add(busDetails);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }

        [HttpPost]
        [Route("api/BusOwner/ModifyBus")]
        public HttpResponseMessage ModifyBus(bus busDetails, int busid)
        {
            var Details = db.buses.Find(busid);
            Details.Source = busDetails.Source;
            Details.Destination = busDetails.Destination;
            Details.DriverName = busDetails.DriverName;
            Details.LowerSeats = busDetails.LowerSeats;
            Details.UpperSeats = busDetails.UpperSeats;
            Details.TotalSeats = busDetails.TotalSeats;
            Details.PhoneNumber = busDetails.PhoneNumber;
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }


        [HttpPost]
        [Route("api/BusOwner/DeleteBus")]
        public HttpResponseMessage DeleteBus(int busid)
        {
            var busDetails = db.buses.Find(busid);
            db.buses.Remove(busDetails);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Success");
        }


        [HttpPost]
        [Route("api/BusOwner/GetDetails")]
        public IQueryable<user> GetDetails(int userId)
        {
            return db.users.Where(x => x.Id == userId);
        }

        [HttpPost]
        [Route("api/BusOwner/GetBusDetails")]
        public IQueryable<bus> GetBusDetails(int busid)
        {
            return db.buses.Where(x => x.Id == busid);
        }
    }
}
