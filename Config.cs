using System;
using System.Xml;

namespace Farsoft.Utils
{
	/// <summary>
	/// Encapsulates the configuration
	/// </summary>
	public class Config
	{
		private bool m_bInitialised = false;
		private string m_strRoot;

		private XmlDataDocument m_xmlConfig;

		public Config(string strConfigFilename, string strRoot)
		{
			m_strRoot = strRoot;
			LoadConfig(strConfigFilename);
		}

		public bool LoadConfig(string strConfigFilename)
		{
		    try
		    {
                m_xmlConfig = new XmlDataDocument();
                m_xmlConfig.Load(strConfigFilename);
		        //m_xmlConfig.Save(Console.Out);
		    	m_bInitialised = true;
                return true;
		    }
		    catch //(Exception ex1)
		    {
				try
				{
					m_xmlConfig = new XmlDataDocument();
					m_xmlConfig.LoadXml(SkeletonFile);
					SaveConfig(strConfigFilename);
					m_bInitialised = true;
					return true;
				}
				catch (Exception ex2)
				{
					Console.WriteLine(ex2.Message);
					m_bInitialised = false;
					return false;
				}
		    }
		}

		public bool SaveConfig(string strConfigFilename)
		{
			try
			{
				m_xmlConfig.Save(strConfigFilename);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public string RootPath
		{
			get { return m_strRoot; }
			set { m_strRoot = value; }
		}

		public XmlElement CreateElement(string strName)
		{
			return m_xmlConfig.CreateElement(strName);
		}

		public XmlAttribute CreateAttribute(string strName)
		{
			return m_xmlConfig.CreateAttribute(strName);
		}

		public XmlNode GetNode(string strPath)
		{
			XmlNodeList nodeList;
			XmlElement root = m_xmlConfig.DocumentElement;
			nodeList = root.SelectNodes(m_strRoot + strPath);

			if (nodeList.Count == 0)
				return null;

			return nodeList[0];
		}

		public XmlNodeList GetNodes(string strPath)
		{
			XmlNodeList nodeList;
			XmlElement root = m_xmlConfig.DocumentElement;
			if (root == null)
				return null;

			nodeList = root.SelectNodes(m_strRoot + strPath);

			if (nodeList.Count == 0)
				return null;

			return nodeList;
		}

		public string Get(string strPath)
		{
			if (m_bInitialised == false)
				return null;

			XmlNodeList nodeList;
			XmlElement root = m_xmlConfig.DocumentElement;
			nodeList = root.SelectNodes(m_strRoot + strPath);

			if (nodeList.Count == 0)
				return null;

			XmlNode node = nodeList[0];

			if (node.InnerText != null)
				return node.InnerText;
			else if (node.Value != null)
				return node.Value;
			else
				return null;
		}

		public string[] GetMultiple(string strPath)
		{
			if (m_bInitialised == false)
				return null;

			XmlNodeList nodeList;
			XmlElement root = m_xmlConfig.DocumentElement;
			nodeList = root.SelectNodes(m_strRoot + strPath);

			if (nodeList.Count == 0)
				return null;

			string[] astrRetval = new string[nodeList.Count];

			for (int i = 0; i < nodeList.Count; i++)
			{
				astrRetval.SetValue(nodeList[i].InnerText, i);
			}

			return astrRetval;
		}

		public string SkeletonFile
		{
			get
			{
				return
					"<?xml version=\"1.0\"?>\n" +
					"<salamandercs>\n" +
					"    <networks scaninterval=\"0\">\n" +
					"    </networks>\n" +
					"    <hosts>\n" +
					"    </hosts>\n" +
					"    <vnc>\n" +
					"    	<graphics>\n" +
					"    		<drawingType>gdiplus</drawingType>\n" +
					"    		<nrOfViews>1</nrOfViews>\n" +
					"    	</graphics>\n" +
					"    	<decoders>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.CopyRectDecoder</decoder>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.ExtendedHexitleDecoder</decoder>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.StandardHexitleDecoder</decoder>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.RREDecoder</decoder>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.CoRREDecoder</decoder>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.ZlibEncDecoder</decoder>\n" +
					"    		<decoder>VNCManager.RFBDrawing.UpdateDecoders.RawDecoder</decoder>\n" +
					"    	</decoders>\n" +
					"    </vnc>\n" +
					"</salamandercs>";
			}
		}
	}
}
