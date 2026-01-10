using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ChangeContactUsStatusToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetActiveContactUsList()
        {
            using(var c=new Context())
            {
                var values = c.ContactUses.Where(x => x.MessageStatus == true).ToList();
                return values;
            }
        }

        public List<ContactUs> GetInactiveContactUsList()
        {
            using(var c=new Context())
            {
                var values = c.ContactUses.Where(x => x.MessageStatus == false).ToList();
                return values;
            }
        }
    }
}
