using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using googlemapintegration.Models;
using System.Xml.Linq;
using System.Runtime.Serialization.Formatters;
using GoogleMaps.LocationServices;

namespace googlemapintegration.Controllers
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public ActionResult Index()
        {
            return View(db.Addresses.ToList());
        }

        // GET: Addresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // GET: Addresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StreetName,StreetNumber,City,State,Zip")] Addresses addresses)
        {

            if (ModelState.IsValid)
            {

                var query = (from A in db.Addresses where A.ID == addresses.ID select A).FirstOrDefault();


                var address = addresses.StreetNumber + " " + addresses.StreetName + " " + addresses.City + " " + addresses.State + " " + addresses.Zip;

                var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

                var request = WebRequest.Create(requestUri);
                var response = request.GetResponse();
                var xdoc = XDocument.Load(response.GetResponseStream());

                var result = xdoc.Element("GeocodeResponse").Element("result");
                var locationElement = result.Element("geometry").Element("location");
                var lat = locationElement.Element("lat");
                var lng = locationElement.Element("lng");
                string stringlat = lat.ToString();
                string stringlng = lng.ToString();
                stringlat = stringlat.Substring(5, stringlat.IndexOf("</lat>")-5);
                stringlng = stringlng.Substring(5, stringlng.IndexOf("</lng>")-5);

            
                float longitude;
                float latitude;
                float.TryParse(stringlat, out latitude);
                float.TryParse(stringlng, out longitude);

                    addresses.Lat = latitude;
                    addresses.Lng = longitude;
                    db.SaveChanges();


                           
                db.Addresses.Add(addresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addresses);
        }

        // GET: Addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StreetName,StreetNumber,City,State,Zip")] Addresses addresses)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(addresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addresses);
        }

        // GET: Addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addresses addresses = db.Addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // POST: Addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Addresses addresses = db.Addresses.Find(id);
            db.Addresses.Remove(addresses);
            db.SaveChanges();
            return RedirectToAction("Index");
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
