using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;

namespace LeeXML.Pantallas
{
	public class AgregaRetiro : FormBase
	{
		private IContainer components = null;

		private Button btnCancelar;

		private Button btnAgregar;

		private FlowLayoutPanel flowLayoutPanel1;

		private Panel pnlBotones;

		private Panel pnlDeposito;

		private Panel panel4;

		private Label label3;

		private Label label4;

		private TextBox txtMontoDeposito;

		private Button btnAgregaDeposito;

		private DataGridViewImageColumn dataGridViewImageColumn1;

		private DataGridViewImageColumn dataGridViewImageColumn2;

		private DataGridViewImageColumn dataGridViewImageColumn3;

		private DateTimePicker dtpFechaPago;

		private DataGridView gvXMLs;

		private DataGridView dataGridView2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private DataGridViewImageColumn dataGridViewImageColumn6;

		private BindingSource entEstadoDeCuentaBindingSource1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewImageColumn dataGridViewImageColumn5;

		public List<EntEstadoDeCuenta> ListaDepositosFromGV => ObtieneListaEstadoDeCuentaFromGV(gvXMLs);

		public List<EntEstadoDeCuenta> ListaDepositos { get; set; }

		public AgregaRetiro(DateTime FechaInicioPeriodo)
		{
			InitializeComponent();
			dtpFechaPago.Value = FechaInicioPeriodo;
			dtpFechaPago.MinDate = FechaInicioPeriodo;
			dtpFechaPago.MaxDate = ObtieneFechaUltimoDiaMes(FechaInicioPeriodo);
		}

