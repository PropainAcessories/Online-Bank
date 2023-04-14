using Online_Bank.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Online_Bank.UI
{
  public partial class UserCreate : Form
  {
    public UserCreate()
    {
      InitializeComponent();
    }

    public Boolean checkInvalidChar(TextBox aInput)
    {
      char[] invalidChars = new char[] { ';', '?', '`' };
      if (aInput.Text.IndexOfAny(invalidChars) != -1)
      {
        return true;
      }
      return false;
    }
    // Conditional If hell may refactor to switch statement but for now is good
    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        foreach (Control txt in this.Controls)
        {
          if (txt is TextBox)
          {
            ((TextBox)txt).ForeColor = DefaultForeColor;
          }
        }
        if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPIN.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtPass.Text))
        {
          MessageBox.Show("Please fill out all the fields and try again.");
        }
        else if (!Regex.IsMatch(this.txtPIN.Text, @"^[\d]{4}$"))
        {
          MessageBox.Show("Please make sure your PIN number is Four (4) digits.");
          this.txtPIN.ForeColor = Color.Red;
        }
        else if (!IsValidEmail(txtEmail.Text))
        {
          MessageBox.Show("Please enter the valid email");
          this.txtEmail.ForeColor = Color.Red;
        }
        else if (!Regex.IsMatch(this.txtPhone.Text, @"^[\d]{3}-[\d]{3}-[\d]{4}$"))
        {
          MessageBox.Show("Please enter the format of (000)-555-1234");
          this.txtPhone.ForeColor = Color.Red;
        }
        else if (!Regex.IsMatch(this.txtPass.Text, @"^[\w]{8,}$"))
        {
          MessageBox.Show("Your password needs to contain at least 8 characters");
          this.txtPass.ForeColor = Color.Red;
        }
        else if (checkInvalidChar(txtEmail) || checkInvalidChar(txtName))
        {
          MessageBox.Show("Those don't go into emails or names.");
        }
        else if (!MainService.getInstance().GetUserService().CheckDuplicateEmail(this.txtEmail.Text))
        {
          MessageBox.Show("This Email address already exists!");
        }
        else
        {
          string fullName = this.txtName.Text;
          string email = this.txtEmail.Text;
          int pin = int.Parse(txtPIN.Text);
          this.txtPIN.ForeColor = SystemColors.WindowText;
          string phone = this.txtPhone.Text;
          string password = this.txtPass.Text;
          MainService.getInstance().GetUserService().CreateNewUser(fullName, pin, phone, email, password);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    public static bool IsValidEmail(string emailaddress)
    {
      try
      {
        MailAddress m = new MailAddress(emailaddress);

        return true;
      }
      catch (FormatException)
      {
        return false;
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      MainService.getInstance().GetUserService().CloseUserCreationForm();
      MainService.getInstance().GetUserService().OpenSignInForm();
    }

    private void button3_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtPIN_TextChanged(object sender, EventArgs e)
    {

    }

    private void txtPhone_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
