using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal: IGenericDal<Message2>
    {
        List<Message2> GetInListWithMessageByWriter(int id);
        List<Message2> GetInList3WithMessageByWriter(int id);

        List<Message2> GetSendListWithMessageByWriter(int id);

    }
}
