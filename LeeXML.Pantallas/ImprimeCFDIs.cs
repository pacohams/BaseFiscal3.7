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
	public class ImprimeCFDIs : FormBase
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

		private TabControl tcImprimirImportacion;

		private TabPage tabPage2;

		private ReportViewer rvImprimeCFDIsImportacion;

		private Label label1;

		private TextBox textBox1;

		private List<EntFactura> ListaComprobantes { get; set; }

		public ImprimeCFDIs(List<EntFactura> ListaComprobantes)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
		}

		public ImprimeCFDIs(List<EntFactura> ListaComprobantes, bool Importacion)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
			tcImprimirImportacion.BringToFront();
			tcPedidosGrids.Visible = false;
		}

		private void CargaRV(List<EntFactura> ListaComprobantes)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + DateTime.Now.ToString("MMM yyyy").ToUpper());
			rvImpresionCFDIs.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIs.LocalReport.SetParameters(parmFecha);
			rvImprimeCFDIsImportacion.LocalReport.SetParameters(parmEmpresa);
			rvImprimeCFDIsImportacion.LocalReport.SetParameters(parmFecha);
			entFacturaBindingSource.DataSource = ListaComprobantes;
			rvImpresionCFDIs.LocalReport.DataSources.Clear();
			rvImpresionCFDIs.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImpresionCFDIs.RefreshReport();
			rvImprimeCFDIsImportacion.LocalReport.DataSources.Clear();
			rvImprimeCFDIsImportacion.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
			rvImprimeCFDIsImportacion.RefreshReport();
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
			this.tcImprimirImportacion = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rvImprimeCFDIsImportacion = new Microsoft.Reporting.WinForms.ReportViewer();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tcImprimirImportacion.SuspendLayout();
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
			this.tcPedidosGrids.Size = new System.Drawing.Size(1261, 602);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.rvImpresionCFDIs);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1253, 571);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Imprimir";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIs.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsConUSD.rdlc";
			this.rvImpresionCFDIs.Location = new System.Drawing.Point(0, 6);
			this.rvImpresionCFDIs.Name = "rvImpresionCFDIs";
			this.rvImpresionCFDIs.ServerReport.BearerToken = null;
			this.rvImpresionCFDIs.Size = new System.Drawing.Size(1253, 564);
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
			this.tcImprimirImportacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcImprimirImportacion.Controls.Add(this.tabPage2);
			this.tcImprimirImportacion.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcImprimirImportacion.Location = new System.Drawing.Point(13, 22);
			this.tcImprimirImportacion.Margin = new System.Windows.Forms.Padding(4);
			this.tcImprimirImportacion.Name = "tcImprimirImportacion";
			this.tcImprimirImportacion.SelectedIndex = 0;
			this.tcImprimirImportacion.Size = new System.Drawing.Size(1261, 602);
			this.tcImprimirImportacion.TabIndex = 130;
			this.tabPage2.Controls.Add(this.rvImprimeCFDIsImportacion);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage2.Size = new System.Drawing.Size(1253, 571);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Imprimir";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.rvImprimeCFDIsImportacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImprimeCFDIsImportacion.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsImportacion.rdlc";
			this.rvImprimeCFDIsImportacion.Location = new System.Drawing.Point(0, 6);
			this.rvImprimeCFDIsImportacion.Name = "rvImprimeCFDIsImportacion";
			this.rvImprimeCFDIsImportacion.ServerReport.BearerToken = null;
			this.rvImprimeCFDIsImportacion.Size = new System.Drawing.Size(1253, 564);
			this.rvImprimeCFDIsImportacion.TabIndex = 1;
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
			base.ClientSize = new System.Drawing.Size(1287, 638);
			base.Controls.Add(this.tcPedidosGrids);
			base.Controls.Add(this.tcImprimirImportacion);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "ImprimeCFDIs";
			this.Text = "Imprime CFDI's";
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tcImprimirImportacion.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
