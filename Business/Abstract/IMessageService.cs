using Core.Business;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService : IEntityService<Message>
    {
        List<Message> GetAllByReceiverId(int receiverId);
    }
}
