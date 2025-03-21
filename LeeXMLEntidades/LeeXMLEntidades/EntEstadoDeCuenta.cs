using System.Collections.Generic;

namespace LeeXMLEntidades
{
	public class EntEstadoDeCuenta : EntFactura
	{
		public List<EntFactura> ListaComprobantes { get; set; }
	}
}
