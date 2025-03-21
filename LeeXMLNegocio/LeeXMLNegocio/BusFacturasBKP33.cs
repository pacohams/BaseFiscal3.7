using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using LeeXMLEntidades;
using LeeXMLsDatos;

namespace LeeXMLNegocio
{
	public class BusFacturasBKP33 : BusAbstracta
	{
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
			ANTICIPOAPROVEEDORES = 15,
			NOMINA = 16
		}

		public decimal ConvierteTextoADecimal(string Valor)
		{
			decimal resul = default(decimal);
			decimal.TryParse(Valor.Replace("$", ""), out resul);
			return resul;
		}

		public string FormatoMoneySinSigno(string ValorTexto)
		{
			if (ConvierteTextoADecimal(ValorTexto) < 0m)
			{
				return "";
			}
			return $"{ConvierteTextoADecimal(ValorTexto):c}".Replace("$", "");
		}

		public string FormatoMoneySinSignoConNegativos(string ValorTexto)
		{
			return $"{ConvierteTextoADecimal(ValorTexto):c}".Replace("$", "");
		}

		public EntFactura ObtieneComprobanteFiscal(int ComprobanteFiscalId)
		{
			try
			{
				EntFactura p = new EntFactura();
				dt = new DatFacturas().obtieneComprobanteFiscal(ComprobanteFiscalId);
				foreach (DataRow r in dt.Rows)
				{
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
				}
				return p;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntFactura ObtieneComprobanteFiscalEgreso(int ComprobanteFiscalId)
		{
			try
			{
				EntFactura p = new EntFactura();
				dt = new DatFacturas().obtieneComprobanteFiscalEgreso(ComprobanteFiscalId);
				foreach (DataRow r in dt.Rows)
				{
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
				}
				return p;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscales(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscales(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.TotalPercepciones = Convert.ToDecimal(r["FAC_TOTALPERCEPCIONES"]);
					p.TotalDeducciones = Convert.ToDecimal(r["FAC_TOTALDEDUCCIONES"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresos(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = Empresa.Nombre;
					p.RFC = Empresa.RFC;
					p.EmisorNombre = r["PROV_NOMBREFISCAl"].ToString();
					p.EmisorRFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscales(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscales(Empresa.Id, FechaDesde, FechaHasta, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.TotalPercepciones = Convert.ToDecimal(r["FAC_TOTALPERCEPCIONES"]);
					p.TotalDeducciones = Convert.ToDecimal(r["FAC_TOTALDEDUCCIONES"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Pagado = Convert.ToBoolean(r["FAC_PAGADO"]);
					p.Depositado = Convert.ToBoolean(r["FAC_DEPOSITADO"]);
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.FechaPagoS = p.FechaPago.ToShortDateString().Replace("01/01/1900", "");
					p.ExcluyeFlujo = Convert.ToBoolean(r["FAC_EXCLUYEFLUJO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesPorFechaPagoExclusivo(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa.Id, FechaDesde, FechaHasta, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Pagado = Convert.ToBoolean(r["FAC_PAGADO"]);
					p.Depositado = Convert.ToBoolean(r["FAC_DEPOSITADO"]);
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.FechaPagoS = p.FechaPago.ToShortDateString().Replace("01/01/1900", "");
					p.ExcluyeFlujo = Convert.ToBoolean(r["FAC_EXCLUYEFLUJO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresos(Empresa.Id, FechaDesde, FechaHasta, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Pagado = Convert.ToBoolean(r["FAC_PAGADO"]);
					p.Depositado = Convert.ToBoolean(r["FAC_DEPOSITADO"]);
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.FechaPagoS = p.FechaPago.ToShortDateString().Replace("01/01/1900", "");
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Empresa.Id, FechaDesde, FechaHasta, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Pagado = Convert.ToBoolean(r["FAC_PAGADO"]);
					p.Depositado = Convert.ToBoolean(r["FAC_DEPOSITADO"]);
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.FechaPagoS = p.FechaPago.ToShortDateString().Replace("01/01/1900", "");
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscales(EntEmpresa Empresa, string UUID)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscales(Empresa.Id, UUID);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Pagado = Convert.ToBoolean(r["FAC_PAGADO"]);
					p.Depositado = Convert.ToBoolean(r["FAC_DEPOSITADO"]);
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresos(EntEmpresa Empresa, string UUID)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresos(Empresa.Id, UUID);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = Empresa.Nombre;
					p.RFC = Empresa.RFC;
					p.EmisorNombre = r["PROV_NOMBREFISCAl"].ToString();
					p.EmisorRFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Pagado = Convert.ToBoolean(r["FAC_PAGADO"]);
					p.Depositado = Convert.ToBoolean(r["FAC_DEPOSITADO"]);
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscales(EntEmpresa Empresa, int TipoRelacionId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscales(Empresa.Id, TipoRelacionId, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONID"]);
					p.TipoRelacion = r["CATREL_DESCRIPCION"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					decimal porcentaje = default(decimal);
					decimal totalNoDep = p.Descuento;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalNoDep / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]) * porcentaje;
					p.SubTotal = p.Descuento - p.IVA + p.Retenciones - p.IEPS;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscales(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscales(Empresa.Id, FechaDesde, FechaHasta, TipoComprobanteId, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					if (p.TipoRelacionId != 3)
					{
						decimal porcentaje = default(decimal);
						decimal totalNoDep = p.Descuento;
						decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
						porcentaje = totalNoDep / totalFac;
						p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
						p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
						p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
						p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
						p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					}
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesNcNoPagados(EntEmpresa Empresa)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesNoPagados(Empresa.Id, 2);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					decimal porcentaje = default(decimal);
					decimal totalNoDep = p.Descuento;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalNoDep / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresosNcNoPagados(EntEmpresa Empresa)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresosNoPagados(Empresa.Id, 2);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					decimal porcentaje = default(decimal);
					decimal totalNoDep = p.Descuento;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalNoDep / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscales(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int MetodoPagoId, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscales(Empresa.Id, FechaDesde, FechaHasta, TipoComprobanteId, MetodoPagoId, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					decimal porcentaje = default(decimal);
					decimal totalNoDep = p.Descuento;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalNoDep / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresos(EntEmpresa Empresa, int TipoRelacionId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresos(Empresa.Id, TipoRelacionId, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONID"]);
					p.TipoRelacion = r["CATREL_DESCRIPCION"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					decimal porcentaje = default(decimal);
					decimal totalNoDep = p.Descuento;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalNoDep / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresos(Empresa.Id, FechaDesde, FechaHasta, TipoComprobanteId, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					if (p.TipoRelacionId != 3)
					{
						decimal porcentaje = default(decimal);
						decimal totalNoDep = p.Descuento;
						decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
						porcentaje = totalNoDep / totalFac;
						p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
						p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
						p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
						p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
						p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					}
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int MetodoPagoId, int EstatusId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresos(Empresa.Id, FechaDesde, FechaHasta, TipoComprobanteId, MetodoPagoId, EstatusId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONFACTURAID"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					decimal porcentaje = default(decimal);
					decimal totalNoDep = p.Descuento;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					if (totalFac > 0m)
					{
						porcentaje = totalNoDep / totalFac;
					}
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Descuento - p.IVA + p.Retenciones;
					p.Deducible = Convert.ToBoolean(r["FAC_DEDUCIBLE"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoPercepciones> ObtieneComprobantesFiscalesPercepciones(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int OpcionFecha)
		{
			try
			{
				List<EntCatalogoPercepciones> lst = new List<EntCatalogoPercepciones>();
				switch (OpcionFecha)
				{
				case 1:
					dt = new DatFacturas().obtieneComprobantesFiscalesPercepciones(Empresa.Id, FechaDesde, FechaHasta);
					break;
				case 2:
					dt = new DatFacturas().obtieneComprobantesFiscalesPercepcionesPorFechasPago(Empresa.Id, FechaDesde, FechaHasta);
					break;
				case 3:
					dt = new DatFacturas().obtieneComprobantesFiscalesPercepcionesPorFechaDevengada(Empresa.Id, FechaDesde, FechaHasta);
					break;
				}
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoPercepciones p = new EntCatalogoPercepciones();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.ClienteId = Convert.ToInt32(r["FAC_CLIENTEID"]);
					p.Cliente = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.ClaveEntFed = r["FAC_CLAVEENTFED"].ToString();
					p.TipoRegimen = r["FAC_TIPOREGIMEN"].ToString();
					p.Clave = r["FACPER_TIPOPERCEPCION"].ToString();
					p.Excento = Convert.ToDecimal(r["FACPER_IMPORTEEXENTO"]);
					p.Gravado = Convert.ToDecimal(r["FACPER_IMPORTEGRAVADO"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesSinRelacionar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesSinRelacionar(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IVA = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONID"]);
					p.TipoRelacion = r["CATREL_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesSinRelacionarEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesSinRelacionarEgresos(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Nombre = r["PROV_NOMBREFISCAl"].ToString();
					p.RFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Deposito = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.Descuento = p.Total - p.Deposito;
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.Moneda = r["CATMON_CLAVE"].ToString();
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.FechaPago = Convert.ToDateTime(r["FAC_FECHAPAGO"]);
					p.EstatusId = Convert.ToInt32(r["FAC_ESTATUSID"]);
					p.EstatusDescripcion = r["ESTFAC_DESCRIPCION"].ToString();
					p.TipoRelacionId = Convert.ToInt32(r["FAC_TIPORELACIONID"]);
					p.TipoRelacion = r["CATREL_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesPorDepositar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesPorDepositar(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Descuento = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesNominaPorDepositar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesNominaPorDepositar(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Descuento = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesNcDevolucionPorDepositar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesNcDevolucionPorDepositar(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Descuento = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.IEPS = Convert.ToDecimal(r["FAC_IEPS"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones - p.IEPS;
					p.Nombre = r["CLI_NOMBREFISCAl"].ToString();
					p.RFC = r["CLI_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresosNcDevolucionPorDepositar(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesEgresosNcDevolucionPorDepositar(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.EmisorNombre = r["PROV_NOMBREFISCAl"].ToString();
					p.EmisorRFC = r["PROV_RFC"].ToString();
					p.Nombre = Empresa.Nombre;
					p.RFC = Empresa.RFC;
					p.Descuento = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesPorDepositarEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneComprobantesFiscalesPorDepositarEgresos(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.Nombre = Empresa.Nombre;
					p.RFC = Empresa.RFC;
					p.Descuento = Convert.ToDecimal(r["FAC_DEPOSITO"]);
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]);
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]);
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]);
					p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					p.Pago = Convert.ToDecimal(r["FAC_PAGO"]);
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.EmisorNombre = r["PROV_NOMBREFISCAl"].ToString();
					p.EmisorRFC = r["PROV_RFC"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.TipoComprobante = r["CATCOM_DESCRIPCION"].ToString();
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MonedaId = Convert.ToInt32(r["FAC_MONEDAID"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.MetodoPago = r["CATMET_CLAVE"].ToString();
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_FACTURARELACIONADAID"]);
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresosAnticiposRelacionadosPUE(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				List<EntFactura> lstEgresos = ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 2, 1);
				List<EntFactura> lstIngresosPUE = ObtieneComprobantesFiscales(Empresa, new DateTime(1900, 1, 1), FechaHasta, 1, 1, 1);
				foreach (EntFactura e in lstEgresos.Where((EntFactura P) => P.TipoRelacionId == 7).ToList())
				{
					string[] facturaIngresoConAnticipo = e.UUIDrelacionado.Split('|');
					string[] array = facturaIngresoConAnticipo;
					foreach (string s in array)
					{
						if (!string.IsNullOrWhiteSpace(s) && lstIngresosPUE.Where((EntFactura P) => P.UUID.Equals(s)).Count() > 0)
						{
							lst.Add(e);
						}
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesNCRelacionadosPUE(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				List<EntFactura> lstEgresos = ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 2, 1);
				lstEgresos.AddRange(ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
				List<EntFactura> lstIngresosPUE = ObtieneComprobantesFiscales(Empresa, new DateTime(1900, 1, 1), FechaHasta, 1, 1, 1);
				foreach (EntFactura e in lstEgresos.Where((EntFactura P) => P.TipoRelacionId == 1 || P.TipoRelacionId == 3).ToList())
				{
					string[] facturaIngresoConAnticipo = e.UUIDrelacionado.Split('|');
					string[] array = facturaIngresoConAnticipo;
					foreach (string s in array)
					{
						if (!string.IsNullOrWhiteSpace(s) && lstIngresosPUE.Where((EntFactura P) => P.UUID.Equals(s)).Count() > 0)
						{
							lst.Add(e);
						}
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresosNCRelacionadosPUE(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				List<EntFactura> lstEgresos = ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 2, 1);
				lstEgresos.AddRange(ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
				List<EntFactura> lstIngresosPUE = ObtieneComprobantesFiscalesEgresos(Empresa, new DateTime(1900, 1, 1), FechaHasta, 1, 1, 1);
				foreach (EntFactura e in lstEgresos.Where((EntFactura P) => P.TipoRelacionId == 1 || P.TipoRelacionId == 3).ToList())
				{
					string[] facturaIngresoConAnticipo = e.UUIDrelacionado.Split('|');
					string[] array = facturaIngresoConAnticipo;
					foreach (string s in array)
					{
						if (!string.IsNullOrWhiteSpace(s) && lstIngresosPUE.Where((EntFactura P) => P.UUID.Equals(s)).Count() > 0)
						{
							lst.Add(e);
						}
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneComprobantesFiscalesEgresosRelacionadosPUEEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				List<EntFactura> lstEgresos = ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 2, 1);
				List<EntFactura> lstIngresosPUE = ObtieneComprobantesFiscalesEgresos(Empresa, new DateTime(1900, 1, 1), FechaHasta, 1, 1, 1);
				foreach (EntFactura e in lstEgresos.Where((EntFactura P) => P.TipoRelacionId == 7).ToList())
				{
					string[] facturaIngresoConAnticipo = e.UUIDrelacionado.Split('|');
					string[] array = facturaIngresoConAnticipo;
					foreach (string s in array)
					{
						if (!string.IsNullOrWhiteSpace(s) && lstIngresosPUE.Where((EntFactura P) => P.UUID.Equals(s)).Count() > 0)
						{
							lst.Add(e);
						}
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneImportesDeclarados(EntEmpresa Empresa, DateTime Fecha)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneImportesDeclarados(Empresa.Id, Fecha);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["IMPDEC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.SubTotal = Convert.ToDecimal(r["IMPDEC_IMPORTE"]);
					p.IVA = Convert.ToDecimal(r["IMPDEC_IVA"]);
					lst.Add(p);
				}
				if (lst.Count == 0)
				{
					lst.Add(new EntFactura());
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneImportesDeclaradosEgresos(EntEmpresa Empresa, DateTime Fecha)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneImportesDeclaradosEgresos(Empresa.Id, Fecha);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["IMPDEC_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.SubTotal = Convert.ToDecimal(r["IMPDEC_IMPORTE"]);
					p.IVA = Convert.ToDecimal(r["IMPDEC_IVA"]);
					lst.Add(p);
				}
				if (lst.Count == 0)
				{
					lst.Add(new EntFactura());
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadoDeCuentaDetalles(int EstadoDeCuentaId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadoDeCuentaDetalles(EstadoDeCuentaId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.Pago = Convert.ToDecimal(r["MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Pago - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadoDeCuentaDetallesEgresos(int EstadoDeCuentaId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadoDeCuentaDetallesEgresos(EstadoDeCuentaId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["ESTCOM_COMPROBANTEFISCALID"]);
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					p.NumeroFactura = r["ESTCOM_NUMEROFACTURA"].ToString();
					p.UUID = r["ESTCOM_UUID"].ToString();
					p.Pago = Convert.ToDecimal(r["MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Pago - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaConDetalle(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuenta(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura ec = new EntFactura();
					ec.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					ec.EmisorNombre = Empresa.Nombre;
					ec.EmisorRFC = Empresa.RFC;
					ec.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					ec.Banco = r["BAN_DESCRIPCION"].ToString();
					ec.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					ec.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					ec.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					ec.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					ec.NumeroFactura = r["ESTCUE_NUMEROFACTURA"].ToString();
					ec.UUID = r["ESTCUE_UUID"].ToString();
					ec.Pago = Convert.ToDecimal(r["MONTO"]);
					lst.Add(ec);
					if (ec.TipoRelacionId != 1 && ec.TipoRelacionId != 7)
					{
						continue;
					}
					bool first = true;
					List<EntFactura> ecDetalles = ObtieneEstadoDeCuentaDetalles(ec.Id);
					foreach (EntFactura ecDet in ecDetalles)
					{
						if (first)
						{
							if (ec.TipoRelacionId == 1)
							{
								EntFactura fac = ObtieneComprobanteFiscal(ecDet.FacturaRelacionId);
								lst.Last().Total = fac.Total;
							}
							lst.Last().NumeroFactura = ecDet.NumeroFactura;
							lst.Last().UUID = ecDet.UUID;
							lst.Last().IVARetenciones = ecDet.IVARetenciones;
							lst.Last().ISRRetenciones = ecDet.ISRRetenciones;
							lst.Last().Retenciones = ecDet.Retenciones;
							lst.Last().IVA = ecDet.IVA;
							lst.Last().SubTotal = ecDet.SubTotal;
							first = false;
							continue;
						}
						lst.Add(new EntFactura
						{
							Id = ec.Id,
							BancoId = ec.BancoId,
							Banco = ec.Banco,
							Fecha = ec.Fecha,
							EstatusId = ec.EstatusId,
							TipoRelacionId = ec.TipoRelacionId,
							TipoRelacion = ec.TipoRelacion,
							Total = ecDet.Pago,
							Pago = 0m,
							NumeroFactura = ecDet.NumeroFactura,
							UUID = ecDet.UUID,
							TipoComprobanteId = ecDet.TipoComprobanteId,
							IVARetenciones = ecDet.IVARetenciones,
							ISRRetenciones = ecDet.ISRRetenciones,
							Retenciones = ecDet.Retenciones,
							IVA = ecDet.IVA,
							SubTotal = ecDet.SubTotal
						});
						if (lst.Last().TipoComprobanteId == 6)
						{
							lst.Last().Total = 0m;
							lst.Last().TipoRelacion = "ANTICIPO DE CLIENTES (SIN CFDI)";
						}
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaConDetalleEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaEgresos(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura ec = new EntFactura();
					ec.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					ec.Nombre = Empresa.Nombre;
					ec.RFC = Empresa.RFC;
					ec.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					ec.Banco = r["BAN_DESCRIPCION"].ToString();
					ec.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					ec.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					ec.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					ec.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					ec.NumeroFactura = r["ESTCUE_NUMEROFACTURA"].ToString();
					ec.UUID = r["ESTCUE_UUID"].ToString();
					ec.Pago = Convert.ToDecimal(r["MONTO"]);
					lst.Add(ec);
					if (ec.TipoRelacionId != 1 && ec.TipoRelacionId != 16 && ec.TipoRelacionId != 15)
					{
						continue;
					}
					bool first = true;
					List<EntFactura> ecDetalles = ObtieneEstadoDeCuentaDetallesEgresos(ec.Id);
					foreach (EntFactura ecDet in ecDetalles)
					{
						if (first)
						{
							if (ec.TipoRelacionId == 1)
							{
								EntFactura fac = ObtieneComprobanteFiscalEgreso(ecDet.FacturaRelacionId);
								lst.Last().Total = fac.Total;
							}
							else if (ec.TipoRelacionId == 16)
							{
								EntFactura fac2 = ObtieneComprobanteFiscal(ecDet.FacturaRelacionId);
								lst.Last().Total = fac2.Total;
							}
							lst.Last().NumeroFactura = ecDet.NumeroFactura;
							lst.Last().UUID = ecDet.UUID;
							lst.Last().IVARetenciones = ecDet.IVARetenciones;
							lst.Last().ISRRetenciones = ecDet.ISRRetenciones;
							lst.Last().Retenciones = ecDet.Retenciones;
							lst.Last().IVA = ecDet.IVA;
							lst.Last().SubTotal = ecDet.SubTotal;
							first = false;
							continue;
						}
						lst.Add(new EntFactura
						{
							Id = ec.Id,
							BancoId = ec.BancoId,
							Banco = ec.Banco,
							Fecha = ec.Fecha,
							EstatusId = ec.EstatusId,
							TipoRelacionId = ec.TipoRelacionId,
							TipoRelacion = ec.TipoRelacion,
							Total = ecDet.Pago,
							Pago = 0m,
							NumeroFactura = ecDet.NumeroFactura,
							UUID = ecDet.UUID,
							TipoComprobanteId = ecDet.TipoComprobanteId,
							IVARetenciones = ecDet.IVARetenciones,
							ISRRetenciones = ecDet.ISRRetenciones,
							Retenciones = ecDet.Retenciones,
							IVA = ecDet.IVA,
							SubTotal = ecDet.SubTotal
						});
						if (lst.Last().TipoComprobanteId == 6)
						{
							lst.Last().Total = 0m;
							lst.Last().TipoRelacion = "ANTICIPO A PROVEEDOR (SIN CFDI)";
						}
						else if (lst.Last().TipoComprobanteId == 7)
						{
							lst.Last().Total = 0m;
							lst.Last().TipoRelacion = "EXCEDENTE DE RETIRO SIN CFDI";
						}
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetalle(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetalle(Empresa.Id, FechaDesde, FechaHasta);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Total = Convert.ToDecimal(r["MONTO"]);
					if (p.FacturaRelacionId > 0)
					{
						decimal porcentaje = default(decimal);
						decimal totalPag = p.Total;
						decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
						porcentaje = totalPag / totalFac;
						p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
						p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
						p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
						p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
						p.SubTotal = p.Total - p.IVA + p.Retenciones;
					}
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetalle(int ComprobanteFiscalId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetallesPorComprobante(ComprobanteFiscalId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Pago = Convert.ToDecimal(r["MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetalleEgresos(int ComprobanteFiscalId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetallesPorComprobanteEgresos(ComprobanteFiscalId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Pago = Convert.ToDecimal(r["MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetallePorTipoComprobante(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetallesPorTipoComprobante(Empresa.Id, FechaDesde, FechaHasta, TipoComprobanteId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCOM_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.FechaPago = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.ClienteId = Convert.ToInt32(r["FAC_CLIENTEID"]);
					p.Nombre = r["CLI_NOMBRE"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.Pago = Convert.ToDecimal(r["ESTCOM_MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = totalFac - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetallePorTipoComprobanteEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetallesPorTipoComprobanteEgresos(Empresa.Id, FechaDesde, FechaHasta, TipoComprobanteId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCOM_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.FechaPago = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.ClienteId = Convert.ToInt32(r["FAC_PROVEEDORID"]);
					p.Nombre = r["PROV_NOMBREFISCAL"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.MetodoPagoId = Convert.ToInt32(r["FAC_METODOPAGOID"]);
					p.FormaPagoId = Convert.ToInt32(r["FAC_FORMAPAGOID"]);
					p.FormaPago = r["CATFOR_DESCRIPCION"].ToString();
					p.Pago = Convert.ToDecimal(r["ESTCOM_MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = totalFac - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetalleFacturaRelacionada(int FacturaRelacionadaId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetallesPorFacturaRelacionada(FacturaRelacionadaId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Pago = Convert.ToDecimal(r["MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaDetalleFacturaRelacionadaEgresos(int FacturaRelacionadaId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuentaDetallesPorFacturaRelacionadaEgresos(FacturaRelacionadaId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["ESTCUE_ID"]);
					p.BancoId = Convert.ToInt32(r["ESTCUE_BANCOID"]);
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.Fecha = Convert.ToDateTime(r["ESTCUE_FECHA"]);
					p.EstatusId = Convert.ToInt32(r["ESTCUE_ESTATUSID"]);
					p.TipoRelacionId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoRelacion = r["TIPMOV_DESCRIPCION"].ToString();
					p.FacturaRelacionId = Convert.ToInt32(r["FAC_ID"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.Pago = Convert.ToDecimal(r["MONTO"]);
					decimal porcentaje = default(decimal);
					decimal totalPag = p.Pago;
					decimal totalFac = Convert.ToDecimal(r["FAC_TOTAL"]);
					if (totalFac == 0m)
					{
						totalFac = default(decimal);
					}
					porcentaje = totalPag / totalFac;
					p.IVARetenciones = Convert.ToDecimal(r["FAC_IVARETENIDO"]) * porcentaje;
					p.ISRRetenciones = Convert.ToDecimal(r["FAC_ISRRETENIDO"]) * porcentaje;
					p.Retenciones = p.IVARetenciones + p.ISRRetenciones;
					p.IVA = Convert.ToDecimal(r["FAC_IVA"]) * porcentaje;
					p.SubTotal = p.Total - p.IVA + p.Retenciones;
					p.Total = totalFac;
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaPT(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneEstadosDeCuenta(Empresa.Id, FechaDesde, FechaHasta);
				int index = 0;
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Banco = r["BAN_DESCRIPCION"].ToString();
					p.SubTotal = Convert.ToDecimal(r["MONTO"]);
					p.TipoComprobanteId = Convert.ToInt32(r["ESTCUE_TIPOMOVIMIENTOID"]);
					p.TipoComprobante = r["TIPMOV_DESCRIPCION"].ToString();
					lst.Add(p);
				}
				List<EntFactura> lstDepositos = new List<EntFactura>();
				EntFactura td = new EntFactura
				{
					Id = index,
					Descripcion = "TOTAL DEPÓSITOS SEGÚN ESTADOS DE CUENTA:",
					SubTotal = 0m,
					Total = lst.Sum((EntFactura P) => P.SubTotal)
				};
				lstDepositos.Add(td);
				index++;
				var result = from a in lst
					group a by new { a.EmisorNombre, a.EmisorRFC, a.BancoId, a.Banco } into g
					select new
					{
						EmisorNombre = g.Key.EmisorNombre,
						EmisorRFC = g.Key.EmisorRFC,
						BancoId = g.Key.BancoId,
						Banco = g.Key.Banco,
						SubTotal = g.Sum((EntFactura P) => P.SubTotal)
					};
				foreach (var f in result)
				{
					EntFactura p2 = new EntFactura();
					p2.Id = index;
					p2.EmisorNombre = Empresa.Nombre;
					p2.EmisorRFC = Empresa.RFC;
					p2.Descripcion = f.Banco;
					p2.SubTotal = f.SubTotal;
					index++;
					lstDepositos.Add(p2);
				}
				EntFactura tni = new EntFactura
				{
					Id = index,
					Descripcion = "(-) DEPÓSITOS QUE NO SON INGRESOS FISCALES",
					SubTotal = 0m,
					Total = lst.Where((EntFactura P) => P.TipoComprobanteId > 1 && P.TipoComprobanteId != 7).Sum((EntFactura P) => P.SubTotal)
				};
				lstDepositos.Add(tni);
				index++;
				int tipoCompId = 0;
				foreach (EntFactura f2 in (from P in lst
					where P.TipoComprobanteId > 1 && P.TipoComprobanteId != 7
					orderby P.TipoComprobanteId
					select P).ToList())
				{
					EntFactura p3 = new EntFactura();
					p3.Id = index;
					p3.EmisorNombre = Empresa.Nombre;
					p3.EmisorRFC = Empresa.RFC;
					p3.Descripcion = f2.TipoComprobante;
					if (tipoCompId != f2.TipoComprobanteId)
					{
						tipoCompId = f2.TipoComprobanteId;
						p3.SubTotal = f2.SubTotal;
						index++;
						lstDepositos.Add(p3);
					}
					else
					{
						lstDepositos.Last().SubTotal += f2.SubTotal;
					}
				}
				int tipoRelacionId = 2;
				List<EntFactura> lstOtrosIngresos = ObtieneComprobantesFiscales(Empresa, tipoRelacionId, FechaDesde, FechaHasta);
				EntFactura to = new EntFactura
				{
					Id = index,
					Descripcion = "(+) OTROS INGRESOS FISCALES NO DEPOSITADOS",
					SubTotal = 0m,
					Total = lstOtrosIngresos.Sum((EntFactura P) => P.Descuento)
				};
				lstDepositos.Add(to);
				index++;
				EntFactura ind = new EntFactura
				{
					Id = index,
					Descripcion = "INGRESOS NO DEPOSITADOS",
					SubTotal = lstOtrosIngresos.Sum((EntFactura P) => P.Descuento),
					Total = 0m
				};
				lstDepositos.Add(ind);
				index++;
				EntFactura totfis = new EntFactura
				{
					Id = index,
					Descripcion = "(=) TOTAL INGRESOS FISCALES POR ESTADOS DE CUENTA",
					SubTotal = 0m,
					Total = td.Total - tni.Total + to.Total
				};
				lstDepositos.Add(totfis);
				index++;
				List<EntFactura> lstIngresos = ObtieneEstadosDeCuentaDetalle(Empresa, FechaDesde, FechaHasta);
				decimal importe = lstIngresos.Sum((EntFactura P) => P.SubTotal) + lstOtrosIngresos.Sum((EntFactura P) => P.SubTotal);
				decimal iva = lstIngresos.Sum((EntFactura P) => P.IVA) + lstOtrosIngresos.Sum((EntFactura P) => P.IVA);
				EntFactura im = new EntFactura
				{
					Id = index,
					Descripcion = "IMPORTE",
					SubTotal = 0m,
					Total = importe
				};
				lstDepositos.Add(im);
				index++;
				EntFactura iv = new EntFactura
				{
					Id = index,
					Descripcion = "IVA",
					SubTotal = 0m,
					Total = iva
				};
				lstDepositos.Add(iv);
				index++;
				decimal ivaRetenido = lstIngresos.Sum((EntFactura P) => P.IVARetenciones) + lstOtrosIngresos.Sum((EntFactura P) => P.IVARetenciones);
				decimal isrRetenido = lstIngresos.Sum((EntFactura P) => P.ISRRetenciones) + lstOtrosIngresos.Sum((EntFactura P) => P.ISRRetenciones);
				EntFactura sub = new EntFactura
				{
					Id = index,
					Descripcion = "SUBTOTAL",
					SubTotal = 0m,
					Total = importe + iva
				};
				lstDepositos.Add(sub);
				index++;
				EntFactura ris = new EntFactura
				{
					Id = index,
					Descripcion = "RETENCION DE ISR",
					SubTotal = 0m,
					Total = isrRetenido
				};
				lstDepositos.Add(ris);
				index++;
				EntFactura riva = new EntFactura
				{
					Id = index,
					Descripcion = "RETENCION DE IVA",
					SubTotal = 0m,
					Total = ivaRetenido
				};
				lstDepositos.Add(riva);
				index++;
				EntFactura totnet = new EntFactura
				{
					Id = index,
					Descripcion = "NETO",
					SubTotal = 0m,
					Total = importe + iva - ivaRetenido - isrRetenido
				};
				lstDepositos.Add(totnet);
				index++;
				EntFactura dif = new EntFactura
				{
					Id = index,
					Descripcion = "DIFERENCIA",
					SubTotal = 0m,
					Total = totfis.Total - totnet.Total
				};
				lstDepositos.Add(dif);
				index++;
				return lstDepositos;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		private void AgregaRenglonPT2(List<EntFactura> ListaPapel, int index, string Columna1, string Columna2, string Columna3, string Columna4)
		{
			EntFactura ren = new EntFactura
			{
				Id = index,
				Descripcion = Columna1,
				MetodoPago = Columna2,
				Banco = Columna3,
				FormaPago = Columna4
			};
			ListaPapel.Add(ren);
			index++;
		}

		private void AgregaRenglonPT2(List<EntFactura> ListaPapel, int index, string Columna1, decimal Columna2, decimal Columna3, decimal Columna4)
		{
			EntFactura ren = new EntFactura
			{
				Id = index,
				Descripcion = Columna1,
				MetodoPago = FormatoMoneySinSigno(Columna2.ToString()),
				Banco = FormatoMoneySinSignoConNegativos(Columna3.ToString()),
				FormaPago = FormatoMoneySinSignoConNegativos(Columna4.ToString())
			};
			ListaPapel.Add(ren);
			index++;
		}

		private void AgregaRenglonPT2Egresos(List<EntFactura> ListaPapel, int index, string Columna1, decimal Columna2, decimal Columna3)
		{
			EntFactura ren = new EntFactura
			{
				Id = index,
				Descripcion = Columna1,
				MetodoPago = FormatoMoneySinSigno(Columna2.ToString()),
				Banco = FormatoMoneySinSignoConNegativos(Columna3.ToString()),
				FormaPago = ""
			};
			ListaPapel.Add(ren);
			index++;
		}

		private void AgregaRenglonPT2SinNegativo(List<EntFactura> ListaPapel, int index, string Columna1, decimal Columna2, decimal Columna3, decimal Columna4)
		{
			EntFactura ren = new EntFactura
			{
				Id = index,
				Descripcion = Columna1,
				MetodoPago = FormatoMoneySinSigno(Columna2.ToString()),
				Banco = FormatoMoneySinSigno(Columna3.ToString()),
				FormaPago = FormatoMoneySinSigno(Columna4.ToString())
			};
			ListaPapel.Add(ren);
			index++;
		}

		private void AgregaRenglonPT2SinNegativoEgresos(List<EntFactura> ListaPapel, int index, string Columna1, decimal Columna2, decimal Columna3)
		{
			EntFactura ren = new EntFactura
			{
				Id = index,
				Descripcion = Columna1,
				MetodoPago = FormatoMoneySinSigno(Columna2.ToString()),
				Banco = FormatoMoneySinSigno(Columna3.ToString()),
				FormaPago = ""
			};
			ListaPapel.Add(ren);
			index++;
		}

		private void AgregaRenglonEspacioPT2(List<EntFactura> ListaPapel, int index)
		{
			ListaPapel.Add(new EntFactura
			{
				Id = index
			});
			index++;
		}

		private void AgregaRenglonEspacioLineaPT2(List<EntFactura> ListaPapel, int index)
		{
			ListaPapel.Add(new EntFactura
			{
				Id = index,
				Descripcion = "-".PadRight(80, '-'),
				Banco = "-".PadRight(30, '-'),
				FormaPago = "-".PadRight(30, '-')
			});
			index++;
		}

		public List<EntFactura> ObtieneEstadosDeCuentaPT2(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				int index = 0;
				List<EntFactura> lst = new List<EntFactura>();
				List<EntFactura> lstPapel = new List<EntFactura>();
				EntFactura t1 = new EntFactura
				{
					Id = index,
					Descripcion = "A) INFORMACIÓN GENERAL",
					MetodoPago = "",
					Banco = "INGRESOS",
					FormaPago = "IVA"
				};
				lstPapel.Add(t1);
				index++;
				lst = new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1);
				lst.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
				decimal ingresosPUE = lst.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.SubTotal);
				decimal ivaIngresosPUE = lst.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.IVA);
				EntFactura t1PUE = new EntFactura
				{
					Id = index,
					Descripcion = "SEGÚN FACTURACIÓN PUE " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ingresosPUE.ToString()),
					FormaPago = FormatoMoneySinSigno(ivaIngresosPUE.ToString())
				};
				lstPapel.Add(t1PUE);
				index++;
				decimal ingresosCP = lst.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.SubTotal);
				decimal ivaIngresosCP = lst.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.IVA);
				EntFactura t1CP = new EntFactura
				{
					Id = index,
					Descripcion = "SEGÚN FACTURACIÓN REP " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ingresosCP.ToString()),
					FormaPago = FormatoMoneySinSigno(ivaIngresosCP.ToString())
				};
				lstPapel.Add(t1CP);
				index++;
				List<EntFactura> lstFacturasEgresosDeAnticipoPUE = ObtieneComprobantesFiscalesEgresosAnticiposRelacionadosPUE(Empresa, FechaDesde, FechaHasta);
				decimal egresosDeAnticipoPUE = default(decimal);
				egresosDeAnticipoPUE = lstFacturasEgresosDeAnticipoPUE.Sum((EntFactura P) => P.SubTotal);
				decimal ivaEgresosDeAnticipoPUE = lstFacturasEgresosDeAnticipoPUE.Sum((EntFactura P) => P.IVA);
				AgregaRenglonPT2(lstPapel, index, "-EGRESO DE ANTICIPOS DE CLIENTES", -1m, egresosDeAnticipoPUE, ivaEgresosDeAnticipoPUE);
				index++;
				List<EntFactura> lstFacturasEgresosDeNCPUE = (from P in ObtieneComprobantesFiscalesNCRelacionadosPUE(Empresa, FechaDesde, FechaHasta)
					where (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && P.FechaPago >= FechaDesde && P.FechaPago <= FechaHasta && !Empresa.ExcluyeNc01) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Empresa.ExcluyeNc03)
					select P).ToList();
				decimal egresosDeNCPUE = default(decimal);
				egresosDeNCPUE = lstFacturasEgresosDeNCPUE.Sum((EntFactura P) => P.SubTotal);
				decimal ivaEgresosDeNCPUE = lstFacturasEgresosDeNCPUE.Sum((EntFactura P) => P.IVA);
				AgregaRenglonPT2(lstPapel, index, "-EGRESO DE NOTAS DE CRÉDITO", -1m, egresosDeNCPUE, ivaEgresosDeNCPUE);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				EntFactura t1Total = new EntFactura
				{
					Id = index,
					Descripcion = "(=) TOTAL SEGÚN FACTURACION",
					MetodoPago = "",
					Banco = FormatoMoneySinSigno((ingresosPUE + ingresosCP - egresosDeAnticipoPUE - egresosDeNCPUE).ToString()),
					FormaPago = FormatoMoneySinSigno((ivaIngresosPUE + ivaIngresosCP - ivaEgresosDeAnticipoPUE - ivaEgresosDeNCPUE).ToString())
				};
				lstPapel.Add(t1Total);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				decimal importeCaptura = default(decimal);
				decimal ivaCaptura = default(decimal);
				EntFactura importeDeclarado = ObtieneImportesDeclarados(Empresa, FechaDesde)[0];
				importeCaptura = importeDeclarado.SubTotal;
				ivaCaptura = importeDeclarado.IVA;
				EntFactura t1Declarados = new EntFactura
				{
					Id = index,
					Descripcion = "(-) IMPORTES DECLARADOS POR LA EMPRESA",
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(importeCaptura.ToString()),
					FormaPago = FormatoMoneySinSigno(ivaCaptura.ToString())
				};
				lstPapel.Add(t1Declarados);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				string diferenciaS = "";
				decimal diferenciaImporte = default(decimal);
				decimal diferenciaIVA = default(decimal);
				diferenciaImporte = ingresosPUE + ingresosCP - egresosDeAnticipoPUE - egresosDeNCPUE - importeCaptura;
				diferenciaIVA = ivaIngresosPUE + ivaIngresosCP - ivaEgresosDeAnticipoPUE - ivaEgresosDeNCPUE - ivaCaptura;
				if (diferenciaImporte > 0m)
				{
					diferenciaS = "IMPORTE MENOR EN DECLARACION";
				}
				else if (diferenciaImporte < 0m)
				{
					diferenciaS = "IMPORTE MAYOR EN DECLARACION";
					diferenciaImporte *= -1m;
					diferenciaIVA *= -1m;
				}
				EntFactura t1Diferencia = new EntFactura
				{
					Id = index,
					Descripcion = "(=) DIFERENCIA | " + diferenciaS + " |",
					MetodoPago = "",
					Banco = FormatoMoneySinSignoConNegativos(diferenciaImporte.ToString()),
					FormaPago = FormatoMoneySinSignoConNegativos(diferenciaIVA.ToString())
				};
				lstPapel.Add(t1Diferencia);
				index++;
				AgregaRenglonEspacioLineaPT2(lstPapel, index);
				index++;
				EntFactura t2 = new EntFactura
				{
					Id = index,
					Descripcion = "B) ANÁLISIS CONCILIACION",
					MetodoPago = "",
					Banco = "",
					FormaPago = ""
				};
				lstPapel.Add(t2);
				index++;
				EntFactura t2PUE = new EntFactura
				{
					Id = index,
					Descripcion = "INGRESOS S/ FACTURACION PUE " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ingresosPUE.ToString()),
					FormaPago = FormatoMoneySinSigno(ivaIngresosPUE.ToString())
				};
				lstPapel.Add(t2PUE);
				index++;
				EntFactura t2CP = new EntFactura
				{
					Id = index,
					Descripcion = "INGRESOS S/ FACTURACION REP " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ingresosCP.ToString()),
					FormaPago = FormatoMoneySinSigno(ivaIngresosCP.ToString())
				};
				lstPapel.Add(t2CP);
				index++;
				AgregaRenglonPT2(lstPapel, index, "-EGRESO DE ANTICIPOS DE CLIENTES", -1m, egresosDeAnticipoPUE, ivaEgresosDeAnticipoPUE);
				index++;
				AgregaRenglonPT2(lstPapel, index, "-EGRESO DE NOTAS DE CRÉDITO", -1m, egresosDeNCPUE, ivaEgresosDeNCPUE);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				decimal ingresosSF = ingresosPUE + ingresosCP - egresosDeAnticipoPUE - egresosDeNCPUE;
				decimal ivaIngresosSF = ivaIngresosPUE + ivaIngresosCP - ivaEgresosDeAnticipoPUE - ivaEgresosDeNCPUE;
				AgregaRenglonPT2(lstPapel, index, "(=) INGRESOS S/FACTURACION", -1m, ingresosSF, ivaIngresosSF);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				decimal anticiposSinCFDI = ObtieneEstadosDeCuentaDetallePorTipoComprobante(Empresa, FechaDesde, FechaHasta, 6).Sum((EntFactura P) => P.SubTotal);
				List<EntFactura> lstFacturasConDeposito = ObtieneEstadosDeCuentaDetallePorTipoComprobante(Empresa, FechaDesde, FechaHasta, 1);
				decimal depositosPPD = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.SubTotal);
				decimal depositosPUEanterior = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.SubTotal);
				decimal ivaAnticiposSinCFDI = ObtieneEstadosDeCuentaDetallePorTipoComprobante(Empresa, FechaDesde, FechaHasta, 6).Sum((EntFactura P) => P.IVA);
				decimal ivaDepositosPPD = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.IVA);
				decimal ivaDepositosPUEanterior = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.IVA);
				decimal partidasSuman = anticiposSinCFDI + depositosPPD + depositosPUEanterior;
				decimal ivaPartidasSuman = ivaAnticiposSinCFDI + ivaDepositosPPD + ivaDepositosPUEanterior;
				AgregaRenglonPT2(lstPapel, index, "(+) PARTIDAS QUE SUMAN", -1m, partidasSuman, ivaPartidasSuman);
				index++;
				AgregaRenglonPT2SinNegativo(lstPapel, index, "ANTICIPO DE CLIENTES NO FACTURADO", -1m, anticiposSinCFDI, ivaAnticiposSinCFDI);
				index++;
				AgregaRenglonPT2SinNegativo(lstPapel, index, "DEPOSITOS DE FACTURAS PPD QUE NO SE ELABORÓ REP", -1m, depositosPPD, ivaDepositosPPD);
				index++;
				if (depositosPPD > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f in lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).ToList())
					{
						AgregaRenglonPT2(lstPapel, index, $"{f.Fecha.ToShortDateString()}        {f.Folio}        {f.Nombre:8}        {f.FormaPago.PadLeft(60)}        ", FormatoMoneySinSigno(f.SubTotal.ToString()), FormatoMoneySinSigno(f.IVA.ToString()), FormatoMoneySinSigno(f.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", depositosPPD, lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.IVA), lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				AgregaRenglonPT2SinNegativo(lstPapel, index, "CFDI PUE DE MESES ANTERIORES DEPOSITADOS EN EL MES", -1m, depositosPUEanterior, ivaDepositosPUEanterior);
				index++;
				if (depositosPUEanterior > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f2 in lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).ToList())
					{
						AgregaRenglonPT2(lstPapel, index, $"{f2.Fecha.ToShortDateString()}        {f2.Folio}        {f2.Nombre:8}        {f2.FormaPago.PadLeft(60)}        ", FormatoMoneySinSigno(f2.SubTotal.ToString()), FormatoMoneySinSigno(f2.IVA.ToString()), FormatoMoneySinSigno(f2.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", depositosPUEanterior, lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.IVA), lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				List<EntFactura> lstFacturasPUESinDeposito = ObtieneComprobantesFiscales(Empresa, 3, FechaDesde, FechaHasta).ToList();
				decimal noDepositos = lstFacturasPUESinDeposito.Sum((EntFactura P) => P.SubTotal);
				decimal ivaNoDepositos = lstFacturasPUESinDeposito.Sum((EntFactura P) => P.IVA);
				List<EntFactura> lstFacturasCPPUEMesAnterior = ObtieneComprobantesFiscales(Empresa, 4, FechaDesde, FechaHasta).ToList();
				decimal depositadoMesAnterior = lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.SubTotal);
				decimal ivaDepositadoMesAnterior = lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.IVA);
				decimal partidasRestan = noDepositos + depositadoMesAnterior;
				decimal ivaPartidasRestan = ivaNoDepositos + ivaDepositadoMesAnterior;
				AgregaRenglonPT2(lstPapel, index, "(-) PARTIDAS QUE RESTAN", -1m, partidasRestan, ivaPartidasRestan);
				index++;
				AgregaRenglonPT2SinNegativo(lstPapel, index, "CFDI PUE DEL MES NO COBRADAS", -1m, noDepositos, ivaNoDepositos);
				index++;
				if (noDepositos > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f3 in lstFacturasPUESinDeposito)
					{
						AgregaRenglonPT2(lstPapel, index, $"{f3.Fecha.ToShortDateString()}        {f3.Folio}        {f3.Nombre:8}        {f3.FormaPago.PadLeft(60)}        ", FormatoMoneySinSigno(f3.SubTotal.ToString()), FormatoMoneySinSigno(f3.IVA.ToString()), FormatoMoneySinSigno(f3.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", noDepositos, lstFacturasPUESinDeposito.Sum((EntFactura P) => P.IVA), lstFacturasPUESinDeposito.Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				AgregaRenglonPT2SinNegativo(lstPapel, index, "PUE / CP DEPOSITADOS EN MESES ANTERIORES", -1m, depositadoMesAnterior, ivaDepositadoMesAnterior);
				index++;
				if (depositadoMesAnterior > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f4 in lstFacturasCPPUEMesAnterior)
					{
						AgregaRenglonPT2(lstPapel, index, $"{f4.Fecha.ToShortDateString()}        {f4.Folio}        {f4.Nombre:8}        {f4.FormaPago.PadRight(30)}        ", FormatoMoneySinSigno(f4.SubTotal.ToString()), FormatoMoneySinSigno(f4.IVA.ToString()), FormatoMoneySinSigno(f4.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", depositadoMesAnterior, lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.IVA), lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				AgregaRenglonPT2(lstPapel, index, "(=) INGRESOS DECLARADOS POR EL CONTRIBUYENTE", -1m, ingresosSF + partidasSuman - partidasRestan, ivaIngresosSF + ivaPartidasSuman - ivaPartidasRestan);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				AgregaRenglonPT2(lstPapel, index, "(=) DIFERENCIA GENERAL", -1m, importeCaptura - (ingresosSF + partidasSuman - partidasRestan), ivaCaptura - (ivaIngresosSF + ivaPartidasSuman - ivaPartidasRestan));
				index++;
				return lstPapel;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneEstadosDeCuentaPT2Egresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				int index = 0;
				List<EntFactura> lst = new List<EntFactura>();
				List<EntFactura> lstPapel = new List<EntFactura>();
				EntFactura t1 = new EntFactura
				{
					Id = index,
					Descripcion = "A) INFORMACIÓN GENERAL",
					MetodoPago = "",
					Banco = "IVA",
					FormaPago = ""
				};
				lstPapel.Add(t1);
				index++;
				lst = new BusFacturas().ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 1);
				lst.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
				decimal egresosPUE = lst.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.SubTotal);
				decimal ivaEgresosPUE = lst.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.IVA);
				EntFactura t1PUE = new EntFactura
				{
					Id = index,
					Descripcion = "IVA SEGÚN FACTURACIÓN PUE " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaEgresosPUE.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t1PUE);
				index++;
				decimal egresosCP = lst.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.SubTotal);
				decimal ivaEgresosCP = lst.Where((EntFactura P) => P.TipoComprobanteId == 5).Sum((EntFactura P) => P.IVA);
				EntFactura t1CP = new EntFactura
				{
					Id = index,
					Descripcion = "IVA SEGÚN FACTURACIÓN REP " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaEgresosCP.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t1CP);
				index++;
				List<EntFactura> lstFacturasEgresosDeAnticipoPUE = ObtieneComprobantesFiscalesEgresosRelacionadosPUEEgresos(Empresa, FechaDesde, FechaHasta);
				decimal egresosDeAnticipoPUE = default(decimal);
				egresosDeAnticipoPUE = lstFacturasEgresosDeAnticipoPUE.Sum((EntFactura P) => P.SubTotal);
				decimal ivaEgresosDeAnticipoPUE = lstFacturasEgresosDeAnticipoPUE.Sum((EntFactura P) => P.IVA);
				AgregaRenglonPT2Egresos(lstPapel, index, "(-) IVA DE EGRESO DE ANTICIPOS A PROVEEDORES", -1m, ivaEgresosDeAnticipoPUE);
				index++;
				List<EntFactura> lstFacturasEgresosDeNCPUE = (from P in ObtieneComprobantesFiscalesEgresosNCRelacionadosPUE(Empresa, FechaDesde, FechaHasta)
					where ((P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && P.FechaPago >= FechaDesde && P.FechaPago <= FechaHasta && !Empresa.ExcluyeNc01) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Empresa.ExcluyeNc03)) && P.Deducible
					select P).ToList();
				decimal egresosDeNCPUE = default(decimal);
				egresosDeNCPUE = lstFacturasEgresosDeNCPUE.Sum((EntFactura P) => P.SubTotal);
				decimal ivaEgresosDeNCPUE = lstFacturasEgresosDeNCPUE.Sum((EntFactura P) => P.IVA);
				AgregaRenglonPT2Egresos(lstPapel, index, "(-) IVA DE NOTAS DE CRÉDITO", -1m, ivaEgresosDeNCPUE);
				index++;
				decimal ivaNoDeducible = lst.Where((EntFactura P) => (P.TipoComprobanteId == 5 || (P.TipoComprobanteId == 1 && P.MetodoPagoId == 1)) && !P.Deducible).Sum((EntFactura P) => P.IVA);
				EntFactura t1ND = new EntFactura
				{
					Id = index,
					Descripcion = "(-) IVA NO DEDUCIBLE ",
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaNoDeducible.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t1ND);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				EntFactura t1Total = new EntFactura
				{
					Id = index,
					Descripcion = "(=) TOTAL IVA SEGÚN FACTURACION",
					MetodoPago = "",
					Banco = FormatoMoneySinSigno((ivaEgresosPUE + ivaEgresosCP - ivaEgresosDeAnticipoPUE - ivaEgresosDeNCPUE - ivaNoDeducible).ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t1Total);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				decimal importeCaptura = default(decimal);
				decimal ivaCaptura = default(decimal);
				EntFactura importeDeclarado = ObtieneImportesDeclaradosEgresos(Empresa, FechaDesde)[0];
				importeCaptura = importeDeclarado.SubTotal;
				ivaCaptura = importeDeclarado.IVA;
				EntFactura t1Declarados = new EntFactura
				{
					Id = index,
					Descripcion = "(-) IVA DECLARADO POR LA EMPRESA",
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaCaptura.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t1Declarados);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				string diferenciaS = "";
				decimal diferenciaImporte = default(decimal);
				decimal diferenciaIVA = default(decimal);
				diferenciaImporte = egresosPUE + egresosCP - egresosDeAnticipoPUE - importeCaptura;
				diferenciaIVA = ivaEgresosPUE + ivaEgresosCP - ivaEgresosDeAnticipoPUE - ivaEgresosDeNCPUE - ivaNoDeducible - ivaCaptura;
				if (diferenciaIVA > 0m)
				{
					diferenciaS = "IMPORTE MENOR EN DECLARACION";
				}
				else if (diferenciaIVA < 0m)
				{
					diferenciaS = "IMPORTE MAYOR EN DECLARACION";
					diferenciaImporte *= -1m;
					diferenciaIVA *= -1m;
				}
				EntFactura t1Diferencia = new EntFactura
				{
					Id = index,
					Descripcion = "(=) DIFERENCIA | " + diferenciaS + " |",
					MetodoPago = "",
					Banco = FormatoMoneySinSignoConNegativos(diferenciaIVA.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t1Diferencia);
				index++;
				AgregaRenglonEspacioLineaPT2(lstPapel, index);
				index++;
				EntFactura t2 = new EntFactura
				{
					Id = index,
					Descripcion = "B) ANÁLISIS CONCILIACIÓN",
					MetodoPago = "",
					Banco = "",
					FormaPago = ""
				};
				lstPapel.Add(t2);
				index++;
				EntFactura t2PUE = new EntFactura
				{
					Id = index,
					Descripcion = "IVA S/ FACTURACIÓN PUE " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaEgresosPUE.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t2PUE);
				index++;
				EntFactura t2CP = new EntFactura
				{
					Id = index,
					Descripcion = "IVA S/ FACTURACION REP " + FechaDesde.ToString("MMM yy"),
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaEgresosCP.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t2CP);
				index++;
				AgregaRenglonPT2Egresos(lstPapel, index, "(-) IVA DE EGRESO DE ANTICIPOS A PROVEEDORES", -1m, ivaEgresosDeAnticipoPUE);
				index++;
				AgregaRenglonPT2Egresos(lstPapel, index, "(-) IVA DE EGRESO DE NOTAS DE CRÉDITO A PROVEEDORES", -1m, ivaEgresosDeNCPUE);
				index++;
				EntFactura t2ND = new EntFactura
				{
					Id = index,
					Descripcion = "(-) IVA NO DEDUCIBLE ",
					MetodoPago = "",
					Banco = FormatoMoneySinSigno(ivaNoDeducible.ToString()),
					FormaPago = ""
				};
				lstPapel.Add(t2ND);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				decimal ingresosSF = egresosPUE + egresosCP - egresosDeAnticipoPUE;
				decimal ivaIngresosSF = ivaEgresosPUE + ivaEgresosCP - ivaEgresosDeAnticipoPUE - ivaEgresosDeNCPUE - ivaNoDeducible;
				AgregaRenglonPT2Egresos(lstPapel, index, "(=) IVA S/FACTURACION", -1m, ivaIngresosSF);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				decimal anticiposSinCFDI = ObtieneEstadosDeCuentaDetallePorTipoComprobanteEgresos(Empresa, FechaDesde, FechaHasta, 6).Sum((EntFactura P) => P.SubTotal);
				List<EntFactura> lstFacturasConDeposito = ObtieneEstadosDeCuentaDetallePorTipoComprobanteEgresos(Empresa, FechaDesde, FechaHasta, 1);
				decimal depositosPPD = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.SubTotal);
				decimal depositosPUEanterior = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.SubTotal);
				decimal ivaAnticiposSinCFDI = ObtieneEstadosDeCuentaDetallePorTipoComprobanteEgresos(Empresa, FechaDesde, FechaHasta, 6).Sum((EntFactura P) => P.IVA);
				decimal ivaDepositosPPD = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.IVA);
				decimal ivaDepositosPUEanterior = lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.IVA);
				decimal partidasSuman = anticiposSinCFDI + depositosPPD + depositosPUEanterior;
				decimal ivaPartidasSuman = ivaAnticiposSinCFDI + ivaDepositosPPD + ivaDepositosPUEanterior;
				AgregaRenglonPT2Egresos(lstPapel, index, "(+) PARTIDAS QUE SUMAN", -1m, ivaPartidasSuman);
				index++;
				AgregaRenglonPT2SinNegativoEgresos(lstPapel, index, "IVA DE ANTICIPO A PROVEEDORES NO FACTURADO", -1m, ivaAnticiposSinCFDI);
				index++;
				AgregaRenglonPT2SinNegativoEgresos(lstPapel, index, "IVA DE FACTURAS PPD QUE NO SE ELABORÓ REP", -1m, ivaDepositosPPD);
				index++;
				if (depositosPPD > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f in lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).ToList())
					{
						AgregaRenglonPT2(lstPapel, index, $"{f.Fecha.ToShortDateString()}        {f.Folio}        {f.Nombre:8}        {f.FormaPago.PadLeft(60)}        ", FormatoMoneySinSigno(f.SubTotal.ToString()), FormatoMoneySinSigno(f.IVA.ToString()), FormatoMoneySinSigno(f.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", depositosPPD, lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.IVA), lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 2).Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				AgregaRenglonPT2SinNegativoEgresos(lstPapel, index, "IVA DE CFDI PUE DE MESES ANTERIORES PAGADOS EN EL MES", -1m, ivaDepositosPUEanterior);
				index++;
				if (depositosPUEanterior > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f2 in lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).ToList())
					{
						AgregaRenglonPT2(lstPapel, index, $"{f2.Fecha.ToShortDateString()}        {f2.Folio}        {f2.Nombre:8}        {f2.FormaPago.PadLeft(60)}        ", FormatoMoneySinSigno(f2.SubTotal.ToString()), FormatoMoneySinSigno(f2.IVA.ToString()), FormatoMoneySinSigno(f2.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", depositosPUEanterior, lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.IVA), lstFacturasConDeposito.Where((EntFactura P) => P.MetodoPagoId == 1 && P.Fecha < FechaDesde).Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				List<EntFactura> lstFacturasPUESinDeposito = (from P in ObtieneComprobantesFiscalesEgresos(Empresa, 3, FechaDesde, FechaHasta)
					where P.Deducible
					select P).ToList();
				decimal noDepositos = lstFacturasPUESinDeposito.Sum((EntFactura P) => P.SubTotal);
				decimal ivaNoDepositos = lstFacturasPUESinDeposito.Sum((EntFactura P) => P.IVA);
				List<EntFactura> lstFacturasCPPUEMesAnterior = (from P in ObtieneComprobantesFiscalesEgresos(Empresa, 4, FechaDesde, FechaHasta)
					where P.TipoComprobanteId == 5
					select P).ToList();
				decimal depositadoMesAnterior = lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.SubTotal);
				decimal ivaDepositadoMesAnterior = lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.IVA);
				decimal partidasRestan = noDepositos + depositadoMesAnterior;
				decimal ivaPartidasRestan = ivaNoDepositos + ivaDepositadoMesAnterior;
				AgregaRenglonPT2Egresos(lstPapel, index, "(-) PARTIDAS QUE RESTAN", -1m, ivaPartidasRestan);
				index++;
				AgregaRenglonPT2SinNegativoEgresos(lstPapel, index, "IVA DE CFDI PUE DEL MES NO PAGADAS", -1m, ivaNoDepositos);
				index++;
				if (noDepositos > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f3 in lstFacturasPUESinDeposito)
					{
						AgregaRenglonPT2(lstPapel, index, $"{f3.Fecha.ToShortDateString()}        {f3.Folio}        {f3.Nombre:8}        {f3.FormaPago.PadLeft(60)}        ", FormatoMoneySinSigno(f3.SubTotal.ToString()), FormatoMoneySinSigno(f3.IVA.ToString()), FormatoMoneySinSigno(f3.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", noDepositos, lstFacturasPUESinDeposito.Sum((EntFactura P) => P.IVA), lstFacturasPUESinDeposito.Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				AgregaRenglonPT2SinNegativoEgresos(lstPapel, index, "IVA DE REP PAGADOS EN MESES ANTERIORES", -1m, ivaDepositadoMesAnterior);
				index++;
				if (depositadoMesAnterior > 0m)
				{
					AgregaRenglonPT2(lstPapel, index, "FECHA FACTURA".PadRight(25) + "FACTURA".PadRight(25) + "CLIENTE".PadRight(80) + "METODO".PadRight(40), "IMPORTE", "IVA", "TOTAL");
					index++;
					foreach (EntFactura f4 in lstFacturasCPPUEMesAnterior)
					{
						AgregaRenglonPT2(lstPapel, index, $"{f4.Fecha.ToShortDateString()}        {f4.Folio}        {f4.Nombre:8}        {f4.FormaPago.PadRight(30)}        ", FormatoMoneySinSigno(f4.SubTotal.ToString()), FormatoMoneySinSigno(f4.IVA.ToString()), FormatoMoneySinSigno(f4.Total.ToString()));
						index++;
					}
					AgregaRenglonPT2(lstPapel, index, "                                                 TOTALES", depositadoMesAnterior, lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.IVA), lstFacturasCPPUEMesAnterior.Sum((EntFactura P) => P.Total));
					index++;
					AgregaRenglonEspacioPT2(lstPapel, index);
					index++;
				}
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				AgregaRenglonPT2Egresos(lstPapel, index, "(=) IVA DECLARADO POR EL CONTRIBUYENTE", -1m, ivaIngresosSF + ivaPartidasSuman - ivaPartidasRestan);
				index++;
				AgregaRenglonEspacioPT2(lstPapel, index);
				index++;
				AgregaRenglonPT2Egresos(lstPapel, index, "(=) DIFERENCIA GENERAL", -1m, ivaCaptura - (ivaIngresosSF + ivaPartidasSuman - ivaPartidasRestan));
				index++;
				return lstPapel;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneSaldoAFecha(EntEmpresa Empresa, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneSaldoAFecha(Empresa.Id, FechaHasta, ClienteDesdeId, ClienteHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["CLIENTEID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.ClienteId = Convert.ToInt32(r["CLIENTEID"]);
					p.Nombre = r["CLIENTE"].ToString();
					p.Fecha = FechaHasta;
					p.SubTotal = Convert.ToDecimal(r["CARGOS"]);
					p.Total = Convert.ToDecimal(r["ABONOS"]);
					p.Descuento = Convert.ToDecimal(r["SALDO"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCxCPorClientes(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				List<EntFactura> lstSaldosIniciales = ObtieneSaldoAFecha(Empresa, FechaDesde, ClienteDesdeId, ClienteHastaId);
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				dt = new DatFacturas().obtieneCxCPorClientes(Empresa.Id, FechaDesde, FechaHasta, ClienteDesdeId, ClienteHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta p = new EntEstadoDeCuenta();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.ClienteId = Convert.ToInt32(r["CLIENTEID"]);
					p.Nombre = r["CLI_NOMBREFISCAL"].ToString();
					if (lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList().Count == 0)
					{
						p.SubTotal0 = 0m;
					}
					else
					{
						p.SubTotal0 = lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList()[0].Descuento;
					}
					p.SubTotal = Convert.ToDecimal(r["CARGOS"]);
					p.Total = Convert.ToDecimal(r["ABONOS"]);
					p.Descuento = Convert.ToDecimal(r["SALDOPERIODO"]) + p.SubTotal0;
					lst.Add(p);
				}
				decimal saldoI = lst.Sum((EntEstadoDeCuenta P) => P.SubTotal0);
				decimal cargos = lst.Sum((EntEstadoDeCuenta P) => P.SubTotal);
				decimal abonos = lst.Sum((EntEstadoDeCuenta P) => P.Total);
				decimal saldoF = lst.Sum((EntEstadoDeCuenta P) => P.Descuento);
				lst.Insert(0, new EntEstadoDeCuenta
				{
					ClienteId = 0,
					Nombre = "CLIENTES",
					SubTotal0 = saldoI,
					SubTotal = cargos,
					Total = abonos,
					Descuento = saldoF
				});
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCxCMovimientosPorClientes(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				List<EntFactura> lstSaldosIniciales = ObtieneSaldoAFecha(Empresa, FechaDesde, ClienteDesdeId, ClienteHastaId);
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				int clienteId = 0;
				decimal saldo = default(decimal);
				decimal saldoFinal = default(decimal);
				dt = new DatFacturas().obtieneCxCMovimientosPorClientes(Empresa.Id, FechaDesde, FechaHasta, ClienteDesdeId, ClienteHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta p = new EntEstadoDeCuenta();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.ClienteId = Convert.ToInt32(r["FAC_CLIENTEID"]);
					p.Nombre = r["CLI_NOMBREFISCAL"].ToString();
					if (clienteId != p.ClienteId)
					{
						clienteId = p.ClienteId;
						if (lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList().Count == 0)
						{
							saldo = default(decimal);
						}
						else
						{
							saldo = lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList()[0].Descuento;
							saldoFinal += saldo;
						}
						p.SubTotal0 = saldo;
					}
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					if (p.TipoComprobanteId == 1)
					{
						p.SubTotal = Convert.ToDecimal(r["FAC_TOTAL"]);
						saldo += p.SubTotal;
						saldoFinal += p.SubTotal;
					}
					else
					{
						p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
						saldo -= p.Total;
						saldoFinal -= p.Total;
					}
					p.Descuento = saldo;
					p.Deposito = saldoFinal;
					lst.Add(p);
				}
				foreach (EntFactura f in lstSaldosIniciales)
				{
					if (lst.Where((EntEstadoDeCuenta P) => P.ClienteId == f.ClienteId).ToList().Count == 0)
					{
						saldoFinal += f.Descuento;
						lst.Add(new EntEstadoDeCuenta
						{
							ClienteId = f.ClienteId,
							Nombre = f.Nombre,
							SubTotal0 = f.Descuento,
							Deposito = saldoFinal
						});
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCxCMovimientosPorClientesPorFactura(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				List<EntFactura> lstSaldosIniciales = ObtieneSaldoAFecha(Empresa, FechaDesde, ClienteDesdeId, ClienteHastaId);
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				int clienteId = 0;
				decimal saldo = default(decimal);
				decimal saldoFinal = default(decimal);
				dt = new DatFacturas().obtieneCxCMovimientosPorClientes(Empresa.Id, FechaDesde, FechaHasta, ClienteDesdeId, ClienteHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta p = new EntEstadoDeCuenta();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.ClienteId = Convert.ToInt32(r["FAC_CLIENTEID"]);
					p.Nombre = r["CLI_NOMBREFISCAL"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					if (p.TipoComprobanteId == 1)
					{
						p.SubTotal = Convert.ToDecimal(r["FAC_TOTAL"]);
					}
					else
					{
						p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					}
					lst.Add(p);
				}
				foreach (EntEstadoDeCuenta p2 in (from P in lst
					orderby P.ClienteId, P.UUIDrelacionado, P.Fecha
					select P).ToList())
				{
					if (clienteId != p2.ClienteId)
					{
						clienteId = p2.ClienteId;
						if (lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p2.ClienteId).ToList().Count == 0)
						{
							saldo = default(decimal);
						}
						else
						{
							saldo = lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p2.ClienteId).ToList()[0].Descuento;
							saldoFinal += saldo;
						}
						p2.SubTotal0 = saldo;
					}
					if (p2.TipoComprobanteId == 1)
					{
						saldo += p2.SubTotal;
						saldoFinal += p2.SubTotal;
					}
					else
					{
						saldo -= p2.Total;
						saldoFinal -= p2.Total;
					}
					p2.Descuento = saldo;
					p2.Deposito = saldoFinal;
				}
				foreach (EntFactura f in lstSaldosIniciales)
				{
					if (lst.Where((EntEstadoDeCuenta P) => P.ClienteId == f.ClienteId).ToList().Count == 0)
					{
						saldoFinal += f.Descuento;
						lst.Add(new EntEstadoDeCuenta
						{
							ClienteId = f.ClienteId,
							Nombre = f.Nombre,
							SubTotal0 = f.Descuento,
							Deposito = saldoFinal
						});
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntFactura> ObtieneSaldoAFechaProveedores(EntEmpresa Empresa, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				List<EntFactura> lst = new List<EntFactura>();
				dt = new DatFacturas().obtieneSaldoAFechaProveedores(Empresa.Id, FechaHasta, ProveedorDesdeId, ProveedorHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntFactura p = new EntFactura();
					p.Id = Convert.ToInt32(r["PROVEEDORID"]);
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.ClienteId = Convert.ToInt32(r["PROVEEDORID"]);
					p.Nombre = r["PROVEEDOR"].ToString();
					p.Fecha = FechaHasta;
					p.SubTotal = Convert.ToDecimal(r["CARGOS"]);
					p.Total = Convert.ToDecimal(r["ABONOS"]);
					p.Descuento = Convert.ToDecimal(r["SALDO"]);
					lst.Add(p);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCxPPorProveedores(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				List<EntFactura> lstSaldosIniciales = ObtieneSaldoAFechaProveedores(Empresa, FechaDesde, ProveedorDesdeId, ProveedorHastaId);
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				dt = new DatFacturas().obtieneCxPPorProveedores(Empresa.Id, FechaDesde, FechaHasta, ProveedorDesdeId, ProveedorHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta p = new EntEstadoDeCuenta();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.ClienteId = Convert.ToInt32(r["PROVEEDORID"]);
					p.Nombre = r["PROV_NOMBREFISCAL"].ToString();
					if (lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList().Count == 0)
					{
						p.SubTotal0 = 0m;
					}
					else
					{
						p.SubTotal0 = lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList()[0].Descuento;
					}
					p.SubTotal = Convert.ToDecimal(r["ABONOS"]);
					p.Total = Convert.ToDecimal(r["CARGOS"]);
					p.Descuento = Convert.ToDecimal(r["SALDOPERIODO"]) + p.SubTotal0;
					lst.Add(p);
				}
				decimal saldoI = lst.Sum((EntEstadoDeCuenta P) => P.SubTotal0);
				decimal cargos = lst.Sum((EntEstadoDeCuenta P) => P.SubTotal);
				decimal abonos = lst.Sum((EntEstadoDeCuenta P) => P.Total);
				decimal saldoF = lst.Sum((EntEstadoDeCuenta P) => P.Descuento);
				lst.Insert(0, new EntEstadoDeCuenta
				{
					ClienteId = 0,
					Nombre = "PROVEEDORES",
					SubTotal0 = saldoI,
					SubTotal = cargos,
					Total = abonos,
					Descuento = saldoF
				});
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCxPMovimientosPorProveedores(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				List<EntFactura> lstSaldosIniciales = ObtieneSaldoAFechaProveedores(Empresa, FechaDesde, ProveedorDesdeId, ProveedorHastaId);
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				int clienteId = 0;
				decimal saldo = default(decimal);
				decimal saldoFinal = default(decimal);
				dt = new DatFacturas().obtieneCxPMovimientosPorProveedores(Empresa.Id, FechaDesde, FechaHasta, ProveedorDesdeId, ProveedorHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta p = new EntEstadoDeCuenta();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.ClienteId = Convert.ToInt32(r["FAC_PROVEEDORID"]);
					p.Nombre = r["PROV_NOMBREFISCAL"].ToString();
					if (clienteId != p.ClienteId)
					{
						clienteId = p.ClienteId;
						if (lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList().Count == 0)
						{
							saldo = default(decimal);
						}
						else
						{
							saldo = lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p.ClienteId).ToList()[0].Descuento;
							saldoFinal += saldo;
						}
						p.SubTotal0 = saldo;
					}
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					if (p.TipoComprobanteId == 1)
					{
						p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
						saldo += p.Total;
						saldoFinal += p.Total;
					}
					else
					{
						p.SubTotal = Convert.ToDecimal(r["FAC_TOTAL"]);
						saldo -= p.SubTotal;
						saldoFinal -= p.SubTotal;
					}
					p.Descuento = saldo;
					p.Deposito = saldoFinal;
					lst.Add(p);
				}
				foreach (EntFactura f in lstSaldosIniciales)
				{
					if (lst.Where((EntEstadoDeCuenta P) => P.ClienteId == f.ClienteId).ToList().Count == 0)
					{
						saldoFinal += f.Descuento;
						lst.Add(new EntEstadoDeCuenta
						{
							ClienteId = f.ClienteId,
							Nombre = f.Nombre,
							SubTotal0 = f.Descuento,
							Deposito = saldoFinal
						});
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCxPMovimientosPorProveedoresPorFactura(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				List<EntFactura> lstSaldosIniciales = ObtieneSaldoAFechaProveedores(Empresa, FechaDesde, ProveedorDesdeId, ProveedorHastaId);
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				int clienteId = 0;
				decimal saldo = default(decimal);
				decimal saldoFinal = default(decimal);
				dt = new DatFacturas().obtieneCxPMovimientosPorProveedores(Empresa.Id, FechaDesde, FechaHasta, ProveedorDesdeId, ProveedorHastaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta p = new EntEstadoDeCuenta();
					p.EmisorNombre = Empresa.Nombre;
					p.EmisorRFC = Empresa.RFC;
					p.Id = Convert.ToInt32(r["FAC_ID"]);
					p.ClienteId = Convert.ToInt32(r["FAC_PROVEEDORID"]);
					p.Nombre = r["PROV_NOMBREFISCAL"].ToString();
					p.Fecha = Convert.ToDateTime(r["FAC_FECHA"]);
					p.SerieFactura = r["FAC_SERIEFACTURA"].ToString();
					p.NumeroFactura = r["FAC_NUMEROFACTURA"].ToString();
					p.UUID = r["FAC_UUID"].ToString();
					p.UUIDrelacionado = r["FAC_UUIDRELACIONADO"].ToString();
					p.Descripcion = r["FAC_CONCEPTO"].ToString();
					p.TipoComprobanteId = Convert.ToInt32(r["FAC_TIPOCOMPROBANTEID"]);
					if (p.TipoComprobanteId == 1)
					{
						p.Total = Convert.ToDecimal(r["FAC_TOTAL"]);
					}
					else
					{
						p.SubTotal = Convert.ToDecimal(r["FAC_TOTAL"]);
					}
					lst.Add(p);
				}
				foreach (EntEstadoDeCuenta p2 in (from P in lst
					orderby P.ClienteId, P.UUIDrelacionado, P.Fecha
					select P).ToList())
				{
					if (clienteId != p2.ClienteId)
					{
						clienteId = p2.ClienteId;
						if (lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p2.ClienteId).ToList().Count == 0)
						{
							saldo = default(decimal);
						}
						else
						{
							saldo = lstSaldosIniciales.Where((EntFactura P) => P.ClienteId == p2.ClienteId).ToList()[0].Descuento;
							saldoFinal += saldo;
						}
						p2.SubTotal0 = saldo;
					}
					if (p2.TipoComprobanteId == 1)
					{
						saldo += p2.Total;
						saldoFinal += p2.Total;
					}
					else
					{
						saldo -= p2.SubTotal;
						saldoFinal -= p2.SubTotal;
					}
					p2.Descuento = saldo;
					p2.Deposito = saldoFinal;
				}
				foreach (EntFactura f in lstSaldosIniciales)
				{
					if (lst.Where((EntEstadoDeCuenta P) => P.ClienteId == f.ClienteId).ToList().Count == 0)
					{
						saldoFinal += f.Descuento;
						lst.Add(new EntEstadoDeCuenta
						{
							ClienteId = f.ClienteId,
							Nombre = f.Nombre,
							SubTotal0 = f.Descuento,
							Deposito = saldoFinal
						});
					}
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscales(EntFactura Factura)
		{
			try
			{
				return new DatFacturasBKP33().agregaComprobanteFiscal(Factura.EmpresaId, Factura.TipoComprobanteId, Factura.ClienteId, Factura.SerieFactura, Factura.NumeroFactura, Factura.Fecha, Factura.IVARetenciones, Factura.ISRRetenciones, Factura.IVA, Factura.SubTotal, Factura.SubTotal0, Factura.Total, Factura.MonedaId, Factura.FormaPagoId, Factura.MetodoPagoId, Factura.UUID, Factura.Descripcion, Factura.FacturaRelacionId, Factura.UUIDrelacionado, Factura.TipoRelacionId, Factura.FechaPago, Factura.Ruta, Factura.PDF, Factura.XML, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscalesNeue(EntFactura Factura)
		{
			try
			{
				return new DatFacturasBKP33().agregaComprobanteFiscal(Factura.EmpresaId, Factura.TipoComprobanteId, Factura.ClienteId, Factura.SerieFactura, Factura.NumeroFactura, Factura.Fecha, Factura.IVARetenciones, Factura.ISRRetenciones, Factura.IVA, Factura.IEPS, Factura.SubTotal, Factura.SubTotal0, Factura.TotalPercepciones, Factura.TotalDeducciones, Factura.Total, Factura.MonedaId, Factura.FormaPagoId, Factura.MetodoPagoId, Factura.UUID, Factura.Descripcion, Factura.FacturaRelacionId, Factura.UUIDrelacionado, Factura.TipoRelacionId, Factura.FechaPago, Factura.FechaInicio, Factura.FechaFin, Factura.ClaveEntFed, Factura.TipoRegimen, Factura.Ruta, Factura.PDF, Factura.XML, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscalesEgreso(EntFactura Factura)
		{
			try
			{
				return new DatFacturasBKP33().agregaComprobanteFiscalEgreso(Factura.EmpresaId, Factura.TipoComprobanteId, Factura.ClienteId, Factura.SerieFactura, Factura.NumeroFactura, Factura.Fecha, Factura.IVARetenciones, Factura.ISRRetenciones, Factura.IVA, Factura.IEPS, Factura.SubTotal, Factura.SubTotal0, Factura.Total, Factura.MonedaId, Factura.FormaPagoId, Factura.MetodoPagoId, Factura.UUID, Factura.Descripcion, Factura.FacturaRelacionId, Factura.UUIDrelacionado, Factura.TipoRelacionId, Factura.FechaPago, Factura.Ruta, Factura.PDF, Factura.XML, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscalesPercepcion(EntCatalogoPercepciones FacturaPercepcion)
		{
			try
			{
				return new DatFacturas().agregaComprobanteFiscalPercepcion(FacturaPercepcion.Id, 0, FacturaPercepcion.Clave, FacturaPercepcion.Descripcion, FacturaPercepcion.Excento, FacturaPercepcion.Gravado, FacturaPercepcion.Total, FacturaPercepcion.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscalesDeduccion(EntCatalogoPercepciones FacturaPercepcion)
		{
			try
			{
				return new DatFacturas().agregaComprobanteFiscalDeduccion(FacturaPercepcion.Id, 0, FacturaPercepcion.Clave, FacturaPercepcion.Descripcion, 0m, FacturaPercepcion.Gravado, FacturaPercepcion.Total, FacturaPercepcion.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscalesNoDeposito(EntFactura Factura)
		{
			try
			{
				return new DatFacturas().agregaComprobanteFiscalNoDepositado(Factura.EmpresaId, Factura.Id, Factura.Fecha, Factura.Descuento, Factura.IVARetenciones, Factura.ISRRetenciones, Factura.IVA, Factura.SubTotal, Factura.SubTotal0, Factura.Total, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaComprobantesFiscalesNoDepositoEgresos(EntFactura Factura)
		{
			try
			{
				return new DatFacturas().agregaComprobanteFiscalNoDepositadoEgresos(Factura.EmpresaId, Factura.Id, Factura.Fecha, Factura.Descuento, Factura.IVARetenciones, Factura.ISRRetenciones, Factura.IVA, Factura.SubTotal, Factura.SubTotal0, Factura.Total, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusComprobanteFiscal(int FacturaId, int EstatusId)
		{
			try
			{
				new DatFacturas().actualizaEstatusComprobanteFiscal(FacturaId, EstatusId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusComprobanteFiscalEgresos(int FacturaId, int EstatusId)
		{
			try
			{
				new DatFacturas().actualizaEstatusComprobanteFiscalEgresos(FacturaId, EstatusId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusComprobanteFiscalNoDepositado(int FacturaId, bool Estatus)
		{
			try
			{
				new DatFacturas().actualizaEstatusComprobanteFiscalNoDepositado(FacturaId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusComprobanteFiscalNoDepositadoEgresos(int FacturaId, bool Estatus)
		{
			try
			{
				new DatFacturas().actualizaEstatusComprobanteFiscalNoDepositadoEgresos(FacturaId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalExcluyeFlujo(int FacturaId, bool ExcluyeFlujo)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalExcluyeFlujo(FacturaId, ExcluyeFlujo);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalEgresosDeducible(int FacturaId, bool Deducible)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalEgresosDeducible(FacturaId, Deducible);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusEstadoDeCuenta(int EstadoDeCuentaId, int EstatusId)
		{
			try
			{
				new DatFacturas().actualizaEstatusEstadoDeCuenta(EstadoDeCuentaId, EstatusId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusEstadoDeCuentaEgresos(int EstadoDeCuentaId, int EstatusId)
		{
			try
			{
				new DatFacturas().actualizaEstatusEstadoDeCuentaEgresos(EstadoDeCuentaId, EstatusId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusEstadoDeCuentaComprobantes(int EstadoDeCuentaId, bool Estatus)
		{
			try
			{
				new DatFacturas().actualizaEstatusEstadoDeCuentaCompronantes(EstadoDeCuentaId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusEstadoDeCuentaComprobantesEgresos(int EstadoDeCuentaId, bool Estatus)
		{
			try
			{
				new DatFacturas().actualizaEstatusEstadoDeCuentaCompronantesEgresos(EstadoDeCuentaId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalTipoRelacion(int FacturaId, int TipoRelacionId)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalTipoRelacion(FacturaId, TipoRelacionId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalTipoRelacionEgresos(int FacturaId, int TipoRelacionId)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalTipoRelacionEgresos(FacturaId, TipoRelacionId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalPagado(int FacturaId, bool Pagado)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalPagado(FacturaId, Pagado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalPagadoEgresos(int FacturaId, bool Pagado)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalPagadoEgresos(FacturaId, Pagado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalDepositado(int FacturaId, bool Depositado)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalDepositado(FacturaId, Depositado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaComprobanteFiscalDepositadoEgresos(int FacturaId, bool Depositado)
		{
			try
			{
				new DatFacturas().actualizaComprobanteFiscalDepositadoEgresos(FacturaId, Depositado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaEstadoDeCuenta(EntEstadoDeCuenta Factura)
		{
			try
			{
				return new DatFacturas().agregaEstadoDeCuenta(Factura.EmpresaId, Factura.BancoId, Factura.TipoComprobanteId, Factura.Fecha, Factura.Total, Factura.Descripcion, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaEstadoDeCuentaEgresos(EntEstadoDeCuenta Factura)
		{
			try
			{
				return new DatFacturas().agregaEstadoDeCuentaEgresos(Factura.EmpresaId, Factura.BancoId, Factura.TipoComprobanteId, Factura.Fecha, Factura.Total, Factura.Descripcion, Factura.UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AgregaEstadoDeCuentaComprobante(int EstadoDeCuentaId, EntFactura Factura)
		{
			try
			{
				new DatFacturas().agregaEstadoDeCuentaComprobante(EstadoDeCuentaId, Factura.Id, Factura.TipoComprobanteId, Factura.Pago, Factura.Folio, Factura.UUID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AgregaEstadoDeCuentaComprobanteEgresos(int EstadoDeCuentaId, EntFactura Factura)
		{
			try
			{
				new DatFacturas().agregaEstadoDeCuentaComprobanteEgresos(EstadoDeCuentaId, Factura.Id, Factura.TipoComprobanteId, Factura.Pago, Factura.Folio, Factura.UUID);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AgregaEstadoDeCuentaComprobante(int EstadoDeCuentaId, EntFactura Factura, decimal Pago, int FacturaRelacionadaId, string UUIDRelacionado)
		{
			try
			{
				new DatFacturas().agregaEstadoDeCuentaComprobante(EstadoDeCuentaId, Factura.Id, Pago, Factura.Folio, Factura.UUID, FacturaRelacionadaId, UUIDRelacionado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AgregaEstadoDeCuentaComprobanteEgresos(int EstadoDeCuentaId, EntFactura Factura, decimal Pago, int FacturaRelacionadaId, string UUIDRelacionado)
		{
			try
			{
				new DatFacturas().agregaEstadoDeCuentaComprobanteEgresos(EstadoDeCuentaId, Factura.Id, Pago, Factura.Folio, Factura.UUID, FacturaRelacionadaId, UUIDRelacionado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AgregaImporteDeclarado(int EmpresaId, decimal Importe, decimal IVA, DateTime Fecha, int UsuarioId)
		{
			try
			{
				new DatFacturas().agregaImporteDeclarado(EmpresaId, Importe, IVA, Fecha, UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AgregaImporteDeclaradoEgresos(int EmpresaId, decimal Importe, decimal IVA, DateTime Fecha, int UsuarioId)
		{
			try
			{
				new DatFacturas().agregaImporteDeclaradoEgresos(EmpresaId, Importe, IVA, Fecha, UsuarioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void VerificaComprobanteFiscalPagado(int ComprobanteFiscalId)
		{
			try
			{
				new DatFacturas().verificaComprobanteFiscalPagado(ComprobanteFiscalId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void VerificaComprobanteFiscalPagadoEgresos(int ComprobanteFiscalId)
		{
			try
			{
				new DatFacturas().verificaComprobanteFiscalPagadoEgresos(ComprobanteFiscalId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void VerificaComprobanteFiscalDepositado(int ComprobanteFiscalId)
		{
			try
			{
				new DatFacturas().verificaComprobanteFiscalDepositado(ComprobanteFiscalId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void VerificaComprobanteFiscalDepositadoEgresos(int ComprobanteFiscalId)
		{
			try
			{
				new DatFacturas().verificaComprobanteFiscalDepositadoEgresos(ComprobanteFiscalId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AumentaPagoComprobanteFiscal(int FacturaId, decimal Pago)
		{
			try
			{
				new DatFacturas().aumentaPagoComprobanteFiscal(FacturaId, Pago);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AumentaPagoComprobanteFiscalEgresos(int FacturaId, decimal Pago)
		{
			try
			{
				new DatFacturas().aumentaPagoComprobanteFiscalEgresos(FacturaId, Pago);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AumentaDepositoComprobanteFiscal(int FacturaId, decimal Deposito)
		{
			try
			{
				new DatFacturas().aumentaDepositoComprobanteFiscal(FacturaId, Deposito);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void AumentaDepositoComprobanteFiscalEgresos(int FacturaId, decimal Deposito)
		{
			try
			{
				new DatFacturas().aumentaDepositoComprobanteFiscalEgresos(FacturaId, Deposito);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
