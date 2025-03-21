using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;

namespace LeeXML.Pantallas
{
	public class Menu : Form
	{
		private IContainer components = null;

		private ToolStrip tsMenu;

		private ToolStripButton tsbLicencias;

		public string Titulo => Text;

		public Menu()
		{
			InitializeComponent();
		}

		private Form BuscaForma(string Titulo)
		{
			Form[] mdiChildren = base.ParentForm.MdiChildren;
			foreach (Form v in mdiChildren)
			{
				if (v.Text == Titulo)
				{
					return v;
				}
			}
			return null;
		}

		private void Menu_Load(object sender, EventArgs e)
		{
			tsMenu.Visible = false;
			if (Program.UsuarioSeleccionado.Usuario == "sys")
			{
				tsMenu.Visible = true;
			}
		}

		private void tsbLicencias_Click(object sender, EventArgs e)
		{
			try
			{
				Licencias a = (Licencias)BuscaForma(new Licencias().Titulo);
				if (a == null)
				{
					a = new Licencias();
					a.MdiParent = base.ParentForm;
					a.Show();
				}
				else
				{
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
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
			this.tsMenu = new System.Windows.Forms.ToolStrip();
			this.tsbLicencias = new System.Windows.Forms.ToolStripButton();
			this.tsMenu.SuspendLayout();
			base.SuspendLayout();
			this.tsMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.tsbLicencias });
			this.tsMenu.Location = new System.Drawing.Point(0, 0);
			this.tsMenu.Name = "tsMenu";
			this.tsMenu.Size = new System.Drawing.Size(1592, 34);
			this.tsMenu.TabIndex = 0;
			this.tsMenu.Text = "toolStrip1";
			this.tsMenu.Visible = false;
			this.tsbLicencias.Image = LeeXML.Properties.Resources.Bookmark;
			this.tsbLicencias.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLicencias.Name = "tsbLicencias";
			this.tsbLicencias.Size = new System.Drawing.Size(124, 29);
			this.tsbLicencias.Text = "LICENCIAS";
			this.tsbLicencias.Click += new System.EventHandler(tsbLicencias_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = LeeXML.Properties.Resources.LOGO_BASEFISCAL;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			base.ClientSize = new System.Drawing.Size(1592, 842);
			base.Controls.Add(this.tsMenu);
			this.DoubleBuffered = true;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Menu";
			this.Text = "Menu";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(Menu_Load);
			this.tsMenu.ResumeLayout(false);
			this.tsMenu.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
