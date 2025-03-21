using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class MuestraMensajePaginaCompra : Form
	{
		private List<EntUsuario> Usuarios;

		private IContainer components = null;

		private Button btnAgregar;

		private Label lbMensaje;

		private LinkLabel lnkPaginaDescarga;

		private PictureBox pbLogoBFX;

		public string Mensaje
		{
			set
			{
				lbMensaje.Text = value;
			}
		}

		public MuestraMensajePaginaCompra()
		{
			InitializeComponent();
		}

		private void ContraseñaLogin_Load(object sender, EventArgs e)
		{
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
		}

		private void Contraseña_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (base.DialogResult == DialogResult.Abort)
				{
					e.Cancel = true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void lnkPaginaDescarga_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				string paginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
				Process.Start(paginaDescarga);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void pbLogoBFX_Click(object sender, EventArgs e)
		{
			try
			{
				string paginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
				Process.Start(paginaDescarga);
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
			this.lbMensaje = new System.Windows.Forms.Label();
			this.lnkPaginaDescarga = new System.Windows.Forms.LinkLabel();
			this.pbLogoBFX = new System.Windows.Forms.PictureBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.pbLogoBFX).BeginInit();
			base.SuspendLayout();
			this.lbMensaje.AutoSize = true;
			this.lbMensaje.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbMensaje.Location = new System.Drawing.Point(249, 56);
			this.lbMensaje.Name = "lbMensaje";
			this.lbMensaje.Size = new System.Drawing.Size(15, 22);
			this.lbMensaje.TabIndex = 82;
			this.lbMensaje.Text = ":";
			this.lnkPaginaDescarga.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lnkPaginaDescarga.AutoSize = true;
			this.lnkPaginaDescarga.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lnkPaginaDescarga.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lnkPaginaDescarga.LinkColor = System.Drawing.Color.DarkSlateBlue;
			this.lnkPaginaDescarga.Location = new System.Drawing.Point(216, 212);
			this.lnkPaginaDescarga.Name = "lnkPaginaDescarga";
			this.lnkPaginaDescarga.Size = new System.Drawing.Size(305, 26);
			this.lnkPaginaDescarga.TabIndex = 83;
			this.lnkPaginaDescarga.TabStop = true;
			this.lnkPaginaDescarga.Text = "¡ADQUIERE TU LICENCIA AQUÍ!";
			this.lnkPaginaDescarga.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkPaginaDescarga_LinkClicked);
			this.pbLogoBFX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.pbLogoBFX.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbLogoBFX.Image = LeeXML.Properties.Resources.LOGO_BASEFISCAL_SINFONDO;
			this.pbLogoBFX.Location = new System.Drawing.Point(251, 93);
			this.pbLogoBFX.Name = "pbLogoBFX";
			this.pbLogoBFX.Size = new System.Drawing.Size(167, 108);
			this.pbLogoBFX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLogoBFX.TabIndex = 84;
			this.pbLogoBFX.TabStop = false;
			this.pbLogoBFX.Click += new System.EventHandler(pbLogoBFX_Click);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(251, 255);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(167, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "Aceptar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(670, 332);
			base.Controls.Add(this.pbLogoBFX);
			base.Controls.Add(this.lnkPaginaDescarga);
			base.Controls.Add(this.lbMensaje);
			base.Controls.Add(this.btnAgregar);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "MuestraMensajePaginaCompra";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Muestra Mensaje";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(ContraseñaLogin_Load);
			((System.ComponentModel.ISupportInitialize)this.pbLogoBFX).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
