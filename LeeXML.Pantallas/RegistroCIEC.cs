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
	public class RegistroCIEC : FormBase
	{
		private List<EntUsuario> ListaLicenciasDescargaMasiva;

		private IContainer components = null;

		private OpenFileDialog ofdBuscaArchivo;

		private BindingSource entEmpresaBindingSource;

		private BindingSource entCatalogoGenericoBindingSource;

		private DataGridViewTextBoxColumn TipoTasa;

		private BindingSource entUsuarioBindingSource;

		private GroupBox gbDatosDescargaMasiva;

		private TextBox txtContraseñaCIEC;

		private Label label33;

		private Button btnRegistraDescargaMasiva;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripProgressBar toolStripProgressBar1;

		private Button btnVerContraseña;

		private TextBox txtConfirmaCIEC;

		private Label label1;

		private Label lbContraseñaIncorrecta;

		private Label lbCaracteresInvalido;

		private Label label2;

		private DateTimePicker dtpFechaInicioSinc;

		public EntEmpresa EmpresaRegistra { get; set; }

		private List<razonesSociales> ListaRS { get; set; }

		private bool RfcEncontrado { get; set; }

		private void InicializaPantalla()
		{
			dtpFechaInicioSinc.Value = new DateTime(DateTime.Today.Year, 1, 1);
			dtpFechaInicioSinc.MinDate = new DateTime(DateTime.Today.AddYears(-1).Year, 1, 1);
		}

		public RegistroCIEC(EntEmpresa EmpresaRegistra)
		{
			InitializeComponent();
			this.EmpresaRegistra = EmpresaRegistra;
		}

		public void CargaLicencias(int CompañiaId)
		{
			ListaLicenciasDescargaMasiva = new BusUsuarios().ObtieneLicenciasDescargaMasivaActivas(CompañiaId);
		}

		private void ActualizaEmpresaCIEC(int EmpresaId, string ContraseñaCIEC)
		{
			EntEmpresa empresa = new EntEmpresa
			{
				Id = EmpresaId,
				Certificado = ContraseñaCIEC
			};
			new BusEmpresas().ActualizaEmpresaCIEC(empresa);
		}

		private async Task Registrar(string RazonSocial, string RFC, string PassCIEC, DateTime FechaInicial)
		{
			toolStripProgressBar1.Value = 1;
			string fechaInicio = FechaInicial.Year + "-" + FechaInicial.Month.ToString().PadLeft(2, '0') + "-" + FechaInicial.Day.ToString().PadLeft(2, '0');
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/create");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"razonSocial\":\"" + RazonSocial + "\",\r\n\"fechaInicioSync\":\"" + fechaInicio + "\",\r\n\"maxComprobantesMensual\":\"1000\",\r\n\"celular\":\"+525539904089\",\r\n\"fiel\":{\"pfx\":\"\",\"passPfx\":\"\"},\r\n\"ciec\":{\"rfc\":\"" + RFC + "\",\"passCiec\":\"" + PassCIEC + "\"},\r\n\"sync\":\"ciec\"\r\n}", (Encoding)null, "application/json");
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
			toolStripStatusLabel1.Text = "REGISTRO COMPLETADO";
		}

		private async Task Actualizar(string RFC, string PassCIEC)
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/ciec-update");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"rfc\":\"" + RFC + "\",\r\n\"password\":\"" + PassCIEC + "\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			_ = "{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"-------\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"rfc\":\"" + RFC + "\",\r\n\"password\":\"" + PassCIEC + "\"\r\n}";
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
			toolStripStatusLabel1.Text = "REGISTRO COMPLETADO";
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
			toolStripStatusLabel1.Text = "LISTA RS DESCARGADA";
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
				JsonConvert.DeserializeObject<JObject>(json);
				toolStripStatusLabel1.Text = myObject.mensaje;
				toolStripProgressBar1.Value = 100;
				ListaRS = new List<razonesSociales> { myObject.razonesSociales.Find((razonesSociales p) => p.rfc == RFC) };
				if (RFC == ListaRS.Last().rfc)
				{
					MuestraMensaje("RFC REGISTRADO CORRECTAMENTE\n" + ((object)ListaRS.Last()).ToString());
					await Sincronizar(RFC);
				}
				else
				{
					MandaExcepcion("ERROR AL REGISTRAR RFC");
				}
			}
			toolStripStatusLabel1.Text = "ENLISTADO";
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
			toolStripStatusLabel1.Text = "RFC REINGRESADO";
		}

		private async Task Sincronizar(string RFC)
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

		private async Task BuscaRFCenRS(string RfcVerifica, bool MostrarMensaje)
		{
			await ObtieneDescargaListaRS();
			RfcEncontrado = false;
			foreach (razonesSociales r in ListaRS)
			{
				if (r.rfc == RfcVerifica)
				{
					RfcEncontrado = true;
					if (MostrarMensaje)
					{
						MuestraMensaje("RFC REGISTRADO\n\nRAZON SOCIAL: " + r.razon_social + "\nRFC: " + r.rfc.ToString() + "\nFECHA ULTM. SINC: " + r.fecha_ult_sync, "RFC ENCONTRADO");
					}
				}
			}
			if (!RfcEncontrado && MostrarMensaje)
			{
				MuestraMensajeError("RFC NO REGISTRADO", "RFC NO ENCONTRADO");
			}
		}

		private async Task BuscaRFCregistrado(string RFC)
		{
			await BuscaRFCenRS(RFC, false);
			if (RfcEncontrado)
			{
				await ActualizarCIEC(EmpresaRegistra.RFC, txtContraseñaCIEC.Text);
			}
			else
			{
				await RegistraCIEC(EmpresaRegistra.NombreFiscal, EmpresaRegistra.RFC, txtContraseñaCIEC.Text);
			}
		}

		private async Task RegistraCIEC(string NombreFiscal, string RFC, string ContraseñaCIEC)
		{
			ObtieneFechaPrimerDiaMes(1, DateTime.Today.AddYears(-1).Year);
			DateTime fechaInicio = dtpFechaInicioSinc.Value;
			await Registrar(NombreFiscal, RFC, ContraseñaCIEC, fechaInicio);
		}

		private async Task ActualizarCIEC(string RFC, string ContraseñaCIEC)
		{
			await Actualizar(RFC, ContraseñaCIEC);
		}

		private void Empresas_Load(object sender, EventArgs e)
		{
			try
			{
				InicializaPantalla();
				CargaLicencias(Program.UsuarioSeleccionado.CompañiaId);
				if (ListaLicenciasDescargaMasiva.Count == 0 && (!(Program.UsuarioSeleccionado.Usuario == "sys") || !(Program.UsuarioSeleccionado.Contraseña == "5fb552a76ef3c7ee67681d80e9797e088a6c9859")))
				{
					gbDatosDescargaMasiva.Enabled = false;
					statusStrip1.Visible = false;
				}
				else
				{
					txtContraseñaCIEC.Text = EmpresaRegistra.Certificado;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private async void btnRegistraDescargaMasiva_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtContraseñaCIEC.Text != txtConfirmaCIEC.Text)
				{
					txtConfirmaCIEC.Focus();
					txtConfirmaCIEC.SelectAll();
					return;
				}
				base.Enabled = false;
				toolStripStatusLabel1.Text = "REGISTRANDO..";
				await BuscaRFCregistrado(EmpresaRegistra.RFC);
				ActualizaEmpresaCIEC(EmpresaRegistra.Id, txtContraseñaCIEC.Text);
				EmpresaRegistra.Certificado = txtContraseñaCIEC.Text;
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MuestraExcepcion(ex2, "ERROR AL REGISTRAR PARA DESCAERGA MASIVA - COMUNICARSE CON SOPORTE TÉCNICO");
				toolStripStatusLabel1.Text = "";
				toolStripProgressBar1.Value = 0;
			}
			finally
			{
				base.Enabled = true;
				if (MuestraMensajeOK("CIEC CAPTURADA, ESPERA 24 HORAS PARA LA VALIDACIÓN DE LA MISMA Y PODER UTILIZAR DESCARGA MASIVA.") == DialogResult.OK)
				{
					Close();
				}
			}
		}

		private void btnVerContraseña_MouseDown(object sender, MouseEventArgs e)
		{
			txtContraseñaCIEC.PasswordChar = '\0';
		}

		private void btnVerContraseña_MouseUp(object sender, MouseEventArgs e)
		{
			txtContraseñaCIEC.PasswordChar = '*';
		}

		private void txtConfirmaCIEC_TextChanged(object sender, EventArgs e)
		{
			try
			{
				if (txtContraseñaCIEC.Text != txtConfirmaCIEC.Text)
				{
					lbContraseñaIncorrecta.Visible = true;
					btnRegistraDescargaMasiva.Enabled = false;
					return;
				}
				lbContraseñaIncorrecta.Visible = false;
				if (txtContraseñaCIEC.TextLength < 8)
				{
					lbCaracteresInvalido.Visible = true;
					return;
				}
				lbCaracteresInvalido.Visible = false;
				btnRegistraDescargaMasiva.Enabled = true;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void dtpFechaInicioSinc_ValueChanged(object sender, EventArgs e)
		{
		}

		private void dtpFechaInicioSinc_Leave(object sender, EventArgs e)
		{
			try
			{
				if (dtpFechaInicioSinc.Value.Year < DateTime.Today.Year)
				{
					MuestraMensajeAdvertencia("SELECCIONASTE UN EJERCICIO ANTERIOR AL EJERCICIO ACTUAL, LA SINCRONIZACIÓN CON EL SERVICIO DEL SAT PUEDE TARDAR HASTA MAS DE 6 DÍAS HÁBILES.", "ADVERTENCIA DESCARGA MASIVA DE EJERCICIOS ANTERIORES");
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
			this.ofdBuscaArchivo = new System.Windows.Forms.OpenFileDialog();
			this.entEmpresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gbDatosDescargaMasiva = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dtpFechaInicioSinc = new System.Windows.Forms.DateTimePicker();
			this.lbCaracteresInvalido = new System.Windows.Forms.Label();
			this.lbContraseñaIncorrecta = new System.Windows.Forms.Label();
			this.txtContraseñaCIEC = new System.Windows.Forms.TextBox();
			this.txtConfirmaCIEC = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnVerContraseña = new System.Windows.Forms.Button();
			this.btnRegistraDescargaMasiva = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.label33 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.gbDatosDescargaMasiva.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.ofdBuscaArchivo.FileName = "openFileDialog1";
			this.entEmpresaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEmpresa);
			this.entUsuarioBindingSource.DataSource = typeof(LeeXMLEntidades.EntUsuario);
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.gbDatosDescargaMasiva.Controls.Add(this.label2);
			this.gbDatosDescargaMasiva.Controls.Add(this.dtpFechaInicioSinc);
			this.gbDatosDescargaMasiva.Controls.Add(this.lbCaracteresInvalido);
			this.gbDatosDescargaMasiva.Controls.Add(this.lbContraseñaIncorrecta);
			this.gbDatosDescargaMasiva.Controls.Add(this.txtContraseñaCIEC);
			this.gbDatosDescargaMasiva.Controls.Add(this.txtConfirmaCIEC);
			this.gbDatosDescargaMasiva.Controls.Add(this.label1);
			this.gbDatosDescargaMasiva.Controls.Add(this.btnVerContraseña);
			this.gbDatosDescargaMasiva.Controls.Add(this.btnRegistraDescargaMasiva);
			this.gbDatosDescargaMasiva.Controls.Add(this.statusStrip1);
			this.gbDatosDescargaMasiva.Controls.Add(this.label33);
			this.gbDatosDescargaMasiva.Location = new System.Drawing.Point(12, 24);
			this.gbDatosDescargaMasiva.Name = "gbDatosDescargaMasiva";
			this.gbDatosDescargaMasiva.Size = new System.Drawing.Size(514, 197);
			this.gbDatosDescargaMasiva.TabIndex = 168;
			this.gbDatosDescargaMasiva.TabStop = false;
			this.gbDatosDescargaMasiva.Text = "Registrar para Descarga Masiva";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(239, 18);
			this.label2.TabIndex = 178;
			this.label2.Text = "Fecha Inicio Descarga Masiva:";
			this.dtpFechaInicioSinc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.dtpFechaInicioSinc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaInicioSinc.Location = new System.Drawing.Point(286, 34);
			this.dtpFechaInicioSinc.Name = "dtpFechaInicioSinc";
			this.dtpFechaInicioSinc.Size = new System.Drawing.Size(122, 22);
			this.dtpFechaInicioSinc.TabIndex = 177;
			this.dtpFechaInicioSinc.ValueChanged += new System.EventHandler(dtpFechaInicioSinc_ValueChanged);
			this.dtpFechaInicioSinc.Leave += new System.EventHandler(dtpFechaInicioSinc_Leave);
			this.lbCaracteresInvalido.AutoSize = true;
			this.lbCaracteresInvalido.ForeColor = System.Drawing.Color.IndianRed;
			this.lbCaracteresInvalido.Location = new System.Drawing.Point(188, 141);
			this.lbCaracteresInvalido.Name = "lbCaracteresInvalido";
			this.lbCaracteresInvalido.Size = new System.Drawing.Size(147, 16);
			this.lbCaracteresInvalido.TabIndex = 176;
			this.lbCaracteresInvalido.Text = "Deben ser 8 caracteres";
			this.lbCaracteresInvalido.Visible = false;
			this.lbContraseñaIncorrecta.AutoSize = true;
			this.lbContraseñaIncorrecta.ForeColor = System.Drawing.Color.IndianRed;
			this.lbContraseñaIncorrecta.Location = new System.Drawing.Point(190, 141);
			this.lbContraseñaIncorrecta.Name = "lbContraseñaIncorrecta";
			this.lbContraseñaIncorrecta.Size = new System.Drawing.Size(167, 16);
			this.lbContraseñaIncorrecta.TabIndex = 175;
			this.lbContraseñaIncorrecta.Text = "Contraseñas No Coinciden";
			this.lbContraseñaIncorrecta.Visible = false;
			this.txtContraseñaCIEC.Location = new System.Drawing.Point(184, 78);
			this.txtContraseñaCIEC.Margin = new System.Windows.Forms.Padding(4);
			this.txtContraseñaCIEC.MaxLength = 8;
			this.txtContraseñaCIEC.Name = "txtContraseñaCIEC";
			this.txtContraseñaCIEC.PasswordChar = '*';
			this.txtContraseñaCIEC.Size = new System.Drawing.Size(180, 22);
			this.txtContraseñaCIEC.TabIndex = 15;
			this.txtContraseñaCIEC.TextChanged += new System.EventHandler(txtConfirmaCIEC_TextChanged);
			this.txtConfirmaCIEC.Location = new System.Drawing.Point(184, 116);
			this.txtConfirmaCIEC.Margin = new System.Windows.Forms.Padding(4);
			this.txtConfirmaCIEC.MaxLength = 8;
			this.txtConfirmaCIEC.Name = "txtConfirmaCIEC";
			this.txtConfirmaCIEC.PasswordChar = '*';
			this.txtConfirmaCIEC.Size = new System.Drawing.Size(180, 22);
			this.txtConfirmaCIEC.TabIndex = 173;
			this.txtConfirmaCIEC.TextChanged += new System.EventHandler(txtConfirmaCIEC_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(38, 115);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(143, 24);
			this.label1.TabIndex = 174;
			this.label1.Text = "Confirma CIEC: ";
			this.btnVerContraseña.BackColor = System.Drawing.Color.Transparent;
			this.btnVerContraseña.BackgroundImage = LeeXML.Properties.Resources.VistaPreviaSinFondo;
			this.btnVerContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnVerContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnVerContraseña.Location = new System.Drawing.Point(366, 71);
			this.btnVerContraseña.Margin = new System.Windows.Forms.Padding(4);
			this.btnVerContraseña.Name = "btnVerContraseña";
			this.btnVerContraseña.Size = new System.Drawing.Size(46, 30);
			this.btnVerContraseña.TabIndex = 172;
			this.btnVerContraseña.TabStop = false;
			this.btnVerContraseña.UseVisualStyleBackColor = false;
			this.btnVerContraseña.MouseDown += new System.Windows.Forms.MouseEventHandler(btnVerContraseña_MouseDown);
			this.btnVerContraseña.MouseUp += new System.Windows.Forms.MouseEventHandler(btnVerContraseña_MouseUp);
			this.btnRegistraDescargaMasiva.BackColor = System.Drawing.Color.White;
			this.btnRegistraDescargaMasiva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRegistraDescargaMasiva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRegistraDescargaMasiva.Enabled = false;
			this.btnRegistraDescargaMasiva.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold);
			this.btnRegistraDescargaMasiva.Image = LeeXML.Properties.Resources.AceptarChico;
			this.btnRegistraDescargaMasiva.Location = new System.Drawing.Point(417, 59);
			this.btnRegistraDescargaMasiva.Margin = new System.Windows.Forms.Padding(4);
			this.btnRegistraDescargaMasiva.Name = "btnRegistraDescargaMasiva";
			this.btnRegistraDescargaMasiva.Size = new System.Drawing.Size(88, 63);
			this.btnRegistraDescargaMasiva.TabIndex = 171;
			this.btnRegistraDescargaMasiva.Text = "Guardar";
			this.btnRegistraDescargaMasiva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRegistraDescargaMasiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRegistraDescargaMasiva.UseVisualStyleBackColor = false;
			this.btnRegistraDescargaMasiva.Click += new System.EventHandler(btnRegistraDescargaMasiva_Click);
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripStatusLabel1, this.toolStripProgressBar1 });
			this.statusStrip1.Location = new System.Drawing.Point(3, 168);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(508, 26);
			this.statusStrip1.TabIndex = 170;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 18);
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label33.Location = new System.Drawing.Point(16, 78);
			this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(159, 24);
			this.label33.TabIndex = 16;
			this.label33.Text = "Contraseña CIEC:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(540, 227);
			base.Controls.Add(this.gbDatosDescargaMasiva);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4);
			base.Name = "RegistroCIEC";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registro de CIEC";
			base.Load += new System.EventHandler(Empresas_Load);
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.gbDatosDescargaMasiva.ResumeLayout(false);
			this.gbDatosDescargaMasiva.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