		private void SeleccionEmpresa_Load(object sender, EventArgs e)
		{
			try
			{
				ListaDepositos = new List<EntEstadoDeCuenta>();
				gvXMLs.DataSource = new List<EntEstadoDeCuenta>();
				gvXMLs.Refresh();
				dtpFechaPago.Focus();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
		}

		private void btnAgregaDeposito_Click(object sender, EventArgs e)
		{
			try
			{
				bool agregaDeposito = true;
				EntEstadoDeCuenta deposito = new EntEstadoDeCuenta
				{
					Total = ConvierteTextoADecimal(txtMontoDeposito),
					Fecha = dtpFechaPago.Value.Date,
					EmpresaId = base.EmpresaSeleccionada.Id,
					UsuarioId = Program.UsuarioSeleccionado.Id,
					TipoComprobanteId = 1,
					UUID = "",
					SerieFactura = "",
					NumeroFactura = "",
					RFC = "",
					Nombre = "",
					MetodoPago = "",
					FormaPago = "",
					Descripcion = "",
					TipoRelacionId = 1,
					ListaComprobantes = new List<EntFactura>()
				};
				SeleccionaRelacionEgresos vSelFac = new SeleccionaRelacionEgresos(deposito, deposito.TipoComprobanteId);
				if (vSelFac.ShowDialog() == DialogResult.OK)
				{
					decimal totalDeposito = deposito.Total;
					deposito.TipoComprobanteId = vSelFac.TipoMovimientoSeleccionado.Id;
					if (deposito.TipoComprobanteId == 1 || deposito.TipoComprobanteId == 16 || deposito.TipoComprobanteId == 17)
					{
						deposito.ListaComprobantes = vSelFac.FacturasSeleccionadas;
						foreach (EntFactura f in deposito.ListaComprobantes)
						{
							AgregaPago vPag = new AgregaPago(f, totalDeposito, false);
							if (vPag.ShowDialog() == DialogResult.OK)
							{
								f.Pago = vPag.CantidadPagoDecimal;
								totalDeposito -= vPag.CantidadPagoDecimal;
								deposito.EmisorNombre = f.EmisorNombre;
								deposito.EmisorRFC = f.EmisorRFC;
								deposito.UUID = deposito.UUID + f.UUID + " | ";
								deposito.NumeroFactura = deposito.NumeroFactura + f.SerieFactura + f.NumeroFactura + " | ";
								deposito.Nombre = deposito.Nombre + f.Nombre + " | ";
								deposito.Estatus = true;
							}
							else
							{
								deposito.ListaComprobantes = new List<EntFactura>();
								deposito.EmisorNombre = "";
								deposito.EmisorRFC = "";
								deposito.UUID = "";
								deposito.NumeroFactura = "";
								deposito.Nombre = "";
								deposito.Estatus = false;
								agregaDeposito = false;
							}
						}
						if (totalDeposito > 0m)
						{
							MuestraMensajeAdvertencia("NO SE RELACIONÓ EL MONTO TOTAL DEL RETIRO. SE DEBERÁ RELACIONAR EL RESTO DEL RETIRO.", "MONTO RETIRO INCOMPLETO");
							SeleccionaRelacionEgresos vSelAnt = new SeleccionaRelacionEgresos(deposito, true, totalDeposito);
							if (vSelAnt.ShowDialog() == DialogResult.OK)
							{
								deposito.NumeroFactura = deposito.NumeroFactura + " | " + vSelAnt.TipoMovimientoSeleccionado.Descripcion;
								deposito.UUID = deposito.UUID + " | " + vSelAnt.TipoMovimientoSeleccionado.Descripcion;
								deposito.ListaComprobantes.Add(vSelAnt.FacturaAnticipo);
							}
							else
							{
								MuestraMensajeError("NO SE RELACIONÓ EL MONTO TOTAL DEL RETIRO", "MONTO RETIRO INCOMPLETO");
								deposito.ListaComprobantes = new List<EntFactura>();
								deposito.UUID = "";
								deposito.NumeroFactura = "";
								deposito.Nombre = "";
								agregaDeposito = false;
							}
						}
					}
					else if (deposito.TipoComprobanteId == 15)
					{
						deposito.UUID = vSelFac.TipoMovimientoSeleccionado.Descripcion;
						deposito.ListaComprobantes.Add(vSelFac.FacturaAnticipo);
						deposito.Estatus = true;
					}
					else
					{
						deposito.Id = 0;
						deposito.UUID = vSelFac.TipoMovimientoSeleccionado.Descripcion;
						deposito.SerieFactura = "";
						deposito.NumeroFactura = "";
						deposito.RFC = "";
						deposito.Nombre = "";
						deposito.MetodoPago = "";
						deposito.FormaPago = "";
						deposito.Estatus = true;
					}
				}
				else
				{
					agregaDeposito = false;
				}
				if (agregaDeposito)
				{
					List<EntEstadoDeCuenta> lst = ListaDepositos;
					lst.Add(deposito);
					gvXMLs.DataSource = null;
					gvXMLs.DataSource = lst;
					gvXMLs.Refresh();
					txtMontoDeposito.Clear();
					txtMontoDeposito.Focus();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtMontoDeposito_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					if (string.IsNullOrWhiteSpace(txtMontoDeposito.Text))
					{
						btnAgregar.PerformClick();
					}
					else
					{
						btnAgregaDeposito.PerformClick();
					}
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvXMLs_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == gvXMLs.Columns.Count - 1)
				{
					EntEstadoDeCuenta estadoDeCuenta = ObtieneEstadoDeCuentaFromGV(gvXMLs);
					ListaDepositos.Remove(estadoDeCuenta);
					gvXMLs.DataSource = null;
					gvXMLs.DataSource = ListaDepositos;
					gvXMLs.Refresh();
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlDeposito = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
			this.btnAgregaDeposito = new System.Windows.Forms.Button();
			this.txtMontoDeposito = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn5 = new System.Windows.Forms.DataGridViewImageColumn();
			this.entEstadoDeCuentaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.pnlBotones = new System.Windows.Forms.Panel();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewImageColumn6 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
			this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
			this.flowLayoutPanel1.SuspendLayout();
			this.pnlDeposito.SuspendLayout();
			this.panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entEstadoDeCuentaBindingSource1).BeginInit();
			this.pnlBotones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.dataGridView2).BeginInit();
			base.SuspendLayout();
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.pnlDeposito);
			this.flowLayoutPanel1.Controls.Add(this.gvXMLs);
			this.flowLayoutPanel1.Controls.Add(this.pnlBotones);
			this.flowLayoutPanel1.Controls.Add(this.dataGridView2);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 14);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(1268, 542);
			this.flowLayoutPanel1.TabIndex = 0;
			this.pnlDeposito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlDeposito.Controls.Add(this.panel4);
			this.pnlDeposito.Location = new System.Drawing.Point(3, 2);
			this.pnlDeposito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlDeposito.Name = "pnlDeposito";
			this.pnlDeposito.Size = new System.Drawing.Size(1261, 73);
			this.pnlDeposito.TabIndex = 0;
			this.panel4.Controls.Add(this.dtpFechaPago);
			this.panel4.Controls.Add(this.btnAgregaDeposito);
			this.panel4.Controls.Add(this.txtMontoDeposito);
			this.panel4.Controls.Add(this.label3);
			this.panel4.Controls.Add(this.label4);
			this.panel4.Location = new System.Drawing.Point(3, 4);
			this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(388, 64);
			this.panel4.TabIndex = 0;
			this.dtpFechaPago.CustomFormat = "dd.MM.yyyy";
			this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFechaPago.Location = new System.Drawing.Point(13, 26);
			this.dtpFechaPago.Margin = new System.Windows.Forms.Padding(4);
			this.dtpFechaPago.Name = "dtpFechaPago";
			this.dtpFechaPago.Size = new System.Drawing.Size(177, 22);
			this.dtpFechaPago.TabIndex = 0;
			this.btnAgregaDeposito.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAgregaDeposito.BackColor = System.Drawing.Color.White;
			this.btnAgregaDeposito.BackgroundImage = LeeXML.Properties.Resources.Plus;
			this.btnAgregaDeposito.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregaDeposito.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregaDeposito.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregaDeposito.Location = new System.Drawing.Point(325, 11);
			this.btnAgregaDeposito.Margin = new System.Windows.Forms.Padding(4);
			this.btnAgregaDeposito.Name = "btnAgregaDeposito";
			this.btnAgregaDeposito.Size = new System.Drawing.Size(53, 44);
			this.btnAgregaDeposito.TabIndex = 2;
			this.btnAgregaDeposito.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregaDeposito.UseVisualStyleBackColor = false;
			this.btnAgregaDeposito.Click += new System.EventHandler(btnAgregaDeposito_Click);
			this.txtMontoDeposito.Location = new System.Drawing.Point(208, 26);
			this.txtMontoDeposito.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtMontoDeposito.Name = "txtMontoDeposito";
			this.txtMontoDeposito.Size = new System.Drawing.Size(100, 22);
			this.txtMontoDeposito.TabIndex = 1;
			this.txtMontoDeposito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtMontoDeposito_KeyPress);
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label3.Location = new System.Drawing.Point(9, 6);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 17);
			this.label3.TabIndex = 99;
			this.label3.Text = "Fecha";
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label4.Location = new System.Drawing.Point(205, 6);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 17);
			this.label4.TabIndex = 97;
			this.label4.Text = "Monto";
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
			this.gvXMLs.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewImageColumn5);
			this.gvXMLs.DataSource = this.entEstadoDeCuentaBindingSource1;
			this.gvXMLs.Location = new System.Drawing.Point(4, 81);
			this.gvXMLs.Margin = new System.Windows.Forms.Padding(4);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle6;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(1259, 364);
			this.gvXMLs.TabIndex = 98;
			this.gvXMLs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellContentClick);
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
			this.dataGridViewTextBoxColumn2.HeaderText = "Monto";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "Folio";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn3.FillWeight = 150f;
			this.dataGridViewTextBoxColumn3.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.dataGridViewTextBoxColumn4.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn4.FillWeight = 350f;
			this.dataGridViewTextBoxColumn4.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
			this.dataGridViewTextBoxColumn4.ReadOnly = true;
			this.dataGridViewTextBoxColumn5.DataPropertyName = "EmisorNombre";
			this.dataGridViewTextBoxColumn5.FillWeight = 300f;
			this.dataGridViewTextBoxColumn5.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "Descripcion";
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn6.FillWeight = 400f;
			this.dataGridViewTextBoxColumn6.HeaderText = "Observación";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewImageColumn5.HeaderText = "Elim.";
			this.dataGridViewImageColumn5.Image = LeeXML.Properties.Resources.X;
			this.dataGridViewImageColumn5.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn5.MinimumWidth = 6;
			this.dataGridViewImageColumn5.Name = "dataGridViewImageColumn5";
			this.entEstadoDeCuentaBindingSource1.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.pnlBotones.Controls.Add(this.btnAgregar);
			this.pnlBotones.Controls.Add(this.btnCancelar);
			this.pnlBotones.Location = new System.Drawing.Point(3, 451);
			this.pnlBotones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pnlBotones.Name = "pnlBotones";
			this.pnlBotones.Size = new System.Drawing.Size(1261, 86);
			this.pnlBotones.TabIndex = 0;
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.Window;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.Location = new System.Drawing.Point(488, 2);
			this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 79);
			this.btnAgregar.TabIndex = 3;
			this.btnAgregar.Text = "Seleccionar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.Window;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancelar.Image = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.Location = new System.Drawing.Point(656, 2);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 79);
			this.btnCancelar.TabIndex = 4;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.dataGridView2.AllowUserToAddRows = false;
			dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn12, this.dataGridViewImageColumn6);
			this.dataGridView2.Location = new System.Drawing.Point(1271, 4);
			this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowHeadersVisible = false;
			this.dataGridView2.RowHeadersWidth = 51;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
			this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridView2.RowTemplate.Height = 30;
			this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView2.Size = new System.Drawing.Size(0, 364);
			this.dataGridView2.TabIndex = 99;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn10.FillWeight = 350f;
			this.dataGridViewTextBoxColumn10.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Descripcion";
			dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewTextBoxColumn12.FillWeight = 400f;
			this.dataGridViewTextBoxColumn12.HeaderText = "Observación";
			this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewImageColumn6.HeaderText = "Elim.";
			this.dataGridViewImageColumn6.Image = LeeXML.Properties.Resources.X;
			this.dataGridViewImageColumn6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn6.MinimumWidth = 6;
			this.dataGridViewImageColumn6.Name = "dataGridViewImageColumn6";
			this.dataGridViewImageColumn1.HeaderText = "Relación";
			this.dataGridViewImageColumn1.Image = LeeXML.Properties.Resources.Search;
			this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn1.MinimumWidth = 6;
			this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
			this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.dataGridViewImageColumn1.Width = 73;
			this.dataGridViewImageColumn2.FillWeight = 50f;
			this.dataGridViewImageColumn2.HeaderText = "";
			this.dataGridViewImageColumn2.Image = LeeXML.Properties.Resources.Cancelar;
			this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn2.MinimumWidth = 6;
			this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
			this.dataGridViewImageColumn2.Width = 37;
			this.dataGridViewImageColumn3.HeaderText = "Elim.";
			this.dataGridViewImageColumn3.Image = LeeXML.Properties.Resources.X;
			this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.dataGridViewImageColumn3.MinimumWidth = 6;
			this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
			this.dataGridViewImageColumn3.Width = 73;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1292, 569);
			base.Controls.Add(this.flowLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "AgregaRetiro";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Agregar Retiro";
			base.Load += new System.EventHandler(SeleccionEmpresa_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.pnlDeposito.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entEstadoDeCuentaBindingSource1).EndInit();
			this.pnlBotones.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.dataGridView2).EndInit();
			base.ResumeLayout(false);
		}
	}
}
