using System.Collections.Generic;

namespace LeeXMLEntidades
{
	public class EntResponseSATjson : EntCatalogoGenerico
	{
		public string solicitud { get; set; }

		public string codigo { get; set; }

		public string mensaje { get; set; }

		public string respuesta { get; set; }

		public List<razonesSociales> razonesSociales { get; set; }
	}
}
