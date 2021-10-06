﻿using System.Linq;

namespace ServiceClient.Services
{
    public interface IPersonRepository
    {
        IQueryable<Person> Load();
    }
}