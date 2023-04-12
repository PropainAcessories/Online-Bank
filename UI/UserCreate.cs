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


  }
}
