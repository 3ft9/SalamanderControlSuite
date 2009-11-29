using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Farsoft.SCS
{
	/// <summary>
	/// Summary description for HostPropertiesForm.
	/// </summary>
	public class HostPropertiesForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDisplayName;
		private System.Windows.Forms.NumericUpDown txtScreen;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblHostname;
		private System.Windows.Forms.TextBox txtHostname;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public HostPropertiesForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HostPropertiesForm));
			this.label1 = new System.Windows.Forms.Label();
			this.lblHostname = new System.Windows.Forms.Label();
			this.txtDisplayName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtScreen = new System.Windows.Forms.NumericUpDown();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtHostname = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.txtScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Display Name";
			// 
			// lblHostname
			// 
			this.lblHostname.Location = new System.Drawing.Point(8, 43);
			this.lblHostname.Name = "lblHostname";
			this.lblHostname.Size = new System.Drawing.Size(80, 16);
			this.lblHostname.TabIndex = 1;
			this.lblHostname.Text = "Hostname";
			// 
			// txtDisplayName
			// 
			this.txtDisplayName.Location = new System.Drawing.Point(88, 8);
			this.txtDisplayName.Name = "txtDisplayName";
			this.txtDisplayName.Size = new System.Drawing.Size(152, 20);
			this.txtDisplayName.TabIndex = 1;
			this.txtDisplayName.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 74);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(80, 16);
			this.label4.TabIndex = 13;
			this.label4.Text = "Screen";
			// 
			// txtScreen
			// 
			this.txtScreen.Location = new System.Drawing.Point(88, 72);
			this.txtScreen.Maximum = new System.Decimal(new int[] {
																	  255,
																	  0,
																	  0,
																	  0});
			this.txtScreen.Name = "txtScreen";
			this.txtScreen.Size = new System.Drawing.Size(48, 20);
			this.txtScreen.TabIndex = 3;
			this.txtScreen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(88, 104);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = '*';
			this.txtPassword.Size = new System.Drawing.Size(152, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 107);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 15;
			this.label5.Text = "Password";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(40, 136);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 5;
			this.btnOK.Text = "OK";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(136, 136);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			// 
			// txtHostname
			// 
			this.txtHostname.Location = new System.Drawing.Point(88, 40);
			this.txtHostname.Name = "txtHostname";
			this.txtHostname.Size = new System.Drawing.Size(152, 20);
			this.txtHostname.TabIndex = 2;
			this.txtHostname.Text = "";
			// 
			// HostPropertiesForm
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(248, 166);
			this.ControlBox = false;
			this.Controls.Add(this.txtHostname);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtDisplayName);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtScreen);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.lblHostname);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "HostPropertiesForm";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Host Properties";
			this.Activated += new System.EventHandler(this.HostPropertiesForm_Activated);
			((System.ComponentModel.ISupportInitialize)(this.txtScreen)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public VNCHost Display(VNCHost host)
		{
			txtDisplayName.Text = host.DisplayName;
			txtHostname.Text = host.Hostname;
			txtScreen.Value = host.Screen;
			if (host.Password.Length > 0)
				txtPassword.Text = "UNCHANGED";
			else
				txtPassword.Text = "";

			if (ShowDialog() == DialogResult.OK)
			{
				host.DisplayName = txtDisplayName.Text;
				host.Hostname = txtHostname.Text;
				host.Screen = Convert.ToInt16(txtScreen.Value);
				if (txtPassword.Text.CompareTo("UNCHANGED") != 0)
					host.Password = txtPassword.Text;
			}
			else
				return null;

			return host;
		}

		private void HostPropertiesForm_Activated(object sender, System.EventArgs e)
		{
			txtDisplayName.Focus();
		}
	}
}
