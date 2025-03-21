using System;

namespace LeeXMLEntidades
{
	public class EntFactura : EntAbstracta
	{
		public int OrdenId { get; set; }

		public int ClienteId { get; set; }

		public int FacturaRelacionId { get; set; }

		public string SerieFactura { get; set; }

		public string NumeroFactura { get; set; }

		public string Folio => SerieFactura + " " + NumeroFactura;

		public string UUID { get; set; }

		public string UUIDrelacionado { get; set; }

		public int VersionCFDIId { get; set; }

		public string VersionCFDI { get; set; }

		public int BancoId { get; set; }

		public string Banco { get; set; }

		public int TipoComprobanteId { get; set; }

		public string TipoComprobante { get; set; }

		public int MonedaId { get; set; }

		public string Moneda { get; set; }

		public int MetodoPagoId { get; set; }

		public string MetodoPago { get; set; }

		public int FormaPagoId { get; set; }

		public string FormaPago { get; set; }

		public int UsoCFDIId { get; set; }

		public string UsoCFDI { get; set; }

		public int TipoRelacionId { get; set; }

		public string TipoRelacion { get; set; }

		public string ClaveEntFed { get; set; }

		public string Ruta { get; set; }

		public byte[] PDF { get; set; }

		public byte[] XML { get; set; }

		public string Nombre { get; set; }

		public string RFC { get; set; }

		public string RegimenFiscal { get; set; }

		public string EmisorNombre { get; set; }

		public string EmisorRFC { get; set; }

		public string EmisorRegimenFiscal { get; set; }

		public decimal TipoCambio { get; set; }

		public decimal EquivalenciaDR { get; set; }

		public decimal SubTotal { get; set; }

		public decimal SubTotal0 { get; set; }

		public decimal Total { get; set; }

		public decimal TotalUSD { get; set; }

		public decimal TotalPercepciones { get; set; }

		public decimal TotalDeducciones { get; set; }

		public decimal Pago { get; set; }

		public decimal Deposito { get; set; }

		public decimal Descuento { get; set; }

		public decimal Base => SubTotal - Descuento;

		public int TipoEstructuraImpuestoId { get; set; }

		public int TipoImpuestoId { get; set; }

		public int TipoFactorId { get; set; }

		public string TipoFactor { get; set; }

		public decimal TasaOCuota { get; set; }

		public decimal ImporteDR { get; set; }

		public decimal IVA { get; set; }

		public decimal IEPS { get; set; }

		public decimal IVARetenciones { get; set; }

		public decimal ISRRetenciones { get; set; }

		public decimal Retenciones { get; set; }

		public decimal ImpuestosLocales { get; set; }

		public int ObjetoImpuestoId { get; set; }

		public string ObjetoImpuesto { get; set; }

		public decimal ObjetoImpuesto01 { get; set; }

		public decimal ObjetoImpuesto02 { get; set; }

		public decimal ObjetoImpuesto03 { get; set; }

		public decimal ObjetoImpuesto04 { get; set; }

		public int TipoRegimenId { get; set; }

		public string TipoRegimen { get; set; }

		public string TipoPercepcion { get; set; }

		public string ConceptoPercepcion { get; set; }

		public decimal PercepcionExento { get; set; }

		public decimal PercepcionGravado { get; set; }

		public string PercepcionExentoS { get; set; }

		public string PercepcionGravadoS { get; set; }

		public string TipoDeduccion { get; set; }

		public string ConceptoDeduccion { get; set; }

		public decimal Deduccion { get; set; }

		public string DeduccionS { get; set; }

		public string PagoS { get; set; }

		public bool Pagado { get; set; }

		public bool Depositado { get; set; }

		public bool Deducible { get; set; }

		public bool ExcluyeFlujo { get; set; }

		public DateTime FechaInicio { get; set; }

		public DateTime FechaFin { get; set; }
	}
}
