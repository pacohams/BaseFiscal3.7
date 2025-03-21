using System;

namespace LeeXMLEntidades
{
	public class EntCatalogoPercepciones : EntCatalogoGenerico
	{
		public int TipoClienteId { get; set; }

		public string CodigoDescripcion => base.Clave + " - " + base.Descripcion;

		public decimal Excento { get; set; }

		public decimal Gravado { get; set; }

		public decimal Total => Excento + Gravado;

		public bool ExcentoB { get; set; }

		public bool GravadoB { get; set; }

		public int ClienteId { get; set; }

		public string Cliente { get; set; }

		public string RFC { get; set; }

		public string SerieFactura { get; set; }

		public string NumeroFactura { get; set; }

		public string Folio => SerieFactura + " " + NumeroFactura;

		public string ClaveEntFed { get; set; }

		public string TipoRegimen { get; set; }

		public string FechaCorta { get; set; }

		public DateTime FechaInicio { get; set; }

		public DateTime FechaFin { get; set; }
	}
}
