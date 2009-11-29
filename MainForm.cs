using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.Text.RegularExpressions;

namespace Farsoft.SCS
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		public const string FOLDER_MARKER = "THIS IS A FOLDER";

		private System.Windows.Forms.MainMenu menuMain;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuMainFileExit;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuMainFileScan;
		private System.Windows.Forms.ImageList imglstToolbar;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuMainHelpAbout;
		public static MainForm thisForm = null;
		private System.Windows.Forms.StatusBar statusBar;
		private Farsoft.Utils.Config m_Config = null;
		public int m_nScanCounter = 0;
		private System.Windows.Forms.Timer timerScanner;
		private System.Windows.Forms.ContextMenu contextmenuMachines;
		private System.Windows.Forms.MenuItem menuMachinesConnect;
		private System.Windows.Forms.MenuItem menuMachinesProperties;
		private System.Windows.Forms.MenuItem menuMachinesDelete;
		private System.Windows.Forms.MenuItem menuMainFileQuickConnect;
		private Crownwood.Magic.Controls.TabControl tabs;
		private System.Windows.Forms.ToolBar tb;
		private System.Windows.Forms.ToolBarButton tbSendCtrlAltDel;
		private System.Windows.Forms.ToolBarButton tbSep1;
		private System.Windows.Forms.ToolBarButton tbSep2;
		private System.Windows.Forms.ToolBarButton tbDisconnect;
		private System.Windows.Forms.MenuItem menuMainFilePrune;
		public int m_nScanTotal = 0;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TreeView treeHosts;
		private string m_strConfigFile = "config.xml";
		private System.Windows.Forms.ImageList imglstTree;
		private TreeNode m_nodeUnassigned = null;
		private System.Windows.Forms.Timer timerExpand;
		private System.Windows.Forms.MenuItem menuMachinesNewFolder;
		private System.Windows.Forms.ToolBarButton tbSep3;
		private System.Windows.Forms.ToolBarButton tbRedrawScreen;
		private TreeNode m_nodeDragging = null;

		public MainForm(string[] args)
		{
			InitializeComponent();
			MainForm.thisForm = this;
			ThreadPool.SetMinThreads(25, 25);

			if (args.Length > 0)
			{
				if (File.Exists(args[0]))
					m_strConfigFile = args[0];
				else
					MessageBox.Show("Configuration file does not exist: " + args[0] + "\nUsing default file");
			}
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.contextmenuMachines = new System.Windows.Forms.ContextMenu();
			this.menuMachinesConnect = new System.Windows.Forms.MenuItem();
			this.menuMachinesNewFolder = new System.Windows.Forms.MenuItem();
			this.menuMachinesDelete = new System.Windows.Forms.MenuItem();
			this.menuMachinesProperties = new System.Windows.Forms.MenuItem();
			this.menuMain = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuMainFileQuickConnect = new System.Windows.Forms.MenuItem();
			this.menuMainFileScan = new System.Windows.Forms.MenuItem();
			this.menuMainFilePrune = new System.Windows.Forms.MenuItem();
			this.menuMainFileExit = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuMainHelpAbout = new System.Windows.Forms.MenuItem();
			this.imglstToolbar = new System.Windows.Forms.ImageList(this.components);
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.timerScanner = new System.Windows.Forms.Timer(this.components);
			this.tabs = new Crownwood.Magic.Controls.TabControl();
			this.tb = new System.Windows.Forms.ToolBar();
			this.tbSep1 = new System.Windows.Forms.ToolBarButton();
			this.tbSendCtrlAltDel = new System.Windows.Forms.ToolBarButton();
			this.tbSep2 = new System.Windows.Forms.ToolBarButton();
			this.tbDisconnect = new System.Windows.Forms.ToolBarButton();
			this.tbSep3 = new System.Windows.Forms.ToolBarButton();
			this.tbRedrawScreen = new System.Windows.Forms.ToolBarButton();
			this.treeHosts = new System.Windows.Forms.TreeView();
			this.imglstTree = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.timerExpand = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// contextmenuMachines
			// 
			this.contextmenuMachines.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.menuMachinesConnect,
																								this.menuMachinesNewFolder,
																								this.menuMachinesDelete,
																								this.menuMachinesProperties});
			// 
			// menuMachinesConnect
			// 
			this.menuMachinesConnect.DefaultItem = true;
			this.menuMachinesConnect.Index = 0;
			this.menuMachinesConnect.Text = "&Connect";
			this.menuMachinesConnect.Click += new System.EventHandler(this.menuMachinesConnect_Click);
			// 
			// menuMachinesNewFolder
			// 
			this.menuMachinesNewFolder.Index = 1;
			this.menuMachinesNewFolder.Text = "New folder...";
			this.menuMachinesNewFolder.Click += new System.EventHandler(this.menuMachinesNewFolder_Click);
			// 
			// menuMachinesDelete
			// 
			this.menuMachinesDelete.Index = 2;
			this.menuMachinesDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
			this.menuMachinesDelete.Text = "&Delete";
			this.menuMachinesDelete.Click += new System.EventHandler(this.menuMachinesDelete_Click);
			// 
			// menuMachinesProperties
			// 
			this.menuMachinesProperties.Index = 3;
			this.menuMachinesProperties.Text = "P&roperties...";
			this.menuMachinesProperties.Click += new System.EventHandler(this.menuMachinesProperties_Click);
			// 
			// menuMain
			// 
			this.menuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuMainFileQuickConnect,
																					  this.menuMainFileScan,
																					  this.menuMainFilePrune,
																					  this.menuMainFileExit});
			this.menuItem1.Text = "&File";
			// 
			// menuMainFileQuickConnect
			// 
			this.menuMainFileQuickConnect.Index = 0;
			this.menuMainFileQuickConnect.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.menuMainFileQuickConnect.Text = "Quick &connect...";
			this.menuMainFileQuickConnect.Click += new System.EventHandler(this.menuMainFileQuickConnect_Click);
			// 
			// menuMainFileScan
			// 
			this.menuMainFileScan.Index = 1;
			this.menuMainFileScan.Text = "&Scan for servers...";
			this.menuMainFileScan.Click += new System.EventHandler(this.menuMainFileScan_Click);
			// 
			// menuMainFilePrune
			// 
			this.menuMainFilePrune.Index = 2;
			this.menuMainFilePrune.Text = "&Prune host list";
			this.menuMainFilePrune.Click += new System.EventHandler(this.menuMainFilePrune_Click);
			// 
			// menuMainFileExit
			// 
			this.menuMainFileExit.Index = 3;
			this.menuMainFileExit.Text = "E&xit";
			this.menuMainFileExit.Click += new System.EventHandler(this.menuMainFileExit_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuMainHelpAbout});
			this.menuItem3.Text = "&Help";
			// 
			// menuMainHelpAbout
			// 
			this.menuMainHelpAbout.Index = 0;
			this.menuMainHelpAbout.Text = "&About...";
			this.menuMainHelpAbout.Click += new System.EventHandler(this.menuMainHelpAbout_Click);
			// 
			// imglstToolbar
			// 
			this.imglstToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
			this.imglstToolbar.ImageSize = new System.Drawing.Size(16, 16);
			this.imglstToolbar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstToolbar.ImageStream")));
			this.imglstToolbar.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 523);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(792, 22);
			this.statusBar.TabIndex = 10;
			this.statusBar.Text = "Ready";
			// 
			// timerScanner
			// 
			this.timerScanner.Tick += new System.EventHandler(this.timerScanner_Tick);
			// 
			// tabs
			// 
			this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabs.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
			this.tabs.HotTrack = true;
			this.tabs.Location = new System.Drawing.Point(155, 28);
			this.tabs.Name = "tabs";
			this.tabs.PositionTop = true;
			this.tabs.ShowArrows = true;
			this.tabs.ShowClose = true;
			this.tabs.ShrinkPagesToFit = false;
			this.tabs.Size = new System.Drawing.Size(637, 495);
			this.tabs.TabIndex = 11;
			this.tabs.ClosePressed += new System.EventHandler(this.tabs_ClosePressed);
			// 
			// tb
			// 
			this.tb.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																				  this.tbSep1,
																				  this.tbSendCtrlAltDel,
																				  this.tbSep2,
																				  this.tbDisconnect,
																				  this.tbSep3,
																				  this.tbRedrawScreen});
			this.tb.DropDownArrows = true;
			this.tb.ImageList = this.imglstToolbar;
			this.tb.Location = new System.Drawing.Point(155, 0);
			this.tb.Name = "tb";
			this.tb.ShowToolTips = true;
			this.tb.Size = new System.Drawing.Size(637, 28);
			this.tb.TabIndex = 12;
			this.tb.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right;
			this.tb.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tb_ButtonClick);
			// 
			// tbSep1
			// 
			this.tbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbSendCtrlAltDel
			// 
			this.tbSendCtrlAltDel.ImageIndex = 0;
			this.tbSendCtrlAltDel.Tag = "";
			this.tbSendCtrlAltDel.Text = "Send Ctrl+Alt+Del";
			// 
			// tbSep2
			// 
			this.tbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbDisconnect
			// 
			this.tbDisconnect.ImageIndex = 1;
			this.tbDisconnect.Tag = "";
			this.tbDisconnect.Text = "Disconnect";
			// 
			// tbSep3
			// 
			this.tbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbRedrawScreen
			// 
			this.tbRedrawScreen.ImageIndex = 2;
			this.tbRedrawScreen.Text = "Redraw Screen";
			// 
			// treeHosts
			// 
			this.treeHosts.AllowDrop = true;
			this.treeHosts.ContextMenu = this.contextmenuMachines;
			this.treeHosts.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeHosts.FullRowSelect = true;
			this.treeHosts.HotTracking = true;
			this.treeHosts.ImageList = this.imglstTree;
			this.treeHosts.LabelEdit = true;
			this.treeHosts.Location = new System.Drawing.Point(0, 0);
			this.treeHosts.Name = "treeHosts";
			this.treeHosts.PathSeparator = "/";
			this.treeHosts.Size = new System.Drawing.Size(152, 523);
			this.treeHosts.Sorted = true;
			this.treeHosts.TabIndex = 13;
			this.treeHosts.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeHosts_AfterExpand);
			this.treeHosts.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeHosts_AfterCollapse);
			this.treeHosts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.treeHosts_KeyPress);
			this.treeHosts.DragOver += new System.Windows.Forms.DragEventHandler(this.treeHosts_DragOver);
			this.treeHosts.DoubleClick += new System.EventHandler(this.treeHosts_DoubleClick);
			this.treeHosts.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeHosts_AfterLabelEdit);
			this.treeHosts.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeHosts_DragEnter);
			this.treeHosts.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeHosts_ItemDrag);
			this.treeHosts.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeHosts_DragDrop);
			// 
			// imglstTree
			// 
			this.imglstTree.ImageSize = new System.Drawing.Size(16, 16);
			this.imglstTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstTree.ImageStream")));
			this.imglstTree.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(152, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 523);
			this.splitter1.TabIndex = 14;
			this.splitter1.TabStop = false;
			// 
			// timerExpand
			// 
			this.timerExpand.Interval = 1000;
			this.timerExpand.Tick += new System.EventHandler(this.timerExpand_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 545);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.tb);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.treeHosts);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.menuMain;
			this.Name = "MainForm";
			this.Text = "Salamander Control Suite";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public static Farsoft.Utils.Config Config
		{
			get { return MainForm.thisForm.m_Config; }
		}

		private TreeNode LoadFolder(string strFolder, XmlNodeList nodes, TreeNode parent)
		{
			TreeNode current = null;
			if (strFolder.Length > 0)
				current = AddFolder(strFolder, parent);

			if (nodes != null)
			{
				foreach (XmlNode node in nodes)
				{
					if (node.Name.CompareTo("folder") == 0)
						LoadFolder(node.Attributes["name"].Value, node.ChildNodes, current);
					else if (node.Name.CompareTo("host") == 0)
						AddHost(new VNCHost(node), current);
					else
						Console.WriteLine("Unknown node type: '" + node.Name + "'");
				}
			}

			return current;
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			m_Config = new Farsoft.Utils.Config(m_strConfigFile, "/salamandercs/");
			XmlNodeList nodes = m_Config.GetNodes("hosts/folder");
			TreeNode hosts = LoadFolder("Hosts", nodes, null);
			
			nodes = m_Config.GetNodes("hosts/host");
			if (nodes != null)
				LoadFolder("Unassigned", nodes, hosts);

			if (treeHosts.Nodes.Count > 0)
				treeHosts.Nodes[0].Expand();

			string tmp = m_Config.Get("networks/@scaninterval");
			if (tmp != null)
			{
				int interval = Convert.ToInt16(tmp);
				if (interval > 0)
					timerScanner.Interval = interval * 60000; // minutes to milliseconds
				timerScanner.Enabled = interval > 0;
				timerScanner_Tick(null, null);
			}
		}

		public void RemoveTab(Crownwood.Magic.Controls.TabPage tab)
		{
			tabs.TabPages.Remove(tab);
		}

		private void menuMainFileExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void treeHosts_DoubleClick(object sender, System.EventArgs e)
		{
			if (treeHosts.SelectedNode == null || IsFolder(treeHosts.SelectedNode))
				return;

			CreateVNCWindow((VNCHost)treeHosts.SelectedNode.Tag);
		}

		private bool CreateVNCWindow(VNCHost target)
		{
			// TODO: Check to see if this client is already connected
			//		 Switch to the window if it is

			// Create the VNC window
			try
			{
				VNCConnectionControl vnc = new VNCConnectionControl();
				Crownwood.Magic.Controls.TabPage newtab = new Crownwood.Magic.Controls.TabPage(target.DisplayName, vnc);
				if (vnc.Connect(target, newtab))
				{
					tabs.TabPages.Add(newtab);
					return true;
				}

				MessageBox.Show("Failed to connect", "Connection Error");
				return false;
			}
			catch (Exception e)
			{
				MessageBox.Show("CreateVNCWindow: " + e.Message);
				return false;
			}
		}

		private void menuMainFileScan_Click(object sender, System.EventArgs e)
		{
			ScanForm sf = new ScanForm();
			if (sf.ShowDialog() == DialogResult.OK)
			{
				Scan(sf.BaseIP, sf.FromHost, sf.ToHost);
			}
		}

		public void AddHosts(ArrayList alHosts)
		{
			foreach (VNCHost h in alHosts)
			{
				AddHost(h);
			}

			ResolveHosts();
		}

		public void AddHost(VNCHost h)
		{
			AddHost(h, m_nodeUnassigned);
		}

		public void AddHost(VNCHost h, TreeNode nodeRoot)
		{
			if (!HostExists(h.Hostname))
			{
				try
				{
					TreeNode item = nodeRoot.Nodes.Add(h.DisplayName);
					item.Tag = h;
					item.ImageIndex = 1;
					item.SelectedImageIndex = 1;
					ResolveHost(item);
				}
				catch { }
			}
		}

		public TreeNode AddFolder(string strFolderName)
		{
			return AddFolder(strFolderName, null);
		}

		public TreeNode AddFolder(string strFolderName, TreeNode nodeRoot)
		{
			TreeNode tnRetVal = null;
			if (nodeRoot == null)
				tnRetVal = treeHosts.Nodes.Add(strFolderName);
			else
				tnRetVal = nodeRoot.Nodes.Add(strFolderName);
			tnRetVal.Tag = new VNCHost(strFolderName, FOLDER_MARKER, 0);
			tnRetVal.ImageIndex = 0;
			tnRetVal.SelectedImageIndex = 0;
			return tnRetVal;
		}

		public bool IsFolder(TreeNode node)
		{
			return (((VNCHost)node.Tag).Hostname.CompareTo(FOLDER_MARKER) == 0);
		}

		private bool HostExists(string strHost)
		{
			return HostExists(strHost, null, true);
		}

		private bool HostExists(string strHost, TreeNodeCollection nodes, bool bRecurse)
		{
			if (nodes == null)
				nodes = treeHosts.Nodes;

			try
			{
				foreach (TreeNode item in nodes)
				{
					if (IsFolder(item))
						if (bRecurse)
							if (HostExists(strHost, item.Nodes, bRecurse))
								return true;
					else if (strHost.CompareTo(((VNCHost)item.Tag).Hostname) == 0)
						return true;
				}
			}
			catch { }
			return false;
		}

		private void ResolveHosts()
		{
			foreach (TreeNode item in treeHosts.Nodes)
				ThreadPool.QueueUserWorkItem(new WaitCallback(ResolveHost), item);
		}

		// This thread procedure performs the task.
		static void ResolveHost(Object stateInfo)
		{
			try
			{
				ListViewItem i = (ListViewItem)stateInfo;

				VNCHost h = (VNCHost)i.Tag;

				Match m = Regex.Match(h.Hostname, "^" +
													@"([01]?\d\d|2[0-4]\d|25[0-5])\." +
													@"([01]?\d\d|2[0-4]\d|25[0-5])\." +
													@"([01]?\d\d|2[0-4]\d|25[0-5])\." +
													@"([01]?\d\d|2[0-4]\d|25[0-5])" +
													"$");
				if (m.Success)
				{
					IPHostEntry host = Dns.GetHostByAddress(h.Hostname);
					string hname = host.HostName.Split(".".ToCharArray())[0].ToUpper();
					MainForm.thisForm.Status("Resolved " + h.Hostname + " to " + hname);
					if (h.DisplayName.CompareTo(h.Hostname) == 0)
					{
						h.DisplayName = hname;
						i.Text = hname;
					}
					h.Hostname = hname;
				}
			}
			catch
			{
			}
		}

		public void Status(string strStatus)
		{
			statusBar.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.f") + ": " + strStatus;
		}

		private void SaveConfig()
		{
			XmlNode node = m_Config.GetNode("hosts");
			node.RemoveAll();

			SaveFolder(node, treeHosts.Nodes[0]);

			m_Config.SaveConfig("config.xml");
		}

		private void SaveFolder(XmlNode xmlRoot, TreeNode tnRoot)
		{
			foreach (TreeNode item in tnRoot.Nodes)
			{
				if (IsFolder(item))
				{
					XmlElement element = m_Config.CreateElement("folder");
					element.SetAttribute("name", item.Text);
					SaveFolder(xmlRoot.AppendChild(element), item);
				}
				else
				{
					if (item.Tag == null)
						continue;

					VNCHost h = (VNCHost)item.Tag;
					if (h.Hostname.Length > 0)
						xmlRoot.AppendChild(h.GetElement(m_Config.CreateElement("host")));
				}
			}
		}

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			SaveConfig();
		}

		/// Host scanner
		private void Scan(string strIPBase, int nFrom, int nTo)
		{
			if (m_nScanTotal == 0)
			{
				m_nScanCounter = 0;
				m_nScanTotal = nTo - nFrom + 1;
				Status("Scanning " + strIPBase + nFrom + "-" + nTo);
			}
			else
			{
				m_nScanTotal += nTo - nFrom + 1;
			}

			for (int i = nFrom; i <= nTo; i++)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(ScanHost), strIPBase + i.ToString());
			}
		}

		static void ScanHost(Object stateInfo) 
		{
			string strCurrentIP = (string)stateInfo;
			IPAddress ip = IPAddress.Parse(strCurrentIP);

			TcpClient c = new TcpClient();
			c.SendTimeout = 100;
			c.ReceiveTimeout = 100;
			try
			{
				c.Connect(ip, 5900);

				// Attempt to get the stream
				Stream s;
				s = c.GetStream();

				// Assume we connected ok
				//ScanForm.thisForm.alScanResults.Add(new VNCHost(strCurrentIP, strCurrentIP, 0));
				MainForm.thisForm.AddHost(new VNCHost(strCurrentIP, strCurrentIP, 0));

				// Make sure the socket is closed
				c.Close();
			}
			catch
			{
				try
				{
					Int32 i = Convert.ToInt32(strCurrentIP.Split(".".ToCharArray())[3]);
					c.Connect(ip, 5900+i);

					// Attempt to get the stream
					Stream s;
					s = c.GetStream();

					// Assume we connected ok
					//ScanForm.thisForm.alScanResults.Add(new VNCHost(strCurrentIP, strCurrentIP, i));
					MainForm.thisForm.AddHost(new VNCHost(strCurrentIP, strCurrentIP, i));

					// Make sure the socket is closed
					c.Close();
				}
				catch
				{
					// Failed, ignore it
				}
			}
			finally
			{
				if (MainForm.thisForm.m_nScanTotal > 0)
				{
					MainForm.thisForm.m_nScanCounter++;

					if (MainForm.thisForm.m_nScanCounter == MainForm.thisForm.m_nScanTotal)
					{
						MainForm.thisForm.ScanComplete();
					}
					else
					{
						float nPercent = ((MainForm.thisForm.m_nScanCounter / MainForm.thisForm.m_nScanTotal) * 100);
						MainForm.thisForm.Status("Scanning... " + MainForm.thisForm.m_nScanCounter + " of " + MainForm.thisForm.m_nScanTotal + " complete");
					}
				}
			}
		}

		public void ScanComplete()
		{
			Status("Scan complete");
			m_nScanCounter = 0;
			m_nScanTotal = 0;
			SaveConfig();
		}

		private void timerScanner_Tick(object sender, System.EventArgs e)
		{
			XmlNodeList nodes = m_Config.GetNodes("networks/network");
			if (nodes != null)
			{
				foreach (XmlNode node in nodes)
				{
					Application.DoEvents();
					Scan(node.InnerText, Convert.ToInt16(node.Attributes["from"].Value), Convert.ToInt16(node.Attributes["to"].Value));
				}
			}
		}

		private void menuMachinesConnect_Click(object sender, System.EventArgs e)
		{
			if (treeHosts.SelectedNode == null)
				return;

			CreateVNCWindow((VNCHost)treeHosts.SelectedNode.Tag);
		}

		private void menuMachinesProperties_Click(object sender, System.EventArgs e)
		{
			if (treeHosts.SelectedNode == null)
				return;

			HostPropertiesForm hp = new HostPropertiesForm();
			
			VNCHost host = hp.Display((VNCHost)treeHosts.SelectedNode.Tag);
			if (host != null)
			{
				treeHosts.SelectedNode.Tag = host;
				treeHosts.SelectedNode.Text = ((VNCHost)treeHosts.SelectedNode.Tag).DisplayName;
				SaveConfig();
			}
		}

		private void menuMachinesDelete_Click(object sender, System.EventArgs e)
		{
			DeleteSelectedHost();
		}

		private void treeHosts_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Delete)
			{
				DeleteSelectedHost();
			}
			else if (e.KeyChar == (char)Keys.F2)
			{
				treeHosts.SelectedNode.BeginEdit();
			}
		}

		private void DeleteSelectedHost()
		{
			if (treeHosts.SelectedNode == null)
				return;

			if (treeHosts.SelectedNode.Parent == null)
			{
				MessageBox.Show("It is not possible to delete the root folder", "Invalid operation");
				return;
			}

			string type = "host";
			if (IsFolder(treeHosts.SelectedNode))
				type = "folder and all sub-folders and hosts";

			if (MessageBox.Show("Are you sure you want to delete this " + type + "?", "Confirm delete " + ((VNCHost)treeHosts.SelectedNode.Tag).DisplayName, MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				treeHosts.Nodes.Remove(treeHosts.SelectedNode);
				SaveConfig();
			}
		}

		private void menuMachinesNewFolder_Click(object sender, System.EventArgs e)
		{
			if (treeHosts.SelectedNode != null)
			{
				TreeNode newitem = null;
				if (IsFolder(treeHosts.SelectedNode))
					newitem = AddFolder("New folder", treeHosts.SelectedNode);
				else
					newitem = AddFolder("New folder", treeHosts.SelectedNode.Parent);

				newitem.BeginEdit();
			}
		}

		private void menuMainFileQuickConnect_Click(object sender, System.EventArgs e)
		{
			QuickConnectForm qc = new QuickConnectForm();
			if (qc.ShowDialog() == DialogResult.OK)
			{
				string server = qc.Server;

				VNCHost host = new VNCHost(server);
				if (host == null)
				{
					MessageBox.Show("Invalid server", "Error");
					return;
				}

				if (CreateVNCWindow(host) && MessageBox.Show("Add this host to the list?", host.DisplayName, MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					AddHost(host);
					SaveConfig();
				}
			}
		}

		private VNCHost GetConnectionDetails(string strTitle)
		{
			HostPropertiesForm hp = new HostPropertiesForm();
			hp.Text = strTitle;
			VNCHost host = hp.Display(new VNCHost("", "0.0.0.0", 0));
			return host;
		}

		private void menuMainHelpAbout_Click(object sender, System.EventArgs e)
		{
			AboutForm about = new AboutForm();
			about.ShowDialog();
		}

		private void tabs_ClosePressed(object sender, System.EventArgs e)
		{
			if (tabs.SelectedTab != null)
				RemoveTab(tabs.SelectedTab);
		}

		private void tb_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (tabs.SelectedTab == null)
				return;
			
			if (e.Button == tbSendCtrlAltDel)
			{
				((VNCConnectionControl)tabs.SelectedTab.Control).SendCtrlAltDel();
			}
			else if (e.Button == tbDisconnect)
			{
				tabs.TabPages.Remove(tabs.SelectedTab);
			}
			else if (e.Button == tbRedrawScreen)
			{
				((VNCConnectionControl)tabs.SelectedTab.Control).Refresh();
			}
		}

		private void menuMainFilePrune_Click(object sender, System.EventArgs e)
		{
			foreach (TreeNode item in treeHosts.Nodes)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(CheckItem), item);
			}
		}

		public static void CheckItem(object stateInfo)
		{
			try
			{
				TreeNode item = (TreeNode)stateInfo;

				VNCHost h = (VNCHost)item.Tag;
				IPHostEntry iphe = Dns.GetHostByName(h.Hostname);
				if (iphe == null)
				{
					MainForm.thisForm.treeHosts.Nodes.Remove(item);
					return;
				}

				IPAddress ip = iphe.AddressList[0];

				TcpClient c = new TcpClient();
				c.SendTimeout = 100;
				c.ReceiveTimeout = 100;
				try
				{
					c.Connect(ip, 5900);

					// Attempt to get the stream
					Stream s;
					s = c.GetStream();

					// Make sure the socket is closed
					c.Close();
				}
				catch
				{
					try
					{
						Int32 i = Convert.ToInt32(ip.ToString().Split(".".ToCharArray())[3]);
						c.Connect(ip, 5900+i);

						// Attempt to get the stream
						Stream s;
						s = c.GetStream();

						// Make sure the socket is closed
						c.Close();
					}
					catch
					{
						// Failed, remove it
						MainForm.thisForm.Status("Pruning: Removing " + item.Text);
						MainForm.thisForm.treeHosts.Nodes.Remove(item);
					}
				}
			}
			catch { }
		}

		private void treeHosts_AfterExpand(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (IsFolder(e.Node))
				e.Node.ImageIndex = e.Node.SelectedImageIndex = 2;
		}

		private void treeHosts_AfterCollapse(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if (IsFolder(e.Node))
				e.Node.ImageIndex = e.Node.SelectedImageIndex = 0;
		}

		private void treeHosts_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			// Start the Drag Operation
			m_nodeDragging = (TreeNode)e.Item;
			DoDragDrop(m_nodeDragging, DragDropEffects.Copy | DragDropEffects.Move);
		}

		private void treeHosts_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
			if (((VNCHost)node.Tag).Hostname != null)
				e.Effect = DragDropEffects.Move;
			else
				e.Effect = DragDropEffects.None;
		}

		private void treeHosts_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			treeHosts.BeginUpdate();
			m_nodeDragging.Remove();
			treeHosts.SelectedNode.Nodes.Add(m_nodeDragging);
			treeHosts.SelectedNode = m_nodeDragging;
			treeHosts.SelectedNode.EnsureVisible();
			treeHosts.EndUpdate();
			m_nodeDragging = null;

			SaveConfig();
		}

		private void treeHosts_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			Point Position = new Point(e.X, e.Y);

			// Convert from Form Coordinates to treeView Client coordinates

			Position = treeHosts.PointToClient(Position);

			// Find the node at this position

			TreeNode DropNode = treeHosts.GetNodeAt(Position);
			if (!IsFolder(DropNode))
				DropNode = DropNode.Parent;

			// if the node exists, insert a new node with the dropped string
			// into the second tree

			if (DropNode != null)
			{
				treeHosts.SelectedNode = DropNode;
				timerExpand.Enabled = true;
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void timerExpand_Tick(object sender, System.EventArgs e)
		{
			timerExpand.Enabled = false;
			if (m_nodeDragging != null)
			{
				if (treeHosts.SelectedNode != null)
				{
					treeHosts.SelectedNode.Expand();
				}
			}
		}

		private void treeHosts_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			VNCHost host = (VNCHost)e.Node.Tag;
			host.DisplayName = e.Node.Text;
			SaveConfig();
			treeHosts.Refresh();
		}
	}
}