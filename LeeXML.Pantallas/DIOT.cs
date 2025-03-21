using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class DIOT : FormBase
	{
		private enum TipoTercero
		{
			PROVEEDOR_NACIONAL = 4,
			PROVEEDOR_EXTRANJERO = 5,
			PROVEEDOR_GLOBAL = 15
		}

		private enum TipoDeOperacion
		{
			ENAJENACION_DE_BIENES = 2,
			PRESTACION_DE_SERVICIOS_PROFESIONALES = 3,
			USO_O_GOCE_TEMPORAL_DE_BIENES = 6,
			IMPORTACION_POR_TRANSFERENCIA_VIRTUAL = 8,
			OTROS = 85,
			IMPORTACION_DE_BIENES_O_SERVICIOS = 7,
			OPERACIONES_GLOBALES = 87
		}

		private enum TipoDeOperacionExtranjero
		{
			ENAJENACION_DE_BIENES = 2,
			PRESTACION_DE_SERVICIOS_PROFESIONALES = 3,
			IMPORTACION_DE_BIENES_O_SERVICIOS = 7
		}

		private enum TipoDeOperacionGlobal
		{
			OPERACIONES_GLOBALES = 87
		}

		private enum EfectosFiscales
		{
			SI = 1,
			NO
		}

		private IContainer components = null;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private Label label3;

		private TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

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

		private BindingSource EntEstadoDeCuentaBindingSource;

		private Panel pnlFiltro;

		private Label label8;

		private TextBox txtRFCFiltro;

		private Label label6;

		private TextBox txtCliente;

		private Button btnFiltraFacturas;

		private Button btnRevisarAnticiposDepositosPrevios;

		private Button btnMarcarVigente;

		private Button btnMarcarCancelada;

		private DataGridViewTextBoxColumn EstatusDescripcion;

		private DataGridViewTextBoxColumn Descripcion;

		private DataGridViewTextBoxColumn UUIDrelacionado;

		private DataGridViewTextBoxColumn FormaPago;

		private DataGridViewTextBoxColumn MetodoPago;

		private new DataGridViewTextBoxColumn TipoComprobante;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn TipoCambio;

		private DataGridViewTextBoxColumn Moneda;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn retencionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn uUIDDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;

		private ToolStrip miniToolStrip;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNum;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotal;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstxtIVA;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImporte;

		private TabControl tcReportesIngresos;

		private TabPage tabPage2;

		private FlowLayoutPanel flpTotalesTodos;

		private ToolStrip toolStrip1;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tsNumContribuyentes;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox toolStripTextBox2;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox toolStripTextBox3;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox toolStripTextBox4;

		private DataGridView gvXMLs;

		private FlowLayoutPanel flowLayoutPanel1;

		private Button button1;

		private Button btnGuardaDIOT;

		private TabPage tabPage6;

		private FlowLayoutPanel flowLayoutPanel7;

		private ToolStrip toolStrip6;

		private ToolStripLabel toolStripLabel37;

		private ToolStripTextBox tstNumCancelados;

		private ToolStripSeparator toolStripSeparator21;

		private ToolStripLabel toolStripLabel38;

		private ToolStripTextBox tstSubCancelados;

		private ToolStripSeparator toolStripSeparator22;

		private ToolStripLabel toolStripLabel39;

		private ToolStripTextBox tstIvaCancelados;

		private ToolStripSeparator toolStripSeparator23;

		private ToolStripLabel toolStripLabel40;

		private ToolStripTextBox tstImporteCancelados;

		private DataGridView gvCancelados;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn85;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn86;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn87;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn88;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn89;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn90;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn91;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn92;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn93;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn94;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn95;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn96;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn97;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn98;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn99;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn100;

		private FlowLayoutPanel flowLayoutPanel13;

		private Button btnEnviarAExcelCanceladas;

		private Button btnImportaXMLs;

		private ComboBox cmbPeriodos;

		private RadioButton radioButton1;

		private DataGridViewTextBoxColumn TipoComprobanteId;

		private DataGridViewTextBoxColumn TipoImpuestoId;

		private Button btnExportarDetallesCFDIsRecibidos;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private Button btnAgregaProveedor;

		private Label label1;

		private DataGridViewImageColumn dataGridViewImageColumn1;

		private DataGridViewImageColumn dataGridViewImageColumn2;

		private Label label2;

		private DataGridViewImageColumn gvColumnEliminar;

		private DataGridViewTextBoxColumn gvColumnTipoTercero;

		private DataGridViewTextBoxColumn gvColumnTipoOperacion;

		private DataGridViewTextBoxColumn gvColumnRFC;

		private DataGridViewTextBoxColumn gvColumnIDFISCAL;

		private DataGridViewTextBoxColumn gvColumnNOMBREEXTRANJERO;

		private DataGridViewTextBoxColumn gvColumnPAIS;

		private DataGridViewTextBoxColumn gvColumnLUGARJURIDICCION;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn Depositado;

		private DataGridViewCheckBoxColumn gvColumnRFnorte;

		private DataGridViewCheckBoxColumn gvColumnRFsur;

		private DataGridViewTextBoxColumn gvColumnBase16;

		private DataGridViewTextBoxColumn gvColumnDevBon16;

		private DataGridViewTextBoxColumn gvColumnImportaciones16;

		private DataGridViewTextBoxColumn gvColumnDevBonImp16;

		private DataGridViewTextBoxColumn gvColumnImportIntan16;

		private DataGridViewTextBoxColumn gvColumnDevBonImpInt16;

		private DataGridViewTextBoxColumn gvColumnIvaRetenido;

		private DataGridViewTextBoxColumn Deduccion;

		private DataGridViewTextBoxColumn SubTotal0;

		private DataGridViewTextBoxColumn gvColumnEfectosFiscales;

		private new DataGridViewTextBoxColumn IVA;

		private new DataGridViewTextBoxColumn IEPS;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn TotalDeducciones;

		private DataGridViewImageColumn VerDetalleCFDIs;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;

		private FlowLayoutPanel flowLayoutPanel14;

		private DataGridView gvTotalesDIOT;

		private DataGridViewTextBoxColumn dataGridViewImageColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn11;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn12;

		private DataGridViewTextBoxColumn dataGridViewCheckBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewCheckBoxColumn2;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn13;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn14;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn15;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn16;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn17;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn19;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn20;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn21;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn22;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn24;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn25;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn26;

		private DataGridViewButtonColumn dataGridViewTextBoxColumn27;

		private DataGridViewButtonColumn dataGridViewImageColumn4;

		private DataGridViewTextBoxColumn gvTotalesColumnEstatus;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantesEgresos { get; set; }

		private List<EntFactura> ListaDIOT { get; set; }

		private List<EntFactura> ListaDIOTdetalle { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public DIOT()
		{
			InitializeComponent();
			base.Size = new Size(500, 500);
		}

		private int RevisaCPencontrados(List<EntFactura> ListaComplementosPago)
		{
			int cont = 0;
			foreach (EntFactura cp in ListaComplementosPago)
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

		public int RevisaAnticipoComprobantesEgresos(List<EntFactura> ListaComprobantesFiscales)
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
			List<EntFactura> lstEgresosAnticipo = ListaComprobantesFiscales.Where((EntFactura P) => P.TipoComprobanteId == 2 && P.TipoRelacionId == 7 && P.EstatusId != 5).ToList();
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

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, DataGridView GridViewMuestra, TextBox TxtMuestraImporte, TextBox TxtMuestraSubtotal, TextBox TxtMuestraIVA, TextBox TxtMuestraNum)
		{
			GridViewMuestra.DataSource = ListaComprobantes.Where((EntFactura P) => P.EmisorRFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			GridViewMuestra.Refresh();
			CalculaSumaTotalFromListaProductos(ListaComprobantes, false, TxtMuestraImporte, TxtMuestraSubtotal, TxtMuestraIVA, TxtMuestraNum, TxtMuestraNum);
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñoComprobantes);
			cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
			cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
			CargaPeriodosCmb(cmbPeriodos, 1);
			SeleccionaPeriodoActual(cmbPeriodos, 1, new Label());
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
				CargaDatosEmpresa(txtNombreFiscal, txtRFC);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CargaComprobantesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantesEgresos = new BusFacturas().ObtieneComprobantesFiscalesEgresosObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantesEgresos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoObjetoImpuesto(Empresa, FechaDesde, FechaHasta, 1));
		}

		private void CalculaTotales(List<EntFactura> ListaDIOT)
		{
			List<EntFactura> totalesDIOT = new List<EntFactura>
			{
				new EntFactura
				{
					Descuento = ListaDIOT.Sum((EntFactura P) => P.Descuento),
					ISRRetenciones = ListaDIOT.Sum((EntFactura P) => P.ISRRetenciones),
					SubTotal = ListaDIOT.Sum((EntFactura P) => P.SubTotal),
					TipoCambio = ListaDIOT.Sum((EntFactura P) => P.TipoCambio),
					TotalUSD = ListaDIOT.Sum((EntFactura P) => P.TotalUSD),
					EquivalenciaDR = ListaDIOT.Sum((EntFactura P) => P.EquivalenciaDR),
					ImporteDR = ListaDIOT.Sum((EntFactura P) => P.ImporteDR),
					ImpuestosLocales = ListaDIOT.Sum((EntFactura P) => P.ImpuestosLocales),
					IVARetenciones = ListaDIOT.Sum((EntFactura P) => P.IVARetenciones),
					Deduccion = ListaDIOT.Sum((EntFactura P) => P.Deduccion),
					SubTotal0 = ListaDIOT.Sum((EntFactura P) => P.SubTotal0),
					IVA = ListaDIOT.Sum((EntFactura P) => P.IVA),
					TotalPercepciones = ListaDIOT.Sum((EntFactura P) => P.TotalPercepciones),
					IEPS = ListaDIOT.Sum((EntFactura P) => P.IEPS),
					TotalDeducciones = ListaDIOT.Sum((EntFactura P) => P.TotalDeducciones)
				}
			};
			gvTotalesDIOT.DataSource = totalesDIOT;
			tsNumContribuyentes.Text = ListaDIOT.Count.ToString();
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				if (rdoPorMesComprobantes.Checked)
				{
					fechaDesde = FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
					fechaHasta = FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
				}
				CargaComprobantesEgresos(Program.EmpresaSeleccionada, fechaDesde, fechaHasta);
				SetWaitCursor();
				ListaDIOTdetalle = ListaComprobantesEgresos.Where((EntFactura P) => P.Deducible && ((P.MetodoPagoId == 1 && P.TipoComprobanteId == 1) || (P.TipoComprobanteId == 5 && P.FechaPago >= fechaDesde && P.FechaPago <= fechaHasta) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo))).ToList();
				ListaDIOTdetalle = ListaDIOTdetalle.Where((EntFactura p) => p.ObjetoImpuesto02 > 0m || p.ObjetoImpuesto02 < 0m).ToList();
				List<EntFactura> listaComprobantesDA = new BusFacturas().ObtieneComprobantesFiscalesEgresosDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesDA.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivoDatosAdicionalesTraslado(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				foreach (EntFactura f in ListaDIOTdetalle)
				{
					f.SubTotal = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.16m).Sum((EntFactura P) => P.Total);
					f.Descuento = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0.08m).Sum((EntFactura P) => P.Total);
					f.SubTotal0 = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 1).Sum((EntFactura P) => P.Total);
					f.Deduccion = listaComprobantesDA.Where((EntFactura P) => P.Id == f.Id && P.TasaOCuota == 0m && P.TipoFactorId == 3).Sum((EntFactura P) => P.Total);
					if (f.TipoComprobanteId == 2 && f.TipoEstructuraImpuestoId == 0)
					{
						f.SubTotal *= -1m;
						f.Descuento *= -1m;
						f.SubTotal0 *= -1m;
						f.Deduccion *= -1m;
						f.IVARetenciones *= -1m;
						f.ISRRetenciones *= -1m;
						f.Total *= -1m;
						f.ObjetoImpuesto02 *= -1m;
						f.TipoEstructuraImpuestoId = 1;
					}
				}
				List<EntFactura> lstExento = ListaDIOTdetalle.Where((EntFactura a) => !listaComprobantesDA.Any((EntFactura b) => b.Id == a.Id)).ToList();
				foreach (EntFactura ex in lstExento.Where((EntFactura p) => p.ObjetoImpuesto02 > 0m).ToList())
				{
					ListaDIOTdetalle.Where((EntFactura P) => P.Id == ex.Id).First().Deduccion = ex.ObjetoImpuesto02;
					ex.Id = ex.Id;
					ex.TipoEstructuraImpuestoId = 1;
					ex.ObjetoImpuestoId = 2;
					ex.TasaOCuota = 0m;
					ex.TipoImpuestoId = 2;
					ex.TipoFactorId = 3;
					ex.ImporteDR = 0m;
					new BusFacturas().AgregaComprobantesFiscalesEgresosDatosAdicionales(ex);
				}
				List<EntFactura> agrupadoPorRFC = (from d in ListaDIOTdetalle
					group d by new { d.RFC, d.Nombre } into g
					select new EntFactura
					{
						EmisorRFC = g.Key.RFC,
						EmisorNombre = g.Key.Nombre,
						SubTotal = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId != 2).Sum((EntFactura d) => d.SubTotal)),
						TipoCambio = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId == 2).Sum((EntFactura d) => d.SubTotal)),
						Descuento = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId != 2).Sum((EntFactura d) => d.Descuento)),
						ISRRetenciones = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId == 2).Sum((EntFactura d) => d.Descuento)),
						IVARetenciones = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId != 2).Sum((EntFactura d) => d.IVARetenciones)),
						Deduccion = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId != 2).Sum((EntFactura d) => d.Deduccion)),
						SubTotal0 = Math.Round(g.Where((EntFactura d) => d.TipoComprobanteId != 2).Sum((EntFactura d) => d.SubTotal0))
					}).ToList();
				foreach (EntFactura f2 in agrupadoPorRFC)
				{
					new BusProveedores().ObtieneProveedor(f2.ClienteId);
					f2.TipoComprobanteId = 4;
					f2.TipoImpuestoId = 85;
					f2.OrdenId = 1;
					f2.IVA = Math.Round((f2.SubTotal + f2.TotalUSD + f2.ImporteDR) * 0.16m);
					f2.TotalPercepciones = Math.Round((f2.TipoCambio + f2.EquivalenciaDR + f2.ImpuestosLocales) * 0.16m);
					f2.IEPS = Math.Round(f2.Descuento * 0.08m);
					f2.TotalDeducciones = Math.Round(f2.ISRRetenciones * 0.08m);
					f2.NumeroFactura = "";
					f2.UUID = "";
					f2.Moneda = "";
					f2.ClaveEntFed = "";
				}
				ListaDIOT = agrupadoPorRFC;
				gvXMLs.DataSource = ListaDIOT;
				gvXMLs.Refresh();
				CalculaTotales(ListaDIOT);
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

		private void btnMarcarCancelada_Click(object sender, EventArgs e)
		{
			try
			{
				if (MuestraMensajeYesNo("¿Desea marcar como Cancelado(s) el(los) Comprobante(s) Fiscal(es) seleccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvXMLs);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					new BusFacturas().ActualizaEstatusComprobanteFiscalEgresos(f.Id, 2);
				}
				MuestraMensaje("¡Comprobante(s) marcado(s) como CANCELADO!");
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnMarcarVigente_Click(object sender, EventArgs e)
		{
			try
			{
				if (MuestraMensajeYesNo("¿Desea marcar como Vigente(s) el(los) Comprobante(s) Fiscal(es) seleccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvXMLs);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					new BusFacturas().ActualizaEstatusComprobanteFiscalEgresos(f.Id, 1);
				}
				MuestraMensaje("¡Comprobante(s) marcado(s) como VIGENTE!");
				btnRefrescar.PerformClick();
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
					gvXMLs.DataSource = new List<EntFactura>();
					gvXMLs.Refresh();
					gvCancelados.DataSource = new List<EntFactura>();
					gvCancelados.Refresh();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnRevisarAnticiposDepositosPrevios_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				int cantCPencontrados = RevisaCPencontrados(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.EstatusId == 1).ToList());
				int cantDepEnFactura = RevisaDepositoEnFacturaPPD(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.EstatusId == 1).ToList());
				int cantFacturasConAntPago = RevisaAnticipoPagadoEnComprobantes(ListaComprobantes);
				int cantFacturasConAnt = RevisaAnticipoComprobantesEgresos(new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), 1));
				int cantEgresosRelacionados = RevisaEgresosComprobantes(new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), 1));
				MuestraMensaje($"SE ENCONTRARON: \n\n {cantCPencontrados} PAGOS AGREGADOS A FACTURA PPD\n {cantDepEnFactura} COMPLEMENTOS DE PAGO CON DEPÓSITOS ANTERIORES A FACTURA PPD\n {cantFacturasConAnt} COMPROBANTES FISCALES INGRESO CON ANTICIPOS RELACIONADOS\n {cantEgresosRelacionados} COMPROBANTES FISCALES EGRESO RELACIONADOS A FACTURA");
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
				FiltraComprobantes(ListaComprobantes.Where((EntFactura P) => P.EstatusId == 2).ToList(), gvCancelados, tstImporteCancelados.TextBox, tstSubCancelados.TextBox, tstIvaCancelados.TextBox, tstNumCancelados.TextBox);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoPorMesComprobantes_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				pnlPorMesVentas.Enabled = rdoPorMesComprobantes.Checked;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void lbTotalIva8nc_Click(object sender, EventArgs e)
		{
		}

		private void gvXMLs_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			try
			{
				MuestraMensajeError(e.Exception.Message, e.Context.ToString());
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private List<string> GenerarTXT(List<EntFactura> ListaDIOT)
		{
			string rutaCarpeta = SeleccionaCarpeta();
			string nombreArchivo = "DIOT-" + txtRFC.Text + "-" + cmbPeriodos.Text + ".txt";
			string rutaCompleta = rutaCarpeta + "\\" + nombreArchivo;
			using (StreamWriter file = new StreamWriter(rutaCompleta))
			{
				DateTime dateTime = default(DateTime);
				dateTime = DateTime.Now;
				int contPer = ListaDIOT.Count;
				int cont = 0;
				foreach (EntFactura p in ListaDIOT)
				{
					cont++;
					string renglon = p.TipoComprobanteId.ToString().PadLeft(2, '0') + "|" + p.TipoImpuestoId.ToString().PadLeft(2, '0') + "|" + p.EmisorRFC.Trim() + "|" + p.NumeroFactura.Trim() + "|" + p.UUID.Trim() + "|" + p.Moneda.Trim() + "|" + p.ClaveEntFed.Trim() + "|";
					renglon = (p.Deducible ? (renglon + p.Descuento.ToString("F0") + "|" + p.ISRRetenciones.ToString("F0") + "|||") : ((!p.ExcluyeFlujo) ? (renglon + "||||") : (renglon + "||" + p.Descuento.ToString("F0") + "|" + p.ISRRetenciones.ToString("F0") + "|")));
					renglon = renglon + p.SubTotal.ToString("F0") + "|" + p.TipoCambio.ToString("F0") + "|" + p.TotalUSD.ToString("F0") + "|" + p.EquivalenciaDR.ToString("F0") + "|" + p.ImporteDR.ToString("F0") + "|" + p.ImpuestosLocales.ToString("F0") + "|";
					renglon += new string('|', 30);
					renglon = renglon + p.IVARetenciones.ToString("F0") + "||" + p.Deduccion.ToString("F0") + "|" + p.SubTotal0.ToString("F0") + "|||" + p.OrdenId.ToString().PadLeft(2, '0');
					if (contPer == cont)
					{
						file.Write(renglon);
					}
					else
					{
						file.WriteLine(renglon);
					}
				}
				file.Dispose();
			}
			List<string> res = new List<string>();
			res.Add(nombreArchivo);
			res.Add(rutaCarpeta);
			return res;
		}

		private void btnImportaXMLs_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> res = GenerarTXT(ListaDIOT);
				if (MuestraMensajeYesNo("¡Archivo TXT creado con éxito! \n\n Nombre Archivo: " + res[0] + "\n Ruta: " + res[1] + "\n\n ¿Desea Mostrar el Archivo?") == DialogResult.Yes)
				{
					MuestraArchivo(res[1], res[0]);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbMesesComprobantes_SelectedIndexChanged(object sender, EventArgs e)
		{
			SeleccionaPeriodoActual(cmbPeriodos, 1, cmbMesesComprobantes.SelectedIndex + 1, ConvierteTextoAInteger(cmbAñoComprobantes.Text));
		}

		private void cmbPeriodos_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void btnExportarDetallesCFDIsRecibidos_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				ImprimeCFDIsFlujoEgresosSinTotales vImprime = new ImprimeCFDIsFlujoEgresosSinTotales(ListaDIOTdetalle, true);
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

		private void btnAgregaProveedor_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntFactura> lst = ObtieneListaFacturasFromGV(gvXMLs);
				lst.Add(new EntFactura
				{
					TipoComprobanteId = 4,
					TipoImpuestoId = 85,
					OrdenId = 1,
					EmisorRFC = "",
					RFC = lst.Last().RFC,
					NumeroFactura = "",
					UUID = "",
					Moneda = "",
					ClaveEntFed = ""
				});
				gvXMLs.DataSource = null;
				gvXMLs.DataSource = lst;
				gvXMLs.Refresh();
				gvXMLs.CurrentCell = gvXMLs.Rows[lst.Count - 1].Cells[gvColumnRFC.Index];
				gvXMLs.BeginEdit(true);
				CalculaTotales(lst);
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

		private void VerificaProveedor(List<EntFactura> ListaDIOT)
		{
			bool rfcIncorrectosEncontrados = false;
		}

		private void gvXMLs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
		{
		}

		private void gvXMLs_KeyDown(object sender, KeyEventArgs e)
		{
		}

		private void gvXMLs_SizeChanged(object sender, EventArgs e)
		{
		}

		private void gvXMLs_Scroll(object sender, ScrollEventArgs e)
		{
		}

		private void tb_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void gvXMLs_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			try
			{
				int columnIndex = gvXMLs.CurrentCell.ColumnIndex;
				if (columnIndex == gvColumnTipoTercero.Index || columnIndex == gvColumnTipoOperacion.Index || columnIndex == gvColumnEfectosFiscales.Index)
				{
					if (e.Control is TextBox tb)
					{
						tb.KeyPress -= tb_KeyPress;
						tb.KeyPress += tb_KeyPress;
					}
				}
				else if (e.Control is TextBox tb2)
				{
					tb2.KeyPress -= tb_KeyPress;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvXMLs_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
		{
			if (e.ColumnIndex != gvColumnRFC.Index)
			{
				return;
			}
			DataGridView gv = (DataGridView)sender;
			EntFactura diotSeleccionada = ObtieneFacturaFromGV(gv, e.RowIndex);
			string cellValue = e.FormattedValue.ToString();
			if (diotSeleccionada.TipoComprobanteId != 5)
			{
				if (string.IsNullOrWhiteSpace(cellValue))
				{
					e.Cancel = true;
					gv.Rows[e.RowIndex].ErrorText = "El valor RFC no puede estar en blanco.";
					MuestraMensajeError("El valor RFC no puede estar en blanco.", "CAMPO RFC OBLIGATORIO");
				}
				else if (cellValue.Length < 12)
				{
					e.Cancel = true;
					gv.Rows[e.RowIndex].ErrorText = "El valor RFC no puede ser menor a 12 caracteres.";
					MuestraMensajeError("El valor RFC no puede ser menor a 12 caracteres.", "ERROR EN FORMATO RFC");
				}
				else if (cellValue.Length > 13)
				{
					e.Cancel = true;
					gv.Rows[e.RowIndex].ErrorText = "El valor RFC no puede ser mayor a 13 caracteres.";
					MuestraMensajeError("El valor RFC no puede ser mayor a 13 caracteres.", "ERROR EN FORMATO RFC");
				}
				else
				{
					gv.Rows[e.RowIndex].ErrorText = string.Empty;
				}
			}
		}

		private void gvXMLs_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex <= -1)
				{
					return;
				}
				EntFactura diotSeleccionada = ObtieneFacturaFromGV(gvXMLs);
				List<EntCatalogoGenerico> catalogoGenerico = new List<EntCatalogoGenerico>();
				if (e.ColumnIndex == gvColumnTipoTercero.Index)
				{
					foreach (TipoTercero tipo in Enum.GetValues(typeof(TipoTercero)))
					{
						EntCatalogoGenerico entCatalogoGenerico = new EntCatalogoGenerico();
						int num = (int)tipo;
						entCatalogoGenerico.Descripcion = num.ToString().PadLeft(2, '0') + " - " + tipo;
						entCatalogoGenerico.Id = (int)tipo;
						catalogoGenerico.Add(entCatalogoGenerico);
					}
					if (!catalogoGenerico.Any((EntCatalogoGenerico P) => P.Id == diotSeleccionada.TipoComprobanteId))
					{
						SeleccionaCatalogo vSelCat = new SeleccionaCatalogo(catalogoGenerico);
						if (vSelCat.ShowDialog() == DialogResult.OK)
						{
							diotSeleccionada.TipoComprobanteId = vSelCat.CatalogoSeleccionado.Id;
							switch ((TipoTercero)diotSeleccionada.TipoComprobanteId)
							{
							case TipoTercero.PROVEEDOR_NACIONAL:
								diotSeleccionada.TipoImpuestoId = 85;
								break;
							case TipoTercero.PROVEEDOR_EXTRANJERO:
								diotSeleccionada.TipoImpuestoId = 7;
								break;
							case TipoTercero.PROVEEDOR_GLOBAL:
								diotSeleccionada.TipoImpuestoId = 87;
								break;
							}
						}
						else
						{
							diotSeleccionada.TipoComprobanteId = 4;
							diotSeleccionada.TipoImpuestoId = 85;
						}
					}
				}
				else if (e.ColumnIndex == gvColumnTipoOperacion.Index)
				{
					switch ((TipoTercero)diotSeleccionada.TipoComprobanteId)
					{
					case TipoTercero.PROVEEDOR_NACIONAL:
						foreach (TipoDeOperacion tipo4 in Enum.GetValues(typeof(TipoDeOperacion)))
						{
							EntCatalogoGenerico entCatalogoGenerico4 = new EntCatalogoGenerico();
							int num = (int)tipo4;
							entCatalogoGenerico4.Descripcion = num.ToString().PadLeft(2, '0') + " - " + tipo4;
							entCatalogoGenerico4.Id = (int)tipo4;
							catalogoGenerico.Add(entCatalogoGenerico4);
						}
						break;
					case TipoTercero.PROVEEDOR_EXTRANJERO:
						foreach (TipoDeOperacionExtranjero tipo3 in Enum.GetValues(typeof(TipoDeOperacionExtranjero)))
						{
							EntCatalogoGenerico entCatalogoGenerico3 = new EntCatalogoGenerico();
							int num = (int)tipo3;
							entCatalogoGenerico3.Descripcion = num.ToString().PadLeft(2, '0') + " - " + tipo3;
							entCatalogoGenerico3.Id = (int)tipo3;
							catalogoGenerico.Add(entCatalogoGenerico3);
						}
						break;
					case TipoTercero.PROVEEDOR_GLOBAL:
						foreach (TipoDeOperacionGlobal tipo2 in Enum.GetValues(typeof(TipoDeOperacionGlobal)))
						{
							EntCatalogoGenerico entCatalogoGenerico2 = new EntCatalogoGenerico();
							int num = (int)tipo2;
							entCatalogoGenerico2.Descripcion = num.ToString().PadLeft(2, '0') + " - " + tipo2;
							entCatalogoGenerico2.Id = (int)tipo2;
							catalogoGenerico.Add(entCatalogoGenerico2);
						}
						break;
					}
					if (!catalogoGenerico.Any((EntCatalogoGenerico P) => P.Id == diotSeleccionada.TipoImpuestoId))
					{
						SeleccionaCatalogo vSelCat2 = new SeleccionaCatalogo(catalogoGenerico);
						if (vSelCat2.ShowDialog() == DialogResult.OK)
						{
							diotSeleccionada.TipoImpuestoId = vSelCat2.CatalogoSeleccionado.Id;
						}
						else
						{
							switch ((TipoTercero)diotSeleccionada.TipoComprobanteId)
							{
							case TipoTercero.PROVEEDOR_NACIONAL:
								diotSeleccionada.TipoImpuestoId = 85;
								break;
							case TipoTercero.PROVEEDOR_EXTRANJERO:
								diotSeleccionada.TipoImpuestoId = 7;
								break;
							case TipoTercero.PROVEEDOR_GLOBAL:
								diotSeleccionada.TipoImpuestoId = 87;
								break;
							}
						}
					}
				}
				else if (e.ColumnIndex == gvColumnEfectosFiscales.Index)
				{
					foreach (EfectosFiscales tipo5 in Enum.GetValues(typeof(EfectosFiscales)))
					{
						EntCatalogoGenerico entCatalogoGenerico5 = new EntCatalogoGenerico();
						int num = (int)tipo5;
						entCatalogoGenerico5.Descripcion = num.ToString().PadLeft(2, '0') + " - " + tipo5;
						entCatalogoGenerico5.Id = (int)tipo5;
						catalogoGenerico.Add(entCatalogoGenerico5);
					}
					if (!catalogoGenerico.Any((EntCatalogoGenerico P) => P.Id == diotSeleccionada.OrdenId))
					{
						SeleccionaCatalogo vSelCat3 = new SeleccionaCatalogo(catalogoGenerico);
						if (vSelCat3.ShowDialog() == DialogResult.OK)
						{
							diotSeleccionada.OrdenId = vSelCat3.CatalogoSeleccionado.Id;
						}
						else
						{
							diotSeleccionada.OrdenId = 1;
						}
					}
				}
				diotSeleccionada.IVA = Math.Round((diotSeleccionada.SubTotal + diotSeleccionada.TotalUSD + diotSeleccionada.ImporteDR) * 0.16m);
				diotSeleccionada.TotalPercepciones = Math.Round((diotSeleccionada.TipoCambio + diotSeleccionada.EquivalenciaDR + diotSeleccionada.ImpuestosLocales) * 0.16m);
				diotSeleccionada.IEPS = Math.Round(diotSeleccionada.Descuento * 0.08m);
				diotSeleccionada.TotalDeducciones = Math.Round(diotSeleccionada.ISRRetenciones * 0.08m);
				CalculaTotales(ObtieneListaFacturasFromGV(gvXMLs));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				gvXMLs.Refresh();
			}
		}

		private void gvXMLs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			try
			{
				int[] columnasEditar = new int[4] { gvColumnPAIS.Index, gvColumnIDFISCAL.Index, gvColumnNOMBREEXTRANJERO.Index, gvColumnLUGARJURIDICCION.Index };
				int[] columnasNoEditar = new int[4] { IVA.Index, IEPS.Index, TotalDeducciones.Index, dataGridViewTextBoxColumn2.Index };
				if (!columnasEditar.Contains(e.ColumnIndex) && columnasNoEditar.Contains(e.ColumnIndex))
				{
					e.CellStyle.BackColor = Color.LightGray;
					e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvXMLs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			try
			{
				int[] columnasEditar = new int[4] { gvColumnPAIS.Index, gvColumnIDFISCAL.Index, gvColumnNOMBREEXTRANJERO.Index, gvColumnLUGARJURIDICCION.Index };
				if (columnasEditar.Contains(e.ColumnIndex))
				{
					EntFactura diotSeleccionada = ObtieneFacturaFromGV(gvXMLs, e.RowIndex);
					string rfc = diotSeleccionada.EmisorRFC;
					if (rfc.ToUpper() != RfcExtranjero)
					{
						e.Cancel = true;
					}
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvXMLs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == gvColumnRFC.Index)
			{
				DataGridView gv = (DataGridView)sender;
				string cellValue = gv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
				EntFactura diotSeleccionada = ObtieneFacturaFromGV(gvXMLs);
			}
		}

		private void gvXMLs_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex < 0)
				{
					return;
				}
				if (e.ColumnIndex == VerDetalleCFDIs.Index)
				{
					string diotSeleccionadaRFC = ObtieneFacturaFromGV(gvXMLs).EmisorRFC;
					SetWaitCursor();
					ImprimeCFDIsFlujoEgresosSinTotales vImprime = new ImprimeCFDIsFlujoEgresosSinTotales(ListaDIOTdetalle.Where((EntFactura P) => P.RFC == diotSeleccionadaRFC).ToList(), true);
					vImprime.Show();
				}
				else if (e.ColumnIndex == gvColumnEliminar.Index)
				{
					EntFactura diotSeleccionada = ObtieneFacturaFromGV(gvXMLs);
					List<EntFactura> lstDIOT = ObtieneListaFacturasFromGV(gvXMLs);
					if (MuestraMensajeYesNo("¿Desea Eliminar el registro seleccionado?") == DialogResult.Yes)
					{
					}
					lstDIOT.Remove(diotSeleccionada);
					gvXMLs.DataSource = null;
					gvXMLs.DataSource = lstDIOT;
					gvXMLs.Refresh();
					CalculaTotales(lstDIOT);
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

		private void btnGuardaDIOT_Click(object sender, EventArgs e)
		{
		}

		private void cmbMesesComprobantes_Leave(object sender, EventArgs e)
		{
			try
			{
				if (cmbMesesComprobantes.Text.Length > 0)
				{
					cmbMesesComprobantes.SelectedIndex = cmbMesesComprobantes.FindString(cmbMesesComprobantes.Text);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbAñoComprobantes_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (cmbMesesComprobantes.Text.Length > 0)
					{
						cmbMesesComprobantes.SelectedIndex = cmbMesesComprobantes.FindString(cmbMesesComprobantes.Text);
					}
					btnRefrescar.PerformClick();
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle45 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.DIOT));
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle84 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tsNumContribuyentes = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
			this.gvTotalesDIOT = new System.Windows.Forms.DataGridView();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.gvColumnEliminar = new System.Windows.Forms.DataGridViewImageColumn();
			this.gvColumnTipoTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnTipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnRFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnIDFISCAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnNOMBREEXTRANJERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnPAIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnLUGARJURIDICCION = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Depositado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnRFnorte = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.gvColumnRFsur = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.gvColumnBase16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnDevBon16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnImportaciones16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnDevBonImp16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnImportIntan16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnDevBonImpInt16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnIvaRetenido = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Deduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SubTotal0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnEfectosFiscales = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IEPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalDeducciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.VerDetalleCFDIs = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAgregaProveedor = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnExportarDetallesCFDIsRecibidos = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGuardaDIOT = new System.Windows.Forms.Button();
			this.btnImportaXMLs = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel37 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel38 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel39 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel40 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.gvCancelados = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn85 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn86 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn87 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn88 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn89 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn90 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn91 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn92 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn93 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn94 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn95 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn96 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn97 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn98 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn99 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn100 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEnviarAExcelCanceladas = new System.Windows.Forms.Button();
			this.pnlFiltro = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.txtRFCFiltro = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.cmbPeriodos = new System.Windows.Forms.ComboBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
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
			this.EstatusDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UUIDrelacionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.retencionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uUIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.miniToolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNum = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIVA = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporte = new System.Windows.Forms.ToolStripTextBox();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnRevisarAnticiposDepositosPrevios = new System.Windows.Forms.Button();
			this.btnMarcarVigente = new System.Windows.Forms.Button();
			this.btnMarcarCancelada = new System.Windows.Forms.Button();
			this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewButtonColumn();
			this.gvTotalesColumnEstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvTotalesDIOT).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.flowLayoutPanel7.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCancelados).BeginInit();
			this.flowLayoutPanel13.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			this.gbDatosGenerales.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			base.SuspendLayout();
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(8, 31);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1429, 997);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Controls.Add(this.pnlFiltro);
			this.tabPage1.Controls.Add(this.gbDatosGenerales);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1421, 962);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "DIOT";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Controls.Add(this.tabPage6);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(3, 215);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(1413, 735);
			this.tcReportesIngresos.TabIndex = 140;
			this.tabPage2.Controls.Add(this.flowLayoutPanel14);
			this.tabPage2.Controls.Add(this.gvTotalesDIOT);
			this.tabPage2.Controls.Add(this.gvXMLs);
			this.tabPage2.Controls.Add(this.flowLayoutPanel1);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 31);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Size = new System.Drawing.Size(1405, 700);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "CARGA DIOT";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.Controls.Add(this.flpTotalesTodos);
			this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel14.Location = new System.Drawing.Point(4, 661);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Size = new System.Drawing.Size(1281, 38);
			this.flowLayoutPanel14.TabIndex = 138;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(980, 2);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(2);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(299, 36);
			this.flpTotalesTodos.TabIndex = 135;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.toolStripLabel5, this.tsNumContribuyentes, this.toolStripSeparator1, this.toolStripLabel6, this.toolStripTextBox2, this.toolStripLabel7, this.toolStripTextBox3, this.toolStripLabel8, this.toolStripTextBox4 });
			this.toolStrip1.Location = new System.Drawing.Point(0, 2);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(238, 31);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(180, 26);
			this.toolStripLabel5.Text = "Núm Contribuyentes:";
			this.tsNumContribuyentes.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tsNumContribuyentes.Name = "tsNumContribuyentes";
			this.tsNumContribuyentes.ReadOnly = true;
			this.tsNumContribuyentes.Size = new System.Drawing.Size(32, 31);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(84, 25);
			this.toolStripLabel6.Text = "SubTotal:";
			this.toolStripLabel6.Visible = false;
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(82, 31);
			this.toolStripTextBox2.Visible = false;
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel7.Text = "I.V.A:";
			this.toolStripLabel7.Visible = false;
			this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox3.Name = "toolStripTextBox3";
			this.toolStripTextBox3.ReadOnly = true;
			this.toolStripTextBox3.Size = new System.Drawing.Size(82, 31);
			this.toolStripTextBox3.Visible = false;
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(80, 25);
			this.toolStripLabel8.Text = "Importe:";
			this.toolStripLabel8.Visible = false;
			this.toolStripTextBox4.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox4.Name = "toolStripTextBox4";
			this.toolStripTextBox4.ReadOnly = true;
			this.toolStripTextBox4.Size = new System.Drawing.Size(82, 31);
			this.toolStripTextBox4.Visible = false;
			this.gvTotalesDIOT.AllowUserToAddRows = false;
			this.gvTotalesDIOT.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.gvTotalesDIOT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvTotalesDIOT.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvTotalesDIOT.AutoGenerateColumns = false;
			this.gvTotalesDIOT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvTotalesDIOT.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvTotalesDIOT.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gvTotalesDIOT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.gvTotalesDIOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvTotalesDIOT.Columns.AddRange(this.dataGridViewImageColumn3, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewCheckBoxColumn1, this.dataGridViewCheckBoxColumn2, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.dataGridViewTextBoxColumn19, this.dataGridViewTextBoxColumn20, this.dataGridViewTextBoxColumn21, this.dataGridViewTextBoxColumn22, this.dataGridViewTextBoxColumn23, this.dataGridViewTextBoxColumn24, this.dataGridViewTextBoxColumn25, this.dataGridViewTextBoxColumn26, this.dataGridViewTextBoxColumn27, this.dataGridViewImageColumn4, this.gvTotalesColumnEstatus);
			this.gvTotalesDIOT.DataSource = this.entFacturaBindingSource;
			this.gvTotalesDIOT.Location = new System.Drawing.Point(3, 525);
			this.gvTotalesDIOT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvTotalesDIOT.Name = "gvTotalesDIOT";
			this.gvTotalesDIOT.ReadOnly = true;
			this.gvTotalesDIOT.RowHeadersVisible = false;
			this.gvTotalesDIOT.RowHeadersWidth = 51;
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f);
			dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
			this.gvTotalesDIOT.RowsDefaultCellStyle = dataGridViewCellStyle18;
			this.gvTotalesDIOT.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.gvTotalesDIOT.RowTemplate.Height = 40;
			this.gvTotalesDIOT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvTotalesDIOT.Size = new System.Drawing.Size(1280, 135);
			this.gvTotalesDIOT.TabIndex = 137;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.gvXMLs.AllowUserToAddRows = false;
			dataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
			this.gvXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLs.AutoGenerateColumns = false;
			this.gvXMLs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLs.Columns.AddRange(this.gvColumnEliminar, this.gvColumnTipoTercero, this.gvColumnTipoOperacion, this.gvColumnRFC, this.gvColumnIDFISCAL, this.gvColumnNOMBREEXTRANJERO, this.gvColumnPAIS, this.gvColumnLUGARJURIDICCION, this.dataGridViewTextBoxColumn6, this.Depositado, this.gvColumnRFnorte, this.gvColumnRFsur, this.gvColumnBase16, this.gvColumnDevBon16, this.gvColumnImportaciones16, this.gvColumnDevBonImp16, this.gvColumnImportIntan16, this.gvColumnDevBonImpInt16, this.gvColumnIvaRetenido, this.Deduccion, this.SubTotal0, this.gvColumnEfectosFiscales, this.IVA, this.IEPS, this.dataGridViewTextBoxColumn2, this.TotalDeducciones, this.VerDetalleCFDIs, this.dataGridViewTextBoxColumn18);
			this.gvXMLs.DataSource = this.entFacturaBindingSource;
			this.gvXMLs.Location = new System.Drawing.Point(3, 3);
			this.gvXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle35.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle35;
			this.gvXMLs.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(1280, 520);
			this.gvXMLs.TabIndex = 14;
			this.gvXMLs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(gvXMLs_CellBeginEdit);
			this.gvXMLs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellContentClick);
			this.gvXMLs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellEndEdit);
			this.gvXMLs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(gvXMLs_CellFormatting);
			this.gvXMLs.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(gvXMLs_CellPainting);
			this.gvXMLs.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(gvXMLs_CellValidating);
			this.gvXMLs.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellValueChanged);
			this.gvXMLs.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(gvXMLs_DataError);
			this.gvXMLs.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(gvXMLs_EditingControlShowing);
			this.gvXMLs.Scroll += new System.Windows.Forms.ScrollEventHandler(gvXMLs_Scroll);
			this.gvXMLs.SizeChanged += new System.EventHandler(gvXMLs_SizeChanged);
			this.gvXMLs.KeyDown += new System.Windows.Forms.KeyEventHandler(gvXMLs_KeyDown);
			this.gvColumnEliminar.HeaderText = "Elim.";
			this.gvColumnEliminar.Image = LeeXML.Properties.Resources.X;
			this.gvColumnEliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.gvColumnEliminar.MinimumWidth = 8;
			this.gvColumnEliminar.Name = "gvColumnEliminar";
			this.gvColumnEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.gvColumnEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.gvColumnTipoTercero.DataPropertyName = "TipoComprobanteId";
			this.gvColumnTipoTercero.FillWeight = 60f;
			this.gvColumnTipoTercero.HeaderText = "TIPO TERCERO";
			this.gvColumnTipoTercero.MinimumWidth = 8;
			this.gvColumnTipoTercero.Name = "gvColumnTipoTercero";
			this.gvColumnTipoOperacion.DataPropertyName = "TipoImpuestoId";
			this.gvColumnTipoOperacion.FillWeight = 60f;
			this.gvColumnTipoOperacion.HeaderText = "TIPO DE OPERACIÓN";
			this.gvColumnTipoOperacion.MinimumWidth = 8;
			this.gvColumnTipoOperacion.Name = "gvColumnTipoOperacion";
			this.gvColumnRFC.DataPropertyName = "EmisorRFC";
			this.gvColumnRFC.FillWeight = 200f;
			this.gvColumnRFC.HeaderText = "RFC";
			this.gvColumnRFC.MinimumWidth = 6;
			this.gvColumnRFC.Name = "gvColumnRFC";
			this.gvColumnIDFISCAL.DataPropertyName = "NumeroFactura";
			this.gvColumnIDFISCAL.HeaderText = "ID FISCAL";
			this.gvColumnIDFISCAL.MinimumWidth = 8;
			this.gvColumnIDFISCAL.Name = "gvColumnIDFISCAL";
			this.gvColumnNOMBREEXTRANJERO.DataPropertyName = "UUID";
			this.gvColumnNOMBREEXTRANJERO.HeaderText = "NOMBRE DEL EXTRANJERO";
			this.gvColumnNOMBREEXTRANJERO.MinimumWidth = 8;
			this.gvColumnNOMBREEXTRANJERO.Name = "gvColumnNOMBREEXTRANJERO";
			this.gvColumnPAIS.DataPropertyName = "Moneda";
			this.gvColumnPAIS.HeaderText = "PAIS";
			this.gvColumnPAIS.MinimumWidth = 8;
			this.gvColumnPAIS.Name = "gvColumnPAIS";
			this.gvColumnLUGARJURIDICCION.DataPropertyName = "ClaveEntFed";
			this.gvColumnLUGARJURIDICCION.HeaderText = "LUGAR DE JURIDICCION FISCAL";
			this.gvColumnLUGARJURIDICCION.MinimumWidth = 8;
			this.gvColumnLUGARJURIDICCION.Name = "gvColumnLUGARJURIDICCION";
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Descuento";
			dataGridViewCellStyle36.Format = "c2";
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle36;
			this.dataGridViewTextBoxColumn6.HeaderText = "ACTOS PAGADOS RF";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.Depositado.DataPropertyName = "ISRRetenciones";
			dataGridViewCellStyle37.Format = "c2";
			this.Depositado.DefaultCellStyle = dataGridViewCellStyle37;
			this.Depositado.HeaderText = "DEV. DESC Y BON RF";
			this.Depositado.MinimumWidth = 8;
			this.Depositado.Name = "Depositado";
			this.Depositado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Depositado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.gvColumnRFnorte.DataPropertyName = "Deducible";
			this.gvColumnRFnorte.FillWeight = 50f;
			this.gvColumnRFnorte.HeaderText = "RF NORTE";
			this.gvColumnRFnorte.MinimumWidth = 8;
			this.gvColumnRFnorte.Name = "gvColumnRFnorte";
			this.gvColumnRFsur.DataPropertyName = "ExcluyeFlujo";
			this.gvColumnRFsur.FillWeight = 50f;
			this.gvColumnRFsur.HeaderText = "RF SUR";
			this.gvColumnRFsur.MinimumWidth = 8;
			this.gvColumnRFsur.Name = "gvColumnRFsur";
			this.gvColumnBase16.DataPropertyName = "SubTotal";
			dataGridViewCellStyle38.Format = "c2";
			this.gvColumnBase16.DefaultCellStyle = dataGridViewCellStyle38;
			this.gvColumnBase16.HeaderText = "BASE 16%";
			this.gvColumnBase16.MinimumWidth = 6;
			this.gvColumnBase16.Name = "gvColumnBase16";
			this.gvColumnDevBon16.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle39.Format = "c2";
			this.gvColumnDevBon16.DefaultCellStyle = dataGridViewCellStyle39;
			this.gvColumnDevBon16.HeaderText = "DEV, DESC Y BON 16%";
			this.gvColumnDevBon16.MinimumWidth = 8;
			this.gvColumnDevBon16.Name = "gvColumnDevBon16";
			this.gvColumnImportaciones16.DataPropertyName = "TotalUSD";
			dataGridViewCellStyle40.Format = "c2";
			this.gvColumnImportaciones16.DefaultCellStyle = dataGridViewCellStyle40;
			this.gvColumnImportaciones16.HeaderText = "IMPORTACIONES 16%";
			this.gvColumnImportaciones16.MinimumWidth = 8;
			this.gvColumnImportaciones16.Name = "gvColumnImportaciones16";
			this.gvColumnDevBonImp16.DataPropertyName = "EquivalenciaDR";
			dataGridViewCellStyle41.Format = "c2";
			this.gvColumnDevBonImp16.DefaultCellStyle = dataGridViewCellStyle41;
			this.gvColumnDevBonImp16.HeaderText = "DEV, DESC Y BON EN IMPORT. 16%";
			this.gvColumnDevBonImp16.MinimumWidth = 8;
			this.gvColumnDevBonImp16.Name = "gvColumnDevBonImp16";
			this.gvColumnImportIntan16.DataPropertyName = "ImporteDR";
			dataGridViewCellStyle42.Format = "c2";
			this.gvColumnImportIntan16.DefaultCellStyle = dataGridViewCellStyle42;
			this.gvColumnImportIntan16.HeaderText = "IMPORT. INTANGIBLES 16%";
			this.gvColumnImportIntan16.MinimumWidth = 8;
			this.gvColumnImportIntan16.Name = "gvColumnImportIntan16";
			this.gvColumnDevBonImpInt16.DataPropertyName = "ImpuestosLocales";
			dataGridViewCellStyle43.Format = "c2";
			this.gvColumnDevBonImpInt16.DefaultCellStyle = dataGridViewCellStyle43;
			this.gvColumnDevBonImpInt16.HeaderText = "DEV, DESC Y BON IMPORT. INTANGIBLES 16%";
			this.gvColumnDevBonImpInt16.MinimumWidth = 8;
			this.gvColumnDevBonImpInt16.Name = "gvColumnDevBonImpInt16";
			this.gvColumnIvaRetenido.DataPropertyName = "IVARetenciones";
			dataGridViewCellStyle44.Format = "c2";
			this.gvColumnIvaRetenido.DefaultCellStyle = dataGridViewCellStyle44;
			this.gvColumnIvaRetenido.HeaderText = "IVA RETENIDO";
			this.gvColumnIvaRetenido.MinimumWidth = 8;
			this.gvColumnIvaRetenido.Name = "gvColumnIvaRetenido";
			this.Deduccion.DataPropertyName = "Deduccion";
			dataGridViewCellStyle45.Format = "c2";
			this.Deduccion.DefaultCellStyle = dataGridViewCellStyle45;
			this.Deduccion.HeaderText = "EXENTO";
			this.Deduccion.MinimumWidth = 8;
			this.Deduccion.Name = "Deduccion";
			this.SubTotal0.DataPropertyName = "SubTotal0";
			dataGridViewCellStyle46.Format = "c2";
			this.SubTotal0.DefaultCellStyle = dataGridViewCellStyle46;
			this.SubTotal0.HeaderText = "BASE 0%";
			this.SubTotal0.MinimumWidth = 8;
			this.SubTotal0.Name = "SubTotal0";
			this.gvColumnEfectosFiscales.DataPropertyName = "OrdenId";
			this.gvColumnEfectosFiscales.DividerWidth = 1;
			this.gvColumnEfectosFiscales.HeaderText = "EFECTOS FISCALES A LOS COMPROBANTES";
			this.gvColumnEfectosFiscales.MinimumWidth = 8;
			this.gvColumnEfectosFiscales.Name = "gvColumnEfectosFiscales";
			this.IVA.DataPropertyName = "IVA";
			dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle47.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle47.Format = "c2";
			this.IVA.DefaultCellStyle = dataGridViewCellStyle47;
			this.IVA.HeaderText = "TOTAL IVA 16%";
			this.IVA.MinimumWidth = 8;
			this.IVA.Name = "IVA";
			this.IEPS.DataPropertyName = "TotalPercepciones";
			dataGridViewCellStyle48.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle48.Format = "c2";
			this.IEPS.DefaultCellStyle = dataGridViewCellStyle48;
			this.IEPS.HeaderText = "TOTAL IVA 16% NC";
			this.IEPS.MinimumWidth = 8;
			this.IEPS.Name = "IEPS";
			this.dataGridViewTextBoxColumn2.DataPropertyName = "IEPS";
			dataGridViewCellStyle49.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle49.Format = "c2";
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle49;
			this.dataGridViewTextBoxColumn2.HeaderText = "TOTAL IVA 8%";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.TotalDeducciones.DataPropertyName = "TotalDeducciones";
			dataGridViewCellStyle50.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle50.Format = "c2";
			this.TotalDeducciones.DefaultCellStyle = dataGridViewCellStyle50;
			this.TotalDeducciones.HeaderText = "TOTAL IVA 8% NC";
			this.TotalDeducciones.MinimumWidth = 8;
			this.TotalDeducciones.Name = "TotalDeducciones";
			this.VerDetalleCFDIs.HeaderText = "Ver Detalle";
			this.VerDetalleCFDIs.Image = LeeXML.Properties.Resources.observaciones;
			this.VerDetalleCFDIs.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.VerDetalleCFDIs.MinimumWidth = 8;
			this.VerDetalleCFDIs.Name = "VerDetalleCFDIs";
			this.dataGridViewTextBoxColumn18.DataPropertyName = "EstatusDescripcion";
			this.dataGridViewTextBoxColumn18.HeaderText = "Estatus";
			this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn18.Visible = false;
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.btnAgregaProveedor);
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.flowLayoutPanel1.Controls.Add(this.label1);
			this.flowLayoutPanel1.Controls.Add(this.btnExportarDetallesCFDIsRecibidos);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.Controls.Add(this.btnGuardaDIOT);
			this.flowLayoutPanel1.Controls.Add(this.btnImportaXMLs);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1286, -2);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(120, 662);
			this.flowLayoutPanel1.TabIndex = 134;
			this.btnAgregaProveedor.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAgregaProveedor.BackColor = System.Drawing.Color.White;
			this.btnAgregaProveedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregaProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregaProveedor.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregaProveedor.Image = LeeXML.Properties.Resources.Proveedores_chico_;
			this.btnAgregaProveedor.Location = new System.Drawing.Point(4, 5);
			this.btnAgregaProveedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregaProveedor.Name = "btnAgregaProveedor";
			this.btnAgregaProveedor.Size = new System.Drawing.Size(105, 105);
			this.btnAgregaProveedor.TabIndex = 147;
			this.btnAgregaProveedor.Text = "Agrega Proveedor";
			this.btnAgregaProveedor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregaProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAgregaProveedor.UseVisualStyleBackColor = false;
			this.btnAgregaProveedor.Click += new System.EventHandler(btnAgregaProveedor_Click);
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Image = LeeXML.Properties.Resources.Cancelar1;
			this.button1.Location = new System.Drawing.Point(4, 120);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(105, 105);
			this.button1.TabIndex = 133;
			this.button1.Text = "Marcar Cancelada";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Visible = false;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 230);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(98, 18);
			this.label1.TabIndex = 148;
			this.label1.Text = "---------------";
			this.btnExportarDetallesCFDIsRecibidos.BackColor = System.Drawing.Color.White;
			this.btnExportarDetallesCFDIsRecibidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportarDetallesCFDIsRecibidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarDetallesCFDIsRecibidos.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarDetallesCFDIsRecibidos.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportarDetallesCFDIsRecibidos.Location = new System.Drawing.Point(4, 253);
			this.btnExportarDetallesCFDIsRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnExportarDetallesCFDIsRecibidos.Name = "btnExportarDetallesCFDIsRecibidos";
			this.btnExportarDetallesCFDIsRecibidos.Size = new System.Drawing.Size(105, 111);
			this.btnExportarDetallesCFDIsRecibidos.TabIndex = 146;
			this.btnExportarDetallesCFDIsRecibidos.Text = "Ver Detalles CFDI'S 4.0";
			this.btnExportarDetallesCFDIsRecibidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarDetallesCFDIsRecibidos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarDetallesCFDIsRecibidos.UseVisualStyleBackColor = false;
			this.btnExportarDetallesCFDIsRecibidos.Click += new System.EventHandler(btnExportarDetallesCFDIsRecibidos_Click);
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 369);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 18);
			this.label2.TabIndex = 149;
			this.label2.Text = "---------------";
			this.btnGuardaDIOT.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnGuardaDIOT.BackColor = System.Drawing.Color.White;
			this.btnGuardaDIOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnGuardaDIOT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGuardaDIOT.Enabled = false;
			this.btnGuardaDIOT.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnGuardaDIOT.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnGuardaDIOT.Location = new System.Drawing.Point(4, 392);
			this.btnGuardaDIOT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnGuardaDIOT.Name = "btnGuardaDIOT";
			this.btnGuardaDIOT.Size = new System.Drawing.Size(105, 105);
			this.btnGuardaDIOT.TabIndex = 134;
			this.btnGuardaDIOT.Text = "Guardar DIOT";
			this.btnGuardaDIOT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnGuardaDIOT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardaDIOT.UseVisualStyleBackColor = false;
			this.btnGuardaDIOT.Click += new System.EventHandler(btnGuardaDIOT_Click);
			this.btnImportaXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnImportaXMLs.BackColor = System.Drawing.Color.White;
			this.btnImportaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnImportaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnImportaXMLs.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnImportaXMLs.Image = LeeXML.Properties.Resources.FONDO_boton_TXT;
			this.btnImportaXMLs.Location = new System.Drawing.Point(4, 507);
			this.btnImportaXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnImportaXMLs.Name = "btnImportaXMLs";
			this.btnImportaXMLs.Size = new System.Drawing.Size(105, 106);
			this.btnImportaXMLs.TabIndex = 135;
			this.btnImportaXMLs.Text = "Genera Txt";
			this.btnImportaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnImportaXMLs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImportaXMLs.UseVisualStyleBackColor = false;
			this.btnImportaXMLs.Click += new System.EventHandler(btnImportaXMLs_Click);
			this.tabPage6.Controls.Add(this.flowLayoutPanel7);
			this.tabPage6.Controls.Add(this.gvCancelados);
			this.tabPage6.Controls.Add(this.flowLayoutPanel13);
			this.tabPage6.Location = new System.Drawing.Point(4, 31);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage6.Size = new System.Drawing.Size(1405, 700);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "ELIMINADOS";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.flowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel7.Controls.Add(this.toolStrip6);
			this.flowLayoutPanel7.Location = new System.Drawing.Point(999, 649);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flowLayoutPanel7.Size = new System.Drawing.Size(299, 36);
			this.flowLayoutPanel7.TabIndex = 142;
			this.toolStrip6.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel37, this.tstNumCancelados, this.toolStripSeparator21, this.toolStripLabel38, this.tstSubCancelados, this.toolStripSeparator22, this.toolStripLabel39, this.tstIvaCancelados, this.toolStripSeparator23, this.toolStripLabel40,
				this.tstImporteCancelados
			});
			this.toolStrip6.Location = new System.Drawing.Point(0, 2);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip6.Size = new System.Drawing.Size(246, 31);
			this.toolStrip6.TabIndex = 2;
			this.toolStrip6.Text = "toolStrip6";
			this.toolStripLabel37.Name = "toolStripLabel37";
			this.toolStripLabel37.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel37.Text = "Núm Comprobantes:";
			this.tstNumCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumCancelados.Name = "tstNumCancelados";
			this.tstNumCancelados.ReadOnly = true;
			this.tstNumCancelados.Size = new System.Drawing.Size(41, 31);
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel38.Name = "toolStripLabel38";
			this.toolStripLabel38.Size = new System.Drawing.Size(84, 25);
			this.toolStripLabel38.Text = "SubTotal:";
			this.toolStripLabel38.Visible = false;
			this.tstSubCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubCancelados.Name = "tstSubCancelados";
			this.tstSubCancelados.ReadOnly = true;
			this.tstSubCancelados.Size = new System.Drawing.Size(108, 31);
			this.tstSubCancelados.Visible = false;
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(6, 32);
			this.toolStripSeparator22.Visible = false;
			this.toolStripLabel39.Name = "toolStripLabel39";
			this.toolStripLabel39.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel39.Text = "I.V.A:";
			this.toolStripLabel39.Visible = false;
			this.tstIvaCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaCancelados.Name = "tstIvaCancelados";
			this.tstIvaCancelados.ReadOnly = true;
			this.tstIvaCancelados.Size = new System.Drawing.Size(108, 31);
			this.tstIvaCancelados.Visible = false;
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(6, 32);
			this.toolStripSeparator23.Visible = false;
			this.toolStripLabel40.Name = "toolStripLabel40";
			this.toolStripLabel40.Size = new System.Drawing.Size(80, 25);
			this.toolStripLabel40.Text = "Importe:";
			this.toolStripLabel40.Visible = false;
			this.tstImporteCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteCancelados.Name = "tstImporteCancelados";
			this.tstImporteCancelados.ReadOnly = true;
			this.tstImporteCancelados.Size = new System.Drawing.Size(82, 31);
			this.tstImporteCancelados.Visible = false;
			this.gvCancelados.AllowUserToAddRows = false;
			dataGridViewCellStyle51.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle51.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvCancelados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle51;
			this.gvCancelados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvCancelados.AutoGenerateColumns = false;
			this.gvCancelados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvCancelados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvCancelados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvCancelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvCancelados.Columns.AddRange(this.dataGridViewTextBoxColumn85, this.dataGridViewTextBoxColumn86, this.dataGridViewTextBoxColumn87, this.dataGridViewTextBoxColumn88, this.dataGridViewTextBoxColumn89, this.dataGridViewTextBoxColumn90, this.dataGridViewTextBoxColumn91, this.dataGridViewTextBoxColumn92, this.dataGridViewTextBoxColumn93, this.dataGridViewTextBoxColumn94, this.dataGridViewTextBoxColumn95, this.dataGridViewTextBoxColumn96, this.dataGridViewTextBoxColumn97, this.dataGridViewTextBoxColumn98, this.dataGridViewTextBoxColumn99, this.dataGridViewTextBoxColumn100);
			this.gvCancelados.DataSource = this.entFacturaBindingSource;
			this.gvCancelados.Location = new System.Drawing.Point(0, 45);
			this.gvCancelados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvCancelados.Name = "gvCancelados";
			this.gvCancelados.ReadOnly = true;
			this.gvCancelados.RowHeadersVisible = false;
			this.gvCancelados.RowHeadersWidth = 51;
			dataGridViewCellStyle52.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle52.ForeColor = System.Drawing.Color.Black;
			this.gvCancelados.RowsDefaultCellStyle = dataGridViewCellStyle52;
			this.gvCancelados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvCancelados.Size = new System.Drawing.Size(1299, 603);
			this.gvCancelados.TabIndex = 138;
			this.dataGridViewTextBoxColumn85.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn85.FillWeight = 150f;
			this.dataGridViewTextBoxColumn85.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn85.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn85.Name = "dataGridViewTextBoxColumn85";
			this.dataGridViewTextBoxColumn85.ReadOnly = true;
			this.dataGridViewTextBoxColumn86.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn86.FillWeight = 250f;
			this.dataGridViewTextBoxColumn86.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn86.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn86.Name = "dataGridViewTextBoxColumn86";
			this.dataGridViewTextBoxColumn86.ReadOnly = true;
			this.dataGridViewTextBoxColumn87.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn87.FillWeight = 250f;
			this.dataGridViewTextBoxColumn87.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn87.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn87.Name = "dataGridViewTextBoxColumn87";
			this.dataGridViewTextBoxColumn87.ReadOnly = true;
			this.dataGridViewTextBoxColumn88.DataPropertyName = "Folio";
			dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn88.DefaultCellStyle = dataGridViewCellStyle53;
			this.dataGridViewTextBoxColumn88.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn88.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn88.Name = "dataGridViewTextBoxColumn88";
			this.dataGridViewTextBoxColumn88.ReadOnly = true;
			this.dataGridViewTextBoxColumn89.DataPropertyName = "SubTotal";
			dataGridViewCellStyle54.Format = "c2";
			this.dataGridViewTextBoxColumn89.DefaultCellStyle = dataGridViewCellStyle54;
			this.dataGridViewTextBoxColumn89.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn89.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn89.Name = "dataGridViewTextBoxColumn89";
			this.dataGridViewTextBoxColumn89.ReadOnly = true;
			this.dataGridViewTextBoxColumn90.DataPropertyName = "Descuento";
			dataGridViewCellStyle55.Format = "c4";
			this.dataGridViewTextBoxColumn90.DefaultCellStyle = dataGridViewCellStyle55;
			this.dataGridViewTextBoxColumn90.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn90.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn90.Name = "dataGridViewTextBoxColumn90";
			this.dataGridViewTextBoxColumn90.ReadOnly = true;
			this.dataGridViewTextBoxColumn90.Visible = false;
			this.dataGridViewTextBoxColumn91.DataPropertyName = "IVA";
			dataGridViewCellStyle56.Format = "c2";
			this.dataGridViewTextBoxColumn91.DefaultCellStyle = dataGridViewCellStyle56;
			this.dataGridViewTextBoxColumn91.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn91.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn91.Name = "dataGridViewTextBoxColumn91";
			this.dataGridViewTextBoxColumn91.ReadOnly = true;
			this.dataGridViewTextBoxColumn92.DataPropertyName = "Retenciones";
			dataGridViewCellStyle57.Format = "c2";
			this.dataGridViewTextBoxColumn92.DefaultCellStyle = dataGridViewCellStyle57;
			this.dataGridViewTextBoxColumn92.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn92.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn92.Name = "dataGridViewTextBoxColumn92";
			this.dataGridViewTextBoxColumn92.ReadOnly = true;
			this.dataGridViewTextBoxColumn93.DataPropertyName = "Total";
			dataGridViewCellStyle58.Format = "c2";
			this.dataGridViewTextBoxColumn93.DefaultCellStyle = dataGridViewCellStyle58;
			this.dataGridViewTextBoxColumn93.HeaderText = "Total";
			this.dataGridViewTextBoxColumn93.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn93.Name = "dataGridViewTextBoxColumn93";
			this.dataGridViewTextBoxColumn93.ReadOnly = true;
			this.dataGridViewTextBoxColumn94.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn94.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn94.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn94.Name = "dataGridViewTextBoxColumn94";
			this.dataGridViewTextBoxColumn94.ReadOnly = true;
			this.dataGridViewTextBoxColumn95.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn95.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn95.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn95.Name = "dataGridViewTextBoxColumn95";
			this.dataGridViewTextBoxColumn95.ReadOnly = true;
			this.dataGridViewTextBoxColumn96.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn96.DefaultCellStyle = dataGridViewCellStyle59;
			this.dataGridViewTextBoxColumn96.FillWeight = 120f;
			this.dataGridViewTextBoxColumn96.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn96.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn96.Name = "dataGridViewTextBoxColumn96";
			this.dataGridViewTextBoxColumn96.ReadOnly = true;
			this.dataGridViewTextBoxColumn97.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn97.FillWeight = 120f;
			this.dataGridViewTextBoxColumn97.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn97.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn97.Name = "dataGridViewTextBoxColumn97";
			this.dataGridViewTextBoxColumn97.ReadOnly = true;
			this.dataGridViewTextBoxColumn98.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn98.HeaderText = "UUID Relacionado";
			this.dataGridViewTextBoxColumn98.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn98.Name = "dataGridViewTextBoxColumn98";
			this.dataGridViewTextBoxColumn98.ReadOnly = true;
			this.dataGridViewTextBoxColumn99.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn99.HeaderText = "Concepto";
			this.dataGridViewTextBoxColumn99.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn99.Name = "dataGridViewTextBoxColumn99";
			this.dataGridViewTextBoxColumn99.ReadOnly = true;
			this.dataGridViewTextBoxColumn100.DataPropertyName = "EstatusDescripcion";
			this.dataGridViewTextBoxColumn100.HeaderText = "Estatus Descripcion";
			this.dataGridViewTextBoxColumn100.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn100.Name = "dataGridViewTextBoxColumn100";
			this.dataGridViewTextBoxColumn100.ReadOnly = true;
			this.flowLayoutPanel13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel13.Controls.Add(this.btnEnviarAExcelCanceladas);
			this.flowLayoutPanel13.Location = new System.Drawing.Point(1297, 38);
			this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel13.Name = "flowLayoutPanel13";
			this.flowLayoutPanel13.Size = new System.Drawing.Size(120, 300);
			this.flowLayoutPanel13.TabIndex = 143;
			this.btnEnviarAExcelCanceladas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcelCanceladas.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcelCanceladas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcelCanceladas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcelCanceladas.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcelCanceladas.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcelCanceladas.Location = new System.Drawing.Point(4, 5);
			this.btnEnviarAExcelCanceladas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEnviarAExcelCanceladas.Name = "btnEnviarAExcelCanceladas";
			this.btnEnviarAExcelCanceladas.Size = new System.Drawing.Size(105, 105);
			this.btnEnviarAExcelCanceladas.TabIndex = 133;
			this.btnEnviarAExcelCanceladas.Text = "Enviar a Excel";
			this.btnEnviarAExcelCanceladas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcelCanceladas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcelCanceladas.UseVisualStyleBackColor = false;
			this.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltro.Controls.Add(this.label8);
			this.pnlFiltro.Controls.Add(this.txtRFCFiltro);
			this.pnlFiltro.Controls.Add(this.label6);
			this.pnlFiltro.Controls.Add(this.txtCliente);
			this.pnlFiltro.Controls.Add(this.btnFiltraFacturas);
			this.pnlFiltro.Location = new System.Drawing.Point(9, 148);
			this.pnlFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(706, 47);
			this.pnlFiltro.TabIndex = 139;
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 12);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(41, 18);
			this.label8.TabIndex = 137;
			this.label8.Text = "R.F.C:";
			this.txtRFCFiltro.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtRFCFiltro.Location = new System.Drawing.Point(62, 9);
			this.txtRFCFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtRFCFiltro.Name = "txtRFCFiltro";
			this.txtRFCFiltro.Size = new System.Drawing.Size(160, 25);
			this.txtRFCFiltro.TabIndex = 136;
			this.txtRFCFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(237, 12);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 18);
			this.label6.TabIndex = 135;
			this.label6.Text = "Proveedor:";
			this.txtCliente.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.txtCliente.Location = new System.Drawing.Point(322, 9);
			this.txtCliente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtCliente.Name = "txtCliente";
			this.txtCliente.Size = new System.Drawing.Size(193, 25);
			this.txtCliente.TabIndex = 4;
			this.txtCliente.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(640, 0);
			this.btnFiltraFacturas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(58, 42);
			this.btnFiltraFacturas.TabIndex = 6;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(644, 11);
			this.gbDatosGenerales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosGenerales.Size = new System.Drawing.Size(726, 106);
			this.gbDatosGenerales.TabIndex = 137;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(20, 31);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(141, 28);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(171, 26);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(510, 30);
			this.txtNombreFiscal.TabIndex = 104;
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(171, 66);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(247, 30);
			this.txtRFC.TabIndex = 106;
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(99, 68);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(58, 28);
			this.label5.TabIndex = 105;
			this.label5.Text = "R.F.C:";
			this.panel1.Controls.Add(this.cmbPeriodos);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Location = new System.Drawing.Point(9, 5);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(626, 131);
			this.panel1.TabIndex = 135;
			this.cmbPeriodos.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbPeriodos.DisplayMember = "Descripcion";
			this.cmbPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPeriodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbPeriodos.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbPeriodos.ForeColor = System.Drawing.Color.Black;
			this.cmbPeriodos.FormattingEnabled = true;
			this.cmbPeriodos.Location = new System.Drawing.Point(124, 89);
			this.cmbPeriodos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbPeriodos.Name = "cmbPeriodos";
			this.cmbPeriodos.Size = new System.Drawing.Size(332, 34);
			this.cmbPeriodos.TabIndex = 145;
			this.cmbPeriodos.ValueMember = "Id";
			this.cmbPeriodos.Visible = false;
			this.cmbPeriodos.SelectedIndexChanged += new System.EventHandler(cmbPeriodos_SelectedIndexChanged);
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.radioButton1.Location = new System.Drawing.Point(8, 88);
			this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(109, 32);
			this.radioButton1.TabIndex = 144;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Periodo:";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.Visible = false;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(482, 9);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(112, 105);
			this.btnRefrescar.TabIndex = 1;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(10, 48);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(84, 22);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorMesComprobantes.CheckedChanged += new System.EventHandler(rdoPorMesComprobantes_CheckedChanged);
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(117, 31);
			this.pnlPorMesVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(364, 52);
			this.pnlPorMesVentas.TabIndex = 0;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Items.AddRange(new object[12]
			{
				"01-ENERO", "02-FEBRERO", "03-MARZO", "04-ABRIL", "05-MAYO", "06-JUNIO", "07-JULIO", "08-AGOSTO", "09-SEPTIEMBRE", "10-OCTUBRE",
				"11-NOVIEMBRE", "12-DICIEMBRE"
			});
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(8, 11);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(187, 33);
			this.cmbMesesComprobantes.TabIndex = 0;
			this.cmbMesesComprobantes.SelectedIndexChanged += new System.EventHandler(cmbMesesComprobantes_SelectedIndexChanged);
			this.cmbMesesComprobantes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmbAñoComprobantes_KeyPress);
			this.cmbMesesComprobantes.Leave += new System.EventHandler(cmbMesesComprobantes_Leave);
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(228, 12);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(114, 33);
			this.cmbAñoComprobantes.TabIndex = 1;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.cmbAñoComprobantes.SelectedIndexChanged += new System.EventHandler(cmbMesesComprobantes_SelectedIndexChanged);
			this.cmbAñoComprobantes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cmbAñoComprobantes_KeyPress);
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
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(385, 18);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(77, 20);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(477, 8);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(404, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.EstatusDescripcion.DataPropertyName = "EstatusDescripcion";
			this.EstatusDescripcion.HeaderText = "Estatus";
			this.EstatusDescripcion.MinimumWidth = 6;
			this.EstatusDescripcion.Name = "EstatusDescripcion";
			this.EstatusDescripcion.ReadOnly = true;
			this.EstatusDescripcion.Width = 150;
			this.Descripcion.DataPropertyName = "Descripcion";
			this.Descripcion.FillWeight = 120f;
			this.Descripcion.HeaderText = "Concepto";
			this.Descripcion.MinimumWidth = 6;
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			this.Descripcion.Width = 150;
			this.UUIDrelacionado.DataPropertyName = "UUIDrelacionado";
			this.UUIDrelacionado.HeaderText = "UUID Relacionado";
			this.UUIDrelacionado.MinimumWidth = 6;
			this.UUIDrelacionado.Name = "UUIDrelacionado";
			this.UUIDrelacionado.ReadOnly = true;
			this.UUIDrelacionado.Width = 150;
			this.FormaPago.DataPropertyName = "FormaPago";
			this.FormaPago.FillWeight = 120f;
			this.FormaPago.HeaderText = "Forma Pago";
			this.FormaPago.MinimumWidth = 6;
			this.FormaPago.Name = "FormaPago";
			this.FormaPago.ReadOnly = true;
			this.FormaPago.Width = 150;
			this.MetodoPago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MetodoPago.DefaultCellStyle = dataGridViewCellStyle60;
			this.MetodoPago.FillWeight = 50f;
			this.MetodoPago.HeaderText = "Metodo Pago";
			this.MetodoPago.MinimumWidth = 6;
			this.MetodoPago.Name = "MetodoPago";
			this.MetodoPago.ReadOnly = true;
			this.MetodoPago.Width = 150;
			this.TipoComprobante.DataPropertyName = "TipoComprobante";
			this.TipoComprobante.FillWeight = 80f;
			this.TipoComprobante.HeaderText = "Tipo Comprobante";
			this.TipoComprobante.MinimumWidth = 6;
			this.TipoComprobante.Name = "TipoComprobante";
			this.TipoComprobante.ReadOnly = true;
			this.TipoComprobante.Width = 150;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle61;
			this.fechaDataGridViewTextBoxColumn.FillWeight = 80f;
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.Width = 150;
			this.TipoCambio.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle62.Format = "n4";
			this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle62;
			this.TipoCambio.FillWeight = 50f;
			this.TipoCambio.HeaderText = "Tipo Cambio";
			this.TipoCambio.MinimumWidth = 6;
			this.TipoCambio.Name = "TipoCambio";
			this.TipoCambio.ReadOnly = true;
			this.TipoCambio.Width = 150;
			this.Moneda.DataPropertyName = "Moneda";
			dataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Moneda.DefaultCellStyle = dataGridViewCellStyle63;
			this.Moneda.FillWeight = 50f;
			this.Moneda.HeaderText = "Moneda";
			this.Moneda.MinimumWidth = 6;
			this.Moneda.Name = "Moneda";
			this.Moneda.ReadOnly = true;
			this.Moneda.Width = 150;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle64.Format = "c2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle64;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.Width = 150;
			this.retencionesDataGridViewTextBoxColumn.DataPropertyName = "Retenciones";
			dataGridViewCellStyle65.Format = "c2";
			this.retencionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle65;
			this.retencionesDataGridViewTextBoxColumn.HeaderText = "Retenciones";
			this.retencionesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.retencionesDataGridViewTextBoxColumn.Name = "retencionesDataGridViewTextBoxColumn";
			this.retencionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.retencionesDataGridViewTextBoxColumn.Width = 150;
			this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
			dataGridViewCellStyle66.Format = "c2";
			this.iVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle66;
			this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
			this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
			this.iVADataGridViewTextBoxColumn.ReadOnly = true;
			this.iVADataGridViewTextBoxColumn.Width = 150;
			this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
			dataGridViewCellStyle67.Format = "c2";
			this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle67;
			this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
			this.descuentoDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
			this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.Visible = false;
			this.descuentoDataGridViewTextBoxColumn.Width = 150;
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle68.Format = "c2";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle68;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.subTotalDataGridViewTextBoxColumn.Width = 150;
			this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
			dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.folioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle69;
			this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
			this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
			this.folioDataGridViewTextBoxColumn.ReadOnly = true;
			this.folioDataGridViewTextBoxColumn.Width = 150;
			this.uUIDDataGridViewTextBoxColumn.DataPropertyName = "UUID";
			this.uUIDDataGridViewTextBoxColumn.FillWeight = 200f;
			this.uUIDDataGridViewTextBoxColumn.HeaderText = "UUID";
			this.uUIDDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.uUIDDataGridViewTextBoxColumn.Name = "uUIDDataGridViewTextBoxColumn";
			this.uUIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.uUIDDataGridViewTextBoxColumn.Width = 150;
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "EmisorNombre";
			this.nombreDataGridViewTextBoxColumn.FillWeight = 250f;
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
			this.nombreDataGridViewTextBoxColumn.Width = 150;
			this.rFCDataGridViewTextBoxColumn.DataPropertyName = "EmisorRFC";
			this.rFCDataGridViewTextBoxColumn.FillWeight = 150f;
			this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
			this.rFCDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
			this.rFCDataGridViewTextBoxColumn.ReadOnly = true;
			this.rFCDataGridViewTextBoxColumn.Width = 150;
			this.miniToolStrip.AccessibleName = "Selección de nuevo elemento";
			this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
			this.miniToolStrip.AutoSize = false;
			this.miniToolStrip.CanOverflow = false;
			this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.miniToolStrip.Location = new System.Drawing.Point(2, 198);
			this.miniToolStrip.Name = "miniToolStrip";
			this.miniToolStrip.Padding = new System.Windows.Forms.Padding(0);
			this.miniToolStrip.Size = new System.Drawing.Size(251, 31);
			this.miniToolStrip.TabIndex = 2;
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel3.Text = "Núm Comprobantes:";
			this.tstxtNum.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNum.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.tstxtNum.Name = "tstxtNum";
			this.tstxtNum.ReadOnly = true;
			this.tstxtNum.Size = new System.Drawing.Size(46, 31);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(84, 25);
			this.toolStripLabel4.Text = "SubTotal:";
			this.toolStripLabel4.Visible = false;
			this.tstxtSubtotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotal.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.tstxtSubtotal.Name = "tstxtSubtotal";
			this.tstxtSubtotal.ReadOnly = true;
			this.tstxtSubtotal.Size = new System.Drawing.Size(82, 31);
			this.tstxtSubtotal.Visible = false;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel1.Text = "I.V.A:";
			this.toolStripLabel1.Visible = false;
			this.tstxtIVA.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIVA.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.tstxtIVA.Name = "tstxtIVA";
			this.tstxtIVA.ReadOnly = true;
			this.tstxtIVA.Size = new System.Drawing.Size(82, 31);
			this.tstxtIVA.Visible = false;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(80, 25);
			this.toolStripLabel2.Text = "Importe:";
			this.toolStripLabel2.Visible = false;
			this.tstxtImporte.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporte.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.tstxtImporte.Name = "tstxtImporte";
			this.tstxtImporte.ReadOnly = true;
			this.tstxtImporte.Size = new System.Drawing.Size(82, 31);
			this.tstxtImporte.Visible = false;
			this.dataGridViewImageColumn1.HeaderText = "Elim.";
			this.dataGridViewImageColumn1.Image = LeeXML.Properties.Resources.X;
			this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn1.MinimumWidth = 8;
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewImageColumn1.Width = 40;
			this.dataGridViewImageColumn2.HeaderText = "Ver Detalle";
			this.dataGridViewImageColumn2.Image = LeeXML.Properties.Resources.observaciones;
			this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn2.MinimumWidth = 8;
			this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn2.Width = 40;
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(912, 3);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(75, 54);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.btnRevisarAnticiposDepositosPrevios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRevisarAnticiposDepositosPrevios.BackColor = System.Drawing.Color.White;
			this.btnRevisarAnticiposDepositosPrevios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRevisarAnticiposDepositosPrevios.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRevisarAnticiposDepositosPrevios.Font = new System.Drawing.Font("Segoe UI", 5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRevisarAnticiposDepositosPrevios.Image = LeeXML.Properties.Resources.World_search;
			this.btnRevisarAnticiposDepositosPrevios.Location = new System.Drawing.Point(4, 98);
			this.btnRevisarAnticiposDepositosPrevios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRevisarAnticiposDepositosPrevios.Name = "btnRevisarAnticiposDepositosPrevios";
			this.btnRevisarAnticiposDepositosPrevios.Size = new System.Drawing.Size(105, 105);
			this.btnRevisarAnticiposDepositosPrevios.TabIndex = 133;
			this.btnRevisarAnticiposDepositosPrevios.Text = "Revisar Anticipos ó Depósitos Previos";
			this.btnRevisarAnticiposDepositosPrevios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRevisarAnticiposDepositosPrevios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRevisarAnticiposDepositosPrevios.UseVisualStyleBackColor = false;
			this.btnRevisarAnticiposDepositosPrevios.Visible = false;
			this.btnRevisarAnticiposDepositosPrevios.Click += new System.EventHandler(btnRevisarAnticiposDepositosPrevios_Click);
			this.btnMarcarVigente.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMarcarVigente.BackColor = System.Drawing.Color.White;
			this.btnMarcarVigente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnMarcarVigente.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMarcarVigente.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnMarcarVigente.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnMarcarVigente.Location = new System.Drawing.Point(4, 120);
			this.btnMarcarVigente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnMarcarVigente.Name = "btnMarcarVigente";
			this.btnMarcarVigente.Size = new System.Drawing.Size(105, 105);
			this.btnMarcarVigente.TabIndex = 134;
			this.btnMarcarVigente.Text = "Marcar Vigente";
			this.btnMarcarVigente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMarcarVigente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMarcarVigente.UseVisualStyleBackColor = false;
			this.btnMarcarVigente.Click += new System.EventHandler(btnMarcarVigente_Click);
			this.btnMarcarCancelada.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMarcarCancelada.BackColor = System.Drawing.Color.White;
			this.btnMarcarCancelada.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnMarcarCancelada.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMarcarCancelada.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnMarcarCancelada.Image = LeeXML.Properties.Resources.Cancelar1;
			this.btnMarcarCancelada.Location = new System.Drawing.Point(4, 5);
			this.btnMarcarCancelada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnMarcarCancelada.Name = "btnMarcarCancelada";
			this.btnMarcarCancelada.Size = new System.Drawing.Size(105, 105);
			this.btnMarcarCancelada.TabIndex = 133;
			this.btnMarcarCancelada.Text = "Marcar Cancelada";
			this.btnMarcarCancelada.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMarcarCancelada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMarcarCancelada.UseVisualStyleBackColor = false;
			this.btnMarcarCancelada.Click += new System.EventHandler(btnMarcarCancelada_Click);
			this.dataGridViewImageColumn3.HeaderText = "";
			this.dataGridViewImageColumn3.MinimumWidth = 8;
			this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
			this.dataGridViewImageColumn3.ReadOnly = true;
			this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn3.FillWeight = 60f;
			this.dataGridViewTextBoxColumn3.HeaderText = "";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn4.FillWeight = 60f;
			this.dataGridViewTextBoxColumn4.HeaderText = "";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn5.FillWeight = 200f;
			this.dataGridViewTextBoxColumn5.HeaderText = "";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "NumeroFactura";
			this.dataGridViewTextBoxColumn7.HeaderText = "";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn8.HeaderText = "";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Moneda";
			this.dataGridViewTextBoxColumn9.HeaderText = "";
			this.dataGridViewTextBoxColumn9.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "ClaveEntFed";
			this.dataGridViewTextBoxColumn10.HeaderText = "";
			this.dataGridViewTextBoxColumn10.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Descuento";
			dataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle70.Format = "c2";
			this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle70;
			this.dataGridViewTextBoxColumn11.HeaderText = "ACTOS RF";
			this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "ISRRetenciones";
			dataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle71.Format = "c2";
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle71;
			this.dataGridViewTextBoxColumn12.HeaderText = "DEV. RF";
			this.dataGridViewTextBoxColumn12.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewCheckBoxColumn1.FillWeight = 50f;
			this.dataGridViewCheckBoxColumn1.HeaderText = "";
			this.dataGridViewCheckBoxColumn1.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewCheckBoxColumn2.FillWeight = 50f;
			this.dataGridViewCheckBoxColumn2.HeaderText = "";
			this.dataGridViewCheckBoxColumn2.MinimumWidth = 8;
			this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
			this.dataGridViewCheckBoxColumn2.ReadOnly = true;
			this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "SubTotal";
			dataGridViewCellStyle72.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle72.Format = "c2";
			this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle72;
			this.dataGridViewTextBoxColumn13.HeaderText = "BASE 16%";
			this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn14.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle73.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle73.Format = "c2";
			this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle73;
			this.dataGridViewTextBoxColumn14.HeaderText = "DEV. 16%";
			this.dataGridViewTextBoxColumn14.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "TotalUSD";
			dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle74.Format = "c2";
			this.dataGridViewTextBoxColumn15.DefaultCellStyle = dataGridViewCellStyle74;
			this.dataGridViewTextBoxColumn15.HeaderText = "IMPORT 16%";
			this.dataGridViewTextBoxColumn15.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn15.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "EquivalenciaDR";
			dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle75.Format = "c2";
			this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle75;
			this.dataGridViewTextBoxColumn16.HeaderText = "DEV 16%";
			this.dataGridViewTextBoxColumn16.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			this.dataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "ImporteDR";
			dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle76.Format = "c2";
			this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle76;
			this.dataGridViewTextBoxColumn17.HeaderText = "IMPORT INT 16%";
			this.dataGridViewTextBoxColumn17.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			this.dataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn17.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn19.DataPropertyName = "ImpuestosLocales";
			dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle77.Format = "c2";
			this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle77;
			this.dataGridViewTextBoxColumn19.HeaderText = "DEV 16%";
			this.dataGridViewTextBoxColumn19.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn19.ReadOnly = true;
			this.dataGridViewTextBoxColumn19.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn19.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn20.DataPropertyName = "IVARetenciones";
			dataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle78.Format = "c2";
			this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle78;
			this.dataGridViewTextBoxColumn20.HeaderText = "IVA RETENIDO";
			this.dataGridViewTextBoxColumn20.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn20.ReadOnly = true;
			this.dataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn20.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn21.DataPropertyName = "Deduccion";
			dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle79.Format = "c2";
			this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle79;
			this.dataGridViewTextBoxColumn21.HeaderText = "EXENTO";
			this.dataGridViewTextBoxColumn21.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn21.ReadOnly = true;
			this.dataGridViewTextBoxColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn21.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn22.DataPropertyName = "SubTotal0";
			dataGridViewCellStyle80.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle80.Format = "c2";
			this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle80;
			this.dataGridViewTextBoxColumn22.HeaderText = "BASE 0%";
			this.dataGridViewTextBoxColumn22.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn22.ReadOnly = true;
			this.dataGridViewTextBoxColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn22.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn23.DividerWidth = 1;
			this.dataGridViewTextBoxColumn23.HeaderText = "";
			this.dataGridViewTextBoxColumn23.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn23.ReadOnly = true;
			this.dataGridViewTextBoxColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn24.DataPropertyName = "IVA";
			dataGridViewCellStyle81.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle81.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle81.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle81.Format = "c2";
			this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle81;
			this.dataGridViewTextBoxColumn24.HeaderText = "IVA 16%";
			this.dataGridViewTextBoxColumn24.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn24.ReadOnly = true;
			this.dataGridViewTextBoxColumn24.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn25.DataPropertyName = "TotalPercepciones";
			dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle82.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle82.Format = "c2";
			this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle82;
			this.dataGridViewTextBoxColumn25.HeaderText = "NC 16% ";
			this.dataGridViewTextBoxColumn25.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn25.ReadOnly = true;
			this.dataGridViewTextBoxColumn25.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn26.DataPropertyName = "IEPS";
			dataGridViewCellStyle83.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle83.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle83.Format = "c2";
			this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle83;
			this.dataGridViewTextBoxColumn26.HeaderText = "IVA 8%";
			this.dataGridViewTextBoxColumn26.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn26.ReadOnly = true;
			this.dataGridViewTextBoxColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewTextBoxColumn27.DataPropertyName = "TotalDeducciones";
			dataGridViewCellStyle84.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle84.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle84.Format = "c2";
			this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle84;
			this.dataGridViewTextBoxColumn27.HeaderText = "NC 8% ";
			this.dataGridViewTextBoxColumn27.MinimumWidth = 8;
			this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn27.ReadOnly = true;
			this.dataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewImageColumn4.FillWeight = 120f;
			this.dataGridViewImageColumn4.HeaderText = "";
			this.dataGridViewImageColumn4.MinimumWidth = 8;
			this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
			this.dataGridViewImageColumn4.ReadOnly = true;
			this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gvTotalesColumnEstatus.DataPropertyName = "EstatusDescripcion";
			this.gvTotalesColumnEstatus.HeaderText = "";
			this.gvTotalesColumnEstatus.MinimumWidth = 6;
			this.gvTotalesColumnEstatus.Name = "gvTotalesColumnEstatus";
			this.gvTotalesColumnEstatus.ReadOnly = true;
			this.gvTotalesColumnEstatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
			this.gvTotalesColumnEstatus.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1454, 1046);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "DIOT";
			this.Text = "DIOT";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.flowLayoutPanel14.ResumeLayout(false);
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvTotalesDIOT).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tabPage6.ResumeLayout(false);
			this.flowLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel7.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCancelados).EndInit();
			this.flowLayoutPanel13.ResumeLayout(false);
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
