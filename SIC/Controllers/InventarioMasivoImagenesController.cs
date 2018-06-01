using shanuMVCUserRoles.Entidad;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shanuMVCUserRoles.Controllers
{
    public class InventarioMasivoImagenesController : Controller
    {
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase[] files)
        {
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {
                //Agregamos la BD
                DB_A372E9_nopcurvasDesignEntities context = new DB_A372E9_nopcurvasDesignEntities();
                int idPicture = 0; ;
                string zero = "";
                string pictureName = "";
                //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        pictureName = Path.GetFileName(file.FileName);
                        pictureName = pictureName.Substring(0, pictureName.IndexOf('.'));
                        idPicture = Int32.Parse((context.vPicture_Product.First(p => p.Sku == pictureName).PictureId.ToString()));
                        if (idPicture > 0 && idPicture < 10)
                        {
                            zero = "000000";
                        } else if(idPicture >= 10 && idPicture < 100)
                        {
                            zero = "00000";
                        } else if (idPicture >= 100 && idPicture < 1000)
                        {
                            zero = "0000";
                        } else if (idPicture >= 1000 && idPicture < 10000)
                        {
                            zero = "000";
                        } else if (idPicture >= 10000 && idPicture < 100000)
                        {
                            zero = "00";
                        } else if (idPicture >= 100000 && idPicture < 1000000)
                        {
                            zero = "0";
                        } else
                        {
                            return View();
                        }                                                                                           
                                                                                  
                        var InputFileName = Path.GetFileName(zero + idPicture + "_0.jpg");
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " archivos subidos exitosamente.";
                    }

                }
            }
            return View();
        }
    }
}