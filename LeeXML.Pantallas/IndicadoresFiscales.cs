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
	public class IndicadoresFiscales : FormBase
	{
		private IContainer components = null;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private Label label24;

		private ComboBox cmbEmpresas;

		private TabPage tabPage1;

		private TabControl tcReportesIngresos;

		private TabPage tabPage2;

		private Panel pnlFiltroPeriodo;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private TabControl tcPedidosGrids;

		private Button btnEnviarAExcel;

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

		private TextBox txtIngresosFacturados;

		private FlowLayoutPanel flowLayoutPanel16;

		private Label label16;

		private TextBox txtIngresosCobrados;

		private Label label17;

		private BindingSource entCatalogoGenericoBindingSource;

		private TabControl tabControl1;

		private TabPage tabPage3;

		private FlowLayoutPanel flowLayoutPanel1;

		private FlowLayoutPanel flowLayoutPanel2;

		private Label label1;

		private TextBox txtIvaCobrado;

		private Label label2;

		private FlowLayoutPanel flowLayoutPanel3;

		private Label label3;

		private TextBox txtIvaAcreditable;

		private TabControl tabControl2;

		private TabPage tabPage4;

		private FlowLayoutPanel flowLayoutPanel4;

		private FlowLayoutPanel flowLayoutPanel5;

		private Label label4;

		private TextBox txtDeduccionesPagadas;

		private Label label5;

		private TabControl tabControl3;

		private TabPage tabPage5;

		private FlowLayoutPanel flowLayoutPanel7;

		private FlowLayoutPanel flowLayoutPanel8;

		private Label label7;

		private TextBox txtIsrRetenidoPorSalario;

		private Label label8;

		private FlowLayoutPanel flowLayoutPanel9;

		private Label label9;

		private TextBox txtIvaRetenido;

		private Label label15;

		private FlowLayoutPanel flowLayoutPanel10;

		private Label label18;

		private TextBox txtIsrRetenido;

		private TabControl tabControl4;

		private TabPage tabPage6;

		private FlowLayoutPanel flowLayoutPanel6;

		private FlowLayoutPanel flowLayoutPanel11;

		private Label label6;

		private TextBox txtIvaRetenidoAFavor;

		private Label label19;

		private FlowLayoutPanel flowLayoutPanel12;

		private Label label20;

		private TextBox txtIsrRetenidoAFavor;

		private TabControl tabControl6;

		private TabPage tabPage8;

		private FlowLayoutPanel flowLayoutPanel18;

		private FlowLayoutPanel flowLayoutPanel19;

		private Label label27;

		private TextBox txtActos16;

		private Label label28;

		private FlowLayoutPanel flowLayoutPanel20;

		private Label label29;

		private TextBox txtActos8;

		private Label label30;

		private FlowLayoutPanel flowLayoutPanel21;

		private Label label31;

		private TextBox txtActos0;

		private Label label32;

		private FlowLayoutPanel flowLayoutPanel22;

		private Label label33;

		private TextBox txtActosExento;

		private TabControl tabControl5;

		private TabPage tabPage7;

		private FlowLayoutPanel flowLayoutPanel13;

		private FlowLayoutPanel flowLayoutPanel14;

		private Label label21;

		private TextBox txtSueldosTotales;

		private Label label22;

		private FlowLayoutPanel flowLayoutPanel15;

		private Label label23;

		private TextBox txtSueldosExentos;

		private Label label25;

		private FlowLayoutPanel flowLayoutPanel17;

		private Label label26;

		private TextBox txtSueldosGravados;

		private FlowLayoutPanel flowLayoutPanel23;

		private FlowLayoutPanel flowLayoutPanel24;

		private Label label34;

		private TextBox txtNC16;

		private Label label35;

		private FlowLayoutPanel flowLayoutPanel25;

		private Label label36;

		private TextBox txtNC8;

		private Label label37;

		private FlowLayoutPanel flpEmpresas;

		private Button btnBuscaEmpresa;

		private int PeriocidadId { get; set; }

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantesEgresos { get; set; }

		private List<EntCatalogoPercepciones> lstDeducciones { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
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

		public IndicadoresFiscales()
		{
			InitializeComponent();
			base.Size = new Size(500, 500);
		}

		private void InicializaPantalla()
		{
			PeriocidadId = 1;
			CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
			SeleccionaPeriodoActual(cmbMesesComprobantes, PeriocidadId, new Label());
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
			ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Program.EmpresaSeleccionada, FechaDesde, FechaHasta, 1));
			ListaComprobantesEgresos = new BusFacturas().ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantesEgresos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Program.EmpresaSeleccionada, FechaDesde, FechaHasta, 1));
			ListaComprobantesEgresos = ListaComprobantesEgresos.Where((EntFactura P) => P.Deducible).ToList();
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, DateTime FechaDesde, DateTime FechaHasta, TextBox TxtMuestraIngresosFacturados, TextBox TxtMuestraSubtotal, TextBox TxtMuestraIva, TextBox TxtMuestraIsrRetenidoSalario, TextBox TxtMuestraIvaRetenido, TextBox TxtMuestraIsrRetenido)
		{
			List<EntFactura> lstFiltro = ListaComprobantes.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			CalculaSumaTotalFromListaProductos(lstFiltro.ToList(), true, new TextBox(), TxtMuestraIngresosFacturados, new TextBox(), new TextBox(), new TextBox());
			decimal totalPue = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.SubTotal);
			decimal totalCP = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= base.FechaDesde(true, FechaDesde.Year.ToString(), FechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.SubTotal);
			decimal totalNC07 = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7).Sum((EntFactura P) => P.SubTotal);
			decimal ivaPue = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.IVA);
			decimal ivaCP = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= base.FechaDesde(true, FechaDesde.Year.ToString(), FechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.IVA);
			decimal ivaNC07 = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 2 && (P.TipoRelacionId == 7 || P.TipoRelacionId == 1 || P.TipoRelacionId == 3)).Sum((EntFactura P) => P.IVA);
			TxtMuestraSubtotal.Text = FormatoMoney(totalPue + totalCP - totalNC07);
			TxtMuestraIva.Text = FormatoMoney(ivaPue + ivaCP - ivaNC07);
			lstDeducciones = new BusFacturas().ObtieneComprobantesFiscalesNominasDeduccionesXML(base.EmpresaSeleccionada, FechaDesde, FechaHasta);
			lstDeducciones = lstDeducciones.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Cliente.ToUpper().Contains(txtCliente.Text.ToUpper()) && P.Clave == "002").ToList();
			TxtMuestraIsrRetenidoSalario.Text = FormatoMoney(lstDeducciones.Sum((EntCatalogoPercepciones P) => P.Total));
			decimal ivaPueRetenido = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.IVARetenciones);
			decimal ivaCpRetenido = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= base.FechaDesde(true, FechaDesde.Year.ToString(), FechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.IVARetenciones);
			decimal ivaNC07Retenido = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7).Sum((EntFactura P) => P.IVARetenciones);
			decimal isrPueRetenido = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.ISRRetenciones);
			decimal isrCpRetenido = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= base.FechaDesde(true, FechaDesde.Year.ToString(), FechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.ISRRetenciones);
			decimal isrNC07Retenido = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7).Sum((EntFactura P) => P.ISRRetenciones);
			TxtMuestraIvaRetenido.Text = FormatoMoney(ivaPueRetenido + ivaCpRetenido - ivaNC07Retenido);
			TxtMuestraIsrRetenido.Text = FormatoMoney(isrPueRetenido + isrCpRetenido - isrNC07Retenido);
		}

		private void FiltraComprobantesEgresos(List<EntFactura> ListaComprobantes, DateTime FechaDesde, TextBox TxtMuestraImporte, TextBox TxtMuestraSubtotal, TextBox TxtMuestraIVA, TextBox TxtMuestraNum)
		{
			List<EntFactura> lstFiltro = ListaComprobantes.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			decimal totalPue = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.SubTotal);
			decimal totalCP = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= base.FechaDesde(true, FechaDesde.Year.ToString(), FechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.SubTotal);
			decimal totalNC07 = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7).Sum((EntFactura P) => P.SubTotal);
			decimal ivaPue = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.IVA);
			decimal ivaCP = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= base.FechaDesde(true, FechaDesde.Year.ToString(), FechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.IVA);
			decimal ivaNC07 = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7).Sum((EntFactura P) => P.IVA);
			TxtMuestraSubtotal.Text = FormatoMoney(totalPue + totalCP - totalNC07);
			TxtMuestraIVA.Text = FormatoMoney(ivaPue + ivaCP - ivaNC07);
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				CargaComprobantes(Program.EmpresaSeleccionada, fechaDesde, fechaHasta);
				FiltraComprobantes(ListaComprobantes, fechaDesde, fechaHasta, txtIngresosFacturados, txtIngresosCobrados, txtIvaCobrado, new TextBox(), txtIvaRetenidoAFavor, txtIsrRetenidoAFavor);
				FiltraComprobantes(ListaComprobantesEgresos, fechaDesde, fechaHasta, new TextBox(), txtDeduccionesPagadas, txtIvaAcreditable, txtIsrRetenidoPorSalario, txtIvaRetenido, txtIsrRetenido);
				List<EntCatalogoPercepciones> lstPercepciones = new BusFacturas().ObtieneComprobantesFiscalesNominasPercepcionesXML(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
				txtSueldosTotales.Text = FormatoMoney(lstPercepciones.Sum((EntCatalogoPercepciones P) => P.Total));
				txtSueldosExentos.Text = FormatoMoney(lstPercepciones.Sum((EntCatalogoPercepciones P) => P.Excento));
				txtSueldosGravados.Text = FormatoMoney(lstPercepciones.Sum((EntCatalogoPercepciones P) => P.Gravado));
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesEgresosDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				listaComprobantesDA = listaComprobantesDA.Where((EntFactura P) => P.Deducible).ToList();
				decimal totalIngreso16 = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0.16m && P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total);
				decimal totalCP16 = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0.16m && P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, fechaDesde.Year.ToString(), fechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.Total);
				decimal totalIngreso17 = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0.08m && P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total);
				decimal totalCP17 = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0.08m && P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, fechaDesde.Year.ToString(), fechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.Total);
				decimal totalIngreso18 = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0m && P.TipoFactorId == 1 && P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total);
				decimal totalCP18 = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0m && P.TipoFactorId == 1 && P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, fechaDesde.Year.ToString(), fechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.Total);
				decimal totalIngresoExento = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0m && P.TipoFactorId == 3 && P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.Total);
				decimal totalCPExento = listaComprobantesDA.Where((EntFactura P) => P.TasaOCuota == 0m && P.TipoFactorId == 3 && P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, fechaDesde.Year.ToString(), fechaDesde.Month, DateTime.Today)).Sum((EntFactura P) => P.Total);
				txtActos16.Text = FormatoMoney(totalIngreso16 + totalCP16);
				txtActos8.Text = FormatoMoney(totalIngreso17 + totalCP17);
				txtActos0.Text = FormatoMoney(totalIngreso18 + totalCP18);
				txtActosExento.Text = FormatoMoney(totalIngresoExento + totalCPExento);
				txtNC16.Text = FormatoMoney(listaComprobantesDA.Where((EntFactura P) => P.TipoComprobanteId == 2 && (P.TipoRelacionId == 7 || P.TipoRelacionId == 1 || P.TipoRelacionId == 3) && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total));
				txtNC8.Text = FormatoMoney(listaComprobantesDA.Where((EntFactura P) => P.TipoComprobanteId == 2 && (P.TipoRelacionId == 7 || P.TipoRelacionId == 1 || P.TipoRelacionId == 3) && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total));
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

		private void btnEnviarAExcel_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntEstadoDeCuenta> lstIVA = new List<EntEstadoDeCuenta>();
				string titulo = "INDICADORES FISCALES";
				ImprimeIndicadoresFiscales vImprime = new ImprimeIndicadoresFiscales(lstIVA, titulo, cmbMesesComprobantes.Text, txtIngresosFacturados.Text, txtIngresosCobrados.Text, txtDeduccionesPagadas.Text, txtIvaCobrado.Text, txtIvaAcreditable.Text, txtIvaRetenidoAFavor.Text, txtIsrRetenidoAFavor.Text, txtIvaRetenido.Text, txtIsrRetenido.Text, txtSueldosTotales.Text, txtSueldosExentos.Text, txtSueldosGravados.Text, txtIsrRetenidoPorSalario.Text, txtActos16.Text, txtActos8.Text, txtActos0.Text, txtActosExento.Text, txtNC16.Text, txtNC8.Text);
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

		private void btnFiltraFacturas_Click(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.IndicadoresFiscales));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabControl6 = new System.Windows.Forms.TabControl();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel23 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel24 = new System.Windows.Forms.FlowLayoutPanel();
			this.label34 = new System.Windows.Forms.Label();
			this.txtNC16 = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.flowLayoutPanel25 = new System.Windows.Forms.FlowLayoutPanel();
			this.label36 = new System.Windows.Forms.Label();
			this.txtNC8 = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.flowLayoutPanel18 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel19 = new System.Windows.Forms.FlowLayoutPanel();
			this.label27 = new System.Windows.Forms.Label();
			this.txtActos16 = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.flowLayoutPanel20 = new System.Windows.Forms.FlowLayoutPanel();
			this.label29 = new System.Windows.Forms.Label();
			this.txtActos8 = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.flowLayoutPanel21 = new System.Windows.Forms.FlowLayoutPanel();
			this.label31 = new System.Windows.Forms.Label();
			this.txtActos0 = new System.Windows.Forms.TextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.flowLayoutPanel22 = new System.Windows.Forms.FlowLayoutPanel();
			this.label33 = new System.Windows.Forms.Label();
			this.txtActosExento = new System.Windows.Forms.TextBox();
			this.tabControl5 = new System.Windows.Forms.TabControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.label21 = new System.Windows.Forms.Label();
			this.txtSueldosTotales = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
			this.label23 = new System.Windows.Forms.Label();
			this.txtSueldosExentos = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
			this.label26 = new System.Windows.Forms.Label();
			this.txtSueldosGravados = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.txtIsrRetenidoPorSalario = new System.Windows.Forms.TextBox();
			this.tabControl4 = new System.Windows.Forms.TabControl();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.txtIvaRetenidoAFavor = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
			this.label20 = new System.Windows.Forms.Label();
			this.txtIsrRetenidoAFavor = new System.Windows.Forms.TextBox();
			this.tabControl3 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
			this.label9 = new System.Windows.Forms.Label();
			this.txtIvaRetenido = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.label18 = new System.Windows.Forms.Label();
			this.txtIsrRetenido = new System.Windows.Forms.TextBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDeduccionesPagadas = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtIvaCobrado = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIvaAcreditable = new System.Windows.Forms.TextBox();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.btnEnviarAExcel = new System.Windows.Forms.Button();
			this.pnlFiltroPeriodo = new System.Windows.Forms.Panel();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flpObjetoImpuesto = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel56 = new System.Windows.Forms.FlowLayoutPanel();
			this.label14 = new System.Windows.Forms.Label();
			this.txtIngresosFacturados = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
			this.label16 = new System.Windows.Forms.Label();
			this.txtIngresosCobrados = new System.Windows.Forms.TextBox();
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
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.flpEmpresas = new System.Windows.Forms.FlowLayoutPanel();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tabPage1.SuspendLayout();
			this.tabControl6.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.flowLayoutPanel23.SuspendLayout();
			this.flowLayoutPanel24.SuspendLayout();
			this.flowLayoutPanel25.SuspendLayout();
			this.flowLayoutPanel18.SuspendLayout();
			this.flowLayoutPanel19.SuspendLayout();
			this.flowLayoutPanel20.SuspendLayout();
			this.flowLayoutPanel21.SuspendLayout();
			this.flowLayoutPanel22.SuspendLayout();
			this.tabControl5.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.flowLayoutPanel13.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.flowLayoutPanel15.SuspendLayout();
			this.flowLayoutPanel17.SuspendLayout();
			this.flowLayoutPanel8.SuspendLayout();
			this.tabControl4.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.flowLayoutPanel12.SuspendLayout();
			this.tabControl3.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.flowLayoutPanel7.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel5.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.pnlFiltroPeriodo.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flpObjetoImpuesto.SuspendLayout();
			this.flowLayoutPanel56.SuspendLayout();
			this.flowLayoutPanel16.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.flpEmpresas.SuspendLayout();
			base.SuspendLayout();
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(3, 2);
			this.label24.Name = "label24";
			this.label24.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.label24.Size = new System.Drawing.Size(73, 27);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(82, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(410, 24);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.tabPage1.AutoScroll = true;
			this.tabPage1.BackgroundImage = (System.Drawing.Image)resources.GetObject("tabPage1.BackgroundImage");
			this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.tabPage1.Controls.Add(this.tabControl6);
			this.tabPage1.Controls.Add(this.tabControl5);
			this.tabPage1.Controls.Add(this.tabControl4);
			this.tabPage1.Controls.Add(this.tabControl3);
			this.tabPage1.Controls.Add(this.tabControl2);
			this.tabPage1.Controls.Add(this.tabControl1);
			this.tabPage1.Controls.Add(this.btnRefrescar);
			this.tabPage1.Controls.Add(this.btnEnviarAExcel);
			this.tabPage1.Controls.Add(this.pnlFiltroPeriodo);
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Controls.Add(this.pnlFiltro);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage1.Size = new System.Drawing.Size(1021, 854);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Generales";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabControl6.Controls.Add(this.tabPage8);
			this.tabControl6.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl6.Location = new System.Drawing.Point(235, 556);
			this.tabControl6.Name = "tabControl6";
			this.tabControl6.SelectedIndex = 0;
			this.tabControl6.Size = new System.Drawing.Size(737, 146);
			this.tabControl6.TabIndex = 142;
			this.tabPage8.Controls.Add(this.flowLayoutPanel23);
			this.tabPage8.Controls.Add(this.flowLayoutPanel18);
			this.tabPage8.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage8.Location = new System.Drawing.Point(4, 23);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage8.Size = new System.Drawing.Size(729, 119);
			this.tabPage8.TabIndex = 0;
			this.tabPage8.Text = "RESUMEN DIOT";
			this.tabPage8.UseVisualStyleBackColor = true;
			this.flowLayoutPanel23.Controls.Add(this.flowLayoutPanel24);
			this.flowLayoutPanel23.Controls.Add(this.label35);
			this.flowLayoutPanel23.Controls.Add(this.flowLayoutPanel25);
			this.flowLayoutPanel23.Controls.Add(this.label37);
			this.flowLayoutPanel23.Location = new System.Drawing.Point(1, 64);
			this.flowLayoutPanel23.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel23.Name = "flowLayoutPanel23";
			this.flowLayoutPanel23.Size = new System.Drawing.Size(718, 55);
			this.flowLayoutPanel23.TabIndex = 143;
			this.flowLayoutPanel24.Controls.Add(this.label34);
			this.flowLayoutPanel24.Controls.Add(this.txtNC16);
			this.flowLayoutPanel24.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel24.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel24.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel24.Name = "flowLayoutPanel24";
			this.flowLayoutPanel24.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel24.TabIndex = 0;
			this.label34.AutoSize = true;
			this.label34.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label34.Location = new System.Drawing.Point(2, 0);
			this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(41, 13);
			this.label34.TabIndex = 0;
			this.label34.Text = "NC 16%";
			this.txtNC16.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNC16.Location = new System.Drawing.Point(2, 14);
			this.txtNC16.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtNC16.Name = "txtNC16";
			this.txtNC16.ReadOnly = true;
			this.txtNC16.Size = new System.Drawing.Size(140, 35);
			this.txtNC16.TabIndex = 155;
			this.txtNC16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label35.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label35.Location = new System.Drawing.Point(155, 0);
			this.label35.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(32, 51);
			this.label35.TabIndex = 4;
			this.label35.Text = "|";
			this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel25.Controls.Add(this.label36);
			this.flowLayoutPanel25.Controls.Add(this.txtNC8);
			this.flowLayoutPanel25.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel25.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel25.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel25.Name = "flowLayoutPanel25";
			this.flowLayoutPanel25.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel25.TabIndex = 3;
			this.label36.AutoSize = true;
			this.label36.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label36.Location = new System.Drawing.Point(2, 0);
			this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(36, 13);
			this.label36.TabIndex = 0;
			this.label36.Text = "NC 8%";
			this.txtNC8.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNC8.Location = new System.Drawing.Point(2, 14);
			this.txtNC8.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtNC8.Name = "txtNC8";
			this.txtNC8.ReadOnly = true;
			this.txtNC8.Size = new System.Drawing.Size(140, 35);
			this.txtNC8.TabIndex = 155;
			this.txtNC8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label37.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label37.Location = new System.Drawing.Point(343, 0);
			this.label37.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(32, 51);
			this.label37.TabIndex = 6;
			this.label37.Text = "|";
			this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel18.Controls.Add(this.flowLayoutPanel19);
			this.flowLayoutPanel18.Controls.Add(this.label28);
			this.flowLayoutPanel18.Controls.Add(this.flowLayoutPanel20);
			this.flowLayoutPanel18.Controls.Add(this.label30);
			this.flowLayoutPanel18.Controls.Add(this.flowLayoutPanel21);
			this.flowLayoutPanel18.Controls.Add(this.label32);
			this.flowLayoutPanel18.Controls.Add(this.flowLayoutPanel22);
			this.flowLayoutPanel18.Location = new System.Drawing.Point(2, 5);
			this.flowLayoutPanel18.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel18.Name = "flowLayoutPanel18";
			this.flowLayoutPanel18.Size = new System.Drawing.Size(718, 55);
			this.flowLayoutPanel18.TabIndex = 142;
			this.flowLayoutPanel19.Controls.Add(this.label27);
			this.flowLayoutPanel19.Controls.Add(this.txtActos16);
			this.flowLayoutPanel19.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel19.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel19.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel19.Name = "flowLayoutPanel19";
			this.flowLayoutPanel19.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel19.TabIndex = 0;
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label27.Location = new System.Drawing.Point(2, 0);
			this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(58, 13);
			this.label27.TabIndex = 0;
			this.label27.Text = "ACTOS 16%";
			this.txtActos16.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActos16.Location = new System.Drawing.Point(2, 14);
			this.txtActos16.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtActos16.Name = "txtActos16";
			this.txtActos16.ReadOnly = true;
			this.txtActos16.Size = new System.Drawing.Size(140, 35);
			this.txtActos16.TabIndex = 155;
			this.txtActos16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label28.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label28.Location = new System.Drawing.Point(155, 0);
			this.label28.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(32, 51);
			this.label28.TabIndex = 4;
			this.label28.Text = "|";
			this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel20.Controls.Add(this.label29);
			this.flowLayoutPanel20.Controls.Add(this.txtActos8);
			this.flowLayoutPanel20.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel20.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel20.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel20.Name = "flowLayoutPanel20";
			this.flowLayoutPanel20.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel20.TabIndex = 3;
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label29.Location = new System.Drawing.Point(2, 0);
			this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(53, 13);
			this.label29.TabIndex = 0;
			this.label29.Text = "ACTOS 8%";
			this.txtActos8.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActos8.Location = new System.Drawing.Point(2, 14);
			this.txtActos8.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtActos8.Name = "txtActos8";
			this.txtActos8.ReadOnly = true;
			this.txtActos8.Size = new System.Drawing.Size(140, 35);
			this.txtActos8.TabIndex = 155;
			this.txtActos8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label30.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label30.Location = new System.Drawing.Point(343, 0);
			this.label30.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(32, 51);
			this.label30.TabIndex = 6;
			this.label30.Text = "|";
			this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel21.Controls.Add(this.label31);
			this.flowLayoutPanel21.Controls.Add(this.txtActos0);
			this.flowLayoutPanel21.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel21.Location = new System.Drawing.Point(378, 1);
			this.flowLayoutPanel21.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel21.Name = "flowLayoutPanel21";
			this.flowLayoutPanel21.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel21.TabIndex = 5;
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label31.Location = new System.Drawing.Point(2, 0);
			this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(53, 13);
			this.label31.TabIndex = 0;
			this.label31.Text = "ACTOS 0%";
			this.txtActos0.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActos0.Location = new System.Drawing.Point(2, 14);
			this.txtActos0.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtActos0.Name = "txtActos0";
			this.txtActos0.ReadOnly = true;
			this.txtActos0.Size = new System.Drawing.Size(140, 35);
			this.txtActos0.TabIndex = 155;
			this.txtActos0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label32.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label32.Location = new System.Drawing.Point(531, 0);
			this.label32.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(32, 51);
			this.label32.TabIndex = 8;
			this.label32.Text = "|";
			this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel22.Controls.Add(this.label33);
			this.flowLayoutPanel22.Controls.Add(this.txtActosExento);
			this.flowLayoutPanel22.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel22.Location = new System.Drawing.Point(566, 1);
			this.flowLayoutPanel22.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel22.Name = "flowLayoutPanel22";
			this.flowLayoutPanel22.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel22.TabIndex = 7;
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label33.Location = new System.Drawing.Point(2, 0);
			this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(81, 13);
			this.label33.TabIndex = 0;
			this.label33.Text = "ACTOS EXENTOS";
			this.txtActosExento.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtActosExento.Location = new System.Drawing.Point(2, 14);
			this.txtActosExento.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtActosExento.Name = "txtActosExento";
			this.txtActosExento.ReadOnly = true;
			this.txtActosExento.Size = new System.Drawing.Size(140, 35);
			this.txtActosExento.TabIndex = 155;
			this.txtActosExento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tabControl5.Controls.Add(this.tabPage7);
			this.tabControl5.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl5.Location = new System.Drawing.Point(237, 452);
			this.tabControl5.Name = "tabControl5";
			this.tabControl5.SelectedIndex = 0;
			this.tabControl5.Size = new System.Drawing.Size(738, 92);
			this.tabControl5.TabIndex = 141;
			this.tabPage7.Controls.Add(this.flowLayoutPanel13);
			this.tabPage7.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage7.Location = new System.Drawing.Point(4, 23);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage7.Size = new System.Drawing.Size(730, 65);
			this.tabPage7.TabIndex = 0;
			this.tabPage7.Text = "RESUMEN DE NOMINA";
			this.tabPage7.UseVisualStyleBackColor = true;
			this.flowLayoutPanel13.Controls.Add(this.flowLayoutPanel14);
			this.flowLayoutPanel13.Controls.Add(this.label22);
			this.flowLayoutPanel13.Controls.Add(this.flowLayoutPanel15);
			this.flowLayoutPanel13.Controls.Add(this.label25);
			this.flowLayoutPanel13.Controls.Add(this.flowLayoutPanel17);
			this.flowLayoutPanel13.Controls.Add(this.label8);
			this.flowLayoutPanel13.Controls.Add(this.flowLayoutPanel8);
			this.flowLayoutPanel13.Location = new System.Drawing.Point(2, 5);
			this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel13.Name = "flowLayoutPanel13";
			this.flowLayoutPanel13.Size = new System.Drawing.Size(726, 55);
			this.flowLayoutPanel13.TabIndex = 142;
			this.flowLayoutPanel14.Controls.Add(this.label21);
			this.flowLayoutPanel14.Controls.Add(this.txtSueldosTotales);
			this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel14.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel14.TabIndex = 0;
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label21.Location = new System.Drawing.Point(2, 0);
			this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(91, 13);
			this.label21.TabIndex = 0;
			this.label21.Text = "SUELDOS TOTALES";
			this.txtSueldosTotales.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtSueldosTotales.Location = new System.Drawing.Point(2, 14);
			this.txtSueldosTotales.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtSueldosTotales.Name = "txtSueldosTotales";
			this.txtSueldosTotales.ReadOnly = true;
			this.txtSueldosTotales.Size = new System.Drawing.Size(140, 35);
			this.txtSueldosTotales.TabIndex = 155;
			this.txtSueldosTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label22.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label22.Location = new System.Drawing.Point(155, 0);
			this.label22.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(32, 51);
			this.label22.TabIndex = 4;
			this.label22.Text = "|";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel15.Controls.Add(this.label23);
			this.flowLayoutPanel15.Controls.Add(this.txtSueldosExentos);
			this.flowLayoutPanel15.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel15.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel15.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel15.Name = "flowLayoutPanel15";
			this.flowLayoutPanel15.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel15.TabIndex = 3;
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label23.Location = new System.Drawing.Point(2, 0);
			this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(93, 13);
			this.label23.TabIndex = 0;
			this.label23.Text = "SUELDOS EXENTOS";
			this.txtSueldosExentos.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtSueldosExentos.Location = new System.Drawing.Point(2, 14);
			this.txtSueldosExentos.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtSueldosExentos.Name = "txtSueldosExentos";
			this.txtSueldosExentos.ReadOnly = true;
			this.txtSueldosExentos.Size = new System.Drawing.Size(140, 35);
			this.txtSueldosExentos.TabIndex = 155;
			this.txtSueldosExentos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label25.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label25.Location = new System.Drawing.Point(343, 0);
			this.label25.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(32, 51);
			this.label25.TabIndex = 6;
			this.label25.Text = "|";
			this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel17.Controls.Add(this.label26);
			this.flowLayoutPanel17.Controls.Add(this.txtSueldosGravados);
			this.flowLayoutPanel17.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel17.Location = new System.Drawing.Point(378, 1);
			this.flowLayoutPanel17.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel17.Name = "flowLayoutPanel17";
			this.flowLayoutPanel17.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel17.TabIndex = 5;
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label26.Location = new System.Drawing.Point(2, 0);
			this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(103, 13);
			this.label26.TabIndex = 0;
			this.label26.Text = "SUELDOS GRAVADOS";
			this.txtSueldosGravados.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtSueldosGravados.Location = new System.Drawing.Point(2, 14);
			this.txtSueldosGravados.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtSueldosGravados.Name = "txtSueldosGravados";
			this.txtSueldosGravados.ReadOnly = true;
			this.txtSueldosGravados.Size = new System.Drawing.Size(140, 35);
			this.txtSueldosGravados.TabIndex = 155;
			this.txtSueldosGravados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new System.Drawing.Point(531, 0);
			this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(32, 51);
			this.label8.TabIndex = 4;
			this.label8.Text = "|";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel8.Controls.Add(this.label7);
			this.flowLayoutPanel8.Controls.Add(this.txtIsrRetenidoPorSalario);
			this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel8.Location = new System.Drawing.Point(566, 1);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel8.TabIndex = 0;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new System.Drawing.Point(2, 0);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "ISR RETENIDO POR SALARIO";
			this.txtIsrRetenidoPorSalario.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIsrRetenidoPorSalario.Location = new System.Drawing.Point(2, 14);
			this.txtIsrRetenidoPorSalario.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIsrRetenidoPorSalario.Name = "txtIsrRetenidoPorSalario";
			this.txtIsrRetenidoPorSalario.ReadOnly = true;
			this.txtIsrRetenidoPorSalario.Size = new System.Drawing.Size(140, 35);
			this.txtIsrRetenidoPorSalario.TabIndex = 155;
			this.txtIsrRetenidoPorSalario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tabControl4.Controls.Add(this.tabPage6);
			this.tabControl4.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl4.Location = new System.Drawing.Point(424, 244);
			this.tabControl4.Name = "tabControl4";
			this.tabControl4.SelectedIndex = 0;
			this.tabControl4.Size = new System.Drawing.Size(358, 92);
			this.tabControl4.TabIndex = 140;
			this.tabPage6.Controls.Add(this.flowLayoutPanel6);
			this.tabPage6.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage6.Location = new System.Drawing.Point(4, 23);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage6.Size = new System.Drawing.Size(350, 65);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.Text = "IMPUESTOS A FAVOR";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel11);
			this.flowLayoutPanel6.Controls.Add(this.label19);
			this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel12);
			this.flowLayoutPanel6.Location = new System.Drawing.Point(2, 5);
			this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Size = new System.Drawing.Size(345, 55);
			this.flowLayoutPanel6.TabIndex = 142;
			this.flowLayoutPanel11.Controls.Add(this.label6);
			this.flowLayoutPanel11.Controls.Add(this.txtIvaRetenidoAFavor);
			this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel11.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel11.Name = "flowLayoutPanel11";
			this.flowLayoutPanel11.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel11.TabIndex = 0;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(2, 0);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(71, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "IVA RETENIDO";
			this.txtIvaRetenidoAFavor.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaRetenidoAFavor.Location = new System.Drawing.Point(2, 14);
			this.txtIvaRetenidoAFavor.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIvaRetenidoAFavor.Name = "txtIvaRetenidoAFavor";
			this.txtIvaRetenidoAFavor.ReadOnly = true;
			this.txtIvaRetenidoAFavor.Size = new System.Drawing.Size(140, 35);
			this.txtIvaRetenidoAFavor.TabIndex = 155;
			this.txtIvaRetenidoAFavor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label19.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label19.Location = new System.Drawing.Point(155, 0);
			this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(32, 51);
			this.label19.TabIndex = 4;
			this.label19.Text = "|";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel12.Controls.Add(this.label20);
			this.flowLayoutPanel12.Controls.Add(this.txtIsrRetenidoAFavor);
			this.flowLayoutPanel12.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel12.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel12.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel12.Name = "flowLayoutPanel12";
			this.flowLayoutPanel12.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel12.TabIndex = 3;
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label20.Location = new System.Drawing.Point(2, 0);
			this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(70, 13);
			this.label20.TabIndex = 0;
			this.label20.Text = "ISR RETENIDO";
			this.txtIsrRetenidoAFavor.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIsrRetenidoAFavor.Location = new System.Drawing.Point(2, 14);
			this.txtIsrRetenidoAFavor.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIsrRetenidoAFavor.Name = "txtIsrRetenidoAFavor";
			this.txtIsrRetenidoAFavor.ReadOnly = true;
			this.txtIsrRetenidoAFavor.Size = new System.Drawing.Size(140, 35);
			this.txtIsrRetenidoAFavor.TabIndex = 155;
			this.txtIsrRetenidoAFavor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tabControl3.Controls.Add(this.tabPage5);
			this.tabControl3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl3.Location = new System.Drawing.Point(424, 347);
			this.tabControl3.Name = "tabControl3";
			this.tabControl3.SelectedIndex = 0;
			this.tabControl3.Size = new System.Drawing.Size(358, 92);
			this.tabControl3.TabIndex = 139;
			this.tabPage5.Controls.Add(this.flowLayoutPanel7);
			this.tabPage5.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage5.Location = new System.Drawing.Point(4, 23);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage5.Size = new System.Drawing.Size(350, 65);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "IMPUESTOS POR PAGAR";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.flowLayoutPanel7.Controls.Add(this.flowLayoutPanel9);
			this.flowLayoutPanel7.Controls.Add(this.label15);
			this.flowLayoutPanel7.Controls.Add(this.flowLayoutPanel10);
			this.flowLayoutPanel7.Location = new System.Drawing.Point(2, 5);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Size = new System.Drawing.Size(343, 55);
			this.flowLayoutPanel7.TabIndex = 142;
			this.flowLayoutPanel9.Controls.Add(this.label9);
			this.flowLayoutPanel9.Controls.Add(this.txtIvaRetenido);
			this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel9.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel9.TabIndex = 3;
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new System.Drawing.Point(2, 0);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(71, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "IVA RETENIDO";
			this.txtIvaRetenido.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaRetenido.Location = new System.Drawing.Point(2, 14);
			this.txtIvaRetenido.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIvaRetenido.Name = "txtIvaRetenido";
			this.txtIvaRetenido.ReadOnly = true;
			this.txtIvaRetenido.Size = new System.Drawing.Size(140, 35);
			this.txtIvaRetenido.TabIndex = 155;
			this.txtIvaRetenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label15.Location = new System.Drawing.Point(155, 0);
			this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(32, 51);
			this.label15.TabIndex = 6;
			this.label15.Text = "|";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel10.Controls.Add(this.label18);
			this.flowLayoutPanel10.Controls.Add(this.txtIsrRetenido);
			this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel10.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel10.TabIndex = 5;
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label18.Location = new System.Drawing.Point(2, 0);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(70, 13);
			this.label18.TabIndex = 0;
			this.label18.Text = "ISR RETENIDO";
			this.txtIsrRetenido.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIsrRetenido.Location = new System.Drawing.Point(2, 14);
			this.txtIsrRetenido.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIsrRetenido.Name = "txtIsrRetenido";
			this.txtIsrRetenido.ReadOnly = true;
			this.txtIsrRetenido.Size = new System.Drawing.Size(140, 35);
			this.txtIsrRetenido.TabIndex = 155;
			this.txtIsrRetenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl2.Location = new System.Drawing.Point(817, 37);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(192, 92);
			this.tabControl2.TabIndex = 138;
			this.tabPage4.Controls.Add(this.flowLayoutPanel4);
			this.tabPage4.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage4.Size = new System.Drawing.Size(184, 65);
			this.tabPage4.TabIndex = 0;
			this.tabPage4.Text = "DEDUCCIONES";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
			this.flowLayoutPanel4.Controls.Add(this.label5);
			this.flowLayoutPanel4.Location = new System.Drawing.Point(2, 5);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(345, 55);
			this.flowLayoutPanel4.TabIndex = 142;
			this.flowLayoutPanel5.Controls.Add(this.label4);
			this.flowLayoutPanel5.Controls.Add(this.txtDeduccionesPagadas);
			this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel5.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel5.TabIndex = 0;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(2, 0);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(50, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "PAGADAS";
			this.txtDeduccionesPagadas.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadas.Location = new System.Drawing.Point(2, 14);
			this.txtDeduccionesPagadas.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtDeduccionesPagadas.Name = "txtDeduccionesPagadas";
			this.txtDeduccionesPagadas.ReadOnly = true;
			this.txtDeduccionesPagadas.Size = new System.Drawing.Size(140, 35);
			this.txtDeduccionesPagadas.TabIndex = 155;
			this.txtDeduccionesPagadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(155, 0);
			this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 51);
			this.label5.TabIndex = 4;
			this.label5.Text = "|";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl1.Location = new System.Drawing.Point(424, 140);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(358, 92);
			this.tabControl1.TabIndex = 137;
			this.tabPage3.Controls.Add(this.flowLayoutPanel1);
			this.tabPage3.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage3.Location = new System.Drawing.Point(4, 23);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage3.Size = new System.Drawing.Size(350, 65);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "IVA";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel3);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 5);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(345, 55);
			this.flowLayoutPanel1.TabIndex = 142;
			this.flowLayoutPanel2.Controls.Add(this.label1);
			this.flowLayoutPanel2.Controls.Add(this.txtIvaCobrado);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel2.TabIndex = 0;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(2, 0);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(54, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "COBRADO";
			this.txtIvaCobrado.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaCobrado.Location = new System.Drawing.Point(2, 14);
			this.txtIvaCobrado.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIvaCobrado.Name = "txtIvaCobrado";
			this.txtIvaCobrado.ReadOnly = true;
			this.txtIvaCobrado.Size = new System.Drawing.Size(140, 35);
			this.txtIvaCobrado.TabIndex = 155;
			this.txtIvaCobrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(155, 0);
			this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 51);
			this.label2.TabIndex = 4;
			this.label2.Text = "|";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel3.Controls.Add(this.label3);
			this.flowLayoutPanel3.Controls.Add(this.txtIvaAcreditable);
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel3.TabIndex = 3;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(2, 0);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "ACREDITABLE";
			this.txtIvaAcreditable.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIvaAcreditable.Location = new System.Drawing.Point(2, 14);
			this.txtIvaAcreditable.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIvaAcreditable.Name = "txtIvaAcreditable";
			this.txtIvaAcreditable.ReadOnly = true;
			this.txtIvaAcreditable.Size = new System.Drawing.Size(140, 35);
			this.txtIvaAcreditable.TabIndex = 155;
			this.txtIvaAcreditable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(14, 63);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(70, 47);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.btnEnviarAExcel.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcel.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcel.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcel.Image = LeeXML.Properties.Resources.PDF_Sinfondo;
			this.btnEnviarAExcel.Location = new System.Drawing.Point(93, 63);
			this.btnEnviarAExcel.Name = "btnEnviarAExcel";
			this.btnEnviarAExcel.Size = new System.Drawing.Size(70, 47);
			this.btnEnviarAExcel.TabIndex = 133;
			this.btnEnviarAExcel.Text = "Exportar";
			this.btnEnviarAExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcel.UseVisualStyleBackColor = false;
			this.btnEnviarAExcel.Click += new System.EventHandler(btnEnviarAExcel_Click);
			this.pnlFiltroPeriodo.Controls.Add(this.rdoPorMesComprobantes);
			this.pnlFiltroPeriodo.Controls.Add(this.pnlPorMesVentas);
			this.pnlFiltroPeriodo.Location = new System.Drawing.Point(6, 3);
			this.pnlFiltroPeriodo.Name = "pnlFiltroPeriodo";
			this.pnlFiltroPeriodo.Size = new System.Drawing.Size(173, 57);
			this.pnlFiltroPeriodo.TabIndex = 135;
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoPorMesComprobantes.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(3, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(64, 17);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(3, 19);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(155, 34);
			this.pnlPorMesVentas.TabIndex = 41;
			this.cmbMesesComprobantes.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbMesesComprobantes.DisplayMember = "Descripcion";
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(5, 7);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(151, 24);
			this.cmbMesesComprobantes.TabIndex = 19;
			this.cmbMesesComprobantes.ValueMember = "Id";
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(424, 37);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(358, 92);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage2.Controls.Add(this.flpObjetoImpuesto);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage2.Size = new System.Drawing.Size(350, 65);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "INGRESOS";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel56);
			this.flpObjetoImpuesto.Controls.Add(this.label17);
			this.flpObjetoImpuesto.Controls.Add(this.flowLayoutPanel16);
			this.flpObjetoImpuesto.Location = new System.Drawing.Point(2, 5);
			this.flpObjetoImpuesto.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flpObjetoImpuesto.Name = "flpObjetoImpuesto";
			this.flpObjetoImpuesto.Size = new System.Drawing.Size(345, 55);
			this.flpObjetoImpuesto.TabIndex = 142;
			this.flowLayoutPanel56.Controls.Add(this.label14);
			this.flowLayoutPanel56.Controls.Add(this.txtIngresosFacturados);
			this.flowLayoutPanel56.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel56.Location = new System.Drawing.Point(2, 1);
			this.flowLayoutPanel56.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel56.Name = "flowLayoutPanel56";
			this.flowLayoutPanel56.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel56.TabIndex = 0;
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new System.Drawing.Point(2, 0);
			this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(68, 13);
			this.label14.TabIndex = 0;
			this.label14.Text = "FACTURADOS";
			this.txtIngresosFacturados.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosFacturados.Location = new System.Drawing.Point(2, 14);
			this.txtIngresosFacturados.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIngresosFacturados.Name = "txtIngresosFacturados";
			this.txtIngresosFacturados.ReadOnly = true;
			this.txtIngresosFacturados.Size = new System.Drawing.Size(140, 35);
			this.txtIngresosFacturados.TabIndex = 155;
			this.txtIngresosFacturados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 30f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new System.Drawing.Point(155, 0);
			this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(32, 51);
			this.label17.TabIndex = 4;
			this.label17.Text = "|";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.flowLayoutPanel16.Controls.Add(this.label16);
			this.flowLayoutPanel16.Controls.Add(this.txtIngresosCobrados);
			this.flowLayoutPanel16.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel16.Location = new System.Drawing.Point(190, 1);
			this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.flowLayoutPanel16.Name = "flowLayoutPanel16";
			this.flowLayoutPanel16.Size = new System.Drawing.Size(150, 53);
			this.flowLayoutPanel16.TabIndex = 3;
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new System.Drawing.Point(2, 0);
			this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(59, 13);
			this.label16.TabIndex = 0;
			this.label16.Text = "COBRADOS";
			this.txtIngresosCobrados.Font = new System.Drawing.Font("Microsoft Tai Le", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobrados.Location = new System.Drawing.Point(2, 14);
			this.txtIngresosCobrados.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtIngresosCobrados.Name = "txtIngresosCobrados";
			this.txtIngresosCobrados.ReadOnly = true;
			this.txtIngresosCobrados.Size = new System.Drawing.Size(140, 35);
			this.txtIngresosCobrados.TabIndex = 155;
			this.txtIngresosCobrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
			this.pnlFiltro.Location = new System.Drawing.Point(341, -1);
			this.pnlFiltro.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(672, 34);
			this.pnlFiltro.TabIndex = 0;
			this.pnlFiltro.Visible = false;
			this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(6, 10);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(30, 13);
			this.label10.TabIndex = 137;
			this.label10.Text = "R.F.C:";
			this.txtRFCFiltro.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtRFCFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFCFiltro.Location = new System.Drawing.Point(41, 5);
			this.txtRFCFiltro.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtRFCFiltro.Name = "txtRFCFiltro";
			this.txtRFCFiltro.Size = new System.Drawing.Size(88, 21);
			this.txtRFCFiltro.TabIndex = 0;
			this.txtRFCFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(139, 10);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(38, 13);
			this.label11.TabIndex = 135;
			this.label11.Text = "Cliente:";
			this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtCliente.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtCliente.Location = new System.Drawing.Point(182, 5);
			this.txtCliente.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(137, 21);
			this.txtCliente.TabIndex = 1;
			this.txtCliente.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(324, 9);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(33, 13);
			this.label12.TabIndex = 133;
			this.label12.Text = "UUID:";
			this.txtUUIDfiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtUUIDfiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtUUIDfiltro.Location = new System.Drawing.Point(357, 5);
			this.txtUUIDfiltro.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtUUIDfiltro.Name = "txtUUIDfiltro";
			this.txtUUIDfiltro.Size = new System.Drawing.Size(145, 21);
			this.txtUUIDfiltro.TabIndex = 2;
			this.txtUUIDfiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(628, 1);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(39, 27);
			this.btnFiltraFacturas.TabIndex = 4;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(510, 9);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(30, 13);
			this.label13.TabIndex = 97;
			this.label13.Text = "Folio:";
			this.txtFacturaFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtFacturaFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFacturaFiltro.Location = new System.Drawing.Point(543, 5);
			this.txtFacturaFiltro.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(76, 21);
			this.txtFacturaFiltro.TabIndex = 3;
			this.txtFacturaFiltro.Visible = false;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(10, 19);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1029, 881);
			this.tcPedidosGrids.TabIndex = 129;
			this.flpEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flpEmpresas.Controls.Add(this.label24);
			this.flpEmpresas.Controls.Add(this.cmbEmpresas);
			this.flpEmpresas.Controls.Add(this.btnBuscaEmpresa);
			this.flpEmpresas.Location = new System.Drawing.Point(280, 6);
			this.flpEmpresas.Name = "flpEmpresas";
			this.flpEmpresas.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpEmpresas.Size = new System.Drawing.Size(555, 33);
			this.flpEmpresas.TabIndex = 138;
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(498, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(35, 25);
			this.btnBuscaEmpresa.TabIndex = 139;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.btnBuscaEmpresa.Click += new System.EventHandler(btnBuscaEmpresa_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1037, 690);
			base.Controls.Add(this.flpEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Name = "IndicadoresFiscales";
			this.Text = "Indicadores Fiscales";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tabPage1.ResumeLayout(false);
			this.tabControl6.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.flowLayoutPanel23.ResumeLayout(false);
			this.flowLayoutPanel24.ResumeLayout(false);
			this.flowLayoutPanel24.PerformLayout();
			this.flowLayoutPanel25.ResumeLayout(false);
			this.flowLayoutPanel25.PerformLayout();
			this.flowLayoutPanel18.ResumeLayout(false);
			this.flowLayoutPanel19.ResumeLayout(false);
			this.flowLayoutPanel19.PerformLayout();
			this.flowLayoutPanel20.ResumeLayout(false);
			this.flowLayoutPanel20.PerformLayout();
			this.flowLayoutPanel21.ResumeLayout(false);
			this.flowLayoutPanel21.PerformLayout();
			this.flowLayoutPanel22.ResumeLayout(false);
			this.flowLayoutPanel22.PerformLayout();
			this.tabControl5.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.flowLayoutPanel13.ResumeLayout(false);
			this.flowLayoutPanel14.ResumeLayout(false);
			this.flowLayoutPanel14.PerformLayout();
			this.flowLayoutPanel15.ResumeLayout(false);
			this.flowLayoutPanel15.PerformLayout();
			this.flowLayoutPanel17.ResumeLayout(false);
			this.flowLayoutPanel17.PerformLayout();
			this.flowLayoutPanel8.ResumeLayout(false);
			this.flowLayoutPanel8.PerformLayout();
			this.tabControl4.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel11.ResumeLayout(false);
			this.flowLayoutPanel11.PerformLayout();
			this.flowLayoutPanel12.ResumeLayout(false);
			this.flowLayoutPanel12.PerformLayout();
			this.tabControl3.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.flowLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.flowLayoutPanel10.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowLayoutPanel5.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.pnlFiltroPeriodo.ResumeLayout(false);
			this.pnlFiltroPeriodo.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.flpObjetoImpuesto.ResumeLayout(false);
			this.flowLayoutPanel56.ResumeLayout(false);
			this.flowLayoutPanel56.PerformLayout();
			this.flowLayoutPanel16.ResumeLayout(false);
			this.flowLayoutPanel16.PerformLayout();
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.flpEmpresas.ResumeLayout(false);
			this.flpEmpresas.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
