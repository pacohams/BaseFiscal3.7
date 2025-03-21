namespace LeeXMLEntidades
{
	public class EntEmpresaISR : EntAbstracta
	{
		public int Año { get; set; }

		public int Mes { get; set; }

		public int TipoRegimenId { get; set; }

		public decimal OtrosIngresosAcumulables { get; set; }

		public decimal RepAcumulados2021Anteriores { get; set; }

		public decimal IngresosCobradosNoAcumulables { get; set; }

		public decimal IngresosCobrados { get; set; }

		public decimal PerdidasFiscalesAmortizar { get; set; }

		public int TasaIsrId { get; set; }

		public decimal PagosProvisionalesAnteriores { get; set; }

		public decimal DeduccionesSinCFDI { get; set; }

		public decimal DeduccionPago { get; set; }

		public decimal OtrosGastosPagadosNoDeducibles { get; set; }

		public decimal DeduccionesPagadas { get; set; }

		public int BaseFechaId { get; set; }

		public int PorcentajeDeducibleId { get; set; }

		public decimal NominaDeducible { get; set; }
	}
}
