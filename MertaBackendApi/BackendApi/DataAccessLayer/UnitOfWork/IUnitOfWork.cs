﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackendApi.DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
