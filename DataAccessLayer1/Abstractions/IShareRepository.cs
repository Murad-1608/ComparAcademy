﻿using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstractions
{
    public interface IShareRepository : IGenericRepository<Share>
    {
        List<Share> GetWithPostAndUser(int id);
    }
}
