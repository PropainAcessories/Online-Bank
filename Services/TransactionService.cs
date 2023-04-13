using Online_Bank.Data.Contexts;
using Online_Bank.Data.DAOs;
using Online_Bank.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Services
{
  public class TransactionService
  {
    private TransactionDAO transactionDAO;
    
    public TransactionService(ProjectContext context)
    {
      this.transactionDAO = new TransactionDAO(context);
    }

    public TransactionDTO getTransactionById(int id)
    {
      return this.transactionDAO.GetTransactionById(id);
    }

    public TransactionDTO saveNewTransaction(TransactionDTO newTransaction)
    {
      return this.transactionDAO.Create(newTransaction);
    }
  }
}
