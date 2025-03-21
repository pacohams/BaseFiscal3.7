using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;

namespace LeeXML.Pantallas
{
	public class AgregaImporteDeclarado : FormBase
	{
		private IContainer components = null;

		private TextBox txtImporte;

		private Label lbImporte;

		private Button btnCancelar;

		private Button btnAgregar;

		private TextBox txtIVA;

		private Label label4;

		private FlowLayoutPanel flowLayoutPanel1;

		public decimal ImporteDecimal => ConvierteTextoADecimal(txtImporte);

		public decimal IVADecimal => ConvierteTextoADecimal(txtIVA);

		public AgregaImporteDeclarado()
		{
			InitializeComponent();
		}

		public AgregaImporteDeclarado(bool SoloIva)
		{
			InitializeComponent();
			lbImporte.Visible = !SoloIva;
			txtImporte.Visible = !SoloIva;
		}

		private void AgregaPago_Load(object sender, EventArgs e)
		{
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			try
			{
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
				e.Cancel = !cierra;
			}
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
			this.txtIVA = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.lbImporte = new System.Windows.Forms.Label();
			this.txtImporte = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.txtIVA.Location = new System.Drawing.Point(227, 3);
			this.txtIVA.Name = "txtIVA";
			this.txtIVA.Size = new System.Drawing.Size(82, 25);
			this.txtIVA.TabIndex = 1;
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(179, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 18);
			this.label4.TabIndex = 86;
			this.label4.Text = "I.V.A.:";
			this.lbImporte.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lbImporte.AutoSize = true;
			this.lbImporte.Location = new System.Drawing.Point(3, 6);
			this.lbImporte.Name = "lbImporte";
			this.lbImporte.Size = new System.Drawing.Size(64, 18);
			this.lbImporte.TabIndex = 1;
			this.lbImporte.Text = "Importe: ";
			this.txtImporte.Location = new System.Drawing.Point(73, 3);
			this.txtImporte.Name = "txtImporte";
			this.txtImporte.Size = new System.Drawing.Size(100, 25);
			this.txtImporte.TabIndex = 0;
			this.txtImporte.TextChanged += new System.EventHandler(txtCantidadPaga_TextChanged);
			this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCantidadPaga_KeyPress);
			this.txtImporte.Leave += new System.EventHandler(txtCantidadPaga_Leave);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.btnCancelar.BackgroundImage = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 6.25f, System.Drawing.FontStyle.Bold);
			this.btnCancelar.Location = new System.Drawing.Point(209, 114);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(78, 70);
			this.btnCancelar.TabIndex = 3;
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
			this.btnAgregar.Location = new System.Drawing.Point(98, 114);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(78, 70);
			this.btnAgregar.TabIndex = 2;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.flowLayoutPanel1.Controls.Add(this.lbImporte);
			this.flowLayoutPanel1.Controls.Add(this.txtImporte);
			this.flowLayoutPanel1.Controls.Add(this.label4);
			this.flowLayoutPanel1.Controls.Add(this.txtIVA);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(17, 54);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(346, 37);
			this.flowLayoutPanel1.TabIndex = 87;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 18f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(375, 192);
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.btnCancelar);
			base.Controls.Add(this.btnAgregar);
			this.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Name = "AgregaImporteDeclarado";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Agregar Importe Declarado";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(AgregaPago_FormClosing);
			base.Load += new System.EventHandler(AgregaPago_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
