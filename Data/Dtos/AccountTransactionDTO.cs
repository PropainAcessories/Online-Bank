using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.Dtos
{
  [Table("accountTransaction")]
  public class AccountTransactionDTO
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public int AccountNumber { get; set; }

    [Required]
    public int TransactionId { get; set; }

    [ForeignKey("AccountNumber")]
    public AccountDTO Account { get; set; }

    [ForeignKey("TransactionId")]
    public TransactionDTO Transaction { get; set; }

    public AccountTransactionDTO(int accountNumber, int transactionId)
    {
      this.AccountNumber = accountNumber;
      this.TransactionId = transactionId;
    }
  }
}
