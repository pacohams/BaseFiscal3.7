using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeeXML.Pantallas
{
	public class Licencias : FormBase
	{
		private new List<EntEmpresa> ListaEmpresas;

		private List<EntCatalogoGenerico> ListaBancos;

		private List<EntCatalogoGenerico> ListaUnidades;

		private new EntEmpresa EmpresaSeleccionada;

		private List<EntUsuario> ListaLicencias;

		private List<EntUsuario> ListaLicenciasDescargaMasiva;

		private IContainer components = null;

		private TabControl tabControl1;

		private TabPage tabPage1;

		private Panel pnlDatos;

		private Label label1;

		private Button btnCancelar;

		private Button btnAgregar;

		private TabControl tcNuevaEmpresa;

		private TabPage tabPage5;

		private TextBox txtNombre;

		private Label label2;

		private TabPage tabPage6;

		private Panel panel3;

		private TextBox txtDescripcionBanco;

		private Label label23;

		private TextBox txtNoReferencia;

		private Label label22;

		private TextBox txtSucursal;

		private Label label21;

		private TextBox txtNoCuenta;

		private Label label20;

		private TextBox txtCLABE;

		private Label label19;

		private Button btnRefrescar;

		private Button btnEditar;

		private TabControl tabControl2;

		private TabPage tabPage2;

		private Button btnEmpresaBusqueda;

		private TextBox txtEmpresaBusqueda;

		private OpenFileDialog ofdBuscaArchivo;

		private Button btnEliminar;

		private DataGridView gvEmpresas;

		private BindingSource entEmpresaBindingSource;

		private Button btnActualizar;

		private BindingSource entCatalogoGenericoBindingSource;

		private Label lbEmpresa;

		private DataGridViewTextBoxColumn TipoTasa;

		private TextBox txtClaveBanco;

		private DataGridView gvBancos;

		private DataGridViewTextBoxColumn claveDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;

		private DataGridViewImageColumn GvEmpresasColumnEliminar;

		private Label label32;

		private Button btnAgregaBanco;

		private Panel pnlDatosFacturacion;

		private ComboBox cmbTipoPersona;

		private Label label24;

		private TextBox txtEmail;

		private TextBox txtTelefono;

		private TextBox txtTelefono2;

		private TextBox txtDireccion;

		private Label label7;

		private Label label6;

		private Label label4;

		private Label label3;

		private Label label31;

		private TextBox txtTasaOCuota;

		private ComboBox cmbUsoCFDI;

		private TextBox txtUsoCFDI;

		private Label label5;

		private ComboBox cmbRegimenFiscal;

		private TextBox txtRegimenFiscal;

		private Label label30;

		private TextBox txtNoCertificado;

		private Label label29;

		private ComboBox cmbTipoFactor;

		private Label label28;

		private TextBox txtNombreFiscal;

		private TextBox txtRFC;

		private TextBox txtCalle;

		private TextBox txtNoExterior;

		private TextBox txtNoInterior;

		private TextBox txtColonia;

		private TextBox txtMunicipio;

		private TextBox txtEstado;

		private TextBox txtCP;

		private TextBox txtLocalidad;

		private Label label18;

		private Label label17;

		private Label label16;

		private Label label15;

		private Label label14;

		private Label label13;

		private Label label12;

		private Label label11;

		private Label label10;

		private Label label9;

		private TextBox txtRuta;

		private Label label89;

		private Button btnCargaXMLs;

		private Button btnSeleccionaRutaRecibidos;

		private TextBox txtRutaRecibidos;

		private Label label8;

		private TextBox txtLicenciaSerial;

		private TextBox txtDiasExpiracion;

		private Label label26;

		private ComboBox cmbLicencias;

		private BindingSource entUsuarioBindingSource;

		private Button btnActualizaLicencia;

		private TextBox txtNoEmpresasDisponibles;

		private FlowLayoutPanel flowLayoutPanel1;

		private FlowLayoutPanel flowLayoutPanel2;

		private GroupBox gbDatosDescargaMasiva;

		private TextBox txtContraseñaCIEC;

		private Label label33;

		private Button btnRegistraDescargaMasiva;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripProgressBar toolStripProgressBar1;

		private ToolStripSplitButton toolStripSplitButton1;

		private Button btnVerContraseña;

		private LinkLabel lnkDescargaMasiva;

		private Button btnVerificarRegistroCIEC;

		private FlowLayoutPanel flowLayoutPanel3;

		private Panel pnlCIECregistrada;

		private Panel panel2;

		private FlowLayoutPanel flowLayoutPanel4;

		private Button button1;

		private GroupBox groupBox2;

		private GroupBox groupBox1;

		private LinkLabel linkLabel1;

		private DataGridViewTextBoxColumn LicenciaSerial;

		private DataGridViewTextBoxColumn DiasExpiracion;

		private DataGridViewTextBoxColumn añoInicialDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn limiteEmpresasDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaActivacionDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaLimiteDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn activacionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn tipoLicenciaIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn licenciaIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn licenciaSerialDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn diasExpiracionDataGridViewTextBoxColumn;

		private DataGridViewCheckBoxColumn activadoDataGridViewCheckBoxColumn;

		private DataGridViewTextBoxColumn estatusIdDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn estatusDescripcionDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn fechaPagoDataGridViewTextBoxColumn;

		private List<razonesSociales> ListaRS { get; set; }

		private bool RfcEncontrado { get; set; }

		private void InicializaPantalla()
		{
		}

		public Licencias()
		{
			InitializeComponent();
		}

		public void CargaEmpresas()
		{
			ListaEmpresas = new BusEmpresas().ObtieneEmpresas(Program.UsuarioSeleccionado.CompañiaId, Program.UsuarioSeleccionado.LimiteEmpresas);
			gvEmpresas.DataSource = ListaEmpresas;
		}

		public void CargaLicencias(int CompañiaId)
		{
			ListaLicencias = new BusUsuarios().ObtieneLicenciasTodas(CompañiaId);
			gvEmpresas.DataSource = ListaLicencias;
			cmbLicencias.DataSource = ListaLicencias;
			if (ListaLicencias.Count > 0)
			{
				cmbLicencias.SelectedIndex = 0;
			}
			ListaLicenciasDescargaMasiva = new BusUsuarios().ObtieneLicenciasDescargaMasivaActivas(CompañiaId);
		}

		public void CargaBancos(int EmpresaId)
		{
			ListaBancos = new BusEmpresas().ObtieneBancos(EmpresaId);
			gvBancos.DataSource = ListaBancos.OrderByDescending((EntCatalogoGenerico P) => P.Estatus).ToList();
			gvBancos.Refresh();
		}

		public void CargaCatalogoRegimen()
		{
			cmbRegimenFiscal.DataSource = new BusEmpresas().ObtieneCatalogoRegimen();
		}

		public void CargaCatalogoUsoCFDI()
		{
			cmbUsoCFDI.DataSource = new BusEmpresas().ObtieneCatalogoUsoCFDI();
		}

		private EntEmpresa AgregaEmpresa(int TipoPersonaId, string Nombre, string NombreFiscal, int RegimenFiscalId, string RegimenFiscal, string Direccion, string Calle, string NoExterior, string NoInterior, string Colonia, string Localidad, string Municipio, string Estado, string CP, string Telefono, string Telefono2, string RFC, string Email, string Banco, string NumeroCuenta, string Sucursal, string CLABE, string NumeroReferencia, string NoCertificado, int TipoFactorId, decimal TasaOCuota, int UsoCFDIId, string Ruta, string RutaRecibidos, string ContraseñaCIEC)
		{
			EntEmpresa empresa = new EntEmpresa
			{
				CompañiaId = Program.UsuarioSeleccionado.CompañiaId,
				TipoPersonaId = TipoPersonaId,
				Nombre = Nombre,
				NombreFiscal = NombreFiscal,
				RegimenFiscalId = RegimenFiscalId,
				RegimenFiscal = RegimenFiscal,
				Direccion = Direccion,
				Telefono = Telefono,
				Telefono2 = Telefono2,
				Email = Email,
				RFC = RFC,
				Calle = Calle,
				NoExterior = NoExterior,
				NoInterior = NoInterior,
				Colonia = Colonia,
				Localidad = Localidad,
				Municipio = Municipio,
				Estado = Estado,
				CP = CP,
				Banco = Banco,
				NumeroCuenta = NumeroCuenta,
				Sucursal = Sucursal,
				CLABE = CLABE,
				NumeroReferencia = NumeroReferencia,
				Certificado = ContraseñaCIEC,
				Key = Ruta,
				KeyRecibidos = RutaRecibidos,
				NoCertificado = NoCertificado,
				TipoFactorId = TipoFactorId,
				TasaOCuota = TasaOCuota,
				UsoCFDIId = UsoCFDIId
			};
			empresa.Id = new BusEmpresas().AgregaEmpresa(empresa);
			return empresa;
		}

		private void ActualizaEmpresa(int EmpresaId, int TipoPersonaId, string Nombre, string NombreFiscal, int RegimenFiscalId, string RegimenFiscal, string Direccion, string Calle, string NoExterior, string NoInterior, string Colonia, string Localidad, string Municipio, string Estado, string CP, string Telefono, string Telefono2, string RFC, string Email, string Banco, string NumeroCuenta, string Sucursal, string CLABE, string NumeroReferencia, string NoCertificado, int TipoFactorId, decimal TasaOCuota, int UsoCFDIId, string Ruta, string RutaRecibidos, string ContraseñaCIEC)
		{
			EntEmpresa empresa = new EntEmpresa
			{
				Id = EmpresaId,
				TipoPersonaId = TipoPersonaId,
				Nombre = Nombre,
				NombreFiscal = NombreFiscal,
				RegimenFiscalId = RegimenFiscalId,
				RegimenFiscal = RegimenFiscal,
				Direccion = Direccion,
				Telefono = Telefono,
				Telefono2 = Telefono2,
				Email = Email,
				RFC = RFC,
				Calle = Calle,
				NoExterior = NoExterior,
				NoInterior = NoInterior,
				Colonia = Colonia,
				Localidad = Localidad,
				Municipio = Municipio,
				Estado = Estado,
				CP = CP,
				Banco = Banco,
				NumeroCuenta = NumeroCuenta,
				Sucursal = Sucursal,
				CLABE = CLABE,
				NumeroReferencia = NumeroReferencia,
				Certificado = ContraseñaCIEC,
				Key = Ruta,
				KeyRecibidos = RutaRecibidos,
				NoCertificado = NoCertificado,
				TipoFactorId = TipoFactorId,
				TasaOCuota = TasaOCuota,
				UsoCFDIId = UsoCFDIId
			};
			new BusEmpresas().ActualizaEmpresa(empresa);
		}

		private void CargaDatosEmpresa(EntEmpresa Empresa)
		{
			lbEmpresa.Text = Empresa.Nombre;
			cmbTipoPersona.SelectedIndex = Empresa.TipoPersonaId - 1;
			txtNombre.Text = Empresa.Nombre;
			txtDireccion.Text = Empresa.Direccion;
			txtTelefono.Text = Empresa.Telefono;
			txtTelefono2.Text = Empresa.Telefono2;
			txtEmail.Text = Empresa.Email;
			txtNombreFiscal.Text = Empresa.NombreFiscal;
			txtRegimenFiscal.Text = Empresa.RegimenFiscal;
			txtRFC.Text = Empresa.RFC;
			txtNoExterior.Text = Empresa.NoExterior;
			txtNoInterior.Text = Empresa.NoInterior;
			txtCalle.Text = Empresa.Calle;
			txtColonia.Text = Empresa.Colonia;
			txtLocalidad.Text = Empresa.Localidad;
			txtMunicipio.Text = Empresa.Municipio;
			txtEstado.Text = Empresa.Estado;
			txtCP.Text = Empresa.CP;
			txtNoCertificado.Text = Empresa.NoCertificado;
			cmbRegimenFiscal.SelectedIndex = ((List<EntCatalogoGenerico>)cmbRegimenFiscal.DataSource).FindIndex((EntCatalogoGenerico P) => P.Id == Empresa.RegimenFiscalId);
			txtDescripcionBanco.Text = Empresa.Banco;
			txtSucursal.Text = Empresa.Sucursal;
			txtCLABE.Text = Empresa.CLABE;
			cmbTipoFactor.SelectedIndex = Empresa.TipoFactorId - 1;
			txtTasaOCuota.Text = Empresa.TasaOCuota.ToString("0.000000");
			cmbUsoCFDI.SelectedIndex = ((List<EntCatalogoGenerico>)cmbUsoCFDI.DataSource).FindIndex((EntCatalogoGenerico P) => P.Id == Empresa.UsoCFDIId);
			txtRuta.Text = Empresa.Key;
			txtRutaRecibidos.Text = Empresa.KeyRecibidos;
			txtLicenciaSerial.Text = Empresa.LicenciaSerial;
			txtDiasExpiracion.Text = Empresa.DiasExpiracionTS.Days.ToString();
			txtNoEmpresasDisponibles.Text = (Empresa.LimiteEmpresas - Empresa.Activaciones).ToString();
			txtContraseñaCIEC.Text = Empresa.Certificado;
			if (string.IsNullOrWhiteSpace(Empresa.Certificado))
			{
				pnlCIECregistrada.Visible = false;
				btnRegistraDescargaMasiva.Text = "REGISTRA CIEC";
			}
			else
			{
				pnlCIECregistrada.Visible = true;
				btnRegistraDescargaMasiva.Text = "Cambio CIEC";
			}
			CargaBancos(Empresa.Id);
		}

		private void FiltrarEmpresasPorDescripcion(List<EntEmpresa> ListaEmpresas, string DescripcionEmpresa, DataGridView GridViewEmpresas)
		{
			IEnumerable<EntEmpresa> empresasFiltro = ListaEmpresas.Where((EntEmpresa c) => c.Descripcion.ToUpper().Contains(DescripcionEmpresa.ToUpper()));
			GridViewEmpresas.DataSource = null;
			GridViewEmpresas.DataSource = empresasFiltro.ToList();
		}

		private void ActivaAgregar(bool Visible)
		{
			txtRFC.Enabled = Visible;
			cmbLicencias.Visible = Visible;
			btnAgregar.Visible = Visible;
			btnActualizar.Visible = !Visible;
			btnActualizaLicencia.Visible = !Visible;
			gbDatosDescargaMasiva.Visible = !Visible;
			btnVerificarRegistroCIEC.Visible = !Visible;
		}

		private void Empresas_Load(object sender, EventArgs e)
		{
			try
			{
				InicializaPantalla();
				CargaLicencias(Program.UsuarioSeleccionado.CompañiaId);
				if (ListaLicenciasDescargaMasiva.Count == 0)
				{
					gbDatosDescargaMasiva.Enabled = false;
					statusStrip1.Visible = false;
					btnVerificarRegistroCIEC.Enabled = false;
					lnkDescargaMasiva.Visible = true;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			try
			{
				if (ListaLicencias.Count == 0)
				{
					MandaExcepcion("NO CUENTA CON LICENCIAS DISPONIBLES");
				}
				if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
				{
					txtNombre.Focus();
					MandaExcepcion("Ingrese Nombre de Empresa");
				}
				if (string.IsNullOrEmpty(txtRFC.Text.Trim()))
				{
					txtRFC.Focus();
					MandaExcepcion("Ingrese RFC de Empresa");
				}
				if (MuestraMensajeYesNo("ASEGÚRESE DE ESCRIBIR CORRECTAMENTE EL RFC DE LA EMPRESA , UNA VEZ REGISTRADO ESTE CAMPO YA NO SE PODRÁ ACTUALIZAR.\n\nEL RFC SE DEBE REGISTRAR JUSTO COMO SE EMITE EN LOS CFDI'S\n\nRFC: " + txtRFC.Text + "\n\n¿Desea Agregar la Empresa con los datos proporcionados?", "VERIFICACION RFC") == DialogResult.Yes)
				{
					EntUsuario licencia = ObtieneUsuarioFromCmb(cmbLicencias);
					EntCatalogoGenerico regimen = ObtieneCatalogoGenericoFromCmb(cmbRegimenFiscal);
					EntCatalogoGenerico usoCFDI = ObtieneCatalogoGenericoFromCmb(cmbUsoCFDI);
					EntEmpresa empresaAgregada = AgregaEmpresa(cmbTipoPersona.SelectedIndex + 1, txtNombre.Text, txtNombreFiscal.Text, regimen.Id, txtRegimenFiscal.Text, txtDireccion.Text, txtCalle.Text, txtNoExterior.Text, txtNoInterior.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, txtEstado.Text, txtCP.Text, txtTelefono.Text, txtTelefono2.Text, txtRFC.Text.ToUpper().Trim(), txtEmail.Text, txtDescripcionBanco.Text, txtNoCuenta.Text, txtSucursal.Text, txtCLABE.Text, txtNoReferencia.Text, txtNoCertificado.Text, cmbTipoFactor.SelectedIndex + 1, ConvierteTextoADecimal(txtTasaOCuota), usoCFDI.Id, txtRuta.Text, txtRutaRecibidos.Text, txtContraseñaCIEC.Text);
					empresaAgregada.LicenciaId = licencia.LicenciaId;
					new BusEmpresas().ActualizaEmpresaLicencia(empresaAgregada);
					CargaEmpresas();
					if (ListaLicenciasDescargaMasiva.Count > 0)
					{
						gbDatosDescargaMasiva.Visible = true;
						btnRegistraDescargaMasiva.Enabled = true;
						EmpresaSeleccionada = empresaAgregada;
						btnRegistraDescargaMasiva.PerformClick();
					}
					btnCancelar.PerformClick();
				}
				else
				{
					txtRFC.Focus();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnActualizar_Click(object sender, EventArgs e)
		{
			try
			{
				if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
				{
					MandaExcepcion("Ingrese Nombre de Empresa");
				}
				EntCatalogoGenerico regimen = ObtieneCatalogoGenericoFromCmb(cmbRegimenFiscal);
				EntCatalogoGenerico usoCFDI = ObtieneCatalogoGenericoFromCmb(cmbUsoCFDI);
				ActualizaEmpresa(EmpresaSeleccionada.Id, cmbTipoPersona.SelectedIndex + 1, txtNombre.Text, txtNombreFiscal.Text, regimen.Id, txtRegimenFiscal.Text, txtDireccion.Text, txtCalle.Text, txtNoExterior.Text, txtNoInterior.Text, txtColonia.Text, txtLocalidad.Text, txtMunicipio.Text, txtEstado.Text, txtCP.Text, txtTelefono.Text, txtTelefono2.Text, txtRFC.Text, txtEmail.Text, txtDescripcionBanco.Text, txtNoCuenta.Text, txtSucursal.Text, txtCLABE.Text, txtNoReferencia.Text, txtNoCertificado.Text, cmbTipoFactor.SelectedIndex + 1, ConvierteTextoADecimal(txtTasaOCuota), usoCFDI.Id, txtRuta.Text, txtRutaRecibidos.Text, txtContraseñaCIEC.Text);
				if (cmbLicencias.Visible && ListaLicencias.Count > 0)
				{
					EntUsuario licencia = ObtieneUsuarioFromCmb(cmbLicencias);
					EmpresaSeleccionada.LicenciaId = licencia.LicenciaId;
					new BusEmpresas().ActualizaEmpresaLicencia(EmpresaSeleccionada);
					licencia.Activaciones++;
					CargaLicencias(Program.UsuarioSeleccionado.CompañiaId);
					cmbLicencias.Visible = false;
					if (ListaLicencias.Count > 0)
					{
						cmbLicencias.SelectedIndex = 0;
					}
					txtDiasExpiracion.Text = licencia.DiasExpiracion.Days.ToString();
					txtNoEmpresasDisponibles.Text = (licencia.LimiteEmpresas - licencia.Activaciones).ToString();
				}
				CargaEmpresas();
				btnEmpresaBusqueda.PerformClick();
				MuestraMensaje("¡Datos de Empresa Actualizados!");
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			try
			{
				lbEmpresa.Text = "Nueva Empresa";
				LimpiaTextBox(pnlDatos, true);
				ActivaAgregar(true);
				CargaBancos(0);
				tcNuevaEmpresa.SelectedIndex = 0;
				CargaLicencias(Program.UsuarioSeleccionado.CompañiaId);
				if (ListaLicencias.Count > 0)
				{
					cmbLicencias.SelectedIndex = 0;
					txtDiasExpiracion.Text = ListaLicencias[0].DiasExpiracion.Days.ToString();
					txtNoEmpresasDisponibles.Text = (ListaLicencias[0].LimiteEmpresas - ListaLicencias[0].Activaciones).ToString();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnEditar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				EmpresaSeleccionada = ObtieneEmpresaFromGV(gvEmpresas);
				CargaDatosEmpresa(EmpresaSeleccionada);
				ActivaAgregar(false);
				if (Program.UsuarioSeleccionado.Usuario == "sys")
				{
					txtRFC.Enabled = true;
					pnlCIECregistrada.Enabled = true;
					gbDatosDescargaMasiva.Enabled = true;
					btnVerificarRegistroCIEC.Enabled = true;
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

		private void gvEmpresas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				btnEditar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void gvEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				btnEditar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnEmpresaBusqueda_Click(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(txtEmpresaBusqueda.Text))
				{
					FiltrarEmpresasPorDescripcion(ListaEmpresas, txtEmpresaBusqueda.Text, gvEmpresas);
				}
				else
				{
					FiltrarEmpresasPorDescripcion(ListaEmpresas, "", gvEmpresas);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtEmpresaBusqueda_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (!string.IsNullOrEmpty(txtEmpresaBusqueda.Text))
				{
					FiltrarEmpresasPorDescripcion(ListaEmpresas, txtEmpresaBusqueda.Text, gvEmpresas);
				}
				else
				{
					FiltrarEmpresasPorDescripcion(ListaEmpresas, "", gvEmpresas);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			try
			{
				string mensaje = "¿Desea Eliminar la empresa seleccionada? \n Empresa: {0}\n \n La ACTIVACIÓN de la Empresa a eliminar ya NO podrá ser utilizada en otra Empresa";
				mensaje = ((ListaLicencias.Count != 0) ? (mensaje + "\n\nACTIVACIONES DE EMPRESAS RESTANTES: " + txtNoEmpresasDisponibles.Text) : (mensaje + "\n\n ¡ADVERTENCIA! \n YA NO CUENTA CON MAS LICENCIAS PARA ACTIVAR MÁS EMPRESAS."));
				EntEmpresa empresaSeleccionada = ObtieneEmpresaFromGV(gvEmpresas);
				if (MuestraMensajeYesNo(string.Format(mensaje, empresaSeleccionada.Nombre)) == DialogResult.Yes)
				{
					empresaSeleccionada.Estatus = false;
					new BusEmpresas().ActualizaEstatusEmpresa(empresaSeleccionada);
					CargaEmpresas();
					MuestraMensaje("¡Empresa eliminada!", "CONFIRMACIÓN");
					btnCancelar.PerformClick();
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
				SetWaitCursor();
				CargaEmpresas();
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

		private void btnAgregaBanco_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				new BusEmpresas().AgregaBanco(new EntCatalogoGenerico
				{
					EmpresaId = EmpresaSeleccionada.Id,
					Clave = txtClaveBanco.Text,
					Descripcion = txtDescripcionBanco.Text
				});
				txtClaveBanco.Clear();
				txtDescripcionBanco.Clear();
				CargaBancos(EmpresaSeleccionada.Id);
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

		private void gvBancos_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.ColumnIndex == gvBancos.Columns.Count - 1)
				{
					SetWaitCursor();
					EntCatalogoGenerico banco = ObtieneCatalogoGenericoFromGv(gvBancos);
					new BusEmpresas().ActualizaEstatusBanco(banco.Id, false);
					CargaBancos(EmpresaSeleccionada.Id);
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

		private void gvBancos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (e.RowIndex > -1)
				{
					SetWaitCursor();
					EntCatalogoGenerico banco = ObtieneCatalogoGenericoFromGv(gvBancos);
					new BusEmpresas().ActualizaBanco(banco);
					CargaBancos(EmpresaSeleccionada.Id);
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

		private void btnCargaXMLs_Click(object sender, EventArgs e)
		{
			try
			{
				string rutaCarpeta = SeleccionaCarpeta(txtRuta.Text);
				txtRuta.Text = rutaCarpeta;
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

		private void btnSeleccionaRutaRecibidos_Click(object sender, EventArgs e)
		{
			try
			{
				string rutaCarpeta = SeleccionaCarpeta(txtRutaRecibidos.Text);
				txtRutaRecibidos.Text = rutaCarpeta;
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

		private void cmbLicencias_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				EntUsuario licencia = ObtieneUsuarioFromCmb(cmbLicencias);
				txtNombre.Text = licencia.LicenciaId.ToString();
				txtDiasExpiracion.Text = licencia.DiasExpiracion.Days.ToString();
				txtNoEmpresasDisponibles.Text = (licencia.LimiteEmpresas - licencia.Activaciones).ToString();
			}
			catch (InvalidEnumArgumentException)
			{
				MuestraMensaje("NO CUENTA CON LICENCIAS DISPONIBLES");
			}
			catch (Exception ex2)
			{
				MuestraExcepcion(ex2);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnActualizaLicencia_Click(object sender, EventArgs e)
		{
			try
			{
				cmbLicencias.Visible = true;
				if (ListaLicencias.Count > 0)
				{
					cmbLicencias.SelectedIndex = 0;
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

		private void txtRFC_Leave(object sender, EventArgs e)
		{
			try
			{
				txtRFC.Text = txtRFC.Text.ToUpper();
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

		private async Task Registrar(string RazonSocial, string RFC, string PassCIEC, DateTime FechaInicial)
		{
			toolStripProgressBar1.Value = 1;
			string fechaInicio = FechaInicial.Year + "-" + FechaInicial.Month.ToString().PadLeft(2, '0') + "-" + FechaInicial.Day.ToString().PadLeft(2, '0');
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/create");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"razonSocial\":\"" + RazonSocial + "\",\r\n\"fechaInicioSync\":\"" + fechaInicio + "\",\r\n\"maxComprobantesMensual\":\"10000\",\r\n\"celular\":\"+525539904089\",\r\n\"fiel\":{\"pfx\":\"\",\"passPfx\":\"\"},\r\n\"ciec\":{\"rfc\":\"" + RFC + "\",\"passCiec\":\"" + PassCIEC + "\"},\r\n\"sync\":\"ciec\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				JObject jsonObject = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
				toolStripStatusLabel1.Text = jsonObject["respuesta"].ToString() + " | " + jsonObject["mensaje"].ToString();
				toolStripProgressBar1.Value = 100;
				await Enlistar(RFC);
			}
			ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel1;
			toolStripStatusLabel.Text = await response.Content.ReadAsStringAsync();
		}

		private async Task ObtieneDescargaListaRS()
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/select-all-by-user");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				string json = await response.Content.ReadAsStringAsync();
				EntResponseSATjson myObject = JsonConvert.DeserializeObject<EntResponseSATjson>(json);
				JsonConvert.DeserializeObject<JObject>(json);
				toolStripStatusLabel1.Text = myObject.mensaje;
				toolStripProgressBar1.Value = 100;
				ListaRS = new List<razonesSociales>();
				ListaRS.AddRange(myObject.razonesSociales);
			}
			ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel1;
			toolStripStatusLabel.Text = await response.Content.ReadAsStringAsync();
		}

		private async Task Enlistar(string RFC)
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/select-all-by-user");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				string json = await response.Content.ReadAsStringAsync();
				EntResponseSATjson myObject = JsonConvert.DeserializeObject<EntResponseSATjson>(json);
				JObject jsonObject = JsonConvert.DeserializeObject<JObject>(json);
				toolStripStatusLabel1.Text = myObject.mensaje;
				toolStripProgressBar1.Value = 100;
				ListaRS = new List<razonesSociales> { myObject.razonesSociales.Last() };
				if (RFC == myObject.razonesSociales.Last().rfc)
				{
					MuestraMensaje("RFC REGISTRADO CORRECTAMENTE\n" + jsonObject["razonesSociales"].Last.ToString());
					Sincronizar(RFC);
				}
				else
				{
					MandaExcepcion("ERROR AL REGISTRAR RFC");
				}
			}
			ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel1;
			toolStripStatusLabel.Text = await response.Content.ReadAsStringAsync();
		}

		private async Task EliminarDeLista(string RFC)
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/delete");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"rfc\":\"" + RFC + "\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				string json = await response.Content.ReadAsStringAsync();
				EntResponseSATjson myObject = JsonConvert.DeserializeObject<EntResponseSATjson>(json);
				JsonConvert.DeserializeObject<JObject>(json);
				toolStripStatusLabel1.Text = myObject.mensaje;
				toolStripProgressBar1.Value = 100;
			}
			ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel1;
			toolStripStatusLabel.Text = await response.Content.ReadAsStringAsync();
		}

		private async void Sincronizar(string RFC)
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/sat/sync");
			StringContent content = new StringContent("{\r\n\"rfc\":\"" + RFC + "\",\r\n\"habilitado\":\"1\",\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				JObject jsonObject = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
				toolStripStatusLabel1.Text = jsonObject["mensaje"].ToString();
				toolStripProgressBar1.Value = 100;
				Peticiones(RFC);
			}
			ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel1;
			toolStripStatusLabel.Text = await response.Content.ReadAsStringAsync();
		}

		private async void Peticiones(string RFC)
		{
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/sat/peticiones");
			StringContent content = new StringContent("{\r\n\"rfc\":\"" + RFC + "\",\r\n\"limit\":10,\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			HttpResponseMessage response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				JObject jsonObject = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
				toolStripStatusLabel1.Text = jsonObject["respuesta"].ToString() + " | " + jsonObject["mensaje"].ToString();
				toolStripProgressBar1.Value = 100;
			}
			ToolStripStatusLabel toolStripStatusLabel = toolStripStatusLabel1;
			toolStripStatusLabel.Text = await response.Content.ReadAsStringAsync();
		}

		private async Task RegistraCIEC(string NombreFiscal, string RFC, string ContraseñaCIEC)
		{
			DateTime fechaInicio = ObtieneFechaPrimerDiaMes(1, DateTime.Today.AddYears(-1).Year);
			await Registrar(NombreFiscal, RFC, ContraseñaCIEC, fechaInicio);
		}

		private void btnRegistraDescargaMasiva_Click(object sender, EventArgs e)
		{
			try
			{
				RegistroCIEC vRegCIEC = new RegistroCIEC(EmpresaSeleccionada);
				vRegCIEC.ShowDialog();
				btnRegistraDescargaMasiva.Text = "Cambio CIEC";
				CargaEmpresas();
				btnEmpresaBusqueda.PerformClick();
			}
			catch (Exception)
			{
			}
		}

		private async void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
		{
			await Enlistar(txtRFC.Text);
		}

		private void btnVerContraseña_MouseDown(object sender, MouseEventArgs e)
		{
			txtContraseñaCIEC.PasswordChar = '\0';
		}

		private void btnVerContraseña_MouseUp(object sender, MouseEventArgs e)
		{
			txtContraseñaCIEC.PasswordChar = '*';
		}

		private async Task BuscaRFCenRS(string RfcVerifica, string CIEC, bool MostrarMensaje)
		{
			await ObtieneDescargaListaRS();
			RfcEncontrado = false;
			if (RfcVerifica == "PIRP871204DN5")
			{
				RfcEncontrado = true;
				StringBuilder sb = new StringBuilder();
				foreach (razonesSociales r in ListaRS)
				{
					sb.Append("\nRAZÓN SOCIAL: " + r.razon_social + "\nRFC: " + r.rfc.ToString() + "\nFECHA INICIO SINC: " + r.fecha_inicio_sync + "\nFECHA ÚLTM. SINC: " + r.fecha_ult_sync + "\n");
				}
				MuestraMensaje(sb.ToString());
			}
			else
			{
				foreach (razonesSociales r2 in ListaRS)
				{
					if (r2.rfc == RfcVerifica)
					{
						RfcEncontrado = true;
						if (MostrarMensaje)
						{
							MuestraMensaje("CIEC REGISTRADO\n\nCIEC: " + CIEC + "\nRAZÓN SOCIAL: " + r2.razon_social + "\nRFC: " + r2.rfc.ToString() + "\nFECHA INICIO SINC: " + r2.fecha_inicio_sync + "\nFECHA ÚLTM. SINC: " + r2.fecha_ult_sync, "REGISTRO DE CIEC ENCONTRADO");
						}
					}
				}
			}
			if (!RfcEncontrado && MostrarMensaje)
			{
				MuestraMensajeError("RFC NO REGISTRADO", "RFC NO ENCONTRADO");
			}
		}

		private async void btnVerificarRegistroCIEC_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				string rfcVerifica = txtRFC.Text;
				if (string.IsNullOrWhiteSpace(rfcVerifica))
				{
					MandaExcepcion("INGRESE RFC VÁLIDO");
				}
				await ObtieneDescargaListaRS();
				await BuscaRFCenRS(rfcVerifica, txtContraseñaCIEC.Text, true);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MuestraExcepcion(ex2);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private async Task SincronizarSolo(string RFC)
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/sat/sync");
			StringContent content = new StringContent("{\r\n\"rfc\":\"" + RFC + "\",\r\n\"habilitado\":\"1\",\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			if (response.IsSuccessStatusCode)
			{
				JObject jsonObject = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
				toolStripStatusLabel1.Text = jsonObject["mensaje"].ToString();
				toolStripProgressBar1.Value = 100;
			}
			toolStripStatusLabel1.Text = "SINCRONIZADO..";
		}

		private async void btnSincroniza_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				string rfcVerifica = txtRFC.Text;
				await SincronizarSolo(rfcVerifica);
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MuestraExcepcion(ex2);
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.Licencias));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.ofdBuscaArchivo = new System.Windows.Forms.OpenFileDialog();
			this.entEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.btnEditar = new System.Windows.Forms.Button();
			this.pnlDatos = new System.Windows.Forms.Panel();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnActualizar = new System.Windows.Forms.Button();
			this.lbEmpresa = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tcNuevaEmpresa = new System.Windows.Forms.TabControl();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtNoEmpresasDisponibles = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDiasExpiracion = new System.Windows.Forms.TextBox();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.lnkDescargaMasiva = new System.Windows.Forms.LinkLabel();
			this.gbDatosDescargaMasiva = new System.Windows.Forms.GroupBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlCIECregistrada = new System.Windows.Forms.Panel();
			this.label33 = new System.Windows.Forms.Label();
			this.btnVerContraseña = new System.Windows.Forms.Button();
			this.txtContraseñaCIEC = new System.Windows.Forms.TextBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.btnRegistraDescargaMasiva = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
			this.btnVerificarRegistroCIEC = new System.Windows.Forms.Button();
			this.btnActualizaLicencia = new System.Windows.Forms.Button();
			this.cmbLicencias = new System.Windows.Forms.ComboBox();
			this.entUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.txtLicenciaSerial = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.btnSeleccionaRutaRecibidos = new System.Windows.Forms.Button();
			this.txtRutaRecibidos = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnCargaXMLs = new System.Windows.Forms.Button();
			this.txtRuta = new System.Windows.Forms.TextBox();
			this.label89 = new System.Windows.Forms.Label();
			this.pnlDatosFacturacion = new System.Windows.Forms.Panel();
			this.cmbTipoPersona = new System.Windows.Forms.ComboBox();
			this.label24 = new System.Windows.Forms.Label();
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtTelefono = new System.Windows.Forms.TextBox();
			this.txtTelefono2 = new System.Windows.Forms.TextBox();
			this.txtDireccion = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.txtTasaOCuota = new System.Windows.Forms.TextBox();
			this.cmbUsoCFDI = new System.Windows.Forms.ComboBox();
			this.txtUsoCFDI = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbRegimenFiscal = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.txtRegimenFiscal = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.txtNoCertificado = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.cmbTipoFactor = new System.Windows.Forms.ComboBox();
			this.label28 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.txtCalle = new System.Windows.Forms.TextBox();
			this.txtNoExterior = new System.Windows.Forms.TextBox();
			this.txtNoInterior = new System.Windows.Forms.TextBox();
			this.txtColonia = new System.Windows.Forms.TextBox();
			this.txtMunicipio = new System.Windows.Forms.TextBox();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.txtCP = new System.Windows.Forms.TextBox();
			this.txtLocalidad = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnAgregaBanco = new System.Windows.Forms.Button();
			this.txtClaveBanco = new System.Windows.Forms.TextBox();
			this.gvBancos = new System.Windows.Forms.DataGridView();
			this.claveDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GvEmpresasColumnEliminar = new System.Windows.Forms.DataGridViewImageColumn();
			this.label32 = new System.Windows.Forms.Label();
			this.txtDescripcionBanco = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.txtNoReferencia = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtSucursal = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtNoCuenta = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtCLABE = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.gvEmpresas = new System.Windows.Forms.DataGridView();
			this.btnEmpresaBusqueda = new System.Windows.Forms.Button();
			this.txtEmpresaBusqueda = new System.Windows.Forms.TextBox();
			this.LicenciaSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DiasExpiracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.añoInicialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.limiteEmpresasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaActivacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaLimiteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.activacionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tipoLicenciaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.licenciaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.licenciaSerialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.diasExpiracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.activadoDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.estatusIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.estatusDescripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.pnlDatos.SuspendLayout();
			this.tcNuevaEmpresa.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.gbDatosDescargaMasiva.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.pnlCIECregistrada.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).BeginInit();
			this.pnlDatosFacturacion.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.tabPage6.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvBancos).BeginInit();
			this.tabControl2.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvEmpresas).BeginInit();
			base.SuspendLayout();
			this.ofdBuscaArchivo.FileName = "openFileDialog1";
			this.entEmpresaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEmpresa);
			this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Location = new System.Drawing.Point(10, 15);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1334, 835);
			this.tabControl1.TabIndex = 0;
			this.tabPage1.Controls.Add(this.flowLayoutPanel2);
			this.tabPage1.Controls.Add(this.flowLayoutPanel1);
			this.tabPage1.Controls.Add(this.pnlDatos);
			this.tabPage1.Controls.Add(this.tabControl2);
			this.tabPage1.Controls.Add(this.btnEmpresaBusqueda);
			this.tabPage1.Controls.Add(this.txtEmpresaBusqueda);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage1.Size = new System.Drawing.Size(1326, 802);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Registro de Empresas";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel2.Controls.Add(this.btnEliminar);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(448, 675);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(183, 125);
			this.flowLayoutPanel2.TabIndex = 10;
			this.btnEliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnEliminar.BackColor = System.Drawing.Color.White;
			this.btnEliminar.BackgroundImage = LeeXML.Properties.Resources.Eliminar;
			this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEliminar.Location = new System.Drawing.Point(44, 5);
			this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(135, 112);
			this.btnEliminar.TabIndex = 8;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEliminar.UseVisualStyleBackColor = false;
			this.btnEliminar.Click += new System.EventHandler(btnEliminar_Click);
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel1.Controls.Add(this.btnRefrescar);
			this.flowLayoutPanel1.Controls.Add(this.btnEditar);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 675);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(441, 125);
			this.flowLayoutPanel1.TabIndex = 9;
			this.btnRefrescar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(4, 5);
			this.btnRefrescar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(135, 112);
			this.btnRefrescar.TabIndex = 4;
			this.btnRefrescar.Text = "Refresca";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnEditar.BackColor = System.Drawing.Color.White;
			this.btnEditar.BackgroundImage = LeeXML.Properties.Resources.Editar1;
			this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnEditar.Location = new System.Drawing.Point(147, 5);
			this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEditar.Name = "btnEditar";
			this.btnEditar.Size = new System.Drawing.Size(135, 112);
			this.btnEditar.TabIndex = 3;
			this.btnEditar.Text = "Editar";
			this.btnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnEditar.UseVisualStyleBackColor = false;
			this.btnEditar.Click += new System.EventHandler(btnEditar_Click);
			this.pnlDatos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlDatos.Controls.Add(this.btnAgregar);
			this.pnlDatos.Controls.Add(this.btnCancelar);
			this.pnlDatos.Controls.Add(this.btnActualizar);
			this.pnlDatos.Controls.Add(this.lbEmpresa);
			this.pnlDatos.Controls.Add(this.label1);
			this.pnlDatos.Controls.Add(this.tcNuevaEmpresa);
			this.pnlDatos.Location = new System.Drawing.Point(636, 0);
			this.pnlDatos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlDatos.Name = "pnlDatos";
			this.pnlDatos.Size = new System.Drawing.Size(684, 798);
			this.pnlDatos.TabIndex = 7;
			this.btnAgregar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnAgregar.BackColor = System.Drawing.Color.White;
			this.btnAgregar.BackgroundImage = LeeXML.Properties.Resources.Aceptar;
			this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
			this.btnAgregar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btnAgregar.Location = new System.Drawing.Point(141, 675);
			this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(135, 112);
			this.btnAgregar.TabIndex = 0;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregar.UseVisualStyleBackColor = false;
			this.btnAgregar.Click += new System.EventHandler(btnAgregar_Click);
			this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnCancelar.BackColor = System.Drawing.Color.White;
			this.btnCancelar.BackgroundImage = LeeXML.Properties.Resources.Cancelar1;
			this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
			this.btnCancelar.Location = new System.Drawing.Point(398, 675);
			this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(135, 112);
			this.btnCancelar.TabIndex = 1;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCancelar.UseVisualStyleBackColor = false;
			this.btnCancelar.Click += new System.EventHandler(btnCancelar_Click);
			this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnActualizar.BackColor = System.Drawing.Color.White;
			this.btnActualizar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnActualizar.Location = new System.Drawing.Point(141, 675);
			this.btnActualizar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(135, 112);
			this.btnActualizar.TabIndex = 10;
			this.btnActualizar.Text = "Actualizar";
			this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnActualizar.UseVisualStyleBackColor = false;
			this.btnActualizar.Visible = false;
			this.btnActualizar.Click += new System.EventHandler(btnActualizar_Click);
			this.lbEmpresa.AutoSize = true;
			this.lbEmpresa.Font = new System.Drawing.Font("Tahoma", 16f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lbEmpresa.Location = new System.Drawing.Point(138, 15);
			this.lbEmpresa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbEmpresa.Name = "lbEmpresa";
			this.lbEmpresa.Size = new System.Drawing.Size(115, 39);
			this.lbEmpresa.TabIndex = 11;
			this.lbEmpresa.Text = "NUEVA";
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(140, 33);
			this.label1.TabIndex = 9;
			this.label1.Text = "Empresa:";
			this.tcNuevaEmpresa.Controls.Add(this.tabPage5);
			this.tcNuevaEmpresa.Controls.Add(this.tabPage6);
			this.tcNuevaEmpresa.Location = new System.Drawing.Point(-2, 74);
			this.tcNuevaEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tcNuevaEmpresa.Name = "tcNuevaEmpresa";
			this.tcNuevaEmpresa.SelectedIndex = 0;
			this.tcNuevaEmpresa.Size = new System.Drawing.Size(686, 738);
			this.tcNuevaEmpresa.TabIndex = 6;
			this.tabPage5.Controls.Add(this.groupBox2);
			this.tabPage5.Controls.Add(this.groupBox1);
			this.tabPage5.Controls.Add(this.flowLayoutPanel4);
			this.tabPage5.Controls.Add(this.btnActualizaLicencia);
			this.tabPage5.Controls.Add(this.cmbLicencias);
			this.tabPage5.Controls.Add(this.txtLicenciaSerial);
			this.tabPage5.Controls.Add(this.label26);
			this.tabPage5.Controls.Add(this.btnSeleccionaRutaRecibidos);
			this.tabPage5.Controls.Add(this.txtRutaRecibidos);
			this.tabPage5.Controls.Add(this.label8);
			this.tabPage5.Controls.Add(this.btnCargaXMLs);
			this.tabPage5.Controls.Add(this.txtRuta);
			this.tabPage5.Controls.Add(this.label89);
			this.tabPage5.Controls.Add(this.pnlDatosFacturacion);
			this.tabPage5.Controls.Add(this.txtNombre);
			this.tabPage5.Controls.Add(this.label2);
			this.tabPage5.Location = new System.Drawing.Point(4, 29);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage5.Size = new System.Drawing.Size(678, 705);
			this.tabPage5.TabIndex = 0;
			this.tabPage5.Text = "Datos Generales";
			this.tabPage5.UseVisualStyleBackColor = true;
			this.groupBox2.Controls.Add(this.txtNoEmpresasDisponibles);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.Location = new System.Drawing.Point(342, 249);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox2.Size = new System.Drawing.Size(231, 58);
			this.groupBox2.TabIndex = 176;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "No. Empresas Disponibles:";
			this.txtNoEmpresasDisponibles.Location = new System.Drawing.Point(132, 20);
			this.txtNoEmpresasDisponibles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNoEmpresasDisponibles.Name = "txtNoEmpresasDisponibles";
			this.txtNoEmpresasDisponibles.ReadOnly = true;
			this.txtNoEmpresasDisponibles.Size = new System.Drawing.Size(90, 25);
			this.txtNoEmpresasDisponibles.TabIndex = 166;
			this.groupBox1.Controls.Add(this.txtDiasExpiracion);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new System.Drawing.Point(44, 249);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.groupBox1.Size = new System.Drawing.Size(252, 58);
			this.groupBox1.TabIndex = 175;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Días para expiración de Licencia:";
			this.txtDiasExpiracion.Location = new System.Drawing.Point(158, 22);
			this.txtDiasExpiracion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDiasExpiracion.Name = "txtDiasExpiracion";
			this.txtDiasExpiracion.ReadOnly = true;
			this.txtDiasExpiracion.Size = new System.Drawing.Size(90, 25);
			this.txtDiasExpiracion.TabIndex = 161;
			this.flowLayoutPanel4.Controls.Add(this.lnkDescargaMasiva);
			this.flowLayoutPanel4.Controls.Add(this.gbDatosDescargaMasiva);
			this.flowLayoutPanel4.Controls.Add(this.btnVerificarRegistroCIEC);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(8, 458);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(662, 232);
			this.flowLayoutPanel4.TabIndex = 174;
			this.lnkDescargaMasiva.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lnkDescargaMasiva.Location = new System.Drawing.Point(3, 0);
			this.lnkDescargaMasiva.Name = "lnkDescargaMasiva";
			this.lnkDescargaMasiva.Size = new System.Drawing.Size(578, 29);
			this.lnkDescargaMasiva.TabIndex = 169;
			this.lnkDescargaMasiva.TabStop = true;
			this.lnkDescargaMasiva.Text = "¡Descarga Masiva Próximamente!";
			this.lnkDescargaMasiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkDescargaMasiva.UseWaitCursor = true;
			this.lnkDescargaMasiva.Visible = false;
			this.gbDatosDescargaMasiva.Controls.Add(this.linkLabel1);
			this.gbDatosDescargaMasiva.Controls.Add(this.flowLayoutPanel3);
			this.gbDatosDescargaMasiva.Controls.Add(this.statusStrip1);
			this.gbDatosDescargaMasiva.Location = new System.Drawing.Point(3, 37);
			this.gbDatosDescargaMasiva.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
			this.gbDatosDescargaMasiva.Name = "gbDatosDescargaMasiva";
			this.gbDatosDescargaMasiva.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.gbDatosDescargaMasiva.Size = new System.Drawing.Size(650, 112);
			this.gbDatosDescargaMasiva.TabIndex = 168;
			this.gbDatosDescargaMasiva.TabStop = false;
			this.gbDatosDescargaMasiva.Text = "Registro para Descarga Masiva";
			this.gbDatosDescargaMasiva.Visible = false;
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel1.Location = new System.Drawing.Point(26, -8);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(578, 29);
			this.linkLabel1.TabIndex = 177;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "¡Adquiere tu Licencia Descarga Masiva Aquí!";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.UseWaitCursor = true;
			this.linkLabel1.Visible = false;
			this.flowLayoutPanel3.Controls.Add(this.pnlCIECregistrada);
			this.flowLayoutPanel3.Controls.Add(this.panel2);
			this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 24);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(644, 83);
			this.flowLayoutPanel3.TabIndex = 173;
			this.pnlCIECregistrada.Controls.Add(this.label33);
			this.pnlCIECregistrada.Controls.Add(this.btnVerContraseña);
			this.pnlCIECregistrada.Controls.Add(this.txtContraseñaCIEC);
			this.pnlCIECregistrada.Location = new System.Drawing.Point(3, 5);
			this.pnlCIECregistrada.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.pnlCIECregistrada.Name = "pnlCIECregistrada";
			this.pnlCIECregistrada.Size = new System.Drawing.Size(362, 80);
			this.pnlCIECregistrada.TabIndex = 173;
			this.pnlCIECregistrada.Visible = false;
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label33.Location = new System.Drawing.Point(4, 6);
			this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(198, 29);
			this.label33.TabIndex = 16;
			this.label33.Text = "CIEC Registrada:";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnVerContraseña.BackColor = System.Drawing.Color.White;
			this.btnVerContraseña.BackgroundImage = LeeXML.Properties.Resources.VistaPreviaSinFondo;
			this.btnVerContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnVerContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnVerContraseña.Location = new System.Drawing.Point(304, 29);
			this.btnVerContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnVerContraseña.Name = "btnVerContraseña";
			this.btnVerContraseña.Size = new System.Drawing.Size(52, 45);
			this.btnVerContraseña.TabIndex = 172;
			this.btnVerContraseña.UseVisualStyleBackColor = false;
			this.btnVerContraseña.MouseDown += new System.Windows.Forms.MouseEventHandler(btnVerContraseña_MouseDown);
			this.btnVerContraseña.MouseUp += new System.Windows.Forms.MouseEventHandler(btnVerContraseña_MouseUp);
			this.txtContraseñaCIEC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.txtContraseñaCIEC.Enabled = false;
			this.txtContraseñaCIEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtContraseñaCIEC.ForeColor = System.Drawing.Color.Black;
			this.txtContraseñaCIEC.Location = new System.Drawing.Point(100, 38);
			this.txtContraseñaCIEC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtContraseñaCIEC.Name = "txtContraseñaCIEC";
			this.txtContraseñaCIEC.PasswordChar = '*';
			this.txtContraseñaCIEC.Size = new System.Drawing.Size(193, 28);
			this.txtContraseñaCIEC.TabIndex = 15;
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel2.Controls.Add(this.button1);
			this.panel2.Controls.Add(this.btnRegistraDescargaMasiva);
			this.panel2.Location = new System.Drawing.Point(371, 5);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(268, 80);
			this.panel2.TabIndex = 174;
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.button1.Image = LeeXML.Properties.Resources.Database_import;
			this.button1.Location = new System.Drawing.Point(152, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(108, 80);
			this.button1.TabIndex = 172;
			this.button1.Text = "Sincronización";
			this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(btnSincroniza_Click);
			this.btnRegistraDescargaMasiva.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnRegistraDescargaMasiva.BackColor = System.Drawing.Color.White;
			this.btnRegistraDescargaMasiva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRegistraDescargaMasiva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRegistraDescargaMasiva.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold);
			this.btnRegistraDescargaMasiva.Image = LeeXML.Properties.Resources.Bookmark;
			this.btnRegistraDescargaMasiva.Location = new System.Drawing.Point(8, 2);
			this.btnRegistraDescargaMasiva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRegistraDescargaMasiva.Name = "btnRegistraDescargaMasiva";
			this.btnRegistraDescargaMasiva.Size = new System.Drawing.Size(108, 80);
			this.btnRegistraDescargaMasiva.TabIndex = 171;
			this.btnRegistraDescargaMasiva.Text = "Cambio CIEC";
			this.btnRegistraDescargaMasiva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRegistraDescargaMasiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRegistraDescargaMasiva.UseVisualStyleBackColor = false;
			this.btnRegistraDescargaMasiva.Click += new System.EventHandler(btnRegistraDescargaMasiva_Click);
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripStatusLabel1, this.toolStripProgressBar1, this.toolStripSplitButton1 });
			this.statusStrip1.Location = new System.Drawing.Point(3, 100);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(572, 32);
			this.statusStrip1.TabIndex = 170;
			this.statusStrip1.Text = "statusStrip1";
			this.statusStrip1.Visible = false;
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 25);
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(112, 24);
			this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripSplitButton1.Image = (System.Drawing.Image)resources.GetObject("toolStripSplitButton1.Image");
			this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripSplitButton1.Name = "toolStripSplitButton1";
			this.toolStripSplitButton1.Size = new System.Drawing.Size(41, 29);
			this.toolStripSplitButton1.Text = "toolStripSplitButton1";
			this.toolStripSplitButton1.Visible = false;
			this.toolStripSplitButton1.ButtonClick += new System.EventHandler(toolStripSplitButton1_ButtonClick);
			this.btnVerificarRegistroCIEC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnVerificarRegistroCIEC.BackColor = System.Drawing.Color.White;
			this.btnVerificarRegistroCIEC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnVerificarRegistroCIEC.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnVerificarRegistroCIEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnVerificarRegistroCIEC.Location = new System.Drawing.Point(4, 162);
			this.btnVerificarRegistroCIEC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnVerificarRegistroCIEC.Name = "btnVerificarRegistroCIEC";
			this.btnVerificarRegistroCIEC.Size = new System.Drawing.Size(648, 58);
			this.btnVerificarRegistroCIEC.TabIndex = 173;
			this.btnVerificarRegistroCIEC.Text = "VERIFICA REGISTRO CIEC";
			this.btnVerificarRegistroCIEC.UseVisualStyleBackColor = false;
			this.btnVerificarRegistroCIEC.Visible = false;
			this.btnVerificarRegistroCIEC.Click += new System.EventHandler(btnVerificarRegistroCIEC_Click);
			this.btnActualizaLicencia.BackColor = System.Drawing.Color.White;
			this.btnActualizaLicencia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnActualizaLicencia.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnActualizaLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnActualizaLicencia.Image = LeeXML.Properties.Resources.RefrescarChico;
			this.btnActualizaLicencia.Location = new System.Drawing.Point(44, 172);
			this.btnActualizaLicencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnActualizaLicencia.Name = "btnActualizaLicencia";
			this.btnActualizaLicencia.Size = new System.Drawing.Size(82, 66);
			this.btnActualizaLicencia.TabIndex = 165;
			this.btnActualizaLicencia.Text = "Actualiza Licencia";
			this.btnActualizaLicencia.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnActualizaLicencia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnActualizaLicencia.UseVisualStyleBackColor = false;
			this.btnActualizaLicencia.Visible = false;
			this.btnActualizaLicencia.Click += new System.EventHandler(btnActualizaLicencia_Click);
			this.cmbLicencias.DataSource = this.entUsuarioBindingSource;
			this.cmbLicencias.DisplayMember = "Descripcion";
			this.cmbLicencias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLicencias.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbLicencias.FormattingEnabled = true;
			this.cmbLicencias.Location = new System.Drawing.Point(244, 189);
			this.cmbLicencias.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
			this.cmbLicencias.Name = "cmbLicencias";
			this.cmbLicencias.Size = new System.Drawing.Size(415, 28);
			this.cmbLicencias.TabIndex = 164;
			this.cmbLicencias.SelectedIndexChanged += new System.EventHandler(cmbLicencias_SelectedIndexChanged);
			this.entUsuarioBindingSource.DataSource = typeof(LeeXMLEntidades.EntUsuario);
			this.txtLicenciaSerial.Location = new System.Drawing.Point(258, 192);
			this.txtLicenciaSerial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtLicenciaSerial.Name = "txtLicenciaSerial";
			this.txtLicenciaSerial.ReadOnly = true;
			this.txtLicenciaSerial.Size = new System.Drawing.Size(314, 26);
			this.txtLicenciaSerial.TabIndex = 160;
			this.txtLicenciaSerial.TabStop = false;
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label26.Location = new System.Drawing.Point(136, 189);
			this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(114, 29);
			this.label26.TabIndex = 162;
			this.label26.Text = " Licencia:";
			this.btnSeleccionaRutaRecibidos.BackColor = System.Drawing.Color.White;
			this.btnSeleccionaRutaRecibidos.BackgroundImage = LeeXML.Properties.Resources.Folder_Search;
			this.btnSeleccionaRutaRecibidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnSeleccionaRutaRecibidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSeleccionaRutaRecibidos.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.btnSeleccionaRutaRecibidos.Location = new System.Drawing.Point(606, 388);
			this.btnSeleccionaRutaRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSeleccionaRutaRecibidos.Name = "btnSeleccionaRutaRecibidos";
			this.btnSeleccionaRutaRecibidos.Size = new System.Drawing.Size(54, 60);
			this.btnSeleccionaRutaRecibidos.TabIndex = 159;
			this.btnSeleccionaRutaRecibidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSeleccionaRutaRecibidos.UseVisualStyleBackColor = false;
			this.btnSeleccionaRutaRecibidos.Click += new System.EventHandler(btnSeleccionaRutaRecibidos_Click);
			this.txtRutaRecibidos.Location = new System.Drawing.Point(10, 415);
			this.txtRutaRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRutaRecibidos.Name = "txtRutaRecibidos";
			this.txtRutaRecibidos.Size = new System.Drawing.Size(586, 26);
			this.txtRutaRecibidos.TabIndex = 158;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new System.Drawing.Point(8, 388);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(191, 22);
			this.label8.TabIndex = 157;
			this.label8.Text = "Ruta XML's Recibidos:";
			this.btnCargaXMLs.BackColor = System.Drawing.Color.White;
			this.btnCargaXMLs.BackgroundImage = LeeXML.Properties.Resources.Folder_Search;
			this.btnCargaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCargaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCargaXMLs.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.btnCargaXMLs.Location = new System.Drawing.Point(606, 320);
			this.btnCargaXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCargaXMLs.Name = "btnCargaXMLs";
			this.btnCargaXMLs.Size = new System.Drawing.Size(54, 60);
			this.btnCargaXMLs.TabIndex = 156;
			this.btnCargaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCargaXMLs.UseVisualStyleBackColor = false;
			this.btnCargaXMLs.Click += new System.EventHandler(btnCargaXMLs_Click);
			this.txtRuta.Location = new System.Drawing.Point(10, 349);
			this.txtRuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRuta.Name = "txtRuta";
			this.txtRuta.Size = new System.Drawing.Size(586, 26);
			this.txtRuta.TabIndex = 155;
			this.label89.AutoSize = true;
			this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label89.Location = new System.Drawing.Point(8, 322);
			this.label89.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(180, 22);
			this.label89.TabIndex = 154;
			this.label89.Text = "Ruta XML's Emitidos:";
			this.pnlDatosFacturacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnlDatosFacturacion.Controls.Add(this.cmbTipoPersona);
			this.pnlDatosFacturacion.Controls.Add(this.label24);
			this.pnlDatosFacturacion.Controls.Add(this.txtEmail);
			this.pnlDatosFacturacion.Controls.Add(this.txtTelefono);
			this.pnlDatosFacturacion.Controls.Add(this.txtTelefono2);
			this.pnlDatosFacturacion.Controls.Add(this.txtDireccion);
			this.pnlDatosFacturacion.Controls.Add(this.label7);
			this.pnlDatosFacturacion.Controls.Add(this.label6);
			this.pnlDatosFacturacion.Controls.Add(this.label4);
			this.pnlDatosFacturacion.Controls.Add(this.label3);
			this.pnlDatosFacturacion.Controls.Add(this.label31);
			this.pnlDatosFacturacion.Controls.Add(this.txtTasaOCuota);
			this.pnlDatosFacturacion.Controls.Add(this.cmbUsoCFDI);
			this.pnlDatosFacturacion.Controls.Add(this.txtUsoCFDI);
			this.pnlDatosFacturacion.Controls.Add(this.label5);
			this.pnlDatosFacturacion.Controls.Add(this.cmbRegimenFiscal);
			this.pnlDatosFacturacion.Controls.Add(this.txtRegimenFiscal);
			this.pnlDatosFacturacion.Controls.Add(this.label30);
			this.pnlDatosFacturacion.Controls.Add(this.txtNoCertificado);
			this.pnlDatosFacturacion.Controls.Add(this.label29);
			this.pnlDatosFacturacion.Controls.Add(this.cmbTipoFactor);
			this.pnlDatosFacturacion.Controls.Add(this.label28);
			this.pnlDatosFacturacion.Controls.Add(this.txtNombreFiscal);
			this.pnlDatosFacturacion.Controls.Add(this.txtRFC);
			this.pnlDatosFacturacion.Controls.Add(this.txtCalle);
			this.pnlDatosFacturacion.Controls.Add(this.txtNoExterior);
			this.pnlDatosFacturacion.Controls.Add(this.txtNoInterior);
			this.pnlDatosFacturacion.Controls.Add(this.txtColonia);
			this.pnlDatosFacturacion.Controls.Add(this.txtMunicipio);
			this.pnlDatosFacturacion.Controls.Add(this.txtEstado);
			this.pnlDatosFacturacion.Controls.Add(this.txtCP);
			this.pnlDatosFacturacion.Controls.Add(this.txtLocalidad);
			this.pnlDatosFacturacion.Controls.Add(this.label18);
			this.pnlDatosFacturacion.Controls.Add(this.label17);
			this.pnlDatosFacturacion.Controls.Add(this.label16);
			this.pnlDatosFacturacion.Controls.Add(this.label15);
			this.pnlDatosFacturacion.Controls.Add(this.label14);
			this.pnlDatosFacturacion.Controls.Add(this.label13);
			this.pnlDatosFacturacion.Controls.Add(this.label12);
			this.pnlDatosFacturacion.Controls.Add(this.label11);
			this.pnlDatosFacturacion.Controls.Add(this.label10);
			this.pnlDatosFacturacion.Controls.Add(this.label9);
			this.pnlDatosFacturacion.Location = new System.Drawing.Point(0, 65);
			this.pnlDatosFacturacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.pnlDatosFacturacion.Name = "pnlDatosFacturacion";
			this.pnlDatosFacturacion.Size = new System.Drawing.Size(660, 102);
			this.pnlDatosFacturacion.TabIndex = 95;
			this.cmbTipoPersona.DisplayMember = "Descripcion";
			this.cmbTipoPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoPersona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbTipoPersona.FormattingEnabled = true;
			this.cmbTipoPersona.Items.AddRange(new object[2] { "Persona Física", "Persona Moral" });
			this.cmbTipoPersona.Location = new System.Drawing.Point(166, 605);
			this.cmbTipoPersona.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbTipoPersona.Name = "cmbTipoPersona";
			this.cmbTipoPersona.Size = new System.Drawing.Size(402, 28);
			this.cmbTipoPersona.TabIndex = 144;
			this.cmbTipoPersona.TabStop = false;
			this.cmbTipoPersona.ValueMember = "Id";
			this.label24.AutoSize = true;
			this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(14, 608);
			this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(165, 29);
			this.label24.TabIndex = 143;
			this.label24.Text = "Tipo Persona:";
			this.txtEmail.Location = new System.Drawing.Point(166, 726);
			this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(448, 26);
			this.txtEmail.TabIndex = 142;
			this.txtEmail.TabStop = false;
			this.txtEmail.Visible = false;
			this.txtTelefono.Location = new System.Drawing.Point(166, 686);
			this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTelefono.Name = "txtTelefono";
			this.txtTelefono.Size = new System.Drawing.Size(144, 26);
			this.txtTelefono.TabIndex = 140;
			this.txtTelefono.TabStop = false;
			this.txtTelefono2.Location = new System.Drawing.Point(436, 686);
			this.txtTelefono2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTelefono2.Name = "txtTelefono2";
			this.txtTelefono2.Size = new System.Drawing.Size(178, 26);
			this.txtTelefono2.TabIndex = 141;
			this.txtTelefono2.TabStop = false;
			this.txtDireccion.Location = new System.Drawing.Point(166, 640);
			this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDireccion.Name = "txtDireccion";
			this.txtDireccion.Size = new System.Drawing.Size(448, 26);
			this.txtDireccion.TabIndex = 139;
			this.txtDireccion.TabStop = false;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new System.Drawing.Point(321, 689);
			this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(129, 29);
			this.label7.TabIndex = 138;
			this.label7.Text = "Teléfono2:";
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(88, 725);
			this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 29);
			this.label6.TabIndex = 137;
			this.label6.Text = "E-mail:";
			this.label6.Visible = false;
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(64, 685);
			this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 29);
			this.label4.TabIndex = 136;
			this.label4.Text = "Teléfono:";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new System.Drawing.Point(57, 645);
			this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 29);
			this.label3.TabIndex = 135;
			this.label3.Text = "Dirección:";
			this.label31.AutoSize = true;
			this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label31.Location = new System.Drawing.Point(348, 520);
			this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(73, 29);
			this.label31.TabIndex = 134;
			this.label31.Text = "Tasa:";
			this.label31.Visible = false;
			this.txtTasaOCuota.Location = new System.Drawing.Point(416, 518);
			this.txtTasaOCuota.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtTasaOCuota.Name = "txtTasaOCuota";
			this.txtTasaOCuota.Size = new System.Drawing.Size(122, 26);
			this.txtTasaOCuota.TabIndex = 133;
			this.txtTasaOCuota.TabStop = false;
			this.txtTasaOCuota.Text = "0.16000000";
			this.txtTasaOCuota.Visible = false;
			this.cmbUsoCFDI.DisplayMember = "Descripcion";
			this.cmbUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUsoCFDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbUsoCFDI.FormattingEnabled = true;
			this.cmbUsoCFDI.Items.AddRange(new object[21]
			{
				"601 - General de Ley Personas Morales", "603 - Personas Morales con Fines no Lucrativos", "605 - Sueldos y Salarios e Ingresos Asimilados a Salarios", "606 - Arrendamiento", "607 - Régimen de Enajenación o Adquisición de Bienes", "608 - Demás ingresos", "609 - Consolidación", "610 - Residentes en el Extranjero sin Establecimiento Permanente en México", "611 - Ingresos por Dividendos (socios y accionistas)", "612 - Personas Físicas con Actividades Empresariales y Profesionales",
				"614 - Ingresos por intereses", "615 - Régimen de los ingresos por obtención de premios", "616 - Sin obligaciones fiscales", "620 - Sociedades Cooperativas de Producción que optan por diferir sus ingresos", "621 - Incorporación Fiscal", "622 - Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras", "623 - Opcional para Grupos de Sociedades", "624 - Coordinados", "628 - Hidrocarburos", "629 - De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales",
				"630 - Enajenación de acciones en bolsa de valores"
			});
			this.cmbUsoCFDI.Location = new System.Drawing.Point(166, 565);
			this.cmbUsoCFDI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbUsoCFDI.Name = "cmbUsoCFDI";
			this.cmbUsoCFDI.Size = new System.Drawing.Size(403, 28);
			this.cmbUsoCFDI.TabIndex = 131;
			this.cmbUsoCFDI.TabStop = false;
			this.cmbUsoCFDI.ValueMember = "Id";
			this.cmbUsoCFDI.Visible = false;
			this.txtUsoCFDI.Location = new System.Drawing.Point(166, 566);
			this.txtUsoCFDI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtUsoCFDI.Name = "txtUsoCFDI";
			this.txtUsoCFDI.Size = new System.Drawing.Size(403, 26);
			this.txtUsoCFDI.TabIndex = 132;
			this.txtUsoCFDI.TabStop = false;
			this.txtUsoCFDI.Visible = false;
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(51, 566);
			this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(123, 29);
			this.label5.TabIndex = 130;
			this.label5.Text = "Uso CFDI:";
			this.label5.Visible = false;
			this.cmbRegimenFiscal.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbRegimenFiscal.DisplayMember = "Descripcion";
			this.cmbRegimenFiscal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRegimenFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbRegimenFiscal.FormattingEnabled = true;
			this.cmbRegimenFiscal.Location = new System.Drawing.Point(166, 102);
			this.cmbRegimenFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbRegimenFiscal.Name = "cmbRegimenFiscal";
			this.cmbRegimenFiscal.Size = new System.Drawing.Size(403, 28);
			this.cmbRegimenFiscal.TabIndex = 1;
			this.cmbRegimenFiscal.TabStop = false;
			this.cmbRegimenFiscal.ValueMember = "Id";
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.txtRegimenFiscal.Location = new System.Drawing.Point(166, 102);
			this.txtRegimenFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRegimenFiscal.Name = "txtRegimenFiscal";
			this.txtRegimenFiscal.Size = new System.Drawing.Size(403, 26);
			this.txtRegimenFiscal.TabIndex = 1;
			this.txtRegimenFiscal.TabStop = false;
			this.label30.AutoSize = true;
			this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label30.Location = new System.Drawing.Point(0, 102);
			this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(187, 29);
			this.label30.TabIndex = 127;
			this.label30.Text = "Régimen Fiscal:";
			this.txtNoCertificado.Location = new System.Drawing.Point(166, 471);
			this.txtNoCertificado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNoCertificado.Name = "txtNoCertificado";
			this.txtNoCertificado.Size = new System.Drawing.Size(274, 26);
			this.txtNoCertificado.TabIndex = 15;
			this.txtNoCertificado.TabStop = false;
			this.txtNoCertificado.Visible = false;
			this.label29.AutoSize = true;
			this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label29.Location = new System.Drawing.Point(2, 471);
			this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(179, 29);
			this.label29.TabIndex = 125;
			this.label29.Text = "No. Certificado:";
			this.label29.Visible = false;
			this.cmbTipoFactor.DisplayMember = "Descripcion";
			this.cmbTipoFactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTipoFactor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbTipoFactor.FormattingEnabled = true;
			this.cmbTipoFactor.Items.AddRange(new object[3] { "Tasa", "Cuota", "Exento" });
			this.cmbTipoFactor.Location = new System.Drawing.Point(166, 515);
			this.cmbTipoFactor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbTipoFactor.Name = "cmbTipoFactor";
			this.cmbTipoFactor.Size = new System.Drawing.Size(163, 28);
			this.cmbTipoFactor.TabIndex = 16;
			this.cmbTipoFactor.TabStop = false;
			this.cmbTipoFactor.ValueMember = "Id";
			this.cmbTipoFactor.Visible = false;
			this.label28.AutoSize = true;
			this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label28.Location = new System.Drawing.Point(34, 518);
			this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(143, 29);
			this.label28.TabIndex = 123;
			this.label28.Text = "Tipo Factor:";
			this.label28.Visible = false;
			this.txtNombreFiscal.Location = new System.Drawing.Point(166, 15);
			this.txtNombreFiscal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.Size = new System.Drawing.Size(468, 26);
			this.txtNombreFiscal.TabIndex = 0;
			this.txtRFC.Location = new System.Drawing.Point(166, 62);
			this.txtRFC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.Size = new System.Drawing.Size(403, 26);
			this.txtRFC.TabIndex = 2;
			this.txtRFC.Leave += new System.EventHandler(txtRFC_Leave);
			this.txtCalle.Location = new System.Drawing.Point(166, 146);
			this.txtCalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCalle.Name = "txtCalle";
			this.txtCalle.Size = new System.Drawing.Size(403, 26);
			this.txtCalle.TabIndex = 3;
			this.txtCalle.TabStop = false;
			this.txtNoExterior.Location = new System.Drawing.Point(166, 189);
			this.txtNoExterior.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNoExterior.Name = "txtNoExterior";
			this.txtNoExterior.Size = new System.Drawing.Size(124, 26);
			this.txtNoExterior.TabIndex = 4;
			this.txtNoExterior.TabStop = false;
			this.txtNoInterior.Location = new System.Drawing.Point(447, 189);
			this.txtNoInterior.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNoInterior.Name = "txtNoInterior";
			this.txtNoInterior.Size = new System.Drawing.Size(122, 26);
			this.txtNoInterior.TabIndex = 5;
			this.txtNoInterior.TabStop = false;
			this.txtColonia.Location = new System.Drawing.Point(166, 238);
			this.txtColonia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtColonia.Name = "txtColonia";
			this.txtColonia.Size = new System.Drawing.Size(284, 26);
			this.txtColonia.TabIndex = 6;
			this.txtColonia.TabStop = false;
			this.txtMunicipio.Location = new System.Drawing.Point(166, 338);
			this.txtMunicipio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtMunicipio.Name = "txtMunicipio";
			this.txtMunicipio.Size = new System.Drawing.Size(274, 26);
			this.txtMunicipio.TabIndex = 8;
			this.txtMunicipio.TabStop = false;
			this.txtEstado.Location = new System.Drawing.Point(166, 385);
			this.txtEstado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(222, 26);
			this.txtEstado.TabIndex = 9;
			this.txtEstado.TabStop = false;
			this.txtCP.Location = new System.Drawing.Point(447, 385);
			this.txtCP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCP.Name = "txtCP";
			this.txtCP.Size = new System.Drawing.Size(122, 26);
			this.txtCP.TabIndex = 10;
			this.txtCP.TabStop = false;
			this.txtLocalidad.Location = new System.Drawing.Point(166, 286);
			this.txtLocalidad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtLocalidad.Name = "txtLocalidad";
			this.txtLocalidad.Size = new System.Drawing.Size(274, 26);
			this.txtLocalidad.TabIndex = 7;
			this.txtLocalidad.TabStop = false;
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label18.Location = new System.Drawing.Point(402, 388);
			this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(52, 29);
			this.label18.TabIndex = 23;
			this.label18.Text = "CP:";
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new System.Drawing.Point(82, 385);
			this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(94, 29);
			this.label17.TabIndex = 22;
			this.label17.Text = "Estado:";
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new System.Drawing.Point(58, 338);
			this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(123, 29);
			this.label16.TabIndex = 21;
			this.label16.Text = "Municipio:";
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label15.Location = new System.Drawing.Point(58, 286);
			this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(124, 29);
			this.label15.TabIndex = 20;
			this.label15.Text = "Localidad:";
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new System.Drawing.Point(76, 238);
			this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(102, 29);
			this.label14.TabIndex = 19;
			this.label14.Text = "Colonia:";
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new System.Drawing.Point(326, 192);
			this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(138, 29);
			this.label13.TabIndex = 18;
			this.label13.Text = "No. Interior:";
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label12.Location = new System.Drawing.Point(34, 189);
			this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(146, 29);
			this.label12.TabIndex = 17;
			this.label12.Text = "No. Exterior:";
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new System.Drawing.Point(104, 142);
			this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(75, 29);
			this.label11.TabIndex = 16;
			this.label11.Text = "Calle:";
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new System.Drawing.Point(94, 58);
			this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(80, 29);
			this.label10.TabIndex = 15;
			this.label10.Text = "R.F.C:";
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new System.Drawing.Point(8, 15);
			this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(177, 29);
			this.label9.TabIndex = 14;
			this.label9.Text = "Nombre Fiscal:";
			this.txtNombre.Location = new System.Drawing.Point(117, 22);
			this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(518, 26);
			this.txtNombre.TabIndex = 7;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(21, 26);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "Nombre:";
			this.tabPage6.Controls.Add(this.panel3);
			this.tabPage6.Location = new System.Drawing.Point(4, 29);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage6.Size = new System.Drawing.Size(678, 705);
			this.tabPage6.TabIndex = 1;
			this.tabPage6.Text = "Bancos";
			this.tabPage6.UseVisualStyleBackColor = true;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.Add(this.btnAgregaBanco);
			this.panel3.Controls.Add(this.txtClaveBanco);
			this.panel3.Controls.Add(this.gvBancos);
			this.panel3.Controls.Add(this.label32);
			this.panel3.Controls.Add(this.txtDescripcionBanco);
			this.panel3.Controls.Add(this.label23);
			this.panel3.Controls.Add(this.txtNoReferencia);
			this.panel3.Controls.Add(this.label22);
			this.panel3.Controls.Add(this.txtSucursal);
			this.panel3.Controls.Add(this.label21);
			this.panel3.Controls.Add(this.txtNoCuenta);
			this.panel3.Controls.Add(this.label20);
			this.panel3.Controls.Add(this.txtCLABE);
			this.panel3.Controls.Add(this.label19);
			this.panel3.Location = new System.Drawing.Point(9, 9);
			this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(588, 506);
			this.panel3.TabIndex = 0;
			this.btnAgregaBanco.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAgregaBanco.BackColor = System.Drawing.Color.White;
			this.btnAgregaBanco.BackgroundImage = LeeXML.Properties.Resources.Plus;
			this.btnAgregaBanco.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnAgregaBanco.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAgregaBanco.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnAgregaBanco.Location = new System.Drawing.Point(508, 11);
			this.btnAgregaBanco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnAgregaBanco.Name = "btnAgregaBanco";
			this.btnAgregaBanco.Size = new System.Drawing.Size(60, 55);
			this.btnAgregaBanco.TabIndex = 2;
			this.btnAgregaBanco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnAgregaBanco.UseVisualStyleBackColor = false;
			this.btnAgregaBanco.Click += new System.EventHandler(btnAgregaBanco_Click);
			this.txtClaveBanco.Location = new System.Drawing.Point(54, 38);
			this.txtClaveBanco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtClaveBanco.Name = "txtClaveBanco";
			this.txtClaveBanco.Size = new System.Drawing.Size(146, 26);
			this.txtClaveBanco.TabIndex = 0;
			this.gvBancos.AllowUserToAddRows = false;
			this.gvBancos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvBancos.AutoGenerateColumns = false;
			this.gvBancos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvBancos.BackgroundColor = System.Drawing.Color.White;
			this.gvBancos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.gvBancos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvBancos.Columns.AddRange(this.claveDataGridViewTextBoxColumn, this.descripcionDataGridViewTextBoxColumn, this.GvEmpresasColumnEliminar);
			this.gvBancos.DataSource = this.entCatalogoGenericoBindingSource;
			this.gvBancos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gvBancos.GridColor = System.Drawing.Color.DimGray;
			this.gvBancos.Location = new System.Drawing.Point(54, 68);
			this.gvBancos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvBancos.MultiSelect = false;
			this.gvBancos.Name = "gvBancos";
			this.gvBancos.RowHeadersVisible = false;
			this.gvBancos.RowHeadersWidth = 51;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5f);
			this.gvBancos.RowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvBancos.RowTemplate.Height = 27;
			this.gvBancos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvBancos.Size = new System.Drawing.Size(514, 229);
			this.gvBancos.TabIndex = 3;
			this.gvBancos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvBancos_CellClick);
			this.gvBancos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(gvBancos_CellValueChanged);
			this.claveDataGridViewTextBoxColumn.DataPropertyName = "Clave";
			this.claveDataGridViewTextBoxColumn.FillWeight = 50f;
			this.claveDataGridViewTextBoxColumn.HeaderText = "Clave";
			this.claveDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.claveDataGridViewTextBoxColumn.Name = "claveDataGridViewTextBoxColumn";
			this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
			this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
			this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
			this.GvEmpresasColumnEliminar.FillWeight = 20f;
			this.GvEmpresasColumnEliminar.HeaderText = "Elim.";
			this.GvEmpresasColumnEliminar.Image = LeeXML.Properties.Resources.X;
			this.GvEmpresasColumnEliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
			this.GvEmpresasColumnEliminar.MinimumWidth = 6;
			this.GvEmpresasColumnEliminar.Name = "GvEmpresasColumnEliminar";
			this.label32.AutoSize = true;
			this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label32.Location = new System.Drawing.Point(56, 5);
			this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(99, 29);
			this.label32.TabIndex = 39;
			this.label32.Text = "Bancos:";
			this.txtDescripcionBanco.Location = new System.Drawing.Point(204, 38);
			this.txtDescripcionBanco.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtDescripcionBanco.Name = "txtDescripcionBanco";
			this.txtDescripcionBanco.Size = new System.Drawing.Size(295, 26);
			this.txtDescripcionBanco.TabIndex = 1;
			this.label23.AutoSize = true;
			this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label23.Location = new System.Drawing.Point(-9, 465);
			this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(180, 29);
			this.label23.TabIndex = 37;
			this.label23.Text = "No. Referencia:";
			this.label23.Visible = false;
			this.txtNoReferencia.Location = new System.Drawing.Point(164, 462);
			this.txtNoReferencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNoReferencia.Name = "txtNoReferencia";
			this.txtNoReferencia.Size = new System.Drawing.Size(284, 26);
			this.txtNoReferencia.TabIndex = 36;
			this.txtNoReferencia.Visible = false;
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label22.Location = new System.Drawing.Point(64, 408);
			this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(96, 29);
			this.label22.TabIndex = 35;
			this.label22.Text = "CLABE:";
			this.label22.Visible = false;
			this.txtSucursal.Location = new System.Drawing.Point(164, 300);
			this.txtSucursal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtSucursal.Name = "txtSucursal";
			this.txtSucursal.Size = new System.Drawing.Size(284, 26);
			this.txtSucursal.TabIndex = 34;
			this.txtSucursal.Visible = false;
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label21.Location = new System.Drawing.Point(72, 252);
			this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(87, 29);
			this.label21.TabIndex = 33;
			this.label21.Text = "Banco:";
			this.label21.Visible = false;
			this.txtNoCuenta.Location = new System.Drawing.Point(164, 354);
			this.txtNoCuenta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtNoCuenta.Name = "txtNoCuenta";
			this.txtNoCuenta.Size = new System.Drawing.Size(284, 26);
			this.txtNoCuenta.TabIndex = 32;
			this.txtNoCuenta.Visible = false;
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label20.Location = new System.Drawing.Point(50, 305);
			this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(112, 29);
			this.label20.TabIndex = 31;
			this.label20.Text = "Sucursal:";
			this.label20.Visible = false;
			this.txtCLABE.Location = new System.Drawing.Point(164, 405);
			this.txtCLABE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtCLABE.Name = "txtCLABE";
			this.txtCLABE.Size = new System.Drawing.Size(284, 26);
			this.txtCLABE.TabIndex = 30;
			this.txtCLABE.Visible = false;
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label19.Location = new System.Drawing.Point(26, 358);
			this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(139, 29);
			this.label19.TabIndex = 29;
			this.label19.Text = "No. Cuenta:";
			this.label19.Visible = false;
			this.tabControl2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Location = new System.Drawing.Point(0, 71);
			this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(632, 614);
			this.tabControl2.TabIndex = 2;
			this.tabPage2.Controls.Add(this.gvEmpresas);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.tabPage2.Size = new System.Drawing.Size(624, 581);
			this.tabPage2.TabIndex = 0;
			this.tabPage2.Text = "Datos Generales";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.gvEmpresas.AllowUserToAddRows = false;
			this.gvEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvEmpresas.AutoGenerateColumns = false;
			this.gvEmpresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvEmpresas.BackgroundColor = System.Drawing.Color.White;
			this.gvEmpresas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
			this.gvEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvEmpresas.Columns.AddRange(this.LicenciaSerial, this.DiasExpiracion, this.añoInicialDataGridViewTextBoxColumn, this.limiteEmpresasDataGridViewTextBoxColumn, this.fechaActivacionDataGridViewTextBoxColumn, this.fechaLimiteDataGridViewTextBoxColumn, this.activacionesDataGridViewTextBoxColumn, this.tipoLicenciaIdDataGridViewTextBoxColumn, this.licenciaIdDataGridViewTextBoxColumn, this.licenciaSerialDataGridViewTextBoxColumn, this.diasExpiracionDataGridViewTextBoxColumn, this.activadoDataGridViewCheckBoxColumn, this.estatusIdDataGridViewTextBoxColumn, this.estatusDescripcionDataGridViewTextBoxColumn, this.fechaDataGridViewTextBoxColumn, this.fechaPagoDataGridViewTextBoxColumn);
			this.gvEmpresas.DataSource = this.entUsuarioBindingSource;
			this.gvEmpresas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.gvEmpresas.GridColor = System.Drawing.Color.DimGray;
			this.gvEmpresas.Location = new System.Drawing.Point(0, 0);
			this.gvEmpresas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.gvEmpresas.MultiSelect = false;
			this.gvEmpresas.Name = "gvEmpresas";
			this.gvEmpresas.ReadOnly = true;
			this.gvEmpresas.RowHeadersVisible = false;
			this.gvEmpresas.RowHeadersWidth = 51;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5f);
			this.gvEmpresas.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.gvEmpresas.RowTemplate.Height = 27;
			this.gvEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvEmpresas.Size = new System.Drawing.Size(622, 565);
			this.gvEmpresas.TabIndex = 79;
			this.gvEmpresas.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvEmpresas_CellContentDoubleClick);
			this.gvEmpresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvEmpresas_CellDoubleClick);
			this.btnEmpresaBusqueda.BackColor = System.Drawing.Color.White;
			this.btnEmpresaBusqueda.BackgroundImage = LeeXML.Properties.Resources.Search;
			this.btnEmpresaBusqueda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnEmpresaBusqueda.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEmpresaBusqueda.Location = new System.Drawing.Point(476, 25);
			this.btnEmpresaBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnEmpresaBusqueda.Name = "btnEmpresaBusqueda";
			this.btnEmpresaBusqueda.Size = new System.Drawing.Size(68, 46);
			this.btnEmpresaBusqueda.TabIndex = 1;
			this.btnEmpresaBusqueda.UseVisualStyleBackColor = false;
			this.btnEmpresaBusqueda.Click += new System.EventHandler(btnEmpresaBusqueda_Click);
			this.txtEmpresaBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f);
			this.txtEmpresaBusqueda.Location = new System.Drawing.Point(6, 31);
			this.txtEmpresaBusqueda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtEmpresaBusqueda.Name = "txtEmpresaBusqueda";
			this.txtEmpresaBusqueda.Size = new System.Drawing.Size(458, 30);
			this.txtEmpresaBusqueda.TabIndex = 0;
			this.txtEmpresaBusqueda.TextChanged += new System.EventHandler(txtEmpresaBusqueda_TextChanged);
			this.LicenciaSerial.DataPropertyName = "LicenciaSerial";
			this.LicenciaSerial.FillWeight = 80f;
			this.LicenciaSerial.HeaderText = "Licencia Serial";
			this.LicenciaSerial.MinimumWidth = 6;
			this.LicenciaSerial.Name = "LicenciaSerial";
			this.LicenciaSerial.ReadOnly = true;
			this.DiasExpiracion.DataPropertyName = "DiasExpiracion";
			this.DiasExpiracion.FillWeight = 40f;
			this.DiasExpiracion.HeaderText = "Días Expiración";
			this.DiasExpiracion.MinimumWidth = 6;
			this.DiasExpiracion.Name = "DiasExpiracion";
			this.DiasExpiracion.ReadOnly = true;
			this.añoInicialDataGridViewTextBoxColumn.DataPropertyName = "AñoInicial";
			this.añoInicialDataGridViewTextBoxColumn.HeaderText = "AñoInicial";
			this.añoInicialDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.añoInicialDataGridViewTextBoxColumn.Name = "añoInicialDataGridViewTextBoxColumn";
			this.añoInicialDataGridViewTextBoxColumn.ReadOnly = true;
			this.limiteEmpresasDataGridViewTextBoxColumn.DataPropertyName = "LimiteEmpresas";
			this.limiteEmpresasDataGridViewTextBoxColumn.HeaderText = "LimiteEmpresas";
			this.limiteEmpresasDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.limiteEmpresasDataGridViewTextBoxColumn.Name = "limiteEmpresasDataGridViewTextBoxColumn";
			this.limiteEmpresasDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaActivacionDataGridViewTextBoxColumn.DataPropertyName = "FechaActivacion";
			this.fechaActivacionDataGridViewTextBoxColumn.HeaderText = "FechaActivacion";
			this.fechaActivacionDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.fechaActivacionDataGridViewTextBoxColumn.Name = "fechaActivacionDataGridViewTextBoxColumn";
			this.fechaActivacionDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaLimiteDataGridViewTextBoxColumn.DataPropertyName = "FechaLimite";
			this.fechaLimiteDataGridViewTextBoxColumn.HeaderText = "FechaLimite";
			this.fechaLimiteDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.fechaLimiteDataGridViewTextBoxColumn.Name = "fechaLimiteDataGridViewTextBoxColumn";
			this.fechaLimiteDataGridViewTextBoxColumn.ReadOnly = true;
			this.activacionesDataGridViewTextBoxColumn.DataPropertyName = "Activaciones";
			this.activacionesDataGridViewTextBoxColumn.HeaderText = "Activaciones";
			this.activacionesDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.activacionesDataGridViewTextBoxColumn.Name = "activacionesDataGridViewTextBoxColumn";
			this.activacionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.tipoLicenciaIdDataGridViewTextBoxColumn.DataPropertyName = "TipoLicenciaId";
			this.tipoLicenciaIdDataGridViewTextBoxColumn.HeaderText = "TipoLicenciaId";
			this.tipoLicenciaIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.tipoLicenciaIdDataGridViewTextBoxColumn.Name = "tipoLicenciaIdDataGridViewTextBoxColumn";
			this.tipoLicenciaIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.licenciaIdDataGridViewTextBoxColumn.DataPropertyName = "LicenciaId";
			this.licenciaIdDataGridViewTextBoxColumn.HeaderText = "LicenciaId";
			this.licenciaIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.licenciaIdDataGridViewTextBoxColumn.Name = "licenciaIdDataGridViewTextBoxColumn";
			this.licenciaIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.licenciaSerialDataGridViewTextBoxColumn.DataPropertyName = "LicenciaSerial";
			this.licenciaSerialDataGridViewTextBoxColumn.HeaderText = "LicenciaSerial";
			this.licenciaSerialDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.licenciaSerialDataGridViewTextBoxColumn.Name = "licenciaSerialDataGridViewTextBoxColumn";
			this.licenciaSerialDataGridViewTextBoxColumn.ReadOnly = true;
			this.diasExpiracionDataGridViewTextBoxColumn.DataPropertyName = "DiasExpiracion";
			this.diasExpiracionDataGridViewTextBoxColumn.HeaderText = "DiasExpiracion";
			this.diasExpiracionDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.diasExpiracionDataGridViewTextBoxColumn.Name = "diasExpiracionDataGridViewTextBoxColumn";
			this.diasExpiracionDataGridViewTextBoxColumn.ReadOnly = true;
			this.activadoDataGridViewCheckBoxColumn.DataPropertyName = "Activado";
			this.activadoDataGridViewCheckBoxColumn.HeaderText = "Activado";
			this.activadoDataGridViewCheckBoxColumn.MinimumWidth = 8;
			this.activadoDataGridViewCheckBoxColumn.Name = "activadoDataGridViewCheckBoxColumn";
			this.activadoDataGridViewCheckBoxColumn.ReadOnly = true;
			this.estatusIdDataGridViewTextBoxColumn.DataPropertyName = "EstatusId";
			this.estatusIdDataGridViewTextBoxColumn.HeaderText = "EstatusId";
			this.estatusIdDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.estatusIdDataGridViewTextBoxColumn.Name = "estatusIdDataGridViewTextBoxColumn";
			this.estatusIdDataGridViewTextBoxColumn.ReadOnly = true;
			this.estatusDescripcionDataGridViewTextBoxColumn.DataPropertyName = "EstatusDescripcion";
			this.estatusDescripcionDataGridViewTextBoxColumn.HeaderText = "EstatusDescripcion";
			this.estatusDescripcionDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.estatusDescripcionDataGridViewTextBoxColumn.Name = "estatusDescripcionDataGridViewTextBoxColumn";
			this.estatusDescripcionDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.fechaPagoDataGridViewTextBoxColumn.DataPropertyName = "FechaPago";
			this.fechaPagoDataGridViewTextBoxColumn.HeaderText = "FechaPago";
			this.fechaPagoDataGridViewTextBoxColumn.MinimumWidth = 8;
			this.fechaPagoDataGridViewTextBoxColumn.Name = "fechaPagoDataGridViewTextBoxColumn";
			this.fechaPagoDataGridViewTextBoxColumn.ReadOnly = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(1359, 858);
			base.Controls.Add(this.tabControl1);
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Licencias";
			this.Text = "Empresas";
			base.Load += new System.EventHandler(Empresas_Load);
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.pnlDatos.ResumeLayout(false);
			this.pnlDatos.PerformLayout();
			this.tcNuevaEmpresa.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.gbDatosDescargaMasiva.ResumeLayout(false);
			this.gbDatosDescargaMasiva.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.pnlCIECregistrada.ResumeLayout(false);
			this.pnlCIECregistrada.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).EndInit();
			this.pnlDatosFacturacion.ResumeLayout(false);
			this.pnlDatosFacturacion.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.tabPage6.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvBancos).EndInit();
			this.tabControl2.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvEmpresas).EndInit();
			base.ResumeLayout(false);
		}
	}
}
