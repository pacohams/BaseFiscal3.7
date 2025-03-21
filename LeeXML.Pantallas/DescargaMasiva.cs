using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
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
	public class DescargaMasiva : FormBase
	{
		private List<EntUsuario> ListaLicenciasDescargaMasiva;

		private IContainer components = null;

		private OpenFileDialog ofdBuscaArchivo;

		private BindingSource entEmpresaBindingSource;

		private BindingSource entCatalogoGenericoBindingSource;

		private DataGridViewTextBoxColumn TipoTasa;

		private BindingSource entUsuarioBindingSource;

		private GroupBox gbDatosDescargaMasiva;

		private Button btnRegistraDescargaMasiva;

		private StatusStrip statusStrip1;

		private Panel panel2;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Label lbRutaDescarga;

		private Label label1;

		private Timer tmVerificaDescargaMasivaSAT;

		private Timer tmVerificaDescargaMasivaSAT2;

		private ToolStripSplitButton tsbCancelaDescargaMasiva;

		private Label lbIntentoDescarga;

		private StatusStrip statusStrip2;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripProgressBar toolStripProgressBar1;

		public EntEmpresa EmpresaRegistra { get; set; }

		public string RutaDescargaMasiva => lbRutaDescarga.Text;

		private List<razonesSociales> ListaRS { get; set; }

		private bool RfcEncontrado { get; set; }

		private int IntentosDescarga { get; set; }

		public DateTime MesFechaSeleccionado => new DateTime(Convert.ToInt32(cmbAñoComprobantes.Text), cmbMesesComprobantes.SelectedIndex + 1, 1);

		private string MensajeDescargaM { get; set; }

		private string RutaHTTPDescargaMasivaSAT { get; set; }

		private string EmisorReceptor { get; set; }

		public DescargaMasiva(EntEmpresa EmpresaRegistra, bool Emitidos)
		{
			InitializeComponent();
			this.EmpresaRegistra = EmpresaRegistra;
			if (Emitidos)
			{
				EmisorReceptor = "emisor";
			}
			else
			{
				EmisorReceptor = "receptor";
			}
		}

		public void CargaLicencias(int CompañiaId)
		{
			ListaLicenciasDescargaMasiva = new BusUsuarios().ObtieneLicenciasDescargaMasivaActivas(CompañiaId);
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

		private void Empresas_Load(object sender, EventArgs e)
		{
			try
			{
				CargaLicencias(Program.UsuarioSeleccionado.CompañiaId);
				if (ListaLicenciasDescargaMasiva.Count == 0 && (!(Program.UsuarioSeleccionado.Usuario == "sys") || !(Program.UsuarioSeleccionado.Contraseña == "5fb552a76ef3c7ee67681d80e9797e088a6c9859")))
				{
					gbDatosDescargaMasiva.Enabled = false;
					statusStrip1.Visible = false;
				}
				else
				{
					CargaAñosCmb(cmbAñoComprobantes);
					cmbMesesComprobantes.SelectedIndex = DateTime.Today.Month - 1;
					cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbAñoComprobantes_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				string rutaDescarga = "C:/BASEFISCALXML/" + EmpresaRegistra.RFC + "/" + EmisorReceptor.ToUpper();
				if (!string.IsNullOrWhiteSpace(cmbAñoComprobantes.Text) && !string.IsNullOrWhiteSpace(cmbMesesComprobantes.Text))
				{
					lbRutaDescarga.Text = rutaDescarga + "/" + cmbAñoComprobantes.Text + "/" + cmbMesesComprobantes.Text.Remove(3).ToUpper();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
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

		private void VerificaLicenciaDescargaMasiva()
		{
			CargaLicencias(Program.UsuarioSeleccionado.CompañiaId);
			if (ListaLicenciasDescargaMasiva.Count == 0 && (!(Program.UsuarioSeleccionado.Usuario == "sys") || !(Program.UsuarioSeleccionado.Contraseña == "5fb552a76ef3c7ee67681d80e9797e088a6c9859")))
			{
				MandaExcepcion("NO CUENTA CON LICENCIA DE DESCARGA MASIVA ACTIVA");
			}
		}

		private async Task DescargaMasivaSAT(string RFC, DateTime FechaDesde, DateTime FechaHasta)
		{
			toolStripProgressBar1.Value = 1;
			if (FechaHasta > DateTime.Today)
			{
				FechaHasta = DateTime.Today;
			}
			string fechaInicio = FechaDesde.ToString("yyy-MM-dd");
			string fechaFin = FechaHasta.ToString("yyy-MM-dd");
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/multicomprobantes/solicitar");
			StringContent content = new StringContent("{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"fechaInicio\":\"" + fechaInicio + "\",\r\n\"fechaFin\":\"" + fechaFin + "\",\r\n\"rfc\":[\"" + RFC + "\"],\r\n\"peticion\":\"" + EmisorReceptor + "\",\r\n\"uuid\":\"\",\r\n\"tipo\":\"\",\r\n\"serie\":\"\",\r\n\"montoMin\":0,\r\n\"montoMax\":0\r\n}", (Encoding)null, "application/json");
			request.Content = (HttpContent)(object)content;
			toolStripProgressBar1.Value = 25;
			_ = "{\r\n\"userPade\":\"pavel_tiim@hotmail.com\",\r\n\"passPade\":\"Fuckoo06!\",\r\n\"contrato\":\"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"fechaInicio\":\"" + fechaInicio + "\",\r\n\"fechaFin\":\"" + fechaFin + "\",\r\n\"rfc\":[\"" + RFC + "\"],\r\n\"peticion\":\"" + EmisorReceptor + "\",\r\n\"uuid\":\"\",\r\n\"tipo\":\"\",\r\n\"serie\":\"\",\r\n\"montoMin\":0,\r\n\"montoMax\":0\r\n}";
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			EntResponseSATjson myObject = new EntResponseSATjson();
			if (response.IsSuccessStatusCode)
			{
				toolStripProgressBar1.Value = 100;
				myObject = JsonConvert.DeserializeObject<EntResponseSATjson>(await response.Content.ReadAsStringAsync());
				MensajeDescargaM = myObject.mensaje;
				toolStripStatusLabel1.Text = myObject.mensaje + " | " + myObject.solicitud + " | DESCARGANDO";
				toolStripProgressBar1.Value = 50;
			}
			statusStrip1.Text = myObject.solicitud;
		}

		private async Task Verifica(string Solicitud)
		{
			toolStripProgressBar1.Value = 1;
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://dm.pade.mx/multicomprobantes/verificar");
			StringContent content = new StringContent("{\r\n\"userPade\": \"pavel_tiim@hotmail.com \",\r\n\"passPade\": \"Fuckoo06!\",\r\n\"contrato\": \"2dc8a2a7-35ec-4bae-85d1-ee00c4f8dda0\",\r\n\"solicitud\": \"" + Solicitud + "\"\r\n}", (Encoding)null, "application/json");
			toolStripProgressBar1.Value = 25;
			request.Content = (HttpContent)(object)content;
			HttpResponseMessage response = await client.SendAsync(request);
			toolStripProgressBar1.Value = 50;
			response.EnsureSuccessStatusCode();
			toolStripProgressBar1.Value = 75;
			new EntResponseSATjson();
			if (response.IsSuccessStatusCode)
			{
				JObject jsonObject = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
				RutaHTTPDescargaMasivaSAT = jsonObject["respuesta"].ToString();
				toolStripStatusLabel1.Text = toolStripStatusLabel1.Text.Replace(" | " + jsonObject["mensaje"].ToString(), "") + " | " + jsonObject["mensaje"].ToString();
				toolStripProgressBar1.Value = 100;
			}
		}

		private void RevisaMensajeError(string MensajeDescargaMasiva)
		{
			if (MensajeDescargaMasiva == "Parametros incorrectos")
			{
				MandaExcepcion(MensajeDescargaM);
			}
		}

		private void DescargaArchivoFromURL(string URL, string RutaDestino)
		{
			using (WebClient webClient = new WebClient())
			{
				try
				{
					Uri address = new Uri(URL);
					webClient.DownloadFile(address, RutaDestino);
					MuestraMensaje("Archivo descargado correctamente.");
				}
				catch (Exception ex)
				{
					MuestraMensajeError("Error al descargar el archivo: " + ex.Message, "ERROR EN DESCARGA ARCHIVO URL");
				}
			}
		}

		private string DescargaDescomprimeArchivoDescargaMasivaSAT(string Solicitud, string DireccionHTTPDescargaMasiva, string RutaDestino)
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			CreaDirectorio(RutaDestino);
			using (FileStream fs = new FileStream(RutaDestino + "/" + Solicitud + ".zip", FileMode.Create))
			{
				ZipArchive archivoZip = new ZipArchive((Stream)fs, (ZipArchiveMode)1);
				try
				{
				}
				finally
				{
					((IDisposable)archivoZip)?.Dispose();
				}
			}
			DescargaArchivoFromURL(DireccionHTTPDescargaMasiva.Remove(0, 6).Replace("\"\r\n]", ""), RutaDestino + "/" + Solicitud + ".zip");
			string rutaUltimoZip = RutaDestino + "/" + Solicitud + ".zip";
			DescomprimirArchivo(rutaUltimoZip, RutaDestino);
			return RutaDestino;
		}

		private async void btnRegistraDescargaMasiva_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				base.Enabled = false;
				VerificaLicenciaDescargaMasiva();
				IntentosDescarga = 1;
				DateTime fechaDesde = MesFechaSeleccionado;
				DateTime fechaHasta = ObtieneFechaUltimoDiaMes(fechaDesde.Month, fechaDesde.Year);
				toolStripStatusLabel1.Text = "DESCARGAR";
				await DescargaMasivaSAT(EmpresaRegistra.RFC, fechaDesde, fechaHasta);
				RevisaMensajeError(MensajeDescargaM);
				toolStripProgressBar1.Value = 50;
				tmVerificaDescargaMasivaSAT.Start();
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MuestraExcepcion(ex2, "ERROR EN DESCAERGA MASIVA - COMUNICARSE CON SOPORTE TÉCNICO");
				toolStripStatusLabel1.Text = "";
				toolStripProgressBar1.Value = 0;
				Close();
			}
			finally
			{
				//int num;
				//if (num >= 0)
				//{
				//}
			}
		}

		private async void tmVerificaDescargaMasivaSAT_Tick(object sender, EventArgs e)
		{
			try
			{
				string solicitud = statusStrip1.Text;
				toolStripStatusLabel1.Text += " | VERIFICANDO  SOLICITUD ";
				toolStripProgressBar1.Value = 1;
				await Verifica(solicitud);
				tmVerificaDescargaMasivaSAT.Stop();
				if (!string.IsNullOrWhiteSpace(RutaHTTPDescargaMasivaSAT))
				{
					DescargaDescomprimeArchivoDescargaMasivaSAT(solicitud, RutaHTTPDescargaMasivaSAT, RutaDescargaMasiva);
					base.Enabled = true;
					base.DialogResult = DialogResult.OK;
					if (MuestraMensajeOK("¡DESCARGA DE ARCHIVOS XML LISTA!") == DialogResult.OK)
					{
						Close();
					}
				}
				else
				{
					tmVerificaDescargaMasivaSAT2.Start();
				}
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

		private async void tmVerificaDescargaMasivaSAT2_Tick(object sender, EventArgs e)
		{
			try
			{
				IntentosDescarga++;
				lbIntentoDescarga.Text = "Intento " + IntentosDescarga + "/15";
				string solicitud = statusStrip1.Text;
				tmVerificaDescargaMasivaSAT2.Stop();
				await Verifica(solicitud);
				if (!string.IsNullOrWhiteSpace(RutaHTTPDescargaMasivaSAT))
				{
					tmVerificaDescargaMasivaSAT2.Stop();
					toolStripStatusLabel1.Text += " | VERIFICADA ";
					DescargaDescomprimeArchivoDescargaMasivaSAT(solicitud, RutaHTTPDescargaMasivaSAT, RutaDescargaMasiva);
					toolStripStatusLabel1.Text += " | SOLICITUD DESCARGADA";
					toolStripProgressBar1.Value = 0;
					base.Enabled = true;
					base.DialogResult = DialogResult.OK;
					if (MuestraMensajeOK("¡DESCARGA DE ARCHIVOS XML LISTA!") == DialogResult.OK)
					{
						Close();
					}
				}
				else if (IntentosDescarga < 15)
				{
					tmVerificaDescargaMasivaSAT2.Start();
				}
				else
				{
					IntentosDescarga = 0;
					tmVerificaDescargaMasivaSAT2.Stop();
					tsbCancelaDescargaMasiva.PerformClick();
					MuestraMensajeError("SE HA LLEGADO AL LÍMITE DE INTENTOS DE DESCARGA PARA ESTA SOLICITUD. VUELVA A INTENTAR MÁS TARDE.\n\n *VERIFIQUE QUE LA CIEC ESTE REGISTRADA CORRECTAMENTE. \n\n *ASEGURECE QUE HAYAN TRANSCURRIDO 24 HORAS PARA LA VALIDACIÓN DE LA CIEC.\r\n", "DESCARGA NO COMPLETADA");
					tsbCancelaDescargaMasiva.PerformButtonClick();
					Close();
				}
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

		private void tsbCancelaDescargaMasiva_ButtonClick(object sender, EventArgs e)
		{
			try
			{
				tmVerificaDescargaMasivaSAT.Stop();
				tmVerificaDescargaMasivaSAT2.Stop();
				toolStripProgressBar1.Value = 0;
				toolStripStatusLabel1.Text = "";
				MensajeDescargaM = "";
				lbIntentoDescarga.Text = "";
				Close();
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
			this.statusStrip2 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.lbIntentoDescarga = new System.Windows.Forms.Label();
			this.lbRutaDescarga = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.btnRegistraDescargaMasiva = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.tsbCancelaDescargaMasiva = new System.Windows.Forms.ToolStripSplitButton();
			this.tmVerificaDescargaMasivaSAT = new System.Windows.Forms.Timer(this.components);
			this.tmVerificaDescargaMasivaSAT2 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.gbDatosDescargaMasiva.SuspendLayout();
			this.statusStrip2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			base.SuspendLayout();
			this.ofdBuscaArchivo.FileName = "openFileDialog1";
			this.entEmpresaBindingSource.DataSource = typeof(LeeXMLEntidades.EntEmpresa);
			this.entUsuarioBindingSource.DataSource = typeof(LeeXMLEntidades.EntUsuario);
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.gbDatosDescargaMasiva.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gbDatosDescargaMasiva.Controls.Add(this.statusStrip2);
			this.gbDatosDescargaMasiva.Controls.Add(this.lbIntentoDescarga);
			this.gbDatosDescargaMasiva.Controls.Add(this.lbRutaDescarga);
			this.gbDatosDescargaMasiva.Controls.Add(this.label1);
			this.gbDatosDescargaMasiva.Controls.Add(this.panel2);
			this.gbDatosDescargaMasiva.Controls.Add(this.btnRegistraDescargaMasiva);
			this.gbDatosDescargaMasiva.Controls.Add(this.statusStrip1);
			this.gbDatosDescargaMasiva.Location = new System.Drawing.Point(14, 30);
			this.gbDatosDescargaMasiva.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gbDatosDescargaMasiva.Name = "gbDatosDescargaMasiva";
			this.gbDatosDescargaMasiva.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.gbDatosDescargaMasiva.Size = new System.Drawing.Size(716, 454);
			this.gbDatosDescargaMasiva.TabIndex = 168;
			this.gbDatosDescargaMasiva.TabStop = false;
			this.gbDatosDescargaMasiva.Text = "Descarga Masiva";
			this.statusStrip2.AutoSize = false;
			this.statusStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.toolStripStatusLabel1 });
			this.statusStrip2.Location = new System.Drawing.Point(3, 362);
			this.statusStrip2.Name = "statusStrip2";
			this.statusStrip2.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusStrip2.Size = new System.Drawing.Size(710, 44);
			this.statusStrip2.TabIndex = 176;
			this.statusStrip2.Text = "statusStrip2";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 37);
			this.lbIntentoDescarga.AutoSize = true;
			this.lbIntentoDescarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbIntentoDescarga.Location = new System.Drawing.Point(262, 319);
			this.lbIntentoDescarga.Name = "lbIntentoDescarga";
			this.lbIntentoDescarga.Size = new System.Drawing.Size(14, 20);
			this.lbIntentoDescarga.TabIndex = 175;
			this.lbIntentoDescarga.Text = ".";
			this.lbRutaDescarga.AutoSize = true;
			this.lbRutaDescarga.Location = new System.Drawing.Point(195, 150);
			this.lbRutaDescarga.Name = "lbRutaDescarga";
			this.lbRutaDescarga.Size = new System.Drawing.Size(252, 20);
			this.lbRutaDescarga.TabIndex = 174;
			this.lbRutaDescarga.Text = "C:/BASEFISCAL/RFC/EMITIDOS/";
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(32, 148);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 20);
			this.label1.TabIndex = 173;
			this.label1.Text = "Ruta de Descarga:";
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.cmbMesesComprobantes);
			this.panel2.Controls.Add(this.cmbAñoComprobantes);
			this.panel2.Location = new System.Drawing.Point(172, 26);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(365, 92);
			this.panel2.TabIndex = 172;
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Items.AddRange(new object[12]
			{
				"ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO", "JUNIO", "JULIO", "AGOSTO", "SEPTIEMBRE", "OCTUBRE",
				"NOVIEMBRE", "DICIEMBRE"
			});
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(15, 26);
			this.cmbMesesComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(187, 33);
			this.cmbMesesComprobantes.TabIndex = 21;
			this.cmbMesesComprobantes.SelectedIndexChanged += new System.EventHandler(cmbAñoComprobantes_SelectedIndexChanged);
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(235, 28);
			this.cmbAñoComprobantes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(113, 33);
			this.cmbAñoComprobantes.TabIndex = 22;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.cmbAñoComprobantes.SelectedIndexChanged += new System.EventHandler(cmbAñoComprobantes_SelectedIndexChanged);
			this.btnRegistraDescargaMasiva.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnRegistraDescargaMasiva.BackColor = System.Drawing.Color.White;
			this.btnRegistraDescargaMasiva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRegistraDescargaMasiva.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRegistraDescargaMasiva.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold);
			this.btnRegistraDescargaMasiva.Image = LeeXML.Properties.Resources.recibidos_cfdi_descargar;
			this.btnRegistraDescargaMasiva.Location = new System.Drawing.Point(190, 214);
			this.btnRegistraDescargaMasiva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.btnRegistraDescargaMasiva.Name = "btnRegistraDescargaMasiva";
			this.btnRegistraDescargaMasiva.Size = new System.Drawing.Size(334, 92);
			this.btnRegistraDescargaMasiva.TabIndex = 171;
			this.btnRegistraDescargaMasiva.Text = "Descargar";
			this.btnRegistraDescargaMasiva.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRegistraDescargaMasiva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnRegistraDescargaMasiva.UseVisualStyleBackColor = false;
			this.btnRegistraDescargaMasiva.Click += new System.EventHandler(btnRegistraDescargaMasiva_Click);
			this.statusStrip1.AutoSize = false;
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.toolStripProgressBar1, this.tsbCancelaDescargaMasiva });
			this.statusStrip1.Location = new System.Drawing.Point(3, 406);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
			this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.statusStrip1.Size = new System.Drawing.Size(710, 44);
			this.statusStrip1.TabIndex = 170;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(601, 36);
			this.tsbCancelaDescargaMasiva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCancelaDescargaMasiva.Image = LeeXML.Properties.Resources.X;
			this.tsbCancelaDescargaMasiva.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCancelaDescargaMasiva.Name = "tsbCancelaDescargaMasiva";
			this.tsbCancelaDescargaMasiva.Size = new System.Drawing.Size(41, 41);
			this.tsbCancelaDescargaMasiva.Text = "toolStripSplitButton1";
			this.tsbCancelaDescargaMasiva.ButtonClick += new System.EventHandler(tsbCancelaDescargaMasiva_ButtonClick);
			this.tmVerificaDescargaMasivaSAT.Interval = 25000;
			this.tmVerificaDescargaMasivaSAT.Tick += new System.EventHandler(tmVerificaDescargaMasivaSAT_Tick);
			this.tmVerificaDescargaMasivaSAT2.Interval = 5000;
			this.tmVerificaDescargaMasivaSAT2.Tick += new System.EventHandler(tmVerificaDescargaMasivaSAT2_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			base.ClientSize = new System.Drawing.Size(742, 499);
			base.Controls.Add(this.gbDatosDescargaMasiva);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "DescargaMasiva";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Descarga Masiva - Base Fiscal XML";
			base.Load += new System.EventHandler(Empresas_Load);
			((System.ComponentModel.ISupportInitialize)this.entEmpresaBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entUsuarioBindingSource).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.gbDatosDescargaMasiva.ResumeLayout(false);
			this.gbDatosDescargaMasiva.PerformLayout();
			this.statusStrip2.ResumeLayout(false);
			this.statusStrip2.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
