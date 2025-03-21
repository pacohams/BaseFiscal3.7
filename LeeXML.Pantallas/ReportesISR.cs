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
	public class ReportesISR : FormBase
	{
		private IContainer components = null;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private Label label3;

		private TextBox txtCantidadVentas;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private GroupBox gbDatosGenerales;

		private Label label4;

		private TextBox txtNombreFiscal;

		private TextBox txtRFC;

		private Label label5;

		private Label label24;

		private ComboBox cmbEmpresas;

		private Button btnBuscaEmpresa;

		private FlowLayoutPanel flpTotalesTodos;

		private Label label6;

		private TextBox txtNumComprobantes;

		private DataGridViewImageColumn dataGridViewImageColumn1;

		private BindingSource entCatalogoGenericoBindingSource;

		private BindingSource entEstadoDeCuentaBindingSource;

		private TabControl tcEstadosCuentaGeneral;

		private Panel pnlDatos;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private RadioButton rdoPorFechasComprobantes;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private PictureBox pictureBox1;

		private TabPage tpAnalitica;

		private TabPage tpAuxiliar;

		private ReportViewer rvAnalitica;

		private ReportViewer rvAuxiliar;

		private TabPage tabPage2;

		private ReportViewer rvDeduccionesAcumulado;

		private TabPage tabPage3;

		private ReportViewer rvAuxiliarDeducciones;

		private Panel panel1;

		private RadioButton rdoEnBaseFechaDevengada;

		private RadioButton rdoEnBaseFechaPago;

		private Label label11;

		private TextBox txtExcluyePrefijoFolio;

		private Label label12;

		private TextBox txtFiltraPrefijoFolio;

		private Label label18;

		private FlowLayoutPanel flowLayoutPanel10;

		private ToolStrip toolStrip4;

		private ToolStripLabel toolStripLabel14;

		private ToolStripTextBox tstTotalPercepciones;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripLabel toolStripLabel15;

		private ToolStripTextBox tstTotalExento;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripLabel toolStripLabel25;

		private ToolStripTextBox tstTotalGravado;

		private ToolStripSeparator toolStripSeparator20;

		private ToolStripLabel toolStripLabel16;

		private ToolStripTextBox tstTotalImpuesto;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstTotalEmpleados;

		private ToolStripSeparator toolStripSeparator1;

		private Panel pnlPorDiaVentas;

		private DateTimePicker dtpFechaHasta;

		private DateTimePicker dtpFechaDesde;

		private ComboBox cmbClientesHasta;

		private Label label1;

		private ComboBox cmbClientesDesde;

		private Label label2;

		private Label label7;

		private Label label8;

		private ComboBox cmbTipoEmpleados;

		private ComboBox cmbTotalExentoGravado;

		private Label label14;

		private TextBox txtPercepcionesHasta;

		private Label label13;

		private Label label10;

		private TextBox txtPercepcionesDesde;

		private Label label15;

		private TextBox txtDeduccionesHasta;

		private Label label16;

		private Label label17;

		private TextBox txtDeduccionesDesde;

		private BindingSource entClienteBindingSource;

		private DataGridView gvFiltroPercepciones;

		private DataGridViewTextBoxColumn claveDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;

		private DataGridView gvFiltroPercepcionesHasta;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private BindingSource entCatalogoPercepcionesBindingSource;

		private DataGridView gvFiltroDeduccionesHasta;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridView gvFiltroDeducciones;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private List<EntFactura> ListaNominas { get; set; }

		private List<EntCatalogoPercepciones> lstPercepciones { get; set; }

		private List<EntCatalogoPercepciones> ListaPercepcionesFiltro { get; set; }

		private List<EntCatalogoPercepciones> lstPercepcionesAuxiliar { get; set; }

		private List<EntCatalogoPercepciones> lstDeducciones { get; set; }

		private List<EntCatalogoPercepciones> ListaDeduccionesFiltro { get; set; }

		private List<EntCatalogoPercepciones> lstDeduccionesAuxiliar { get; set; }

		private bool Cargado { get; set; }

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					CargaDatosEmpresa(txtNombreFiscal, txtRFC);
					if (Cargado)
					{
						btnRefrescar.PerformClick();
						rvAnalitica.RefreshReport();
						rvAuxiliar.RefreshReport();
					}
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		public ReportesISR(DateTime FechaDesde, DateTime FechaHasta)
		{
			InitializeComponent();
			dtpFechaDesde.Value = FechaDesde;
			dtpFechaHasta.Value = FechaHasta;
		}

		private void Filtrar(List<EntFactura> ListaNominas, List<EntCatalogoPercepciones> lstPercepciones, List<EntCatalogoPercepciones> lstPercepcionesAuxiliar, List<EntCatalogoPercepciones> lstDeducciones, List<EntCatalogoPercepciones> lstDeduccionesAuxiliar)
		{
			int clienteDesdeId = 0;
			int clienteHastaId = 99999999;
			this.lstPercepciones = lstPercepciones.Where((EntCatalogoPercepciones P) => P.ClienteId >= clienteDesdeId && P.ClienteId <= clienteHastaId).ToList();
			this.lstPercepcionesAuxiliar = lstPercepcionesAuxiliar.Where((EntCatalogoPercepciones P) => P.ClienteId >= clienteDesdeId && P.ClienteId <= clienteHastaId).ToList();
			this.lstDeducciones = lstDeducciones.Where((EntCatalogoPercepciones P) => P.ClienteId >= clienteDesdeId && P.ClienteId <= clienteHastaId).ToList();
			this.lstDeduccionesAuxiliar = lstDeduccionesAuxiliar.Where((EntCatalogoPercepciones P) => P.ClienteId >= clienteDesdeId && P.ClienteId <= clienteHastaId).ToList();
			if (cmbTipoEmpleados.SelectedIndex == 1)
			{
				this.lstPercepciones = lstPercepciones.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) > 4 && ConvierteTextoAInteger(P.TipoRegimen) < 11).ToList();
				this.lstPercepcionesAuxiliar = lstPercepcionesAuxiliar.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) > 4 && ConvierteTextoAInteger(P.TipoRegimen) < 11).ToList();
				this.lstDeducciones = lstDeducciones.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) > 4 && ConvierteTextoAInteger(P.TipoRegimen) < 11).ToList();
				this.lstDeduccionesAuxiliar = lstDeduccionesAuxiliar.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) > 4 && ConvierteTextoAInteger(P.TipoRegimen) < 11).ToList();
			}
			else if (cmbTipoEmpleados.SelectedIndex == 2)
			{
				lstPercepciones = lstPercepciones.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) <= 4 && ConvierteTextoAInteger(P.TipoRegimen) >= 11).ToList();
				lstPercepcionesAuxiliar = lstPercepcionesAuxiliar.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) <= 4 && ConvierteTextoAInteger(P.TipoRegimen) >= 11).ToList();
				lstDeducciones = lstDeducciones.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) <= 4 && ConvierteTextoAInteger(P.TipoRegimen) >= 11).ToList();
				lstDeduccionesAuxiliar = lstDeduccionesAuxiliar.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.TipoRegimen) <= 4 && ConvierteTextoAInteger(P.TipoRegimen) >= 11).ToList();
			}
			if (cmbTotalExentoGravado.SelectedIndex == 1)
			{
				foreach (EntCatalogoPercepciones f in lstPercepciones)
				{
					f.Gravado = 0m;
					f.GravadoB = false;
				}
				foreach (EntCatalogoPercepciones f2 in lstPercepcionesAuxiliar)
				{
					f2.Gravado = 0m;
					f2.GravadoB = false;
				}
			}
			else if (cmbTotalExentoGravado.SelectedIndex == 2)
			{
				foreach (EntCatalogoPercepciones f3 in lstPercepciones)
				{
					f3.Excento = 0m;
					f3.ExcentoB = false;
				}
				foreach (EntCatalogoPercepciones f4 in lstPercepcionesAuxiliar)
				{
					f4.Excento = 0m;
					f4.ExcentoB = false;
				}
			}
			if (!string.IsNullOrWhiteSpace(txtPercepcionesDesde.Text) && !string.IsNullOrWhiteSpace(txtPercepcionesHasta.Text))
			{
				int percepcionDesde = ConvierteTextoAInteger(txtPercepcionesDesde.Text);
				int percepcionHasta = ConvierteTextoAInteger(txtPercepcionesHasta.Text);
				this.lstPercepciones = lstPercepciones.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.Clave) >= percepcionDesde && ConvierteTextoAInteger(P.Clave) <= percepcionHasta).ToList();
				this.lstPercepcionesAuxiliar = lstPercepcionesAuxiliar.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.Clave) >= percepcionDesde && ConvierteTextoAInteger(P.Clave) <= percepcionHasta).ToList();
			}
			if (!string.IsNullOrWhiteSpace(txtDeduccionesDesde.Text) && !string.IsNullOrWhiteSpace(txtDeduccionesHasta.Text))
			{
				int deduccionDesde = ConvierteTextoAInteger(txtDeduccionesDesde.Text);
				int dedeccionHasta = ConvierteTextoAInteger(txtDeduccionesHasta.Text);
				this.lstDeducciones = lstDeducciones.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.Clave) >= deduccionDesde && ConvierteTextoAInteger(P.Clave) <= dedeccionHasta).ToList();
				this.lstDeduccionesAuxiliar = lstDeduccionesAuxiliar.Where((EntCatalogoPercepciones P) => ConvierteTextoAInteger(P.Clave) >= deduccionDesde && ConvierteTextoAInteger(P.Clave) <= dedeccionHasta).ToList();
			}
		}

		private void PoneTotales()
		{
		}

		private void InicializaPantalla()
		{
			CargaDatosEmpresa(txtNombreFiscal, txtRFC);
			cmbClientesDesde.DataSource = new List<EntCliente>();
			cmbClientesHasta.DataSource = new List<EntCliente>();
			new CxC().CargaClientes(cmbClientesDesde, Program.EmpresaSeleccionada.Id);
			cmbClientesDesde.SelectedIndex = 0;
			new CxC().CargaClientes(cmbClientesHasta, Program.EmpresaSeleccionada.Id);
			cmbClientesHasta.SelectedIndex = cmbClientesHasta.Items.Count - 1;
			List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
			lst.Add(new EntCatalogoGenerico
			{
				Id = -1,
				Descripcion = "-CUALQUIERA-"
			});
			lst.Add(new EntCatalogoGenerico
			{
				Id = 1,
				Descripcion = "ASIMILADOS"
			});
			lst.Add(new EntCatalogoGenerico
			{
				Id = 2,
				Descripcion = "SUELDOS"
			});
			cmbTipoEmpleados.DataSource = lst;
			cmbTipoEmpleados.SelectedIndex = 0;
			List<EntCatalogoGenerico> lst2 = new List<EntCatalogoGenerico>();
			lst2.Add(new EntCatalogoGenerico
			{
				Id = -1,
				Descripcion = "-EXENTO/GRAVADO-"
			});
			lst2.Add(new EntCatalogoGenerico
			{
				Id = 1,
				Descripcion = "SOLO EXENTO"
			});
			lst2.Add(new EntCatalogoGenerico
			{
				Id = 2,
				Descripcion = "SOLO GRAVADO"
			});
			cmbTotalExentoGravado.DataSource = lst2;
			cmbTotalExentoGravado.SelectedIndex = 0;
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
				else
				{
					cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				}
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				InicializaPantalla();
				Cargado = true;
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				SetDefaultCursor();
				MuestraExcepcion(ex);
			}
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				txtFiltraPrefijoFolio.Clear();
				txtExcluyePrefijoFolio.Clear();
				DateTime fechaDesde = dtpFechaDesde.Value.Date;
				DateTime fechaHasta = dtpFechaHasta.Value.Date;
				if (rdoEnBaseFechaPago.Checked)
				{
					lstPercepciones = new BusFacturas().ObtieneComprobantesFiscalesNominasPercepcionesXML(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
					lstPercepcionesAuxiliar = new BusFacturas().ObtieneComprobantesFiscalesNominasPercepcionesAuxiliar(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
					lstDeducciones = new BusFacturas().ObtieneComprobantesFiscalesNominasDeduccionesXML(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
					lstDeduccionesAuxiliar = new BusFacturas().ObtieneComprobantesFiscalesNominasDeduccionesAuxiliar(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
				}
				else
				{
					lstPercepciones = new BusFacturas().ObtieneComprobantesFiscalesNominasPercepcionesPorFechaFinXML(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
					lstPercepcionesAuxiliar = new BusFacturas().ObtieneComprobantesFiscalesNominasPercepcionesAuxiliarPorFechaFin(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
					lstDeducciones = new BusFacturas().ObtieneComprobantesFiscalesNominasDeduccionesPorFechaFinXML(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
					lstDeduccionesAuxiliar = new BusFacturas().ObtieneComprobantesFiscalesNominasDeduccionesAuxiliarPorFechaFin(base.EmpresaSeleccionada, fechaDesde, fechaHasta);
				}
				Filtrar(ListaNominas, lstPercepciones, lstPercepcionesAuxiliar, lstDeducciones, lstDeduccionesAuxiliar);
				ListaPercepcionesFiltro = lstPercepciones.ToList();
				ListaDeduccionesFiltro = lstDeducciones.ToList();
				PoneTotales();
				ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + base.EmpresaSeleccionada.Nombre);
				ReportParameter parmFecha = new ReportParameter("parmFecha", " " + fechaDesde.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(fechaHasta.Month, fechaHasta.Year).ToString("dd/MMM/yyyy").ToUpper());
				rvAnalitica.LocalReport.SetParameters(parmEmpresa);
				rvAnalitica.LocalReport.SetParameters(parmFecha);
				entEstadoDeCuentaBindingSource.DataSource = lstPercepciones;
				rvAnalitica.LocalReport.DataSources.Clear();
				rvAnalitica.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPercepciones));
				rvAnalitica.RefreshReport();
				rvAuxiliar.LocalReport.SetParameters(parmEmpresa);
				rvAuxiliar.LocalReport.SetParameters(parmFecha);
				rvAuxiliar.LocalReport.DataSources.Clear();
				rvAuxiliar.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPercepcionesAuxiliar));
				rvAuxiliar.RefreshReport();
				rvDeduccionesAcumulado.LocalReport.SetParameters(parmEmpresa);
				rvDeduccionesAcumulado.LocalReport.SetParameters(parmFecha);
				rvDeduccionesAcumulado.LocalReport.DataSources.Clear();
				rvDeduccionesAcumulado.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDeducciones));
				rvDeduccionesAcumulado.RefreshReport();
				rvAuxiliarDeducciones.LocalReport.SetParameters(parmEmpresa);
				rvAuxiliarDeducciones.LocalReport.SetParameters(parmFecha);
				rvAuxiliarDeducciones.LocalReport.DataSources.Clear();
				rvAuxiliarDeducciones.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDeduccionesAuxiliar));
				rvAuxiliarDeducciones.RefreshReport();
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

		private void tcEstadosCuentaGeneral_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				tcEstadosCuentaGeneral.SelectedIndex = 0;
				MuestraExcepcion(ex);
			}
		}

		private void txtFiltraPrefijoFolio_TextChanged(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				List<EntCatalogoPercepciones> lstPer = lstPercepciones.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtFiltraPrefijoFolio.Text.ToUpper())).ToList();
				List<EntCatalogoPercepciones> lstPerAux = lstPercepcionesAuxiliar.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtFiltraPrefijoFolio.Text.ToUpper())).ToList();
				List<EntCatalogoPercepciones> lstDed = lstDeducciones.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtFiltraPrefijoFolio.Text.ToUpper())).ToList();
				List<EntCatalogoPercepciones> lstDedAux = lstDeduccionesAuxiliar.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtFiltraPrefijoFolio.Text.ToUpper())).ToList();
				ListaPercepcionesFiltro = lstPer;
				PoneTotales();
				entEstadoDeCuentaBindingSource.DataSource = lstPer;
				rvAnalitica.LocalReport.DataSources.Clear();
				rvAnalitica.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPer));
				rvAnalitica.RefreshReport();
				rvAuxiliar.LocalReport.DataSources.Clear();
				rvAuxiliar.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPerAux));
				rvAuxiliar.RefreshReport();
				rvDeduccionesAcumulado.LocalReport.DataSources.Clear();
				rvDeduccionesAcumulado.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDed));
				rvDeduccionesAcumulado.RefreshReport();
				rvAuxiliarDeducciones.LocalReport.DataSources.Clear();
				rvAuxiliarDeducciones.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDedAux));
				rvAuxiliarDeducciones.RefreshReport();
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

		private void txtExcluyePrefijoFolio_TextChanged(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				List<EntCatalogoPercepciones> lstPer = lstPercepciones.ToList();
				List<EntCatalogoPercepciones> lstPerAux = lstPercepcionesAuxiliar.ToList();
				List<EntCatalogoPercepciones> lstDed = lstDeducciones.ToList();
				List<EntCatalogoPercepciones> lstDedAux = lstDeduccionesAuxiliar.ToList();
				if (!string.IsNullOrWhiteSpace(txtExcluyePrefijoFolio.Text))
				{
					lstPer = lstPer.Except(lstPercepciones.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtExcluyePrefijoFolio.Text.ToUpper()))).ToList();
					lstPerAux = lstPerAux.Except(lstPercepcionesAuxiliar.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtExcluyePrefijoFolio.Text.ToUpper()))).ToList();
					lstDed = lstDed.Except(lstDeducciones.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtExcluyePrefijoFolio.Text.ToUpper()))).ToList();
					lstDedAux = lstDedAux.Except(lstDeduccionesAuxiliar.Where((EntCatalogoPercepciones P) => P.Folio.ToUpper().StartsWith(txtExcluyePrefijoFolio.Text.ToUpper()))).ToList();
				}
				ListaPercepcionesFiltro = lstPer;
				PoneTotales();
				entEstadoDeCuentaBindingSource.DataSource = lstPer;
				rvAnalitica.LocalReport.DataSources.Clear();
				rvAnalitica.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPer));
				rvAnalitica.RefreshReport();
				rvAuxiliar.LocalReport.DataSources.Clear();
				rvAuxiliar.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstPerAux));
				rvAuxiliar.RefreshReport();
				rvDeduccionesAcumulado.LocalReport.DataSources.Clear();
				rvDeduccionesAcumulado.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDed));
				rvDeduccionesAcumulado.RefreshReport();
				rvAuxiliarDeducciones.LocalReport.DataSources.Clear();
				rvAuxiliarDeducciones.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstDedAux));
				rvAuxiliarDeducciones.RefreshReport();
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

		private void txtPercepcionesDesde_TextChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvFiltroPercepciones_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				gvFiltroPercepciones.Visible = false;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPercepcionesHasta_TextChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvFiltroPercepcionesHasta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				gvFiltroPercepciones.Visible = false;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPercepcionesDesde_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					gvFiltroPercepciones.Visible = false;
				}
				else if (e.KeyChar == '\u001b')
				{
					gvFiltroPercepciones.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPercepcionesHasta_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					gvFiltroPercepcionesHasta.Visible = false;
				}
				else if (e.KeyChar == '\u001b')
				{
					gvFiltroPercepcionesHasta.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtDeduccionesDesde_TextChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtDeduccionesHasta_TextChanged(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtDeduccionesDesde_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					gvFiltroDeducciones.Visible = false;
				}
				else if (e.KeyChar == '\u001b')
				{
					gvFiltroDeducciones.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtDeduccionesHasta_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					gvFiltroDeduccionesHasta.Visible = false;
				}
				else if (e.KeyChar == '\u001b')
				{
					gvFiltroDeduccionesHasta.Visible = false;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvFiltroDeducciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				gvFiltroDeducciones.Visible = false;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvFiltroDeduccionesHasta_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				gvFiltroDeducciones.Visible = false;
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnlDatos = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.gvFiltroDeduccionesHasta = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entCatalogoPercepcionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label15 = new System.Windows.Forms.Label();
			this.gvFiltroDeducciones = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.txtDeduccionesHasta = new System.Windows.Forms.TextBox();
			this.gvFiltroPercepcionesHasta = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label16 = new System.Windows.Forms.Label();
			this.gvFiltroPercepciones = new System.Windows.Forms.DataGridView();
			this.claveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label17 = new System.Windows.Forms.Label();
			this.txtDeduccionesDesde = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtPercepcionesHasta = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtPercepcionesDesde = new System.Windows.Forms.TextBox();
			this.cmbTotalExentoGravado = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cmbTipoEmpleados = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbClientesHasta = new System.Windows.Forms.ComboBox();
			this.entClienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.cmbClientesDesde = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.pnlPorDiaVentas = new System.Windows.Forms.Panel();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.label12 = new System.Windows.Forms.Label();
			this.txtFiltraPrefijoFolio = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtExcluyePrefijoFolio = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rdoEnBaseFechaDevengada = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaPago = new System.Windows.Forms.RadioButton();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.tcEstadosCuentaGeneral = new System.Windows.Forms.TabControl();
			this.tpAnalitica = new System.Windows.Forms.TabPage();
			this.rvAnalitica = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tpAuxiliar = new System.Windows.Forms.TabPage();
			this.rvAuxiliar = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.rvDeduccionesAcumulado = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.rvAuxiliarDeducciones = new Microsoft.Reporting.WinForms.ReportViewer();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNumComprobantes = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.rdoPorFechasComprobantes = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstTotalEmpleados = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
			this.tstTotalPercepciones = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
			this.tstTotalExento = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel25 = new System.Windows.Forms.ToolStripLabel();
			this.tstTotalGravado = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel16 = new System.Windows.Forms.ToolStripLabel();
			this.tstTotalImpuesto = new System.Windows.Forms.ToolStripTextBox();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pnlDatos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroDeduccionesHasta).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoPercepcionesBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroDeducciones).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroPercepcionesHasta).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroPercepciones).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entClienteBindingSource).BeginInit();
			this.pnlPorDiaVentas.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.gbDatosGenerales.SuspendLayout();
			this.tcEstadosCuentaGeneral.SuspendLayout();
			this.tpAnalitica.SuspendLayout();
			this.tpAuxiliar.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entEstadoDeCuentaBindingSource).BeginInit();
			base.SuspendLayout();
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 34);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1624, 862);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.pnlDatos);
			this.tabPage1.Controls.Add(this.tcEstadosCuentaGeneral);
			this.tabPage1.Controls.Add(this.flpTotalesTodos);
			this.tabPage1.Controls.Add(this.rdoPorFechasComprobantes);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Controls.Add(this.flowLayoutPanel10);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 31);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1616, 827);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Área de Trabajo";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlDatos.Controls.Add(this.btnRefrescar);
			this.pnlDatos.Controls.Add(this.gvFiltroDeduccionesHasta);
			this.pnlDatos.Controls.Add(this.label15);
			this.pnlDatos.Controls.Add(this.gvFiltroDeducciones);
			this.pnlDatos.Controls.Add(this.txtDeduccionesHasta);
			this.pnlDatos.Controls.Add(this.gvFiltroPercepcionesHasta);
			this.pnlDatos.Controls.Add(this.label16);
			this.pnlDatos.Controls.Add(this.gvFiltroPercepciones);
			this.pnlDatos.Controls.Add(this.label17);
			this.pnlDatos.Controls.Add(this.txtDeduccionesDesde);
			this.pnlDatos.Controls.Add(this.label14);
			this.pnlDatos.Controls.Add(this.txtPercepcionesHasta);
			this.pnlDatos.Controls.Add(this.label13);
			this.pnlDatos.Controls.Add(this.label10);
			this.pnlDatos.Controls.Add(this.txtPercepcionesDesde);
			this.pnlDatos.Controls.Add(this.cmbTotalExentoGravado);
			this.pnlDatos.Controls.Add(this.cmbTipoEmpleados);
			this.pnlDatos.Controls.Add(this.label8);
			this.pnlDatos.Controls.Add(this.cmbClientesHasta);
			this.pnlDatos.Controls.Add(this.label1);
			this.pnlDatos.Controls.Add(this.cmbClientesDesde);
			this.pnlDatos.Controls.Add(this.label2);
			this.pnlDatos.Controls.Add(this.label7);
			this.pnlDatos.Controls.Add(this.pnlPorDiaVentas);
			this.pnlDatos.Controls.Add(this.label12);
			this.pnlDatos.Controls.Add(this.txtFiltraPrefijoFolio);
			this.pnlDatos.Controls.Add(this.label11);
			this.pnlDatos.Controls.Add(this.txtExcluyePrefijoFolio);
			this.pnlDatos.Controls.Add(this.panel1);
			this.pnlDatos.Controls.Add(this.pictureBox1);
			this.pnlDatos.Controls.Add(this.gbDatosGenerales);
			this.pnlDatos.Controls.Add(this.rdoPorMesComprobantes);
			this.pnlDatos.Location = new System.Drawing.Point(3, 2);
			this.pnlDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlDatos.Name = "pnlDatos";
			this.pnlDatos.Size = new System.Drawing.Size(1471, 176);
			this.pnlDatos.TabIndex = 140;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(1054, 34);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(111, 106);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.gvFiltroDeduccionesHasta.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvFiltroDeduccionesHasta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvFiltroDeduccionesHasta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvFiltroDeduccionesHasta.AutoGenerateColumns = false;
			this.gvFiltroDeduccionesHasta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvFiltroDeduccionesHasta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gvFiltroDeduccionesHasta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvFiltroDeduccionesHasta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvFiltroDeduccionesHasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvFiltroDeduccionesHasta.Columns.AddRange(this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4);
			this.gvFiltroDeduccionesHasta.DataSource = this.entCatalogoPercepcionesBindingSource;
			this.gvFiltroDeduccionesHasta.Location = new System.Drawing.Point(702, 135);
			this.gvFiltroDeduccionesHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvFiltroDeduccionesHasta.Name = "gvFiltroDeduccionesHasta";
			this.gvFiltroDeduccionesHasta.ReadOnly = true;
			this.gvFiltroDeduccionesHasta.RowHeadersVisible = false;
			this.gvFiltroDeduccionesHasta.RowHeadersWidth = 20;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			this.gvFiltroDeduccionesHasta.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.gvFiltroDeduccionesHasta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvFiltroDeduccionesHasta.Size = new System.Drawing.Size(124, 0);
			this.gvFiltroDeduccionesHasta.TabIndex = 182;
			this.gvFiltroDeduccionesHasta.Visible = false;
			this.gvFiltroDeduccionesHasta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvFiltroDeduccionesHasta_CellContentClick);
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Clave";
			this.dataGridViewTextBoxColumn3.FillWeight = 1f;
			this.dataGridViewTextBoxColumn3.HeaderText = "Clave";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn4.FillWeight = 2f;
			this.dataGridViewTextBoxColumn4.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.entCatalogoPercepcionesBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoPercepciones);
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(662, 111);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(46, 18);
			this.label15.TabIndex = 176;
			this.label15.Text = "Hasta:";
			this.gvFiltroDeducciones.AllowUserToAddRows = false;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvFiltroDeducciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
			this.gvFiltroDeducciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvFiltroDeducciones.AutoGenerateColumns = false;
			this.gvFiltroDeducciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvFiltroDeducciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gvFiltroDeducciones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvFiltroDeducciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvFiltroDeducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvFiltroDeducciones.Columns.AddRange(this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6);
			this.gvFiltroDeducciones.DataSource = this.entCatalogoPercepcionesBindingSource;
			this.gvFiltroDeducciones.Location = new System.Drawing.Point(544, 135);
			this.gvFiltroDeducciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvFiltroDeducciones.Name = "gvFiltroDeducciones";
			this.gvFiltroDeducciones.ReadOnly = true;
			this.gvFiltroDeducciones.RowHeadersVisible = false;
			this.gvFiltroDeducciones.RowHeadersWidth = 20;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
			this.gvFiltroDeducciones.RowsDefaultCellStyle = dataGridViewCellStyle4;
			this.gvFiltroDeducciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvFiltroDeducciones.Size = new System.Drawing.Size(124, 0);
			this.gvFiltroDeducciones.TabIndex = 181;
			this.gvFiltroDeducciones.Visible = false;
			this.gvFiltroDeducciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvFiltroDeducciones_CellContentClick);
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Clave";
			this.dataGridViewTextBoxColumn5.FillWeight = 1f;
			this.dataGridViewTextBoxColumn5.HeaderText = "Clave";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn6.FillWeight = 2f;
			this.dataGridViewTextBoxColumn6.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.txtDeduccionesHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesHasta.Location = new System.Drawing.Point(717, 105);
			this.txtDeduccionesHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDeduccionesHasta.Name = "txtDeduccionesHasta";
			this.txtDeduccionesHasta.Size = new System.Drawing.Size(90, 30);
			this.txtDeduccionesHasta.TabIndex = 175;
			this.txtDeduccionesHasta.TextChanged += new System.EventHandler(txtDeduccionesHasta_TextChanged);
			this.txtDeduccionesHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDeduccionesHasta_KeyPress);
			this.gvFiltroPercepcionesHasta.AllowUserToAddRows = false;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvFiltroPercepcionesHasta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
			this.gvFiltroPercepcionesHasta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvFiltroPercepcionesHasta.AutoGenerateColumns = false;
			this.gvFiltroPercepcionesHasta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvFiltroPercepcionesHasta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gvFiltroPercepcionesHasta.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvFiltroPercepcionesHasta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvFiltroPercepcionesHasta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvFiltroPercepcionesHasta.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2);
			this.gvFiltroPercepcionesHasta.DataSource = this.entCatalogoPercepcionesBindingSource;
			this.gvFiltroPercepcionesHasta.Location = new System.Drawing.Point(717, 62);
			this.gvFiltroPercepcionesHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvFiltroPercepcionesHasta.Name = "gvFiltroPercepcionesHasta";
			this.gvFiltroPercepcionesHasta.ReadOnly = true;
			this.gvFiltroPercepcionesHasta.RowHeadersVisible = false;
			this.gvFiltroPercepcionesHasta.RowHeadersWidth = 20;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			this.gvFiltroPercepcionesHasta.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.gvFiltroPercepcionesHasta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvFiltroPercepcionesHasta.Size = new System.Drawing.Size(126, 0);
			this.gvFiltroPercepcionesHasta.TabIndex = 178;
			this.gvFiltroPercepcionesHasta.Visible = false;
			this.gvFiltroPercepcionesHasta.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvFiltroPercepcionesHasta_CellContentDoubleClick);
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Clave";
			this.dataGridViewTextBoxColumn1.FillWeight = 1f;
			this.dataGridViewTextBoxColumn1.HeaderText = "Clave";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Descripcion";
			this.dataGridViewTextBoxColumn2.FillWeight = 2f;
			this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(524, 111);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(28, 18);
			this.label16.TabIndex = 174;
			this.label16.Text = "De:";
			this.gvFiltroPercepciones.AllowUserToAddRows = false;
			dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvFiltroPercepciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
			this.gvFiltroPercepciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvFiltroPercepciones.AutoGenerateColumns = false;
			this.gvFiltroPercepciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvFiltroPercepciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gvFiltroPercepciones.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvFiltroPercepciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvFiltroPercepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvFiltroPercepciones.Columns.AddRange(this.claveDataGridViewTextBoxColumn, this.descripcionDataGridViewTextBoxColumn);
			this.gvFiltroPercepciones.DataSource = this.entCatalogoPercepcionesBindingSource;
			this.gvFiltroPercepciones.Location = new System.Drawing.Point(560, 62);
			this.gvFiltroPercepciones.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvFiltroPercepciones.Name = "gvFiltroPercepciones";
			this.gvFiltroPercepciones.ReadOnly = true;
			this.gvFiltroPercepciones.RowHeadersVisible = false;
			this.gvFiltroPercepciones.RowHeadersWidth = 20;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
			this.gvFiltroPercepciones.RowsDefaultCellStyle = dataGridViewCellStyle8;
			this.gvFiltroPercepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvFiltroPercepciones.Size = new System.Drawing.Size(126, 0);
			this.gvFiltroPercepciones.TabIndex = 177;
			this.gvFiltroPercepciones.Visible = false;
			this.gvFiltroPercepciones.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvFiltroPercepciones_CellContentDoubleClick);
			this.claveDataGridViewTextBoxColumn.DataPropertyName = "Clave";
			this.claveDataGridViewTextBoxColumn.FillWeight = 1f;
			this.claveDataGridViewTextBoxColumn.HeaderText = "Clave";
			this.claveDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.claveDataGridViewTextBoxColumn.Name = "claveDataGridViewTextBoxColumn";
			this.claveDataGridViewTextBoxColumn.ReadOnly = true;
			this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
			this.descripcionDataGridViewTextBoxColumn.FillWeight = 2f;
			this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
			this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
			this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new System.Drawing.Point(484, 75);
			this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(123, 23);
			this.label17.TabIndex = 172;
			this.label17.Text = "Deducciones:";
			this.txtDeduccionesDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesDesde.Location = new System.Drawing.Point(560, 105);
			this.txtDeduccionesDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDeduccionesDesde.Name = "txtDeduccionesDesde";
			this.txtDeduccionesDesde.Size = new System.Drawing.Size(90, 30);
			this.txtDeduccionesDesde.TabIndex = 173;
			this.txtDeduccionesDesde.TextChanged += new System.EventHandler(txtDeduccionesDesde_TextChanged);
			this.txtDeduccionesDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDeduccionesDesde_KeyPress);
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(662, 45);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(46, 18);
			this.label14.TabIndex = 171;
			this.label14.Text = "Hasta:";
			this.txtPercepcionesHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPercepcionesHasta.Location = new System.Drawing.Point(717, 38);
			this.txtPercepcionesHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtPercepcionesHasta.Name = "txtPercepcionesHasta";
			this.txtPercepcionesHasta.Size = new System.Drawing.Size(90, 30);
			this.txtPercepcionesHasta.TabIndex = 170;
			this.txtPercepcionesHasta.TextChanged += new System.EventHandler(txtPercepcionesHasta_TextChanged);
			this.txtPercepcionesHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPercepcionesHasta_KeyPress);
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(524, 45);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(28, 18);
			this.label13.TabIndex = 169;
			this.label13.Text = "De:";
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new System.Drawing.Point(484, 9);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(127, 23);
			this.label10.TabIndex = 167;
			this.label10.Text = "Percepciones:";
			this.txtPercepcionesDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPercepcionesDesde.Location = new System.Drawing.Point(560, 38);
			this.txtPercepcionesDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtPercepcionesDesde.Name = "txtPercepcionesDesde";
			this.txtPercepcionesDesde.Size = new System.Drawing.Size(90, 30);
			this.txtPercepcionesDesde.TabIndex = 168;
			this.txtPercepcionesDesde.TextChanged += new System.EventHandler(txtPercepcionesDesde_TextChanged);
			this.txtPercepcionesDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtPercepcionesDesde_KeyPress);
			this.cmbTotalExentoGravado.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbTotalExentoGravado.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbTotalExentoGravado.DisplayMember = "Descripcion";
			this.cmbTotalExentoGravado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTotalExentoGravado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbTotalExentoGravado.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbTotalExentoGravado.ForeColor = System.Drawing.Color.Black;
			this.cmbTotalExentoGravado.FormattingEnabled = true;
			this.cmbTotalExentoGravado.Location = new System.Drawing.Point(148, 125);
			this.cmbTotalExentoGravado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbTotalExentoGravado.Name = "cmbTotalExentoGravado";
			this.cmbTotalExentoGravado.Size = new System.Drawing.Size(247, 34);
			this.cmbTotalExentoGravado.TabIndex = 166;
			this.cmbTotalExentoGravado.ValueMember = "Id";
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.cmbTipoEmpleados.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbTipoEmpleados.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbTipoEmpleados.DisplayMember = "Descripcion";
			this.cmbTipoEmpleados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbTipoEmpleados.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbTipoEmpleados.ForeColor = System.Drawing.Color.Black;
			this.cmbTipoEmpleados.FormattingEnabled = true;
			this.cmbTipoEmpleados.Location = new System.Drawing.Point(1184, 82);
			this.cmbTipoEmpleados.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbTipoEmpleados.Name = "cmbTipoEmpleados";
			this.cmbTipoEmpleados.Size = new System.Drawing.Size(187, 34);
			this.cmbTipoEmpleados.TabIndex = 164;
			this.cmbTipoEmpleados.ValueMember = "Id";
			this.cmbTipoEmpleados.Visible = false;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new System.Drawing.Point(1050, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(134, 23);
			this.label8.TabIndex = 163;
			this.label8.Text = "Tipo Empleado:";
			this.label8.Visible = false;
			this.cmbClientesHasta.DataSource = this.entClienteBindingSource;
			this.cmbClientesHasta.DisplayMember = "NombreFiscal";
			this.cmbClientesHasta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbClientesHasta.FormattingEnabled = true;
			this.cmbClientesHasta.Location = new System.Drawing.Point(1366, 40);
			this.cmbClientesHasta.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cmbClientesHasta.Name = "cmbClientesHasta";
			this.cmbClientesHasta.Size = new System.Drawing.Size(108, 26);
			this.cmbClientesHasta.TabIndex = 162;
			this.cmbClientesHasta.ValueMember = "Id";
			this.cmbClientesHasta.Visible = false;
			this.entClienteBindingSource.DataSource = typeof(LeeXMLEntidades.EntCliente);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1316, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 18);
			this.label1.TabIndex = 161;
			this.label1.Text = "Hasta:";
			this.label1.Visible = false;
			this.cmbClientesDesde.DataSource = this.entClienteBindingSource;
			this.cmbClientesDesde.DisplayMember = "NombreFiscal";
			this.cmbClientesDesde.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbClientesDesde.FormattingEnabled = true;
			this.cmbClientesDesde.Location = new System.Drawing.Point(1184, 38);
			this.cmbClientesDesde.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cmbClientesDesde.Name = "cmbClientesDesde";
			this.cmbClientesDesde.Size = new System.Drawing.Size(112, 26);
			this.cmbClientesDesde.TabIndex = 160;
			this.cmbClientesDesde.ValueMember = "Id";
			this.cmbClientesDesde.Visible = false;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(1148, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 18);
			this.label2.TabIndex = 159;
			this.label2.Text = "De:";
			this.label2.Visible = false;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new System.Drawing.Point(1082, 9);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 23);
			this.label7.TabIndex = 158;
			this.label7.Text = "Empleados:";
			this.label7.Visible = false;
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaHasta);
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaDesde);
			this.pnlPorDiaVentas.Location = new System.Drawing.Point(574, 274);
			this.pnlPorDiaVentas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlPorDiaVentas.Name = "pnlPorDiaVentas";
			this.pnlPorDiaVentas.Size = new System.Drawing.Size(364, 49);
			this.pnlPorDiaVentas.TabIndex = 157;
			this.pnlPorDiaVentas.Visible = false;
			this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaHasta.Location = new System.Drawing.Point(180, 11);
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
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label12.Location = new System.Drawing.Point(846, 9);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(206, 23);
			this.label12.TabIndex = 155;
			this.label12.Text = "Filtrar por prefijo Folio:";
			this.txtFiltraPrefijoFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFiltraPrefijoFolio.Location = new System.Drawing.Point(921, 38);
			this.txtFiltraPrefijoFolio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtFiltraPrefijoFolio.Name = "txtFiltraPrefijoFolio";
			this.txtFiltraPrefijoFolio.Size = new System.Drawing.Size(109, 30);
			this.txtFiltraPrefijoFolio.TabIndex = 156;
			this.txtFiltraPrefijoFolio.TextChanged += new System.EventHandler(txtFiltraPrefijoFolio_TextChanged);
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new System.Drawing.Point(840, 75);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(213, 23);
			this.label11.TabIndex = 153;
			this.label11.Text = "Excluir por prefijo Folio:";
			this.txtExcluyePrefijoFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtExcluyePrefijoFolio.Location = new System.Drawing.Point(921, 105);
			this.txtExcluyePrefijoFolio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtExcluyePrefijoFolio.Name = "txtExcluyePrefijoFolio";
			this.txtExcluyePrefijoFolio.Size = new System.Drawing.Size(109, 30);
			this.txtExcluyePrefijoFolio.TabIndex = 154;
			this.txtExcluyePrefijoFolio.TextChanged += new System.EventHandler(txtExcluyePrefijoFolio_TextChanged);
			this.panel1.Controls.Add(this.rdoEnBaseFechaDevengada);
			this.panel1.Controls.Add(this.rdoEnBaseFechaPago);
			this.panel1.Location = new System.Drawing.Point(146, 9);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(297, 106);
			this.panel1.TabIndex = 152;
			this.rdoEnBaseFechaDevengada.AutoSize = true;
			this.rdoEnBaseFechaDevengada.Checked = true;
			this.rdoEnBaseFechaDevengada.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaDevengada.Location = new System.Drawing.Point(3, 15);
			this.rdoEnBaseFechaDevengada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoEnBaseFechaDevengada.Name = "rdoEnBaseFechaDevengada";
			this.rdoEnBaseFechaDevengada.Size = new System.Drawing.Size(277, 32);
			this.rdoEnBaseFechaDevengada.TabIndex = 152;
			this.rdoEnBaseFechaDevengada.TabStop = true;
			this.rdoEnBaseFechaDevengada.Text = "En base a Fecha Devengada";
			this.rdoEnBaseFechaDevengada.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaPago.AutoSize = true;
			this.rdoEnBaseFechaPago.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaPago.Location = new System.Drawing.Point(3, 62);
			this.rdoEnBaseFechaPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoEnBaseFechaPago.Name = "rdoEnBaseFechaPago";
			this.rdoEnBaseFechaPago.Size = new System.Drawing.Size(222, 32);
			this.rdoEnBaseFechaPago.TabIndex = 151;
			this.rdoEnBaseFechaPago.Text = "En base a Fecha Pago";
			this.rdoEnBaseFechaPago.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaPago.CheckedChanged += new System.EventHandler(btnRefrescar_Click);
			this.pictureBox1.Image = LeeXML.Properties.Resources.LOGO_BASEFISCAL;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(138, 175);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 148;
			this.pictureBox1.TabStop = false;
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(466, 149);
			this.gbDatosGenerales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gbDatosGenerales.Size = new System.Drawing.Size(676, 106);
			this.gbDatosGenerales.TabIndex = 136;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.gbDatosGenerales.Visible = false;
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(20, 31);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(141, 28);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtNombreFiscal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(171, 26);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(492, 30);
			this.txtNombreFiscal.TabIndex = 104;
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(171, 66);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(220, 30);
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
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(466, 280);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(99, 32);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Fechas:";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorMesComprobantes.Visible = false;
			this.tcEstadosCuentaGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcEstadosCuentaGeneral.Controls.Add(this.tpAnalitica);
			this.tcEstadosCuentaGeneral.Controls.Add(this.tpAuxiliar);
			this.tcEstadosCuentaGeneral.Controls.Add(this.tabPage2);
			this.tcEstadosCuentaGeneral.Controls.Add(this.tabPage3);
			this.tcEstadosCuentaGeneral.Location = new System.Drawing.Point(0, 182);
			this.tcEstadosCuentaGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tcEstadosCuentaGeneral.Name = "tcEstadosCuentaGeneral";
			this.tcEstadosCuentaGeneral.SelectedIndex = 0;
			this.tcEstadosCuentaGeneral.Size = new System.Drawing.Size(1614, 635);
			this.tcEstadosCuentaGeneral.TabIndex = 139;
			this.tcEstadosCuentaGeneral.SelectedIndexChanged += new System.EventHandler(tcEstadosCuentaGeneral_SelectedIndexChanged);
			this.tpAnalitica.Controls.Add(this.rvAnalitica);
			this.tpAnalitica.Location = new System.Drawing.Point(4, 27);
			this.tpAnalitica.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAnalitica.Name = "tpAnalitica";
			this.tpAnalitica.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAnalitica.Size = new System.Drawing.Size(1606, 604);
			this.tpAnalitica.TabIndex = 1;
			this.tpAnalitica.Text = "Analítica Percepciones";
			this.tpAnalitica.UseVisualStyleBackColor = true;
			this.rvAnalitica.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvAnalitica.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptAnaliticaPercepcionesNomina.rdlc";
			this.rvAnalitica.Location = new System.Drawing.Point(2, 5);
			this.rvAnalitica.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvAnalitica.Name = "rvAnalitica";
			this.rvAnalitica.ServerReport.BearerToken = null;
			this.rvAnalitica.Size = new System.Drawing.Size(1604, 590);
			this.rvAnalitica.TabIndex = 1;
			this.tpAuxiliar.Controls.Add(this.rvAuxiliar);
			this.tpAuxiliar.Location = new System.Drawing.Point(4, 27);
			this.tpAuxiliar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAuxiliar.Name = "tpAuxiliar";
			this.tpAuxiliar.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tpAuxiliar.Size = new System.Drawing.Size(1606, 604);
			this.tpAuxiliar.TabIndex = 2;
			this.tpAuxiliar.Text = "Auxiliar Percepciones";
			this.tpAuxiliar.UseVisualStyleBackColor = true;
			this.rvAuxiliar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvAuxiliar.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptAuxiliarPercepcionesNomina.rdlc";
			this.rvAuxiliar.Location = new System.Drawing.Point(2, 5);
			this.rvAuxiliar.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvAuxiliar.Name = "rvAuxiliar";
			this.rvAuxiliar.ServerReport.BearerToken = null;
			this.rvAuxiliar.Size = new System.Drawing.Size(1604, 590);
			this.rvAuxiliar.TabIndex = 2;
			this.tabPage2.Controls.Add(this.rvDeduccionesAcumulado);
			this.tabPage2.Location = new System.Drawing.Point(4, 27);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tabPage2.Size = new System.Drawing.Size(1606, 604);
			this.tabPage2.TabIndex = 3;
			this.tabPage2.Text = "Analítica Deducciones";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.rvDeduccionesAcumulado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvDeduccionesAcumulado.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptAnaliticaDeduccionesNomina.rdlc";
			this.rvDeduccionesAcumulado.Location = new System.Drawing.Point(2, 5);
			this.rvDeduccionesAcumulado.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvDeduccionesAcumulado.Name = "rvDeduccionesAcumulado";
			this.rvDeduccionesAcumulado.ServerReport.BearerToken = null;
			this.rvDeduccionesAcumulado.Size = new System.Drawing.Size(1604, 590);
			this.rvDeduccionesAcumulado.TabIndex = 3;
			this.tabPage3.Controls.Add(this.rvAuxiliarDeducciones);
			this.tabPage3.Location = new System.Drawing.Point(4, 27);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.tabPage3.Size = new System.Drawing.Size(1606, 604);
			this.tabPage3.TabIndex = 4;
			this.tabPage3.Text = "Auxiliar Deducciones";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.rvAuxiliarDeducciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvAuxiliarDeducciones.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptAuxiliarDeduccionesNomina.rdlc";
			this.rvAuxiliarDeducciones.Location = new System.Drawing.Point(2, 5);
			this.rvAuxiliarDeducciones.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.rvAuxiliarDeducciones.Name = "rvAuxiliarDeducciones";
			this.rvAuxiliarDeducciones.ServerReport.BearerToken = null;
			this.rvAuxiliarDeducciones.Size = new System.Drawing.Size(1604, 590);
			this.rvAuxiliarDeducciones.TabIndex = 4;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.label6);
			this.flpTotalesTodos.Controls.Add(this.txtNumComprobantes);
			this.flpTotalesTodos.Controls.Add(this.label18);
			this.flpTotalesTodos.Location = new System.Drawing.Point(0, 786);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(268, 34);
			this.flpTotalesTodos.TabIndex = 136;
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(2, 2);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(177, 23);
			this.label6.TabIndex = 3;
			this.label6.Text = "Núm Comprobantes:";
			this.txtNumComprobantes.Location = new System.Drawing.Point(183, 4);
			this.txtNumComprobantes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtNumComprobantes.Name = "txtNumComprobantes";
			this.txtNumComprobantes.ReadOnly = true;
			this.txtNumComprobantes.Size = new System.Drawing.Size(50, 25);
			this.txtNumComprobantes.TabIndex = 4;
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label18.ForeColor = System.Drawing.Color.White;
			this.label18.Location = new System.Drawing.Point(2, 31);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(53, 23);
			this.label18.TabIndex = 149;
			this.label18.Text = "Núm:";
			this.rdoPorFechasComprobantes.AutoSize = true;
			this.rdoPorFechasComprobantes.Location = new System.Drawing.Point(1178, 155);
			this.rdoPorFechasComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.rdoPorFechasComprobantes.Name = "rdoPorFechasComprobantes";
			this.rdoPorFechasComprobantes.Size = new System.Drawing.Size(99, 22);
			this.rdoPorFechasComprobantes.TabIndex = 43;
			this.rdoPorFechasComprobantes.Text = "Por Fechas";
			this.rdoPorFechasComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorFechasComprobantes.Visible = false;
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
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel10.Controls.Add(this.toolStrip4);
			this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel10.Location = new System.Drawing.Point(484, 785);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Padding = new System.Windows.Forms.Padding(6, 2, 6, 0);
			this.flowLayoutPanel10.Size = new System.Drawing.Size(1128, 36);
			this.flowLayoutPanel10.TabIndex = 142;
			this.toolStrip4.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel1, this.tstTotalEmpleados, this.toolStripSeparator1, this.toolStripLabel14, this.tstTotalPercepciones, this.toolStripSeparator11, this.toolStripLabel15, this.tstTotalExento, this.toolStripSeparator12, this.toolStripLabel25,
				this.tstTotalGravado, this.toolStripSeparator20, this.toolStripLabel16, this.tstTotalImpuesto
			});
			this.toolStrip4.Location = new System.Drawing.Point(6, 2);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip4.Size = new System.Drawing.Size(972, 31);
			this.toolStrip4.TabIndex = 2;
			this.toolStrip4.Text = "toolStrip4";
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(152, 26);
			this.toolStripLabel1.Text = "Num. Empleados:";
			this.tstTotalEmpleados.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstTotalEmpleados.Name = "tstTotalEmpleados";
			this.tstTotalEmpleados.ReadOnly = true;
			this.tstTotalEmpleados.Size = new System.Drawing.Size(44, 31);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel14.Name = "toolStripLabel14";
			this.toolStripLabel14.Size = new System.Drawing.Size(160, 26);
			this.toolStripLabel14.Text = "Total Percepciones:";
			this.tstTotalPercepciones.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstTotalPercepciones.Name = "tstTotalPercepciones";
			this.tstTotalPercepciones.ReadOnly = true;
			this.tstTotalPercepciones.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel15.Name = "toolStripLabel15";
			this.toolStripLabel15.Size = new System.Drawing.Size(111, 26);
			this.toolStripLabel15.Text = "Total Exento:";
			this.tstTotalExento.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstTotalExento.Name = "tstTotalExento";
			this.tstTotalExento.ReadOnly = true;
			this.tstTotalExento.Size = new System.Drawing.Size(121, 31);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel25.Name = "toolStripLabel25";
			this.toolStripLabel25.Size = new System.Drawing.Size(125, 26);
			this.toolStripLabel25.Text = "Total Gravado:";
			this.tstTotalGravado.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstTotalGravado.Name = "tstTotalGravado";
			this.tstTotalGravado.ReadOnly = true;
			this.tstTotalGravado.Size = new System.Drawing.Size(82, 31);
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(6, 31);
			this.toolStripLabel16.Name = "toolStripLabel16";
			this.toolStripLabel16.Size = new System.Drawing.Size(134, 25);
			this.toolStripLabel16.Text = "Total Impuesto:";
			this.toolStripLabel16.Visible = false;
			this.tstTotalImpuesto.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstTotalImpuesto.Name = "tstTotalImpuesto";
			this.tstTotalImpuesto.ReadOnly = true;
			this.tstTotalImpuesto.Size = new System.Drawing.Size(50, 31);
			this.tstTotalImpuesto.Visible = false;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.entEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Location = new System.Drawing.Point(532, 20);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(77, 20);
			this.label24.TabIndex = 131;
			this.label24.Text = "Empresa:";
			this.label24.Visible = false;
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(612, 14);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(487, 33);
			this.cmbEmpresas.TabIndex = 132;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.Visible = false;
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.dataGridViewImageColumn1.DataPropertyName = "TipoComprobante";
			this.dataGridViewImageColumn1.FillWeight = 200f;
			this.dataGridViewImageColumn1.HeaderText = "Relación";
			this.dataGridViewImageColumn1.Image = LeeXML.Properties.Resources.Paper;
			this.dataGridViewImageColumn1.MinimumWidth = 6;
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewImageColumn1.Width = 178;
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(1104, 9);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(58, 42);
			this.btnBuscaEmpresa.TabIndex = 130;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.btnBuscaEmpresa.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1653, 915);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.tcPedidosGrids);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "ReportesISR";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Reportes ISR";
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.pnlDatos.ResumeLayout(false);
			this.pnlDatos.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroDeduccionesHasta).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoPercepcionesBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroDeducciones).EndInit();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroPercepcionesHasta).EndInit();
			((System.ComponentModel.ISupportInitialize)this.gvFiltroPercepciones).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entClienteBindingSource).EndInit();
			this.pnlPorDiaVentas.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.tcEstadosCuentaGeneral.ResumeLayout(false);
			this.tpAnalitica.ResumeLayout(false);
			this.tpAuxiliar.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.flowLayoutPanel10.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entEstadoDeCuentaBindingSource).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
