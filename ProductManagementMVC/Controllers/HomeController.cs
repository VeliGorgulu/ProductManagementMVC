using ProductManagementMVC.DataAccess;
using ProductManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementMVC.Controllers
{
    public class HomeController : Controller
    {
        ProductDal _productDal = new ProductDal();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add(Product product)
        {
            string message = string.Empty;
            try
            {
                _productDal.Add(product);
                message = "Added";
            }
            catch (Exception)
            {
                message = "Failed";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(Product product)
        {
            string message = string.Empty;
            try
            {
                _productDal.Update(product);
                message = "Updated";
            }
            catch (Exception)
            {
                message = "Failed";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(Product product)
        {
            string message = string.Empty;
            try
            {
                _productDal.Delete(product);
                message = "Deleted";
            }
            catch (Exception)
            {
                message = "Failed";
            }
            return Json(message, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(int id)
        {
            try
            {
                var product = _productDal.Get(id);

                return Json(product, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(exception, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAll()
        {
            try
            {
                var products = _productDal.GetAll();

                return Json(products, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exception)
            {
                return Json(exception, JsonRequestBehavior.AllowGet);
            }
        }

    }
}