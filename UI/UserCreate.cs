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

      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}
