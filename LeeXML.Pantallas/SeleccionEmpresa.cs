using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class SeleccionEmpresa : Form
	{
		private IContainer components = null;

		private Button btnCancelar;

		private Button btnAgregar;

		private BindingSource entEmpresaBindingSource;

		private DataGridView gvEmpresas;

		private Label lbMensaje;

		private Panel pnlGeneral;

		private Button btnFiltraFacturas;

		private TextBox txtFacturaFiltro;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn nombreFiscalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn RFC;

		private DataGridViewTextBoxColumn LicenciaSerial;

		private DataGridViewTextBoxColumn DiasExpiracion;

		public List<EntEmpresa> ListaEmpresas { get; set; }

		public EntEmpresa EmpresaSeleccionada => ObtieneEmpresaFromGV(gvEmpresas);

		public SeleccionEmpresa()
		{
			InitializeComponent();
			CargaEmpresas();
		}

		public void CargaEmpresas()
		{
			ListaEmpresas = new BusEmpresas().ObtieneEmpresasActivas(Program.UsuarioSeleccionado.CompañiaId);
			gvEmpresas.DataSource = ListaEmpresas;
		}

		public EntEmpresa ObtieneEmpresaFromGV(DataGridView GridViewEmpresas)
		{
			if (GridViewEmpresas.CurrentRow == null)
			{
				return null;
			}
			return ((List<EntEmpresa>)GridViewEmpresas.DataSource)[GridViewEmpresas.CurrentRow.Index];
		}

		private void SeleccionEmpresa_Load(object sender, EventArgs e)
		{
			try
			{
				if (ListaEmpresas.Count == 0)
				{
					MuestraMensajePaginaCompra vMensaje = new MuestraMensajePaginaCompra();
					vMensaje.Text = "SIN LICENCIAS ACTIVAS";
					vMensaje.Mensaje = "LICENCIA(S) VENCIDA(S)";
					vMensaje.ShowDialog();
					Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
		}

		private void gvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				btnAgregar.PerformClick();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void gvEmpresas_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					btnAgregar.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void txtFacturaFiltro_TextChanged(object sender, EventArgs e)
		{
			try
			{
				gvEmpresas.DataSource = ListaEmpresas.Where((EntEmpresa P) => P.Nombre.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) || P.NombreFiscal.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) || P.RFC.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper())).ToList();
				gvEmpresas.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void pnlGeneral_Paint(object sender, PaintEventArgs e)
		{
		}

		private void txtFacturaFiltro_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				btnAgregar.PerformClick();
			}
		}

		private void SeleccionEmpresa_Activated(object sender, EventArgs e)
		{
			txtFacturaFiltro.Focus();
		}

		private void btnFiltraFacturas_Click(object sender, EventArgs e)
		{
		}

		private void gvEmpresas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.SeleccionEmpresa));
			this.gvEmpresas = new System.Windows.Forms.DataGridView();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreFiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.LicenciaSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DiasExpiracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.lbMensaje = new System.Windows.Forms.Label();
			this.pnlGeneral = new System.Windows.Forms.Panel();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.txtFacturaFiltro = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)this.gvEmpresas).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).BeginInit();
			this.pnlGeneral.SuspendLayout();
			base.SuspendLayout();
			this.gvEmpresas.AllowUserToAddRows = false;
			this.gvEmpresas.AllowUserToResizeRows = false;
			this.gvEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvEmpresas.AutoGenerateColumns = false;
			this.gvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvEmpresas.BackgroundColor = System.Drawing.Color.White;
			this.gvEmpresas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.gvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvEmpresas.Columns.AddRange(this.nombreDataGridViewTextBoxColumn, this.nombreFiscalDataGridViewTextBoxColumn, this.RFC, this.LicenciaSerial, this.DiasExpiracion);
			this.gvEmpresas.DataSource = this.entEmpresaBindingSource;
			this.gvEmpresas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gvEmpresas.GridColor = System.Drawing.Color.DimGray;
			this.gvEmpresas.Location = new System.Drawing.Point(5, 37);
			this.gvEmpresas.MultiSelect = false;
			this.gvEmpresas.Name = "gvEmpresas";
			this.gvEmpresas.ReadOnly = true;
			this.gvEmpresas.RowHeadersVisible = false;
			this.gvEmpresas.RowHeadersWidth = 51;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.gvEmpresas.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.gvEmpresas.RowTemplate.Height = 30;
			this.gvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvEmpresas.Size = new System.Drawing.Size(891, 417);
			this.gvEmpresas.TabIndex = 92;
			this.gvEmpresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvEmpresas_CellDoubleClick);
			this.gvEmpresas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(gvEmpresas_ColumnHeaderMouseClick);
			this.gvEmpresas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(gvEmpresas_KeyPress);
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
			this.nombreDataGridViewTextBoxColumn.FillWeight = 2.5f;
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
			this.nombreFiscalDataGridViewTextBoxColumn.DataPropertyName = "NombreFiscal";
			this.nombreFiscalDataGridViewTextBoxColumn.FillWeight = 3f;
			this.nombreFiscalDataGridViewTextBoxColumn.HeaderText = "NombreFiscal";
			this.nombreFiscalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreFiscalDataGridViewTextBoxColumn.Name = "nombreFiscalDataGridViewTextBoxColumn";
			this.nombreFiscalDataGridViewTextBoxColumn.ReadOnly = true;
			this.RFC.DataPropertyName = "RFC";
			this.RFC.FillWeight = 1f;
			this.RFC.HeaderText = "RFC";
			this.RFC.MinimumWidth = 6;
			this.RFC.Name = "RFC";
			this.RFC.ReadOnly = true;
			this.LicenciaSerial.DataPropertyName = "LicenciaSerial";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.LicenciaSerial.DefaultCellStyle = dataGridViewCellStyle3;
			this.LicenciaSerial.FillWeight = 1.5f;
			this.LicenciaSerial.HeaderText = "Licencia Serial";
			this.LicenciaSerial.MinimumWidth = 6;
			this.LicenciaSerial.Name = "LicenciaSerial";
			this.LicenciaSerial.ReadOnly = true;
			this.DiasExpiracion.DataPropertyName = "DiasExpiracion";
			this.DiasExpiracion.FillWeight = 0.6f;
			this.DiasExpiracion.HeaderText = "Días Expiración";
			this.DiasExpiracion.MinimumWidth = 6;
			this.DiasExpiracion.Name = "DiasExpiracion";
			this.DiasExpiracion.ReadOnly = true;
			this.entEmpresaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEmpresa);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.Window;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancelar.Image = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.Location = new System.Drawing.Point(469, 458);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(74, 64);
			this.btnCancelar.TabIndex = 91;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Visible = false;
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.Window;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.Location = new System.Drawing.Point(396, 458);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(132, 64);
			this.btnAgregar.TabIndex = 90;
			this.btnAgregar.Text = "Seleccionar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.lbMensaje.AutoSize = true;
			this.lbMensaje.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbMensaje.Location = new System.Drawing.Point(5, 12);
			this.lbMensaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbMensaje.Name = "lbMensaje";
			this.lbMensaje.Size = new System.Drawing.Size(159, 18);
			this.lbMensaje.TabIndex = 93;
			this.lbMensaje.Text = "SELECCIONE EMPRESA:";
			this.pnlGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlGeneral.Controls.Add(this.btnFiltraFacturas);
			this.pnlGeneral.Controls.Add(this.txtFacturaFiltro);
			this.pnlGeneral.Controls.Add(this.lbMensaje);
			this.pnlGeneral.Controls.Add(this.btnAgregar);
			this.pnlGeneral.Controls.Add(this.btnCancelar);
			this.pnlGeneral.Controls.Add(this.gvEmpresas);
			this.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlGeneral.Location = new System.Drawing.Point(0, 0);
			this.pnlGeneral.Margin = new System.Windows.Forms.Padding(2);
			this.pnlGeneral.Name = "pnlGeneral";
			this.pnlGeneral.Size = new System.Drawing.Size(907, 532);
			this.pnlGeneral.TabIndex = 94;
			this.pnlGeneral.Paint += new System.Windows.Forms.PaintEventHandler(pnlGeneral_Paint);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(486, 6);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(39, 28);
			this.btnFiltraFacturas.TabIndex = 95;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.txtFacturaFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtFacturaFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFacturaFiltro.Location = new System.Drawing.Point(168, 5);
			this.txtFacturaFiltro.Margin = new System.Windows.Forms.Padding(2);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(313, 28);
			this.txtFacturaFiltro.TabIndex = 94;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(txtFacturaFiltro_TextChanged);
			this.txtFacturaFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFacturaFiltro_KeyPress);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(907, 532);
			base.Controls.Add(this.pnlGeneral);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "SeleccionEmpresa";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Selección de Empresa";
			base.Activated += new System.EventHandler(SeleccionEmpresa_Activated);
			base.Load += new System.EventHandler(SeleccionEmpresa_Load);
			((System.ComponentModel.ISupportInitialize)this.gvEmpresas).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			this.pnlGeneral.ResumeLayout(false);
			this.pnlGeneral.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
