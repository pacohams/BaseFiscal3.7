using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class SeleccionaTipoRevision : Form
	{
		private List<EntUsuario> Usuarios;

		private IContainer components = null;

		private Button btnAgregar;

		private ComboBox cmbTipoRevision;

		private Panel panel2;

		private RadioButton rdoEgresos;

		private RadioButton rdoIngresos;

		public EntUsuario UsuarioLogin { get; set; }

		public SeleccionaTipoRevision()
		{
			InitializeComponent();
			Usuarios = new BusUsuarios().ObtieneUsuarios();
		}

		private void SeleccionaTipoRevision_Load(object sender, EventArgs e)
		{
			try
			{
				Program.TipoRevisionId = 1;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
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

		private void rdoIngresos_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (rdoIngresos.Checked)
				{
					Program.TipoRevisionId = 1;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void rdoEgresos_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (rdoEgresos.Checked)
				{
					Program.TipoRevisionId = 2;
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
			this.cmbTipoRevision = new System.Windows.Forms.ComboBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.rdoIngresos = new System.Windows.Forms.RadioButton();
			this.rdoEgresos = new System.Windows.Forms.RadioButton();
			this.panel2.SuspendLayout();
			base.SuspendLayout();
			this.cmbTipoRevision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoRevision.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbTipoRevision.FormattingEnabled = true;
			this.cmbTipoRevision.Location = new System.Drawing.Point(265, 149);
			this.cmbTipoRevision.Name = "cmbTipoRevision";
			this.cmbTipoRevision.Size = new System.Drawing.Size(173, 26);
			this.cmbTipoRevision.TabIndex = 12;
			this.cmbTipoRevision.Visible = false;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.rdoEgresos);
			this.panel2.Controls.Add(this.rdoIngresos);
			this.panel2.Location = new System.Drawing.Point(12, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(325, 101);
			this.panel2.TabIndex = 134;
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(115, 124);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "¡Listo!";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.rdoIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rdoIngresos.BackgroundImage = LeeXML.Properties.Resources.emitidos_cfdi_descargar;
			this.rdoIngresos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.rdoIngresos.Checked = true;
			this.rdoIngresos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rdoIngresos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rdoIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoIngresos.Location = new System.Drawing.Point(6, -3);
			this.rdoIngresos.Name = "rdoIngresos";
			this.rdoIngresos.Size = new System.Drawing.Size(137, 101);
			this.rdoIngresos.TabIndex = 0;
			this.rdoIngresos.TabStop = true;
			this.rdoIngresos.Text = "CFDI EMITIDOS";
			this.rdoIngresos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.rdoIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.rdoIngresos.UseVisualStyleBackColor = true;
			this.rdoIngresos.CheckedChanged += new System.EventHandler(rdoIngresos_CheckedChanged);
			this.rdoEgresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rdoEgresos.BackgroundImage = LeeXML.Properties.Resources.recibidos_cfdi_descargar;
			this.rdoEgresos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.rdoEgresos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rdoEgresos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.rdoEgresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEgresos.Location = new System.Drawing.Point(169, 0);
			this.rdoEgresos.Name = "rdoEgresos";
			this.rdoEgresos.Size = new System.Drawing.Size(158, 97);
			this.rdoEgresos.TabIndex = 1;
			this.rdoEgresos.Text = "CFDI RECIBIDOS";
			this.rdoEgresos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.rdoEgresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.rdoEgresos.UseVisualStyleBackColor = true;
			this.rdoEgresos.CheckedChanged += new System.EventHandler(rdoEgresos_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(349, 201);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.cmbTipoRevision);
			base.Controls.Add(this.btnAgregar);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "SeleccionaTipoRevision";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tipo Revisión";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(SeleccionaTipoRevision_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
