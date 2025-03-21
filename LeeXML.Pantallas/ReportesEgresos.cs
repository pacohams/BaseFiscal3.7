using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Microsoft.Office.Interop.Excel;
using TextBox = System.Windows.Forms.TextBox;

namespace LeeXML.Pantallas
{
	public class ReportesEgresos : FormBase
	{
		private IContainer components = null;

		private DataGridView gvXMLs;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private FlowLayoutPanel flowLayoutPanel1;

		private TabControl tcReportesIngresos;

		private TabPage tabPage2;

		private FlowLayoutPanel flpTotalesTodos;

		private ToolStrip toolStrip1;

		private ToolStripLabel toolStripLabel1;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.TextBox textBox1;

		private Panel panel1;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Panel pnlPorDiaVentas;

		private DateTimePicker dtpFechaDesde;

		private RadioButton rdoPorFechasComprobantes;

		private ToolStripTextBox tstxtIVA;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImporte;

		private TabPage tpIngresos;

		private System.Windows.Forms.Button btnRefrescar;

		private DateTimePicker dtpFechaHasta;

		private FlowLayoutPanel flowLayoutPanel2;

		private System.Windows.Forms.CheckBox chkIngresosFiltro;

		private System.Windows.Forms.CheckBox chkCPFiltro;

		private System.Windows.Forms.CheckBox chkNominaFiltro;

		private System.Windows.Forms.CheckBox chkNotasCreditoFiltro;

		private System.Windows.Forms.CheckBox chkCanceladasFiltro;

		private System.Windows.Forms.Button btnMarcarCancelada;

		private System.Windows.Forms.Button btnMarcarVigente;

		private TabPage tabPage3;

		private TabPage tabPage4;

		private TabPage tabPage5;

		private TabPage tabPage6;

		private System.Windows.Forms.Button btnBuscaEmpresa;

		private System.Windows.Forms.Label label24;

		private ComboBox cmbEmpresas;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotal;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNum;

		private ToolStripSeparator toolStripSeparator4;

		private DataGridView gvIngresos;

		private DataGridView gvComplementos;

		private FlowLayoutPanel flowLayoutPanel5;

		private DataGridView gvNominas;

		private FlowLayoutPanel flowLayoutPanel6;

		private DataGridView gvNotasCredito;

		private DataGridView gvCancelados;

		private FlowLayoutPanel flowLayoutPanel3;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tstNumIngresos;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox tstSubIngresos;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tstIvaIngresos;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tstImporteIngresos;

		private FlowLayoutPanel flowLayoutPanel4;

		private ToolStrip toolStrip3;

		private ToolStripLabel toolStripLabel9;

		private ToolStripTextBox tstNumCP;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripLabel toolStripLabel10;

		private ToolStripTextBox tstSubCP;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripLabel toolStripLabel11;

		private ToolStripTextBox tstIvaCP;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripLabel toolStripLabel12;

		private ToolStripTextBox tstImporteCP;

		private FlowLayoutPanel flowLayoutPanel8;

		private ToolStrip toolStrip4;

		private ToolStripLabel toolStripLabel13;

		private ToolStripTextBox tstNumNom;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripLabel toolStripLabel14;

		private ToolStripTextBox tstSubNom;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripLabel toolStripLabel15;

		private ToolStripTextBox tstIvaNom;

		private ToolStripSeparator toolStripSeparator15;

		private ToolStripLabel toolStripLabel16;

		private ToolStripTextBox tstImporteNom;

		private FlowLayoutPanel flowLayoutPanel9;

		private ToolStrip toolStrip5;

		private ToolStripLabel toolStripLabel17;

		private ToolStripTextBox tstNumNC;

		private ToolStripSeparator toolStripSeparator17;

		private ToolStripLabel toolStripLabel18;

		private ToolStripTextBox tstSubNC;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripLabel toolStripLabel19;

		private ToolStripTextBox tstIvaNC;

		private ToolStripSeparator toolStripSeparator19;

		private ToolStripLabel toolStripLabel20;

		private ToolStripTextBox tstImporteNC;

		private FlowLayoutPanel flowLayoutPanel7;

		private ToolStrip toolStrip6;

		private ToolStripLabel toolStripLabel21;

		private ToolStripTextBox tstNumCancelados;

		private ToolStripSeparator toolStripSeparator21;

		private ToolStripLabel toolStripLabel22;

		private ToolStripTextBox tstSubCancelados;

		private ToolStripSeparator toolStripSeparator22;

		private ToolStripLabel toolStripLabel23;

		private ToolStripTextBox tstIvaCancelados;

		private ToolStripSeparator toolStripSeparator23;

		private ToolStripLabel toolStripLabel24;

		private ToolStripTextBox tstImporteCancelados;

		private System.Windows.Forms.GroupBox gbDatosGenerales;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.TextBox txtNombreFiscal;

		private System.Windows.Forms.TextBox txtRFC;

		private System.Windows.Forms.Label label5;

		private FlowLayoutPanel flowLayoutPanel10;

		private System.Windows.Forms.Button btnEnviarAExcelIngresos;

		private FlowLayoutPanel flowLayoutPanel11;

		private System.Windows.Forms.Button btnEnviarAExcelCP;

		private FlowLayoutPanel flowLayoutPanel12;

		private System.Windows.Forms.Button btnEnviarAExcelNC;

		private FlowLayoutPanel flowLayoutPanel13;

		private System.Windows.Forms.Button btnEnviarAExcelCanceladas;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private FlowLayoutPanel flowLayoutPanel14;

		private System.Windows.Forms.Button btnRevisarAnticiposDepositosPrevios;

		private System.Windows.Forms.Button btnNoDeducible;

		private System.Windows.Forms.Button btnDeducible;

		private Panel pnlFiltro;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.TextBox txtRFCFiltro;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.TextBox txtCliente;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.TextBox txtUUIDfiltro;

		private System.Windows.Forms.Button btnFiltraFacturas;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.TextBox txtFacturaFiltro;

		private Panel pnlFiltroPUEPPD;

		private RadioButton rdoTodas;

		private RadioButton rdoPPD;

		private RadioButton rdoPueCP;

		private ToolStripLabel toolStripLabel29;

		private FlowLayoutPanel flowLayoutPanel16;

		private ToolStrip toolStrip7;

		private ToolStripLabel toolStripLabel30;

		private ToolStripLabel toolStripLabel25;

		private ToolStripTextBox tstNumIngresosUSD;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel26;

		private ToolStripTextBox tstSubIngresosUSD;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel27;

		private ToolStripTextBox tstIvaIngresosUSD;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel28;

		private ToolStripTextBox tstImporteIngresosUSD;

		private ToolStripLabel toolStripLabel35;

		private FlowLayoutPanel flowLayoutPanel17;

		private ToolStrip toolStrip8;

		private ToolStripLabel toolStripLabel36;

		private ToolStripLabel toolStripLabel31;

		private ToolStripTextBox tstNumCPUSD;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripLabel toolStripLabel32;

		private ToolStripTextBox toolStripTextBox2;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripLabel toolStripLabel33;

		private ToolStripTextBox toolStripTextBox3;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripLabel toolStripLabel34;

		private ToolStripTextBox tstImporteCPUSD;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;

		private DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn uUIDDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn retencionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn Moneda;

		private DataGridViewTextBoxColumn TipoCambio;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private new DataGridViewTextBoxColumn TipoComprobante;

		private DataGridViewTextBoxColumn MetodoPago;

		private DataGridViewTextBoxColumn FormaPago;

		private DataGridViewTextBoxColumn UUIDrelacionado;

		private DataGridViewTextBoxColumn Descripcion;

		private DataGridViewTextBoxColumn EstatusDescripcion;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn SubTotal;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private new DataGridViewTextBoxColumn IEPS;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;

		private DataGridViewCheckBoxColumn Deducible;

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

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn79;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn80;

		private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn81;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn82;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntEstadoDeCuenta> ListaCxC { get; set; }

