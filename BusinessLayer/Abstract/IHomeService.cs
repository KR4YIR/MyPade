using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHomeService : IGenericService<Sal>
    {
        public List<Sal> TGetPostWithUser(string category, string city);
    }
}