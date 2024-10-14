using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.FileIO;
using Shopify.Models;
using X.PagedList;

namespace Shopify.Controllers;

public class HomeController : Controller
{
    ApplicationDbContext db = new ApplicationDbContext();
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(int ?page)
    {
        int pageSize = 8;
        int pageIndex = page==null?1 : page.Value;
        var lst = db.TDanhMucSps.AsNoTracking().OrderBy(x=>x.TenSp);
        PagedList<TDanhMucSp> listSp = new PagedList<TDanhMucSp>(lst,pageIndex,pageSize);
        return View(listSp);
    }

    public IActionResult SanPhamTheoLoai(string maLoai, int ?page)
    {
        int pageSize = 8;
        int pageIndex = page==null?1 : page.Value;
        var lst = db.TDanhMucSps.AsNoTracking().Where(x => x.MaLoai == maLoai).OrderBy(x=>x.TenSp);
        PagedList<TDanhMucSp> listSp = new PagedList<TDanhMucSp>(lst,pageIndex,pageSize);
        ViewBag.maloai = maLoai;
        return View(listSp);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}