		private List<EntEstadoDeCuenta> ListaCxCMovimientos { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public ReportesEgresos()
		{
			InitializeComponent();
		}

		private void ConvierteComprobantesIngresoToUSD(List<EntFactura> FacturasIngreso, bool CalculaEquivalencia = false)
		{
			foreach (EntFactura f in FacturasIngreso.Where((EntFactura P) => P.TipoCambio > 1m).ToList())
			{
				f.Total = f.TotalUSD;
				f.Retenciones /= f.TipoCambio;
				f.IVARetenciones /= f.TipoCambio;
				f.ISRRetenciones /= f.TipoCambio;
				f.IVA /= f.TipoCambio;
				f.IEPS /= f.TipoCambio;
				f.Descuento /= f.TipoCambio;
				f.SubTotal /= f.TipoCambio;
				f.ImporteDR /= f.TipoCambio;
				f.ObjetoImpuesto01 /= f.TipoCambio;
				f.ObjetoImpuesto02 /= f.TipoCambio;
				f.ObjetoImpuesto03 /= f.TipoCambio;
				f.ObjetoImpuesto04 /= f.TipoCambio;
			}
		}

		private void CargaComprobantes(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, bool Ingresos, bool CP, bool Nominas, bool NC, bool Canceladas)
		{
			ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta);
			ConvierteComprobantesIngresoToUSD(ListaComprobantes);
			List<EntFactura> lstFiltro = ListaComprobantes;
			if (!Ingresos)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 1).ToList();
			}
			if (!CP)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 5).ToList();
			}
			if (!Nominas)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 4).ToList();
			}
			if (!NC)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 2).ToList();
			}
			if (!Canceladas)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.EstatusId == 1 || P.EstatusId == 5).ToList();
			}
			if (!Ingresos && !CP && !Nominas && !NC && Canceladas)
			{
				lstFiltro = ListaComprobantes.Where((EntFactura P) => P.EstatusId == 2).ToList();
			}
			gvXMLs.DataSource = lstFiltro;
			gvXMLs.Refresh();
			CalculaSumaTotalFromListaProductos(ListaComprobantes, true, tstxtImporte.TextBox, tstxtSubtotal.TextBox, tstxtIVA.TextBox, tstxtNum.TextBox, tstxtNum.TextBox);
		}

		private void CargaComprobantes(List<EntFactura> ListaComprobantes, bool Ingresos, bool CP, bool Nominas, bool NC, bool Canceladas)
		{
			List<EntFactura> lstFiltro = ListaComprobantes.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorRFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			if (!Ingresos)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 1).ToList();
			}
			if (!CP)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 5).ToList();
			}
			if (!Nominas)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 4).ToList();
			}
			if (!NC)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 2).ToList();
			}
			if (!Canceladas)
			{
				lstFiltro = lstFiltro.Where((EntFactura P) => P.EstatusId == 1 || P.EstatusId == 5).ToList();
			}
			if (!Ingresos && !CP && !Nominas && !NC && Canceladas)
			{
				lstFiltro = ListaComprobantes.Where((EntFactura P) => P.EstatusId == 2).ToList();
			}
			gvXMLs.DataSource = lstFiltro;
			gvXMLs.Refresh();
			CalculaSumaTotalFromListaProductos(ListaComprobantes, true, tstxtImporte.TextBox, tstxtSubtotal.TextBox, tstxtIVA.TextBox, tstxtNum.TextBox, tstxtNum.TextBox);
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
			GridViewMuestra.DataSource = ListaComprobantes.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorRFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			GridViewMuestra.Refresh();
			CalculaSumaTotalFromListaProductos(ListaComprobantes, false, TxtMuestraImporte, TxtMuestraSubtotal, TxtMuestraIVA, TxtMuestraNum, TxtMuestraNum);
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, int TipoComprobanteId, bool PUE, bool PPD, int EstatusId, DataGridView GridViewMuestra, TextBox TxtMuestraImporte, TextBox TxtMuestraSubtotal, TextBox TxtMuestraIVA, TextBox TxtMuestraNum, TextBox TxtMuestraImporteUSD, TextBox TxtMuestraSubtotalUSD, TextBox TxtMuestraIVAUSD, TextBox TxtMuestraNumUSD)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			lstFiltro = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == TipoComprobanteId && (P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && (P.EstatusId == EstatusId || P.EstatusId == 5)).ToList();
			GridViewMuestra.DataSource = (from P in lstFiltro
				where P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorRFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtCliente.Text.ToUpper())
				orderby P.Fecha descending
				select P).ToList();
			GridViewMuestra.Refresh();
			CalculaSumaTotalFromListaProductos(lstFiltro.Where((EntFactura P) => P.MonedaId == 1).ToList(), false, TxtMuestraImporte, TxtMuestraSubtotal, TxtMuestraIVA, TxtMuestraNum, TxtMuestraNum);
			CalculaSumaTotalFromListaProductos(lstFiltro.Where((EntFactura P) => P.MonedaId == 2).ToList(), false, TxtMuestraImporteUSD, TxtMuestraSubtotalUSD, TxtMuestraIVAUSD, TxtMuestraNumUSD, TxtMuestraNumUSD);
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, int TipoComprobanteId, int EstatusId, DataGridView GridViewMuestra, TextBox TxtMuestraImporte, TextBox TxtMuestraSubtotal, TextBox TxtMuestraIVA, TextBox TxtMuestraNum)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			lstFiltro = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == TipoComprobanteId && (P.EstatusId == EstatusId || P.EstatusId == 5)).ToList();
			GridViewMuestra.DataSource = lstFiltro.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorRFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			GridViewMuestra.Refresh();
			CalculaSumaTotalFromListaProductos(lstFiltro, false, TxtMuestraImporte, TxtMuestraSubtotal, TxtMuestraIVA, TxtMuestraNum, TxtMuestraNum);
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, int TipoComprobanteId, int EstatusId, DataGridView GridViewMuestra, TextBox TxtMuestraImporte, TextBox TxtMuestraSubtotal, TextBox TxtMuestraIVA, TextBox TxtMuestraNum, TextBox TxtMuestraImporteUSD, TextBox TxtMuestraSubtotalUSD, TextBox TxtMuestraIVAUSD, TextBox TxtMuestraNumUSD)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			lstFiltro = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == TipoComprobanteId && (P.EstatusId == EstatusId || P.EstatusId == 5)).ToList();
			GridViewMuestra.DataSource = lstFiltro.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorRFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtCliente.Text.ToUpper())).ToList();
			GridViewMuestra.Refresh();
			CalculaSumaTotalFromListaProductos(lstFiltro.Where((EntFactura P) => P.MonedaId == 1).ToList(), false, TxtMuestraImporte, TxtMuestraSubtotal, TxtMuestraIVA, TxtMuestraNum, TxtMuestraNum);
			CalculaSumaTotalFromListaProductos(lstFiltro.Where((EntFactura P) => P.MonedaId == 2).ToList(), false, TxtMuestraImporteUSD, TxtMuestraSubtotalUSD, TxtMuestraIVAUSD, TxtMuestraNumUSD, TxtMuestraNumUSD);
		}

		private void EnviarListaFacturasAExcel(string NombreArchivo, List<EntFactura> xmls)
		{
			Microsoft.Office.Interop.Excel.Application xlApp = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
			if (xlApp == null)
			{
				MandaExcepcion("Excel NO esta instalado apropiadamente.");
			}
			decimal iva = default(decimal);
			decimal subtotal;
			decimal total = (subtotal = iva);
			object misValue = Missing.Value;
			Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
			Worksheet xlWorkSheet = (Worksheet)(dynamic)xlWorkBook.Worksheets.get_Item((object)1);
			try
			{
				xlWorkSheet.Cells[1, 1] = "RFC";
				xlWorkSheet.Cells[1, 2] = "NOMBRE";
				xlWorkSheet.Cells[1, 3] = "UUID";
				xlWorkSheet.Cells[1, 4] = "FOLIO";
				xlWorkSheet.Cells[1, 5] = "SUBTOTAL";
				xlWorkSheet.Cells[1, 6] = "IVA";
				xlWorkSheet.Cells[1, 7] = "IVARETENCIONES";
				xlWorkSheet.Cells[1, 8] = "ISRRETENCIONES";
				xlWorkSheet.Cells[1, 9] = "TOTAL";
				xlWorkSheet.Cells[1, 10] = "FECHA";
				xlWorkSheet.Cells[1, 11] = "TIPOCOMPROBANTE";
				xlWorkSheet.Cells[1, 12] = "METODOPAGO";
				xlWorkSheet.Cells[1, 13] = "FORMAPAGO";
				xlWorkSheet.Cells[1, 14] = "UUIDRELACIONADO";
				xlWorkSheet.Cells[1, 15] = "CONCEPTO";
				int ren = 2;
				foreach (EntFactura x in xmls)
				{
					xlWorkSheet.Cells[ren, 1] = x.EmisorRFC;
					xlWorkSheet.Cells[ren, 2] = x.EmisorNombre;
					xlWorkSheet.Cells[ren, 3] = x.UUID;
					xlWorkSheet.Cells[ren, 4] = x.Folio;
					xlWorkSheet.Cells[ren, 5] = x.SubTotal - x.Descuento;
					xlWorkSheet.Cells[ren, 6] = x.IVA;
					xlWorkSheet.Cells[ren, 7] = x.IVARetenciones;
					xlWorkSheet.Cells[ren, 8] = x.ISRRetenciones;
					xlWorkSheet.Cells[ren, 9] = x.Total;
					xlWorkSheet.Cells[ren, 10] = x.Fecha;
					xlWorkSheet.Cells[ren, 11] = x.TipoComprobante;
					xlWorkSheet.Cells[ren, 12] = x.MetodoPago;
					xlWorkSheet.Cells[ren, 13] = x.FormaPago;
					xlWorkSheet.Cells[ren, 14] = x.UUIDrelacionado;
					xlWorkSheet.Cells[ren, 15] = x.Descripcion;
					total += x.Total;
					subtotal += x.SubTotal - x.Descuento;
					iva += x.IVA;
					ren++;
				}
				string rutaExportacion = SeleccionaCarpeta();
				rutaExportacion += $"\\{NombreArchivo} {DateTime.Now:yyyy-MM-dd hhmmss}.xls";
				xlWorkBook.SaveAs(rutaExportacion, XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
				MuestraArchivo(rutaExportacion, true);
			}
			catch (Exception ex)
			{
				MandaExcepcion(ex.Message);
			}
			finally
			{
				xlWorkBook.Close(true, misValue, misValue);
				xlApp.Quit();
				Marshal.ReleaseComObject(xlWorkSheet);
				Marshal.ReleaseComObject(xlWorkBook);
				Marshal.ReleaseComObject(xlApp);
			}
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñoComprobantes);
			cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
			cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
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
				else
				{
					fechaDesde = dtpFechaDesde.Value.Date;
					fechaHasta = dtpFechaHasta.Value.Date;
				}
				CargaComprobantes(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, chkIngresosFiltro.Checked, chkCPFiltro.Checked, chkNominaFiltro.Checked, chkNotasCreditoFiltro.Checked, chkCanceladasFiltro.Checked);
				if (rdoTodas.Checked)
				{
					FiltraComprobantes(ListaComprobantes, 1, 1, gvIngresos, tstImporteIngresos.TextBox, tstSubIngresos.TextBox, tstIvaIngresos.TextBox, tstNumIngresos.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				}
				else
				{
					FiltraComprobantes(ListaComprobantes, 1, rdoPueCP.Checked, rdoPPD.Checked, 1, gvIngresos, tstImporteIngresos.TextBox, tstSubIngresos.TextBox, tstIvaIngresos.TextBox, tstNumIngresos.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				}
				FiltraComprobantes(ListaComprobantes, 5, 1, gvComplementos, tstImporteCP.TextBox, tstSubCP.TextBox, tstIvaCP.TextBox, tstNumCP.TextBox, tstImporteCPUSD.TextBox, tstSubCP.TextBox, tstIvaCP.TextBox, tstNumCPUSD.TextBox);
				FiltraComprobantes(ListaComprobantes, 4, 1, gvNominas, tstImporteNom.TextBox, tstSubNom.TextBox, tstIvaNom.TextBox, tstNumNom.TextBox);
				FiltraComprobantes(ListaComprobantes, 2, 1, gvNotasCredito, tstImporteNC.TextBox, tstSubNC.TextBox, tstIvaNC.TextBox, tstNumNC.TextBox);
				FiltraComprobantes(ListaComprobantes.Where((EntFactura P) => P.EstatusId == 2).ToList(), gvCancelados, tstImporteCancelados.TextBox, tstSubCancelados.TextBox, tstIvaCancelados.TextBox, tstNumCancelados.TextBox);
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
					gvIngresos.DataSource = new List<EntFactura>();
					gvIngresos.Refresh();
					gvComplementos.DataSource = new List<EntFactura>();
					gvComplementos.Refresh();
					gvNominas.DataSource = new List<EntFactura>();
					gvNominas.Refresh();
					gvNotasCredito.DataSource = new List<EntFactura>();
					gvNotasCredito.Refresh();
					gvCancelados.DataSource = new List<EntFactura>();
					gvCancelados.Refresh();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnEnviarAExcelIngresos_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntFactura> xmls = new List<EntFactura>();
				switch (tcReportesIngresos.SelectedIndex)
				{
				case 1:
					xmls = ObtieneListaFacturasFromGV(gvIngresos);
					break;
				case 2:
					xmls = ObtieneListaFacturasFromGV(gvComplementos);
					break;
				case 4:
					xmls = ObtieneListaFacturasFromGV(gvNotasCredito);
					break;
				case 5:
					xmls = ObtieneListaFacturasFromGV(gvCancelados);
					break;
				}
				ImprimeCFDIs vImprime = new ImprimeCFDIs(xmls);
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

		private void btnNoDeducible_Click(object sender, EventArgs e)
		{
			try
			{
				if (MuestraMensajeYesNo("¿Desea marcar como No Deducible el(los) Comprobante(s) Fiscal(es) seleccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvIngresos);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					new BusFacturas().ActualizaComprobanteFiscalEgresosDeducible(f.Id, false);
				}
				MuestraMensaje("¡Comprobante(s) marcado(s) como No Deducible!");
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnDeducible_Click(object sender, EventArgs e)
		{
			try
			{
				if (MuestraMensajeYesNo("¿Desea marcar como Deducible el(los) Comprobante(s) Fiscal(es) seleccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvIngresos);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					new BusFacturas().ActualizaComprobanteFiscalEgresosDeducible(f.Id, true);
				}
				MuestraMensaje("¡Comprobante(s) marcado(s) como Deducible!");
				btnRefrescar.PerformClick();
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
				if (rdoTodas.Checked)
				{
					FiltraComprobantes(ListaComprobantes, 1, 1, gvIngresos, tstImporteIngresos.TextBox, tstSubIngresos.TextBox, tstIvaIngresos.TextBox, tstNumIngresos.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				}
				else
				{
					FiltraComprobantes(ListaComprobantes, 1, rdoPueCP.Checked, rdoPPD.Checked, 1, gvIngresos, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				}
				FiltraComprobantes(ListaComprobantes, 1, 1, gvIngresos, tstImporteIngresos.TextBox, tstSubIngresos.TextBox, tstIvaIngresos.TextBox, tstNumIngresos.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				FiltraComprobantes(ListaComprobantes, 5, 1, gvComplementos, tstImporteCP.TextBox, tstSubCP.TextBox, tstIvaCP.TextBox, tstNumCP.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				FiltraComprobantes(ListaComprobantes, 4, 1, gvNominas, tstImporteNom.TextBox, tstSubNom.TextBox, tstIvaNom.TextBox, tstNumNom.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				FiltraComprobantes(ListaComprobantes, 2, 1, gvNotasCredito, tstImporteNC.TextBox, tstSubNC.TextBox, tstIvaNC.TextBox, tstNumNC.TextBox, tstImporteIngresosUSD.TextBox, tstSubIngresosUSD.TextBox, tstIvaIngresosUSD.TextBox, tstNumIngresosUSD.TextBox);
				FiltraComprobantes(ListaComprobantes.Where((EntFactura P) => P.EstatusId == 2).ToList(), gvCancelados, tstImporteCancelados.TextBox, tstSubCancelados.TextBox, tstIvaCancelados.TextBox, tstNumCancelados.TextBox);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoTodas_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (((RadioButton)sender).Checked)
				{
					btnRefrescar.PerformClick();
				}
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
				pnlPorDiaVentas.Enabled = rdoPorFechasComprobantes.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.ReportesEgresos));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle85 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle86 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle87 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle88 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uUIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.retencionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoCambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TipoComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UUIDrelacionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EstatusDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnlFiltro = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.txtRFCFiltro = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtCliente = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtUUIDfiltro = new System.Windows.Forms.TextBox();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.txtFacturaFiltro = new System.Windows.Forms.TextBox();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tcReportesIngresos = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNum = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIVA = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporte = new System.Windows.Forms.ToolStripTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnMarcarCancelada = new System.Windows.Forms.Button();
			this.btnMarcarVigente = new System.Windows.Forms.Button();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.chkCanceladasFiltro = new System.Windows.Forms.CheckBox();
			this.chkNotasCreditoFiltro = new System.Windows.Forms.CheckBox();
			this.chkNominaFiltro = new System.Windows.Forms.CheckBox();
			this.chkCPFiltro = new System.Windows.Forms.CheckBox();
			this.chkIngresosFiltro = new System.Windows.Forms.CheckBox();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnRevisarAnticiposDepositosPrevios = new System.Windows.Forms.Button();
			this.tpIngresos = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel30 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel25 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumIngresosUSD = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel26 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubIngresosUSD = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel27 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaIngresosUSD = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel28 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteIngresosUSD = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel29 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumIngresos = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubIngresos = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaIngresos = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteIngresos = new System.Windows.Forms.ToolStripTextBox();
			this.gvIngresos = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IEPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Deducible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEnviarAExcelIngresos = new System.Windows.Forms.Button();
			this.btnNoDeducible = new System.Windows.Forms.Button();
			this.btnDeducible = new System.Windows.Forms.Button();
			this.pnlFiltroPUEPPD = new System.Windows.Forms.Panel();
			this.rdoTodas = new System.Windows.Forms.RadioButton();
			this.rdoPPD = new System.Windows.Forms.RadioButton();
			this.rdoPueCP = new System.Windows.Forms.RadioButton();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip8 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel36 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel31 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumCPUSD = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel32 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel33 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel34 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteCPUSD = new System.Windows.Forms.ToolStripTextBox();
			this.gvComplementos = new System.Windows.Forms.DataGridView();
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
			this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn79 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn80 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel35 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteCP = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEnviarAExcelCP = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.gvNominas = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumNom = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubNom = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaNom = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel16 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteNom = new System.Windows.Forms.ToolStripTextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.gvNotasCredito = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn81 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn82 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel17 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumNC = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel18 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubNC = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel19 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaNC = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel20 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteNC = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEnviarAExcelNC = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel21 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel22 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel23 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel24 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteCancelados = new System.Windows.Forms.ToolStripTextBox();
			this.gvCancelados = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEnviarAExcelCanceladas = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.pnlPorDiaVentas = new System.Windows.Forms.Panel();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.rdoPorFechasComprobantes = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			this.gbDatosGenerales.SuspendLayout();
			this.tcReportesIngresos.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.tpIngresos.SuspendLayout();
			this.flowLayoutPanel16.SuspendLayout();
			this.toolStrip7.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvIngresos).BeginInit();
			this.flowLayoutPanel10.SuspendLayout();
			this.pnlFiltroPUEPPD.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.flowLayoutPanel17.SuspendLayout();
			this.toolStrip8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvComplementos).BeginInit();
			this.flowLayoutPanel4.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvNominas).BeginInit();
			this.flowLayoutPanel5.SuspendLayout();
			this.flowLayoutPanel8.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvNotasCredito).BeginInit();
			this.flowLayoutPanel6.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			this.flowLayoutPanel12.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.flowLayoutPanel7.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCancelados).BeginInit();
			this.flowLayoutPanel13.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			this.pnlPorDiaVentas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			base.SuspendLayout();
			this.gvXMLs.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLs.AutoGenerateColumns = false;
			this.gvXMLs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLs.Columns.AddRange(this.rFCDataGridViewTextBoxColumn, this.nombreDataGridViewTextBoxColumn, this.uUIDDataGridViewTextBoxColumn, this.folioDataGridViewTextBoxColumn, this.subTotalDataGridViewTextBoxColumn, this.descuentoDataGridViewTextBoxColumn, this.iVADataGridViewTextBoxColumn, this.retencionesDataGridViewTextBoxColumn, this.totalDataGridViewTextBoxColumn, this.Moneda, this.TipoCambio, this.fechaDataGridViewTextBoxColumn, this.TipoComprobante, this.MetodoPago, this.FormaPago, this.UUIDrelacionado, this.Descripcion, this.EstatusDescripcion);
			this.gvXMLs.DataSource = this.entFacturaBindingSource;
			this.gvXMLs.Location = new System.Drawing.Point(9, 46);
			this.gvXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.ReadOnly = true;
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle12;
			this.gvXMLs.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(1174, 554);
			this.gvXMLs.TabIndex = 14;
			this.rFCDataGridViewTextBoxColumn.DataPropertyName = "EmisorRFC";
			this.rFCDataGridViewTextBoxColumn.FillWeight = 150f;
			this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
			this.rFCDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
			this.rFCDataGridViewTextBoxColumn.ReadOnly = true;
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "EmisorNombre";
			this.nombreDataGridViewTextBoxColumn.FillWeight = 250f;
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
			this.uUIDDataGridViewTextBoxColumn.DataPropertyName = "UUID";
			this.uUIDDataGridViewTextBoxColumn.FillWeight = 200f;
			this.uUIDDataGridViewTextBoxColumn.HeaderText = "UUID";
			this.uUIDDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.uUIDDataGridViewTextBoxColumn.Name = "uUIDDataGridViewTextBoxColumn";
			this.uUIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
			dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.folioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
			this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
			this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
			this.folioDataGridViewTextBoxColumn.ReadOnly = true;
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle14.Format = "c2";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
			dataGridViewCellStyle15.Format = "c2";
			this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
			this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
			this.descuentoDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
			this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.Visible = false;
			this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
			dataGridViewCellStyle16.Format = "c2";
			this.iVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
			this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
			this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
			this.iVADataGridViewTextBoxColumn.ReadOnly = true;
			this.retencionesDataGridViewTextBoxColumn.DataPropertyName = "Retenciones";
			dataGridViewCellStyle17.Format = "c2";
			this.retencionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle17;
			this.retencionesDataGridViewTextBoxColumn.HeaderText = "Retenciones";
			this.retencionesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.retencionesDataGridViewTextBoxColumn.Name = "retencionesDataGridViewTextBoxColumn";
			this.retencionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle18.Format = "c2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.Moneda.DataPropertyName = "Moneda";
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.Moneda.DefaultCellStyle = dataGridViewCellStyle19;
			this.Moneda.FillWeight = 50f;
			this.Moneda.HeaderText = "Moneda";
			this.Moneda.MinimumWidth = 6;
			this.Moneda.Name = "Moneda";
			this.Moneda.ReadOnly = true;
			this.TipoCambio.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle20.Format = "n4";
			this.TipoCambio.DefaultCellStyle = dataGridViewCellStyle20;
			this.TipoCambio.FillWeight = 50f;
			this.TipoCambio.HeaderText = "Tipo Cambio";
			this.TipoCambio.MinimumWidth = 6;
			this.TipoCambio.Name = "TipoCambio";
			this.TipoCambio.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
			this.fechaDataGridViewTextBoxColumn.FillWeight = 80f;
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.TipoComprobante.DataPropertyName = "TipoComprobante";
			this.TipoComprobante.FillWeight = 80f;
			this.TipoComprobante.HeaderText = "Tipo Comprobante";
			this.TipoComprobante.MinimumWidth = 6;
			this.TipoComprobante.Name = "TipoComprobante";
			this.TipoComprobante.ReadOnly = true;
			this.MetodoPago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MetodoPago.DefaultCellStyle = dataGridViewCellStyle22;
			this.MetodoPago.FillWeight = 50f;
			this.MetodoPago.HeaderText = "Metodo Pago";
			this.MetodoPago.MinimumWidth = 6;
			this.MetodoPago.Name = "MetodoPago";
			this.MetodoPago.ReadOnly = true;
			this.FormaPago.DataPropertyName = "FormaPago";
			this.FormaPago.FillWeight = 120f;
			this.FormaPago.HeaderText = "Forma Pago";
			this.FormaPago.MinimumWidth = 6;
			this.FormaPago.Name = "FormaPago";
			this.FormaPago.ReadOnly = true;
			this.UUIDrelacionado.DataPropertyName = "UUIDrelacionado";
			this.UUIDrelacionado.HeaderText = "UUID Relacionado";
			this.UUIDrelacionado.MinimumWidth = 6;
			this.UUIDrelacionado.Name = "UUIDrelacionado";
			this.UUIDrelacionado.ReadOnly = true;
			this.Descripcion.DataPropertyName = "Descripcion";
			this.Descripcion.FillWeight = 120f;
			this.Descripcion.HeaderText = "Concepto";
			this.Descripcion.MinimumWidth = 6;
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			this.EstatusDescripcion.DataPropertyName = "EstatusDescripcion";
			this.EstatusDescripcion.HeaderText = "Estatus";
			this.EstatusDescripcion.MinimumWidth = 6;
			this.EstatusDescripcion.Name = "EstatusDescripcion";
			this.EstatusDescripcion.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 29);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1314, 939);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.pnlFiltro);
			this.tabPage1.Controls.Add(this.gbDatosGenerales);
			this.tabPage1.Controls.Add(this.tcReportesIngresos);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1306, 904);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Comprobantes Fiscales Recibidos";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.pnlFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltro.Controls.Add(this.label8);
			this.pnlFiltro.Controls.Add(this.txtRFCFiltro);
			this.pnlFiltro.Controls.Add(this.label6);
			this.pnlFiltro.Controls.Add(this.txtCliente);
			this.pnlFiltro.Controls.Add(this.label2);
			this.pnlFiltro.Controls.Add(this.txtUUIDfiltro);
			this.pnlFiltro.Controls.Add(this.btnFiltraFacturas);
			this.pnlFiltro.Controls.Add(this.label7);
			this.pnlFiltro.Controls.Add(this.txtFacturaFiltro);
			this.pnlFiltro.Location = new System.Drawing.Point(9, 148);
			this.pnlFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(1255, 47);
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
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(532, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 18);
			this.label2.TabIndex = 133;
			this.label2.Text = "UUID:";
			this.txtUUIDfiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtUUIDfiltro.Location = new System.Drawing.Point(584, 10);
			this.txtUUIDfiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtUUIDfiltro.Name = "txtUUIDfiltro";
			this.txtUUIDfiltro.Size = new System.Drawing.Size(396, 25);
			this.txtUUIDfiltro.TabIndex = 3;
			this.txtUUIDfiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(1190, 0);
			this.btnFiltraFacturas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(58, 42);
			this.btnFiltraFacturas.TabIndex = 6;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(993, 14);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 18);
			this.label7.TabIndex = 97;
			this.label7.Text = "Folio:";
			this.txtFacturaFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtFacturaFiltro.Location = new System.Drawing.Point(1043, 10);
			this.txtFacturaFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(112, 25);
			this.txtFacturaFiltro.TabIndex = 2;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
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
			this.label4.Location = new System.Drawing.Point(19, 31);
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
			this.txtNombreFiscal.Size = new System.Drawing.Size(509, 30);
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
			this.tcReportesIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcReportesIngresos.Controls.Add(this.tabPage2);
			this.tcReportesIngresos.Controls.Add(this.tpIngresos);
			this.tcReportesIngresos.Controls.Add(this.tabPage3);
			this.tcReportesIngresos.Controls.Add(this.tabPage4);
			this.tcReportesIngresos.Controls.Add(this.tabPage5);
			this.tcReportesIngresos.Controls.Add(this.tabPage6);
			this.tcReportesIngresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcReportesIngresos.Location = new System.Drawing.Point(9, 208);
			this.tcReportesIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcReportesIngresos.Name = "tcReportesIngresos";
			this.tcReportesIngresos.SelectedIndex = 0;
			this.tcReportesIngresos.Size = new System.Drawing.Size(1300, 683);
			this.tcReportesIngresos.TabIndex = 136;
			this.tabPage2.Controls.Add(this.flpTotalesTodos);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.textBox1);
			this.tabPage2.Controls.Add(this.gvXMLs);
			this.tabPage2.Controls.Add(this.flowLayoutPanel1);
			this.tabPage2.Controls.Add(this.flowLayoutPanel2);
			this.tabPage2.Controls.Add(this.flowLayoutPanel14);
			this.tabPage2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage2.Location = new System.Drawing.Point(4, 31);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Size = new System.Drawing.Size(1292, 648);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Todos";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(884, 601);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(1);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(299, 36);
			this.flpTotalesTodos.TabIndex = 135;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[9] { this.toolStripLabel3, this.tstxtNum, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotal, this.toolStripLabel1, this.tstxtIVA, this.toolStripLabel2, this.tstxtImporte });
			this.toolStrip1.Location = new System.Drawing.Point(0, 1);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(251, 31);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel3.Text = "Núm Comprobantes:";
			this.tstxtNum.Font = new System.Drawing.Font("Segoe UI", 9f);
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
			this.tstxtSubtotal.Name = "tstxtSubtotal";
			this.tstxtSubtotal.ReadOnly = true;
			this.tstxtSubtotal.Size = new System.Drawing.Size(82, 31);
			this.tstxtSubtotal.Visible = false;
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel1.Text = "I.V.A:";
			this.toolStripLabel1.Visible = false;
			this.tstxtIVA.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIVA.Name = "tstxtIVA";
			this.tstxtIVA.ReadOnly = true;
			this.tstxtIVA.Size = new System.Drawing.Size(82, 31);
			this.tstxtIVA.Visible = false;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(80, 25);
			this.toolStripLabel2.Text = "Importe:";
			this.toolStripLabel2.Visible = false;
			this.tstxtImporte.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporte.Name = "tstxtImporte";
			this.tstxtImporte.ReadOnly = true;
			this.tstxtImporte.Size = new System.Drawing.Size(82, 31);
			this.tstxtImporte.Visible = false;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1583, 939);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 18);
			this.label1.TabIndex = 128;
			this.label1.Text = "Cantidad:";
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(1655, 932);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(80, 25);
			this.textBox1.TabIndex = 127;
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.btnMarcarCancelada);
			this.flowLayoutPanel1.Controls.Add(this.btnMarcarVigente);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1180, 40);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(120, 268);
			this.flowLayoutPanel1.TabIndex = 134;
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
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.chkCanceladasFiltro);
			this.flowLayoutPanel2.Controls.Add(this.chkNotasCreditoFiltro);
			this.flowLayoutPanel2.Controls.Add(this.chkNominaFiltro);
			this.flowLayoutPanel2.Controls.Add(this.chkCPFiltro);
			this.flowLayoutPanel2.Controls.Add(this.chkIngresosFiltro);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(333, 1);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(6, 8, 0, 0);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(851, 43);
			this.flowLayoutPanel2.TabIndex = 136;
			this.chkCanceladasFiltro.AutoSize = true;
			this.chkCanceladasFiltro.Location = new System.Drawing.Point(716, 9);
			this.chkCanceladasFiltro.Margin = new System.Windows.Forms.Padding(1);
			this.chkCanceladasFiltro.Name = "chkCanceladasFiltro";
			this.chkCanceladasFiltro.Size = new System.Drawing.Size(126, 22);
			this.chkCanceladasFiltro.TabIndex = 4;
			this.chkCanceladasFiltro.Text = "Cancelados - C";
			this.chkCanceladasFiltro.UseVisualStyleBackColor = true;
			this.chkCanceladasFiltro.CheckedChanged += new System.EventHandler(btnRefrescar_Click);
			this.chkNotasCreditoFiltro.AutoSize = true;
			this.chkNotasCreditoFiltro.Checked = true;
			this.chkNotasCreditoFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkNotasCreditoFiltro.Location = new System.Drawing.Point(612, 9);
			this.chkNotasCreditoFiltro.Margin = new System.Windows.Forms.Padding(1);
			this.chkNotasCreditoFiltro.Name = "chkNotasCreditoFiltro";
			this.chkNotasCreditoFiltro.Size = new System.Drawing.Size(102, 22);
			this.chkNotasCreditoFiltro.TabIndex = 3;
			this.chkNotasCreditoFiltro.Text = "Egresos - E";
			this.chkNotasCreditoFiltro.UseVisualStyleBackColor = true;
			this.chkNotasCreditoFiltro.CheckedChanged += new System.EventHandler(btnRefrescar_Click);
			this.chkNominaFiltro.AutoSize = true;
			this.chkNominaFiltro.Checked = true;
			this.chkNominaFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkNominaFiltro.Location = new System.Drawing.Point(498, 9);
			this.chkNominaFiltro.Margin = new System.Windows.Forms.Padding(1);
			this.chkNominaFiltro.Name = "chkNominaFiltro";
			this.chkNominaFiltro.Size = new System.Drawing.Size(112, 22);
			this.chkNominaFiltro.TabIndex = 2;
			this.chkNominaFiltro.Text = "Nóminas - N";
			this.chkNominaFiltro.UseVisualStyleBackColor = true;
			this.chkNominaFiltro.CheckedChanged += new System.EventHandler(btnRefrescar_Click);
			this.chkCPFiltro.AutoSize = true;
			this.chkCPFiltro.Checked = true;
			this.chkCPFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCPFiltro.Location = new System.Drawing.Point(318, 9);
			this.chkCPFiltro.Margin = new System.Windows.Forms.Padding(1);
			this.chkCPFiltro.Name = "chkCPFiltro";
			this.chkCPFiltro.Size = new System.Drawing.Size(178, 22);
			this.chkCPFiltro.TabIndex = 1;
			this.chkCPFiltro.Text = "Complemento Pago - P";
			this.chkCPFiltro.UseVisualStyleBackColor = true;
			this.chkCPFiltro.CheckedChanged += new System.EventHandler(btnRefrescar_Click);
			this.chkIngresosFiltro.AutoSize = true;
			this.chkIngresosFiltro.Checked = true;
			this.chkIngresosFiltro.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkIngresosFiltro.Location = new System.Drawing.Point(212, 9);
			this.chkIngresosFiltro.Margin = new System.Windows.Forms.Padding(1);
			this.chkIngresosFiltro.Name = "chkIngresosFiltro";
			this.chkIngresosFiltro.Size = new System.Drawing.Size(104, 22);
			this.chkIngresosFiltro.TabIndex = 0;
			this.chkIngresosFiltro.Text = "Ingresos - I";
			this.chkIngresosFiltro.UseVisualStyleBackColor = true;
			this.chkIngresosFiltro.CheckedChanged += new System.EventHandler(btnRefrescar_Click);
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.Controls.Add(this.btnRevisarAnticiposDepositosPrevios);
			this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.flowLayoutPanel14.Location = new System.Drawing.Point(1180, 393);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Size = new System.Drawing.Size(120, 208);
			this.flowLayoutPanel14.TabIndex = 137;
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
			this.tpIngresos.Controls.Add(this.flowLayoutPanel16);
			this.tpIngresos.Controls.Add(this.flowLayoutPanel3);
			this.tpIngresos.Controls.Add(this.gvIngresos);
			this.tpIngresos.Controls.Add(this.flowLayoutPanel10);
			this.tpIngresos.Controls.Add(this.pnlFiltroPUEPPD);
			this.tpIngresos.Location = new System.Drawing.Point(4, 31);
			this.tpIngresos.Margin = new System.Windows.Forms.Padding(1);
			this.tpIngresos.Name = "tpIngresos";
			this.tpIngresos.Padding = new System.Windows.Forms.Padding(1);
			this.tpIngresos.Size = new System.Drawing.Size(1292, 648);
			this.tpIngresos.TabIndex = 1;
			this.tpIngresos.Text = "Ingresos - I";
			this.tpIngresos.UseVisualStyleBackColor = true;
			this.flowLayoutPanel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel16.Controls.Add(this.toolStrip7);
			this.flowLayoutPanel16.Location = new System.Drawing.Point(144, 603);
			this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel16.Name = "flowLayoutPanel16";
			this.flowLayoutPanel16.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel16.Size = new System.Drawing.Size(1039, 36);
			this.flowLayoutPanel16.TabIndex = 141;
			this.toolStrip7.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				this.toolStripLabel30, this.toolStripLabel25, this.tstNumIngresosUSD, this.toolStripSeparator1, this.toolStripLabel26, this.tstSubIngresosUSD, this.toolStripSeparator2, this.toolStripLabel27, this.tstIvaIngresosUSD, this.toolStripSeparator3,
				this.toolStripLabel28, this.tstImporteIngresosUSD
			});
			this.toolStrip7.Location = new System.Drawing.Point(0, 1);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip7.Size = new System.Drawing.Size(850, 31);
			this.toolStrip7.TabIndex = 2;
			this.toolStrip7.Text = "toolStrip7";
			this.toolStripLabel30.Name = "toolStripLabel30";
			this.toolStripLabel30.Size = new System.Drawing.Size(59, 26);
			this.toolStripLabel30.Text = "USD -";
			this.toolStripLabel25.Name = "toolStripLabel25";
			this.toolStripLabel25.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel25.Text = "Núm Comprobantes:";
			this.tstNumIngresosUSD.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumIngresosUSD.Name = "tstNumIngresosUSD";
			this.tstNumIngresosUSD.ReadOnly = true;
			this.tstNumIngresosUSD.Size = new System.Drawing.Size(67, 31);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel26.Name = "toolStripLabel26";
			this.toolStripLabel26.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel26.Text = "Base:";
			this.tstSubIngresosUSD.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubIngresosUSD.Name = "tstSubIngresosUSD";
			this.tstSubIngresosUSD.ReadOnly = true;
			this.tstSubIngresosUSD.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel27.Name = "toolStripLabel27";
			this.toolStripLabel27.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel27.Text = "I.V.A:";
			this.tstIvaIngresosUSD.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaIngresosUSD.Name = "tstIvaIngresosUSD";
			this.tstIvaIngresosUSD.ReadOnly = true;
			this.tstIvaIngresosUSD.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel28.Name = "toolStripLabel28";
			this.toolStripLabel28.Size = new System.Drawing.Size(80, 26);
			this.toolStripLabel28.Text = "Importe:";
			this.tstImporteIngresosUSD.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteIngresosUSD.Name = "tstImporteIngresosUSD";
			this.tstImporteIngresosUSD.ReadOnly = true;
			this.tstImporteIngresosUSD.Size = new System.Drawing.Size(69, 31);
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel3.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(144, 564);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel3.Size = new System.Drawing.Size(1039, 36);
			this.flowLayoutPanel3.TabIndex = 137;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				this.toolStripLabel29, this.toolStripLabel5, this.tstNumIngresos, this.toolStripSeparator5, this.toolStripLabel6, this.tstSubIngresos, this.toolStripSeparator6, this.toolStripLabel7, this.tstIvaIngresos, this.toolStripSeparator7,
				this.toolStripLabel8, this.tstImporteIngresos
			});
			this.toolStrip2.Location = new System.Drawing.Point(0, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(878, 31);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel29.Name = "toolStripLabel29";
			this.toolStripLabel29.Size = new System.Drawing.Size(64, 26);
			this.toolStripLabel29.Text = "MXN -";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel5.Text = "Núm Comprobantes:";
			this.tstNumIngresos.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumIngresos.Name = "tstNumIngresos";
			this.tstNumIngresos.ReadOnly = true;
			this.tstNumIngresos.Size = new System.Drawing.Size(67, 31);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel6.Text = "Base:";
			this.tstSubIngresos.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubIngresos.Name = "tstSubIngresos";
			this.tstSubIngresos.ReadOnly = true;
			this.tstSubIngresos.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(52, 26);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tstIvaIngresos.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaIngresos.Name = "tstIvaIngresos";
			this.tstIvaIngresos.ReadOnly = true;
			this.tstIvaIngresos.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(80, 26);
			this.toolStripLabel8.Text = "Importe:";
			this.tstImporteIngresos.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteIngresos.Name = "tstImporteIngresos";
			this.tstImporteIngresos.ReadOnly = true;
			this.tstImporteIngresos.Size = new System.Drawing.Size(92, 31);
			this.gvIngresos.AllowUserToAddRows = false;
			dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle23.ForeColor = System.Drawing.Color.Black;
			this.gvIngresos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle23;
			this.gvIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvIngresos.AutoGenerateColumns = false;
			this.gvIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvIngresos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvIngresos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvIngresos.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.SubTotal, this.dataGridViewTextBoxColumn7, this.IEPS, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn77, this.dataGridViewTextBoxColumn78, this.Deducible);
			this.gvIngresos.DataSource = this.entFacturaBindingSource;
			this.gvIngresos.Location = new System.Drawing.Point(0, 45);
			this.gvIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvIngresos.Name = "gvIngresos";
			this.gvIngresos.ReadOnly = true;
			this.gvIngresos.RowHeadersVisible = false;
			this.gvIngresos.RowHeadersWidth = 51;
			dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
			this.gvIngresos.RowsDefaultCellStyle = dataGridViewCellStyle29;
			this.gvIngresos.RowTemplate.Height = 30;
			this.gvIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvIngresos.Size = new System.Drawing.Size(1186, 518);
			this.gvIngresos.TabIndex = 136;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "EmisorRFC";
			dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle30;
			this.dataGridViewTextBoxColumn1.FillWeight = 150f;
			this.dataGridViewTextBoxColumn1.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "EmisorNombre";
			dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle31;
			this.dataGridViewTextBoxColumn2.FillWeight = 200f;
			this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn3.FillWeight = 200f;
			this.dataGridViewTextBoxColumn3.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Folio";
			dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle32;
			this.dataGridViewTextBoxColumn4.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "ImporteDR";
			dataGridViewCellStyle33.Format = "c2";
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle33;
			this.dataGridViewTextBoxColumn5.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Descuento";
			dataGridViewCellStyle34.Format = "c2";
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle34;
			this.dataGridViewTextBoxColumn6.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.SubTotal.DataPropertyName = "SubTotal";
			dataGridViewCellStyle35.Format = "c2";
			this.SubTotal.DefaultCellStyle = dataGridViewCellStyle35;
			this.SubTotal.HeaderText = "Base";
			this.SubTotal.MinimumWidth = 6;
			this.SubTotal.Name = "SubTotal";
			this.SubTotal.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "IVA";
			dataGridViewCellStyle36.Format = "c2";
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle36;
			this.dataGridViewTextBoxColumn7.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.IEPS.DataPropertyName = "IEPS";
			dataGridViewCellStyle37.Format = "c2";
			this.IEPS.DefaultCellStyle = dataGridViewCellStyle37;
			this.IEPS.HeaderText = "IEPS";
			this.IEPS.MinimumWidth = 6;
			this.IEPS.Name = "IEPS";
			this.IEPS.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "Retenciones";
			dataGridViewCellStyle38.Format = "c2";
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle38;
			this.dataGridViewTextBoxColumn8.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "Total";
			dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle39.Format = "c2";
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle39;
			this.dataGridViewTextBoxColumn9.HeaderText = "Total";
			this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "Moneda";
			dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle40;
			this.dataGridViewTextBoxColumn10.FillWeight = 80f;
			this.dataGridViewTextBoxColumn10.HeaderText = "Moneda";
			this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle41.Format = "n4";
			this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle41;
			this.dataGridViewTextBoxColumn11.FillWeight = 80f;
			this.dataGridViewTextBoxColumn11.HeaderText = "Tipo Cambio";
			this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn11.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Fecha";
			dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle42;
			this.dataGridViewTextBoxColumn12.FillWeight = 120f;
			this.dataGridViewTextBoxColumn12.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn12.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "TipoComprobante";
			dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle43;
			this.dataGridViewTextBoxColumn13.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.dataGridViewTextBoxColumn14.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle44;
			this.dataGridViewTextBoxColumn14.HeaderText = "Metodo Pago";
			this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn15.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn77.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn77.HeaderText = "UUID Relacionado";
			this.dataGridViewTextBoxColumn77.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
			this.dataGridViewTextBoxColumn77.ReadOnly = true;
			this.dataGridViewTextBoxColumn78.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn78.FillWeight = 120f;
			this.dataGridViewTextBoxColumn78.HeaderText = "Concepto";
			this.dataGridViewTextBoxColumn78.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
			this.dataGridViewTextBoxColumn78.ReadOnly = true;
			this.Deducible.DataPropertyName = "Deducible";
			this.Deducible.FillWeight = 50f;
			this.Deducible.HeaderText = "Deducible";
			this.Deducible.MinimumWidth = 6;
			this.Deducible.Name = "Deducible";
			this.Deducible.ReadOnly = true;
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.Controls.Add(this.btnEnviarAExcelIngresos);
			this.flowLayoutPanel10.Controls.Add(this.btnNoDeducible);
			this.flowLayoutPanel10.Controls.Add(this.btnDeducible);
			this.flowLayoutPanel10.Location = new System.Drawing.Point(1182, 39);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Size = new System.Drawing.Size(120, 372);
			this.flowLayoutPanel10.TabIndex = 138;
			this.btnEnviarAExcelIngresos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcelIngresos.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcelIngresos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcelIngresos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcelIngresos.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcelIngresos.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcelIngresos.Location = new System.Drawing.Point(4, 5);
			this.btnEnviarAExcelIngresos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEnviarAExcelIngresos.Name = "btnEnviarAExcelIngresos";
			this.btnEnviarAExcelIngresos.Size = new System.Drawing.Size(105, 105);
			this.btnEnviarAExcelIngresos.TabIndex = 133;
			this.btnEnviarAExcelIngresos.Text = "Enviar a Excel";
			this.btnEnviarAExcelIngresos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcelIngresos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcelIngresos.UseVisualStyleBackColor = false;
			this.btnEnviarAExcelIngresos.Click += new System.EventHandler(btnEnviarAExcelIngresos_Click);
			this.btnNoDeducible.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnNoDeducible.BackColor = System.Drawing.Color.White;
			this.btnNoDeducible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnNoDeducible.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnNoDeducible.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnNoDeducible.Image = LeeXML.Properties.Resources.X;
			this.btnNoDeducible.Location = new System.Drawing.Point(4, 120);
			this.btnNoDeducible.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnNoDeducible.Name = "btnNoDeducible";
			this.btnNoDeducible.Size = new System.Drawing.Size(105, 105);
			this.btnNoDeducible.TabIndex = 134;
			this.btnNoDeducible.Text = "No Deducible";
			this.btnNoDeducible.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnNoDeducible.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnNoDeducible.UseVisualStyleBackColor = false;
			this.btnNoDeducible.Click += new System.EventHandler(btnNoDeducible_Click);
			this.btnDeducible.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnDeducible.BackColor = System.Drawing.Color.White;
			this.btnDeducible.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnDeducible.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDeducible.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnDeducible.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnDeducible.Location = new System.Drawing.Point(4, 235);
			this.btnDeducible.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnDeducible.Name = "btnDeducible";
			this.btnDeducible.Size = new System.Drawing.Size(105, 105);
			this.btnDeducible.TabIndex = 135;
			this.btnDeducible.Text = "Deducible";
			this.btnDeducible.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnDeducible.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDeducible.UseVisualStyleBackColor = false;
			this.btnDeducible.Click += new System.EventHandler(btnDeducible_Click);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoTodas);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoPPD);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoPueCP);
			this.pnlFiltroPUEPPD.Location = new System.Drawing.Point(0, 1);
			this.pnlFiltroPUEPPD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFiltroPUEPPD.Name = "pnlFiltroPUEPPD";
			this.pnlFiltroPUEPPD.Size = new System.Drawing.Size(820, 48);
			this.pnlFiltroPUEPPD.TabIndex = 140;
			this.rdoTodas.AutoSize = true;
			this.rdoTodas.Checked = true;
			this.rdoTodas.Location = new System.Drawing.Point(15, 10);
			this.rdoTodas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoTodas.Name = "rdoTodas";
			this.rdoTodas.Size = new System.Drawing.Size(80, 26);
			this.rdoTodas.TabIndex = 4;
			this.rdoTodas.TabStop = true;
			this.rdoTodas.Tag = "0";
			this.rdoTodas.Text = "Todas";
			this.rdoTodas.UseVisualStyleBackColor = true;
			this.rdoTodas.CheckedChanged += new System.EventHandler(rdoTodas_CheckedChanged);
			this.rdoPPD.AutoSize = true;
			this.rdoPPD.Location = new System.Drawing.Point(315, 10);
			this.rdoPPD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoPPD.Name = "rdoPPD";
			this.rdoPPD.Size = new System.Drawing.Size(67, 26);
			this.rdoPPD.TabIndex = 1;
			this.rdoPPD.Tag = "2";
			this.rdoPPD.Text = "PPD";
			this.rdoPPD.UseVisualStyleBackColor = true;
			this.rdoPPD.CheckedChanged += new System.EventHandler(rdoTodas_CheckedChanged);
			this.rdoPueCP.AutoSize = true;
			this.rdoPueCP.Location = new System.Drawing.Point(159, 10);
			this.rdoPueCP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.rdoPueCP.Name = "rdoPueCP";
			this.rdoPueCP.Size = new System.Drawing.Size(66, 26);
			this.rdoPueCP.TabIndex = 0;
			this.rdoPueCP.Tag = "1";
			this.rdoPueCP.Text = "PUE";
			this.rdoPueCP.UseVisualStyleBackColor = true;
			this.rdoPueCP.CheckedChanged += new System.EventHandler(rdoTodas_CheckedChanged);
			this.tabPage3.Controls.Add(this.flowLayoutPanel17);
			this.tabPage3.Controls.Add(this.gvComplementos);
			this.tabPage3.Controls.Add(this.flowLayoutPanel4);
			this.tabPage3.Controls.Add(this.flowLayoutPanel11);
			this.tabPage3.Location = new System.Drawing.Point(4, 31);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage3.Size = new System.Drawing.Size(1292, 648);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Complementos Pago - P";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.flowLayoutPanel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel17.Controls.Add(this.toolStrip8);
			this.flowLayoutPanel17.Location = new System.Drawing.Point(643, 603);
			this.flowLayoutPanel17.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel17.Name = "flowLayoutPanel17";
			this.flowLayoutPanel17.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel17.Size = new System.Drawing.Size(542, 36);
			this.flowLayoutPanel17.TabIndex = 142;
			this.toolStrip8.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				this.toolStripLabel36, this.toolStripLabel31, this.tstNumCPUSD, this.toolStripSeparator8, this.toolStripLabel32, this.toolStripTextBox2, this.toolStripSeparator12, this.toolStripLabel33, this.toolStripTextBox3, this.toolStripSeparator16,
				this.toolStripLabel34, this.tstImporteCPUSD
			});
			this.toolStrip8.Location = new System.Drawing.Point(0, 1);
			this.toolStrip8.Name = "toolStrip8";
			this.toolStrip8.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip8.Size = new System.Drawing.Size(470, 31);
			this.toolStrip8.TabIndex = 2;
			this.toolStrip8.Text = "toolStrip8";
			this.toolStripLabel36.Name = "toolStripLabel36";
			this.toolStripLabel36.Size = new System.Drawing.Size(59, 26);
			this.toolStripLabel36.Text = "USD -";
			this.toolStripLabel31.Name = "toolStripLabel31";
			this.toolStripLabel31.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel31.Text = "Núm Comprobantes:";
			this.tstNumCPUSD.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumCPUSD.Name = "tstNumCPUSD";
			this.tstNumCPUSD.ReadOnly = true;
			this.tstNumCPUSD.Size = new System.Drawing.Size(67, 31);
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel32.Name = "toolStripLabel32";
			this.toolStripLabel32.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel32.Text = "SubTotal:";
			this.toolStripLabel32.Visible = false;
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(82, 33);
			this.toolStripTextBox2.Visible = false;
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator12.Visible = false;
			this.toolStripLabel33.Name = "toolStripLabel33";
			this.toolStripLabel33.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel33.Text = "I.V.A:";
			this.toolStripLabel33.Visible = false;
			this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox3.Name = "toolStripTextBox3";
			this.toolStripTextBox3.ReadOnly = true;
			this.toolStripTextBox3.Size = new System.Drawing.Size(108, 33);
			this.toolStripTextBox3.Visible = false;
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 31);
			this.toolStripSeparator16.Visible = false;
			this.toolStripLabel34.Name = "toolStripLabel34";
			this.toolStripLabel34.Size = new System.Drawing.Size(53, 26);
			this.toolStripLabel34.Text = "Total:";
			this.tstImporteCPUSD.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteCPUSD.Name = "tstImporteCPUSD";
			this.tstImporteCPUSD.ReadOnly = true;
			this.tstImporteCPUSD.Size = new System.Drawing.Size(82, 31);
			this.gvComplementos.AllowUserToAddRows = false;
			dataGridViewCellStyle45.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle45.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle45.ForeColor = System.Drawing.Color.Black;
			this.gvComplementos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle45;
			this.gvComplementos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvComplementos.AutoGenerateColumns = false;
			this.gvComplementos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvComplementos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvComplementos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvComplementos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvComplementos.Columns.AddRange(this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.dataGridViewTextBoxColumn18, this.dataGridViewTextBoxColumn19, this.dataGridViewTextBoxColumn20, this.dataGridViewTextBoxColumn21, this.dataGridViewTextBoxColumn22, this.dataGridViewTextBoxColumn23, this.dataGridViewTextBoxColumn24, this.dataGridViewTextBoxColumn25, this.dataGridViewTextBoxColumn26, this.dataGridViewTextBoxColumn27, this.dataGridViewTextBoxColumn28, this.dataGridViewTextBoxColumn29, this.dataGridViewTextBoxColumn30, this.dataGridViewTextBoxColumn79, this.dataGridViewTextBoxColumn80, this.dataGridViewCheckBoxColumn1);
			this.gvComplementos.DataSource = this.entFacturaBindingSource;
			this.gvComplementos.Location = new System.Drawing.Point(0, 45);
			this.gvComplementos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvComplementos.Name = "gvComplementos";
			this.gvComplementos.ReadOnly = true;
			this.gvComplementos.RowHeadersVisible = false;
			this.gvComplementos.RowHeadersWidth = 51;
			dataGridViewCellStyle46.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle46.ForeColor = System.Drawing.Color.Black;
			this.gvComplementos.RowsDefaultCellStyle = dataGridViewCellStyle46;
			this.gvComplementos.RowTemplate.Height = 30;
			this.gvComplementos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvComplementos.Size = new System.Drawing.Size(1186, 519);
			this.gvComplementos.TabIndex = 138;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn16.FillWeight = 150f;
			this.dataGridViewTextBoxColumn16.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn17.FillWeight = 250f;
			this.dataGridViewTextBoxColumn17.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			this.dataGridViewTextBoxColumn18.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn18.FillWeight = 250f;
			this.dataGridViewTextBoxColumn18.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn18.ReadOnly = true;
			this.dataGridViewTextBoxColumn19.DataPropertyName = "Folio";
			dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle47;
			this.dataGridViewTextBoxColumn19.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
			this.dataGridViewTextBoxColumn19.ReadOnly = true;
			this.dataGridViewTextBoxColumn20.DataPropertyName = "SubTotal";
			dataGridViewCellStyle48.Format = "c2";
			this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle48;
			this.dataGridViewTextBoxColumn20.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
			this.dataGridViewTextBoxColumn20.ReadOnly = true;
			this.dataGridViewTextBoxColumn20.Visible = false;
			this.dataGridViewTextBoxColumn21.DataPropertyName = "Descuento";
			dataGridViewCellStyle49.Format = "c2";
			this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle49;
			this.dataGridViewTextBoxColumn21.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn21.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
			this.dataGridViewTextBoxColumn21.ReadOnly = true;
			this.dataGridViewTextBoxColumn21.Visible = false;
			this.dataGridViewTextBoxColumn22.DataPropertyName = "IVA";
			dataGridViewCellStyle50.Format = "c2";
			this.dataGridViewTextBoxColumn22.DefaultCellStyle = dataGridViewCellStyle50;
			this.dataGridViewTextBoxColumn22.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn22.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
			this.dataGridViewTextBoxColumn22.ReadOnly = true;
			this.dataGridViewTextBoxColumn22.Visible = false;
			this.dataGridViewTextBoxColumn23.DataPropertyName = "Retenciones";
			dataGridViewCellStyle51.Format = "c2";
			this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle51;
			this.dataGridViewTextBoxColumn23.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn23.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
			this.dataGridViewTextBoxColumn23.ReadOnly = true;
			this.dataGridViewTextBoxColumn23.Visible = false;
			this.dataGridViewTextBoxColumn24.DataPropertyName = "Total";
			dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle52.Format = "c2";
			this.dataGridViewTextBoxColumn24.DefaultCellStyle = dataGridViewCellStyle52;
			this.dataGridViewTextBoxColumn24.HeaderText = "Total";
			this.dataGridViewTextBoxColumn24.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
			this.dataGridViewTextBoxColumn24.ReadOnly = true;
			this.dataGridViewTextBoxColumn25.DataPropertyName = "Moneda";
			dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn25.DefaultCellStyle = dataGridViewCellStyle53;
			this.dataGridViewTextBoxColumn25.FillWeight = 80f;
			this.dataGridViewTextBoxColumn25.HeaderText = "Moneda";
			this.dataGridViewTextBoxColumn25.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
			this.dataGridViewTextBoxColumn25.ReadOnly = true;
			this.dataGridViewTextBoxColumn26.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle54.Format = "n4";
			this.dataGridViewTextBoxColumn26.DefaultCellStyle = dataGridViewCellStyle54;
			this.dataGridViewTextBoxColumn26.FillWeight = 80f;
			this.dataGridViewTextBoxColumn26.HeaderText = "Tipo Cambio";
			this.dataGridViewTextBoxColumn26.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
			this.dataGridViewTextBoxColumn26.ReadOnly = true;
			this.dataGridViewTextBoxColumn27.DataPropertyName = "Fecha";
			dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn27.DefaultCellStyle = dataGridViewCellStyle55;
			this.dataGridViewTextBoxColumn27.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn27.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
			this.dataGridViewTextBoxColumn27.ReadOnly = true;
			this.dataGridViewTextBoxColumn28.DataPropertyName = "TipoComprobante";
			dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn28.DefaultCellStyle = dataGridViewCellStyle56;
			this.dataGridViewTextBoxColumn28.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn28.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
			this.dataGridViewTextBoxColumn28.ReadOnly = true;
			this.dataGridViewTextBoxColumn29.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn29.DefaultCellStyle = dataGridViewCellStyle57;
			this.dataGridViewTextBoxColumn29.FillWeight = 80f;
			this.dataGridViewTextBoxColumn29.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn29.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
			this.dataGridViewTextBoxColumn29.ReadOnly = true;
			this.dataGridViewTextBoxColumn30.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn30.FillWeight = 120f;
			this.dataGridViewTextBoxColumn30.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn30.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
			this.dataGridViewTextBoxColumn30.ReadOnly = true;
			this.dataGridViewTextBoxColumn79.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn79.HeaderText = "UUID Relacionado";
			this.dataGridViewTextBoxColumn79.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn79.Name = "dataGridViewTextBoxColumn79";
			this.dataGridViewTextBoxColumn79.ReadOnly = true;
			this.dataGridViewTextBoxColumn80.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn80.HeaderText = "Concepto";
			this.dataGridViewTextBoxColumn80.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn80.Name = "dataGridViewTextBoxColumn80";
			this.dataGridViewTextBoxColumn80.ReadOnly = true;
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "Deducible";
			this.dataGridViewCheckBoxColumn1.FillWeight = 50f;
			this.dataGridViewCheckBoxColumn1.HeaderText = "Deducible";
			this.dataGridViewCheckBoxColumn1.MinimumWidth = 6;
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.ReadOnly = true;
			this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel4.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel4.Location = new System.Drawing.Point(643, 565);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel4.Size = new System.Drawing.Size(542, 36);
			this.flowLayoutPanel4.TabIndex = 139;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[12]
			{
				this.toolStripLabel35, this.toolStripLabel9, this.tstNumCP, this.toolStripSeparator9, this.toolStripLabel10, this.tstSubCP, this.toolStripSeparator10, this.toolStripLabel11, this.tstIvaCP, this.toolStripSeparator11,
				this.toolStripLabel12, this.tstImporteCP
			});
			this.toolStrip3.Location = new System.Drawing.Point(0, 1);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip3.Size = new System.Drawing.Size(475, 31);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStripLabel35.Name = "toolStripLabel35";
			this.toolStripLabel35.Size = new System.Drawing.Size(64, 26);
			this.toolStripLabel35.Text = "MXN -";
			this.toolStripLabel9.Name = "toolStripLabel9";
			this.toolStripLabel9.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel9.Text = "Núm Comprobantes:";
			this.tstNumCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumCP.Name = "tstNumCP";
			this.tstNumCP.ReadOnly = true;
			this.tstNumCP.Size = new System.Drawing.Size(67, 31);
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel10.Name = "toolStripLabel10";
			this.toolStripLabel10.Size = new System.Drawing.Size(84, 28);
			this.toolStripLabel10.Text = "SubTotal:";
			this.toolStripLabel10.Visible = false;
			this.tstSubCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubCP.Name = "tstSubCP";
			this.tstSubCP.ReadOnly = true;
			this.tstSubCP.Size = new System.Drawing.Size(108, 33);
			this.tstSubCP.Visible = false;
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator10.Visible = false;
			this.toolStripLabel11.Name = "toolStripLabel11";
			this.toolStripLabel11.Size = new System.Drawing.Size(52, 28);
			this.toolStripLabel11.Text = "I.V.A:";
			this.toolStripLabel11.Visible = false;
			this.tstIvaCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaCP.Name = "tstIvaCP";
			this.tstIvaCP.ReadOnly = true;
			this.tstIvaCP.Size = new System.Drawing.Size(108, 33);
			this.tstIvaCP.Visible = false;
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 31);
			this.toolStripSeparator11.Visible = false;
			this.toolStripLabel12.Name = "toolStripLabel12";
			this.toolStripLabel12.Size = new System.Drawing.Size(53, 26);
			this.toolStripLabel12.Text = "Total:";
			this.tstImporteCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteCP.Name = "tstImporteCP";
			this.tstImporteCP.ReadOnly = true;
			this.tstImporteCP.Size = new System.Drawing.Size(82, 31);
			this.flowLayoutPanel11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel11.Controls.Add(this.btnEnviarAExcelCP);
			this.flowLayoutPanel11.Location = new System.Drawing.Point(1182, 39);
			this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel11.Name = "flowLayoutPanel11";
			this.flowLayoutPanel11.Size = new System.Drawing.Size(120, 300);
			this.flowLayoutPanel11.TabIndex = 140;
			this.btnEnviarAExcelCP.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcelCP.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcelCP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcelCP.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcelCP.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcelCP.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcelCP.Location = new System.Drawing.Point(4, 5);
			this.btnEnviarAExcelCP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEnviarAExcelCP.Name = "btnEnviarAExcelCP";
			this.btnEnviarAExcelCP.Size = new System.Drawing.Size(105, 105);
			this.btnEnviarAExcelCP.TabIndex = 133;
			this.btnEnviarAExcelCP.Text = "Enviar a Excel";
			this.btnEnviarAExcelCP.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcelCP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcelCP.UseVisualStyleBackColor = false;
			this.btnEnviarAExcelCP.Click += new System.EventHandler(btnEnviarAExcelIngresos_Click);
			this.tabPage4.Controls.Add(this.gvNominas);
			this.tabPage4.Controls.Add(this.flowLayoutPanel5);
			this.tabPage4.Location = new System.Drawing.Point(4, 31);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage4.Size = new System.Drawing.Size(1292, 648);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Nóminas - N";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.gvNominas.AllowUserToAddRows = false;
			dataGridViewCellStyle58.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle58.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle58.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvNominas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle58;
			this.gvNominas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvNominas.AutoGenerateColumns = false;
			this.gvNominas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvNominas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvNominas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvNominas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvNominas.Columns.AddRange(this.dataGridViewTextBoxColumn31, this.dataGridViewTextBoxColumn32, this.dataGridViewTextBoxColumn33, this.dataGridViewTextBoxColumn34, this.dataGridViewTextBoxColumn35, this.dataGridViewTextBoxColumn36, this.dataGridViewTextBoxColumn37, this.dataGridViewTextBoxColumn38, this.dataGridViewTextBoxColumn39, this.dataGridViewTextBoxColumn40, this.dataGridViewTextBoxColumn41, this.dataGridViewTextBoxColumn42, this.dataGridViewTextBoxColumn43, this.dataGridViewTextBoxColumn44, this.dataGridViewTextBoxColumn45);
			this.gvNominas.DataSource = this.entFacturaBindingSource;
			this.gvNominas.Location = new System.Drawing.Point(0, 45);
			this.gvNominas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvNominas.Name = "gvNominas";
			this.gvNominas.ReadOnly = true;
			this.gvNominas.RowHeadersVisible = false;
			this.gvNominas.RowHeadersWidth = 51;
			dataGridViewCellStyle59.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle59.ForeColor = System.Drawing.Color.Black;
			this.gvNominas.RowsDefaultCellStyle = dataGridViewCellStyle59;
			this.gvNominas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvNominas.Size = new System.Drawing.Size(1291, 554);
			this.gvNominas.TabIndex = 138;
			this.dataGridViewTextBoxColumn31.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn31.FillWeight = 150f;
			this.dataGridViewTextBoxColumn31.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn31.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn31.ReadOnly = true;
			this.dataGridViewTextBoxColumn32.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn32.FillWeight = 250f;
			this.dataGridViewTextBoxColumn32.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn32.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
			this.dataGridViewTextBoxColumn32.ReadOnly = true;
			this.dataGridViewTextBoxColumn33.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn33.FillWeight = 250f;
			this.dataGridViewTextBoxColumn33.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn33.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
			this.dataGridViewTextBoxColumn33.ReadOnly = true;
			this.dataGridViewTextBoxColumn34.DataPropertyName = "Folio";
			dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle60;
			this.dataGridViewTextBoxColumn34.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn34.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
			this.dataGridViewTextBoxColumn34.ReadOnly = true;
			this.dataGridViewTextBoxColumn35.DataPropertyName = "SubTotal";
			dataGridViewCellStyle61.Format = "c4";
			this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle61;
			this.dataGridViewTextBoxColumn35.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn35.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
			this.dataGridViewTextBoxColumn35.ReadOnly = true;
			this.dataGridViewTextBoxColumn35.Visible = false;
			this.dataGridViewTextBoxColumn36.DataPropertyName = "Descuento";
			dataGridViewCellStyle62.Format = "c4";
			this.dataGridViewTextBoxColumn36.DefaultCellStyle = dataGridViewCellStyle62;
			this.dataGridViewTextBoxColumn36.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn36.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
			this.dataGridViewTextBoxColumn36.ReadOnly = true;
			this.dataGridViewTextBoxColumn36.Visible = false;
			this.dataGridViewTextBoxColumn37.DataPropertyName = "IVA";
			dataGridViewCellStyle63.Format = "c4";
			this.dataGridViewTextBoxColumn37.DefaultCellStyle = dataGridViewCellStyle63;
			this.dataGridViewTextBoxColumn37.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn37.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
			this.dataGridViewTextBoxColumn37.ReadOnly = true;
			this.dataGridViewTextBoxColumn37.Visible = false;
			this.dataGridViewTextBoxColumn38.DataPropertyName = "Retenciones";
			dataGridViewCellStyle64.Format = "c4";
			this.dataGridViewTextBoxColumn38.DefaultCellStyle = dataGridViewCellStyle64;
			this.dataGridViewTextBoxColumn38.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn38.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
			this.dataGridViewTextBoxColumn38.ReadOnly = true;
			this.dataGridViewTextBoxColumn38.Visible = false;
			this.dataGridViewTextBoxColumn39.DataPropertyName = "Total";
			dataGridViewCellStyle65.Format = "c2";
			this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle65;
			this.dataGridViewTextBoxColumn39.HeaderText = "Total";
			this.dataGridViewTextBoxColumn39.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
			this.dataGridViewTextBoxColumn39.ReadOnly = true;
			this.dataGridViewTextBoxColumn40.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn40.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn40.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
			this.dataGridViewTextBoxColumn40.ReadOnly = true;
			this.dataGridViewTextBoxColumn41.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn41.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn41.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
			this.dataGridViewTextBoxColumn41.ReadOnly = true;
			this.dataGridViewTextBoxColumn42.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn42.DefaultCellStyle = dataGridViewCellStyle66;
			this.dataGridViewTextBoxColumn42.FillWeight = 120f;
			this.dataGridViewTextBoxColumn42.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn42.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
			this.dataGridViewTextBoxColumn42.ReadOnly = true;
			this.dataGridViewTextBoxColumn43.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn43.FillWeight = 120f;
			this.dataGridViewTextBoxColumn43.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn43.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
			this.dataGridViewTextBoxColumn43.ReadOnly = true;
			this.dataGridViewTextBoxColumn44.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn44.HeaderText = "UUID Relacionado";
			this.dataGridViewTextBoxColumn44.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
			this.dataGridViewTextBoxColumn44.ReadOnly = true;
			this.dataGridViewTextBoxColumn45.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn45.HeaderText = "Concepto";
			this.dataGridViewTextBoxColumn45.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
			this.dataGridViewTextBoxColumn45.ReadOnly = true;
			this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel5.Controls.Add(this.flowLayoutPanel8);
			this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel5.Location = new System.Drawing.Point(366, 597);
			this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel5.Size = new System.Drawing.Size(926, 42);
			this.flowLayoutPanel5.TabIndex = 139;
			this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel8.Controls.Add(this.toolStrip4);
			this.flowLayoutPanel8.Location = new System.Drawing.Point(624, 2);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel8.Size = new System.Drawing.Size(299, 36);
			this.flowLayoutPanel8.TabIndex = 140;
			this.toolStrip4.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel13, this.tstNumNom, this.toolStripSeparator13, this.toolStripLabel14, this.tstSubNom, this.toolStripSeparator14, this.toolStripLabel15, this.tstIvaNom, this.toolStripSeparator15, this.toolStripLabel16,
				this.tstImporteNom
			});
			this.toolStrip4.Location = new System.Drawing.Point(0, 1);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip4.Size = new System.Drawing.Size(265, 31);
			this.toolStrip4.TabIndex = 2;
			this.toolStrip4.Text = "toolStrip4";
			this.toolStripLabel13.Name = "toolStripLabel13";
			this.toolStripLabel13.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel13.Text = "Núm Comprobantes:";
			this.tstNumNom.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumNom.Name = "tstNumNom";
			this.tstNumNom.ReadOnly = true;
			this.tstNumNom.Size = new System.Drawing.Size(60, 31);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator13.Visible = false;
			this.toolStripLabel14.Name = "toolStripLabel14";
			this.toolStripLabel14.Size = new System.Drawing.Size(84, 25);
			this.toolStripLabel14.Text = "SubTotal:";
			this.toolStripLabel14.Visible = false;
			this.tstSubNom.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubNom.Name = "tstSubNom";
			this.tstSubNom.ReadOnly = true;
			this.tstSubNom.Size = new System.Drawing.Size(108, 31);
			this.tstSubNom.Visible = false;
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator14.Visible = false;
			this.toolStripLabel15.Name = "toolStripLabel15";
			this.toolStripLabel15.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel15.Text = "I.V.A:";
			this.toolStripLabel15.Visible = false;
			this.tstIvaNom.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaNom.Name = "tstIvaNom";
			this.tstIvaNom.ReadOnly = true;
			this.tstIvaNom.Size = new System.Drawing.Size(108, 31);
			this.tstIvaNom.Visible = false;
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel16.Name = "toolStripLabel16";
			this.toolStripLabel16.Size = new System.Drawing.Size(53, 25);
			this.toolStripLabel16.Text = "Total:";
			this.toolStripLabel16.Visible = false;
			this.tstImporteNom.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteNom.Name = "tstImporteNom";
			this.tstImporteNom.ReadOnly = true;
			this.tstImporteNom.Size = new System.Drawing.Size(82, 31);
			this.tstImporteNom.Visible = false;
			this.tabPage5.Controls.Add(this.gvNotasCredito);
			this.tabPage5.Controls.Add(this.flowLayoutPanel6);
			this.tabPage5.Controls.Add(this.flowLayoutPanel12);
			this.tabPage5.Location = new System.Drawing.Point(4, 31);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage5.Size = new System.Drawing.Size(1292, 648);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Egresos - E";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.gvNotasCredito.AllowUserToAddRows = false;
			dataGridViewCellStyle67.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle67.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle67.ForeColor = System.Drawing.Color.Black;
			this.gvNotasCredito.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle67;
			this.gvNotasCredito.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvNotasCredito.AutoGenerateColumns = false;
			this.gvNotasCredito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvNotasCredito.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvNotasCredito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvNotasCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvNotasCredito.Columns.AddRange(this.dataGridViewTextBoxColumn46, this.dataGridViewTextBoxColumn47, this.dataGridViewTextBoxColumn48, this.dataGridViewTextBoxColumn49, this.dataGridViewTextBoxColumn50, this.dataGridViewTextBoxColumn51, this.dataGridViewTextBoxColumn52, this.dataGridViewTextBoxColumn53, this.dataGridViewTextBoxColumn54, this.dataGridViewTextBoxColumn55, this.dataGridViewTextBoxColumn56, this.dataGridViewTextBoxColumn57, this.dataGridViewTextBoxColumn58, this.dataGridViewTextBoxColumn59, this.dataGridViewTextBoxColumn60, this.dataGridViewTextBoxColumn81, this.dataGridViewTextBoxColumn82);
			this.gvNotasCredito.DataSource = this.entFacturaBindingSource;
			this.gvNotasCredito.Location = new System.Drawing.Point(0, 45);
			this.gvNotasCredito.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvNotasCredito.Name = "gvNotasCredito";
			this.gvNotasCredito.ReadOnly = true;
			this.gvNotasCredito.RowHeadersVisible = false;
			this.gvNotasCredito.RowHeadersWidth = 51;
			dataGridViewCellStyle68.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle68.ForeColor = System.Drawing.Color.Black;
			this.gvNotasCredito.RowsDefaultCellStyle = dataGridViewCellStyle68;
			this.gvNotasCredito.RowTemplate.Height = 30;
			this.gvNotasCredito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvNotasCredito.Size = new System.Drawing.Size(1186, 554);
			this.gvNotasCredito.TabIndex = 138;
			this.dataGridViewTextBoxColumn46.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn46.FillWeight = 150f;
			this.dataGridViewTextBoxColumn46.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn46.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
			this.dataGridViewTextBoxColumn46.ReadOnly = true;
			this.dataGridViewTextBoxColumn47.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn47.FillWeight = 250f;
			this.dataGridViewTextBoxColumn47.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn47.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
			this.dataGridViewTextBoxColumn47.ReadOnly = true;
			this.dataGridViewTextBoxColumn48.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn48.FillWeight = 250f;
			this.dataGridViewTextBoxColumn48.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn48.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
			this.dataGridViewTextBoxColumn48.ReadOnly = true;
			this.dataGridViewTextBoxColumn49.DataPropertyName = "Folio";
			dataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn49.DefaultCellStyle = dataGridViewCellStyle69;
			this.dataGridViewTextBoxColumn49.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn49.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
			this.dataGridViewTextBoxColumn49.ReadOnly = true;
			this.dataGridViewTextBoxColumn50.DataPropertyName = "SubTotal";
			dataGridViewCellStyle70.Format = "c2";
			this.dataGridViewTextBoxColumn50.DefaultCellStyle = dataGridViewCellStyle70;
			this.dataGridViewTextBoxColumn50.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn50.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
			this.dataGridViewTextBoxColumn50.ReadOnly = true;
			this.dataGridViewTextBoxColumn51.DataPropertyName = "Descuento";
			dataGridViewCellStyle71.Format = "c2";
			this.dataGridViewTextBoxColumn51.DefaultCellStyle = dataGridViewCellStyle71;
			this.dataGridViewTextBoxColumn51.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn51.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
			this.dataGridViewTextBoxColumn51.ReadOnly = true;
			this.dataGridViewTextBoxColumn51.Visible = false;
			this.dataGridViewTextBoxColumn52.DataPropertyName = "IVA";
			dataGridViewCellStyle72.Format = "c2";
			this.dataGridViewTextBoxColumn52.DefaultCellStyle = dataGridViewCellStyle72;
			this.dataGridViewTextBoxColumn52.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn52.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
			this.dataGridViewTextBoxColumn52.ReadOnly = true;
			this.dataGridViewTextBoxColumn53.DataPropertyName = "Retenciones";
			dataGridViewCellStyle73.Format = "c2";
			this.dataGridViewTextBoxColumn53.DefaultCellStyle = dataGridViewCellStyle73;
			this.dataGridViewTextBoxColumn53.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn53.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
			this.dataGridViewTextBoxColumn53.ReadOnly = true;
			this.dataGridViewTextBoxColumn54.DataPropertyName = "Total";
			dataGridViewCellStyle74.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle74.Format = "c2";
			this.dataGridViewTextBoxColumn54.DefaultCellStyle = dataGridViewCellStyle74;
			this.dataGridViewTextBoxColumn54.HeaderText = "Total";
			this.dataGridViewTextBoxColumn54.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
			this.dataGridViewTextBoxColumn54.ReadOnly = true;
			this.dataGridViewTextBoxColumn55.DataPropertyName = "Moneda";
			dataGridViewCellStyle75.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn55.DefaultCellStyle = dataGridViewCellStyle75;
			this.dataGridViewTextBoxColumn55.FillWeight = 80f;
			this.dataGridViewTextBoxColumn55.HeaderText = "Moneda";
			this.dataGridViewTextBoxColumn55.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
			this.dataGridViewTextBoxColumn55.ReadOnly = true;
			this.dataGridViewTextBoxColumn56.DataPropertyName = "TipoCambio";
			dataGridViewCellStyle76.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle76.Format = "n4";
			this.dataGridViewTextBoxColumn56.DefaultCellStyle = dataGridViewCellStyle76;
			this.dataGridViewTextBoxColumn56.FillWeight = 80f;
			this.dataGridViewTextBoxColumn56.HeaderText = "Tipo Cambio";
			this.dataGridViewTextBoxColumn56.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
			this.dataGridViewTextBoxColumn56.ReadOnly = true;
			this.dataGridViewTextBoxColumn57.DataPropertyName = "Fecha";
			dataGridViewCellStyle77.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn57.DefaultCellStyle = dataGridViewCellStyle77;
			this.dataGridViewTextBoxColumn57.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn57.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
			this.dataGridViewTextBoxColumn57.ReadOnly = true;
			this.dataGridViewTextBoxColumn58.DataPropertyName = "TipoComprobante";
			dataGridViewCellStyle78.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn58.DefaultCellStyle = dataGridViewCellStyle78;
			this.dataGridViewTextBoxColumn58.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn58.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
			this.dataGridViewTextBoxColumn58.ReadOnly = true;
			this.dataGridViewTextBoxColumn59.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle79.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn59.DefaultCellStyle = dataGridViewCellStyle79;
			this.dataGridViewTextBoxColumn59.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn59.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
			this.dataGridViewTextBoxColumn59.ReadOnly = true;
			this.dataGridViewTextBoxColumn60.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn60.FillWeight = 120f;
			this.dataGridViewTextBoxColumn60.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn60.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
			this.dataGridViewTextBoxColumn60.ReadOnly = true;
			this.dataGridViewTextBoxColumn81.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn81.HeaderText = "UUID Relacionado";
			this.dataGridViewTextBoxColumn81.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn81.Name = "dataGridViewTextBoxColumn81";
			this.dataGridViewTextBoxColumn81.ReadOnly = true;
			this.dataGridViewTextBoxColumn82.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn82.HeaderText = "Concepto";
			this.dataGridViewTextBoxColumn82.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn82.Name = "dataGridViewTextBoxColumn82";
			this.dataGridViewTextBoxColumn82.ReadOnly = true;
			this.flowLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel6.Controls.Add(this.flowLayoutPanel9);
			this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel6.Location = new System.Drawing.Point(261, 597);
			this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel6.Size = new System.Drawing.Size(926, 42);
			this.flowLayoutPanel6.TabIndex = 139;
			this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel9.Controls.Add(this.toolStrip5);
			this.flowLayoutPanel9.Location = new System.Drawing.Point(624, 2);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel9.Size = new System.Drawing.Size(299, 36);
			this.flowLayoutPanel9.TabIndex = 141;
			this.toolStrip5.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel17, this.tstNumNC, this.toolStripSeparator17, this.toolStripLabel18, this.tstSubNC, this.toolStripSeparator18, this.toolStripLabel19, this.tstIvaNC, this.toolStripSeparator19, this.toolStripLabel20,
				this.tstImporteNC
			});
			this.toolStrip5.Location = new System.Drawing.Point(0, 1);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip5.Size = new System.Drawing.Size(265, 31);
			this.toolStrip5.TabIndex = 2;
			this.toolStrip5.Text = "toolStrip5";
			this.toolStripLabel17.Name = "toolStripLabel17";
			this.toolStripLabel17.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel17.Text = "Núm Comprobantes:";
			this.tstNumNC.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumNC.Name = "tstNumNC";
			this.tstNumNC.ReadOnly = true;
			this.tstNumNC.Size = new System.Drawing.Size(60, 31);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator17.Visible = false;
			this.toolStripLabel18.Name = "toolStripLabel18";
			this.toolStripLabel18.Size = new System.Drawing.Size(84, 25);
			this.toolStripLabel18.Text = "SubTotal:";
			this.toolStripLabel18.Visible = false;
			this.tstSubNC.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubNC.Name = "tstSubNC";
			this.tstSubNC.ReadOnly = true;
			this.tstSubNC.Size = new System.Drawing.Size(108, 31);
			this.tstSubNC.Visible = false;
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator18.Visible = false;
			this.toolStripLabel19.Name = "toolStripLabel19";
			this.toolStripLabel19.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel19.Text = "I.V.A:";
			this.toolStripLabel19.Visible = false;
			this.tstIvaNC.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaNC.Name = "tstIvaNC";
			this.tstIvaNC.ReadOnly = true;
			this.tstIvaNC.Size = new System.Drawing.Size(108, 31);
			this.tstIvaNC.Visible = false;
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel20.Name = "toolStripLabel20";
			this.toolStripLabel20.Size = new System.Drawing.Size(53, 25);
			this.toolStripLabel20.Text = "Total:";
			this.toolStripLabel20.Visible = false;
			this.tstImporteNC.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteNC.Name = "tstImporteNC";
			this.tstImporteNC.ReadOnly = true;
			this.tstImporteNC.Size = new System.Drawing.Size(82, 31);
			this.tstImporteNC.Visible = false;
			this.flowLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel12.Controls.Add(this.btnEnviarAExcelNC);
			this.flowLayoutPanel12.Location = new System.Drawing.Point(1182, 39);
			this.flowLayoutPanel12.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel12.Name = "flowLayoutPanel12";
			this.flowLayoutPanel12.Size = new System.Drawing.Size(120, 300);
			this.flowLayoutPanel12.TabIndex = 141;
			this.btnEnviarAExcelNC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcelNC.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcelNC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcelNC.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcelNC.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcelNC.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcelNC.Location = new System.Drawing.Point(4, 5);
			this.btnEnviarAExcelNC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEnviarAExcelNC.Name = "btnEnviarAExcelNC";
			this.btnEnviarAExcelNC.Size = new System.Drawing.Size(105, 105);
			this.btnEnviarAExcelNC.TabIndex = 133;
			this.btnEnviarAExcelNC.Text = "Enviar a Excel";
			this.btnEnviarAExcelNC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcelNC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcelNC.UseVisualStyleBackColor = false;
			this.btnEnviarAExcelNC.Click += new System.EventHandler(btnEnviarAExcelIngresos_Click);
			this.tabPage6.Controls.Add(this.flowLayoutPanel7);
			this.tabPage6.Controls.Add(this.gvCancelados);
			this.tabPage6.Controls.Add(this.flowLayoutPanel13);
			this.tabPage6.Location = new System.Drawing.Point(4, 31);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage6.Size = new System.Drawing.Size(1292, 648);
			this.tabPage6.TabIndex = 5;
			this.tabPage6.Text = "Cancelados - C";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.flowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel7.Controls.Add(this.toolStrip6);
			this.flowLayoutPanel7.Location = new System.Drawing.Point(886, 601);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel7.Size = new System.Drawing.Size(299, 36);
			this.flowLayoutPanel7.TabIndex = 142;
			this.toolStrip6.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel21, this.tstNumCancelados, this.toolStripSeparator21, this.toolStripLabel22, this.tstSubCancelados, this.toolStripSeparator22, this.toolStripLabel23, this.tstIvaCancelados, this.toolStripSeparator23, this.toolStripLabel24,
				this.tstImporteCancelados
			});
			this.toolStrip6.Location = new System.Drawing.Point(0, 1);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip6.Size = new System.Drawing.Size(265, 31);
			this.toolStrip6.TabIndex = 2;
			this.toolStrip6.Text = "toolStrip6";
			this.toolStripLabel21.Name = "toolStripLabel21";
			this.toolStripLabel21.Size = new System.Drawing.Size(179, 26);
			this.toolStripLabel21.Text = "Núm Comprobantes:";
			this.tstNumCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumCancelados.Name = "tstNumCancelados";
			this.tstNumCancelados.ReadOnly = true;
			this.tstNumCancelados.Size = new System.Drawing.Size(60, 31);
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel22.Name = "toolStripLabel22";
			this.toolStripLabel22.Size = new System.Drawing.Size(84, 25);
			this.toolStripLabel22.Text = "SubTotal:";
			this.toolStripLabel22.Visible = false;
			this.tstSubCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubCancelados.Name = "tstSubCancelados";
			this.tstSubCancelados.ReadOnly = true;
			this.tstSubCancelados.Size = new System.Drawing.Size(108, 31);
			this.tstSubCancelados.Visible = false;
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator22.Visible = false;
			this.toolStripLabel23.Name = "toolStripLabel23";
			this.toolStripLabel23.Size = new System.Drawing.Size(52, 25);
			this.toolStripLabel23.Text = "I.V.A:";
			this.toolStripLabel23.Visible = false;
			this.tstIvaCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaCancelados.Name = "tstIvaCancelados";
			this.tstIvaCancelados.ReadOnly = true;
			this.tstIvaCancelados.Size = new System.Drawing.Size(108, 31);
			this.tstIvaCancelados.Visible = false;
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(6, 33);
			this.toolStripSeparator23.Visible = false;
			this.toolStripLabel24.Name = "toolStripLabel24";
			this.toolStripLabel24.Size = new System.Drawing.Size(80, 25);
			this.toolStripLabel24.Text = "Importe:";
			this.toolStripLabel24.Visible = false;
			this.tstImporteCancelados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteCancelados.Name = "tstImporteCancelados";
			this.tstImporteCancelados.ReadOnly = true;
			this.tstImporteCancelados.Size = new System.Drawing.Size(82, 31);
			this.tstImporteCancelados.Visible = false;
			this.gvCancelados.AllowUserToAddRows = false;
			dataGridViewCellStyle80.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle80.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle80.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvCancelados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle80;
			this.gvCancelados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvCancelados.AutoGenerateColumns = false;
			this.gvCancelados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvCancelados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvCancelados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvCancelados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvCancelados.Columns.AddRange(this.dataGridViewTextBoxColumn61, this.dataGridViewTextBoxColumn62, this.dataGridViewTextBoxColumn63, this.dataGridViewTextBoxColumn64, this.dataGridViewTextBoxColumn65, this.dataGridViewTextBoxColumn66, this.dataGridViewTextBoxColumn67, this.dataGridViewTextBoxColumn68, this.dataGridViewTextBoxColumn69, this.dataGridViewTextBoxColumn70, this.dataGridViewTextBoxColumn71, this.dataGridViewTextBoxColumn72, this.dataGridViewTextBoxColumn73, this.dataGridViewTextBoxColumn74, this.dataGridViewTextBoxColumn75, this.dataGridViewTextBoxColumn76);
			this.gvCancelados.DataSource = this.entFacturaBindingSource;
			this.gvCancelados.Location = new System.Drawing.Point(0, 45);
			this.gvCancelados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvCancelados.Name = "gvCancelados";
			this.gvCancelados.ReadOnly = true;
			this.gvCancelados.RowHeadersVisible = false;
			this.gvCancelados.RowHeadersWidth = 51;
			dataGridViewCellStyle81.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle81.ForeColor = System.Drawing.Color.Black;
			this.gvCancelados.RowsDefaultCellStyle = dataGridViewCellStyle81;
			this.gvCancelados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvCancelados.Size = new System.Drawing.Size(1186, 555);
			this.gvCancelados.TabIndex = 138;
			this.dataGridViewTextBoxColumn61.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn61.FillWeight = 150f;
			this.dataGridViewTextBoxColumn61.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn61.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
			this.dataGridViewTextBoxColumn61.ReadOnly = true;
			this.dataGridViewTextBoxColumn62.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn62.FillWeight = 250f;
			this.dataGridViewTextBoxColumn62.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn62.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
			this.dataGridViewTextBoxColumn62.ReadOnly = true;
			this.dataGridViewTextBoxColumn63.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn63.FillWeight = 250f;
			this.dataGridViewTextBoxColumn63.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn63.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
			this.dataGridViewTextBoxColumn63.ReadOnly = true;
			this.dataGridViewTextBoxColumn64.DataPropertyName = "Folio";
			dataGridViewCellStyle82.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn64.DefaultCellStyle = dataGridViewCellStyle82;
			this.dataGridViewTextBoxColumn64.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn64.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
			this.dataGridViewTextBoxColumn64.ReadOnly = true;
			this.dataGridViewTextBoxColumn65.DataPropertyName = "SubTotal";
			dataGridViewCellStyle83.Format = "c2";
			this.dataGridViewTextBoxColumn65.DefaultCellStyle = dataGridViewCellStyle83;
			this.dataGridViewTextBoxColumn65.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn65.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
			this.dataGridViewTextBoxColumn65.ReadOnly = true;
			this.dataGridViewTextBoxColumn66.DataPropertyName = "Descuento";
			dataGridViewCellStyle84.Format = "c4";
			this.dataGridViewTextBoxColumn66.DefaultCellStyle = dataGridViewCellStyle84;
			this.dataGridViewTextBoxColumn66.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn66.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
			this.dataGridViewTextBoxColumn66.ReadOnly = true;
			this.dataGridViewTextBoxColumn66.Visible = false;
			this.dataGridViewTextBoxColumn67.DataPropertyName = "IVA";
			dataGridViewCellStyle85.Format = "c2";
			this.dataGridViewTextBoxColumn67.DefaultCellStyle = dataGridViewCellStyle85;
			this.dataGridViewTextBoxColumn67.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn67.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
			this.dataGridViewTextBoxColumn67.ReadOnly = true;
			this.dataGridViewTextBoxColumn68.DataPropertyName = "Retenciones";
			dataGridViewCellStyle86.Format = "c2";
			this.dataGridViewTextBoxColumn68.DefaultCellStyle = dataGridViewCellStyle86;
			this.dataGridViewTextBoxColumn68.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn68.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
			this.dataGridViewTextBoxColumn68.ReadOnly = true;
			this.dataGridViewTextBoxColumn69.DataPropertyName = "Total";
			dataGridViewCellStyle87.Format = "c2";
			this.dataGridViewTextBoxColumn69.DefaultCellStyle = dataGridViewCellStyle87;
			this.dataGridViewTextBoxColumn69.HeaderText = "Total";
			this.dataGridViewTextBoxColumn69.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
			this.dataGridViewTextBoxColumn69.ReadOnly = true;
			this.dataGridViewTextBoxColumn70.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn70.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn70.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
			this.dataGridViewTextBoxColumn70.ReadOnly = true;
			this.dataGridViewTextBoxColumn71.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn71.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn71.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
			this.dataGridViewTextBoxColumn71.ReadOnly = true;
			this.dataGridViewTextBoxColumn72.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle88.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn72.DefaultCellStyle = dataGridViewCellStyle88;
			this.dataGridViewTextBoxColumn72.FillWeight = 120f;
			this.dataGridViewTextBoxColumn72.HeaderText = "Método Pago";
			this.dataGridViewTextBoxColumn72.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
			this.dataGridViewTextBoxColumn72.ReadOnly = true;
			this.dataGridViewTextBoxColumn73.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn73.FillWeight = 120f;
			this.dataGridViewTextBoxColumn73.HeaderText = "Forma Pago";
			this.dataGridViewTextBoxColumn73.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
			this.dataGridViewTextBoxColumn73.ReadOnly = true;
			this.dataGridViewTextBoxColumn74.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn74.HeaderText = "UUID Relacionado";
			this.dataGridViewTextBoxColumn74.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
			this.dataGridViewTextBoxColumn74.ReadOnly = true;
			this.dataGridViewTextBoxColumn75.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn75.HeaderText = "Concepto";
			this.dataGridViewTextBoxColumn75.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
			this.dataGridViewTextBoxColumn75.ReadOnly = true;
			this.dataGridViewTextBoxColumn76.DataPropertyName = "EstatusDescripcion";
			this.dataGridViewTextBoxColumn76.HeaderText = "Estatus Descripcion";
			this.dataGridViewTextBoxColumn76.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
			this.dataGridViewTextBoxColumn76.ReadOnly = true;
			this.flowLayoutPanel13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel13.Controls.Add(this.btnEnviarAExcelCanceladas);
			this.flowLayoutPanel13.Location = new System.Drawing.Point(1182, 39);
			this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(1);
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
			this.btnEnviarAExcelCanceladas.Click += new System.EventHandler(btnEnviarAExcelIngresos_Click);
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Controls.Add(this.pnlPorDiaVentas);
			this.panel1.Controls.Add(this.rdoPorFechasComprobantes);
			this.panel1.Location = new System.Drawing.Point(9, 5);
			this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(626, 131);
			this.panel1.TabIndex = 135;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(482, 10);
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
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(12, 28);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(84, 22);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorMesComprobantes.CheckedChanged += new System.EventHandler(rdoPorMesComprobantes_CheckedChanged);
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(118, 11);
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
			this.pnlPorDiaVentas.Location = new System.Drawing.Point(118, 68);
			this.pnlPorDiaVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorDiaVentas.Name = "pnlPorDiaVentas";
			this.pnlPorDiaVentas.Size = new System.Drawing.Size(364, 49);
			this.pnlPorDiaVentas.TabIndex = 42;
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
			this.rdoPorFechasComprobantes.Location = new System.Drawing.Point(12, 82);
			this.rdoPorFechasComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorFechasComprobantes.Name = "rdoPorFechasComprobantes";
			this.rdoPorFechasComprobantes.Size = new System.Drawing.Size(99, 22);
			this.rdoPorFechasComprobantes.TabIndex = 43;
			this.rdoPorFechasComprobantes.Text = "Por Fechas";
			this.rdoPorFechasComprobantes.UseVisualStyleBackColor = true;
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
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(326, 18);
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
			this.cmbEmpresas.Location = new System.Drawing.Point(422, 12);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(607, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(1044, 6);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(73, 54);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1343, 984);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "ReportesEgresos";
			this.Text = "Reportes";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.tcReportesIngresos.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel14.ResumeLayout(false);
			this.tpIngresos.ResumeLayout(false);
			this.flowLayoutPanel16.ResumeLayout(false);
			this.flowLayoutPanel16.PerformLayout();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvIngresos).EndInit();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.pnlFiltroPUEPPD.ResumeLayout(false);
			this.pnlFiltroPUEPPD.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.flowLayoutPanel17.ResumeLayout(false);
			this.flowLayoutPanel17.PerformLayout();
			this.toolStrip8.ResumeLayout(false);
			this.toolStrip8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvComplementos).EndInit();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.flowLayoutPanel11.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvNominas).EndInit();
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowLayoutPanel8.ResumeLayout(false);
			this.flowLayoutPanel8.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvNotasCredito).EndInit();
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			this.flowLayoutPanel12.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.flowLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel7.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCancelados).EndInit();
			this.flowLayoutPanel13.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			this.pnlPorDiaVentas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
