using MvcUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUygulama.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        NorthwindEntities pro = new NorthwindEntities();
        public ActionResult Index()
        {
            List<Products> urun = pro.Products.ToList();
            ViewBag.Urunler = urun;
            List<Categories> cat = pro.Categories.ToList();
            ViewBag.Categoriler=cat;
            return View();
        }
        public ActionResult UrunEkle()
        {
            List<Categories> cat = pro.Categories.ToList();
            ViewBag.Categoriler = cat;
            List<Suppliers> sup = pro.Suppliers.ToList();
            ViewBag.Supplier = sup;
            return View();
        }
        [HttpPost] //Veri ekleme yapılacaksa yazılır
        public ActionResult UrunEkle(string Ad,decimal Fiyat,short Stok,int cId,int tId) //Formda seçili bulunan değerlerle 
        {                                                                                //aynı isimde parametreler verilir.
            Products p = new Products
            {
                ProductName = Ad,
                UnitPrice=Fiyat,
                UnitsInStock=Stok,
                CategoryID=cId,
                SupplierID=tId
            };
            pro.Products.Add(p);
            pro.SaveChanges();
            return RedirectToAction("Index"); //İşlem gerçekleştikten sonra Index view'ına yönlendirir.
        }
    }
}