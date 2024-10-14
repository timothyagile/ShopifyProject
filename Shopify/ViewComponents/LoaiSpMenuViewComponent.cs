using Microsoft.AspNetCore.Mvc;
using Shopify.Repository;

namespace Shopify.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSPRepository _loaiSp;
        public LoaiSpMenuViewComponent(ILoaiSPRepository loaiSPRepository) 
        {
            _loaiSp = loaiSPRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp =  _loaiSp.GetAll().OrderBy(x => x.Loai);
            return View(loaiSp);
        }

    }
}
