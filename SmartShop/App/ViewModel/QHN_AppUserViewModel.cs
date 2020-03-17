using SmartShop.App.ModelEntity.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ViewModel
{
    public class QHN_AppUserViewModel
    {
        public QHN_AppUserViewModel()
        {
        }

        public QHN_AppUserViewModel(Guid id, string username, string password, string email, string fullname, string avatar, string securityStamp, string normalizedUserName,
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

        public Guid Id { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(150)]
        public string PasswordHash { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string NormalizedEmail { get; set; }

        [StringLength(30)]
        public string NormalizedUserName { get; set; }
        
        [StringLength(150)]
        public string SecurityStamp { get; set; }

        [MaxLength(150)]
        public string FullName { get; set; }

        [MaxLength(150)]
        public string Avatar { get; set; }

       

        [DefaultValue(Status.Active)]
        public Status Status { get; set; }

        [MaxLength(150)]
        public string Temp { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
