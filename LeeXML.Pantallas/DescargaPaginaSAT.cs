using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace LeeXML.Pantallas
{
	public class DescargaPaginaSAT : Form
	{
		private IContainer components = null;

		private WebBrowser webBrowser1;

		public DescargaPaginaSAT()
		{
			InitializeComponent();
		}

		private void DescargaSAT_Load(object sender, EventArgs e)
		{
			webBrowser1.Navigate("https://portalcfdi.facturaelectronica.sat.gob.mx/");
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
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			base.SuspendLayout();
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(1410, 767);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.Url = new System.Uri("http://www.portalcfdi.facturaelectronica.sat.gob.mx/", System.UriKind.Absolute);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1410, 767);
			base.Controls.Add(this.webBrowser1);
			base.Name = "DescargaSAT";
			this.Text = "DescargaSAT";
			base.Load += new System.EventHandler(DescargaSAT_Load);
			base.ResumeLayout(false);
		}
	}
}
