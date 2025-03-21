using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;

namespace LeeXML.Pantallas
{
	public class SeleccionaCatalogo : FormBase
	{
		private IContainer components = null;

		private Button btnAgregar;

		private Panel panel2;

		private ComboBox cmbMesesComprobantes;

		private BindingSource entCatalogoGenericoBindingSource;

		private List<EntCatalogoGenerico> Catalogo { get; set; }

		public EntCatalogoGenerico CatalogoSeleccionado => ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);

		public SeleccionaCatalogo(List<Enum> Catalogo)
		{
			InitializeComponent();
		}

		public SeleccionaCatalogo(Dictionary<string, int> Catalogo)
		{
			InitializeComponent();
		}

		public SeleccionaCatalogo(List<EntCatalogoGenerico> Catalogo, string Titulo = "SELECCIÓN DE CATÁLOGO")
		{
			InitializeComponent();
			this.Catalogo = Catalogo;
			Text = Titulo;
			cmbMesesComprobantes.DataSource = Catalogo;
			cmbMesesComprobantes.SelectedIndex = 0;
		}

		private void SeleccionaFechaMes_Load(object sender, EventArgs e)
		{
			try
			{
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
			this.components = new System.ComponentModel.Container();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnAgregar = new System.Windows.Forms.Button();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			base.SuspendLayout();
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmbMesesComprobantes);
			this.panel2.Location = new System.Drawing.Point(12, 24);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(325, 74);
			this.panel2.TabIndex = 134;
			this.cmbMesesComprobantes.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbMesesComprobantes.DisplayMember = "Descripcion";
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(13, 21);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(296, 33);
			this.cmbMesesComprobantes.TabIndex = 21;
			this.cmbMesesComprobantes.ValueMember = "Id";
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(113, 107);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 74);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "Seleccionar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 22f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(349, 190);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.btnAgregar);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "SeleccionaCatalogo";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seleccion";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Contraseña_FormClosing);
			base.Load += new System.EventHandler(SeleccionaFechaMes_Load);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			base.ResumeLayout(false);
		}
	}
}
