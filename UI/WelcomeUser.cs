using Online_Bank.Data.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Online_Bank.Services;

namespace Online_Bank.UI
{
  public partial class WelcomeUser : Form
  {
    private AccountCreator creator;
    private TransactionView transactionView;
    private AccountDTO currentWorkingAccount;

    public static int ACCOUNTNUMBER = 0;
    public WelcomeUser()
    {
      InitializeComponent();
      Init();
    }

    public void FillData(UserDTO userDTO)
    {
      txtI.Text = userDTO.ID.ToString();
      txtName.Text = userDTO.FullName;
      txtEmail.Text = userDTO.Email;
      txtPIN.Text = userDTO.PIN.ToString();
      txtPhone.Text = userDTO.PhoneNumber;
      txtDate.Text = userDTO.RegistrationDate.ToString();
    }

    private void Init()
    {
      this.creator = new AccountCreator();
      this.transactionView = new TransactionView();
    }

    private void WelcomeUser_Load(object sender, EventArgs e)
    {
      LoadAccounts();
    }

    private void logOutBtn_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void txtName_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
      txtName.ReadOnly = false;
      txtEmail.ReadOnly = false;
      txtPIN.ReadOnly = false;
      txtPhone.ReadOnly = false;
    }

    private void button5_Click(object sender, EventArgs e)
    {
      try
      {
        txtName.ReadOnly = true;
        txtEmail.ReadOnly = true;
        txtPIN.ReadOnly = true;
        txtPhone.ReadOnly = true;

        int id = int.Parse(this.txtI.Text);
        string fullName = this.txtName.Text;
        int pin = int.Parse(txtPIN.Text);
        string email = this.txtEmail.Text;
        string phone = this.txtPhone.Text;

        UserDTO user = MainService.getInstance().GetUserService().getUserById(id);
        MainService.getInstance().GetUserService().UpdateUser(user, fullName, pin, email, phone);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void LoadAccounts()
    {//Make this exist later; like the next thing you do you fucking idiot.
      List<AccountDTO> accountList = MainService.getInstance().GetUserAccountService().GetAllUsersAccounts(SignInForm.USERID);
      foreach (AccountDTO account in accountList)
      {
        accountCombo.Items.Add(account.AccountNumber);
      }
    }

    private void LoadAccountFields(AccountDTO account)
    {
      this.txtAccNumber.Text = account.AccountNumber.ToString();
      this.txtAccType.Text = account.AccountType.ToString();
      this.txtBalance.Text = account.Balance.ToString();
    }

    private void ClearAccountFields(AccountDTO account)
    {
      this.txtAccNumber.Text = "";
      this.txtAccType.Text = "";
      this.txtBalance.Text = "";
    }

    private void accountCombo_SelectedIndexChanged(object sender, EventArgs e)
    {
      try
      {
        this.currentWorkingAccount = MainService.getInstance().GetAccountService().getByAccountNumber((int)accountCombo.SelectedItem);
        LoadAccountFields(this.currentWorkingAccount);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }


    private void createAccountBtn_Click(object sender, EventArgs e)
    {
      try
      {
        this.creator.ShowDialog();
        if (this.creator.DialogResult == DialogResult.OK)
        {
          this.accountCombo.Items.Clear();
          LoadAccounts();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void accDeleteBtn_Click(object sender, EventArgs e)
    {
      try
      {
        if (accountCombo.SelectedItem == null)
        {
          MessageBox.Show("Please select an account");
        }
        else
        {
          this.currentWorkingAccount = MainService.getInstance().GetAccountService().getByAccountNumber((int)accountCombo.SelectedItem);
          if (this.currentWorkingAccount.Balance != 0)
          {
            MessageBox.Show("You can't delete an account with money in it.");
          }
          else
          {
            MainService.getInstance().GetUserAccountService().UnlinkAllUsersFromAccount(this.currentWorkingAccount.AccountNumber);
            ClearAccountFields(this.currentWorkingAccount);
            this.accountCombo.Items.Remove(accountCombo.SelectedItem);
            MessageBox.Show("Account Deleted");
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void transactionBtn_Click(object sender, EventArgs e)
    {
      try
      {
        if (accountCombo.SelectedItem == null)
        {
          MessageBox.Show("Please select an account to proceed.");
        }
        else
        {
          this.currentWorkingAccount = MainService.getInstance().GetAccountService().getByAccountNumber((int)accountCombo.SelectedItem);
          ACCOUNTNUMBER = this.currentWorkingAccount.AccountNumber;
          List<TransactionDTO> transactionList = MainService.getInstance().GetAccountTransactionService().GetAllTransactionOfAccount(ACCOUNTNUMBER);
          this.transactionView.OpenModal(transactionList);
          if (this.transactionView.DialogResult == DialogResult.OK)
          {
            LoadAccountFields(this.currentWorkingAccount);
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        List<AccountDTO> accountList = MainService.getInstance().GetUserAccountService().GetAllUsersAccounts(SignInForm.USERID);
        try
        {
          MainService.getInstance().GetUserAccountService().UnlinkAllAccountFromUser(SignInForm.USERID);
          UserDTO currentUser = MainService.getInstance().GetUserService().getUserById(SignInForm.USERID);
          MainService.getInstance().GetUserService().DeleteUser(currentUser);
          MessageBox.Show("Bye Felicia.");
          this.Close();
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
