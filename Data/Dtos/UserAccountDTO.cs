using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.Dtos
{
  [Table("userAccount")]
  public class UserAccountDTO
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int AccountNumber { get; set; }

    [ForeignKey("AccountNumber")]
    public AccountDTO Account { get; set; }

    [ForeignKey("UserId")]
    public UserDTO User { get; set; }

    public UserAccountDTO(int userId, int accountNumber)
    {
      this.UserId = userId;
      this.AccountNumber = accountNumber;
    }
  }
}
