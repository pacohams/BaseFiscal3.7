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
	public class Observaciones : FormBase
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

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

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

		private ReportViewer rvObservaciones;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private TabPage tabPage2;

		private ReportViewer rvObservaciones2;

		private TabPage tabPage4;

		private ReportViewer rvObservaciones3;

		private TabPage tabPage5;

		private ReportViewer rvObservaciones4;

		private TabPage tabPage7;

		private ReportViewer rvObservaciones5;

		private List<EntFactura> ListaComprobantes1 { get; set; }

		private List<EntFactura> ListaComprobantes2 { get; set; }

		private List<EntFactura> ListaComprobantes3 { get; set; }

		private List<EntFactura> ListaComprobantes4 { get; set; }

		private List<EntFactura> ListaComprobantes5 { get; set; }

		private List<EntFactura> ListaComprobantesPENDIENTE { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public Observaciones()
		{
			InitializeComponent();
		}

		private void CargaObservacion1(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes1 = (from P in new BusFacturas().ObtieneEstadosDeCuentaDetallePorTipoComprobante(Empresa, FechaDesde, FechaHasta, 1)
				where P.MetodoPagoId == 2
				select P).ToList();
			List<EntFactura> lstFiltro = ListaComprobantes1;
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvObservaciones.LocalReport.SetParameters(parmEmpresa);
			rvObservaciones.LocalReport.SetParameters(parmFecha);
			rvObservaciones.LocalReport.DataSources.Clear();
			rvObservaciones.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvObservaciones.RefreshReport();
		}

		private void CargaObservacion2(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes2 = new BusFacturas().ObtieneComprobantesFiscales(Empresa, 3, FechaDesde, FechaHasta).ToList();
			List<EntFactura> lstFiltro = ListaComprobantes2;
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvObservaciones2.LocalReport.SetParameters(parmEmpresa);
			rvObservaciones2.LocalReport.SetParameters(parmFecha);
			rvObservaciones2.LocalReport.DataSources.Clear();
			rvObservaciones2.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvObservaciones2.RefreshReport();
		}

		private void CargaObservacion3(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes3 = (from P in new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1)
				where P.TipoComprobanteId == 1 && P.MetodoPagoId == 2 && P.FormaPagoId != 99
				select P).ToList();
			List<EntFactura> lstFiltro = ListaComprobantes3;
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvObservaciones3.LocalReport.SetParameters(parmEmpresa);
			rvObservaciones3.LocalReport.SetParameters(parmFecha);
			rvObservaciones3.LocalReport.DataSources.Clear();
			rvObservaciones3.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvObservaciones3.RefreshReport();
		}

		private void CargaObservacion4(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstCP = (from P in new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1)
				where P.TipoComprobanteId == 5
				select P).ToList();
			ListaComprobantes4 = new List<EntFactura>();
			foreach (EntFactura f in lstCP)
			{
				int mes = f.FechaPago.Month;
				DateTime fechaEmision = f.Fecha;
				DateTime fechaLimite = new DateTime(f.FechaPago.Year, mes, 5).AddMonths(1);
				if (fechaEmision > fechaLimite)
				{
					ListaComprobantes4.Add(f);
				}
			}
			List<EntFactura> lstFiltro = ListaComprobantes4;
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvObservaciones4.LocalReport.SetParameters(parmEmpresa);
			rvObservaciones4.LocalReport.SetParameters(parmFecha);
			rvObservaciones4.LocalReport.DataSources.Clear();
			rvObservaciones4.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvObservaciones4.RefreshReport();
		}

		private void CargaObservacion5(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes5 = new BusFacturas().ObtieneEstadosDeCuentaDetallePorTipoComprobante(Empresa, FechaDesde, FechaHasta, 6);
			List<EntFactura> lstFiltro = ListaComprobantes5;
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvObservaciones5.LocalReport.SetParameters(parmEmpresa);
			rvObservaciones5.LocalReport.SetParameters(parmFecha);
			rvObservaciones5.LocalReport.DataSources.Clear();
			rvObservaciones5.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvObservaciones5.RefreshReport();
		}

		private void CargaObservacionPENDIENTE(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstCFDIconRelacionAnticipo = (from P in new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1)
				where P.TipoComprobanteId == 1 && P.TipoRelacionId == 7
				select P).ToList();
			ListaComprobantesPENDIENTE = new List<EntFactura>();
			foreach (EntFactura f in lstCFDIconRelacionAnticipo)
			{
				string[] facturas = f.UUIDrelacionado.Split('|');
				string[] array = facturas;
				foreach (string s in array)
				{
					if (!string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lstFac = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
						EntFactura fac = new EntFactura();
						if (lstFac.Count > 0)
						{
							fac = lstFac[0];
						}
					}
				}
			}
			List<EntFactura> lstFiltro = ListaComprobantesPENDIENTE;
		}

		private void CargaObservacionPENDIENTE2(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstCP = (from P in new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1)
				where P.TipoComprobanteId == 5
				select P).ToList();
			ListaComprobantesPENDIENTE = new List<EntFactura>();
			foreach (EntFactura f in lstCP)
			{
				string[] facturas = f.UUIDrelacionado.Split('|');
				string[] array = facturas;
				foreach (string s in array)
				{
					if (string.IsNullOrWhiteSpace(s))
					{
						continue;
					}
					List<EntFactura> lstFac = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
					EntFactura fac = new EntFactura();
					if (lstFac.Count > 0)
					{
						fac = lstFac[0];
						if (fac.MetodoPagoId == 1)
						{
							ListaComprobantesPENDIENTE.Add(fac);
						}
					}
				}
			}
			List<EntFactura> lstFiltro = ListaComprobantesPENDIENTE;
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñoComprobantes);
			cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
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
				CargaObservacion1(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				CargaObservacion2(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				CargaObservacion3(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				CargaObservacion4(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				CargaObservacion5(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.Observaciones));
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
			this.rvObservaciones = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rvObservaciones2 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.rvObservaciones3 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.rvObservaciones4 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.rvObservaciones5 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
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
			this.tabPage2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
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
			this.tabPage1.Text = "Observaciones";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(4, 8);
			this.gbDatosGenerales.Margin = new System.Windows.Forms.Padding(4);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Padding = new System.Windows.Forms.Padding(4);
			this.gbDatosGenerales.Size = new System.Drawing.Size(316, 141);
			this.gbDatosGenerales.TabIndex = 137;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(9, 24);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 23);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(45, 50);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(263, 23);
			this.txtNombreFiscal.TabIndex = 104;
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(45, 110);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(171, 23);
			this.txtRFC.TabIndex = 106;
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(80, 83);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 23);
			this.label5.TabIndex = 105;
			this.label5.Text = "R.F.C:";
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage3);
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Controls.Add(this.tabPage4);
			this.tcReportesIngresos.Controls.Add(this.tabPage5);
			this.tcReportesIngresos.Controls.Add(this.tabPage7);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(323, 4);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(922, 567);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage3.Controls.Add(this.rvObservaciones);
			this.tabPage3.Location = new System.Drawing.Point(4, 27);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(914, 536);
			this.tabPage3.TabIndex = 1;
			this.tabPage3.Text = "1. CFDI PPD COBRADAS SIN COMPLEMENTO DE PAGO";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.rvObservaciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvObservaciones.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptObservacion1.rdlc";
			this.rvObservaciones.Location = new System.Drawing.Point(0, 0);
			this.rvObservaciones.Name = "rvObservaciones";
			this.rvObservaciones.ServerReport.BearerToken = null;
			this.rvObservaciones.Size = new System.Drawing.Size(914, 536);
			this.rvObservaciones.TabIndex = 1;
			this.rvObservaciones.ZoomPercent = 125;
			this.tabPage2.Controls.Add(this.rvObservaciones2);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(961, 424);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "2. CFDI PUE NO COBRADAS";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.rvObservaciones2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvObservaciones2.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptObservacion2.rdlc";
			this.rvObservaciones2.Location = new System.Drawing.Point(0, 0);
			this.rvObservaciones2.Name = "rvObservaciones2";
			this.rvObservaciones2.ServerReport.BearerToken = null;
			this.rvObservaciones2.Size = new System.Drawing.Size(961, 424);
			this.rvObservaciones2.TabIndex = 2;
			this.rvObservaciones2.ZoomPercent = 125;
			this.tabPage4.Controls.Add(this.rvObservaciones3);
			this.tabPage4.Location = new System.Drawing.Point(4, 27);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(961, 424);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "3. PPD CON FORMA DE PAGO DIFERENTE A 99 ";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.rvObservaciones3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvObservaciones3.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptObservacion3.rdlc";
			this.rvObservaciones3.Location = new System.Drawing.Point(0, 0);
			this.rvObservaciones3.Name = "rvObservaciones3";
			this.rvObservaciones3.ServerReport.BearerToken = null;
			this.rvObservaciones3.Size = new System.Drawing.Size(961, 424);
			this.rvObservaciones3.TabIndex = 3;
			this.rvObservaciones3.ZoomPercent = 125;
			this.tabPage5.Controls.Add(this.rvObservaciones4);
			this.tabPage5.Location = new System.Drawing.Point(4, 27);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(961, 424);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "4. COMPLEMENTOS DE PAGO ELABORADOS FUERA DEL PLAZO QUE ESTABLECE LA RMF";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.rvObservaciones4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvObservaciones4.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptObservacion4.rdlc";
			this.rvObservaciones4.Location = new System.Drawing.Point(0, 0);
			this.rvObservaciones4.Name = "rvObservaciones4";
			this.rvObservaciones4.ServerReport.BearerToken = null;
			this.rvObservaciones4.Size = new System.Drawing.Size(961, 424);
			this.rvObservaciones4.TabIndex = 4;
			this.rvObservaciones4.ZoomPercent = 125;
			this.tabPage7.Controls.Add(this.rvObservaciones5);
			this.tabPage7.Location = new System.Drawing.Point(4, 27);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage7.Size = new System.Drawing.Size(961, 424);
			this.tabPage7.TabIndex = 6;
			this.tabPage7.Text = "5. ANTICIPOS DE CLIENTES NO FACTURADOS";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.rvObservaciones5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvObservaciones5.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptObservacion5.rdlc";
			this.rvObservaciones5.Location = new System.Drawing.Point(0, 0);
			this.rvObservaciones5.Name = "rvObservaciones5";
			this.rvObservaciones5.ServerReport.BearerToken = null;
			this.rvObservaciones5.Size = new System.Drawing.Size(961, 424);
			this.rvObservaciones5.TabIndex = 5;
			this.rvObservaciones5.ZoomPercent = 125;
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Location = new System.Drawing.Point(4, 158);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(316, 170);
			this.panel1.TabIndex = 135;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(204, 77);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(100, 84);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(10, 3);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(72, 20);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(4, 27);
			this.pnlPorMesVentas.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(312, 42);
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
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(7, 9);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(167, 30);
			this.cmbMesesComprobantes.TabIndex = 19;
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(203, 10);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(101, 28);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
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
			base.Name = "Observaciones";
			this.Text = "Observaciones";
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
			this.tabPage2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
