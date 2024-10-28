using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shopify.Models;
using X.PagedList;

namespace Shopify.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]

    public class HomeAdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {

            return View();
        }

        [Route("DanhMucSanPham")]
        public IActionResult DanhMucSanPham(int ?page)
        {
            int pageSize = 16;
            int pageIndex = page==null?1 : page.Value;
            var lst = db.TDanhMucSps.ToList();
            PagedList<TDanhMucSp> listSp = new PagedList<TDanhMucSp>(lst,pageIndex,pageSize);
            return View(listSp);
        }

        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");

            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp sanPham)
        {
            if(ModelState.IsValid)
            {
                db.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);   
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");
            var sp = db.TDanhMucSps.Find(maSanPham);
            return View(sp);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp sanPham)
        {
            if(ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);   
        }

        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSp = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();    
            if(chiTietSp.Count() > 0)
            {
                TempData["Message"] = "Khong xoa duoc san pham nay";
                return RedirectToAction("DanhMucSanPham");
            }
            else
            {
                var anhSps = db.TAnhSps.Where(x => x.MaSp == maSanPham).ToList();
                if(anhSps.Any()) db.RemoveRange(anhSps);
                db.Remove(db.TDanhMucSps.Find(maSanPham));
                db.SaveChanges();
                TempData["Message"] = "San pham nay da duoc xoa";
                return RedirectToAction("DanhMucSanPham");
            }
        }

        //NGUOI DUNG

        [Route("danhsachnguoidung")]
        public IActionResult DanhSachNguoiDung(int ?page)
        {
            int pageSize = 16;
            int pageIndex = page==null?1 : page.Value;
            var lst = db.TNhanViens.ToList();
            PagedList<TNhanVien> listUsr = new PagedList<TNhanVien>(lst,pageIndex,pageSize);
            return View(listUsr);
        }

        [Route("themnguoidungmoi")]
        [HttpGet]
        public IActionResult ThemNguoiDungMoi()
        {
            // ViewBag.MaChatLieu = new SelectList(db.TChatLieus, "MaChatLieu", "ChatLieu");
            // ViewBag.MaHangSx = new SelectList(db.THangSxes, "MaHangSx", "HangSx");
            // ViewBag.MaNuocSx = new SelectList(db.TQuocGia, "MaNuoc", "TenNuoc");
            // ViewBag.MaLoai = new SelectList(db.TLoaiSps, "MaLoai", "Loai");
            // ViewBag.MaDt = new SelectList(db.TLoaiDts, "MaDt", "TenLoai");

            return View();
        }
        [Route("themnguoidungmoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNguoiDungMoi(TNhanVien nhanVien)
        {
            if(ModelState.IsValid)
            {
                db.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("DanhSachNguoiDung");
            }
            return View(nhanVien);   
        }

        [Route("suanguoidung")]
        [HttpGet]
        public IActionResult SuaNguoiDung(string maNhanVien)
        {
            var sp = db.TNhanViens.Find(maNhanVien);
            return View(sp);
        }
        [Route("suanguoidung")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNguoiDung(TNhanVien sanPham)
        {
            if(ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachNguoiDung");
            }
            return View(sanPham);   
        }

        [Route("xoanguoidung/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaNguoiDung(string id)
        {
            // Tìm người dùng theo id
            var nhanVien = db.TNhanViens.Find(id);

            if (nhanVien == null)
            {
                // Nếu không tìm thấy, có thể thêm thông báo lỗi ở đây
                return NotFound(); // Hoặc bạn có thể redirect về một trang khác
            }

            db.TNhanViens.Remove(nhanVien); // Xóa người dùng
            db.SaveChanges(); // Lưu thay đổi

            return RedirectToAction("DanhSachNguoiDung"); // Chuyển hướng đến danh sách người dùng
        }
    }
}
