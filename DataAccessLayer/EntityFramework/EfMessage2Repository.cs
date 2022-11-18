﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInList3WithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s?.Include(x => x.SenderUser).Where(x => x.MessageReceiver == id).ToList();
            }
        }
        public List<Message2> GetInListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s?.Include(x => x.SenderUser).Where(x => x.MessageReceiver == id).ToList();
            }
        }
        public List<Message2> GetSendListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Message2s?.Include(x => x.ReceiverUser).Where(x => x.MessageSender == id).ToList();
            }
        }
    }
}
