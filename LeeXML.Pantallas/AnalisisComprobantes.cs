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
	public class AnalisisComprobantes : FormBase
	{
		private IContainer components = null;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private Button btnBuscaEmpresa;

		private Label label24;

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

		private TabControl tcReportesIngresos;

		private TabPage tabPage2;

		private Label label7;

		private FlowLayoutPanel flowLayoutPanel7;

		private CheckBox chkPUE;

		private CheckBox chkPPD;

		private CheckBox chkComplementosPago;

		private Button btnFiltrarComprobantes;

		private FlowLayoutPanel flpPPDPUECPtotales;

		private FlowLayoutPanel flowLayoutPanel6;

		private TextBox txtTotalPPD;

		private Label label6;

		private FlowLayoutPanel flowLayoutPanel1;

		private TextBox txtTotalPUE;

		private Label label2;

		private FlowLayoutPanel flowLayoutPanel3;

		private TextBox txtTotalCP;

		private Label label4;

		private FlowLayoutPanel flowLayoutPanel4;

		private TextBox txtTotal;

		private Label label5;

		private FlowLayoutPanel flowLayoutPanel11;

		private TextBox txtTotalTasa0;

		private Label label8;

		private DataGridView gvXMLs;

		private FlowLayoutPanel flpPUE;

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

		private FlowLayoutPanel flowLayoutPanel8;

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

		private FlowLayoutPanel flowLayoutPanel9;

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

		private Panel pnlFiltroPeriodo;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Panel pnlPorDiaVentas;

		private DateTimePicker dtpFechaHasta;

		private DateTimePicker dtpFechaDesde;

		private RadioButton rdoPorFechasComprobantes;

		private TabControl tcPedidosGrids;

		private Button btnEnviarAExcel;

		private CheckBox chkEgresos;

		private FlowLayoutPanel flowLayoutPanel13;

		private TextBox txtTotalEgresos;

		private Label label9;

		private FlowLayoutPanel flowLayoutPanel14;

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

		private ToolStripLabel toolStripLabel25;

		private ToolStripTextBox tstRetencionesPUEant;

		private ToolStripSeparator toolStripSeparator20;

		private FlowLayoutPanel flpExcluir;

		private CheckBox chkExcluirNC03;

		private CheckBox chkExcluirNC01;

		private Panel pnlFiltro;

		private Label label10;

		private TextBox txtRFCFiltro;

		private Label label11;

		private TextBox txtCliente;

		private Label label12;

		private TextBox txtUUIDfiltro;

		private Button btnFiltraFacturas;

		private Label label13;

		private TextBox txtFacturaFiltro;

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

		private FlowLayoutPanel flowLayoutPanel16;

		private Label label16;

		private TextBox txtObjetoImpuestoTotal;

		private GroupBox gbObjetos;

		private Label label17;

		private DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn FechaPago;

		private new DataGridViewTextBoxColumn TipoComprobante;

		private DataGridViewTextBoxColumn MetodoPago;

		private DataGridViewTextBoxColumn FormaPago;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn retencionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn Moneda;

		private DataGridViewTextBoxColumn TipoCambio;

		private DataGridViewTextBoxColumn UsoCFDI;

		private DataGridViewTextBoxColumn UUID;

		private TabControl tcCFDIs;

		private TabPage tpPUECP;

		private TabPage tpCPaPUE;

		private DataGridView gvCPaPUE;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantesObjetos { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public AnalisisComprobantes()
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
			ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
			gvXMLs.DataSource = ListaComprobantes;
			gvXMLs.Refresh();
			txtTotalPUE.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total));
			txtTotalCP.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.Total));
			txtTotal.Text = FormatoMoney(ConvierteTextoADecimal(txtTotalPUE) + ConvierteTextoADecimal(txtTotalCP));
			txtTotalPPD.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 2).Sum((EntFactura P) => P.Total));
			txtTotalEgresos.Text = FormatoMoney(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 2).Sum((EntFactura P) => P.Total));
			ListaComprobantesObjetos = new BusFacturas().ObtieneComprobantesFiscalesObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantesObjetos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivoObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1));
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
				lstFiltro = ListaComprobantes.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03 && !P.ExcluyeFlujo)).ToList();
				lstFiltroObjetos = ListaComprobantesObjetos.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03 && !P.ExcluyeFlujo)).ToList();
			}
			gvXMLs.DataSource = lstFiltro.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			gvXMLs.Refresh();
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUE.TextBox, tstxtSubtotalPUE.TextBox, tstxtIvaPUE.TextBox, tstxtRetencionesPUE.TextBox, tstxtNumPUE.TextBox);
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList(), false, tstxtImporteCP.TextBox, tstxtSubtotalCP.TextBox, tstxtIvaCP.TextBox, tstxtRetencionesCP.TextBox, tstxtNumCP.TextBox);
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03 && !P.ExcluyeFlujo)).ToList(), false, tstxtImporteEg.TextBox, tstxtSubtotalEg.TextBox, tstxtIvaEg.TextBox, tstxtRetencionesEg.TextBox, tstxtNumEg.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUE.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCP.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEg.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUE.TextBox) + ConvierteTextoADecimal(tstxtIvaCP.TextBox) - ConvierteTextoADecimal(tstxtIvaEg.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUE.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCP.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEg.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUE.TextBox) + ConvierteTextoADecimal(tstxtImporteCP.TextBox) - ConvierteTextoADecimal(tstxtImporteEg.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUE.TextBox) + ConvierteTextoADecimal(tstxtNumCP.TextBox) + ConvierteTextoADecimal(tstxtNumEg.TextBox);
			tstxtSubtotalTotal.TextBox.Text = FormatoMoney(subtotal);
			tstxtIvaTotal.TextBox.Text = FormatoMoney(iva);
			tstxtRetencionesTotal.TextBox.Text = FormatoMoney(retenciones);
			tstxtImporteTotal.TextBox.Text = FormatoMoney(total);
			tstxtNumTotal.TextBox.Text = num.ToString();
			CalculaSumaTotalFromListaProductos(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago < FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList(), false, tstImportePUEant.TextBox, tstSubPUEant.TextBox, tstIvaPUEant.TextBox, tstRetencionesPUEant.TextBox, tstNumPUEant.TextBox);
			lstFiltroObjetos = lstFiltroObjetos.Where((EntFactura P) => P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today) || P.TipoComprobanteId == 1).ToList();
			txtObjetoImpuesto01.Text = FormatoMoney(lstFiltroObjetos.Sum((EntFactura P) => P.ObjetoImpuesto01));
			txtObjetoImpuesto02.Text = FormatoMoney(lstFiltroObjetos.Sum((EntFactura P) => P.ObjetoImpuesto02));
			txtObjetoImpuesto03.Text = FormatoMoney(lstFiltroObjetos.Sum((EntFactura P) => P.ObjetoImpuesto03));
			txtObjetoImpuestoTotal.Text = FormatoMoney(ConvierteTextoADecimal(txtObjetoImpuesto01) + ConvierteTextoADecimal(txtObjetoImpuesto02) + ConvierteTextoADecimal(txtObjetoImpuesto03));
			RevisaCPaPUE(lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList(), lstFiltro);
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
						List<EntFactura> lstFacPPD = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
						if (lstFacPPD.Count > 0)
						{
							EntFactura fac = lstFacPPD.First();
							new BusFacturas().AumentaPagoComprobanteFiscal(fac.Id, cp.Total);
							new BusFacturas().VerificaComprobanteFiscalPagado(fac.Id);
							new BusFacturas().ActualizaComprobanteFiscalPagado(cp.Id, true);
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
			foreach (EntFactura cp in ListaComplementosPago)
			{
				if (cp.FacturaRelacionId <= 0)
				{
					continue;
				}
				List<EntFactura> lstDepositos = new BusFacturas().ObtieneEstadosDeCuentaDetalle(cp.FacturaRelacionId);
				List<EntFactura> lstDepositosCP = new BusFacturas().ObtieneEstadosDeCuentaDetalleFacturaRelacionada(cp.FacturaRelacionId);
				decimal totalDeposito = lstDepositos.Sum((EntFactura P) => P.Pago);
				decimal totalDepositoCP = lstDepositosCP.Sum((EntFactura P) => P.Pago);
				decimal diferencia = totalDeposito - totalDepositoCP;
				if (diferencia > 0m)
				{
					decimal deposito = cp.Total;
					if (diferencia >= cp.Total)
					{
						new BusFacturas().AgregaEstadoDeCuentaComprobante(0, cp, cp.Total, cp.FacturaRelacionId, cp.UUIDrelacionado);
					}
					else
					{
						deposito = diferencia;
						new BusFacturas().AgregaEstadoDeCuentaComprobante(0, cp, diferencia, cp.FacturaRelacionId, cp.UUIDrelacionado);
					}
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(cp.Id, 1);
					new BusFacturas().AumentaDepositoComprobanteFiscal(cp.Id, deposito);
					new BusFacturas().VerificaComprobanteFiscalDepositado(cp.Id);
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
						List<EntFactura> lstFacAnticipos = (from P in new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s)
							where !P.Pagado
							select P).ToList();
						if (lstFacAnticipos.Count > 0)
						{
							EntFactura anticipo = lstFacAnticipos.First();
							new BusFacturas().AumentaPagoComprobanteFiscal(f.Id, anticipo.Total);
							new BusFacturas().VerificaComprobanteFiscalPagado(f.Id);
							new BusFacturas().ActualizaComprobanteFiscalPagado(anticipo.Id, true);
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
					List<EntFactura> lstFacIngRelacionada = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
					if (lstFacIngRelacionada.Count > 0)
					{
						EntFactura facIng = lstFacIngRelacionada.First();
						new BusFacturas().AumentaPagoComprobanteFiscal(facIng.Id, f.Total);
						new BusFacturas().VerificaComprobanteFiscalPagado(facIng.Id);
						new BusFacturas().ActualizaComprobanteFiscalPagado(f.Id, true);
						facIng.Pago = f.Total;
						new BusFacturas().AgregaEstadoDeCuentaComprobante(0, facIng);
						new BusFacturas().AumentaDepositoComprobanteFiscal(facIng.Id, f.Total);
						new BusFacturas().VerificaComprobanteFiscalDepositado(facIng.Id);
						if (facIng.MetodoPagoId == 2)
						{
							new BusFacturas().ActualizaEstatusComprobanteFiscal(f.Id, 5);
							new BusFacturas().ActualizaComprobanteFiscalExcluyeFlujo(f.Id, true);
						}
						cont++;
					}
				}
			}
			return cont;
		}

		public int RevisaAnticipoDepositadoEnComprobantes(List<EntFactura> ListaComprobantesFiscales)
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
					List<EntFactura> lstFacAnticipos = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
					if (lstFacAnticipos.Count > 0)
					{
						EntFactura anticipo = lstFacAnticipos.First();
						List<EntFactura> lstFacAnticiposDepositos = new BusFacturas().ObtieneEstadosDeCuentaDetalleFacturaRelacionada(anticipo.Id);
						if (lstFacAnticiposDepositos.Count == 0)
						{
							new BusFacturas().AgregaEstadoDeCuentaComprobante(0, f, anticipo.Total, anticipo.Id, anticipo.UUID);
							new BusFacturas().AumentaDepositoComprobanteFiscal(f.Id, anticipo.Total);
							new BusFacturas().VerificaComprobanteFiscalDepositado(f.Id);
							cont++;
						}
					}
				}
			}
			return cont;
		}

		public int RevisaEgresosAnticiposComprobantes(List<EntFactura> ListaComprobantesFiscales)
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
					List<EntFactura> lstFacIngConAnticipos = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
					if (lstFacIngConAnticipos.Count > 0)
					{
						EntFactura facIngConAnticipo = lstFacIngConAnticipos.First();
						if (facIngConAnticipo.MetodoPagoId == 2)
						{
							new BusFacturas().ActualizaEstatusComprobanteFiscal(f.Id, 5);
							cont++;
						}
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
			int cantFacturasConAnt = RevisaAnticipoDepositadoEnComprobantes(ListaComprobantes);
			int cantEgresosRelacionados = RevisaEgresosAnticiposComprobantes(ListaComprobantes);
			int cantNcRelacionados = RevisaEgresoNcPagadoEnComprobantes(new BusFacturas().ObtieneComprobantesFiscalesNcNoPagados(Program.EmpresaSeleccionada));
			MuestraMensaje($"SE ENCONTRARON: \n\n {cantCPencontrados} PAGOS AGREGADOS A FACTURA PPD\n {cantDepEnFactura} COMPLEMENTOS DE PAGO CON DEPÓSITOS ANTERIORES A FACTURA PPD\n {cantFacturasConAnt} COMPROBANTES FISCALES INGRESO CON ANTICIPOS RELACIONADOS\n {cantEgresosRelacionados} COMPROBANTES FISCALES EGRESO RELACIONADOS A FACTURA CON ANTICIPO");
			if (cantEgresosRelacionados > 0 || cantNcRelacionados > 0)
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
				List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
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
				List<EntFactura> xmls = new List<EntFactura>();
				if (tcCFDIs.SelectedIndex == 0)
				{
					xmls = (from P in ObtieneListaFacturasFromGV(gvXMLs)
						where P.TipoComprobanteId != 5 || (P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today))
						select P).ToList();
				}
				else if (tcCFDIs.SelectedIndex == 1)
				{
					xmls = (from P in ObtieneListaFacturasFromGV(gvCPaPUE)
						where P.TipoComprobanteId != 5 || (P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today))
						select P).ToList();
				}
				ImprimeCFDIsFlujo vImprime = new ImprimeCFDIsFlujo(xmls, tstxtNumPUE.TextBox.Text, tstxtNumCP.TextBox.Text, tstxtNumEg.TextBox.Text, "0", tstxtNumTotal.TextBox.Text, tstxtSubtotalPUE.TextBox.Text, tstxtSubtotalCP.TextBox.Text, tstxtSubtotalEg.TextBox.Text, "0", tstxtSubtotalTotal.TextBox.Text, tstxtIvaPUE.TextBox.Text, tstxtIvaCP.TextBox.Text, tstxtIvaEg.TextBox.Text, "0", tstxtIvaTotal.TextBox.Text, tstxtRetencionesPUE.TextBox.Text, tstxtRetencionesCP.TextBox.Text, tstxtRetencionesEg.TextBox.Text, "0", tstxtRetencionesTotal.TextBox.Text, tstxtImportePUE.TextBox.Text, tstxtImporteCP.TextBox.Text, tstxtImporteEg.TextBox.Text, "0", tstxtImporteTotal.TextBox.Text);
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

		private void chkExluirNC01_CheckedChanged(object sender, EventArgs e)
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

		private void gvXMLs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				MuestraDatosFactura(sender);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.AnalisisComprobantes));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnlFiltroPeriodo = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.pnlPorDiaVentas = new System.Windows.Forms.Panel();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.rdoPorFechasComprobantes = new System.Windows.Forms.RadioButton();
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
			this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
			this.label16 = new System.Windows.Forms.Label();
			this.txtObjetoImpuestoTotal = new System.Windows.Forms.TextBox();
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flpExcluir = new System.Windows.Forms.FlowLayoutPanel();
			this.chkExcluirNC03 = new System.Windows.Forms.CheckBox();
			this.chkExcluirNC01 = new System.Windows.Forms.CheckBox();
			this.btnEnviarAExcel = new System.Windows.Forms.Button();
			this.pnlFiltro = new System.Windows.Forms.Panel();
			this.label10 = new System.Windows.Forms.Label();
			this.txtRFCFiltro = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtUUIDfiltro = new System.Windows.Forms.TextBox();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.txtFacturaFiltro = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.chkPUE = new System.Windows.Forms.CheckBox();
			this.chkPPD = new System.Windows.Forms.CheckBox();
			this.chkComplementosPago = new System.Windows.Forms.CheckBox();
			this.chkEgresos = new System.Windows.Forms.CheckBox();
			this.btnFiltrarComprobantes = new System.Windows.Forms.Button();
			this.tcCFDIs = new System.Windows.Forms.TabControl();
			this.tpPUECP = new System.Windows.Forms.TabPage();
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
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FechaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.retencionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UsoCFDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flpPUE = new System.Windows.Forms.FlowLayoutPanel();
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
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
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
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
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
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
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
			this.label7 = new System.Windows.Forms.Label();
			this.tpCPaPUE = new System.Windows.Forms.TabPage();
			this.gvCPaPUE = new System.Windows.Forms.DataGridView();
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
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flpPPDPUECPtotales = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPPD = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPUE = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalCP = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalTasa0 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalEgresos = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pnlFiltroPeriodo.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			this.pnlPorDiaVentas.SuspendLayout();
			this.gbObjetos.SuspendLayout();
			this.flpObjetoImpuesto.SuspendLayout();
			this.flowLayoutPanel56.SuspendLayout();
			this.flowLayoutPanel57.SuspendLayout();
			this.flowLayoutPanel58.SuspendLayout();
			this.flowLayoutPanel16.SuspendLayout();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flpExcluir.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			this.flowLayoutPanel7.SuspendLayout();
			this.tcCFDIs.SuspendLayout();
			this.tpPUECP.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			this.flpPUE.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel8.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.tpCPaPUE.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCPaPUE).BeginInit();
			this.flpPPDPUECPtotales.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.flowLayoutPanel13.SuspendLayout();
			base.SuspendLayout();
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(1213, 10);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(54, 46);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(487, 19);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(90, 25);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(610, 14);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(598, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 29);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1524, 961);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.pnlFiltroPeriodo);
			this.tabPage1.Controls.Add(this.gbObjetos);
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1516, 926);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Flujo de Comprobantes Fiscales ";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.pnlFiltroPeriodo.Controls.Add(this.btnRefrescar);
			this.pnlFiltroPeriodo.Controls.Add(this.rdoPorMesComprobantes);
			this.pnlFiltroPeriodo.Controls.Add(this.pnlPorMesVentas);
			this.pnlFiltroPeriodo.Controls.Add(this.pnlPorDiaVentas);
			this.pnlFiltroPeriodo.Controls.Add(this.rdoPorFechasComprobantes);
			this.pnlFiltroPeriodo.Location = new System.Drawing.Point(12, 8);
			this.pnlFiltroPeriodo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlFiltroPeriodo.Name = "pnlFiltroPeriodo";
			this.pnlFiltroPeriodo.Size = new System.Drawing.Size(626, 118);
			this.pnlFiltroPeriodo.TabIndex = 135;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(482, 8);
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
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(12, 51);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(84, 22);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(118, 35);
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
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(113, 33);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaHasta);
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaDesde);
			this.pnlPorDiaVentas.Enabled = false;
			this.pnlPorDiaVentas.Location = new System.Drawing.Point(118, 86);
			this.pnlPorDiaVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorDiaVentas.Name = "pnlPorDiaVentas";
			this.pnlPorDiaVentas.Size = new System.Drawing.Size(364, 49);
			this.pnlPorDiaVentas.TabIndex = 42;
			this.pnlPorDiaVentas.Visible = false;
			this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaHasta.Location = new System.Drawing.Point(179, 11);
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
			this.rdoPorFechasComprobantes.Location = new System.Drawing.Point(12, 88);
			this.rdoPorFechasComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorFechasComprobantes.Name = "rdoPorFechasComprobantes";
			this.rdoPorFechasComprobantes.Size = new System.Drawing.Size(99, 22);
			this.rdoPorFechasComprobantes.TabIndex = 43;
			this.rdoPorFechasComprobantes.Text = "Por Fechas";
			this.rdoPorFechasComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorFechasComprobantes.Visible = false;
			this.gbObjetos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.gbObjetos.Controls.Add(this.flpObjetoImpuesto);
			this.gbObjetos.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.gbObjetos.Location = new System.Drawing.Point(254, 9);
			this.gbObjetos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gbObjetos.Name = "gbObjetos";
			this.gbObjetos.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gbObjetos.Size = new System.Drawing.Size(1109, 116);
			this.gbObjetos.TabIndex = 143;
			this.gbObjetos.TabStop = false;
			this.gbObjetos.Text = "INFORMACIÓN DE CFDI 4.0";
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel56);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel57);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel58);
			this.flpObjetoImpuesto.Controls.Add(this.label17);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel16);
			this.flpObjetoImpuesto.Location = new System.Drawing.Point(12, 26);
			this.flpObjetoImpuesto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.flpObjetoImpuesto.Name = "flpObjetoImpuesto";
			this.flpObjetoImpuesto.Size = new System.Drawing.Size(1095, 81);
			this.flpObjetoImpuesto.TabIndex = 142;
			this.flowLayoutPanel56.Controls.Add(this.label14);
			this.flowLayoutPanel56.Controls.Add(this.txtObjetoImpuesto01);
			this.flowLayoutPanel56.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel56.Location = new System.Drawing.Point(3, 4);
			this.flowLayoutPanel56.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
			this.txtObjetoImpuesto01.Location = new System.Drawing.Point(3, 20);
			this.txtObjetoImpuesto01.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuesto01.Name = "txtObjetoImpuesto01";
			this.txtObjetoImpuesto01.ReadOnly = true;
			this.txtObjetoImpuesto01.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuesto01.TabIndex = 155;
			this.txtObjetoImpuesto01.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flowLayoutPanel57.Controls.Add(this.label15);
			this.flowLayoutPanel57.Controls.Add(this.txtObjetoImpuesto02);
			this.flowLayoutPanel57.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel57.Location = new System.Drawing.Point(235, 4);
			this.flowLayoutPanel57.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.flowLayoutPanel57.Name = "flowLayoutPanel57";
			this.flowLayoutPanel57.Size = new System.Drawing.Size(214, 74);
			this.flowLayoutPanel57.TabIndex = 1;
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label15.Location = new System.Drawing.Point(3, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(179, 18);
			this.label15.TabIndex = 0;
			this.label15.Text = "02 - OBJETO DE IMPUESTO";
			this.txtObjetoImpuesto02.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuesto02.Location = new System.Drawing.Point(3, 20);
			this.txtObjetoImpuesto02.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuesto02.Name = "txtObjetoImpuesto02";
			this.txtObjetoImpuesto02.ReadOnly = true;
			this.txtObjetoImpuesto02.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuesto02.TabIndex = 155;
			this.txtObjetoImpuesto02.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.flowLayoutPanel58.Controls.Add(this.label49);
			this.flowLayoutPanel58.Controls.Add(this.txtObjetoImpuesto03);
			this.flowLayoutPanel58.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel58.Location = new System.Drawing.Point(455, 4);
			this.flowLayoutPanel58.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
			this.txtObjetoImpuesto03.Location = new System.Drawing.Point(3, 20);
			this.txtObjetoImpuesto03.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuesto03.Name = "txtObjetoImpuesto03";
			this.txtObjetoImpuesto03.ReadOnly = true;
			this.txtObjetoImpuesto03.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuesto03.TabIndex = 155;
			this.txtObjetoImpuesto03.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new System.Drawing.Point(864, 0);
			this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(47, 78);
			this.label17.TabIndex = 4;
			this.label17.Text = "|";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel16.Controls.Add(this.label16);
			this.flowLayoutPanel16.Controls.Add(this.txtObjetoImpuestoTotal);
			this.flowLayoutPanel16.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel16.Location = new System.Drawing.Point(915, 4);
			this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.flowLayoutPanel16.Name = "flowLayoutPanel16";
			this.flowLayoutPanel16.Size = new System.Drawing.Size(166, 74);
			this.flowLayoutPanel16.TabIndex = 3;
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new System.Drawing.Point(3, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(136, 18);
			this.label16.TabIndex = 0;
			this.label16.Text = "SUMA DE INGRESOS";
			this.txtObjetoImpuestoTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtObjetoImpuestoTotal.Location = new System.Drawing.Point(3, 20);
			this.txtObjetoImpuestoTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtObjetoImpuestoTotal.Name = "txtObjetoImpuestoTotal";
			this.txtObjetoImpuestoTotal.ReadOnly = true;
			this.txtObjetoImpuestoTotal.Size = new System.Drawing.Size(157, 38);
			this.txtObjetoImpuestoTotal.TabIndex = 155;
			this.txtObjetoImpuestoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(9, 92);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(1497, 820);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage2.Controls.Add(this.flpExcluir);
			this.tabPage2.Controls.Add(this.btnEnviarAExcel);
			this.tabPage2.Controls.Add(this.pnlFiltro);
			this.tabPage2.Controls.Add(this.flowLayoutPanel7);
			this.tabPage2.Controls.Add(this.tcCFDIs);
			this.tabPage2.Controls.Add(this.flpPPDPUECPtotales);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 31);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Size = new System.Drawing.Size(1489, 785);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Ingresos";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flpExcluir.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flpExcluir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpExcluir.Controls.Add(this.chkExcluirNC03);
			this.flpExcluir.Controls.Add(this.chkExcluirNC01);
			this.flpExcluir.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpExcluir.Location = new System.Drawing.Point(717, 49);
			this.flpExcluir.Margin = new System.Windows.Forms.Padding(1);
			this.flpExcluir.Name = "flpExcluir";
			this.flpExcluir.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flpExcluir.Size = new System.Drawing.Size(625, 43);
			this.flpExcluir.TabIndex = 141;
			this.chkExcluirNC03.AutoSize = true;
			this.chkExcluirNC03.Location = new System.Drawing.Point(402, 8);
			this.chkExcluirNC03.Margin = new System.Windows.Forms.Padding(1, 8, 1, 1);
			this.chkExcluirNC03.Name = "chkExcluirNC03";
			this.chkExcluirNC03.Size = new System.Drawing.Size(214, 22);
			this.chkExcluirNC03.TabIndex = 0;
			this.chkExcluirNC03.Text = "Excluir Devoluciones (NC '03')";
			this.chkExcluirNC03.UseVisualStyleBackColor = true;
			this.chkExcluirNC03.CheckedChanged += new System.EventHandler(chkExluirNC01_CheckedChanged);
			this.chkExcluirNC01.AutoSize = true;
			this.chkExcluirNC01.Location = new System.Drawing.Point(98, 8);
			this.chkExcluirNC01.Margin = new System.Windows.Forms.Padding(1, 8, 1, 1);
			this.chkExcluirNC01.Name = "chkExcluirNC01";
			this.chkExcluirNC01.Size = new System.Drawing.Size(302, 22);
			this.chkExcluirNC01.TabIndex = 1;
			this.chkExcluirNC01.Text = "Excluir Descuentos o Bonifcaciones (NC '01')";
			this.chkExcluirNC01.UseVisualStyleBackColor = true;
			this.chkExcluirNC01.CheckedChanged += new System.EventHandler(chkExluirNC01_CheckedChanged);
			this.btnEnviarAExcel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcel.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcel.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcel.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcel.Location = new System.Drawing.Point(1350, 0);
			this.btnEnviarAExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEnviarAExcel.Name = "btnEnviarAExcel";
			this.btnEnviarAExcel.Size = new System.Drawing.Size(134, 92);
			this.btnEnviarAExcel.TabIndex = 133;
			this.btnEnviarAExcel.Text = "Enviar a Excel";
			this.btnEnviarAExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcel.UseVisualStyleBackColor = false;
			this.btnEnviarAExcel.Click += new System.EventHandler(btnEnviarAExcel_Click);
			this.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltro.Controls.Add(this.label10);
			this.pnlFiltro.Controls.Add(this.txtRFCFiltro);
			this.pnlFiltro.Controls.Add(this.label11);
			this.pnlFiltro.Controls.Add(this.txtCliente);
			this.pnlFiltro.Controls.Add(this.label12);
			this.pnlFiltro.Controls.Add(this.txtUUIDfiltro);
			this.pnlFiltro.Controls.Add(this.btnFiltraFacturas);
			this.pnlFiltro.Controls.Add(this.label13);
			this.pnlFiltro.Controls.Add(this.txtFacturaFiltro);
			this.pnlFiltro.Location = new System.Drawing.Point(9, 1);
			this.pnlFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(1008, 47);
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
			this.txtRFCFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRFCFiltro.Name = "txtRFCFiltro";
			this.txtRFCFiltro.Size = new System.Drawing.Size(130, 28);
			this.txtRFCFiltro.TabIndex = 0;
			this.txtRFCFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(208, 12);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 18);
			this.label11.TabIndex = 135;
			this.label11.Text = "Cliente:";
			this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtCliente.Location = new System.Drawing.Point(272, 9);
			this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(203, 28);
			this.txtCliente.TabIndex = 1;
			this.txtCliente.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(486, 14);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(45, 18);
			this.label12.TabIndex = 133;
			this.label12.Text = "UUID:";
			this.txtUUIDfiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtUUIDfiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtUUIDfiltro.Location = new System.Drawing.Point(536, 9);
			this.txtUUIDfiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtUUIDfiltro.Name = "txtUUIDfiltro";
			this.txtUUIDfiltro.Size = new System.Drawing.Size(216, 28);
			this.txtUUIDfiltro.TabIndex = 2;
			this.txtUUIDfiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(943, 0);
			this.btnFiltraFacturas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(58, 42);
			this.btnFiltraFacturas.TabIndex = 4;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(765, 14);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(40, 18);
			this.label13.TabIndex = 97;
			this.label13.Text = "Folio:";
			this.txtFacturaFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtFacturaFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFacturaFiltro.Location = new System.Drawing.Point(814, 9);
			this.txtFacturaFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(112, 28);
			this.txtFacturaFiltro.TabIndex = 3;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.flowLayoutPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel7.Controls.Add(this.chkPUE);
			this.flowLayoutPanel7.Controls.Add(this.chkPPD);
			this.flowLayoutPanel7.Controls.Add(this.chkComplementosPago);
			this.flowLayoutPanel7.Controls.Add(this.chkEgresos);
			this.flowLayoutPanel7.Controls.Add(this.btnFiltrarComprobantes);
			this.flowLayoutPanel7.Location = new System.Drawing.Point(9, 49);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flowLayoutPanel7.Size = new System.Drawing.Size(580, 43);
			this.flowLayoutPanel7.TabIndex = 139;
			this.chkPUE.AutoSize = true;
			this.chkPUE.Checked = true;
			this.chkPUE.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPUE.Location = new System.Drawing.Point(7, 8);
			this.chkPUE.Margin = new System.Windows.Forms.Padding(1, 8, 1, 1);
			this.chkPUE.Name = "chkPUE";
			this.chkPUE.Size = new System.Drawing.Size(59, 22);
			this.chkPUE.TabIndex = 0;
			this.chkPUE.Text = "PUE";
			this.chkPUE.UseVisualStyleBackColor = true;
			this.chkPUE.CheckedChanged += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.chkPPD.AutoSize = true;
			this.chkPPD.Location = new System.Drawing.Point(68, 8);
			this.chkPPD.Margin = new System.Windows.Forms.Padding(1, 8, 1, 1);
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
			this.chkComplementosPago.Location = new System.Drawing.Point(130, 8);
			this.chkComplementosPago.Margin = new System.Windows.Forms.Padding(1, 8, 1, 1);
			this.chkComplementosPago.Name = "chkComplementosPago";
			this.chkComplementosPago.Size = new System.Drawing.Size(162, 22);
			this.chkComplementosPago.TabIndex = 2;
			this.chkComplementosPago.Text = "Complementos Pago";
			this.chkComplementosPago.UseVisualStyleBackColor = true;
			this.chkComplementosPago.CheckedChanged += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.chkEgresos.AutoSize = true;
			this.chkEgresos.Checked = true;
			this.chkEgresos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEgresos.Location = new System.Drawing.Point(294, 8);
			this.chkEgresos.Margin = new System.Windows.Forms.Padding(1, 8, 1, 1);
			this.chkEgresos.Name = "chkEgresos";
			this.chkEgresos.Size = new System.Drawing.Size(143, 22);
			this.chkEgresos.TabIndex = 134;
			this.chkEgresos.Text = "Egresos (Anticipo)";
			this.chkEgresos.UseVisualStyleBackColor = true;
			this.btnFiltrarComprobantes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltrarComprobantes.BackColor = System.Drawing.Color.White;
			this.btnFiltrarComprobantes.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnFiltrarComprobantes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltrarComprobantes.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltrarComprobantes.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltrarComprobantes.Location = new System.Drawing.Point(442, 2);
			this.btnFiltrarComprobantes.Margin = new System.Windows.Forms.Padding(4, 2, 4, 5);
			this.btnFiltrarComprobantes.Name = "btnFiltrarComprobantes";
			this.btnFiltrarComprobantes.Size = new System.Drawing.Size(39, 38);
			this.btnFiltrarComprobantes.TabIndex = 133;
			this.btnFiltrarComprobantes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFiltrarComprobantes.UseVisualStyleBackColor = false;
			this.btnFiltrarComprobantes.Click += new System.EventHandler(btnFiltrarComprobantes_Click);
			this.tcCFDIs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCFDIs.Controls.Add(this.tpPUECP);
			this.tcCFDIs.Controls.Add(this.tpCPaPUE);
			this.tcCFDIs.Location = new System.Drawing.Point(3, 98);
			this.tcCFDIs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tcCFDIs.Name = "tcCFDIs";
			this.tcCFDIs.SelectedIndex = 0;
			this.tcCFDIs.Size = new System.Drawing.Size(1485, 679);
			this.tcCFDIs.TabIndex = 142;
			this.tpPUECP.Controls.Add(this.flowLayoutPanel10);
			this.tpPUECP.Controls.Add(this.gvXMLs);
			this.tpPUECP.Controls.Add(this.flpPUE);
			this.tpPUECP.Controls.Add(this.label7);
			this.tpPUECP.Location = new System.Drawing.Point(4, 27);
			this.tpPUECP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpPUECP.Name = "tpPUECP";
			this.tpPUECP.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpPUECP.Size = new System.Drawing.Size(1477, 648);
			this.tpPUECP.TabIndex = 0;
			this.tpPUECP.Text = "CFDI'S PUE/CP";
			this.tpPUECP.UseVisualStyleBackColor = true;
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
			this.flowLayoutPanel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel10.Controls.Add(this.toolStrip4);
			this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel10.Location = new System.Drawing.Point(126, 600);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Padding = new System.Windows.Forms.Padding(6, 1, 6, 0);
			this.flowLayoutPanel10.Size = new System.Drawing.Size(1345, 36);
			this.flowLayoutPanel10.TabIndex = 141;
			this.toolStrip4.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel13, this.tstNumPUEant, this.toolStripSeparator10, this.toolStripLabel14, this.tstSubPUEant, this.toolStripSeparator11, this.toolStripLabel15, this.tstIvaPUEant, this.toolStripSeparator12, this.toolStripLabel25,
				this.tstRetencionesPUEant, this.toolStripSeparator20, this.toolStripLabel16, this.tstImportePUEant
			});
			this.toolStrip4.Location = new System.Drawing.Point(6, 1);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip4.Size = new System.Drawing.Size(1275, 33);
			this.toolStrip4.TabIndex = 2;
			this.toolStrip4.Text = "toolStrip4";
			this.toolStripLabel13.Name = "toolStripLabel13";
			this.toolStripLabel13.Size = new System.Drawing.Size(419, 28);
			this.toolStripLabel13.Text = "*Complementos de Pago pagados en Mes anterior:";
			this.tstNumPUEant.Name = "tstNumPUEant";
			this.tstNumPUEant.ReadOnly = true;
			this.tstNumPUEant.Size = new System.Drawing.Size(52, 33);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel14.Name = "toolStripLabel14";
			this.toolStripLabel14.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel14.Text = "SubTotal:";
			this.tstSubPUEant.Name = "tstSubPUEant";
			this.tstSubPUEant.ReadOnly = true;
			this.tstSubPUEant.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel15.Name = "toolStripLabel15";
			this.toolStripLabel15.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel15.Text = "I.V.A:";
			this.tstIvaPUEant.Name = "tstIvaPUEant";
			this.tstIvaPUEant.ReadOnly = true;
			this.tstIvaPUEant.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel25.Name = "toolStripLabel25";
			this.toolStripLabel25.Size = new System.Drawing.Size(110, 28);
			this.toolStripLabel25.Text = "Retenciones:";
			this.tstRetencionesPUEant.Name = "tstRetencionesPUEant";
			this.tstRetencionesPUEant.ReadOnly = true;
			this.tstRetencionesPUEant.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel16.Name = "toolStripLabel16";
			this.toolStripLabel16.Size = new System.Drawing.Size(53, 28);
			this.toolStripLabel16.Text = "Total:";
			this.tstImportePUEant.Name = "tstImportePUEant";
			this.tstImportePUEant.ReadOnly = true;
			this.tstImportePUEant.Size = new System.Drawing.Size(82, 33);
			this.gvXMLs.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLs.AutoGenerateColumns = false;
			this.gvXMLs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLs.Columns.AddRange(this.rFCDataGridViewTextBoxColumn, this.nombreDataGridViewTextBoxColumn, this.folioDataGridViewTextBoxColumn, this.fechaDataGridViewTextBoxColumn, this.FechaPago, this.TipoComprobante, this.MetodoPago, this.FormaPago, this.subTotalDataGridViewTextBoxColumn, this.descuentoDataGridViewTextBoxColumn, this.iVADataGridViewTextBoxColumn, this.retencionesDataGridViewTextBoxColumn, this.totalDataGridViewTextBoxColumn, this.Moneda, this.TipoCambio, this.UsoCFDI, this.UUID);
			this.gvXMLs.DataSource = this.entFacturaBindingSource;
			this.gvXMLs.Location = new System.Drawing.Point(1, 0);
			this.gvXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.ReadOnly = true;
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle11;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(1472, 440);
			this.gvXMLs.TabIndex = 14;
			this.gvXMLs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellDoubleClick);
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
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.folioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
			this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
			this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
			this.folioDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			this.fechaDataGridViewTextBoxColumn.FillWeight = 90f;
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha Timbrado";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.FechaPago.DataPropertyName = "FechaPagoS";
			this.FechaPago.HeaderText = "Fecha Pago";
			this.FechaPago.MinimumWidth = 6;
			this.FechaPago.Name = "FechaPago";
			this.FechaPago.ReadOnly = true;
			this.TipoComprobante.DataPropertyName = "TipoComprobante";
			this.TipoComprobante.FillWeight = 90f;
			this.TipoComprobante.HeaderText = "Tipo Comprobante";
			this.TipoComprobante.MinimumWidth = 6;
			this.TipoComprobante.Name = "TipoComprobante";
			this.TipoComprobante.ReadOnly = true;
			this.MetodoPago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MetodoPago.DefaultCellStyle = dataGridViewCellStyle13;
			this.MetodoPago.FillWeight = 90f;
			this.MetodoPago.HeaderText = "Metodo Pago";
			this.MetodoPago.MinimumWidth = 6;
			this.MetodoPago.Name = "MetodoPago";
			this.MetodoPago.ReadOnly = true;
			this.FormaPago.DataPropertyName = "FormaPago";
			dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.FormaPago.DefaultCellStyle = dataGridViewCellStyle14;
			this.FormaPago.FillWeight = 120f;
			this.FormaPago.HeaderText = "Forma Pago";
			this.FormaPago.MinimumWidth = 6;
			this.FormaPago.Name = "FormaPago";
			this.FormaPago.ReadOnly = true;
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle15.Format = "c2";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
			dataGridViewCellStyle16.Format = "c2";
			this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
			this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
			this.descuentoDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
			this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.Visible = false;
			this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
			dataGridViewCellStyle17.Format = "c2";
			this.iVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
			this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
			this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
			this.iVADataGridViewTextBoxColumn.ReadOnly = true;
			this.retencionesDataGridViewTextBoxColumn.DataPropertyName = "Retenciones";
			dataGridViewCellStyle18.Format = "c2";
			this.retencionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
			this.retencionesDataGridViewTextBoxColumn.HeaderText = "Retenciones";
			this.retencionesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.retencionesDataGridViewTextBoxColumn.Name = "retencionesDataGridViewTextBoxColumn";
			this.retencionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle19.Format = "c2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total (MXN)";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.Moneda.DataPropertyName = "Moneda";
			this.Moneda.FillWeight = 50f;
			this.Moneda.HeaderText = "Moneda";
			this.Moneda.MinimumWidth = 6;
			this.Moneda.Name = "Moneda";
			this.Moneda.ReadOnly = true;
			this.TipoCambio.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle20.Format = "N2";
			dataGridViewCellStyle20.NullValue = null;
			this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle20;
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
			this.UUID.DataPropertyName = "UUID";
			this.UUID.FillWeight = 60f;
			this.UUID.HeaderText = "UUID";
			this.UUID.MinimumWidth = 6;
			this.UUID.Name = "UUID";
			this.UUID.ReadOnly = true;
			this.flpPUE.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpPUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPUE.Controls.Add(this.flpTotalesTodos);
			this.flpPUE.Controls.Add(this.flowLayoutPanel8);
			this.flpPUE.Controls.Add(this.flowLayoutPanel14);
			this.flpPUE.Controls.Add(this.flowLayoutPanel9);
			this.flpPUE.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPUE.Location = new System.Drawing.Point(320, 442);
			this.flpPUE.Margin = new System.Windows.Forms.Padding(1);
			this.flpPUE.Name = "flpPUE";
			this.flpPUE.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpPUE.Size = new System.Drawing.Size(1157, 167);
			this.flpPUE.TabIndex = 140;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(1, 2);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(1);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(1151, 36);
			this.flpTotalesTodos.TabIndex = 135;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel3, this.tstxtNumPUE, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotalPUE, this.toolStripSeparator1, this.toolStripLabel17, this.tstxtIvaPUE, this.toolStripSeparator2, this.toolStripLabel1,
				this.tstxtRetencionesPUE, this.toolStripSeparator13, this.toolStripLabel2, this.tstxtImportePUE
			});
			this.toolStrip1.Location = new System.Drawing.Point(0, 1);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(1009, 33);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(102, 28);
			this.toolStripLabel3.Text = "           PUE:";
			this.tstxtNumPUE.Name = "tstxtNumPUE";
			this.tstxtNumPUE.ReadOnly = true;
			this.tstxtNumPUE.Size = new System.Drawing.Size(52, 33);
			this.tstxtNumPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel4.Text = "SubTotal:";
			this.tstxtSubtotalPUE.Name = "tstxtSubtotalPUE";
			this.tstxtSubtotalPUE.ReadOnly = true;
			this.tstxtSubtotalPUE.Size = new System.Drawing.Size(126, 33);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel17.Name = "toolStripLabel17";
			this.toolStripLabel17.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel17.Text = "I.V.A:";
			this.tstxtIvaPUE.Name = "tstxtIvaPUE";
			this.tstxtIvaPUE.ReadOnly = true;
			this.tstxtIvaPUE.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(110, 28);
			this.toolStripLabel1.Text = "Retenciones:";
			this.tstxtRetencionesPUE.Name = "tstxtRetencionesPUE";
			this.tstxtRetencionesPUE.ReadOnly = true;
			this.tstxtRetencionesPUE.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(53, 28);
			this.toolStripLabel2.Text = "Total:";
			this.tstxtImportePUE.Name = "tstxtImportePUE";
			this.tstxtImportePUE.ReadOnly = true;
			this.tstxtImportePUE.Size = new System.Drawing.Size(128, 33);
			this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel8.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel8.Location = new System.Drawing.Point(1, 40);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel8.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel8.TabIndex = 136;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel5, this.tstxtNumCP, this.toolStripSeparator3, this.toolStripLabel6, this.tstxtSubtotalCP, this.toolStripSeparator5, this.toolStripLabel7, this.tstxtIvaCP, this.toolStripSeparator6, this.toolStripLabel18,
				this.tstxtRetencionesCP, this.toolStripSeparator14, this.toolStripLabel8, this.tstxtImporteCP
			});
			this.toolStrip2.Location = new System.Drawing.Point(0, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(1009, 33);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(102, 28);
			this.toolStripLabel5.Text = "             CP:";
			this.tstxtNumCP.Name = "tstxtNumCP";
			this.tstxtNumCP.ReadOnly = true;
			this.tstxtNumCP.Size = new System.Drawing.Size(52, 33);
			this.tstxtNumCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel6.Text = "SubTotal:";
			this.tstxtSubtotalCP.Name = "tstxtSubtotalCP";
			this.tstxtSubtotalCP.ReadOnly = true;
			this.tstxtSubtotalCP.Size = new System.Drawing.Size(126, 33);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tstxtIvaCP.Name = "tstxtIvaCP";
			this.tstxtIvaCP.ReadOnly = true;
			this.tstxtIvaCP.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel18.Name = "toolStripLabel18";
			this.toolStripLabel18.Size = new System.Drawing.Size(110, 28);
			this.toolStripLabel18.Text = "Retenciones:";
			this.tstxtRetencionesCP.Name = "tstxtRetencionesCP";
			this.tstxtRetencionesCP.ReadOnly = true;
			this.tstxtRetencionesCP.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(53, 28);
			this.toolStripLabel8.Text = "Total:";
			this.tstxtImporteCP.Name = "tstxtImporteCP";
			this.tstxtImporteCP.ReadOnly = true;
			this.tstxtImporteCP.Size = new System.Drawing.Size(128, 33);
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel14.Controls.Add(this.toolStrip5);
			this.flowLayoutPanel14.Location = new System.Drawing.Point(1, 78);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel14.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel14.TabIndex = 138;
			this.toolStrip5.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel20, this.tstxtNumEg, this.toolStripSeparator16, this.toolStripLabel21, this.tstxtSubtotalEg, this.toolStripSeparator17, this.toolStripLabel22, this.tstxtIvaEg, this.toolStripSeparator18, this.toolStripLabel23,
				this.tstxtRetencionesEg, this.toolStripSeparator19, this.toolStripLabel24, this.tstxtImporteEg
			});
			this.toolStrip5.Location = new System.Drawing.Point(0, 1);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip5.Size = new System.Drawing.Size(1005, 33);
			this.toolStrip5.TabIndex = 2;
			this.toolStrip5.Text = "toolStrip5";
			this.toolStripLabel20.Name = "toolStripLabel20";
			this.toolStripLabel20.Size = new System.Drawing.Size(98, 28);
			this.toolStripLabel20.Text = "    Egresos:";
			this.tstxtNumEg.Name = "tstxtNumEg";
			this.tstxtNumEg.ReadOnly = true;
			this.tstxtNumEg.Size = new System.Drawing.Size(52, 33);
			this.tstxtNumEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel21.Name = "toolStripLabel21";
			this.toolStripLabel21.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel21.Text = "SubTotal:";
			this.tstxtSubtotalEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEg.Name = "tstxtSubtotalEg";
			this.tstxtSubtotalEg.ReadOnly = true;
			this.tstxtSubtotalEg.Size = new System.Drawing.Size(126, 33);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel22.Name = "toolStripLabel22";
			this.toolStripLabel22.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel22.Text = "I.V.A:";
			this.tstxtIvaEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEg.Name = "tstxtIvaEg";
			this.tstxtIvaEg.ReadOnly = true;
			this.tstxtIvaEg.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel23.Name = "toolStripLabel23";
			this.toolStripLabel23.Size = new System.Drawing.Size(110, 28);
			this.toolStripLabel23.Text = "Retenciones:";
			this.tstxtRetencionesEg.Name = "tstxtRetencionesEg";
			this.tstxtRetencionesEg.ReadOnly = true;
			this.tstxtRetencionesEg.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel24.Name = "toolStripLabel24";
			this.toolStripLabel24.Size = new System.Drawing.Size(53, 28);
			this.toolStripLabel24.Text = "Total:";
			this.tstxtImporteEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteEg.Name = "tstxtImporteEg";
			this.tstxtImporteEg.ReadOnly = true;
			this.tstxtImporteEg.Size = new System.Drawing.Size(128, 33);
			this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel9.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel9.Location = new System.Drawing.Point(1, 116);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel9.Size = new System.Drawing.Size(1151, 36);
			this.flowLayoutPanel9.TabIndex = 137;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel9, this.tstxtNumTotal, this.toolStripSeparator7, this.toolStripLabel10, this.tstxtSubtotalTotal, this.toolStripSeparator8, this.toolStripLabel11, this.tstxtIvaTotal, this.toolStripSeparator9, this.toolStripLabel19,
				this.tstxtRetencionesTotal, this.toolStripSeparator15, this.toolStripLabel12, this.tstxtImporteTotal
			});
			this.toolStrip3.Location = new System.Drawing.Point(0, 1);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip3.Size = new System.Drawing.Size(1003, 33);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStripLabel9.Name = "toolStripLabel9";
			this.toolStripLabel9.Size = new System.Drawing.Size(96, 28);
			this.toolStripLabel9.Text = "Total Flujo:";
			this.tstxtNumTotal.Name = "tstxtNumTotal";
			this.tstxtNumTotal.ReadOnly = true;
			this.tstxtNumTotal.Size = new System.Drawing.Size(52, 33);
			this.tstxtNumTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel10.Name = "toolStripLabel10";
			this.toolStripLabel10.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel10.Text = "SubTotal:";
			this.tstxtSubtotalTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotal.Name = "tstxtSubtotalTotal";
			this.tstxtSubtotalTotal.ReadOnly = true;
			this.tstxtSubtotalTotal.Size = new System.Drawing.Size(126, 33);
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel11.Name = "toolStripLabel11";
			this.toolStripLabel11.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel11.Text = "I.V.A:";
			this.tstxtIvaTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotal.Name = "tstxtIvaTotal";
			this.tstxtIvaTotal.ReadOnly = true;
			this.tstxtIvaTotal.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel19.Name = "toolStripLabel19";
			this.toolStripLabel19.Size = new System.Drawing.Size(110, 28);
			this.toolStripLabel19.Text = "Retenciones:";
			this.tstxtRetencionesTotal.Name = "tstxtRetencionesTotal";
			this.tstxtRetencionesTotal.ReadOnly = true;
			this.tstxtRetencionesTotal.Size = new System.Drawing.Size(121, 33);
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 33);
			this.toolStripLabel12.Name = "toolStripLabel12";
			this.toolStripLabel12.Size = new System.Drawing.Size(53, 28);
			this.toolStripLabel12.Text = "Total:";
			this.tstxtImporteTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteTotal.Name = "tstxtImporteTotal";
			this.tstxtImporteTotal.ReadOnly = true;
			this.tstxtImporteTotal.Size = new System.Drawing.Size(128, 33);
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(129, 578);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(340, 18);
			this.label7.TabIndex = 139;
			this.label7.Text = "*Complementos de Pago depositados en Mes anterior";
			this.label7.Visible = false;
			this.tpCPaPUE.Controls.Add(this.gvCPaPUE);
			this.tpCPaPUE.Location = new System.Drawing.Point(4, 27);
			this.tpCPaPUE.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpCPaPUE.Name = "tpCPaPUE";
			this.tpCPaPUE.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tpCPaPUE.Size = new System.Drawing.Size(1477, 648);
			this.tpCPaPUE.TabIndex = 1;
			this.tpCPaPUE.Text = "CP APLICADOS A PUE";
			this.tpCPaPUE.UseVisualStyleBackColor = true;
			this.gvCPaPUE.AllowUserToAddRows = false;
			dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
			this.gvCPaPUE.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
			this.gvCPaPUE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvCPaPUE.AutoGenerateColumns = false;
			this.gvCPaPUE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvCPaPUE.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvCPaPUE.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvCPaPUE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvCPaPUE.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17);
			this.gvCPaPUE.DataSource = this.entFacturaBindingSource;
			this.gvCPaPUE.Location = new System.Drawing.Point(2, 0);
			this.gvCPaPUE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvCPaPUE.Name = "gvCPaPUE";
			this.gvCPaPUE.ReadOnly = true;
			this.gvCPaPUE.RowHeadersVisible = false;
			this.gvCPaPUE.RowHeadersWidth = 51;
			dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
			this.gvCPaPUE.RowsDefaultCellStyle = dataGridViewCellStyle22;
			this.gvCPaPUE.RowTemplate.Height = 30;
			this.gvCPaPUE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvCPaPUE.Size = new System.Drawing.Size(1472, 645);
			this.gvCPaPUE.TabIndex = 15;
			this.gvCPaPUE.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellDoubleClick);
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
			dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle23;
			this.dataGridViewTextBoxColumn3.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn4.FillWeight = 90f;
			this.dataGridViewTextBoxColumn4.HeaderText = "Fecha Timbrado";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "FechaPagoS";
			this.dataGridViewTextBoxColumn5.HeaderText = "Fecha Pago";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn6.FillWeight = 90f;
			this.dataGridViewTextBoxColumn6.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle24;
			this.dataGridViewTextBoxColumn7.FillWeight = 90f;
			this.dataGridViewTextBoxColumn7.HeaderText = "Metodo Pago";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "FormaPago";
			dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewTextBoxColumn8.FillWeight = 120f;
			this.dataGridViewTextBoxColumn8.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "SubTotal";
			dataGridViewCellStyle26.Format = "c2";
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle26;
			this.dataGridViewTextBoxColumn9.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "Descuento";
			dataGridViewCellStyle27.Format = "c2";
			this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle27;
			this.dataGridViewTextBoxColumn10.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.Visible = false;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "IVA";
			dataGridViewCellStyle28.Format = "c2";
			this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle28;
			this.dataGridViewTextBoxColumn11.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Retenciones";
			dataGridViewCellStyle29.Format = "c2";
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle29;
			this.dataGridViewTextBoxColumn12.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "Total";
			dataGridViewCellStyle30.Format = "c2";
			this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle30;
			this.dataGridViewTextBoxColumn13.HeaderText = "Total (MXN)";
			this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.dataGridViewTextBoxColumn14.DataPropertyName = "Moneda";
			this.dataGridViewTextBoxColumn14.FillWeight = 50f;
			this.dataGridViewTextBoxColumn14.HeaderText = "Moneda";
			this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle31.Format = "N2";
			dataGridViewCellStyle31.NullValue = null;
			this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle31;
			this.dataGridViewTextBoxColumn15.FillWeight = 50f;
			this.dataGridViewTextBoxColumn15.HeaderText = "Tipo Cambio";
			this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "UsoCFDI";
			this.dataGridViewTextBoxColumn16.HeaderText = "Uso CFDI";
			this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn17.FillWeight = 60f;
			this.dataGridViewTextBoxColumn17.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			this.flpPPDPUECPtotales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flpPPDPUECPtotales.Controls.Add(this.flowLayoutPanel6);
			this.flpPPDPUECPtotales.Controls.Add(this.flowLayoutPanel1);
			this.flpPPDPUECPtotales.Controls.Add(this.flowLayoutPanel3);
			this.flpPPDPUECPtotales.Controls.Add(this.flowLayoutPanel4);
			this.flpPPDPUECPtotales.Controls.Add(this.flowLayoutPanel11);
			this.flpPPDPUECPtotales.Controls.Add(this.flowLayoutPanel13);
			this.flpPPDPUECPtotales.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPPDPUECPtotales.Location = new System.Drawing.Point(1240, 86);
			this.flpPPDPUECPtotales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flpPPDPUECPtotales.Name = "flpPPDPUECPtotales";
			this.flpPPDPUECPtotales.Size = new System.Drawing.Size(246, 385);
			this.flpPPDPUECPtotales.TabIndex = 137;
			this.flpPPDPUECPtotales.Visible = false;
			this.flowLayoutPanel6.Controls.Add(this.txtTotalPPD);
			this.flowLayoutPanel6.Controls.Add(this.label6);
			this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel6.Location = new System.Drawing.Point(3, 2);
			this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Size = new System.Drawing.Size(238, 38);
			this.flowLayoutPanel6.TabIndex = 0;
			this.flowLayoutPanel6.Visible = false;
			this.txtTotalPPD.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPPD.Location = new System.Drawing.Point(59, 2);
			this.txtTotalPPD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			this.flowLayoutPanel1.Controls.Add(this.txtTotalPUE);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 44);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(238, 38);
			this.flowLayoutPanel1.TabIndex = 0;
			this.txtTotalPUE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPUE.Location = new System.Drawing.Point(59, 2);
			this.txtTotalPUE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			this.flowLayoutPanel3.Controls.Add(this.txtTotalCP);
			this.flowLayoutPanel3.Controls.Add(this.label4);
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 86);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(238, 38);
			this.flowLayoutPanel3.TabIndex = 1;
			this.txtTotalCP.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalCP.Location = new System.Drawing.Point(59, 2);
			this.txtTotalCP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			this.flowLayoutPanel4.Controls.Add(this.txtTotal);
			this.flowLayoutPanel4.Controls.Add(this.label5);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(3, 128);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(238, 38);
			this.flowLayoutPanel4.TabIndex = 2;
			this.flowLayoutPanel4.Visible = false;
			this.txtTotal.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotal.Location = new System.Drawing.Point(59, 2);
			this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			this.flowLayoutPanel11.Controls.Add(this.txtTotalTasa0);
			this.flowLayoutPanel11.Controls.Add(this.label8);
			this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel11.Location = new System.Drawing.Point(3, 170);
			this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel11.Name = "flowLayoutPanel11";
			this.flowLayoutPanel11.Size = new System.Drawing.Size(238, 38);
			this.flowLayoutPanel11.TabIndex = 3;
			this.flowLayoutPanel11.Visible = false;
			this.txtTotalTasa0.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalTasa0.Location = new System.Drawing.Point(105, 2);
			this.txtTotalTasa0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtTotalTasa0.Name = "txtTotalTasa0";
			this.txtTotalTasa0.ReadOnly = true;
			this.txtTotalTasa0.Size = new System.Drawing.Size(130, 28);
			this.txtTotalTasa0.TabIndex = 1;
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
			this.flowLayoutPanel13.Location = new System.Drawing.Point(3, 212);
			this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel13.Name = "flowLayoutPanel13";
			this.flowLayoutPanel13.Size = new System.Drawing.Size(238, 38);
			this.flowLayoutPanel13.TabIndex = 142;
			this.txtTotalEgresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalEgresos.Location = new System.Drawing.Point(105, 2);
			this.txtTotalEgresos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1548, 995);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "AnalisisComprobantes";
			this.Text = "Analisis Flujo";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.pnlFiltroPeriodo.ResumeLayout(false);
			this.pnlFiltroPeriodo.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			this.pnlPorDiaVentas.ResumeLayout(false);
			this.gbObjetos.ResumeLayout(false);
			this.flpObjetoImpuesto.ResumeLayout(false);
			this.flowLayoutPanel56.ResumeLayout(false);
			this.flowLayoutPanel56.PerformLayout();
			this.flowLayoutPanel57.ResumeLayout(false);
			this.flowLayoutPanel57.PerformLayout();
			this.flowLayoutPanel58.ResumeLayout(false);
			this.flowLayoutPanel58.PerformLayout();
			this.flowLayoutPanel16.ResumeLayout(false);
			this.flowLayoutPanel16.PerformLayout();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.flpExcluir.ResumeLayout(false);
			this.flpExcluir.PerformLayout();
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			this.flowLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel7.PerformLayout();
			this.tcCFDIs.ResumeLayout(false);
			this.tpPUECP.ResumeLayout(false);
			this.tpPUECP.PerformLayout();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.flowLayoutPanel10.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
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
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.tpCPaPUE.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvCPaPUE).EndInit();
			this.flpPPDPUECPtotales.ResumeLayout(false);
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel6.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.flowLayoutPanel11.ResumeLayout(false);
			this.flowLayoutPanel11.PerformLayout();
			this.flowLayoutPanel13.ResumeLayout(false);
			this.flowLayoutPanel13.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
