using System;
using Domain.Enums;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public UserRoleEnum Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}

