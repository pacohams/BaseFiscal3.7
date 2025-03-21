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
using LinqToExcel;
using Microsoft.Office.Interop.Excel;

namespace LeeXML.Pantallas
{
	public class EstadoDeCuenta : FormBase
	{
		private IContainer components = null;

		private DataGridView gvXMLs;

		private System.Windows.Forms.Button btnCargaXMLs;

		private System.Windows.Forms.TextBox txtRutaCarpeta;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private System.Windows.Forms.Button btnExportar;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.TextBox txtCantidadVentas;

		private System.Windows.Forms.Button btnRefrescaCargaArchivo;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private FlowLayoutPanel flowLayoutPanel1;

		private System.Windows.Forms.Button btnImportaXMLs;

		private System.Windows.Forms.GroupBox gbDatosGenerales;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.TextBox txtNombreFiscal;

		private System.Windows.Forms.TextBox txtRFC;

		private System.Windows.Forms.Label label5;

		private Panel pnlGeneral;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Label label24;

		private ComboBox cmbEmpresas;

		private System.Windows.Forms.Button btnBuscaEmpresa;

		private FlowLayoutPanel flpTotalesTodos;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.TextBox txtSubTotal;

		private ToolStrip toolStrip1;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstxtIVA;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImporte;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.TextBox txtNumComprobantes;

		private DataGridViewImageColumn dataGridViewImageColumn1;

		private System.Windows.Forms.Label label7;

		private ComboBox cmbBancos;

		private BindingSource entCatalogoGenericoBindingSource;

		private BindingSource entEstadoDeCuentaBindingSource;

		private TabControl tcEstadosCuentaGeneral;

		private TabPage tbImportacion;

		private TabPage tpCFDISinRelacionar;

		private DataGridView gvCFDIsSinRelacionar;

		private FlowLayoutPanel flpPUE;

		private FlowLayoutPanel flowLayoutPanel2;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNumPUE;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotalPUE;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel17;

		private ToolStripTextBox tstxtIvaPUE;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tstxtRetencionesPUE;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox tstxtImportePUE;

		private FlowLayoutPanel flowLayoutPanel8;

		private ToolStrip toolStrip3;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tstNumCP;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tstSubCP;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripLabel toolStripLabel9;

		private ToolStripTextBox tstIvaCP;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripLabel toolStripLabel18;

		private ToolStripTextBox tstxtRetencionesCP;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripLabel toolStripLabel10;

		private ToolStripTextBox tstImporteCP;

		private FlowLayoutPanel flowLayoutPanel9;

		private ToolStrip toolStrip4;

		private ToolStripLabel toolStripLabel11;

		private ToolStripTextBox tstNumTotal;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripLabel toolStripLabel12;

		private ToolStripTextBox tstSubTotal;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripLabel toolStripLabel13;

		private ToolStripTextBox tstIvaTotal;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripLabel toolStripLabel19;

		private ToolStripTextBox tstxtRetencionesTotal;

		private ToolStripSeparator toolStripSeparator15;

		private ToolStripLabel toolStripLabel14;

		private ToolStripTextBox tstImporteTotal;

		private Panel panel1;

		private System.Windows.Forms.Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Panel pnlPorDiaVentas;

		private DateTimePicker dtpFechaHasta;

		private DateTimePicker dtpFechaDesde;

		private RadioButton rdoPorFechasComprobantes;

		private FlowLayoutPanel flowLayoutPanel3;

		private System.Windows.Forms.Button btnMarcarNoDepositara;

		private System.Windows.Forms.Button btnMarcarDepositaraPosterior;

		private TabPage tabPage2;

		private FlowLayoutPanel flowLayoutPanel4;

		private FlowLayoutPanel flowLayoutPanel5;

		private ToolStrip toolStrip5;

		private ToolStripLabel toolStripLabel15;

		private ToolStripTextBox toolStripTextBox1;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripLabel toolStripLabel16;

		private ToolStripTextBox toolStripTextBox2;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripLabel toolStripLabel20;

		private ToolStripTextBox toolStripTextBox3;

		private ToolStripSeparator toolStripSeparator17;

		private ToolStripLabel toolStripLabel21;

		private ToolStripTextBox toolStripTextBox4;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripLabel toolStripLabel22;

		private ToolStripTextBox toolStripTextBox5;

		private FlowLayoutPanel flowLayoutPanel6;

		private ToolStrip toolStrip6;

		private ToolStripLabel toolStripLabel23;

		private ToolStripTextBox toolStripTextBox6;

		private ToolStripSeparator toolStripSeparator19;

		private ToolStripLabel toolStripLabel24;

		private ToolStripTextBox toolStripTextBox7;

		private ToolStripSeparator toolStripSeparator20;

		private ToolStripLabel toolStripLabel25;

		private ToolStripTextBox toolStripTextBox8;

		private ToolStripSeparator toolStripSeparator21;

		private ToolStripLabel toolStripLabel26;

		private ToolStripTextBox toolStripTextBox9;

		private ToolStripSeparator toolStripSeparator22;

		private ToolStripLabel toolStripLabel27;

		private ToolStripTextBox toolStripTextBox10;

		private FlowLayoutPanel flowLayoutPanel7;

		private ToolStrip toolStrip7;

		private ToolStripLabel toolStripLabel28;

		private ToolStripTextBox toolStripTextBox11;

		private ToolStripSeparator toolStripSeparator23;

		private ToolStripLabel toolStripLabel29;

		private ToolStripTextBox toolStripTextBox12;

		private ToolStripSeparator toolStripSeparator24;

		private ToolStripLabel toolStripLabel30;

		private ToolStripTextBox toolStripTextBox13;

		private ToolStripSeparator toolStripSeparator25;

		private ToolStripLabel toolStripLabel31;

		private ToolStripTextBox toolStripTextBox14;

		private ToolStripSeparator toolStripSeparator26;

		private ToolStripLabel toolStripLabel32;

		private ToolStripTextBox toolStripTextBox15;

		private FlowLayoutPanel flowLayoutPanel10;

		private System.Windows.Forms.Label label8;

		private ComboBox cmbBancoFiltro;

		private DataGridView gvEstadoDeCuentasImportados;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private System.Windows.Forms.Button btnVerificaDepositado;

		private System.Windows.Forms.Button btnAgregaDepositoManual;

		private System.Windows.Forms.Button btnEliminaDeposito;

		private System.Windows.Forms.Button btnEnviarAExcelEstadosCuentaImportados;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewImageColumn GvXMLTipoComprobante;

		private DataGridViewImageColumn GvXMLEliminaRelacion;

		private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn UUID;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn Descripcion;

		private DataGridViewImageColumn gvXmlsColumnElimina;

		private System.Windows.Forms.Button btnMarcarDepositadoMesAnterior;

		private FlowLayoutPanel flowLayoutPanel14;

		private System.Windows.Forms.Button btnRevisarAnticiposDepositosPrevios;

		private DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn MetodoPago;

		private DataGridViewTextBoxColumn FormaPago;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn retencionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn Descuento;

		private DataGridViewTextBoxColumn EstatusDescripcion;

		private System.Windows.Forms.Button btnSinRelacion;

		private DataGridViewTextBoxColumn Banco;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

		private DataGridViewTextBoxColumn gvEstadosCuentaColumPago;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private bool BancosCargados { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public void CargaEmpresas()
		{
			Program.CambiaEmpresa = false;
			cmbEmpresas.DataSource = new BusEmpresas().ObtieneEmpresas(Program.UsuarioSeleccionado.CompañiaId, Program.UsuarioSeleccionado.LimiteEmpresas);
			Program.CambiaEmpresa = true;
		}

		public EstadoDeCuenta()
		{
			InitializeComponent();
		}

		public List<EntEstadoDeCuenta> ExcelToListaPedidos(string PathExcel)
		{
			ExcelQueryFactory book = new ExcelQueryFactory(PathExcel);
			List<EntEstadoDeCuenta> resultado = (from row in (IQueryable<Row>)book.Worksheet(0)
				let item = new EntEstadoDeCuenta
				{
					Total = ConvierteTextoADecimal((string)row["DEPOSITO"]),
					Fecha = row["FECHA"].Cast<DateTime>(),
					EmpresaId = EmpresaSeleccionada.Id,
					UsuarioId = Program.UsuarioSeleccionado.Id,
					TipoComprobanteId = 1,
					UUID = "",
					SerieFactura = "",
					NumeroFactura = "",
					RFC = "",
					Nombre = "",
					MetodoPago = "",
					FormaPago = "",
					Descripcion = ""
				}
				select item).ToList();
			book.Dispose();
			List<EntEstadoDeCuenta> lst = resultado;
			return lst.Where((EntEstadoDeCuenta P) => P.Total > 0m).ToList();
		}

		private void CargaEstadoDeCuentaExcelEnGrid(string RutaArchivo, DataGridView GridCarga)
		{
			DateTime fecha = FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes);
			List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
			lst = (from P in ExcelToListaPedidos(RutaArchivo)
				where P.Fecha >= fecha && P.Fecha < fecha.AddMonths(1)
				select P).ToList();
			if (lst.Count == 0)
			{
				MandaExcepcion("No se encontraron registros para el mes de trabajo seleccionado");
			}
			GridCarga.DataSource = lst.OrderBy((EntEstadoDeCuenta P) => P.Fecha).ToList();
			txtNumComprobantes.Text = lst.Count.ToString();
		}

		public void CargaBancos()
		{
			List<EntCatalogoGenerico> lst = new BusEmpresas().ObtieneBancos(Program.EmpresaSeleccionada.Id);
			lst.Insert(0, new EntCatalogoGenerico
			{
				Id = -1,
				Descripcion = "          -SELECCIONE-"
			});
			cmbBancos.DataSource = lst;
			cmbBancos.SelectedIndex = 0;
		}

		public void CargaCFDIsinRelacionar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			gvCFDIsSinRelacionar.DataSource = (from P in new BusFacturas().ObtieneComprobantesFiscalesSinRelacionar(Empresa, FechaDesde, FechaHasta)
				where P.TotalUSD == 0m
				select P).ToList();
			gvCFDIsSinRelacionar.Refresh();
		}

		public void CargaEstadoDeCuentasImportados(int BancoId, DateTime FechaDesde, DateTime FechaHasta)
		{
			if (BancoId <= 0)
			{
				gvEstadoDeCuentasImportados.DataSource = new BusFacturas().ObtieneEstadosDeCuentaConDetalle(Program.EmpresaSeleccionada, FechaDesde, FechaHasta);
			}
			else
			{
				gvEstadoDeCuentasImportados.DataSource = (from P in new BusFacturas().ObtieneEstadosDeCuentaConDetalle(Program.EmpresaSeleccionada, FechaDesde, FechaHasta)
					where P.BancoId == BancoId
					select P).ToList();
			}
			gvEstadoDeCuentasImportados.Refresh();
		}

