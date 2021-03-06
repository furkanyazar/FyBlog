using Core.DataAccess;
using Entities.Concrete;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>
    {
        List<Message> GetAllByReceiverId(int receiverId);

        List<Message> GetAllBySenderId(int senderId);

        Message GetByMessageId(int messageId);
    }
}
