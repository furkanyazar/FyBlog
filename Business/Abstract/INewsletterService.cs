using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface INewsletterService
    {
        List<Newsletter> GetAll();

        Newsletter GetById(int id);

        void Add(Newsletter newsletter);

        void Update(Newsletter newsletter);

        void Delete(Newsletter newsletter);
    }
}
