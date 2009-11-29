using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using VncSharp;

namespace Farsoft.SCS
{
	/// <summary>
	/// Summary description for VNCConnectionControl.
	/// </summary>
	public class VNCConnectionControl : System.Windows.Forms.UserControl
	{
		private RemoteDesktop rd;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private VNCHost m_host = null;
		private Crownwood.Magic.Controls.TabPage m_tab = null;

		public VNCConnectionControl()
		{
			InitializeComponent();
			rd.GetPassword = new AuthenticateDelegate(GetPassword);
			Dock = DockStyle.Fill;
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.rd = new VncSharp.RemoteDesktop();
			this.SuspendLayout();
			// 
			// rd
			// 
			this.rd.AutoScroll = true;
			this.rd.AutoScrollMinSize = new System.Drawing.Size(608, 427);
			this.rd.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rd.Location = new System.Drawing.Point(0, 0);
			this.rd.Name = "rd";
			this.rd.Size = new System.Drawing.Size(416, 376);
			this.rd.TabIndex = 0;
			this.rd.Text = "remoteDesktop1";
			this.rd.ExceptionEvent += new VncSharp.ExceptionHandler(this.rd_ExceptionEvent);
			this.rd.ConnectionLost += new System.EventHandler(this.rd_ConnectionLost);
			this.rd.ConnectComplete += new VncSharp.ConnectCompleteHandler(this.rd_ConnectComplete);
			// 
			// VNCConnectionControl
			// 
			this.Controls.Add(this.rd);
			this.Name = "VNCConnectionControl";
			this.Size = new System.Drawing.Size(416, 376);
			this.ResumeLayout(false);

		}
		#endregion

		public bool Connect(VNCHost target, Crownwood.Magic.Controls.TabPage tab)
		{
			try
			{
				m_host = target;
				m_tab = tab;
				rd.Connect(target.Hostname, target.Screen, true);
				return true;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message, "Connect Exception");
				Disconnect();
				return false;
			}
		}

		public bool Disconnect()
		{
			try
			{
				if (m_tab != null)
					MainForm.thisForm.RemoveTab(m_tab);
				if (rd != null)
					rd.Disconnect();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public string GetPassword()
		{
			if (m_host.Password.Length > 0)
				return m_host.Password;
			else
			{
				AuthenticationForm auth = new AuthenticationForm();
				if (auth.ShowDialog() == DialogResult.OK)
				{
					if (auth.getSavePassword())
						m_host.Password = auth.getPassword();
					return auth.getPassword();
				}
				else
					return "";
			}
		}

		public void SendCtrlAltDel()
		{
			rd.SendKeyDown(new KeyEventArgs(Keys.Control | Keys.Alt | Keys.Delete));
			Thread.Sleep(10);
			rd.SendKeyUp(new KeyEventArgs(Keys.Control | Keys.Alt | Keys.Delete));
		}

		private void rd_ConnectionLost(object sender, System.EventArgs e)
		{
			Disconnect();
			//MessageBox.Show("Connection to " + Text + " lost\n\n" + e.ToString());
		}

		private void rd_ConnectComplete(object sender, VncSharp.ConnectEventArgs e)
		{
			m_tab.Title = e.DesktopName;
		}

		private void rd_ExceptionEvent(object sender, VncSharp.ExceptionEventArgs e)
		{
			MainForm.thisForm.Status(m_tab.Title + ": Exception: " + e.Message);
			Disconnect();
		}
	}
}
