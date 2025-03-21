using System;
using System.Collections;
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
	public class InformacionPrecargadaSAT : FormBase
	{
		private IContainer components = null;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private Button btnBuscaEmpresa;

		private ComboBox cmbEmpresas;

		private TabPage tpGeneral;

		private TabControl tcCFDIsRecibidos;

		private TabPage tpCFDIsTotales;

		private Panel pnlFiltroFechas;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Label label3;

		private TextBox txtCantidadVentas;

		private TabControl tcGeneral;

		private TabPage tpCFDIsPrecargadosSAT;

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

		private TabPage tpCFDIsConfrontaInformacion;

		private ReportViewer rvImpresionCFDIsSAT;

		private ReportViewer rvImpresionCFDIsConfronta;

		private ReportViewer rvImpresionCFDIsTotales;

		private FlowLayoutPanel flpFiltrosExcluye;

		private CheckBox chkExcluirNC03;

		private CheckBox chkExcluirNC01;

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

		private FlowLayoutPanel flowLayoutPanel13;

		private TextBox txtTotalEgresos;

		private Label label9;

		private FlowLayoutPanel flpFiltrosTipoComprobante;

		private CheckBox chkPUE;

		private CheckBox chkPPD;

		private CheckBox chkComplementosPago;

		private CheckBox chkEgresos;

		private Button btnFiltrarComprobantes;

		private TabControl tcCFDIsGeneral;

		private TabPage tpCFDIsRecibidos;

		private TabPage tpCFDIsEmitidos;

		private TabPage tpCFDIsNominas;

		private FlowLayoutPanel flowLayoutPanel1;

		private CheckBox chkPUEemitidos;

		private CheckBox chkPPDemitidos;

		private CheckBox chkCPemitidos;

		private CheckBox chkEgresosEmitidos;

		private Button btnFiltrarComprobantesEmitidos;

		private ReportViewer rvImpresionCFDIsEmitidos;

		private TabControl tcNominasGeneral;

		private TabPage tpAuxiliarPercepciones;

		private ReportViewer rvAuxiliar;

		private TabPage tpAuxiliarDeducciones;

		private ReportViewer rvAuxiliarDeducciones;

		private Button btnCFDIsNomina;

		private Button btnCFDIsRecibidos;

		private Button btnCFDIsEmitidos;

		private FlowLayoutPanel flpEmpresas;

		private Label label1;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntCatalogoPercepciones> lstPercepcionesAuxiliar { get; set; }

		private List<EntCatalogoPercepciones> lstDeduccionesAuxiliar { get; set; }

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					ListaComprobantes = new List<EntFactura>();
					entFacturaBindingSource.DataSource = new List<EntFactura>();
					rvImpresionCFDIsTotales.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantes));
					rvImpresionCFDIsTotales.RefreshReport();
					chkExcluirNC01.Checked = Program.EmpresaSeleccionada.ExcluyeNc01;
					chkExcluirNC03.Checked = Program.EmpresaSeleccionada.ExcluyeNc03;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public InformacionPrecargadaSAT()
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

		private void CargaComprobantesEmitidos(EntEmpresa empresaSeleccionada, DateTime fechaDesde, DateTime fechaHasta)
		{
			ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscales(empresaSeleccionada, fechaDesde, fechaHasta, 1);
			ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(empresaSeleccionada, fechaDesde, fechaHasta, 1));
		}

		private void CargaComprobantesRecibidos(EntEmpresa empresaSeleccionada, DateTime fechaDesde, DateTime fechaHasta)
		{
			ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscalesEgresos(empresaSeleccionada, fechaDesde, fechaHasta, 1);
			ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(empresaSeleccionada, fechaDesde, fechaHasta, 1));
		}

		private List<EntFactura> FiltraComprobantes(List<EntFactura> ListaComprobantes, bool PUE, bool PPD, bool Complementos, bool Egresos, bool ExcluyeNc01, bool ExcluyeNc03)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			if (ListaComprobantes != null)
			{
				if (PUE || PPD || Complementos || Egresos)
				{
					lstFiltro = ListaComprobantes.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !ExcluyeNc01 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !ExcluyeNc03 && P.Deducible)).ToList();
				}
				lstFiltro = lstFiltro.Where((EntFactura P) => P.TipoComprobanteId != 5 || (P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today))).ToList();
			}
			return lstFiltro.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.RFC.ToUpper().Contains(txtRFCFiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtNombre.Text.ToUpper())).ToList();
		}

		private void MuestraReportesCFDIsRecibidos()
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			if (tcCFDIsRecibidos.SelectedIndex == tcCFDIsRecibidos.TabPages.IndexOf(tpCFDIsTotales))
			{
				List<EntFactura> comprobantesFiltrados = (from P in FiltraComprobantes(ListaComprobantes, chkPUE.Checked, chkPPD.Checked, chkComplementosPago.Checked, chkEgresos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked)
					where P.Deducible
					select P).ToList();
				rvImpresionCFDIsTotales.LocalReport.SetParameters(parmEmpresa);
				entFacturaBindingSource.DataSource = comprobantesFiltrados;
				rvImpresionCFDIsTotales.LocalReport.DataSources.Clear();
				rvImpresionCFDIsTotales.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)comprobantesFiltrados));
				rvImpresionCFDIsTotales.RefreshReport();
			}
			else
			{
				if (tcCFDIsRecibidos.SelectedIndex != 1 && tcCFDIsRecibidos.SelectedIndex != 2)
				{
					return;
				}
				List<EntFactura> xmls = new List<EntFactura>();
				List<EntFactura> xmlsCP = new List<EntFactura>();
				xmlsCP = RevisaCPusoCFDI(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today) && (P.FormaPagoId == 2 || P.FormaPagoId == 3 || P.FormaPagoId == 4 || P.FormaPagoId == 28)).ToList(), ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && (P.UsoCFDIId == 1 || P.UsoCFDIId == 3)).ToList());
				xmls = ListaComprobantes.Where((EntFactura P) => (P.MetodoPagoId == 1 && P.TipoComprobanteId == 1 && (P.UsoCFDIId == 1 || P.UsoCFDIId == 3) && (P.FormaPagoId == 2 || P.FormaPagoId == 3 || P.FormaPagoId == 4 || P.FormaPagoId == 28)) || (P.MetodoPagoId == 1 && P.TipoComprobanteId == 2)).ToList();
				xmls.AddRange((from P in new BusFacturas().ObtieneComprobantesFiscalesEgresos(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), 5)
					where P.MetodoPagoId == 1 && P.TipoComprobanteId == 2
					select P).ToList());
				xmls.AddRange(xmlsCP);
				if (tcCFDIsRecibidos.SelectedIndex == 1)
				{
					rvImpresionCFDIsSAT.LocalReport.SetParameters(parmEmpresa);
					entFacturaBindingSource.DataSource = xmls;
					rvImpresionCFDIsSAT.LocalReport.DataSources.Clear();
					rvImpresionCFDIsSAT.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)xmls));
					rvImpresionCFDIsSAT.RefreshReport();
				}
				else
				{
					if (tcCFDIsRecibidos.SelectedIndex != 2)
					{
						return;
					}
					List<EntFactura> xmlsPUE = ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1 && P.Deducible).ToList();
					List<EntFactura> xmlsCPtodos = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(true, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, DateTime.Today)).ToList();
					List<EntFactura> xmlsNC = ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && P.Deducible)).ToList();
					List<EntFactura> xmlsTodos = xmlsPUE;
					xmlsTodos.AddRange(xmlsCPtodos);
					xmlsTodos.AddRange(xmlsNC);
					List<EntFactura> lstDiferenciaSAT = xmlsTodos.Where((EntFactura item2) => !xmls.Any((EntFactura item1) => item1.Id == item2.Id)).ToList();
					List<EntFactura> lstEnTodosNoEnSAT = xmls.Where((EntFactura item2) => !xmlsTodos.Any((EntFactura item1) => item1.Id == item2.Id)).ToList();
					lstDiferenciaSAT.AddRange(lstEnTodosNoEnSAT);
					rvImpresionCFDIsConfronta.LocalReport.SetParameters(parmEmpresa);
					entFacturaBindingSource.DataSource = lstDiferenciaSAT;
					rvImpresionCFDIsConfronta.LocalReport.DataSources.Clear();
					rvImpresionCFDIsConfronta.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDiferenciaSAT));
					rvImpresionCFDIsConfronta.RefreshReport();
				}
			}
		}

		private void MuestraReportesCFDIsEmitidos(List<EntFactura> ListaComprobantesMuestra)
		{
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Program.EmpresaSeleccionada.Nombre);
			rvImpresionCFDIsEmitidos.LocalReport.SetParameters(parmEmpresa);
			entFacturaBindingSource.DataSource = ListaComprobantesMuestra;
			rvImpresionCFDIsEmitidos.LocalReport.DataSources.Clear();
			rvImpresionCFDIsEmitidos.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)ListaComprobantesMuestra));
			rvImpresionCFDIsEmitidos.RefreshReport();
		}

		private void MuestraBotonesPestañas()
		{
			btnCFDIsEmitidos.BackColor = Color.Black;
			btnCFDIsEmitidos.ForeColor = Color.White;
			btnCFDIsRecibidos.BackColor = Color.Black;
			btnCFDIsRecibidos.ForeColor = Color.White;
			btnCFDIsNomina.BackColor = Color.Black;
			btnCFDIsNomina.ForeColor = Color.White;
			if (tcCFDIsGeneral.SelectedIndex == tcCFDIsGeneral.TabPages.IndexOf(tpCFDIsRecibidos))
			{
				btnCFDIsRecibidos.Visible = true;
				btnCFDIsRecibidos.BackColor = Color.White;
				btnCFDIsRecibidos.ForeColor = Color.Black;
			}
			else if (tcCFDIsGeneral.SelectedIndex == tcCFDIsGeneral.TabPages.IndexOf(tpCFDIsEmitidos))
			{
				btnCFDIsEmitidos.Visible = true;
				btnCFDIsEmitidos.BackColor = Color.White;
				btnCFDIsEmitidos.ForeColor = Color.Black;
			}
			else if (tcCFDIsGeneral.SelectedIndex == tcCFDIsGeneral.TabPages.IndexOf(tpCFDIsNominas))
			{
				btnCFDIsNomina.Visible = true;
				btnCFDIsNomina.BackColor = Color.White;
				btnCFDIsNomina.ForeColor = Color.Black;
			}
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				MuestraBotonesPestañas();
				EntEmpresa empresaSeleccionada = Program.EmpresaSeleccionada;
				DateTime fechaDesde = FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
				DateTime fechaHasta = FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
				if (tcCFDIsGeneral.SelectedIndex == tcCFDIsGeneral.TabPages.IndexOf(tpCFDIsRecibidos))
				{
					CargaComprobantesRecibidos(empresaSeleccionada, fechaDesde, fechaHasta);
					MuestraReportesCFDIsRecibidos();
				}
				else if (tcCFDIsGeneral.SelectedIndex == tcCFDIsGeneral.TabPages.IndexOf(tpCFDIsEmitidos))
				{
					CargaComprobantesEmitidos(empresaSeleccionada, fechaDesde, fechaHasta);
					MuestraReportesCFDIsEmitidos(FiltraComprobantes(ListaComprobantes, chkPUEemitidos.Checked, chkPPDemitidos.Checked, chkCPemitidos.Checked, chkEgresosEmitidos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked));
				}
				else if (tcCFDIsGeneral.SelectedIndex == tcCFDIsGeneral.TabPages.IndexOf(tpCFDIsNominas))
				{
					lstPercepcionesAuxiliar = new BusFacturas().ObtieneComprobantesFiscalesNominasPercepcionesAuxiliar(empresaSeleccionada, fechaDesde, fechaHasta);
					lstDeduccionesAuxiliar = new BusFacturas().ObtieneComprobantesFiscalesNominasDeduccionesAuxiliar(empresaSeleccionada, fechaDesde, fechaHasta);
					ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + base.EmpresaSeleccionada.Nombre);
					ReportParameter parmFecha = new ReportParameter("parmFecha", " " + fechaDesde.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(fechaHasta.Month, fechaHasta.Year).ToString("dd/MMM/yyyy").ToUpper());
					rvAuxiliar.LocalReport.SetParameters(parmEmpresa);
					rvAuxiliar.LocalReport.SetParameters(parmFecha);
					rvAuxiliar.LocalReport.DataSources.Clear();
					rvAuxiliar.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPercepcionesAuxiliar));
					rvAuxiliar.RefreshReport();
					rvAuxiliarDeducciones.LocalReport.SetParameters(parmEmpresa);
					rvAuxiliarDeducciones.LocalReport.SetParameters(parmFecha);
					rvAuxiliarDeducciones.LocalReport.DataSources.Clear();
					rvAuxiliarDeducciones.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDeduccionesAuxiliar));
					rvAuxiliarDeducciones.RefreshReport();
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

		private void btnFiltraFacturas_Click(object sender, EventArgs e)
		{
			try
			{
				MuestraReportesCFDIsRecibidos();
				MuestraReportesCFDIsEmitidos(FiltraComprobantes(ListaComprobantes, chkPUEemitidos.Checked, chkPPDemitidos.Checked, chkCPemitidos.Checked, chkEgresosEmitidos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnFiltrarComprobantes_Click(object sender, EventArgs e)
		{
			try
			{
				MuestraReportesCFDIsRecibidos();
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
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnFiltrarComprobantesEmitidos_Click(object sender, EventArgs e)
		{
			try
			{
				MuestraReportesCFDIsEmitidos(FiltraComprobantes(ListaComprobantes, chkPUEemitidos.Checked, chkPPDemitidos.Checked, chkCPemitidos.Checked, chkEgresosEmitidos.Checked, chkExcluirNC01.Checked, chkExcluirNC03.Checked));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void tcCFDIsRecibidos_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				MuestraReportesCFDIsRecibidos();
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

		private void btnCFDIsRecibidos_Click(object sender, EventArgs e)
		{
			tcCFDIsGeneral.SelectedIndex = 0;
		}

		private void btnCFDIsEmitidos_Click(object sender, EventArgs e)
		{
			tcCFDIsGeneral.SelectedIndex = 1;
		}

		private void btnCFDIsNomina_Click(object sender, EventArgs e)
		{
			tcCFDIsGeneral.SelectedIndex = 2;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.InformacionPrecargadaSAT));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.tpGeneral = new System.Windows.Forms.TabPage();
			this.btnCFDIsNomina = new System.Windows.Forms.Button();
			this.btnCFDIsRecibidos = new System.Windows.Forms.Button();
			this.btnCFDIsEmitidos = new System.Windows.Forms.Button();
			this.tcCFDIsGeneral = new System.Windows.Forms.TabControl();
			this.tpCFDIsRecibidos = new System.Windows.Forms.TabPage();
			this.tcCFDIsRecibidos = new System.Windows.Forms.TabControl();
			this.tpCFDIsTotales = new System.Windows.Forms.TabPage();
			this.flpFiltrosExcluye = new System.Windows.Forms.FlowLayoutPanel();
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
			this.flpFiltrosTipoComprobante = new System.Windows.Forms.FlowLayoutPanel();
			this.chkPUE = new System.Windows.Forms.CheckBox();
			this.chkPPD = new System.Windows.Forms.CheckBox();
			this.chkComplementosPago = new System.Windows.Forms.CheckBox();
			this.chkEgresos = new System.Windows.Forms.CheckBox();
			this.btnFiltrarComprobantes = new System.Windows.Forms.Button();
			this.rvImpresionCFDIsTotales = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tpCFDIsPrecargadosSAT = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIsSAT = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tpCFDIsConfrontaInformacion = new System.Windows.Forms.TabPage();
			this.rvImpresionCFDIsConfronta = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tpCFDIsEmitidos = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.chkPUEemitidos = new System.Windows.Forms.CheckBox();
			this.chkPPDemitidos = new System.Windows.Forms.CheckBox();
			this.chkCPemitidos = new System.Windows.Forms.CheckBox();
			this.chkEgresosEmitidos = new System.Windows.Forms.CheckBox();
			this.btnFiltrarComprobantesEmitidos = new System.Windows.Forms.Button();
			this.rvImpresionCFDIsEmitidos = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tpCFDIsNominas = new System.Windows.Forms.TabPage();
			this.tcNominasGeneral = new System.Windows.Forms.TabControl();
			this.tpAuxiliarPercepciones = new System.Windows.Forms.TabPage();
			this.rvAuxiliar = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tpAuxiliarDeducciones = new System.Windows.Forms.TabPage();
			this.rvAuxiliarDeducciones = new Microsoft.Reporting.WinForms.ReportViewer();
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
			this.pnlFiltroFechas = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcGeneral = new System.Windows.Forms.TabControl();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.flpEmpresas = new System.Windows.Forms.FlowLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.tpGeneral.SuspendLayout();
			this.tcCFDIsGeneral.SuspendLayout();
			this.tpCFDIsRecibidos.SuspendLayout();
			this.tcCFDIsRecibidos.SuspendLayout();
			this.tpCFDIsTotales.SuspendLayout();
			this.flpFiltrosExcluye.SuspendLayout();
			this.flpTotales.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.flpTotalPUE.SuspendLayout();
			this.flpTotalCP.SuspendLayout();
			this.flpTotalTotal.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.flowLayoutPanel13.SuspendLayout();
			this.flpFiltrosTipoComprobante.SuspendLayout();
			this.tpCFDIsPrecargadosSAT.SuspendLayout();
			this.tpCFDIsConfrontaInformacion.SuspendLayout();
			this.tpCFDIsEmitidos.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.tpCFDIsNominas.SuspendLayout();
			this.tcNominasGeneral.SuspendLayout();
			this.tpAuxiliarPercepciones.SuspendLayout();
			this.tpAuxiliarDeducciones.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			this.pnlFiltroFechas.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcGeneral.SuspendLayout();
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
			this.tpGeneral.Controls.Add(this.btnCFDIsNomina);
			this.tpGeneral.Controls.Add(this.btnCFDIsRecibidos);
			this.tpGeneral.Controls.Add(this.btnCFDIsEmitidos);
			this.tpGeneral.Controls.Add(this.tcCFDIsGeneral);
			this.tpGeneral.Controls.Add(this.pnlFiltro);
			this.tpGeneral.Controls.Add(this.pnlFiltroFechas);
			this.tpGeneral.Controls.Add(this.label3);
			this.tpGeneral.Controls.Add(this.txtCantidadVentas);
			this.tpGeneral.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tpGeneral.Location = new System.Drawing.Point(4, 31);
			this.tpGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpGeneral.Name = "tpGeneral";
			this.tpGeneral.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpGeneral.Size = new System.Drawing.Size(1524, 803);
			this.tpGeneral.TabIndex = 0;
			this.tpGeneral.Text = "Comprobantes Fiscales ";
			this.tpGeneral.UseVisualStyleBackColor = true;
			this.btnCFDIsNomina.BackColor = System.Drawing.Color.Black;
			this.btnCFDIsNomina.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCFDIsNomina.Font = new System.Drawing.Font("Microsoft Tai Le", 14f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCFDIsNomina.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCFDIsNomina.Location = new System.Drawing.Point(636, 123);
			this.btnCFDIsNomina.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCFDIsNomina.Name = "btnCFDIsNomina";
			this.btnCFDIsNomina.Size = new System.Drawing.Size(309, 77);
			this.btnCFDIsNomina.TabIndex = 140;
			this.btnCFDIsNomina.Text = "CFDI NÓMINAS";
			this.btnCFDIsNomina.UseVisualStyleBackColor = false;
			this.btnCFDIsNomina.Click += new System.EventHandler(btnCFDIsNomina_Click);
			this.btnCFDIsRecibidos.BackColor = System.Drawing.Color.White;
			this.btnCFDIsRecibidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCFDIsRecibidos.Font = new System.Drawing.Font("Microsoft Tai Le", 14f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCFDIsRecibidos.ForeColor = System.Drawing.Color.Black;
			this.btnCFDIsRecibidos.Location = new System.Drawing.Point(14, 123);
			this.btnCFDIsRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCFDIsRecibidos.Name = "btnCFDIsRecibidos";
			this.btnCFDIsRecibidos.Size = new System.Drawing.Size(309, 77);
			this.btnCFDIsRecibidos.TabIndex = 139;
			this.btnCFDIsRecibidos.Text = "CFDI RECIBIDOS";
			this.btnCFDIsRecibidos.UseVisualStyleBackColor = false;
			this.btnCFDIsRecibidos.Click += new System.EventHandler(btnCFDIsRecibidos_Click);
			this.btnCFDIsEmitidos.BackColor = System.Drawing.Color.Black;
			this.btnCFDIsEmitidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCFDIsEmitidos.Font = new System.Drawing.Font("Microsoft Tai Le", 14f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCFDIsEmitidos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCFDIsEmitidos.Location = new System.Drawing.Point(322, 123);
			this.btnCFDIsEmitidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCFDIsEmitidos.Name = "btnCFDIsEmitidos";
			this.btnCFDIsEmitidos.Size = new System.Drawing.Size(309, 77);
			this.btnCFDIsEmitidos.TabIndex = 138;
			this.btnCFDIsEmitidos.Text = "CFDI EMITIDOS";
			this.btnCFDIsEmitidos.UseVisualStyleBackColor = false;
			this.btnCFDIsEmitidos.Click += new System.EventHandler(btnCFDIsEmitidos_Click);
			this.tcCFDIsGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCFDIsGeneral.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tcCFDIsGeneral.Controls.Add(this.tpCFDIsRecibidos);
			this.tcCFDIsGeneral.Controls.Add(this.tpCFDIsEmitidos);
			this.tcCFDIsGeneral.Controls.Add(this.tpCFDIsNominas);
			this.tcCFDIsGeneral.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tcCFDIsGeneral.Font = new System.Drawing.Font("Microsoft Tai Le", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcCFDIsGeneral.ItemSize = new System.Drawing.Size(200, 50);
			this.tcCFDIsGeneral.Location = new System.Drawing.Point(9, 123);
			this.tcCFDIsGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcCFDIsGeneral.Name = "tcCFDIsGeneral";
			this.tcCFDIsGeneral.SelectedIndex = 0;
			this.tcCFDIsGeneral.Size = new System.Drawing.Size(1506, 669);
			this.tcCFDIsGeneral.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tcCFDIsGeneral.TabIndex = 137;
			this.tcCFDIsGeneral.SelectedIndexChanged += new System.EventHandler(btnRefrescar_Click);
			this.tpCFDIsRecibidos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.tpCFDIsRecibidos.Controls.Add(this.tcCFDIsRecibidos);
			this.tpCFDIsRecibidos.Font = new System.Drawing.Font("Microsoft Tai Le", 15f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tpCFDIsRecibidos.ForeColor = System.Drawing.Color.Black;
			this.tpCFDIsRecibidos.Location = new System.Drawing.Point(4, 54);
			this.tpCFDIsRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsRecibidos.Name = "tpCFDIsRecibidos";
			this.tpCFDIsRecibidos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsRecibidos.Size = new System.Drawing.Size(1498, 611);
			this.tpCFDIsRecibidos.TabIndex = 0;
			this.tpCFDIsRecibidos.Text = "< CFDI RECIBIDOS > ";
			this.tpCFDIsRecibidos.ToolTipText = "CFDI RECIBIDOS";
			this.tcCFDIsRecibidos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCFDIsRecibidos.Controls.Add(this.tpCFDIsTotales);
			this.tcCFDIsRecibidos.Controls.Add(this.tpCFDIsPrecargadosSAT);
			this.tcCFDIsRecibidos.Controls.Add(this.tpCFDIsConfrontaInformacion);
			this.tcCFDIsRecibidos.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.tcCFDIsRecibidos.ItemSize = new System.Drawing.Size(270, 30);
			this.tcCFDIsRecibidos.Location = new System.Drawing.Point(4, 32);
			this.tcCFDIsRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcCFDIsRecibidos.Name = "tcCFDIsRecibidos";
			this.tcCFDIsRecibidos.SelectedIndex = 0;
			this.tcCFDIsRecibidos.Size = new System.Drawing.Size(1490, 575);
			this.tcCFDIsRecibidos.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tcCFDIsRecibidos.TabIndex = 136;
			this.tcCFDIsRecibidos.SelectedIndexChanged += new System.EventHandler(tcCFDIsRecibidos_SelectedIndexChanged);
			this.tpCFDIsTotales.Controls.Add(this.flpFiltrosExcluye);
			this.tpCFDIsTotales.Controls.Add(this.flpFiltrosTipoComprobante);
			this.tpCFDIsTotales.Controls.Add(this.rvImpresionCFDIsTotales);
			this.tpCFDIsTotales.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tpCFDIsTotales.Location = new System.Drawing.Point(4, 34);
			this.tpCFDIsTotales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsTotales.Name = "tpCFDIsTotales";
			this.tpCFDIsTotales.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsTotales.Size = new System.Drawing.Size(1482, 537);
			this.tpCFDIsTotales.TabIndex = 0;
			this.tpCFDIsTotales.Text = "CFDI'S TOTALES";
			this.tpCFDIsTotales.UseVisualStyleBackColor = true;
			this.flpFiltrosExcluye.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flpFiltrosExcluye.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpFiltrosExcluye.Controls.Add(this.chkExcluirNC03);
			this.flpFiltrosExcluye.Controls.Add(this.chkExcluirNC01);
			this.flpFiltrosExcluye.Controls.Add(this.flpTotales);
			this.flpFiltrosExcluye.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flpFiltrosExcluye.Location = new System.Drawing.Point(711, 6);
			this.flpFiltrosExcluye.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flpFiltrosExcluye.Name = "flpFiltrosExcluye";
			this.flpFiltrosExcluye.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flpFiltrosExcluye.Size = new System.Drawing.Size(761, 44);
			this.flpFiltrosExcluye.TabIndex = 144;
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
			this.flpFiltrosTipoComprobante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpFiltrosTipoComprobante.Controls.Add(this.chkPUE);
			this.flpFiltrosTipoComprobante.Controls.Add(this.chkPPD);
			this.flpFiltrosTipoComprobante.Controls.Add(this.chkComplementosPago);
			this.flpFiltrosTipoComprobante.Controls.Add(this.chkEgresos);
			this.flpFiltrosTipoComprobante.Controls.Add(this.btnFiltrarComprobantes);
			this.flpFiltrosTipoComprobante.Location = new System.Drawing.Point(4, 6);
			this.flpFiltrosTipoComprobante.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flpFiltrosTipoComprobante.Name = "flpFiltrosTipoComprobante";
			this.flpFiltrosTipoComprobante.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flpFiltrosTipoComprobante.Size = new System.Drawing.Size(617, 44);
			this.flpFiltrosTipoComprobante.TabIndex = 143;
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
			this.rvImpresionCFDIsTotales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIsTotales.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosSAT.rdlc";
			this.rvImpresionCFDIsTotales.Location = new System.Drawing.Point(4, 57);
			this.rvImpresionCFDIsTotales.Name = "rvImpresionCFDIsTotales";
			this.rvImpresionCFDIsTotales.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsTotales.Size = new System.Drawing.Size(1468, 454);
			this.rvImpresionCFDIsTotales.TabIndex = 2;
			this.tpCFDIsPrecargadosSAT.Controls.Add(this.rvImpresionCFDIsSAT);
			this.tpCFDIsPrecargadosSAT.Location = new System.Drawing.Point(4, 34);
			this.tpCFDIsPrecargadosSAT.Name = "tpCFDIsPrecargadosSAT";
			this.tpCFDIsPrecargadosSAT.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tpCFDIsPrecargadosSAT.Size = new System.Drawing.Size(1482, 537);
			this.tpCFDIsPrecargadosSAT.TabIndex = 1;
			this.tpCFDIsPrecargadosSAT.Text = "CFDI'S  PRECARGADOS POR SAT";
			this.tpCFDIsPrecargadosSAT.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIsSAT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rvImpresionCFDIsSAT.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosSAT.rdlc";
			this.rvImpresionCFDIsSAT.Location = new System.Drawing.Point(3, 3);
			this.rvImpresionCFDIsSAT.Name = "rvImpresionCFDIsSAT";
			this.rvImpresionCFDIsSAT.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsSAT.Size = new System.Drawing.Size(1476, 531);
			this.rvImpresionCFDIsSAT.TabIndex = 3;
			this.tpCFDIsConfrontaInformacion.Controls.Add(this.rvImpresionCFDIsConfronta);
			this.tpCFDIsConfrontaInformacion.Location = new System.Drawing.Point(4, 34);
			this.tpCFDIsConfrontaInformacion.Name = "tpCFDIsConfrontaInformacion";
			this.tpCFDIsConfrontaInformacion.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tpCFDIsConfrontaInformacion.Size = new System.Drawing.Size(1482, 537);
			this.tpCFDIsConfrontaInformacion.TabIndex = 2;
			this.tpCFDIsConfrontaInformacion.Text = "CONFRONTA DE INFORMACIÓN (DIFERENCIAS)";
			this.tpCFDIsConfrontaInformacion.UseVisualStyleBackColor = true;
			this.rvImpresionCFDIsConfronta.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rvImpresionCFDIsConfronta.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEgresosSAT.rdlc";
			this.rvImpresionCFDIsConfronta.Location = new System.Drawing.Point(3, 3);
			this.rvImpresionCFDIsConfronta.Name = "rvImpresionCFDIsConfronta";
			this.rvImpresionCFDIsConfronta.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsConfronta.Size = new System.Drawing.Size(1476, 531);
			this.rvImpresionCFDIsConfronta.TabIndex = 3;
			this.tpCFDIsEmitidos.Controls.Add(this.flowLayoutPanel1);
			this.tpCFDIsEmitidos.Controls.Add(this.rvImpresionCFDIsEmitidos);
			this.tpCFDIsEmitidos.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tpCFDIsEmitidos.Location = new System.Drawing.Point(4, 54);
			this.tpCFDIsEmitidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsEmitidos.Name = "tpCFDIsEmitidos";
			this.tpCFDIsEmitidos.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsEmitidos.Size = new System.Drawing.Size(1498, 611);
			this.tpCFDIsEmitidos.TabIndex = 1;
			this.tpCFDIsEmitidos.Text = "< CFDI EMITIDOS >";
			this.tpCFDIsEmitidos.UseVisualStyleBackColor = true;
			this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel1.Controls.Add(this.chkPUEemitidos);
			this.flowLayoutPanel1.Controls.Add(this.chkPPDemitidos);
			this.flowLayoutPanel1.Controls.Add(this.chkCPemitidos);
			this.flowLayoutPanel1.Controls.Add(this.chkEgresosEmitidos);
			this.flowLayoutPanel1.Controls.Add(this.btnFiltrarComprobantesEmitidos);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.flowLayoutPanel1.Size = new System.Drawing.Size(617, 44);
			this.flowLayoutPanel1.TabIndex = 145;
			this.chkPUEemitidos.AutoSize = true;
			this.chkPUEemitidos.Checked = true;
			this.chkPUEemitidos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPUEemitidos.Location = new System.Drawing.Point(8, 8);
			this.chkPUEemitidos.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkPUEemitidos.Name = "chkPUEemitidos";
			this.chkPUEemitidos.Size = new System.Drawing.Size(59, 22);
			this.chkPUEemitidos.TabIndex = 0;
			this.chkPUEemitidos.Text = "PUE";
			this.chkPUEemitidos.UseVisualStyleBackColor = true;
			this.chkPUEemitidos.CheckedChanged += new System.EventHandler(btnFiltrarComprobantesEmitidos_Click);
			this.chkPPDemitidos.AutoSize = true;
			this.chkPPDemitidos.Checked = true;
			this.chkPPDemitidos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPPDemitidos.Location = new System.Drawing.Point(71, 8);
			this.chkPPDemitidos.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkPPDemitidos.Name = "chkPPDemitidos";
			this.chkPPDemitidos.Size = new System.Drawing.Size(60, 22);
			this.chkPPDemitidos.TabIndex = 1;
			this.chkPPDemitidos.Text = "PPD";
			this.chkPPDemitidos.UseVisualStyleBackColor = true;
			this.chkPPDemitidos.CheckedChanged += new System.EventHandler(btnFiltrarComprobantesEmitidos_Click);
			this.chkCPemitidos.AutoSize = true;
			this.chkCPemitidos.Checked = true;
			this.chkCPemitidos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkCPemitidos.Location = new System.Drawing.Point(135, 8);
			this.chkCPemitidos.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkCPemitidos.Name = "chkCPemitidos";
			this.chkCPemitidos.Size = new System.Drawing.Size(162, 22);
			this.chkCPemitidos.TabIndex = 2;
			this.chkCPemitidos.Text = "Complementos Pago";
			this.chkCPemitidos.UseVisualStyleBackColor = true;
			this.chkCPemitidos.CheckedChanged += new System.EventHandler(btnFiltrarComprobantesEmitidos_Click);
			this.chkEgresosEmitidos.AutoSize = true;
			this.chkEgresosEmitidos.Checked = true;
			this.chkEgresosEmitidos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkEgresosEmitidos.Location = new System.Drawing.Point(301, 8);
			this.chkEgresosEmitidos.Margin = new System.Windows.Forms.Padding(2, 8, 2, 2);
			this.chkEgresosEmitidos.Name = "chkEgresosEmitidos";
			this.chkEgresosEmitidos.Size = new System.Drawing.Size(143, 22);
			this.chkEgresosEmitidos.TabIndex = 134;
			this.chkEgresosEmitidos.Text = "Egresos (Anticipo)";
			this.chkEgresosEmitidos.UseVisualStyleBackColor = true;
			this.chkEgresosEmitidos.CheckedChanged += new System.EventHandler(btnFiltrarComprobantesEmitidos_Click);
			this.btnFiltrarComprobantesEmitidos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltrarComprobantesEmitidos.BackColor = System.Drawing.Color.White;
			this.btnFiltrarComprobantesEmitidos.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnFiltrarComprobantesEmitidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltrarComprobantesEmitidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltrarComprobantesEmitidos.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltrarComprobantesEmitidos.Location = new System.Drawing.Point(450, 3);
			this.btnFiltrarComprobantesEmitidos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 5);
			this.btnFiltrarComprobantesEmitidos.Name = "btnFiltrarComprobantesEmitidos";
			this.btnFiltrarComprobantesEmitidos.Size = new System.Drawing.Size(39, 37);
			this.btnFiltrarComprobantesEmitidos.TabIndex = 133;
			this.btnFiltrarComprobantesEmitidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnFiltrarComprobantesEmitidos.UseVisualStyleBackColor = false;
			this.btnFiltrarComprobantesEmitidos.Click += new System.EventHandler(btnFiltrarComprobantesEmitidos_Click);
			this.rvImpresionCFDIsEmitidos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvImpresionCFDIsEmitidos.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptImprimeCFDIsFlujoEmitidosSAT.rdlc";
			this.rvImpresionCFDIsEmitidos.Location = new System.Drawing.Point(4, 52);
			this.rvImpresionCFDIsEmitidos.Name = "rvImpresionCFDIsEmitidos";
			this.rvImpresionCFDIsEmitidos.ServerReport.BearerToken = null;
			this.rvImpresionCFDIsEmitidos.Size = new System.Drawing.Size(1484, 522);
			this.rvImpresionCFDIsEmitidos.TabIndex = 144;
			this.tpCFDIsNominas.Controls.Add(this.tcNominasGeneral);
			this.tpCFDIsNominas.Font = new System.Drawing.Font("Microsoft Tai Le", 8.5f);
			this.tpCFDIsNominas.Location = new System.Drawing.Point(4, 54);
			this.tpCFDIsNominas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsNominas.Name = "tpCFDIsNominas";
			this.tpCFDIsNominas.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tpCFDIsNominas.Size = new System.Drawing.Size(1498, 611);
			this.tpCFDIsNominas.TabIndex = 2;
			this.tpCFDIsNominas.Text = "< CFDI NÓMINAS >";
			this.tpCFDIsNominas.UseVisualStyleBackColor = true;
			this.tcNominasGeneral.Controls.Add(this.tpAuxiliarPercepciones);
			this.tcNominasGeneral.Controls.Add(this.tpAuxiliarDeducciones);
			this.tcNominasGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tcNominasGeneral.Font = new System.Drawing.Font("Microsoft Tai Le", 8.5f, System.Drawing.FontStyle.Bold);
			this.tcNominasGeneral.ItemSize = new System.Drawing.Size(200, 35);
			this.tcNominasGeneral.Location = new System.Drawing.Point(4, 5);
			this.tcNominasGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tcNominasGeneral.Name = "tcNominasGeneral";
			this.tcNominasGeneral.SelectedIndex = 0;
			this.tcNominasGeneral.Size = new System.Drawing.Size(1490, 601);
			this.tcNominasGeneral.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tcNominasGeneral.TabIndex = 140;
			this.tpAuxiliarPercepciones.Controls.Add(this.rvAuxiliar);
			this.tpAuxiliarPercepciones.Location = new System.Drawing.Point(4, 39);
			this.tpAuxiliarPercepciones.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAuxiliarPercepciones.Name = "tpAuxiliarPercepciones";
			this.tpAuxiliarPercepciones.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAuxiliarPercepciones.Size = new System.Drawing.Size(1482, 558);
			this.tpAuxiliarPercepciones.TabIndex = 2;
			this.tpAuxiliarPercepciones.Text = "Auxiliar Percepciones";
			this.tpAuxiliarPercepciones.UseVisualStyleBackColor = true;
			this.rvAuxiliar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvAuxiliar.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptAuxiliarPercepcionesNominaSAT.rdlc";
			this.rvAuxiliar.Location = new System.Drawing.Point(2, 5);
			this.rvAuxiliar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvAuxiliar.Name = "rvAuxiliar";
			this.rvAuxiliar.ServerReport.BearerToken = null;
			this.rvAuxiliar.Size = new System.Drawing.Size(1477, 529);
			this.rvAuxiliar.TabIndex = 2;
			this.tpAuxiliarDeducciones.Controls.Add(this.rvAuxiliarDeducciones);
			this.tpAuxiliarDeducciones.Location = new System.Drawing.Point(4, 39);
			this.tpAuxiliarDeducciones.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAuxiliarDeducciones.Name = "tpAuxiliarDeducciones";
			this.tpAuxiliarDeducciones.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAuxiliarDeducciones.Size = new System.Drawing.Size(1482, 558);
			this.tpAuxiliarDeducciones.TabIndex = 4;
			this.tpAuxiliarDeducciones.Text = "Auxiliar Deducciones";
			this.tpAuxiliarDeducciones.UseVisualStyleBackColor = true;
			this.rvAuxiliarDeducciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvAuxiliarDeducciones.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptAuxiliarDeduccionesNominaSAT.rdlc";
			this.rvAuxiliarDeducciones.Location = new System.Drawing.Point(2, 5);
			this.rvAuxiliarDeducciones.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvAuxiliarDeducciones.Name = "rvAuxiliarDeducciones";
			this.rvAuxiliarDeducciones.ServerReport.BearerToken = null;
			this.rvAuxiliarDeducciones.Size = new System.Drawing.Size(1096, 529);
			this.rvAuxiliarDeducciones.TabIndex = 4;
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
			this.pnlFiltro.Location = new System.Drawing.Point(927, 8);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(1043, 47);
			this.pnlFiltro.TabIndex = 0;
			this.pnlFiltro.Visible = false;
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
			this.pnlFiltroFechas.Controls.Add(this.btnRefrescar);
			this.pnlFiltroFechas.Controls.Add(this.rdoPorMesComprobantes);
			this.pnlFiltroFechas.Controls.Add(this.pnlPorMesVentas);
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
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcGeneral.Controls.Add(this.tpGeneral);
			this.tcGeneral.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcGeneral.Location = new System.Drawing.Point(15, 29);
			this.tcGeneral.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcGeneral.Name = "tcGeneral";
			this.tcGeneral.SelectedIndex = 0;
			this.tcGeneral.Size = new System.Drawing.Size(1532, 838);
			this.tcGeneral.TabIndex = 129;
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
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.btnBuscaEmpresa.Click += new System.EventHandler(btnBuscaEmpresa_Click);
			this.flpEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flpEmpresas.Controls.Add(this.label1);
			this.flpEmpresas.Controls.Add(this.cmbEmpresas);
			this.flpEmpresas.Controls.Add(this.btnBuscaEmpresa);
			this.flpEmpresas.Location = new System.Drawing.Point(420, 8);
			this.flpEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.flpEmpresas.Name = "flpEmpresas";
			this.flpEmpresas.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
			this.flpEmpresas.Size = new System.Drawing.Size(822, 51);
			this.flpEmpresas.TabIndex = 139;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(4, 3);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
			this.label1.Size = new System.Drawing.Size(108, 39);
			this.label1.TabIndex = 136;
			this.label1.Text = "Empresa:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1556, 872);
			base.Controls.Add(this.flpEmpresas);
			base.Controls.Add(this.tcGeneral);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "InformacionPrecargadaSAT";
			this.Text = "Información Precargada SAT";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tpGeneral.ResumeLayout(false);
			this.tpGeneral.PerformLayout();
			this.tcCFDIsGeneral.ResumeLayout(false);
			this.tpCFDIsRecibidos.ResumeLayout(false);
			this.tcCFDIsRecibidos.ResumeLayout(false);
			this.tpCFDIsTotales.ResumeLayout(false);
			this.flpFiltrosExcluye.ResumeLayout(false);
			this.flpFiltrosExcluye.PerformLayout();
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
			this.flpFiltrosTipoComprobante.ResumeLayout(false);
			this.flpFiltrosTipoComprobante.PerformLayout();
			this.tpCFDIsPrecargadosSAT.ResumeLayout(false);
			this.tpCFDIsConfrontaInformacion.ResumeLayout(false);
			this.tpCFDIsEmitidos.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tpCFDIsNominas.ResumeLayout(false);
			this.tcNominasGeneral.ResumeLayout(false);
			this.tpAuxiliarPercepciones.ResumeLayout(false);
			this.tpAuxiliarDeducciones.ResumeLayout(false);
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			this.pnlFiltroFechas.ResumeLayout(false);
			this.pnlFiltroFechas.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcGeneral.ResumeLayout(false);
			this.flpEmpresas.ResumeLayout(false);
			this.flpEmpresas.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
