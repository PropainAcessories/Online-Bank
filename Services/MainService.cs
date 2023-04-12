using Online_Bank.Data.Contexts;
//TODO: ADD UI here as well for main controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Services
{
    public class MainService
    {
        private ProjectContext clientContext;
        private UserService userService;
        private AccountService accountService;
        private UserAccountService userAccountService;
        private TransactionService transactionService;
        private AccountTransactionService accountTransactionService;
        private static MainService INSTANCE = null;
        protected MainService()
        {

          this.clientContext = new ProjectContext();
          this.userService = new UserService(this.clientContext);
          this.accountService = new AccountService(this.clientContext);
          this.userAccountService = new UserAccountService(this.clientContext);
          this.transactionService = new TransactionService(this.clientContext);
          this.accountTransactionService = new AccountTransactionService(this.clientContext);

        }

        public static MainService getInstance()
        {
          if (INSTANCE is null)
            {
              INSTANCE = new MainService();
            }
          return INSTANCE;
        }

        public UserService GetUserService()
        {
           return this.userService;
        }

        public AccountService GetAccountService()
        {
          return this.accountService;
        }
        public UserAccountService GetUserAccountService()
        {
            return this.userAccountService;
        }

        public TransactionService GetTransactionService()
        {
          return this.transactionService;
        }

        public AccountTransactionService GetAccountTransactionService()
        {
          return this.accountTransactionService;
        }
        public void OpenMainWindow()
        {
            Application.Run(new homeForm());
        }

        public void ExitApplication()
        {
            Application.Exit();
        }
    }
}
