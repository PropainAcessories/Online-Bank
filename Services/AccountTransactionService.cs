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
  public class AccountTransactionService
  {
    private AccountTransactionDAO accountTransactionDAO;

    public AccountTransactionService(ProjectContext context)
    {
      this.accountTransactionDAO = new AccountTransactionDAO(context);
    }

    public List<TransactionDTO> GetAllTransactionOfAccount(int accountNumber)
    {
      return this.accountTransactionDAO.GetTransactionByAccountNumber(accountNumber).ToList();
    }

    public List<AccountDTO> GetAllAccountOfTransaction(int transactionId)
    {
      return this.accountTransactionDAO.GetAccountByTransactionId(transactionId).ToList();
    }

    public Boolean LinkTransactionToAccount(int  transactionId, int accountNumber)
    {
      AccountTransactionDTO createdLink = this.accountTransactionDAO.GetByAccountNumberAndTransactionId(accountNumber, transactionId);
      return this.accountTransactionDAO.Create(createdLink);
    }

    public AccountTransactionDTO UnlinkTransactionToAccount(int transactionId, int accountNumber)
    {
      AccountTransactionDTO deletedLink = this.accountTransactionDAO.GetByAccountNumberAndTransactionId(accountNumber, transactionId);
      return this.accountTransactionDAO.Delete(deletedLink);
    }

    public void UnlinkAllTransactionsFromAccount(int accountNumber)
    {
      List<TransactionDTO> transactionList = this.GetAllTransactionOfAccount(accountNumber);
      foreach (TransactionDTO transaction in transactionList)
      {
        AccountTransactionDTO accountTransactionToDelete = this.accountTransactionDAO.GetByAccountNumberAndTransactionId(accountNumber, transaction.Id);
        this.accountTransactionDAO.Delete(accountTransactionToDelete);
      }
    }

    public void UnlinkAllAccountFromTransaction(int transactionId)
    {
      List<AccountDTO> accountOfTransaction = this.accountTransactionDAO.GetAccountByTransactionId(transactionId);
      foreach (AccountDTO account in accountOfTransaction)
      {
        AccountTransactionDTO accountTransactionToDelete = this.accountTransactionDAO.GetByAccountNumberAndTransactionId(account.AccountNumber, transactionId);
        this.accountTransactionDAO.Delete(accountTransactionToDelete);
      }
    }
  }
}
