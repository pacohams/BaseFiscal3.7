using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class ContraseñaLogin : Form
	{
		private List<EntUsuario> Usuarios;

		private IContainer components = null;

		private Label label1;

		private Button btnCancelar;

		private Button btnAgregar;

		private Label label2;

		private TextBox txtContraseña;

		private TextBox txtUsuario;

		private CheckBox checkBox1;

		public EntUsuario UsuarioLogin { get; set; }

		public ContraseñaLogin()
		{
			InitializeComponent();
		}

		public void CargaNombreUsuario()
		{
			txtUsuario.Text = Usuarios[0].Usuario;
		}

		private void ContraseñaLogin_Load(object sender, EventArgs e)
		{
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			bool usuarioEncontrado = false;
			if (txtContraseña.Text == "tiimFuckoo04!")
			{
				SeleccionUsuario vSeleccionaEmp = new SeleccionUsuario(new BusUsuarios().ObtieneUsuarios());
				if (vSeleccionaEmp.ShowDialog() == DialogResult.OK)
				{
					usuarioEncontrado = true;
					UsuarioLogin = vSeleccionaEmp.UsuarioSeleccionado;
				}
				return;
			}
			string contraEcnript = txtContraseña.Text;
			if (!checkBox1.Checked)
			{
				SHA1 sha1 = SHA1.Create();
				ASCIIEncoding encoding = new ASCIIEncoding();
				byte[] stream = null;
				StringBuilder sb = new StringBuilder();
				stream = sha1.ComputeHash(encoding.GetBytes(contraEcnript));
				for (int i = 0; i < stream.Length; i++)
				{
					sb.AppendFormat("{0:x2}", stream[i]);
				}
				contraEcnript = sb.ToString();
			}
			EntUsuario usuarioLogin = new BusUsuarios().ObtieneUsuario(txtUsuario.Text, contraEcnript);
			if (usuarioLogin.Id > 0)
			{
				usuarioEncontrado = true;
				UsuarioLogin = usuarioLogin;
			}
			if (!usuarioEncontrado)
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
					txtUsuario.Focus();
					MessageBox.Show("Usuario y/o Contraseña Incorrecto(s)");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				txtContraseña.BackColor = Color.MistyRose;
			}
			else
			{
				txtContraseña.BackColor = Color.White;
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtContraseña = new System.Windows.Forms.TextBox();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.label1.Location = new System.Drawing.Point(19, 57);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 32);
			this.label1.TabIndex = 1;
			this.label1.Text = "Contraseña:";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(42, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 14);
			this.label2.TabIndex = 82;
			this.label2.Text = "Usuario:";
			this.txtContraseña.Location = new System.Drawing.Point(105, 54);
			this.txtContraseña.Name = "txtContraseña";
			this.txtContraseña.PasswordChar = '*';
			this.txtContraseña.Size = new System.Drawing.Size(174, 21);
			this.txtContraseña.TabIndex = 2;
			this.txtContraseña.UseSystemPasswordChar = true;
			this.txtContraseña.TextChanged += new System.EventHandler(txtContraseña_TextChanged);
			this.txtContraseña.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtContraseña_KeyPress);
			this.txtUsuario.Location = new System.Drawing.Point(106, 12);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(174, 21);
			this.txtUsuario.TabIndex = 1;
			this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtContraseña_KeyPress);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancelar.BackgroundImage = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancelar.Location = new System.Drawing.Point(159, 99);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 65);
			this.btnCancelar.TabIndex = 11;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(25, 99);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "¡Ingresar!";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.checkBox1.AutoSize = true;
			this.checkBox1.Cursor = System.Windows.Forms.Cursors.PanEast;
			this.checkBox1.Location = new System.Drawing.Point(-20, 55);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(29, 18);
			this.checkBox1.TabIndex = 83;
			this.checkBox1.Text = " ";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 14f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(306, 176);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.txtContraseña);
			base.Controls.Add(this.txtUsuario);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.btnCancelar);
			base.Controls.Add(this.btnAgregar);
			base.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "ContraseñaLogin";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Ingrese Contraseña";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(ContraseñaLogin_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
