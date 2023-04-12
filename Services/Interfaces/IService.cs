using Online_Bank.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Services.Interfaces
{
  public interface IService
  {
    UserDTO CreateNewUser(string fullName, int pin, string passwordHash, string email, string phoneNumber);
  }
}
