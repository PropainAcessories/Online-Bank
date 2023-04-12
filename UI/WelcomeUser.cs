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
      txtID.Text = userDTO.ID.ToString();
      txtName.Text = userDTO.FullName;
      txtEmail.Text = userDTO.Email;
      txtPIN.Text = userDTO.PIN.ToString();
      txtPhone.Text = userDTO.PhoneNumber;
      txtDate.Text = userDTO.RegistrationDate.ToString();
    }

    private void Init()
    {
      this.creator = new AccountCreator();
      this .transactionView = new TransactionView();
    }

  }
}