		private void AgregarEstadoDeCuenta(EntEstadoDeCuenta EstadoDeCuenta)
		{
			EstadoDeCuenta.Id = new BusFacturas().AgregaEstadoDeCuenta(EstadoDeCuenta);
			foreach (EntFactura f in EstadoDeCuenta.ListaComprobantes)
			{
				if (f.Id == -1)
				{
					f.Id = new BusFacturas().AgregaComprobantesFiscales(f);
				}
				new BusFacturas().AgregaEstadoDeCuentaComprobante(EstadoDeCuenta.Id, f);
				if (f.TipoComprobanteId == 2)
				{
					new BusFacturas().AumentaPagoComprobanteFiscalEgresos(f.Id, f.Pago);
					new BusFacturas().VerificaComprobanteFiscalPagadoEgresos(f.Id);
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacionEgresos(f.Id, 1);
					new BusFacturas().AumentaDepositoComprobanteFiscalEgresos(f.Id, f.Pago);
					new BusFacturas().VerificaComprobanteFiscalDepositadoEgresos(f.Id);
				}
				else
				{
					new BusFacturas().AumentaPagoComprobanteFiscal(f.Id, f.Pago);
					new BusFacturas().VerificaComprobanteFiscalPagado(f.Id);
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(f.Id, 1);
					new BusFacturas().AumentaDepositoComprobanteFiscal(f.Id, f.Pago);
					new BusFacturas().VerificaComprobanteFiscalDepositado(f.Id);
				}
			}
		}

