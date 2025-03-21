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
	public class SeleccionaRelacionEgresos : FormBase
	{
		private IContainer components = null;

		private Button btnCancelar;

		private Button btnAgregar;

		private BindingSource entEmpresaBindingSource;

		private BindingSource entFacturaBindingSource;

		private FlowLayoutPanel flowLayoutPanel1;

		private DataGridView gvFacturas;

		private ComboBox cmbTiposRelacion;

		private Panel panel1;

		private BindingSource entCatalogoGenericoBindingSource;

		private Panel pnlFiltro;

		private Label label1;

		private TextBox txtFacturaFiltro;

		private Button btnFiltraFacturas;

		private Label label2;

		private Panel pnlBotones;

		private Panel pnlAnticipo;

		private Panel panel3;

		private RadioButton rdoTasa0;

		private RadioButton rdoTasa16;

		private Panel panel4;

		private TextBox txtSubtotal;

		private Label label3;

		private Label label4;

		private TextBox txtIVA;

		private Panel pnlRetenciones;

		private CheckBox chkIsrRetenido;

		private CheckBox chkIvaRetenido;

		private TextBox txtIsrRetenidoPorcentaje;

		private TextBox txtIvaRetenidoPorcentaje;

		private TextBox txtISRRetenido;

		private Label lbISRretenido;

		private TextBox txtIVARetenido;

		private Label lbIVAretenido;

		private TextBox txtTotal;

		private Label label7;

		private Panel pnlFiltroPUEPPD;

		private RadioButton rdoPPD;

		private RadioButton rdoPueCP;

		private Label label5;

		private TextBox txtUUIDfiltro;

		private Label lbNombreFiltro;

		private TextBox txtProveedor;

		private RadioButton rdoNomina;

		private Label label8;

		private TextBox txtDescripcion;

		private RadioButton rdoNcDevoluciones;

		private DataGridViewCheckBoxColumn Seleccionar;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn UUID;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn gvRFCreceptor;

		private DataGridViewTextBoxColumn gvNombreReceptor;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn Descripcion;

		public EntEstadoDeCuenta Deposito { get; set; }

		public bool Anticipo { get; set; }

		public decimal Total { get; set; }

		public EntCatalogoGenerico TipoMovimientoSeleccionado
		{
			get
			{
				if (rdoNomina.Checked)
				{
					return new EntCatalogoGenerico
					{
						Id = 16,
						Descripcion = "NÓMINA"
					};
				}
				if (rdoNcDevoluciones.Checked)
				{
					return new EntCatalogoGenerico
					{
						Id = 17,
						Descripcion = "NOTA DE CRÉDITO - DEV"
					};
				}
				return ObtieneCatalogoGenericoFromCmb(cmbTiposRelacion);
			}
		}

		public List<EntFactura> FacturasSeleccionadas
		{
			get
			{
				if (rdoPueCP.Checked || rdoPPD.Checked)
				{
					return ListaFacturas.Where((EntFactura P) => P.Estatus).ToList();
				}
				if (rdoNomina.Checked)
				{
					return ListaFacturasNominas.Where((EntFactura P) => P.Estatus).ToList();
				}
				return ListaFacturasNcDevoluciones.Where((EntFactura P) => P.Estatus).ToList();
			}
		}

		public int TipoRelacionExcedenteId
		{
			get
			{
				if (ObtieneCatalogoGenericoFromCmb(cmbTiposRelacion).Id == 15)
				{
					return 6;
				}
				return 7;
			}
		}

		public EntFactura FacturaAnticipo
		{
			get
			{
				EntFactura entFactura = new EntFactura();
				entFactura.Id = -1;
				entFactura.ClienteId = -1;
				entFactura.TipoComprobanteId = TipoRelacionExcedenteId;
				entFactura.SubTotal = ConvierteTextoADecimal(txtSubtotal);
				entFactura.IVA = ConvierteTextoADecimal(txtIVA);
				entFactura.IVARetenciones = ConvierteTextoADecimal(txtIVARetenido);
				entFactura.ISRRetenciones = ConvierteTextoADecimal(txtISRRetenido);
				entFactura.Total = ConvierteTextoADecimal(txtTotal);
				entFactura.Pago = ConvierteTextoADecimal(txtTotal);
				entFactura.Fecha = Deposito.Fecha;
				entFactura.Descripcion = TipoMovimientoSeleccionado.Descripcion;
				entFactura.Nombre = "";
				entFactura.RFC = "";
				entFactura.UsoCFDI = "";
				entFactura.NumeroFactura = "";
				entFactura.SerieFactura = "";
				entFactura.UUID = "";
				entFactura.UUIDrelacionado = "";
				entFactura.FormaPago = "";
				entFactura.FechaPago = new DateTime(1900, 1, 1);
				entFactura.Ruta = "";
				entFactura.PDF = new byte[1];
				entFactura.XML = new byte[1];
				entFactura.EmpresaId = Program.EmpresaSeleccionada.Id;
				entFactura.UsuarioId = Program.UsuarioSeleccionado.Id;
				return entFactura;
			}
		}

		public List<EntFactura> ListaFacturas { get; set; }

		public List<EntFactura> ListaFacturasNominas { get; set; }

		public List<EntFactura> ListaFacturasNcDevoluciones { get; set; }

		public SeleccionaRelacionEgresos(EntEstadoDeCuenta Deposito, int TipoMovimientoId)
		{
			InitializeComponent();
			this.Deposito = Deposito;
			Total = Deposito.Total;
			CargaTiposMovimientos(TipoMovimientoId);
		}

		public SeleccionaRelacionEgresos(EntEstadoDeCuenta Deposito, bool Anticipo, decimal Total)
		{
			InitializeComponent();
			this.Deposito = Deposito;
			this.Total = Total;
			CargaTiposMovimientos(15);
			this.Anticipo = Anticipo;
		}

		public void CargaTiposMovimientos(int TipoMovimientoId)
		{
			cmbTiposRelacion.DataSource = new BusEmpresas().ObtieneTiposMovimientosEgreso(Program.EmpresaSeleccionada.Id);
			cmbTiposRelacion.SelectedIndex = ((List<EntCatalogoGenerico>)cmbTiposRelacion.DataSource).FindIndex((EntCatalogoGenerico P) => P.Id == TipoMovimientoId);
		}

		private void CargaPuePpdNominaNc(List<EntFactura> ListaFacturas, int TipoId)
		{
			if (TipoId == 1)
			{
				gvFacturas.DataSource = ListaFacturas.Where((EntFactura P) => (P.TipoComprobanteId == 1 && P.MetodoPagoId == 1) || P.TipoComprobanteId == 5).ToList();
			}
			else if (TipoId == 2)
			{
				gvFacturas.DataSource = ListaFacturas.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 2).ToList();
			}
			else if (TipoId == 3 || TipoId == 4)
			{
				gvFacturas.DataSource = ListaFacturas;
			}
			gvFacturas.Refresh();
		}

		private void SeleccionEmpresa_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Anticipo)
				{
					ListaFacturas = (from P in new BusFacturas().ObtieneComprobantesFiscalesPorDepositarEgresos(Program.EmpresaSeleccionada, new DateTime(1900, 1, 1), ObtieneFechaUltimoDiaMes(Deposito.Fecha))
						where P.TotalUSD == 0m
						select P).ToList();
					ListaFacturasNominas = (from P in new BusFacturas().ObtieneComprobantesFiscalesNominaPorDepositar(Program.EmpresaSeleccionada, new DateTime(1900, 1, 1), ObtieneFechaUltimoDiaMes(Deposito.Fecha))
						where P.TipoComprobanteId == 4
						select P).ToList();
					ListaFacturasNcDevoluciones = (from P in new BusFacturas().ObtieneComprobantesFiscalesNcDevolucionPorDepositar(Program.EmpresaSeleccionada, new DateTime(1900, 1, 1), ObtieneFechaUltimoDiaMes(Deposito.Fecha))
						where P.TotalUSD == 0m
						select P).ToList();
					CargaPuePpdNominaNc(ListaFacturas, ConvierteTextoAInteger(rdoPueCP.Tag.ToString()));
					txtFacturaFiltro.Focus();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbTiposRelacion_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				pnlAnticipo.Visible = false;
				if (cmbTiposRelacion.SelectedIndex > 0)
				{
					if (Anticipo && ObtieneCatalogoGenericoFromCmb(cmbTiposRelacion).Id == 1)
					{
						MuestraMensaje("NO SE PERMITE RELACIONAR DEPÓSITO EXCEDENTE CON FACTURA");
						cmbTiposRelacion.SelectedIndex = 0;
					}
					pnlFiltro.Visible = false;
					pnlFiltroPUEPPD.Visible = false;
					gvFacturas.Visible = false;
					if (ObtieneCatalogoGenericoFromCmb(cmbTiposRelacion).Id == 15)
					{
						pnlAnticipo.Visible = true;
						rdoTasa16.Checked = true;
					}
				}
				else
				{
					pnlFiltro.Visible = true;
					pnlFiltroPUEPPD.Visible = true;
					gvFacturas.Visible = true;
					gvFacturas.DataSource = ListaFacturas;
					gvFacturas.Refresh();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
		}

		private void gvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				btnAgregar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtFacturaFiltro_TextChanged(object sender, EventArgs e)
		{
		}

		private void gvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				ObtieneFacturaFromGV(gvFacturas).Estatus = !ObtieneFacturaFromGV(gvFacturas).Estatus;
				gvFacturas.Refresh();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CalculaCantidadesAnticipo(decimal Total, bool Tasa16, decimal IvaRetenidoPorcentaje, decimal IsrRetenidoPorcentaje)
		{
			decimal cantidadIVARetenido = default(decimal);
			decimal cantidadISRRetenido = default(decimal);
			decimal porcentaje = 100m - IvaRetenidoPorcentaje - IsrRetenidoPorcentaje;
			decimal iva;
			if (Tasa16)
			{
				iva = 16m;
				porcentaje += 16m;
			}
			else
			{
				iva = default(decimal);
			}
			decimal subtotal = Total * 100m / porcentaje;
			decimal cantidadIva = Total * iva / porcentaje;
			cantidadIVARetenido = subtotal * (IvaRetenidoPorcentaje / 100m);
			cantidadISRRetenido = subtotal * (IsrRetenidoPorcentaje / 100m);
			decimal cantidadIEPS = default(decimal);
			txtTotal.Text = FormatoMoney(subtotal + cantidadIva - cantidadIVARetenido - cantidadISRRetenido);
			txtSubtotal.Text = FormatoMoney(subtotal);
			txtIVA.Text = FormatoMoney(cantidadIva);
			txtIVARetenido.Text = FormatoMoney(cantidadIVARetenido);
			txtISRRetenido.Text = FormatoMoney(cantidadISRRetenido);
		}

		private void rdoTasa16_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				txtIvaRetenidoPorcentaje.Text = "0";
				chkIvaRetenido.Enabled = true;
				CalculaCantidadesAnticipo(Total, rdoTasa16.Checked, ConvierteTextoADecimal(txtIvaRetenidoPorcentaje), ConvierteTextoADecimal(txtIsrRetenidoPorcentaje.Text.Replace("%", "")));
				pnlRetenciones.Visible = true;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoTasa0_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				txtIvaRetenidoPorcentaje.Text = "0";
				chkIvaRetenido.Checked = false;
				chkIvaRetenido.Enabled = false;
				CalculaCantidadesAnticipo(Total, rdoTasa16.Checked, ConvierteTextoADecimal(txtIvaRetenidoPorcentaje), ConvierteTextoADecimal(txtIsrRetenidoPorcentaje.Text.Replace("%", "")));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void chkIvaRetenido_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				txtIvaRetenidoPorcentaje.Text = "0";
				txtIvaRetenidoPorcentaje.Enabled = chkIvaRetenido.Checked;
				txtIvaRetenidoPorcentaje.Focus();
				CalculaCantidadesAnticipo(Total, rdoTasa16.Checked, ConvierteTextoADecimal(txtIvaRetenidoPorcentaje), ConvierteTextoADecimal(txtIsrRetenidoPorcentaje.Text.Replace("%", "")));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void chkIsrRetenido_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				txtIsrRetenidoPorcentaje.Enabled = chkIsrRetenido.Checked;
				txtIsrRetenidoPorcentaje.Focus();
				if (chkIsrRetenido.Checked)
				{
					txtIsrRetenidoPorcentaje.Text = "10%";
				}
				else
				{
					txtIsrRetenidoPorcentaje.Text = "0%";
				}
				CalculaCantidadesAnticipo(Total, rdoTasa16.Checked, ConvierteTextoADecimal(txtIvaRetenidoPorcentaje), ConvierteTextoADecimal(txtIsrRetenidoPorcentaje.Text.Replace("%", "")));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtIvaRetenidoPorcentaje_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalculaCantidadesAnticipo(Total, rdoTasa16.Checked, ConvierteTextoADecimal(txtIvaRetenidoPorcentaje), ConvierteTextoADecimal(txtIsrRetenidoPorcentaje.Text.Replace("%", "")));
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtFacturaFiltro_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					EntFactura facSeleccionada = ObtieneFacturaFromGV(gvFacturas);
					facSeleccionada.Estatus = true;
					btnAgregar.PerformClick();
				}
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
				if (rdoPueCP.Checked)
				{
					CargaPuePpdNominaNc(ListaFacturas.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtProveedor.Text.ToUpper()) && P.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList(), ConvierteTextoAInteger(rdoPueCP.Tag.ToString()));
				}
				else if (rdoPPD.Checked)
				{
					CargaPuePpdNominaNc(ListaFacturas.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.EmisorNombre.ToUpper().Contains(txtProveedor.Text.ToUpper()) && P.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList(), ConvierteTextoAInteger(rdoPPD.Tag.ToString()));
				}
				else if (rdoNomina.Checked)
				{
					CargaPuePpdNominaNc(ListaFacturasNominas.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtProveedor.Text.ToUpper()) && P.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList(), ConvierteTextoAInteger(rdoNomina.Tag.ToString()));
				}
				else
				{
					CargaPuePpdNominaNc(ListaFacturasNcDevoluciones.Where((EntFactura P) => P.Folio.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper()) && P.UUID.ToUpper().Contains(txtUUIDfiltro.Text.ToUpper()) && P.Nombre.ToUpper().Contains(txtProveedor.Text.ToUpper()) && P.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList(), ConvierteTextoAInteger(rdoNcDevoluciones.Tag.ToString()));
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtUUIDfiltro_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					EntFactura facSeleccionada = ObtieneFacturaFromGV(gvFacturas);
					facSeleccionada.Estatus = true;
					btnAgregar.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnFiltraFacturas_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					EntFactura facSeleccionada = ObtieneFacturaFromGV(gvFacturas);
					facSeleccionada.Estatus = true;
					btnAgregar.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoPueCP_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (((RadioButton)sender).Checked)
				{
					CargaPuePpdNominaNc(ListaFacturas, ConvierteTextoAInteger(rdoPueCP.Tag.ToString()));
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoPPD_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (((RadioButton)sender).Checked)
				{
					CargaPuePpdNominaNc(ListaFacturas, ConvierteTextoAInteger(rdoPPD.Tag.ToString()));
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoNomina_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (((RadioButton)sender).Checked)
				{
					CargaPuePpdNominaNc(ListaFacturasNominas, ConvierteTextoAInteger(rdoNomina.Tag.ToString()));
					lbNombreFiltro.Text = "Nombre Receptor:";
				}
				else
				{
					lbNombreFiltro.Text = "Nombre Emisor:";
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoNcDevoluciones_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (((RadioButton)sender).Checked)
				{
					CargaPuePpdNominaNc(ListaFacturasNcDevoluciones, ConvierteTextoAInteger(rdoNcDevoluciones.Tag.ToString()));
					lbNombreFiltro.Text = "Nombre Receptor:";
				}
				else
				{
					lbNombreFiltro.Text = "Nombre Emisor:";
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtIsrRetenidoPorcentaje_Leave(object sender, EventArgs e)
		{
			TextBoxPorcentaje_Leave(sender, e);
		}

		private void lbIVAretenido_Click(object sender, EventArgs e)
		{
			try
			{
				chkIvaRetenido.Checked = !chkIvaRetenido.Checked;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void lbISRretenido_Click(object sender, EventArgs e)
		{
			try
			{
				chkIsrRetenido.Checked = !chkIsrRetenido.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.SeleccionaRelacionEgresos));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.entEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbTiposRelacion = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pnlAnticipo = new System.Windows.Forms.Panel();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.pnlRetenciones = new System.Windows.Forms.Panel();
			this.chkIsrRetenido = new System.Windows.Forms.CheckBox();
			this.chkIvaRetenido = new System.Windows.Forms.CheckBox();
			this.txtIsrRetenidoPorcentaje = new System.Windows.Forms.TextBox();
			this.txtIvaRetenidoPorcentaje = new System.Windows.Forms.TextBox();
			this.txtISRRetenido = new System.Windows.Forms.TextBox();
			this.lbISRretenido = new System.Windows.Forms.Label();
			this.txtIVARetenido = new System.Windows.Forms.TextBox();
			this.lbIVAretenido = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.txtSubtotal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtIVA = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.rdoTasa0 = new System.Windows.Forms.RadioButton();
			this.rdoTasa16 = new System.Windows.Forms.RadioButton();
			this.pnlFiltro = new System.Windows.Forms.Panel();
			this.label8 = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.lbNombreFiltro = new System.Windows.Forms.Label();
			this.txtProveedor = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtUUIDfiltro = new System.Windows.Forms.TextBox();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtFacturaFiltro = new System.Windows.Forms.TextBox();
			this.pnlFiltroPUEPPD = new System.Windows.Forms.Panel();
			this.rdoNcDevoluciones = new System.Windows.Forms.RadioButton();
			this.rdoNomina = new System.Windows.Forms.RadioButton();
			this.rdoPPD = new System.Windows.Forms.RadioButton();
			this.rdoPueCP = new System.Windows.Forms.RadioButton();
			this.gvFacturas = new System.Windows.Forms.DataGridView();
			this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvRFCreceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvNombreReceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.pnlBotones = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.pnlAnticipo.SuspendLayout();
			this.pnlRetenciones.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.pnlFiltro.SuspendLayout();
			this.pnlFiltroPUEPPD.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvFacturas).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.pnlBotones.SuspendLayout();
			base.SuspendLayout();
			this.entEmpresaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEmpresa);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.Window;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancelar.Image = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.Location = new System.Drawing.Point(671, 2);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 80);
			this.btnCancelar.TabIndex = 91;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.Window;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.Location = new System.Drawing.Point(515, 3);
			this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 80);
			this.btnAgregar.TabIndex = 90;
			this.btnAgregar.Text = "Seleccionar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.panel1);
			this.flowLayoutPanel1.Controls.Add(this.pnlAnticipo);
			this.flowLayoutPanel1.Controls.Add(this.pnlFiltro);
			this.flowLayoutPanel1.Controls.Add(this.pnlFiltroPUEPPD);
			this.flowLayoutPanel1.Controls.Add(this.gvFacturas);
			this.flowLayoutPanel1.Controls.Add(this.pnlBotones);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 14);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1299, 861);
			this.flowLayoutPanel1.TabIndex = 93;
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.cmbTiposRelacion);
			this.panel1.Location = new System.Drawing.Point(3, 2);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1293, 37);
			this.panel1.TabIndex = 95;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 17);
			this.label2.TabIndex = 98;
			this.label2.Text = "Relacionar a:";
			this.cmbTiposRelacion.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbTiposRelacion.DisplayMember = "Descripcion";
			this.cmbTiposRelacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTiposRelacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbTiposRelacion.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbTiposRelacion.FormattingEnabled = true;
			this.cmbTiposRelacion.Location = new System.Drawing.Point(107, 4);
			this.cmbTiposRelacion.Margin = new System.Windows.Forms.Padding(4);
			this.cmbTiposRelacion.Name = "cmbTiposRelacion";
			this.cmbTiposRelacion.Size = new System.Drawing.Size(437, 30);
			this.cmbTiposRelacion.TabIndex = 94;
			this.cmbTiposRelacion.ValueMember = "Id";
			this.cmbTiposRelacion.SelectedIndexChanged += new System.EventHandler(cmbTiposRelacion_SelectedIndexChanged);
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.pnlAnticipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlAnticipo.Controls.Add(this.txtTotal);
			this.pnlAnticipo.Controls.Add(this.label7);
			this.pnlAnticipo.Controls.Add(this.pnlRetenciones);
			this.pnlAnticipo.Controls.Add(this.panel4);
			this.pnlAnticipo.Controls.Add(this.panel3);
			this.pnlAnticipo.Location = new System.Drawing.Point(3, 43);
			this.pnlAnticipo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlAnticipo.Name = "pnlAnticipo";
			this.pnlAnticipo.Size = new System.Drawing.Size(799, 168);
			this.pnlAnticipo.TabIndex = 96;
			this.pnlAnticipo.Visible = false;
			this.txtTotal.Location = new System.Drawing.Point(653, 138);
			this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(91, 22);
			this.txtTotal.TabIndex = 102;
			this.txtTotal.TabStop = false;
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label7.Location = new System.Drawing.Point(606, 142);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 17);
			this.label7.TabIndex = 103;
			this.label7.Text = "Total";
			this.pnlRetenciones.Controls.Add(this.chkIsrRetenido);
			this.pnlRetenciones.Controls.Add(this.chkIvaRetenido);
			this.pnlRetenciones.Controls.Add(this.txtIsrRetenidoPorcentaje);
			this.pnlRetenciones.Controls.Add(this.txtIvaRetenidoPorcentaje);
			this.pnlRetenciones.Controls.Add(this.txtISRRetenido);
			this.pnlRetenciones.Controls.Add(this.lbISRretenido);
			this.pnlRetenciones.Controls.Add(this.txtIVARetenido);
			this.pnlRetenciones.Controls.Add(this.lbIVAretenido);
			this.pnlRetenciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.pnlRetenciones.Location = new System.Drawing.Point(429, 68);
			this.pnlRetenciones.Margin = new System.Windows.Forms.Padding(4);
			this.pnlRetenciones.Name = "pnlRetenciones";
			this.pnlRetenciones.Size = new System.Drawing.Size(319, 62);
			this.pnlRetenciones.TabIndex = 101;
			this.pnlRetenciones.Visible = false;
			this.chkIsrRetenido.AutoSize = true;
			this.chkIsrRetenido.Location = new System.Drawing.Point(25, 37);
			this.chkIsrRetenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkIsrRetenido.Name = "chkIsrRetenido";
			this.chkIsrRetenido.Size = new System.Drawing.Size(18, 17);
			this.chkIsrRetenido.TabIndex = 103;
			this.chkIsrRetenido.UseVisualStyleBackColor = true;
			this.chkIsrRetenido.CheckedChanged += new System.EventHandler(chkIsrRetenido_CheckedChanged);
			this.chkIvaRetenido.AutoSize = true;
			this.chkIvaRetenido.Location = new System.Drawing.Point(25, 7);
			this.chkIvaRetenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.chkIvaRetenido.Name = "chkIvaRetenido";
			this.chkIvaRetenido.Size = new System.Drawing.Size(18, 17);
			this.chkIvaRetenido.TabIndex = 102;
			this.chkIvaRetenido.UseVisualStyleBackColor = true;
			this.chkIvaRetenido.CheckedChanged += new System.EventHandler(chkIvaRetenido_CheckedChanged);
			this.txtIsrRetenidoPorcentaje.Enabled = false;
			this.txtIsrRetenidoPorcentaje.Location = new System.Drawing.Point(121, 34);
			this.txtIsrRetenidoPorcentaje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIsrRetenidoPorcentaje.Name = "txtIsrRetenidoPorcentaje";
			this.txtIsrRetenidoPorcentaje.Size = new System.Drawing.Size(81, 24);
			this.txtIsrRetenidoPorcentaje.TabIndex = 101;
			this.txtIsrRetenidoPorcentaje.TextChanged += new System.EventHandler(txtIvaRetenidoPorcentaje_TextChanged);
			this.txtIsrRetenidoPorcentaje.Leave += new System.EventHandler(txtIsrRetenidoPorcentaje_Leave);
			this.txtIvaRetenidoPorcentaje.Enabled = false;
			this.txtIvaRetenidoPorcentaje.Location = new System.Drawing.Point(121, 5);
			this.txtIvaRetenidoPorcentaje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtIvaRetenidoPorcentaje.Name = "txtIvaRetenidoPorcentaje";
			this.txtIvaRetenidoPorcentaje.Size = new System.Drawing.Size(81, 24);
			this.txtIvaRetenidoPorcentaje.TabIndex = 100;
			this.txtIvaRetenidoPorcentaje.TextChanged += new System.EventHandler(txtIvaRetenidoPorcentaje_TextChanged);
			this.txtISRRetenido.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtISRRetenido.Location = new System.Drawing.Point(224, 34);
			this.txtISRRetenido.Margin = new System.Windows.Forms.Padding(4);
			this.txtISRRetenido.Name = "txtISRRetenido";
			this.txtISRRetenido.ReadOnly = true;
			this.txtISRRetenido.Size = new System.Drawing.Size(91, 24);
			this.txtISRRetenido.TabIndex = 98;
			this.txtISRRetenido.TabStop = false;
			this.lbISRretenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lbISRretenido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbISRretenido.Location = new System.Drawing.Point(51, 34);
			this.lbISRretenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbISRretenido.Name = "lbISRretenido";
			this.lbISRretenido.Size = new System.Drawing.Size(67, 31);
			this.lbISRretenido.TabIndex = 99;
			this.lbISRretenido.Text = "ISR Retenido";
			this.lbISRretenido.Click += new System.EventHandler(lbISRretenido_Click);
			this.txtIVARetenido.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtIVARetenido.Location = new System.Drawing.Point(224, 5);
			this.txtIVARetenido.Margin = new System.Windows.Forms.Padding(4);
			this.txtIVARetenido.Name = "txtIVARetenido";
			this.txtIVARetenido.ReadOnly = true;
			this.txtIVARetenido.Size = new System.Drawing.Size(91, 24);
			this.txtIVARetenido.TabIndex = 96;
			this.txtIVARetenido.TabStop = false;
			this.lbIVAretenido.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lbIVAretenido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lbIVAretenido.Location = new System.Drawing.Point(51, 2);
			this.lbIVAretenido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbIVAretenido.Name = "lbIVAretenido";
			this.lbIVAretenido.Size = new System.Drawing.Size(64, 30);
			this.lbIVAretenido.TabIndex = 97;
			this.lbIVAretenido.Text = "IVA Retenido";
			this.lbIVAretenido.Click += new System.EventHandler(lbIVAretenido_Click);
			this.panel4.Controls.Add(this.txtSubtotal);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Controls.Add(this.txtIVA);
			this.panel4.Location = new System.Drawing.Point(548, 4);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 59);
			this.panel4.TabIndex = 1;
			this.txtSubtotal.Location = new System.Drawing.Point(105, 2);
			this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
			this.txtSubtotal.Name = "txtSubtotal";
			this.txtSubtotal.ReadOnly = true;
			this.txtSubtotal.Size = new System.Drawing.Size(91, 22);
			this.txtSubtotal.TabIndex = 98;
			this.txtSubtotal.TabStop = false;
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(27, 7);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 17);
			this.label3.TabIndex = 99;
			this.label3.Text = "Sub-Total";
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(69, 37);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 17);
			this.label4.TabIndex = 97;
			this.label4.Text = "IVA";
			this.txtIVA.Location = new System.Drawing.Point(105, 34);
			this.txtIVA.Margin = new System.Windows.Forms.Padding(4);
			this.txtIVA.Name = "txtIVA";
			this.txtIVA.ReadOnly = true;
			this.txtIVA.Size = new System.Drawing.Size(91, 22);
			this.txtIVA.TabIndex = 96;
			this.txtIVA.TabStop = false;
			this.panel3.Controls.Add(this.rdoTasa0);
			this.panel3.Controls.Add(this.rdoTasa16);
			this.panel3.Location = new System.Drawing.Point(418, 4);
			this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(127, 59);
			this.panel3.TabIndex = 0;
			this.rdoTasa0.AutoSize = true;
			this.rdoTasa0.Location = new System.Drawing.Point(4, 32);
			this.rdoTasa0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoTasa0.Name = "rdoTasa0";
			this.rdoTasa0.Size = new System.Drawing.Size(120, 21);
			this.rdoTasa0.TabIndex = 1;
			this.rdoTasa0.Text = "Tasa 0/Exenta";
			this.rdoTasa0.UseVisualStyleBackColor = true;
			this.rdoTasa0.CheckedChanged += new System.EventHandler(rdoTasa0_CheckedChanged);
			this.rdoTasa16.AutoSize = true;
			this.rdoTasa16.Location = new System.Drawing.Point(4, 4);
			this.rdoTasa16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rdoTasa16.Name = "rdoTasa16";
			this.rdoTasa16.Size = new System.Drawing.Size(81, 21);
			this.rdoTasa16.TabIndex = 0;
			this.rdoTasa16.Text = "Tasa 16";
			this.rdoTasa16.UseVisualStyleBackColor = true;
			this.rdoTasa16.CheckedChanged += new System.EventHandler(rdoTasa16_CheckedChanged);
			this.pnlFiltro.Controls.Add(this.label8);
			this.pnlFiltro.Controls.Add(this.txtDescripcion);
			this.pnlFiltro.Controls.Add(this.lbNombreFiltro);
			this.pnlFiltro.Controls.Add(this.txtProveedor);
			this.pnlFiltro.Controls.Add(this.label5);
			this.pnlFiltro.Controls.Add(this.txtUUIDfiltro);
			this.pnlFiltro.Controls.Add(this.btnFiltraFacturas);
			this.pnlFiltro.Controls.Add(this.label1);
			this.pnlFiltro.Controls.Add(this.txtFacturaFiltro);
			this.pnlFiltro.Location = new System.Drawing.Point(3, 215);
			this.pnlFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFiltro.Name = "pnlFiltro";
			this.pnlFiltro.Size = new System.Drawing.Size(1287, 46);
			this.pnlFiltro.TabIndex = 1;
			this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(883, 15);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 17);
			this.label8.TabIndex = 139;
			this.label8.Text = "Concepto:";
			this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtDescripcion.Location = new System.Drawing.Point(960, 12);
			this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(264, 22);
			this.txtDescripcion.TabIndex = 138;
			this.txtDescripcion.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.lbNombreFiltro.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lbNombreFiltro.Location = new System.Drawing.Point(589, 10);
			this.lbNombreFiltro.Name = "lbNombreFiltro";
			this.lbNombreFiltro.Size = new System.Drawing.Size(78, 37);
			this.lbNombreFiltro.TabIndex = 137;
			this.lbNombreFiltro.Text = "Nombre Emisor:";
			this.txtProveedor.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtProveedor.Location = new System.Drawing.Point(677, 12);
			this.txtProveedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtProveedor.Name = "txtProveedor";
			this.txtProveedor.Size = new System.Drawing.Size(189, 22);
			this.txtProveedor.TabIndex = 2;
			this.txtProveedor.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(163, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 17);
			this.label5.TabIndex = 133;
			this.label5.Text = "UUID:";
			this.txtUUIDfiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtUUIDfiltro.Location = new System.Drawing.Point(214, 8);
			this.txtUUIDfiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtUUIDfiltro.Name = "txtUUIDfiltro";
			this.txtUUIDfiltro.Size = new System.Drawing.Size(357, 22);
			this.txtUUIDfiltro.TabIndex = 1;
			this.txtUUIDfiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.txtUUIDfiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtUUIDfiltro_KeyPress);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(1231, 0);
			this.btnFiltraFacturas.Margin = new System.Windows.Forms.Padding(4);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(52, 34);
			this.btnFiltraFacturas.TabIndex = 3;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.btnFiltraFacturas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(btnFiltraFacturas_KeyPress);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 17);
			this.label1.TabIndex = 97;
			this.label1.Text = "Folio:";
			this.txtFacturaFiltro.Location = new System.Drawing.Point(47, 7);
			this.txtFacturaFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(100, 22);
			this.txtFacturaFiltro.TabIndex = 0;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.txtFacturaFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFacturaFiltro_KeyPress);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoNcDevoluciones);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoNomina);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoPPD);
			this.pnlFiltroPUEPPD.Controls.Add(this.rdoPueCP);
			this.pnlFiltroPUEPPD.Location = new System.Drawing.Point(3, 265);
			this.pnlFiltroPUEPPD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlFiltroPUEPPD.Name = "pnlFiltroPUEPPD";
			this.pnlFiltroPUEPPD.Size = new System.Drawing.Size(1287, 38);
			this.pnlFiltroPUEPPD.TabIndex = 97;
			this.rdoNcDevoluciones.AutoSize = true;
			this.rdoNcDevoluciones.Location = new System.Drawing.Point(431, 9);
			this.rdoNcDevoluciones.Name = "rdoNcDevoluciones";
			this.rdoNcDevoluciones.Size = new System.Drawing.Size(139, 21);
			this.rdoNcDevoluciones.TabIndex = 3;
			this.rdoNcDevoluciones.Tag = "4";
			this.rdoNcDevoluciones.Text = "Notas de Crédito ";
			this.rdoNcDevoluciones.UseVisualStyleBackColor = true;
			this.rdoNcDevoluciones.CheckedChanged += new System.EventHandler(rdoNcDevoluciones_CheckedChanged);
			this.rdoNomina.AutoSize = true;
			this.rdoNomina.Location = new System.Drawing.Point(283, 9);
			this.rdoNomina.Name = "rdoNomina";
			this.rdoNomina.Size = new System.Drawing.Size(77, 21);
			this.rdoNomina.TabIndex = 2;
			this.rdoNomina.Tag = "3";
			this.rdoNomina.Text = "Nómina";
			this.rdoNomina.UseVisualStyleBackColor = true;
			this.rdoNomina.CheckedChanged += new System.EventHandler(rdoNomina_CheckedChanged);
			this.rdoPPD.AutoSize = true;
			this.rdoPPD.Location = new System.Drawing.Point(153, 9);
			this.rdoPPD.Name = "rdoPPD";
			this.rdoPPD.Size = new System.Drawing.Size(57, 21);
			this.rdoPPD.TabIndex = 1;
			this.rdoPPD.Tag = "2";
			this.rdoPPD.Text = "PPD";
			this.rdoPPD.UseVisualStyleBackColor = true;
			this.rdoPPD.CheckedChanged += new System.EventHandler(rdoPPD_CheckedChanged);
			this.rdoPueCP.AutoSize = true;
			this.rdoPueCP.Checked = true;
			this.rdoPueCP.Location = new System.Drawing.Point(6, 9);
			this.rdoPueCP.Name = "rdoPueCP";
			this.rdoPueCP.Size = new System.Drawing.Size(79, 21);
			this.rdoPueCP.TabIndex = 0;
			this.rdoPueCP.TabStop = true;
			this.rdoPueCP.Tag = "1";
			this.rdoPueCP.Text = "PUE/CP";
			this.rdoPueCP.UseVisualStyleBackColor = true;
			this.rdoPueCP.CheckedChanged += new System.EventHandler(rdoPueCP_CheckedChanged);
			this.gvFacturas.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvFacturas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvFacturas.AutoGenerateColumns = false;
			this.gvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvFacturas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvFacturas.Columns.AddRange(this.Seleccionar, this.dataGridViewTextBoxColumn4, this.UUID, this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.gvRFCreceptor, this.gvNombreReceptor, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.Descripcion);
			this.gvFacturas.DataSource = this.entFacturaBindingSource;
			this.gvFacturas.Location = new System.Drawing.Point(4, 309);
			this.gvFacturas.Margin = new System.Windows.Forms.Padding(4);
			this.gvFacturas.Name = "gvFacturas";
			this.gvFacturas.RowHeadersVisible = false;
			this.gvFacturas.RowHeadersWidth = 51;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
			this.gvFacturas.RowsDefaultCellStyle = dataGridViewCellStyle5;
			this.gvFacturas.RowTemplate.Height = 30;
			this.gvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvFacturas.Size = new System.Drawing.Size(1291, 456);
			this.gvFacturas.TabIndex = 93;
			this.gvFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvFacturas_CellClick);
			this.gvFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvFacturas_CellDoubleClick);
			this.Seleccionar.DataPropertyName = "Estatus";
			this.Seleccionar.FillWeight = 80f;
			this.Seleccionar.HeaderText = "Sel.";
			this.Seleccionar.MinimumWidth = 6;
			this.Seleccionar.Name = "Seleccionar";
			this.dataGridViewTextBoxColumn4.DataPropertyName = "Folio";
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle6;
			this.dataGridViewTextBoxColumn4.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.UUID.DataPropertyName = "UUID";
			this.UUID.FillWeight = 400f;
			this.UUID.HeaderText = "UUID";
			this.UUID.MinimumWidth = 6;
			this.UUID.Name = "UUID";
			this.UUID.ReadOnly = true;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Fecha";
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle7;
			this.dataGridViewTextBoxColumn1.FillWeight = 150f;
			this.dataGridViewTextBoxColumn1.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Total";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle8.Format = "c4";
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewTextBoxColumn2.FillWeight = 150f;
			this.dataGridViewTextBoxColumn2.HeaderText = "Total";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "EmisorRFC";
			this.dataGridViewTextBoxColumn5.FillWeight = 150f;
			this.dataGridViewTextBoxColumn5.HeaderText = "RFC Emisor";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn6.FillWeight = 250f;
			this.dataGridViewTextBoxColumn6.HeaderText = "Nombre Emisor";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn6.ReadOnly = true;
			this.gvRFCreceptor.DataPropertyName = "RFC";
			this.gvRFCreceptor.FillWeight = 150f;
			this.gvRFCreceptor.HeaderText = "RFC Receptor";
			this.gvRFCreceptor.MinimumWidth = 6;
			this.gvRFCreceptor.Name = "gvRFCreceptor";
			this.gvRFCreceptor.ReadOnly = true;
			this.gvNombreReceptor.DataPropertyName = "Nombre";
			this.gvNombreReceptor.FillWeight = 250f;
			this.gvNombreReceptor.HeaderText = "Nombre Receptor";
			this.gvNombreReceptor.MinimumWidth = 6;
			this.gvNombreReceptor.Name = "gvNombreReceptor";
			this.gvNombreReceptor.ReadOnly = true;
			this.dataGridViewTextBoxColumn7.DataPropertyName = "MetodoPago";
			this.dataGridViewTextBoxColumn7.FillWeight = 80f;
			this.dataGridViewTextBoxColumn7.HeaderText = "MetodoPago";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn8.FillWeight = 120f;
			this.dataGridViewTextBoxColumn8.HeaderText = "FormaPago";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.Descripcion.DataPropertyName = "Descripcion";
			this.Descripcion.FillWeight = 300f;
			this.Descripcion.HeaderText = "Concepto";
			this.Descripcion.MinimumWidth = 6;
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.pnlBotones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pnlBotones.Controls.Add(this.btnAgregar);
			this.pnlBotones.Controls.Add(this.btnCancelar);
			this.pnlBotones.Location = new System.Drawing.Point(3, 771);
			this.pnlBotones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlBotones.Name = "pnlBotones";
			this.pnlBotones.Size = new System.Drawing.Size(1293, 86);
			this.pnlBotones.TabIndex = 94;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1323, 886);
			base.Controls.Add(this.flowLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "SeleccionaRelacionEgresos";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Selecciona";
			base.Load += new System.EventHandler(SeleccionEmpresa_Load);
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.pnlAnticipo.ResumeLayout(false);
			this.pnlAnticipo.PerformLayout();
			this.pnlRetenciones.ResumeLayout(false);
			this.pnlRetenciones.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.pnlFiltro.ResumeLayout(false);
			this.pnlFiltro.PerformLayout();
			this.pnlFiltroPUEPPD.ResumeLayout(false);
			this.pnlFiltroPUEPPD.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvFacturas).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.pnlBotones.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
