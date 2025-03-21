using System;

namespace LeeXMLEntidades
{
	public abstract class EntAbstracta
	{
		public int Id { get; set; }

		public int UsuarioId { get; set; }

		public string Descripcion { get; set; }

		public bool Estatus { get; set; }

		public int EstatusId { get; set; }

		public string EstatusDescripcion { get; set; }

		public DateTime Fecha { get; set; }

		public DateTime FechaPago { get; set; }

		public string FechaPagoS { get; set; }

		public int EmpresaId { get; set; }
	}
}
