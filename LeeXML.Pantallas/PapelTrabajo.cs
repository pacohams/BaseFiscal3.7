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
	public class PapelTrabajo : FormBase
	{
		private IContainer components = null;

		private DataGridView gvPapelDeTrabajo;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private Label label3;

		private TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private FlowLayoutPanel flowLayoutPanel1;

		private TabControl tcReportesIngresos;

		private TabPage tabPage2;

		private FlowLayoutPanel flpTotalesTodos;

		private ToolStrip toolStrip1;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel1;

		private Panel panel1;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private ToolStripTextBox tstxtIVA;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImporte;

		private Button btnRefrescar;

		private Button btnBuscaEmpresa;

		private Label label24;

		private ComboBox cmbEmpresas;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotal;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNum;

		private ToolStripSeparator toolStripSeparator4;

		private GroupBox gbDatosGenerales;

		private Label label4;

		private TextBox txtNombreFiscal;

		private TextBox txtRFC;

		private Label label5;

		private TabPage tabPage3;

		private ReportViewer rvPapelDeTrabajo;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private TabPage tabPage4;

		private GroupBox gbDatosEmpresa;

		private Label label1;

		private TextBox txtNombreFiscal2;

		private TextBox txtRFC2;

		private Label label2;

		private TabControl tabControl1;

		private TabPage tabPage5;

		private FlowLayoutPanel flowLayoutPanel2;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox toolStripTextBox1;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox toolStripTextBox2;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tsTxtImporte2;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tsTxtIVA2;

		private DataGridView gvPapelDeTrabajo2;

		private FlowLayoutPanel flowLayoutPanel3;

		private TabPage tabPage6;

		private Panel pnlFiltros;

		private Button btnRefrescar2;

		private RadioButton radioButton1;

		private Panel panel3;

		private ComboBox cmbMesesComprobantes2;

		private ComboBox cmbAñoComprobantes2;

		private Button btnMarcarVigente;

		private ReportViewer rvPapelDeTrabajo2;

		private DataGridViewTextBoxColumn Descripcion;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn Pago;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantes2 { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public PapelTrabajo()
		{
			InitializeComponent();
		}

		private void CargaPapelDeTrabajo(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes = new BusFacturas().ObtieneEstadosDeCuentaPT(Empresa, FechaDesde, FechaHasta);
			List<EntFactura> lstFiltro = ListaComprobantes;
			gvPapelDeTrabajo.DataSource = lstFiltro;
			gvPapelDeTrabajo.Refresh();
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvPapelDeTrabajo.LocalReport.SetParameters(parmEmpresa);
			rvPapelDeTrabajo.LocalReport.SetParameters(parmFecha);
			entFacturaBindingSource.DataSource = lstFiltro;
			rvPapelDeTrabajo.LocalReport.DataSources.Clear();
			rvPapelDeTrabajo.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvPapelDeTrabajo.RefreshReport();
		}

		private void CargaPapelDeTrabajo2(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes2 = new BusFacturas().ObtieneEstadosDeCuentaPT2(Empresa, FechaDesde, FechaHasta);
			List<EntFactura> lstFiltro = ListaComprobantes2;
			gvPapelDeTrabajo2.DataSource = lstFiltro;
			gvPapelDeTrabajo2.Refresh();
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvPapelDeTrabajo2.LocalReport.SetParameters(parmEmpresa);
			rvPapelDeTrabajo2.LocalReport.SetParameters(parmFecha);
			entFacturaBindingSource.DataSource = lstFiltro;
			rvPapelDeTrabajo2.LocalReport.DataSources.Clear();
			rvPapelDeTrabajo2.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvPapelDeTrabajo2.RefreshReport();
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñoComprobantes);
			cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
			CargaAñosCmb(cmbAñoComprobantes2);
			cmbMesesComprobantes2.SelectedIndex = DateTime.Today.Month - 1;
			cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				base.UsuarioLogin = Program.UsuarioSeleccionado;
				CargaEmpresas(cmbEmpresas, Program.UsuarioSeleccionado.CompañiaId);
				if (Program.EmpresaSeleccionada == null)
				{
					Program.EmpresaSeleccionada = SeleccionaEmpresa();
				}
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				InicializaPantalla();
				CargaDatosEmpresa(txtNombreFiscal, txtRFC);
				CargaDatosEmpresa(txtNombreFiscal2, txtRFC2);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		public void VerificaCFDIsinRelacionar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstFiltro = new BusFacturas().ObtieneComprobantesFiscalesSinRelacionar(Empresa, FechaDesde, FechaHasta);
			int sinRelacionar = lstFiltro.Where((EntFactura P) => P.TipoRelacionId <= 0 || (P.TipoRelacionId == 1 && P.Descuento > 0m)).ToList().Count;
			if (sinRelacionar > 0)
			{
				MuestraMensajeAdvertencia($"Se encontraron {sinRelacionar.ToString()} registro(s) de CFDI\u00b4s tipo PUE/CP sin relacionar a Depósito", "ADVERTENCIA");
			}
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				VerificaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				CargaPapelDeTrabajo(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnMarcarCancelada_Click(object sender, EventArgs e)
		{
			try
			{
				if (MuestraMensajeYesNo("¿Desea marcar como Cancelado el Comprobante Fiscal seleccionado?") == DialogResult.Yes)
				{
					EntFactura facSeleccionada = ObtieneFacturaFromGV(gvPapelDeTrabajo);
					new BusFacturas().ActualizaEstatusComprobanteFiscal(facSeleccionada.Id, 2);
					MuestraMensaje("¡Comprobante marcado como CANCELADO!");
					btnRefrescar.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnMarcarVigente_Click(object sender, EventArgs e)
		{
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					CargaDatosEmpresa(txtNombreFiscal, txtRFC);
					CargaDatosEmpresa(txtNombreFiscal2, txtRFC2);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnMarcarVigente_Click_1(object sender, EventArgs e)
		{
			try
			{
				AgregaImporteDeclarado vImpDep = new AgregaImporteDeclarado();
				if (vImpDep.ShowDialog() == DialogResult.OK)
				{
					tsTxtImporte2.Text = FormatoMoney(vImpDep.ImporteDecimal);
					tsTxtIVA2.Text = FormatoMoney(vImpDep.IVADecimal);
					new BusFacturas().AgregaImporteDeclarado(base.EmpresaSeleccionada.Id, vImpDep.ImporteDecimal, vImpDep.IVADecimal, FechaDesdeFromComboBoxs(cmbMesesComprobantes2, cmbAñoComprobantes2), base.UsuarioLogin.Id);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnRefrescar2_Click(object sender, EventArgs e)
		{
			try
			{
				CargaPapelDeTrabajo2(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes2, cmbAñoComprobantes2), FechaHastaFromComboBoxs(cmbMesesComprobantes2, cmbAñoComprobantes2));
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.PapelTrabajo));
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvPapelDeTrabajo = new System.Windows.Forms.DataGridView();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNum = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIVA = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporte = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.rvPapelDeTrabajo = new Microsoft.Reporting.WinForms.ReportViewer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.gbDatosEmpresa = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtNombreFiscal2 = new System.Windows.Forms.TextBox();
			this.txtRFC2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tsTxtImporte2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tsTxtIVA2 = new System.Windows.Forms.ToolStripTextBox();
			this.gvPapelDeTrabajo2 = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnMarcarVigente = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.rvPapelDeTrabajo2 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.pnlFiltros = new System.Windows.Forms.Panel();
			this.btnRefrescar2 = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes2 = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes2 = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.gvPapelDeTrabajo).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gbDatosGenerales.SuspendLayout();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.gbDatosEmpresa.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvPapelDeTrabajo2).BeginInit();
			this.flowLayoutPanel3.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.pnlFiltros.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.gvPapelDeTrabajo.AllowUserToAddRows = false;
			dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvPapelDeTrabajo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
			this.gvPapelDeTrabajo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvPapelDeTrabajo.AutoGenerateColumns = false;
			this.gvPapelDeTrabajo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvPapelDeTrabajo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvPapelDeTrabajo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvPapelDeTrabajo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvPapelDeTrabajo.Columns.AddRange(this.Descripcion, this.subTotalDataGridViewTextBoxColumn, this.totalDataGridViewTextBoxColumn);
			this.gvPapelDeTrabajo.DataSource = this.entFacturaBindingSource;
			this.gvPapelDeTrabajo.Location = new System.Drawing.Point(9, 46);
			this.gvPapelDeTrabajo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvPapelDeTrabajo.Name = "gvPapelDeTrabajo";
			this.gvPapelDeTrabajo.ReadOnly = true;
			this.gvPapelDeTrabajo.RowHeadersVisible = false;
			this.gvPapelDeTrabajo.RowHeadersWidth = 51;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
			this.gvPapelDeTrabajo.RowsDefaultCellStyle = dataGridViewCellStyle17;
			this.gvPapelDeTrabajo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.gvPapelDeTrabajo.RowTemplate.Height = 30;
			this.gvPapelDeTrabajo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvPapelDeTrabajo.Size = new System.Drawing.Size(701, 566);
			this.gvPapelDeTrabajo.TabIndex = 14;
			this.Descripcion.DataPropertyName = "Descripcion";
			dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.Descripcion.DefaultCellStyle = dataGridViewCellStyle18;
			this.Descripcion.FillWeight = 6f;
			this.Descripcion.HeaderText = "Descripcion";
			this.Descripcion.MinimumWidth = 6;
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle19.Format = "c2";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
			this.subTotalDataGridViewTextBoxColumn.FillWeight = 2f;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle20.Format = "c2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
			this.totalDataGridViewTextBoxColumn.FillWeight = 2f;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Controls.Add(this.tabPage4);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 29);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1419, 752);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.gbDatosGenerales);
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1411, 717);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Papel de Trabajo 1.0";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(4, 10);
			this.gbDatosGenerales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosGenerales.Size = new System.Drawing.Size(560, 106);
			this.gbDatosGenerales.TabIndex = 137;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.txtNombreFiscal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(171, 30);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(380, 26);
			this.txtNombreFiscal.TabIndex = 104;
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(19, 30);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(141, 28);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(171, 66);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(247, 30);
			this.txtRFC.TabIndex = 106;
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(99, 68);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 28);
			this.label5.TabIndex = 105;
			this.label5.Text = "R.F.C:";
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Controls.Add(this.tabPage3);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(574, 10);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(827, 694);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage2.Controls.Add(this.flpTotalesTodos);
			this.tabPage2.Controls.Add(this.gvPapelDeTrabajo);
			this.tabPage2.Controls.Add(this.flowLayoutPanel1);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 31);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Size = new System.Drawing.Size(819, 659);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Reporte";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(-216, 614);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(1);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(927, 36);
			this.flpTotalesTodos.TabIndex = 135;
			this.flpTotalesTodos.Visible = false;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel3, this.tstxtNum, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotal, this.toolStripSeparator1, this.toolStripLabel1, this.tstxtIVA, this.toolStripSeparator2, this.toolStripLabel2,
				this.tstxtImporte
			});
			this.toolStrip1.Location = new System.Drawing.Point(0, 1);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(862, 33);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel3.Text = "Núm Comprobantes:";
			this.tstxtNum.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNum.Name = "tstxtNum";
			this.tstxtNum.ReadOnly = true;
			this.tstxtNum.Size = new System.Drawing.Size(67, 31);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel4.Text = "SubTotal:";
			this.tstxtSubtotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotal.Name = "tstxtSubtotal";
			this.tstxtSubtotal.ReadOnly = true;
			this.tstxtSubtotal.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel1.Text = "I.V.A:";
			this.tstxtIVA.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIVA.Name = "tstxtIVA";
			this.tstxtIVA.ReadOnly = true;
			this.tstxtIVA.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(80, 26);
			this.toolStripLabel2.Text = "Importe:";
			this.tstxtImporte.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporte.Name = "tstxtImporte";
			this.tstxtImporte.ReadOnly = true;
			this.tstxtImporte.Size = new System.Drawing.Size(108, 31);
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(706, 40);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(119, 300);
			this.flowLayoutPanel1.TabIndex = 134;
			this.tabPage3.Controls.Add(this.rvPapelDeTrabajo);
			this.tabPage3.Location = new System.Drawing.Point(4, 31);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage3.Size = new System.Drawing.Size(819, 659);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.Text = "Exporta";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.rvPapelDeTrabajo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			reportDataSource2.Name = "dsBancos";
			reportDataSource2.Value = this.EntEstadoDeCuentaBindingSource;
			this.rvPapelDeTrabajo.LocalReport.DataSources.Add(reportDataSource2);
			this.rvPapelDeTrabajo.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptPapelDeTrabajo.rdlc";
			this.rvPapelDeTrabajo.Location = new System.Drawing.Point(0, 0);
			this.rvPapelDeTrabajo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rvPapelDeTrabajo.Name = "rvPapelDeTrabajo";
			this.rvPapelDeTrabajo.ServerReport.BearerToken = null;
			this.rvPapelDeTrabajo.Size = new System.Drawing.Size(818, 646);
			this.rvPapelDeTrabajo.TabIndex = 1;
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Location = new System.Drawing.Point(99, 116);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(466, 190);
			this.panel1.TabIndex = 135;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(340, 76);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(112, 105);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(11, 25);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(84, 22);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(109, 8);
			this.pnlPorMesVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(348, 52);
			this.pnlPorMesVentas.TabIndex = 41;
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(8, 11);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(187, 33);
			this.cmbMesesComprobantes.TabIndex = 19;
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(228, 12);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(113, 33);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1583, 939);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 18);
			this.label3.TabIndex = 128;
			this.label3.Text = "Cantidad:";
			this.txtCantidadVentas.Enabled = false;
			this.txtCantidadVentas.Location = new System.Drawing.Point(1655, 932);
			this.txtCantidadVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCantidadVentas.Name = "txtCantidadVentas";
			this.txtCantidadVentas.Size = new System.Drawing.Size(80, 25);
			this.txtCantidadVentas.TabIndex = 127;
			this.tabPage4.Controls.Add(this.gbDatosEmpresa);
			this.tabPage4.Controls.Add(this.tabControl1);
			this.tabPage4.Controls.Add(this.pnlFiltros);
			this.tabPage4.Location = new System.Drawing.Point(4, 31);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage4.Size = new System.Drawing.Size(1411, 717);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Papel de Trabajo 2.0";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.gbDatosEmpresa.Controls.Add(this.label1);
			this.gbDatosEmpresa.Controls.Add(this.txtNombreFiscal2);
			this.gbDatosEmpresa.Controls.Add(this.txtRFC2);
			this.gbDatosEmpresa.Controls.Add(this.label2);
			this.gbDatosEmpresa.Location = new System.Drawing.Point(8, 10);
			this.gbDatosEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosEmpresa.Name = "gbDatosEmpresa";
			this.gbDatosEmpresa.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosEmpresa.Size = new System.Drawing.Size(495, 106);
			this.gbDatosEmpresa.TabIndex = 140;
			this.gbDatosEmpresa.TabStop = false;
			this.gbDatosEmpresa.Text = "Datos Empresa Emisora";
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(19, 30);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 28);
			this.label1.TabIndex = 102;
			this.label1.Text = "Nombre Fiscal:";
			this.txtNombreFiscal2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtNombreFiscal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal2.Location = new System.Drawing.Point(171, 28);
			this.txtNombreFiscal2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombreFiscal2.Name = "txtNombreFiscal2";
			this.txtNombreFiscal2.ReadOnly = true;
			this.txtNombreFiscal2.Size = new System.Drawing.Size(314, 26);
			this.txtNombreFiscal2.TabIndex = 104;
			this.txtRFC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC2.Location = new System.Drawing.Point(171, 68);
			this.txtRFC2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRFC2.Name = "txtRFC2";
			this.txtRFC2.ReadOnly = true;
			this.txtRFC2.Size = new System.Drawing.Size(247, 26);
			this.txtRFC2.TabIndex = 106;
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(99, 68);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 28);
			this.label2.TabIndex = 105;
			this.label2.Text = "R.F.C:";
			this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl1.Location = new System.Drawing.Point(507, 10);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(893, 696);
			this.tabControl1.TabIndex = 139;
			this.tabPage5.Controls.Add(this.flowLayoutPanel2);
			this.tabPage5.Controls.Add(this.gvPapelDeTrabajo2);
			this.tabPage5.Controls.Add(this.flowLayoutPanel3);
			this.tabPage5.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage5.Location = new System.Drawing.Point(4, 31);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage5.Size = new System.Drawing.Size(885, 661);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "Reporte";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(-148, 6);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(927, 36);
			this.flowLayoutPanel2.TabIndex = 135;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel5, this.toolStripTextBox1, this.toolStripSeparator3, this.toolStripLabel6, this.toolStripTextBox2, this.toolStripSeparator5, this.toolStripLabel8, this.tsTxtImporte2, this.toolStripSeparator6, this.toolStripLabel7,
				this.tsTxtIVA2
			});
			this.toolStrip2.Location = new System.Drawing.Point(522, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(403, 31);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel5.Text = "Núm Comprobantes:";
			this.toolStripLabel5.Visible = false;
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.ReadOnly = true;
			this.toolStripTextBox1.Size = new System.Drawing.Size(67, 31);
			this.toolStripTextBox1.Visible = false;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel6.Text = "SubTotal:";
			this.toolStripLabel6.Visible = false;
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(121, 31);
			this.toolStripTextBox2.Visible = false;
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(80, 26);
			this.toolStripLabel8.Text = "Importe:";
			this.tsTxtImporte2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tsTxtImporte2.Name = "tsTxtImporte2";
			this.tsTxtImporte2.ReadOnly = true;
			this.tsTxtImporte2.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tsTxtIVA2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tsTxtIVA2.Name = "tsTxtIVA2";
			this.tsTxtIVA2.ReadOnly = true;
			this.tsTxtIVA2.Size = new System.Drawing.Size(108, 31);
			this.gvPapelDeTrabajo2.AllowUserToAddRows = false;
			dataGridViewCellStyle21.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle21.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvPapelDeTrabajo2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
			this.gvPapelDeTrabajo2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvPapelDeTrabajo2.AutoGenerateColumns = false;
			this.gvPapelDeTrabajo2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvPapelDeTrabajo2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvPapelDeTrabajo2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gvPapelDeTrabajo2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
			this.gvPapelDeTrabajo2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvPapelDeTrabajo2.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.Pago, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3);
			this.gvPapelDeTrabajo2.DataSource = this.entFacturaBindingSource;
			this.gvPapelDeTrabajo2.Location = new System.Drawing.Point(9, 48);
			this.gvPapelDeTrabajo2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvPapelDeTrabajo2.Name = "gvPapelDeTrabajo2";
			this.gvPapelDeTrabajo2.ReadOnly = true;
			this.gvPapelDeTrabajo2.RowHeadersVisible = false;
			this.gvPapelDeTrabajo2.RowHeadersWidth = 51;
			dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle24.ForeColor = System.Drawing.Color.Black;
			this.gvPapelDeTrabajo2.RowsDefaultCellStyle = dataGridViewCellStyle24;
			this.gvPapelDeTrabajo2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.gvPapelDeTrabajo2.RowTemplate.Height = 30;
			this.gvPapelDeTrabajo2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvPapelDeTrabajo2.Size = new System.Drawing.Size(767, 569);
			this.gvPapelDeTrabajo2.TabIndex = 14;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
			dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewTextBoxColumn1.FillWeight = 6f;
			this.dataGridViewTextBoxColumn1.HeaderText = "";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.Pago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle26.NullValue = null;
			this.Pago.DefaultCellStyle = dataGridViewCellStyle26;
			this.Pago.FillWeight = 2f;
			this.Pago.HeaderText = "";
			this.Pago.MinimumWidth = 6;
			this.Pago.Name = "Pago";
			this.Pago.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Banco";
			dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle27.Format = "N2";
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle27;
			this.dataGridViewTextBoxColumn2.FillWeight = 2f;
			this.dataGridViewTextBoxColumn2.HeaderText = "";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "FormaPago";
			dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle28.Format = "N2";
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewTextBoxColumn3.FillWeight = 2f;
			this.dataGridViewTextBoxColumn3.HeaderText = "";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel3.Controls.Add(this.btnMarcarVigente);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(773, 40);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(119, 300);
			this.flowLayoutPanel3.TabIndex = 134;
			this.btnMarcarVigente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMarcarVigente.BackColor = System.Drawing.Color.White;
			this.btnMarcarVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnMarcarVigente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMarcarVigente.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnMarcarVigente.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnMarcarVigente.Location = new System.Drawing.Point(4, 5);
			this.btnMarcarVigente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnMarcarVigente.Name = "btnMarcarVigente";
			this.btnMarcarVigente.Size = new System.Drawing.Size(105, 105);
			this.btnMarcarVigente.TabIndex = 135;
			this.btnMarcarVigente.Text = "Agregar Importe Declarado ";
			this.btnMarcarVigente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMarcarVigente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMarcarVigente.UseVisualStyleBackColor = false;
			this.btnMarcarVigente.Click += new System.EventHandler(btnMarcarVigente_Click_1);
			this.tabPage6.Controls.Add(this.rvPapelDeTrabajo2);
			this.tabPage6.Location = new System.Drawing.Point(4, 31);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tabPage6.Size = new System.Drawing.Size(885, 661);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "Exporta";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.rvPapelDeTrabajo2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvPapelDeTrabajo2.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptPapelDeTrabajo2.rdlc";
			this.rvPapelDeTrabajo2.Location = new System.Drawing.Point(0, 0);
			this.rvPapelDeTrabajo2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rvPapelDeTrabajo2.Name = "rvPapelDeTrabajo2";
			this.rvPapelDeTrabajo2.ServerReport.BearerToken = null;
			this.rvPapelDeTrabajo2.Size = new System.Drawing.Size(881, 648);
			this.rvPapelDeTrabajo2.TabIndex = 2;
			this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltros.Controls.Add(this.btnRefrescar2);
			this.pnlFiltros.Controls.Add(this.radioButton1);
			this.pnlFiltros.Controls.Add(this.panel3);
			this.pnlFiltros.Location = new System.Drawing.Point(8, 118);
			this.pnlFiltros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlFiltros.Name = "pnlFiltros";
			this.pnlFiltros.Size = new System.Drawing.Size(495, 183);
			this.pnlFiltros.TabIndex = 138;
			this.btnRefrescar2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar2.BackColor = System.Drawing.Color.White;
			this.btnRefrescar2.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar2.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar2.Location = new System.Drawing.Point(372, 71);
			this.btnRefrescar2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar2.Name = "btnRefrescar2";
			this.btnRefrescar2.Size = new System.Drawing.Size(112, 105);
			this.btnRefrescar2.TabIndex = 132;
			this.btnRefrescar2.Text = "Refrescar";
			this.btnRefrescar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar2.UseVisualStyleBackColor = false;
			this.btnRefrescar2.Click += new System.EventHandler(btnRefrescar2_Click);
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(36, 18);
			this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(97, 26);
			this.radioButton1.TabIndex = 44;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Por Mes";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.panel3.Controls.Add(this.cmbMesesComprobantes2);
			this.panel3.Controls.Add(this.cmbAñoComprobantes2);
			this.panel3.Location = new System.Drawing.Point(135, 5);
			this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(353, 52);
			this.panel3.TabIndex = 41;
			this.cmbMesesComprobantes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes2.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes2.FormattingEnabled = true;
			this.cmbMesesComprobantes2.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesComprobantes2.Location = new System.Drawing.Point(8, 11);
			this.cmbMesesComprobantes2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbMesesComprobantes2.Name = "cmbMesesComprobantes2";
			this.cmbMesesComprobantes2.Size = new System.Drawing.Size(187, 33);
			this.cmbMesesComprobantes2.TabIndex = 19;
			this.cmbAñoComprobantes2.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes2.FormattingEnabled = true;
			this.cmbAñoComprobantes2.Location = new System.Drawing.Point(236, 12);
			this.cmbAñoComprobantes2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbAñoComprobantes2.Name = "cmbAñoComprobantes2";
			this.cmbAñoComprobantes2.Size = new System.Drawing.Size(113, 33);
			this.cmbAñoComprobantes2.TabIndex = 20;
			this.cmbAñoComprobantes2.ValueMember = "Descripcion";
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(378, 18);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(90, 25);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(475, 8);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(511, 37);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(991, 8);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(58, 42);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1448, 798);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "PapelTrabajo";
			this.Text = "Papel de Trabajo";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.gvPapelDeTrabajo).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.gbDatosEmpresa.ResumeLayout(false);
			this.gbDatosEmpresa.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvPapelDeTrabajo2).EndInit();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.pnlFiltros.ResumeLayout(false);
			this.pnlFiltros.PerformLayout();
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
