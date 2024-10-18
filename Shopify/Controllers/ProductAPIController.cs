using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shopify.Models;
using Shopify.Models.ProductModels;

namespace Shopify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAPIController : ControllerBase
    {
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public IEnumerable<Product> GetProducts() 
        {
            var products = (from p in db.TDanhMucSps select new Product
            { 
                MaSp = p.MaSp,
                TenSp = p.TenSp,
                MaLoai = p.MaLoai,
                AnhDaiDien = p.AnhDaiDien,
                GiaLonNhat = p.GiaLonNhat,
            }).ToList();
            return products;
        }
        [HttpGet("{maLoai}")]
        public IEnumerable<Product> GetProducts(string maLoai) 
        {
            var products = (
                from p in db.TDanhMucSps 
                where p.MaLoai == maLoai
                select new Product
            { 
                MaSp = p.MaSp,
                TenSp = p.TenSp,
                MaLoai = p.MaLoai,
                AnhDaiDien = p.AnhDaiDien,
                GiaLonNhat = p.GiaLonNhat,
            }).ToList();
            return products;
        }
    }
}