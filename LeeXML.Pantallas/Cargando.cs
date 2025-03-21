using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;

namespace LeeXML.Pantallas
{
	public class Cargando : FormBase
	{
		private int contador = 0;

		private int total = 0;

		private IContainer components = null;

		private Panel pnlProgressBar;

		private PictureBox pictureBox1;

		private Label lbImportacion;

		private ProgressBar progressBar1;

		private Label label1;

		private Timer timer1;

		private Label lbContador;

		private Timer timer2;

		private Button button1;

		public string LabelContador
		{
			set
			{
				lbContador.Text = value;
			}
		}

		public Cargando(int TotalArchivos)
		{
			InitializeComponent();
			total = TotalArchivos;
		}

		public Cargando()
		{
			InitializeComponent();
			lbContador.Visible = false;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (lbImportacion.Text == "Importando CFDI'S...")
			{
				lbImportacion.Text = "Importando CFDI'S";
			}
			else if (lbImportacion.Text == "Importando CFDI'S")
			{
				lbImportacion.Text = "Importando CFDI'S.";
			}
			else if (lbImportacion.Text == "Importando CFDI'S.")
			{
				lbImportacion.Text = "Importando CFDI'S..";
			}
			else if (lbImportacion.Text == "Importando CFDI'S..")
			{
				lbImportacion.Text = "Importando CFDI'S...";
			}
			label1.Visible = !label1.Visible;
			LabelContador = contador + "/" + total;
			contador++;
		}

		private void Cargando_Load(object sender, EventArgs e)
		{
			timer1.Start();
		}

		private void Cargando_FormClosing(object sender, FormClosingEventArgs e)
		{
			timer1.Stop();
			if (contador < total)
			{
				lbImportacion.Text = "        FINALIZANDO..";
				e.Cancel = true;
				for (int x = contador; x <= total; x++)
				{
					LabelContador = x + "/" + total;
					contador++;
				}
			}
			lbImportacion.Text = "        FINALIZANDO...";
			timer2.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void timer2_Tick(object sender, EventArgs e)
		{
			Close();
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.pnlProgressBar = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.lbContador = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lbImportacion = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.pnlProgressBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(timer1_Tick);
			this.timer2.Interval = 2000;
			this.timer2.Tick += new System.EventHandler(timer2_Tick);
			this.pnlProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pnlProgressBar.BackColor = System.Drawing.Color.White;
			this.pnlProgressBar.Controls.Add(this.button1);
			this.pnlProgressBar.Controls.Add(this.lbContador);
			this.pnlProgressBar.Controls.Add(this.label1);
			this.pnlProgressBar.Controls.Add(this.pictureBox1);
			this.pnlProgressBar.Controls.Add(this.lbImportacion);
			this.pnlProgressBar.Controls.Add(this.progressBar1);
			this.pnlProgressBar.Location = new System.Drawing.Point(52, 70);
			this.pnlProgressBar.Name = "pnlProgressBar";
			this.pnlProgressBar.Size = new System.Drawing.Size(1597, 963);
			this.pnlProgressBar.TabIndex = 134;
			this.button1.Location = new System.Drawing.Point(559, 80);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(button1_Click);
			this.lbContador.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lbContador.AutoSize = true;
			this.lbContador.BackColor = System.Drawing.Color.Transparent;
			this.lbContador.Font = new System.Drawing.Font("Microsoft New Tai Lue", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbContador.Location = new System.Drawing.Point(724, 499);
			this.lbContador.Name = "lbContador";
			this.lbContador.Size = new System.Drawing.Size(59, 35);
			this.lbContador.TabIndex = 4;
			this.lbContador.Text = "0/0";
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft New Tai Lue", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(495, 533);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(560, 22);
			this.label1.TabIndex = 3;
			this.label1.Text = "¡NO INGRESE MÁS ARCHIVOS HASTA TERMINAR LA IMPORTACIÓN!";
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.pictureBox1.Image = LeeXML.Properties.Resources.Cargando;
			this.pictureBox1.Location = new System.Drawing.Point(659, 260);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(221, 181);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.lbImportacion.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lbImportacion.AutoSize = true;
			this.lbImportacion.BackColor = System.Drawing.Color.Transparent;
			this.lbImportacion.Font = new System.Drawing.Font("Microsoft New Tai Lue", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbImportacion.Location = new System.Drawing.Point(626, 474);
			this.lbImportacion.Name = "lbImportacion";
			this.lbImportacion.Size = new System.Drawing.Size(281, 35);
			this.lbImportacion.TabIndex = 1;
			this.lbImportacion.Text = "Importando CFDI'S...";
			this.progressBar1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.progressBar1.Location = new System.Drawing.Point(512, 447);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(529, 108);
			this.progressBar1.TabIndex = 0;
			this.progressBar1.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1702, 1072);
			base.Controls.Add(this.pnlProgressBar);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Cargando";
			base.Opacity = 0.5;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cargando";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Cargando_FormClosing);
			base.Load += new System.EventHandler(Cargando_Load);
			this.pnlProgressBar.ResumeLayout(false);
			this.pnlProgressBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
