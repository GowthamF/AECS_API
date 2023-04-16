﻿namespace Authentication_API.Models
{
    public class User
    {
        public User(string userName)
        {
            UserName = userName;
        }

        public Guid UserId { get; set; } = Guid.NewGuid();
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
