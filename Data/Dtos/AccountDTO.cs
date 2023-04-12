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
  [Table("Accounts")]
  public class AccountDTO: IDto
  {
    [Key]
    public int AccountNumber { get; set; }

    [Required]
    [StringLength(10)]
    public string AccountType { get; set; }

    [Required]
    public double Balance { get; set; }

    public List<UserAccountDTO> userAccount { get; set; } = null;

    public List<AccountTransactionDTO> accountTransaction { get; set; } = null;

    public AccountDTO(string AccountType)
    {
      this.AccountType = AccountType;
    }

    public AccountDTO(int AccountNumber, string AccountType, float Balance)
    {
      this.AccountNumber = AccountNumber;
      this.AccountType = AccountType;
      this.Balance = Balance;
    }
  }
}
