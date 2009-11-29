#region Using directives

using System;
using System.Windows.Forms;

#endregion

namespace Farsoft.SCS
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			// Fix for EnableVisualStyles breaking imagelists
			// From http://www.codeproject.com/buglist/EnableVisualStylesBug.asp
			Application.DoEvents();
			Application.Run(new MainForm(args));
		}
	}
}