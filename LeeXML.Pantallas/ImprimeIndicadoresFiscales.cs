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
	public class ImprimeIndicadoresFiscales : FormBase
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

		private List<EntEstadoDeCuenta> ListaComprobantes { get; set; }

		private new string Titulo { get; set; }

		private DateTime Fecha { get; set; }

		private bool Periodo { get; set; }

		private string PeriodoS { get; set; }

		private string IngresosFacturados { get; set; }

		private string IngresosCobrados { get; set; }

		private string DeduccionesPagadas { get; set; }

		private string IvaCobrado { get; set; }

		private string IvaAcreditable { get; set; }

		private string ImpuestoFavorIvaR { get; set; }

		private string ImpuestoFavorIsrR { get; set; }

		private string ImpuestoPagarIvaR { get; set; }

		private string ImpuestoPagarIsrR { get; set; }

		private string NominaTotales { get; set; }

		private string NominaExentos { get; set; }

		private string NominaGravados { get; set; }

		private string NominaIsrR { get; set; }

		private string DIOTactos16 { get; set; }

		private string DIOTactos8 { get; set; }

		private string DIOTactos0 { get; set; }

		private string DIOTactosExentos { get; set; }

		private string DIOTnc16 { get; set; }

		private string DIOTnc8 { get; set; }

		public ImprimeIndicadoresFiscales(List<EntEstadoDeCuenta> ListaComprobantes, string Titulo, DateTime Fecha)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			this.Titulo = Titulo;
			this.Fecha = Fecha;
		}

		public ImprimeIndicadoresFiscales(List<EntEstadoDeCuenta> ListaComprobantes, string Titulo, string Periodo, string IngresosFacturados, string IngresosCobrados, string DeduccionesPagadas, string IvaCobrado, string IvaAcreditable, string ImpuestoFavorIvaR, string ImpuestoFavorIsrR, string ImpuestoPagarIvaR, string ImpuestoPagarIsrR, string NominaTotales, string NominaExentos, string NominaGravados, string NominaIsrR, string DIOTactos16, string DIOTactos8, string DIOTactos0, string DIOTactosExentos, string DIOTnc16, string DIOTnc8)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			this.Titulo = Titulo;
			this.Periodo = true;
			PeriodoS = Periodo;
			this.IngresosFacturados = IngresosFacturados;
			this.IngresosCobrados = IngresosCobrados;
			this.DeduccionesPagadas = DeduccionesPagadas;
			this.IvaCobrado = IvaCobrado;
			this.IvaAcreditable = IvaAcreditable;
			this.ImpuestoFavorIvaR = ImpuestoFavorIvaR;
			this.ImpuestoFavorIsrR = ImpuestoFavorIsrR;
			this.ImpuestoPagarIvaR = ImpuestoPagarIvaR;
			this.ImpuestoPagarIsrR = ImpuestoPagarIsrR;
			this.NominaTotales = NominaTotales;
			this.NominaExentos = NominaExentos;
			this.NominaGravados = NominaGravados;
			this.NominaIsrR = NominaIsrR;
			this.DIOTactos16 = DIOTactos16;
			this.DIOTactos8 = DIOTactos8;
			this.DIOTactos0 = DIOTactos0;
			this.DIOTactosExentos = DIOTactosExentos;
			this.DIOTnc16 = DIOTnc16;
			this.DIOTnc8 = DIOTnc8;
		}

		private void CargaRV(List<EntEstadoDeCuenta> ListaComprobantes, string Titulo, DateTime Fecha)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + Fecha.ToString("MMM yyyy").ToUpper());
			ReportParameter parmTitulo = new ReportParameter("parmTitulo", Titulo);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIs.LocalReport.SetParameters(parmFecha);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTitulo);
			entFacturaBindingSource.DataSource = ListaComprobantes;
			rvImpresionCFDIs.LocalReport.DataSources.Clear();
			rvImpresionCFDIs.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIs.RefreshReport();
		}

		private void CargaRV(List<EntEstadoDeCuenta> ListaComprobantes, string Titulo, string Periodo)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + Periodo.ToUpper());
			ReportParameter parmTitulo = new ReportParameter("parmTitulo", Titulo);
			ReportParameter parmIngresosFacturados = new ReportParameter("parmIngresosFacturados", IngresosFacturados);
			ReportParameter parmIngresosCobrados = new ReportParameter("parmIngresosCobrados", IngresosCobrados);
			ReportParameter parmDeduccionesPagadas = new ReportParameter("parmDeduccionesPagadas", DeduccionesPagadas);
			ReportParameter parmIvaCobrado = new ReportParameter("parmIvaCobrado", IvaCobrado);
			ReportParameter parmIvaAcreditable = new ReportParameter("parmIvaAcreditable", IvaAcreditable);
			ReportParameter parmImpuestoFavorIvaR = new ReportParameter("parmImpuestoFavorIvaR", ImpuestoFavorIvaR);
			ReportParameter parmImpuestoFavorIsrR = new ReportParameter("parmImpuestoFavorIsrR", ImpuestoFavorIsrR);
			ReportParameter parmImpuestoPagarIvaR = new ReportParameter("parmImpuestoPagarIvaR", ImpuestoPagarIvaR);
			ReportParameter parmImpuestoPagarIsrR = new ReportParameter("parmImpuestoPagarIsrR", ImpuestoPagarIsrR);
			ReportParameter parmNominaTotales = new ReportParameter("parmNominaTotales", NominaTotales);
			ReportParameter parmNominaExentos = new ReportParameter("parmNominaExentos", NominaExentos);
			ReportParameter parmNominaGravados = new ReportParameter("parmNominaGravados", NominaGravados);
			ReportParameter parmNominaIsrR = new ReportParameter("parmNominaIsrR", NominaIsrR);
			ReportParameter parmDIOTactos16 = new ReportParameter("parmDIOTactos16", DIOTactos16);
			ReportParameter parmDIOTactos17 = new ReportParameter("parmDIOTactos8", DIOTactos8);
			ReportParameter parmDIOTactos18 = new ReportParameter("parmDIOTactos0", DIOTactos0);
			ReportParameter parmDIOTactosExentos = new ReportParameter("parmDIOTactosExentos", DIOTactosExentos);
			ReportParameter parmDIOTnc16 = new ReportParameter("parmDIOTnc16", DIOTnc16);
			ReportParameter parmDIOTnc17 = new ReportParameter("parmDIOTnc8", DIOTnc8);
			rvImpresionCFDIs.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIs.LocalReport.SetParameters(parmFecha);
			rvImpresionCFDIs.LocalReport.SetParameters(parmTitulo);
			rvImpresionCFDIs.LocalReport.SetParameters(parmIngresosFacturados);
			rvImpresionCFDIs.LocalReport.SetParameters(parmIngresosCobrados);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDeduccionesPagadas);
			rvImpresionCFDIs.LocalReport.SetParameters(parmIvaCobrado);
			rvImpresionCFDIs.LocalReport.SetParameters(parmIvaAcreditable);
			rvImpresionCFDIs.LocalReport.SetParameters(parmImpuestoFavorIvaR);
			rvImpresionCFDIs.LocalReport.SetParameters(parmImpuestoFavorIsrR);
			rvImpresionCFDIs.LocalReport.SetParameters(parmImpuestoPagarIvaR);
			rvImpresionCFDIs.LocalReport.SetParameters(parmImpuestoPagarIsrR);
			rvImpresionCFDIs.LocalReport.SetParameters(parmNominaTotales);
			rvImpresionCFDIs.LocalReport.SetParameters(parmNominaExentos);
			rvImpresionCFDIs.LocalReport.SetParameters(parmNominaGravados);
			rvImpresionCFDIs.LocalReport.SetParameters(parmNominaIsrR);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDIOTactos16);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDIOTactos17);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDIOTactos18);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDIOTactosExentos);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDIOTnc16);
			rvImpresionCFDIs.LocalReport.SetParameters(parmDIOTnc17);
			entFacturaBindingSource.DataSource = ListaComprobantes;
			rvImpresionCFDIs.LocalReport.DataSources.Clear();
			rvImpresionCFDIs.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIs.RefreshReport();
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				base.UsuarioLogin = Program.UsuarioSeleccionado;
				if (!Periodo)
				{
					CargaRV(ListaComprobantes, Titulo, Fecha);
				}
				else
				{
					CargaRV(ListaComprobantes, Titulo, PeriodoS);
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
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIs = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			base.SuspendLayout();
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 29);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1455, 751);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.rvImpresionCFDIs);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1447, 716);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Imprimir";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIs.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptIndicadoresFiscales.rdlc";
			this.rvImpresionCFDIs.Location = new System.Drawing.Point(0, 8);
			this.rvImpresionCFDIs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rvImpresionCFDIs.Name = "rvImpresionCFDIs";
			this.rvImpresionCFDIs.ServerReport.BearerToken = null;
			this.rvImpresionCFDIs.Size = new System.Drawing.Size(1445, 703);
			this.rvImpresionCFDIs.TabIndex = 1;
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
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1484, 836);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "ImprimeIndicadoresFiscales";
			this.Text = "Imprime Indicadores Fiscales";
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			base.ResumeLayout(false);
		}
	}
}
