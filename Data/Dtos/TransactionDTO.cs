using Online_Bank.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.Dtos
{
  [Table("Transactions")]
  public class TransactionDTO
  {
    [Key]
    public int Id { get; set; }
    [Required]
    public string? type { get; set; }
    [Required]
    public double amount { get; set; }

    [Required]
    public string currency { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime transactionDate { get; set; }

    public List<AccountTransactionDTO> accountTransaction { get; set; } = null;

    public TransactionDTO(int id, string? type, double amount, string currency, List<AccountTransactionDTO> accountTransaction)
    {
      Id = id;
      this.type = type;
      this.amount = amount;
      this.currency = currency;
      this.accountTransaction = accountTransaction;
    } 

    public TransactionDTO(string? type, double amount, string currency)
    {
      this.type = type;
      this.amount = amount;
      this.currency = currency;
    }
    //TODO add live exchange rate thing
    public static double EXCHANGERATE = 1.5;
  }
}
