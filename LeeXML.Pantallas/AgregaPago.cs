using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;

namespace LeeXML.Pantallas
{
	public class AgregaPago : FormBase
	{
		private IContainer components = null;

		private TextBox txtCantidadPaga;

		private Label label1;

		private Button btnCancelar;

		private Button btnAgregar;

		private Label label2;

		private TextBox txtFactura;

		private TextBox txtTotal;

		private Label label3;

		private TextBox txtDeuda;

		private Label label4;

		private GroupBox gbFormaFechaPago;

		private ComboBox cmbFormaPago;

		private DateTimePicker dtpFechaPago;

		private TextBox txtFormaPago;

		private TextBox txtTipoCambio;

		private Label label27;

		private ComboBox cmbMoneda;

		private TextBox txtMoneda;

		private GroupBox gbMoneda;

		private TextBox txtPagado;

		private Label label5;

		public decimal TotalDeposito { get; set; }

		public string CantidadPago => txtCantidadPaga.Text;

		public decimal CantidadPagoDecimal => ConvierteTextoADecimal(txtCantidadPaga);

		public DateTime FechaPago => dtpFechaPago.Value;

		public string FormaPago => cmbFormaPago.Text.Remove(0, 4);

		public int FormaPagoId => ConvierteTextoAInteger(cmbFormaPago.Text.Remove(2));

		public int TipoMonedaId => cmbMoneda.SelectedIndex + 1;

		public decimal TipoCambio => ConvierteTextoADecimal(txtTipoCambio);

		public AgregaPago()
		{
			InitializeComponent();
		}

		public AgregaPago(EntFactura PedidoFactura, decimal TotalDeposito, bool MuestraFormaFechaPago)
		{
			InitializeComponent();
			this.TotalDeposito = TotalDeposito;
			CargaDatosFactura(PedidoFactura, TotalDeposito);
			gbFormaFechaPago.Visible = MuestraFormaFechaPago;
		}

		private void CargaDatosFactura(EntFactura PedidoFactura, decimal TotalDeposito)
		{
			txtFactura.Text = PedidoFactura.Folio;
			txtTotal.Text = FormatoMoney(PedidoFactura.Total);
			txtPagado.Text = FormatoMoney(PedidoFactura.Pago);
			txtDeuda.Text = FormatoMoney(PedidoFactura.Total - PedidoFactura.Pago);
			if (TotalDeposito > PedidoFactura.Total)
			{
				txtCantidadPaga.Text = FormatoMoney(PedidoFactura.Total);
			}
			else
			{
				txtCantidadPaga.Text = FormatoMoney(TotalDeposito);
			}
			dtpFechaPago.MinDate = PedidoFactura.Fecha;
		}

