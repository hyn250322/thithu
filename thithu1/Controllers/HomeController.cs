using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thithu1.Context;
using thithu1.Models;

namespace thithu1.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanQuanAoEntities db = new QuanLyBanQuanAoEntities();
        public ActionResult Index()
        {
            ViewBag.PhanLoaiSanPhams = db.PhanLoaiSanPhams.ToList();
            var distinctProducts = db.Sanphams
                .GroupBy(p => p.TenSanpham)
                .Select(g => g.FirstOrDefault())
                .ToList();

            ViewBag.SanPhams = distinctProducts;
            return View();
        }

        public ActionResult GetProductsByCategory(string category)
        {
            IEnumerable<thithu1.Context.Sanpham> products;
            string categoryName = category.TrimStart('#');

            var categoryId = db.PhanLoaiSanPhams
                .Where(c => c.TenPhanLoai.ToLower() == categoryName)
                .Select(c => c.PhanLoaiSanPhamID)
                .FirstOrDefault();

            // Lọc sản phẩm theo phân loại
            products = db.Sanphams
                                .Where(p => p.PhanLoaiSanPhamID == categoryId)
                                .ToList();

            // Trả về Partial View với danh sách sản phẩm
            return PartialView("~/Views/Home/_ProductList.cshtml", products);
        }

        public ActionResult Create()
        {
            var phanloai = db.PhanLoaiSanPhams.ToList();
            ViewBag.PhanLoaiSanPhamList = new SelectList(phanloai, "PhanLoaiSanPhamID", "TenPhanLoai");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sanpham model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.ImageFile.ContentLength > 0)
                {
                    var allowedExtensions = new[] { ".jpg" };
                    var fileExtension = Path.GetExtension(model.ImageFile.FileName).ToLower();

                    if (!allowedExtensions.Contains(fileExtension))
                    {
                        ModelState.AddModelError("ImageFile", "Only .jpg files are allowed");
                    }
                    else
                    {
                        var fileName = Path.GetFileName(model.ImageFile.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/images/"), fileName);
                        model.ImageFile.SaveAs(path);
                        model.AnhDaiDien = fileName;
                    }
                }
                else
                {
                    ModelState.AddModelError("ImageFile", "Please upload an image file");
                }

                if (ModelState.IsValid)
                {
                    db.Sanphams.Add(model);
                    db.SaveChanges();
                    ViewBag.InsertMessage = "Product created successfully.";
                    return RedirectToAction("Index");
                }
            }

            // Nếu không thành công, render lại view với dữ liệu
            var phanloai = db.PhanLoaiSanPhams.ToList();
            ViewBag.PhanLoaiSanPhamList = new SelectList(phanloai, "PhanLoaiSanPhamID", "TenPhanLoai");

            // Trả về lại view cùng với model để hiển thị lỗi
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}