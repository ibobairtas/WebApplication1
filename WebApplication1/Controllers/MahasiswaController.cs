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
using System.Security.Cryptography;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;

namespace WebApplication1.Controllers
{
    public class MahasiswaController : Controller
    {
        private DBMahasiswaEntities1 db = new DBMahasiswaEntities1();

        // GET: Mahasiswa
        public ActionResult Index(int? page, string sortOrder)
        {
            var mahasiswa = db.tabel_mahasiswa.OrderBy(m => m.id_mahasiswa);
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(mahasiswa.ToPagedList(pageNumber, pageSize));
        }

        // GET: Mahasiswa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mahasiswa/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_mahasiswa,nama_mahasiswa")] tabel_mahasiswa tabel_mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.tabel_mahasiswa.Add(tabel_mahasiswa);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tabel_mahasiswa);
        }

        // GET: Mahasiswa/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_mahasiswa tabel_mahasiswa = await db.tabel_mahasiswa.FindAsync(id);
            if (tabel_mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(tabel_mahasiswa);
        }

        // POST: Mahasiswa/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_mahasiswa,nama_mahasiswa")] tabel_mahasiswa tabel_mahasiswa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabel_mahasiswa).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tabel_mahasiswa);
        }

        // GET: Mahasiswa/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tabel_mahasiswa tabel_mahasiswa = await db.tabel_mahasiswa.FindAsync(id);
            if (tabel_mahasiswa == null)
            {
                return HttpNotFound();
            }
            db.tabel_mahasiswa.Remove(tabel_mahasiswa);
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
