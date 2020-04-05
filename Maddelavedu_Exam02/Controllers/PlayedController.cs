using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Maddelavedu_Exam02.Models;
using Maddelavedu_Exam02.SportsPlayers;

namespace Maddelavedu_Exam02.Controllers
{
    public class PlayedController : Controller
    {
        private PlayerContext db = new PlayerContext();

        // GET: Played
        public ActionResult Index()
        {
            var played = db.Played.Include(p => p.Match).Include(p => p.Player);
            return View(played.ToList());
        }

        // GET: Played/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Played played = db.Played.Find(id);
            if (played == null)
            {
                return HttpNotFound();
            }
            return View(played);
        }

        // GET: Played/Create
        public ActionResult Create()
        {
            ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Stadium");
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "LastName");
            return View();
        }

        // POST: Played/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayedID,MatchID,PlayerID,Score")] Played played)
        {
            if (ModelState.IsValid)
            {
                db.Played.Add(played);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Stadium", played.MatchID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "LastName", played.PlayerID);
            return View(played);
        }

        // GET: Played/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Played played = db.Played.Find(id);
            if (played == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Stadium", played.MatchID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "LastName", played.PlayerID);
            return View(played);
        }

        // POST: Played/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayedID,MatchID,PlayerID,Score")] Played played)
        {
            if (ModelState.IsValid)
            {
                db.Entry(played).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatchID = new SelectList(db.Match, "MatchID", "Stadium", played.MatchID);
            ViewBag.PlayerID = new SelectList(db.Player, "PlayerID", "LastName", played.PlayerID);
            return View(played);
        }

        // GET: Played/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Played played = db.Played.Find(id);
            if (played == null)
            {
                return HttpNotFound();
            }
            return View(played);
        }

        // POST: Played/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Played played = db.Played.Find(id);
            db.Played.Remove(played);
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
