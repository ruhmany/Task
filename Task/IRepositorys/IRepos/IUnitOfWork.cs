﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories.IRepos
{
    public interface IUnitOfWork
    {
        int CommitChanges();
    }
}
