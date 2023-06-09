﻿using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ICategory
{
    public interface CategoryInterface : GenericInterface<Category>
    {

        Task<IList<Category>> ListUserCategories( string email);

    }
}
