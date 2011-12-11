using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Fifa.WebUi.Models
{
    public class User : IPrincipal
    {
        private IIdentity identity;
        private string name;

        public User()
        {
            PasswordSalt = Guid.NewGuid().ToString();
            RegistrationDate = DateTime.Now;
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                identity = new UserIdentity(name);
            }
        }

        [Required]
        [StringLength(50), Display(Name = "Password")]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(50), Display(Name = "Password Confirmation")]
        public string PasswordSalt { get; set; }

        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }

        [ScaffoldColumn(false)]
        public bool IsAdmin { get; set; }

        public bool VerifyPassword(string password)
        {
            var md5 = MD5.Create();

            var hashBytes = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var hash = BitConverter.ToString(hashBytes) + PasswordSalt;

            hashBytes = md5.ComputeHash(Encoding.Default.GetBytes(hash));
            hash = BitConverter.ToString(hashBytes);

            return hash == PasswordHash;
        }

        public void InitializePasswordHash()
        {
            if (PasswordHash != PasswordSalt)
            {
                throw new ApplicationException("Password must match its confirmation.");
            }

            var md5 = MD5.Create();

            var hashBytes = md5.ComputeHash(Encoding.Default.GetBytes(PasswordHash));
            var hash = BitConverter.ToString(hashBytes) + PasswordSalt;

            hashBytes = md5.ComputeHash(Encoding.Default.GetBytes(hash));
            PasswordHash = BitConverter.ToString(hashBytes);
        }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            var isAdminRole = role.ToLowerInvariant().StartsWith("admin");
            return isAdminRole && IsAdmin;
        }

        public IIdentity Identity
        {
            get { return identity; }
        }

        #endregion

        #region Nested type: UserIdentity

        internal class UserIdentity : IIdentity
        {
            private readonly string name;

            public UserIdentity(string name)
            {
                this.name = name;
            }

            #region IIdentity Members

            public string Name
            {
                get { return name; }
            }

            public string AuthenticationType
            {
                get { return "Custom"; }
            }

            public bool IsAuthenticated
            {
                get { return true; }
            }

            #endregion
        }

        #endregion
    }
}