		private void AgregaPago_Load(object sender, EventArgs e)
		{
			cmbFormaPago.SelectedIndex = 0;
			cmbMoneda.SelectedIndex = 0;
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			try
			{
				if (ConvierteTextoADecimal(txtCantidadPaga) > TotalDeposito)
				{
					base.DialogResult = DialogResult.Abort;
					MuestraMensaje("La cantidad no puede ser mayor al Depósito/Retiro");
					txtCantidadPaga.Focus();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
		}

		private void txtCantidadPaga_Leave(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtCantidadPaga_KeyPress(object sender, KeyPressEventArgs e)
		{
			try
			{
				if (e.KeyChar == '\r')
				{
					btnAgregar.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void AgregaPago_FormClosing(object sender, FormClosingEventArgs e)
		{
			bool cierra = true;
			if (base.DialogResult == DialogResult.OK)
			{
				if (CantidadPagoDecimal <= 0m)
				{
					MuestraMensaje("La cantidad a Pagar debe ser mayor a 0.");
					cierra = false;
				}
				else if (CantidadPagoDecimal > ConvierteTextoADecimal(txtDeuda))
				{
					MuestraMensaje("La cantidad a Pagar debe ser menor o igual a la cantidad que se Debe de la factura.");
					cierra = false;
				}
				e.Cancel = !cierra;
			}
		}

		private void cmbMoneda_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (cmbMoneda.SelectedIndex == 0)
				{
					txtTipoCambio.Text = "1.00";
					txtTipoCambio.Enabled = false;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void dtpFechaPago_ValueChanged(object sender, EventArgs e)
		{
		}

		private void txtCantidadPaga_TextChanged(object sender, EventArgs e)
		{
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
			this.gbMoneda = new System.Windows.Forms.GroupBox();
			this.cmbMoneda = new System.Windows.Forms.ComboBox();
			this.label27 = new System.Windows.Forms.Label();
			this.txtTipoCambio = new System.Windows.Forms.TextBox();
			this.txtMoneda = new System.Windows.Forms.TextBox();
			this.gbFormaFechaPago = new System.Windows.Forms.GroupBox();
			this.cmbFormaPago = new System.Windows.Forms.ComboBox();
			this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
			this.txtFormaPago = new System.Windows.Forms.TextBox();
			this.txtDeuda = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFactura = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCantidadPaga = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.txtPagado = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.gbMoneda.SuspendLayout();
			this.gbFormaFechaPago.SuspendLayout();
			base.SuspendLayout();
			this.gbMoneda.Controls.Add(this.cmbMoneda);
			this.gbMoneda.Controls.Add(this.label27);
			this.gbMoneda.Controls.Add(this.txtTipoCambio);
			this.gbMoneda.Controls.Add(this.txtMoneda);
			this.gbMoneda.Location = new System.Drawing.Point(260, 135);
			this.gbMoneda.Name = "gbMoneda";
			this.gbMoneda.Size = new System.Drawing.Size(105, 98);
			this.gbMoneda.TabIndex = 171;
			this.gbMoneda.TabStop = false;
			this.gbMoneda.Text = "Moneda ";
			this.gbMoneda.Visible = false;
			this.cmbMoneda.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMoneda.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMoneda.FormattingEnabled = true;
			this.cmbMoneda.Items.AddRange(new object[2] { "MXN - Moneda Nacional", "USD - Dolar" });
			this.cmbMoneda.Location = new System.Drawing.Point(6, 19);
			this.cmbMoneda.Name = "cmbMoneda";
			this.cmbMoneda.Size = new System.Drawing.Size(68, 26);
			this.cmbMoneda.TabIndex = 166;
			this.cmbMoneda.SelectedIndexChanged += new System.EventHandler(cmbMoneda_SelectedIndexChanged);
			this.label27.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.label27.AutoSize = true;
			this.label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label27.Location = new System.Drawing.Point(4, 45);
			this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(85, 18);
			this.label27.TabIndex = 169;
			this.label27.Text = "Tipo Cambio";
			this.txtTipoCambio.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.txtTipoCambio.Enabled = false;
			this.txtTipoCambio.Location = new System.Drawing.Point(5, 63);
			this.txtTipoCambio.Margin = new System.Windows.Forms.Padding(4);
			this.txtTipoCambio.Name = "txtTipoCambio";
			this.txtTipoCambio.Size = new System.Drawing.Size(91, 25);
			this.txtTipoCambio.TabIndex = 170;
			this.txtMoneda.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtMoneda.Location = new System.Drawing.Point(6, 19);
			this.txtMoneda.Name = "txtMoneda";
			this.txtMoneda.Size = new System.Drawing.Size(68, 26);
			this.txtMoneda.TabIndex = 168;
			this.txtMoneda.TabStop = false;
			this.gbFormaFechaPago.Controls.Add(this.cmbFormaPago);
			this.gbFormaFechaPago.Controls.Add(this.dtpFechaPago);
			this.gbFormaFechaPago.Controls.Add(this.txtFormaPago);
			this.gbFormaFechaPago.Location = new System.Drawing.Point(31, 135);
			this.gbFormaFechaPago.Name = "gbFormaFechaPago";
			this.gbFormaFechaPago.Size = new System.Drawing.Size(98, 98);
			this.gbFormaFechaPago.TabIndex = 165;
			this.gbFormaFechaPago.TabStop = false;
			this.gbFormaFechaPago.Text = "Forma y Fecha de Pago";
			this.gbFormaFechaPago.Visible = false;
			this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFormaPago.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbFormaPago.FormattingEnabled = true;
			this.cmbFormaPago.Items.AddRange(new object[5] { "01 - Efectivo", "02 - Cheque nominativo", "03 - Transferencia electrónica de fondos", "04 - Tarjeta de crédito", "28 - Tarjeta de débito" });
			this.cmbFormaPago.Location = new System.Drawing.Point(6, 19);
			this.cmbFormaPago.Name = "cmbFormaPago";
			this.cmbFormaPago.Size = new System.Drawing.Size(212, 26);
			this.cmbFormaPago.TabIndex = 163;
			this.dtpFechaPago.CustomFormat = "ddd dd.MM.yyyy";
			this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFechaPago.Location = new System.Drawing.Point(7, 64);
			this.dtpFechaPago.Name = "dtpFechaPago";
			this.dtpFechaPago.Size = new System.Drawing.Size(134, 25);
			this.dtpFechaPago.TabIndex = 161;
			this.dtpFechaPago.ValueChanged += new System.EventHandler(dtpFechaPago_ValueChanged);
			this.txtFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFormaPago.Location = new System.Drawing.Point(6, 19);
			this.txtFormaPago.Name = "txtFormaPago";
			this.txtFormaPago.Size = new System.Drawing.Size(195, 26);
			this.txtFormaPago.TabIndex = 162;
			this.txtDeuda.Location = new System.Drawing.Point(260, 99);
			this.txtDeuda.Name = "txtDeuda";
			this.txtDeuda.ReadOnly = true;
			this.txtDeuda.Size = new System.Drawing.Size(82, 25);
			this.txtDeuda.TabIndex = 87;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(209, 102);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 18);
			this.label4.TabIndex = 86;
			this.label4.Text = "Deuda:";
			this.txtTotal.Location = new System.Drawing.Point(88, 59);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(82, 25);
			this.txtTotal.TabIndex = 85;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(49, 62);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 18);
			this.label3.TabIndex = 84;
			this.label3.Text = "Total:";
			this.txtFactura.Location = new System.Drawing.Point(88, 22);
			this.txtFactura.Name = "txtFactura";
			this.txtFactura.ReadOnly = true;
			this.txtFactura.Size = new System.Drawing.Size(121, 25);
			this.txtFactura.TabIndex = 83;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 25);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 18);
			this.label2.TabIndex = 82;
			this.label2.Text = "Factura(s):";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cantidad: ";
			this.txtCantidadPaga.Location = new System.Drawing.Point(88, 99);
			this.txtCantidadPaga.Name = "txtCantidadPaga";
			this.txtCantidadPaga.Size = new System.Drawing.Size(100, 25);
			this.txtCantidadPaga.TabIndex = 0;
			this.txtCantidadPaga.TextChanged += new System.EventHandler(txtCantidadPaga_TextChanged);
			this.txtCantidadPaga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCantidadPaga_KeyPress);
			this.txtCantidadPaga.Leave += new System.EventHandler(txtCantidadPaga_Leave);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancelar.BackgroundImage = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold);
			this.btnCancelar.Location = new System.Drawing.Point(213, 135);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(120, 65);
			this.btnCancelar.TabIndex = 11;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold);
			this.btnAgregar.Location = new System.Drawing.Point(85, 135);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(120, 65);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.txtPagado.Location = new System.Drawing.Point(260, 59);
			this.txtPagado.Name = "txtPagado";
			this.txtPagado.ReadOnly = true;
			this.txtPagado.Size = new System.Drawing.Size(82, 25);
			this.txtPagado.TabIndex = 173;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(203, 62);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 18);
			this.label5.TabIndex = 172;
			this.label5.Text = "Pagado:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(375, 213);
			base.Controls.Add(this.btnCancelar);
			base.Controls.Add(this.btnAgregar);
			base.Controls.Add(this.txtPagado);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.gbMoneda);
			base.Controls.Add(this.gbFormaFechaPago);
			base.Controls.Add(this.txtDeuda);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.txtTotal);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.txtFactura);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.txtCantidadPaga);
			base.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "AgregaPago";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agregar Pago";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(AgregaPago_FormClosing);
			base.Load += new System.EventHandler(AgregaPago_Load);
			this.gbMoneda.ResumeLayout(false);
			this.gbMoneda.PerformLayout();
			this.gbFormaFechaPago.ResumeLayout(false);
			this.gbFormaFechaPago.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
