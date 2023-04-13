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
  public class UserAccountService
  {
    private UserAccountDAO userAccountDAO;

    public UserAccountService(ProjectContext context)
    {
      this.userAccountDAO = new UserAccountDAO(context);
    }

    public List<AccountDTO> GetAllUsersAccounts(int userId)
    {
      return this.userAccountDAO.GetAccountOfUser(userId).ToList();
    }

    public List<UserDTO> GetAllUsersOfAnAccount(int accountNumber)
    {
      return this.userAccountDAO.GetUserOfAccount(accountNumber).ToList();
    }

    public UserAccountDTO LinkAccountToUser(int userId, int accountNumber)
    {
      UserAccountDTO createdLink = new UserAccountDTO(userId, accountNumber);
      return this.userAccountDAO.Create(createdLink);
    }

    public UserAccountDTO UnlinkUserFromAccount(int userId, int accountNumber)
    {
      UserAccountDTO linkToRemove = this.userAccountDAO.GetByUserAndAccountNumber(userId, accountNumber);
      return this.userAccountDAO.Delete(linkToRemove);
    }

    public void UnlinkAllUsersFromAccount(int accountNumber)
    {
      List<UserDTO> usersOfAccount = this.userAccountDAO.GetUserOfAccount(accountNumber);
      foreach (UserDTO user in usersOfAccount)
      {
        UserAccountDTO userAccountToDelete = this.userAccountDAO.GetByUserAndAccountNumber(user.ID, accountNumber);
        this.userAccountDAO.Delete(userAccountToDelete);
      }
    }

    public void UnlinkAllAccountFromUser(int userId)
    {
      List<AccountDTO> accountOfUser = this.userAccountDAO.GetAccountOfUser(userId);
      foreach (AccountDTO account in accountOfUser)
      {
        UserAccountDTO userAccountToDelete = this.userAccountDAO.GetByUserAndAccountNumber(userId, account.AccountNumber);
        this.userAccountDAO.Delete(userAccountToDelete);
      }
    }
  }
}
