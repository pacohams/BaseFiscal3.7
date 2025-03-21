using System;
using System.Collections.Generic;
using System.Data;
using LeeXMLEntidades;
using LeeXMLsDatos;

namespace LeeXMLNegocio
{
	public class BusEmpresas : BusAbstracta
	{
		public List<EntCatalogoGenerico> ObtieneUltimaVersion(int SoftwareId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneUltimaVersion(SoftwareId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["VER_ID"]);
					m.Clave = r["VER_VERSION"].ToString();
					m.Descripcion = r["VER_VERSION"].ToString();
					m.Fecha = Convert.ToDateTime(r["VER_FECHA"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEmpresa> ObtieneEmpresas(int CompañiaId, int LimiteEmpresas)
		{
			try
			{
				List<EntEmpresa> lst = new List<EntEmpresa>();
				dt = new DatEmpresas().obtieneEmpresas(CompañiaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEmpresa m = new EntEmpresa();
					m.Id = Convert.ToInt32(r["EMP_ID"]);
					m.TipoPersonaId = Convert.ToInt32(r["EMP_TIPOPERSONAID"]);
					m.Descripcion = r["EMP_NOMBRE"].ToString();
					m.Nombre = r["EMP_NOMBRE"].ToString();
					m.NombreFiscal = r["EMP_NOMBREFISCAL"].ToString();
					m.RegimenFiscal = r["EMP_REGIMENFISCAL"].ToString();
					m.RFC = r["EMP_RFC"].ToString().ToUpper();
					m.Logo = r["EMP_LOGO"].ToString();
					m.NoCertificado = r["EMP_NOCERTIFICADO"].ToString();
					m.Key = r["EMP_KEYRUTA"].ToString();
					m.KeyRecibidos = r["EMP_KEYRUTARECIBIDOS"].ToString();
					m.TipoFactorId = Convert.ToInt32(r["EMP_TIPOFACTORID"]);
					m.TipoFactor = r["CATFAC_DESCRIPCION"].ToString();
					m.TasaOCuota = Convert.ToDecimal(r["EMP_TASAOCUOTA"]);
					m.Fecha = Convert.ToDateTime(r["EMP_FECHAREGISTRO"]);
					m.RegimenFiscalId = Convert.ToInt32(r["EMP_REGIMENFISCALID"]);
					m.RegimenFiscal = r["CATREG_DESCRIPCION"].ToString();
					m.UsoCFDIId = Convert.ToInt32(r["EMP_USOCFDIID"]);
					m.ExcluyeNc01 = Convert.ToBoolean(r["EMP_EXCLUYENC01"]);
					m.ExcluyeNc03 = Convert.ToBoolean(r["EMP_EXCLUYENC03"]);
					m.LicenciaId = Convert.ToInt32(r["EMP_LICENCIAID"]);
					m.LicenciaSerial = r["LICGEN_KEY"].ToString();
					m.Activaciones = Convert.ToInt32(r["LICGEN_ACTIVACIONES"]);
					m.LimiteEmpresas = Convert.ToInt32(r["TIPLIC_LIMITEEMPRESAS"]);
					m.DiasExpiracionTS = Convert.ToDateTime(r["LICGEN_FECHACADUCA"]) - Convert.ToDateTime(r["FECHAACTUAL"]);
					m.DiasExpiracion = m.DiasExpiracionTS.Days;
					m.Certificado = r["EMP_CERTIFICADORUTA"].ToString();
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEmpresa> ObtieneEmpresasActivas(int CompañiaId)
		{
			try
			{
				List<EntEmpresa> lst = new List<EntEmpresa>();
				dt = new DatEmpresas().obtieneEmpresasActivas(CompañiaId);
				foreach (DataRow r in dt.Rows)
				{
					EntEmpresa m = new EntEmpresa();
					m.Id = Convert.ToInt32(r["EMP_ID"]);
					m.TipoPersonaId = Convert.ToInt32(r["EMP_TIPOPERSONAID"]);
					m.Descripcion = r["EMP_NOMBRE"].ToString();
					m.Nombre = r["EMP_NOMBRE"].ToString();
					m.NombreFiscal = r["EMP_NOMBREFISCAL"].ToString();
					m.RegimenFiscal = r["EMP_REGIMENFISCAL"].ToString();
					m.RFC = r["EMP_RFC"].ToString().ToUpper();
					m.Logo = r["EMP_LOGO"].ToString();
					m.NoCertificado = r["EMP_NOCERTIFICADO"].ToString();
					m.Key = r["EMP_KEYRUTA"].ToString();
					m.KeyRecibidos = r["EMP_KEYRUTARECIBIDOS"].ToString();
					m.TipoFactorId = Convert.ToInt32(r["EMP_TIPOFACTORID"]);
					m.TipoFactor = r["CATFAC_DESCRIPCION"].ToString();
					m.TasaOCuota = Convert.ToDecimal(r["EMP_TASAOCUOTA"]);
					m.Fecha = Convert.ToDateTime(r["EMP_FECHAREGISTRO"]);
					m.RegimenFiscalId = Convert.ToInt32(r["EMP_REGIMENFISCALID"]);
					m.RegimenFiscal = r["CATREG_DESCRIPCION"].ToString();
					m.UsoCFDIId = Convert.ToInt32(r["EMP_USOCFDIID"]);
					m.ExcluyeNc01 = Convert.ToBoolean(r["EMP_EXCLUYENC01"]);
					m.ExcluyeNc03 = Convert.ToBoolean(r["EMP_EXCLUYENC03"]);
					m.LicenciaId = Convert.ToInt32(r["EMP_LICENCIAID"]);
					m.LicenciaSerial = r["LICGEN_KEY"].ToString();
					m.Activaciones = Convert.ToInt32(r["LICGEN_ACTIVACIONES"]);
					m.DiasExpiracionTS = Convert.ToDateTime(r["LICGEN_FECHACADUCA"]) - Convert.ToDateTime(r["FECHAACTUAL"]);
					m.DiasExpiracion = m.DiasExpiracionTS.Days;
					m.Certificado = r["EMP_CERTIFICADORUTA"].ToString();
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneBancos(int EmpresaId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneBancos(EmpresaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["BAN_ID"]);
					m.Clave = r["BAN_CLAVE"].ToString();
					m.Descripcion = r["BAN_DESCRIPCION"].ToString();
					m.EmpresaId = EmpresaId;
					m.Estatus = Convert.ToBoolean(r["BAN_ESTATUS"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntEmpresaISR ObtieneEmpresaISR(int EmpresaId, int TipoRegimenId, int Año, int Mes)
		{
			try
			{
				EntEmpresaISR m = new EntEmpresaISR();
				dt = new DatEmpresas().obtieneEmpresasISR(EmpresaId, TipoRegimenId, Año, Mes);
				foreach (DataRow r in dt.Rows)
				{
					m.Id = Convert.ToInt32(r["EMPISR_ID"]);
					m.EmpresaId = EmpresaId;
					m.OtrosIngresosAcumulables = Convert.ToDecimal(r["EMPISR_OTROSINGRESOSACUMULABLES"]);
					m.RepAcumulados2021Anteriores = Convert.ToDecimal(r["EMPISR_REPACUMULADOS2021ANTERIORES"]);
					m.IngresosCobradosNoAcumulables = Convert.ToDecimal(r["EMPISR_INGRESOSCOBRADOSNOACUMULABLES"]);
					m.IngresosCobrados = Convert.ToDecimal(r["EMPISR_INGRESOSCOBRADOS"]);
					m.PerdidasFiscalesAmortizar = Convert.ToDecimal(r["EMPISR_PERDIDASFISCALESAMORTIZAR"]);
					m.TasaIsrId = Convert.ToInt32(r["EMPISR_TASAISRID"]);
					m.PagosProvisionalesAnteriores = Convert.ToDecimal(r["EMPISR_PAGOSPROVISIONALESANTERIORES"]);
					m.DeduccionesSinCFDI = Convert.ToDecimal(r["EMPISR_DEDUCCIONESSINCFDI"]);
					m.DeduccionPago = Convert.ToDecimal(r["EMPISR_DEDUCCIONPAGO"]);
					m.OtrosGastosPagadosNoDeducibles = Convert.ToDecimal(r["EMPISR_OTROSGASTOSPAGADOSNODEDUCIBLES"]);
					m.DeduccionesPagadas = Convert.ToDecimal(r["EMPISR_DEDUCCIONESPAGADAS"]);
					m.BaseFechaId = Convert.ToInt32(r["EMPISR_BASEFECHAID"]);
					m.PorcentajeDeducibleId = Convert.ToInt32(r["EMPISR_PORCENTAJEDEDUCIBLEID"]);
					m.NominaDeducible = Convert.ToDecimal(r["EMPISR_NOMINANODEDUCIBLE"]);
				}
				return m;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntCatalogoGenerico ObtieneEmpresaISR(int EmpresaId, int TipoRegimenId, int Año, int MesDesde, int MesHasta)
		{
			try
			{
				EntCatalogoGenerico m = new EntCatalogoGenerico
				{
					Clave = ""
				};
				dt = new DatEmpresas().obtieneEmpresasISR(EmpresaId, TipoRegimenId, Año, MesDesde, MesHasta);
				decimal deduccionesPagadas = default(decimal);
				decimal ingresosCobrados = default(decimal);
				foreach (DataRow r in dt.Rows)
				{
					m.Id = Convert.ToInt32(r["EMPISR_ID"]);
					ingresosCobrados = Convert.ToDecimal(r["EMPISR_INGRESOSCOBRADOS"]);
					deduccionesPagadas += Convert.ToDecimal(r["EMPISR_DEDUCCIONESPAGADAS"]);
					m.EmpresaId = EmpresaId;
				}
				m.Descripcion = ingresosCobrados.ToString();
				m.Clave = deduccionesPagadas.ToString();
				return m;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtienePaginasDescarga()
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtienePaginasDescarga();
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["PAGDES_ID"]);
					m.Clave = r["PAGDES_PAGINA"].ToString();
					m.Descripcion = r["PAGDES_PAGINA"].ToString();
					m.Estatus = Convert.ToBoolean(r["PAGDES_ESTATUS"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtienePaginasDescarga(int PaginaId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtienePaginasDescarga(PaginaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["PAGDES_ID"]);
					m.Clave = r["PAGDES_PAGINA"].ToString();
					m.Descripcion = r["PAGDES_PAGINA"].ToString();
					m.Estatus = Convert.ToBoolean(r["PAGDES_ESTATUS"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaEmpresa(EntEmpresa Empresa)
		{
			try
			{
				return new DatEmpresas().agregaEmpresa(Empresa.CompañiaId, Empresa.TipoPersonaId, Empresa.Nombre, Empresa.NombreFiscal, Empresa.RegimenFiscal, Empresa.Direccion, Empresa.Calle, Empresa.NoExterior, Empresa.NoInterior, Empresa.Colonia, Empresa.Localidad, Empresa.Municipio, Empresa.Estado, Empresa.CP, Empresa.Telefono, Empresa.Telefono2, Empresa.RFC, Empresa.Email, Empresa.Banco, Empresa.NumeroCuenta, Empresa.Sucursal, Empresa.CLABE, Empresa.NumeroReferencia, Empresa.Certificado, Empresa.Key, Empresa.KeyRecibidos, Empresa.NoCertificado, Empresa.RegimenFiscalId, Empresa.TipoFactorId, Empresa.TasaOCuota, Empresa.UsoCFDIId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaBanco(EntCatalogoGenerico Banco)
		{
			try
			{
				return new DatEmpresas().agregaBanco(Banco.EmpresaId, Banco.Clave, Banco.Descripcion, 1);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaEmpresaISR(int EmpresaId, int Año, int Mes, int TipoRegimenId, decimal OtrosIngresosAcumulables, decimal RepAcumulados2021Anteriores, decimal IngresosCobradosNoAcumulables, decimal IngresosCobrados, decimal PerdidasFiscalesAmortizar, int TasaIsrId, decimal PagosProvisionalesAnteriores, decimal DeduccionesSinCFDI, decimal DeduccionPago, decimal OtrosGastosPagadosNoDeducibles, decimal DeduccionesPagadas, int BaseFechaId, int PorcentajeDeducibleId, decimal NominaDeducible)
		{
			try
			{
				return new DatEmpresas().agregaEmpresaISR(EmpresaId, Año, Mes, TipoRegimenId, OtrosIngresosAcumulables, RepAcumulados2021Anteriores, IngresosCobradosNoAcumulables, IngresosCobrados, PerdidasFiscalesAmortizar, TasaIsrId, PagosProvisionalesAnteriores, DeduccionesSinCFDI, DeduccionPago, OtrosGastosPagadosNoDeducibles, DeduccionesPagadas, BaseFechaId, PorcentajeDeducibleId, NominaDeducible);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEmpresa(EntEmpresa Empresa)
		{
			try
			{
				return new DatEmpresas().actualizaEmpresa(Empresa.Id, Empresa.TipoPersonaId, Empresa.Nombre, Empresa.NombreFiscal, Empresa.RegimenFiscal, Empresa.Direccion, Empresa.Calle, Empresa.NoExterior, Empresa.NoInterior, Empresa.Colonia, Empresa.Localidad, Empresa.Municipio, Empresa.Estado, Empresa.CP, Empresa.Telefono, Empresa.Telefono2, Empresa.RFC, Empresa.Email, Empresa.Banco, Empresa.NumeroCuenta, Empresa.Sucursal, Empresa.CLABE, Empresa.NumeroReferencia, Empresa.Certificado, Empresa.Key, Empresa.KeyRecibidos, Empresa.NoCertificado, Empresa.RegimenFiscalId, Empresa.TipoFactorId, Empresa.TasaOCuota, Empresa.UsoCFDIId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEmpresaCIEC(EntEmpresa Empresa)
		{
			try
			{
				return new DatEmpresas().actualizaEmpresaCIEC(Empresa.Id, Empresa.Certificado);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEmpresaExcluyeNc(EntEmpresa Empresa)
		{
			try
			{
				return new DatEmpresas().actualizaEmpresaExcluyeNc(Empresa.Id, Empresa.ExcluyeNc01, Empresa.ExcluyeNc03);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEmpresaLicencia(EntEmpresa Empresa)
		{
			try
			{
				return new DatEmpresas().actualizaEmpresaLicencia(Empresa.Id, Empresa.LicenciaId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaBanco(EntCatalogoGenerico Banco)
		{
			try
			{
				return new DatEmpresas().actualizaBanco(Banco.Id, Banco.Clave, Banco.Descripcion, 1);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEstatusEmpresa(EntEmpresa Empresa)
		{
			try
			{
				return new DatEmpresas().actualizaEstatusEmpresa(Empresa.Id, Empresa.Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEstatusBanco(int BancoId, bool Estatus)
		{
			try
			{
				return new DatEmpresas().actualizaEstatusBanco(BancoId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaEmpresaISR(int EmpresaId, int Año, int Mes, int TipoRegimenId, decimal OtrosIngresosAcumulables, decimal RepAcumulados2021Anteriores, decimal IngresosCobradosNoAcumulables, decimal IngresosCobrados, decimal PerdidasFiscalesAmortizar, int TasaIsrId, decimal PagosProvisionalesAnteriores, decimal DeduccionesSinCFDI, decimal DeduccionPago, decimal OtrosGastosPagadosNoDeducibles, decimal DeduccionesPagadas, int BaseFechaId, int PorcentajeDeducibleId, decimal NominaDeducible)
		{
			try
			{
				return new DatEmpresas().actualizaEmpresaISR(EmpresaId, Año, Mes, TipoRegimenId, OtrosIngresosAcumulables, RepAcumulados2021Anteriores, IngresosCobradosNoAcumulables, IngresosCobrados, PerdidasFiscalesAmortizar, TasaIsrId, PagosProvisionalesAnteriores, DeduccionesSinCFDI, DeduccionPago, OtrosGastosPagadosNoDeducibles, DeduccionesPagadas, BaseFechaId, PorcentajeDeducibleId, NominaDeducible);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneProductosServicios(int EmpresaId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneProductosServicios(EmpresaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["CATPRO_ID"]);
					m.Clave = r["CATPRO_CLAVE"].ToString();
					m.Descripcion = r["CATPRO_DESCRIPCION"].ToString();
					m.EmpresaId = Convert.ToInt32(r["EMPPROSER_ID"]);
					m.Estatus = Convert.ToBoolean(r["EMPPROSER_ESTATUS"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneUnidades(int EmpresaId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneUnidades(EmpresaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["CATUNI_ID"]);
					m.Clave = r["CATUNI_CLAVE"].ToString();
					m.Descripcion = r["CATUNI_DESCRIPCION"].ToString();
					m.EmpresaId = Convert.ToInt32(r["EMPUNI_ID"]);
					m.Estatus = Convert.ToBoolean(r["EMPUNI_ESTATUS"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneCatalogoRegimen()
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneCatalogoRegimen();
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["CATREG_ID"]);
					m.Descripcion = r["CATREG_ID"].ToString() + " - " + r["CATREG_DESCRIPCION"].ToString();
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneCatalogoUsoCFDI()
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneCatalogoUsoCFDI();
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["CATUSO_ID"]);
					m.Clave = r["CATUSO_CLAVE"].ToString();
					m.Descripcion = r["CATUSO_CLAVE"].ToString() + " - " + r["CATUSO_DESCRIPCION"].ToString();
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneTiposMovimientos(int EmpresaId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneTiposMovimientos(EmpresaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["TIPMOV_ID"]);
					m.Descripcion = r["TIPMOV_DESCRIPCION"].ToString();
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCatalogoGenerico> ObtieneTiposMovimientosEgreso(int EmpresaId)
		{
			try
			{
				List<EntCatalogoGenerico> lst = new List<EntCatalogoGenerico>();
				dt = new DatEmpresas().obtieneTiposMovimientosEgreso(EmpresaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCatalogoGenerico m = new EntCatalogoGenerico();
					m.Id = Convert.ToInt32(r["TIPMOV_ID"]);
					m.Descripcion = r["TIPMOV_DESCRIPCION"].ToString();
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCatalogoISR(int TipoRegimenId, int TipoPeriodoId)
		{
			try
			{
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				dt = new DatEmpresas().obtieneCatalogoISR(TipoRegimenId, TipoPeriodoId);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta m = new EntEstadoDeCuenta();
					m.Id = Convert.ToInt32(r["CATISR_ID"]);
					m.SubTotal = Convert.ToDecimal(r["CATISR_LIMITEINFERIOR"]);
					m.Total = Convert.ToDecimal(r["CATISR_LIMITESUPERIOR"]);
					m.Retenciones = Convert.ToDecimal(r["CATISR_CUOTAFIJA"]);
					m.IVA = Convert.ToDecimal(r["CATISR_PORCENTAJE"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntEstadoDeCuenta> ObtieneCatalogoISR(int TipoRegimenId, int TipoPeriodoId, int PeriodoId, int Año)
		{
			try
			{
				List<EntEstadoDeCuenta> lst = new List<EntEstadoDeCuenta>();
				dt = new DatEmpresas().obtieneCatalogoISR(TipoRegimenId, TipoPeriodoId, PeriodoId, Año);
				foreach (DataRow r in dt.Rows)
				{
					EntEstadoDeCuenta m = new EntEstadoDeCuenta();
					m.Id = Convert.ToInt32(r["CATISR_ID"]);
					m.SubTotal = Convert.ToDecimal(r["CATISR_LIMITEINFERIOR"]);
					m.Total = Convert.ToDecimal(r["CATISR_LIMITESUPERIOR"]);
					m.Retenciones = Convert.ToDecimal(r["CATISR_CUOTAFIJA"]);
					m.IVA = Convert.ToDecimal(r["CATISR_PORCENTAJE"]);
					lst.Add(m);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaEmpresaProductoServicio(int EmpresaId, int ProductoServicioId)
		{
			try
			{
				return new DatEmpresas().agregaEmpresaProductoServicio(EmpresaId, ProductoServicioId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusEmpresaProductoServicio(int EmpresaId, int ProductoServicioId, bool Estatus)
		{
			try
			{
				new DatEmpresas().actualizaEstatusEmpresaProductoServicio(EmpresaId, ProductoServicioId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void EliminaEmpresaProductoServicio(int EmpresaId)
		{
			try
			{
				new DatEmpresas().eliminaEmpresaProductoServicio(EmpresaId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaEmpresaUnidad(int EmpresaId, int UnidadId)
		{
			try
			{
				return new DatEmpresas().agregaEmpresaUnidad(EmpresaId, UnidadId);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void ActualizaEstatusEmpresaUnidad(int EmpresaId, int UnidadId, bool Estatus)
		{
			try
			{
				new DatEmpresas().actualizaEstatusEmpresaUnidad(EmpresaId, UnidadId, Estatus);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
