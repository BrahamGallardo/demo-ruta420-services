﻿using Ardalis.Specification;
using Demo.Ruta420.Domain.Entities;

namespace Demo.Ruta420.Application.Common.Specifications.UserSpec
{
    public class GetByEmailSpecification : Specification<User>
    {
        public GetByEmailSpecification(string email)
        {
            Query.Where(e => e.Email.Equals(email));
            Query.Include(e => e.Role);
        }
    }
}
