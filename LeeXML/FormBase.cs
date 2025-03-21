using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Pantallas;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeeXML
{
	public class FormBase : Form
	{
		public enum EstatusFactura
		{
			ELIMINADO = 0,
			VIGENTE = 1,
			CANCELADA = 2,
			EGRESOPPD = 5
		}

		public enum MetodosPago
		{
			PUE = 1,
			PPD
		}

		public enum TipoComprobante
		{
			FACTURA = 1,
			NOTACREDITO = 2,
			NOMINA = 4,
			COMPLEMENTOPAGO = 5,
			ANTICIPI = 6
		}

		public enum TipoRelacion
		{
			SINRELACION,
			RELACIONADO,
			NORELACIONARA,
			DEPOSITARAPOSTERIOR,
			DEPOSITADOMESANTERIOR,
			OTRAFORMAPAGO
		}

		public enum TipoDepositoRelacion
		{
			FACTURA = 1,
			PRESTAMO = 2,
			DEVOLUCIONIMPUESTOS = 3,
			TRASPASOS = 4,
			CHEQUEDEVUELTO = 5,
			INTERESES = 6,
			ANTICIPOCLIENTES = 7,
			OTRO = 10,
			PAGODEIMPUESTOS = 11,
			PAGOSINCFDI = 12,
			PAGONOMINASSINCFDI = 13,
			REEMBOLSOGASTOPAGADOPORTERCERO = 14,
			ANTICIPOAPROVEEDORES = 15,
			NOMINA = 16,
			NOTACREDITO03 = 17
		}

		public enum TIPOTERCERO
		{
			PROVEEDORNACIONAL = 4,
			PROVEEDOREXTRANJERO = 5,
			PROVEEDORGLOBAL = 15
		}

		public enum TIPODEOPERACIÓN
		{
			ENAJENACIONDEBIENES = 2,
			PRESTACIONDESERVPROF = 3,
			USOOGOCETEMPORALDEBIENES = 6,
			IMPORTACIONPORTRANSFVIRTUAL = 8,
			OTROS = 85,
			IMPORTACIONDEBIENESOSERV = 7,
			OPERACIONESGLOBALES = 87
		}

		private bool Demo = false;

		private string PantallaSize = "1700, 802";

		public string PathFacturas = "C:\\TIIM\\Facturacion\\Facturas";

		public string PathFacturasPruebas = "C:\\TIIM\\Facturacion\\FacturasPruebas";

		public string PathPreFacturas = "C:\\TIIM\\Facturacion\\PreFacturas";

		public string PathFacturasComplementos = "C:\\TIIM\\Facturacion\\Facturas";

		public decimal IEPS = 0.08m;

		public decimal IVA = 0.16m;

		public decimal ISR = 0.10m;

		public int AlturaMaximaGrid = 200;

		public string RfcExtranjero = "XEXX010101000";

		public string Titulo => Text;

		public EntUsuario UsuarioLogin { get; set; }

		public EntEmpresa EmpresaSeleccionada => Program.EmpresaSeleccionada;

		public List<EntEmpresa> ListaEmpresas { get; set; }

		public void CargaAñosCmb(ComboBox cmbAños)
		{
			List<EntCatalogoGenerico> años = new List<EntCatalogoGenerico>();
			for (int x = DateTime.Today.Year + 1; x >= Program.AñoInicio; x--)
			{
				EntCatalogoGenerico año = new EntCatalogoGenerico();
				año.Descripcion = x.ToString();
				años.Add(año);
			}
			cmbAños.DataSource = años;
		}

		public void CargaPeriodosCmb(ComboBox cmbPeriodos, int TipoPeriodo)
		{
			List<EntCatalogoGenerico> periodos = new List<EntCatalogoGenerico>();
			if (!Demo)
			{
				for (int x = DateTime.Today.Year; x >= Program.AñoInicio; x--)
				{
					switch (TipoPeriodo)
					{
					case 1:
					{
						for (int p2 = 12; p2 >= 1; p2--)
						{
							EntCatalogoGenerico periodo2 = new EntCatalogoGenerico();
							periodo2.Descripcion = x + "-" + p2.ToString().PadLeft(2, '0') + " " + new DateTime(Program.AñoInicio, p2, 1).ToString("MMMM").ToUpper();
							periodo2.Id = x;
							periodo2.Clave = p2.ToString().PadLeft(2, '0');
							periodos.Add(periodo2);
						}
						break;
					}
					case 2:
					{
						for (int p3 = 6; p3 >= 1; p3--)
						{
							int mesFinal = p3 * 2;
							EntCatalogoGenerico periodo3 = new EntCatalogoGenerico();
							periodo3.Descripcion = x + "-" + p3.ToString().PadLeft(2, '0') + " " + new DateTime(Program.AñoInicio, mesFinal - 1, 1).ToString("MMM").ToUpper() + "-" + new DateTime(Program.AñoInicio, mesFinal, 1).ToString("MMM").ToUpper();
							periodo3.Id = x;
							periodo3.Clave = p3.ToString().PadLeft(2, '0');
							periodos.Add(periodo3);
						}
						break;
					}
					case 3:
					{
						for (int p = 4; p >= 1; p--)
						{
							EntCatalogoGenerico periodo = new EntCatalogoGenerico();
							periodo.Descripcion = x + p.ToString().PadLeft(2, '0');
							periodo.Id = x;
							periodo.Clave = p.ToString().PadLeft(2, '0');
							periodos.Add(periodo);
						}
						break;
					}
					}
				}
			}
			else
			{
				for (int i = Program.AñoInicio; i <= Program.AñoInicio + 1; i++)
				{
					switch (TipoPeriodo)
					{
					case 1:
						if (i == Program.AñoInicio)
						{
							for (int l = 11; l <= 12; l++)
							{
								EntCatalogoGenerico periodo6 = new EntCatalogoGenerico();
								periodo6.Descripcion = i + l.ToString().PadLeft(2, '0');
								periodo6.Id = i;
								periodo6.Clave = l.ToString().PadLeft(2, '0');
								periodos.Add(periodo6);
							}
						}
						else
						{
							for (int m = 1; m <= 8; m++)
							{
								EntCatalogoGenerico periodo7 = new EntCatalogoGenerico();
								periodo7.Descripcion = i + m.ToString().PadLeft(2, '0');
								periodo7.Id = i;
								periodo7.Clave = m.ToString().PadLeft(2, '0');
								periodos.Add(periodo7);
							}
						}
						break;
					case 2:
						if (i == Program.AñoInicio)
						{
							for (int n = 6; n <= 6; n++)
							{
								EntCatalogoGenerico periodo8 = new EntCatalogoGenerico();
								periodo8.Descripcion = i + n.ToString().PadLeft(2, '0');
								periodo8.Id = i;
								periodo8.Clave = n.ToString().PadLeft(2, '0');
								periodos.Add(periodo8);
							}
						}
						else
						{
							for (int num = 1; num <= 4; num++)
							{
								EntCatalogoGenerico periodo9 = new EntCatalogoGenerico();
								periodo9.Descripcion = i + num.ToString().PadLeft(2, '0');
								periodo9.Id = i;
								periodo9.Clave = num.ToString().PadLeft(2, '0');
								periodos.Add(periodo9);
							}
						}
						break;
					case 3:
						if (i == Program.AñoInicio)
						{
							for (int j = 4; j <= 4; j++)
							{
								EntCatalogoGenerico periodo4 = new EntCatalogoGenerico();
								periodo4.Descripcion = i + j.ToString().PadLeft(2, '0');
								periodo4.Id = i;
								periodo4.Clave = j.ToString().PadLeft(2, '0');
								periodos.Add(periodo4);
							}
						}
						else
						{
							for (int k = 1; k <= 3; k++)
							{
								EntCatalogoGenerico periodo5 = new EntCatalogoGenerico();
								periodo5.Descripcion = i + k.ToString().PadLeft(2, '0');
								periodo5.Id = i;
								periodo5.Clave = k.ToString().PadLeft(2, '0');
								periodos.Add(periodo5);
							}
						}
						break;
					}
				}
			}
			cmbPeriodos.DataSource = periodos;
		}

		public void SeleccionaPeriodoActual(ComboBox cmbPeriodos, int TipoPeriodo, Label MuestraTipoPeriodo)
		{
			decimal periodo = 1m;
			if (!Demo)
			{
				switch (TipoPeriodo)
				{
				case 1:
					MuestraTipoPeriodo.Text = "MENSUAL";
					periodo = DateTime.Today.Month;
					break;
				case 2:
					MuestraTipoPeriodo.Text = "BIMESTRAL";
					periodo = DateTime.Today.Month;
					periodo = Math.Round(periodo / 2m, MidpointRounding.AwayFromZero);
					break;
				case 3:
				{
					MuestraTipoPeriodo.Text = "TRIMESTRAL";
					int mes = DateTime.Today.Month;
					periodo = ((mes > 1 && mes <= 3) ? 1m : ((mes > 6) ? ((mes > 9) ? 4m : 3m) : 2m));
					break;
				}
				}
				cmbPeriodos.SelectedIndex = cmbPeriodos.FindString(DateTime.Today.Year + "-" + periodo.ToString().PadLeft(2, '0'));
			}
			else
			{
				switch (TipoPeriodo)
				{
				case 1:
					periodo = 11m;
					break;
				case 2:
					MuestraTipoPeriodo.Text = "BIMESTRAL";
					periodo = 6m;
					break;
				case 3:
					MuestraTipoPeriodo.Text = "TRIMESTRAL";
					periodo = 4m;
					break;
				}
				cmbPeriodos.SelectedIndex = cmbPeriodos.FindStringExact(Program.AñoInicio + periodo.ToString().PadLeft(2, '0'));
			}
		}

		public void SeleccionaPeriodoActual(ComboBox cmbPeriodos, int TipoPeriodo, int Mes, int Año)
		{
			decimal periodo = 1m;
			if (!Demo)
			{
				switch (TipoPeriodo)
				{
				case 1:
					periodo = Mes;
					break;
				case 2:
					periodo = Mes;
					periodo = Math.Round(periodo / 2m, MidpointRounding.AwayFromZero);
					break;
				case 3:
					periodo = ((Mes > 1 && Mes <= 3) ? 1m : ((Mes > 6) ? ((Mes > 9) ? 4m : 3m) : 2m));
					break;
				}
				cmbPeriodos.SelectedIndex = cmbPeriodos.FindString(Año + "-" + periodo.ToString().PadLeft(2, '0'));
			}
		}

		public Form BuscaFormaBase(string Titulo)
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

		public void CierraFormasBase()
		{
			Form[] mdiChildren = base.ParentForm.MdiChildren;
			foreach (Form v in mdiChildren)
			{
				v.Close();
			}
		}

		public void SetWaitCursor()
		{
			Cursor = Cursors.WaitCursor;
		}

		public void SetDefaultCursor()
		{
			Cursor = Cursors.Default;
		}

		public void VerificaVigenciaLicencia(EntEmpresa EmpresaVerifica)
		{
			string PaginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
			if (new BusUsuarios().VerificaVigenciaLicencia(EmpresaVerifica.LicenciaId))
			{
				CierraFormasBase();
				Program.EmpresaSeleccionada = null;
				if (MessageBox.Show("SU LICENCIA HA CADUCADO\n¿DESEA REENOVARLA?", "LICENCIA CADUCADA", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
				{
					Process.Start(PaginaDescarga);
				}
			}
		}

		public void CargaLicenciasDescargaMasiva(int CompañiaId, ref List<EntUsuario> ListaLicenciasDescargaMasiva)
		{
			ListaLicenciasDescargaMasiva = new BusUsuarios().ObtieneLicenciasDescargaMasivaActivas(CompañiaId);
		}

		public EntEmpresa SeleccionaEmpresa()
		{
			SeleccionEmpresa vSeleccionaEmp = new SeleccionEmpresa();
			if (vSeleccionaEmp.ShowDialog() == DialogResult.OK)
			{
				return vSeleccionaEmp.EmpresaSeleccionada;
			}
			return new EntEmpresa();
		}

		public void CargaEmpresas(ComboBox cmbEmpresas, int CompañiaId)
		{
			ListaEmpresas = new BusEmpresas().ObtieneEmpresasActivas(CompañiaId);
			Program.CambiaEmpresa = false;
			cmbEmpresas.DataSource = ListaEmpresas;
			Program.CambiaEmpresa = true;
		}

		public void CargaDatosEmpresa(TextBox TxtEmpresa, TextBox TxtRFC)
		{
			TxtEmpresa.Text = EmpresaSeleccionada.NombreFiscal;
			TxtRFC.Text = EmpresaSeleccionada.RFC;
			if (EmpresaSeleccionada.Id == 0)
			{
				MuestraMensajePaginaCompra vMensaje = new MuestraMensajePaginaCompra();
				vMensaje.Text = "SIN LICENCIAS ACTIVAS";
				vMensaje.Mensaje = "LICENCIA(S) VENCIDA(S)";
				vMensaje.ShowDialog();
			}
		}

		public void CargaDatosEmpresa(TextBox TxtEmpresa, TextBox TxtRFC, TextBox TxtRutaCarpeta)
		{
			Text = " - " + EmpresaSeleccionada.DiasExpiracion + " DÍAS PARA EXPIRACIÓN DE LICENCIA";
			TxtEmpresa.Text = EmpresaSeleccionada.NombreFiscal;
			TxtRFC.Text = EmpresaSeleccionada.RFC;
			TxtRutaCarpeta.Text = EmpresaSeleccionada.Key;
			if (EmpresaSeleccionada.Id == 0)
			{
				MuestraMensajePaginaCompra vMensaje = new MuestraMensajePaginaCompra();
				vMensaje.Text = "SIN LICENCIAS ACTIVAS";
				vMensaje.Mensaje = "LICENCIA(S) VENCIDA(S)";
				vMensaje.ShowDialog();
			}
		}

		public void CargaDatosEmpresaRecibidos(TextBox TxtEmpresa, TextBox TxtRFC, TextBox TxtRutaCarpeta)
		{
			Text = "VERSIÓN " + Program.Version + " - " + EmpresaSeleccionada.DiasExpiracion + " DÍAS PARA EXPIRACIÓN DE LICENCIA";
			TxtEmpresa.Text = EmpresaSeleccionada.NombreFiscal;
			TxtRFC.Text = EmpresaSeleccionada.RFC;
			TxtRutaCarpeta.Text = EmpresaSeleccionada.KeyRecibidos;
			if (EmpresaSeleccionada.Id == 0)
			{
				MuestraMensajePaginaCompra vMensaje = new MuestraMensajePaginaCompra();
				vMensaje.Text = "SIN LICENCIAS ACTIVAS";
				vMensaje.Mensaje = "LICENCIA(S) VENCIDA(S)";
				vMensaje.ShowDialog();
			}
		}

		public DateTime ObtieneFechaInicial()
		{
			return new DateTime(Program.AñoInicio, 1, 1);
		}

		public DateTime ObtieneFechaUltimoDiaMes(int Mes, int Año)
		{
			return new DateTime(Año, Mes, DateTime.DaysInMonth(Año, Mes));
		}

		public DateTime ObtieneFechaUltimoDiaMes(DateTime Fecha)
		{
			return new DateTime(Fecha.Year, Fecha.Month, DateTime.DaysInMonth(Fecha.Year, Fecha.Month));
		}

		public DateTime ObtieneFechaPrimerDiaMes(int Mes, int Año)
		{
			return new DateTime(Año, Mes, 1);
		}

		public DateTime FechaDesde(bool PorMes, string Año, int Mes, DateTime Fecha)
		{
			if (PorMes)
			{
				return new DateTime(ConvierteTextoAInteger(Año), Mes, 1);
			}
			return Fecha.Date;
		}

		public DateTime FechaHasta(bool PorMes, string Año, int Mes, DateTime Fecha)
		{
			if (PorMes)
			{
				return new DateTime(ConvierteTextoAInteger(Año), Mes, DateTime.DaysInMonth(ConvierteTextoAInteger(Año), Mes));
			}
			return Fecha.Date;
		}

		public DateTime FechaDesde(int Mes, int Año)
		{
			return new DateTime(Año, Mes, 1);
		}

		public DateTime FechaHasta(int Mes, int Año)
		{
			return new DateTime(Año, Mes, DateTime.DaysInMonth(Año, Mes));
		}

		public DateTime FechaDesdeFromComboBoxs(ComboBox ComboBoxMes, ComboBox ComboBoxAño)
		{
			return new DateTime(ConvierteTextoAInteger(ComboBoxAño.Text), ComboBoxMes.SelectedIndex + 1, 1);
		}

		public DateTime FechaHastaFromComboBoxs(ComboBox ComboBoxMes, ComboBox ComboBoxAño)
		{
			return new DateTime(ConvierteTextoAInteger(ComboBoxAño.Text), ComboBoxMes.SelectedIndex + 1, DateTime.DaysInMonth(ConvierteTextoAInteger(ComboBoxAño.Text), ComboBoxMes.SelectedIndex + 1));
		}

		public void AsignaFechaDesdeFechaHastaFromCmbPeriodos(ComboBox cmbPeriodos, int TipoPeriodo, ref DateTime FechaDesde, ref DateTime FechaHasta)
		{
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbPeriodos);
			switch (TipoPeriodo)
			{
			case 1:
				FechaDesde = ObtieneFechaPrimerDiaMes(ConvierteTextoAInteger(periodo.Clave), periodo.Id);
				FechaHasta = ObtieneFechaUltimoDiaMes(ConvierteTextoAInteger(periodo.Clave), periodo.Id);
				break;
			case 2:
			{
				int mesFinal = ConvierteTextoAInteger(periodo.Clave) * 2;
				FechaDesde = ObtieneFechaPrimerDiaMes(mesFinal - 1, periodo.Id);
				FechaHasta = ObtieneFechaUltimoDiaMes(mesFinal, periodo.Id);
				break;
			}
			case 3:
			{
				int variable = ConvierteTextoAInteger(periodo.Clave);
				int mesInicial = ConvierteTextoAInteger(periodo.Clave) * 2 + (variable - 2);
				FechaDesde = ObtieneFechaPrimerDiaMes(mesInicial, periodo.Id);
				FechaHasta = ObtieneFechaUltimoDiaMes(mesInicial + 2, periodo.Id);
				break;
			}
			}
		}

		public void CalculaSumaTotalFromListaProductos(List<EntFactura> ListaComprobantes, bool SoloIngresos, TextBox TxtMuestraTotal, TextBox TxtMuestraSubTotal, TextBox TxtMuestraIva, TextBox TxtMuestraRetenciones, TextBox TxtMuestraCount)
		{
			decimal total;
			decimal subtotal;
			decimal cantidadIva;
			decimal retenciones;
			if (SoloIngresos)
			{
				total = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.Retenciones);
			}
			else
			{
				total = ListaComprobantes.Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Sum((EntFactura P) => P.Retenciones);
			}
			TxtMuestraTotal.Text = FormatoMoney(total);
			TxtMuestraSubTotal.Text = FormatoMoney(subtotal);
			TxtMuestraIva.Text = FormatoMoney(cantidadIva);
			TxtMuestraRetenciones.Text = FormatoMoney(retenciones);
			TxtMuestraCount.Text = ListaComprobantes.Count.ToString();
		}

		public void CalculaSumaTotalFromListaProductosIVAretenido(List<EntFactura> ListaComprobantes, bool SoloIngresos, TextBox TxtMuestraTotal, TextBox TxtMuestraSubTotal, TextBox TxtMuestraIva, TextBox TxtMuestraRetenciones, TextBox TxtMuestraCount)
		{
			decimal total;
			decimal subtotal;
			decimal cantidadIva;
			decimal retenciones;
			if (SoloIngresos)
			{
				total = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.IVARetenciones);
			}
			else
			{
				total = ListaComprobantes.Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Sum((EntFactura P) => P.IVARetenciones);
			}
			TxtMuestraTotal.Text = FormatoMoney(total);
			TxtMuestraSubTotal.Text = FormatoMoney(subtotal);
			TxtMuestraIva.Text = FormatoMoney(cantidadIva);
			TxtMuestraRetenciones.Text = FormatoMoney(retenciones);
			TxtMuestraCount.Text = ListaComprobantes.Count.ToString();
		}

		public List<decimal> CalculaSumaTotalFromListaProductosIVAretenidoPG(List<EntFactura> ListaComprobantes, bool SoloIngresos)
		{
			List<decimal> lst = new List<decimal>();
			decimal total;
			decimal subtotal;
			decimal cantidadIva;
			decimal retenciones;
			if (SoloIngresos)
			{
				total = ListaComprobantes.Where((EntFactura P) => (P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000") && P.TipoComprobanteId == 1).Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Where((EntFactura P) => (P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000") && P.TipoComprobanteId == 1).Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Where((EntFactura P) => (P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000") && P.TipoComprobanteId == 1).Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Where((EntFactura P) => (P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000") && P.TipoComprobanteId == 1).Sum((EntFactura P) => P.IVARetenciones);
			}
			else
			{
				total = ListaComprobantes.Where((EntFactura P) => P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000").Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Where((EntFactura P) => P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000").Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Where((EntFactura P) => P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000").Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Where((EntFactura P) => P.RFC == "XAXX010101000" || P.RFC == "XEXX010101000").Sum((EntFactura P) => P.IVARetenciones);
			}
			lst.Add(total);
			lst.Add(subtotal);
			lst.Add(cantidadIva);
			lst.Add(retenciones);
			lst.Add(ListaComprobantes.Count);
			return lst;
		}

		public void CalculaSumaTotalFromListaProductosISRretenido(List<EntFactura> ListaComprobantes, bool SoloIngresos, TextBox TxtMuestraTotal, TextBox TxtMuestraSubTotal, TextBox TxtMuestraIva, TextBox TxtMuestraRetenciones, TextBox TxtMuestraCount)
		{
			decimal total;
			decimal subtotal;
			decimal cantidadIva;
			decimal retenciones;
			if (SoloIngresos)
			{
				total = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1).Sum((EntFactura P) => P.ISRRetenciones);
			}
			else
			{
				total = ListaComprobantes.Sum((EntFactura P) => P.Total);
				subtotal = ListaComprobantes.Sum((EntFactura P) => P.SubTotal);
				cantidadIva = ListaComprobantes.Sum((EntFactura P) => P.IVA);
				retenciones = ListaComprobantes.Sum((EntFactura P) => P.ISRRetenciones);
			}
			TxtMuestraTotal.Text = FormatoMoney(total);
			TxtMuestraSubTotal.Text = FormatoMoney(subtotal);
			TxtMuestraIva.Text = FormatoMoney(cantidadIva);
			TxtMuestraRetenciones.Text = FormatoMoney(retenciones);
			TxtMuestraCount.Text = ListaComprobantes.Count.ToString();
		}

		public void ConvierteComprobantesIngresoToMXN(List<EntFactura> FacturasIngreso, bool CalculaEquivalencia = false)
		{
			foreach (EntFactura f in FacturasIngreso.Where((EntFactura P) => P.TipoCambio > 1m).ToList())
			{
				f.TotalUSD = f.Total;
				f.Retenciones *= f.TipoCambio;
				f.IVARetenciones *= f.TipoCambio;
				f.ISRRetenciones *= f.TipoCambio;
				f.IVA *= f.TipoCambio;
				f.IEPS *= f.TipoCambio;
				f.ImpuestosLocales *= f.TipoCambio;
				f.Descuento *= f.TipoCambio;
				f.SubTotal *= f.TipoCambio;
				f.Total *= f.TipoCambio;
				f.ImporteDR *= f.TipoCambio;
				f.ObjetoImpuesto01 *= f.TipoCambio;
				f.ObjetoImpuesto02 *= f.TipoCambio;
				f.ObjetoImpuesto03 *= f.TipoCambio;
				f.ObjetoImpuesto04 *= f.TipoCambio;
			}
			if (!CalculaEquivalencia)
			{
				return;
			}
			foreach (EntFactura f2 in FacturasIngreso.Where((EntFactura P) => P.EquivalenciaDR != 1m && P.EquivalenciaDR > 0m).ToList())
			{
				f2.Descuento /= f2.EquivalenciaDR;
				f2.Retenciones /= f2.EquivalenciaDR;
				f2.IVARetenciones /= f2.EquivalenciaDR;
				f2.ISRRetenciones /= f2.EquivalenciaDR;
				f2.IVA /= f2.EquivalenciaDR;
				f2.IEPS /= f2.EquivalenciaDR;
				f2.ImpuestosLocales /= f2.EquivalenciaDR;
				f2.ImporteDR /= f2.EquivalenciaDR;
			}
		}

		public string FormatoMoney(decimal Valor)
		{
			return $"{Valor:c}";
		}

		public string FormatoMoney(string ValorTexto)
		{
			return $"{ConvierteTextoADecimal(ValorTexto):c}";
		}

		public string FormatoMoneySinNegativo(decimal Valor)
		{
			if (Valor < 0m)
			{
				return $"{0:c}";
			}
			return $"{Valor:c}";
		}

		public string FormatoMoneyDecimales4(decimal Valor)
		{
			return $"{Valor:c4}";
		}

		public string FormatoMoneyDecimales4(string ValorTexto)
		{
			return $"{ConvierteTextoADecimal(ValorTexto):c4}";
		}

		public decimal ConvierteTextoADecimal(string Valor)
		{
			decimal resul = default(decimal);
			decimal.TryParse(Valor.Replace("$", ""), out resul);
			return resul;
		}

		public decimal ConvierteTextoADecimal(TextBox txtValor)
		{
			decimal resul = default(decimal);
			decimal.TryParse(txtValor.Text.Replace("$", ""), out resul);
			return resul;
		}

		public int ConvierteTextoAInteger(string Valor)
		{
			int resul = 0;
			int.TryParse(Valor, out resul);
			return resul;
		}

		public void TextBoxDecimal_TextChanged(object sender, EventArgs e)
		{
			decimal resul = default(decimal);
			if (((TextBox)sender).Text.Trim() != "")
			{
				decimal.TryParse(((TextBox)sender).Text.Replace("$", ""), out resul);
				((TextBox)sender).Text = resul.ToString();
			}
		}

		public void TextBoxDecimal_Leave(object sender, EventArgs e)
		{
			decimal resul = default(decimal);
			decimal.TryParse(((TextBox)sender).Text.Replace("$", ""), out resul);
			((TextBox)sender).Text = resul.ToString();
		}

		public void TextBoxDecimalMoney_Leave(object sender, EventArgs e)
		{
			decimal resul = default(decimal);
			decimal.TryParse(((TextBox)sender).Text.Replace("$", ""), out resul);
			((TextBox)sender).Text = FormatoMoney(resul);
		}

		public void TextBoxDecimalMoneyDecimales_Leave(object sender, EventArgs e)
		{
			decimal resul = default(decimal);
			decimal.TryParse(((TextBox)sender).Text.Replace("$", ""), out resul);
			((TextBox)sender).Text = FormatoMoneyDecimales4(resul);
		}

		public void TextBoxPorcentaje_Leave(object sender, EventArgs e)
		{
			decimal resul = default(decimal);
			decimal.TryParse(((TextBox)sender).Text.Replace("%", ""), out resul);
			((TextBox)sender).Text = resul + "%";
		}

		public void LimpiaTextBox(Control Contenedor)
		{
			foreach (Control c in Contenedor.Controls)
			{
				if (c.GetType() == typeof(TextBox))
				{
					((TextBox)c).Text = "";
				}
				if (c.HasChildren)
				{
					LimpiaTextBox(c);
				}
			}
		}

		public void LimpiaTextBox(Control Contenedor, bool InicializaComboBox)
		{
			foreach (Control c in Contenedor.Controls)
			{
				if (c.GetType() == typeof(TextBox))
				{
					((TextBox)c).Text = "";
				}
				else if (c.GetType() == typeof(ComboBox) && InicializaComboBox)
				{
					((ComboBox)c).SelectedIndex = 0;
				}
				if (c.HasChildren)
				{
					LimpiaTextBox(c, InicializaComboBox);
				}
			}
		}

		public void ChecaChecBox(Control Contenedor, bool Checked)
		{
			foreach (Control c in Contenedor.Controls)
			{
				if (c.GetType() == typeof(CheckBox))
				{
					((CheckBox)c).Checked = Checked;
				}
				if (c.HasChildren)
				{
					ChecaChecBox(c, Checked);
				}
			}
		}

		public void EnableTextBox(Control Contenedor, bool Checked)
		{
			foreach (Control c in Contenedor.Controls)
			{
				if (c.GetType() == typeof(TextBox))
				{
					((TextBox)c).Enabled = Checked;
				}
				if (c.HasChildren)
				{
					EnableTextBox(c, Checked);
				}
			}
		}

		public string CreaDirectorio(string PathBase)
		{
			if (!Directory.Exists(PathBase))
			{
				Directory.CreateDirectory(PathBase);
			}
			return PathBase;
		}

		public void EliminaArchivo(string PathArchivo)
		{
			if (File.Exists(PathArchivo))
			{
				FileInfo file = new FileInfo(PathArchivo);
				file.Delete();
			}
		}

		public string EncuentraArchivo(string Ruta, string Extension)
		{
			DirectoryInfo di = new DirectoryInfo(Ruta);
			FileInfo[] fi = (from P in di.GetFiles()
				where P.Extension == Extension
				orderby P.CreationTime descending
				select P).ToArray();
			FileInfo[] array = fi;
			foreach (FileInfo f in array)
			{
				if (f.Extension == Extension)
				{
					return f.Name;
				}
			}
			return "";
		}

		public void MuestraArchivo(string Path)
		{
			if (Directory.Exists(Path))
			{
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.InitialDirectory = Path;
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					Process proc = new Process();
					proc.StartInfo.FileName = ofd.FileName;
					proc.Start();
					proc.Close();
				}
			}
			else
			{
				MuestraMensaje("No se encontraron archivos en la ruta seleccionada", "");
			}
		}

		public void MuestraArchivo(string Path, string FileName)
		{
			if (File.Exists(Path + "\\" + FileName))
			{
				Process proc = new Process();
				proc.StartInfo.FileName = Path + "\\" + FileName;
				proc.Start();
				proc.Close();
			}
			else
			{
				MuestraMensaje("No se encontraron archivos en la ruta seleccionada", "");
			}
		}

		public void MuestraArchivo(string FileName, bool IsFile)
		{
			if (File.Exists(FileName))
			{
				Process proc = new Process();
				proc.StartInfo.FileName = FileName;
				proc.Start();
				proc.Close();
			}
			else
			{
				MuestraMensaje("No se encontró archivo", "");
			}
		}

		public void DescomprimirArchivo(string RutaArchivoZip, string RutaDestino)
		{
			DirectoryInfo di = new DirectoryInfo(RutaDestino);
			FileInfo[] fi = (from P in di.GetFiles()
				where P.Extension == ".xml"
				orderby P.CreationTime descending
				select P).ToArray();
			if (fi.Count() == 0)
			{
				ZipFile.ExtractToDirectory(RutaArchivoZip, RutaDestino);
				return;
			}
			ZipArchive archivoZip = ZipFile.OpenRead(RutaArchivoZip);
			try
			{
				foreach (ZipArchiveEntry entrada in archivoZip.Entries)
				{
					string rutaCompleta = Path.Combine(RutaDestino, entrada.FullName);
					if (File.Exists(rutaCompleta))
					{
						File.Delete(rutaCompleta);
					}
					entrada.ExtractToFile(rutaCompleta);
				}
			}
			finally
			{
				((IDisposable)archivoZip)?.Dispose();
			}
		}

		public void MuestraMensaje(string Mensaje)
		{
			MessageBox.Show(Mensaje, "CONFIRMACIÓN", MessageBoxButtons.OK);
		}

		public void MuestraMensaje(string Mensaje, string Titulo)
		{
			MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK);
		}

		public DialogResult MuestraMensajeOK(string Mensaje)
		{
			return MessageBox.Show(Mensaje, "CONFIRMACIÓN", MessageBoxButtons.OK);
		}

		public DialogResult MuestraMensajeYesNo(string Mensaje)
		{
			return MessageBox.Show(Mensaje, "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public DialogResult MuestraMensajeYesNo(string Mensaje, string Titulo)
		{
			return MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public void MuestraMensajeError(string Mensaje, string Titulo)
		{
			MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public void MuestraMensajeAdvertencia(string Mensaje, string Titulo)
		{
			MessageBox.Show(Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public void MandaExcepcion(string MensajeExcepcion)
		{
			throw new Exception(MensajeExcepcion);
		}

		public void MandaExcepcion(string MensajeExcepcion, TextBox TxtCajaFocus)
		{
			TxtCajaFocus.Focus();
			throw new Exception(MensajeExcepcion);
		}

		public void MuestraExcepcion(Exception ex)
		{
			MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public void MuestraExcepcion(Exception ex, string MensajeAgregado)
		{
			MessageBox.Show(ex.Message + " (" + MensajeAgregado + ")", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public void MuestraDatosFactura(object GvFactura)
		{
			EntFactura fac = ObtieneFacturaFromGV((DataGridView)GvFactura);
			string facJson = JsonConvert.SerializeObject(fac);
			JObject jsonObject = JsonConvert.DeserializeObject<JObject>(facJson);
			MuestraMensaje(jsonObject.ToString());
		}

		public List<EntCatalogoGenerico> ObtieneListaCatalogoGenericoFromGV(DataGridView GridViewCatalogoGenerico)
		{
			return (List<EntCatalogoGenerico>)GridViewCatalogoGenerico.DataSource;
		}

		public List<EntFactura> ObtieneListaFacturasFromGV(DataGridView GridViewFacturas)
		{
			return (List<EntFactura>)GridViewFacturas.DataSource;
		}

		public List<EntFactura> ObtieneListaFacturasFromGVseleccionados(DataGridView GridViewFacturas)
		{
			List<EntFactura> lst = (List<EntFactura>)GridViewFacturas.DataSource;
			List<EntFactura> lstSeleccionados = new List<EntFactura>();
			foreach (DataGridViewRow r in GridViewFacturas.SelectedRows)
			{
				lstSeleccionados.Add(lst[r.Index]);
			}
			return lstSeleccionados;
		}

		public EntFactura ObtieneFacturaFromGV(DataGridView GridViewFacturas)
		{
			if (GridViewFacturas.CurrentRow == null)
			{
				return null;
			}
			return ((List<EntFactura>)GridViewFacturas.DataSource)[GridViewFacturas.CurrentRow.Index];
		}

		public EntFactura ObtieneFacturaFromGV(DataGridView GridViewFacturas, int RowIndex)
		{
			if (GridViewFacturas.Rows[RowIndex] == null)
			{
				return null;
			}
			return ((List<EntFactura>)GridViewFacturas.DataSource)[RowIndex];
		}

		public List<EntEstadoDeCuenta> ObtieneListaEstadoDeCuentaFromGV(DataGridView GridViewEstadosDeCuenta)
		{
			return (List<EntEstadoDeCuenta>)GridViewEstadosDeCuenta.DataSource;
		}

		public EntEstadoDeCuenta ObtieneEstadoDeCuentaFromGV(DataGridView GridViewFacturas)
		{
			if (GridViewFacturas.CurrentRow == null)
			{
				return null;
			}
			return ((List<EntEstadoDeCuenta>)GridViewFacturas.DataSource)[GridViewFacturas.CurrentRow.Index];
		}

		public EntEmpresa ObtieneEmpresaFromGV(DataGridView GridViewEmpresas)
		{
			if (GridViewEmpresas.CurrentRow == null)
			{
				return null;
			}
			return ((List<EntEmpresa>)GridViewEmpresas.DataSource)[GridViewEmpresas.CurrentRow.Index];
		}

		public EntEmpresa ObtieneEmpresaFromCmb(ComboBox ComboBoxEmpresas)
		{
			return ((List<EntEmpresa>)ComboBoxEmpresas.DataSource)[ComboBoxEmpresas.SelectedIndex];
		}

		public EntUsuario ObtieneUsuarioFromCmb(ComboBox ComboBoxUsuarios)
		{
			return ((List<EntUsuario>)ComboBoxUsuarios.DataSource)[ComboBoxUsuarios.SelectedIndex];
		}

		public EntCatalogoGenerico ObtieneCatalogoGenericoFromCmb(ComboBox ComboBoxEmpresas)
		{
			return ((List<EntCatalogoGenerico>)ComboBoxEmpresas.DataSource)[ComboBoxEmpresas.SelectedIndex];
		}

		public EntCatalogoGenerico ObtieneCatalogoGenericoFromGv(DataGridView GridViewEmpresas)
		{
			return ((List<EntCatalogoGenerico>)GridViewEmpresas.DataSource)[GridViewEmpresas.CurrentRow.Index];
		}

		public FileInfo SeleccionaArchivo(string Path)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.InitialDirectory = Path;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				return new FileInfo(ofd.FileName);
			}
			return null;
		}

		public string SeleccionaArchivo()
		{
			OpenFileDialog ofd = new OpenFileDialog();
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				return ofd.FileName;
			}
			return null;
		}

		public string SeleccionaCarpeta()
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				return fbd.SelectedPath;
			}
			return null;
		}

		public string SeleccionaCarpeta(string RutaInicial)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = RutaInicial;
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				return fbd.SelectedPath;
			}
			return null;
		}
	}
}
