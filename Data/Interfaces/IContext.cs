using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.Interfaces
{
  public interface IContext<TDTO>: IDisposable where TDTO: class, IDto
  {
    public DbSet<TDTO> GetDbSet();
    public int SaveChange();
  }
}
