using Online_Bank.Data.Contexts;
using Online_Bank.Data.Dtos;
using Online_Bank.Data;
using Online_Bank.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.DAOs
{
  public class AccountDAO
  {
    private ProjectContext clientContext;

    public AccountDAO(ProjectContext clientContext)
    {
      clientContext ??= new ProjectContext();
      this.clientContext = clientContext;
    }
    //CRUD below
    public AccountDTO GetByAccountNumber(int accountNumber)
    {
      return this.clientContext.Accounts.Where(account => account.AccountNumber == accountNumber).Single();
    }

    public List<AccountDTO> GetAll()
    {
      return this.clientContext.Accounts.ToList();
    }

    public AccountDTO Create(AccountDTO newAccount)
    {
      this.clientContext.Accounts.Add(newAccount);
      this.clientContext.SaveChanges();
      return newAccount;
    }

    public void SaveModification(AccountDTO account)
    {
      this.clientContext.Accounts.Update(account);
      this.clientContext.SaveChanges();
    }

    public void Delete(AccountDTO account)
    {
      this.clientContext.Accounts.Remove(account);
      this.clientContext.SaveChanges();
    }
  }
}
