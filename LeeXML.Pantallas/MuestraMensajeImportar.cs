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
	public class MuestraMensajeImportar : Form
	{
		private List<EntUsuario> Usuarios;

		private IContainer components = null;

		private Button btnAgregar;

		private Label lbMensaje;

		private LinkLabel lnkMensaje;

		private PictureBox pbLogoBFX;

		private Button button1;

		private Panel panel1;

		public string Mensaje
		{
			set
			{
				lbMensaje.Text = value;
			}
		}

		public MuestraMensajeImportar()
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
				string paginaDescarga = new BusEmpresas().ObtienePaginasDescarga(2).First().Descripcion;
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
			this.lnkMensaje = new System.Windows.Forms.LinkLabel();
			this.button1 = new System.Windows.Forms.Button();
			this.pbLogoBFX = new System.Windows.Forms.PictureBox();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)this.pbLogoBFX).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.lbMensaje.AutoSize = true;
			this.lbMensaje.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbMensaje.Location = new System.Drawing.Point(73, 225);
			this.lbMensaje.Name = "lbMensaje";
			this.lbMensaje.Size = new System.Drawing.Size(15, 22);
			this.lbMensaje.TabIndex = 82;
			this.lbMensaje.Text = ":";
			this.lnkMensaje.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.lnkMensaje.AutoSize = true;
			this.lnkMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lnkMensaje.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.lnkMensaje.LinkColor = System.Drawing.Color.Black;
			this.lnkMensaje.Location = new System.Drawing.Point(57, 29);
			this.lnkMensaje.Name = "lnkMensaje";
			this.lnkMensaje.Size = new System.Drawing.Size(330, 68);
			this.lnkMensaje.TabIndex = 83;
			this.lnkMensaje.TabStop = true;
			this.lnkMensaje.Text = "              ¡Carga de archivos XML exitosa! \r\n\r\nPara guardar la información en BASE FISCAL XML \r\n                    Dar click en 'Importar'";
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Image = LeeXML.Properties.Resources.Paper_Search;
			this.button1.Location = new System.Drawing.Point(274, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(167, 65);
			this.button1.TabIndex = 85;
			this.button1.Text = "Ver Información \r\nAntes de Importar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button1.UseVisualStyleBackColor = false;
			this.pbLogoBFX.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.pbLogoBFX.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pbLogoBFX.Image = LeeXML.Properties.Resources.LOGO_BASEFISCAL_SINFONDO;
			this.pbLogoBFX.Location = new System.Drawing.Point(359, 5);
			this.pbLogoBFX.Name = "pbLogoBFX";
			this.pbLogoBFX.Size = new System.Drawing.Size(167, 108);
			this.pbLogoBFX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbLogoBFX.TabIndex = 84;
			this.pbLogoBFX.TabStop = false;
			this.pbLogoBFX.Click += new System.EventHandler(pbLogoBFX_Click);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Image = LeeXML.Properties.Resources.Database_import;
			this.btnAgregar.Location = new System.Drawing.Point(41, 9);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(167, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "Importar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Controls.Add(this.button1);
			this.panel1.Controls.Add(this.btnAgregar);
			this.panel1.Location = new System.Drawing.Point(0, 108);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(501, 88);
			this.panel1.TabIndex = 86;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			base.ClientSize = new System.Drawing.Size(500, 190);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.lnkMensaje);
			base.Controls.Add(this.pbLogoBFX);
			base.Controls.Add(this.lbMensaje);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "MuestraMensajeImportar";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "COMPLETAR IMPORTACIÓN";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(ContraseñaLogin_Load);
			((System.ComponentModel.ISupportInitialize)this.pbLogoBFX).EndInit();
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
