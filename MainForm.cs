/*
 * Created by SharpDevelop.
 * User: Radiation
 * Date: 2016/10/20
 * Time: 12:11
 * blog: http://b.zlweb.cc
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using fuckbrain;

namespace fuckbrain
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Button1Click(object sender, EventArgs e)
		{
			fuckBrain fb = new fuckBrain();
			string text = textBox1.Text;
			textBox2.Text = fb.text2FuckBrain(text);
		}
		void Button2Click(object sender, EventArgs e)
		{
			fuckBrain fb = new fuckBrain();
			string text = textBox1.Text;
			textBox2.Text = fb.FuckBrain2Text(text);
			
		}
	}
}
