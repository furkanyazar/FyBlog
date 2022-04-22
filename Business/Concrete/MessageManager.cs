using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MessageManager : EntityManager<Message, IMessageDal>, IMessageService
    {
        public MessageManager(IMessageDal tdal) : base(tdal)
        {
        }

        public List<Message> GetAllByReceiverId(int receiverId)
        {
            return _tdal.GetAllByReceiverId(receiverId);
        }
    }
}
