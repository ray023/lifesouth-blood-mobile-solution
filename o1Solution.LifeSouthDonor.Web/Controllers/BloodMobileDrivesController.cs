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
using System.Data.SqlClient;
using System.Data.Entity.Core.Objects;

namespace o1Solution.LifeSouthDonor.Web.Controllers
{
    public class BloodMobileDrivesController : ApiController
    {
        private LifeSouthDonorModelContext db = new LifeSouthDonorModelContext();

        // GET: api/BloodMobileDrives/?latitude=33.6705438&longitude=-86.4199482
        [ResponseType(typeof(IEnumerable<p_GetDonationInformation_Result>))]
        public IHttpActionResult GetBloodMobileDrive(Decimal latitude, Decimal longitude)
        {
            return Ok(db.p_GetDonationInformation(latitude, longitude));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BloodMobileDriveExists(int id)
        {
            return db.BloodMobileDrives.Count(e => e.DriveId == id) > 0;
        }
        
    }
}