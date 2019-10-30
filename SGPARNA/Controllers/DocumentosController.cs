using SGPARNA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGPARNA.Controllers
{
    public class DocumentosController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Documentos
        public ActionResult Achados()
        {
            return View(db.Documentos_Achados);
        } 
        public ActionResult Anunciar()
        {
            return View();
        } 
        public ActionResult Perdidos()
        {
            return View(db.Documentos_Perdidos);
        }
    }
}