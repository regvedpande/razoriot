using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BestEmployeeManagement.Models
{
    public class UserRegistrationModel
    {
        public int UserRegistrationId { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public string UniqueUserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; }
    }
}