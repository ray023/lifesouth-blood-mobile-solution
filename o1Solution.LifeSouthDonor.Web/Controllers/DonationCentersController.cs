using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using o1Solution.LifeSouthDonor.Data;

namespace o1Solution.LifeSouthDonor.Web.Controllers
{
    public class DonationCentersController : ApiController
    {
        private LifeSouthDonorModelContext db = new LifeSouthDonorModelContext();

        // GET: api/DonationCenters/?latitude=33.6705438&longitude=-86.4199482
        [ResponseType(typeof(IEnumerable<p_GetDonationCenters_Result>))]
        public IHttpActionResult GetDonationCenters(Decimal latitude, Decimal longitude)
        {
            return Ok(db.p_GetDonationCenters(latitude, longitude));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}