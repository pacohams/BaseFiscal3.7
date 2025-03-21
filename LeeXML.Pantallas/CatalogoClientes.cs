using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Microsoft.Reporting.WinForms;

namespace LeeXML.Pantallas
{
	public class CatalogoClientes : FormBase
	{
		private IContainer components = null;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private Label label3;

		private TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private TabControl tcReportesIngresos;

		private Panel panel1;

		private Button btnRefrescar;

		private Button btnBuscaEmpresa;

		private Label label24;

		private ComboBox cmbEmpresas;

		private GroupBox gbDatosGenerales;

		private Label label4;

		private TextBox txtNombreFiscal;

		private TextBox txtRFC;

		private Label label5;

		private TabPage tabPage3;

		private ReportViewer rvCatalogoClientes;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private ComboBox cmbClientesHasta;

		private Label label1;

		private ComboBox cmbClientesDesde;

		private Label label2;

		private Label label6;

		private List<EntCliente> ListaClientes { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public CatalogoClientes()
		{
			InitializeComponent();
		}

		private void CargaCatalogoClientes(EntEmpresa Empresa, int ClienteDesdeId, int ClienteHastaId)
		{
			if (Empresa.Id > 0)
			{
				ListaClientes = (from P in new BusClientes().ObtieneClientes(Empresa.Id)
					where P.TipoPersonaId != 3 && P.Id >= ClienteDesdeId && P.Id <= ClienteHastaId
					select P).ToList();
				ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
				rvCatalogoClientes.LocalReport.SetParameters(parmEmpresa);
				entFacturaBindingSource.DataSource = ListaClientes;
				rvCatalogoClientes.LocalReport.DataSources.Clear();
				rvCatalogoClientes.LocalReport.DataSources.Add(new ReportDataSource("dsClientes", (IEnumerable)ListaClientes));
				rvCatalogoClientes.RefreshReport();
			}
		}

		private void InicializaPantalla()
		{
			if (Program.EmpresaSeleccionada.Id > 0)
			{
				new CxC().CargaClientes(cmbClientesDesde, Program.EmpresaSeleccionada.Id);
				cmbClientesDesde.SelectedIndex = 0;
				new CxC().CargaClientes(cmbClientesHasta, Program.EmpresaSeleccionada.Id);
				cmbClientesHasta.SelectedIndex = cmbClientesHasta.Items.Count - 1;
			}
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				CargaEmpresas(cmbEmpresas, Program.UsuarioSeleccionado.CompañiaId);
				if (Program.EmpresaSeleccionada == null)
				{
					Program.EmpresaSeleccionada = SeleccionaEmpresa();
				}
				else
				{
					cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				}
				InicializaPantalla();
				CargaDatosEmpresa(txtNombreFiscal, txtRFC);
				CargaCatalogoClientes(Program.EmpresaSeleccionada, ConvierteTextoAInteger(cmbClientesDesde.Text), ConvierteTextoAInteger(cmbClientesHasta.Text));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				CargaCatalogoClientes(Program.EmpresaSeleccionada, ConvierteTextoAInteger(cmbClientesDesde.Text), ConvierteTextoAInteger(cmbClientesHasta.Text));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					CargaDatosEmpresa(txtNombreFiscal, txtRFC);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.CatalogoClientes));
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.rvCatalogoClientes = new Microsoft.Reporting.WinForms.ReportViewer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbClientesHasta = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbClientesDesde = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gbDatosGenerales.SuspendLayout();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(13, 23);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1261, 602);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.gbDatosGenerales);
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1253, 571);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Clientes";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(533, 9);
			this.gbDatosGenerales.Margin = new System.Windows.Forms.Padding(4);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Padding = new System.Windows.Forms.Padding(4);
			this.gbDatosGenerales.Size = new System.Drawing.Size(712, 85);
			this.gbDatosGenerales.TabIndex = 137;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(17, 24);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 23);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(152, 21);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(453, 26);
			this.txtNombreFiscal.TabIndex = 104;
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(152, 53);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(220, 26);
			this.txtRFC.TabIndex = 106;
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(88, 54);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 23);
			this.label5.TabIndex = 105;
			this.label5.Text = "R.F.C:";
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage3);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(8, 116);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(1237, 447);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage3.Controls.Add(this.rvCatalogoClientes);
			this.tabPage3.Location = new System.Drawing.Point(4, 27);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1229, 416);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.Text = "Exporta Catálogo";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.rvCatalogoClientes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvCatalogoClientes.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptClientes.rdlc";
			this.rvCatalogoClientes.Location = new System.Drawing.Point(0, 0);
			this.rvCatalogoClientes.Name = "rvCatalogoClientes";
			this.rvCatalogoClientes.ServerReport.BearerToken = null;
			this.rvCatalogoClientes.Size = new System.Drawing.Size(1229, 416);
			this.rvCatalogoClientes.TabIndex = 1;
			this.panel1.Controls.Add(this.cmbClientesHasta);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cmbClientesDesde);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Location = new System.Drawing.Point(8, 4);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(523, 105);
			this.panel1.TabIndex = 135;
			this.cmbClientesHasta.DisplayMember = "Id";
			this.cmbClientesHasta.FormattingEnabled = true;
			this.cmbClientesHasta.Location = new System.Drawing.Point(278, 44);
			this.cmbClientesHasta.Name = "cmbClientesHasta";
			this.cmbClientesHasta.Size = new System.Drawing.Size(121, 24);
			this.cmbClientesHasta.TabIndex = 144;
			this.cmbClientesHasta.ValueMember = "Id";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(228, 49);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 16);
			this.label1.TabIndex = 143;
			this.label1.Text = "Hasta:";
			this.cmbClientesDesde.DisplayMember = "Id";
			this.cmbClientesDesde.FormattingEnabled = true;
			this.cmbClientesDesde.Location = new System.Drawing.Point(87, 44);
			this.cmbClientesDesde.Name = "cmbClientesDesde";
			this.cmbClientesDesde.Size = new System.Drawing.Size(121, 24);
			this.cmbClientesDesde.TabIndex = 142;
			this.cmbClientesDesde.ValueMember = "Id";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(55, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 16);
			this.label2.TabIndex = 141;
			this.label2.Text = "De:";
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(1, 28);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 16);
			this.label6.TabIndex = 140;
			this.label6.Text = "Clientes:";
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(415, 7);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(100, 84);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1407, 751);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 16);
			this.label3.TabIndex = 128;
			this.label3.Text = "Cantidad:";
			this.txtCantidadVentas.Enabled = false;
			this.txtCantidadVentas.Location = new System.Drawing.Point(1471, 746);
			this.txtCantidadVentas.Margin = new System.Windows.Forms.Padding(4);
			this.txtCantidadVentas.Name = "txtCantidadVentas";
			this.txtCantidadVentas.Size = new System.Drawing.Size(72, 22);
			this.txtCantidadVentas.TabIndex = 127;
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(336, 14);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(79, 22);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(422, 6);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(455, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(881, 6);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(52, 34);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1287, 638);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "CatalogoClientes";
			this.Text = "Catálogo de Clientes";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
