using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Bank.Data.Dtos;
using Microsoft.EntityFrameworkCore;


namespace Online_Bank.Data.Contexts
{
    public class ProjectContext: DbContext
    {
      public DbSet<AccountDTO> Accounts { get; set; }
      public DbSet<UserDTO> Users { get; set; }
      
      public DbSet<UserAccountDTO> UserAccounts { get; set; }

      public DbSet<TransactionDTO> Transactions { get; set; }
      public DbSet<AccountTransactionDTO> AccountTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQL2022EXPRESS;Database=Banking_db;Integrated security=true;TrustServerCertificate=true;");
        }
    }
}
