using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXMLEntidades;
using Microsoft.Reporting.WinForms;

namespace LeeXML.Pantallas
{
	public class ImprimeCFDIsFlujoEgresosSinTotales : FormBase
	{
		private IContainer components = null;

		private TabControl tcImprimirCFDIs;

		private TabPage tabPage1;

		private Label label3;

		private TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private ReportViewer rvImpresionCFDIs;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private TabControl tcImprimirIVA;

		private TabPage tabPage2;

		private ReportViewer rvImpresionCFDIsIVA;

		private Label label1;

		private TextBox textBox1;

		private TabControl tcImprimirIVARFC;

		private TabPage tabPage3;

		private ReportViewer rvImpresionIVARFC;

		private Label label2;

		private TextBox textBox2;

		private TabControl tcImprimirDetalleDIOT;

		private TabPage tabPage4;

		private ReportViewer rvImpresionCFDIsDetalleDIOT;

		private Label label4;

		private TextBox textBox3;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<string> Parametros { get; set; }

		public ImprimeCFDIsFlujoEgresosSinTotales(List<EntFactura> ListaComprobantes)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			Parametros = new List<string>();
		}

		public ImprimeCFDIsFlujoEgresosSinTotales(List<EntFactura> ListaComprobantes, bool DetalleDIOT)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			Parametros = new List<string>();
			if (DetalleDIOT)
			{
				tcImprimirDetalleDIOT.BringToFront();
				tcImprimirIVA.Visible = false;
				tcImprimirIVARFC.Visible = false;
				tcImprimirCFDIs.Visible = false;
			}
		}

		public ImprimeCFDIsFlujoEgresosSinTotales(List<EntFactura> ListaComprobantes, string PueCantidad, string CpCantidad, string EgresosCantidad, string NDcantidad, string TotalCantidad, string PueSub, string CpSub, string EgresosSub, string NDsub, string TotalSub, string PueIva, string CpIva, string EgresosIva, string NDiva, string TotalIva, string PueRet, string CpRet, string EgresosRet, string NDret, string TotalRet, string PueTot, string CpTot, string EgresosTot, string NDtot, string TotalTot)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			Parametros = new List<string>();
			Parametros.Add(PueCantidad);
			Parametros.Add(CpCantidad);
			Parametros.Add(EgresosCantidad);
			Parametros.Add(NDcantidad);
			Parametros.Add(TotalCantidad);
			Parametros.Add(PueSub);
			Parametros.Add(CpSub);
			Parametros.Add(EgresosSub);
			Parametros.Add(NDsub);
			Parametros.Add(TotalSub);
			Parametros.Add(PueIva);
			Parametros.Add(CpIva);
			Parametros.Add(EgresosIva);
			Parametros.Add(NDiva);
			Parametros.Add(TotalIva);
			Parametros.Add(PueRet);
			Parametros.Add(CpRet);
			Parametros.Add(EgresosRet);
			Parametros.Add(NDret);
			Parametros.Add(TotalRet);
			Parametros.Add(PueTot);
			Parametros.Add(CpTot);
			Parametros.Add(EgresosTot);
			Parametros.Add(NDtot);
			Parametros.Add(TotalTot);
			tcImprimirDetalleDIOT.Visible = false;
		}

		public ImprimeCFDIsFlujoEgresosSinTotales(List<EntFactura> ListaComprobantes, bool IVA, bool RFC, string PueCantidad, string CpCantidad, string EgresosCantidad, string NDcantidad, string TotalCantidad, string PueSub, string CpSub, string EgresosSub, string NDsub, string TotalSub, string PueIva, string CpIva, string EgresosIva, string NDiva, string TotalIva, string PueRet, string CpRet, string EgresosRet, string NDret, string TotalRet, string PueTot, string CpTot, string EgresosTot, string NDtot, string TotalTot)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			Parametros = new List<string>();
			Parametros.Add(PueCantidad);
			Parametros.Add(CpCantidad);
			Parametros.Add(EgresosCantidad);
			Parametros.Add(NDcantidad);
			Parametros.Add(TotalCantidad);
			Parametros.Add(PueSub);
			Parametros.Add(CpSub);
			Parametros.Add(EgresosSub);
			Parametros.Add(NDsub);
			Parametros.Add(TotalSub);
			Parametros.Add(PueIva);
			Parametros.Add(CpIva);
			Parametros.Add(EgresosIva);
			Parametros.Add(NDiva);
			Parametros.Add(TotalIva);
			Parametros.Add(PueRet);
			Parametros.Add(CpRet);
			Parametros.Add(EgresosRet);
			Parametros.Add(NDret);
			Parametros.Add(TotalRet);
			Parametros.Add(PueTot);
			Parametros.Add(CpTot);
			Parametros.Add(EgresosTot);
			Parametros.Add(NDtot);
			Parametros.Add(TotalTot);
			if (IVA && !RFC)
			{
				tcImprimirIVA.BringToFront();
				tcImprimirCFDIs.Visible = false;
			}
			else
			{
				tcImprimirIVARFC.BringToFront();
				tcImprimirIVA.Visible = false;
				tcImprimirCFDIs.Visible = false;
			}
			tcImprimirDetalleDIOT.Visible = false;
		}

		private void CargaRV(List<EntFactura> ListaComprobantes)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + DateTime.Now.ToString("MMM yyyy").ToUpper());
			rvImpresionCFDIs.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIs.LocalReport.SetParameters(parmFecha);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmFecha);
			rvImpresionIVARFC.LocalReport.SetParameters(parmEmpresa);
			rvImpresionIVARFC.LocalReport.SetParameters(parmFecha);
			rvImpresionCFDIsDetalleDIOT.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIsDetalleDIOT.LocalReport.SetParameters(parmFecha);
			if (Parametros.Count > 0)
			{
				ReportParameter parmPue = new ReportParameter("parmPUEcantidad", Parametros[0]);
				ReportParameter parmCp = new ReportParameter("parmCPcantidad", Parametros[1]);
				ReportParameter parmEgresos = new ReportParameter("parmEGcantidad", Parametros[2]);
				ReportParameter parmND = new ReportParameter("parmNDcantidad", Parametros[3]);
				ReportParameter parmTotal = new ReportParameter("parmTOTcantidad", Parametros[4]);
				ReportParameter parmPueSub = new ReportParameter("parmPUEsubtotal", Parametros[5]);
				ReportParameter parmCpSub = new ReportParameter("parmCPsubtotal", Parametros[6]);
				ReportParameter parmEgresosSub = new ReportParameter("parmEGsubtotal", Parametros[7]);
				ReportParameter parmNDsub = new ReportParameter("parmNDsubtotal", Parametros[8]);
				ReportParameter parmTotalSub = new ReportParameter("parmTOTsubtotal", Parametros[9]);
				ReportParameter parmPueIva = new ReportParameter("parmPUEiva", Parametros[10]);
				ReportParameter parmCpIva = new ReportParameter("parmCPiva", Parametros[11]);
				ReportParameter parmEgresosIva = new ReportParameter("parmEGiva", Parametros[12]);
				ReportParameter parmNDiva = new ReportParameter("parmNDiva", Parametros[13]);
				ReportParameter parmTotalIva = new ReportParameter("parmTOTiva", Parametros[14]);
				ReportParameter parmPueRet = new ReportParameter("parmPUEretenciones", Parametros[15]);
				ReportParameter parmCpRet = new ReportParameter("parmCPretenciones", Parametros[16]);
				ReportParameter parmEgresosRet = new ReportParameter("parmEGretenciones", Parametros[17]);
				ReportParameter parmNDret = new ReportParameter("parmNDretenciones", Parametros[18]);
				ReportParameter parmTotalRet = new ReportParameter("parmTOTretenciones", Parametros[19]);
				ReportParameter parmPueTot = new ReportParameter("parmPUEtotal", Parametros[20]);
				ReportParameter parmCpTot = new ReportParameter("parmCPtotal", Parametros[21]);
				ReportParameter parmEgresosTot = new ReportParameter("parmEGtotal", Parametros[22]);
				ReportParameter parmNDtot = new ReportParameter("parmNDtotal", Parametros[23]);
				ReportParameter parmTotalTot = new ReportParameter("parmTOTtotal", Parametros[24]);
				rvImpresionCFDIs.LocalReport.SetParameters(parmPue);
				rvImpresionCFDIs.LocalReport.SetParameters(parmCp);
				rvImpresionCFDIs.LocalReport.SetParameters(parmEgresos);
				rvImpresionCFDIs.LocalReport.SetParameters(parmND);
				rvImpresionCFDIs.LocalReport.SetParameters(parmTotal);
				rvImpresionCFDIs.LocalReport.SetParameters(parmPueSub);
				rvImpresionCFDIs.LocalReport.SetParameters(parmCpSub);
				rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosSub);
				rvImpresionCFDIs.LocalReport.SetParameters(parmNDsub);
				rvImpresionCFDIs.LocalReport.SetParameters(parmTotalSub);
				rvImpresionCFDIs.LocalReport.SetParameters(parmPueIva);
				rvImpresionCFDIs.LocalReport.SetParameters(parmCpIva);
				rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosIva);
				rvImpresionCFDIs.LocalReport.SetParameters(parmNDiva);
				rvImpresionCFDIs.LocalReport.SetParameters(parmTotalIva);
				rvImpresionCFDIs.LocalReport.SetParameters(parmPueRet);
				rvImpresionCFDIs.LocalReport.SetParameters(parmCpRet);
				rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosRet);
				rvImpresionCFDIs.LocalReport.SetParameters(parmNDret);
				rvImpresionCFDIs.LocalReport.SetParameters(parmTotalRet);
				rvImpresionCFDIs.LocalReport.SetParameters(parmPueTot);
				rvImpresionCFDIs.LocalReport.SetParameters(parmCpTot);
				rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosTot);
				rvImpresionCFDIs.LocalReport.SetParameters(parmNDtot);
				rvImpresionCFDIs.LocalReport.SetParameters(parmTotalTot);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPue);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCp);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresos);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmND);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotal);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueSub);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpSub);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosSub);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmNDsub);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalSub);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueIva);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpIva);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosIva);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmNDiva);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalIva);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueRet);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpRet);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosRet);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmNDret);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalRet);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueTot);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpTot);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosTot);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmNDtot);
				rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalTot);
				rvImpresionIVARFC.LocalReport.SetParameters(parmPue);
				rvImpresionIVARFC.LocalReport.SetParameters(parmCp);
				rvImpresionIVARFC.LocalReport.SetParameters(parmEgresos);
				rvImpresionIVARFC.LocalReport.SetParameters(parmND);
				rvImpresionIVARFC.LocalReport.SetParameters(parmTotal);
				rvImpresionIVARFC.LocalReport.SetParameters(parmPueSub);
				rvImpresionIVARFC.LocalReport.SetParameters(parmCpSub);
				rvImpresionIVARFC.LocalReport.SetParameters(parmEgresosSub);
				rvImpresionIVARFC.LocalReport.SetParameters(parmNDsub);
				rvImpresionIVARFC.LocalReport.SetParameters(parmTotalSub);
				rvImpresionIVARFC.LocalReport.SetParameters(parmPueIva);
				rvImpresionIVARFC.LocalReport.SetParameters(parmCpIva);
				rvImpresionIVARFC.LocalReport.SetParameters(parmEgresosIva);
				rvImpresionIVARFC.LocalReport.SetParameters(parmNDiva);
				rvImpresionIVARFC.LocalReport.SetParameters(parmTotalIva);
				rvImpresionIVARFC.LocalReport.SetParameters(parmPueRet);
				rvImpresionIVARFC.LocalReport.SetParameters(parmCpRet);
				rvImpresionIVARFC.LocalReport.SetParameters(parmEgresosRet);
				rvImpresionIVARFC.LocalReport.SetParameters(parmNDret);
				rvImpresionIVARFC.LocalReport.SetParameters(parmTotalRet);
				rvImpresionIVARFC.LocalReport.SetParameters(parmPueTot);
				rvImpresionIVARFC.LocalReport.SetParameters(parmCpTot);
				rvImpresionIVARFC.LocalReport.SetParameters(parmEgresosTot);
				rvImpresionIVARFC.LocalReport.SetParameters(parmNDtot);
				rvImpresionIVARFC.LocalReport.SetParameters(parmTotalTot);
			}
			entFacturaBindingSource.DataSource = ListaComprobantes;
			rvImpresionCFDIs.LocalReport.DataSources.Clear();
			rvImpresionCFDIs.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIs.RefreshReport();
			rvImpresionCFDIsIVA.LocalReport.DataSources.Clear();
			rvImpresionCFDIsIVA.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIsIVA.RefreshReport();
			rvImpresionIVARFC.LocalReport.DataSources.Clear();
			rvImpresionIVARFC.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionIVARFC.RefreshReport();
			rvImpresionCFDIsDetalleDIOT.LocalReport.DataSources.Clear();
			rvImpresionCFDIsDetalleDIOT.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIsDetalleDIOT.RefreshReport();
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				base.UsuarioLogin = Program.UsuarioSeleccionado;
				CargaRV(ListaComprobantes);
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
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcImprimirCFDIs = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIs = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tcImprimirIVA = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIsIVA = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tcImprimirIVARFC = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.rvImpresionIVARFC = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tcImprimirDetalleDIOT = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIsDetalleDIOT = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcImprimirCFDIs.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tcImprimirIVA.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tcImprimirIVARFC.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tcImprimirDetalleDIOT.SuspendLayout();
			this.tabPage4.SuspendLayout();
			base.SuspendLayout();
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcImprimirCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcImprimirCFDIs.Controls.Add(this.tabPage1);
			this.tcImprimirCFDIs.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcImprimirCFDIs.Location = new System.Drawing.Point(7, 13);
			this.tcImprimirCFDIs.Name = "tcImprimirCFDIs";
			this.tcImprimirCFDIs.SelectedIndex = 0;
			this.tcImprimirCFDIs.Size = new System.Drawing.Size(945, 562);
			this.tcImprimirCFDIs.TabIndex = 129;
			this.tabPage1.Controls.Add(this.rvImpresionCFDIs);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(937, 535);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Imprimir";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIs.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosSAT.rdlc";
			this.rvImpresionCFDIs.Location = new System.Drawing.Point(0, 3);
			this.rvImpresionCFDIs.Margin = new System.Windows.Forms.Padding(2);
			this.rvImpresionCFDIs.Name = "rvImpresionCFDIs";
			this.rvImpresionCFDIs.ServerReport.BearerToken = null;
			this.rvImpresionCFDIs.Size = new System.Drawing.Size(940, 532);
			this.rvImpresionCFDIs.TabIndex = 1;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1055, 610);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 128;
			this.label3.Text = "Cantidad:";
			this.txtCantidadVentas.Enabled = false;
			this.txtCantidadVentas.Location = new System.Drawing.Point(1103, 606);
			this.txtCantidadVentas.Name = "txtCantidadVentas";
			this.txtCantidadVentas.Size = new System.Drawing.Size(55, 19);
			this.txtCantidadVentas.TabIndex = 127;
			this.tcImprimirIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcImprimirIVA.Controls.Add(this.tabPage2);
			this.tcImprimirIVA.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcImprimirIVA.Location = new System.Drawing.Point(10, 17);
			this.tcImprimirIVA.Name = "tcImprimirIVA";
			this.tcImprimirIVA.SelectedIndex = 0;
			this.tcImprimirIVA.Size = new System.Drawing.Size(945, 562);
			this.tcImprimirIVA.TabIndex = 130;
			this.tabPage2.Controls.Add(this.rvImpresionCFDIsIVA);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(937, 535);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Imprimir";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIsIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIsIVA.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosIVA.rdlc";
			this.rvImpresionCFDIsIVA.Location = new System.Drawing.Point(0, 5);
			this.rvImpresionCFDIsIVA.Margin = new System.Windows.Forms.Padding(2);
			this.rvImpresionCFDIsIVA.Name = "rvImpresionCFDIsIVA";
			this.rvImpresionCFDIsIVA.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsIVA.Size = new System.Drawing.Size(940, 532);
			this.rvImpresionCFDIsIVA.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1055, 610);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 128;
			this.label1.Text = "Cantidad:";
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(1103, 606);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(55, 19);
			this.textBox1.TabIndex = 127;
			this.tcImprimirIVARFC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcImprimirIVARFC.Controls.Add(this.tabPage3);
			this.tcImprimirIVARFC.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcImprimirIVARFC.Location = new System.Drawing.Point(10, 15);
			this.tcImprimirIVARFC.Name = "tcImprimirIVARFC";
			this.tcImprimirIVARFC.SelectedIndex = 0;
			this.tcImprimirIVARFC.Size = new System.Drawing.Size(945, 562);
			this.tcImprimirIVARFC.TabIndex = 131;
			this.tabPage3.Controls.Add(this.rvImpresionIVARFC);
			this.tabPage3.Controls.Add(this.label2);
			this.tabPage3.Controls.Add(this.textBox2);
			this.tabPage3.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(937, 535);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Imprimir";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.rvImpresionIVARFC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionIVARFC.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosIvaPorRFC.rdlc";
			this.rvImpresionIVARFC.Location = new System.Drawing.Point(0, 5);
			this.rvImpresionIVARFC.Margin = new System.Windows.Forms.Padding(2);
			this.rvImpresionIVARFC.Name = "rvImpresionIVARFC";
			this.rvImpresionIVARFC.ServerReport.BearerToken = null;
			this.rvImpresionIVARFC.Size = new System.Drawing.Size(940, 532);
			this.rvImpresionIVARFC.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1055, 610);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 128;
			this.label2.Text = "Cantidad:";
			this.textBox2.Enabled = false;
			this.textBox2.Location = new System.Drawing.Point(1103, 606);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(55, 19);
			this.textBox2.TabIndex = 127;
			this.tcImprimirDetalleDIOT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcImprimirDetalleDIOT.Controls.Add(this.tabPage4);
			this.tcImprimirDetalleDIOT.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcImprimirDetalleDIOT.Location = new System.Drawing.Point(12, 11);
			this.tcImprimirDetalleDIOT.Name = "tcImprimirDetalleDIOT";
			this.tcImprimirDetalleDIOT.SelectedIndex = 0;
			this.tcImprimirDetalleDIOT.Size = new System.Drawing.Size(945, 562);
			this.tcImprimirDetalleDIOT.TabIndex = 132;
			this.tabPage4.Controls.Add(this.rvImpresionCFDIsDetalleDIOT);
			this.tabPage4.Controls.Add(this.label4);
			this.tabPage4.Controls.Add(this.textBox3);
			this.tabPage4.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(937, 535);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "Imprimir";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIsDetalleDIOT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIsDetalleDIOT.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosDetalleDIOT.rdlc";
			this.rvImpresionCFDIsDetalleDIOT.Location = new System.Drawing.Point(0, 3);
			this.rvImpresionCFDIsDetalleDIOT.Margin = new System.Windows.Forms.Padding(2);
			this.rvImpresionCFDIsDetalleDIOT.Name = "rvImpresionCFDIsDetalleDIOT";
			this.rvImpresionCFDIsDetalleDIOT.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsDetalleDIOT.Size = new System.Drawing.Size(935, 532);
			this.rvImpresionCFDIsDetalleDIOT.TabIndex = 1;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(1055, 610);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 128;
			this.label4.Text = "Cantidad:";
			this.textBox3.Enabled = false;
			this.textBox3.Location = new System.Drawing.Point(1103, 606);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(55, 19);
			this.textBox3.TabIndex = 127;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(964, 587);
			base.Controls.Add(this.tcImprimirCFDIs);
			base.Controls.Add(this.tcImprimirIVA);
			base.Controls.Add(this.tcImprimirIVARFC);
			base.Controls.Add(this.tcImprimirDetalleDIOT);
			base.Name = "ImprimeCFDIsFlujoEgresosSinTotales";
			this.Text = "Imprime CFDI's";
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcImprimirCFDIs.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tcImprimirIVA.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tcImprimirIVARFC.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tcImprimirDetalleDIOT.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
