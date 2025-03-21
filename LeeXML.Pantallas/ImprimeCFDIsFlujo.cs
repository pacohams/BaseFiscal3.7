using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Microsoft.Reporting.WinForms;

namespace LeeXML.Pantallas
{
	public class ImprimeCFDIsFlujo : FormBase
	{
		private IContainer components = null;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private Label label3;

		private TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private ReportViewer rvImpresionCFDIs;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private TabControl tcImprimirCFDIsIVA;

		private TabPage tabPage2;

		private ReportViewer rvImpresionCFDIsIVA;

		private Label label1;

		private TextBox textBox1;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<string> Parametros { get; set; }

		public ImprimeCFDIsFlujo(List<EntFactura> ListaComprobantes, string PueCantidad, string CpCantidad, string EgresosCantidad, string NDcantidad, string TotalCantidad, string PueSub, string CpSub, string EgresosSub, string NDsub, string TotalSub, string PueIva, string CpIva, string EgresosIva, string NDiva, string TotalIva, string PueRet, string CpRet, string EgresosRet, string NDret, string TotalRet, string PueTot, string CpTot, string EgresosTot, string NDtot, string TotalTot)
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
		}

		public ImprimeCFDIsFlujo(List<EntFactura> ListaComprobantes, bool IVA, string PueCantidad, string CpCantidad, string EgresosCantidad, string NDcantidad, string TotalCantidad, string PueSub, string CpSub, string EgresosSub, string NDsub, string TotalSub, string PueIva, string CpIva, string EgresosIva, string NDiva, string TotalIva, string PueRet, string CpRet, string EgresosRet, string NDret, string TotalRet, string PueTot, string CpTot, string EgresosTot, string NDtot, string TotalTot)
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
			tcImprimirCFDIsIVA.BringToFront();
			tcPedidosGrids.Visible = false;
		}

		private void CargaRV(List<EntFactura> ListaComprobantes)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + DateTime.Now.ToString("MMM yyyy").ToUpper());
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
			rvImpresionCFDIs.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIs.LocalReport.SetParameters(parmFecha);
			rvImpresionCFDIs.LocalReport.SetParameters(parmPue);
			rvImpresionCFDIs.LocalReport.SetParameters(parmCp);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEgresos);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTotal);
			rvImpresionCFDIs.LocalReport.SetParameters(parmPueSub);
			rvImpresionCFDIs.LocalReport.SetParameters(parmCpSub);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosSub);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTotalSub);
			rvImpresionCFDIs.LocalReport.SetParameters(parmPueIva);
			rvImpresionCFDIs.LocalReport.SetParameters(parmCpIva);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosIva);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTotalIva);
			rvImpresionCFDIs.LocalReport.SetParameters(parmPueRet);
			rvImpresionCFDIs.LocalReport.SetParameters(parmCpRet);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosRet);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTotalRet);
			rvImpresionCFDIs.LocalReport.SetParameters(parmPueTot);
			rvImpresionCFDIs.LocalReport.SetParameters(parmCpTot);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEgresosTot);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTotalTot);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmFecha);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPue);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCp);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresos);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotal);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueSub);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpSub);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosSub);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalSub);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueIva);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpIva);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosIva);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalIva);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueRet);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpRet);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosRet);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalRet);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmPueTot);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmCpTot);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmEgresosTot);
			rvImpresionCFDIsIVA.LocalReport.SetParameters(parmTotalTot);
			entFacturaBindingSource.DataSource = ListaComprobantes;
			rvImpresionCFDIs.LocalReport.DataSources.Clear();
			rvImpresionCFDIs.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIs.RefreshReport();
			rvImpresionCFDIsIVA.LocalReport.DataSources.Clear();
			rvImpresionCFDIsIVA.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIsIVA.RefreshReport();
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

		public void VerificaCFDIsinRelacionar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstFiltro = new BusFacturas().ObtieneComprobantesFiscalesSinRelacionar(Empresa, FechaDesde, FechaHasta);
			int sinRelacionar = lstFiltro.Where((EntFactura P) => P.TipoRelacionId <= 0 || (P.TipoRelacionId == 1 && P.Descuento > 0m)).ToList().Count;
			if (sinRelacionar > 0)
			{
				MuestraMensajeAdvertencia($"Se encontraron {sinRelacionar.ToString()} registro(s) de CFDI\u00b4s tipo PUE/CP sin relacionar a Depósito", "ADVERTENCIA");
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
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIs = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tcImprimirCFDIsIVA = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIsIVA = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tcImprimirCFDIsIVA.SuspendLayout();
			this.tabPage2.SuspendLayout();
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
			this.tcPedidosGrids.Size = new System.Drawing.Size(1344, 582);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.rvImpresionCFDIs);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1336, 551);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Imprimir";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIs.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujo.rdlc";
			this.rvImpresionCFDIs.Location = new System.Drawing.Point(0, 6);
			this.rvImpresionCFDIs.Name = "rvImpresionCFDIs";
			this.rvImpresionCFDIs.ServerReport.BearerToken = null;
			this.rvImpresionCFDIs.Size = new System.Drawing.Size(1336, 544);
			this.rvImpresionCFDIs.TabIndex = 1;
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
			this.tcImprimirCFDIsIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcImprimirCFDIsIVA.Controls.Add(this.tabPage2);
			this.tcImprimirCFDIsIVA.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcImprimirCFDIsIVA.Location = new System.Drawing.Point(13, 22);
			this.tcImprimirCFDIsIVA.Margin = new System.Windows.Forms.Padding(4);
			this.tcImprimirCFDIsIVA.Name = "tcImprimirCFDIsIVA";
			this.tcImprimirCFDIsIVA.SelectedIndex = 0;
			this.tcImprimirCFDIsIVA.Size = new System.Drawing.Size(1344, 582);
			this.tcImprimirCFDIsIVA.TabIndex = 130;
			this.tabPage2.Controls.Add(this.rvImpresionCFDIsIVA);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage2.Size = new System.Drawing.Size(1336, 551);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Imprimir";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIsIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIsIVA.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoIVA.rdlc";
			this.rvImpresionCFDIsIVA.Location = new System.Drawing.Point(0, 6);
			this.rvImpresionCFDIsIVA.Name = "rvImpresionCFDIsIVA";
			this.rvImpresionCFDIsIVA.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsIVA.Size = new System.Drawing.Size(1336, 544);
			this.rvImpresionCFDIsIVA.TabIndex = 1;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1407, 751);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 16);
			this.label1.TabIndex = 128;
			this.label1.Text = "Cantidad:";
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(1471, 746);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(72, 22);
			this.textBox1.TabIndex = 127;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1370, 618);
			base.Controls.Add(this.tcPedidosGrids);
			base.Controls.Add(this.tcImprimirCFDIsIVA);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "ImprimeCFDIsFlujo";
			this.Text = "Imprime CFDI's";
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tcImprimirCFDIsIVA.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
