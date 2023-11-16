﻿namespace Demo.Ruta420.Domain.Entities
{
    public class Session : BaseEntity
    {
        public int UserId { get; set; }
        public bool? Active { get; set; }
        public User User { get; set; }
    }
}
