using Online_Bank.Data.Contexts;
using Online_Bank.Data.Dtos;
using Online_Bank.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.DAOs
{
  public class UserAccountDAO
  {
    private ProjectContext context;

    public UserAccountDAO(ProjectContext context)
    {
      this.context = context;
    }
    //CRUD below
    public List<UserAccountDTO> GetAll()
    {
      return this.context.UserAccounts.ToList();
    }

    public UserAccountDTO GetById(int id)
    {
      return this.context.UserAccounts
        .Where(userAccount => userAccount.Id == id).Single();
    }

    public List<AccountDTO> GetAccountOfUser(int userId)
    {
      List<UserAccountDTO> userAccounts = this.context.UserAccounts
        .Where(userAccount => userAccount.UserId == userId)
        .Include(userAccount => userAccount.Account)
        .ToList();

      List<AccountDTO> accounts = new List<AccountDTO>();
      foreach (UserAccountDTO userAccount in userAccounts)
      {
        accounts.Add(userAccount.Account);
      }
      return accounts;
    }

    public List<UserDTO> GetUserOfAccount(int accountNumber)
    {
      List<UserAccountDTO> userAccounts = this.context.UserAccounts
        .Where(userAccount => userAccount.AccountNumber == accountNumber)
        .Include(userAccount => userAccount.User)
        .ToList();

      List<UserDTO> users = new List<UserDTO>();
      foreach (UserAccountDTO userAccount in userAccounts)
      {
        users.Add(userAccount.User);
      }
      return users;
    }

    public UserAccountDTO Create(UserAccountDTO newUserAccount)
    {
      this.context.UserAccounts.Add(newUserAccount);
      this.context.SaveChanges();
      return newUserAccount;
    }

    public UserAccountDTO GetByUserAndAccountNumber(int userId, int accountNumber)
    {
      return this.context.UserAccounts
        .Where(userAccount => userAccount.AccountNumber == accountNumber && userAccount.UserId == userId)
        .Single();
    }

    public UserAccountDTO Update(UserAccountDTO userAccount)
    {
      this.context.UserAccounts.Update(userAccount);
      this.context.SaveChanges();
      return userAccount;
    }

    public UserAccountDTO Delete(UserAccountDTO userAccount)
    {
      this.context.UserAccounts.Remove(userAccount);
      this.context.SaveChanges();
      return userAccount;
    }
  }
}
