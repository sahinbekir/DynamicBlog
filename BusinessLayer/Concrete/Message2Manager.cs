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
    public class Message2Manager:IMessage2Service
    {
        IMessage2Dal _message2Dal;
        public Message2Manager(IMessage2Dal message2Dal)
        {
            _message2Dal = message2Dal;
        }

        public Message2 GetById(int id)
        {
            return _message2Dal.GetById(id);
        }

        public List<Message2> GetInboxMessagesListByWriter(int id)
        {
            return _message2Dal.GetInListWithMessageByWriter(id);
        }
        public List<Message2> GetInbox3MessagesListByWriter(int id)
        {
            return _message2Dal.GetInList3WithMessageByWriter(id).TakeLast(3).OrderByDescending(x=>x.MessageDate).ToList();
        }

        public List<Message2> GetListAll()
        {
            return _message2Dal.GetListAll();
        }

        public List<Message2> GetSendboxMessagesListByWriter(int id)
        {
            return _message2Dal.GetSendListWithMessageByWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _message2Dal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message2 t)
        {
            throw new NotImplementedException();
        }
    }
}
