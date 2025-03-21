using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class AnalisisComprobantesEgresos : FormBase
	{
		private IContainer components = null;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private ComboBox cmbEmpresas;

		private TabPage tabPage1;

		private FlowLayoutPanel flowLayoutPanel10;

		private ToolStrip toolStrip4;

		private ToolStripLabel toolStripLabel13;

		private ToolStripTextBox tstNumPUEant;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripLabel toolStripLabel14;

		private ToolStripTextBox tstSubPUEant;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripLabel toolStripLabel15;

		private ToolStripTextBox tstIvaPUEant;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripLabel toolStripLabel16;

		private ToolStripTextBox tstImportePUEant;

		private TabControl tcCFDIs;

		private TabPage tpDeducibles;

		private Label label7;

		private FlowLayoutPanel flowLayoutPanel7;

		private CheckBox chkPUE;

		private CheckBox chkPPD;

		private CheckBox chkComplementosPago;

		private Button btnFiltrarComprobantes;

		private FlowLayoutPanel flpTotales;

		private FlowLayoutPanel flowLayoutPanel6;

		private TextBox txtTotalPPD;

		private Label label6;

		private FlowLayoutPanel flpTotalPUE;

		private TextBox txtTotalPUE;

		private Label label2;

		private FlowLayoutPanel flpTotalCP;

		private TextBox txtTotalCP;

		private Label label4;

		private FlowLayoutPanel flpTotalTotal;

		private TextBox txtTotal;

		private Label label5;

		private FlowLayoutPanel flowLayoutPanel11;

		private TextBox textBox2;

		private Label label8;

		private Label label1;

		private TextBox textBox1;

		private DataGridView gvXMLs;

		private FlowLayoutPanel flpPUE;

		private FlowLayoutPanel flpTotalesTodos;

		private ToolStrip toolStrip1;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNumPUEe;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotalPUEe;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel17;

		private ToolStripTextBox tstxtIvaPUEe;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstxtRetencionesPUEe;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImportePUEe;

		private FlowLayoutPanel flowLayoutPanel8;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tstxtNumCPe;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox tstxtSubtotalCPe;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tstxtIvaCPe;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel18;

		private ToolStripTextBox tstxtRetencionesCPe;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tstxtImporteCPe;

		private FlowLayoutPanel flowLayoutPanel9;

		private ToolStrip toolStrip3;

		private ToolStripLabel toolStripLabel9;

		private ToolStripTextBox tstxtNumTotale;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripLabel toolStripLabel10;

		private ToolStripTextBox tstxtSubtotalTotale;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripLabel toolStripLabel11;

		private ToolStripTextBox tstxtIvaTotale;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripLabel toolStripLabel19;

		private ToolStripTextBox tstxtRetencionesTotale;

		private ToolStripSeparator toolStripSeparator15;

		private ToolStripLabel toolStripLabel12;

		private ToolStripTextBox tstxtImporteTotale;

		private Panel pnlFiltroFechas;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Panel pnlPorDiaVentas;

		private DateTimePicker dtpFechaHasta;

		private DateTimePicker dtpFechaDesde;

		private RadioButton rdoPorFechasComprobantes;

		private Label label3;

		private TextBox txtCantidadVentas;

		private TabControl tcPedidosGrids;

		private FlowLayoutPanel flpExporta;

		private Button btnEnviarAExcel;

		private CheckBox chkEgresos;

		private FlowLayoutPanel flowLayoutPanel13;

		private TextBox txtTotalEgresos;

		private Label label9;

		private FlowLayoutPanel flowLayoutPanel14;

		private ToolStrip toolStrip5;

		private ToolStripLabel toolStripLabel20;

		private ToolStripTextBox tstxtNumEge;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripLabel toolStripLabel21;

		private ToolStripTextBox tstxtSubtotalEge;

		private ToolStripSeparator toolStripSeparator17;

		private ToolStripLabel toolStripLabel22;

		private ToolStripTextBox tstxtIvaEge;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripLabel toolStripLabel23;

		private ToolStripTextBox tstxtRetencionesEge;

		private ToolStripSeparator toolStripSeparator19;

		private ToolStripLabel toolStripLabel24;

		private ToolStripTextBox tstxtImporteEge;

		private ToolStripLabel toolStripLabel25;

		private ToolStripTextBox tstRetencionesPUEant;

		private ToolStripSeparator toolStripSeparator20;

		private FlowLayoutPanel flowLayoutPanel15;

		private ToolStrip toolStrip6;

		private ToolStripLabel toolStripLabel26;

		private ToolStripTextBox tstxtNumNDe;

		private ToolStripSeparator toolStripSeparator21;

		private ToolStripLabel toolStripLabel27;

		private ToolStripTextBox tstxtSubtotalNDe;

		private ToolStripSeparator toolStripSeparator22;

		private ToolStripLabel toolStripLabel28;

		private ToolStripTextBox tstxtIvaNDe;

		private ToolStripSeparator toolStripSeparator23;

		private ToolStripLabel toolStripLabel29;

		private ToolStripTextBox tstxtRetencionesNDe;

		private ToolStripSeparator toolStripSeparator24;

		private ToolStripLabel toolStripLabel30;

		private ToolStripTextBox tstxtImporteNDe;

		private TabPage tpNoDeducibles;

		private DataGridView gvXMLsNoDeducibles;

		private FlowLayoutPanel flowLayoutPanel16;

		private CheckBox chkExcluirNC03;

		private CheckBox chkExcluirNC01;

		private Panel pnlFiltro;

		private Label label10;

		private TextBox txtRFCFiltro;

		private Label label11;

		private TextBox txtNombre;

		private Label label12;

		private TextBox txtUUIDfiltro;

		private Button btnFiltraFacturas;

		private Label label13;

		private TextBox txtFacturaFiltro;

		private GroupBox gbObjetos;

		private FlowLayoutPanel flpObjetoImpuesto;

		private FlowLayoutPanel flowLayoutPanel56;

		private Label label14;

		private TextBox txtObjetoImpuesto01;

		private FlowLayoutPanel flowLayoutPanel57;

		private Label label15;

		private TextBox txtObjetoImpuesto02;

		private FlowLayoutPanel flowLayoutPanel58;

		private Label label49;

		private TextBox txtObjetoImpuesto03;

		private Label label17;

		private FlowLayoutPanel flowLayoutPanel1;

		private Label label16;

		private TextBox txtObjetoImpuestoTotal;

		private DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn FechaPagoS;

		private new DataGridViewTextBoxColumn TipoComprobante;

		private DataGridViewTextBoxColumn MetodoPago;

		private DataGridViewTextBoxColumn FormaPago;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn retencionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn TipoCambio;

		private DataGridViewTextBoxColumn UsoCFDI;

		private DataGridViewCheckBoxColumn Deducible;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

		private TabPage tpCFDIsCPaPUE;

		private DataGridView gvCPaPUE;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;

		private Button btnExportaSAT;

		private FlowLayoutPanel flpEmpresas;

		private Label label24;

		private Button btnBuscaEmpresa;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantesObjetos { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public AnalisisComprobantesEgresos()
		{
			InitializeComponent();
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñoComprobantes);
			cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
			cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
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
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CargaComprobantes(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
			gvXMLs.DataSource = ListaComprobantes;
			gvXMLs.Refresh();
			txtTotalPUE.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total));
			txtTotalCP.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.Total));
			txtTotal.Text = FormatoMoney(ConvierteTextoADecimal(txtTotalPUE) + ConvierteTextoADecimal(txtTotalCP));
			txtTotalPPD.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 2).Sum((EntFactura P) => P.Total));
			txtTotalEgresos.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 2 && (P.TipoRelacionId == 1 || P.TipoRelacionId == 7)).Sum((EntFactura P) => P.Total));
			ListaComprobantesObjetos = new BusFacturas().ObtieneComprobantesFiscalesEgresosObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantesObjetos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1));
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, bool PUE, bool PPD, bool Complementos, bool Egresos, bool ExcluyeNc01, bool ExcluyeNc03)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			List<EntFactura> lstFiltroObjetos = new List<EntFactura>();
			if (ListaComprobantes == null)
			{
				return;
			}
			if (PUE || PPD || Complementos || Egresos)
			{
				lstFiltro = ListaComprobantes.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03 && P.Deducible)).ToList();
				lstFiltroObjetos = ListaComprobantesObjetos.Where((EntFactura P) => (((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03)) && P.Deducible).ToList();
			}
			gvXMLs.DataSource = lstFiltro.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtNombre.Text.ToUpper())).ToList();
			gvXMLs.Refresh();
			gvXMLsNoDeducibles.DataSource = lstFiltro.Where((EntFactura P) => !P.Deducible && P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtNombre.Text.ToUpper())).ToList();
			gvXMLsNoDeducibles.Refresh();
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUEe.TextBox, tstxtSubtotalPUEe.TextBox, tstxtIvaPUEe.TextBox, tstxtRetencionesPUEe.TextBox, tstxtNumPUEe.TextBox);
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList(), false, tstxtImporteCPe.TextBox, tstxtSubtotalCPe.TextBox, tstxtIvaCPe.TextBox, tstxtRetencionesCPe.TextBox, tstxtNumCPe.TextBox);
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03 && P.Deducible)).ToList(), false, tstxtImporteEge.TextBox, tstxtSubtotalEge.TextBox, tstxtIvaEge.TextBox, tstxtRetencionesEge.TextBox, tstxtNumEge.TextBox);
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => ((P.TipoComprobanteId == 1 && P.MetodoPagoId == 1) || P.TipoComprobanteId == 5) && !P.Deducible).ToList(), false, tstxtImporteNDe.TextBox, tstxtSubtotalNDe.TextBox, tstxtIvaNDe.TextBox, tstxtRetencionesNDe.TextBox, tstxtNumNDe.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUEe.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCPe.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEge.TextBox) - ConvierteTextoADecimal(tstxtSubtotalNDe.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUEe.TextBox) + ConvierteTextoADecimal(tstxtIvaCPe.TextBox) - ConvierteTextoADecimal(tstxtIvaEge.TextBox) - ConvierteTextoADecimal(tstxtIvaNDe.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUEe.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCPe.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEge.TextBox) - ConvierteTextoADecimal(tstxtRetencionesNDe.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUEe.TextBox) + ConvierteTextoADecimal(tstxtImporteCPe.TextBox) - ConvierteTextoADecimal(tstxtImporteEge.TextBox) - ConvierteTextoADecimal(tstxtImporteNDe.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUEe.TextBox) + ConvierteTextoADecimal(tstxtNumCPe.TextBox) + ConvierteTextoADecimal(tstxtNumEge.TextBox) + ConvierteTextoADecimal(tstxtNumNDe.TextBox);
			tstxtSubtotalTotale.TextBox.Text = FormatoMoney(subtotal);
			tstxtIvaTotale.TextBox.Text = FormatoMoney(iva);
			tstxtRetencionesTotale.TextBox.Text = FormatoMoney(retenciones);
			tstxtImporteTotale.TextBox.Text = FormatoMoney(total);
			tstxtNumTotale.TextBox.Text = num.ToString();
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago < FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList(), false, tstImportePUEant.TextBox, tstSubPUEant.TextBox, tstIvaPUEant.TextBox, tstRetencionesPUEant.TextBox, tstNumPUEant.TextBox);
			lstFiltroObjetos = lstFiltroObjetos.Where((EntFactura P) => P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today) || P.TipoComprobanteId == 1).ToList();
			txtObjetoImpuesto01.Text = FormatoMoney(lstFiltroObjetos.Sum((EntFactura P) => P.ObjetoImpuesto01));
			txtObjetoImpuesto02.Text = FormatoMoney(lstFiltroObjetos.Sum((EntFactura P) => P.ObjetoImpuesto02));
			txtObjetoImpuesto03.Text = FormatoMoney(lstFiltroObjetos.Sum((EntFactura P) => P.ObjetoImpuesto03));
			txtObjetoImpuestoTotal.Text = FormatoMoney(ConvierteTextoADecimal(txtObjetoImpuesto01) + ConvierteTextoADecimal(txtObjetoImpuesto02) + ConvierteTextoADecimal(txtObjetoImpuesto03));
			decimal objetoImp = lstFiltroObjetos.Where((EntFactura P) => P.TipoFactorId == 3).Sum((EntFactura P) => P.ObjetoImpuesto02);
			RevisaCPaPUE(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList(), ListaComprobantes);
		}

		private int RevisaCPencontrados(List<EntFactura> ListaComplementosPago)
		{
			int cont = 0;
			foreach (EntFactura cp in ListaComplementosPago.Where((EntFactura P) => !P.Pagado))
			{
				string[] facPPD = cp.UUIDrelacionado.Split('|');
				string[] array = new string[1] { cp.UUIDrelacionado };
				foreach (string s in array)
				{
					if (!string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lstFacPPD = new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s);
						if (lstFacPPD.Count > 0)
						{
							EntFactura fac = lstFacPPD.First();
							new BusFacturas().AumentaPagoComprobanteFiscalEgresos(fac.Id, cp.Total);
							new BusFacturas().VerificaComprobanteFiscalPagadoEgresos(fac.Id);
							new BusFacturas().ActualizaComprobanteFiscalPagadoEgresos(cp.Id, true);
							cont++;
						}
					}
				}
			}
			return cont;
		}

		private int RevisaDepositoEnFacturaPPD(List<EntFactura> ListaComplementosPago)
		{
			int cont = 0;
			foreach (EntFactura cp in ListaComplementosPago.Where((EntFactura P) => P.FacturaRelacionId != 0).ToList())
			{
				List<EntFactura> lstDepositos = new BusFacturas().ObtieneEstadosDeCuentaDetalleEgresos(cp.FacturaRelacionId);
				List<EntFactura> lstDepositosCP = new BusFacturas().ObtieneEstadosDeCuentaDetalleFacturaRelacionadaEgresos(cp.FacturaRelacionId);
				decimal totalDeposito = lstDepositos.Sum((EntFactura P) => P.Pago);
				decimal totalDepositoCP = lstDepositosCP.Sum((EntFactura P) => P.Pago);
				decimal diferencia = totalDeposito - totalDepositoCP;
				if (diferencia > 0m)
				{
					decimal deposito = cp.Total;
					if (diferencia >= cp.Total)
					{
						new BusFacturas().AgregaEstadoDeCuentaComprobanteEgresos(0, cp, cp.Total, cp.FacturaRelacionId, cp.UUIDrelacionado);
					}
					else
					{
						deposito = diferencia;
						new BusFacturas().AgregaEstadoDeCuentaComprobanteEgresos(0, cp, diferencia, cp.FacturaRelacionId, cp.UUIDrelacionado);
					}
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacionEgresos(cp.Id, 1);
					new BusFacturas().AumentaDepositoComprobanteFiscalEgresos(cp.Id, deposito);
					new BusFacturas().VerificaComprobanteFiscalDepositadoEgresos(cp.Id);
					cont++;
				}
			}
			return cont;
		}

		public int RevisaAnticipoPagadoEnComprobantes(List<EntFactura> ListaComprobantesFiscales)
		{
			List<EntFactura> lstFacConAnticipo = ListaComprobantesFiscales.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.TipoRelacionId == 7).ToList();
			int cont = 0;
			foreach (EntFactura f in lstFacConAnticipo)
			{
				string[] anticipos = f.UUIDrelacionado.Split('|');
				string[] array = anticipos;
				foreach (string s in array)
				{
					if (!string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lstFacAnticipos = (from P in new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s)
							where !P.Pagado
							select P).ToList();
						if (lstFacAnticipos.Count > 0)
						{
							EntFactura anticipo = lstFacAnticipos.First();
							new BusFacturas().AumentaPagoComprobanteFiscalEgresos(f.Id, anticipo.Total);
							new BusFacturas().VerificaComprobanteFiscalPagadoEgresos(f.Id);
							new BusFacturas().ActualizaComprobanteFiscalPagadoEgresos(anticipo.Id, true);
							cont++;
						}
					}
				}
			}
			return cont;
		}

		public int RevisaAnticipoComprobantes(List<EntFactura> ListaComprobantesFiscales)
		{
			List<EntFactura> lstFacConAnticipo = ListaComprobantesFiscales.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.TipoRelacionId == 7).ToList();
			int cont = 0;
			foreach (EntFactura f in lstFacConAnticipo)
			{
				string[] anticipos = f.UUIDrelacionado.Split('|');
				string[] array = anticipos;
				foreach (string s in array)
				{
					if (string.IsNullOrWhiteSpace(s))
					{
						continue;
					}
					List<EntFactura> lstFacAnticipos = new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s);
					if (lstFacAnticipos.Count > 0)
					{
						EntFactura anticipo = lstFacAnticipos.First();
						List<EntFactura> lstFacAnticiposDepositos = new BusFacturas().ObtieneEstadosDeCuentaDetalleFacturaRelacionadaEgresos(anticipo.Id);
						if (lstFacAnticiposDepositos.Count == 0)
						{
							new BusFacturas().AgregaEstadoDeCuentaComprobanteEgresos(0, f, anticipo.Total, anticipo.Id, anticipo.UUID);
							new BusFacturas().AumentaDepositoComprobanteFiscalEgresos(f.Id, anticipo.Total);
							new BusFacturas().VerificaComprobanteFiscalDepositadoEgresos(f.Id);
							cont++;
						}
					}
				}
			}
			return cont;
		}

		public int RevisaEgresosComprobantes(List<EntFactura> ListaComprobantesFiscales)
		{
			List<EntFactura> lstEgresosAnticipo = ListaComprobantesFiscales.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.EstatusId != 5).ToList();
			int cont = 0;
			foreach (EntFactura f in lstEgresosAnticipo)
			{
				string[] facturaIngresoConAnticipo = f.UUIDrelacionado.Split('|');
				string[] array = facturaIngresoConAnticipo;
				foreach (string s in array)
				{
					if (string.IsNullOrWhiteSpace(s))
					{
						continue;
					}
					List<EntFactura> lstFacIngConAnticipos = new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s);
					if (lstFacIngConAnticipos.Count > 0)
					{
						EntFactura facIngConAnticipo = lstFacIngConAnticipos.First();
						if (facIngConAnticipo.MetodoPagoId == 2)
						{
							new BusFacturas().ActualizaEstatusComprobanteFiscalEgresos(f.Id, 5);
							cont++;
						}
					}
				}
			}
			return cont;
		}

		public int RevisaEgresoNcPagadoEnComprobantes(List<EntFactura> ListaComprobantesFiscales)
		{
			int cont = 0;
			foreach (EntFactura f in ListaComprobantesFiscales)
			{
				string[] facturaIngreso = f.UUIDrelacionado.Split('|');
				string[] array = facturaIngreso;
				foreach (string s in array)
				{
					if (string.IsNullOrWhiteSpace(s))
					{
						continue;
					}
					List<EntFactura> lstFacIngRelacionada = new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s);
					if (lstFacIngRelacionada.Count > 0)
					{
						EntFactura facIng = lstFacIngRelacionada.First();
						new BusFacturas().AumentaPagoComprobanteFiscalEgresos(facIng.Id, f.Total);
						new BusFacturas().VerificaComprobanteFiscalPagadoEgresos(facIng.Id);
						new BusFacturas().ActualizaComprobanteFiscalPagadoEgresos(f.Id, true);
						facIng.Pago = f.Total;
						new BusFacturas().AgregaEstadoDeCuentaComprobanteEgresos(0, facIng);
						new BusFacturas().AumentaDepositoComprobanteFiscalEgresos(facIng.Id, f.Total);
						new BusFacturas().VerificaComprobanteFiscalDepositadoEgresos(facIng.Id);
						if (facIng.MetodoPagoId == 2)
						{
							new BusFacturas().ActualizaEstatusComprobanteFiscalEgresos(f.Id, 5);
						}
						cont++;
					}
				}
			}
			return cont;
		}

		private void RevisaTodo(List<EntFactura> ListaComprobantesFiscales)
		{
			int cantCPencontrados = RevisaCPencontrados(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.EstatusId == 1).ToList());
			int cantDepEnFactura = RevisaDepositoEnFacturaPPD(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.EstatusId == 1).ToList());
			int cantFacturasConAntPago = RevisaAnticipoPagadoEnComprobantes(ListaComprobantes);
			int cantFacturasConAnt = RevisaAnticipoComprobantes(ListaComprobantes);
			int cantEgresosRelacionados = RevisaEgresosComprobantes(ListaComprobantes);
			int cantEgresosNcRelacionados = RevisaEgresoNcPagadoEnComprobantes(new BusFacturas().ObtieneComprobantesFiscalesEgresosNcNoPagados(Program.EmpresaSeleccionada));
			MuestraMensaje($"SE ENCONTRARON: \n\n {cantCPencontrados} PAGOS AGREGADOS A FACTURA PPD\n {cantDepEnFactura} REP CON PAGOS ANTERIORES A FACTURA PPD\n {cantFacturasConAnt} COMPROBANTES FISCALES RECIBIDOS COMO ANTICIPOS RELACIONADOS\n {cantEgresosRelacionados} COMPROBANTES FISCALES EGRESO RELACIONADOS COMO ANTICIPOS");
			if (cantEgresosRelacionados > 0 || cantEgresosNcRelacionados > 0)
			{
				CargaComprobantes(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				FiltraComprobantes(ListaComprobantes, chkPUE.Checked, chkPPD.Checked, chkComplementosPago.Checked, chkEgresos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked);
			}
		}

		private void RevisaCPaPUE(List<EntFactura> ListaComprobantesCP, List<EntFactura> ListaFacturas)
		{
			List<EntFactura> lstCPaPUEencontrados = new List<EntFactura>();
			foreach (EntFactura f in ListaComprobantesCP)
			{
				string s = f.UUIDrelacionado;
				if (string.IsNullOrWhiteSpace(s))
				{
					continue;
				}
				if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().Count > 0)
				{
					if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().First()
						.MetodoPagoId == 1)
					{
						lstCPaPUEencontrados.Add(f);
					}
					continue;
				}
				List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s);
				if (lst.Count > 0 && lst.Where((EntFactura P) => P.UUID == s).ToList().First()
					.MetodoPagoId == 1)
				{
					lstCPaPUEencontrados.Add(f);
				}
			}
			gvCPaPUE.DataSource = lstCPaPUEencontrados;
			gvCPaPUE.Refresh();
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				CargaComprobantes(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				FiltraComprobantes(ListaComprobantes, chkPUE.Checked, chkPPD.Checked, chkComplementosPago.Checked, chkEgresos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked);
				RevisaTodo(ListaComprobantes);
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

		private void btnFiltrarComprobantes_Click(object sender, EventArgs e)
		{
			try
			{
				FiltraComprobantes(ListaComprobantes, chkPUE.Checked, chkPPD.Checked, chkComplementosPago.Checked, chkEgresos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnEnviarAExcel_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (gvXMLs.Rows == null || gvXMLs.Rows.Count <= 0)
				{
					MandaExcepcion("No hay registros a Exportar");
				}
				string nombreArchivo = "XMLsFlujo";
				if (chkPUE.Checked)
				{
					nombreArchivo += "PUE";
				}
				if (chkComplementosPago.Checked)
				{
					nombreArchivo += "-CP";
				}
				if (chkEgresos.Checked)
				{
					nombreArchivo += "-E";
				}
				List<EntFactura> xmls = new List<EntFactura>();
				if (tcCFDIs.SelectedIndex == 0)
				{
					xmls = (from P in ObtieneListaFacturasFromGV(gvXMLs)
						where P.TipoComprobanteId != 5 || (P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today))
						select P).ToList();
				}
				else if (tcCFDIs.SelectedIndex == 1)
				{
					xmls = (from P in ObtieneListaFacturasFromGV(gvXMLsNoDeducibles)
						where P.TipoComprobanteId != 5 || (P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today))
						select P).ToList();
				}
				else if (tcCFDIs.SelectedIndex == 2)
				{
					xmls = (from P in ObtieneListaFacturasFromGV(gvCPaPUE)
						where P.TipoComprobanteId != 5 || (P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today))
						select P).ToList();
				}
				ImprimeCFDIsFlujoEgresos vImprime = new ImprimeCFDIsFlujoEgresos(xmls, tstxtNumPUEe.TextBox.Text, tstxtNumCPe.TextBox.Text, tstxtNumEge.TextBox.Text, tstxtNumNDe.TextBox.Text, tstxtNumTotale.TextBox.Text, tstxtSubtotalPUEe.TextBox.Text, tstxtSubtotalCPe.TextBox.Text, tstxtSubtotalEge.TextBox.Text, tstxtSubtotalNDe.TextBox.Text, tstxtSubtotalTotale.TextBox.Text, tstxtIvaPUEe.TextBox.Text, tstxtIvaCPe.TextBox.Text, tstxtIvaEge.TextBox.Text, tstxtIvaNDe.TextBox.Text, tstxtIvaTotale.TextBox.Text, tstxtRetencionesPUEe.TextBox.Text, tstxtRetencionesCPe.TextBox.Text, tstxtRetencionesEge.TextBox.Text, tstxtRetencionesNDe.TextBox.Text, tstxtRetencionesTotale.TextBox.Text, tstxtImportePUEe.TextBox.Text, tstxtImporteCPe.TextBox.Text, tstxtImporteEge.TextBox.Text, tstxtImporteNDe.TextBox.Text, tstxtImporteTotale.TextBox.Text);
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

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					gvXMLs.DataSource = new List<EntFactura>();
					gvXMLs.Refresh();
					chkExcluirNC01.Checked = Program.EmpresaSeleccionada.ExcluyeNc01;
					chkExcluirNC03.Checked = Program.EmpresaSeleccionada.ExcluyeNc03;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void chkExcluirNC01_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				Program.EmpresaSeleccionada.ExcluyeNc01 = chkExcluirNC01.Checked;
				Program.EmpresaSeleccionada.ExcluyeNc03 = chkExcluirNC03.Checked;
				new BusEmpresas().ActualizaEmpresaExcluyeNc(Program.EmpresaSeleccionada);
				FiltraComprobantes(ListaComprobantes, chkPUE.Checked, chkPPD.Checked, chkComplementosPago.Checked, chkEgresos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnFiltraFacturas_Click(object sender, EventArgs e)
		{
			try
			{
				FiltraComprobantes(ListaComprobantes, chkPUE.Checked, chkPPD.Checked, chkComplementosPago.Checked, chkEgresos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private List<EntFactura> RevisaCPusoCFDI(List<EntFactura> ListaComprobantesCP, List<EntFactura> ListaFacturas)
		{
			List<EntFactura> lstCPaPUEencontrados = new List<EntFactura>();
			foreach (EntFactura f in ListaComprobantesCP)
			{
				string s = f.UUIDrelacionado;
				if (string.IsNullOrWhiteSpace(s))
				{
					continue;
				}
				if (ListaFacturas.Where((EntFactura P) => P.UUID == s && (P.UsoCFDIId == 1 || P.UsoCFDIId == 3)).ToList().Count > 0)
				{
					lstCPaPUEencontrados.Add(f);
					continue;
				}
				List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscalesEgresos(base.EmpresaSeleccionada, s);
				if (lst.Count > 0)
				{
					int usoCFDI = lst.Where((EntFactura P) => P.UUID == s).ToList().First()
						.UsoCFDIId;
					if (usoCFDI == 1 || usoCFDI == 3)
					{
						lstCPaPUEencontrados.Add(f);
					}
				}
			}
			return lstCPaPUEencontrados;
		}

		private void btnExportaSAT_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (ListaComprobantes == null)
				{
					MandaExcepcion("No hay registros a Exportar");
				}
				string nombreArchivo = "XMLsFlujoDeclaracionFiscalSAT";
				List<EntFactura> xmls = new List<EntFactura>();
				List<EntFactura> xmlsCP = new List<EntFactura>();
				xmlsCP = RevisaCPusoCFDI(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today) && (P.FormaPagoId == 2 || P.FormaPagoId == 3 || P.FormaPagoId == 4 || P.FormaPagoId == 28)).ToList(), ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && (P.UsoCFDIId == 1 || P.UsoCFDIId == 3)).ToList());
				xmls = ListaComprobantes.Where((EntFactura P) => (P.MetodoPagoId == 1 && P.TipoComprobanteId == 1 && (P.UsoCFDIId == 1 || P.UsoCFDIId == 3) && (P.FormaPagoId == 2 || P.FormaPagoId == 3 || P.FormaPagoId == 4 || P.FormaPagoId == 28)) || (P.MetodoPagoId == 1 && P.TipoComprobanteId == 2)).ToList();
				xmls.AddRange((from P in new BusFacturas().ObtieneComprobantesFiscalesEgresos(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), 5)
					where P.MetodoPagoId == 1 && P.TipoComprobanteId == 2
					select P).ToList());
				xmls.AddRange(xmlsCP);
				ImprimeCFDIsFlujoEgresosSinTotales vImprime = new ImprimeCFDIsFlujoEgresosSinTotales(xmls, tstxtNumPUEe.TextBox.Text, tstxtNumCPe.TextBox.Text, tstxtNumEge.TextBox.Text, tstxtNumNDe.TextBox.Text, tstxtNumTotale.TextBox.Text, tstxtSubtotalPUEe.TextBox.Text, tstxtSubtotalCPe.TextBox.Text, tstxtSubtotalEge.TextBox.Text, tstxtSubtotalNDe.TextBox.Text, tstxtSubtotalTotale.TextBox.Text, tstxtIvaPUEe.TextBox.Text, tstxtIvaCPe.TextBox.Text, tstxtIvaEge.TextBox.Text, tstxtIvaNDe.TextBox.Text, tstxtIvaTotale.TextBox.Text, tstxtRetencionesPUEe.TextBox.Text, tstxtRetencionesCPe.TextBox.Text, tstxtRetencionesEge.TextBox.Text, tstxtRetencionesNDe.TextBox.Text, tstxtRetencionesTotale.TextBox.Text, tstxtImportePUEe.TextBox.Text, tstxtImporteCPe.TextBox.Text, tstxtImporteEge.TextBox.Text, tstxtImporteNDe.TextBox.Text, tstxtImporteTotale.TextBox.Text);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.AnalisisComprobantesEgresos));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle66 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle67 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle68 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle69 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle70 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle71 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle72 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle73 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle74 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle75 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle76 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle77 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle78 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle79 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle80 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle81 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle82 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle83 = new System.Windows.Forms.DataGridViewCellStyle();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnlFiltro = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.txtRFCFiltro = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtUUIDfiltro = new System.Windows.Forms.TextBox();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.txtFacturaFiltro = new System.Windows.Forms.TextBox();
			this.flpExporta = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEnviarAExcel = new System.Windows.Forms.Button();
			this.btnExportaSAT = new System.Windows.Forms.Button();
			this.pnlFiltroFechas = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.pnlPorDiaVentas = new System.Windows.Forms.Panel();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.rdoPorFechasComprobantes = new System.Windows.Forms.RadioButton();
			this.tcCFDIs = new System.Windows.Forms.TabControl();
			this.tpDeducibles = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
			this.chkExcluirNC03 = new System.Windows.Forms.CheckBox();
			this.chkExcluirNC01 = new System.Windows.Forms.CheckBox();
			this.flpTotales = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPPD = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.flpTotalPUE = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPUE = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flpTotalCP = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalCP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.flpTotalTotal = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalEgresos = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumPUEant = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubPUEant = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaPUEant = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel25 = new System.Windows.Forms.ToolStripLabel();
			this.tstRetencionesPUEant = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel16 = new System.Windows.Forms.ToolStripLabel();
			this.tstImportePUEant = new System.Windows.Forms.ToolStripTextBox();
			this.flpPUE = new System.Windows.Forms.FlowLayoutPanel();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel17 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImportePUEe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel18 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteCPe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel20 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel21 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel22 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel23 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel24 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteEge = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel26 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel27 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel28 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel29 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel30 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteNDe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel19 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteTotale = new System.Windows.Forms.ToolStripTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.chkPUE = new System.Windows.Forms.CheckBox();
			this.chkPPD = new System.Windows.Forms.CheckBox();
			this.chkComplementosPago = new System.Windows.Forms.CheckBox();
			this.chkEgresos = new System.Windows.Forms.CheckBox();
			this.btnFiltrarComprobantes = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaPagoS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.retencionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UsoCFDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Deducible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tpNoDeducibles = new System.Windows.Forms.TabPage();
			this.gvXMLsNoDeducibles = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tpCFDIsCPaPUE = new System.Windows.Forms.TabPage();
			this.gvCPaPUE = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.gbObjetos = new System.Windows.Forms.GroupBox();
			this.flpObjetoImpuesto = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel56 = new System.Windows.Forms.FlowLayoutPanel();
			this.label14 = new System.Windows.Forms.Label();
			this.txtObjetoImpuesto01 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel57 = new System.Windows.Forms.FlowLayoutPanel();
			this.label15 = new System.Windows.Forms.Label();
			this.txtObjetoImpuesto02 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel58 = new System.Windows.Forms.FlowLayoutPanel();
			this.label49 = new System.Windows.Forms.Label();
			this.txtObjetoImpuesto03 = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.label16 = new System.Windows.Forms.Label();
			this.txtObjetoImpuestoTotal = new System.Windows.Forms.TextBox();
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.flpEmpresas = new System.Windows.Forms.FlowLayoutPanel();
			this.label24 = new System.Windows.Forms.Label();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tabPage1.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			this.flpExporta.SuspendLayout();
			this.pnlFiltroFechas.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			this.pnlPorDiaVentas.SuspendLayout();
			this.tcCFDIs.SuspendLayout();
			this.tpDeducibles.SuspendLayout();
			this.flowLayoutPanel16.SuspendLayout();
			this.flpTotales.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.flpTotalPUE.SuspendLayout();
			this.flpTotalCP.SuspendLayout();
			this.flpTotalTotal.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.flowLayoutPanel13.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			this.flpPUE.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel8.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			this.flowLayoutPanel15.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.flowLayoutPanel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tpNoDeducibles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLsNoDeducibles).BeginInit();
			this.tpCFDIsCPaPUE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCPaPUE).BeginInit();
			this.gbObjetos.SuspendLayout();
			this.flpObjetoImpuesto.SuspendLayout();
			this.flowLayoutPanel56.SuspendLayout();
			this.flowLayoutPanel57.SuspendLayout();
			this.flowLayoutPanel58.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tcPedidosGrids.SuspendLayout();
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
			this.cmbEmpresas.Size = new System.Drawing.Size(607, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.tabPage1.Controls.Add(this.pnlFiltro);
			this.tabPage1.Controls.Add(this.flpExporta);
			this.tabPage1.Controls.Add(this.pnlFiltroFechas);
			this.tabPage1.Controls.Add(this.tcCFDIs);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Controls.Add(this.gbObjetos);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1667, 899);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Flujo de Comprobantes Fiscales ";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltro.Controls.Add(this.label10);
			this.pnlFiltro.Controls.Add(this.txtRFCFiltro);
			this.pnlFiltro.Controls.Add(this.label11);
			this.pnlFiltro.Controls.Add(this.txtNombre);
			this.pnlFiltro.Controls.Add(this.label12);
			this.pnlFiltro.Controls.Add(this.txtUUIDfiltro);
			this.pnlFiltro.Controls.Add(this.btnFiltraFacturas);
			this.pnlFiltro.Controls.Add(this.label13);
			this.pnlFiltro.Controls.Add(this.txtFacturaFiltro);
			this.pnlFiltro.Location = new System.Drawing.Point(9, 145);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(1043, 47);
			this.pnlFiltro.TabIndex = 0;
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(9, 12);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(41, 18);
			this.label10.TabIndex = 137;
			this.label10.Text = "R.F.C:";
			this.txtRFCFiltro.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtRFCFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFCFiltro.Location = new System.Drawing.Point(62, 9);
			this.txtRFCFiltro.Name = "txtRFCFiltro";
			this.txtRFCFiltro.Size = new System.Drawing.Size(130, 28);
			this.txtRFCFiltro.TabIndex = 0;
			this.txtRFCFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(208, 12);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(61, 18);
			this.label11.TabIndex = 135;
			this.label11.Text = "Nombre:";
			this.txtNombre.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtNombre.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombre.Location = new System.Drawing.Point(278, 9);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(204, 28);
			this.txtNombre.TabIndex = 1;
			this.txtNombre.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(492, 14);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(45, 18);
			this.label12.TabIndex = 133;
			this.label12.Text = "UUID:";
			this.txtUUIDfiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtUUIDfiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtUUIDfiltro.Location = new System.Drawing.Point(546, 9);
			this.txtUUIDfiltro.Name = "txtUUIDfiltro";
			this.txtUUIDfiltro.Size = new System.Drawing.Size(241, 28);
			this.txtUUIDfiltro.TabIndex = 2;
			this.txtUUIDfiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(978, 0);
			this.btnFiltraFacturas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(58, 43);
			this.btnFiltraFacturas.TabIndex = 4;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(801, 14);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(40, 18);
			this.label13.TabIndex = 97;
			this.label13.Text = "Folio:";
			this.txtFacturaFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtFacturaFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFacturaFiltro.Location = new System.Drawing.Point(850, 9);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(112, 28);
			this.txtFacturaFiltro.TabIndex = 3;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.flpExporta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flpExporta.Controls.Add(this.btnEnviarAExcel);
			this.flpExporta.Controls.Add(this.btnExportaSAT);
			this.flpExporta.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpExporta.Location = new System.Drawing.Point(1334, 129);
			this.flpExporta.Margin = new System.Windows.Forms.Padding(2);
			this.flpExporta.Name = "flpExporta";
			this.flpExporta.Size = new System.Drawing.Size(318, 100);
			this.flpExporta.TabIndex = 141;
			this.btnEnviarAExcel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcel.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcel.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcel.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcel.Location = new System.Drawing.Point(180, 5);
			this.btnEnviarAExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEnviarAExcel.Name = "btnEnviarAExcel";
			this.btnEnviarAExcel.Size = new System.Drawing.Size(134, 92);
			this.btnEnviarAExcel.TabIndex = 133;
			this.btnEnviarAExcel.Text = "Enviar a Excel";
			this.btnEnviarAExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcel.UseVisualStyleBackColor = false;
			this.btnEnviarAExcel.Click += new System.EventHandler(btnEnviarAExcel_Click);
			this.btnExportaSAT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnExportaSAT.BackColor = System.Drawing.Color.White;
			this.btnExportaSAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnExportaSAT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportaSAT.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportaSAT.Image = LeeXML.Properties.Resources.SAT;
			this.btnExportaSAT.Location = new System.Drawing.Point(38, 5);
			this.btnExportaSAT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportaSAT.Name = "btnExportaSAT";
			this.btnExportaSAT.Size = new System.Drawing.Size(134, 92);
			this.btnExportaSAT.TabIndex = 134;
			this.btnExportaSAT.Text = "Declaración Fiscal";
			this.btnExportaSAT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportaSAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportaSAT.UseVisualStyleBackColor = false;
			this.btnExportaSAT.Click += new System.EventHandler(btnExportaSAT_Click);
			this.pnlFiltroFechas.Controls.Add(this.btnRefrescar);
			this.pnlFiltroFechas.Controls.Add(this.rdoPorMesComprobantes);
			this.pnlFiltroFechas.Controls.Add(this.pnlPorMesVentas);
			this.pnlFiltroFechas.Controls.Add(this.pnlPorDiaVentas);
			this.pnlFiltroFechas.Controls.Add(this.rdoPorFechasComprobantes);
			this.pnlFiltroFechas.Location = new System.Drawing.Point(3, 23);
			this.pnlFiltroFechas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlFiltroFechas.Name = "pnlFiltroFechas";
			this.pnlFiltroFechas.Size = new System.Drawing.Size(626, 97);
			this.pnlFiltroFechas.TabIndex = 135;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(482, 3);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(102, 88);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(12, 37);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(84, 22);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(118, 18);
			this.pnlPorMesVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(364, 52);
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
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(114, 33);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaHasta);
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaDesde);
			this.pnlPorDiaVentas.Enabled = false;
			this.pnlPorDiaVentas.Location = new System.Drawing.Point(118, 49);
			this.pnlPorDiaVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorDiaVentas.Name = "pnlPorDiaVentas";
			this.pnlPorDiaVentas.Size = new System.Drawing.Size(364, 49);
			this.pnlPorDiaVentas.TabIndex = 42;
			this.pnlPorDiaVentas.Visible = false;
			this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaHasta.Location = new System.Drawing.Point(178, 11);
			this.dtpFechaHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dtpFechaHasta.Name = "dtpFechaHasta";
			this.dtpFechaHasta.Size = new System.Drawing.Size(163, 25);
			this.dtpFechaHasta.TabIndex = 16;
			this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaDesde.Location = new System.Drawing.Point(8, 11);
			this.dtpFechaDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.dtpFechaDesde.Name = "dtpFechaDesde";
			this.dtpFechaDesde.Size = new System.Drawing.Size(163, 25);
			this.dtpFechaDesde.TabIndex = 15;
			this.rdoPorFechasComprobantes.AutoSize = true;
			this.rdoPorFechasComprobantes.Location = new System.Drawing.Point(12, 65);
			this.rdoPorFechasComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorFechasComprobantes.Name = "rdoPorFechasComprobantes";
			this.rdoPorFechasComprobantes.Size = new System.Drawing.Size(99, 22);
			this.rdoPorFechasComprobantes.TabIndex = 43;
			this.rdoPorFechasComprobantes.Text = "Por Fechas";
			this.rdoPorFechasComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorFechasComprobantes.Visible = false;
			this.tcCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCFDIs.Controls.Add(this.tpDeducibles);
			this.tcCFDIs.Controls.Add(this.tpNoDeducibles);
			this.tcCFDIs.Controls.Add(this.tpCFDIsCPaPUE);
			this.tcCFDIs.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcCFDIs.Location = new System.Drawing.Point(9, 198);
			this.tcCFDIs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcCFDIs.Name = "tcCFDIs";
			this.tcCFDIs.SelectedIndex = 0;
			this.tcCFDIs.Size = new System.Drawing.Size(1647, 688);
			this.tcCFDIs.TabIndex = 136;
			this.tpDeducibles.Controls.Add(this.flowLayoutPanel16);
			this.tpDeducibles.Controls.Add(this.flowLayoutPanel10);
			this.tpDeducibles.Controls.Add(this.flpPUE);
			this.tpDeducibles.Controls.Add(this.label7);
			this.tpDeducibles.Controls.Add(this.flowLayoutPanel7);
			this.tpDeducibles.Controls.Add(this.label1);
			this.tpDeducibles.Controls.Add(this.textBox1);
			this.tpDeducibles.Controls.Add(this.gvXMLs);
			this.tpDeducibles.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tpDeducibles.Location = new System.Drawing.Point(4, 31);
			this.tpDeducibles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpDeducibles.Name = "tpDeducibles";
			this.tpDeducibles.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpDeducibles.Size = new System.Drawing.Size(1639, 653);
			this.tpDeducibles.TabIndex = 0;
			this.tpDeducibles.Text = "CFDI'S PUE/CP DEDUCIBLES";
			this.tpDeducibles.UseVisualStyleBackColor = true;
			this.flowLayoutPanel16.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel16.Controls.Add(this.chkExcluirNC03);
			this.flowLayoutPanel16.Controls.Add(this.chkExcluirNC01);
			this.flowLayoutPanel16.Controls.Add(this.flpTotales);
			this.flowLayoutPanel16.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel16.Location = new System.Drawing.Point(875, 2);
			this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel16.Name = "flowLayoutPanel16";
			this.flowLayoutPanel16.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flowLayoutPanel16.Size = new System.Drawing.Size(761, 44);
			this.flowLayoutPanel16.TabIndex = 142;
			this.chkExcluirNC03.AutoSize = true;
			this.chkExcluirNC03.Location = new System.Drawing.Point(537, 8);
			this.chkExcluirNC03.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkExcluirNC03.Name = "chkExcluirNC03";
			this.chkExcluirNC03.Size = new System.Drawing.Size(214, 22);
			this.chkExcluirNC03.TabIndex = 0;
			this.chkExcluirNC03.Text = "Excluir Devoluciones (NC '03')";
			this.chkExcluirNC03.UseVisualStyleBackColor = true;
			this.chkExcluirNC03.CheckedChanged += new System.EventHandler(chkExcluirNC01_CheckedChanged);
			this.chkExcluirNC01.AutoSize = true;
			this.chkExcluirNC01.Location = new System.Drawing.Point(231, 8);
			this.chkExcluirNC01.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkExcluirNC01.Name = "chkExcluirNC01";
			this.chkExcluirNC01.Size = new System.Drawing.Size(302, 22);
			this.chkExcluirNC01.TabIndex = 1;
			this.chkExcluirNC01.Text = "Excluir Descuentos o Bonifcaciones (NC '01')";
			this.chkExcluirNC01.UseVisualStyleBackColor = true;
			this.chkExcluirNC01.CheckedChanged += new System.EventHandler(chkExcluirNC01_CheckedChanged);
			this.flpTotales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotales.Controls.Add(this.flowLayoutPanel6);
			this.flpTotales.Controls.Add(this.flpTotalPUE);
			this.flpTotales.Controls.Add(this.flpTotalCP);
			this.flpTotales.Controls.Add(this.flpTotalTotal);
			this.flpTotales.Controls.Add(this.flowLayoutPanel11);
			this.flpTotales.Controls.Add(this.flowLayoutPanel13);
			this.flpTotales.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpTotales.Location = new System.Drawing.Point(504, 35);
			this.flpTotales.Name = "flpTotales";
			this.flpTotales.Size = new System.Drawing.Size(246, 385);
			this.flpTotales.TabIndex = 137;
			this.flpTotales.Visible = false;
			this.flowLayoutPanel6.Controls.Add(this.txtTotalPPD);
			this.flowLayoutPanel6.Controls.Add(this.label6);
			this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Size = new System.Drawing.Size(238, 37);
			this.flowLayoutPanel6.TabIndex = 0;
			this.flowLayoutPanel6.Visible = false;
			this.txtTotalPPD.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPPD.Location = new System.Drawing.Point(59, 3);
			this.txtTotalPPD.Name = "txtTotalPPD";
			this.txtTotalPPD.ReadOnly = true;
			this.txtTotalPPD.Size = new System.Drawing.Size(176, 28);
			this.txtTotalPPD.TabIndex = 1;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 8);
			this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(37, 18);
			this.label6.TabIndex = 0;
			this.label6.Text = "PPD:";
			this.flpTotalPUE.Controls.Add(this.txtTotalPUE);
			this.flpTotalPUE.Controls.Add(this.label2);
			this.flpTotalPUE.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpTotalPUE.Location = new System.Drawing.Point(3, 46);
			this.flpTotalPUE.Name = "flpTotalPUE";
			this.flpTotalPUE.Size = new System.Drawing.Size(238, 37);
			this.flpTotalPUE.TabIndex = 0;
			this.txtTotalPUE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPUE.Location = new System.Drawing.Point(59, 3);
			this.txtTotalPUE.Name = "txtTotalPUE";
			this.txtTotalPUE.ReadOnly = true;
			this.txtTotalPUE.Size = new System.Drawing.Size(176, 28);
			this.txtTotalPUE.TabIndex = 1;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 8);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "PUE:";
			this.flpTotalCP.Controls.Add(this.txtTotalCP);
			this.flpTotalCP.Controls.Add(this.label4);
			this.flpTotalCP.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpTotalCP.Location = new System.Drawing.Point(3, 89);
			this.flpTotalCP.Name = "flpTotalCP";
			this.flpTotalCP.Size = new System.Drawing.Size(238, 37);
			this.flpTotalCP.TabIndex = 1;
			this.txtTotalCP.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalCP.Location = new System.Drawing.Point(59, 3);
			this.txtTotalCP.Name = "txtTotalCP";
			this.txtTotalCP.ReadOnly = true;
			this.txtTotalCP.Size = new System.Drawing.Size(176, 28);
			this.txtTotalCP.TabIndex = 1;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(25, 8);
			this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "CP:";
			this.flpTotalTotal.Controls.Add(this.txtTotal);
			this.flpTotalTotal.Controls.Add(this.label5);
			this.flpTotalTotal.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpTotalTotal.Location = new System.Drawing.Point(3, 132);
			this.flpTotalTotal.Name = "flpTotalTotal";
			this.flpTotalTotal.Size = new System.Drawing.Size(238, 37);
			this.flpTotalTotal.TabIndex = 2;
			this.flpTotalTotal.Visible = false;
			this.txtTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotal.Location = new System.Drawing.Point(59, 3);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(176, 28);
			this.txtTotal.TabIndex = 1;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 8);
			this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "Total:";
			this.flowLayoutPanel11.Controls.Add(this.textBox2);
			this.flowLayoutPanel11.Controls.Add(this.label8);
			this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel11.Location = new System.Drawing.Point(3, 175);
			this.flowLayoutPanel11.Name = "flowLayoutPanel11";
			this.flowLayoutPanel11.Size = new System.Drawing.Size(238, 37);
			this.flowLayoutPanel11.TabIndex = 3;
			this.flowLayoutPanel11.Visible = false;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.textBox2.Location = new System.Drawing.Point(105, 3);
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(130, 28);
			this.textBox2.TabIndex = 1;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(10, 8);
			this.label8.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(89, 18);
			this.label8.TabIndex = 0;
			this.label8.Text = "Tota Tasa 0%";
			this.flowLayoutPanel13.Controls.Add(this.txtTotalEgresos);
			this.flowLayoutPanel13.Controls.Add(this.label9);
			this.flowLayoutPanel13.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel13.Location = new System.Drawing.Point(3, 218);
			this.flowLayoutPanel13.Name = "flowLayoutPanel13";
			this.flowLayoutPanel13.Size = new System.Drawing.Size(238, 37);
			this.flowLayoutPanel13.TabIndex = 142;
			this.txtTotalEgresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalEgresos.Location = new System.Drawing.Point(105, 3);
			this.txtTotalEgresos.Name = "txtTotalEgresos";
			this.txtTotalEgresos.ReadOnly = true;
			this.txtTotalEgresos.Size = new System.Drawing.Size(130, 28);
			this.txtTotalEgresos.TabIndex = 1;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(31, 8);
			this.label9.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "EGRESOS:";
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.flowLayoutPanel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel10.Controls.Add(this.toolStrip4);
			this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel10.Location = new System.Drawing.Point(267, 594);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Padding = new System.Windows.Forms.Padding(6, 2, 6, 0);
			this.flowLayoutPanel10.Size = new System.Drawing.Size(1367, 36);
			this.flowLayoutPanel10.TabIndex = 141;
			this.toolStrip4.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel13, this.tstNumPUEant, this.toolStripSeparator10, this.toolStripLabel14, this.tstSubPUEant, this.toolStripSeparator11, this.toolStripLabel15, this.tstIvaPUEant, this.toolStripSeparator12, this.toolStripLabel25,
				this.tstRetencionesPUEant, this.toolStripSeparator20, this.toolStripLabel16, this.tstImportePUEant
			});
			this.toolStrip4.Location = new System.Drawing.Point(6, 2);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip4.Size = new System.Drawing.Size(1196, 32);
			this.toolStrip4.TabIndex = 2;
			this.toolStrip4.Text = "toolStrip4";
			this.toolStripLabel13.Name = "toolStripLabel13";
			this.toolStripLabel13.Size = new System.Drawing.Size(448, 27);
			this.toolStripLabel13.Text = "*Complementos de Pago depositados en Mes anterior:";
			this.tstNumPUEant.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumPUEant.Name = "tstNumPUEant";
			this.tstNumPUEant.ReadOnly = true;
			this.tstNumPUEant.Size = new System.Drawing.Size(52, 32);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel14.Name = "toolStripLabel14";
			this.toolStripLabel14.Size = new System.Drawing.Size(84, 27);
			this.toolStripLabel14.Text = "SubTotal:";
			this.tstSubPUEant.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubPUEant.Name = "tstSubPUEant";
			this.tstSubPUEant.ReadOnly = true;
			this.tstSubPUEant.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel15.Name = "toolStripLabel15";
			this.toolStripLabel15.Size = new System.Drawing.Size(52, 27);
			this.toolStripLabel15.Text = "I.V.A:";
			this.tstIvaPUEant.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaPUEant.Name = "tstIvaPUEant";
			this.tstIvaPUEant.ReadOnly = true;
			this.tstIvaPUEant.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel25.Name = "toolStripLabel25";
			this.toolStripLabel25.Size = new System.Drawing.Size(110, 27);
			this.toolStripLabel25.Text = "Retenciones:";
			this.tstRetencionesPUEant.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstRetencionesPUEant.Name = "tstRetencionesPUEant";
			this.tstRetencionesPUEant.ReadOnly = true;
			this.tstRetencionesPUEant.Size = new System.Drawing.Size(56, 32);
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel16.Name = "toolStripLabel16";
			this.toolStripLabel16.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel16.Text = "Total:";
			this.tstImportePUEant.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImportePUEant.Name = "tstImportePUEant";
			this.tstImportePUEant.ReadOnly = true;
			this.tstImportePUEant.Size = new System.Drawing.Size(39, 32);
			this.flpPUE.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpPUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPUE.Controls.Add(this.flpTotalesTodos);
			this.flpPUE.Controls.Add(this.flowLayoutPanel8);
			this.flpPUE.Controls.Add(this.flowLayoutPanel14);
			this.flpPUE.Controls.Add(this.flowLayoutPanel15);
			this.flpPUE.Controls.Add(this.flowLayoutPanel9);
			this.flpPUE.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPUE.Location = new System.Drawing.Point(477, 382);
			this.flpPUE.Margin = new System.Windows.Forms.Padding(2);
			this.flpPUE.Name = "flpPUE";
			this.flpPUE.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpPUE.Size = new System.Drawing.Size(1157, 210);
			this.flpPUE.TabIndex = 140;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(2, 4);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(2);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(1151, 36);
			this.flpTotalesTodos.TabIndex = 135;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel3, this.tstxtNumPUEe, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotalPUEe, this.toolStripSeparator1, this.toolStripLabel17, this.tstxtIvaPUEe, this.toolStripSeparator2, this.toolStripLabel1,
				this.tstxtRetencionesPUEe, this.toolStripSeparator13, this.toolStripLabel2, this.tstxtImportePUEe
			});
			this.toolStrip1.Location = new System.Drawing.Point(0, 2);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(972, 32);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(142, 27);
			this.toolStripLabel3.Text = "                   PUE:";
			this.tstxtNumPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUEe.Name = "tstxtNumPUEe";
			this.tstxtNumPUEe.ReadOnly = true;
			this.tstxtNumPUEe.Size = new System.Drawing.Size(52, 32);
			this.tstxtNumPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(84, 27);
			this.toolStripLabel4.Text = "SubTotal:";
			this.tstxtSubtotalPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUEe.Name = "tstxtSubtotalPUEe";
			this.tstxtSubtotalPUEe.ReadOnly = true;
			this.tstxtSubtotalPUEe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel17.Name = "toolStripLabel17";
			this.toolStripLabel17.Size = new System.Drawing.Size(52, 27);
			this.toolStripLabel17.Text = "I.V.A:";
			this.tstxtIvaPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUEe.Name = "tstxtIvaPUEe";
			this.tstxtIvaPUEe.ReadOnly = true;
			this.tstxtIvaPUEe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(110, 27);
			this.toolStripLabel1.Text = "Retenciones:";
			this.tstxtRetencionesPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUEe.Name = "tstxtRetencionesPUEe";
			this.tstxtRetencionesPUEe.ReadOnly = true;
			this.tstxtRetencionesPUEe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel2.Text = "Total:";
			this.tstxtImportePUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImportePUEe.Name = "tstxtImportePUEe";
			this.tstxtImportePUEe.ReadOnly = true;
			this.tstxtImportePUEe.Size = new System.Drawing.Size(56, 32);
			this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel8.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel8.Location = new System.Drawing.Point(2, 44);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel8.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel8.TabIndex = 136;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel5, this.tstxtNumCPe, this.toolStripSeparator3, this.toolStripLabel6, this.tstxtSubtotalCPe, this.toolStripSeparator5, this.toolStripLabel7, this.tstxtIvaCPe, this.toolStripSeparator6, this.toolStripLabel18,
				this.tstxtRetencionesCPe, this.toolStripSeparator14, this.toolStripLabel8, this.tstxtImporteCPe
			});
			this.toolStrip2.Location = new System.Drawing.Point(0, 2);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(972, 32);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(142, 27);
			this.toolStripLabel5.Text = "                     CP:";
			this.tstxtNumCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumCPe.Name = "tstxtNumCPe";
			this.tstxtNumCPe.ReadOnly = true;
			this.tstxtNumCPe.Size = new System.Drawing.Size(52, 32);
			this.tstxtNumCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(84, 27);
			this.toolStripLabel6.Text = "SubTotal:";
			this.tstxtSubtotalCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalCPe.Name = "tstxtSubtotalCPe";
			this.tstxtSubtotalCPe.ReadOnly = true;
			this.tstxtSubtotalCPe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(52, 27);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tstxtIvaCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaCPe.Name = "tstxtIvaCPe";
			this.tstxtIvaCPe.ReadOnly = true;
			this.tstxtIvaCPe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel18.Name = "toolStripLabel18";
			this.toolStripLabel18.Size = new System.Drawing.Size(110, 27);
			this.toolStripLabel18.Text = "Retenciones:";
			this.tstxtRetencionesCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCPe.Name = "tstxtRetencionesCPe";
			this.tstxtRetencionesCPe.ReadOnly = true;
			this.tstxtRetencionesCPe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel8.Text = "Total:";
			this.tstxtImporteCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporteCPe.Name = "tstxtImporteCPe";
			this.tstxtImporteCPe.ReadOnly = true;
			this.tstxtImporteCPe.Size = new System.Drawing.Size(56, 32);
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel14.Controls.Add(this.toolStrip5);
			this.flowLayoutPanel14.Location = new System.Drawing.Point(2, 84);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel14.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel14.TabIndex = 138;
			this.toolStrip5.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel20, this.tstxtNumEge, this.toolStripSeparator16, this.toolStripLabel21, this.tstxtSubtotalEge, this.toolStripSeparator17, this.toolStripLabel22, this.tstxtIvaEge, this.toolStripSeparator18, this.toolStripLabel23,
				this.tstxtRetencionesEge, this.toolStripSeparator19, this.toolStripLabel24, this.tstxtImporteEge
			});
			this.toolStrip5.Location = new System.Drawing.Point(0, 2);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip5.Size = new System.Drawing.Size(970, 32);
			this.toolStrip5.TabIndex = 2;
			this.toolStrip5.Text = "toolStrip5";
			this.toolStripLabel20.Name = "toolStripLabel20";
			this.toolStripLabel20.Size = new System.Drawing.Size(140, 27);
			this.toolStripLabel20.Text = "          - Egresos:";
			this.tstxtNumEge.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumEge.Name = "tstxtNumEge";
			this.tstxtNumEge.ReadOnly = true;
			this.tstxtNumEge.Size = new System.Drawing.Size(52, 32);
			this.tstxtNumEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel21.Name = "toolStripLabel21";
			this.toolStripLabel21.Size = new System.Drawing.Size(84, 27);
			this.toolStripLabel21.Text = "SubTotal:";
			this.tstxtSubtotalEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEge.Name = "tstxtSubtotalEge";
			this.tstxtSubtotalEge.ReadOnly = true;
			this.tstxtSubtotalEge.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel22.Name = "toolStripLabel22";
			this.toolStripLabel22.Size = new System.Drawing.Size(52, 27);
			this.toolStripLabel22.Text = "I.V.A:";
			this.tstxtIvaEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEge.Name = "tstxtIvaEge";
			this.tstxtIvaEge.ReadOnly = true;
			this.tstxtIvaEge.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel23.Name = "toolStripLabel23";
			this.toolStripLabel23.Size = new System.Drawing.Size(110, 27);
			this.toolStripLabel23.Text = "Retenciones:";
			this.tstxtRetencionesEge.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesEge.Name = "tstxtRetencionesEge";
			this.tstxtRetencionesEge.ReadOnly = true;
			this.tstxtRetencionesEge.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel24.Name = "toolStripLabel24";
			this.toolStripLabel24.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel24.Text = "Total:";
			this.tstxtImporteEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteEge.Name = "tstxtImporteEge";
			this.tstxtImporteEge.ReadOnly = true;
			this.tstxtImporteEge.Size = new System.Drawing.Size(56, 32);
			this.flowLayoutPanel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel15.Controls.Add(this.toolStrip6);
			this.flowLayoutPanel15.Location = new System.Drawing.Point(2, 124);
			this.flowLayoutPanel15.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel15.Name = "flowLayoutPanel15";
			this.flowLayoutPanel15.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel15.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel15.TabIndex = 139;
			this.toolStrip6.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel26, this.tstxtNumNDe, this.toolStripSeparator21, this.toolStripLabel27, this.tstxtSubtotalNDe, this.toolStripSeparator22, this.toolStripLabel28, this.tstxtIvaNDe, this.toolStripSeparator23, this.toolStripLabel29,
				this.tstxtRetencionesNDe, this.toolStripSeparator24, this.toolStripLabel30, this.tstxtImporteNDe
			});
			this.toolStrip6.Location = new System.Drawing.Point(0, 2);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip6.Size = new System.Drawing.Size(966, 32);
			this.toolStrip6.TabIndex = 2;
			this.toolStrip6.Text = "toolStrip6";
			this.toolStripLabel26.Name = "toolStripLabel26";
			this.toolStripLabel26.Size = new System.Drawing.Size(136, 27);
			this.toolStripLabel26.Text = "- No Deducible:";
			this.tstxtNumNDe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumNDe.Name = "tstxtNumNDe";
			this.tstxtNumNDe.ReadOnly = true;
			this.tstxtNumNDe.Size = new System.Drawing.Size(52, 32);
			this.tstxtNumNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel27.Name = "toolStripLabel27";
			this.toolStripLabel27.Size = new System.Drawing.Size(84, 27);
			this.toolStripLabel27.Text = "SubTotal:";
			this.tstxtSubtotalNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalNDe.Name = "tstxtSubtotalNDe";
			this.tstxtSubtotalNDe.ReadOnly = true;
			this.tstxtSubtotalNDe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel28.Name = "toolStripLabel28";
			this.toolStripLabel28.Size = new System.Drawing.Size(52, 27);
			this.toolStripLabel28.Text = "I.V.A:";
			this.tstxtIvaNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaNDe.Name = "tstxtIvaNDe";
			this.tstxtIvaNDe.ReadOnly = true;
			this.tstxtIvaNDe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel29.Name = "toolStripLabel29";
			this.toolStripLabel29.Size = new System.Drawing.Size(110, 27);
			this.toolStripLabel29.Text = "Retenciones:";
			this.tstxtRetencionesNDe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesNDe.Name = "tstxtRetencionesNDe";
			this.tstxtRetencionesNDe.ReadOnly = true;
			this.tstxtRetencionesNDe.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator24.Name = "toolStripSeparator24";
			this.toolStripSeparator24.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel30.Name = "toolStripLabel30";
			this.toolStripLabel30.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel30.Text = "Total:";
			this.tstxtImporteNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteNDe.Name = "tstxtImporteNDe";
			this.tstxtImporteNDe.ReadOnly = true;
			this.tstxtImporteNDe.Size = new System.Drawing.Size(56, 32);
			this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel9.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel9.Location = new System.Drawing.Point(2, 164);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel9.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel9.TabIndex = 137;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel9, this.tstxtNumTotale, this.toolStripSeparator7, this.toolStripLabel10, this.tstxtSubtotalTotale, this.toolStripSeparator8, this.toolStripLabel11, this.tstxtIvaTotale, this.toolStripSeparator9, this.toolStripLabel19,
				this.tstxtRetencionesTotale, this.toolStripSeparator15, this.toolStripLabel12, this.tstxtImporteTotale
			});
			this.toolStrip3.Location = new System.Drawing.Point(0, 2);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip3.Size = new System.Drawing.Size(966, 32);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStripLabel9.Name = "toolStripLabel9";
			this.toolStripLabel9.Size = new System.Drawing.Size(136, 27);
			this.toolStripLabel9.Text = "        Total Flujo:";
			this.tstxtNumTotale.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumTotale.Name = "tstxtNumTotale";
			this.tstxtNumTotale.ReadOnly = true;
			this.tstxtNumTotale.Size = new System.Drawing.Size(52, 32);
			this.tstxtNumTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel10.Name = "toolStripLabel10";
			this.toolStripLabel10.Size = new System.Drawing.Size(84, 27);
			this.toolStripLabel10.Text = "SubTotal:";
			this.tstxtSubtotalTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotale.Name = "tstxtSubtotalTotale";
			this.tstxtSubtotalTotale.ReadOnly = true;
			this.tstxtSubtotalTotale.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel11.Name = "toolStripLabel11";
			this.toolStripLabel11.Size = new System.Drawing.Size(52, 27);
			this.toolStripLabel11.Text = "I.V.A:";
			this.tstxtIvaTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotale.Name = "tstxtIvaTotale";
			this.tstxtIvaTotale.ReadOnly = true;
			this.tstxtIvaTotale.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel19.Name = "toolStripLabel19";
			this.toolStripLabel19.Size = new System.Drawing.Size(110, 27);
			this.toolStripLabel19.Text = "Retenciones:";
			this.tstxtRetencionesTotale.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotale.Name = "tstxtRetencionesTotale";
			this.tstxtRetencionesTotale.ReadOnly = true;
			this.tstxtRetencionesTotale.Size = new System.Drawing.Size(121, 32);
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 32);
			this.toolStripLabel12.Name = "toolStripLabel12";
			this.toolStripLabel12.Size = new System.Drawing.Size(53, 27);
			this.toolStripLabel12.Text = "Total:";
			this.tstxtImporteTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteTotale.Name = "tstxtImporteTotale";
			this.tstxtImporteTotale.ReadOnly = true;
			this.tstxtImporteTotale.Size = new System.Drawing.Size(56, 32);
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(1401, 425);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(340, 18);
			this.label7.TabIndex = 139;
			this.label7.Text = "*Complementos de Pago depositados en Mes anterior";
			this.label7.Visible = false;
			this.flowLayoutPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel7.Controls.Add(this.chkPUE);
			this.flowLayoutPanel7.Controls.Add(this.chkPPD);
			this.flowLayoutPanel7.Controls.Add(this.chkComplementosPago);
			this.flowLayoutPanel7.Controls.Add(this.chkEgresos);
			this.flowLayoutPanel7.Controls.Add(this.btnFiltrarComprobantes);
			this.flowLayoutPanel7.Location = new System.Drawing.Point(9, 2);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flowLayoutPanel7.Size = new System.Drawing.Size(617, 44);
			this.flowLayoutPanel7.TabIndex = 139;
			this.chkPUE.AutoSize = true;
			this.chkPUE.Checked = true;
			this.chkPUE.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPUE.Location = new System.Drawing.Point(8, 8);
			this.chkPUE.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkPUE.Name = "chkPUE";
			this.chkPUE.Size = new System.Drawing.Size(59, 22);
			this.chkPUE.TabIndex = 0;
			this.chkPUE.Text = "PUE";
			this.chkPUE.UseVisualStyleBackColor = true;
			this.chkPUE.CheckedChanged += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.chkPPD.AutoSize = true;
			this.chkPPD.Location = new System.Drawing.Point(71, 8);
			this.chkPPD.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkPPD.Name = "chkPPD";
			this.chkPPD.Size = new System.Drawing.Size(60, 22);
			this.chkPPD.TabIndex = 1;
			this.chkPPD.Text = "PPD";
			this.chkPPD.UseVisualStyleBackColor = true;
			this.chkPPD.Visible = false;
			this.chkPPD.CheckedChanged += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.chkComplementosPago.AutoSize = true;
			this.chkComplementosPago.Checked = true;
			this.chkComplementosPago.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkComplementosPago.Location = new System.Drawing.Point(135, 8);
			this.chkComplementosPago.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkComplementosPago.Name = "chkComplementosPago";
			this.chkComplementosPago.Size = new System.Drawing.Size(162, 22);
			this.chkComplementosPago.TabIndex = 2;
			this.chkComplementosPago.Text = "Complementos Pago";
			this.chkComplementosPago.UseVisualStyleBackColor = true;
			this.chkComplementosPago.CheckedChanged += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.chkEgresos.AutoSize = true;
			this.chkEgresos.Checked = true;
			this.chkEgresos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEgresos.Location = new System.Drawing.Point(301, 8);
			this.chkEgresos.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkEgresos.Name = "chkEgresos";
			this.chkEgresos.Size = new System.Drawing.Size(143, 22);
			this.chkEgresos.TabIndex = 134;
			this.chkEgresos.Text = "Egresos (Anticipo)";
			this.chkEgresos.UseVisualStyleBackColor = true;
			this.chkEgresos.CheckedChanged += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.btnFiltrarComprobantes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltrarComprobantes.BackColor = System.Drawing.Color.White;
			this.btnFiltrarComprobantes.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnFiltrarComprobantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltrarComprobantes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltrarComprobantes.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltrarComprobantes.Location = new System.Drawing.Point(450, 3);
			this.btnFiltrarComprobantes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 5);
			this.btnFiltrarComprobantes.Name = "btnFiltrarComprobantes";
			this.btnFiltrarComprobantes.Size = new System.Drawing.Size(39, 37);
			this.btnFiltrarComprobantes.TabIndex = 133;
			this.btnFiltrarComprobantes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFiltrarComprobantes.UseVisualStyleBackColor = false;
			this.btnFiltrarComprobantes.Click += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1582, 938);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 18);
			this.label1.TabIndex = 128;
			this.label1.Text = "Cantidad:";
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(1654, 932);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 25);
			this.textBox1.TabIndex = 127;
			this.gvXMLs.AllowUserToAddRows = false;
			this.gvXMLs.AllowUserToResizeRows = false;
			dataGridViewCellStyle37.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle37.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle37.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle37;
			this.gvXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLs.AutoGenerateColumns = false;
			this.gvXMLs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLs.Columns.AddRange(this.rFCDataGridViewTextBoxColumn, this.nombreDataGridViewTextBoxColumn, this.folioDataGridViewTextBoxColumn, this.fechaDataGridViewTextBoxColumn, this.FechaPagoS, this.TipoComprobante, this.MetodoPago, this.FormaPago, this.subTotalDataGridViewTextBoxColumn, this.descuentoDataGridViewTextBoxColumn, this.iVADataGridViewTextBoxColumn, this.retencionesDataGridViewTextBoxColumn, this.totalDataGridViewTextBoxColumn, this.TipoCambio, this.UsoCFDI, this.Deducible);
			this.gvXMLs.DataSource = this.entFacturaBindingSource;
			this.gvXMLs.Location = new System.Drawing.Point(6, 46);
			this.gvXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.ReadOnly = true;
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle49.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle49;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(1631, 333);
			this.gvXMLs.TabIndex = 14;
			this.rFCDataGridViewTextBoxColumn.DataPropertyName = "RFC";
			this.rFCDataGridViewTextBoxColumn.FillWeight = 150f;
			this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
			this.rFCDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
			this.rFCDataGridViewTextBoxColumn.ReadOnly = true;
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
			this.nombreDataGridViewTextBoxColumn.FillWeight = 250f;
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
			this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
			dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.folioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle50;
			this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
			this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
			this.folioDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle51;
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha Timbrado";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.FechaPagoS.DataPropertyName = "FechaPagoS";
			dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.FechaPagoS.DefaultCellStyle = dataGridViewCellStyle52;
			this.FechaPagoS.HeaderText = "Fecha Pago REP";
			this.FechaPagoS.MinimumWidth = 6;
			this.FechaPagoS.Name = "FechaPagoS";
			this.FechaPagoS.ReadOnly = true;
			this.TipoComprobante.DataPropertyName = "TipoComprobante";
			dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.TipoComprobante.DefaultCellStyle = dataGridViewCellStyle53;
			this.TipoComprobante.FillWeight = 80f;
			this.TipoComprobante.HeaderText = "Tipo Comprobante";
			this.TipoComprobante.MinimumWidth = 6;
			this.TipoComprobante.Name = "TipoComprobante";
			this.TipoComprobante.ReadOnly = true;
			this.MetodoPago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MetodoPago.DefaultCellStyle = dataGridViewCellStyle54;
			this.MetodoPago.FillWeight = 50f;
			this.MetodoPago.HeaderText = "Método Pago";
			this.MetodoPago.MinimumWidth = 6;
			this.MetodoPago.Name = "MetodoPago";
			this.MetodoPago.ReadOnly = true;
			this.FormaPago.DataPropertyName = "FormaPago";
			this.FormaPago.FillWeight = 120f;
			this.FormaPago.HeaderText = "Forma Pago";
			this.FormaPago.MinimumWidth = 6;
			this.FormaPago.Name = "FormaPago";
			this.FormaPago.ReadOnly = true;
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle55.Format = "c2";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle55;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
			dataGridViewCellStyle56.Format = "c2";
			this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle56;
			this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
			this.descuentoDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
			this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.Visible = false;
			this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
			dataGridViewCellStyle57.Format = "c2";
			this.iVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle57;
			this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
			this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
			this.iVADataGridViewTextBoxColumn.ReadOnly = true;
			this.retencionesDataGridViewTextBoxColumn.DataPropertyName = "Retenciones";
			dataGridViewCellStyle58.Format = "c2";
			this.retencionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle58;
			this.retencionesDataGridViewTextBoxColumn.HeaderText = "Retenciones";
			this.retencionesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.retencionesDataGridViewTextBoxColumn.Name = "retencionesDataGridViewTextBoxColumn";
			this.retencionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle59.Format = "c2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle59;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.TipoCambio.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle60.Format = "n4";
			this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle60;
			this.TipoCambio.FillWeight = 50f;
			this.TipoCambio.HeaderText = "Tipo Cambio";
			this.TipoCambio.MinimumWidth = 6;
			this.TipoCambio.Name = "TipoCambio";
			this.TipoCambio.ReadOnly = true;
			this.UsoCFDI.DataPropertyName = "UsoCFDI";
			this.UsoCFDI.HeaderText = "Uso CFDI";
			this.UsoCFDI.MinimumWidth = 6;
			this.UsoCFDI.Name = "UsoCFDI";
			this.UsoCFDI.ReadOnly = true;
			this.UsoCFDI.Visible = false;
			this.Deducible.DataPropertyName = "Deducible";
			this.Deducible.HeaderText = "Deducible";
			this.Deducible.MinimumWidth = 6;
			this.Deducible.Name = "Deducible";
			this.Deducible.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tpNoDeducibles.Controls.Add(this.gvXMLsNoDeducibles);
			this.tpNoDeducibles.Location = new System.Drawing.Point(4, 31);
			this.tpNoDeducibles.Name = "tpNoDeducibles";
			this.tpNoDeducibles.Padding = new System.Windows.Forms.Padding(3);
			this.tpNoDeducibles.Size = new System.Drawing.Size(1639, 653);
			this.tpNoDeducibles.TabIndex = 1;
			this.tpNoDeducibles.Text = "CFDI'S  PUE/CP NO DEDUCIBLES";
			this.tpNoDeducibles.UseVisualStyleBackColor = true;
			this.gvXMLsNoDeducibles.AllowUserToAddRows = false;
			this.gvXMLsNoDeducibles.AllowUserToResizeRows = false;
			dataGridViewCellStyle61.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle61.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle61.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvXMLsNoDeducibles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle61;
			this.gvXMLsNoDeducibles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLsNoDeducibles.AutoGenerateColumns = false;
			this.gvXMLsNoDeducibles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLsNoDeducibles.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLsNoDeducibles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLsNoDeducibles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLsNoDeducibles.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewTextBoxColumn13);
			this.gvXMLsNoDeducibles.DataSource = this.entFacturaBindingSource;
			this.gvXMLsNoDeducibles.Location = new System.Drawing.Point(2, 48);
			this.gvXMLsNoDeducibles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvXMLsNoDeducibles.Name = "gvXMLsNoDeducibles";
			this.gvXMLsNoDeducibles.ReadOnly = true;
			this.gvXMLsNoDeducibles.RowHeadersVisible = false;
			this.gvXMLsNoDeducibles.RowHeadersWidth = 51;
			dataGridViewCellStyle62.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle62.ForeColor = System.Drawing.Color.Black;
			this.gvXMLsNoDeducibles.RowsDefaultCellStyle = dataGridViewCellStyle62;
			this.gvXMLsNoDeducibles.RowTemplate.Height = 30;
			this.gvXMLsNoDeducibles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLsNoDeducibles.Size = new System.Drawing.Size(1637, 590);
			this.gvXMLsNoDeducibles.TabIndex = 15;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "RFC";
			this.dataGridViewTextBoxColumn1.FillWeight = 150f;
			this.dataGridViewTextBoxColumn1.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
			this.dataGridViewTextBoxColumn2.FillWeight = 250f;
			this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Folio";
			dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle63;
			this.dataGridViewTextBoxColumn3.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn4.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn5.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle64;
			this.dataGridViewTextBoxColumn6.FillWeight = 120f;
			this.dataGridViewTextBoxColumn6.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn7.FillWeight = 120f;
			this.dataGridViewTextBoxColumn7.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "SubTotal";
			dataGridViewCellStyle65.Format = "c2";
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle65;
			this.dataGridViewTextBoxColumn8.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Descuento";
			dataGridViewCellStyle66.Format = "c2";
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle66;
			this.dataGridViewTextBoxColumn9.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Visible = false;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "IVA";
			dataGridViewCellStyle67.Format = "c2";
			this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle67;
			this.dataGridViewTextBoxColumn10.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Retenciones";
			dataGridViewCellStyle68.Format = "c2";
			this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle68;
			this.dataGridViewTextBoxColumn11.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Total";
			dataGridViewCellStyle69.Format = "c2";
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle69;
			this.dataGridViewTextBoxColumn12.HeaderText = "Total";
			this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle70.Format = "n4";
			this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle70;
			this.dataGridViewTextBoxColumn13.HeaderText = "Tipo Cambio";
			this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.tpCFDIsCPaPUE.Controls.Add(this.gvCPaPUE);
			this.tpCFDIsCPaPUE.Location = new System.Drawing.Point(4, 31);
			this.tpCFDIsCPaPUE.Name = "tpCFDIsCPaPUE";
			this.tpCFDIsCPaPUE.Padding = new System.Windows.Forms.Padding(3);
			this.tpCFDIsCPaPUE.Size = new System.Drawing.Size(1639, 653);
			this.tpCFDIsCPaPUE.TabIndex = 2;
			this.tpCFDIsCPaPUE.Text = "CP APLICADOS A PUE";
			this.tpCFDIsCPaPUE.UseVisualStyleBackColor = true;
			this.gvCPaPUE.AllowUserToAddRows = false;
			this.gvCPaPUE.AllowUserToResizeRows = false;
			dataGridViewCellStyle71.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle71.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle71.ForeColor = System.Drawing.Color.Black;
			this.gvCPaPUE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle71;
			this.gvCPaPUE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvCPaPUE.AutoGenerateColumns = false;
			this.gvCPaPUE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvCPaPUE.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvCPaPUE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvCPaPUE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvCPaPUE.Columns.AddRange(this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.dataGridViewTextBoxColumn18, this.dataGridViewTextBoxColumn19, this.dataGridViewTextBoxColumn20, this.dataGridViewTextBoxColumn21, this.dataGridViewTextBoxColumn22, this.dataGridViewTextBoxColumn23, this.dataGridViewTextBoxColumn24, this.dataGridViewTextBoxColumn25, this.dataGridViewTextBoxColumn26, this.dataGridViewTextBoxColumn27, this.dataGridViewTextBoxColumn28, this.dataGridViewCheckBoxColumn1);
			this.gvCPaPUE.DataSource = this.entFacturaBindingSource;
			this.gvCPaPUE.Location = new System.Drawing.Point(0, 3);
			this.gvCPaPUE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvCPaPUE.Name = "gvCPaPUE";
			this.gvCPaPUE.ReadOnly = true;
			this.gvCPaPUE.RowHeadersVisible = false;
			this.gvCPaPUE.RowHeadersWidth = 51;
			dataGridViewCellStyle72.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle72.ForeColor = System.Drawing.Color.Black;
			this.gvCPaPUE.RowsDefaultCellStyle = dataGridViewCellStyle72;
			this.gvCPaPUE.RowTemplate.Height = 30;
			this.gvCPaPUE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvCPaPUE.Size = new System.Drawing.Size(1635, 633);
			this.gvCPaPUE.TabIndex = 15;
			this.dataGridViewTextBoxColumn14.DataPropertyName = "RFC";
			this.dataGridViewTextBoxColumn14.FillWeight = 150f;
			this.dataGridViewTextBoxColumn14.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "Nombre";
			this.dataGridViewTextBoxColumn15.FillWeight = 250f;
			this.dataGridViewTextBoxColumn15.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "Folio";
			dataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle73;
			this.dataGridViewTextBoxColumn16.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "Fecha";
			dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle74;
			this.dataGridViewTextBoxColumn17.HeaderText = "Fecha Timbrado";
			this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			this.dataGridViewTextBoxColumn18.DataPropertyName = "FechaPagoS";
			dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle75;
			this.dataGridViewTextBoxColumn18.HeaderText = "Fecha Pago REP";
			this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn18.ReadOnly = true;
			this.dataGridViewTextBoxColumn19.DataPropertyName = "TipoComprobante";
			dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle76;
			this.dataGridViewTextBoxColumn19.FillWeight = 80f;
			this.dataGridViewTextBoxColumn19.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn19.ReadOnly = true;
			this.dataGridViewTextBoxColumn20.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle77;
			this.dataGridViewTextBoxColumn20.FillWeight = 50f;
			this.dataGridViewTextBoxColumn20.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn20.ReadOnly = true;
			this.dataGridViewTextBoxColumn21.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn21.FillWeight = 120f;
			this.dataGridViewTextBoxColumn21.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn21.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn21.ReadOnly = true;
			this.dataGridViewTextBoxColumn22.DataPropertyName = "SubTotal";
			dataGridViewCellStyle78.Format = "c2";
			this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle78;
			this.dataGridViewTextBoxColumn22.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn22.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn22.ReadOnly = true;
			this.dataGridViewTextBoxColumn23.DataPropertyName = "Descuento";
			dataGridViewCellStyle79.Format = "c2";
			this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle79;
			this.dataGridViewTextBoxColumn23.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn23.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn23.ReadOnly = true;
			this.dataGridViewTextBoxColumn23.Visible = false;
			this.dataGridViewTextBoxColumn24.DataPropertyName = "IVA";
			dataGridViewCellStyle80.Format = "c2";
			this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle80;
			this.dataGridViewTextBoxColumn24.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn24.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn24.ReadOnly = true;
			this.dataGridViewTextBoxColumn25.DataPropertyName = "Retenciones";
			dataGridViewCellStyle81.Format = "c2";
			this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle81;
			this.dataGridViewTextBoxColumn25.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn25.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn25.ReadOnly = true;
			this.dataGridViewTextBoxColumn26.DataPropertyName = "Total";
			dataGridViewCellStyle82.Format = "c2";
			this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle82;
			this.dataGridViewTextBoxColumn26.HeaderText = "Total";
			this.dataGridViewTextBoxColumn26.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn26.ReadOnly = true;
			this.dataGridViewTextBoxColumn27.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle83.Format = "n4";
			this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle83;
			this.dataGridViewTextBoxColumn27.FillWeight = 50f;
			this.dataGridViewTextBoxColumn27.HeaderText = "Tipo Cambio";
			this.dataGridViewTextBoxColumn27.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn27.ReadOnly = true;
			this.dataGridViewTextBoxColumn28.DataPropertyName = "UsoCFDI";
			this.dataGridViewTextBoxColumn28.HeaderText = "Uso CFDI";
			this.dataGridViewTextBoxColumn28.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
			this.dataGridViewTextBoxColumn28.ReadOnly = true;
			this.dataGridViewTextBoxColumn28.Visible = false;
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "Deducible";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Deducible";
			this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.ReadOnly = true;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1582, 938);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 18);
			this.label3.TabIndex = 128;
			this.label3.Text = "Cantidad:";
			this.txtCantidadVentas.Enabled = false;
			this.txtCantidadVentas.Location = new System.Drawing.Point(1654, 932);
			this.txtCantidadVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCantidadVentas.Name = "txtCantidadVentas";
			this.txtCantidadVentas.Size = new System.Drawing.Size(80, 25);
			this.txtCantidadVentas.TabIndex = 127;
			this.gbObjetos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.gbObjetos.Controls.Add(this.flpObjetoImpuesto);
			this.gbObjetos.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.gbObjetos.Location = new System.Drawing.Point(404, 12);
			this.gbObjetos.Name = "gbObjetos";
			this.gbObjetos.Size = new System.Drawing.Size(1110, 117);
			this.gbObjetos.TabIndex = 144;
			this.gbObjetos.TabStop = false;
			this.gbObjetos.Text = "INFORMACIÓN DE CFDI 4.0";
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel56);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel57);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel58);
			this.flpObjetoImpuesto.Controls.Add(this.label17);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel1);
			this.flpObjetoImpuesto.Location = new System.Drawing.Point(12, 26);
			this.flpObjetoImpuesto.Name = "flpObjetoImpuesto";
			this.flpObjetoImpuesto.Size = new System.Drawing.Size(1095, 82);
			this.flpObjetoImpuesto.TabIndex = 142;
			this.flowLayoutPanel56.Controls.Add(this.label14);
			this.flowLayoutPanel56.Controls.Add(this.txtObjetoImpuesto01);
			this.flowLayoutPanel56.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel56.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel56.Name = "flowLayoutPanel56";
			this.flowLayoutPanel56.Size = new System.Drawing.Size(226, 74);
			this.flowLayoutPanel56.TabIndex = 0;
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new System.Drawing.Point(3, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(204, 18);
			this.label14.TabIndex = 0;
			this.label14.Text = "01 - NO OBJETO DE IMPUESTO";
			this.txtObjetoImpuesto01.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto01.Location = new System.Drawing.Point(3, 21);
			this.txtObjetoImpuesto01.Name = "txtObjetoImpuesto01";
			this.txtObjetoImpuesto01.ReadOnly = true;
			this.txtObjetoImpuesto01.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuesto01.TabIndex = 155;
			this.txtObjetoImpuesto01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flowLayoutPanel57.Controls.Add(this.label15);
			this.flowLayoutPanel57.Controls.Add(this.txtObjetoImpuesto02);
			this.flowLayoutPanel57.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel57.Location = new System.Drawing.Point(235, 3);
			this.flowLayoutPanel57.Name = "flowLayoutPanel57";
			this.flowLayoutPanel57.Size = new System.Drawing.Size(213, 74);
			this.flowLayoutPanel57.TabIndex = 1;
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label15.Location = new System.Drawing.Point(3, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(179, 18);
			this.label15.TabIndex = 0;
			this.label15.Text = "02 - OBJETO DE IMPUESTO";
			this.txtObjetoImpuesto02.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto02.Location = new System.Drawing.Point(3, 21);
			this.txtObjetoImpuesto02.Name = "txtObjetoImpuesto02";
			this.txtObjetoImpuesto02.ReadOnly = true;
			this.txtObjetoImpuesto02.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuesto02.TabIndex = 155;
			this.txtObjetoImpuesto02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flowLayoutPanel58.Controls.Add(this.label49);
			this.flowLayoutPanel58.Controls.Add(this.txtObjetoImpuesto03);
			this.flowLayoutPanel58.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel58.Location = new System.Drawing.Point(454, 3);
			this.flowLayoutPanel58.Name = "flowLayoutPanel58";
			this.flowLayoutPanel58.Size = new System.Drawing.Size(405, 74);
			this.flowLayoutPanel58.TabIndex = 2;
			this.label49.AutoSize = true;
			this.label49.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label49.Location = new System.Drawing.Point(3, 0);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(368, 18);
			this.label49.TabIndex = 0;
			this.label49.Text = "03 - OBJETO DE IMPUESTO NO OBLIGADO AL DESGLOSE";
			this.txtObjetoImpuesto03.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto03.Location = new System.Drawing.Point(3, 21);
			this.txtObjetoImpuesto03.Name = "txtObjetoImpuesto03";
			this.txtObjetoImpuesto03.ReadOnly = true;
			this.txtObjetoImpuesto03.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuesto03.TabIndex = 155;
			this.txtObjetoImpuesto03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new System.Drawing.Point(864, 0);
			this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(48, 77);
			this.label17.TabIndex = 4;
			this.label17.Text = "|";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel1.Controls.Add(this.label16);
			this.flowLayoutPanel1.Controls.Add(this.txtObjetoImpuestoTotal);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(917, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 74);
			this.flowLayoutPanel1.TabIndex = 3;
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new System.Drawing.Point(3, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(129, 18);
			this.label16.TabIndex = 0;
			this.label16.Text = "SUMA DE EGRESOS";
			this.txtObjetoImpuestoTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuestoTotal.Location = new System.Drawing.Point(3, 21);
			this.txtObjetoImpuestoTotal.Name = "txtObjetoImpuestoTotal";
			this.txtObjetoImpuestoTotal.ReadOnly = true;
			this.txtObjetoImpuestoTotal.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuestoTotal.TabIndex = 155;
			this.txtObjetoImpuestoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 29);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1675, 934);
			this.tcPedidosGrids.TabIndex = 129;
			this.flpEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flpEmpresas.Controls.Add(this.label24);
			this.flpEmpresas.Controls.Add(this.cmbEmpresas);
			this.flpEmpresas.Controls.Add(this.btnBuscaEmpresa);
			this.flpEmpresas.Location = new System.Drawing.Point(491, 5);
			this.flpEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flpEmpresas.Name = "flpEmpresas";
			this.flpEmpresas.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.flpEmpresas.Size = new System.Drawing.Size(832, 51);
			this.flpEmpresas.TabIndex = 141;
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
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(735, 8);
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
			base.ClientSize = new System.Drawing.Size(1699, 968);
			base.Controls.Add(this.flpEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "AnalisisComprobantesEgresos";
			this.Text = "Analisis Flujo";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			this.flpExporta.ResumeLayout(false);
			this.pnlFiltroFechas.ResumeLayout(false);
			this.pnlFiltroFechas.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			this.pnlPorDiaVentas.ResumeLayout(false);
			this.tcCFDIs.ResumeLayout(false);
			this.tpDeducibles.ResumeLayout(false);
			this.tpDeducibles.PerformLayout();
			this.flowLayoutPanel16.ResumeLayout(false);
			this.flowLayoutPanel16.PerformLayout();
			this.flpTotales.ResumeLayout(false);
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel6.PerformLayout();
			this.flpTotalPUE.ResumeLayout(false);
			this.flpTotalPUE.PerformLayout();
			this.flpTotalCP.ResumeLayout(false);
			this.flpTotalCP.PerformLayout();
			this.flpTotalTotal.ResumeLayout(false);
			this.flpTotalTotal.PerformLayout();
			this.flowLayoutPanel11.ResumeLayout(false);
			this.flowLayoutPanel11.PerformLayout();
			this.flowLayoutPanel13.ResumeLayout(false);
			this.flowLayoutPanel13.PerformLayout();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.flowLayoutPanel10.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			this.flpPUE.ResumeLayout(false);
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.flowLayoutPanel8.ResumeLayout(false);
			this.flowLayoutPanel8.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.flowLayoutPanel14.ResumeLayout(false);
			this.flowLayoutPanel14.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			this.flowLayoutPanel15.ResumeLayout(false);
			this.flowLayoutPanel15.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.flowLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tpNoDeducibles.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvXMLsNoDeducibles).EndInit();
			this.tpCFDIsCPaPUE.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvCPaPUE).EndInit();
			this.gbObjetos.ResumeLayout(false);
			this.flpObjetoImpuesto.ResumeLayout(false);
			this.flowLayoutPanel56.ResumeLayout(false);
			this.flowLayoutPanel56.PerformLayout();
			this.flowLayoutPanel57.ResumeLayout(false);
			this.flowLayoutPanel57.PerformLayout();
			this.flowLayoutPanel58.ResumeLayout(false);
			this.flowLayoutPanel58.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tcPedidosGrids.ResumeLayout(false);
			this.flpEmpresas.ResumeLayout(false);
			this.flpEmpresas.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
