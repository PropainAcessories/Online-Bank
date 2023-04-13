using Online_Bank.Data.Contexts;
using Online_Bank.Data.DAOs;
using Online_Bank.Data.Dtos;
using Online_Bank.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Services
{
  public class AccountService : IService
  {
    private AccountDAO accountDAO;
    public AccountService(ProjectContext dbContext)
    {
      this.accountDAO = new AccountDAO(dbContext);
    }

    public List<AccountDTO> GetAllAccounts()
    {
      return this.accountDAO.GetAll();
    }

    public AccountDTO getByAccountNumber(int accountNumber)
    {
      return this.accountDAO.GetByAccountNumber(accountNumber);
    }

    public AccountDTO saveNewAccount(AccountDTO newAccount)
    {
      return this.accountDAO.Create(newAccount);
    }

    public void updateAccount(AccountDTO account)
    {
      this.accountDAO.SaveModification(account);
    }
  }
}
