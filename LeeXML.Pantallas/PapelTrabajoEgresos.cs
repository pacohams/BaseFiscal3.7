using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Microsoft.Reporting.WinForms;

namespace LeeXML.Pantallas
{
	public class PapelTrabajoEgresos : FormBase
	{
		private IContainer components = null;

		private TabControl tcPedidosGrids;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private Button btnBuscaEmpresa;

		private Label label24;

		private ComboBox cmbEmpresas;

		private BindingSource EntEstadoDeCuentaBindingSource;

		private TabPage tabPage4;

		private GroupBox groupBox1;

		private Label label1;

		private TextBox txtNombreFiscal2;

		private TextBox txtRFC2;

		private Label label2;

		private TabControl tabControl1;

		private TabPage tabPage5;

		private FlowLayoutPanel flowLayoutPanel2;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox toolStripTextBox1;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox toolStripTextBox2;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tsTxtImporte2;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tsTxtIVA2;

		private DataGridView gvPapelDeTrabajo2;

		private FlowLayoutPanel flowLayoutPanel3;

		private TabPage tabPage6;

		private Panel pnlFiltros;

		private Button btnRefrescar2;

		private RadioButton radioButton1;

		private Panel panel3;

		private ComboBox cmbMesesComprobantes2;

		private ComboBox cmbAñoComprobantes2;

		private Button btnAgregaImporteDeclarado;

