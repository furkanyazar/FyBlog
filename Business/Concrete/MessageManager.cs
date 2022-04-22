using Business.Abstract;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MessageManager : EntityManager<Message, IMessageDal>, IMessageService
    {
        public MessageManager(IMessageDal tdal) : base(tdal)
        {
        }
    }
}
