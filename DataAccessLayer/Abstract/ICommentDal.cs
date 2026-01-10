using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        public List<Comment> GetCommentListWihtDestination();
        public List<Comment> GetCommentListWithDestinationAndUser(int id);
        public List<Comment> GetCommentWithUser(int id);
    }
}
