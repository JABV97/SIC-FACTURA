using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExcelDataReader;
using shanuMVCUserRoles.Entidad;

namespace shanuMVCUserRoles.Controllers
{
    public class InventarioMasivoController : Controller
    {
        // GET: InventarioMasivo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase uploadfile)
        {
            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    //ExcelDataReader works on binary excel file
                    Stream stream = uploadfile.InputStream;

                    //We need to written the Interface.
                    IExcelDataReader reader = null;

                    if (uploadfile.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (uploadfile.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }

                    //treats the first row of excel file as Coluymn Names
                    var conf = new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    };

                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();
                    reader.Close();
                    
                    //Creamos el Datatables e instanciamos el contexto
                    DB_A372E9_nopcurvasDesignEntities entidadContexto = new DB_A372E9_nopcurvasDesignEntities();
                    DataTable datatable = result.Tables[0];

                    foreach (DataRow row in datatable.Rows.Cast<DataRow>().Skip(1))
                    {
                        foreach(DataColumn col in datatable.Columns) {

                            string slugProducto = row[1].ToString().Replace(" ", "-");
                            string slugCategoria = row[5].ToString().Replace(" ", "-");
                            string slugSubCategoria = row[6].ToString().Replace(" ", "-");

                            slugProducto.ToLower();
                            slugCategoria.ToLower();
                            slugSubCategoria.ToLower();

                            entidadContexto.spInsertProductsInventory(row[1].ToString(), row[8].ToString(), row[2].ToString(), row[7].ToString(), 
                                Decimal.Parse(row[3].ToString()), row[10].ToString(), slugProducto, row[5].ToString(), slugCategoria, row[6].ToString(),
                                slugSubCategoria, row[11].ToString(), row[9].ToString(), int.Parse(row[4].ToString()), row[0].ToString());
                        }

                    }                       
                    
                    //Sending result data to View
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("File", "Plase upload your file");
            }
            return View();
        }
    }
}
    
