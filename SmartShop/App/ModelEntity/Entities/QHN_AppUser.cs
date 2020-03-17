using Microsoft.AspNetCore.Identity;
using SmartShop.App.ModelEntity.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartShop.App.ModelEntity.Entities
{
    [Table("QHN_AppUsers")]
    public class QHN_AppUser : IdentityUser<Guid>
    {
        public QHN_AppUser()
        {
        }

        public QHN_AppUser(Guid id, string username, string password, string email, string fullname, string avatar, string securityStamp, string normalizedUserName,
            string normalizedEmail, Status status, string temp)
        {
            Id = id;
            UserName = username;
            PasswordHash = password;
            Email = email;
            FullName = fullname;
            Avatar = avatar;
            SecurityStamp = securityStamp;
            NormalizedEmail = normalizedEmail;
            NormalizedUserName = normalizedUserName;
            Status = status;
            Temp = temp;
        }

        [MaxLength(150)]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Avatar { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public Status Status { get; set; }

        [MaxLength(150)]
        public string Temp { get; set; }
    }
}