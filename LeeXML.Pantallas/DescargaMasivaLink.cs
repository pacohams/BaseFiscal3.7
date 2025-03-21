using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LeeXML.Pantallas
{
	public class DescargaMasivaLink : Form
	{
		private IContainer components = null;

		private WebBrowser webBrowser1;

		private Timer timer1;

		public string DireccionHTTP { get; set; }

		public DescargaMasivaLink(string DireccionHTTP)
		{
			InitializeComponent();
			this.DireccionHTTP = DireccionHTTP.Replace("\"\r\n]", "");
		}

		private void DescargaSAT_Load(object sender, EventArgs e)
		{
			webBrowser1.Navigate(DireccionHTTP);
			Close();
		}

		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(1410, 767);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.Url = new System.Uri("http://www.portalcfdi.facturaelectronica.sat.gob.mx/", System.UriKind.Absolute);
			this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
			this.timer1.Interval = 5000;
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1410, 767);
			base.Controls.Add(this.webBrowser1);
			base.Name = "DescargaMasivaLink";
			this.Text = "DescargaMasivaSAT";
			base.Load += new System.EventHandler(DescargaSAT_Load);
			base.ResumeLayout(false);
		}
	}
}
