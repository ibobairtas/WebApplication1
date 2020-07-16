using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using PagedList;

namespace WebApplication1.Controllers
{
    public class MatakuliahController : Controller
    {
        private DBMahasiswaEntities1 db = new DBMahasiswaEntities1();

        // GET: Matakuliah
        public ActionResult Index(int? page)
        {
            var matakuliah = db.tabel_matakuliah.OrderBy(mt => mt.id_matakuliah);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(matakuliah.ToPagedList(pageNumber, pageSize));
        }

        // GET: Matakuliah/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matakuliah/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_matakuliah,nama_matakuliah")] tabel_matakuliah tabel_matakuliah)
        {
            if (ModelState.IsValid)
            {
                db.tabel_matakuliah.Add(tabel_matakuliah);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tabel_matakuliah);
        }

        // GET: Matakuliah/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_matakuliah tabel_matakuliah = await db.tabel_matakuliah.FindAsync(id);
            if (tabel_matakuliah == null)
            {
                return HttpNotFound();
            }
            return View(tabel_matakuliah);
        }

        // POST: Matakuliah/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_matakuliah,nama_matakuliah")] tabel_matakuliah tabel_matakuliah)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabel_matakuliah).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tabel_matakuliah);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_matakuliah tabel_matakuliah = await db.tabel_matakuliah.FindAsync(id);
            if (tabel_matakuliah == null)
            {
                return HttpNotFound();
            }
            db.tabel_matakuliah.Remove(tabel_matakuliah);
            await db.SaveChangesAsync();
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
