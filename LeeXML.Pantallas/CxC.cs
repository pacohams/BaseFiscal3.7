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
	public class CxC : FormBase
	{
		private IContainer components = null;

		private TabControl tcPedidosGrids;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private Button btnBuscaEmpresa;

		private Label label24;

		private ComboBox cmbEmpresas;

		private TabPage tabPage7;

		private GroupBox groupBox1;

		private Label label2;

		private TextBox txtNombreFiscalBalanza;

		private TextBox txtRFCBalanza;

		private Label label6;

		private TabControl tabControl1;

		private Panel pnlFiltros;

		private Button btnRefrescaReporteBalanza;

		private RadioButton rdoPorMesBalanzaComprobacion;

		private Panel panel3;

		private ComboBox cmbMesesHastaBalanza;

		private ComboBox cmbAñosHastaBalanza;

		private TabPage tabPage9;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private ReportViewer rvBalanzaComprobacion;

		private Panel panel4;

		private ComboBox cmbMesesDesdeBalanza;

		private ComboBox cmbAñosDesdeBalanza;

		private TabPage tabPage10;

		private ReportViewer rvMovimientosAuxiliares;

		private RadioButton rdoMovimientosAuxiliaresPorFactura;

		private RadioButton rdoMovimientosAuxiliaresPorFecha;

		private ReportViewer rvMovimientosAuxiliaresFactura;

		private Label label4;

		private ComboBox cmbClientesDesde;

		private Label label3;

		private Label label1;

		private ComboBox cmbClientesHasta;

		private BindingSource entClienteBindingSource;

		private List<EntEstadoDeCuenta> ListaCxC { get; set; }

		private List<EntEstadoDeCuenta> ListaCxCMovimientosPorFecha { get; set; }

		private List<EntEstadoDeCuenta> ListaCxCMovimientosPorFactura { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public CxC()
		{
			InitializeComponent();
		}

		public void CargaClientes(ComboBox cmbClientes, int EmpresaId)
		{
			List<EntCliente> lstClientes = (from P in new BusClientes().ObtieneClientes(EmpresaId)
				orderby P.Id
				select P).ToList();
			lstClientes.Insert(0, new EntCliente
			{
				Id = 0,
				Nombre = "-PRIMERO-"
			});
			lstClientes.Add(new EntCliente
			{
				Id = 999999,
				Nombre = "-ÚLTIMO-"
			});
			cmbClientes.DataSource = lstClientes;
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñosDesdeBalanza);
			cmbMesesDesdeBalanza.SelectedIndex = DateTime.Today.Month - 1;
			CargaAñosCmb(cmbAñosHastaBalanza);
			cmbMesesHastaBalanza.SelectedIndex = DateTime.Today.Month - 1;
			if (Program.EmpresaSeleccionada.Id > 0)
			{
				CargaClientes(cmbClientesDesde, Program.EmpresaSeleccionada.Id);
				cmbClientesDesde.SelectedIndex = 0;
				CargaClientes(cmbClientesHasta, Program.EmpresaSeleccionada.Id);
				cmbClientesHasta.SelectedIndex = cmbClientesHasta.Items.Count - 1;
				cmbAñosDesdeBalanza.SelectedIndex = cmbAñosDesdeBalanza.FindStringExact(DateTime.Today.Year.ToString());
				cmbAñosHastaBalanza.SelectedIndex = cmbAñosHastaBalanza.FindStringExact(DateTime.Today.Year.ToString());
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
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				InicializaPantalla();
				CargaDatosEmpresa(txtNombreFiscalBalanza, txtRFCBalanza);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			rvBalanzaComprobacion.RefreshReport();
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					CargaDatosEmpresa(txtNombreFiscalBalanza, txtRFCBalanza);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CargaCxC(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			ListaCxC = new BusFacturas().ObtieneCxCPorClientes(Empresa, FechaDesde, FechaHasta, ClienteDesdeId, ClienteHastaId);
			ListaCxC = ListaCxC.Where((EntEstadoDeCuenta P) => P.SubTotal0 > 0m || P.SubTotal > 0m || P.Total > 0m || P.Descuento > 0m).ToList();
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(FechaHasta.Month, FechaHasta.Year).ToString("dd/MMM/yyyy").ToUpper());
			rvBalanzaComprobacion.LocalReport.SetParameters(parmEmpresa);
			rvBalanzaComprobacion.LocalReport.SetParameters(parmFecha);
			EntEstadoDeCuentaBindingSource.DataSource = ListaCxC;
			rvBalanzaComprobacion.LocalReport.DataSources.Clear();
			rvBalanzaComprobacion.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaCxC));
			rvBalanzaComprobacion.RefreshReport();
		}

		private void CargaCxCMovimientos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			ListaCxCMovimientosPorFecha = new BusFacturas().ObtieneCxCMovimientosPorClientes(Empresa, FechaDesde, FechaHasta, ClienteDesdeId, ClienteHastaId);
			ListaCxCMovimientosPorFecha = ListaCxCMovimientosPorFecha.Where((EntEstadoDeCuenta P) => P.SubTotal0 > 0m || P.SubTotal > 0m || P.Total > 0m || P.Descuento > 0m).ToList();
			decimal saldoFinal = default(decimal);
			if (ListaCxCMovimientosPorFecha.Count > 0)
			{
				saldoFinal = ListaCxCMovimientosPorFecha.Last().Deposito;
			}
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(FechaHasta.Month, FechaHasta.Year).ToString("dd/MMM/yyyy").ToUpper());
			ReportParameter parmSaldoFinal = new ReportParameter("parmSaldoFinal", saldoFinal.ToString("0,0.00"));
			rvMovimientosAuxiliares.LocalReport.SetParameters(parmEmpresa);
			rvMovimientosAuxiliares.LocalReport.SetParameters(parmFecha);
			rvMovimientosAuxiliares.LocalReport.SetParameters(parmSaldoFinal);
			EntEstadoDeCuentaBindingSource.DataSource = ListaCxCMovimientosPorFecha;
			rvMovimientosAuxiliares.LocalReport.DataSources.Clear();
			rvMovimientosAuxiliares.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaCxCMovimientosPorFecha));
			rvMovimientosAuxiliares.RefreshReport();
			ListaCxCMovimientosPorFactura = new BusFacturas().ObtieneCxCMovimientosPorClientesPorFactura(Empresa, FechaDesde, FechaHasta, ClienteDesdeId, ClienteHastaId);
			ListaCxCMovimientosPorFactura = ListaCxCMovimientosPorFactura.Where((EntEstadoDeCuenta P) => P.SubTotal0 > 0m || P.SubTotal > 0m || P.Total > 0m || P.Descuento > 0m).ToList();
			rvMovimientosAuxiliaresFactura.LocalReport.SetParameters(parmEmpresa);
			rvMovimientosAuxiliaresFactura.LocalReport.SetParameters(parmFecha);
			rvMovimientosAuxiliaresFactura.LocalReport.SetParameters(parmSaldoFinal);
			rvMovimientosAuxiliaresFactura.LocalReport.DataSources.Clear();
			rvMovimientosAuxiliaresFactura.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaCxCMovimientosPorFactura));
			rvMovimientosAuxiliaresFactura.RefreshReport();
		}

		private void btnRefrescaReporteBalanza_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (tabControl1.SelectedIndex == 0)
				{
					CargaCxC(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesDesdeBalanza, cmbAñosDesdeBalanza), FechaHastaFromComboBoxs(cmbMesesHastaBalanza, cmbAñosHastaBalanza), ConvierteTextoAInteger(cmbClientesDesde.Text), ConvierteTextoAInteger(cmbClientesHasta.Text));
				}
				else
				{
					CargaCxCMovimientos(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesDesdeBalanza, cmbAñosDesdeBalanza), FechaHastaFromComboBoxs(cmbMesesHastaBalanza, cmbAñosHastaBalanza), ConvierteTextoAInteger(cmbClientesDesde.Text), ConvierteTextoAInteger(cmbClientesHasta.Text));
				}
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

		private void rdoMovimientosAuxiliaresPorFecha_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (rdoMovimientosAuxiliaresPorFecha.Checked)
				{
					rvMovimientosAuxiliares.BringToFront();
					rvMovimientosAuxiliaresFactura.SendToBack();
				}
				else
				{
					rvMovimientosAuxiliares.SendToBack();
					rvMovimientosAuxiliaresFactura.BringToFront();
				}
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.CxC));
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtNombreFiscalBalanza = new System.Windows.Forms.TextBox();
			this.txtRFCBalanza = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.rvBalanzaComprobacion = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.rdoMovimientosAuxiliaresPorFactura = new System.Windows.Forms.RadioButton();
			this.rdoMovimientosAuxiliaresPorFecha = new System.Windows.Forms.RadioButton();
			this.rvMovimientosAuxiliares = new Microsoft.Reporting.WinForms.ReportViewer();
			this.rvMovimientosAuxiliaresFactura = new Microsoft.Reporting.WinForms.ReportViewer();
			this.pnlFiltros = new System.Windows.Forms.Panel();
			this.cmbClientesHasta = new System.Windows.Forms.ComboBox();
			this.entClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.cmbClientesDesde = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnRefrescaReporteBalanza = new System.Windows.Forms.Button();
			this.rdoPorMesBalanzaComprobacion = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cmbMesesHastaBalanza = new System.Windows.Forms.ComboBox();
			this.cmbAñosHastaBalanza = new System.Windows.Forms.ComboBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.cmbMesesDesdeBalanza = new System.Windows.Forms.ComboBox();
			this.cmbAñosDesdeBalanza = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage9.SuspendLayout();
			this.tabPage10.SuspendLayout();
			this.pnlFiltros.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entClienteBindingSource).BeginInit();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			base.SuspendLayout();
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage7);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(13, 23);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1369, 569);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage7.Controls.Add(this.groupBox1);
			this.tabPage7.Controls.Add(this.tabControl1);
			this.tabPage7.Controls.Add(this.pnlFiltros);
			this.tabPage7.Location = new System.Drawing.Point(4, 27);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(1361, 538);
			this.tabPage7.TabIndex = 1;
			this.tabPage7.Text = "Balanza de Comprobación/Movimientos Auxiliares";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtNombreFiscalBalanza);
			this.groupBox1.Controls.Add(this.txtRFCBalanza);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new System.Drawing.Point(4, 7);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(506, 85);
			this.groupBox1.TabIndex = 140;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos Empresa Emisora";
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(17, 24);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(122, 23);
			this.label2.TabIndex = 102;
			this.label2.Text = "Nombre Fiscal:";
			this.txtNombreFiscalBalanza.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscalBalanza.Location = new System.Drawing.Point(152, 24);
			this.txtNombreFiscalBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.txtNombreFiscalBalanza.Name = "txtNombreFiscalBalanza";
			this.txtNombreFiscalBalanza.ReadOnly = true;
			this.txtNombreFiscalBalanza.Size = new System.Drawing.Size(346, 23);
			this.txtNombreFiscalBalanza.TabIndex = 104;
			this.txtRFCBalanza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFCBalanza.Location = new System.Drawing.Point(152, 53);
			this.txtRFCBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.txtRFCBalanza.Name = "txtRFCBalanza";
			this.txtRFCBalanza.ReadOnly = true;
			this.txtRFCBalanza.Size = new System.Drawing.Size(220, 26);
			this.txtRFCBalanza.TabIndex = 106;
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.White;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(88, 54);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 23);
			this.label6.TabIndex = 105;
			this.label6.Text = "R.F.C:";
			this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage10);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl1.Location = new System.Drawing.Point(518, 7);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(839, 527);
			this.tabControl1.TabIndex = 139;
			this.tabPage9.Controls.Add(this.rvBalanzaComprobacion);
			this.tabPage9.Location = new System.Drawing.Point(4, 27);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage9.Size = new System.Drawing.Size(831, 496);
			this.tabPage9.TabIndex = 0;
			this.tabPage9.Text = "Balanza de Comprobación";
			this.tabPage9.UseVisualStyleBackColor = true;
			this.rvBalanzaComprobacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			reportDataSource3.Name = "dsBancos";
			reportDataSource3.Value = this.EntEstadoDeCuentaBindingSource;
			this.rvBalanzaComprobacion.LocalReport.DataSources.Add(reportDataSource3);
			this.rvBalanzaComprobacion.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptBalanzaComprobacion.rdlc";
			this.rvBalanzaComprobacion.Location = new System.Drawing.Point(0, 0);
			this.rvBalanzaComprobacion.Name = "rvBalanzaComprobacion";
			this.rvBalanzaComprobacion.ServerReport.BearerToken = null;
			this.rvBalanzaComprobacion.Size = new System.Drawing.Size(831, 496);
			this.rvBalanzaComprobacion.TabIndex = 0;
			this.rvBalanzaComprobacion.ZoomPercent = 125;
			this.tabPage10.Controls.Add(this.rdoMovimientosAuxiliaresPorFactura);
			this.tabPage10.Controls.Add(this.rdoMovimientosAuxiliaresPorFecha);
			this.tabPage10.Controls.Add(this.rvMovimientosAuxiliares);
			this.tabPage10.Controls.Add(this.rvMovimientosAuxiliaresFactura);
			this.tabPage10.Location = new System.Drawing.Point(4, 27);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage10.Size = new System.Drawing.Size(831, 496);
			this.tabPage10.TabIndex = 1;
			this.tabPage10.Text = "Movimientos Auxiliares";
			this.tabPage10.UseVisualStyleBackColor = true;
			this.rdoMovimientosAuxiliaresPorFactura.AutoSize = true;
			this.rdoMovimientosAuxiliaresPorFactura.Location = new System.Drawing.Point(167, 5);
			this.rdoMovimientosAuxiliaresPorFactura.Margin = new System.Windows.Forms.Padding(4);
			this.rdoMovimientosAuxiliaresPorFactura.Name = "rdoMovimientosAuxiliaresPorFactura";
			this.rdoMovimientosAuxiliaresPorFactura.Size = new System.Drawing.Size(99, 22);
			this.rdoMovimientosAuxiliaresPorFactura.TabIndex = 46;
			this.rdoMovimientosAuxiliaresPorFactura.Text = "Por Factura";
			this.rdoMovimientosAuxiliaresPorFactura.UseVisualStyleBackColor = true;
			this.rdoMovimientosAuxiliaresPorFecha.AutoSize = true;
			this.rdoMovimientosAuxiliaresPorFecha.Checked = true;
			this.rdoMovimientosAuxiliaresPorFecha.Location = new System.Drawing.Point(6, 5);
			this.rdoMovimientosAuxiliaresPorFecha.Margin = new System.Windows.Forms.Padding(4);
			this.rdoMovimientosAuxiliaresPorFecha.Name = "rdoMovimientosAuxiliaresPorFecha";
			this.rdoMovimientosAuxiliaresPorFecha.Size = new System.Drawing.Size(89, 22);
			this.rdoMovimientosAuxiliaresPorFecha.TabIndex = 45;
			this.rdoMovimientosAuxiliaresPorFecha.TabStop = true;
			this.rdoMovimientosAuxiliaresPorFecha.Text = "Por Fecha";
			this.rdoMovimientosAuxiliaresPorFecha.UseVisualStyleBackColor = true;
			this.rdoMovimientosAuxiliaresPorFecha.CheckedChanged += new System.EventHandler(rdoMovimientosAuxiliaresPorFecha_CheckedChanged);
			this.rvMovimientosAuxiliares.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			reportDataSource4.Name = "dsBancos";
			reportDataSource4.Value = this.EntEstadoDeCuentaBindingSource;
			this.rvMovimientosAuxiliares.LocalReport.DataSources.Add(reportDataSource4);
			this.rvMovimientosAuxiliares.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptMovimientosAuxiliarCXC.rdlc";
			this.rvMovimientosAuxiliares.Location = new System.Drawing.Point(4, 34);
			this.rvMovimientosAuxiliares.Name = "rvMovimientosAuxiliares";
			this.rvMovimientosAuxiliares.ServerReport.BearerToken = null;
			this.rvMovimientosAuxiliares.Size = new System.Drawing.Size(824, 458);
			this.rvMovimientosAuxiliares.TabIndex = 1;
			this.rvMovimientosAuxiliares.ZoomPercent = 145;
			this.rvMovimientosAuxiliaresFactura.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvMovimientosAuxiliaresFactura.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptMovimientosAuxiliarCXCFacturas.rdlc";
			this.rvMovimientosAuxiliaresFactura.Location = new System.Drawing.Point(4, 34);
			this.rvMovimientosAuxiliaresFactura.Name = "rvMovimientosAuxiliaresFactura";
			this.rvMovimientosAuxiliaresFactura.ServerReport.BearerToken = null;
			this.rvMovimientosAuxiliaresFactura.Size = new System.Drawing.Size(824, 459);
			this.rvMovimientosAuxiliaresFactura.TabIndex = 47;
			this.rvMovimientosAuxiliaresFactura.ZoomPercent = 145;
			this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltros.Controls.Add(this.cmbClientesHasta);
			this.pnlFiltros.Controls.Add(this.label4);
			this.pnlFiltros.Controls.Add(this.cmbClientesDesde);
			this.pnlFiltros.Controls.Add(this.label3);
			this.pnlFiltros.Controls.Add(this.label1);
			this.pnlFiltros.Controls.Add(this.btnRefrescaReporteBalanza);
			this.pnlFiltros.Controls.Add(this.rdoPorMesBalanzaComprobacion);
			this.pnlFiltros.Controls.Add(this.panel3);
			this.pnlFiltros.Controls.Add(this.panel4);
			this.pnlFiltros.Location = new System.Drawing.Point(4, 105);
			this.pnlFiltros.Margin = new System.Windows.Forms.Padding(4);
			this.pnlFiltros.Name = "pnlFiltros";
			this.pnlFiltros.Size = new System.Drawing.Size(506, 252);
			this.pnlFiltros.TabIndex = 138;
			this.cmbClientesHasta.DataSource = this.entClienteBindingSource;
			this.cmbClientesHasta.DisplayMember = "Id";
			this.cmbClientesHasta.FormattingEnabled = true;
			this.cmbClientesHasta.Location = new System.Drawing.Point(380, 118);
			this.cmbClientesHasta.Name = "cmbClientesHasta";
			this.cmbClientesHasta.Size = new System.Drawing.Size(113, 26);
			this.cmbClientesHasta.TabIndex = 139;
			this.cmbClientesHasta.ValueMember = "Id";
			this.entClienteBindingSource.DataSource = typeof(LeeXMLEntidades.EntCliente);
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(330, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 18);
			this.label4.TabIndex = 138;
			this.label4.Text = "Hasta:";
			this.cmbClientesDesde.DataSource = this.entClienteBindingSource;
			this.cmbClientesDesde.DisplayMember = "Id";
			this.cmbClientesDesde.FormattingEnabled = true;
			this.cmbClientesDesde.Location = new System.Drawing.Point(184, 118);
			this.cmbClientesDesde.Name = "cmbClientesDesde";
			this.cmbClientesDesde.Size = new System.Drawing.Size(113, 26);
			this.cmbClientesDesde.TabIndex = 136;
			this.cmbClientesDesde.ValueMember = "Id";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(152, 123);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(28, 18);
			this.label3.TabIndex = 135;
			this.label3.Text = "De:";
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(88, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 18);
			this.label1.TabIndex = 134;
			this.label1.Text = "Clientes:";
			this.btnRefrescaReporteBalanza.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescaReporteBalanza.BackColor = System.Drawing.Color.White;
			this.btnRefrescaReporteBalanza.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescaReporteBalanza.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescaReporteBalanza.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescaReporteBalanza.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescaReporteBalanza.Location = new System.Drawing.Point(392, 162);
			this.btnRefrescaReporteBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefrescaReporteBalanza.Name = "btnRefrescaReporteBalanza";
			this.btnRefrescaReporteBalanza.Size = new System.Drawing.Size(100, 84);
			this.btnRefrescaReporteBalanza.TabIndex = 132;
			this.btnRefrescaReporteBalanza.Text = "Refrescar";
			this.btnRefrescaReporteBalanza.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescaReporteBalanza.UseVisualStyleBackColor = false;
			this.btnRefrescaReporteBalanza.Click += new System.EventHandler(btnRefrescaReporteBalanza_Click);
			this.rdoPorMesBalanzaComprobacion.AutoSize = true;
			this.rdoPorMesBalanzaComprobacion.Checked = true;
			this.rdoPorMesBalanzaComprobacion.Location = new System.Drawing.Point(82, 13);
			this.rdoPorMesBalanzaComprobacion.Margin = new System.Windows.Forms.Padding(4);
			this.rdoPorMesBalanzaComprobacion.Name = "rdoPorMesBalanzaComprobacion";
			this.rdoPorMesBalanzaComprobacion.Size = new System.Drawing.Size(80, 22);
			this.rdoPorMesBalanzaComprobacion.TabIndex = 44;
			this.rdoPorMesBalanzaComprobacion.TabStop = true;
			this.rdoPorMesBalanzaComprobacion.Text = "Por Mes";
			this.rdoPorMesBalanzaComprobacion.UseVisualStyleBackColor = true;
			this.panel3.Controls.Add(this.cmbMesesHastaBalanza);
			this.panel3.Controls.Add(this.cmbAñosHastaBalanza);
			this.panel3.Location = new System.Drawing.Point(177, 51);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(324, 42);
			this.panel3.TabIndex = 41;
			this.cmbMesesHastaBalanza.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cmbMesesHastaBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesHastaBalanza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesHastaBalanza.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesHastaBalanza.ForeColor = System.Drawing.Color.Black;
			this.cmbMesesHastaBalanza.FormattingEnabled = true;
			this.cmbMesesHastaBalanza.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesHastaBalanza.Location = new System.Drawing.Point(7, 9);
			this.cmbMesesHastaBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesHastaBalanza.Name = "cmbMesesHastaBalanza";
			this.cmbMesesHastaBalanza.Size = new System.Drawing.Size(167, 30);
			this.cmbMesesHastaBalanza.TabIndex = 19;
			this.cmbAñosHastaBalanza.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cmbAñosHastaBalanza.DisplayMember = "Descripcion";
			this.cmbAñosHastaBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñosHastaBalanza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñosHastaBalanza.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñosHastaBalanza.ForeColor = System.Drawing.Color.Black;
			this.cmbAñosHastaBalanza.FormattingEnabled = true;
			this.cmbAñosHastaBalanza.Location = new System.Drawing.Point(215, 10);
			this.cmbAñosHastaBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.cmbAñosHastaBalanza.Name = "cmbAñosHastaBalanza";
			this.cmbAñosHastaBalanza.Size = new System.Drawing.Size(101, 30);
			this.cmbAñosHastaBalanza.TabIndex = 20;
			this.cmbAñosHastaBalanza.ValueMember = "Descripcion";
			this.panel4.Controls.Add(this.cmbMesesDesdeBalanza);
			this.panel4.Controls.Add(this.cmbAñosDesdeBalanza);
			this.panel4.Location = new System.Drawing.Point(177, 5);
			this.panel4.Margin = new System.Windows.Forms.Padding(4);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(324, 42);
			this.panel4.TabIndex = 133;
			this.cmbMesesDesdeBalanza.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cmbMesesDesdeBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesDesdeBalanza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesDesdeBalanza.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesDesdeBalanza.ForeColor = System.Drawing.Color.Black;
			this.cmbMesesDesdeBalanza.FormattingEnabled = true;
			this.cmbMesesDesdeBalanza.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesDesdeBalanza.Location = new System.Drawing.Point(7, 9);
			this.cmbMesesDesdeBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesDesdeBalanza.Name = "cmbMesesDesdeBalanza";
			this.cmbMesesDesdeBalanza.Size = new System.Drawing.Size(167, 30);
			this.cmbMesesDesdeBalanza.TabIndex = 19;
			this.cmbAñosDesdeBalanza.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.cmbAñosDesdeBalanza.DisplayMember = "Descripcion";
			this.cmbAñosDesdeBalanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñosDesdeBalanza.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñosDesdeBalanza.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñosDesdeBalanza.ForeColor = System.Drawing.Color.Black;
			this.cmbAñosDesdeBalanza.FormattingEnabled = true;
			this.cmbAñosDesdeBalanza.Location = new System.Drawing.Point(215, 10);
			this.cmbAñosDesdeBalanza.Margin = new System.Windows.Forms.Padding(4);
			this.cmbAñosDesdeBalanza.Name = "cmbAñosDesdeBalanza";
			this.cmbAñosDesdeBalanza.Size = new System.Drawing.Size(101, 30);
			this.cmbAñosDesdeBalanza.TabIndex = 20;
			this.cmbAñosDesdeBalanza.ValueMember = "Descripcion";
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(459, 14);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(79, 22);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(545, 12);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(455, 24);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(1005, 6);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(52, 34);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1395, 605);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "CxC";
			this.Text = "CxC";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage9.ResumeLayout(false);
			this.tabPage10.ResumeLayout(false);
			this.tabPage10.PerformLayout();
			this.pnlFiltros.ResumeLayout(false);
			this.pnlFiltros.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entClienteBindingSource).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
