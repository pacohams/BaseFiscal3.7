using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.OpenSsl;

namespace LeeXML.Pantallas
{
	public class RegistroFIEL : FormBase
	{
		public class PasswordFinder : IPasswordFinder
		{
			private readonly string password;

			public PasswordFinder(string password)
			{
				this.password = password;
			}

			public char[] GetPassword()
			{
				return password.ToCharArray();
			}
		}

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

		private Button btnSeleccionaRutaRecibidos;

		private TextBox txtRutaRecibidos;

		private Label label8;

		private Button btnCargaXMLs;

		private TextBox txtRuta;

		private Label label89;

		private Button btnGuardaFIEL;

		public EntEmpresa EmpresaRegistra { get; set; }

		private List<razonesSociales> ListaRS { get; set; }

		private bool RfcEncontrado { get; set; }

		private void InicializaPantalla()
		{
			dtpFechaInicioSinc.Value = new DateTime(DateTime.Today.Year, 1, 1);
			dtpFechaInicioSinc.MinDate = new DateTime(DateTime.Today.AddYears(-1).Year, 1, 1);
		}

		public RegistroFIEL(EntEmpresa EmpresaRegistra)
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

		private async Task RegistrarFIEL(string RazonSocial, string RFC, string PFXbase64, string PassPfx, DateTime FechaInicial)
		{
			toolStripProgressBar1.Value = 1;
			string fechaInicio = FechaInicial.Year + "-" + FechaInicial.Month.ToString().PadLeft(2, '0') + "-" + FechaInicial.Day.ToString().PadLeft(2, '0');
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/razon-social/create");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"razonSocial\":\"" + RazonSocial + "\",\r\n\"fechaInicioSync\":\"" + fechaInicio + "\",\r\n\"maxComprobantesMensual\":\"1000\",\r\n\"celular\":\"+525539904089\",\r\n\"fiel\":{\"pfx\":\"" + PFXbase64.Replace(" ", string.Empty).Replace("\r\n", string.Empty).Replace("\n", string.Empty)
				.Trim() + "\",\"passPfx\":\"" + PassPfx + "\"},\r\n\"ciec\":{\"rfc\":\"\",\"passCiec\":\"\"},\r\n\"sync\":\"fiel\"\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			_ = "{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"-------\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"razonSocial\":\"" + RazonSocial + "\",\r\n\"fechaInicioSync\":\"" + fechaInicio + "\",\r\n\"maxComprobantesMensual\":\"1000\",\r\n\"celular\":\"+525539904089\",\r\n\"fiel\":{\"pfx\":\"" + PFXbase64.Trim() + "\",\"passPfx\":\"" + PassPfx + "\"},\r\n\"ciec\":{\"rfc\":\"\",\"passCiec\":\"\"},\r\n\"sync\":\"fiel\"\r\n}";
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

		public string ImprimirPropiedades(object obj)
		{
			StringBuilder sbTexto = new StringBuilder();
			Type type = obj.GetType();
			PropertyInfo[] properties = type.GetProperties();
			PropertyInfo[] array = properties;
			foreach (PropertyInfo property in array)
			{
				string nombre = property.Name;
				object valor = property.GetValue(obj);
				sbTexto.Append($"{nombre}: {valor}");
			}
			return sbTexto.ToString();
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
					MuestraMensaje("RFC REGISTRADO CORRECTAMENTE\n" + ImprimirPropiedades(((object)ListaRS.Last()).ToString()));
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
			await RegistraCIEC(EmpresaRegistra.NombreFiscal, EmpresaRegistra.RFC, txtContraseñaCIEC.Text);
		}

		private async Task RegistraCIEC(string NombreFiscal, string RFC, string ContraseñaCIEC)
		{
			ObtieneFechaPrimerDiaMes(1, DateTime.Today.AddYears(-1).Year);
			DateTime fechaInicio = dtpFechaInicioSinc.Value;
			string filePath = txtRuta.Text;
			string content = File.ReadAllText(filePath);
			await RegistrarFIEL(NombreFiscal, RFC, content, ContraseñaCIEC, fechaInicio);
		}

		private async Task ActualizarCIEC(string RFC, string ContraseñaCIEC)
		{
			await Actualizar(RFC, ContraseñaCIEC);
		}

		private static string SelectFile(string title, string filter)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Title = title;
				openFileDialog.Filter = filter;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					return openFileDialog.FileName;
				}
			}
			return null;
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
				}
				else
				{
					base.Enabled = false;
					toolStripStatusLabel1.Text = "REGISTRANDO..";
					await BuscaRFCregistrado(EmpresaRegistra.RFC);
				}
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
				if (MuestraMensajeOK("FIEL CAPTURADA, ESPERA 24 HORAS PARA LA VALIDACIÓN DE LA MISMA Y PODER UTILIZAR DESCARGA MASIVA.") == DialogResult.OK)
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
				}
				else
				{
					lbContraseñaIncorrecta.Visible = false;
					if (txtContraseñaCIEC.TextLength < 8)
					{
						lbCaracteresInvalido.Visible = true;
					}
					else
					{
						lbCaracteresInvalido.Visible = false;
						btnRegistraDescargaMasiva.Enabled = true;
					}
				}
				btnGuardaFIEL.Enabled = true;
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

		private async void btnGuardaFIEL_Click(object sender, EventArgs e)
		{
			try
			{
				base.Enabled = false;
				toolStripStatusLabel1.Text = "REGISTRANDO..";
				await BuscaRFCregistrado(EmpresaRegistra.RFC);
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
				if (MuestraMensajeOK("FIEL CAPTURADA, ESPERA 24 HORAS PARA LA VALIDACIÓN DE LA MISMA Y PODER UTILIZAR DESCARGA MASIVA.") == DialogResult.OK)
				{
					Close();
				}
			}
		}

		private void btnCargaXMLs_Click(object sender, EventArgs e)
		{
			txtRuta.Text = SelectFile("Selecciona el archivo .txt", "Archivos TXT (*.txt)|*.txt");
			if (string.IsNullOrEmpty(txtRuta.Text))
			{
				MandaExcepcion("No se seleccionó ningún archivo .txt.");
			}
		}

		private void btnSeleccionaRutaRecibidos_Click(object sender, EventArgs e)
		{
			txtRutaRecibidos.Text = SelectFile("Selecciona el archivo .key", "Archivos KEY (*.key)|*.key");
			if (string.IsNullOrEmpty(txtRutaRecibidos.Text))
			{
				MandaExcepcion("No se seleccionó ningún archivo .key.");
			}
		}

		private void RegistroFIEL_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (base.DialogResult != DialogResult.OK)
			{
				e.Cancel = true;
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
			this.btnSeleccionaRutaRecibidos = new System.Windows.Forms.Button();
			this.txtRutaRecibidos = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnCargaXMLs = new System.Windows.Forms.Button();
			this.txtRuta = new System.Windows.Forms.TextBox();
			this.label89 = new System.Windows.Forms.Label();
			this.btnGuardaFIEL = new System.Windows.Forms.Button();
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
			this.gbDatosDescargaMasiva.Location = new System.Drawing.Point(14, 30);
			this.gbDatosDescargaMasiva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gbDatosDescargaMasiva.Name = "gbDatosDescargaMasiva";
			this.gbDatosDescargaMasiva.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gbDatosDescargaMasiva.Size = new System.Drawing.Size(578, 246);
			this.gbDatosDescargaMasiva.TabIndex = 168;
			this.gbDatosDescargaMasiva.TabStop = false;
			this.gbDatosDescargaMasiva.Text = "Registrar para Descarga Masiva";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(14, 44);
			this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(283, 22);
			this.label2.TabIndex = 178;
			this.label2.Text = "Fecha Inicio Descarga Masiva:";
			this.dtpFechaInicioSinc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.dtpFechaInicioSinc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtpFechaInicioSinc.Location = new System.Drawing.Point(322, 42);
			this.dtpFechaInicioSinc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.dtpFechaInicioSinc.Name = "dtpFechaInicioSinc";
			this.dtpFechaInicioSinc.Size = new System.Drawing.Size(137, 25);
			this.dtpFechaInicioSinc.TabIndex = 177;
			this.dtpFechaInicioSinc.ValueChanged += new System.EventHandler(dtpFechaInicioSinc_ValueChanged);
			this.dtpFechaInicioSinc.Leave += new System.EventHandler(dtpFechaInicioSinc_Leave);
			this.lbCaracteresInvalido.AutoSize = true;
			this.lbCaracteresInvalido.ForeColor = System.Drawing.Color.IndianRed;
			this.lbCaracteresInvalido.Location = new System.Drawing.Point(212, 176);
			this.lbCaracteresInvalido.Name = "lbCaracteresInvalido";
			this.lbCaracteresInvalido.Size = new System.Drawing.Size(175, 20);
			this.lbCaracteresInvalido.TabIndex = 176;
			this.lbCaracteresInvalido.Text = "Deben ser 8 caracteres";
			this.lbCaracteresInvalido.Visible = false;
			this.lbContraseñaIncorrecta.AutoSize = true;
			this.lbContraseñaIncorrecta.ForeColor = System.Drawing.Color.IndianRed;
			this.lbContraseñaIncorrecta.Location = new System.Drawing.Point(214, 176);
			this.lbContraseñaIncorrecta.Name = "lbContraseñaIncorrecta";
			this.lbContraseñaIncorrecta.Size = new System.Drawing.Size(198, 20);
			this.lbContraseñaIncorrecta.TabIndex = 175;
			this.lbContraseñaIncorrecta.Text = "Contraseñas No Coinciden";
			this.lbContraseñaIncorrecta.Visible = false;
			this.txtContraseñaCIEC.Location = new System.Drawing.Point(207, 98);
			this.txtContraseñaCIEC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtContraseñaCIEC.MaxLength = 18;
			this.txtContraseñaCIEC.Name = "txtContraseñaCIEC";
			this.txtContraseñaCIEC.PasswordChar = '*';
			this.txtContraseñaCIEC.Size = new System.Drawing.Size(202, 26);
			this.txtContraseñaCIEC.TabIndex = 15;
			this.txtContraseñaCIEC.TextChanged += new System.EventHandler(txtConfirmaCIEC_TextChanged);
			this.txtConfirmaCIEC.Location = new System.Drawing.Point(207, 145);
			this.txtConfirmaCIEC.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtConfirmaCIEC.MaxLength = 18;
			this.txtConfirmaCIEC.Name = "txtConfirmaCIEC";
			this.txtConfirmaCIEC.PasswordChar = '*';
			this.txtConfirmaCIEC.Size = new System.Drawing.Size(202, 26);
			this.txtConfirmaCIEC.TabIndex = 173;
			this.txtConfirmaCIEC.TextChanged += new System.EventHandler(txtConfirmaCIEC_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(43, 144);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 29);
			this.label1.TabIndex = 174;
			this.label1.Text = "Confirma CIEC: ";
			this.btnVerContraseña.BackColor = System.Drawing.Color.Transparent;
			this.btnVerContraseña.BackgroundImage = LeeXML.Properties.Resources.VistaPreviaSinFondo;
			this.btnVerContraseña.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnVerContraseña.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnVerContraseña.Location = new System.Drawing.Point(412, 89);
			this.btnVerContraseña.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnVerContraseña.Name = "btnVerContraseña";
			this.btnVerContraseña.Size = new System.Drawing.Size(52, 38);
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
			this.btnRegistraDescargaMasiva.Location = new System.Drawing.Point(469, 74);
			this.btnRegistraDescargaMasiva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRegistraDescargaMasiva.Name = "btnRegistraDescargaMasiva";
			this.btnRegistraDescargaMasiva.Size = new System.Drawing.Size(99, 79);
			this.btnRegistraDescargaMasiva.TabIndex = 171;
			this.btnRegistraDescargaMasiva.Text = "Guardar";
			this.btnRegistraDescargaMasiva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRegistraDescargaMasiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRegistraDescargaMasiva.UseVisualStyleBackColor = false;
			this.btnRegistraDescargaMasiva.Click += new System.EventHandler(btnRegistraDescargaMasiva_Click);
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripStatusLabel1, this.toolStripProgressBar1 });
			this.statusStrip1.Location = new System.Drawing.Point(3, 212);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.Size = new System.Drawing.Size(572, 30);
			this.statusStrip1.TabIndex = 170;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 23);
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(338, 22);
			this.label33.AutoSize = true;
			this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label33.Location = new System.Drawing.Point(18, 98);
			this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(204, 29);
			this.label33.TabIndex = 16;
			this.label33.Text = "Contraseña CIEC:";
			this.btnSeleccionaRutaRecibidos.BackColor = System.Drawing.Color.White;
			this.btnSeleccionaRutaRecibidos.BackgroundImage = LeeXML.Properties.Resources.Folder_Search;
			this.btnSeleccionaRutaRecibidos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnSeleccionaRutaRecibidos.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSeleccionaRutaRecibidos.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.btnSeleccionaRutaRecibidos.Location = new System.Drawing.Point(602, 357);
			this.btnSeleccionaRutaRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnSeleccionaRutaRecibidos.Name = "btnSeleccionaRutaRecibidos";
			this.btnSeleccionaRutaRecibidos.Size = new System.Drawing.Size(54, 60);
			this.btnSeleccionaRutaRecibidos.TabIndex = 174;
			this.btnSeleccionaRutaRecibidos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnSeleccionaRutaRecibidos.UseVisualStyleBackColor = false;
			this.btnSeleccionaRutaRecibidos.Click += new System.EventHandler(btnSeleccionaRutaRecibidos_Click);
			this.txtRutaRecibidos.Location = new System.Drawing.Point(6, 384);
			this.txtRutaRecibidos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRutaRecibidos.Name = "txtRutaRecibidos";
			this.txtRutaRecibidos.Size = new System.Drawing.Size(586, 26);
			this.txtRutaRecibidos.TabIndex = 173;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new System.Drawing.Point(4, 357);
			this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(191, 22);
			this.label8.TabIndex = 172;
			this.label8.Text = "Ruta XML's Recibidos:";
			this.btnCargaXMLs.BackColor = System.Drawing.Color.White;
			this.btnCargaXMLs.BackgroundImage = LeeXML.Properties.Resources.Folder_Search;
			this.btnCargaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCargaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCargaXMLs.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.btnCargaXMLs.Location = new System.Drawing.Point(602, 289);
			this.btnCargaXMLs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnCargaXMLs.Name = "btnCargaXMLs";
			this.btnCargaXMLs.Size = new System.Drawing.Size(54, 60);
			this.btnCargaXMLs.TabIndex = 171;
			this.btnCargaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCargaXMLs.UseVisualStyleBackColor = false;
			this.btnCargaXMLs.Click += new System.EventHandler(btnCargaXMLs_Click);
			this.txtRuta.Location = new System.Drawing.Point(6, 318);
			this.txtRuta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.txtRuta.Name = "txtRuta";
			this.txtRuta.Size = new System.Drawing.Size(586, 26);
			this.txtRuta.TabIndex = 170;
			this.label89.AutoSize = true;
			this.label89.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label89.Location = new System.Drawing.Point(4, 291);
			this.label89.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(180, 22);
			this.label89.TabIndex = 169;
			this.label89.Text = "Ruta XML's Emitidos:";
			this.btnGuardaFIEL.BackColor = System.Drawing.Color.White;
			this.btnGuardaFIEL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnGuardaFIEL.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGuardaFIEL.Enabled = false;
			this.btnGuardaFIEL.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold);
			this.btnGuardaFIEL.Image = LeeXML.Properties.Resources.AceptarChico;
			this.btnGuardaFIEL.Location = new System.Drawing.Point(265, 420);
			this.btnGuardaFIEL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnGuardaFIEL.Name = "btnGuardaFIEL";
			this.btnGuardaFIEL.Size = new System.Drawing.Size(99, 79);
			this.btnGuardaFIEL.TabIndex = 175;
			this.btnGuardaFIEL.Text = "Guardar FIEL";
			this.btnGuardaFIEL.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnGuardaFIEL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardaFIEL.UseVisualStyleBackColor = false;
			this.btnGuardaFIEL.Click += new System.EventHandler(btnGuardaFIEL_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(672, 541);
			base.Controls.Add(this.btnGuardaFIEL);
			base.Controls.Add(this.btnSeleccionaRutaRecibidos);
			base.Controls.Add(this.txtRutaRecibidos);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.btnCargaXMLs);
			base.Controls.Add(this.txtRuta);
			base.Controls.Add(this.label89);
			base.Controls.Add(this.gbDatosDescargaMasiva);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "RegistroFIEL";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Registro de CIEC";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(RegistroFIEL_FormClosing);
			base.Load += new System.EventHandler(Empresas_Load);
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.gbDatosDescargaMasiva.ResumeLayout(false);
			this.gbDatosDescargaMasiva.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
