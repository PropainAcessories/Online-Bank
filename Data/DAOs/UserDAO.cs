using Online_Bank.Data.Contexts;
using Online_Bank.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Data.DAOs
{
  public class UserDAO
  {
    private ProjectContext clientContext;
    public UserDAO(ProjectContext clientContext)
    {
      clientContext ??= new ProjectContext();
      this.clientContext = clientContext;
    }

    public UserDTO GetById(int id)
    {
      return this.clientContext.Users.Where(user => user.ID == id).Single();
    }

    public int GetUserIdFromEmail(string email)
    {
      UserDTO user = GetByEmail(email);
      if (user == null)
      {
        return 0;
      } else
      {
        return user.ID;
      }
    }

    public List<UserDTO> GetAll()
    {
      return this.clientContext.Users.ToList();
    }

    public UserDTO? GetByEmail(string email)
    {
      List<UserDTO> userList = GetAll();
      foreach (UserDTO user in userList)
      {
        if (user.Email == email)
        {
          return user;
        }
      }
      return null;
    }
    //Login
    public UserDTO? GetLogIn(string email, string PasswordHash)
    {
      List<UserDTO> userList = GetAll();
      foreach (UserDTO user in userList)
      {
        if(user.PasswordHash == PasswordHash && user.Email == email)
        {
          return user;
        }
      }
      return null;
    }
    //Register
    public void AddNewUser(UserDTO newUser)
    {
      this.clientContext.Users.Add(newUser);
      this.clientContext.SaveChanges();
    }
    //Update/modify
    public void SaveModification(UserDTO user)
    {
      this.clientContext.Users.Update(user);
      this.clientContext.SaveChanges();
    }
    //Delete
    public void DeleteUser(UserDTO user)
    {
      this.clientContext.Users.Remove(user);
      this.clientContext.SaveChanges();
    }
  }
}
