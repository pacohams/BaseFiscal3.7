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
	public class SeleccionUsuario : Form
	{
		private List<EntUsuario> Usuarios;

		private IContainer components = null;

		private Button btnCancelar;

		private Button btnAgregar;

		private BindingSource entEmpresaBindingSource;

		private DataGridView gvEmpresas;

		private DataGridViewTextBoxColumn RFC;

		private Button btnFiltraFacturas;

		private TextBox txtFacturaFiltro;

		private Label lbMensaje;

		private DataGridViewTextBoxColumn compañiaIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn empresaIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn tipoUsuarioIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn contraseñaDataGridViewTextBoxColumn;

		private DataGridViewCheckBoxColumn administradorDataGridViewCheckBoxColumn;

		private DataGridViewTextBoxColumn claveDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn usuarioIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;

		private DataGridViewCheckBoxColumn estatusDataGridViewCheckBoxColumn;

		private DataGridViewTextBoxColumn estatusIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private BindingSource entUsuarioBindingSource;

		public EntUsuario UsuarioLogin { get; set; }

		public EntUsuario UsuarioSeleccionado => ObtieneEmpresaFromGV(gvEmpresas);

		public SeleccionUsuario()
		{
			InitializeComponent();
			CargaEmpresas();
		}

		public SeleccionUsuario(List<EntUsuario> ListaUsuarios)
		{
			InitializeComponent();
			Usuarios = ListaUsuarios;
		}

		public void CargaEmpresas()
		{
			Usuarios = new BusUsuarios().ObtieneUsuarios();
			gvEmpresas.DataSource = Usuarios;
		}

		public EntUsuario ObtieneEmpresaFromGV(DataGridView GridViewEmpresas)
		{
			if (GridViewEmpresas.CurrentRow == null)
			{
				return null;
			}
			return ((List<EntUsuario>)GridViewEmpresas.DataSource)[GridViewEmpresas.CurrentRow.Index];
		}

		private void SeleccionEmpresa_Load(object sender, EventArgs e)
		{
			if (Usuarios.Count > 0)
			{
				gvEmpresas.DataSource = Usuarios;
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
		}

		private void gvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				btnAgregar.PerformClick();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void gvEmpresas_KeyPress(object sender, KeyPressEventArgs e)
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
				MessageBox.Show(ex.Message);
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
		}

		private void btnFiltraFacturas_Click(object sender, EventArgs e)
		{
			try
			{
				gvEmpresas.DataSource = Usuarios.Where((EntUsuario P) => P.Usuario.ToUpper().Contains(txtFacturaFiltro.Text.ToUpper())).ToList();
				gvEmpresas.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void txtFacturaFiltro_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				btnAgregar.PerformClick();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.SeleccionUsuario));
			this.gvEmpresas = new System.Windows.Forms.DataGridView();
			this.RFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnFiltraFacturas = new System.Windows.Forms.Button();
			this.txtFacturaFiltro = new System.Windows.Forms.TextBox();
			this.lbMensaje = new System.Windows.Forms.Label();
			this.entUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.compañiaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.empresaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tipoUsuarioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contraseñaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.administradorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.claveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.usuarioIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.estatusDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.estatusIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)this.gvEmpresas).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).BeginInit();
			base.SuspendLayout();
			this.gvEmpresas.AllowUserToAddRows = false;
			this.gvEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvEmpresas.AutoGenerateColumns = false;
			this.gvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvEmpresas.BackgroundColor = System.Drawing.Color.White;
			this.gvEmpresas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.gvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvEmpresas.Columns.AddRange(this.RFC, this.compañiaIdDataGridViewTextBoxColumn, this.empresaIdDataGridViewTextBoxColumn, this.tipoUsuarioIdDataGridViewTextBoxColumn, this.usuarioDataGridViewTextBoxColumn, this.contraseñaDataGridViewTextBoxColumn, this.administradorDataGridViewCheckBoxColumn, this.claveDataGridViewTextBoxColumn, this.idDataGridViewTextBoxColumn, this.usuarioIdDataGridViewTextBoxColumn, this.descripcionDataGridViewTextBoxColumn, this.estatusDataGridViewCheckBoxColumn, this.estatusIdDataGridViewTextBoxColumn, this.fechaDataGridViewTextBoxColumn);
			this.gvEmpresas.DataSource = this.entUsuarioBindingSource;
			this.gvEmpresas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gvEmpresas.GridColor = System.Drawing.Color.DimGray;
			this.gvEmpresas.Location = new System.Drawing.Point(18, 59);
			this.gvEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvEmpresas.MultiSelect = false;
			this.gvEmpresas.Name = "gvEmpresas";
			this.gvEmpresas.ReadOnly = true;
			this.gvEmpresas.RowHeadersVisible = false;
			this.gvEmpresas.RowHeadersWidth = 51;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5f);
			this.gvEmpresas.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvEmpresas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Tai Le", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.gvEmpresas.RowTemplate.Height = 27;
			this.gvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvEmpresas.Size = new System.Drawing.Size(938, 580);
			this.gvEmpresas.TabIndex = 2;
			this.gvEmpresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvEmpresas_CellDoubleClick);
			this.gvEmpresas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(gvEmpresas_KeyPress);
			this.RFC.DataPropertyName = "RFC";
			this.RFC.FillWeight = 1.5f;
			this.RFC.HeaderText = "RFC";
			this.RFC.MinimumWidth = 6;
			this.RFC.Name = "RFC";
			this.RFC.ReadOnly = true;
			this.entEmpresaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEmpresa);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnCancelar.BackColor = System.Drawing.SystemColors.Window;
			this.btnCancelar.BackgroundImage = LeeXML.Properties.Resources.Cancelar;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 6.6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnCancelar.Location = new System.Drawing.Point(512, 645);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(146, 100);
			this.btnCancelar.TabIndex = 91;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnAgregar.BackColor = System.Drawing.SystemColors.Window;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 6.6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregar.Location = new System.Drawing.Point(323, 645);
			this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(146, 100);
			this.btnAgregar.TabIndex = 90;
			this.btnAgregar.Text = "Seleccionar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.btnFiltraFacturas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnFiltraFacturas.BackColor = System.Drawing.Color.White;
			this.btnFiltraFacturas.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnFiltraFacturas.BackgroundImage");
			this.btnFiltraFacturas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnFiltraFacturas.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnFiltraFacturas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnFiltraFacturas.Location = new System.Drawing.Point(740, 9);
			this.btnFiltraFacturas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnFiltraFacturas.Name = "btnFiltraFacturas";
			this.btnFiltraFacturas.Size = new System.Drawing.Size(58, 42);
			this.btnFiltraFacturas.TabIndex = 98;
			this.btnFiltraFacturas.UseVisualStyleBackColor = false;
			this.btnFiltraFacturas.Click += new System.EventHandler(btnFiltraFacturas_Click);
			this.txtFacturaFiltro.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.txtFacturaFiltro.Font = new System.Drawing.Font("Microsoft Tai Le", 8.5f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtFacturaFiltro.Location = new System.Drawing.Point(262, 14);
			this.txtFacturaFiltro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.txtFacturaFiltro.Name = "txtFacturaFiltro";
			this.txtFacturaFiltro.Size = new System.Drawing.Size(469, 29);
			this.txtFacturaFiltro.TabIndex = 1;
			this.txtFacturaFiltro.TextChanged += new System.EventHandler(btnFiltraFacturas_Click);
			this.txtFacturaFiltro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFacturaFiltro_KeyPress);
			this.lbMensaje.AutoSize = true;
			this.lbMensaje.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbMensaje.Location = new System.Drawing.Point(16, 18);
			this.lbMensaje.Name = "lbMensaje";
			this.lbMensaje.Size = new System.Drawing.Size(229, 26);
			this.lbMensaje.TabIndex = 96;
			this.lbMensaje.Text = "SELECCIONE EMPRESA:";
			this.entUsuarioBindingSource.DataSource = typeof(LeeXMLEntidades.EntUsuario);
			this.compañiaIdDataGridViewTextBoxColumn.DataPropertyName = "CompañiaId";
			this.compañiaIdDataGridViewTextBoxColumn.HeaderText = "CompañiaId";
			this.compañiaIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.compañiaIdDataGridViewTextBoxColumn.Name = "compañiaIdDataGridViewTextBoxColumn";
			this.compañiaIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.empresaIdDataGridViewTextBoxColumn.DataPropertyName = "EmpresaId";
			this.empresaIdDataGridViewTextBoxColumn.HeaderText = "EmpresaId";
			this.empresaIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.empresaIdDataGridViewTextBoxColumn.Name = "empresaIdDataGridViewTextBoxColumn";
			this.empresaIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.tipoUsuarioIdDataGridViewTextBoxColumn.DataPropertyName = "TipoUsuarioId";
			this.tipoUsuarioIdDataGridViewTextBoxColumn.HeaderText = "TipoUsuarioId";
			this.tipoUsuarioIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.tipoUsuarioIdDataGridViewTextBoxColumn.Name = "tipoUsuarioIdDataGridViewTextBoxColumn";
			this.tipoUsuarioIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
			this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
			this.usuarioDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
			this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
			this.contraseñaDataGridViewTextBoxColumn.DataPropertyName = "Contraseña";
			this.contraseñaDataGridViewTextBoxColumn.HeaderText = "Contraseña";
			this.contraseñaDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.contraseñaDataGridViewTextBoxColumn.Name = "contraseñaDataGridViewTextBoxColumn";
			this.contraseñaDataGridViewTextBoxColumn.ReadOnly = true;
			this.administradorDataGridViewCheckBoxColumn.DataPropertyName = "Administrador";
			this.administradorDataGridViewCheckBoxColumn.HeaderText = "Administrador";
			this.administradorDataGridViewCheckBoxColumn.MinimumWidth = 8;
			this.administradorDataGridViewCheckBoxColumn.Name = "administradorDataGridViewCheckBoxColumn";
			this.administradorDataGridViewCheckBoxColumn.ReadOnly = true;
			this.claveDataGridViewTextBoxColumn.DataPropertyName = "Clave";
			this.claveDataGridViewTextBoxColumn.HeaderText = "Clave";
			this.claveDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.claveDataGridViewTextBoxColumn.Name = "claveDataGridViewTextBoxColumn";
			this.claveDataGridViewTextBoxColumn.ReadOnly = true;
			this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
			this.idDataGridViewTextBoxColumn.HeaderText = "Id";
			this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
			this.idDataGridViewTextBoxColumn.ReadOnly = true;
			this.usuarioIdDataGridViewTextBoxColumn.DataPropertyName = "UsuarioId";
			this.usuarioIdDataGridViewTextBoxColumn.HeaderText = "UsuarioId";
			this.usuarioIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.usuarioIdDataGridViewTextBoxColumn.Name = "usuarioIdDataGridViewTextBoxColumn";
			this.usuarioIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
			this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
			this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
			this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
			this.estatusDataGridViewCheckBoxColumn.DataPropertyName = "Estatus";
			this.estatusDataGridViewCheckBoxColumn.HeaderText = "Estatus";
			this.estatusDataGridViewCheckBoxColumn.MinimumWidth = 8;
			this.estatusDataGridViewCheckBoxColumn.Name = "estatusDataGridViewCheckBoxColumn";
			this.estatusDataGridViewCheckBoxColumn.ReadOnly = true;
			this.estatusIdDataGridViewTextBoxColumn.DataPropertyName = "EstatusId";
			this.estatusIdDataGridViewTextBoxColumn.HeaderText = "EstatusId";
			this.estatusIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.estatusIdDataGridViewTextBoxColumn.Name = "estatusIdDataGridViewTextBoxColumn";
			this.estatusIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(974, 751);
			base.Controls.Add(this.btnFiltraFacturas);
			base.Controls.Add(this.txtFacturaFiltro);
			base.Controls.Add(this.lbMensaje);
			base.Controls.Add(this.gvEmpresas);
			base.Controls.Add(this.btnCancelar);
			base.Controls.Add(this.btnAgregar);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "SeleccionUsuario";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Selección de Empresa";
			base.Load += new System.EventHandler(SeleccionEmpresa_Load);
			((System.ComponentModel.ISupportInitialize)this.gvEmpresas).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
