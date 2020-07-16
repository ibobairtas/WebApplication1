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
    public class NilaiController : Controller
    {
        private DBMahasiswaEntities1 db = new DBMahasiswaEntities1();

        // GET: Nilai
        public ActionResult Index(int? page, string search)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var tabel_nilai = db.tabel_nilai.Include(t => t.tabel_mahasiswa).Include(t => t.tabel_matakuliah);
            if (!String.IsNullOrEmpty(search))
            {
                tabel_nilai = tabel_nilai.Where(t => t.id_nilai.ToString().Contains(search) || t.id_mahasiswa.ToString().Contains(search) || 
                    t.id_matakuliah.ToString().Contains(search) || t.nilai.ToString().Contains(search))
                    .OrderBy(t => t.id_nilai);
            }
            tabel_nilai = tabel_nilai.OrderBy(t => t.id_nilai);
            return View(tabel_nilai.ToPagedList(pageNumber, pageSize));
        }

        // GET: Nilai/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_nilai tabel_nilai = await db.tabel_nilai.FindAsync(id);
            if (tabel_nilai == null)
            {
                return HttpNotFound();
            }
            return View(tabel_nilai);
        }

        // GET: Nilai/Create
        public ActionResult Create()
        {
            var mahasiswa = db.tabel_mahasiswa.Select(m => new
            {
                idMahasiswa = m.id_mahasiswa,
                namaMahasiswa = m.nama_mahasiswa + " - " + m.id_mahasiswa            
            }).ToList();

            var matakuliah = db.tabel_matakuliah.Select(mt => new
            {
                idMatakuliah = mt.id_matakuliah,
                namaMatakuliah = mt.nama_matakuliah + " - " + mt.id_matakuliah
            }).ToList();

            ViewBag.id_mahasiswa = new SelectList(mahasiswa, "idMahasiswa", "namaMahasiswa");
            ViewBag.id_matakuliah = new SelectList(matakuliah, "idMatakuliah", "namaMatakuliah");
            return View();
        }

        // POST: Nilai/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_nilai,id_mahasiswa,id_matakuliah,nilai")] tabel_nilai tabel_nilai)
        {
            if (ModelState.IsValid)
            {
                db.tabel_nilai.Add(tabel_nilai);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_mahasiswa = new SelectList(db.tabel_mahasiswa, "id_mahasiswa", "nama_mahasiswa", tabel_nilai.id_mahasiswa);
            ViewBag.id_matakuliah = new SelectList(db.tabel_matakuliah, "id_matakuliah", "nama_matakuliah", tabel_nilai.id_matakuliah);
            return View(tabel_nilai);
        }

        // GET: Nilai/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_nilai tabel_nilai = await db.tabel_nilai.FindAsync(id);
            if (tabel_nilai == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_mahasiswa = new SelectList(db.tabel_mahasiswa, "id_mahasiswa", "nama_mahasiswa", tabel_nilai.id_mahasiswa);
            ViewBag.id_matakuliah = new SelectList(db.tabel_matakuliah, "id_matakuliah", "nama_matakuliah", tabel_nilai.id_matakuliah);
            return View(tabel_nilai);
        }

        // POST: Nilai/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_nilai,id_mahasiswa,id_matakuliah,nilai")] tabel_nilai tabel_nilai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabel_nilai).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_mahasiswa = new SelectList(db.tabel_mahasiswa, "id_mahasiswa", "nama_mahasiswa", tabel_nilai.id_mahasiswa);
            ViewBag.id_matakuliah = new SelectList(db.tabel_matakuliah, "id_matakuliah", "nama_matakuliah", tabel_nilai.id_matakuliah);
            return View(tabel_nilai);
        }

        // GET: Nilai/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_nilai tabel_nilai = await db.tabel_nilai.FindAsync(id);
            if (tabel_nilai == null)
            {
                return HttpNotFound();
            }
            return View(tabel_nilai);
        }

        // POST: Nilai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tabel_nilai tabel_nilai = await db.tabel_nilai.FindAsync(id);
            db.tabel_nilai.Remove(tabel_nilai);
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
