﻿namespace Demo.Ruta420.Application.Models
{
    public class RoleDto : BaseDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<UserDto>? Users { get; set; }
    }
}