		private void InicializaPantalla()
		{
			CargaDatosEmpresa(txtNombreFiscal, txtRFC);
			txtRutaCarpeta.Text = base.EmpresaSeleccionada.Key;
			CargaAñosCmb(cmbAñoComprobantes);
			cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
			CargaBancos();
			BancosCargados = true;
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
				gvXMLs.DataSource = new List<EntEstadoDeCuenta>();
			}
			catch (Exception ex)
			{
				SetDefaultCursor();
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
					CargaBancos();
					gvXMLs.DataSource = new List<EntEstadoDeCuenta>();
					gvXMLs.Refresh();
					tcEstadosCuentaGeneral.Enabled = Convert.ToBoolean(cmbBancos.SelectedIndex);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbBancos_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (BancosCargados)
				{
					tcEstadosCuentaGeneral.Enabled = Convert.ToBoolean(cmbBancos.SelectedIndex);
					CargaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
					CargaEstadoDeCuentasImportados(ObtieneCatalogoGenericoFromCmb(cmbBancos).Id, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnCargaXMLs_Click(object sender, EventArgs e)
		{
			try
			{
				string rutaArchivo = SeleccionaArchivo();
				txtRutaCarpeta.Text = rutaArchivo;
				CargaEstadoDeCuentaExcelEnGrid(rutaArchivo, gvXMLs);
			}
			catch (Exception ex)
			{
				Cursor = Cursors.Default;
				MuestraExcepcion(ex, "ERROR CARGA ARCHIVO");
			}
		}

		private void btnRefrescaCargaArchivo_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (string.IsNullOrWhiteSpace(txtRutaCarpeta.Text))
				{
					txtRutaCarpeta.Focus();
					MandaExcepcion("Ruta de Carpeta Necesaria");
				}
				CargaEstadoDeCuentaExcelEnGrid(txtRutaCarpeta.Text, gvXMLs);
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

		private void gvXMLs_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				EntEstadoDeCuenta fac = ObtieneEstadoDeCuentaFromGV(gvXMLs);
				if (e.ColumnIndex == 2)
				{
					fac.ListaComprobantes = new List<EntFactura>();
					fac.UUID = "";
					fac.NumeroFactura = "";
					fac.Nombre = "";
					((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.Cancelar_sinFondo;
					fac.Estatus = false;
					gvXMLs.Refresh();
					SeleccionaRelacion vSelFac = new SeleccionaRelacion(fac, fac.TipoComprobanteId);
					if (vSelFac.ShowDialog() == DialogResult.OK)
					{
						decimal totalDeposito = fac.Total;
						fac.TipoComprobanteId = vSelFac.TipoMovimientoSeleccionado.Id;
						if (fac.TipoComprobanteId == 1)
						{
							fac.ListaComprobantes = vSelFac.FacturasSeleccionadas;
							foreach (EntFactura f in fac.ListaComprobantes)
							{
								AgregaPago vPag = new AgregaPago(f, totalDeposito, false);
								if (vPag.ShowDialog() == DialogResult.OK)
								{
									f.Pago = vPag.CantidadPagoDecimal;
									totalDeposito -= vPag.CantidadPagoDecimal;
									fac.UUID = fac.UUID + f.UUID + " | ";
									fac.NumeroFactura = fac.NumeroFactura + f.SerieFactura + f.NumeroFactura + " | ";
									fac.Nombre = fac.Nombre + f.Nombre + " | ";
									((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.palomitaChica_sinFondo;
									fac.Estatus = true;
								}
								else
								{
									fac.ListaComprobantes = new List<EntFactura>();
									fac.UUID = "";
									fac.NumeroFactura = "";
									fac.Nombre = "";
									((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.Cancelar_sinFondo;
									fac.Estatus = false;
								}
							}
							if (fac.Estatus && totalDeposito > 0m)
							{
								MuestraMensajeAdvertencia("NO SE RELACIONÓ EL MONTO TOTAL DEL DEPÓSITO. EL RESTO SE DEBERÁ RELACIONAR COMO ANTICIPO.", "MONTO DEPÓSITO INCOMPLETO");
								SeleccionaRelacion vSelAnt = new SeleccionaRelacion(fac, true, totalDeposito);
								if (vSelAnt.ShowDialog() == DialogResult.OK)
								{
									fac.NumeroFactura += " | ANT.";
									fac.UUID = fac.UUID + " | " + vSelAnt.TipoMovimientoSeleccionado.Descripcion;
									fac.ListaComprobantes.Add(vSelAnt.FacturaAnticipo);
									((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.palomitaChica_sinFondo;
									fac.Estatus = true;
								}
								else
								{
									MuestraMensajeError("NO SE RELACIONÓ EL MONTO TOTAL DEL DEPÓSITO", "MONTO DEPOSITO INCOMPLETO");
									fac.ListaComprobantes = new List<EntFactura>();
									fac.UUID = "";
									fac.NumeroFactura = "";
									fac.Nombre = "";
									((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.Cancelar_sinFondo;
									fac.Estatus = false;
								}
							}
						}
						else if (fac.TipoComprobanteId == 7)
						{
							fac.UUID = vSelFac.TipoMovimientoSeleccionado.Descripcion;
							fac.ListaComprobantes.Add(vSelFac.FacturaAnticipo);
							((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.palomitaChica_sinFondo;
							fac.Estatus = true;
						}
						else
						{
							fac.Id = 0;
							fac.UUID = vSelFac.TipoMovimientoSeleccionado.Descripcion;
							fac.SerieFactura = "";
							fac.NumeroFactura = "";
							fac.RFC = "";
							fac.Nombre = "";
							fac.MetodoPago = "";
							fac.FormaPago = "";
							((DataGridViewImageCell)gvXMLs.Rows[e.RowIndex].Cells[3]).Value = Resources.palomitaChica_sinFondo;
							fac.Estatus = true;
						}
					}
					gvXMLs.Refresh();
				}
				else if (e.ColumnIndex == gvXMLs.ColumnCount - 1 && MuestraMensajeYesNo("¿Seguro desea Eliminar el registro seleccionado?") == DialogResult.Yes)
				{
					List<EntEstadoDeCuenta> lst = ObtieneListaEstadoDeCuentaFromGV(gvXMLs);
					lst.Remove(fac);
					gvXMLs.DataSource = null;
					gvXMLs.DataSource = lst;
					RevisaCambiaImagenEstatusEnGrid(lst, gvXMLs);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void VerificaDepositosRelacionados(List<EntEstadoDeCuenta> ListaFacturas)
		{
			if (ListaFacturas.Where((EntEstadoDeCuenta P) => !P.Estatus).ToList().Count > 0)
			{
				MandaExcepcion("Faltan Depósitos por relacionar");
			}
		}

		private void btnImportaXMLs_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvXMLs.Rows.Count == 0)
				{
					txtRutaCarpeta.Focus();
					MandaExcepcion("No se encontraron registros a Importar");
				}
				List<EntEstadoDeCuenta> lstFacturas = ObtieneListaEstadoDeCuentaFromGV(gvXMLs);
				VerificaDepositosRelacionados(lstFacturas);
				if (MuestraMensajeYesNo("¿Seguro desea Importar los registros mostrados?") != DialogResult.Yes)
				{
					return;
				}
				int bancoId = ObtieneCatalogoGenericoFromCmb(cmbBancos).Id;
				foreach (EntEstadoDeCuenta ec in lstFacturas)
				{
					ec.BancoId = bancoId;
					AgregarEstadoDeCuenta(ec);
				}
				MuestraMensaje("¡Estado de Cuenta Importado!");
				btnRefrescar.PerformClick();
				tcEstadosCuentaGeneral.SelectedIndex = 2;
				gvXMLs.DataSource = new List<EntEstadoDeCuenta>();
				gvXMLs.Refresh();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void EnviarListaFacturasAExcel(string NombreArchivo, DateTime Fecha, List<EntFactura> xmls)
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
				xlWorkSheet.Cells[1, 3] = "BANCO";
				xlWorkSheet.Cells[1, 4] = "FECHA";
				xlWorkSheet.Cells[1, 5] = "MONTO DEPOSITO";
				xlWorkSheet.Cells[1, 6] = "TIPORELACION";
				xlWorkSheet.Cells[1, 7] = "MONTO FACTURA";
				xlWorkSheet.Cells[1, 8] = "FOLIO";
				xlWorkSheet.Cells[1, 9] = "UUID";
				xlWorkSheet.Cells[1, 10] = "SUBTOTAL";
				xlWorkSheet.Cells[1, 11] = "IVA";
				xlWorkSheet.Cells[1, 12] = "IVARETENCIONES";
				xlWorkSheet.Cells[1, 13] = "ISRRETENCIONES";
				int ren = 2;
				foreach (EntFactura x in xmls)
				{
					xlWorkSheet.Cells[ren, 1] = x.RFC;
					xlWorkSheet.Cells[ren, 2] = x.Nombre;
					xlWorkSheet.Cells[ren, 3] = x.Banco;
					xlWorkSheet.Cells[ren, 4] = x.Fecha;
					xlWorkSheet.Cells[ren, 5] = x.Pago;
					xlWorkSheet.Cells[ren, 6] = x.TipoRelacion;
					xlWorkSheet.Cells[ren, 7] = x.Total;
					xlWorkSheet.Cells[ren, 8] = x.Folio;
					xlWorkSheet.Cells[ren, 9] = x.UUID;
					xlWorkSheet.Cells[ren, 10] = x.SubTotal;
					xlWorkSheet.Cells[ren, 11] = x.IVA;
					xlWorkSheet.Cells[ren, 12] = x.IVARetenciones;
					xlWorkSheet.Cells[ren, 13] = x.ISRRetenciones;
					total += x.Total;
					subtotal += x.SubTotal - x.Descuento;
					iva += x.IVA;
					ren++;
				}
				string rutaExportacion = SeleccionaCarpeta();
				rutaExportacion += $"\\{NombreArchivo} {Fecha:yyyy-MM} {DateTime.Now:ddhhmmss}.xls";
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

		private void btnExportar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				Microsoft.Office.Interop.Excel.Application xlApp = (Microsoft.Office.Interop.Excel.Application)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("00024500-0000-0000-C000-000000000046")));
				if (xlApp == null)
				{
					MandaExcepcion("Excel NO esta instalado apropiadamente.");
				}
				object misValue = Missing.Value;
				Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
				Worksheet xlWorkSheet = (Worksheet)(dynamic)xlWorkBook.Worksheets.get_Item((object)1);
				try
				{
					xlWorkSheet.Cells[1, 1] = "FECHA";
					xlWorkSheet.Cells[1, 2] = "DEPOSITO";
					xlWorkSheet.Cells[1, 3] = "RETIRO";
					int ren = 2;
					string rutaExportacion = SeleccionaCarpeta();
					rutaExportacion += $"\\EstadoDeCuentaBASE {DateTime.Now:yyyy-MM-dd hhmmss}.xls";
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
					SetDefaultCursor();
				}
			}
			catch (Exception ex2)
			{
				MuestraExcepcion(ex2);
			}
		}

		private void btnMarcarNoDepositara_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvCFDIsSinRelacionar.Rows.Count == 0)
				{
					MandaExcepcion("No se encontraron registros.");
				}
				if (MuestraMensajeYesNo("¿Seguro desea marcar como 'NO DEPOSITARÁ' el(los) Comprobante(s) selecccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvCFDIsSinRelacionar);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					f.TipoRelacionId = 2;
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(f.Id, f.TipoRelacionId);
					new BusFacturas().ActualizaComprobanteFiscalDepositado(f.Id, true);
					new BusFacturas().AgregaComprobantesFiscalesNoDeposito(f);
				}
				CargaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnMarcarDepositaraPosterior_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvCFDIsSinRelacionar.Rows.Count == 0)
				{
					MandaExcepcion("No se encontraron registros.");
				}
				if (MuestraMensajeYesNo("¿Seguro desea marcar como 'DEPOSITARÁ EN MES SIGUIENTE' el(los) Comprobante(s) selecccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvCFDIsSinRelacionar);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					f.TipoRelacionId = 3;
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(f.Id, f.TipoRelacionId);
					new BusFacturas().ActualizaEstatusComprobanteFiscalNoDepositado(f.Id, false);
					new BusFacturas().ActualizaComprobanteFiscalDepositado(f.Id, false);
				}
				CargaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbBancoFiltro_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (BancosCargados)
				{
					CargaEstadoDeCuentasImportados(ObtieneCatalogoGenericoFromCmb(cmbBancoFiltro).Id, FechaDesde(rdoPorMesComprobantes.Checked, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, dtpFechaDesde.Value), FechaHasta(rdoPorMesComprobantes.Checked, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, dtpFechaHasta.Value));
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
				if (BancosCargados)
				{
					SetWaitCursor();
					CargaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
					CargaEstadoDeCuentasImportados(ObtieneCatalogoGenericoFromCmb(cmbBancos).Id, FechaDesde(rdoPorMesComprobantes.Checked, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, dtpFechaDesde.Value), FechaHasta(rdoPorMesComprobantes.Checked, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, dtpFechaHasta.Value));
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

		private void btnVerificaDepositado_Click(object sender, EventArgs e)
		{
			try
			{
				EntFactura fac = ObtieneFacturaFromGV(gvEstadoDeCuentasImportados);
				new BusFacturas().VerificaComprobanteFiscalDepositado(fac.FacturaRelacionId);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void tcEstadosCuentaGeneral_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (tcEstadosCuentaGeneral.SelectedIndex > 0)
				{
					List<EntEstadoDeCuenta> lstFacturas = ObtieneListaEstadoDeCuentaFromGV(gvXMLs);
					VerificaDepositosRelacionados(lstFacturas);
				}
			}
			catch (Exception ex)
			{
				tcEstadosCuentaGeneral.SelectedIndex = 0;
				MuestraExcepcion(ex);
			}
		}

		private void RevisaCambiaImagenEstatusEnGrid(List<EntEstadoDeCuenta> ListaDepositos, DataGridView GvEstadosDeCuenta)
		{
			for (int x = 0; x < ListaDepositos.Count; x++)
			{
				if (ListaDepositos[x].Estatus)
				{
					((DataGridViewImageCell)GvEstadosDeCuenta.Rows[x].Cells[3]).Value = Resources.palomitaChica_sinFondo;
				}
			}
			GvEstadosDeCuenta.Refresh();
		}

		private void btnAgregaDepositoManual_Click(object sender, EventArgs e)
		{
			try
			{
				AgregaDeposito vDepositos = new AgregaDeposito(FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
				if (vDepositos.ShowDialog() != DialogResult.OK)
				{
					return;
				}
				List<EntEstadoDeCuenta> lstDepositos = ObtieneListaEstadoDeCuentaFromGV(gvXMLs);
				foreach (EntEstadoDeCuenta ec in vDepositos.ListaDepositosFromGV)
				{
					lstDepositos.Add(ec);
				}
				gvXMLs.DataSource = null;
				gvXMLs.DataSource = lstDepositos.OrderBy((EntEstadoDeCuenta P) => P.Fecha).ToList();
				RevisaCambiaImagenEstatusEnGrid(lstDepositos.OrderBy((EntEstadoDeCuenta P) => P.Fecha).ToList(), gvXMLs);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnEnviarAExcelEstadosCuentaImportados_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				List<EntFactura> xmls = ObtieneListaFacturasFromGV(gvEstadoDeCuentasImportados);
				ImprimeCFDIsEstadoCuenta vImprime = new ImprimeCFDIsEstadoCuenta(xmls);
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

		private void btnEliminaDeposito_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntFactura> lstdepositosSeleccionados = ObtieneListaFacturasFromGVseleccionados(gvEstadoDeCuentasImportados);
				if (MuestraMensajeYesNo("¿Desea Eliminar el Depósito(s) seleccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				foreach (EntFactura dep in lstdepositosSeleccionados)
				{
					List<EntFactura> cfRelacionados = new BusFacturas().ObtieneEstadoDeCuentaDetalles(dep.Id);
					new BusFacturas().ActualizaEstatusEstadoDeCuenta(dep.Id, 0);
					new BusFacturas().ActualizaEstatusEstadoDeCuentaComprobantes(dep.Id, false);
					foreach (EntFactura f in cfRelacionados)
					{
						if (f.TipoComprobanteId == 2)
						{
							new BusFacturas().AumentaPagoComprobanteFiscalEgresos(f.FacturaRelacionId, -f.Pago);
							new BusFacturas().ActualizaComprobanteFiscalTipoRelacionEgresos(f.FacturaRelacionId, 1);
							new BusFacturas().AumentaDepositoComprobanteFiscalEgresos(f.FacturaRelacionId, -f.Pago);
							new BusFacturas().VerificaComprobanteFiscalDepositadoEgresos(f.FacturaRelacionId);
						}
						else
						{
							new BusFacturas().AumentaPagoComprobanteFiscal(f.FacturaRelacionId, -f.Pago);
							new BusFacturas().VerificaComprobanteFiscalPagado(f.FacturaRelacionId);
							new BusFacturas().AumentaDepositoComprobanteFiscal(f.FacturaRelacionId, -f.Pago);
							new BusFacturas().VerificaComprobanteFiscalDepositado(f.FacturaRelacionId);
							new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(f.FacturaRelacionId, 0);
						}
					}
				}
				MuestraMensaje("¡Depósito Eliminado!");
				btnRefrescar.PerformClick();
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

		private void btnMarcarDepositadoMesAnterior_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvCFDIsSinRelacionar.Rows.Count == 0)
				{
					MandaExcepcion("No se encontraron registros.");
				}
				if (MuestraMensajeYesNo("¿Seguro desea marcar como 'DEPOSITADO EN MES ANTERIOR' el(los) Comprobante(s) selecccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvCFDIsSinRelacionar);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					f.TipoRelacionId = 4;
					new BusFacturas().ActualizaEstatusComprobanteFiscalNoDepositado(f.Id, false);
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(f.Id, f.TipoRelacionId);
					new BusFacturas().ActualizaComprobanteFiscalDepositado(f.Id, true);
				}
				CargaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
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
				new Reportes().RevisaAnticipoComprobantes(new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, FechaDesde(rdoPorMesComprobantes.Checked, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, dtpFechaDesde.Value), FechaHasta(rdoPorMesComprobantes.Checked, cmbAñoComprobantes.Text, cmbMesesComprobantes.SelectedIndex + 1, dtpFechaHasta.Value), 1));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnSinRelacion_Click(object sender, EventArgs e)
		{
			try
			{
				if (gvCFDIsSinRelacionar.Rows.Count == 0)
				{
					MandaExcepcion("No se encontraron registros.");
				}
				if (MuestraMensajeYesNo("¿Seguro desea marcar como 'SIN RELACIÓN' el(los) Comprobante(s) selecccionado(s)?") != DialogResult.Yes)
				{
					return;
				}
				List<EntFactura> lstFacturasSeleccionadas = ObtieneListaFacturasFromGVseleccionados(gvCFDIsSinRelacionar);
				foreach (EntFactura f in lstFacturasSeleccionadas)
				{
					f.TipoRelacionId = 0;
					new BusFacturas().ActualizaComprobanteFiscalTipoRelacion(f.Id, f.TipoRelacionId);
					new BusFacturas().ActualizaEstatusComprobanteFiscalNoDepositado(f.Id, false);
					new BusFacturas().ActualizaComprobanteFiscalDepositado(f.Id, false);
					new BusFacturas().AgregaComprobantesFiscalesNoDeposito(f);
				}
				CargaCFDIsinRelacionar(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes), FechaHastaFromComboBoxs(cmbMesesComprobantes, cmbAñoComprobantes));
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.EstadoDeCuenta));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.cmbBancos = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.tcEstadosCuentaGeneral = new System.Windows.Forms.TabControl();
			this.tbImportacion = new System.Windows.Forms.TabPage();
			this.pnlGeneral = new System.Windows.Forms.Panel();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSubTotal = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIVA = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporte = new System.Windows.Forms.ToolStripTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNumComprobantes = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRutaCarpeta = new System.Windows.Forms.TextBox();
			this.btnRefrescaCargaArchivo = new System.Windows.Forms.Button();
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GvXMLTipoComprobante = new System.Windows.Forms.DataGridViewImageColumn();
			this.GvXMLEliminaRelacion = new System.Windows.Forms.DataGridViewImageColumn();
			this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvXmlsColumnElimina = new System.Windows.Forms.DataGridViewImageColumn();
			this.entEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnExportar = new System.Windows.Forms.Button();
			this.btnCargaXMLs = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnImportaXMLs = new System.Windows.Forms.Button();
			this.btnAgregaDepositoManual = new System.Windows.Forms.Button();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnRevisarAnticiposDepositosPrevios = new System.Windows.Forms.Button();
			this.tpCFDISinRelacionar = new System.Windows.Forms.TabPage();
			this.flpPUE = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel17 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImportePUE = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel18 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteCP = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
			this.tstNumTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
			this.tstSubTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
			this.tstIvaTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel19 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
			this.tstImporteTotal = new System.Windows.Forms.ToolStripTextBox();
			this.gvCFDIsSinRelacionar = new System.Windows.Forms.DataGridView();
			this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.retencionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.EstatusDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnMarcarNoDepositara = new System.Windows.Forms.Button();
			this.btnMarcarDepositaraPosterior = new System.Windows.Forms.Button();
			this.btnMarcarDepositadoMesAnterior = new System.Windows.Forms.Button();
			this.btnSinRelacion = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.gvEstadoDeCuentasImportados = new System.Windows.Forms.DataGridView();
			this.Banco = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvEstadosCuentaColumPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbBancoFiltro = new System.Windows.Forms.ComboBox();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel16 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel20 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel21 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel22 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox5 = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel23 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox6 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel24 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox7 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel25 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox8 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel26 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox9 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel27 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox10 = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel28 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox11 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel29 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox12 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel30 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox13 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel31 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox14 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel32 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox15 = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnVerificaDepositado = new System.Windows.Forms.Button();
			this.btnEliminaDeposito = new System.Windows.Forms.Button();
			this.btnEnviarAExcelEstadosCuentaImportados = new System.Windows.Forms.Button();
			this.rdoPorFechasComprobantes = new System.Windows.Forms.RadioButton();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.pnlPorDiaVentas = new System.Windows.Forms.Panel();
			this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
			this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.pnlPorMesVentas.SuspendLayout();
			this.tcEstadosCuentaGeneral.SuspendLayout();
			this.tbImportacion.SuspendLayout();
			this.pnlGeneral.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entEstadoDeCuentaBindingSource).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.tpCFDISinRelacionar.SuspendLayout();
			this.flpPUE.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.flowLayoutPanel8.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCFDIsSinRelacionar).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.flowLayoutPanel3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvEstadoDeCuentasImportados).BeginInit();
			this.flowLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel5.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			this.flowLayoutPanel7.SuspendLayout();
			this.toolStrip7.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.gbDatosGenerales.SuspendLayout();
			this.pnlPorDiaVentas.SuspendLayout();
			base.SuspendLayout();
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(13, 27);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1335, 560);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.tcEstadosCuentaGeneral);
			this.tabPage1.Controls.Add(this.rdoPorFechasComprobantes);
			this.tabPage1.Controls.Add(this.gbDatosGenerales);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Controls.Add(this.pnlPorDiaVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 27);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(1327, 529);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Importar Estado de Cuenta";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.cmbBancos);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Location = new System.Drawing.Point(3, 2);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(563, 111);
			this.panel1.TabIndex = 140;
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.White;
			this.label7.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new System.Drawing.Point(68, 69);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 23);
			this.label7.TabIndex = 138;
			this.label7.Text = "Banco:";
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(459, 11);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(100, 84);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(55, 21);
			this.rdoPorMesComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(75, 20);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Por Mes:";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.cmbBancos.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.cmbBancos.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbBancos.DisplayMember = "Descripcion";
			this.cmbBancos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBancos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbBancos.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbBancos.ForeColor = System.Drawing.Color.White;
			this.cmbBancos.FormattingEnabled = true;
			this.cmbBancos.Location = new System.Drawing.Point(147, 61);
			this.cmbBancos.Margin = new System.Windows.Forms.Padding(4);
			this.cmbBancos.Name = "cmbBancos";
			this.cmbBancos.Size = new System.Drawing.Size(295, 34);
			this.cmbBancos.TabIndex = 137;
			this.cmbBancos.ValueMember = "Id";
			this.cmbBancos.SelectedIndexChanged += new System.EventHandler(cmbBancos_SelectedIndexChanged);
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(138, 7);
			this.pnlPorMesVentas.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(324, 42);
			this.pnlPorMesVentas.TabIndex = 41;
			this.cmbMesesComprobantes.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.ForeColor = System.Drawing.Color.Black;
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(7, 6);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(167, 30);
			this.cmbMesesComprobantes.TabIndex = 19;
			this.cmbMesesComprobantes.SelectedIndexChanged += new System.EventHandler(btnRefrescar_Click);
			this.cmbAñoComprobantes.BackColor = System.Drawing.SystemColors.HighlightText;
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.ForeColor = System.Drawing.Color.Black;
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(203, 6);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(101, 30);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.cmbAñoComprobantes.SelectedIndexChanged += new System.EventHandler(btnRefrescar_Click);
			this.tcEstadosCuentaGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcEstadosCuentaGeneral.Controls.Add(this.tbImportacion);
			this.tcEstadosCuentaGeneral.Controls.Add(this.tpCFDISinRelacionar);
			this.tcEstadosCuentaGeneral.Controls.Add(this.tabPage2);
			this.tcEstadosCuentaGeneral.Enabled = false;
			this.tcEstadosCuentaGeneral.Location = new System.Drawing.Point(3, 119);
			this.tcEstadosCuentaGeneral.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tcEstadosCuentaGeneral.Name = "tcEstadosCuentaGeneral";
			this.tcEstadosCuentaGeneral.SelectedIndex = 0;
			this.tcEstadosCuentaGeneral.Size = new System.Drawing.Size(1323, 407);
			this.tcEstadosCuentaGeneral.TabIndex = 139;
			this.tcEstadosCuentaGeneral.SelectedIndexChanged += new System.EventHandler(tcEstadosCuentaGeneral_SelectedIndexChanged);
			this.tbImportacion.Controls.Add(this.pnlGeneral);
			this.tbImportacion.Location = new System.Drawing.Point(4, 25);
			this.tbImportacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbImportacion.Name = "tbImportacion";
			this.tbImportacion.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tbImportacion.Size = new System.Drawing.Size(1315, 378);
			this.tbImportacion.TabIndex = 0;
			this.tbImportacion.Text = "Importación a Bancos";
			this.tbImportacion.UseVisualStyleBackColor = true;
			this.pnlGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pnlGeneral.Controls.Add(this.flpTotalesTodos);
			this.pnlGeneral.Controls.Add(this.label1);
			this.pnlGeneral.Controls.Add(this.txtRutaCarpeta);
			this.pnlGeneral.Controls.Add(this.btnRefrescaCargaArchivo);
			this.pnlGeneral.Controls.Add(this.gvXMLs);
			this.pnlGeneral.Controls.Add(this.btnExportar);
			this.pnlGeneral.Controls.Add(this.btnCargaXMLs);
			this.pnlGeneral.Controls.Add(this.flowLayoutPanel1);
			this.pnlGeneral.Controls.Add(this.flowLayoutPanel14);
			this.pnlGeneral.Location = new System.Drawing.Point(1, 0);
			this.pnlGeneral.Margin = new System.Windows.Forms.Padding(1);
			this.pnlGeneral.Name = "pnlGeneral";
			this.pnlGeneral.Size = new System.Drawing.Size(1313, 378);
			this.pnlGeneral.TabIndex = 135;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.label2);
			this.flpTotalesTodos.Controls.Add(this.txtSubTotal);
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Controls.Add(this.label6);
			this.flpTotalesTodos.Controls.Add(this.txtNumComprobantes);
			this.flpTotalesTodos.Location = new System.Drawing.Point(127, 348);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(1);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(637, 28);
			this.flpTotalesTodos.TabIndex = 136;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "SubTotal:";
			this.label2.Visible = false;
			this.txtSubTotal.Location = new System.Drawing.Point(74, 2);
			this.txtSubTotal.Margin = new System.Windows.Forms.Padding(1);
			this.txtSubTotal.Name = "txtSubTotal";
			this.txtSubTotal.ReadOnly = true;
			this.txtSubTotal.Size = new System.Drawing.Size(103, 22);
			this.txtSubTotal.TabIndex = 1;
			this.txtSubTotal.Visible = false;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.toolStripSeparator1, this.toolStripLabel1, this.tstxtIVA, this.toolStripSeparator2, this.toolStripLabel2, this.tstxtImporte });
			this.toolStrip1.Location = new System.Drawing.Point(172, 1);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(349, 26);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.Visible = false;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel1.Text = "I.V.A:";
			this.tstxtIVA.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIVA.Name = "tstxtIVA";
			this.tstxtIVA.ReadOnly = true;
			this.tstxtIVA.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(65, 23);
			this.toolStripLabel2.Text = "Importe:";
			this.tstxtImporte.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporte.Name = "tstxtImporte";
			this.tstxtImporte.ReadOnly = true;
			this.tstxtImporte.Size = new System.Drawing.Size(82, 26);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(179, 1);
			this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(146, 19);
			this.label6.TabIndex = 3;
			this.label6.Text = "Núm Comprobantes:";
			this.txtNumComprobantes.Location = new System.Drawing.Point(327, 2);
			this.txtNumComprobantes.Margin = new System.Windows.Forms.Padding(1);
			this.txtNumComprobantes.Name = "txtNumComprobantes";
			this.txtNumComprobantes.ReadOnly = true;
			this.txtNumComprobantes.Size = new System.Drawing.Size(55, 22);
			this.txtNumComprobantes.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(31, 15);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 16);
			this.label1.TabIndex = 135;
			this.label1.Text = "Ruta Archivo:";
			this.txtRutaCarpeta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtRutaCarpeta.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRutaCarpeta.Location = new System.Drawing.Point(125, 11);
			this.txtRutaCarpeta.Margin = new System.Windows.Forms.Padding(4);
			this.txtRutaCarpeta.Name = "txtRutaCarpeta";
			this.txtRutaCarpeta.Size = new System.Drawing.Size(739, 24);
			this.txtRutaCarpeta.TabIndex = 128;
			this.btnRefrescaCargaArchivo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescaCargaArchivo.BackColor = System.Drawing.Color.White;
			this.btnRefrescaCargaArchivo.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescaCargaArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRefrescaCargaArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescaCargaArchivo.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescaCargaArchivo.Location = new System.Drawing.Point(867, 0);
			this.btnRefrescaCargaArchivo.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefrescaCargaArchivo.Name = "btnRefrescaCargaArchivo";
			this.btnRefrescaCargaArchivo.Size = new System.Drawing.Size(49, 39);
			this.btnRefrescaCargaArchivo.TabIndex = 131;
			this.btnRefrescaCargaArchivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescaCargaArchivo.UseVisualStyleBackColor = false;
			this.btnRefrescaCargaArchivo.Click += new System.EventHandler(btnRefrescaCargaArchivo_Click);
			this.gvXMLs.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvXMLs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLs.AutoGenerateColumns = false;
			this.gvXMLs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLs.Columns.AddRange(this.fechaDataGridViewTextBoxColumn, this.totalDataGridViewTextBoxColumn, this.GvXMLTipoComprobante, this.GvXMLEliminaRelacion, this.folioDataGridViewTextBoxColumn, this.UUID, this.nombreDataGridViewTextBoxColumn, this.Descripcion, this.gvXmlsColumnElimina);
			this.gvXMLs.DataSource = this.entEstadoDeCuentaBindingSource;
			this.gvXMLs.Location = new System.Drawing.Point(125, 41);
			this.gvXMLs.Margin = new System.Windows.Forms.Padding(4);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(1086, 308);
			this.gvXMLs.TabIndex = 14;
			this.gvXMLs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellClick);
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
			this.fechaDataGridViewTextBoxColumn.FillWeight = 250f;
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.Format = "c4";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
			this.totalDataGridViewTextBoxColumn.FillWeight = 300f;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Monto";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.GvXMLTipoComprobante.HeaderText = "Relación";
			this.GvXMLTipoComprobante.Image = LeeXML.Properties.Resources.Search;
			this.GvXMLTipoComprobante.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.GvXMLTipoComprobante.MinimumWidth = 6;
			this.GvXMLTipoComprobante.Name = "GvXMLTipoComprobante";
			this.GvXMLTipoComprobante.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.GvXMLTipoComprobante.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.GvXMLEliminaRelacion.FillWeight = 50f;
			this.GvXMLEliminaRelacion.HeaderText = "";
			this.GvXMLEliminaRelacion.Image = LeeXML.Properties.Resources.Cancelar_sinFondo;
			this.GvXMLEliminaRelacion.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.GvXMLEliminaRelacion.MinimumWidth = 6;
			this.GvXMLEliminaRelacion.Name = "GvXMLEliminaRelacion";
			this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.folioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
			this.folioDataGridViewTextBoxColumn.FillWeight = 200f;
			this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
			this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
			this.folioDataGridViewTextBoxColumn.ReadOnly = true;
			this.UUID.DataPropertyName = "UUID";
			this.UUID.FillWeight = 350f;
			this.UUID.HeaderText = "UUID";
			this.UUID.MinimumWidth = 6;
			this.UUID.Name = "UUID";
			this.UUID.ReadOnly = true;
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
			this.nombreDataGridViewTextBoxColumn.FillWeight = 300f;
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
			this.Descripcion.DataPropertyName = "Descripcion";
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Descripcion.DefaultCellStyle = dataGridViewCellStyle10;
			this.Descripcion.FillWeight = 350f;
			this.Descripcion.HeaderText = "Observación";
			this.Descripcion.MinimumWidth = 6;
			this.Descripcion.Name = "Descripcion";
			this.gvXmlsColumnElimina.FillWeight = 80f;
			this.gvXmlsColumnElimina.HeaderText = "Elim.";
			this.gvXmlsColumnElimina.Image = LeeXML.Properties.Resources.X;
			this.gvXmlsColumnElimina.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.gvXmlsColumnElimina.MinimumWidth = 6;
			this.gvXmlsColumnElimina.Name = "gvXmlsColumnElimina";
			this.entEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.btnExportar.BackColor = System.Drawing.Color.White;
			this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportar.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportar.Location = new System.Drawing.Point(4, 134);
			this.btnExportar.Margin = new System.Windows.Forms.Padding(4);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(116, 82);
			this.btnExportar.TabIndex = 130;
			this.btnExportar.Text = "Descarga Formato";
			this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportar.UseVisualStyleBackColor = false;
			this.btnExportar.Click += new System.EventHandler(btnExportar_Click);
			this.btnCargaXMLs.BackColor = System.Drawing.Color.White;
			this.btnCargaXMLs.BackgroundImage = LeeXML.Properties.Resources.Folder_Search;
			this.btnCargaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCargaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCargaXMLs.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.btnCargaXMLs.Location = new System.Drawing.Point(4, 39);
			this.btnCargaXMLs.Margin = new System.Windows.Forms.Padding(4);
			this.btnCargaXMLs.Name = "btnCargaXMLs";
			this.btnCargaXMLs.Size = new System.Drawing.Size(116, 82);
			this.btnCargaXMLs.TabIndex = 127;
			this.btnCargaXMLs.Text = "Seleccione Archivo";
			this.btnCargaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCargaXMLs.UseVisualStyleBackColor = false;
			this.btnCargaXMLs.Click += new System.EventHandler(btnCargaXMLs_Click);
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.btnImportaXMLs);
			this.flowLayoutPanel1.Controls.Add(this.btnAgregaDepositoManual);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(1209, 37);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(104, 204);
			this.flowLayoutPanel1.TabIndex = 134;
			this.btnImportaXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnImportaXMLs.BackColor = System.Drawing.Color.White;
			this.btnImportaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnImportaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnImportaXMLs.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnImportaXMLs.Image = LeeXML.Properties.Resources.importar_estados_de_cuenta;
			this.btnImportaXMLs.Location = new System.Drawing.Point(4, 4);
			this.btnImportaXMLs.Margin = new System.Windows.Forms.Padding(4);
			this.btnImportaXMLs.Name = "btnImportaXMLs";
			this.btnImportaXMLs.Size = new System.Drawing.Size(99, 85);
			this.btnImportaXMLs.TabIndex = 131;
			this.btnImportaXMLs.Text = "Importar Estado De Cuenta";
			this.btnImportaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnImportaXMLs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImportaXMLs.UseVisualStyleBackColor = false;
			this.btnImportaXMLs.Click += new System.EventHandler(btnImportaXMLs_Click);
			this.btnAgregaDepositoManual.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAgregaDepositoManual.BackColor = System.Drawing.Color.White;
			this.btnAgregaDepositoManual.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregaDepositoManual.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregaDepositoManual.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregaDepositoManual.Image = LeeXML.Properties.Resources.agregar_recibo;
			this.btnAgregaDepositoManual.Location = new System.Drawing.Point(4, 97);
			this.btnAgregaDepositoManual.Margin = new System.Windows.Forms.Padding(4);
			this.btnAgregaDepositoManual.Name = "btnAgregaDepositoManual";
			this.btnAgregaDepositoManual.Size = new System.Drawing.Size(99, 85);
			this.btnAgregaDepositoManual.TabIndex = 132;
			this.btnAgregaDepositoManual.Text = "Agregar Depósito";
			this.btnAgregaDepositoManual.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregaDepositoManual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAgregaDepositoManual.UseVisualStyleBackColor = false;
			this.btnAgregaDepositoManual.Click += new System.EventHandler(btnAgregaDepositoManual_Click);
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.Controls.Add(this.btnRevisarAnticiposDepositosPrevios);
			this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
			this.flowLayoutPanel14.Location = new System.Drawing.Point(1210, 187);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Size = new System.Drawing.Size(107, 166);
			this.flowLayoutPanel14.TabIndex = 138;
			this.flowLayoutPanel14.Visible = false;
			this.btnRevisarAnticiposDepositosPrevios.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRevisarAnticiposDepositosPrevios.BackColor = System.Drawing.Color.White;
			this.btnRevisarAnticiposDepositosPrevios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRevisarAnticiposDepositosPrevios.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRevisarAnticiposDepositosPrevios.Font = new System.Drawing.Font("Segoe UI", 5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRevisarAnticiposDepositosPrevios.Image = LeeXML.Properties.Resources.World_search;
			this.btnRevisarAnticiposDepositosPrevios.Location = new System.Drawing.Point(4, 77);
			this.btnRevisarAnticiposDepositosPrevios.Margin = new System.Windows.Forms.Padding(4);
			this.btnRevisarAnticiposDepositosPrevios.Name = "btnRevisarAnticiposDepositosPrevios";
			this.btnRevisarAnticiposDepositosPrevios.Size = new System.Drawing.Size(99, 85);
			this.btnRevisarAnticiposDepositosPrevios.TabIndex = 133;
			this.btnRevisarAnticiposDepositosPrevios.Text = "Revisar Anticipos ó Depósitos Previos";
			this.btnRevisarAnticiposDepositosPrevios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRevisarAnticiposDepositosPrevios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRevisarAnticiposDepositosPrevios.UseVisualStyleBackColor = false;
			this.btnRevisarAnticiposDepositosPrevios.Click += new System.EventHandler(btnRevisarAnticiposDepositosPrevios_Click);
			this.tpCFDISinRelacionar.Controls.Add(this.flpPUE);
			this.tpCFDISinRelacionar.Controls.Add(this.gvCFDIsSinRelacionar);
			this.tpCFDISinRelacionar.Controls.Add(this.flowLayoutPanel3);
			this.tpCFDISinRelacionar.Location = new System.Drawing.Point(4, 25);
			this.tpCFDISinRelacionar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpCFDISinRelacionar.Name = "tpCFDISinRelacionar";
			this.tpCFDISinRelacionar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tpCFDISinRelacionar.Size = new System.Drawing.Size(1315, 378);
			this.tpCFDISinRelacionar.TabIndex = 1;
			this.tpCFDISinRelacionar.Text = "CFDI's PUE/CP Sin Relacionar";
			this.tpCFDISinRelacionar.UseVisualStyleBackColor = true;
			this.flpPUE.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpPUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPUE.Controls.Add(this.flowLayoutPanel2);
			this.flpPUE.Controls.Add(this.flowLayoutPanel8);
			this.flpPUE.Controls.Add(this.flowLayoutPanel9);
			this.flpPUE.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPUE.Location = new System.Drawing.Point(191, 274);
			this.flpPUE.Margin = new System.Windows.Forms.Padding(1);
			this.flpPUE.Name = "flpPUE";
			this.flpPUE.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpPUE.Size = new System.Drawing.Size(1029, 99);
			this.flpPUE.TabIndex = 141;
			this.flpPUE.Visible = false;
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(1, 2);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(1023, 29);
			this.flowLayoutPanel2.TabIndex = 135;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel3, this.tstxtNumPUE, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotalPUE, this.toolStripSeparator3, this.toolStripLabel17, this.tstxtIvaPUE, this.toolStripSeparator5, this.toolStripLabel5,
				this.tstxtRetencionesPUE, this.toolStripSeparator13, this.toolStripLabel6, this.tstxtImportePUE
			});
			this.toolStrip2.Location = new System.Drawing.Point(0, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(855, 26);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(82, 23);
			this.toolStripLabel3.Text = "           PUE:";
			this.tstxtNumPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUE.Name = "tstxtNumPUE";
			this.tstxtNumPUE.ReadOnly = true;
			this.tstxtNumPUE.Size = new System.Drawing.Size(47, 26);
			this.tstxtNumPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel4.Text = "SubTotal:";
			this.tstxtSubtotalPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUE.Name = "tstxtSubtotalPUE";
			this.tstxtSubtotalPUE.ReadOnly = true;
			this.tstxtSubtotalPUE.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel17.Name = "toolStripLabel17";
			this.toolStripLabel17.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel17.Text = "I.V.A:";
			this.tstxtIvaPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUE.Name = "tstxtIvaPUE";
			this.tstxtIvaPUE.ReadOnly = true;
			this.tstxtIvaPUE.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(92, 23);
			this.toolStripLabel5.Text = "Retenciones:";
			this.tstxtRetencionesPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUE.Name = "tstxtRetencionesPUE";
			this.tstxtRetencionesPUE.ReadOnly = true;
			this.tstxtRetencionesPUE.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel6.Text = "Total:";
			this.tstxtImportePUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImportePUE.Name = "tstxtImportePUE";
			this.tstxtImportePUE.ReadOnly = true;
			this.tstxtImportePUE.Size = new System.Drawing.Size(108, 26);
			this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel8.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel8.Location = new System.Drawing.Point(1, 33);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel8.Size = new System.Drawing.Size(1023, 29);
			this.flowLayoutPanel8.TabIndex = 136;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel7, this.tstNumCP, this.toolStripSeparator6, this.toolStripLabel8, this.tstSubCP, this.toolStripSeparator7, this.toolStripLabel9, this.tstIvaCP, this.toolStripSeparator8, this.toolStripLabel18,
				this.tstxtRetencionesCP, this.toolStripSeparator14, this.toolStripLabel10, this.tstImporteCP
			});
			this.toolStrip3.Location = new System.Drawing.Point(0, 1);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip3.Size = new System.Drawing.Size(854, 26);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(81, 23);
			this.toolStripLabel7.Text = "             CP:";
			this.tstNumCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumCP.Name = "tstNumCP";
			this.tstNumCP.ReadOnly = true;
			this.tstNumCP.Size = new System.Drawing.Size(47, 26);
			this.tstNumCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel8.Text = "SubTotal:";
			this.tstSubCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstSubCP.Name = "tstSubCP";
			this.tstSubCP.ReadOnly = true;
			this.tstSubCP.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel9.Name = "toolStripLabel9";
			this.toolStripLabel9.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel9.Text = "I.V.A:";
			this.tstIvaCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstIvaCP.Name = "tstIvaCP";
			this.tstIvaCP.ReadOnly = true;
			this.tstIvaCP.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel18.Name = "toolStripLabel18";
			this.toolStripLabel18.Size = new System.Drawing.Size(92, 23);
			this.toolStripLabel18.Text = "Retenciones:";
			this.tstxtRetencionesCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCP.Name = "tstxtRetencionesCP";
			this.tstxtRetencionesCP.ReadOnly = true;
			this.tstxtRetencionesCP.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel10.Name = "toolStripLabel10";
			this.toolStripLabel10.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel10.Text = "Total:";
			this.tstImporteCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstImporteCP.Name = "tstImporteCP";
			this.tstImporteCP.ReadOnly = true;
			this.tstImporteCP.Size = new System.Drawing.Size(108, 26);
			this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel9.Controls.Add(this.toolStrip4);
			this.flowLayoutPanel9.Location = new System.Drawing.Point(1, 64);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel9.Size = new System.Drawing.Size(1023, 29);
			this.flowLayoutPanel9.TabIndex = 137;
			this.toolStrip4.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel11, this.tstNumTotal, this.toolStripSeparator9, this.toolStripLabel12, this.tstSubTotal, this.toolStripSeparator10, this.toolStripLabel13, this.tstIvaTotal, this.toolStripSeparator11, this.toolStripLabel19,
				this.tstxtRetencionesTotal, this.toolStripSeparator15, this.toolStripLabel14, this.tstImporteTotal
			});
			this.toolStrip4.Location = new System.Drawing.Point(0, 1);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip4.Size = new System.Drawing.Size(818, 26);
			this.toolStrip4.TabIndex = 2;
			this.toolStrip4.Text = "toolStrip4";
			this.toolStripLabel11.Name = "toolStripLabel11";
			this.toolStripLabel11.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel11.Text = "Total:";
			this.tstNumTotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstNumTotal.Name = "tstNumTotal";
			this.tstNumTotal.ReadOnly = true;
			this.tstNumTotal.Size = new System.Drawing.Size(47, 26);
			this.tstNumTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel12.Name = "toolStripLabel12";
			this.toolStripLabel12.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel12.Text = "SubTotal:";
			this.tstSubTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstSubTotal.Name = "tstSubTotal";
			this.tstSubTotal.ReadOnly = true;
			this.tstSubTotal.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel13.Name = "toolStripLabel13";
			this.toolStripLabel13.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel13.Text = "I.V.A:";
			this.tstIvaTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstIvaTotal.Name = "tstIvaTotal";
			this.tstIvaTotal.ReadOnly = true;
			this.tstIvaTotal.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel19.Name = "toolStripLabel19";
			this.toolStripLabel19.Size = new System.Drawing.Size(92, 23);
			this.toolStripLabel19.Text = "Retenciones:";
			this.tstxtRetencionesTotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotal.Name = "tstxtRetencionesTotal";
			this.tstxtRetencionesTotal.ReadOnly = true;
			this.tstxtRetencionesTotal.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel14.Name = "toolStripLabel14";
			this.toolStripLabel14.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel14.Text = "Total:";
			this.tstImporteTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstImporteTotal.Name = "tstImporteTotal";
			this.tstImporteTotal.ReadOnly = true;
			this.tstImporteTotal.Size = new System.Drawing.Size(108, 26);
			this.gvCFDIsSinRelacionar.AllowUserToAddRows = false;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
			this.gvCFDIsSinRelacionar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
			this.gvCFDIsSinRelacionar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvCFDIsSinRelacionar.AutoGenerateColumns = false;
			this.gvCFDIsSinRelacionar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvCFDIsSinRelacionar.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvCFDIsSinRelacionar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvCFDIsSinRelacionar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvCFDIsSinRelacionar.Columns.AddRange(this.rFCDataGridViewTextBoxColumn, this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.MetodoPago, this.FormaPago, this.subTotalDataGridViewTextBoxColumn, this.descuentoDataGridViewTextBoxColumn, this.iVADataGridViewTextBoxColumn, this.retencionesDataGridViewTextBoxColumn, this.dataGridViewTextBoxColumn5, this.Descuento, this.EstatusDescripcion);
			this.gvCFDIsSinRelacionar.DataSource = this.entFacturaBindingSource;
			this.gvCFDIsSinRelacionar.Location = new System.Drawing.Point(1, 27);
			this.gvCFDIsSinRelacionar.Margin = new System.Windows.Forms.Padding(4);
			this.gvCFDIsSinRelacionar.Name = "gvCFDIsSinRelacionar";
			this.gvCFDIsSinRelacionar.ReadOnly = true;
			this.gvCFDIsSinRelacionar.RowHeadersVisible = false;
			this.gvCFDIsSinRelacionar.RowHeadersWidth = 51;
			dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
			this.gvCFDIsSinRelacionar.RowsDefaultCellStyle = dataGridViewCellStyle17;
			this.gvCFDIsSinRelacionar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvCFDIsSinRelacionar.Size = new System.Drawing.Size(1217, 249);
			this.gvCFDIsSinRelacionar.TabIndex = 15;
			this.rFCDataGridViewTextBoxColumn.DataPropertyName = "RFC";
			dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rFCDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle18;
			this.rFCDataGridViewTextBoxColumn.FillWeight = 130f;
			this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
			this.rFCDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
			this.rFCDataGridViewTextBoxColumn.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
			this.dataGridViewTextBoxColumn1.FillWeight = 250f;
			this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Folio";
			dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewTextBoxColumn2.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn3.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn4.FillWeight = 80f;
			this.dataGridViewTextBoxColumn4.HeaderText = "Tipo Comprobante";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.MetodoPago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.MetodoPago.DefaultCellStyle = dataGridViewCellStyle20;
			this.MetodoPago.FillWeight = 60f;
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
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle21.Format = "c4";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle21;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
			dataGridViewCellStyle22.Format = "c4";
			this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle22;
			this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
			this.descuentoDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
			this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.Visible = false;
			this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
			dataGridViewCellStyle23.Format = "c4";
			this.iVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle23;
			this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
			this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
			this.iVADataGridViewTextBoxColumn.ReadOnly = true;
			this.retencionesDataGridViewTextBoxColumn.DataPropertyName = "Retenciones";
			dataGridViewCellStyle24.Format = "c4";
			this.retencionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle24;
			this.retencionesDataGridViewTextBoxColumn.HeaderText = "Retenciones";
			this.retencionesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.retencionesDataGridViewTextBoxColumn.Name = "retencionesDataGridViewTextBoxColumn";
			this.retencionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Total";
			dataGridViewCellStyle25.Format = "c4";
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle25;
			this.dataGridViewTextBoxColumn5.HeaderText = "Total";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.Descuento.DataPropertyName = "Descuento";
			dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle26.Format = "c2";
			this.Descuento.DefaultCellStyle = dataGridViewCellStyle26;
			this.Descuento.HeaderText = "Sin Depósitar";
			this.Descuento.MinimumWidth = 6;
			this.Descuento.Name = "Descuento";
			this.Descuento.ReadOnly = true;
			this.EstatusDescripcion.DataPropertyName = "TipoRelacion";
			this.EstatusDescripcion.FillWeight = 220f;
			this.EstatusDescripcion.HeaderText = "Relación";
			this.EstatusDescripcion.MinimumWidth = 6;
			this.EstatusDescripcion.Name = "EstatusDescripcion";
			this.EstatusDescripcion.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel3.Controls.Add(this.btnMarcarNoDepositara);
			this.flowLayoutPanel3.Controls.Add(this.btnMarcarDepositaraPosterior);
			this.flowLayoutPanel3.Controls.Add(this.btnMarcarDepositadoMesAnterior);
			this.flowLayoutPanel3.Controls.Add(this.btnSinRelacion);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(1216, 22);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(107, 362);
			this.flowLayoutPanel3.TabIndex = 142;
			this.btnMarcarNoDepositara.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMarcarNoDepositara.BackColor = System.Drawing.Color.White;
			this.btnMarcarNoDepositara.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnMarcarNoDepositara.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMarcarNoDepositara.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnMarcarNoDepositara.Image = LeeXML.Properties.Resources.Eliminar;
			this.btnMarcarNoDepositara.Location = new System.Drawing.Point(4, 4);
			this.btnMarcarNoDepositara.Margin = new System.Windows.Forms.Padding(4);
			this.btnMarcarNoDepositara.Name = "btnMarcarNoDepositara";
			this.btnMarcarNoDepositara.Size = new System.Drawing.Size(93, 84);
			this.btnMarcarNoDepositara.TabIndex = 133;
			this.btnMarcarNoDepositara.Text = "No Depositará";
			this.btnMarcarNoDepositara.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMarcarNoDepositara.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMarcarNoDepositara.UseVisualStyleBackColor = false;
			this.btnMarcarNoDepositara.Click += new System.EventHandler(btnMarcarNoDepositara_Click);
			this.btnMarcarDepositaraPosterior.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMarcarDepositaraPosterior.BackColor = System.Drawing.Color.White;
			this.btnMarcarDepositaraPosterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnMarcarDepositaraPosterior.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMarcarDepositaraPosterior.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnMarcarDepositaraPosterior.Image = LeeXML.Properties.Resources.palomitaChica_sinFondo;
			this.btnMarcarDepositaraPosterior.Location = new System.Drawing.Point(4, 96);
			this.btnMarcarDepositaraPosterior.Margin = new System.Windows.Forms.Padding(4);
			this.btnMarcarDepositaraPosterior.Name = "btnMarcarDepositaraPosterior";
			this.btnMarcarDepositaraPosterior.Size = new System.Drawing.Size(93, 84);
			this.btnMarcarDepositaraPosterior.TabIndex = 134;
			this.btnMarcarDepositaraPosterior.Text = "Depositará en Mes Posterior";
			this.btnMarcarDepositaraPosterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMarcarDepositaraPosterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMarcarDepositaraPosterior.UseVisualStyleBackColor = false;
			this.btnMarcarDepositaraPosterior.Click += new System.EventHandler(btnMarcarDepositaraPosterior_Click);
			this.btnMarcarDepositadoMesAnterior.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMarcarDepositadoMesAnterior.BackColor = System.Drawing.Color.White;
			this.btnMarcarDepositadoMesAnterior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnMarcarDepositadoMesAnterior.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnMarcarDepositadoMesAnterior.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnMarcarDepositadoMesAnterior.Image = LeeXML.Properties.Resources.volver;
			this.btnMarcarDepositadoMesAnterior.Location = new System.Drawing.Point(4, 188);
			this.btnMarcarDepositadoMesAnterior.Margin = new System.Windows.Forms.Padding(4);
			this.btnMarcarDepositadoMesAnterior.Name = "btnMarcarDepositadoMesAnterior";
			this.btnMarcarDepositadoMesAnterior.Size = new System.Drawing.Size(93, 84);
			this.btnMarcarDepositadoMesAnterior.TabIndex = 135;
			this.btnMarcarDepositadoMesAnterior.Text = "Depositado en Mes Anterior";
			this.btnMarcarDepositadoMesAnterior.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnMarcarDepositadoMesAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnMarcarDepositadoMesAnterior.UseVisualStyleBackColor = false;
			this.btnMarcarDepositadoMesAnterior.Click += new System.EventHandler(btnMarcarDepositadoMesAnterior_Click);
			this.btnSinRelacion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnSinRelacion.BackColor = System.Drawing.Color.White;
			this.btnSinRelacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnSinRelacion.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSinRelacion.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnSinRelacion.Image = LeeXML.Properties.Resources.Cancelar_sinFondo;
			this.btnSinRelacion.Location = new System.Drawing.Point(4, 280);
			this.btnSinRelacion.Margin = new System.Windows.Forms.Padding(4);
			this.btnSinRelacion.Name = "btnSinRelacion";
			this.btnSinRelacion.Size = new System.Drawing.Size(93, 84);
			this.btnSinRelacion.TabIndex = 136;
			this.btnSinRelacion.Text = "Sin Relación";
			this.btnSinRelacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSinRelacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnSinRelacion.UseVisualStyleBackColor = false;
			this.btnSinRelacion.Click += new System.EventHandler(btnSinRelacion_Click);
			this.tabPage2.Controls.Add(this.gvEstadoDeCuentasImportados);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.cmbBancoFiltro);
			this.tabPage2.Controls.Add(this.flowLayoutPanel4);
			this.tabPage2.Controls.Add(this.flowLayoutPanel10);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage2.Size = new System.Drawing.Size(1315, 378);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "Estado de Cuentas Importados";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.gvEstadoDeCuentasImportados.AllowUserToAddRows = false;
			dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle27.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvEstadoDeCuentasImportados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
			this.gvEstadoDeCuentasImportados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvEstadoDeCuentasImportados.AutoGenerateColumns = false;
			this.gvEstadoDeCuentasImportados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvEstadoDeCuentasImportados.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvEstadoDeCuentasImportados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvEstadoDeCuentasImportados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvEstadoDeCuentasImportados.Columns.AddRange(this.Banco, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn13, this.gvEstadosCuentaColumPago, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9);
			this.gvEstadoDeCuentasImportados.DataSource = this.entEstadoDeCuentaBindingSource;
			this.gvEstadoDeCuentasImportados.Location = new System.Drawing.Point(1, 34);
			this.gvEstadoDeCuentasImportados.Margin = new System.Windows.Forms.Padding(4);
			this.gvEstadoDeCuentasImportados.Name = "gvEstadoDeCuentasImportados";
			this.gvEstadoDeCuentasImportados.RowHeadersVisible = false;
			this.gvEstadoDeCuentasImportados.RowHeadersWidth = 51;
			dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle28.ForeColor = System.Drawing.Color.Black;
			this.gvEstadoDeCuentasImportados.RowsDefaultCellStyle = dataGridViewCellStyle28;
			this.gvEstadoDeCuentasImportados.RowTemplate.Height = 30;
			this.gvEstadoDeCuentasImportados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvEstadoDeCuentasImportados.Size = new System.Drawing.Size(1219, 245);
			this.gvEstadoDeCuentasImportados.TabIndex = 148;
			this.Banco.DataPropertyName = "Banco";
			this.Banco.FillWeight = 200f;
			this.Banco.HeaderText = "Banco";
			this.Banco.MinimumWidth = 6;
			this.Banco.Name = "Banco";
			this.Banco.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Fecha";
			dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle29;
			this.dataGridViewTextBoxColumn6.FillWeight = 300f;
			this.dataGridViewTextBoxColumn6.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "Pago";
			dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle30.Format = "c2";
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle30;
			this.dataGridViewTextBoxColumn7.FillWeight = 300f;
			this.dataGridViewTextBoxColumn7.HeaderText = "Monto Depósito";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn13.DataPropertyName = "TipoRelacion";
			this.dataGridViewTextBoxColumn13.FillWeight = 300f;
			this.dataGridViewTextBoxColumn13.HeaderText = "TipoRelacion";
			this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn13.ReadOnly = true;
			this.gvEstadosCuentaColumPago.DataPropertyName = "Total";
			dataGridViewCellStyle31.Format = "c2";
			this.gvEstadosCuentaColumPago.DefaultCellStyle = dataGridViewCellStyle31;
			this.gvEstadosCuentaColumPago.FillWeight = 200f;
			this.gvEstadosCuentaColumPago.HeaderText = "Monto Factura";
			this.gvEstadosCuentaColumPago.MinimumWidth = 6;
			this.gvEstadosCuentaColumPago.Name = "gvEstadosCuentaColumPago";
			this.gvEstadosCuentaColumPago.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "Folio";
			dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle32;
			this.dataGridViewTextBoxColumn8.FillWeight = 150f;
			this.dataGridViewTextBoxColumn8.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn9.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn9.FillWeight = 400f;
			this.dataGridViewTextBoxColumn9.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.White;
			this.label8.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new System.Drawing.Point(15, 5);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 23);
			this.label8.TabIndex = 147;
			this.label8.Text = "Banco:";
			this.label8.Visible = false;
			this.cmbBancoFiltro.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbBancoFiltro.DisplayMember = "Descripcion";
			this.cmbBancoFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBancoFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbBancoFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbBancoFiltro.FormattingEnabled = true;
			this.cmbBancoFiltro.Location = new System.Drawing.Point(93, 1);
			this.cmbBancoFiltro.Margin = new System.Windows.Forms.Padding(4);
			this.cmbBancoFiltro.Name = "cmbBancoFiltro";
			this.cmbBancoFiltro.Size = new System.Drawing.Size(167, 30);
			this.cmbBancoFiltro.TabIndex = 146;
			this.cmbBancoFiltro.ValueMember = "Id";
			this.cmbBancoFiltro.Visible = false;
			this.cmbBancoFiltro.SelectedIndexChanged += new System.EventHandler(cmbBancoFiltro_SelectedIndexChanged);
			this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel5);
			this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel6);
			this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel7);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(191, 279);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel4.Size = new System.Drawing.Size(1029, 99);
			this.flowLayoutPanel4.TabIndex = 144;
			this.flowLayoutPanel4.Visible = false;
			this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel5.Controls.Add(this.toolStrip5);
			this.flowLayoutPanel5.Location = new System.Drawing.Point(1, 2);
			this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel5.Size = new System.Drawing.Size(1023, 29);
			this.flowLayoutPanel5.TabIndex = 135;
			this.toolStrip5.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel15, this.toolStripTextBox1, this.toolStripSeparator12, this.toolStripLabel16, this.toolStripTextBox2, this.toolStripSeparator16, this.toolStripLabel20, this.toolStripTextBox3, this.toolStripSeparator17, this.toolStripLabel21,
				this.toolStripTextBox4, this.toolStripSeparator18, this.toolStripLabel22, this.toolStripTextBox5
			});
			this.toolStrip5.Location = new System.Drawing.Point(0, 1);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip5.Size = new System.Drawing.Size(855, 26);
			this.toolStrip5.TabIndex = 2;
			this.toolStrip5.Text = "toolStrip5";
			this.toolStripLabel15.Name = "toolStripLabel15";
			this.toolStripLabel15.Size = new System.Drawing.Size(82, 23);
			this.toolStripLabel15.Text = "           PUE:";
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.ReadOnly = true;
			this.toolStripTextBox1.Size = new System.Drawing.Size(47, 26);
			this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel16.Name = "toolStripLabel16";
			this.toolStripLabel16.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel16.Text = "SubTotal:";
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel20.Name = "toolStripLabel20";
			this.toolStripLabel20.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel20.Text = "I.V.A:";
			this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox3.Name = "toolStripTextBox3";
			this.toolStripTextBox3.ReadOnly = true;
			this.toolStripTextBox3.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel21.Name = "toolStripLabel21";
			this.toolStripLabel21.Size = new System.Drawing.Size(92, 23);
			this.toolStripLabel21.Text = "Retenciones:";
			this.toolStripTextBox4.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox4.Name = "toolStripTextBox4";
			this.toolStripTextBox4.ReadOnly = true;
			this.toolStripTextBox4.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel22.Name = "toolStripLabel22";
			this.toolStripLabel22.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel22.Text = "Total:";
			this.toolStripTextBox5.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox5.Name = "toolStripTextBox5";
			this.toolStripTextBox5.ReadOnly = true;
			this.toolStripTextBox5.Size = new System.Drawing.Size(108, 26);
			this.flowLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel6.Controls.Add(this.toolStrip6);
			this.flowLayoutPanel6.Location = new System.Drawing.Point(1, 33);
			this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel6.Size = new System.Drawing.Size(1023, 29);
			this.flowLayoutPanel6.TabIndex = 136;
			this.toolStrip6.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel23, this.toolStripTextBox6, this.toolStripSeparator19, this.toolStripLabel24, this.toolStripTextBox7, this.toolStripSeparator20, this.toolStripLabel25, this.toolStripTextBox8, this.toolStripSeparator21, this.toolStripLabel26,
				this.toolStripTextBox9, this.toolStripSeparator22, this.toolStripLabel27, this.toolStripTextBox10
			});
			this.toolStrip6.Location = new System.Drawing.Point(0, 1);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip6.Size = new System.Drawing.Size(854, 26);
			this.toolStrip6.TabIndex = 2;
			this.toolStrip6.Text = "toolStrip6";
			this.toolStripLabel23.Name = "toolStripLabel23";
			this.toolStripLabel23.Size = new System.Drawing.Size(81, 23);
			this.toolStripLabel23.Text = "             CP:";
			this.toolStripTextBox6.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox6.Name = "toolStripTextBox6";
			this.toolStripTextBox6.ReadOnly = true;
			this.toolStripTextBox6.Size = new System.Drawing.Size(47, 26);
			this.toolStripTextBox6.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel24.Name = "toolStripLabel24";
			this.toolStripLabel24.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel24.Text = "SubTotal:";
			this.toolStripTextBox7.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox7.Name = "toolStripTextBox7";
			this.toolStripTextBox7.ReadOnly = true;
			this.toolStripTextBox7.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel25.Name = "toolStripLabel25";
			this.toolStripLabel25.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel25.Text = "I.V.A:";
			this.toolStripTextBox8.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox8.Name = "toolStripTextBox8";
			this.toolStripTextBox8.ReadOnly = true;
			this.toolStripTextBox8.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel26.Name = "toolStripLabel26";
			this.toolStripLabel26.Size = new System.Drawing.Size(92, 23);
			this.toolStripLabel26.Text = "Retenciones:";
			this.toolStripTextBox9.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox9.Name = "toolStripTextBox9";
			this.toolStripTextBox9.ReadOnly = true;
			this.toolStripTextBox9.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel27.Name = "toolStripLabel27";
			this.toolStripLabel27.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel27.Text = "Total:";
			this.toolStripTextBox10.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox10.Name = "toolStripTextBox10";
			this.toolStripTextBox10.ReadOnly = true;
			this.toolStripTextBox10.Size = new System.Drawing.Size(108, 26);
			this.flowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel7.Controls.Add(this.toolStrip7);
			this.flowLayoutPanel7.Location = new System.Drawing.Point(1, 64);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel7.Size = new System.Drawing.Size(1023, 29);
			this.flowLayoutPanel7.TabIndex = 137;
			this.toolStrip7.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel28, this.toolStripTextBox11, this.toolStripSeparator23, this.toolStripLabel29, this.toolStripTextBox12, this.toolStripSeparator24, this.toolStripLabel30, this.toolStripTextBox13, this.toolStripSeparator25, this.toolStripLabel31,
				this.toolStripTextBox14, this.toolStripSeparator26, this.toolStripLabel32, this.toolStripTextBox15
			});
			this.toolStrip7.Location = new System.Drawing.Point(0, 1);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip7.Size = new System.Drawing.Size(818, 26);
			this.toolStrip7.TabIndex = 2;
			this.toolStrip7.Text = "toolStrip7";
			this.toolStripLabel28.Name = "toolStripLabel28";
			this.toolStripLabel28.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel28.Text = "Total:";
			this.toolStripTextBox11.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox11.Name = "toolStripTextBox11";
			this.toolStripTextBox11.ReadOnly = true;
			this.toolStripTextBox11.Size = new System.Drawing.Size(47, 26);
			this.toolStripTextBox11.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel29.Name = "toolStripLabel29";
			this.toolStripLabel29.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel29.Text = "SubTotal:";
			this.toolStripTextBox12.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.toolStripTextBox12.Name = "toolStripTextBox12";
			this.toolStripTextBox12.ReadOnly = true;
			this.toolStripTextBox12.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator24.Name = "toolStripSeparator24";
			this.toolStripSeparator24.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel30.Name = "toolStripLabel30";
			this.toolStripLabel30.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel30.Text = "I.V.A:";
			this.toolStripTextBox13.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.toolStripTextBox13.Name = "toolStripTextBox13";
			this.toolStripTextBox13.ReadOnly = true;
			this.toolStripTextBox13.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator25.Name = "toolStripSeparator25";
			this.toolStripSeparator25.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel31.Name = "toolStripLabel31";
			this.toolStripLabel31.Size = new System.Drawing.Size(92, 23);
			this.toolStripLabel31.Text = "Retenciones:";
			this.toolStripTextBox14.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox14.Name = "toolStripTextBox14";
			this.toolStripTextBox14.ReadOnly = true;
			this.toolStripTextBox14.Size = new System.Drawing.Size(108, 26);
			this.toolStripSeparator26.Name = "toolStripSeparator26";
			this.toolStripSeparator26.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel32.Name = "toolStripLabel32";
			this.toolStripLabel32.Size = new System.Drawing.Size(45, 23);
			this.toolStripLabel32.Text = "Total:";
			this.toolStripTextBox15.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.toolStripTextBox15.Name = "toolStripTextBox15";
			this.toolStripTextBox15.ReadOnly = true;
			this.toolStripTextBox15.Size = new System.Drawing.Size(108, 26);
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.Controls.Add(this.btnVerificaDepositado);
			this.flowLayoutPanel10.Controls.Add(this.btnEliminaDeposito);
			this.flowLayoutPanel10.Controls.Add(this.btnEnviarAExcelEstadosCuentaImportados);
			this.flowLayoutPanel10.Location = new System.Drawing.Point(1216, 27);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Size = new System.Drawing.Size(107, 336);
			this.flowLayoutPanel10.TabIndex = 145;
			this.btnVerificaDepositado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnVerificaDepositado.BackColor = System.Drawing.Color.White;
			this.btnVerificaDepositado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnVerificaDepositado.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnVerificaDepositado.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnVerificaDepositado.Image = LeeXML.Properties.Resources.palomitaChica_sinFondo;
			this.btnVerificaDepositado.Location = new System.Drawing.Point(4, 4);
			this.btnVerificaDepositado.Margin = new System.Windows.Forms.Padding(4);
			this.btnVerificaDepositado.Name = "btnVerificaDepositado";
			this.btnVerificaDepositado.Size = new System.Drawing.Size(93, 84);
			this.btnVerificaDepositado.TabIndex = 135;
			this.btnVerificaDepositado.Text = "Verifica Depositado";
			this.btnVerificaDepositado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnVerificaDepositado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnVerificaDepositado.UseVisualStyleBackColor = false;
			this.btnVerificaDepositado.Visible = false;
			this.btnVerificaDepositado.Click += new System.EventHandler(btnVerificaDepositado_Click);
			this.btnEliminaDeposito.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEliminaDeposito.BackColor = System.Drawing.Color.White;
			this.btnEliminaDeposito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEliminaDeposito.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEliminaDeposito.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEliminaDeposito.Image = LeeXML.Properties.Resources.Eliminar;
			this.btnEliminaDeposito.Location = new System.Drawing.Point(4, 96);
			this.btnEliminaDeposito.Margin = new System.Windows.Forms.Padding(4);
			this.btnEliminaDeposito.Name = "btnEliminaDeposito";
			this.btnEliminaDeposito.Size = new System.Drawing.Size(93, 84);
			this.btnEliminaDeposito.TabIndex = 136;
			this.btnEliminaDeposito.Text = "Eliminar Depósito";
			this.btnEliminaDeposito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEliminaDeposito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEliminaDeposito.UseVisualStyleBackColor = false;
			this.btnEliminaDeposito.Click += new System.EventHandler(btnEliminaDeposito_Click);
			this.btnEnviarAExcelEstadosCuentaImportados.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnEnviarAExcelEstadosCuentaImportados.BackColor = System.Drawing.Color.White;
			this.btnEnviarAExcelEstadosCuentaImportados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEnviarAExcelEstadosCuentaImportados.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEnviarAExcelEstadosCuentaImportados.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEnviarAExcelEstadosCuentaImportados.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnEnviarAExcelEstadosCuentaImportados.Location = new System.Drawing.Point(4, 188);
			this.btnEnviarAExcelEstadosCuentaImportados.Margin = new System.Windows.Forms.Padding(4);
			this.btnEnviarAExcelEstadosCuentaImportados.Name = "btnEnviarAExcelEstadosCuentaImportados";
			this.btnEnviarAExcelEstadosCuentaImportados.Size = new System.Drawing.Size(93, 84);
			this.btnEnviarAExcelEstadosCuentaImportados.TabIndex = 137;
			this.btnEnviarAExcelEstadosCuentaImportados.Text = "Enviar a Excel";
			this.btnEnviarAExcelEstadosCuentaImportados.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEnviarAExcelEstadosCuentaImportados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnEnviarAExcelEstadosCuentaImportados.UseVisualStyleBackColor = false;
			this.btnEnviarAExcelEstadosCuentaImportados.Click += new System.EventHandler(btnEnviarAExcelEstadosCuentaImportados_Click);
			this.rdoPorFechasComprobantes.AutoSize = true;
			this.rdoPorFechasComprobantes.Location = new System.Drawing.Point(593, 109);
			this.rdoPorFechasComprobantes.Margin = new System.Windows.Forms.Padding(4);
			this.rdoPorFechasComprobantes.Name = "rdoPorFechasComprobantes";
			this.rdoPorFechasComprobantes.Size = new System.Drawing.Size(86, 20);
			this.rdoPorFechasComprobantes.TabIndex = 43;
			this.rdoPorFechasComprobantes.Text = "Por Fechas";
			this.rdoPorFechasComprobantes.UseVisualStyleBackColor = true;
			this.rdoPorFechasComprobantes.Visible = false;
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(593, 10);
			this.gbDatosGenerales.Margin = new System.Windows.Forms.Padding(4);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Padding = new System.Windows.Forms.Padding(4);
			this.gbDatosGenerales.Size = new System.Drawing.Size(459, 85);
			this.gbDatosGenerales.TabIndex = 136;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(17, 25);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(122, 23);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtNombreFiscal.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(152, 21);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(295, 26);
			this.txtNombreFiscal.TabIndex = 104;
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(152, 53);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(196, 26);
			this.txtRFC.TabIndex = 106;
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(88, 54);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 23);
			this.label5.TabIndex = 105;
			this.label5.Text = "R.F.C:";
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
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaHasta);
			this.pnlPorDiaVentas.Controls.Add(this.dtpFechaDesde);
			this.pnlPorDiaVentas.Enabled = false;
			this.pnlPorDiaVentas.Location = new System.Drawing.Point(704, 97);
			this.pnlPorDiaVentas.Margin = new System.Windows.Forms.Padding(4);
			this.pnlPorDiaVentas.Name = "pnlPorDiaVentas";
			this.pnlPorDiaVentas.Size = new System.Drawing.Size(324, 39);
			this.pnlPorDiaVentas.TabIndex = 42;
			this.pnlPorDiaVentas.Visible = false;
			this.dtpFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaHasta.Location = new System.Drawing.Point(159, 9);
			this.dtpFechaHasta.Margin = new System.Windows.Forms.Padding(4);
			this.dtpFechaHasta.Name = "dtpFechaHasta";
			this.dtpFechaHasta.Size = new System.Drawing.Size(145, 22);
			this.dtpFechaHasta.TabIndex = 16;
			this.dtpFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaDesde.Location = new System.Drawing.Point(7, 9);
			this.dtpFechaDesde.Margin = new System.Windows.Forms.Padding(4);
			this.dtpFechaDesde.Name = "dtpFechaDesde";
			this.dtpFechaDesde.Size = new System.Drawing.Size(145, 22);
			this.dtpFechaDesde.TabIndex = 15;
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Location = new System.Drawing.Point(510, 16);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(68, 17);
			this.label24.TabIndex = 131;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(581, 9);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(433, 33);
			this.cmbEmpresas.TabIndex = 132;
			this.cmbEmpresas.ValueMember = "Id";
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
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(1018, 7);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(52, 34);
			this.btnBuscaEmpresa.TabIndex = 130;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1360, 604);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "EstadoDeCuenta";
			this.Text = "DEVE";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.pnlPorMesVentas.ResumeLayout(false);
			this.tcEstadosCuentaGeneral.ResumeLayout(false);
			this.tbImportacion.ResumeLayout(false);
			this.pnlGeneral.ResumeLayout(false);
			this.pnlGeneral.PerformLayout();
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entEstadoDeCuentaBindingSource).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel14.ResumeLayout(false);
			this.tpCFDISinRelacionar.ResumeLayout(false);
			this.flpPUE.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.flowLayoutPanel8.ResumeLayout(false);
			this.flowLayoutPanel8.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvCFDIsSinRelacionar).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvEstadoDeCuentasImportados).EndInit();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowLayoutPanel5.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel6.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			this.flowLayoutPanel7.ResumeLayout(false);
			this.flowLayoutPanel7.PerformLayout();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.pnlPorDiaVentas.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
