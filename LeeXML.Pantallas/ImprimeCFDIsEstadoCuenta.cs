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
	public class ImprimeCFDIsEstadoCuenta : FormBase
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

		private List<EntFactura> ListaComprobantes { get; set; }

		public ImprimeCFDIsEstadoCuenta(List<EntFactura> ListaComprobantes)
		{
			InitializeComponent();
			this.ListaComprobantes = ListaComprobantes;
		}

		private void CargaRV(List<EntFactura> ListaComprobantes)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + DateTime.Now.ToString("MMM yyyy").ToUpper());
			rvImpresionCFDIs.LocalReport.SetParameters(parmEmpresa);
			rvImpresionCFDIs.LocalReport.SetParameters(parmFecha);
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
			this.tcPedidosGrids.Location = new System.Drawing.Point(13, 23);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1151, 602);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.rvImpresionCFDIs);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1143, 571);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Imprimir";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIs.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsEstadoCuenta.rdlc";
			this.rvImpresionCFDIs.Location = new System.Drawing.Point(0, 6);
			this.rvImpresionCFDIs.Name = "rvImpresionCFDIs";
			this.rvImpresionCFDIs.ServerReport.BearerToken = null;
			this.rvImpresionCFDIs.Size = new System.Drawing.Size(1143, 564);
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
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1177, 638);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "ImprimeCFDIsEstadoCuenta";
			this.Text = "Imprime CFDI's";
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
