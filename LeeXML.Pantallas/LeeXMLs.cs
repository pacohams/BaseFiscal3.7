using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeeXML.Pantallas
{
	public class LeeXMLs : FormBase
	{
		private List<EntFactura> ListaComplementosPagoSinReferenciaImportada;

		private List<EntFactura> ListaAnticiposSinReferenciaImportada;

		private List<EntFactura> ListaFacturaEgresoSinReferenciaImportada;

		private List<EntUsuario> ListaLicenciasDescargaMasiva;

		private Cargando carga;

		private int intentosDescarga = 0;

		private IContainer components = null;

		private DataGridView gvXMLs;

		private Button btnCargaXMLs;

		private TextBox txtRutaCarpeta;

		private TabControl tcPedidosGrids;

		private TabPage tabPage1;

		private Button btnExportar;

		private Label label3;

		private TextBox txtCantidadVentas;

		private Button btnRefrescaCargaArchivo;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private RadioButton rdoRecibidos;

		private RadioButton rdoEmitidos;

		private FlowLayoutPanel flowLayoutPanel1;

		private Button btnImportaXMLs;

		private GroupBox gbDatosGenerales;

		private Label label4;

		private TextBox txtNombreFiscal;

		private TextBox txtRFC;

		private Label label5;

		private Panel pnlGeneral;

		private Label label1;

		private DataGridViewTextBoxColumn TipoComprobanteGridViewTextBoxColumn;

		private FlowLayoutPanel flpTotalesTodos;

		private Label label2;

		private TextBox txtSubTotal;

		private ToolStrip toolStrip1;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstxtIVA;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImporte;

		private Label label6;

		private TextBox txtNumComprobantes;

		private Button btnDescargaSAT;

		private GroupBox gbCFDISnoImporta;

		private FlowLayoutPanel flowLayoutPanel2;

		private Label label7;

		private TextBox txtSubTotalRestringidos;

		private Label label8;

		private TextBox txtNumComprobantesRestringidos;

		private ToolStrip toolStrip2;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox toolStripTextBox1;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox toolStripTextBox2;

		private DataGridView gvXMLsRestringidos;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

		private Panel pnlCFDISimporta;

		private DataGridViewTextBoxColumn versionDataGridViewTextBoxColumn;

		private NotifyIcon notifyIcon1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;

		private DataGridViewTextBoxColumn rFCDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn uUIDDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn subTotalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn gvColumnImporteDR;

		private DataGridViewTextBoxColumn iVADataGridViewTextBoxColumn;

		private new DataGridViewTextBoxColumn IEPS;

		private DataGridViewTextBoxColumn IVARetenciones;

		private DataGridViewTextBoxColumn ISRRetenciones;

		private DataGridViewTextBoxColumn retencionesDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn Moneda;

		private DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;

		private DataGridViewTextBoxColumn gvColumnTipoComprobante;

		private DataGridViewTextBoxColumn MetodoPago;

		private DataGridViewTextBoxColumn FormaPago;

		private DataGridViewTextBoxColumn UUIDrelacionado;

		private DataGridViewTextBoxColumn Descripcion;

		private Button btnDescargaMasivaSAT;

		private StatusStrip statusStrip1;

		private Timer tmVerificaDescargaMasivaSAT;

		private Timer tmVerificaDescargaMasivaSAT2;

		private Button btnVerificaDescargaMasivaSAT;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripProgressBar toolStripProgressBar1;

		private ToolStripSplitButton tsbCancelaDescargaMasiva;

		private LinkLabel lnkDescargaMasiva;

		private ComboBox cmbEmpresas;

		private LinkLabel linkLabel1;

		private FlowLayoutPanel flpEmpresas;

		private Label label24;

		private Button btnBuscaEmpresa;

		private List<EntFactura> ListaCP { get; set; }

		private List<EntFactura> ListaCP40 { get; set; }

		private List<EntFactura> ListaCP40adicionales { get; set; }

		private List<EntFactura> ListaFacturas40adicionales { get; set; }

		private List<EntCatalogoPercepciones> ListaPercepciones { get; set; }

		private List<EntCatalogoPercepciones> ListaDeducciones { get; set; }

		private List<razonesSociales> ListaRS { get; set; }

		private string mensajeDescargaM { get; set; }

		private string RutaHTTPDescargaMasivaSAT { get; set; }

		private bool RfcEncontrado { get; set; }

		private string PaginaDescarga { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public LeeXMLs()
		{
			InitializeComponent();
			base.Size = new Size(500, 500);
		}

		private int AgregarComprobanteFiscal(EntFactura Factura)
		{
			return new BusFacturas().AgregaComprobantesFiscalesNeue(Factura);
		}

		private int AgregarComprobanteFiscalPercepcion(EntCatalogoPercepciones FacturaPercepcion)
		{
			return new BusFacturas().AgregaComprobantesFiscalesPercepcion(FacturaPercepcion);
		}

		private int AgregarComprobanteFiscalDeduccion(EntCatalogoPercepciones FacturaPercepcion)
		{
			return new BusFacturas().AgregaComprobantesFiscalesDeduccion(FacturaPercepcion);
		}

		private void RevisaEmitidos(EntEmpresa EmpresaSeleccionada, List<EntFactura> ListaFacturas)
		{
			foreach (EntFactura f in ListaFacturas)
			{
				if (f.RFC == EmpresaSeleccionada.RFC)
				{
					MandaExcepcion("SE ENCONTRARON ARCHIVOS QUE NO CORRESPONDEN A FACTURAS DE INGRESO. \n \n    RFC EMISOR: " + f.EmisorRFC + "\n     FACTURA: " + f.SerieFactura + f.NumeroFactura + "\n     UUID: " + f.UUID + "\n\n");
				}
				else if (f.EmisorRFC != EmpresaSeleccionada.RFC)
				{
					MandaExcepcion("SE ENCONTRARON ARCHIVOS QUE NO CORRESPONDEN A LA EMPRESA EMISORA. \n \n    RFC: " + f.EmisorRFC + "\n    EMPRESA: " + f.EmisorNombre + "\n\n");
				}
			}
		}

		private int RevisaAgregaCliente(string Nombre, string RFC, int TipoComprobanteId)
		{
			int clienteId = 0;
			int tipoPersonaId = 0;
			List<EntCliente> lst = new BusClientes().ObtieneClientes(base.EmpresaSeleccionada.Id, RFC);
			if (lst.Count == 0)
			{
				if (TipoComprobanteId == 4)
				{
					tipoPersonaId = 3;
				}
				if (Nombre == null)
				{
					Nombre = "";
				}
				EntCliente c = new EntCliente
				{
					EmpresaId = base.EmpresaSeleccionada.Id,
					Nombre = RFC.Remove(3) + "-",
					NombreFiscal = Nombre,
					RFC = RFC,
					TipoPersonaId = tipoPersonaId,
					Direccion = "",
					Telefono = "",
					Telefono2 = "",
					Celular = "",
					Email = "",
					Email2 = "",
					Email3 = "",
					Calle = "",
					NoExterior = "",
					NoInterior = "",
					Colonia = "",
					Localidad = "",
					Municipio = "",
					Estado = "",
					CP = "",
					Banco = "",
					NumeroCuenta = "",
					Sucursal = "",
					CLABE = "",
					NumeroReferencia = "",
					FormaPagoId = 0,
					Fecha = DateTime.Today
				};
				Nombre = ((Nombre.Length <= 2) ? (Nombre + Nombre) : (Nombre + Nombre.Remove(2)));
				return new BusClientes().AgregaCliente(c);
			}
			return lst[0].Id;
		}

		private EntFactura ConvierteFacturaEnFacturaCP(EntFactura FacturaBase)
		{
			return new EntFactura
			{
				Id = FacturaBase.Id,
				EmpresaId = FacturaBase.EmpresaId,
				UsuarioId = FacturaBase.UsuarioId,
				EmisorNombre = FacturaBase.EmisorNombre,
				EmisorRFC = FacturaBase.EmisorRFC,
				Nombre = FacturaBase.Nombre,
				RFC = FacturaBase.RFC,
				TipoComprobanteId = FacturaBase.TipoComprobanteId,
				TipoComprobante = FacturaBase.TipoComprobante,
				SerieFactura = FacturaBase.SerieFactura,
				NumeroFactura = FacturaBase.NumeroFactura,
				IVARetenciones = FacturaBase.IVARetenciones,
				ISRRetenciones = FacturaBase.ISRRetenciones,
				Retenciones = FacturaBase.Retenciones,
				IVA = FacturaBase.IVA,
				IEPS = FacturaBase.IEPS,
				Total = FacturaBase.Total,
				TotalUSD = FacturaBase.TotalUSD,
				SubTotal = FacturaBase.Total - FacturaBase.IVA - FacturaBase.IEPS + FacturaBase.Retenciones,
				Descuento = FacturaBase.Descuento,
				Fecha = FacturaBase.Fecha,
				MonedaId = FacturaBase.MonedaId,
				Moneda = FacturaBase.Moneda,
				TipoCambio = FacturaBase.TipoCambio,
				EquivalenciaDR = 1m,
				MetodoPagoId = 2,
				MetodoPago = "PPD",
				FormaPagoId = FacturaBase.FormaPagoId,
				FormaPago = FacturaBase.FormaPago,
				UUID = FacturaBase.UUID,
				UUIDrelacionado = FacturaBase.UUIDrelacionado,
				Descripcion = FacturaBase.Descripcion,
				TipoRelacionId = 0,
				FechaPago = FacturaBase.FechaPago,
				EstatusId = FacturaBase.EstatusId,
				EstatusDescripcion = FacturaBase.EstatusDescripcion,
				UsoCFDI = FacturaBase.UsoCFDI,
				UsoCFDIId = FacturaBase.UsoCFDIId,
				Ruta = FacturaBase.Ruta,
				PDF = FacturaBase.PDF,
				XML = FacturaBase.XML,
				VersionCFDI = FacturaBase.VersionCFDI,
				VersionCFDIId = FacturaBase.VersionCFDIId,
				TipoPercepcion = "",
				ConceptoPercepcion = "",
				PercepcionExentoS = "",
				PercepcionGravadoS = "",
				TipoDeduccion = "",
				ConceptoDeduccion = "",
				DeduccionS = "",
				FechaInicio = new DateTime(1900, 1, 1),
				FechaFin = new DateTime(1900, 1, 1),
				ClaveEntFed = "",
				TipoRegimen = ""
			};
		}

		private void AgregaFacturaEnLista(EntFactura f, List<EntFactura> lstCP)
		{
			if (f.EquivalenciaDR != 1m)
			{
				f.TotalUSD = f.Total;
				f.Total /= f.EquivalenciaDR;
			}
			EntFactura cp = new EntFactura
			{
				Id = f.Id,
				EmpresaId = f.EmpresaId,
				UsuarioId = f.UsuarioId,
				EmisorNombre = f.EmisorNombre,
				EmisorRFC = f.EmisorRFC,
				Nombre = f.Nombre,
				RFC = f.RFC,
				TipoComprobanteId = f.TipoComprobanteId,
				TipoComprobante = f.TipoComprobante,
				SerieFactura = f.SerieFactura,
				NumeroFactura = f.NumeroFactura,
				IVARetenciones = f.IVARetenciones,
				ISRRetenciones = f.ISRRetenciones,
				Retenciones = f.Retenciones,
				IVA = f.IVA,
				IEPS = f.IEPS,
				Total = f.Total,
				TotalUSD = f.TotalUSD,
				Descuento = f.Descuento,
				Fecha = f.Fecha,
				MonedaId = f.MonedaId,
				Moneda = f.Moneda,
				MetodoPagoId = 2,
				MetodoPago = "PPD",
				FormaPagoId = f.FormaPagoId,
				FormaPago = f.FormaPago,
				UUID = f.UUID,
				UUIDrelacionado = f.UUIDrelacionado,
				Descripcion = f.Descripcion,
				UsoCFDIId = f.UsoCFDIId,
				TipoRelacionId = 0,
				FechaPago = f.FechaPago,
				EstatusId = f.EstatusId,
				EstatusDescripcion = f.EstatusDescripcion,
				UsoCFDI = f.UsoCFDI,
				Ruta = f.Ruta,
				PDF = f.PDF,
				XML = f.XML,
				VersionCFDI = f.VersionCFDI,
				VersionCFDIId = f.VersionCFDIId,
				TipoPercepcion = "",
				ConceptoPercepcion = "",
				PercepcionExentoS = "",
				PercepcionGravadoS = "",
				TipoDeduccion = "",
				ConceptoDeduccion = "",
				DeduccionS = "",
				FechaInicio = new DateTime(1900, 1, 1),
				FechaFin = new DateTime(1900, 1, 1),
				ClaveEntFed = "",
				TipoRegimen = "",
				TipoEstructuraImpuestoId = f.TipoEstructuraImpuestoId,
				ObjetoImpuesto = f.ObjetoImpuesto,
				ObjetoImpuestoId = f.ObjetoImpuestoId,
				ImporteDR = f.ImporteDR,
				TasaOCuota = f.TasaOCuota,
				TipoCambio = f.TipoCambio,
				EquivalenciaDR = f.EquivalenciaDR,
				TipoFactor = f.TipoFactor,
				TipoFactorId = f.TipoFactorId,
				TipoImpuestoId = f.TipoImpuestoId
			};
			if (cp.TipoCambio > 1m)
			{
				cp.Descuento /= cp.TipoCambio;
				cp.Retenciones /= cp.TipoCambio;
				cp.IVARetenciones /= cp.TipoCambio;
				cp.ISRRetenciones /= cp.TipoCambio;
				cp.IVA /= cp.TipoCambio;
				cp.IEPS /= cp.TipoCambio;
			}
			cp.SubTotal = cp.Total - cp.IVA - cp.IEPS + cp.Retenciones;
			lstCP.Add(cp);
			f.IVA = 0m;
			f.IEPS = 0m;
			f.IVARetenciones = 0m;
			f.ISRRetenciones = 0m;
			f.Retenciones = 0m;
		}

		private void VerificaUUIDRepetido(List<EntFactura> ListaFacturasRevisa, string UUIDRevisa, List<EntFactura> ListaFacturasRegistradas)
		{
			if (ListaFacturasRevisa.Count != 0)
			{
				int index = ListaFacturasRevisa.FindIndex((EntFactura P) => P.UUID == UUIDRevisa);
				if (index >= 0)
				{
					ListaFacturasRegistradas.Add(ListaFacturasRevisa[index]);
					ListaFacturasRevisa.RemoveAt(index);
					VerificaUUIDRepetido(ListaFacturasRevisa, UUIDRevisa, ListaFacturasRegistradas);
				}
				else
				{
					VerificaUUIDRepetido(ListaFacturasRevisa.Take(ListaFacturasRevisa.Count - 1).ToList(), ListaFacturasRevisa.Last().UUID, ListaFacturasRegistradas);
				}
			}
		}

		private void CargaXMLsEmitidosEnGrid(string RutaCarpeta, DataGridView GridCarga, bool Emitidos)
		{
			DirectoryInfo dir = new DirectoryInfo(RutaCarpeta);
			if (dir.GetFiles().Length == 0)
			{
				MandaExcepcion("NO se encuentran archivos en la carpeta seleccionada.");
			}
			List<EntFactura> lstFacturasRegistradas = new List<EntFactura>();
			List<EntFactura> lst = new List<EntFactura>();
			ListaCP40 = new List<EntFactura>();
			ListaCP40adicionales = new List<EntFactura>();
			ListaFacturas40adicionales = new List<EntFactura>();
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				string rutaArchivo = file.FullName;
				if (!(file.Extension == ".xml"))
				{
					continue;
				}
				EntFactura fac = new EntFactura();
				EntFactura cp40 = new EntFactura();
				EntFactura fac40ad = new EntFactura();
				fac.Id = new Random().Next();
				fac.NumeroFactura = "";
				fac.SerieFactura = "";
				fac.UUIDrelacionado = "";
				fac.FechaPago = new DateTime(1900, 1, 1);
				fac.EmpresaId = Program.EmpresaSeleccionada.Id;
				fac.UsuarioId = Program.UsuarioSeleccionado.Id;
				fac.TipoPercepcion = "";
				fac.ConceptoPercepcion = "";
				fac.PercepcionExentoS = "";
				fac.PercepcionGravadoS = "";
				fac.TipoDeduccion = "";
				fac.ConceptoDeduccion = "";
				fac.DeduccionS = "";
				fac.FechaInicio = new DateTime(1900, 1, 1);
				fac.FechaFin = new DateTime(1900, 1, 1);
				fac.ClaveEntFed = "";
				fac.TipoRegimen = "";
				fac.UsoCFDI = "";
				fac.Ruta = "";
				fac.PDF = new byte[1];
				fac.XML = new byte[1];
				fac.TipoCambio = 1m;
				decimal objetoImpuesto = default(decimal);
				decimal descuento = default(decimal);
				bool isImpuestosTotal = false;
				bool isDescuentoEnProducto = false;
				XmlTextReader reader = new XmlTextReader(rutaArchivo);
				while (reader.Read())
				{
					switch (reader.NodeType)
					{
					case XmlNodeType.Element:
						if (reader.Name.ToUpper() == "cfdi:Comprobante".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								switch (reader.Name.ToUpper())
								{
								case "VERSION":
									fac.VersionCFDI = reader.Value;
									if (fac.VersionCFDI == "3.3")
									{
										fac.VersionCFDIId = 1;
									}
									else if (fac.VersionCFDI == "4.0")
									{
										fac.VersionCFDIId = 2;
									}
									break;
								case "FECHA":
									fac.Fecha = Convert.ToDateTime(reader.Value);
									break;
								case "TOTAL":
									fac.Total = Convert.ToDecimal(reader.Value);
									break;
								case "DESCUENTO":
									fac.Descuento = Convert.ToDecimal(reader.Value);
									break;
								case "SUBTOTAL":
									fac.SubTotal = Convert.ToDecimal(reader.Value);
									break;
								case "SERIE":
									fac.SerieFactura = reader.Value;
									break;
								case "FOLIO":
									fac.NumeroFactura = reader.Value;
									break;
								case "MONEDA":
									fac.Moneda = reader.Value.ToUpper();
									if (reader.Value.ToUpper() == "USD")
									{
										fac.MonedaId = 2;
									}
									else
									{
										fac.MonedaId = 1;
									}
									break;
								case "TIPOCAMBIO":
									fac.TipoCambio = ConvierteTextoADecimal(reader.Value);
									break;
								case "TIPODECOMPROBANTE":
									fac.TipoComprobante = reader.Value;
									switch (fac.TipoComprobante)
									{
									case "I":
										fac.TipoComprobanteId = 1;
										break;
									case "E":
										fac.TipoComprobanteId = 2;
										break;
									case "T":
										fac.TipoComprobanteId = 3;
										break;
									case "N":
										fac.TipoComprobanteId = 4;
										break;
									case "P":
										fac.TipoComprobanteId = 5;
										break;
									}
									break;
								case "FORMAPAGO":
									fac.FormaPago = reader.Value;
									switch (fac.FormaPago)
									{
									case "01":
										fac.FormaPagoId = 1;
										break;
									case "02":
										fac.FormaPagoId = 2;
										break;
									case "03":
										fac.FormaPagoId = 3;
										break;
									case "04":
										fac.FormaPagoId = 4;
										break;
									case "05":
										fac.FormaPagoId = 5;
										break;
									case "06":
										fac.FormaPagoId = 6;
										break;
									case "08":
										fac.FormaPagoId = 8;
										break;
									case "12":
										fac.FormaPagoId = 12;
										break;
									case "13":
										fac.FormaPagoId = 13;
										break;
									case "14":
										fac.FormaPagoId = 14;
										break;
									case "15":
										fac.FormaPagoId = 15;
										break;
									case "17":
										fac.FormaPagoId = 17;
										break;
									case "23":
										fac.FormaPagoId = 23;
										break;
									case "24":
										fac.FormaPagoId = 24;
										break;
									case "25":
										fac.FormaPagoId = 25;
										break;
									case "26":
										fac.FormaPagoId = 26;
										break;
									case "27":
										fac.FormaPagoId = 27;
										break;
									case "28":
										fac.FormaPagoId = 28;
										break;
									case "29":
										fac.FormaPagoId = 29;
										break;
									case "30":
										fac.FormaPagoId = 30;
										break;
									case "99":
										fac.FormaPagoId = 99;
										break;
									}
									break;
								case "METODOPAGO":
								{
									fac.MetodoPago = reader.Value;
									string metodoPago = fac.MetodoPago;
									string text = metodoPago;
									if (!(text == "PUE"))
									{
										if (text == "PPD")
										{
											fac.MetodoPagoId = 2;
										}
									}
									else
									{
										fac.MetodoPagoId = 1;
									}
									break;
								}
								}
							}
							fac.ImporteDR = fac.SubTotal - fac.Descuento;
						}
						if (reader.Name.ToUpper() == "cfdi:Emisor".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "NOMBRE":
									fac.EmisorNombre = reader.Value;
									break;
								case "RFC":
									fac.EmisorRFC = reader.Value.ToUpper();
									break;
								case "REGIMENFISCAL":
									fac.EmisorRegimenFiscal = reader.Value;
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "cfdi:Receptor".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "NOMBRE":
									fac.Nombre = reader.Value;
									break;
								case "RFC":
									fac.RFC = reader.Value.ToUpper();
									break;
								case "USOCFDI":
									fac.UsoCFDI = reader.Value;
									break;
								}
							}
						}
						fac40ad = ConvierteFacturaEnFacturaCP(fac);
						if (reader.Name.ToUpper() == "cfdi:Concepto".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "DESCRIPCION":
									fac.Descripcion = fac.Descripcion + reader.Value + "|";
									break;
								case "DESCUENTO":
									descuento = Convert.ToDecimal(reader.Value);
									isDescuentoEnProducto = true;
									break;
								case "OBJETOIMP":
									fac.ObjetoImpuesto = reader.Value;
									fac.ObjetoImpuestoId = ConvierteTextoAInteger(fac.ObjetoImpuesto);
									switch (fac.ObjetoImpuestoId)
									{
									case 1:
										fac.ObjetoImpuesto01 += objetoImpuesto - descuento;
										break;
									case 2:
										fac.ObjetoImpuesto02 += objetoImpuesto - descuento;
										break;
									case 3:
										fac.ObjetoImpuesto03 += objetoImpuesto - descuento;
										break;
									case 4:
										fac.ObjetoImpuesto04 += objetoImpuesto - descuento;
										break;
									}
									if (objetoImpuesto > 0m)
									{
										descuento = default(decimal);
										fac.ObjetoImpuestoId = 0;
									}
									break;
								case "IMPORTE":
									switch (fac.ObjetoImpuestoId)
									{
									case 0:
										objetoImpuesto = Convert.ToDecimal(reader.Value);
										break;
									case 1:
										fac.ObjetoImpuesto01 += Convert.ToDecimal(reader.Value) - descuento;
										break;
									case 2:
										fac.ObjetoImpuesto02 += Convert.ToDecimal(reader.Value) - descuento;
										break;
									case 3:
										fac.ObjetoImpuesto03 += Convert.ToDecimal(reader.Value) - descuento;
										break;
									case 4:
										fac.ObjetoImpuesto04 += Convert.ToDecimal(reader.Value) - descuento;
										break;
									}
									if (fac.ObjetoImpuestoId > 0)
									{
										descuento = default(decimal);
										objetoImpuesto = default(decimal);
									}
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "nomina12:Nomina".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "FECHAPAGO":
									fac.FechaPago = Convert.ToDateTime(reader.Value);
									break;
								case "FECHAINICIALPAGO":
									fac.FechaInicio = Convert.ToDateTime(reader.Value);
									break;
								case "FECHAFINALPAGO":
									fac.FechaFin = Convert.ToDateTime(reader.Value);
									break;
								case "TOTALDEDUCCIONES":
									fac.TotalDeducciones = Convert.ToDecimal(reader.Value);
									break;
								case "TOTALPERCEPCIONES":
									fac.TotalPercepciones = Convert.ToDecimal(reader.Value);
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "nomina12:Receptor".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text2 = reader.Name.ToUpper();
								string text3 = text2;
								if (!(text3 == "CLAVEENTFED"))
								{
									if (text3 == "TIPOREGIMEN")
									{
										fac.TipoRegimen = reader.Value;
									}
								}
								else
								{
									fac.ClaveEntFed = reader.Value;
								}
							}
						}
						if (reader.Name.ToUpper() == "nomina12:Percepcion".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "IMPORTEEXENTO":
									fac.PercepcionExento = Convert.ToDecimal(reader.Value);
									fac.PercepcionExentoS = fac.PercepcionExentoS + reader.Value + "|";
									break;
								case "IMPORTEGRAVADO":
									fac.PercepcionGravado = Convert.ToDecimal(reader.Value);
									fac.PercepcionGravadoS = fac.PercepcionGravadoS + reader.Value + "|";
									break;
								case "CONCEPTO":
									fac.ConceptoPercepcion = fac.ConceptoPercepcion + reader.Value + "|";
									break;
								case "TIPOPERCEPCION":
									fac.TipoPercepcion = fac.TipoPercepcion + reader.Value + "|";
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "nomina12:Deduccion".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "IMPORTE":
									fac.Deduccion = Convert.ToDecimal(reader.Value);
									fac.DeduccionS = fac.DeduccionS + reader.Value + "|";
									break;
								case "CONCEPTO":
									fac.ConceptoDeduccion = fac.ConceptoDeduccion + reader.Value + "|";
									break;
								case "TIPODEDUCCION":
									fac.TipoDeduccion = fac.TipoDeduccion + reader.Value + "|";
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "pago10:DoctoRelacionado".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text4 = reader.Name.ToUpper();
								string text5 = text4;
								if (!(text5 == "IDDOCUMENTO"))
								{
									if (text5 == "IMPPAGADO")
									{
										fac.Total = Convert.ToDecimal(reader.Value);
										fac.PagoS = fac.PagoS + reader.Value + "|";
									}
								}
								else
								{
									fac.UUIDrelacionado = fac.UUIDrelacionado + reader.Value.ToUpper() + "|";
								}
							}
						}
						if (reader.Name.ToUpper() == "pago10:Pago".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "FECHAPAGO":
									fac.FechaPago = Convert.ToDateTime(reader.Value);
									break;
								case "FORMADEPAGOP":
									fac.FormaPago = reader.Value;
									switch (fac.FormaPago)
									{
									case "01":
										fac.FormaPagoId = 1;
										break;
									case "02":
										fac.FormaPagoId = 2;
										break;
									case "03":
										fac.FormaPagoId = 3;
										break;
									case "04":
										fac.FormaPagoId = 4;
										break;
									case "05":
										fac.FormaPagoId = 5;
										break;
									case "06":
										fac.FormaPagoId = 6;
										break;
									case "08":
										fac.FormaPagoId = 8;
										break;
									case "12":
										fac.FormaPagoId = 12;
										break;
									case "13":
										fac.FormaPagoId = 13;
										break;
									case "14":
										fac.FormaPagoId = 14;
										break;
									case "15":
										fac.FormaPagoId = 15;
										break;
									case "17":
										fac.FormaPagoId = 17;
										break;
									case "23":
										fac.FormaPagoId = 23;
										break;
									case "24":
										fac.FormaPagoId = 24;
										break;
									case "25":
										fac.FormaPagoId = 25;
										break;
									case "26":
										fac.FormaPagoId = 26;
										break;
									case "27":
										fac.FormaPagoId = 27;
										break;
									case "28":
										fac.FormaPagoId = 28;
										break;
									case "29":
										fac.FormaPagoId = 29;
										break;
									case "30":
										fac.FormaPagoId = 30;
										break;
									case "99":
										fac.FormaPagoId = 99;
										break;
									}
									break;
								case "MONEDAP":
									fac.Moneda = reader.Value.ToUpper();
									if (reader.Value.ToUpper() == "USD")
									{
										fac.MonedaId = 2;
									}
									else
									{
										fac.MonedaId = 1;
									}
									break;
								case "TIPOCAMBIOP":
									fac.TipoCambio = ConvierteTextoADecimal(reader.Value);
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "pago20:Totales".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "TOTALRETENCIONESIVA":
									fac.IVARetenciones = Convert.ToDecimal(reader.Value);
									fac.Retenciones += fac.IVARetenciones;
									break;
								case "TOTALRETENCIONESISR":
									fac.ISRRetenciones = Convert.ToDecimal(reader.Value);
									fac.Retenciones += fac.ISRRetenciones;
									break;
								case "TOTALTRASLADOSIMPUESTOIVA16":
									fac.IVA += Convert.ToDecimal(reader.Value);
									break;
								case "TOTALTRASLADOSIMPUESTOIVA8":
									fac.IVA += Convert.ToDecimal(reader.Value);
									break;
								case "TOTALTRASLADOSIMPUESTOIEPS":
									fac.IEPS += Convert.ToDecimal(reader.Value);
									break;
								case "TOTALTRASLADOSBASEIVA16":
									fac.SubTotal += Convert.ToDecimal(reader.Value);
									break;
								case "TOTALTRASLADOSBASEIVA8":
									fac.SubTotal += Convert.ToDecimal(reader.Value);
									break;
								case "TOTALTRASLADOSBASEIVA0":
									fac.SubTotal += Convert.ToDecimal(reader.Value);
									break;
								case "TOTALTRASLADOSBASEIVAEXENTO":
									fac.SubTotal += Convert.ToDecimal(reader.Value);
									break;
								case "MONTOTOTALPAGOS":
									fac.Total = Convert.ToDecimal(reader.Value);
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "pago20:Pago".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "FECHAPAGO":
									fac.FechaPago = Convert.ToDateTime(reader.Value);
									break;
								case "FORMADEPAGOP":
									fac.FormaPago = reader.Value;
									switch (fac.FormaPago)
									{
									case "01":
										fac.FormaPagoId = 1;
										break;
									case "02":
										fac.FormaPagoId = 2;
										break;
									case "03":
										fac.FormaPagoId = 3;
										break;
									case "04":
										fac.FormaPagoId = 4;
										break;
									case "05":
										fac.FormaPagoId = 5;
										break;
									case "06":
										fac.FormaPagoId = 6;
										break;
									case "08":
										fac.FormaPagoId = 8;
										break;
									case "12":
										fac.FormaPagoId = 12;
										break;
									case "13":
										fac.FormaPagoId = 13;
										break;
									case "14":
										fac.FormaPagoId = 14;
										break;
									case "15":
										fac.FormaPagoId = 15;
										break;
									case "17":
										fac.FormaPagoId = 17;
										break;
									case "23":
										fac.FormaPagoId = 23;
										break;
									case "24":
										fac.FormaPagoId = 24;
										break;
									case "25":
										fac.FormaPagoId = 25;
										break;
									case "26":
										fac.FormaPagoId = 26;
										break;
									case "27":
										fac.FormaPagoId = 27;
										break;
									case "28":
										fac.FormaPagoId = 28;
										break;
									case "29":
										fac.FormaPagoId = 29;
										break;
									case "30":
										fac.FormaPagoId = 30;
										break;
									case "99":
										fac.FormaPagoId = 99;
										break;
									}
									break;
								case "MONEDAP":
									fac.Moneda = reader.Value.ToUpper();
									if (reader.Value.ToUpper() == "USD")
									{
										fac.MonedaId = 2;
									}
									else
									{
										fac.MonedaId = 1;
									}
									break;
								case "TIPOCAMBIOP":
									fac.TipoCambio = ConvierteTextoADecimal(reader.Value);
									break;
								}
							}
							cp40 = ConvierteFacturaEnFacturaCP(fac);
						}
						if (reader.Name.ToUpper() == "pago20:DoctoRelacionado".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "IDDOCUMENTO":
									fac.UUIDrelacionado = fac.UUIDrelacionado + reader.Value.ToUpper() + "|";
									cp40.UUIDrelacionado = reader.Value.ToUpper();
									break;
								case "IMPPAGADO":
									fac.PagoS = fac.PagoS + reader.Value + "|";
									cp40.Total = Convert.ToDecimal(reader.Value);
									cp40.PagoS = reader.Value;
									break;
								case "OBJETOIMPDR":
									cp40.ObjetoImpuesto = reader.Value;
									cp40.ObjetoImpuestoId = Convert.ToInt32(reader.Value);
									break;
								case "EQUIVALENCIADR":
									cp40.EquivalenciaDR = Convert.ToDecimal(reader.Value);
									break;
								}
							}
							AgregaFacturaEnLista(cp40, ListaCP40);
						}
						if (reader.Name.ToUpper() == "pago20:RetencionDR".ToUpper())
						{
							string impuesto = "";
							decimal importeImpuesto = default(decimal);
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "TASAOCUOTADR":
									cp40.TasaOCuota = Convert.ToDecimal(reader.Value);
									break;
								case "TIPOFACTORDR":
									cp40.TipoFactor = reader.Value.ToUpper();
									switch (cp40.TipoFactor)
									{
									case "TASA":
										cp40.TipoFactorId = 1;
										break;
									case "CUOTA":
										cp40.TipoFactorId = 2;
										break;
									case "EXENTO":
										cp40.TipoFactorId = 3;
										break;
									}
									break;
								case "BASEDR":
									cp40.Total = Convert.ToDecimal(reader.Value);
									break;
								case "IMPUESTODR":
									impuesto = reader.Value;
									cp40.TipoImpuestoId = Convert.ToInt32(impuesto);
									if (importeImpuesto > 0m)
									{
										if (impuesto == "002")
										{
											cp40.IVARetenciones = importeImpuesto;
											cp40.Retenciones = importeImpuesto;
										}
										else if (impuesto == "001")
										{
											cp40.ISRRetenciones = importeImpuesto;
											cp40.Retenciones = importeImpuesto;
										}
										importeImpuesto = default(decimal);
									}
									break;
								case "IMPORTEDR":
									cp40.ImporteDR = Convert.ToDecimal(reader.Value);
									cp40.Retenciones = cp40.ImporteDR;
									if (impuesto == "002")
									{
										cp40.IVARetenciones = fac.Retenciones;
									}
									else if (impuesto == "001")
									{
										cp40.ISRRetenciones = fac.Retenciones;
									}
									else
									{
										importeImpuesto = fac.Retenciones;
									}
									break;
								}
							}
							cp40.TipoEstructuraImpuestoId = 2;
							AgregaFacturaEnLista(cp40, ListaCP40adicionales);
						}
						if (reader.Name.ToUpper() == "pago20:TrasladoDR".ToUpper())
						{
							string impuesto2 = "";
							decimal importeImpuesto2 = default(decimal);
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "TASAOCUOTADR":
									cp40.TasaOCuota = Convert.ToDecimal(reader.Value);
									break;
								case "TIPOFACTORDR":
									cp40.TipoFactor = reader.Value.ToUpper();
									switch (cp40.TipoFactor)
									{
									case "TASA":
										cp40.TipoFactorId = 1;
										break;
									case "CUOTA":
										cp40.TipoFactorId = 2;
										break;
									case "EXENTO":
										cp40.TipoFactorId = 3;
										break;
									}
									break;
								case "BASEDR":
									cp40.Total = Convert.ToDecimal(reader.Value);
									break;
								case "IMPUESTODR":
									impuesto2 = reader.Value;
									cp40.TipoImpuestoId = Convert.ToInt32(impuesto2);
									if (importeImpuesto2 > 0m)
									{
										if (impuesto2 == "002")
										{
											cp40.TipoImpuestoId = 2;
											cp40.IVA = importeImpuesto2;
										}
										else if (impuesto2 == "003")
										{
											cp40.TipoImpuestoId = 3;
											cp40.IEPS = importeImpuesto2;
										}
										importeImpuesto2 = default(decimal);
									}
									break;
								case "IMPORTEDR":
									cp40.ImporteDR = Convert.ToDecimal(reader.Value);
									if (impuesto2 == "002" && cp40.ImporteDR > 0m)
									{
										cp40.IVA = cp40.ImporteDR;
									}
									else if (impuesto2 == "003")
									{
										cp40.IEPS = cp40.ImporteDR;
									}
									else
									{
										importeImpuesto2 = cp40.ImporteDR;
									}
									break;
								}
							}
							cp40.TipoEstructuraImpuestoId = 1;
							if (cp40.TipoFactorId == 3)
							{
								cp40.ImporteDR = 0m;
								cp40.TasaOCuota = 0m;
							}
							AgregaFacturaEnLista(cp40, ListaCP40adicionales);
						}
						if (reader.Name.ToUpper() == "pago20:RetencionP".ToUpper())
						{
							string impuesto3 = "";
							decimal importeImpuesto3 = default(decimal);
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text6 = reader.Name.ToUpper();
								string text7 = text6;
								if (!(text7 == "IMPUESTOP"))
								{
									if (text7 == "IMPORTEDR")
									{
										cp40.Retenciones = Convert.ToDecimal(reader.Value);
										if (impuesto3 == "002")
										{
											cp40.IVARetenciones = fac.Retenciones;
										}
										else if (impuesto3 == "001")
										{
											cp40.ISRRetenciones = fac.Retenciones;
										}
										else
										{
											importeImpuesto3 = fac.Retenciones;
										}
									}
									continue;
								}
								impuesto3 = reader.Value;
								if (importeImpuesto3 > 0m)
								{
									if (impuesto3 == "002")
									{
										cp40.TipoImpuestoId = 2;
										cp40.IVARetenciones = importeImpuesto3;
										cp40.Retenciones = importeImpuesto3;
									}
									else if (impuesto3 == "001")
									{
										cp40.TipoImpuestoId = 1;
										cp40.ISRRetenciones = importeImpuesto3;
										cp40.Retenciones = importeImpuesto3;
									}
									importeImpuesto3 = default(decimal);
								}
							}
						}
						if (reader.Name.ToUpper() == "pago20:TrasladoP".ToUpper())
						{
							string impuesto4 = "";
							decimal importeImpuesto4 = default(decimal);
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "TASAOCUOTAP":
									fac.TasaOCuota = Convert.ToDecimal(reader.Value);
									break;
								case "TIPOFACTORP":
									fac.TipoFactor = reader.Value.ToUpper();
									switch (cp40.TipoFactor)
									{
									case "TASA":
										fac.TipoFactorId = 1;
										break;
									case "CUOTA":
										fac.TipoFactorId = 2;
										break;
									case "EXENTO":
										fac.TipoFactorId = 3;
										break;
									}
									break;
								case "BASEP":
									cp40.Total = Convert.ToDecimal(reader.Value);
									break;
								case "IMPUESTOP":
									impuesto4 = reader.Value;
									if (importeImpuesto4 > 0m)
									{
										if (impuesto4 == "002")
										{
											cp40.TipoImpuestoId = 2;
											cp40.IVA = importeImpuesto4;
										}
										else if (impuesto4 == "003")
										{
											cp40.TipoImpuestoId = 3;
											cp40.IEPS = importeImpuesto4;
										}
										importeImpuesto4 = default(decimal);
									}
									break;
								case "IMPORTEDR":
									cp40.ImporteDR = Convert.ToDecimal(reader.Value);
									if (impuesto4 == "002" && fac.ImporteDR > 0m)
									{
										cp40.IVA = fac.ImporteDR;
									}
									else if (impuesto4 == "003")
									{
										cp40.IEPS = fac.ImporteDR;
									}
									else
									{
										importeImpuesto4 = fac.ImporteDR;
									}
									break;
								}
							}
						}
						if (reader.Name.ToUpper() == "cfdi:CfdiRelacionados".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text8 = reader.Name.ToUpper();
								string text9 = text8;
								if (text9 == "TIPORELACION")
								{
									fac.TipoRelacion = fac.TipoRelacion + reader.Value + "|";
									fac.TipoRelacionId = ConvierteTextoAInteger(reader.Value);
								}
							}
						}
						if (reader.Name.ToUpper() == "cfdi:CfdiRelacionado".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text10 = reader.Name.ToUpper();
								string text11 = text10;
								if (text11 == "UUID")
								{
									fac.UUIDrelacionado = fac.UUIDrelacionado + reader.Value.ToUpper() + "|";
								}
							}
						}
						if (reader.Name.ToUpper() == "cfdi:Impuestos".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text12 = reader.Name.ToUpper();
								string text13 = text12;
								if (!(text13 == "TOTALIMPUESTOSTRASLADADOS"))
								{
									if (text13 == "TOTALIMPUESTOSRETENIDOS")
									{
										isImpuestosTotal = true;
										fac.Retenciones = Convert.ToDecimal(reader.Value);
									}
								}
								else
								{
									isImpuestosTotal = true;
								}
							}
						}
						if (reader.Name.ToUpper() == "cfdi:Retencion".ToUpper())
						{
							string impuesto5 = "";
							decimal importeImpuesto5 = default(decimal);
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text14 = reader.Name.ToUpper();
								string text15 = text14;
								if (!(text15 == "IMPUESTO"))
								{
									if (text15 == "IMPORTE")
									{
										fac40ad.ImporteDR = Convert.ToDecimal(reader.Value);
										if (impuesto5 == "002")
										{
											fac.IVARetenciones = fac40ad.ImporteDR;
										}
										else if (impuesto5 == "001")
										{
											fac.ISRRetenciones = fac40ad.ImporteDR;
										}
										else
										{
											importeImpuesto5 = fac40ad.ImporteDR;
										}
									}
									continue;
								}
								impuesto5 = reader.Value;
								fac40ad.TipoImpuestoId = Convert.ToInt32(impuesto5);
								if (importeImpuesto5 > 0m)
								{
									if (impuesto5 == "002")
									{
										fac.IVARetenciones = importeImpuesto5;
									}
									else if (impuesto5 == "001")
									{
										fac.ISRRetenciones = importeImpuesto5;
									}
									importeImpuesto5 = default(decimal);
								}
							}
							if (isImpuestosTotal)
							{
								fac40ad.TipoEstructuraImpuestoId = 2;
								AgregaFacturaEnLista(fac40ad, ListaFacturas40adicionales);
							}
						}
						if (reader.Name.ToUpper() == "cfdi:Traslado".ToUpper())
						{
							string impuesto6 = "";
							decimal importeImpuesto6 = default(decimal);
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								switch (reader.Name.ToUpper())
								{
								case "BASE":
									fac40ad.Total = Convert.ToDecimal(reader.Value);
									break;
								case "TASAOCUOTA":
									fac40ad.TasaOCuota = Convert.ToDecimal(reader.Value);
									break;
								case "TIPOFACTOR":
									fac40ad.TipoFactor = reader.Value.ToUpper();
									switch (fac40ad.TipoFactor)
									{
									case "TASA":
										fac40ad.TipoFactorId = 1;
										break;
									case "CUOTA":
										fac40ad.TipoFactorId = 2;
										break;
									case "EXENTO":
										fac40ad.TipoFactorId = 3;
										break;
									}
									break;
								case "IMPUESTO":
									impuesto6 = reader.Value;
									fac40ad.TipoImpuestoId = Convert.ToInt32(impuesto6);
									if (importeImpuesto6 > 0m)
									{
										if (impuesto6 == "002")
										{
											fac.IVA = importeImpuesto6;
										}
										else if (impuesto6 == "003")
										{
											fac.IEPS = importeImpuesto6;
										}
										importeImpuesto6 = default(decimal);
									}
									break;
								case "IMPORTE":
									fac40ad.ImporteDR = Convert.ToDecimal(reader.Value);
									if (impuesto6 == "002" && fac40ad.ImporteDR > 0m)
									{
										fac.IVA = fac40ad.ImporteDR;
									}
									else if (impuesto6 == "003")
									{
										fac.IEPS = fac40ad.ImporteDR;
									}
									else
									{
										importeImpuesto6 = fac40ad.ImporteDR;
									}
									break;
								}
							}
							if (isImpuestosTotal)
							{
								fac40ad.TipoEstructuraImpuestoId = 1;
								AgregaFacturaEnLista(fac40ad, ListaFacturas40adicionales);
							}
						}
						if (reader.Name.ToUpper() == "implocal:ImpuestosLocales".ToUpper())
						{
							while (reader.MoveToNextAttribute())
							{
								Console.Write(" " + reader.Name + "='" + reader.Value + "'");
								string text16 = reader.Name.ToUpper();
								string text17 = text16;
								if (text17 == "TOTALDERETENCIONES")
								{
									fac.ImpuestosLocales = Convert.ToDecimal(reader.Value);
								}
							}
						}
						if (!(reader.Name.ToUpper() == "tfd:TimbreFiscalDigital".ToUpper()))
						{
							break;
						}
						while (reader.MoveToNextAttribute())
						{
							string text18 = reader.Name.ToUpper();
							string text19 = text18;
							if (text19 == "UUID")
							{
								fac.UUID = reader.Value.ToUpper();
							}
						}
						break;
					}
				}
				if (fac.TipoComprobanteId == 5 && fac.TipoCambio > 1m)
				{
					fac.Descuento /= fac.TipoCambio;
					fac.Retenciones /= fac.TipoCambio;
					fac.IVARetenciones /= fac.TipoCambio;
					fac.ISRRetenciones /= fac.TipoCambio;
					fac.IVA /= fac.TipoCambio;
					fac.IEPS /= fac.TipoCambio;
					fac.ImpuestosLocales /= fac.TipoCambio;
					fac.SubTotal /= fac.TipoCambio;
					fac.Total /= fac.TipoCambio;
				}
				if (fac.Descuento > 0m && !isDescuentoEnProducto)
				{
					decimal descuentoProrrateo = default(decimal);
					int contObjImp = 0;
					if (fac.ObjetoImpuesto01 > 0m)
					{
						contObjImp++;
					}
					if (fac.ObjetoImpuesto02 > 0m)
					{
						contObjImp++;
					}
					if (fac.ObjetoImpuesto03 > 0m)
					{
						contObjImp++;
					}
					if (fac.ObjetoImpuesto04 > 0m)
					{
						contObjImp++;
					}
					if (contObjImp > 0)
					{
						descuentoProrrateo = fac.Descuento / (decimal)contObjImp;
					}
					if (fac.ObjetoImpuesto01 > 0m)
					{
						fac.ObjetoImpuesto01 -= descuentoProrrateo;
					}
					if (fac.ObjetoImpuesto02 > 0m)
					{
						fac.ObjetoImpuesto02 -= descuentoProrrateo;
					}
					if (fac.ObjetoImpuesto03 > 0m)
					{
						fac.ObjetoImpuesto03 -= descuentoProrrateo;
					}
					if (fac.ObjetoImpuesto04 > 0m)
					{
						fac.ObjetoImpuesto04 -= descuentoProrrateo;
					}
				}
				if (!RevisaExisteFacturaRegistrada(fac.UUID))
				{
					if (fac.Descuento > 0m && fac.TipoComprobanteId != 2)
					{
						fac.TipoRelacionId = 77;
					}
					lst.Add(fac);
				}
				else
				{
					lstFacturasRegistradas.Add(fac);
				}
			}
			RevisaEmitidos(Program.EmpresaSeleccionada, lst);
			VerificaUUIDRepetido(lst, "", lstFacturasRegistradas);
			if (lstFacturasRegistradas.Count > 0)
			{
				StringBuilder sb = new StringBuilder();
				foreach (EntFactura f in lstFacturasRegistradas)
				{
					lst.Remove(f);
					ListaCP40.RemoveAll((EntFactura P) => P.Id == f.Id);
					ListaCP40adicionales.RemoveAll((EntFactura P) => P.Id == f.Id);
					ListaFacturas40adicionales.RemoveAll((EntFactura P) => P.Id == f.Id);
					sb.Append("FOLIO:" + f.Folio + " UUID:" + f.UUID + "\n");
				}
				MuestraMensajeAdvertencia("SE ENCONTRARON COMPROBANTES FISCALES REGISTRADOS ANTERIORMENTE \n\n" + sb.ToString(), "COMPROBANTES FISCALES REGISTRADOS");
			}
			GridCarga.DataSource = lst;
			txtNumComprobantes.Text = lst.Count.ToString();
		}

		private void CargaXMLsEmitidosEnGrid(List<EntFactura> ListaFacturas, DataGridView GridCarga, TextBox TxtMuestraNumComprobantes)
		{
			GridCarga.DataSource = null;
			GridCarga.DataSource = ListaFacturas;
			TxtMuestraNumComprobantes.Text = ListaFacturas.Count.ToString();
		}

		private bool RevisaExisteFacturaRegistrada(string UUID)
		{
			List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, UUID);
			if (lst.Count > 0)
			{
				return true;
			}
			return false;
		}

		private List<EntFactura> SetIVAenPagos(List<EntFactura> ListaFacturas, List<EntFactura> ListaComplementos)
		{
			List<EntFactura> lstCP = new List<EntFactura>();
			foreach (EntFactura f in ListaComplementos)
			{
				if (string.IsNullOrWhiteSpace(f.UUIDrelacionado))
				{
					MandaExcepcion("SE ENCONTRÓ CFDI TIPO COMPLEMENTO DE PAGO SIN RELACIÓN A FACTURA");
				}
				int cont = 0;
				string[] facturas = f.UUIDrelacionado.Split('|');
				string[] pagos = f.PagoS.Split('|');
				string[] array = facturas;
				foreach (string s in array)
				{
					if (!string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lstFac = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
						EntFactura fac = new EntFactura();
						if (lstFac.Count == 0)
						{
							if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().Count == 0)
							{
								fac = new EntFactura();
							}
							else
							{
								fac = ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList()[0];
								fac.Id = 0;
							}
						}
						else
						{
							fac = lstFac.First();
						}
						decimal porcentaje = default(decimal);
						decimal totalCP = ConvierteTextoADecimal(pagos[cont]);
						decimal totalFac = fac.Total;
						if (!(totalFac > 0m))
						{
							lstCP.RemoveAll((EntFactura P) => P.UUID == f.UUID);
							break;
						}
						porcentaje = totalCP / totalFac;
						EntFactura cp = new EntFactura
						{
							Id = f.Id,
							EmpresaId = f.EmpresaId,
							UsuarioId = f.UsuarioId,
							EmisorNombre = f.EmisorNombre,
							EmisorRFC = f.EmisorRFC,
							Nombre = f.Nombre,
							RFC = f.RFC,
							TipoComprobanteId = f.TipoComprobanteId,
							TipoComprobante = f.TipoComprobante,
							SerieFactura = f.SerieFactura,
							NumeroFactura = f.NumeroFactura,
							IVARetenciones = f.IVARetenciones,
							ISRRetenciones = f.ISRRetenciones,
							Retenciones = f.Retenciones,
							IVA = f.IVA,
							IEPS = f.IEPS,
							Total = totalCP,
							SubTotal = f.SubTotal,
							Fecha = f.Fecha,
							MonedaId = f.MonedaId,
							Moneda = f.Moneda,
							TipoCambio = f.TipoCambio,
							MetodoPagoId = 2,
							MetodoPago = "PPD",
							FormaPagoId = f.FormaPagoId,
							FormaPago = f.FormaPago,
							UUID = f.UUID,
							Descripcion = f.Descripcion,
							UsoCFDIId = f.UsoCFDIId,
							TipoRelacionId = 0,
							FechaPago = f.FechaPago,
							EstatusId = f.EstatusId,
							EstatusDescripcion = f.EstatusDescripcion,
							UsoCFDI = f.UsoCFDI,
							Ruta = f.Ruta,
							PDF = f.PDF,
							XML = f.XML,
							VersionCFDI = f.VersionCFDI,
							VersionCFDIId = f.VersionCFDIId,
							TipoPercepcion = "",
							ConceptoPercepcion = "",
							PercepcionExentoS = "",
							PercepcionGravadoS = "",
							TipoDeduccion = "",
							ConceptoDeduccion = "",
							DeduccionS = "",
							FechaInicio = new DateTime(1900, 1, 1),
							FechaFin = new DateTime(1900, 1, 1),
							ClaveEntFed = "",
							TipoRegimen = ""
						};
						cp.SubTotal = fac.SubTotal * porcentaje;
						cp.IVA = fac.IVA * porcentaje;
						cp.IEPS = fac.IEPS * porcentaje;
						cp.IVARetenciones = fac.IVARetenciones * porcentaje;
						cp.ISRRetenciones = fac.ISRRetenciones * porcentaje;
						cp.Retenciones = fac.Retenciones * porcentaje;
						cp.FacturaRelacionId = fac.Id;
						cp.UUIDrelacionado = s;
						lstCP.Add(cp);
					}
					cont++;
				}
			}
			return lstCP;
		}

		private List<EntCatalogoPercepciones> SetPercepciones(List<EntFactura> ListaFacturas)
		{
			List<EntCatalogoPercepciones> lstPercepciones = new List<EntCatalogoPercepciones>();
			foreach (EntFactura f in ListaFacturas)
			{
				int cont = 0;
				string[] tiposPercepciones = f.TipoPercepcion.Split('|');
				string[] conceptosPercepciones = f.ConceptoPercepcion.Split('|');
				string[] importesExentos = f.PercepcionExentoS.Split('|');
				string[] importesGravados = f.PercepcionGravadoS.Split('|');
				for (int x = 0; x < conceptosPercepciones.Length; x++)
				{
					EntCatalogoPercepciones cp = new EntCatalogoPercepciones
					{
						Id = f.Id,
						EmpresaId = f.EmpresaId,
						UsuarioId = f.UsuarioId,
						Clave = tiposPercepciones[x],
						Descripcion = conceptosPercepciones[x],
						Excento = ConvierteTextoADecimal(importesExentos[x]),
						Gravado = ConvierteTextoADecimal(importesGravados[x])
					};
					lstPercepciones.Add(cp);
				}
				cont++;
			}
			return lstPercepciones;
		}

		private List<EntCatalogoPercepciones> SetDeducciones(List<EntFactura> ListaFacturas)
		{
			List<EntCatalogoPercepciones> lstPercepciones = new List<EntCatalogoPercepciones>();
			foreach (EntFactura f in ListaFacturas)
			{
				int cont = 0;
				string[] tiposPercepciones = f.TipoDeduccion.Split('|');
				string[] conceptosPercepciones = f.ConceptoDeduccion.Split('|');
				string[] importes = f.DeduccionS.Split('|');
				for (int x = 0; x < conceptosPercepciones.Length; x++)
				{
					EntCatalogoPercepciones cp = new EntCatalogoPercepciones
					{
						Id = f.Id,
						EmpresaId = f.EmpresaId,
						UsuarioId = f.UsuarioId,
						Clave = tiposPercepciones[x],
						Descripcion = conceptosPercepciones[x],
						Gravado = ConvierteTextoADecimal(importes[x])
					};
					lstPercepciones.Add(cp);
				}
				cont++;
			}
			return lstPercepciones;
		}

		private void RevisaExistenFacturasParaCP(List<EntFactura> ListaFacturas)
		{
			ListaComplementosPagoSinReferenciaImportada = new List<EntFactura>();
			List<EntFactura> ListaComplementosPago = ListaFacturas.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.VersionCFDIId == 1).ToList();
			foreach (EntFactura f in ListaComplementosPago)
			{
				string[] facturas = f.UUIDrelacionado.Split('|');
				string[] array = facturas;
				foreach (string s in array)
				{
					if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().Count == 0 && !string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
						if (lst.Count == 0)
						{
							ListaComplementosPagoSinReferenciaImportada.Add(f);
						}
					}
				}
			}
			StringBuilder sb = new StringBuilder();
			foreach (EntFactura f2 in ListaComplementosPagoSinReferenciaImportada)
			{
				ListaFacturas.RemoveAll((EntFactura P) => P.UUID == f2.UUID);
				sb.AppendLine("El Complemento de Pago: -" + f2.NumeroFactura + "-  hace referencia al siguiente UUID de Factura que no se encuentra registrada en el sistema. \n\n  UUID: " + f2.UUIDrelacionado + " ");
			}
			if (sb.Length > 0)
			{
				MuestraMensajeAdvertencia(sb.ToString() + "\n\n Se recomienda importar Factura(s) correspondiente(s) para continuar con el proceso.", "CFDI'S RESTRINGIDOS PARA IMPORTACIÓN");
			}
		}

		private void RevisaExistenFacturasParaCP40(List<EntFactura> ListaComplementosPago40, List<EntFactura> ListaFacturas)
		{
			List<EntFactura> listaComplementosPagoSinReferenciaImportada = new List<EntFactura>();
			if (ListaFacturas.Count <= 0)
			{
				return;
			}
			foreach (EntFactura f in ListaComplementosPago40)
			{
				string s = f.UUIDrelacionado;
				if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().Count == 0 && !string.IsNullOrWhiteSpace(s))
				{
					List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
					if (lst.Count == 0)
					{
						listaComplementosPagoSinReferenciaImportada.Add(f);
					}
					else
					{
						f.FacturaRelacionId = lst.First().Id;
					}
				}
				f.UUID = ListaFacturas.Where((EntFactura P) => P.Id == f.Id).First().UUID;
			}
			StringBuilder sb = new StringBuilder();
			foreach (EntFactura f2 in listaComplementosPagoSinReferenciaImportada)
			{
				sb.AppendLine("El Complemento de Pago: -" + f2.NumeroFactura + "-  hace referencia al siguiente UUID de Factura que no se encuentra registrada en el sistema. \n\n  UUID: " + f2.UUIDrelacionado + "\n ");
			}
			if (sb.Length > 0)
			{
				MuestraMensajeAdvertencia(sb.ToString() + "\n\n Se recomienda importar Factura(s) correspondiente(s) para continuar con el proceso.", "CFDI'S RESTRINGIDOS PARA IMPORTACIÓN");
			}
		}

		private void RevisaExistenUUIDRelacionadoEnCP40(List<EntFactura> ListaComplementosPago40, List<EntFactura> ListaFacturas)
		{
			if (ListaFacturas.Count <= 0)
			{
				return;
			}
			foreach (EntFactura f in ListaComplementosPago40)
			{
				string s = f.UUIDrelacionado;
				if (string.IsNullOrWhiteSpace(s))
				{
					ListaComplementosPagoSinReferenciaImportada.Add(f);
					continue;
				}
				f.UUID = ListaFacturas.Where((EntFactura P) => P.Id == f.Id).First().UUID;
			}
			StringBuilder sb = new StringBuilder();
			foreach (EntFactura f2 in ListaComplementosPagoSinReferenciaImportada)
			{
				ListaFacturas.RemoveAll((EntFactura P) => P.Id == f2.Id);
				sb.AppendLine("El Complemento de Pago: -" + f2.NumeroFactura + "-  NO hace referencia UUID relacionado.\n ");
			}
			if (sb.Length > 0)
			{
				MuestraMensajeAdvertencia(sb.ToString() + "\n\n Se recomienda verificar Factura(s) correspondiente(s) para continuar con el proceso.", "CFDI'S RESTRINGIDOS PARA IMPORTACIÓN");
			}
		}

		private void RevisaExistenFacturasParaAnticipo(List<EntFactura> ListaFacturas)
		{
			ListaAnticiposSinReferenciaImportada = new List<EntFactura>();
			List<EntFactura> ListaAnticipos = ListaFacturas.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.TipoRelacionId == 7).ToList();
			foreach (EntFactura f in ListaAnticipos)
			{
				string[] facturas = f.UUIDrelacionado.Split('|');
				string[] array = facturas;
				foreach (string s in array)
				{
					if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().Count == 0 && !string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
						if (lst.Count == 0)
						{
							ListaAnticiposSinReferenciaImportada.Add(f);
						}
						else
						{
							f.FacturaRelacionId = lst.First().Id;
						}
					}
				}
			}
			StringBuilder sb = new StringBuilder();
			foreach (EntFactura f2 in ListaAnticiposSinReferenciaImportada)
			{
				ListaFacturas.RemoveAll((EntFactura P) => P.UUID == f2.UUID);
				sb.AppendLine("El Comprobante Fiscal: " + f2.NumeroFactura + " hace referencia a la Factura con UUID:" + f2.UUIDrelacionado + " la cual no se encuentra registrada en el sistema.\n\n Se recomienda importar Factura correspondiente para continuar con el proceso.");
			}
			if (sb.Length > 0)
			{
				MuestraMensajeAdvertencia(sb.ToString(), "CFDI'S RESTRINGIDOS PARA IMPORTACIÓN");
			}
		}

		private void RevisaExistenFacturasParaEgreso(List<EntFactura> ListaFacturas)
		{
			ListaFacturaEgresoSinReferenciaImportada = new List<EntFactura>();
			List<EntFactura> ListaEgresos = ListaFacturas.Where((EntFactura P) => P.TipoComprobanteId == 2 && (P.TipoRelacionId == 1 || P.TipoRelacionId == 3 || P.TipoRelacionId == 7)).ToList();
			foreach (EntFactura f in ListaEgresos)
			{
				string[] facturas = f.UUIDrelacionado.Split('|');
				string[] array = facturas;
				foreach (string s in array)
				{
					if (ListaFacturas.Where((EntFactura P) => P.UUID == s).ToList().Count == 0 && !string.IsNullOrWhiteSpace(s))
					{
						List<EntFactura> lst = new BusFacturas().ObtieneComprobantesFiscales(base.EmpresaSeleccionada, s);
						if (lst.Count == 0)
						{
							ListaFacturaEgresoSinReferenciaImportada.Add(f);
						}
						else
						{
							f.FacturaRelacionId = lst.First().Id;
						}
					}
				}
			}
			StringBuilder sb = new StringBuilder();
			foreach (EntFactura f2 in ListaFacturaEgresoSinReferenciaImportada)
			{
				ListaFacturas.RemoveAll((EntFactura P) => P.UUID == f2.UUID);
				sb.AppendLine("El Comprobante Fiscal: " + f2.NumeroFactura + " hace referencia a la Factura con UUID:" + f2.UUIDrelacionado + " la cual no se encuentra registrada en el sistema.\n\n Se recomienda importar Factura correspondiente para continuar con el proceso.");
			}
			if (sb.Length > 0)
			{
				MuestraMensajeAdvertencia(sb.ToString(), "CFDI'S RESTRINGIDOS PARA IMPORTACIÓN");
			}
		}

		private Form BuscaForma(string Titulo)
		{
			Form[] mdiChildren = base.ParentForm.MdiChildren;
			foreach (Form v in mdiChildren)
			{
				if (v.Text == Titulo)
				{
					return v;
				}
			}
			return null;
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				CargaEmpresas(cmbEmpresas, Program.UsuarioSeleccionado.CompañiaId);
				if (Program.EmpresaSeleccionada == null)
				{
					Program.EmpresaSeleccionada = SeleccionaEmpresa();
				}
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				CargaDatosEmpresa(txtNombreFiscal, txtRFC, txtRutaCarpeta);
				PaginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
				CargaLicenciasDescargaMasiva(Program.UsuarioSeleccionado.CompañiaId, ref ListaLicenciasDescargaMasiva);
				if (ListaLicenciasDescargaMasiva.Count == 0 && (!(Program.UsuarioSeleccionado.Usuario == "sys") || !(Program.UsuarioSeleccionado.Contraseña == "5fb552a76ef3c7ee67681d80e9797e088a6c9859")))
				{
					btnDescargaMasivaSAT.Enabled = false;
					lnkDescargaMasiva.Visible = true;
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

		private void rdoEmitidos_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				rdoRecibidos.Checked = !rdoEmitidos.Checked;
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoRecibidos_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				rdoEmitidos.Checked = !rdoRecibidos.Checked;
				if (rdoRecibidos.Checked)
				{
					btnImportaXMLs.Visible = false;
				}
				else
				{
					btnImportaXMLs.Visible = true;
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					CargaDatosEmpresa(txtNombreFiscal, txtRFC, txtRutaCarpeta);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnCargaXMLs_Click(object sender, EventArgs e)
		{
			try
			{
				string rutaCarpeta = SeleccionaCarpeta();
				txtRutaCarpeta.Text = rutaCarpeta;
				bool emitidos = rdoEmitidos.Checked;
				btnRefrescaCargaArchivo.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex, "ERROR CARGA ARCHIVOS XML");
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnRefrescaCargaArchivo_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (string.IsNullOrWhiteSpace(txtRutaCarpeta.Text))
				{
					txtRutaCarpeta.Focus();
					MandaExcepcion("Ruta de Carpeta Necesaria");
				}
				CargaXMLsEmitidosEnGrid(txtRutaCarpeta.Text, gvXMLs, rdoEmitidos.Checked);
				ListaCP = SetIVAenPagos(ObtieneListaFacturasFromGV(gvXMLs), (from P in ObtieneListaFacturasFromGV(gvXMLs)
					where P.TipoComprobanteId == 5 && P.VersionCFDIId == 1
					select P).ToList());
				List<EntFactura> lstFacturas = (from P in ObtieneListaFacturasFromGV(gvXMLs)
					orderby P.TipoComprobanteId, P.Fecha
					select P).ToList();
				RevisaExistenFacturasParaCP(lstFacturas);
				RevisaExistenFacturasParaCP40(ListaCP40, lstFacturas);
				RevisaExistenUUIDRelacionadoEnCP40(ListaCP40, lstFacturas);
				RevisaExistenFacturasParaAnticipo(lstFacturas);
				RevisaExistenFacturasParaEgreso(lstFacturas);
				CargaXMLsEmitidosEnGrid(lstFacturas, gvXMLs, txtNumComprobantes);
				List<EntFactura> lstFacturasNoImportados = new List<EntFactura>();
				lstFacturasNoImportados.AddRange(ListaComplementosPagoSinReferenciaImportada);
				lstFacturasNoImportados.AddRange(ListaAnticiposSinReferenciaImportada);
				lstFacturasNoImportados.AddRange(ListaFacturaEgresoSinReferenciaImportada);
				CargaXMLsEmitidosEnGrid(lstFacturasNoImportados, gvXMLsRestringidos, txtNumComprobantesRestringidos);
				ListaPercepciones = SetPercepciones(ObtieneListaFacturasFromGV(gvXMLs));
				ListaDeducciones = SetDeducciones(ObtieneListaFacturasFromGV(gvXMLs));
				SetDefaultCursor();
				MuestraMensajeImportar vMensajeImporta = new MuestraMensajeImportar();
				if (vMensajeImporta.ShowDialog() == DialogResult.OK)
				{
					btnImportaXMLs.PerformClick();
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

		private void IngresaComprobantesIngresoNoRelacionados(List<EntFactura> FacturasIngreso)
		{
			foreach (EntFactura f in FacturasIngreso.Where((EntFactura P) => P.TipoComprobanteId != 5 && P.TipoRelacionId == 0).ToList())
			{
				f.ClienteId = RevisaAgregaCliente(f.Nombre, f.RFC, f.TipoComprobanteId);
				List<EntFactura> lstFacA = ListaFacturas40adicionales.Where((EntFactura P) => P.Id == f.Id).ToList();
				f.Id = AgregarComprobanteFiscal(f);
				foreach (EntFactura facA in lstFacA)
				{
					facA.Id = f.Id;
					new BusFacturas().AgregaComprobantesFiscalesDatosAdicionales(facA);
				}
			}
		}

		private void IngresaComprobantesIngresoRelacionados(List<EntFactura> FacturasIngreso)
		{
			foreach (EntFactura f in FacturasIngreso.Where((EntFactura P) => P.TipoComprobanteId != 5 && P.TipoRelacionId > 0).ToList())
			{
				f.ClienteId = RevisaAgregaCliente(f.Nombre, f.RFC, f.TipoComprobanteId);
				if (!string.IsNullOrWhiteSpace(f.UUIDrelacionado) && f.FacturaRelacionId == 0 && FacturasIngreso.Where((EntFactura P) => P.UUID == f.UUIDrelacionado).ToList().Count > 0)
				{
					f.FacturaRelacionId = FacturasIngreso.Where((EntFactura P) => P.UUID == f.UUIDrelacionado).ToList()[0].Id;
				}
				List<EntFactura> lstFacA = ListaFacturas40adicionales.Where((EntFactura P) => P.Id == f.Id).ToList();
				f.Id = AgregarComprobanteFiscal(f);
				foreach (EntFactura facA in lstFacA)
				{
					facA.Id = f.Id;
					new BusFacturas().AgregaComprobantesFiscalesDatosAdicionales(facA);
				}
			}
		}

		private void IngresaComprobantesCP(List<EntFactura> ListaComplementosPago, List<EntFactura> ListaComprobantesFiscales)
		{
			foreach (EntFactura cp in ListaComplementosPago.OrderBy((EntFactura P) => P.FechaPago))
			{
				cp.ClienteId = RevisaAgregaCliente(cp.Nombre, cp.RFC, 5);
				if (cp.FacturaRelacionId == 0 && ListaComprobantesFiscales.Where((EntFactura P) => P.UUID == cp.UUIDrelacionado).ToList().Count > 0)
				{
					cp.FacturaRelacionId = ListaComprobantesFiscales.Where((EntFactura P) => P.UUID == cp.UUIDrelacionado).ToList()[0].Id;
				}
				cp.Id = AgregarComprobanteFiscal(cp);
			}
		}

		private void IngresaComprobantesCP40(List<EntFactura> ListaComplementosPago40, List<EntFactura> ListaComprobantesFiscales)
		{
			foreach (EntFactura cp in ListaComplementosPago40.OrderBy((EntFactura P) => P.FechaPago))
			{
				cp.ClienteId = RevisaAgregaCliente(cp.Nombre, cp.RFC, 5);
				if (cp.FacturaRelacionId == 0 && ListaComprobantesFiscales.Where((EntFactura P) => P.UUID == cp.UUIDrelacionado).ToList().Count > 0)
				{
					cp.FacturaRelacionId = ListaComprobantesFiscales.Where((EntFactura P) => P.UUID == cp.UUIDrelacionado).ToList()[0].Id;
				}
				List<EntFactura> lstCpA = ListaCP40adicionales.Where((EntFactura P) => P.Id == cp.Id && P.UUIDrelacionado == cp.UUIDrelacionado).ToList();
				cp.SubTotal = lstCpA.Where((EntFactura P) => P.TipoEstructuraImpuestoId == 1 && P.TipoImpuestoId == 2).Sum((EntFactura P) => P.Total);
				cp.IVA = lstCpA.Where((EntFactura P) => P.TipoEstructuraImpuestoId == 1 && P.TipoImpuestoId == 2).Sum((EntFactura P) => P.ImporteDR);
				cp.IEPS = lstCpA.Where((EntFactura P) => P.TipoEstructuraImpuestoId == 1 && P.TipoImpuestoId == 3).Sum((EntFactura P) => P.ImporteDR);
				cp.IVARetenciones = lstCpA.Where((EntFactura P) => P.TipoEstructuraImpuestoId == 2 && P.TipoImpuestoId == 2).Sum((EntFactura P) => P.ImporteDR);
				cp.ISRRetenciones = lstCpA.Where((EntFactura P) => P.TipoEstructuraImpuestoId == 2 && P.TipoImpuestoId == 1).Sum((EntFactura P) => P.ImporteDR);
				switch (cp.ObjetoImpuestoId)
				{
				case 1:
					cp.ObjetoImpuesto01 += cp.SubTotal;
					break;
				case 2:
					cp.ObjetoImpuesto02 += cp.SubTotal;
					break;
				case 3:
					cp.ObjetoImpuesto03 += cp.SubTotal;
					break;
				}
				cp.Id = AgregarComprobanteFiscal(cp);
				foreach (EntFactura cpA in lstCpA)
				{
					cpA.Id = cp.Id;
					new BusFacturas().AgregaComprobantesFiscalesDatosAdicionales(cpA);
				}
			}
		}

		private void IngresaPercepciones(List<EntCatalogoPercepciones> ListaPercepciones)
		{
			foreach (EntCatalogoPercepciones cp in ListaPercepciones)
			{
				cp.Id = AgregarComprobanteFiscalPercepcion(cp);
			}
		}

		private void IngresaDeducciones(List<EntCatalogoPercepciones> ListaPercepciones)
		{
			foreach (EntCatalogoPercepciones cp in ListaPercepciones)
			{
				cp.Id = AgregarComprobanteFiscalDeduccion(cp);
			}
		}

		private void btnImportaXMLs_Click(object sender, EventArgs e)
		{
			try
			{
				tcPedidosGrids.Enabled = false;
				Cargando ca = (Cargando)BuscaForma(new Cargando().Titulo);
				if (ca != null)
				{
					MandaExcepcion("IMPORTANDO ARCHIVOS");
				}
				VerificaVigenciaLicencia(Program.EmpresaSeleccionada);
				if (string.IsNullOrWhiteSpace(txtRutaCarpeta.Text))
				{
					txtRutaCarpeta.Focus();
					MandaExcepcion("Seleccione carpeta de archivos a Importar");
				}
				if (gvXMLs.Rows.Count == 0)
				{
					txtRutaCarpeta.Focus();
					MandaExcepcion("No se encontraron archivos a Importar");
				}
				if (MuestraMensajeYesNo("¿Seguro desea Importar los archivos mostrados?") == DialogResult.Yes)
				{
					SetWaitCursor();
					List<EntFactura> lstFacturas = (from P in ObtieneListaFacturasFromGV(gvXMLs)
						orderby P.TipoComprobanteId, P.Fecha
						select P).ToList();
					carga = new Cargando(ConvierteTextoAInteger(txtNumComprobantes.Text));
					carga.Show();
					ConvierteComprobantesIngresoToMXN(lstFacturas);
					ConvierteComprobantesIngresoToMXN(ListaFacturas40adicionales);
					ConvierteComprobantesIngresoToMXN(ListaCP40.Where((EntFactura P) => !string.IsNullOrWhiteSpace(P.UUID)).ToList());
					ConvierteComprobantesIngresoToMXN(ListaCP40adicionales, true);
					IngresaComprobantesIngresoNoRelacionados(lstFacturas);
					IngresaComprobantesIngresoRelacionados(lstFacturas);
					IngresaComprobantesCP(ListaCP, lstFacturas);
					IngresaComprobantesCP40(ListaCP40.Where((EntFactura P) => !string.IsNullOrWhiteSpace(P.UUID)).ToList(), lstFacturas);
					ListaPercepciones = SetPercepciones(lstFacturas);
					IngresaPercepciones(ListaPercepciones);
					ListaDeducciones = SetDeducciones(lstFacturas);
					IngresaDeducciones(ListaDeducciones);
					gvXMLs.DataSource = null;
					gvXMLs.Refresh();
					carga.Close();
					txtNumComprobantes.Text = "0";
					MuestraMensaje("¡Comprobantes Fiscales Importados!");
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
				tcPedidosGrids.Enabled = true;
			}
		}

		private void btnExportar_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntFactura> xmls = (from P in ObtieneListaFacturasFromGV(gvXMLs)
					where P.TipoComprobanteId != 5
					select P).ToList();
				xmls.AddRange(ListaCP);
				xmls.AddRange(ListaCP40);
				ImprimeCFDIs vImprime = new ImprimeCFDIs(xmls, true);
				vImprime.Show();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnDescargaSAT_Click(object sender, EventArgs e)
		{
			try
			{
				DescargaPaginaSAT vDescargaSAT = new DescargaPaginaSAT();
				vDescargaSAT.ShowDialog();
				string rutaUltimoZip = txtRutaCarpeta.Text + "\\" + EncuentraArchivo(txtRutaCarpeta.Text, ".zip");
				MuestraMensaje("CONFIRMAR RUTA PARA DESCOMPRIMIR");
				string rutaDestino = SeleccionaCarpeta(txtRutaCarpeta.Text);
				DescomprimirArchivo(rutaUltimoZip, rutaDestino);
				txtRutaCarpeta.Text = rutaDestino;
				btnRefrescaCargaArchivo.PerformClick();
			}
			catch (Exception)
			{
			}
		}

		private string DescargaDescomprimeArchivoDescargaMasivaSAT(string Solicitud, string DireccionHTTPDescargaMasiva, string RutaDestino)
		{
			DescargaMasivaLink vDescargaMasiva = new DescargaMasivaLink(DireccionHTTPDescargaMasiva.Remove(0, 6).Replace("\"\r\n]", ""));
			vDescargaMasiva.ShowDialog();
			string rutaDescargas = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
			string rutaUltimoZip = rutaDescargas + "\\" + Solicitud + "_1.zip";
			MuestraMensaje("DESCARGA COMPLETA");
			CreaDirectorio(RutaDestino);
			DescomprimirArchivo(rutaUltimoZip, RutaDestino);
			return RutaDestino;
		}

		private async void Verifica(string Solicitud)
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

		private async Task RevisaUltmFechaSincRFCenRS(string RfcVerifica, string CIEC, bool MostrarMensaje)
		{
			await ObtieneDescargaListaRS();
			RfcEncontrado = false;
			foreach (razonesSociales r in ListaRS)
			{
				if (r.rfc == RfcVerifica)
				{
					RfcEncontrado = true;
					if (r.fecha_ult_sync == "0000-00-00")
					{
						RfcEncontrado = false;
						MuestraMensaje("ESPERA 24 HORAS PARA LA VALIDACIÓN DE CIEC Y PODER UTILIZAR DESCARGA MASIVA.\n\nCIEC: " + CIEC + "\nRAZÓN SOCIAL: " + r.razon_social + "\nRFC: " + r.rfc.ToString() + "\nFECHA ÚLTM. SINC: " + r.fecha_ult_sync, "REGISTRO DE CIEC ENCONTRADO");
					}
				}
			}
		}

		private async void btnDescargaMasivaSAT_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				if (string.IsNullOrWhiteSpace(Program.EmpresaSeleccionada.Certificado))
				{
					RegistroCIEC vRegCIEC = new RegistroCIEC(Program.EmpresaSeleccionada);
					vRegCIEC.ShowDialog();
				}
				else if (!string.IsNullOrWhiteSpace(Program.EmpresaSeleccionada.Certificado))
				{
					string rfcVerifica = txtRFC.Text;
					if (string.IsNullOrWhiteSpace(rfcVerifica))
					{
						MandaExcepcion("INGRESE RFC VÁLIDO");
					}
					await ObtieneDescargaListaRS();
					await RevisaUltmFechaSincRFCenRS(rfcVerifica, Program.EmpresaSeleccionada.Certificado, false);
					if (RfcEncontrado)
					{
						DescargaMasiva vDescargaM = new DescargaMasiva(Program.EmpresaSeleccionada, true);
						if (vDescargaM.ShowDialog() == DialogResult.OK)
						{
							txtRutaCarpeta.Text = vDescargaM.RutaDescargaMasiva;
							btnRefrescaCargaArchivo.PerformClick();
						}
					}
				}
				else
				{
					MuestraMensajeError("NO SE HA PODIDO REGISTRAR CONTRASEÑA CIEC", "ERROR AL REGISTRAR CIEC");
				}
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				MuestraExcepcion(ex2);
				mensajeDescargaM = "";
				tsbCancelaDescargaMasiva.PerformButtonClick();
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void tmVerificaDescargaMasivaSAT_Tick(object sender, EventArgs e)
		{
			try
			{
				string solicitud = statusStrip1.Text;
				toolStripStatusLabel1.Text += " | VERIFICANDO  SOLICITUD ";
				toolStripProgressBar1.Value = 1;
				Verifica(solicitud);
				tmVerificaDescargaMasivaSAT.Stop();
				if (!string.IsNullOrWhiteSpace(RutaHTTPDescargaMasivaSAT))
				{
					txtRutaCarpeta.Text = DescargaDescomprimeArchivoDescargaMasivaSAT(solicitud, RutaHTTPDescargaMasivaSAT, txtRutaCarpeta.Text);
					btnRefrescaCargaArchivo.PerformClick();
				}
				else
				{
					tmVerificaDescargaMasivaSAT2.Start();
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

		private void tmVerificaDescargaMasivaSAT2_Tick(object sender, EventArgs e)
		{
			try
			{
				intentosDescarga++;
				string solicitud = statusStrip1.Text;
				tmVerificaDescargaMasivaSAT2.Stop();
				Verifica(solicitud);
				if (!string.IsNullOrWhiteSpace(RutaHTTPDescargaMasivaSAT))
				{
					tmVerificaDescargaMasivaSAT2.Stop();
					toolStripStatusLabel1.Text += " | VERIFICADA ";
					txtRutaCarpeta.Text = DescargaDescomprimeArchivoDescargaMasivaSAT(solicitud, RutaHTTPDescargaMasivaSAT, txtRutaCarpeta.Text);
					btnRefrescaCargaArchivo.PerformClick();
					toolStripStatusLabel1.Text += " | SOLICITUD DESCARGADA";
					toolStripProgressBar1.Value = 0;
				}
				else if (intentosDescarga < 15)
				{
					tmVerificaDescargaMasivaSAT2.Start();
				}
				else
				{
					intentosDescarga = 0;
					tmVerificaDescargaMasivaSAT2.Stop();
					tsbCancelaDescargaMasiva.PerformClick();
					MuestraMensajeError("SE HA LLEGADO AL LÍMITE DE INTENTOS DE DESCARGA PARA ESTA SOLICITUD. VUELVA A INTENTAR MÁS TARDE.\n\n *VERIFIQUE QUE LA CIEC ESTE REGISTRADA CORRECTAMENTE. \n\n *ASEGURECE QUE HAYAN TRANSCURRIDO 24 HORAS PARA LA VALIDACIÓN DE LA CIEC.\r\n", "DESCARGA NO COMPLETADA");
					tsbCancelaDescargaMasiva.PerformButtonClick();
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

		private void btnVerificaDescargaMasivaSAT_Click(object sender, EventArgs e)
		{
			try
			{
				statusStrip1.Text = "95baac30-7de2-11ee-aad9-b28e36eab3d8";
				Verifica("95baac30-7de2-11ee-aad9-b28e36eab3d8");
				if (!string.IsNullOrWhiteSpace(RutaHTTPDescargaMasivaSAT))
				{
					Process.Start(RutaHTTPDescargaMasivaSAT);
					tmVerificaDescargaMasivaSAT2.Stop();
				}
				else
				{
					tmVerificaDescargaMasivaSAT2.Start();
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

		private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
		{
			try
			{
				tmVerificaDescargaMasivaSAT.Stop();
				tmVerificaDescargaMasivaSAT2.Stop();
				toolStripProgressBar1.Value = 0;
				toolStripStatusLabel1.Text = "";
				mensajeDescargaM = "";
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

		private void lnkDescargaMasiva_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start(PaginaDescarga);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void gvXMLs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				MuestraDatosFactura(sender);
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

		private void btnBuscaEmpresa_Click(object sender, EventArgs e)
		{
			try
			{
				Program.EmpresaSeleccionada = SeleccionaEmpresa();
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.LeeXMLs));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tcPedidosGrids = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtNombreFiscal = new System.Windows.Forms.TextBox();
			this.txtRFC = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pnlGeneral = new System.Windows.Forms.Panel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.lnkDescargaMasiva = new System.Windows.Forms.LinkLabel();
			this.btnVerificaDescargaMasivaSAT = new System.Windows.Forms.Button();
			this.gbCFDISnoImporta = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.label7 = new System.Windows.Forms.Label();
			this.txtSubTotalRestringidos = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtNumComprobantesRestringidos = new System.Windows.Forms.TextBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.gvXMLsRestringidos = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.tsbCancelaDescargaMasiva = new System.Windows.Forms.ToolStripSplitButton();
			this.btnDescargaMasivaSAT = new System.Windows.Forms.Button();
			this.pnlCFDISimporta = new System.Windows.Forms.Panel();
			this.gvXMLs = new System.Windows.Forms.DataGridView();
			this.rFCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uUIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.subTotalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnImporteDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.iVADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IEPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IVARetenciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ISRRetenciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.retencionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Moneda = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gvColumnTipoComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MetodoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UUIDrelacionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.label2 = new System.Windows.Forms.Label();
			this.txtSubTotal = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIVA = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporte = new System.Windows.Forms.ToolStripTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtNumComprobantes = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnDescargaSAT = new System.Windows.Forms.Button();
			this.txtRutaCarpeta = new System.Windows.Forms.TextBox();
			this.rdoRecibidos = new System.Windows.Forms.RadioButton();
			this.rdoEmitidos = new System.Windows.Forms.RadioButton();
			this.btnRefrescaCargaArchivo = new System.Windows.Forms.Button();
			this.btnCargaXMLs = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnImportaXMLs = new System.Windows.Forms.Button();
			this.btnExportar = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tmVerificaDescargaMasivaSAT = new System.Windows.Forms.Timer(this.components);
			this.tmVerificaDescargaMasivaSAT2 = new System.Windows.Forms.Timer(this.components);
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.flpEmpresas = new System.Windows.Forms.FlowLayoutPanel();
			this.label24 = new System.Windows.Forms.Label();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tcPedidosGrids.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gbDatosGenerales.SuspendLayout();
			this.pnlGeneral.SuspendLayout();
			this.gbCFDISnoImporta.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLsRestringidos).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.pnlCFDISimporta.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).BeginInit();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flpEmpresas.SuspendLayout();
			base.SuspendLayout();
			this.tcPedidosGrids.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcPedidosGrids.Controls.Add(this.tabPage1);
			this.tcPedidosGrids.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcPedidosGrids.Location = new System.Drawing.Point(15, 35);
			this.tcPedidosGrids.Name = "tcPedidosGrids";
			this.tcPedidosGrids.SelectedIndex = 0;
			this.tcPedidosGrids.Size = new System.Drawing.Size(1012, 489);
			this.tcPedidosGrids.TabIndex = 129;
			this.tabPage1.Controls.Add(this.gbDatosGenerales);
			this.tabPage1.Controls.Add(this.pnlGeneral);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.tabPage1.Size = new System.Drawing.Size(1004, 462);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Importar Comprobantes Fiscales ";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.gbDatosGenerales.Controls.Add(this.label4);
			this.gbDatosGenerales.Controls.Add(this.txtNombreFiscal);
			this.gbDatosGenerales.Controls.Add(this.txtRFC);
			this.gbDatosGenerales.Controls.Add(this.label5);
			this.gbDatosGenerales.Location = new System.Drawing.Point(96, 2);
			this.gbDatosGenerales.Name = "gbDatosGenerales";
			this.gbDatosGenerales.Size = new System.Drawing.Size(484, 69);
			this.gbDatosGenerales.TabIndex = 136;
			this.gbDatosGenerales.TabStop = false;
			this.gbDatosGenerales.Text = "Datos Empresa Emisora";
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.White;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new System.Drawing.Point(13, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 19);
			this.label4.TabIndex = 102;
			this.label4.Text = "Nombre Fiscal:";
			this.txtNombreFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNombreFiscal.Location = new System.Drawing.Point(114, 17);
			this.txtNombreFiscal.Name = "txtNombreFiscal";
			this.txtNombreFiscal.ReadOnly = true;
			this.txtNombreFiscal.Size = new System.Drawing.Size(341, 22);
			this.txtNombreFiscal.TabIndex = 104;
			this.txtRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRFC.Location = new System.Drawing.Point(114, 43);
			this.txtRFC.Name = "txtRFC";
			this.txtRFC.ReadOnly = true;
			this.txtRFC.Size = new System.Drawing.Size(166, 22);
			this.txtRFC.TabIndex = 106;
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.White;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new System.Drawing.Point(66, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 19);
			this.label5.TabIndex = 105;
			this.label5.Text = "R.F.C:";
			this.pnlGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pnlGeneral.Controls.Add(this.linkLabel1);
			this.pnlGeneral.Controls.Add(this.lnkDescargaMasiva);
			this.pnlGeneral.Controls.Add(this.btnVerificaDescargaMasivaSAT);
			this.pnlGeneral.Controls.Add(this.gbCFDISnoImporta);
			this.pnlGeneral.Controls.Add(this.statusStrip1);
			this.pnlGeneral.Controls.Add(this.btnDescargaMasivaSAT);
			this.pnlGeneral.Controls.Add(this.pnlCFDISimporta);
			this.pnlGeneral.Controls.Add(this.label1);
			this.pnlGeneral.Controls.Add(this.btnDescargaSAT);
			this.pnlGeneral.Controls.Add(this.txtRutaCarpeta);
			this.pnlGeneral.Controls.Add(this.rdoRecibidos);
			this.pnlGeneral.Controls.Add(this.rdoEmitidos);
			this.pnlGeneral.Controls.Add(this.btnRefrescaCargaArchivo);
			this.pnlGeneral.Controls.Add(this.btnCargaXMLs);
			this.pnlGeneral.Controls.Add(this.flowLayoutPanel1);
			this.pnlGeneral.Location = new System.Drawing.Point(1, 73);
			this.pnlGeneral.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.pnlGeneral.Name = "pnlGeneral";
			this.pnlGeneral.Size = new System.Drawing.Size(1003, 388);
			this.pnlGeneral.TabIndex = 135;
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel1.Location = new System.Drawing.Point(2, 302);
			this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(86, 41);
			this.linkLabel1.TabIndex = 148;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "¡Adquiere tu Licencia Descarga Masiva Aquí!";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.UseWaitCursor = true;
			this.linkLabel1.Visible = false;
			this.lnkDescargaMasiva.Font = new System.Drawing.Font("Microsoft Tai Le", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lnkDescargaMasiva.Location = new System.Drawing.Point(3, 239);
			this.lnkDescargaMasiva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lnkDescargaMasiva.Name = "lnkDescargaMasiva";
			this.lnkDescargaMasiva.Size = new System.Drawing.Size(86, 26);
			this.lnkDescargaMasiva.TabIndex = 147;
			this.lnkDescargaMasiva.TabStop = true;
			this.lnkDescargaMasiva.Text = "¡PRÓXIMAMENTE!";
			this.lnkDescargaMasiva.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lnkDescargaMasiva.UseWaitCursor = true;
			this.lnkDescargaMasiva.Visible = false;
			this.lnkDescargaMasiva.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkDescargaMasiva_LinkClicked);
			this.btnVerificaDescargaMasivaSAT.BackColor = System.Drawing.Color.White;
			this.btnVerificaDescargaMasivaSAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnVerificaDescargaMasivaSAT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnVerificaDescargaMasivaSAT.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnVerificaDescargaMasivaSAT.Location = new System.Drawing.Point(2, 316);
			this.btnVerificaDescargaMasivaSAT.Name = "btnVerificaDescargaMasivaSAT";
			this.btnVerificaDescargaMasivaSAT.Size = new System.Drawing.Size(88, 44);
			this.btnVerificaDescargaMasivaSAT.TabIndex = 146;
			this.btnVerificaDescargaMasivaSAT.Text = "VERIFICA Descarga Masiva SAT";
			this.btnVerificaDescargaMasivaSAT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnVerificaDescargaMasivaSAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnVerificaDescargaMasivaSAT.UseVisualStyleBackColor = false;
			this.btnVerificaDescargaMasivaSAT.Visible = false;
			this.btnVerificaDescargaMasivaSAT.Click += new System.EventHandler(btnVerificaDescargaMasivaSAT_Click);
			this.gbCFDISnoImporta.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gbCFDISnoImporta.Controls.Add(this.flowLayoutPanel2);
			this.gbCFDISnoImporta.Controls.Add(this.gvXMLsRestringidos);
			this.gbCFDISnoImporta.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.gbCFDISnoImporta.Location = new System.Drawing.Point(92, 239);
			this.gbCFDISnoImporta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.gbCFDISnoImporta.Name = "gbCFDISnoImporta";
			this.gbCFDISnoImporta.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.gbCFDISnoImporta.Size = new System.Drawing.Size(838, 121);
			this.gbCFDISnoImporta.TabIndex = 140;
			this.gbCFDISnoImporta.TabStop = false;
			this.gbCFDISnoImporta.Text = "CFDI'S RESTRINGIDOS PARA IMPORTACIÓN";
			this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel2.Controls.Add(this.label7);
			this.flowLayoutPanel2.Controls.Add(this.txtSubTotalRestringidos);
			this.flowLayoutPanel2.Controls.Add(this.label8);
			this.flowLayoutPanel2.Controls.Add(this.txtNumComprobantesRestringidos);
			this.flowLayoutPanel2.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel2.Location = new System.Drawing.Point(5, 94);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel2.Size = new System.Drawing.Size(478, 24);
			this.flowLayoutPanel2.TabIndex = 136;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new System.Drawing.Point(1, 1);
			this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 16);
			this.label7.TabIndex = 0;
			this.label7.Text = "SubTotal:";
			this.label7.Visible = false;
			this.txtSubTotalRestringidos.Location = new System.Drawing.Point(61, 2);
			this.txtSubTotalRestringidos.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.txtSubTotalRestringidos.Name = "txtSubTotalRestringidos";
			this.txtSubTotalRestringidos.ReadOnly = true;
			this.txtSubTotalRestringidos.Size = new System.Drawing.Size(78, 19);
			this.txtSubTotalRestringidos.TabIndex = 1;
			this.txtSubTotalRestringidos.Visible = false;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new System.Drawing.Point(141, 1);
			this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(120, 16);
			this.label8.TabIndex = 3;
			this.label8.Text = "Núm Comprobantes:";
			this.txtNumComprobantesRestringidos.Location = new System.Drawing.Point(263, 2);
			this.txtNumComprobantesRestringidos.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.txtNumComprobantesRestringidos.Name = "txtNumComprobantesRestringidos";
			this.txtNumComprobantesRestringidos.ReadOnly = true;
			this.txtNumComprobantesRestringidos.Size = new System.Drawing.Size(42, 19);
			this.txtNumComprobantesRestringidos.TabIndex = 4;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.toolStripSeparator3, this.toolStripLabel3, this.toolStripTextBox1, this.toolStripSeparator4, this.toolStripLabel4, this.toolStripTextBox2 });
			this.toolStrip2.Location = new System.Drawing.Point(129, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(262, 21);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStrip2.Visible = false;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel3.Text = "I.V.A:";
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.ReadOnly = true;
			this.toolStripTextBox1.Size = new System.Drawing.Size(82, 21);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(52, 18);
			this.toolStripLabel4.Text = "Importe:";
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(39, 21);
			this.gvXMLsRestringidos.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvXMLsRestringidos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvXMLsRestringidos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLsRestringidos.AutoGenerateColumns = false;
			this.gvXMLsRestringidos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLsRestringidos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLsRestringidos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLsRestringidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLsRestringidos.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewTextBoxColumn13, this.dataGridViewTextBoxColumn14, this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.dataGridViewTextBoxColumn18);
			this.gvXMLsRestringidos.DataSource = this.entFacturaBindingSource;
			this.gvXMLsRestringidos.Location = new System.Drawing.Point(5, 18);
			this.gvXMLsRestringidos.Name = "gvXMLsRestringidos";
			this.gvXMLsRestringidos.RowHeadersVisible = false;
			this.gvXMLsRestringidos.RowHeadersWidth = 51;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
			this.gvXMLsRestringidos.RowsDefaultCellStyle = dataGridViewCellStyle11;
			this.gvXMLsRestringidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLsRestringidos.Size = new System.Drawing.Size(827, 75);
			this.gvXMLsRestringidos.TabIndex = 14;
			this.gvXMLsRestringidos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellDoubleClick);
			this.dataGridViewTextBoxColumn1.DataPropertyName = "RFC";
			this.dataGridViewTextBoxColumn1.FillWeight = 150f;
			this.dataGridViewTextBoxColumn1.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Nombre";
			this.dataGridViewTextBoxColumn2.FillWeight = 250f;
			this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn3.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn3.FillWeight = 250f;
			this.dataGridViewTextBoxColumn3.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
			this.dataGridViewTextBoxColumn5.DataPropertyName = "Folio";
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle12;
			this.dataGridViewTextBoxColumn5.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
			this.dataGridViewTextBoxColumn5.ReadOnly = true;
			this.dataGridViewTextBoxColumn6.DataPropertyName = "SubTotal";
			dataGridViewCellStyle13.Format = "c2";
			this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle13;
			this.dataGridViewTextBoxColumn6.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
			this.dataGridViewTextBoxColumn7.DataPropertyName = "Descuento";
			dataGridViewCellStyle14.Format = "c2";
			this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle14;
			this.dataGridViewTextBoxColumn7.HeaderText = "Descuento";
			this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
			this.dataGridViewTextBoxColumn7.Visible = false;
			this.dataGridViewTextBoxColumn8.DataPropertyName = "IVA";
			dataGridViewCellStyle15.Format = "c2";
			this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle15;
			this.dataGridViewTextBoxColumn8.HeaderText = "IVA";
			this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn9.DataPropertyName = "IVARetenciones";
			dataGridViewCellStyle16.Format = "c2";
			this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle16;
			this.dataGridViewTextBoxColumn9.HeaderText = "IVARetenciones";
			this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			this.dataGridViewTextBoxColumn10.DataPropertyName = "ISRRetenciones";
			dataGridViewCellStyle17.Format = "c2";
			this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle17;
			this.dataGridViewTextBoxColumn10.HeaderText = "ISRRetenciones";
			this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			this.dataGridViewTextBoxColumn11.DataPropertyName = "Retenciones";
			dataGridViewCellStyle18.Format = "c2";
			this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle18;
			this.dataGridViewTextBoxColumn11.HeaderText = "Retenciones";
			this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
			this.dataGridViewTextBoxColumn12.DataPropertyName = "Total";
			dataGridViewCellStyle19.Format = "c2";
			this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle19;
			this.dataGridViewTextBoxColumn12.HeaderText = "Total";
			this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
			this.dataGridViewTextBoxColumn13.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn13.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
			this.dataGridViewTextBoxColumn14.DataPropertyName = "TipoComprobante";
			this.dataGridViewTextBoxColumn14.HeaderText = "TipoComprobante";
			this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
			this.dataGridViewTextBoxColumn14.ReadOnly = true;
			this.dataGridViewTextBoxColumn15.DataPropertyName = "MetodoPago";
			this.dataGridViewTextBoxColumn15.FillWeight = 120f;
			this.dataGridViewTextBoxColumn15.HeaderText = "MetodoPago";
			this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
			this.dataGridViewTextBoxColumn15.ReadOnly = true;
			this.dataGridViewTextBoxColumn16.DataPropertyName = "FormaPago";
			this.dataGridViewTextBoxColumn16.FillWeight = 120f;
			this.dataGridViewTextBoxColumn16.HeaderText = "FormaPago";
			this.dataGridViewTextBoxColumn16.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
			this.dataGridViewTextBoxColumn16.ReadOnly = true;
			this.dataGridViewTextBoxColumn17.DataPropertyName = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn17.FillWeight = 200f;
			this.dataGridViewTextBoxColumn17.HeaderText = "UUIDrelacionado";
			this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
			this.dataGridViewTextBoxColumn17.ReadOnly = true;
			this.dataGridViewTextBoxColumn18.DataPropertyName = "Descripcion";
			dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle20;
			this.dataGridViewTextBoxColumn18.FillWeight = 300f;
			this.dataGridViewTextBoxColumn18.HeaderText = "Descripcion";
			this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
			this.dataGridViewTextBoxColumn18.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripStatusLabel1, this.toolStripProgressBar1, this.tsbCancelaDescargaMasiva });
			this.statusStrip1.Location = new System.Drawing.Point(0, 362);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
			this.statusStrip1.Size = new System.Drawing.Size(1003, 26);
			this.statusStrip1.TabIndex = 145;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 21);
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(75, 20);
			this.tsbCancelaDescargaMasiva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCancelaDescargaMasiva.Image = LeeXML.Properties.Resources.X;
			this.tsbCancelaDescargaMasiva.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCancelaDescargaMasiva.Name = "tsbCancelaDescargaMasiva";
			this.tsbCancelaDescargaMasiva.Size = new System.Drawing.Size(36, 24);
			this.tsbCancelaDescargaMasiva.Text = "toolStripSplitButton1";
			this.tsbCancelaDescargaMasiva.ButtonClick += new System.EventHandler(toolStripSplitButton1_ButtonClick);
			this.btnDescargaMasivaSAT.BackColor = System.Drawing.Color.White;
			this.btnDescargaMasivaSAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnDescargaMasivaSAT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDescargaMasivaSAT.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnDescargaMasivaSAT.Image = LeeXML.Properties.Resources.SAT;
			this.btnDescargaMasivaSAT.Location = new System.Drawing.Point(2, 180);
			this.btnDescargaMasivaSAT.Name = "btnDescargaMasivaSAT";
			this.btnDescargaMasivaSAT.Size = new System.Drawing.Size(88, 66);
			this.btnDescargaMasivaSAT.TabIndex = 142;
			this.btnDescargaMasivaSAT.Text = "Descarga Masiva";
			this.btnDescargaMasivaSAT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnDescargaMasivaSAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDescargaMasivaSAT.UseVisualStyleBackColor = false;
			this.btnDescargaMasivaSAT.Click += new System.EventHandler(btnDescargaMasivaSAT_Click);
			this.pnlCFDISimporta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pnlCFDISimporta.Controls.Add(this.gvXMLs);
			this.pnlCFDISimporta.Controls.Add(this.flpTotalesTodos);
			this.pnlCFDISimporta.Location = new System.Drawing.Point(92, 32);
			this.pnlCFDISimporta.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pnlCFDISimporta.Name = "pnlCFDISimporta";
			this.pnlCFDISimporta.Size = new System.Drawing.Size(838, 202);
			this.pnlCFDISimporta.TabIndex = 138;
			this.gvXMLs.AllowUserToAddRows = false;
			dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle21.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
			this.gvXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvXMLs.AutoGenerateColumns = false;
			this.gvXMLs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvXMLs.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvXMLs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvXMLs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvXMLs.Columns.AddRange(this.rFCDataGridViewTextBoxColumn, this.nombreDataGridViewTextBoxColumn, this.uUIDDataGridViewTextBoxColumn, this.folioDataGridViewTextBoxColumn, this.subTotalDataGridViewTextBoxColumn, this.descuentoDataGridViewTextBoxColumn, this.gvColumnImporteDR, this.iVADataGridViewTextBoxColumn, this.IEPS, this.IVARetenciones, this.ISRRetenciones, this.retencionesDataGridViewTextBoxColumn, this.totalDataGridViewTextBoxColumn, this.Moneda, this.fechaDataGridViewTextBoxColumn, this.gvColumnTipoComprobante, this.MetodoPago, this.FormaPago, this.UUIDrelacionado, this.Descripcion);
			this.gvXMLs.DataSource = this.entFacturaBindingSource;
			this.gvXMLs.Location = new System.Drawing.Point(2, 0);
			this.gvXMLs.Name = "gvXMLs";
			this.gvXMLs.ReadOnly = true;
			this.gvXMLs.RowHeadersVisible = false;
			this.gvXMLs.RowHeadersWidth = 51;
			dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75f);
			dataGridViewCellStyle26.ForeColor = System.Drawing.Color.Black;
			this.gvXMLs.RowsDefaultCellStyle = dataGridViewCellStyle26;
			this.gvXMLs.RowTemplate.Height = 30;
			this.gvXMLs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvXMLs.Size = new System.Drawing.Size(833, 176);
			this.gvXMLs.TabIndex = 14;
			this.gvXMLs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(gvXMLs_CellDoubleClick);
			this.rFCDataGridViewTextBoxColumn.DataPropertyName = "RFC";
			this.rFCDataGridViewTextBoxColumn.FillWeight = 150f;
			this.rFCDataGridViewTextBoxColumn.HeaderText = "RFC";
			this.rFCDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.rFCDataGridViewTextBoxColumn.Name = "rFCDataGridViewTextBoxColumn";
			this.rFCDataGridViewTextBoxColumn.ReadOnly = true;
			this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
			this.nombreDataGridViewTextBoxColumn.FillWeight = 250f;
			this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
			this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
			this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
			this.uUIDDataGridViewTextBoxColumn.DataPropertyName = "UUID";
			dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.uUIDDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle27;
			this.uUIDDataGridViewTextBoxColumn.FillWeight = 250f;
			this.uUIDDataGridViewTextBoxColumn.HeaderText = "UUID";
			this.uUIDDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.uUIDDataGridViewTextBoxColumn.Name = "uUIDDataGridViewTextBoxColumn";
			this.uUIDDataGridViewTextBoxColumn.ReadOnly = true;
			this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
			dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.folioDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle28;
			this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
			this.folioDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
			this.folioDataGridViewTextBoxColumn.ReadOnly = true;
			this.subTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal";
			dataGridViewCellStyle29.Format = "c2";
			this.subTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle29;
			this.subTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal";
			this.subTotalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.subTotalDataGridViewTextBoxColumn.Name = "subTotalDataGridViewTextBoxColumn";
			this.subTotalDataGridViewTextBoxColumn.ReadOnly = true;
			this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
			dataGridViewCellStyle30.Format = "c2";
			this.descuentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle30;
			this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
			this.descuentoDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
			this.descuentoDataGridViewTextBoxColumn.ReadOnly = true;
			this.gvColumnImporteDR.DataPropertyName = "Base";
			dataGridViewCellStyle31.Format = "c2";
			this.gvColumnImporteDR.DefaultCellStyle = dataGridViewCellStyle31;
			this.gvColumnImporteDR.HeaderText = "Base";
			this.gvColumnImporteDR.MinimumWidth = 6;
			this.gvColumnImporteDR.Name = "gvColumnImporteDR";
			this.gvColumnImporteDR.ReadOnly = true;
			this.iVADataGridViewTextBoxColumn.DataPropertyName = "IVA";
			dataGridViewCellStyle32.Format = "c2";
			this.iVADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle32;
			this.iVADataGridViewTextBoxColumn.HeaderText = "IVA";
			this.iVADataGridViewTextBoxColumn.MinimumWidth = 6;
			this.iVADataGridViewTextBoxColumn.Name = "iVADataGridViewTextBoxColumn";
			this.iVADataGridViewTextBoxColumn.ReadOnly = true;
			this.IEPS.DataPropertyName = "IEPS";
			dataGridViewCellStyle33.Format = "c2";
			this.IEPS.DefaultCellStyle = dataGridViewCellStyle33;
			this.IEPS.HeaderText = "IEPS";
			this.IEPS.MinimumWidth = 6;
			this.IEPS.Name = "IEPS";
			this.IEPS.ReadOnly = true;
			this.IVARetenciones.DataPropertyName = "IVARetenciones";
			dataGridViewCellStyle34.Format = "c2";
			this.IVARetenciones.DefaultCellStyle = dataGridViewCellStyle34;
			this.IVARetenciones.HeaderText = "IVA Retenciones";
			this.IVARetenciones.MinimumWidth = 6;
			this.IVARetenciones.Name = "IVARetenciones";
			this.IVARetenciones.ReadOnly = true;
			this.ISRRetenciones.DataPropertyName = "ISRRetenciones";
			dataGridViewCellStyle35.Format = "c2";
			this.ISRRetenciones.DefaultCellStyle = dataGridViewCellStyle35;
			this.ISRRetenciones.HeaderText = "ISR Retenciones";
			this.ISRRetenciones.MinimumWidth = 6;
			this.ISRRetenciones.Name = "ISRRetenciones";
			this.ISRRetenciones.ReadOnly = true;
			this.retencionesDataGridViewTextBoxColumn.DataPropertyName = "Retenciones";
			dataGridViewCellStyle36.Format = "c2";
			this.retencionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle36;
			this.retencionesDataGridViewTextBoxColumn.HeaderText = "Retenciones";
			this.retencionesDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.retencionesDataGridViewTextBoxColumn.Name = "retencionesDataGridViewTextBoxColumn";
			this.retencionesDataGridViewTextBoxColumn.ReadOnly = true;
			this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
			dataGridViewCellStyle37.Format = "c2";
			this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle37;
			this.totalDataGridViewTextBoxColumn.FillWeight = 120f;
			this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
			this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
			this.totalDataGridViewTextBoxColumn.ReadOnly = true;
			this.Moneda.DataPropertyName = "Moneda";
			this.Moneda.FillWeight = 80f;
			this.Moneda.HeaderText = "Moneda";
			this.Moneda.MinimumWidth = 6;
			this.Moneda.Name = "Moneda";
			this.Moneda.ReadOnly = true;
			this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
			this.fechaDataGridViewTextBoxColumn.FillWeight = 135f;
			this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
			this.fechaDataGridViewTextBoxColumn.MinimumWidth = 6;
			this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
			this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
			this.gvColumnTipoComprobante.DataPropertyName = "TipoComprobante";
			this.gvColumnTipoComprobante.HeaderText = "Tipo Comprobante";
			this.gvColumnTipoComprobante.MinimumWidth = 6;
			this.gvColumnTipoComprobante.Name = "gvColumnTipoComprobante";
			this.gvColumnTipoComprobante.ReadOnly = true;
			this.MetodoPago.DataPropertyName = "MetodoPago";
			this.MetodoPago.FillWeight = 120f;
			this.MetodoPago.HeaderText = "Metodo Pago";
			this.MetodoPago.MinimumWidth = 6;
			this.MetodoPago.Name = "MetodoPago";
			this.MetodoPago.ReadOnly = true;
			this.FormaPago.DataPropertyName = "FormaPago";
			this.FormaPago.FillWeight = 120f;
			this.FormaPago.HeaderText = "Forma Pago";
			this.FormaPago.MinimumWidth = 6;
			this.FormaPago.Name = "FormaPago";
			this.FormaPago.ReadOnly = true;
			this.UUIDrelacionado.DataPropertyName = "UUIDrelacionado";
			dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 6f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.UUIDrelacionado.DefaultCellStyle = dataGridViewCellStyle38;
			this.UUIDrelacionado.FillWeight = 200f;
			this.UUIDrelacionado.HeaderText = "UUIDrelacionado";
			this.UUIDrelacionado.MinimumWidth = 6;
			this.UUIDrelacionado.Name = "UUIDrelacionado";
			this.UUIDrelacionado.ReadOnly = true;
			this.Descripcion.DataPropertyName = "Descripcion";
			dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.Descripcion.DefaultCellStyle = dataGridViewCellStyle39;
			this.Descripcion.FillWeight = 250f;
			this.Descripcion.HeaderText = "Descripcion";
			this.Descripcion.MinimumWidth = 6;
			this.Descripcion.Name = "Descripcion";
			this.Descripcion.ReadOnly = true;
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.label2);
			this.flpTotalesTodos.Controls.Add(this.txtSubTotal);
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Controls.Add(this.label6);
			this.flpTotalesTodos.Controls.Add(this.txtNumComprobantes);
			this.flpTotalesTodos.Location = new System.Drawing.Point(2, 177);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(478, 24);
			this.flpTotalesTodos.TabIndex = 136;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new System.Drawing.Point(1, 1);
			this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 16);
			this.label2.TabIndex = 0;
			this.label2.Text = "SubTotal:";
			this.label2.Visible = false;
			this.txtSubTotal.Location = new System.Drawing.Point(61, 2);
			this.txtSubTotal.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.txtSubTotal.Name = "txtSubTotal";
			this.txtSubTotal.ReadOnly = true;
			this.txtSubTotal.Size = new System.Drawing.Size(78, 19);
			this.txtSubTotal.TabIndex = 1;
			this.txtSubTotal.Visible = false;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[6] { this.toolStripSeparator1, this.toolStripLabel1, this.tstxtIVA, this.toolStripSeparator2, this.toolStripLabel2, this.tstxtImporte });
			this.toolStrip1.Location = new System.Drawing.Point(129, 1);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(262, 21);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStrip1.Visible = false;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel1.Text = "I.V.A:";
			this.tstxtIVA.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIVA.Name = "tstxtIVA";
			this.tstxtIVA.ReadOnly = true;
			this.tstxtIVA.Size = new System.Drawing.Size(82, 21);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(52, 18);
			this.toolStripLabel2.Text = "Importe:";
			this.tstxtImporte.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporte.Name = "tstxtImporte";
			this.tstxtImporte.ReadOnly = true;
			this.tstxtImporte.Size = new System.Drawing.Size(39, 21);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new System.Drawing.Point(141, 1);
			this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(120, 16);
			this.label6.TabIndex = 3;
			this.label6.Text = "Núm Comprobantes:";
			this.txtNumComprobantes.Location = new System.Drawing.Point(263, 2);
			this.txtNumComprobantes.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.txtNumComprobantes.Name = "txtNumComprobantes";
			this.txtNumComprobantes.ReadOnly = true;
			this.txtNumComprobantes.Size = new System.Drawing.Size(42, 19);
			this.txtNumComprobantes.TabIndex = 4;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new System.Drawing.Point(16, 12);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 135;
			this.label1.Text = "Ruta Archivos:";
			this.btnDescargaSAT.BackColor = System.Drawing.Color.White;
			this.btnDescargaSAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnDescargaSAT.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDescargaSAT.Font = new System.Drawing.Font("Segoe UI", 7f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnDescargaSAT.Image = LeeXML.Properties.Resources.World_download;
			this.btnDescargaSAT.Location = new System.Drawing.Point(2, 108);
			this.btnDescargaSAT.Name = "btnDescargaSAT";
			this.btnDescargaSAT.Size = new System.Drawing.Size(88, 66);
			this.btnDescargaSAT.TabIndex = 137;
			this.btnDescargaSAT.Text = "Descarga SAT";
			this.btnDescargaSAT.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnDescargaSAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnDescargaSAT.UseVisualStyleBackColor = false;
			this.btnDescargaSAT.Click += new System.EventHandler(btnDescargaSAT_Click);
			this.txtRutaCarpeta.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.txtRutaCarpeta.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtRutaCarpeta.Location = new System.Drawing.Point(94, 9);
			this.txtRutaCarpeta.Name = "txtRutaCarpeta";
			this.txtRutaCarpeta.Size = new System.Drawing.Size(574, 21);
			this.txtRutaCarpeta.TabIndex = 128;
			this.rdoRecibidos.AutoSize = true;
			this.rdoRecibidos.Location = new System.Drawing.Point(20, 135);
			this.rdoRecibidos.Name = "rdoRecibidos";
			this.rdoRecibidos.Size = new System.Drawing.Size(67, 17);
			this.rdoRecibidos.TabIndex = 133;
			this.rdoRecibidos.Text = "Recibidos";
			this.rdoRecibidos.UseVisualStyleBackColor = true;
			this.rdoRecibidos.Visible = false;
			this.rdoRecibidos.CheckedChanged += new System.EventHandler(rdoRecibidos_CheckedChanged);
			this.rdoEmitidos.AutoSize = true;
			this.rdoEmitidos.Checked = true;
			this.rdoEmitidos.Location = new System.Drawing.Point(20, 110);
			this.rdoEmitidos.Name = "rdoEmitidos";
			this.rdoEmitidos.Size = new System.Drawing.Size(62, 17);
			this.rdoEmitidos.TabIndex = 132;
			this.rdoEmitidos.TabStop = true;
			this.rdoEmitidos.Text = "Emitidos";
			this.rdoEmitidos.UseVisualStyleBackColor = true;
			this.rdoEmitidos.Visible = false;
			this.rdoEmitidos.CheckedChanged += new System.EventHandler(rdoEmitidos_CheckedChanged);
			this.btnRefrescaCargaArchivo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnRefrescaCargaArchivo.BackColor = System.Drawing.Color.White;
			this.btnRefrescaCargaArchivo.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescaCargaArchivo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnRefrescaCargaArchivo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescaCargaArchivo.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescaCargaArchivo.Location = new System.Drawing.Point(669, 0);
			this.btnRefrescaCargaArchivo.Name = "btnRefrescaCargaArchivo";
			this.btnRefrescaCargaArchivo.Size = new System.Drawing.Size(37, 32);
			this.btnRefrescaCargaArchivo.TabIndex = 131;
			this.btnRefrescaCargaArchivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescaCargaArchivo.UseVisualStyleBackColor = false;
			this.btnRefrescaCargaArchivo.Click += new System.EventHandler(btnRefrescaCargaArchivo_Click);
			this.btnCargaXMLs.BackColor = System.Drawing.Color.White;
			this.btnCargaXMLs.BackgroundImage = LeeXML.Properties.Resources.Folder_Search;
			this.btnCargaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnCargaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnCargaXMLs.Font = new System.Drawing.Font("Segoe UI", 6f, System.Drawing.FontStyle.Bold);
			this.btnCargaXMLs.Location = new System.Drawing.Point(2, 35);
			this.btnCargaXMLs.Name = "btnCargaXMLs";
			this.btnCargaXMLs.Size = new System.Drawing.Size(88, 66);
			this.btnCargaXMLs.TabIndex = 127;
			this.btnCargaXMLs.Text = "Seleccione Carpeta";
			this.btnCargaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnCargaXMLs.UseVisualStyleBackColor = false;
			this.btnCargaXMLs.Click += new System.EventHandler(btnCargaXMLs_Click);
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.btnImportaXMLs);
			this.flowLayoutPanel1.Controls.Add(this.btnExportar);
			this.flowLayoutPanel1.Location = new System.Drawing.Point(927, 28);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(96, 229);
			this.flowLayoutPanel1.TabIndex = 134;
			this.btnImportaXMLs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnImportaXMLs.BackColor = System.Drawing.Color.White;
			this.btnImportaXMLs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnImportaXMLs.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnImportaXMLs.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnImportaXMLs.Image = LeeXML.Properties.Resources.Database_import;
			this.btnImportaXMLs.Location = new System.Drawing.Point(3, 3);
			this.btnImportaXMLs.Name = "btnImportaXMLs";
			this.btnImportaXMLs.Size = new System.Drawing.Size(74, 69);
			this.btnImportaXMLs.TabIndex = 131;
			this.btnImportaXMLs.Text = "Importar";
			this.btnImportaXMLs.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnImportaXMLs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnImportaXMLs.UseVisualStyleBackColor = false;
			this.btnImportaXMLs.Click += new System.EventHandler(btnImportaXMLs_Click);
			this.btnExportar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnExportar.BackColor = System.Drawing.Color.White;
			this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportar.Image = LeeXML.Properties.Resources.excel_logo;
			this.btnExportar.Location = new System.Drawing.Point(3, 78);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(74, 69);
			this.btnExportar.TabIndex = 130;
			this.btnExportar.Text = "Enviar a Excel";
			this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportar.UseVisualStyleBackColor = false;
			this.btnExportar.Click += new System.EventHandler(btnExportar_Click);
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1055, 610);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 128;
			this.label3.Text = "Cantidad:";
			this.txtCantidadVentas.Enabled = false;
			this.txtCantidadVentas.Location = new System.Drawing.Point(1103, 606);
			this.txtCantidadVentas.Name = "txtCantidadVentas";
			this.txtCantidadVentas.Size = new System.Drawing.Size(55, 19);
			this.txtCantidadVentas.TabIndex = 127;
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			this.tmVerificaDescargaMasivaSAT.Interval = 25000;
			this.tmVerificaDescargaMasivaSAT.Tick += new System.EventHandler(tmVerificaDescargaMasivaSAT_Tick);
			this.tmVerificaDescargaMasivaSAT2.Interval = 5000;
			this.tmVerificaDescargaMasivaSAT2.Tick += new System.EventHandler(tmVerificaDescargaMasivaSAT2_Tick);
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(82, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(410, 24);
			this.cmbEmpresas.TabIndex = 138;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.flpEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flpEmpresas.Controls.Add(this.label24);
			this.flpEmpresas.Controls.Add(this.cmbEmpresas);
			this.flpEmpresas.Controls.Add(this.btnBuscaEmpresa);
			this.flpEmpresas.Location = new System.Drawing.Point(280, 11);
			this.flpEmpresas.Name = "flpEmpresas";
			this.flpEmpresas.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpEmpresas.Size = new System.Drawing.Size(555, 33);
			this.flpEmpresas.TabIndex = 140;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(3, 2);
			this.label24.Name = "label24";
			this.label24.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.label24.Size = new System.Drawing.Size(73, 27);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(498, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(35, 25);
			this.btnBuscaEmpresa.TabIndex = 139;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.btnBuscaEmpresa.Click += new System.EventHandler(btnBuscaEmpresa_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1037, 535);
			base.Controls.Add(this.flpEmpresas);
			base.Controls.Add(this.tcPedidosGrids);
			base.Name = "LeeXMLs";
			this.Text = "Importa XMLs";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tcPedidosGrids.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gbDatosGenerales.ResumeLayout(false);
			this.gbDatosGenerales.PerformLayout();
			this.pnlGeneral.ResumeLayout(false);
			this.pnlGeneral.PerformLayout();
			this.gbCFDISnoImporta.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvXMLsRestringidos).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.pnlCFDISimporta.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.gvXMLs).EndInit();
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flpEmpresas.ResumeLayout(false);
			this.flpEmpresas.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
