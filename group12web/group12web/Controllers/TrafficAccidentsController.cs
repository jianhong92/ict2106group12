using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using group12web.DAL;
using group12web.Models;

namespace group12web.Controllers
{
    public class TrafficAccidentsController : Controller
    {
        private group12Context db = new group12Context();
        private TrafficAccidentsGateway TrafficAccidentsGate = new TrafficAccidentsGateway();

        // GET: TrafficAccidents
        public ActionResult Index()
        {
            return View(TrafficAccidentsGate.SelectAll());
        }

        // GET: TrafficAccidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficAccident trafficAccident = TrafficAccidentsGate.SelectById(id);
            if (trafficAccident == null)
            {
                return HttpNotFound();
            }
            return View(trafficAccident);
        }

        // GET: TrafficAccidents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrafficAccidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RoadName,Date,Long,Lat,Description")] TrafficAccident trafficAccident)
        {
            if (ModelState.IsValid)
            {
                TrafficAccidentsGate.Insert(trafficAccident);
                return RedirectToAction("Index");
            }

            return View(trafficAccident);
        }

        // GET: TrafficAccidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficAccident trafficAccident = TrafficAccidentsGate.SelectById(id);
            if (trafficAccident == null)
            {
                return HttpNotFound();
            }
            return View(trafficAccident);
        }

        // POST: TrafficAccidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RoadName,Date,Long,Lat,Description")] TrafficAccident trafficAccident)
        {
            if (ModelState.IsValid)
            {
                TrafficAccidentsGate.Update(trafficAccident);
                return RedirectToAction("Index");
            }
            return View(trafficAccident);
        }

        // GET: TrafficAccidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrafficAccident trafficAccident = TrafficAccidentsGate.SelectById(id);
            if (trafficAccident == null)
            {
                return HttpNotFound();
            }
            return View(trafficAccident);
        }

        // POST: TrafficAccidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrafficAccidentsGate.Delete(id);
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
