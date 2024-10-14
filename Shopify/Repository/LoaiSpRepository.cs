using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopify.Models;

namespace Shopify.Repository
{
    public class LoaiSpRepository : ILoaiSPRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LoaiSpRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TLoaiSp Add(TLoaiSp item) 
        {
            _dbContext.TLoaiSps.Add(item);
            _dbContext.SaveChanges();
            return item;
        }
        public TLoaiSp Update(TLoaiSp item) 
        {
            _dbContext.TLoaiSps.Update(item);
            _dbContext.SaveChanges();
            return item;
        }

        public TLoaiSp Remove(TLoaiSp loaiSp)
        {
            throw new NotImplementedException();
        }

        public TLoaiSp GetById(string id)
        {
            return _dbContext.TLoaiSps.Find(id);
        }

        public IEnumerable<TLoaiSp> GetAll()
        {
            return _dbContext.TLoaiSps;
        }
    }
}