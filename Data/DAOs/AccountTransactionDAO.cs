using Online_Bank.Data.Contexts;
using Online_Bank.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.DAOs
{
  public class AccountTransactionDAO
  {
    private ProjectContext context;

    public AccountTransactionDAO(ProjectContext context)
    {
      this.context = context;
    }

    public List<TransactionDTO> GetTransactionByAccountNumber(int accountNumber)
    {
      List<AccountTransactionDTO> allAccountTransactionLinks =
        this.context.AccountTransactions
        .Where(accTrans => accTrans.AccountNumber == accountNumber)
        .Include(accTrans => accTrans.Transaction )
        .ToList();

      List<TransactionDTO> transactionList = new List<TransactionDTO>();
      foreach(AccountTransactionDTO accountTransactionDTO in allAccountTransactionLinks)
      {
        TransactionDTO trans = accountTransactionDTO.Transaction;
        if (!transactionList.Contains(trans))
        {
          transactionList.Add(trans);
        }
      }
      return transactionList;
    }
    //CRUD below
    public List<AccountDTO> GetAccountByTransactionId(int id)
    {
      List<AccountTransactionDTO> allAccountTransactionLinks =
        this.context.AccountTransactions
        .Where(accTrans => accTrans.TransactionId == id)
        .Include(accTrans => accTrans.Account)
        .ToList();

      List<AccountDTO> accountList = new List<AccountDTO>();
      foreach (AccountTransactionDTO accountTransactionDTO in allAccountTransactionLinks)
      {
        AccountDTO account = accountTransactionDTO.Account;
        if(!accountList.Contains(account))
        {
          accountList.Add(account);
        }
      }
      return accountList;
    }
    //CRUD below
    public AccountTransactionDTO GetByAccountNumberAndTransactionId(int accNum, int id)
    {
      return this.context.AccountTransactions
         .Where(accTr => accTr.AccountNumber == accNum && accTr.TransactionId == id)
         .Single();
    }

    public Boolean Create(AccountTransactionDTO newAccountTransaction)
    {
      IDbContextTransaction transaction = context.Database.BeginTransaction();
      this.context.AccountTransactions.Add(newAccountTransaction);
      this.context.SaveChanges();
      string transType = newAccountTransaction.Transaction.type;
      string transCurr = newAccountTransaction.Transaction.currency;
      double transAmount = newAccountTransaction.Transaction.amount;

      if (transCurr.ToLower() == "usd")
      {
        transAmount = transAmount * TransactionDTO.EXCHANGERATE;
      }

      if (transType.ToLower() == "deposit" || transType.ToLower() == "debit")
      {
        newAccountTransaction.Account.Balance += transAmount;
      }
      else
      {
        if(newAccountTransaction.Account.Balance >= transAmount)
        {
          newAccountTransaction.Account.Balance -= transAmount;
          this.context.Accounts.Update(newAccountTransaction.Account);
          this.context.SaveChanges();
        }
        else
        {
          transaction.Rollback();
          return false;
        }
      }

      transaction.Commit();
      return true;
    }

    public AccountTransactionDTO Update(AccountTransactionDTO accountTransaction)
    {
      this.context.AccountTransactions.Remove(accountTransaction);
      this.context.SaveChanges();
      return accountTransaction;
    }

    public AccountTransactionDTO Delete(AccountTransactionDTO accountTransaction)
    {
      this.context.AccountTransactions.Remove(accountTransaction);
      this.context.SaveChanges();
      return accountTransaction;
    }
  }
}
