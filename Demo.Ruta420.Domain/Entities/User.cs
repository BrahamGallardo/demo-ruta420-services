﻿namespace Demo.Ruta420.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string? LastName { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual Role Role { get; set; }
    }
}
