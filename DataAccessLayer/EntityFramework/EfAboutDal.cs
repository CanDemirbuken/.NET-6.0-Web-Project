using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal // CRUD dışında bir işlem yapılması gerekirse ve bu işlem sadece ilgili Entity'e ait olursa IAboutDal kısmını kullanıyoruz
    {
    }
}
