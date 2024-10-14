using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shopify.Models;

namespace Shopify.Repository
{
    public interface ILoaiSPRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Remove(TLoaiSp loaiSp);
        IEnumerable<TLoaiSp> GetAll();
        TLoaiSp GetById(string id);
    }
}