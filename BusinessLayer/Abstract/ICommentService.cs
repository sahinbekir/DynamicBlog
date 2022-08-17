using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
        //void BlogUpdate(Blog blog);
        //void BlogDelete(Blog blog);
        List<Comment> GetListAll(int id);
        //Blog GetById(int id);
        //List<Blog> GetBlogListWithCategory();
    }
}
