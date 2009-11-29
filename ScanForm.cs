using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace Farsoft.SCS
{
	/// <summary>
	/// Summary description for ScanForm.
	/// </summary>
	public class ScanForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TextBox txtIP1;
		private System.Windows.Forms.TextBox txtIP2;
		private System.Windows.Forms.TextBox txtIP3;
		private System.Windows.Forms.NumericUpDown txtFrom;
		private System.Windows.Forms.NumericUpDown txtTo;
		private System.Windows.Forms.Button btnScan;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblDot1;
		private System.Windows.Forms.Label lblDot2;

		public ScanForm()
		{
			InitializeComponent();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ScanForm));
			this.label1 = new System.Windows.Forms.Label();
			this.txtIP1 = new System.Windows.Forms.TextBox();
			this.txtIP2 = new System.Windows.Forms.TextBox();
			this.txtIP3 = new System.Windows.Forms.TextBox();
			this.lblDot1 = new System.Windows.Forms.Label();
			this.lblDot2 = new System.Windows.Forms.Label();
			this.btnScan = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFrom = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTo = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.txtFrom)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTo)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "IP block:";
			// 
			// txtIP1
			// 
			this.txtIP1.Location = new System.Drawing.Point(64, 8);
			this.txtIP1.Name = "txtIP1";
			this.txtIP1.Size = new System.Drawing.Size(32, 20);
			this.txtIP1.TabIndex = 1;
			this.txtIP1.Text = "0";
			this.txtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtIP2
			// 
			this.txtIP2.Location = new System.Drawing.Point(104, 8);
			this.txtIP2.Name = "txtIP2";
			this.txtIP2.Size = new System.Drawing.Size(32, 20);
			this.txtIP2.TabIndex = 2;
			this.txtIP2.Text = "0";
			this.txtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// txtIP3
			// 
			this.txtIP3.Location = new System.Drawing.Point(144, 8);
			this.txtIP3.Name = "txtIP3";
			this.txtIP3.Size = new System.Drawing.Size(32, 20);
			this.txtIP3.TabIndex = 3;
			this.txtIP3.Text = "0";
			this.txtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lblDot1
			// 
			this.lblDot1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDot1.Location = new System.Drawing.Point(96, 11);
			this.lblDot1.Name = "lblDot1";
			this.lblDot1.Size = new System.Drawing.Size(8, 16);
			this.lblDot1.TabIndex = 4;
			this.lblDot1.Text = ".";
			// 
			// lblDot2
			// 
			this.lblDot2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDot2.Location = new System.Drawing.Point(136, 11);
			this.lblDot2.Name = "lblDot2";
			this.lblDot2.Size = new System.Drawing.Size(8, 16);
			this.lblDot2.TabIndex = 5;
			this.lblDot2.Text = ".";
			// 
			// btnScan
			// 
			this.btnScan.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnScan.Location = new System.Drawing.Point(32, 40);
			this.btnScan.Name = "btnScan";
			this.btnScan.Size = new System.Drawing.Size(104, 23);
			this.btnScan.TabIndex = 6;
			this.btnScan.Text = "Scan";
			this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(160, 40);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(104, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(176, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(8, 16);
			this.label2.TabIndex = 12;
			this.label2.Text = ".";
			// 
			// txtFrom
			// 
			this.txtFrom.Location = new System.Drawing.Point(184, 8);
			this.txtFrom.Maximum = new System.Decimal(new int[] {
																	255,
																	0,
																	0,
																	0});
			this.txtFrom.Name = "txtFrom";
			this.txtFrom.Size = new System.Drawing.Size(48, 20);
			this.txtFrom.TabIndex = 4;
			this.txtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(231, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(8, 16);
			this.label3.TabIndex = 14;
			this.label3.Text = "-";
			// 
			// txtTo
			// 
			this.txtTo.Location = new System.Drawing.Point(240, 8);
			this.txtTo.Maximum = new System.Decimal(new int[] {
																  255,
																  0,
																  0,
																  0});
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(48, 20);
			this.txtTo.TabIndex = 5;
			this.txtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtTo.Value = new System.Decimal(new int[] {
																255,
																0,
																0,
																0});
			// 
			// ScanForm
			// 
			this.AcceptButton = this.btnScan;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(296, 72);
			this.ControlBox = false;
			this.Controls.Add(this.txtTo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtFrom);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnScan);
			this.Controls.Add(this.lblDot2);
			this.Controls.Add(this.lblDot1);
			this.Controls.Add(this.txtIP3);
			this.Controls.Add(this.txtIP2);
			this.Controls.Add(this.txtIP1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ScanForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Scan for servers";
			this.Activated += new System.EventHandler(this.ScanForm_Activated);
			((System.ComponentModel.ISupportInitialize)(this.txtFrom)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtTo)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public string BaseIP
		{
			get { return txtIP1.Text + "." + txtIP2.Text + "." + txtIP3.Text + "."; }
		}

		public int FromHost
		{
			get { return Convert.ToInt32(txtFrom.Value); }
		}

		public int ToHost
		{
			get { return Convert.ToInt32(txtTo.Value); }
		}

		private void btnScan_Click(object sender, System.EventArgs e)
		{
			Int32 i = 0;
			try
			{
				i = Convert.ToInt32(txtIP1.Text);
				if (i < 0 || i > 255)
					throw(new Exception());
				i = Convert.ToInt32(txtIP2.Text);
				if (i < 0 || i > 255)
					throw(new Exception());
				i = Convert.ToInt32(txtIP3.Text);
				if (i < 0 || i > 255)
					throw(new Exception());
			}
			catch
			{
				MessageBox.Show("The IP is not valid!");
				return;
			}
		}

		private void ScanForm_Activated(object sender, System.EventArgs e)
		{
			if (btnScan.Enabled)
			{
				txtIP1.Focus();
			}
		}
	}
}
