using System.Windows.Forms;
using System;

namespace Farsoft.SCS
{

	/// <summary>
	/// this class represents a form for entering the password
	/// </summary>
	class AuthenticationForm : Form 
	{
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkboxSavePassword;
	
		public AuthenticationForm() 
		{
			InitializeComponent();
		}

		public string getPassword() 
		{
			return txtPassword.Text;
		}

		public bool getSavePassword()
		{
			return checkboxSavePassword.Checked;
		}

		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkboxSavePassword = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(136, 64);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(40, 64);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(88, 8);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(152, 20);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 19;
			this.label5.Text = "Password";
			// 
			// checkboxSavePassword
			// 
			this.checkboxSavePassword.Location = new System.Drawing.Point(88, 32);
			this.checkboxSavePassword.Name = "checkboxSavePassword";
			this.checkboxSavePassword.Size = new System.Drawing.Size(152, 24);
			this.checkboxSavePassword.TabIndex = 2;
			this.checkboxSavePassword.Text = "Save password?";
			// 
			// AuthenticationForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(248, 94);
			this.ControlBox = false;
			this.Controls.Add(this.checkboxSavePassword);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label5);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "AuthenticationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Authentication needed";
			this.ResumeLayout(false);

		}

	}
}