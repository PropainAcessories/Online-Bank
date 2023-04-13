namespace Online_Bank.UI
{
  partial class UserCreate
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      button1 = new Button();
      button2 = new Button();
      button3 = new Button();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      label4 = new Label();
      label5 = new Label();
      txtName = new TextBox();
      txtPhone = new TextBox();
      txtPass = new TextBox();
      txtEmail = new TextBox();
      txtPIN = new TextBox();
      SuspendLayout();
      // 
      // button1
      // 
      button1.Location = new Point(602, 84);
      button1.Name = "button1";
      button1.Size = new Size(136, 48);
      button1.TabIndex = 0;
      button1.Text = "Create Account";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // button2
      // 
      button2.Location = new Point(602, 187);
      button2.Name = "button2";
      button2.Size = new Size(136, 48);
      button2.TabIndex = 1;
      button2.Text = "Sign-In";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // button3
      // 
      button3.Location = new Point(602, 288);
      button3.Name = "button3";
      button3.Size = new Size(136, 48);
      button3.TabIndex = 2;
      button3.Text = "Exit Application";
      button3.UseVisualStyleBackColor = true;
      button3.Click += button3_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(171, 84);
      label1.Name = "label1";
      label1.Size = new Size(64, 15);
      label1.TabIndex = 3;
      label1.Text = "Full Name:";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(171, 187);
      label2.Name = "label2";
      label2.Size = new Size(102, 15);
      label2.TabIndex = 4;
      label2.Text = "Desired Password:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(171, 135);
      label3.Name = "label3";
      label3.Size = new Size(91, 15);
      label3.TabIndex = 5;
      label3.Text = "Phone Number:";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(171, 238);
      label4.Name = "label4";
      label4.Size = new Size(84, 15);
      label4.TabIndex = 6;
      label4.Text = "Email Address:";
      // 
      // label5
      // 
      label5.AutoSize = true;
      label5.Location = new Point(171, 288);
      label5.Name = "label5";
      label5.Size = new Size(68, 15);
      label5.TabIndex = 7;
      label5.Text = "4-Digit PIN:";
      // 
      // txtName
      // 
      txtName.Location = new Point(303, 84);
      txtName.Name = "txtName";
      txtName.Size = new Size(172, 23);
      txtName.TabIndex = 8;
      txtName.TextChanged += txtName_TextChanged;
      // 
      // txtPhone
      // 
      txtPhone.Location = new Point(303, 135);
      txtPhone.Name = "txtPhone";
      txtPhone.Size = new Size(172, 23);
      txtPhone.TabIndex = 9;
      txtPhone.TextChanged += txtPhone_TextChanged;
      // 
      // txtPass
      // 
      txtPass.Location = new Point(303, 187);
      txtPass.Name = "txtPass";
      txtPass.Size = new Size(172, 23);
      txtPass.TabIndex = 10;
      // 
      // txtEmail
      // 
      txtEmail.Location = new Point(303, 238);
      txtEmail.Name = "txtEmail";
      txtEmail.Size = new Size(172, 23);
      txtEmail.TabIndex = 11;
      // 
      // txtPIN
      // 
      txtPIN.Location = new Point(303, 288);
      txtPIN.Name = "txtPIN";
      txtPIN.Size = new Size(172, 23);
      txtPIN.TabIndex = 12;
      txtPIN.TextChanged += txtPIN_TextChanged;
      // 
      // UserCreate
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(800, 450);
      Controls.Add(txtPIN);
      Controls.Add(txtEmail);
      Controls.Add(txtPass);
      Controls.Add(txtPhone);
      Controls.Add(txtName);
      Controls.Add(label5);
      Controls.Add(label4);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(button3);
      Controls.Add(button2);
      Controls.Add(button1);
      Name = "UserCreate";
      Text = "UserCreate";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Button button1;
    private Button button2;
    private Button button3;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private TextBox txtName;
    private TextBox txtPhone;
    private TextBox txtPass;
    private TextBox txtEmail;
    private TextBox txtPIN;
  }
}