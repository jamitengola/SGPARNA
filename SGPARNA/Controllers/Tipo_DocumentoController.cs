using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SGPARNA.Models;

namespace SGPARNA.Controllers
{
    public class Tipo_DocumentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tipo_Documento
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.tipo_Doocumentos.ToList());
        }

        // GET: Tipo_Documento/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Documento tipo_Documento = db.tipo_Doocumentos.Find(id);
            if (tipo_Documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Documento);
        }

        // GET: Tipo_Documento/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Documento/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Numero,Imagem")] Tipo_Documento tipo_Documento)
        {
            if (ModelState.IsValid)
            {
                db.tipo_Doocumentos.Add(tipo_Documento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipo_Documento);
        }

        // GET: Tipo_Documento/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Documento tipo_Documento = db.tipo_Doocumentos.Find(id);
            if (tipo_Documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Documento);
        }

        // POST: Tipo_Documento/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Numero,Imagem")] Tipo_Documento tipo_Documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipo_Documento);
        }

        // GET: Tipo_Documento/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Documento tipo_Documento = db.tipo_Doocumentos.Find(id);
            if (tipo_Documento == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Documento);
        }

        // POST: Tipo_Documento/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Documento tipo_Documento = db.tipo_Doocumentos.Find(id);
            db.tipo_Doocumentos.Remove(tipo_Documento);
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
