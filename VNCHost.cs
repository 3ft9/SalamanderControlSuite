using System;
using System.Net;
using System.Xml;

namespace Farsoft.SCS
{
	/// <summary>
	/// Summary description for VNCHost.
	/// </summary>
	public class VNCHost
	{
		string m_strHostname;
		int m_nScreen;
		string m_strDisplayName;
		string m_strPassword;

		public VNCHost(string strServer)
		{
			string name = "";
			string hostname = "";
			int screen = 0;

			string[] bits = strServer.Split(":".ToCharArray());
			hostname = bits[0];
			if (bits.Length > 1)
				screen = Convert.ToInt16(bits[1]);

			Init(name, hostname, screen, "");
		}

		public VNCHost(string strDisplayName, string strHostname, int nScreen)
		{
			Init(strDisplayName, strHostname, nScreen, "");
		}

		public VNCHost(string strDisplayName, string strHostname, int nScreen, string strPassword)
		{
			Init(strDisplayName, strHostname, nScreen, strPassword);
		}

		public VNCHost(XmlNode node)
		{
			try
			{
				string strDisplayName = node.InnerXml;
				string strHostname;
				int nScreen = Convert.ToInt32(node.Attributes["screen"].Value);
				string strPassword = node.Attributes["password"].Value;

				if (node.Attributes["ip"] != null)
					strHostname = node.Attributes["ip"].Value;
				else
					strHostname = node.Attributes["hostname"].Value;

				Init(strDisplayName, strHostname, nScreen, strPassword);
			}
			catch
			{
				Init("", "", 0, "");
			}
		}

		public void Init(string strDisplayName, string strHostname, int nScreen, string strPassword)
		{
			m_strDisplayName = strDisplayName;
			m_strHostname = strHostname;
			m_nScreen = nScreen;
			m_strPassword = strPassword;
		}

		public XmlElement GetElement(XmlElement e)
		{
			try
			{
				e.InnerText = DisplayName;
				e.SetAttribute("hostname", Hostname);
				e.SetAttribute("screen", Screen.ToString());
				e.SetAttribute("password", Password);
				return e;
			}
			catch
			{
				return null;
			}
		}

		public string DisplayName
		{
			get { return m_strDisplayName; }
			set { m_strDisplayName = value; }
		}

		public string Hostname
		{
			get { return m_strHostname; }
			set { m_strHostname = value; }
		}

		public string Password
		{
			get { return m_strPassword; }
			set { m_strPassword = value; }
		}

		public int Screen
		{
			get { return m_nScreen; }
			set { m_nScreen = value; }
		}
	}
}
