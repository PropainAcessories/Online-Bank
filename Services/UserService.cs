using Online_Bank.Data.Contexts;
using Online_Bank.Data.DAOs;
using Online_Bank.Data.Dtos;
using Online_Bank.Services.Interfaces;
using Online_Bank.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Bank.Services
{
  public class UserService : IService
  {
    private UserDAO userDAO;
    private UserCreate userForm;
    private SignInForm signInForm;
    private WelcomeUser welcomeUser;

    public UserService(ProjectContext clientContext)
    {
      this.userDAO = new UserDAO(clientContext);
      this.userForm = new UserCreate();
      this.signInForm = new SignInForm();
      this.welcomeUser = new WelcomeUser();
    }

    public UserDTO getUserById(int id)
    {
      UserDTO user = this.userDAO.GetById(id);
      return user;
    }

    public List<UserDTO> GetAllUsers()
    {
      return this.userDAO.GetAll();
    }

    public int GetUserIdByEmail(string email)
    {
      return this.userDAO.GetUserIdFromEmail(email);
    }

    public UserDTO CreateNewUser(string fullName, int pin, string passwordHash, string email, string phoneNumber)
    {
      UserDTO newUser = new UserDTO(fullName, pin, passwordHash, email, phoneNumber);
      this.userDAO.AddNewUser(newUser);
      CloseUserCreationForm();
      MessageBox.Show("Registration Successful");
      return newUser;
    }

    public void DeleteUser(UserDTO user)
    {
      this.userDAO.DeleteUser(user);
    }

    public void UpdateUser(UserDTO user, string fullName, int pin, string email, string phoneNumber)
    {
      user.PIN = pin;
      user.FullName = fullName;
      user.Email = email;
      user.PhoneNumber = phoneNumber;

      this.userDAO.SaveModification(user);
      MessageBox.Show("You have Successfully updated your information");
    }

    public Boolean CheckDuplicateEmail(string email)
    {
      if (this.userDAO.GetByEmail(email) == null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public void CheckCredentials(string Email, string Password)
    {
      if (this.userDAO.GetLogIn(email: Email, PasswordHash: Password)==null)
      {
        MessageBox.Show("Something is incorrect; please try again.");
      } else
      {
        CloseSignInForm();
        this.welcomeUser.FillData(userDAO.GetByEmail(Email));
        WelcomeTheUser();
      }
    }

    public void OpenUserCreationForm()
    {
      this.userForm.ShowDialog(); 
    }

    public void CloseUserCreationForm()
    {
      this.userForm.DialogResult = DialogResult.Cancel;
    }

    public void OpenSignInForm()
    {
      this.signInForm.ShowDialog();
    }

    public void CloseSignInForm()
    {
      this.signInForm.Close();
    }

    public void WelcomeTheUser()
    {
      this.welcomeUser.ShowDialog();
    }
  }
}
