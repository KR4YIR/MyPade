using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    internal class PostManager : IGenericService<Sal>
    {
        IHomeDal _homeDal;
public PostManager(IHomeDal homeDal)
        {
            _homeDal = homeDal;
        }

        public void TAdd(Sal t)
        {
            _homeDal.Insert(t);
        }

        public void TDelete(Sal t)
        {
            _homeDal.Delete(t);
        }

        public Sal TGetByID(int id)
        {
            return _homeDal.GetByID(id);
        }

        public List<Sal> TGetList()
        {
            return _homeDal.GetList();
        }

        public void TUpdate(Sal t)
        {
            _homeDal.Update(t);
        }
    }
}
