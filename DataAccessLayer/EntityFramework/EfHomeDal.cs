using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfHomeDal : GenericRepository<Sal>, IHomeDal
    {
        public List<Sal> GetPostWithUser(string category, string city)
        {
            var context = new Context();
            var query = context.Homes.Include(c => c.User).AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(x => x.Category == category);
            }

            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(x => x.City == city);
            }

            return query.ToList();
        }
    }
}