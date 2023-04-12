using Online_Bank.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.Dtos
{
    [Table("Clients")]
    public class UserDTO : IDto
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(120)]
        public string FullName { get; set; }

        [Required]
        public int PIN { get; set; }

        [Required]
        [StringLength(12)]
        public string PasswordHash { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength (10)]
        public string PhoneNumber { get; set; }

        public UserDTO(string fullName, int PIN, string passwordHash, string email, string phoneNumber)
        {
          FullName = fullName;
          this.PIN = PIN;
          PasswordHash = passwordHash;
          Email = email;
          PhoneNumber = phoneNumber;

        }

        public UserDTO(string fullName, int pin, string passwordHash, string email, string phoneNumber, List<AccountDTO>? accounts = null)
        {
          this.FullName = fullName;
          this.PasswordHash = passwordHash;
          this.Email = email;
          this.PhoneNumber = phoneNumber;
          this.PIN = pin;
        }

        public int getId()
        {
          return this.ID;
        }
    }
}