		private ReportViewer rvPapelDeTrabajo2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn Pago;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantes2 { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public PapelTrabajoEgresos()
		{
			InitializeComponent();
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					CargaDatosEmpresa(txtNombreFiscal2, txtRFC2);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CargaPapelDeTrabajo2Egresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes2 = new BusFacturas().ObtieneEstadosDeCuentaPT2Egresos(Empresa, FechaDesde, FechaHasta);
			List<EntFactura> lstFiltro = ListaComprobantes2;
			gvPapelDeTrabajo2.DataSource = lstFiltro;
			gvPapelDeTrabajo2.Refresh();
			ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + Empresa.Nombre);
			ReportParameter parmFecha = new ReportParameter("parmFecha", " " + FechaDesde.ToString("MMM yyyy").ToUpper());
			rvPapelDeTrabajo2.LocalReport.SetParameters(parmEmpresa);
			rvPapelDeTrabajo2.LocalReport.SetParameters(parmFecha);
			entFacturaBindingSource.DataSource = lstFiltro;
			rvPapelDeTrabajo2.LocalReport.DataSources.Clear();
			rvPapelDeTrabajo2.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstFiltro));
			rvPapelDeTrabajo2.RefreshReport();
		}

		private void InicializaPantalla()
		{
			CargaAñosCmb(cmbAñoComprobantes2);
			cmbMesesComprobantes2.SelectedIndex = DateTime.Today.Month - 1;
			cmbAñoComprobantes2.SelectedIndex = cmbAñoComprobantes2.FindStringExact(DateTime.Today.Year.ToString());
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				base.UsuarioLogin = Program.UsuarioSeleccionado;
				CargaEmpresas(cmbEmpresas, Program.UsuarioSeleccionado.CompañiaId);
				if (Program.EmpresaSeleccionada == null)
				{
					Program.EmpresaSeleccionada = SeleccionaEmpresa();
				}
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				InicializaPantalla();
				CargaDatosEmpresa(txtNombreFiscal2, txtRFC2);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnAgregaImporteDeclarado_Click_1(object sender, EventArgs e)
		{
			try
			{
				AgregaImporteDeclarado vImpDep = new AgregaImporteDeclarado(true);
				if (vImpDep.ShowDialog() == DialogResult.OK)
				{
					tsTxtIVA2.Text = FormatoMoney(vImpDep.IVADecimal);
					new BusFacturas().AgregaImporteDeclaradoEgresos(base.EmpresaSeleccionada.Id, vImpDep.ImporteDecimal, vImpDep.IVADecimal, FechaDesdeFromComboBoxs(cmbMesesComprobantes2, cmbAñoComprobantes2), base.UsuarioLogin.Id);
					btnRefrescar2.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnRefrescar2_Click(object sender, EventArgs e)
		{
			try
			{
				CargaPapelDeTrabajo2Egresos(Program.EmpresaSeleccionada, FechaDesdeFromComboBoxs(cmbMesesComprobantes2, cmbAñoComprobantes2), FechaHastaFromComboBoxs(cmbMesesComprobantes2, cmbAñoComprobantes2));
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.PapelTrabajoEgresos));
			this.EntEstadoDeCuentaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtNombreFiscal2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtRFC2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tsTxtImporte2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tsTxtIVA2 = new System.Windows.Forms.ToolStripTextBox();
			this.gvPapelDeTrabajo2 = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAgregaImporteDeclarado = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.rvPapelDeTrabajo2 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.pnlFiltros = new System.Windows.Forms.Panel();
			this.btnRefrescar2 = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes2 = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes2 = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label24 = new System.Windows.Forms.Label();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvPapelDeTrabajo2).BeginInit();
			this.flowLayoutPanel3.SuspendLayout();
			this.tabPage6.SuspendLayout();
			this.pnlFiltros.SuspendLayout();
			this.panel3.SuspendLayout();
			base.SuspendLayout();
			this.EntEstadoDeCuentaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEstadoDeCuenta);
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage4);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(13, 23);
			this.tcPedidosGrids.Margin = new System.Windows.Forms.Padding(4);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1261, 602);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage4.Controls.Add(this.groupBox1);
			this.tabPage4.Controls.Add(this.tabControl1);
			this.tabPage4.Controls.Add(this.pnlFiltros);
			this.tabPage4.Location = new System.Drawing.Point(4, 27);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage4.Size = new System.Drawing.Size(1253, 571);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Papel de Trabajo ";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.groupBox1.Controls.Add(this.txtNombreFiscal2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtRFC2);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(7, 7);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
			this.groupBox1.Size = new System.Drawing.Size(440, 85);
			this.groupBox1.TabIndex = 140;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Datos Empresa Emisora";
			this.txtNombreFiscal2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtNombreFiscal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal2.Location = new System.Drawing.Point(145, 25);
			this.txtNombreFiscal2.Margin = new System.Windows.Forms.Padding(4);
			this.txtNombreFiscal2.Name = "txtNombreFiscal2";
			this.txtNombreFiscal2.ReadOnly = true;
			this.txtNombreFiscal2.Size = new System.Drawing.Size(280, 23);
			this.txtNombreFiscal2.TabIndex = 104;
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(17, 25);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(122, 23);
			this.label1.TabIndex = 102;
			this.label1.Text = "Nombre Fiscal:";
			this.txtRFC2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC2.Location = new System.Drawing.Point(145, 57);
			this.txtRFC2.Margin = new System.Windows.Forms.Padding(4);
			this.txtRFC2.Name = "txtRFC2";
			this.txtRFC2.ReadOnly = true;
			this.txtRFC2.Size = new System.Drawing.Size(220, 23);
			this.txtRFC2.TabIndex = 106;
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.White;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(88, 54);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 23);
			this.label2.TabIndex = 105;
			this.label2.Text = "R.F.C:";
			this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Controls.Add(this.tabPage6);
			this.tabControl1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabControl1.Location = new System.Drawing.Point(451, 7);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(795, 558);
			this.tabControl1.TabIndex = 139;
			this.tabPage5.Controls.Add(this.flowLayoutPanel2);
			this.tabPage5.Controls.Add(this.gvPapelDeTrabajo2);
			this.tabPage5.Controls.Add(this.flowLayoutPanel3);
			this.tabPage5.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage5.Location = new System.Drawing.Point(4, 27);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage5.Size = new System.Drawing.Size(787, 527);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "Reporte";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(-132, 5);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(823, 29);
			this.flowLayoutPanel2.TabIndex = 135;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[11]
			{
				this.toolStripLabel5, this.toolStripTextBox1, this.toolStripSeparator3, this.toolStripLabel6, this.toolStripTextBox2, this.toolStripSeparator5, this.toolStripLabel8, this.tsTxtImporte2, this.toolStripSeparator6, this.toolStripLabel7,
				this.tsTxtIVA2
			});
			this.toolStrip2.Location = new System.Drawing.Point(666, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(155, 26);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(146, 23);
			this.toolStripLabel5.Text = "Núm Comprobantes:";
			this.toolStripLabel5.Visible = false;
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.ReadOnly = true;
			this.toolStripTextBox1.Size = new System.Drawing.Size(60, 26);
			this.toolStripTextBox1.Visible = false;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(70, 23);
			this.toolStripLabel6.Text = "SubTotal:";
			this.toolStripLabel6.Visible = false;
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(108, 26);
			this.toolStripTextBox2.Visible = false;
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(65, 23);
			this.toolStripLabel8.Text = "Importe:";
			this.toolStripLabel8.Visible = false;
			this.tsTxtImporte2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tsTxtImporte2.Name = "tsTxtImporte2";
			this.tsTxtImporte2.ReadOnly = true;
			this.tsTxtImporte2.Size = new System.Drawing.Size(108, 26);
			this.tsTxtImporte2.Visible = false;
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 26);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(41, 23);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tsTxtIVA2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tsTxtIVA2.Name = "tsTxtIVA2";
			this.tsTxtIVA2.ReadOnly = true;
			this.tsTxtIVA2.Size = new System.Drawing.Size(82, 26);
			this.gvPapelDeTrabajo2.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvPapelDeTrabajo2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvPapelDeTrabajo2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvPapelDeTrabajo2.AutoGenerateColumns = false;
			this.gvPapelDeTrabajo2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvPapelDeTrabajo2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvPapelDeTrabajo2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gvPapelDeTrabajo2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.gvPapelDeTrabajo2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvPapelDeTrabajo2.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.Pago, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3);
			this.gvPapelDeTrabajo2.DataSource = this.entFacturaBindingSource;
			this.gvPapelDeTrabajo2.Location = new System.Drawing.Point(8, 38);
			this.gvPapelDeTrabajo2.Margin = new System.Windows.Forms.Padding(4);
			this.gvPapelDeTrabajo2.Name = "gvPapelDeTrabajo2";
			this.gvPapelDeTrabajo2.ReadOnly = true;
			this.gvPapelDeTrabajo2.RowHeadersVisible = false;
			this.gvPapelDeTrabajo2.RowHeadersWidth = 51;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
			this.gvPapelDeTrabajo2.RowsDefaultCellStyle = dataGridViewCellStyle7;
			this.gvPapelDeTrabajo2.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
			this.gvPapelDeTrabajo2.RowTemplate.Height = 30;
			this.gvPapelDeTrabajo2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvPapelDeTrabajo2.Size = new System.Drawing.Size(683, 458);
			this.gvPapelDeTrabajo2.TabIndex = 14;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Descripcion";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewTextBoxColumn1.FillWeight = 6f;
			this.dataGridViewTextBoxColumn1.HeaderText = "";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			this.Pago.DataPropertyName = "MetodoPago";
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle9.NullValue = null;
			this.Pago.DefaultCellStyle = dataGridViewCellStyle9;
			this.Pago.FillWeight = 2f;
			this.Pago.HeaderText = "";
			this.Pago.MinimumWidth = 6;
			this.Pago.Name = "Pago";
			this.Pago.ReadOnly = true;
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Banco";
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle10.Format = "N2";
			this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn2.FillWeight = 2f;
			this.dataGridViewTextBoxColumn2.HeaderText = "";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			this.dataGridViewTextBoxColumn3.DataPropertyName = "FormaPago";
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle11.Format = "N2";
			this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
			this.dataGridViewTextBoxColumn3.FillWeight = 2f;
			this.dataGridViewTextBoxColumn3.HeaderText = "";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn3.ReadOnly = true;
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel3.Controls.Add(this.btnAgregaImporteDeclarado);
			this.flowLayoutPanel3.Location = new System.Drawing.Point(687, 32);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(107, 240);
			this.flowLayoutPanel3.TabIndex = 134;
			this.btnAgregaImporteDeclarado.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAgregaImporteDeclarado.BackColor = System.Drawing.Color.White;
			this.btnAgregaImporteDeclarado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregaImporteDeclarado.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregaImporteDeclarado.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregaImporteDeclarado.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregaImporteDeclarado.Location = new System.Drawing.Point(4, 4);
			this.btnAgregaImporteDeclarado.Margin = new System.Windows.Forms.Padding(4);
			this.btnAgregaImporteDeclarado.Name = "btnAgregaImporteDeclarado";
			this.btnAgregaImporteDeclarado.Size = new System.Drawing.Size(93, 84);
			this.btnAgregaImporteDeclarado.TabIndex = 135;
			this.btnAgregaImporteDeclarado.Text = "Agregar Importe Declarado ";
			this.btnAgregaImporteDeclarado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregaImporteDeclarado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAgregaImporteDeclarado.UseVisualStyleBackColor = false;
			this.btnAgregaImporteDeclarado.Click += new System.EventHandler(btnAgregaImporteDeclarado_Click_1);
			this.tabPage6.Controls.Add(this.rvPapelDeTrabajo2);
			this.tabPage6.Location = new System.Drawing.Point(4, 27);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPage6.Size = new System.Drawing.Size(787, 527);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "Exporta";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.rvPapelDeTrabajo2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvPapelDeTrabajo2.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptPapelDeTrabajo2Gastos.rdlc";
			this.rvPapelDeTrabajo2.Location = new System.Drawing.Point(0, 0);
			this.rvPapelDeTrabajo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.rvPapelDeTrabajo2.Name = "rvPapelDeTrabajo2";
			this.rvPapelDeTrabajo2.ServerReport.BearerToken = null;
			this.rvPapelDeTrabajo2.Size = new System.Drawing.Size(783, 523);
			this.rvPapelDeTrabajo2.TabIndex = 2;
			this.pnlFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlFiltros.Controls.Add(this.btnRefrescar2);
			this.pnlFiltros.Controls.Add(this.radioButton1);
			this.pnlFiltros.Controls.Add(this.panel3);
			this.pnlFiltros.Location = new System.Drawing.Point(7, 94);
			this.pnlFiltros.Margin = new System.Windows.Forms.Padding(4);
			this.pnlFiltros.Name = "pnlFiltros";
			this.pnlFiltros.Size = new System.Drawing.Size(439, 147);
			this.pnlFiltros.TabIndex = 138;
			this.btnRefrescar2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescar2.BackColor = System.Drawing.Color.White;
			this.btnRefrescar2.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar2.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar2.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar2.Location = new System.Drawing.Point(324, 54);
			this.btnRefrescar2.Margin = new System.Windows.Forms.Padding(4);
			this.btnRefrescar2.Name = "btnRefrescar2";
			this.btnRefrescar2.Size = new System.Drawing.Size(100, 84);
			this.btnRefrescar2.TabIndex = 132;
			this.btnRefrescar2.Text = "Refrescar";
			this.btnRefrescar2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar2.UseVisualStyleBackColor = false;
			this.btnRefrescar2.Click += new System.EventHandler(btnRefrescar2_Click);
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(32, 14);
			this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(80, 22);
			this.radioButton1.TabIndex = 44;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Por Mes";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.panel3.Controls.Add(this.cmbMesesComprobantes2);
			this.panel3.Controls.Add(this.cmbAñoComprobantes2);
			this.panel3.Location = new System.Drawing.Point(120, 4);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(315, 42);
			this.panel3.TabIndex = 41;
			this.cmbMesesComprobantes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes2.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes2.FormattingEnabled = true;
			this.cmbMesesComprobantes2.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesComprobantes2.Location = new System.Drawing.Point(7, 9);
			this.cmbMesesComprobantes2.Margin = new System.Windows.Forms.Padding(4);
			this.cmbMesesComprobantes2.Name = "cmbMesesComprobantes2";
			this.cmbMesesComprobantes2.Size = new System.Drawing.Size(167, 30);
			this.cmbMesesComprobantes2.TabIndex = 19;
			this.cmbAñoComprobantes2.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes2.FormattingEnabled = true;
			this.cmbAñoComprobantes2.Location = new System.Drawing.Point(203, 9);
			this.cmbAñoComprobantes2.Margin = new System.Windows.Forms.Padding(4);
			this.cmbAñoComprobantes2.Name = "cmbAñoComprobantes2";
			this.cmbAñoComprobantes2.Size = new System.Drawing.Size(101, 28);
			this.cmbAñoComprobantes2.TabIndex = 20;
			this.cmbAñoComprobantes2.ValueMember = "Descripcion";
			this.label24.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(336, 14);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(79, 22);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(421, 6);
			this.cmbEmpresas.Margin = new System.Windows.Forms.Padding(4);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(455, 33);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(881, 6);
			this.btnBuscaEmpresa.Margin = new System.Windows.Forms.Padding(4);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(52, 34);
			this.btnBuscaEmpresa.TabIndex = 138;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1287, 638);
			base.Controls.Add(this.btnBuscaEmpresa);
			base.Controls.Add(this.label24);
			base.Controls.Add(this.cmbEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "PapelTrabajoEgresos";
			this.Text = "Papel de Trabajo";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			((System.ComponentModel.ISupportInitialize)this.EntEstadoDeCuentaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvPapelDeTrabajo2).EndInit();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.tabPage6.ResumeLayout(false);
			this.pnlFiltros.ResumeLayout(false);
			this.pnlFiltros.PerformLayout();
			this.panel3.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
