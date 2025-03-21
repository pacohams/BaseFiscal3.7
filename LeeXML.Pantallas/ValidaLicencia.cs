using System;
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
	public class ValidaLicencia : Form
	{
		private IContainer components = null;

		private Label label1;

		private Button btnCancelar;

		private Button btnAgregar;

		private TextBox txtSerial;

		private Label label2;

		private Button btnAdquiereLicencia;

		private PictureBox pbAquiereLicencia;

		private int CompañiaId { get; set; }

		private string PaginaDescarga { get; set; }

		public EntUsuario UsuarioLogin { get; set; }

		public ValidaLicencia(int CompañiaId)
		{
			InitializeComponent();
			this.CompañiaId = CompañiaId;
		}

		private void ContraseñaLogin_Load(object sender, EventArgs e)
		{
			PaginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			bool serialEncontrado = false;
			string serialEcnript = txtSerial.Text;
			EntUsuario usuarioLogin = new BusUsuarios().VerificaLicencia(CompañiaId, serialEcnript);
			if (usuarioLogin.Id > 0)
			{
				serialEncontrado = true;
				UsuarioLogin = usuarioLogin;
			}
			if (!serialEncontrado)
			{
				base.DialogResult = DialogResult.Abort;
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
		}

		private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				btnAgregar.PerformClick();
			}
		}

		private void txtContraseña_TextChanged(object sender, EventArgs e)
		{
		}

		private void Contraseña_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (base.DialogResult == DialogResult.Abort)
				{
					e.Cancel = true;
					MessageBox.Show("SERIAL INVÁLIDO");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void btnAdquiereLicencia_Click(object sender, EventArgs e)
		{
			Process.Start(PaginaDescarga);
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
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.txtSerial = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAdquiereLicencia = new System.Windows.Forms.Button();
			this.pbAquiereLicencia = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)this.pbAquiereLicencia).BeginInit();
			base.SuspendLayout();
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(12, 111);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ingrese Serial:";
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancelar.BackgroundImage = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancelar.Location = new System.Drawing.Point(226, 168);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(70, 65);
			this.btnCancelar.TabIndex = 11;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(123, 168);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(70, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "¡Ingresar!";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.txtSerial.Location = new System.Drawing.Point(119, 108);
			this.txtSerial.Name = "txtSerial";
			this.txtSerial.PasswordChar = '*';
			this.txtSerial.Size = new System.Drawing.Size(263, 25);
			this.txtSerial.TabIndex = 2;
			this.txtSerial.UseSystemPasswordChar = true;
			this.txtSerial.TextChanged += new System.EventHandler(txtContraseña_TextChanged);
			this.txtSerial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtContraseña_KeyPress);
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(133, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(203, 18);
			this.label2.TabIndex = 12;
			this.label2.Text = "¿Desea adquirir una Licencia?";
			this.btnAdquiereLicencia.BackColor = System.Drawing.Color.White;
			this.btnAdquiereLicencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAdquiereLicencia.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAdquiereLicencia.Location = new System.Drawing.Point(121, 32);
			this.btnAdquiereLicencia.Name = "btnAdquiereLicencia";
			this.btnAdquiereLicencia.Size = new System.Drawing.Size(220, 45);
			this.btnAdquiereLicencia.TabIndex = 13;
			this.btnAdquiereLicencia.Text = "¡ADQUIERE TU LICENCIA AQUÍ!";
			this.btnAdquiereLicencia.UseVisualStyleBackColor = false;
			this.btnAdquiereLicencia.Click += new System.EventHandler(btnAdquiereLicencia_Click);
			this.pbAquiereLicencia.Image = LeeXML.Properties.Resources.LOGO_BASEFISCAL;
			this.pbAquiereLicencia.Location = new System.Drawing.Point(52, 31);
			this.pbAquiereLicencia.Name = "pbAquiereLicencia";
			this.pbAquiereLicencia.Size = new System.Drawing.Size(84, 45);
			this.pbAquiereLicencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pbAquiereLicencia.TabIndex = 14;
			this.pbAquiereLicencia.TabStop = false;
			this.pbAquiereLicencia.Click += new System.EventHandler(btnAdquiereLicencia_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(416, 245);
			base.Controls.Add(this.btnAdquiereLicencia);
			base.Controls.Add(this.pbAquiereLicencia);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.txtSerial);
			base.Controls.Add(this.btnCancelar);
			base.Controls.Add(this.btnAgregar);
			base.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "ValidaLicencia";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Validar Licencia";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(ContraseñaLogin_Load);
			((System.ComponentModel.ISupportInitialize)this.pbAquiereLicencia).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
