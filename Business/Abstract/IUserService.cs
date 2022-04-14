﻿using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(int id);

        void Add(User user);

        void Update(User user);

        void Delete(User user);
    }
}
