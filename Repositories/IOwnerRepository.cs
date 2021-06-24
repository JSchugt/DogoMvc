﻿using DogoMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogoMvc.Repositories
{
    public interface IOwnerRepository
    {
        Owner GetOwner(int id);
        List<Owner> Owners();
        public void DeleteOwner(int id);
        public void UpdateOwner(Owner owner);
        public void AddOwner(Owner owner);

    }
}
