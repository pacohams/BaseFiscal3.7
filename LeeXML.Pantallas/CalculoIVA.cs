using System;
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
	public class CalculoIVA : FormBase
	{
		private IContainer components = null;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private ComboBox cmbEmpresas;

		private TabPage tabPage1;

		private TabControl tcReportesIngresos;

		private TabPage tabPage2;

		private FlowLayoutPanel flpCalculosIVA;

		private FlowLayoutPanel flowLayoutPanel6;

		private TextBox txtTotalIngresos;

		private Label label6;

		private FlowLayoutPanel flowLayoutPanel1;

		private TextBox txtIVATrasladado;

		private Label label2;

		private FlowLayoutPanel flowLayoutPanel3;

		private TextBox txtIVAretenido;

		private Label label4;

		private FlowLayoutPanel flowLayoutPanel4;

		private TextBox txtIVAacreditableTotal;

		private Label label5;

		private FlowLayoutPanel flowLayoutPanel11;

		private Label label8;

		private Panel panel1;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private TabControl tcCalculosIVA;

		private FlowLayoutPanel flowLayoutPanel13;

		private TextBox txtIVAretenidoG;

		private Label label9;

		private FlowLayoutPanel flowLayoutPanel7;

		private TextBox txtIVAacreditable;

		private FlowLayoutPanel flowLayoutPanel5;

		private TextBox txtIVAacreditableCalculado;

		private Label label7;

		private FlowLayoutPanel flowLayoutPanel8;

		private FlowLayoutPanel flowLayoutPanel9;

		private TextBox txtIVAPagarFavor;

		private Label label10;

		private FlowLayoutPanel flowLayoutPanel12;

		private Label lbPagarFavor;

		private FlowLayoutPanel flowLayoutPanel14;

		private FlowLayoutPanel flpEmitidos;

		private FlowLayoutPanel flpTotalesTodos;

		private ToolStrip toolStrip1;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNumPUE;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotalPUE;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel17;

		private ToolStripTextBox tstxtIvaPUE;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstxtRetencionesPUE;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImportePUE;

		private FlowLayoutPanel flowLayoutPanel16;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tstxtNumCP;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox tstxtSubtotalCP;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tstxtIvaCP;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel18;

		private ToolStripTextBox tstxtRetencionesCP;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tstxtImporteCP;

		private FlowLayoutPanel flowLayoutPanel17;

		private ToolStrip toolStrip5;

		private ToolStripLabel toolStripLabel20;

		private ToolStripTextBox tstxtNumEg;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripLabel toolStripLabel21;

		private ToolStripTextBox tstxtSubtotalEg;

		private ToolStripSeparator toolStripSeparator17;

		private ToolStripLabel toolStripLabel22;

		private ToolStripTextBox tstxtIvaEg;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripLabel toolStripLabel23;

		private ToolStripTextBox tstxtRetencionesEg;

		private ToolStripSeparator toolStripSeparator19;

		private ToolStripLabel toolStripLabel24;

		private ToolStripTextBox tstxtImporteEg;

		private FlowLayoutPanel flowLayoutPanel19;

		private ToolStrip toolStrip3;

		private ToolStripLabel toolStripLabel9;

		private ToolStripTextBox tstxtNumTotal;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripLabel toolStripLabel10;

		private ToolStripTextBox tstxtSubtotalTotal;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripLabel toolStripLabel11;

		private ToolStripTextBox tstxtIvaTotal;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripLabel toolStripLabel19;

		private ToolStripTextBox tstxtRetencionesTotal;

		private ToolStripSeparator toolStripSeparator15;

		private ToolStripLabel toolStripLabel12;

		private ToolStripTextBox tstxtImporteTotal;

		private FlowLayoutPanel flowLayoutPanel20;

		private TextBox txtIvaRetenidoPagado;

		private Label label13;

		private FlowLayoutPanel flpRecibidos;

		private FlowLayoutPanel flowLayoutPanel22;

		private ToolStrip toolStrip7;

		private ToolStripLabel toolStripLabel31;

		private ToolStripTextBox tstxtNumPUEe;

		private ToolStripSeparator toolStripSeparator25;

		private ToolStripLabel toolStripLabel32;

		private ToolStripTextBox tstxtSubtotalPUEe;

		private ToolStripSeparator toolStripSeparator26;

		private ToolStripLabel toolStripLabel33;

		private ToolStripTextBox tstxtIvaPUEe;

		private ToolStripSeparator toolStripSeparator27;

		private ToolStripLabel toolStripLabel34;

		private ToolStripTextBox tstxtRetencionesPUEe;

		private ToolStripSeparator toolStripSeparator28;

		private ToolStripLabel toolStripLabel35;

		private ToolStripTextBox tstxtImportePUEe;

		private FlowLayoutPanel flowLayoutPanel23;

		private ToolStrip toolStrip8;

		private ToolStripLabel toolStripLabel36;

		private ToolStripTextBox tstxtNumCPe;

		private ToolStripSeparator toolStripSeparator29;

		private ToolStripLabel toolStripLabel37;

		private ToolStripTextBox tstxtSubtotalCPe;

		private ToolStripSeparator toolStripSeparator30;

		private ToolStripLabel toolStripLabel38;

		private ToolStripTextBox tstxtIvaCPe;

		private ToolStripSeparator toolStripSeparator31;

		private ToolStripLabel toolStripLabel39;

		private ToolStripTextBox tstxtRetencionesCPe;

		private ToolStripSeparator toolStripSeparator32;

		private ToolStripLabel toolStripLabel40;

		private ToolStripTextBox tstxtImporteCPe;

		private FlowLayoutPanel flowLayoutPanel24;

		private ToolStrip toolStrip9;

		private ToolStripLabel toolStripLabel41;

		private ToolStripTextBox tstxtNumEge;

		private ToolStripSeparator toolStripSeparator33;

		private ToolStripLabel toolStripLabel42;

		private ToolStripTextBox tstxtSubtotalEge;

		private ToolStripSeparator toolStripSeparator34;

		private ToolStripLabel toolStripLabel43;

		private ToolStripTextBox tstxtIvaEge;

		private ToolStripSeparator toolStripSeparator35;

		private ToolStripLabel toolStripLabel44;

		private ToolStripTextBox tstxtRetencionesEge;

		private ToolStripSeparator toolStripSeparator36;

		private ToolStripLabel toolStripLabel45;

		private ToolStripTextBox tstxtImporteEge;

		private FlowLayoutPanel flowLayoutPanel25;

		private ToolStrip toolStrip10;

		private ToolStripLabel toolStripLabel46;

		private ToolStripTextBox tstxtNumNDe;

		private ToolStripSeparator toolStripSeparator37;

		private ToolStripLabel toolStripLabel47;

		private ToolStripTextBox tstxtSubtotalNDe;

		private ToolStripSeparator toolStripSeparator38;

		private ToolStripLabel toolStripLabel48;

		private ToolStripTextBox tstxtIvaNDe;

		private ToolStripSeparator toolStripSeparator39;

		private ToolStripLabel toolStripLabel49;

		private ToolStripTextBox tstxtRetencionesNDe;

		private ToolStripSeparator toolStripSeparator40;

		private ToolStripLabel toolStripLabel50;

		private ToolStripTextBox tstxtImporteNDe;

		private FlowLayoutPanel flowLayoutPanel26;

		private ToolStrip toolStrip11;

		private ToolStripLabel toolStripLabel51;

		private ToolStripTextBox tstxtNumTotale;

		private ToolStripSeparator toolStripSeparator41;

		private ToolStripLabel toolStripLabel52;

		private ToolStripTextBox tstxtSubtotalTotale;

		private ToolStripSeparator toolStripSeparator42;

		private ToolStripLabel toolStripLabel53;

		private ToolStripTextBox tstxtIvaTotale;

		private ToolStripSeparator toolStripSeparator43;

		private ToolStripLabel toolStripLabel54;

		private ToolStripTextBox tstxtRetencionesTotale;

		private ToolStripSeparator toolStripSeparator44;

		private ToolStripLabel toolStripLabel55;

		private ToolStripTextBox tstxtImporteTotale;

		private Label label14;

		private Label label11;

		private TabPage tpImpresion;

		private ReportViewer rvCalculoIVA;

		private CheckBox chkCalculoIvaRIF;

		private FlowLayoutPanel flpCalculosIvaRif;

		private FlowLayoutPanel flowLayoutPanel10;

		private TextBox txtTotalIngresosFacturadosRif;

		private Label label15;

		private FlowLayoutPanel flowLayoutPanel18;

		private TextBox txtIngresosPublicoGeneral;

		private Label label16;

		private FlowLayoutPanel flowLayoutPanel27;

		private TextBox txtOtrosIngresosPG;

		private Label label17;

		private FlowLayoutPanel flowLayoutPanel28;

		private TextBox txtTotalIngresosPG;

		private Label label18;

		private FlowLayoutPanel flowLayoutPanel29;

		private FlowLayoutPanel flowLayoutPanel30;

		private Label label19;

		private FlowLayoutPanel flowLayoutPanel31;

		private TextBox txtIvaOperacionesPG;

		private Label label20;

		private FlowLayoutPanel flowLayoutPanel32;

		private Label label21;

		private FlowLayoutPanel flowLayoutPanel33;

		private TextBox txtIvaReducido;

		private Label label22;

		private FlowLayoutPanel flowLayoutPanel35;

		private TextBox txtIvaTrasladadoOperacionesPG;

		private Label label23;

		private FlowLayoutPanel flowLayoutPanel36;

		private FlowLayoutPanel flowLayoutPanel37;

		private FlowLayoutPanel flowLayoutPanel38;

		private TextBox txtIvaTrasladadoOperacionesPG2;

		private Label label26;

		private BindingSource entCatalogoGenericoBindingSource;

		private TextBox txtIvaTrasladadoCFDI;

		private Label label25;

		private FlowLayoutPanel flowLayoutPanel2;

		private TextBox txtIvaTrasladadoTotal;

		private Label label27;

		private FlowLayoutPanel flowLayoutPanel39;

		private FlowLayoutPanel flowLayoutPanel40;

		private TextBox txtIvaRetenidoRIF;

		private Label label28;

		private FlowLayoutPanel flowLayoutPanel41;

		private FlowLayoutPanel flowLayoutPanel42;

		private TextBox txtIvaAcreditableCFDI;

		private Label label29;

		private FlowLayoutPanel flowLayoutPanel43;

		private TextBox txtProporcionPorOperacionesPG;

		private Label label30;

		private FlowLayoutPanel flowLayoutPanel44;

		private TextBox txtIvaFiscalAcreditable;

		private Label label31;

		private FlowLayoutPanel flowLayoutPanel45;

		private FlowLayoutPanel flowLayoutPanel46;

		private TextBox txtIvaPorPagarAfavorRIF;

		private Label lbIvaPorPagarAfavorRIF;

		private ComboBox cmbTasaIVA;

		private ComboBox cmbPorcentajeReduccion;

		private FlowLayoutPanel flowLayoutPanel47;

		private TextBox txtIngresosPublicoNoAcumulables;

		private Label label32;

		private Panel pnlIngresosPgCi;

		private Label label34;

		private TextBox txtIngresosClientesIndividualesFlujo;

		private Label label33;

		private TextBox txtIngresosPgFlujo;

		private Button btnExportarIVA;

		private FlowLayoutPanel flowLayoutPanel50;

		private TextBox txtIngresosCI;

		private Label label36;

		private FlowLayoutPanel flowLayoutPanel48;

		private TextBox txtOtrosIngresosCI;

		private Label label35;

		private FlowLayoutPanel flowLayoutPanel34;

		private TextBox txtIngresosNoAcumulablesCI;

		private Label label37;

		private FlowLayoutPanel flowLayoutPanel49;

		private FlowLayoutPanel flowLayoutPanel51;

		private TextBox txtTotalIngresosCI;

		private Label label38;

		private FlowLayoutPanel flowLayoutPanel52;

		private TextBox txtOtroIvaAcreditable;

		private Label label39;

		private FlowLayoutPanel flowLayoutPanel53;

		private TextBox txtIvaNoAcreditable;

		private Label label40;

		private FlowLayoutPanel flowLayoutPanel54;

		private TextBox txtIvaAcreditableTotalRIF;

		private Label label41;

		private Button btnDeshacerCaptura;

		private Label label42;

		private TextBox txtActos8;

		private Label label43;

		private TextBox txtActos16;

		private Panel pnlActos;

		private Label label44;

		private TextBox txtActosExentos;

		private Label label45;

		private TextBox txtActos0;

		private TextBox txtSumaActos;

		private Label label46;

		private TextBox txtProporcionIvaAcreditable;

		private Label label47;

		private Button btnExportarDetallesCFDIs;

		private Panel pnlExportaDetallesCFDIsEgresos;

		private Button btnExportarDetallesCFDIsRecibidos;

		private Button btnExportarDetallesCFDIsRecibidosPorRFC;

		private Panel pnlExportaDetallesCFDIs;

		private FlowLayoutPanel flowLayoutPanel21;

		private TextBox txtProporcionIvaAcreditableAE;

		private Label label1;

		private FlowLayoutPanel flowLayoutPanel55;

		private TextBox txtIvaFiscalAcreditableAE;

		private Label label48;

		private FlowLayoutPanel flpObjetoImpuesto;

		private FlowLayoutPanel flowLayoutPanel56;

		private Label label3;

		private TextBox txtObjetoImpuesto01;

		private FlowLayoutPanel flowLayoutPanel57;

		private Label label12;

		private TextBox txtObjetoImpuesto02;

		private FlowLayoutPanel flowLayoutPanel58;

		private Label label49;

		private TextBox txtObjetoImpuesto03;

		private GroupBox gbInformacionCFDI40;

		private GroupBox gbActos;

		private Button btnExportarDetallesCFDIsRecibidosPorRFCbatch;

		private FlowLayoutPanel flowLayoutPanel15;

		private TextBox txtIvaAcreditableSinCFDI;

		private Label label50;

		private FlowLayoutPanel flowLayoutPanel59;

		private TextBox txtIvaAcreditableSinCFDIresta;

		private Label label51;

		private FlowLayoutPanel flowLayoutPanel60;

		private TextBox txtIvaTrasladadoSinCFDI;

		private Label label52;

		private FlowLayoutPanel flowLayoutPanel61;

		private TextBox txtIvaTrasladadoSinCFDIresta;

		private Label label53;

		private FlowLayoutPanel flpEmpresas;

		private Label label24;

		private Button btnBuscaEmpresa;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantesEgresos { get; set; }

		private int PeriocidadId { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public CalculoIVA()
		{
			InitializeComponent();
		}

		private void CargaComprobantes(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, bool RIF)
		{
			if (RIF)
			{
				ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1);
				ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
			}
			else
			{
				ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscalesObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1);
				ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivoObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1));
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesDatosAdicionalesTraslado(Empresa, FechaDesde, FechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivoDatosAdicionalesTraslado(Empresa, FechaDesde, FechaHasta, 1));
				decimal actos16 = default(decimal);
				decimal actos17 = default(decimal);
				decimal actos18 = default(decimal);
				decimal actosExentos = default(decimal);
				List<EntFactura> lstNC = listaComprobantesDA.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList();
				listaComprobantesDA = listaComprobantesDA.Where((EntFactura P) => P.FechaPago >= FechaDesde || P.TipoComprobanteId == 1).ToList();
				actos16 = listaComprobantesDA.Where((EntFactura P) => P.TipoComprobanteId != 2 && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total) - lstNC.Where((EntFactura P) => P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total);
				actos17 = listaComprobantesDA.Where((EntFactura P) => P.TipoComprobanteId != 2 && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total) - lstNC.Where((EntFactura P) => P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total);
				actos18 = listaComprobantesDA.Where((EntFactura P) => P.TipoComprobanteId != 2 && P.TipoFactorId == 1 && P.TasaOCuota == 0m).Sum((EntFactura P) => P.Total) - lstNC.Where((EntFactura P) => P.TipoFactorId == 1 && P.TasaOCuota == 0m).Sum((EntFactura P) => P.Total);
				actosExentos = listaComprobantesDA.Where((EntFactura P) => P.TipoComprobanteId != 2 && P.TipoFactorId == 3 && P.TasaOCuota == 0m).Sum((EntFactura P) => P.Total) - lstNC.Where((EntFactura P) => P.TipoFactorId == 3 && P.TasaOCuota == 0m).Sum((EntFactura P) => P.Total);
				txtActos16.Text = FormatoMoney(actos16);
				txtActos8.Text = FormatoMoney(actos17);
				txtActos0.Text = FormatoMoney(actos18);
				txtActosExentos.Text = FormatoMoney(actosExentos);
				txtSumaActos.Text = FormatoMoney(ConvierteTextoADecimal(txtActos16) + ConvierteTextoADecimal(txtActos8) + ConvierteTextoADecimal(txtActos0) + ConvierteTextoADecimal(txtActosExentos));
				if (ConvierteTextoADecimal(txtSumaActos) == 0m)
				{
					txtProporcionIvaAcreditable.Text = "1.00";
				}
				else
				{
					txtProporcionIvaAcreditable.Text = Math.Round((ConvierteTextoADecimal(txtActos16) + ConvierteTextoADecimal(txtActos8) + ConvierteTextoADecimal(txtActos0)) / ConvierteTextoADecimal(txtSumaActos), 4).ToString();
				}
				txtProporcionIvaAcreditableAE.Text = txtProporcionIvaAcreditable.Text;
			}
			txtIVATrasladado.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total));
			txtIVAretenido.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.Total));
			txtIVAacreditableTotal.Text = FormatoMoney(ConvierteTextoADecimal(txtIVATrasladado) + ConvierteTextoADecimal(txtIVAretenido));
			txtTotalIngresos.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 2).Sum((EntFactura P) => P.Total));
			txtIVAretenidoG.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7).Sum((EntFactura P) => P.Total));
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, bool PUE, bool PPD, bool Complementos, bool Egresos, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			if (PUE || PPD || Complementos || Egresos)
			{
				lstFiltro = ListaComprobantes.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList();
			}
			List<decimal> lstPuePG = CalculaSumaTotalFromListaProductosIVAretenidoPG(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false);
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUE.TextBox, tstxtSubtotalPUE.TextBox, tstxtIvaPUE.TextBox, tstxtRetencionesPUE.TextBox, tstxtNumPUE.TextBox);
			List<decimal> lstCpPG = CalculaSumaTotalFromListaProductosIVAretenidoPG(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde).ToList(), false);
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde).ToList(), false, tstxtImporteCP.TextBox, tstxtSubtotalCP.TextBox, tstxtIvaCP.TextBox, tstxtRetencionesCP.TextBox, tstxtNumCP.TextBox);
			List<decimal> lstEgresosPG = CalculaSumaTotalFromListaProductosIVAretenidoPG(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList(), false);
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList(), false, tstxtImporteEg.TextBox, tstxtSubtotalEg.TextBox, tstxtIvaEg.TextBox, tstxtRetencionesEg.TextBox, tstxtNumEg.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUE.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCP.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEg.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUE.TextBox) + ConvierteTextoADecimal(tstxtIvaCP.TextBox) - ConvierteTextoADecimal(tstxtIvaEg.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUE.TextBox) + ConvierteTextoADecimal(tstxtImporteCP.TextBox) - ConvierteTextoADecimal(tstxtImporteEg.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUE.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCP.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEg.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUE.TextBox) + ConvierteTextoADecimal(tstxtNumCP.TextBox) + ConvierteTextoADecimal(tstxtNumEg.TextBox);
			tstxtSubtotalTotal.TextBox.Text = FormatoMoney(subtotal);
			tstxtIvaTotal.TextBox.Text = FormatoMoney(iva);
			tstxtRetencionesTotal.TextBox.Text = FormatoMoney(retenciones);
			tstxtImporteTotal.TextBox.Text = FormatoMoney(total);
			tstxtNumTotal.TextBox.Text = num.ToString();
			txtTotalIngresos.Text = FormatoMoney(subtotal);
			txtTotalIngresosFacturadosRif.Text = FormatoMoney(subtotal);
			txtIngresosPublicoGeneral.Text = FormatoMoney(lstPuePG[1] + lstCpPG[1] - lstEgresosPG[1]);
			txtIngresosCI.Text = FormatoMoney(subtotal - ConvierteTextoADecimal(txtIngresosPublicoGeneral));
			txtIVATrasladado.Text = FormatoMoney(iva);
			txtIvaTrasladadoCFDI.Text = FormatoMoney(iva);
			txtIVAretenido.Text = FormatoMoney(retenciones);
			txtIvaRetenidoRIF.Text = FormatoMoney(retenciones);
			lstFiltro = lstFiltro.Where((EntFactura P) => P.FechaPago >= FechaDesde || P.TipoComprobanteId == 1).ToList();
			txtObjetoImpuesto01.Text = FormatoMoney(lstFiltro.Sum((EntFactura P) => P.ObjetoImpuesto01));
			txtObjetoImpuesto02.Text = FormatoMoney(lstFiltro.Sum((EntFactura P) => P.ObjetoImpuesto02));
			txtObjetoImpuesto03.Text = FormatoMoney(lstFiltro.Sum((EntFactura P) => P.ObjetoImpuesto03));
		}

		private void CargaComprobantesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, bool RIF)
		{
			if (RIF)
			{
				ListaComprobantesEgresos = new BusFacturas().ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 1);
				ListaComprobantesEgresos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
			}
			else
			{
				ListaComprobantesEgresos = new BusFacturas().ObtieneComprobantesFiscalesEgresosObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1);
				ListaComprobantesEgresos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1));
			}
		}

		private void FiltraComprobantesEgresos(List<EntFactura> ListaComprobantes, bool PUE, bool PPD, bool Complementos, bool Egresos, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			if (PUE || PPD || Complementos || Egresos)
			{
				lstFiltro = ListaComprobantes.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && P.Deducible)).ToList();
			}
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUEe.TextBox, tstxtSubtotalPUEe.TextBox, tstxtIvaPUEe.TextBox, tstxtRetencionesPUEe.TextBox, tstxtNumPUEe.TextBox);
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde).ToList(), false, tstxtImporteCPe.TextBox, tstxtSubtotalCPe.TextBox, tstxtIvaCPe.TextBox, tstxtRetencionesCPe.TextBox, tstxtNumCPe.TextBox);
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && P.Deducible)).ToList(), false, tstxtImporteEge.TextBox, tstxtSubtotalEge.TextBox, tstxtIvaEge.TextBox, tstxtRetencionesEge.TextBox, tstxtNumEge.TextBox);
			CalculaSumaTotalFromListaProductosIVAretenido(ListaComprobantes.Where((EntFactura P) => ((P.TipoComprobanteId == 1 && P.MetodoPagoId == 1) || P.TipoComprobanteId == 5) && !P.Deducible).ToList(), false, tstxtImporteNDe.TextBox, tstxtSubtotalNDe.TextBox, tstxtIvaNDe.TextBox, tstxtRetencionesNDe.TextBox, tstxtNumNDe.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUEe.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCPe.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEge.TextBox) - ConvierteTextoADecimal(tstxtSubtotalNDe.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUEe.TextBox) + ConvierteTextoADecimal(tstxtIvaCPe.TextBox) - ConvierteTextoADecimal(tstxtIvaEge.TextBox) - ConvierteTextoADecimal(tstxtIvaNDe.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUEe.TextBox) + ConvierteTextoADecimal(tstxtImporteCPe.TextBox) - ConvierteTextoADecimal(tstxtImporteEge.TextBox) - ConvierteTextoADecimal(tstxtImporteNDe.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUEe.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCPe.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEge.TextBox) - ConvierteTextoADecimal(tstxtRetencionesNDe.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUEe.TextBox) + ConvierteTextoADecimal(tstxtNumCPe.TextBox) + ConvierteTextoADecimal(tstxtNumEge.TextBox) + ConvierteTextoADecimal(tstxtNumNDe.TextBox);
			tstxtSubtotalTotale.TextBox.Text = FormatoMoney(subtotal);
			tstxtIvaTotale.TextBox.Text = FormatoMoney(iva);
			txtIVAacreditable.Text = FormatoMoney(iva);
			txtIvaAcreditableCFDI.Text = FormatoMoney(iva);
			tstxtRetencionesTotale.TextBox.Text = FormatoMoney(retenciones);
			txtIVAretenidoG.Text = FormatoMoney(retenciones);
			tstxtImporteTotale.TextBox.Text = FormatoMoney(total);
			tstxtNumTotale.TextBox.Text = num.ToString();
		}

		private void CalculaIVAacreditableRIF(decimal TotalIngresosFacturados, decimal IngresosPG, decimal IngresosCI, decimal TasaIVA, decimal PorcentajeReduccion, decimal IvaTrasladadoCFDI, decimal IvaRetenido, decimal IvaAcreditableCFDI)
		{
			decimal otrosIngresosPG = ConvierteTextoADecimal(txtOtrosIngresosPG);
			decimal IngresosPublicoNoAcumulables = ConvierteTextoADecimal(txtIngresosPublicoNoAcumulables);
			decimal totalIngresosPG = IngresosPG + otrosIngresosPG - IngresosPublicoNoAcumulables;
			decimal otrosIngresosCI = ConvierteTextoADecimal(txtOtrosIngresosCI);
			decimal ingresosNoAcumulablesCI = ConvierteTextoADecimal(txtIngresosNoAcumulablesCI);
			decimal totalIngresosCI = IngresosCI + otrosIngresosCI - ingresosNoAcumulablesCI;
			decimal otroIvaAcreditable = ConvierteTextoADecimal(txtOtroIvaAcreditable);
			decimal ivaNoAcreditable = ConvierteTextoADecimal(txtIvaNoAcreditable);
			decimal ivaAcreditableTotal = IvaAcreditableCFDI + otroIvaAcreditable - ivaNoAcreditable;
			txtTotalIngresosPG.Text = FormatoMoney(totalIngresosPG);
			txtIngresosPgFlujo.Text = FormatoMoney(IngresosPG);
			txtIngresosClientesIndividualesFlujo.Text = FormatoMoney(TotalIngresosFacturados - IngresosPG);
			txtTotalIngresosCI.Text = FormatoMoney(totalIngresosCI);
			decimal ivaOperacionesPG = totalIngresosPG * (TasaIVA / 100m);
			txtIvaOperacionesPG.Text = FormatoMoney(totalIngresosPG * (TasaIVA / 100m));
			decimal ivaReducido = ivaOperacionesPG * (PorcentajeReduccion / 100m);
			txtIvaReducido.Text = FormatoMoney(ivaReducido);
			decimal ivaTrasldadoOperacionesPG = ivaOperacionesPG - ivaReducido;
			txtIvaTrasladadoOperacionesPG.Text = FormatoMoney(ivaTrasldadoOperacionesPG);
			txtIvaTrasladadoOperacionesPG2.Text = FormatoMoney(ivaTrasldadoOperacionesPG);
			decimal ivaTrasladadoTotal = ivaTrasldadoOperacionesPG + IvaTrasladadoCFDI;
			txtIvaTrasladadoTotal.Text = FormatoMoney(ivaTrasladadoTotal);
			decimal proporcionOperacionesPG = ((!(totalIngresosPG + totalIngresosCI > 0m)) ? default(decimal) : (totalIngresosCI / (totalIngresosPG + totalIngresosCI)));
			txtProporcionPorOperacionesPG.Text = proporcionOperacionesPG.ToString("0.0000");
			txtIvaAcreditableTotalRIF.Text = FormatoMoney(ivaAcreditableTotal);
			decimal ivaFiscalAcreditable = ivaAcreditableTotal * proporcionOperacionesPG;
			txtIvaFiscalAcreditable.Text = FormatoMoney(ivaFiscalAcreditable);
			decimal ivaPagarFavor = ivaTrasladadoTotal - IvaRetenido - ivaFiscalAcreditable;
			txtIvaPorPagarAfavorRIF.Text = FormatoMoney(ivaPagarFavor);
			string ivaPagarFavorS = "";
			if (ivaPagarFavor > 0m)
			{
				ivaPagarFavorS = "(=) IVA POR PAGAR";
			}
			else if (ivaPagarFavor < 0m)
			{
				ivaPagarFavorS = "(=) IVA A FAVOR";
			}
			lbIvaPorPagarAfavorRIF.Text = ivaPagarFavorS;
		}

		private void InicializaPantalla()
		{
			PeriocidadId = 1;
			CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
			CargaAñosCmb(cmbAñoComprobantes);
			SeleccionaPeriodoActual(cmbMesesComprobantes, PeriocidadId, new Label());
			cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
			cmbTasaIVA.SelectedIndex = 2;
			cmbPorcentajeReduccion.SelectedIndex = cmbPorcentajeReduccion.Items.Count - 1;
			flpCalculosIvaRif.SendToBack();
			if (Program.EmpresaSeleccionada.Id == 0)
			{
				MuestraMensajePaginaCompra vMensaje = new MuestraMensajePaginaCompra();
				vMensaje.Text = "SIN LICENCIAS ACTIVAS";
				vMensaje.Mensaje = "LICENCIA(S) VENCIDA(S)";
				vMensaje.ShowDialog();
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
				tcCalculosIVA.TabPages.Remove(tpImpresion);
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
				}
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
				SetWaitCursor();
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				CargaComprobantes(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, chkCalculoIvaRIF.Checked);
				FiltraComprobantes(ListaComprobantes, true, false, true, true, fechaDesde, fechaHasta);
				CargaComprobantesEgresos(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, chkCalculoIvaRIF.Checked);
				FiltraComprobantesEgresos(ListaComprobantesEgresos, true, false, true, true, fechaDesde, fechaHasta);
				CalculaIVAacreditableRIF(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIngresosPublicoGeneral), ConvierteTextoADecimal(txtIngresosCI), ConvierteTextoADecimal(cmbTasaIVA.Text.Replace("%", "")), ConvierteTextoADecimal(cmbPorcentajeReduccion.Text.Replace("%", "")), ConvierteTextoADecimal(txtIvaTrasladadoCFDI.Text), ConvierteTextoADecimal(txtIvaRetenidoRIF.Text), ConvierteTextoADecimal(txtIvaAcreditableCFDI.Text));
				List<EntEstadoDeCuenta> lstIVA = CalculaIVAacreditable(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIVATrasladado), ConvierteTextoADecimal(txtIVAretenido), ConvierteTextoADecimal(txtIvaRetenidoPagado), ConvierteTextoADecimal(txtProporcionIvaAcreditableAE), ConvierteTextoADecimal(txtIvaAcreditableSinCFDI), ConvierteTextoADecimal(txtIvaAcreditableSinCFDIresta), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDI), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDIresta));
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

		public List<EntEstadoDeCuenta> CalculaIVAacreditable(decimal TotalIngreso, decimal IvaTrasladado, decimal IvaRetenido, decimal IvaCapturado, decimal ProporcionIvaAcreditable, decimal ivaAcreditableSinCFDI, decimal ivaAcreditableSinCFDIresta, decimal ivaTrasladadoSinCFDI, decimal ivaTrasladadoSinCFDIresta)
		{
			decimal ivaPagarFavor = default(decimal);
			decimal ivaAcreditable = default(decimal);
			decimal ivaRetenidoG = default(decimal);
			decimal ivaCalculado = default(decimal);
			ivaAcreditable = ConvierteTextoADecimal(txtIVAacreditable);
			ivaRetenidoG = ConvierteTextoADecimal(txtIVAretenidoG);
			ivaCalculado = ivaAcreditable - ivaRetenidoG + IvaCapturado;
			ivaCalculado += ivaAcreditableSinCFDI - ivaAcreditableSinCFDIresta;
			txtIVAacreditableCalculado.Text = FormatoMoney(ivaCalculado);
			ivaCalculado *= ProporcionIvaAcreditable;
			txtIvaFiscalAcreditableAE.Text = FormatoMoney(ivaCalculado);
			txtIVAacreditableTotal.Text = FormatoMoney(ivaCalculado);
			ivaPagarFavor = IvaTrasladado - IvaRetenido - ivaCalculado;
			ivaPagarFavor += ivaTrasladadoSinCFDI - ivaTrasladadoSinCFDIresta;
			txtIVAPagarFavor.Text = FormatoMoney(ivaPagarFavor);
			string ivaPagarFavorS = "";
			if (ivaPagarFavor > 0m)
			{
				ivaPagarFavorS = "IVA POR PAGAR";
			}
			else if (ivaPagarFavor < 0m)
			{
				ivaPagarFavorS = "IVA A FAVOR";
			}
			lbPagarFavor.Text = ivaPagarFavorS;
			List<EntEstadoDeCuenta> lstIVA = new List<EntEstadoDeCuenta>();
			decimal isrDeterminado = default(decimal);
			decimal porcentaje = default(decimal);
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "TOTAL DE INGRESOS PARA IVA SEGÚN CFDI:",
				Total = TotalIngreso
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "IVA TRASLADADO SEGÚN CFDI:",
				Total = IvaTrasladado
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(-) IVA RETENIDO SEGÚN CFDI:",
				Total = IvaRetenido
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(-) IVA ACREDITABLE SEGÚN CFDI:",
				Total = ivaCalculado
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "IVA ACREDITABLE",
				Total = ivaAcreditable
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(-) IVA RETENIDO DE GASTOS:",
				Total = ivaRetenidoG
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(+) IVA RETENIDO PAGADO:",
				Total = IvaCapturado
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(=) IVA ACREDITABLE SEGÚN CFDI:",
				Total = ivaCalculado
			});
			lstIVA.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(=) " + ivaPagarFavorS,
				Total = ivaPagarFavor
			});
			return lstIVA;
		}

		private void txtIVACaptura_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalculaIVAacreditable(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIVATrasladado), ConvierteTextoADecimal(txtIVAretenido), ConvierteTextoADecimal(txtIvaRetenidoPagado), ConvierteTextoADecimal(txtProporcionIvaAcreditableAE), ConvierteTextoADecimal(txtIvaAcreditableSinCFDI), ConvierteTextoADecimal(txtIvaAcreditableSinCFDIresta), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDI), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDIresta));
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

		private void tcPedidosGrids_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DateTime fechaDesde = FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
				DateTime fechaHasta = FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
				List<EntEstadoDeCuenta> lstIVA = CalculaIVAacreditable(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIVATrasladado), ConvierteTextoADecimal(txtIVAretenido), ConvierteTextoADecimal(txtIvaRetenidoPagado), ConvierteTextoADecimal(txtProporcionIvaAcreditableAE), ConvierteTextoADecimal(txtIvaAcreditableSinCFDI), ConvierteTextoADecimal(txtIvaAcreditableSinCFDIresta), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDI), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDIresta));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtIVACaptura_Leave(object sender, EventArgs e)
		{
			TextBoxDecimalMoney_Leave(sender, e);
		}

		private void chkCalculoIvaRIF_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				flpCalculosIVA.Visible = !chkCalculoIvaRIF.Checked;
				gbInformacionCFDI40.Visible = !chkCalculoIvaRIF.Checked;
				gbActos.Visible = !chkCalculoIvaRIF.Checked;
				flpCalculosIvaRif.Visible = chkCalculoIvaRIF.Checked;
				btnDeshacerCaptura.Visible = chkCalculoIvaRIF.Checked;
				pnlIngresosPgCi.Visible = chkCalculoIvaRIF.Checked;
				pnlActos.Visible = !chkCalculoIvaRIF.Checked;
				if (chkCalculoIvaRIF.Checked)
				{
					PeriocidadId = 2;
					CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
				}
				else
				{
					PeriocidadId = 1;
					CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
				}
				SeleccionaPeriodoActual(cmbMesesComprobantes, PeriocidadId, new Label());
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtIngresosPublicoGeneral_TextChanged(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (((TextBox)sender).Focused)
				{
					CalculaIVAacreditableRIF(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIngresosPublicoGeneral), ConvierteTextoADecimal(txtIngresosCI), ConvierteTextoADecimal(cmbTasaIVA.Text.Remove(1)), ConvierteTextoADecimal(cmbPorcentajeReduccion.Text.Replace("%", "")), ConvierteTextoADecimal(txtIvaTrasladadoCFDI.Text), ConvierteTextoADecimal(txtIvaRetenidoRIF.Text), ConvierteTextoADecimal(txtIvaAcreditableCFDI.Text));
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

		private void cmbTasaIVA_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (((ComboBox)sender).Focused)
				{
					CalculaIVAacreditableRIF(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIngresosPublicoGeneral), ConvierteTextoADecimal(txtIngresosCI), ConvierteTextoADecimal(cmbTasaIVA.Text.Remove(1)), ConvierteTextoADecimal(cmbPorcentajeReduccion.Text.Replace("%", "")), ConvierteTextoADecimal(txtIvaTrasladadoCFDI.Text), ConvierteTextoADecimal(txtIvaRetenidoRIF.Text), ConvierteTextoADecimal(txtIvaAcreditableCFDI.Text));
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

		private void AgregaElementoEnLista(List<EntEstadoDeCuenta> Lista, string Descripcion, decimal Total)
		{
			string totals = "";
			if (Total != 0m)
			{
				totals = FormatoMoney(Total);
			}
			Lista.Add(new EntEstadoDeCuenta
			{
				Fecha = DateTime.Now,
				Descripcion = Descripcion.ToUpper(),
				NumeroFactura = totals
			});
		}

		private void AgregaElementoEnLista(List<EntEstadoDeCuenta> Lista, string Descripcion, string Total)
		{
			Lista.Add(new EntEstadoDeCuenta
			{
				Fecha = DateTime.Now,
				Descripcion = Descripcion.ToUpper(),
				NumeroFactura = Total
			});
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionIva(decimal TotalIngreso, decimal IvaTrasladado, decimal IvaRetenido, decimal IvaAcreditableTotal, decimal IvaAcreditable, decimal IvaRetenidoG, decimal IvaRetenidoPagado, decimal IvaAcreditableCFDI, string IvaPorPagarAfavor, decimal IvaPorPagarAnual, string ProporcionIvaAcreditable, decimal IvaAcreditableSinCFDI, decimal IvaAcreditableSinCFDIresta, decimal IvaTrasladadoSinCFDI, decimal IvaTrasladadoSinCFDIresta)
		{
			List<EntEstadoDeCuenta> lstIVA = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstIVA, "CALCULO DE IVA", "");
			AgregaElementoEnLista(lstIVA, "TOTAL DE INGRESOS PARA IVA SEGÚN CFDI: ", TotalIngreso);
			AgregaElementoEnLista(lstIVA, "IVA TRASLADADO SEGÚN CFDI: ", IvaTrasladado);
			AgregaElementoEnLista(lstIVA, "(+) IVA TRASLADADO SIN CFDI: ", IvaTrasladadoSinCFDI);
			AgregaElementoEnLista(lstIVA, "(-) IVA TRASLADADO SIN CFDI: ", IvaTrasladadoSinCFDIresta);
			AgregaElementoEnLista(lstIVA, "(-) IVA RETENIDO SEGÚN CFDI: ", IvaRetenido);
			AgregaElementoEnLista(lstIVA, "(-) IVA FISCAL ACREDITABLE: ", IvaAcreditableTotal);
			AgregaElementoEnLista(lstIVA, "", "");
			AgregaElementoEnLista(lstIVA, "IVA ACREDITABLE", IvaAcreditable);
			AgregaElementoEnLista(lstIVA, "(+) IVA ACREDITABLE SIN CFDI: ", IvaAcreditableSinCFDI);
			AgregaElementoEnLista(lstIVA, "(-) IVA ACREDITABLE SIN CFDI: ", IvaAcreditableSinCFDIresta);
			AgregaElementoEnLista(lstIVA, "(-) IVA RETENIDO DE GASTOS: ", IvaRetenidoG);
			AgregaElementoEnLista(lstIVA, "(+) IVA RETENIDO PAGADO: ", IvaRetenidoPagado);
			AgregaElementoEnLista(lstIVA, "(=) IVA ACREDITABLE SEGÚN CFDI: ", IvaAcreditableCFDI);
			AgregaElementoEnLista(lstIVA, "(X) PROPORCIÓN IVA ACREDITABLE: ", ProporcionIvaAcreditable);
			AgregaElementoEnLista(lstIVA, "(=) IVA FISCAL ACREDITABLE: ", IvaAcreditableTotal);
			AgregaElementoEnLista(lstIVA, "   ", "");
			AgregaElementoEnLista(lstIVA, IvaPorPagarAfavor, IvaPorPagarAnual);
			return lstIVA;
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionIvaRif(decimal TotalIngreso, decimal IngresosPublicoGeneral, decimal OtrosIngresosPG, decimal IngresosPublicoNoAcumulables, decimal TotalIngresosPublicoGeneral, string TasaIvaDeAcuerdoActividad, decimal IvaOperacionesPublicoGeneral, string PorcentajeReduccion, decimal IvaReducido, decimal IvaTrasladadoOperacionesPG, decimal IngresosCI, decimal OtrosIngresosCI, decimal IngresosNoAcumulablesCI, decimal TotalIngresosCI, decimal IvaTrasladadoSegunCFDI, decimal IvaTrasladadoTotal, decimal IvaRetenido, decimal IvaAcreditableSegunCFDI, decimal OtroIvaAcreditable, decimal IvaNoAcreditable, decimal IvaAcreditableTotal, string ProporcionOperacionesPG, decimal IvaFiscalAcreditable, string IvaPorPagarAfavor, decimal IvaPorPagarAnual)
		{
			List<EntEstadoDeCuenta> lstIVA = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstIVA, "CALCULO DE IVA RIF", "");
			AgregaElementoEnLista(lstIVA, "INGRESOS PÚBLICO GENERAL: ", IngresosPublicoGeneral);
			AgregaElementoEnLista(lstIVA, "(+) OTROS INGRESOS PÚBLICO GENERAL: ", OtrosIngresosPG);
			AgregaElementoEnLista(lstIVA, "(-) INGRESOS PÚBLICO NO ACUMULABLES: ", IngresosPublicoNoAcumulables);
			AgregaElementoEnLista(lstIVA, "(=) TOTAL INGRESOS PÚBLICO GENERAL", TotalIngresosPublicoGeneral);
			AgregaElementoEnLista(lstIVA, "", "");
			AgregaElementoEnLista(lstIVA, "(x) TASA DE IVA DE ACUERDO A LA ACTIVIDAD: ", TasaIvaDeAcuerdoActividad);
			AgregaElementoEnLista(lstIVA, "(=) IVA OPERACIONES PÚBLICO GENERAL: ", IvaOperacionesPublicoGeneral);
			AgregaElementoEnLista(lstIVA, "(x) PORCENTAJE DE REDUCCIÓN: ", PorcentajeReduccion);
			AgregaElementoEnLista(lstIVA, "(=) IVA REDUCIDO: ", IvaReducido);
			AgregaElementoEnLista(lstIVA, "(=) IVA TRASLADADO OPERACIONES PÚBLICO GENERAL: ", IvaTrasladadoOperacionesPG);
			AgregaElementoEnLista(lstIVA, "  ", "");
			AgregaElementoEnLista(lstIVA, "INGRESOS CLIENTES INDIVIDUALES: ", IngresosCI);
			AgregaElementoEnLista(lstIVA, "(+) OTROS INGRESOS CLIENTES INDIVIDUALES: ", OtrosIngresosCI);
			AgregaElementoEnLista(lstIVA, "(-) INGRESOS CLIENTES INDIVIDUALES NO ACUMULABLES: ", IngresosNoAcumulablesCI);
			AgregaElementoEnLista(lstIVA, "(=) TOTAL INGRESOS CLIENTES INDIVIDUALES", TotalIngresosCI);
			AgregaElementoEnLista(lstIVA, "   ", "");
			AgregaElementoEnLista(lstIVA, "IVA TRASLADADO OPERACIONES PÚBLICO GENERAL: ", IvaTrasladadoOperacionesPG);
			AgregaElementoEnLista(lstIVA, "(+) IVA TRASLADADO: ", IvaTrasladadoSegunCFDI);
			AgregaElementoEnLista(lstIVA, "(=) IVA TRASLADADO TOTAL: ", IvaTrasladadoTotal);
			AgregaElementoEnLista(lstIVA, "    ", "");
			AgregaElementoEnLista(lstIVA, "(-) IVA RETENIDO: ", IvaRetenido);
			AgregaElementoEnLista(lstIVA, "     ", "");
			AgregaElementoEnLista(lstIVA, "IVA ACREDITABLE SEGÚN CFDI: ", IvaAcreditableSegunCFDI);
			AgregaElementoEnLista(lstIVA, "(+) OTRO IVA ACREDITABLE: ", OtroIvaAcreditable);
			AgregaElementoEnLista(lstIVA, "(-) IVA NO ACREDITABLE: ", IvaNoAcreditable);
			AgregaElementoEnLista(lstIVA, "(=) IVA ACREDITABLE TOTAL", IvaAcreditableTotal);
			AgregaElementoEnLista(lstIVA, "PROPORCIÓN POR OPERACIONES PÚBLICO GENERAL: ", ProporcionOperacionesPG);
			AgregaElementoEnLista(lstIVA, "(=) IVA FISCAL ACREDITABLE: ", IvaFiscalAcreditable);
			AgregaElementoEnLista(lstIVA, IvaPorPagarAfavor, IvaPorPagarAnual);
			return lstIVA;
		}

		private void btnExportarIVA_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntEstadoDeCuenta> lstIVA = new List<EntEstadoDeCuenta>();
				string titulo = "";
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				ImprimeDeclaracion vImprime;
				if (chkCalculoIvaRIF.Checked)
				{
					lstIVA = ObtieneListaImpresionIvaRif(ConvierteTextoADecimal(txtTotalIngresosFacturadosRif), ConvierteTextoADecimal(txtIngresosPublicoGeneral), ConvierteTextoADecimal(txtOtrosIngresosPG), ConvierteTextoADecimal(txtIngresosPublicoNoAcumulables), ConvierteTextoADecimal(txtTotalIngresosPG), cmbTasaIVA.Text, ConvierteTextoADecimal(txtIvaOperacionesPG), cmbPorcentajeReduccion.Text, ConvierteTextoADecimal(txtIvaReducido), ConvierteTextoADecimal(txtIvaTrasladadoOperacionesPG), ConvierteTextoADecimal(txtIngresosCI), ConvierteTextoADecimal(txtOtrosIngresosCI), ConvierteTextoADecimal(txtIngresosNoAcumulablesCI), ConvierteTextoADecimal(txtTotalIngresosCI), ConvierteTextoADecimal(txtIvaTrasladadoCFDI), ConvierteTextoADecimal(txtIvaTrasladadoTotal), ConvierteTextoADecimal(txtIvaRetenidoRIF), ConvierteTextoADecimal(txtIvaAcreditableCFDI), ConvierteTextoADecimal(txtOtroIvaAcreditable), ConvierteTextoADecimal(txtIvaNoAcreditable), ConvierteTextoADecimal(txtIvaAcreditableTotalRIF), txtProporcionPorOperacionesPG.Text, ConvierteTextoADecimal(txtIvaFiscalAcreditable), lbIvaPorPagarAfavorRIF.Text, ConvierteTextoADecimal(txtIvaPorPagarAfavorRIF));
					string periodo = fechaDesde.ToString("MMM").ToUpper() + "-" + fechaHasta.ToString("MMM").ToUpper();
					vImprime = new ImprimeDeclaracion(lstIVA, titulo, periodo);
				}
				else
				{
					lstIVA = ObtieneListaImpresionIva(ConvierteTextoADecimal(txtTotalIngresos), ConvierteTextoADecimal(txtIVATrasladado), ConvierteTextoADecimal(txtIVAretenido), ConvierteTextoADecimal(txtIVAacreditableTotal), ConvierteTextoADecimal(txtIVAacreditable), ConvierteTextoADecimal(txtIVAretenidoG), ConvierteTextoADecimal(txtIvaRetenidoPagado), ConvierteTextoADecimal(txtIVAacreditableCalculado), lbPagarFavor.Text, ConvierteTextoADecimal(txtIVAPagarFavor), txtProporcionIvaAcreditableAE.Text, ConvierteTextoADecimal(txtIvaAcreditableSinCFDI), ConvierteTextoADecimal(txtIvaAcreditableSinCFDIresta), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDI), ConvierteTextoADecimal(txtIvaTrasladadoSinCFDIresta));
					vImprime = new ImprimeDeclaracion(lstIVA, titulo, fechaDesde);
				}
				vImprime.Show();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnDeshacerCaptura_Click(object sender, EventArgs e)
		{
			try
			{
				txtOtrosIngresosPG.Text = FormatoMoney(0m);
				txtIngresosPublicoNoAcumulables.Text = FormatoMoney(0m);
				txtOtrosIngresosCI.Text = FormatoMoney(0m);
				txtIngresosNoAcumulablesCI.Text = FormatoMoney(0m);
				txtOtroIvaAcreditable.Text = FormatoMoney(0m);
				txtIvaNoAcreditable.Text = FormatoMoney(0m);
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnExportarDetallesCFDIs_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				List<EntFactura> xmls = ListaComprobantes.Where((EntFactura P) => (P.MetodoPagoId == 1 && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList();
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivoDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				foreach (EntFactura f in xmls)
				{
					f.SubTotal = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total);
					f.Descuento = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total);
					f.SubTotal0 = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 1).Sum((EntFactura P) => P.Total);
					f.Deduccion = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 3).Sum((EntFactura P) => P.Total);
					f.IVA = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.ImporteDR);
					f.Retenciones = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.ImporteDR);
					if (f.TipoComprobanteId == 2)
					{
						f.SubTotal *= -1m;
						f.Descuento *= -1m;
						f.SubTotal0 *= -1m;
						f.Deduccion *= -1m;
						f.IVA *= -1m;
						f.Retenciones *= -1m;
						f.IVARetenciones *= -1m;
						f.ISRRetenciones *= -1m;
						f.Total *= -1m;
						f.TipoEstructuraImpuestoId = 1;
					}
				}
				ImprimeCFDIsFlujo vImprime = new ImprimeCFDIsFlujo(xmls, true, tstxtNumPUE.TextBox.Text, tstxtNumCP.TextBox.Text, tstxtNumEg.TextBox.Text, "0", tstxtNumTotal.TextBox.Text, tstxtSubtotalPUE.TextBox.Text, tstxtSubtotalCP.TextBox.Text, tstxtSubtotalEg.TextBox.Text, "0", tstxtSubtotalTotal.TextBox.Text, tstxtIvaPUE.TextBox.Text, tstxtIvaCP.TextBox.Text, tstxtIvaEg.TextBox.Text, "0", tstxtIvaTotal.TextBox.Text, tstxtRetencionesPUE.TextBox.Text, tstxtRetencionesCP.TextBox.Text, tstxtRetencionesEg.TextBox.Text, "0", tstxtRetencionesTotal.TextBox.Text, tstxtImportePUE.TextBox.Text, tstxtImporteCP.TextBox.Text, tstxtImporteEg.TextBox.Text, "0", tstxtImporteTotal.TextBox.Text);
				vImprime.Show();
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

		private void btnExportarDetallesCFDIsRecibidos_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				List<EntFactura> xmls = new List<EntFactura>();
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				xmls = ListaComprobantesEgresos.Where((EntFactura P) => P.Deducible && ((P.MetodoPagoId == 1 && P.TipoComprobanteId == 1) || (P.TipoComprobanteId == 5 && P.FechaPago >= fechaDesde && P.FechaPago <= fechaHasta) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo))).ToList();
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesEgresosDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				foreach (EntFactura f in xmls)
				{
					f.SubTotal = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total);
					f.Descuento = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total);
					f.SubTotal0 = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 1).Sum((EntFactura P) => P.Total);
					f.Deduccion = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 3).Sum((EntFactura P) => P.Total);
					f.IVA = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.ImporteDR);
					f.Retenciones = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.ImporteDR);
					if (f.TipoComprobanteId == 2 && f.TipoEstructuraImpuestoId == 0)
					{
						f.Total *= -1m;
						f.TipoEstructuraImpuestoId = 1;
					}
				}
				List<EntFactura> lstExento = xmls.Where((EntFactura a) => !listaComprobantesDA.Any((EntFactura b) => b.Id == a.Id)).ToList();
				foreach (EntFactura ex in lstExento.Where((EntFactura p) => p.ObjetoImpuesto02 > 0m).ToList())
				{
					xmls.Where((EntFactura P) => P.Id == ex.Id).First().Deduccion = ex.ObjetoImpuesto02;
					ex.Id = ex.Id;
					ex.TipoEstructuraImpuestoId = 1;
					ex.ObjetoImpuestoId = 2;
					ex.TasaOCuota = 0m;
					ex.TipoImpuestoId = 2;
					ex.TipoFactorId = 3;
					ex.ImporteDR = 0m;
					new BusFacturas().AgregaComprobantesFiscalesEgresosDatosAdicionales(ex);
				}
				ImprimeCFDIsFlujoEgresos vImprime = new ImprimeCFDIsFlujoEgresos(xmls, true, false, tstxtNumPUEe.TextBox.Text, tstxtNumCPe.TextBox.Text, tstxtNumEge.TextBox.Text, tstxtNumNDe.TextBox.Text, tstxtNumTotale.TextBox.Text, tstxtSubtotalPUEe.TextBox.Text, tstxtSubtotalCPe.TextBox.Text, tstxtSubtotalEge.TextBox.Text, tstxtSubtotalNDe.TextBox.Text, tstxtSubtotalTotale.TextBox.Text, tstxtIvaPUEe.TextBox.Text, tstxtIvaCPe.TextBox.Text, tstxtIvaEge.TextBox.Text, tstxtIvaNDe.TextBox.Text, tstxtIvaTotale.TextBox.Text, tstxtRetencionesPUEe.TextBox.Text, tstxtRetencionesCPe.TextBox.Text, tstxtRetencionesEge.TextBox.Text, tstxtRetencionesNDe.TextBox.Text, tstxtRetencionesTotale.TextBox.Text, tstxtImportePUEe.TextBox.Text, tstxtImporteCPe.TextBox.Text, tstxtImporteEge.TextBox.Text, tstxtImporteNDe.TextBox.Text, tstxtImporteTotale.TextBox.Text);
				vImprime.Show();
			}
			catch (Exception ex2)
			{
				MuestraExcepcion(ex2);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnExportarDetallesCFDIsRecibidosPorRFC_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				List<EntFactura> xmls = new List<EntFactura>();
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				xmls = ListaComprobantesEgresos.Where((EntFactura P) => P.Deducible && ((P.MetodoPagoId == 1 && P.TipoComprobanteId == 1) || (P.TipoComprobanteId == 5 && P.FechaPago >= fechaDesde && P.FechaPago <= fechaHasta) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo))).ToList();
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesEgresosDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				foreach (EntFactura f in xmls)
				{
					f.SubTotal = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total);
					f.Descuento = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total);
					f.SubTotal0 = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 1).Sum((EntFactura P) => P.Total);
					f.Deduccion = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 3).Sum((EntFactura P) => P.Total);
					f.IVA = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.ImporteDR);
					f.Retenciones = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.ImporteDR);
					if (f.TipoComprobanteId == 2 && f.TipoEstructuraImpuestoId == 0)
					{
						f.SubTotal *= -1m;
						f.Descuento *= -1m;
						f.SubTotal0 *= -1m;
						f.Deduccion *= -1m;
						f.IVA *= -1m;
						f.IVARetenciones *= -1m;
						f.ISRRetenciones *= -1m;
						f.Total *= -1m;
						f.TipoEstructuraImpuestoId = 1;
					}
				}
				List<EntFactura> lstExento = xmls.Where((EntFactura a) => !listaComprobantesDA.Any((EntFactura b) => b.Id == a.Id)).ToList();
				foreach (EntFactura ex in lstExento.Where((EntFactura p) => p.ObjetoImpuesto02 > 0m).ToList())
				{
					xmls.Where((EntFactura P) => P.Id == ex.Id).First().Deduccion = ex.ObjetoImpuesto02;
					ex.Id = ex.Id;
					ex.TipoEstructuraImpuestoId = 1;
					ex.ObjetoImpuestoId = 2;
					ex.TasaOCuota = 0m;
					ex.TipoImpuestoId = 2;
					ex.TipoFactorId = 3;
					ex.ImporteDR = 0m;
					new BusFacturas().AgregaComprobantesFiscalesEgresosDatosAdicionales(ex);
				}
				ImprimeCFDIsFlujoEgresos vImprime = new ImprimeCFDIsFlujoEgresos(xmls, true, true, tstxtNumPUEe.TextBox.Text, tstxtNumCPe.TextBox.Text, tstxtNumEge.TextBox.Text, tstxtNumNDe.TextBox.Text, tstxtNumTotale.TextBox.Text, tstxtSubtotalPUEe.TextBox.Text, tstxtSubtotalCPe.TextBox.Text, tstxtSubtotalEge.TextBox.Text, tstxtSubtotalNDe.TextBox.Text, tstxtSubtotalTotale.TextBox.Text, tstxtIvaPUEe.TextBox.Text, tstxtIvaCPe.TextBox.Text, tstxtIvaEge.TextBox.Text, tstxtIvaNDe.TextBox.Text, tstxtIvaTotale.TextBox.Text, tstxtRetencionesPUEe.TextBox.Text, tstxtRetencionesCPe.TextBox.Text, tstxtRetencionesEge.TextBox.Text, tstxtRetencionesNDe.TextBox.Text, tstxtRetencionesTotale.TextBox.Text, tstxtImportePUEe.TextBox.Text, tstxtImporteCPe.TextBox.Text, tstxtImporteEge.TextBox.Text, tstxtImporteNDe.TextBox.Text, tstxtImporteTotale.TextBox.Text);
				vImprime.Show();
			}
			catch (Exception ex2)
			{
				MuestraExcepcion(ex2);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void txtActos16_TextChanged(object sender, EventArgs e)
		{
			try
			{
				txtSumaActos.Text = FormatoMoney(ConvierteTextoADecimal(txtActos16) + ConvierteTextoADecimal(txtActos8) + ConvierteTextoADecimal(txtActos0) + ConvierteTextoADecimal(txtActosExentos));
				if (ConvierteTextoADecimal(txtSumaActos) == 0m)
				{
					txtProporcionIvaAcreditable.Text = "1.00";
				}
				else
				{
					txtProporcionIvaAcreditable.Text = Math.Round((ConvierteTextoADecimal(txtActos16) + ConvierteTextoADecimal(txtActos8) + ConvierteTextoADecimal(txtActos0)) / ConvierteTextoADecimal(txtSumaActos), 4).ToString();
				}
				txtProporcionIvaAcreditableAE.Text = txtProporcionIvaAcreditable.Text;
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

		private void btnExportarDetallesCFDIsRecibidosPorRFCbatch_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				List<EntFactura> xmls = new List<EntFactura>();
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				xmls = ListaComprobantesEgresos.Where((EntFactura P) => P.Deducible && ((P.MetodoPagoId == 1 && P.TipoComprobanteId == 1) || (P.TipoComprobanteId == 5 && P.FechaPago >= fechaDesde && P.FechaPago <= fechaHasta) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo))).ToList();
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesEgresosDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				foreach (EntFactura f in xmls)
				{
					f.SubTotal = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total);
					f.Descuento = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total);
					f.SubTotal0 = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 1).Sum((EntFactura P) => P.Total);
					f.Deduccion = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 3).Sum((EntFactura P) => P.Total);
					f.IVA = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.ImporteDR);
					f.Retenciones = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.ImporteDR);
					if (f.TipoComprobanteId == 2 && f.TipoEstructuraImpuestoId == 0)
					{
						f.SubTotal *= -1m;
						f.Descuento *= -1m;
						f.SubTotal0 *= -1m;
						f.Deduccion *= -1m;
						f.IVA *= -1m;
						f.IVARetenciones *= -1m;
						f.ISRRetenciones *= -1m;
						f.Total *= -1m;
						f.TipoEstructuraImpuestoId = 1;
					}
				}
				List<EntFactura> lstExento = xmls.Where((EntFactura a) => !listaComprobantesDA.Any((EntFactura b) => b.Id == a.Id)).ToList();
				foreach (EntFactura ex in lstExento.Where((EntFactura p) => p.ObjetoImpuesto02 > 0m).ToList())
				{
					xmls.Where((EntFactura P) => P.Id == ex.Id).First().Deduccion = ex.ObjetoImpuesto02;
					ex.Id = ex.Id;
					ex.TipoEstructuraImpuestoId = 1;
					ex.ObjetoImpuestoId = 2;
					ex.TasaOCuota = 0m;
					ex.TipoImpuestoId = 2;
					ex.TipoFactorId = 3;
					ex.ImporteDR = 0m;
					new BusFacturas().AgregaComprobantesFiscalesEgresosDatosAdicionales(ex);
				}
				ImprimeCFDIsFlujoEgresosBatch vImprime = new ImprimeCFDIsFlujoEgresosBatch(xmls, true, true, tstxtNumPUEe.TextBox.Text, tstxtNumCPe.TextBox.Text, tstxtNumEge.TextBox.Text, tstxtNumNDe.TextBox.Text, tstxtNumTotale.TextBox.Text, tstxtSubtotalPUEe.TextBox.Text, tstxtSubtotalCPe.TextBox.Text, tstxtSubtotalEge.TextBox.Text, tstxtSubtotalNDe.TextBox.Text, tstxtSubtotalTotale.TextBox.Text, tstxtIvaPUEe.TextBox.Text, tstxtIvaCPe.TextBox.Text, tstxtIvaEge.TextBox.Text, tstxtIvaNDe.TextBox.Text, tstxtIvaTotale.TextBox.Text, tstxtRetencionesPUEe.TextBox.Text, tstxtRetencionesCPe.TextBox.Text, tstxtRetencionesEge.TextBox.Text, tstxtRetencionesNDe.TextBox.Text, tstxtRetencionesTotale.TextBox.Text, tstxtImportePUEe.TextBox.Text, tstxtImporteCPe.TextBox.Text, tstxtImporteEge.TextBox.Text, tstxtImporteNDe.TextBox.Text, tstxtImporteTotale.TextBox.Text);
				vImprime.Show();
			}
			catch (Exception ex2)
			{
				MuestraExcepcion(ex2);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void txtIVAPagarFavor_TextChanged(object sender, EventArgs e)
		{
		}

		private void btnBuscaEmpresa_Click(object sender, EventArgs e)
		{
			try
			{
				Program.EmpresaSeleccionada = SeleccionaEmpresa();
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.CalculoIVA));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gbInformacionCFDI40 = new System.Windows.Forms.GroupBox();
			this.flpObjetoImpuesto = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel56 = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.txtObjetoImpuesto01 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel57 = new System.Windows.Forms.FlowLayoutPanel();
			this.label12 = new System.Windows.Forms.Label();
			this.txtObjetoImpuesto02 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel58 = new System.Windows.Forms.FlowLayoutPanel();
			this.label49 = new System.Windows.Forms.Label();
			this.txtObjetoImpuesto03 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnExportarIVA = new System.Windows.Forms.Button();
			this.chkCalculoIvaRIF = new System.Windows.Forms.CheckBox();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flpRecibidos = new System.Windows.Forms.FlowLayoutPanel();
			this.label14 = new System.Windows.Forms.Label();
			this.flowLayoutPanel22 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel31 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel32 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel33 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel34 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel35 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImportePUEe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel23 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip8 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel36 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel37 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel38 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel39 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel40 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteCPe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel24 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip9 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel41 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel42 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel43 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel44 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel45 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteEge = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel25 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip10 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel46 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator37 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel47 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel48 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator39 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel49 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator40 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel50 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteNDe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel26 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip11 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel51 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator41 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel52 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator42 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel53 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator43 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel54 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator44 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel55 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteTotale = new System.Windows.Forms.ToolStripTextBox();
			this.pnlExportaDetallesCFDIsEgresos = new System.Windows.Forms.Panel();
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch = new System.Windows.Forms.Button();
			this.btnExportarDetallesCFDIsRecibidosPorRFC = new System.Windows.Forms.Button();
			this.btnExportarDetallesCFDIsRecibidos = new System.Windows.Forms.Button();
			this.btnDeshacerCaptura = new System.Windows.Forms.Button();
			this.flpCalculosIVA = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalIngresos = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVATrasladado = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel60 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaTrasladadoSinCFDI = new System.Windows.Forms.TextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.flowLayoutPanel61 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaTrasladadoSinCFDIresta = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVAretenido = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVAacreditableTotal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVAacreditable = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaAcreditableSinCFDI = new System.Windows.Forms.TextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.flowLayoutPanel59 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaAcreditableSinCFDIresta = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVAretenidoG = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.flowLayoutPanel20 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaRetenidoPagado = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVAacreditableCalculado = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.flowLayoutPanel21 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtProporcionIvaAcreditableAE = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.flowLayoutPanel55 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaFiscalAcreditableAE = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIVAPagarFavor = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbPagarFavor = new System.Windows.Forms.Label();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.flpCalculosIvaRif = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalIngresosFacturadosRif = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.flowLayoutPanel18 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosPublicoGeneral = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.flowLayoutPanel27 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosIngresosPG = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.flowLayoutPanel47 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosPublicoNoAcumulables = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.flowLayoutPanel28 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalIngresosPG = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.flowLayoutPanel29 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel30 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbTasaIVA = new System.Windows.Forms.ComboBox();
			this.label19 = new System.Windows.Forms.Label();
			this.flowLayoutPanel31 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaOperacionesPG = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.flowLayoutPanel32 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbPorcentajeReduccion = new System.Windows.Forms.ComboBox();
			this.label21 = new System.Windows.Forms.Label();
			this.flowLayoutPanel33 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaReducido = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.flowLayoutPanel35 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaTrasladadoOperacionesPG = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.flowLayoutPanel36 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel50 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCI = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.flowLayoutPanel48 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosIngresosCI = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.flowLayoutPanel34 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosNoAcumulablesCI = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.flowLayoutPanel51 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalIngresosCI = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.flowLayoutPanel49 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel37 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaTrasladadoOperacionesPG2 = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.flowLayoutPanel38 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaTrasladadoCFDI = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaTrasladadoTotal = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.flowLayoutPanel39 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel40 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaRetenidoRIF = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.flowLayoutPanel41 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel42 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaAcreditableCFDI = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.flowLayoutPanel52 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtroIvaAcreditable = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.flowLayoutPanel53 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaNoAcreditable = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.flowLayoutPanel54 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaAcreditableTotalRIF = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.flowLayoutPanel43 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtProporcionPorOperacionesPG = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.flowLayoutPanel44 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaFiscalAcreditable = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.flowLayoutPanel45 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel46 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIvaPorPagarAfavorRIF = new System.Windows.Forms.TextBox();
			this.lbIvaPorPagarAfavorRIF = new System.Windows.Forms.Label();
			this.flpEmitidos = new System.Windows.Forms.FlowLayoutPanel();
			this.label11 = new System.Windows.Forms.Label();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel17 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImportePUE = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel18 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteCP = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel20 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel21 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel22 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel23 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel24 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteEg = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel19 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel19 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteTotal = new System.Windows.Forms.ToolStripTextBox();
			this.pnlIngresosPgCi = new System.Windows.Forms.Panel();
			this.label34 = new System.Windows.Forms.Label();
			this.txtIngresosClientesIndividualesFlujo = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.txtIngresosPgFlujo = new System.Windows.Forms.TextBox();
			this.gbActos = new System.Windows.Forms.GroupBox();
			this.pnlActos = new System.Windows.Forms.Panel();
			this.txtSumaActos = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.txtProporcionIvaAcreditable = new System.Windows.Forms.TextBox();
			this.txtActos16 = new System.Windows.Forms.TextBox();
			this.txtActosExentos = new System.Windows.Forms.TextBox();
			this.label43 = new System.Windows.Forms.Label();
			this.txtActos8 = new System.Windows.Forms.TextBox();
			this.txtActos0 = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.pnlExportaDetallesCFDIs = new System.Windows.Forms.Panel();
			this.btnExportarDetallesCFDIs = new System.Windows.Forms.Button();
			this.tcCalculosIVA = new System.Windows.Forms.TabControl();
			this.tpImpresion = new System.Windows.Forms.TabPage();
			this.rvCalculoIVA = new Microsoft.Reporting.WinForms.ReportViewer();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.flpEmpresas = new System.Windows.Forms.FlowLayoutPanel();
			this.label24 = new System.Windows.Forms.Label();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tabPage1.SuspendLayout();
			this.gbInformacionCFDI40.SuspendLayout();
			this.flpObjetoImpuesto.SuspendLayout();
			this.flowLayoutPanel56.SuspendLayout();
			this.flowLayoutPanel57.SuspendLayout();
			this.flowLayoutPanel58.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flpRecibidos.SuspendLayout();
			this.flowLayoutPanel22.SuspendLayout();
			this.toolStrip7.SuspendLayout();
			this.flowLayoutPanel23.SuspendLayout();
			this.toolStrip8.SuspendLayout();
			this.flowLayoutPanel24.SuspendLayout();
			this.toolStrip9.SuspendLayout();
			this.flowLayoutPanel25.SuspendLayout();
			this.toolStrip10.SuspendLayout();
			this.flowLayoutPanel26.SuspendLayout();
			this.toolStrip11.SuspendLayout();
			this.pnlExportaDetallesCFDIsEgresos.SuspendLayout();
			this.flpCalculosIVA.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel60.SuspendLayout();
			this.flowLayoutPanel61.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.flowLayoutPanel15.SuspendLayout();
			this.flowLayoutPanel59.SuspendLayout();
			this.flowLayoutPanel13.SuspendLayout();
			this.flowLayoutPanel20.SuspendLayout();
			this.flowLayoutPanel5.SuspendLayout();
			this.flowLayoutPanel21.SuspendLayout();
			this.flowLayoutPanel55.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.flowLayoutPanel12.SuspendLayout();
			this.flpCalculosIvaRif.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.flowLayoutPanel18.SuspendLayout();
			this.flowLayoutPanel27.SuspendLayout();
			this.flowLayoutPanel47.SuspendLayout();
			this.flowLayoutPanel28.SuspendLayout();
			this.flowLayoutPanel30.SuspendLayout();
			this.flowLayoutPanel31.SuspendLayout();
			this.flowLayoutPanel32.SuspendLayout();
			this.flowLayoutPanel33.SuspendLayout();
			this.flowLayoutPanel35.SuspendLayout();
			this.flowLayoutPanel50.SuspendLayout();
			this.flowLayoutPanel48.SuspendLayout();
			this.flowLayoutPanel34.SuspendLayout();
			this.flowLayoutPanel51.SuspendLayout();
			this.flowLayoutPanel37.SuspendLayout();
			this.flowLayoutPanel38.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel40.SuspendLayout();
			this.flowLayoutPanel42.SuspendLayout();
			this.flowLayoutPanel52.SuspendLayout();
			this.flowLayoutPanel53.SuspendLayout();
			this.flowLayoutPanel54.SuspendLayout();
			this.flowLayoutPanel43.SuspendLayout();
			this.flowLayoutPanel44.SuspendLayout();
			this.flowLayoutPanel46.SuspendLayout();
			this.flpEmitidos.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel16.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.flowLayoutPanel17.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			this.flowLayoutPanel19.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.pnlIngresosPgCi.SuspendLayout();
			this.gbActos.SuspendLayout();
			this.pnlActos.SuspendLayout();
			this.pnlExportaDetallesCFDIs.SuspendLayout();
			this.tcCalculosIVA.SuspendLayout();
			this.tpImpresion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.flpEmpresas.SuspendLayout();
			base.SuspendLayout();
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(120, 8);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(613, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.tabPage1.Controls.Add(this.gbInformacionCFDI40);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1524, 850);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Cálculo de IVA ";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.gbInformacionCFDI40.Controls.Add(this.flpObjetoImpuesto);
			this.gbInformacionCFDI40.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.gbInformacionCFDI40.Location = new System.Drawing.Point(844, 8);
			this.gbInformacionCFDI40.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gbInformacionCFDI40.Name = "gbInformacionCFDI40";
			this.gbInformacionCFDI40.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gbInformacionCFDI40.Size = new System.Drawing.Size(830, 108);
			this.gbInformacionCFDI40.TabIndex = 147;
			this.gbInformacionCFDI40.TabStop = false;
			this.gbInformacionCFDI40.Text = "INFORMACIÓN DE CFDI 4.0 EMITIDOS";
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel56);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel57);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel58);
			this.flpObjetoImpuesto.Location = new System.Drawing.Point(8, 22);
			this.flpObjetoImpuesto.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flpObjetoImpuesto.Name = "flpObjetoImpuesto";
			this.flpObjetoImpuesto.Size = new System.Drawing.Size(843, 82);
			this.flpObjetoImpuesto.TabIndex = 137;
			this.flowLayoutPanel56.Controls.Add(this.label3);
			this.flowLayoutPanel56.Controls.Add(this.txtObjetoImpuesto01);
			this.flowLayoutPanel56.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel56.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel56.Location = new System.Drawing.Point(3, 5);
			this.flowLayoutPanel56.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel56.Name = "flowLayoutPanel56";
			this.flowLayoutPanel56.Size = new System.Drawing.Size(226, 74);
			this.flowLayoutPanel56.TabIndex = 0;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(204, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "01 - NO OBJETO DE IMPUESTO";
			this.txtObjetoImpuesto01.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto01.Location = new System.Drawing.Point(3, 20);
			this.txtObjetoImpuesto01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuesto01.Name = "txtObjetoImpuesto01";
			this.txtObjetoImpuesto01.ReadOnly = true;
			this.txtObjetoImpuesto01.Size = new System.Drawing.Size(168, 38);
			this.txtObjetoImpuesto01.TabIndex = 155;
			this.txtObjetoImpuesto01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flowLayoutPanel57.Controls.Add(this.label12);
			this.flowLayoutPanel57.Controls.Add(this.txtObjetoImpuesto02);
			this.flowLayoutPanel57.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel57.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel57.Location = new System.Drawing.Point(235, 5);
			this.flowLayoutPanel57.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel57.Name = "flowLayoutPanel57";
			this.flowLayoutPanel57.Size = new System.Drawing.Size(214, 74);
			this.flowLayoutPanel57.TabIndex = 1;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(185, 18);
			this.label12.TabIndex = 0;
			this.label12.Text = "02 - OBJETO DE IMPUESTO";
			this.txtObjetoImpuesto02.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto02.Location = new System.Drawing.Point(3, 20);
			this.txtObjetoImpuesto02.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuesto02.Name = "txtObjetoImpuesto02";
			this.txtObjetoImpuesto02.ReadOnly = true;
			this.txtObjetoImpuesto02.Size = new System.Drawing.Size(168, 38);
			this.txtObjetoImpuesto02.TabIndex = 155;
			this.txtObjetoImpuesto02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flowLayoutPanel58.Controls.Add(this.label49);
			this.flowLayoutPanel58.Controls.Add(this.txtObjetoImpuesto03);
			this.flowLayoutPanel58.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel58.Location = new System.Drawing.Point(455, 5);
			this.flowLayoutPanel58.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel58.Name = "flowLayoutPanel58";
			this.flowLayoutPanel58.Size = new System.Drawing.Size(382, 74);
			this.flowLayoutPanel58.TabIndex = 2;
			this.label49.AutoSize = true;
			this.label49.Font = new System.Drawing.Font("Microsoft Tai Le", 6.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label49.Location = new System.Drawing.Point(3, 0);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(340, 16);
			this.label49.TabIndex = 0;
			this.label49.Text = "03 - OBJETO DE IMPUESTO NO OBLIGADO AL DESGLOSE";
			this.txtObjetoImpuesto03.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto03.Location = new System.Drawing.Point(3, 18);
			this.txtObjetoImpuesto03.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuesto03.Name = "txtObjetoImpuesto03";
			this.txtObjetoImpuesto03.ReadOnly = true;
			this.txtObjetoImpuesto03.Size = new System.Drawing.Size(168, 38);
			this.txtObjetoImpuesto03.TabIndex = 155;
			this.txtObjetoImpuesto03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.panel1.Controls.Add(this.btnExportarIVA);
			this.panel1.Controls.Add(this.chkCalculoIvaRIF);
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Location = new System.Drawing.Point(9, 5);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(772, 98);
			this.panel1.TabIndex = 135;
			this.btnExportarIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnExportarIVA.BackColor = System.Drawing.Color.White;
			this.btnExportarIVA.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnExportarIVA.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarIVA.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarIVA.Image = LeeXML.Properties.Resources.ExportaPapel;
			this.btnExportarIVA.Location = new System.Drawing.Point(650, 6);
			this.btnExportarIVA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportarIVA.Name = "btnExportarIVA";
			this.btnExportarIVA.Size = new System.Drawing.Size(106, 88);
			this.btnExportarIVA.TabIndex = 138;
			this.btnExportarIVA.Text = "Exportar";
			this.btnExportarIVA.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarIVA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarIVA.UseVisualStyleBackColor = false;
			this.btnExportarIVA.Click += new System.EventHandler(btnExportarIVA_Click);
			this.chkCalculoIvaRIF.AutoSize = true;
			this.chkCalculoIvaRIF.Location = new System.Drawing.Point(224, 6);
			this.chkCalculoIvaRIF.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.chkCalculoIvaRIF.Name = "chkCalculoIvaRIF";
			this.chkCalculoIvaRIF.Size = new System.Drawing.Size(261, 22);
			this.chkCalculoIvaRIF.TabIndex = 137;
			this.chkCalculoIvaRIF.Text = "Régimen de Incorporación Fiscal (RIF)";
			this.chkCalculoIvaRIF.UseVisualStyleBackColor = true;
			this.chkCalculoIvaRIF.CheckedChanged += new System.EventHandler(chkCalculoIvaRIF_CheckedChanged);
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(532, 6);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(100, 88);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(160, 52);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(80, 22);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Periodo";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(248, 38);
			this.pnlPorMesVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(272, 52);
			this.pnlPorMesVentas.TabIndex = 41;
			this.cmbMesesComprobantes.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbMesesComprobantes.DisplayMember = "Descripcion";
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(14, 9);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(248, 33);
			this.cmbMesesComprobantes.TabIndex = 19;
			this.cmbMesesComprobantes.ValueMember = "Id";
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(148, 9);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(114, 33);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(9, 69);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(1504, 766);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage2.Controls.Add(this.flpRecibidos);
			this.tabPage2.Controls.Add(this.btnDeshacerCaptura);
			this.tabPage2.Controls.Add(this.flpCalculosIVA);
			this.tabPage2.Controls.Add(this.flpCalculosIvaRif);
			this.tabPage2.Controls.Add(this.flpEmitidos);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 31);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Size = new System.Drawing.Size(1496, 731);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Muestra Cálculo ";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flpRecibidos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpRecibidos.AutoScroll = true;
			this.flpRecibidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpRecibidos.Controls.Add(this.label14);
			this.flpRecibidos.Controls.Add(this.flowLayoutPanel22);
			this.flpRecibidos.Controls.Add(this.flowLayoutPanel23);
			this.flpRecibidos.Controls.Add(this.flowLayoutPanel24);
			this.flpRecibidos.Controls.Add(this.flowLayoutPanel25);
			this.flpRecibidos.Controls.Add(this.flowLayoutPanel26);
			this.flpRecibidos.Controls.Add(this.pnlExportaDetallesCFDIsEgresos);
			this.flpRecibidos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpRecibidos.Location = new System.Drawing.Point(830, 409);
			this.flpRecibidos.Margin = new System.Windows.Forms.Padding(2);
			this.flpRecibidos.Name = "flpRecibidos";
			this.flpRecibidos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpRecibidos.Size = new System.Drawing.Size(656, 287);
			this.flpRecibidos.TabIndex = 142;
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new System.Drawing.Point(3, 2);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(207, 23);
			this.label14.TabIndex = 141;
			this.label14.Text = "Flujo CFDI's RECIBIDOS";
			this.flowLayoutPanel22.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel22.Controls.Add(this.toolStrip7);
			this.flowLayoutPanel22.Location = new System.Drawing.Point(2, 27);
			this.flowLayoutPanel22.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel22.Name = "flowLayoutPanel22";
			this.flowLayoutPanel22.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel22.Size = new System.Drawing.Size(846, 36);
			this.flowLayoutPanel22.TabIndex = 135;
			this.toolStrip7.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel31, this.tstxtNumPUEe, this.toolStripSeparator25, this.toolStripLabel32, this.tstxtSubtotalPUEe, this.toolStripSeparator26, this.toolStripLabel33, this.tstxtIvaPUEe, this.toolStripSeparator27, this.toolStripLabel34,
				this.tstxtRetencionesPUEe, this.toolStripSeparator28, this.toolStripLabel35, this.tstxtImportePUEe
			});
			this.toolStrip7.Location = new System.Drawing.Point(0, 2);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip7.Size = new System.Drawing.Size(765, 31);
			this.toolStrip7.TabIndex = 2;
			this.toolStrip7.Text = "toolStrip7";
			this.toolStripLabel31.Name = "toolStripLabel31";
			this.toolStripLabel31.Size = new System.Drawing.Size(142, 26);
			this.toolStripLabel31.Text = "                   PUE:";
			this.tstxtNumPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUEe.Name = "tstxtNumPUEe";
			this.tstxtNumPUEe.ReadOnly = true;
			this.tstxtNumPUEe.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator25.Name = "toolStripSeparator25";
			this.toolStripSeparator25.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel32.Name = "toolStripLabel32";
			this.toolStripLabel32.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel32.Text = "SubTotal:";
			this.tstxtSubtotalPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUEe.Name = "tstxtSubtotalPUEe";
			this.tstxtSubtotalPUEe.ReadOnly = true;
			this.tstxtSubtotalPUEe.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator26.Name = "toolStripSeparator26";
			this.toolStripSeparator26.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel33.Name = "toolStripLabel33";
			this.toolStripLabel33.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel33.Text = "I.V.A:";
			this.tstxtIvaPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUEe.Name = "tstxtIvaPUEe";
			this.tstxtIvaPUEe.ReadOnly = true;
			this.tstxtIvaPUEe.Size = new System.Drawing.Size(106, 31);
			this.tstxtIvaPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator27.Name = "toolStripSeparator27";
			this.toolStripSeparator27.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel34.Name = "toolStripLabel34";
			this.toolStripLabel34.Size = new System.Drawing.Size(123, 26);
			this.toolStripLabel34.Text = " IVA Retenido:";
			this.tstxtRetencionesPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUEe.Name = "tstxtRetencionesPUEe";
			this.tstxtRetencionesPUEe.ReadOnly = true;
			this.tstxtRetencionesPUEe.Size = new System.Drawing.Size(44, 31);
			this.tstxtRetencionesPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator28.Name = "toolStripSeparator28";
			this.toolStripSeparator28.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel35.Name = "toolStripLabel35";
			this.toolStripLabel35.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel35.Text = "Total:";
			this.toolStripLabel35.Visible = false;
			this.tstxtImportePUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImportePUEe.Name = "tstxtImportePUEe";
			this.tstxtImportePUEe.ReadOnly = true;
			this.tstxtImportePUEe.Size = new System.Drawing.Size(73, 31);
			this.tstxtImportePUEe.Visible = false;
			this.flowLayoutPanel23.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel23.Controls.Add(this.toolStrip8);
			this.flowLayoutPanel23.Location = new System.Drawing.Point(2, 67);
			this.flowLayoutPanel23.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel23.Name = "flowLayoutPanel23";
			this.flowLayoutPanel23.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel23.Size = new System.Drawing.Size(846, 36);
			this.flowLayoutPanel23.TabIndex = 136;
			this.toolStrip8.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel36, this.tstxtNumCPe, this.toolStripSeparator29, this.toolStripLabel37, this.tstxtSubtotalCPe, this.toolStripSeparator30, this.toolStripLabel38, this.tstxtIvaCPe, this.toolStripSeparator31, this.toolStripLabel39,
				this.tstxtRetencionesCPe, this.toolStripSeparator32, this.toolStripLabel40, this.tstxtImporteCPe
			});
			this.toolStrip8.Location = new System.Drawing.Point(0, 2);
			this.toolStrip8.Name = "toolStrip8";
			this.toolStrip8.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip8.Size = new System.Drawing.Size(765, 31);
			this.toolStrip8.TabIndex = 2;
			this.toolStrip8.Text = "toolStrip8";
			this.toolStripLabel36.Name = "toolStripLabel36";
			this.toolStripLabel36.Size = new System.Drawing.Size(142, 26);
			this.toolStripLabel36.Text = "                     CP:";
			this.tstxtNumCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumCPe.Name = "tstxtNumCPe";
			this.tstxtNumCPe.ReadOnly = true;
			this.tstxtNumCPe.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator29.Name = "toolStripSeparator29";
			this.toolStripSeparator29.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel37.Name = "toolStripLabel37";
			this.toolStripLabel37.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel37.Text = "SubTotal:";
			this.tstxtSubtotalCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalCPe.Name = "tstxtSubtotalCPe";
			this.tstxtSubtotalCPe.ReadOnly = true;
			this.tstxtSubtotalCPe.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator30.Name = "toolStripSeparator30";
			this.toolStripSeparator30.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel38.Name = "toolStripLabel38";
			this.toolStripLabel38.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel38.Text = "I.V.A:";
			this.tstxtIvaCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaCPe.Name = "tstxtIvaCPe";
			this.tstxtIvaCPe.ReadOnly = true;
			this.tstxtIvaCPe.Size = new System.Drawing.Size(106, 31);
			this.tstxtIvaCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator31.Name = "toolStripSeparator31";
			this.toolStripSeparator31.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel39.Name = "toolStripLabel39";
			this.toolStripLabel39.Size = new System.Drawing.Size(123, 26);
			this.toolStripLabel39.Text = " IVA Retenido:";
			this.tstxtRetencionesCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCPe.Name = "tstxtRetencionesCPe";
			this.tstxtRetencionesCPe.ReadOnly = true;
			this.tstxtRetencionesCPe.Size = new System.Drawing.Size(44, 31);
			this.tstxtRetencionesCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator32.Name = "toolStripSeparator32";
			this.toolStripSeparator32.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel40.Name = "toolStripLabel40";
			this.toolStripLabel40.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel40.Text = "Total:";
			this.toolStripLabel40.Visible = false;
			this.tstxtImporteCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporteCPe.Name = "tstxtImporteCPe";
			this.tstxtImporteCPe.ReadOnly = true;
			this.tstxtImporteCPe.Size = new System.Drawing.Size(73, 31);
			this.tstxtImporteCPe.Visible = false;
			this.flowLayoutPanel24.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel24.Controls.Add(this.toolStrip9);
			this.flowLayoutPanel24.Location = new System.Drawing.Point(2, 107);
			this.flowLayoutPanel24.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel24.Name = "flowLayoutPanel24";
			this.flowLayoutPanel24.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel24.Size = new System.Drawing.Size(846, 36);
			this.flowLayoutPanel24.TabIndex = 138;
			this.toolStrip9.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel41, this.tstxtNumEge, this.toolStripSeparator33, this.toolStripLabel42, this.tstxtSubtotalEge, this.toolStripSeparator34, this.toolStripLabel43, this.tstxtIvaEge, this.toolStripSeparator35, this.toolStripLabel44,
				this.tstxtRetencionesEge, this.toolStripSeparator36, this.toolStripLabel45, this.tstxtImporteEge
			});
			this.toolStrip9.Location = new System.Drawing.Point(0, 2);
			this.toolStrip9.Name = "toolStrip9";
			this.toolStrip9.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip9.Size = new System.Drawing.Size(763, 31);
			this.toolStrip9.TabIndex = 2;
			this.toolStrip9.Text = "toolStrip9";
			this.toolStripLabel41.Name = "toolStripLabel41";
			this.toolStripLabel41.Size = new System.Drawing.Size(140, 26);
			this.toolStripLabel41.Text = "          - Egresos:";
			this.tstxtNumEge.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumEge.Name = "tstxtNumEge";
			this.tstxtNumEge.ReadOnly = true;
			this.tstxtNumEge.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator33.Name = "toolStripSeparator33";
			this.toolStripSeparator33.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel42.Name = "toolStripLabel42";
			this.toolStripLabel42.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel42.Text = "SubTotal:";
			this.tstxtSubtotalEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEge.Name = "tstxtSubtotalEge";
			this.tstxtSubtotalEge.ReadOnly = true;
			this.tstxtSubtotalEge.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator34.Name = "toolStripSeparator34";
			this.toolStripSeparator34.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel43.Name = "toolStripLabel43";
			this.toolStripLabel43.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel43.Text = "I.V.A:";
			this.tstxtIvaEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEge.Name = "tstxtIvaEge";
			this.tstxtIvaEge.ReadOnly = true;
			this.tstxtIvaEge.Size = new System.Drawing.Size(106, 31);
			this.tstxtIvaEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator35.Name = "toolStripSeparator35";
			this.toolStripSeparator35.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel44.Name = "toolStripLabel44";
			this.toolStripLabel44.Size = new System.Drawing.Size(123, 26);
			this.toolStripLabel44.Text = " IVA Retenido:";
			this.tstxtRetencionesEge.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesEge.Name = "tstxtRetencionesEge";
			this.tstxtRetencionesEge.ReadOnly = true;
			this.tstxtRetencionesEge.Size = new System.Drawing.Size(44, 31);
			this.tstxtRetencionesEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator36.Name = "toolStripSeparator36";
			this.toolStripSeparator36.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel45.Name = "toolStripLabel45";
			this.toolStripLabel45.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel45.Text = "Total:";
			this.toolStripLabel45.Visible = false;
			this.tstxtImporteEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteEge.Name = "tstxtImporteEge";
			this.tstxtImporteEge.ReadOnly = true;
			this.tstxtImporteEge.Size = new System.Drawing.Size(73, 31);
			this.tstxtImporteEge.Visible = false;
			this.flowLayoutPanel25.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel25.Controls.Add(this.toolStrip10);
			this.flowLayoutPanel25.Location = new System.Drawing.Point(2, 147);
			this.flowLayoutPanel25.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel25.Name = "flowLayoutPanel25";
			this.flowLayoutPanel25.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel25.Size = new System.Drawing.Size(846, 36);
			this.flowLayoutPanel25.TabIndex = 139;
			this.toolStrip10.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel46, this.tstxtNumNDe, this.toolStripSeparator37, this.toolStripLabel47, this.tstxtSubtotalNDe, this.toolStripSeparator38, this.toolStripLabel48, this.tstxtIvaNDe, this.toolStripSeparator39, this.toolStripLabel49,
				this.tstxtRetencionesNDe, this.toolStripSeparator40, this.toolStripLabel50, this.tstxtImporteNDe
			});
			this.toolStrip10.Location = new System.Drawing.Point(0, 2);
			this.toolStrip10.Name = "toolStrip10";
			this.toolStrip10.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip10.Size = new System.Drawing.Size(759, 31);
			this.toolStrip10.TabIndex = 2;
			this.toolStrip10.Text = "toolStrip10";
			this.toolStripLabel46.Name = "toolStripLabel46";
			this.toolStripLabel46.Size = new System.Drawing.Size(136, 26);
			this.toolStripLabel46.Text = "- No Deducible:";
			this.tstxtNumNDe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumNDe.Name = "tstxtNumNDe";
			this.tstxtNumNDe.ReadOnly = true;
			this.tstxtNumNDe.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator37.Name = "toolStripSeparator37";
			this.toolStripSeparator37.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel47.Name = "toolStripLabel47";
			this.toolStripLabel47.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel47.Text = "SubTotal:";
			this.tstxtSubtotalNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalNDe.Name = "tstxtSubtotalNDe";
			this.tstxtSubtotalNDe.ReadOnly = true;
			this.tstxtSubtotalNDe.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator38.Name = "toolStripSeparator38";
			this.toolStripSeparator38.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel48.Name = "toolStripLabel48";
			this.toolStripLabel48.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel48.Text = "I.V.A:";
			this.tstxtIvaNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaNDe.Name = "tstxtIvaNDe";
			this.tstxtIvaNDe.ReadOnly = true;
			this.tstxtIvaNDe.Size = new System.Drawing.Size(106, 31);
			this.tstxtIvaNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator39.Name = "toolStripSeparator39";
			this.toolStripSeparator39.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel49.Name = "toolStripLabel49";
			this.toolStripLabel49.Size = new System.Drawing.Size(123, 26);
			this.toolStripLabel49.Text = " IVA Retenido:";
			this.tstxtRetencionesNDe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesNDe.Name = "tstxtRetencionesNDe";
			this.tstxtRetencionesNDe.ReadOnly = true;
			this.tstxtRetencionesNDe.Size = new System.Drawing.Size(44, 31);
			this.tstxtRetencionesNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator40.Name = "toolStripSeparator40";
			this.toolStripSeparator40.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel50.Name = "toolStripLabel50";
			this.toolStripLabel50.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel50.Text = "Total:";
			this.toolStripLabel50.Visible = false;
			this.tstxtImporteNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteNDe.Name = "tstxtImporteNDe";
			this.tstxtImporteNDe.ReadOnly = true;
			this.tstxtImporteNDe.Size = new System.Drawing.Size(73, 31);
			this.tstxtImporteNDe.Visible = false;
			this.flowLayoutPanel26.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel26.Controls.Add(this.toolStrip11);
			this.flowLayoutPanel26.Location = new System.Drawing.Point(2, 187);
			this.flowLayoutPanel26.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel26.Name = "flowLayoutPanel26";
			this.flowLayoutPanel26.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel26.Size = new System.Drawing.Size(846, 36);
			this.flowLayoutPanel26.TabIndex = 137;
			this.toolStrip11.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel51, this.tstxtNumTotale, this.toolStripSeparator41, this.toolStripLabel52, this.tstxtSubtotalTotale, this.toolStripSeparator42, this.toolStripLabel53, this.tstxtIvaTotale, this.toolStripSeparator43, this.toolStripLabel54,
				this.tstxtRetencionesTotale, this.toolStripSeparator44, this.toolStripLabel55, this.tstxtImporteTotale
			});
			this.toolStrip11.Location = new System.Drawing.Point(0, 2);
			this.toolStrip11.Name = "toolStrip11";
			this.toolStrip11.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip11.Size = new System.Drawing.Size(754, 31);
			this.toolStrip11.TabIndex = 2;
			this.toolStrip11.Text = "toolStrip11";
			this.toolStripLabel51.Name = "toolStripLabel51";
			this.toolStripLabel51.Size = new System.Drawing.Size(136, 26);
			this.toolStripLabel51.Text = "        Total Flujo:";
			this.tstxtNumTotale.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumTotale.Name = "tstxtNumTotale";
			this.tstxtNumTotale.ReadOnly = true;
			this.tstxtNumTotale.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator41.Name = "toolStripSeparator41";
			this.toolStripSeparator41.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel52.Name = "toolStripLabel52";
			this.toolStripLabel52.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel52.Text = "SubTotal:";
			this.tstxtSubtotalTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotale.Name = "tstxtSubtotalTotale";
			this.tstxtSubtotalTotale.ReadOnly = true;
			this.tstxtSubtotalTotale.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator42.Name = "toolStripSeparator42";
			this.toolStripSeparator42.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel53.Name = "toolStripLabel53";
			this.toolStripLabel53.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel53.Text = "I.V.A:";
			this.tstxtIvaTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotale.Name = "tstxtIvaTotale";
			this.tstxtIvaTotale.ReadOnly = true;
			this.tstxtIvaTotale.Size = new System.Drawing.Size(106, 31);
			this.tstxtIvaTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator43.Name = "toolStripSeparator43";
			this.toolStripSeparator43.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel54.Name = "toolStripLabel54";
			this.toolStripLabel54.Size = new System.Drawing.Size(118, 26);
			this.toolStripLabel54.Text = "IVA Retenido:";
			this.tstxtRetencionesTotale.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotale.Name = "tstxtRetencionesTotale";
			this.tstxtRetencionesTotale.ReadOnly = true;
			this.tstxtRetencionesTotale.Size = new System.Drawing.Size(44, 31);
			this.tstxtRetencionesTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator44.Name = "toolStripSeparator44";
			this.toolStripSeparator44.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel55.Name = "toolStripLabel55";
			this.toolStripLabel55.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel55.Text = "Total:";
			this.toolStripLabel55.Visible = false;
			this.tstxtImporteTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteTotale.Name = "tstxtImporteTotale";
			this.tstxtImporteTotale.ReadOnly = true;
			this.tstxtImporteTotale.Size = new System.Drawing.Size(73, 31);
			this.tstxtImporteTotale.Visible = false;
			this.pnlExportaDetallesCFDIsEgresos.Controls.Add(this.btnExportarDetallesCFDIsRecibidosPorRFCbatch);
			this.pnlExportaDetallesCFDIsEgresos.Controls.Add(this.btnExportarDetallesCFDIsRecibidosPorRFC);
			this.pnlExportaDetallesCFDIsEgresos.Controls.Add(this.btnExportarDetallesCFDIsRecibidos);
			this.pnlExportaDetallesCFDIsEgresos.Location = new System.Drawing.Point(853, 7);
			this.pnlExportaDetallesCFDIsEgresos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.pnlExportaDetallesCFDIsEgresos.Name = "pnlExportaDetallesCFDIsEgresos";
			this.pnlExportaDetallesCFDIsEgresos.Size = new System.Drawing.Size(170, 249);
			this.pnlExportaDetallesCFDIsEgresos.TabIndex = 145;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.BackColor = System.Drawing.Color.White;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Location = new System.Drawing.Point(4, 200);
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Name = "btnExportarDetallesCFDIsRecibidosPorRFCbatch";
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Size = new System.Drawing.Size(154, 49);
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.TabIndex = 147;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Text = "Información Batch";
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.UseVisualStyleBackColor = false;
			this.btnExportarDetallesCFDIsRecibidosPorRFCbatch.Click += new System.EventHandler(btnExportarDetallesCFDIsRecibidosPorRFCbatch_Click);
			this.btnExportarDetallesCFDIsRecibidosPorRFC.BackColor = System.Drawing.Color.White;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Location = new System.Drawing.Point(4, 111);
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Name = "btnExportarDetallesCFDIsRecibidosPorRFC";
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Size = new System.Drawing.Size(154, 88);
			this.btnExportarDetallesCFDIsRecibidosPorRFC.TabIndex = 146;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Text = "Detalles CFDI'S 4.0 Por RFC";
			this.btnExportarDetallesCFDIsRecibidosPorRFC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.UseVisualStyleBackColor = false;
			this.btnExportarDetallesCFDIsRecibidosPorRFC.Click += new System.EventHandler(btnExportarDetallesCFDIsRecibidosPorRFC_Click);
			this.btnExportarDetallesCFDIsRecibidos.BackColor = System.Drawing.Color.White;
			this.btnExportarDetallesCFDIsRecibidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportarDetallesCFDIsRecibidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarDetallesCFDIsRecibidos.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarDetallesCFDIsRecibidos.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportarDetallesCFDIsRecibidos.Location = new System.Drawing.Point(4, 22);
			this.btnExportarDetallesCFDIsRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportarDetallesCFDIsRecibidos.Name = "btnExportarDetallesCFDIsRecibidos";
			this.btnExportarDetallesCFDIsRecibidos.Size = new System.Drawing.Size(154, 88);
			this.btnExportarDetallesCFDIsRecibidos.TabIndex = 145;
			this.btnExportarDetallesCFDIsRecibidos.Text = "Detalles CFDI'S 4.0";
			this.btnExportarDetallesCFDIsRecibidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarDetallesCFDIsRecibidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarDetallesCFDIsRecibidos.UseVisualStyleBackColor = false;
			this.btnExportarDetallesCFDIsRecibidos.Click += new System.EventHandler(btnExportarDetallesCFDIsRecibidos_Click);
			this.btnDeshacerCaptura.BackColor = System.Drawing.Color.White;
			this.btnDeshacerCaptura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnDeshacerCaptura.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeshacerCaptura.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnDeshacerCaptura.Image = LeeXML.Properties.Resources.borrar_white;
			this.btnDeshacerCaptura.Location = new System.Drawing.Point(722, 9);
			this.btnDeshacerCaptura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnDeshacerCaptura.Name = "btnDeshacerCaptura";
			this.btnDeshacerCaptura.Size = new System.Drawing.Size(100, 88);
			this.btnDeshacerCaptura.TabIndex = 144;
			this.btnDeshacerCaptura.Text = "Deshacer Captura";
			this.btnDeshacerCaptura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnDeshacerCaptura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeshacerCaptura.UseVisualStyleBackColor = false;
			this.btnDeshacerCaptura.Visible = false;
			this.btnDeshacerCaptura.Click += new System.EventHandler(btnDeshacerCaptura_Click);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel6);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel1);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel60);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel61);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel3);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel4);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel7);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel11);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel15);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel59);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel13);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel20);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel5);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel21);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel55);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel8);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel9);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel12);
			this.flpCalculosIVA.Controls.Add(this.flowLayoutPanel14);
			this.flpCalculosIVA.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpCalculosIVA.Location = new System.Drawing.Point(3, 8);
			this.flpCalculosIVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flpCalculosIVA.Name = "flpCalculosIVA";
			this.flpCalculosIVA.Size = new System.Drawing.Size(646, 715);
			this.flpCalculosIVA.TabIndex = 137;
			this.flowLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel6.Controls.Add(this.txtTotalIngresos);
			this.flowLayoutPanel6.Controls.Add(this.label6);
			this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 2);
			this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel6.TabIndex = 0;
			this.txtTotalIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalIngresos.Location = new System.Drawing.Point(447, 2);
			this.txtTotalIngresos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTotalIngresos.Name = "txtTotalIngresos";
			this.txtTotalIngresos.ReadOnly = true;
			this.txtTotalIngresos.Size = new System.Drawing.Size(176, 28);
			this.txtTotalIngresos.TabIndex = 1;
			this.txtTotalIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(154, 8);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(287, 18);
			this.label6.TabIndex = 0;
			this.label6.Text = "TOTAL DE INGRESOS PARA IVA SEGÚN CFDI:";
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.txtIVATrasladado);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 44);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel1.TabIndex = 0;
			this.txtIVATrasladado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVATrasladado.Location = new System.Drawing.Point(447, 2);
			this.txtIVATrasladado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVATrasladado.Name = "txtIVATrasladado";
			this.txtIVATrasladado.ReadOnly = true;
			this.txtIVATrasladado.Size = new System.Drawing.Size(176, 28);
			this.txtIVATrasladado.TabIndex = 1;
			this.txtIVATrasladado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(235, 8);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(206, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "IVA TRASLADADO SEGÚN CFDI:";
			this.flowLayoutPanel60.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel60.Controls.Add(this.txtIvaTrasladadoSinCFDI);
			this.flowLayoutPanel60.Controls.Add(this.label52);
			this.flowLayoutPanel60.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel60.Location = new System.Drawing.Point(3, 86);
			this.flowLayoutPanel60.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel60.Name = "flowLayoutPanel60";
			this.flowLayoutPanel60.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel60.TabIndex = 152;
			this.txtIvaTrasladadoSinCFDI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaTrasladadoSinCFDI.Location = new System.Drawing.Point(493, 2);
			this.txtIvaTrasladadoSinCFDI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaTrasladadoSinCFDI.Name = "txtIvaTrasladadoSinCFDI";
			this.txtIvaTrasladadoSinCFDI.Size = new System.Drawing.Size(130, 28);
			this.txtIvaTrasladadoSinCFDI.TabIndex = 1;
			this.txtIvaTrasladadoSinCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaTrasladadoSinCFDI.TextChanged += new System.EventHandler(txtIVACaptura_TextChanged);
			this.txtIvaTrasladadoSinCFDI.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(285, 8);
			this.label52.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(202, 18);
			this.label52.TabIndex = 5;
			this.label52.Text = "(+) IVA TRASLADADO SIN CFDI";
			this.flowLayoutPanel61.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel61.Controls.Add(this.txtIvaTrasladadoSinCFDIresta);
			this.flowLayoutPanel61.Controls.Add(this.label53);
			this.flowLayoutPanel61.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel61.Location = new System.Drawing.Point(3, 128);
			this.flowLayoutPanel61.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel61.Name = "flowLayoutPanel61";
			this.flowLayoutPanel61.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel61.TabIndex = 153;
			this.txtIvaTrasladadoSinCFDIresta.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaTrasladadoSinCFDIresta.Location = new System.Drawing.Point(493, 2);
			this.txtIvaTrasladadoSinCFDIresta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaTrasladadoSinCFDIresta.Name = "txtIvaTrasladadoSinCFDIresta";
			this.txtIvaTrasladadoSinCFDIresta.Size = new System.Drawing.Size(130, 28);
			this.txtIvaTrasladadoSinCFDIresta.TabIndex = 2;
			this.txtIvaTrasladadoSinCFDIresta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaTrasladadoSinCFDIresta.TextChanged += new System.EventHandler(txtIVACaptura_TextChanged);
			this.txtIvaTrasladadoSinCFDIresta.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(289, 8);
			this.label53.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(198, 18);
			this.label53.TabIndex = 7;
			this.label53.Text = "(-) IVA TRASLADADO SIN CFDI";
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel3.Controls.Add(this.txtIVAretenido);
			this.flowLayoutPanel3.Controls.Add(this.label4);
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 170);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel3.TabIndex = 1;
			this.txtIVAretenido.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVAretenido.Location = new System.Drawing.Point(447, 2);
			this.txtIVAretenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVAretenido.Name = "txtIVAretenido";
			this.txtIVAretenido.ReadOnly = true;
			this.txtIVAretenido.Size = new System.Drawing.Size(176, 28);
			this.txtIVAretenido.TabIndex = 1;
			this.txtIVAretenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(240, 8);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(201, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "(-) IVA RETENIDO SEGÚN CFDI:";
			this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel4.Controls.Add(this.txtIVAacreditableTotal);
			this.flowLayoutPanel4.Controls.Add(this.label5);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 212);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel4.TabIndex = 2;
			this.txtIVAacreditableTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVAacreditableTotal.Location = new System.Drawing.Point(447, 2);
			this.txtIVAacreditableTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVAacreditableTotal.Name = "txtIVAacreditableTotal";
			this.txtIVAacreditableTotal.ReadOnly = true;
			this.txtIVAacreditableTotal.Size = new System.Drawing.Size(176, 28);
			this.txtIVAacreditableTotal.TabIndex = 1;
			this.txtIVAacreditableTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(254, 8);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(187, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "(-) IVA FISCAL ACREDITABLE:";
			this.flowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel7.Location = new System.Drawing.Point(3, 254);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Size = new System.Drawing.Size(626, 14);
			this.flowLayoutPanel7.TabIndex = 144;
			this.flowLayoutPanel11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel11.Controls.Add(this.txtIVAacreditable);
			this.flowLayoutPanel11.Controls.Add(this.label8);
			this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel11.Location = new System.Drawing.Point(3, 272);
			this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel11.Name = "flowLayoutPanel11";
			this.flowLayoutPanel11.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel11.TabIndex = 3;
			this.txtIVAacreditable.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVAacreditable.Location = new System.Drawing.Point(493, 2);
			this.txtIVAacreditable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVAacreditable.Name = "txtIVAacreditable";
			this.txtIVAacreditable.ReadOnly = true;
			this.txtIVAacreditable.Size = new System.Drawing.Size(130, 28);
			this.txtIVAacreditable.TabIndex = 1;
			this.txtIVAacreditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(368, 8);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(119, 18);
			this.label8.TabIndex = 0;
			this.label8.Text = "IVA ACREDITABLE";
			this.flowLayoutPanel15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel15.Controls.Add(this.txtIvaAcreditableSinCFDI);
			this.flowLayoutPanel15.Controls.Add(this.label50);
			this.flowLayoutPanel15.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel15.Location = new System.Drawing.Point(3, 314);
			this.flowLayoutPanel15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel15.Name = "flowLayoutPanel15";
			this.flowLayoutPanel15.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel15.TabIndex = 149;
			this.txtIvaAcreditableSinCFDI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaAcreditableSinCFDI.Location = new System.Drawing.Point(493, 2);
			this.txtIvaAcreditableSinCFDI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaAcreditableSinCFDI.Name = "txtIvaAcreditableSinCFDI";
			this.txtIvaAcreditableSinCFDI.Size = new System.Drawing.Size(130, 28);
			this.txtIvaAcreditableSinCFDI.TabIndex = 3;
			this.txtIvaAcreditableSinCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaAcreditableSinCFDI.TextChanged += new System.EventHandler(txtIVACaptura_TextChanged);
			this.txtIvaAcreditableSinCFDI.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(287, 8);
			this.label50.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(200, 18);
			this.label50.TabIndex = 3;
			this.label50.Text = "(+) IVA ACREDITABLE SIN CFDI";
			this.flowLayoutPanel59.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel59.Controls.Add(this.txtIvaAcreditableSinCFDIresta);
			this.flowLayoutPanel59.Controls.Add(this.label51);
			this.flowLayoutPanel59.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel59.Location = new System.Drawing.Point(3, 356);
			this.flowLayoutPanel59.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel59.Name = "flowLayoutPanel59";
			this.flowLayoutPanel59.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel59.TabIndex = 151;
			this.txtIvaAcreditableSinCFDIresta.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaAcreditableSinCFDIresta.Location = new System.Drawing.Point(493, 2);
			this.txtIvaAcreditableSinCFDIresta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaAcreditableSinCFDIresta.Name = "txtIvaAcreditableSinCFDIresta";
			this.txtIvaAcreditableSinCFDIresta.Size = new System.Drawing.Size(130, 28);
			this.txtIvaAcreditableSinCFDIresta.TabIndex = 4;
			this.txtIvaAcreditableSinCFDIresta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaAcreditableSinCFDIresta.TextChanged += new System.EventHandler(txtIVACaptura_TextChanged);
			this.txtIvaAcreditableSinCFDIresta.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(291, 8);
			this.label51.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(196, 18);
			this.label51.TabIndex = 5;
			this.label51.Text = "(-) IVA ACREDITABLE SIN CFDI";
			this.flowLayoutPanel13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel13.Controls.Add(this.txtIVAretenidoG);
			this.flowLayoutPanel13.Controls.Add(this.label9);
			this.flowLayoutPanel13.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel13.Location = new System.Drawing.Point(3, 398);
			this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel13.Name = "flowLayoutPanel13";
			this.flowLayoutPanel13.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel13.TabIndex = 142;
			this.txtIVAretenidoG.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVAretenidoG.Location = new System.Drawing.Point(493, 2);
			this.txtIVAretenidoG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVAretenidoG.Name = "txtIVAretenidoG";
			this.txtIVAretenidoG.ReadOnly = true;
			this.txtIVAretenidoG.Size = new System.Drawing.Size(130, 28);
			this.txtIVAretenidoG.TabIndex = 1;
			this.txtIVAretenidoG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(292, 8);
			this.label9.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(195, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "(-) IVA RETENIDO DE GASTOS:";
			this.flowLayoutPanel20.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel20.Controls.Add(this.txtIvaRetenidoPagado);
			this.flowLayoutPanel20.Controls.Add(this.label13);
			this.flowLayoutPanel20.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel20.Location = new System.Drawing.Point(3, 440);
			this.flowLayoutPanel20.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel20.Name = "flowLayoutPanel20";
			this.flowLayoutPanel20.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel20.TabIndex = 150;
			this.txtIvaRetenidoPagado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaRetenidoPagado.Location = new System.Drawing.Point(493, 2);
			this.txtIvaRetenidoPagado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaRetenidoPagado.Name = "txtIvaRetenidoPagado";
			this.txtIvaRetenidoPagado.Size = new System.Drawing.Size(130, 28);
			this.txtIvaRetenidoPagado.TabIndex = 5;
			this.txtIvaRetenidoPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaRetenidoPagado.TextChanged += new System.EventHandler(txtIVACaptura_TextChanged);
			this.txtIvaRetenidoPagado.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(303, 8);
			this.label13.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(184, 18);
			this.label13.TabIndex = 0;
			this.label13.Text = "(+) IVA RETENIDO PAGADO:";
			this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel5.Controls.Add(this.txtIVAacreditableCalculado);
			this.flowLayoutPanel5.Controls.Add(this.label7);
			this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 482);
			this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel5.TabIndex = 143;
			this.txtIVAacreditableCalculado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVAacreditableCalculado.Location = new System.Drawing.Point(493, 2);
			this.txtIVAacreditableCalculado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVAacreditableCalculado.Name = "txtIVAacreditableCalculado";
			this.txtIVAacreditableCalculado.ReadOnly = true;
			this.txtIVAacreditableCalculado.Size = new System.Drawing.Size(130, 28);
			this.txtIVAacreditableCalculado.TabIndex = 1;
			this.txtIVAacreditableCalculado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(261, 8);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(226, 18);
			this.label7.TabIndex = 0;
			this.label7.Text = "(=) IVA ACREDITABLE SEGÚN CFDI:";
			this.flowLayoutPanel21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel21.Controls.Add(this.txtProporcionIvaAcreditableAE);
			this.flowLayoutPanel21.Controls.Add(this.label1);
			this.flowLayoutPanel21.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel21.Location = new System.Drawing.Point(3, 524);
			this.flowLayoutPanel21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel21.Name = "flowLayoutPanel21";
			this.flowLayoutPanel21.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel21.TabIndex = 145;
			this.txtProporcionIvaAcreditableAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtProporcionIvaAcreditableAE.Location = new System.Drawing.Point(493, 2);
			this.txtProporcionIvaAcreditableAE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtProporcionIvaAcreditableAE.Name = "txtProporcionIvaAcreditableAE";
			this.txtProporcionIvaAcreditableAE.Size = new System.Drawing.Size(130, 28);
			this.txtProporcionIvaAcreditableAE.TabIndex = 6;
			this.txtProporcionIvaAcreditableAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtProporcionIvaAcreditableAE.TextChanged += new System.EventHandler(txtIVACaptura_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(253, 8);
			this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(234, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "(X) PROPORCIÓN IVA ACREDITABLE:";
			this.flowLayoutPanel55.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel55.Controls.Add(this.txtIvaFiscalAcreditableAE);
			this.flowLayoutPanel55.Controls.Add(this.label48);
			this.flowLayoutPanel55.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel55.Location = new System.Drawing.Point(3, 566);
			this.flowLayoutPanel55.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel55.Name = "flowLayoutPanel55";
			this.flowLayoutPanel55.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel55.TabIndex = 145;
			this.txtIvaFiscalAcreditableAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaFiscalAcreditableAE.Location = new System.Drawing.Point(493, 2);
			this.txtIvaFiscalAcreditableAE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaFiscalAcreditableAE.Name = "txtIvaFiscalAcreditableAE";
			this.txtIvaFiscalAcreditableAE.ReadOnly = true;
			this.txtIvaFiscalAcreditableAE.Size = new System.Drawing.Size(130, 28);
			this.txtIvaFiscalAcreditableAE.TabIndex = 1;
			this.txtIvaFiscalAcreditableAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label48.AutoSize = true;
			this.label48.Location = new System.Drawing.Point(296, 8);
			this.label48.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(191, 18);
			this.label48.TabIndex = 0;
			this.label48.Text = "(=) IVA FISCAL ACREDITABLE:";
			this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel8.Location = new System.Drawing.Point(3, 608);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Size = new System.Drawing.Size(626, 14);
			this.flowLayoutPanel8.TabIndex = 145;
			this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel9.Controls.Add(this.txtIVAPagarFavor);
			this.flowLayoutPanel9.Controls.Add(this.label10);
			this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel9.Location = new System.Drawing.Point(3, 626);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel9.TabIndex = 146;
			this.txtIVAPagarFavor.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIVAPagarFavor.Location = new System.Drawing.Point(493, 2);
			this.txtIVAPagarFavor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIVAPagarFavor.Name = "txtIVAPagarFavor";
			this.txtIVAPagarFavor.ReadOnly = true;
			this.txtIVAPagarFavor.Size = new System.Drawing.Size(130, 28);
			this.txtIVAPagarFavor.TabIndex = 1;
			this.txtIVAPagarFavor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIVAPagarFavor.TextChanged += new System.EventHandler(txtIVAPagarFavor_TextChanged);
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(265, 8);
			this.label10.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(222, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "(=) IVA POR PAGAR/IVA A FAVOR:";
			this.flowLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel12.Controls.Add(this.lbPagarFavor);
			this.flowLayoutPanel12.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel12.Location = new System.Drawing.Point(3, 668);
			this.flowLayoutPanel12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel12.Name = "flowLayoutPanel12";
			this.flowLayoutPanel12.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel12.TabIndex = 147;
			this.lbPagarFavor.AutoSize = true;
			this.lbPagarFavor.Location = new System.Drawing.Point(609, 8);
			this.lbPagarFavor.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.lbPagarFavor.Name = "lbPagarFavor";
			this.lbPagarFavor.Size = new System.Drawing.Size(14, 18);
			this.lbPagarFavor.TabIndex = 0;
			this.lbPagarFavor.Text = "''";
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel14.Location = new System.Drawing.Point(635, 2);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel14.TabIndex = 148;
			this.flpCalculosIvaRif.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flpCalculosIvaRif.AutoScroll = true;
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel10);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel18);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel27);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel47);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel28);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel29);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel30);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel31);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel32);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel33);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel35);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel36);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel50);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel48);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel34);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel51);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel49);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel37);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel38);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel2);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel39);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel40);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel41);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel42);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel52);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel53);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel54);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel43);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel44);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel45);
			this.flpCalculosIvaRif.Controls.Add(this.flowLayoutPanel46);
			this.flpCalculosIvaRif.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpCalculosIvaRif.Location = new System.Drawing.Point(6, 8);
			this.flpCalculosIvaRif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flpCalculosIvaRif.Name = "flpCalculosIvaRif";
			this.flpCalculosIvaRif.Size = new System.Drawing.Size(714, 708);
			this.flpCalculosIvaRif.TabIndex = 143;
			this.flpCalculosIvaRif.Visible = false;
			this.flpCalculosIvaRif.WrapContents = false;
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.Controls.Add(this.txtTotalIngresosFacturadosRif);
			this.flowLayoutPanel10.Controls.Add(this.label15);
			this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel10.Location = new System.Drawing.Point(3, 2);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel10.TabIndex = 0;
			this.flowLayoutPanel10.Visible = false;
			this.txtTotalIngresosFacturadosRif.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalIngresosFacturadosRif.Location = new System.Drawing.Point(447, 2);
			this.txtTotalIngresosFacturadosRif.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTotalIngresosFacturadosRif.Name = "txtTotalIngresosFacturadosRif";
			this.txtTotalIngresosFacturadosRif.ReadOnly = true;
			this.txtTotalIngresosFacturadosRif.Size = new System.Drawing.Size(176, 28);
			this.txtTotalIngresosFacturadosRif.TabIndex = 1;
			this.txtTotalIngresosFacturadosRif.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(230, 8);
			this.label15.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(211, 18);
			this.label15.TabIndex = 0;
			this.label15.Text = "TOTAL INGRESOS FACTURADOS:";
			this.flowLayoutPanel18.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel18.Controls.Add(this.txtIngresosPublicoGeneral);
			this.flowLayoutPanel18.Controls.Add(this.label16);
			this.flowLayoutPanel18.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel18.Location = new System.Drawing.Point(3, 44);
			this.flowLayoutPanel18.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel18.Name = "flowLayoutPanel18";
			this.flowLayoutPanel18.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel18.TabIndex = 0;
			this.txtIngresosPublicoGeneral.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosPublicoGeneral.Location = new System.Drawing.Point(447, 2);
			this.txtIngresosPublicoGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIngresosPublicoGeneral.Name = "txtIngresosPublicoGeneral";
			this.txtIngresosPublicoGeneral.Size = new System.Drawing.Size(176, 28);
			this.txtIngresosPublicoGeneral.TabIndex = 1;
			this.txtIngresosPublicoGeneral.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosPublicoGeneral.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtIngresosPublicoGeneral.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(243, 8);
			this.label16.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(198, 18);
			this.label16.TabIndex = 0;
			this.label16.Text = "INGRESOS PUBLICO GENERAL:";
			this.flowLayoutPanel27.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel27.Controls.Add(this.txtOtrosIngresosPG);
			this.flowLayoutPanel27.Controls.Add(this.label17);
			this.flowLayoutPanel27.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel27.Location = new System.Drawing.Point(3, 86);
			this.flowLayoutPanel27.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel27.Name = "flowLayoutPanel27";
			this.flowLayoutPanel27.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel27.TabIndex = 1;
			this.txtOtrosIngresosPG.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosIngresosPG.Location = new System.Drawing.Point(447, 2);
			this.txtOtrosIngresosPG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtOtrosIngresosPG.Name = "txtOtrosIngresosPG";
			this.txtOtrosIngresosPG.Size = new System.Drawing.Size(176, 28);
			this.txtOtrosIngresosPG.TabIndex = 1;
			this.txtOtrosIngresosPG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosIngresosPG.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtOtrosIngresosPG.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(173, 8);
			this.label17.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(268, 18);
			this.label17.TabIndex = 0;
			this.label17.Text = "(+) OTROS INGRESOS PUBLICO GENERAL:";
			this.flowLayoutPanel47.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel47.Controls.Add(this.txtIngresosPublicoNoAcumulables);
			this.flowLayoutPanel47.Controls.Add(this.label32);
			this.flowLayoutPanel47.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel47.Location = new System.Drawing.Point(3, 128);
			this.flowLayoutPanel47.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel47.Name = "flowLayoutPanel47";
			this.flowLayoutPanel47.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel47.TabIndex = 137;
			this.txtIngresosPublicoNoAcumulables.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosPublicoNoAcumulables.Location = new System.Drawing.Point(447, 2);
			this.txtIngresosPublicoNoAcumulables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIngresosPublicoNoAcumulables.Name = "txtIngresosPublicoNoAcumulables";
			this.txtIngresosPublicoNoAcumulables.Size = new System.Drawing.Size(176, 28);
			this.txtIngresosPublicoNoAcumulables.TabIndex = 1;
			this.txtIngresosPublicoNoAcumulables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosPublicoNoAcumulables.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtIngresosPublicoNoAcumulables.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(162, 8);
			this.label32.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(279, 18);
			this.label32.TabIndex = 0;
			this.label32.Text = "(-) INGRESOS PUBLICO NO ACUMULABLES:";
			this.flowLayoutPanel28.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel28.Controls.Add(this.txtTotalIngresosPG);
			this.flowLayoutPanel28.Controls.Add(this.label18);
			this.flowLayoutPanel28.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel28.Location = new System.Drawing.Point(3, 170);
			this.flowLayoutPanel28.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel28.Name = "flowLayoutPanel28";
			this.flowLayoutPanel28.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel28.TabIndex = 2;
			this.txtTotalIngresosPG.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalIngresosPG.Location = new System.Drawing.Point(447, 2);
			this.txtTotalIngresosPG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTotalIngresosPG.Name = "txtTotalIngresosPG";
			this.txtTotalIngresosPG.ReadOnly = true;
			this.txtTotalIngresosPG.Size = new System.Drawing.Size(176, 28);
			this.txtTotalIngresosPG.TabIndex = 1;
			this.txtTotalIngresosPG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(176, 8);
			this.label18.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(265, 18);
			this.label18.TabIndex = 0;
			this.label18.Text = "(=) TOTAL INGRESOS PUBLICO GENERAL:";
			this.flowLayoutPanel29.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel29.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel29.Location = new System.Drawing.Point(3, 212);
			this.flowLayoutPanel29.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel29.Name = "flowLayoutPanel29";
			this.flowLayoutPanel29.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel29.TabIndex = 144;
			this.flowLayoutPanel30.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel30.Controls.Add(this.cmbTasaIVA);
			this.flowLayoutPanel30.Controls.Add(this.label19);
			this.flowLayoutPanel30.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel30.Location = new System.Drawing.Point(3, 254);
			this.flowLayoutPanel30.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel30.Name = "flowLayoutPanel30";
			this.flowLayoutPanel30.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel30.TabIndex = 3;
			this.cmbTasaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTasaIVA.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbTasaIVA.FormattingEnabled = true;
			this.cmbTasaIVA.Items.AddRange(new object[4] { "8%", "6%", "2%", "0%" });
			this.cmbTasaIVA.Location = new System.Drawing.Point(545, 2);
			this.cmbTasaIVA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbTasaIVA.Name = "cmbTasaIVA";
			this.cmbTasaIVA.Size = new System.Drawing.Size(78, 26);
			this.cmbTasaIVA.TabIndex = 3;
			this.cmbTasaIVA.SelectedIndexChanged += new System.EventHandler(cmbTasaIVA_SelectedIndexChanged);
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(232, 8);
			this.label19.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(307, 18);
			this.label19.TabIndex = 0;
			this.label19.Text = "(X) TASA DE IVA DE ACUERDO A LA ACTIVIDAD:";
			this.flowLayoutPanel31.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel31.Controls.Add(this.txtIvaOperacionesPG);
			this.flowLayoutPanel31.Controls.Add(this.label20);
			this.flowLayoutPanel31.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel31.Location = new System.Drawing.Point(3, 296);
			this.flowLayoutPanel31.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel31.Name = "flowLayoutPanel31";
			this.flowLayoutPanel31.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel31.TabIndex = 142;
			this.txtIvaOperacionesPG.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaOperacionesPG.Location = new System.Drawing.Point(493, 2);
			this.txtIvaOperacionesPG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaOperacionesPG.Name = "txtIvaOperacionesPG";
			this.txtIvaOperacionesPG.ReadOnly = true;
			this.txtIvaOperacionesPG.Size = new System.Drawing.Size(130, 28);
			this.txtIvaOperacionesPG.TabIndex = 1;
			this.txtIvaOperacionesPG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(214, 8);
			this.label20.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(273, 18);
			this.label20.TabIndex = 0;
			this.label20.Text = "(=) IVA OPERACIONES PUBLICO GENERAL:";
			this.flowLayoutPanel32.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel32.Controls.Add(this.cmbPorcentajeReduccion);
			this.flowLayoutPanel32.Controls.Add(this.label21);
			this.flowLayoutPanel32.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel32.Location = new System.Drawing.Point(3, 338);
			this.flowLayoutPanel32.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel32.Name = "flowLayoutPanel32";
			this.flowLayoutPanel32.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel32.TabIndex = 150;
			this.cmbPorcentajeReduccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPorcentajeReduccion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbPorcentajeReduccion.FormattingEnabled = true;
			this.cmbPorcentajeReduccion.Items.AddRange(new object[11]
			{
				"100%", "90%", "80%", "70%", "60%", "50%", "40%", "30%", "20%", "10%",
				"-SIN REDUCCIÓN-"
			});
			this.cmbPorcentajeReduccion.Location = new System.Drawing.Point(493, 2);
			this.cmbPorcentajeReduccion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.cmbPorcentajeReduccion.Name = "cmbPorcentajeReduccion";
			this.cmbPorcentajeReduccion.Size = new System.Drawing.Size(130, 26);
			this.cmbPorcentajeReduccion.TabIndex = 4;
			this.cmbPorcentajeReduccion.SelectedIndexChanged += new System.EventHandler(cmbTasaIVA_SelectedIndexChanged);
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(272, 8);
			this.label21.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(215, 18);
			this.label21.TabIndex = 0;
			this.label21.Text = "(X) PORCENTAJE DE REDUCCION:";
			this.flowLayoutPanel33.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel33.Controls.Add(this.txtIvaReducido);
			this.flowLayoutPanel33.Controls.Add(this.label22);
			this.flowLayoutPanel33.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel33.Location = new System.Drawing.Point(3, 380);
			this.flowLayoutPanel33.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel33.Name = "flowLayoutPanel33";
			this.flowLayoutPanel33.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel33.TabIndex = 143;
			this.txtIvaReducido.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaReducido.Location = new System.Drawing.Point(493, 2);
			this.txtIvaReducido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaReducido.Name = "txtIvaReducido";
			this.txtIvaReducido.ReadOnly = true;
			this.txtIvaReducido.Size = new System.Drawing.Size(130, 28);
			this.txtIvaReducido.TabIndex = 1;
			this.txtIvaReducido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(359, 8);
			this.label22.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(128, 18);
			this.label22.TabIndex = 0;
			this.label22.Text = "(=) IVA REDUCIDO:";
			this.flowLayoutPanel35.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel35.Controls.Add(this.txtIvaTrasladadoOperacionesPG);
			this.flowLayoutPanel35.Controls.Add(this.label23);
			this.flowLayoutPanel35.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel35.Location = new System.Drawing.Point(3, 422);
			this.flowLayoutPanel35.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel35.Name = "flowLayoutPanel35";
			this.flowLayoutPanel35.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel35.TabIndex = 146;
			this.txtIvaTrasladadoOperacionesPG.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaTrasladadoOperacionesPG.Location = new System.Drawing.Point(493, 2);
			this.txtIvaTrasladadoOperacionesPG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaTrasladadoOperacionesPG.Name = "txtIvaTrasladadoOperacionesPG";
			this.txtIvaTrasladadoOperacionesPG.ReadOnly = true;
			this.txtIvaTrasladadoOperacionesPG.Size = new System.Drawing.Size(130, 28);
			this.txtIvaTrasladadoOperacionesPG.TabIndex = 1;
			this.txtIvaTrasladadoOperacionesPG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(123, 8);
			this.label23.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(364, 18);
			this.label23.TabIndex = 0;
			this.label23.Text = "(=) IVA TRASLADADO OPERACIONES PUBLICO GENERAL:";
			this.flowLayoutPanel36.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel36.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel36.Location = new System.Drawing.Point(3, 464);
			this.flowLayoutPanel36.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel36.Name = "flowLayoutPanel36";
			this.flowLayoutPanel36.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel36.TabIndex = 147;
			this.flowLayoutPanel50.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel50.Controls.Add(this.txtIngresosCI);
			this.flowLayoutPanel50.Controls.Add(this.label36);
			this.flowLayoutPanel50.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel50.Location = new System.Drawing.Point(3, 506);
			this.flowLayoutPanel50.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel50.Name = "flowLayoutPanel50";
			this.flowLayoutPanel50.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel50.TabIndex = 163;
			this.txtIngresosCI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCI.Location = new System.Drawing.Point(447, 2);
			this.txtIngresosCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIngresosCI.Name = "txtIngresosCI";
			this.txtIngresosCI.Size = new System.Drawing.Size(176, 28);
			this.txtIngresosCI.TabIndex = 1;
			this.txtIngresosCI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCI.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtIngresosCI.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(209, 8);
			this.label36.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(232, 18);
			this.label36.TabIndex = 0;
			this.label36.Text = "INGRESOS CLIENTES INDIVIDUALES:";
			this.flowLayoutPanel48.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel48.Controls.Add(this.txtOtrosIngresosCI);
			this.flowLayoutPanel48.Controls.Add(this.label35);
			this.flowLayoutPanel48.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel48.Location = new System.Drawing.Point(3, 548);
			this.flowLayoutPanel48.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel48.Name = "flowLayoutPanel48";
			this.flowLayoutPanel48.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel48.TabIndex = 161;
			this.txtOtrosIngresosCI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosIngresosCI.Location = new System.Drawing.Point(447, 2);
			this.txtOtrosIngresosCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtOtrosIngresosCI.Name = "txtOtrosIngresosCI";
			this.txtOtrosIngresosCI.Size = new System.Drawing.Size(176, 28);
			this.txtOtrosIngresosCI.TabIndex = 1;
			this.txtOtrosIngresosCI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosIngresosCI.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtOtrosIngresosCI.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(139, 8);
			this.label35.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(302, 18);
			this.label35.TabIndex = 0;
			this.label35.Text = "(+) OTROS INGRESOS CLIENTES INDIVIDUALES:";
			this.flowLayoutPanel34.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel34.Controls.Add(this.txtIngresosNoAcumulablesCI);
			this.flowLayoutPanel34.Controls.Add(this.label37);
			this.flowLayoutPanel34.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel34.Location = new System.Drawing.Point(3, 590);
			this.flowLayoutPanel34.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel34.Name = "flowLayoutPanel34";
			this.flowLayoutPanel34.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel34.TabIndex = 164;
			this.txtIngresosNoAcumulablesCI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosNoAcumulablesCI.Location = new System.Drawing.Point(447, 2);
			this.txtIngresosNoAcumulablesCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIngresosNoAcumulablesCI.Name = "txtIngresosNoAcumulablesCI";
			this.txtIngresosNoAcumulablesCI.Size = new System.Drawing.Size(176, 28);
			this.txtIngresosNoAcumulablesCI.TabIndex = 1;
			this.txtIngresosNoAcumulablesCI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosNoAcumulablesCI.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtIngresosNoAcumulablesCI.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(66, 8);
			this.label37.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(375, 18);
			this.label37.TabIndex = 0;
			this.label37.Text = "(-) INGRESOS CLIENTES INDIVIDUALES NO ACUMULABLES:";
			this.flowLayoutPanel51.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel51.Controls.Add(this.txtTotalIngresosCI);
			this.flowLayoutPanel51.Controls.Add(this.label38);
			this.flowLayoutPanel51.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel51.Location = new System.Drawing.Point(3, 632);
			this.flowLayoutPanel51.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel51.Name = "flowLayoutPanel51";
			this.flowLayoutPanel51.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel51.TabIndex = 165;
			this.txtTotalIngresosCI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalIngresosCI.Location = new System.Drawing.Point(447, 2);
			this.txtTotalIngresosCI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTotalIngresosCI.Name = "txtTotalIngresosCI";
			this.txtTotalIngresosCI.ReadOnly = true;
			this.txtTotalIngresosCI.Size = new System.Drawing.Size(176, 28);
			this.txtTotalIngresosCI.TabIndex = 1;
			this.txtTotalIngresosCI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(142, 8);
			this.label38.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(299, 18);
			this.label38.TabIndex = 0;
			this.label38.Text = "(=) TOTAL INGRESOS CLIENTES INDIVIDUALES:";
			this.flowLayoutPanel49.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel49.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel49.Location = new System.Drawing.Point(3, 674);
			this.flowLayoutPanel49.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel49.Name = "flowLayoutPanel49";
			this.flowLayoutPanel49.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel49.TabIndex = 162;
			this.flowLayoutPanel37.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel37.Controls.Add(this.txtIvaTrasladadoOperacionesPG2);
			this.flowLayoutPanel37.Controls.Add(this.label26);
			this.flowLayoutPanel37.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel37.Location = new System.Drawing.Point(3, 716);
			this.flowLayoutPanel37.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel37.Name = "flowLayoutPanel37";
			this.flowLayoutPanel37.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel37.TabIndex = 148;
			this.txtIvaTrasladadoOperacionesPG2.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaTrasladadoOperacionesPG2.Location = new System.Drawing.Point(447, 2);
			this.txtIvaTrasladadoOperacionesPG2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaTrasladadoOperacionesPG2.Name = "txtIvaTrasladadoOperacionesPG2";
			this.txtIvaTrasladadoOperacionesPG2.ReadOnly = true;
			this.txtIvaTrasladadoOperacionesPG2.Size = new System.Drawing.Size(176, 28);
			this.txtIvaTrasladadoOperacionesPG2.TabIndex = 1;
			this.txtIvaTrasladadoOperacionesPG2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(99, 8);
			this.label26.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(342, 18);
			this.label26.TabIndex = 0;
			this.label26.Text = "IVA TRASLADADO OPERACIONES PUBLICO GENERAL:";
			this.flowLayoutPanel38.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel38.Controls.Add(this.txtIvaTrasladadoCFDI);
			this.flowLayoutPanel38.Controls.Add(this.label25);
			this.flowLayoutPanel38.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel38.Location = new System.Drawing.Point(3, 758);
			this.flowLayoutPanel38.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel38.Name = "flowLayoutPanel38";
			this.flowLayoutPanel38.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel38.TabIndex = 149;
			this.txtIvaTrasladadoCFDI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaTrasladadoCFDI.Location = new System.Drawing.Point(447, 2);
			this.txtIvaTrasladadoCFDI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaTrasladadoCFDI.Name = "txtIvaTrasladadoCFDI";
			this.txtIvaTrasladadoCFDI.Size = new System.Drawing.Size(176, 28);
			this.txtIvaTrasladadoCFDI.TabIndex = 3;
			this.txtIvaTrasladadoCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaTrasladadoCFDI.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtIvaTrasladadoCFDI.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(295, 8);
			this.label25.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(146, 18);
			this.label25.TabIndex = 2;
			this.label25.Text = "(+) IVA TRASLADADO:";
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.Controls.Add(this.txtIvaTrasladadoTotal);
			this.flowLayoutPanel2.Controls.Add(this.label27);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 800);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel2.TabIndex = 151;
			this.txtIvaTrasladadoTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaTrasladadoTotal.Location = new System.Drawing.Point(447, 2);
			this.txtIvaTrasladadoTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaTrasladadoTotal.Name = "txtIvaTrasladadoTotal";
			this.txtIvaTrasladadoTotal.ReadOnly = true;
			this.txtIvaTrasladadoTotal.Size = new System.Drawing.Size(176, 28);
			this.txtIvaTrasladadoTotal.TabIndex = 3;
			this.txtIvaTrasladadoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(250, 8);
			this.label27.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(191, 18);
			this.label27.TabIndex = 2;
			this.label27.Text = "(=) IVA TRASLADADO TOTAL:";
			this.flowLayoutPanel39.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel39.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel39.Location = new System.Drawing.Point(3, 842);
			this.flowLayoutPanel39.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel39.Name = "flowLayoutPanel39";
			this.flowLayoutPanel39.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel39.TabIndex = 152;
			this.flowLayoutPanel40.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel40.Controls.Add(this.txtIvaRetenidoRIF);
			this.flowLayoutPanel40.Controls.Add(this.label28);
			this.flowLayoutPanel40.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel40.Location = new System.Drawing.Point(3, 884);
			this.flowLayoutPanel40.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel40.Name = "flowLayoutPanel40";
			this.flowLayoutPanel40.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel40.TabIndex = 154;
			this.txtIvaRetenidoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaRetenidoRIF.Location = new System.Drawing.Point(493, 2);
			this.txtIvaRetenidoRIF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaRetenidoRIF.Name = "txtIvaRetenidoRIF";
			this.txtIvaRetenidoRIF.ReadOnly = true;
			this.txtIvaRetenidoRIF.Size = new System.Drawing.Size(130, 28);
			this.txtIvaRetenidoRIF.TabIndex = 1;
			this.txtIvaRetenidoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(368, 8);
			this.label28.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(119, 18);
			this.label28.TabIndex = 0;
			this.label28.Text = "(-) IVA RETENIDO:";
			this.flowLayoutPanel41.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel41.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel41.Location = new System.Drawing.Point(3, 926);
			this.flowLayoutPanel41.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel41.Name = "flowLayoutPanel41";
			this.flowLayoutPanel41.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel41.TabIndex = 155;
			this.flowLayoutPanel42.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel42.Controls.Add(this.txtIvaAcreditableCFDI);
			this.flowLayoutPanel42.Controls.Add(this.label29);
			this.flowLayoutPanel42.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel42.Location = new System.Drawing.Point(3, 968);
			this.flowLayoutPanel42.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel42.Name = "flowLayoutPanel42";
			this.flowLayoutPanel42.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel42.TabIndex = 156;
			this.txtIvaAcreditableCFDI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaAcreditableCFDI.Location = new System.Drawing.Point(493, 2);
			this.txtIvaAcreditableCFDI.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaAcreditableCFDI.Name = "txtIvaAcreditableCFDI";
			this.txtIvaAcreditableCFDI.ReadOnly = true;
			this.txtIvaAcreditableCFDI.Size = new System.Drawing.Size(130, 28);
			this.txtIvaAcreditableCFDI.TabIndex = 1;
			this.txtIvaAcreditableCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(283, 8);
			this.label29.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(204, 18);
			this.label29.TabIndex = 0;
			this.label29.Text = "IVA ACREDITABLE SEGÚN CFDI:";
			this.flowLayoutPanel52.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel52.Controls.Add(this.txtOtroIvaAcreditable);
			this.flowLayoutPanel52.Controls.Add(this.label39);
			this.flowLayoutPanel52.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel52.Location = new System.Drawing.Point(3, 1010);
			this.flowLayoutPanel52.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel52.Name = "flowLayoutPanel52";
			this.flowLayoutPanel52.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel52.TabIndex = 166;
			this.txtOtroIvaAcreditable.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtroIvaAcreditable.Location = new System.Drawing.Point(493, 2);
			this.txtOtroIvaAcreditable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtOtroIvaAcreditable.Name = "txtOtroIvaAcreditable";
			this.txtOtroIvaAcreditable.Size = new System.Drawing.Size(130, 28);
			this.txtOtroIvaAcreditable.TabIndex = 1;
			this.txtOtroIvaAcreditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtroIvaAcreditable.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtOtroIvaAcreditable.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(302, 8);
			this.label39.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(185, 18);
			this.label39.TabIndex = 0;
			this.label39.Text = "(+) OTRO IVA ACREDITABLE:";
			this.flowLayoutPanel53.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel53.Controls.Add(this.txtIvaNoAcreditable);
			this.flowLayoutPanel53.Controls.Add(this.label40);
			this.flowLayoutPanel53.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel53.Location = new System.Drawing.Point(3, 1052);
			this.flowLayoutPanel53.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel53.Name = "flowLayoutPanel53";
			this.flowLayoutPanel53.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel53.TabIndex = 167;
			this.txtIvaNoAcreditable.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaNoAcreditable.Location = new System.Drawing.Point(493, 2);
			this.txtIvaNoAcreditable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaNoAcreditable.Name = "txtIvaNoAcreditable";
			this.txtIvaNoAcreditable.Size = new System.Drawing.Size(130, 28);
			this.txtIvaNoAcreditable.TabIndex = 1;
			this.txtIvaNoAcreditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIvaNoAcreditable.TextChanged += new System.EventHandler(txtIngresosPublicoGeneral_TextChanged);
			this.txtIvaNoAcreditable.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(322, 8);
			this.label40.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(165, 18);
			this.label40.TabIndex = 0;
			this.label40.Text = "(-) IVA NO ACREDITABLE:";
			this.flowLayoutPanel54.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel54.Controls.Add(this.txtIvaAcreditableTotalRIF);
			this.flowLayoutPanel54.Controls.Add(this.label41);
			this.flowLayoutPanel54.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel54.Location = new System.Drawing.Point(3, 1094);
			this.flowLayoutPanel54.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel54.Name = "flowLayoutPanel54";
			this.flowLayoutPanel54.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel54.TabIndex = 168;
			this.txtIvaAcreditableTotalRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaAcreditableTotalRIF.Location = new System.Drawing.Point(447, 2);
			this.txtIvaAcreditableTotalRIF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaAcreditableTotalRIF.Name = "txtIvaAcreditableTotalRIF";
			this.txtIvaAcreditableTotalRIF.ReadOnly = true;
			this.txtIvaAcreditableTotalRIF.Size = new System.Drawing.Size(176, 28);
			this.txtIvaAcreditableTotalRIF.TabIndex = 3;
			this.txtIvaAcreditableTotalRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(252, 8);
			this.label41.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(189, 18);
			this.label41.TabIndex = 2;
			this.label41.Text = "(=) IVA ACREDITABLE TOTAL:";
			this.flowLayoutPanel43.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel43.Controls.Add(this.txtProporcionPorOperacionesPG);
			this.flowLayoutPanel43.Controls.Add(this.label30);
			this.flowLayoutPanel43.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel43.Location = new System.Drawing.Point(3, 1136);
			this.flowLayoutPanel43.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel43.Name = "flowLayoutPanel43";
			this.flowLayoutPanel43.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel43.TabIndex = 157;
			this.txtProporcionPorOperacionesPG.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtProporcionPorOperacionesPG.Location = new System.Drawing.Point(493, 2);
			this.txtProporcionPorOperacionesPG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtProporcionPorOperacionesPG.Name = "txtProporcionPorOperacionesPG";
			this.txtProporcionPorOperacionesPG.ReadOnly = true;
			this.txtProporcionPorOperacionesPG.Size = new System.Drawing.Size(130, 28);
			this.txtProporcionPorOperacionesPG.TabIndex = 1;
			this.txtProporcionPorOperacionesPG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(139, 8);
			this.label30.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(348, 18);
			this.label30.TabIndex = 0;
			this.label30.Text = "PROPORCION POR OPERACIONES PUBLICO GENERAL:";
			this.flowLayoutPanel44.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel44.Controls.Add(this.txtIvaFiscalAcreditable);
			this.flowLayoutPanel44.Controls.Add(this.label31);
			this.flowLayoutPanel44.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel44.Location = new System.Drawing.Point(3, 1178);
			this.flowLayoutPanel44.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel44.Name = "flowLayoutPanel44";
			this.flowLayoutPanel44.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel44.TabIndex = 158;
			this.txtIvaFiscalAcreditable.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaFiscalAcreditable.Location = new System.Drawing.Point(493, 2);
			this.txtIvaFiscalAcreditable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaFiscalAcreditable.Name = "txtIvaFiscalAcreditable";
			this.txtIvaFiscalAcreditable.ReadOnly = true;
			this.txtIvaFiscalAcreditable.Size = new System.Drawing.Size(130, 28);
			this.txtIvaFiscalAcreditable.TabIndex = 1;
			this.txtIvaFiscalAcreditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(296, 8);
			this.label31.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(191, 18);
			this.label31.TabIndex = 0;
			this.label31.Text = "(=) IVA FISCAL ACREDITABLE:";
			this.flowLayoutPanel45.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel45.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel45.Location = new System.Drawing.Point(3, 1220);
			this.flowLayoutPanel45.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel45.Name = "flowLayoutPanel45";
			this.flowLayoutPanel45.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel45.TabIndex = 159;
			this.flowLayoutPanel46.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel46.Controls.Add(this.txtIvaPorPagarAfavorRIF);
			this.flowLayoutPanel46.Controls.Add(this.lbIvaPorPagarAfavorRIF);
			this.flowLayoutPanel46.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel46.Location = new System.Drawing.Point(3, 1262);
			this.flowLayoutPanel46.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel46.Name = "flowLayoutPanel46";
			this.flowLayoutPanel46.Size = new System.Drawing.Size(626, 38);
			this.flowLayoutPanel46.TabIndex = 160;
			this.txtIvaPorPagarAfavorRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaPorPagarAfavorRIF.Location = new System.Drawing.Point(493, 2);
			this.txtIvaPorPagarAfavorRIF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaPorPagarAfavorRIF.Name = "txtIvaPorPagarAfavorRIF";
			this.txtIvaPorPagarAfavorRIF.ReadOnly = true;
			this.txtIvaPorPagarAfavorRIF.Size = new System.Drawing.Size(130, 28);
			this.txtIvaPorPagarAfavorRIF.TabIndex = 1;
			this.txtIvaPorPagarAfavorRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.lbIvaPorPagarAfavorRIF.AutoSize = true;
			this.lbIvaPorPagarAfavorRIF.Location = new System.Drawing.Point(296, 8);
			this.lbIvaPorPagarAfavorRIF.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.lbIvaPorPagarAfavorRIF.Name = "lbIvaPorPagarAfavorRIF";
			this.lbIvaPorPagarAfavorRIF.Size = new System.Drawing.Size(191, 18);
			this.lbIvaPorPagarAfavorRIF.TabIndex = 0;
			this.lbIvaPorPagarAfavorRIF.Text = "(=) IVA POR PAGAR / FAVOR:";
			this.flpEmitidos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpEmitidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpEmitidos.Controls.Add(this.label11);
			this.flpEmitidos.Controls.Add(this.flpTotalesTodos);
			this.flpEmitidos.Controls.Add(this.flowLayoutPanel16);
			this.flpEmitidos.Controls.Add(this.flowLayoutPanel17);
			this.flpEmitidos.Controls.Add(this.flowLayoutPanel19);
			this.flpEmitidos.Controls.Add(this.pnlIngresosPgCi);
			this.flpEmitidos.Controls.Add(this.gbActos);
			this.flpEmitidos.Controls.Add(this.pnlExportaDetallesCFDIs);
			this.flpEmitidos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpEmitidos.Location = new System.Drawing.Point(830, 9);
			this.flpEmitidos.Margin = new System.Windows.Forms.Padding(2);
			this.flpEmitidos.Name = "flpEmitidos";
			this.flpEmitidos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpEmitidos.Size = new System.Drawing.Size(656, 391);
			this.flpEmitidos.TabIndex = 141;
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new System.Drawing.Point(3, 2);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(200, 23);
			this.label11.TabIndex = 140;
			this.label11.Text = "Flujo CFDI's EMITIDOS";
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(2, 27);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(2);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(832, 36);
			this.flpTotalesTodos.TabIndex = 135;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel3, this.tstxtNumPUE, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotalPUE, this.toolStripSeparator1, this.toolStripLabel17, this.tstxtIvaPUE, this.toolStripSeparator2, this.toolStripLabel1,
				this.tstxtRetencionesPUE, this.toolStripSeparator13, this.toolStripLabel2, this.tstxtImportePUE
			});
			this.toolStrip1.Location = new System.Drawing.Point(0, 2);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(727, 31);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(102, 26);
			this.toolStripLabel3.Text = "           PUE:";
			this.tstxtNumPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUE.Name = "tstxtNumPUE";
			this.tstxtNumPUE.ReadOnly = true;
			this.tstxtNumPUE.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel4.Text = "SubTotal:";
			this.tstxtSubtotalPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUE.Name = "tstxtSubtotalPUE";
			this.tstxtSubtotalPUE.ReadOnly = true;
			this.tstxtSubtotalPUE.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel17.Name = "toolStripLabel17";
			this.toolStripLabel17.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel17.Text = "I.V.A:";
			this.tstxtIvaPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUE.Name = "tstxtIvaPUE";
			this.tstxtIvaPUE.ReadOnly = true;
			this.tstxtIvaPUE.Size = new System.Drawing.Size(102, 31);
			this.tstxtIvaPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(118, 26);
			this.toolStripLabel1.Text = "IVA Retenido:";
			this.tstxtRetencionesPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUE.Name = "tstxtRetencionesPUE";
			this.tstxtRetencionesPUE.ReadOnly = true;
			this.tstxtRetencionesPUE.Size = new System.Drawing.Size(55, 31);
			this.tstxtRetencionesPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel2.Text = "Total:";
			this.toolStripLabel2.Visible = false;
			this.tstxtImportePUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImportePUE.Name = "tstxtImportePUE";
			this.tstxtImportePUE.ReadOnly = true;
			this.tstxtImportePUE.Size = new System.Drawing.Size(59, 31);
			this.tstxtImportePUE.Visible = false;
			this.flowLayoutPanel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel16.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel16.Location = new System.Drawing.Point(2, 67);
			this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel16.Name = "flowLayoutPanel16";
			this.flowLayoutPanel16.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel16.Size = new System.Drawing.Size(832, 36);
			this.flowLayoutPanel16.TabIndex = 136;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel5, this.tstxtNumCP, this.toolStripSeparator3, this.toolStripLabel6, this.tstxtSubtotalCP, this.toolStripSeparator5, this.toolStripLabel7, this.tstxtIvaCP, this.toolStripSeparator6, this.toolStripLabel18,
				this.tstxtRetencionesCP, this.toolStripSeparator14, this.toolStripLabel8, this.tstxtImporteCP
			});
			this.toolStrip2.Location = new System.Drawing.Point(0, 2);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(727, 31);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(102, 26);
			this.toolStripLabel5.Text = "             CP:";
			this.tstxtNumCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumCP.Name = "tstxtNumCP";
			this.tstxtNumCP.ReadOnly = true;
			this.tstxtNumCP.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel6.Text = "SubTotal:";
			this.tstxtSubtotalCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalCP.Name = "tstxtSubtotalCP";
			this.tstxtSubtotalCP.ReadOnly = true;
			this.tstxtSubtotalCP.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tstxtIvaCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaCP.Name = "tstxtIvaCP";
			this.tstxtIvaCP.ReadOnly = true;
			this.tstxtIvaCP.Size = new System.Drawing.Size(102, 31);
			this.tstxtIvaCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel18.Name = "toolStripLabel18";
			this.toolStripLabel18.Size = new System.Drawing.Size(118, 26);
			this.toolStripLabel18.Text = "IVA Retenido:";
			this.tstxtRetencionesCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCP.Name = "tstxtRetencionesCP";
			this.tstxtRetencionesCP.ReadOnly = true;
			this.tstxtRetencionesCP.Size = new System.Drawing.Size(55, 31);
			this.tstxtRetencionesCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel8.Text = "Total:";
			this.toolStripLabel8.Visible = false;
			this.tstxtImporteCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporteCP.Name = "tstxtImporteCP";
			this.tstxtImporteCP.ReadOnly = true;
			this.tstxtImporteCP.Size = new System.Drawing.Size(59, 31);
			this.tstxtImporteCP.Visible = false;
			this.flowLayoutPanel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel17.Controls.Add(this.toolStrip5);
			this.flowLayoutPanel17.Location = new System.Drawing.Point(2, 107);
			this.flowLayoutPanel17.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel17.Name = "flowLayoutPanel17";
			this.flowLayoutPanel17.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel17.Size = new System.Drawing.Size(832, 36);
			this.flowLayoutPanel17.TabIndex = 138;
			this.toolStrip5.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel20, this.tstxtNumEg, this.toolStripSeparator16, this.toolStripLabel21, this.tstxtSubtotalEg, this.toolStripSeparator17, this.toolStripLabel22, this.tstxtIvaEg, this.toolStripSeparator18, this.toolStripLabel23,
				this.tstxtRetencionesEg, this.toolStripSeparator19, this.toolStripLabel24, this.tstxtImporteEg
			});
			this.toolStrip5.Location = new System.Drawing.Point(0, 2);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip5.Size = new System.Drawing.Size(725, 31);
			this.toolStrip5.TabIndex = 2;
			this.toolStrip5.Text = "toolStrip5";
			this.toolStripLabel20.Name = "toolStripLabel20";
			this.toolStripLabel20.Size = new System.Drawing.Size(100, 26);
			this.toolStripLabel20.Text = "  - Egresos:";
			this.tstxtNumEg.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumEg.Name = "tstxtNumEg";
			this.tstxtNumEg.ReadOnly = true;
			this.tstxtNumEg.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel21.Name = "toolStripLabel21";
			this.toolStripLabel21.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel21.Text = "SubTotal:";
			this.tstxtSubtotalEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEg.Name = "tstxtSubtotalEg";
			this.tstxtSubtotalEg.ReadOnly = true;
			this.tstxtSubtotalEg.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel22.Name = "toolStripLabel22";
			this.toolStripLabel22.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel22.Text = "I.V.A:";
			this.tstxtIvaEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEg.Name = "tstxtIvaEg";
			this.tstxtIvaEg.ReadOnly = true;
			this.tstxtIvaEg.Size = new System.Drawing.Size(102, 31);
			this.tstxtIvaEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel23.Name = "toolStripLabel23";
			this.toolStripLabel23.Size = new System.Drawing.Size(118, 26);
			this.toolStripLabel23.Text = "IVA Retenido:";
			this.tstxtRetencionesEg.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesEg.Name = "tstxtRetencionesEg";
			this.tstxtRetencionesEg.ReadOnly = true;
			this.tstxtRetencionesEg.Size = new System.Drawing.Size(55, 31);
			this.tstxtRetencionesEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel24.Name = "toolStripLabel24";
			this.toolStripLabel24.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel24.Text = "Total:";
			this.toolStripLabel24.Visible = false;
			this.tstxtImporteEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteEg.Name = "tstxtImporteEg";
			this.tstxtImporteEg.ReadOnly = true;
			this.tstxtImporteEg.Size = new System.Drawing.Size(59, 31);
			this.tstxtImporteEg.Visible = false;
			this.flowLayoutPanel19.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel19.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel19.Location = new System.Drawing.Point(2, 147);
			this.flowLayoutPanel19.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel19.Name = "flowLayoutPanel19";
			this.flowLayoutPanel19.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel19.Size = new System.Drawing.Size(832, 36);
			this.flowLayoutPanel19.TabIndex = 137;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel9, this.tstxtNumTotal, this.toolStripSeparator7, this.toolStripLabel10, this.tstxtSubtotalTotal, this.toolStripSeparator8, this.toolStripLabel11, this.tstxtIvaTotal, this.toolStripSeparator9, this.toolStripLabel19,
				this.tstxtRetencionesTotal, this.toolStripSeparator15, this.toolStripLabel12, this.tstxtImporteTotal
			});
			this.toolStrip3.Location = new System.Drawing.Point(0, 2);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip3.Size = new System.Drawing.Size(727, 31);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStripLabel9.Name = "toolStripLabel9";
			this.toolStripLabel9.Size = new System.Drawing.Size(96, 26);
			this.toolStripLabel9.Text = "Total Flujo:";
			this.tstxtNumTotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumTotal.Name = "tstxtNumTotal";
			this.tstxtNumTotal.ReadOnly = true;
			this.tstxtNumTotal.Size = new System.Drawing.Size(52, 31);
			this.tstxtNumTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel10.Name = "toolStripLabel10";
			this.toolStripLabel10.Size = new System.Drawing.Size(84, 26);
			this.toolStripLabel10.Text = "SubTotal:";
			this.tstxtSubtotalTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotal.Name = "tstxtSubtotalTotal";
			this.tstxtSubtotalTotal.ReadOnly = true;
			this.tstxtSubtotalTotal.Size = new System.Drawing.Size(106, 31);
			this.tstxtSubtotalTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel11.Name = "toolStripLabel11";
			this.toolStripLabel11.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel11.Text = "I.V.A:";
			this.tstxtIvaTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotal.Name = "tstxtIvaTotal";
			this.tstxtIvaTotal.ReadOnly = true;
			this.tstxtIvaTotal.Size = new System.Drawing.Size(102, 31);
			this.tstxtIvaTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel19.Name = "toolStripLabel19";
			this.toolStripLabel19.Size = new System.Drawing.Size(118, 26);
			this.toolStripLabel19.Text = "IVA Retenido:";
			this.tstxtRetencionesTotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotal.Name = "tstxtRetencionesTotal";
			this.tstxtRetencionesTotal.ReadOnly = true;
			this.tstxtRetencionesTotal.Size = new System.Drawing.Size(61, 31);
			this.tstxtRetencionesTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel12.Name = "toolStripLabel12";
			this.toolStripLabel12.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel12.Text = "Total:";
			this.toolStripLabel12.Visible = false;
			this.tstxtImporteTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteTotal.Name = "tstxtImporteTotal";
			this.tstxtImporteTotal.ReadOnly = true;
			this.tstxtImporteTotal.Size = new System.Drawing.Size(73, 31);
			this.tstxtImporteTotal.Visible = false;
			this.pnlIngresosPgCi.Controls.Add(this.label34);
			this.pnlIngresosPgCi.Controls.Add(this.txtIngresosClientesIndividualesFlujo);
			this.pnlIngresosPgCi.Controls.Add(this.label33);
			this.pnlIngresosPgCi.Controls.Add(this.txtIngresosPgFlujo);
			this.pnlIngresosPgCi.Location = new System.Drawing.Point(3, 190);
			this.pnlIngresosPgCi.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.pnlIngresosPgCi.Name = "pnlIngresosPgCi";
			this.pnlIngresosPgCi.Size = new System.Drawing.Size(776, 82);
			this.pnlIngresosPgCi.TabIndex = 142;
			this.pnlIngresosPgCi.Visible = false;
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(3, 49);
			this.label34.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(232, 18);
			this.label34.TabIndex = 145;
			this.label34.Text = "INGRESOS CLIENTES INDIVIDUALES:";
			this.txtIngresosClientesIndividualesFlujo.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosClientesIndividualesFlujo.Location = new System.Drawing.Point(252, 46);
			this.txtIngresosClientesIndividualesFlujo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIngresosClientesIndividualesFlujo.Name = "txtIngresosClientesIndividualesFlujo";
			this.txtIngresosClientesIndividualesFlujo.ReadOnly = true;
			this.txtIngresosClientesIndividualesFlujo.Size = new System.Drawing.Size(122, 28);
			this.txtIngresosClientesIndividualesFlujo.TabIndex = 144;
			this.txtIngresosClientesIndividualesFlujo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(34, 12);
			this.label33.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(198, 18);
			this.label33.TabIndex = 143;
			this.label33.Text = "INGRESOS PÚBLICO GENERAL:";
			this.txtIngresosPgFlujo.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosPgFlujo.Location = new System.Drawing.Point(252, 9);
			this.txtIngresosPgFlujo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIngresosPgFlujo.Name = "txtIngresosPgFlujo";
			this.txtIngresosPgFlujo.ReadOnly = true;
			this.txtIngresosPgFlujo.Size = new System.Drawing.Size(122, 28);
			this.txtIngresosPgFlujo.TabIndex = 142;
			this.txtIngresosPgFlujo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.gbActos.Controls.Add(this.pnlActos);
			this.gbActos.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.gbActos.Location = new System.Drawing.Point(839, 7);
			this.gbActos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gbActos.Name = "gbActos";
			this.gbActos.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gbActos.Size = new System.Drawing.Size(838, 105);
			this.gbActos.TabIndex = 148;
			this.gbActos.TabStop = false;
			this.gbActos.Text = "CFDI 4.0 ";
			this.pnlActos.Controls.Add(this.txtSumaActos);
			this.pnlActos.Controls.Add(this.label46);
			this.pnlActos.Controls.Add(this.txtProporcionIvaAcreditable);
			this.pnlActos.Controls.Add(this.txtActos16);
			this.pnlActos.Controls.Add(this.txtActosExentos);
			this.pnlActos.Controls.Add(this.label43);
			this.pnlActos.Controls.Add(this.txtActos8);
			this.pnlActos.Controls.Add(this.txtActos0);
			this.pnlActos.Controls.Add(this.label42);
			this.pnlActos.Controls.Add(this.label45);
			this.pnlActos.Controls.Add(this.label44);
			this.pnlActos.Controls.Add(this.label47);
			this.pnlActos.Location = new System.Drawing.Point(8, 20);
			this.pnlActos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.pnlActos.Name = "pnlActos";
			this.pnlActos.Size = new System.Drawing.Size(830, 85);
			this.pnlActos.TabIndex = 143;
			this.txtSumaActos.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtSumaActos.Location = new System.Drawing.Point(100, 42);
			this.txtSumaActos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtSumaActos.Name = "txtSumaActos";
			this.txtSumaActos.ReadOnly = true;
			this.txtSumaActos.Size = new System.Drawing.Size(122, 30);
			this.txtSumaActos.TabIndex = 154;
			this.txtSumaActos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label46.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label46.Location = new System.Drawing.Point(10, 42);
			this.label46.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(82, 54);
			this.label46.TabIndex = 155;
			this.label46.Text = "SUMA DE ACTOS:";
			this.txtProporcionIvaAcreditable.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtProporcionIvaAcreditable.Location = new System.Drawing.Point(488, 42);
			this.txtProporcionIvaAcreditable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtProporcionIvaAcreditable.Name = "txtProporcionIvaAcreditable";
			this.txtProporcionIvaAcreditable.ReadOnly = true;
			this.txtProporcionIvaAcreditable.Size = new System.Drawing.Size(67, 28);
			this.txtProporcionIvaAcreditable.TabIndex = 156;
			this.txtProporcionIvaAcreditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtActos16.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActos16.Location = new System.Drawing.Point(100, 2);
			this.txtActos16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtActos16.Name = "txtActos16";
			this.txtActos16.Size = new System.Drawing.Size(96, 28);
			this.txtActos16.TabIndex = 146;
			this.txtActos16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtActos16.TextChanged += new System.EventHandler(txtActos16_TextChanged);
			this.txtActos16.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.txtActosExentos.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActosExentos.Location = new System.Drawing.Point(724, 5);
			this.txtActosExentos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtActosExentos.Name = "txtActosExentos";
			this.txtActosExentos.Size = new System.Drawing.Size(96, 28);
			this.txtActosExentos.TabIndex = 152;
			this.txtActosExentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtActosExentos.TextChanged += new System.EventHandler(txtActos16_TextChanged);
			this.txtActosExentos.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label43.AutoSize = true;
			this.label43.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label43.Location = new System.Drawing.Point(2, 6);
			this.label43.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(85, 18);
			this.label43.TabIndex = 147;
			this.label43.Text = "ACTOS 16%:";
			this.txtActos8.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActos8.Location = new System.Drawing.Point(294, 2);
			this.txtActos8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtActos8.Name = "txtActos8";
			this.txtActos8.Size = new System.Drawing.Size(96, 28);
			this.txtActos8.TabIndex = 148;
			this.txtActos8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtActos8.TextChanged += new System.EventHandler(txtActos16_TextChanged);
			this.txtActos8.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.txtActos0.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActos0.Location = new System.Drawing.Point(488, 5);
			this.txtActos0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtActos0.Name = "txtActos0";
			this.txtActos0.Size = new System.Drawing.Size(96, 28);
			this.txtActos0.TabIndex = 150;
			this.txtActos0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtActos0.TextChanged += new System.EventHandler(txtActos16_TextChanged);
			this.txtActos0.Leave += new System.EventHandler(txtIVACaptura_Leave);
			this.label42.AutoSize = true;
			this.label42.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label42.Location = new System.Drawing.Point(208, 8);
			this.label42.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(77, 18);
			this.label42.TabIndex = 149;
			this.label42.Text = "ACTOS 8%:";
			this.label45.AutoSize = true;
			this.label45.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label45.Location = new System.Drawing.Point(402, 8);
			this.label45.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(77, 18);
			this.label45.TabIndex = 151;
			this.label45.Text = "ACTOS 0%:";
			this.label44.AutoSize = true;
			this.label44.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label44.Location = new System.Drawing.Point(598, 8);
			this.label44.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(115, 18);
			this.label44.TabIndex = 153;
			this.label44.Text = "ACTOS EXENTOS:";
			this.label47.AutoSize = true;
			this.label47.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label47.Location = new System.Drawing.Point(262, 48);
			this.label47.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(214, 18);
			this.label47.TabIndex = 157;
			this.label47.Text = "PROPORCIÓN IVA ACREDITABLE:";
			this.pnlExportaDetallesCFDIs.Controls.Add(this.btnExportarDetallesCFDIs);
			this.pnlExportaDetallesCFDIs.Location = new System.Drawing.Point(839, 122);
			this.pnlExportaDetallesCFDIs.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.pnlExportaDetallesCFDIs.Name = "pnlExportaDetallesCFDIs";
			this.pnlExportaDetallesCFDIs.Size = new System.Drawing.Size(170, 174);
			this.pnlExportaDetallesCFDIs.TabIndex = 146;
			this.btnExportarDetallesCFDIs.BackColor = System.Drawing.Color.White;
			this.btnExportarDetallesCFDIs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportarDetallesCFDIs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarDetallesCFDIs.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarDetallesCFDIs.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportarDetallesCFDIs.Location = new System.Drawing.Point(4, 20);
			this.btnExportarDetallesCFDIs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportarDetallesCFDIs.Name = "btnExportarDetallesCFDIs";
			this.btnExportarDetallesCFDIs.Size = new System.Drawing.Size(154, 88);
			this.btnExportarDetallesCFDIs.TabIndex = 144;
			this.btnExportarDetallesCFDIs.Text = "Detalles CFDI'S 4.0";
			this.btnExportarDetallesCFDIs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarDetallesCFDIs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarDetallesCFDIs.UseVisualStyleBackColor = false;
			this.btnExportarDetallesCFDIs.Click += new System.EventHandler(btnExportarDetallesCFDIs_Click);
			this.tcCalculosIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCalculosIVA.Controls.Add(this.tabPage1);
			this.tcCalculosIVA.Controls.Add(this.tpImpresion);
			this.tcCalculosIVA.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcCalculosIVA.Location = new System.Drawing.Point(15, 29);
			this.tcCalculosIVA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcCalculosIVA.Name = "tcCalculosIVA";
			this.tcCalculosIVA.SelectedIndex = 0;
			this.tcCalculosIVA.Size = new System.Drawing.Size(1532, 885);
			this.tcCalculosIVA.TabIndex = 129;
			this.tcCalculosIVA.SelectedIndexChanged += new System.EventHandler(tcPedidosGrids_SelectedIndexChanged);
			this.tpImpresion.Controls.Add(this.rvCalculoIVA);
			this.tpImpresion.Location = new System.Drawing.Point(4, 31);
			this.tpImpresion.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpImpresion.Name = "tpImpresion";
			this.tpImpresion.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpImpresion.Size = new System.Drawing.Size(1524, 850);
			this.tpImpresion.TabIndex = 1;
			this.tpImpresion.Text = "Impresión";
			this.tpImpresion.UseVisualStyleBackColor = true;
			this.rvCalculoIVA.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvCalculoIVA.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptDeclaracionIVA.rdlc";
			this.rvCalculoIVA.Location = new System.Drawing.Point(0, 5);
			this.rvCalculoIVA.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvCalculoIVA.Name = "rvCalculoIVA";
			this.rvCalculoIVA.ServerReport.BearerToken = null;
			this.rvCalculoIVA.Size = new System.Drawing.Size(1282, 782);
			this.rvCalculoIVA.TabIndex = 4;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.flpEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flpEmpresas.Controls.Add(this.label24);
			this.flpEmpresas.Controls.Add(this.cmbEmpresas);
			this.flpEmpresas.Controls.Add(this.btnBuscaEmpresa);
			this.flpEmpresas.Location = new System.Drawing.Point(420, 6);
			this.flpEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flpEmpresas.Name = "flpEmpresas";
			this.flpEmpresas.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.flpEmpresas.Size = new System.Drawing.Size(832, 51);
			this.flpEmpresas.TabIndex = 139;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(4, 3);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
			this.label24.Size = new System.Drawing.Size(108, 39);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(741, 8);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(52, 38);
			this.btnBuscaEmpresa.TabIndex = 139;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.btnBuscaEmpresa.Click += new System.EventHandler(btnBuscaEmpresa_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1556, 918);
			base.Controls.Add(this.flpEmpresas);
			base.Controls.Add(this.tcCalculosIVA);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "CalculoIVA";
			this.Text = "Cálculo IVA";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tabPage1.ResumeLayout(false);
			this.gbInformacionCFDI40.ResumeLayout(false);
			this.flpObjetoImpuesto.ResumeLayout(false);
			this.flowLayoutPanel56.ResumeLayout(false);
			this.flowLayoutPanel56.PerformLayout();
			this.flowLayoutPanel57.ResumeLayout(false);
			this.flowLayoutPanel57.PerformLayout();
			this.flowLayoutPanel58.ResumeLayout(false);
			this.flowLayoutPanel58.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.flpRecibidos.ResumeLayout(false);
			this.flpRecibidos.PerformLayout();
			this.flowLayoutPanel22.ResumeLayout(false);
			this.flowLayoutPanel22.PerformLayout();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			this.flowLayoutPanel23.ResumeLayout(false);
			this.flowLayoutPanel23.PerformLayout();
			this.toolStrip8.ResumeLayout(false);
			this.toolStrip8.PerformLayout();
			this.flowLayoutPanel24.ResumeLayout(false);
			this.flowLayoutPanel24.PerformLayout();
			this.toolStrip9.ResumeLayout(false);
			this.toolStrip9.PerformLayout();
			this.flowLayoutPanel25.ResumeLayout(false);
			this.flowLayoutPanel25.PerformLayout();
			this.toolStrip10.ResumeLayout(false);
			this.toolStrip10.PerformLayout();
			this.flowLayoutPanel26.ResumeLayout(false);
			this.flowLayoutPanel26.PerformLayout();
			this.toolStrip11.ResumeLayout(false);
			this.toolStrip11.PerformLayout();
			this.pnlExportaDetallesCFDIsEgresos.ResumeLayout(false);
			this.flpCalculosIVA.ResumeLayout(false);
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel6.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel60.ResumeLayout(false);
			this.flowLayoutPanel60.PerformLayout();
			this.flowLayoutPanel61.ResumeLayout(false);
			this.flowLayoutPanel61.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.flowLayoutPanel11.ResumeLayout(false);
			this.flowLayoutPanel11.PerformLayout();
			this.flowLayoutPanel15.ResumeLayout(false);
			this.flowLayoutPanel15.PerformLayout();
			this.flowLayoutPanel59.ResumeLayout(false);
			this.flowLayoutPanel59.PerformLayout();
			this.flowLayoutPanel13.ResumeLayout(false);
			this.flowLayoutPanel13.PerformLayout();
			this.flowLayoutPanel20.ResumeLayout(false);
			this.flowLayoutPanel20.PerformLayout();
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowLayoutPanel5.PerformLayout();
			this.flowLayoutPanel21.ResumeLayout(false);
			this.flowLayoutPanel21.PerformLayout();
			this.flowLayoutPanel55.ResumeLayout(false);
			this.flowLayoutPanel55.PerformLayout();
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.flowLayoutPanel12.ResumeLayout(false);
			this.flowLayoutPanel12.PerformLayout();
			this.flpCalculosIvaRif.ResumeLayout(false);
			this.flowLayoutPanel10.ResumeLayout(false);
			this.flowLayoutPanel10.PerformLayout();
			this.flowLayoutPanel18.ResumeLayout(false);
			this.flowLayoutPanel18.PerformLayout();
			this.flowLayoutPanel27.ResumeLayout(false);
			this.flowLayoutPanel27.PerformLayout();
			this.flowLayoutPanel47.ResumeLayout(false);
			this.flowLayoutPanel47.PerformLayout();
			this.flowLayoutPanel28.ResumeLayout(false);
			this.flowLayoutPanel28.PerformLayout();
			this.flowLayoutPanel30.ResumeLayout(false);
			this.flowLayoutPanel30.PerformLayout();
			this.flowLayoutPanel31.ResumeLayout(false);
			this.flowLayoutPanel31.PerformLayout();
			this.flowLayoutPanel32.ResumeLayout(false);
			this.flowLayoutPanel32.PerformLayout();
			this.flowLayoutPanel33.ResumeLayout(false);
			this.flowLayoutPanel33.PerformLayout();
			this.flowLayoutPanel35.ResumeLayout(false);
			this.flowLayoutPanel35.PerformLayout();
			this.flowLayoutPanel50.ResumeLayout(false);
			this.flowLayoutPanel50.PerformLayout();
			this.flowLayoutPanel48.ResumeLayout(false);
			this.flowLayoutPanel48.PerformLayout();
			this.flowLayoutPanel34.ResumeLayout(false);
			this.flowLayoutPanel34.PerformLayout();
			this.flowLayoutPanel51.ResumeLayout(false);
			this.flowLayoutPanel51.PerformLayout();
			this.flowLayoutPanel37.ResumeLayout(false);
			this.flowLayoutPanel37.PerformLayout();
			this.flowLayoutPanel38.ResumeLayout(false);
			this.flowLayoutPanel38.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel40.ResumeLayout(false);
			this.flowLayoutPanel40.PerformLayout();
			this.flowLayoutPanel42.ResumeLayout(false);
			this.flowLayoutPanel42.PerformLayout();
			this.flowLayoutPanel52.ResumeLayout(false);
			this.flowLayoutPanel52.PerformLayout();
			this.flowLayoutPanel53.ResumeLayout(false);
			this.flowLayoutPanel53.PerformLayout();
			this.flowLayoutPanel54.ResumeLayout(false);
			this.flowLayoutPanel54.PerformLayout();
			this.flowLayoutPanel43.ResumeLayout(false);
			this.flowLayoutPanel43.PerformLayout();
			this.flowLayoutPanel44.ResumeLayout(false);
			this.flowLayoutPanel44.PerformLayout();
			this.flowLayoutPanel46.ResumeLayout(false);
			this.flowLayoutPanel46.PerformLayout();
			this.flpEmitidos.ResumeLayout(false);
			this.flpEmitidos.PerformLayout();
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.flowLayoutPanel16.ResumeLayout(false);
			this.flowLayoutPanel16.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.flowLayoutPanel17.ResumeLayout(false);
			this.flowLayoutPanel17.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			this.flowLayoutPanel19.ResumeLayout(false);
			this.flowLayoutPanel19.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.pnlIngresosPgCi.ResumeLayout(false);
			this.pnlIngresosPgCi.PerformLayout();
			this.gbActos.ResumeLayout(false);
			this.pnlActos.ResumeLayout(false);
			this.pnlActos.PerformLayout();
			this.pnlExportaDetallesCFDIs.ResumeLayout(false);
			this.tcCalculosIVA.ResumeLayout(false);
			this.tpImpresion.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.flpEmpresas.ResumeLayout(false);
			this.flpEmpresas.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
