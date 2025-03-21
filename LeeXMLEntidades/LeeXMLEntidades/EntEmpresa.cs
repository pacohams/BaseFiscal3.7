using System;

namespace LeeXMLEntidades
{
	public class EntEmpresa : EntAbstracta
	{
		public int CompañiaId { get; set; }

		public string Nombre { get; set; }

		public string NombreFiscal { get; set; }

		public int RegimenFiscalId { get; set; }

		public string RegimenFiscal { get; set; }

		public string Direccion { get; set; }

		public string Telefono { get; set; }

		public string Telefono2 { get; set; }

		public string Email { get; set; }

		public string Contacto { get; set; }

		public string TelefonoContacto { get; set; }

		public string Banco { get; set; }

		public string NumeroCuenta { get; set; }

		public string Sucursal { get; set; }

		public string CLABE { get; set; }

		public string NumeroReferencia { get; set; }

		public decimal Deuda { get; set; }

		public decimal Pago { get; set; }

		public decimal NotasCredito { get; set; }

		public decimal Saldo => Deuda - Pago - NotasCredito;

		public string NombreLegal { get; set; }

		public string Celular { get; set; }

		public string RFC { get; set; }

		public string Calle { get; set; }

		public string NoExterior { get; set; }

		public string NoInterior { get; set; }

		public string Colonia { get; set; }

		public string Localidad { get; set; }

		public string Municipio { get; set; }

		public string Estado { get; set; }

		public string CP { get; set; }

		public int TipoPersonaId { get; set; }

		public int TipoFactorId { get; set; }

		public string TipoFactor { get; set; }

		public decimal TasaOCuota { get; set; }

		public string NoCertificado { get; set; }

		public string Certificado { get; set; }

		public string Key { get; set; }

		public string KeyRecibidos { get; set; }

		public string Logo { get; set; }

		public int UsoCFDIId { get; set; }

		public bool ExcluyeNc01 { get; set; }

		public bool ExcluyeNc03 { get; set; }

		public int LicenciaId { get; set; }

		public string LicenciaSerial { get; set; }

		public int DiasExpiracion { get; set; }

		public int Activaciones { get; set; }

		public int LimiteEmpresas { get; set; }

		public TimeSpan DiasExpiracionTS { get; set; }
	}
}
