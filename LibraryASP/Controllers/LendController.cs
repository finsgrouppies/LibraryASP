using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryASP.DAL;
using LibraryASP.Models;

namespace LibraryASP.Controllers
{
    public class LendController : Controller
    {
        private LibraryContext db = new LibraryContext();

        // GET: Lend
        public ActionResult Index()
        {
            var lends = db.Lends.Include(l => l.Book).Include(l => l.User);
            return View(lends.ToList());
        }

        // GET: Lend/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // GET: Lend/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname");
            return View();
        }

        // POST: Lend/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LendID,BookID,Title,UserID,Fname")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                db.Lends.Add(lend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", lend.BookID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname", lend.UserID);
            return View(lend);
        }

        // GET: Lend/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", lend.BookID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname", lend.UserID);
            return View(lend);
        }

        // POST: Lend/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LendID,BookID,Title,UserID,Fname")] Lend lend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.Books, "BookID", "Title", lend.BookID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Fname", lend.UserID);
            return View(lend);
        }

        // GET: Lend/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lend lend = db.Lends.Find(id);
            if (lend == null)
            {
                return HttpNotFound();
            }
            return View(lend);
        }

        // POST: Lend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lend lend = db.Lends.Find(id);
            db.Lends.Remove(lend);
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
