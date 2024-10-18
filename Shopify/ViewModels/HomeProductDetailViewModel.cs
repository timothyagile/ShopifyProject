using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.Models;

namespace Shopify.ViewModels
{
    public class HomeProductDetailViewModel
    {
        public TDanhMucSp danhMucSp { get; set; }
        public List<TAnhSp> anhSps { get; set; }
    }
}