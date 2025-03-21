using System;

namespace LeeXMLEntidades
{
	public class EntUsuario : EntCatalogoGenerico
	{
		public int CompañiaId { get; set; }

		public int AñoInicial { get; set; }

		public int LimiteEmpresas { get; set; }

		public int TipoUsuarioId { get; set; }

		public string Usuario { get; set; }

		public string Contraseña { get; set; }

		public bool Administrador { get; set; }

		public DateTime FechaLimite { get; set; }

		public DateTime FechaActivacion { get; set; }

		public int Activaciones { get; set; }

		public int TipoLicenciaId { get; set; }

		public int LicenciaId { get; set; }

		public string LicenciaSerial { get; set; }

		public TimeSpan DiasExpiracion => FechaLimite - base.Fecha;

		public bool Activado { get; set; }

		public bool Caducado { get; set; }
	}
}
