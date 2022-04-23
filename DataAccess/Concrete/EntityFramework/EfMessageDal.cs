using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepository<Message, MvcCoreDbContext>, IMessageDal
    {
        public List<Message> GetAllByReceiverId(int receiverId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Messages.Where(x => x.ReceiverUserId == receiverId).OrderByDescending(x => x.MessageDateOf).Include(x => x.ReceiverUser).Include(x => x.SenderUser).ToList();
            }
        }

        public List<Message> GetAllBySenderId(int senderId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Messages.Where(x => x.SenderUserId == senderId).OrderByDescending(x => x.MessageDateOf).Include(x => x.ReceiverUser).Include(x => x.SenderUser).ToList();
            }
        }

        public Message GetByMessageId(int messageId)
        {
            using (var context = new MvcCoreDbContext())
            {
                return context.Messages.Include(x => x.ReceiverUser).Include(x => x.SenderUser).SingleOrDefault(x => x.MessageId == messageId);
            }
        }
    }
}
