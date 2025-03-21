using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;

namespace LeeXML.Pantallas
{
	public class SeleccionaFechaMes : Form
	{
		private IContainer components = null;

		private Button btnAgregar;

		private ComboBox cmbTipoRevision;

		private Panel panel2;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		public DateTime MesFechaSeleccionado => new DateTime(Convert.ToInt32(cmbAñoComprobantes.Text), cmbMesesComprobantes.SelectedIndex + 1, 1);

		public SeleccionaFechaMes()
		{
			InitializeComponent();
		}

		public void CargaAñosCmb(ComboBox cmbAños)
		{
			List<EntCatalogoGenerico> años = new List<EntCatalogoGenerico>();
			for (int x = DateTime.Today.Year + 1; x >= Program.AñoInicio; x--)
			{
				EntCatalogoGenerico año = new EntCatalogoGenerico();
				año.Descripcion = x.ToString();
				años.Add(año);
			}
			cmbAños.DataSource = años;
		}

		private void SeleccionaFechaMes_Load(object sender, EventArgs e)
		{
			try
			{
				CargaAñosCmb(cmbAñoComprobantes);
				cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
				cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
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
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.btnAgregar = new System.Windows.Forms.Button();
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
			this.panel2.Controls.Add(this.cmbMesesComprobantes);
			this.panel2.Controls.Add(this.cmbAñoComprobantes);
			this.panel2.Location = new System.Drawing.Point(12, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(325, 74);
			this.panel2.TabIndex = 134;
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(13, 21);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(167, 30);
			this.cmbMesesComprobantes.TabIndex = 21;
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(209, 22);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(101, 28);
			this.cmbAñoComprobantes.TabIndex = 22;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(113, 113);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "Seleccionar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(349, 190);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.cmbTipoRevision);
			base.Controls.Add(this.btnAgregar);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "SeleccionaFechaMes";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seleccione Mes - Fecha";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(SeleccionaFechaMes_Load);
			this.panel2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
