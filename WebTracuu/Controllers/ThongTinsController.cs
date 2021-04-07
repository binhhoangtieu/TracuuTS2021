using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTracuu.Models;

namespace WebTracuu.Controllers
{
    public class ThongTinsController : Controller
    {
        private tracuuEntities db = new tracuuEntities();



        // GET: ThongTins
        public ActionResult Index(string KeyWord)
        {
            var list = db.ThongTins.ToList();
            if (KeyWord != null && KeyWord != "")
            {
                list = list.Where(m=>m.Ma_nganh !=null).Where(m => m.Ma_nganh.Contains(KeyWord)).ToList();                
            }            
            return View(list);
                
        }

        // GET: ThongTins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // GET: ThongTins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThongTins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nganh,To_hop_thi,Ma_nganh,Chi_Tieu,Tham_Gia_Doi_Tuyen,To_Hop_XTT2,Ghi_Chu,Loai_XT,Ngoai_SP")] ThongTin thongTin)
        {
            if (ModelState.IsValid)
            {
                db.ThongTins.Add(thongTin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongTin);
        }

        // GET: ThongTins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // POST: ThongTins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nganh,To_hop_thi,Ma_nganh,Chi_Tieu,Tham_Gia_Doi_Tuyen,To_Hop_XTT2,Ghi_Chu,Loai_XT,Ngoai_SP")] ThongTin thongTin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongTin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongTin);
        }

        // GET: ThongTins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThongTin thongTin = db.ThongTins.Find(id);
            if (thongTin == null)
            {
                return HttpNotFound();
            }
            return View(thongTin);
        }

        // POST: ThongTins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThongTin thongTin = db.ThongTins.Find(id);
            db.ThongTins.Remove(thongTin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewDetail(string cNganh)
        {
            // Modify your code base on your requirements. For example ,find files in directory base on id or name
            return View(cNganh);
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
