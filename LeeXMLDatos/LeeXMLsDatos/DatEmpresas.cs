using System;
using System.Data;
using System.Data.SqlClient;

namespace LeeXMLsDatos
{
	public class DatEmpresas : DatAbstracta
	{
		public DataTable obtieneUltimaVersion(int SoftwareId)
		{
			try
			{
				com = new SqlCommand("selUltimaVersion", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("SoftwareId", SoftwareId);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneEmpresas(int Compañia)
		{
			try
			{
				com = new SqlCommand("selObtieneEmpresasPorCompañia", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", Compañia);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneEmpresasActivas(int Compañia)
		{
			try
			{
				com = new SqlCommand("[selObtieneEmpresasActivasPorCompañia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", Compañia);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtienePagosEmpresas(DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("selObtienePagosEmpresasPorFechaPago", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneNotasCreditoEmpresas(DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("selObtieneNotasCreditoEmpresasPorFecha", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneBancos(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneBancosPorEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneEmpresasISR(int EmpresaId, int TipoRegimenId, int Año, int Mes)
		{
			try
			{
				com = new SqlCommand("[selObtieneEmpresasISR]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoRegimenId", TipoRegimenId);
				com.Parameters.AddWithValue("Año", Año);
				com.Parameters.AddWithValue("Mes", Mes);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneEmpresasISR(int EmpresaId, int TipoRegimenId, int Año, int MesDesde, int MesHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneEmpresasISRPorMeses]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoRegimenId", TipoRegimenId);
				com.Parameters.AddWithValue("Año", Año);
				com.Parameters.AddWithValue("MesDesde", MesDesde);
				com.Parameters.AddWithValue("MesHasta", MesHasta);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneCatalogoISR(int TipoRegimenId, int TipoPeriodoId)
		{
			try
			{
				com = new SqlCommand("[selCatalogoISRporTipoRegimenPeriodo]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("TipoRegimenId", TipoRegimenId);
				com.Parameters.AddWithValue("TipoPeriodoId", TipoPeriodoId);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneCatalogoISR(int TipoRegimenId, int TipoPeriodoId, int PeriodoId, int Año)
		{
			try
			{
				com = new SqlCommand("[selCatalogoISRporTipoRegimenPeriodoAño]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("TipoRegimenId", TipoRegimenId);
				com.Parameters.AddWithValue("TipoPeriodoId", TipoPeriodoId);
				com.Parameters.AddWithValue("PeriodoId", PeriodoId);
				com.Parameters.AddWithValue("Año", Año);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtienePaginasDescarga()
		{
			try
			{
				com = new SqlCommand("[selPaginasDescarga]", con);
				com.CommandType = CommandType.StoredProcedure;
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtienePaginasDescarga(int PaginaId)
		{
			try
			{
				com = new SqlCommand("[selPaginasDescargaPorId]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("PaginaId", PaginaId);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int agregaEmpresa(int CompañiaId, int TipoPersonaId, string Nombre, string NombreFiscal, string RegimenFiscal, string Direccion, string Calle, string NoExterior, string NoInterior, string Colonia, string Localidad, string Municipio, string Estado, string CP, string Telefono, string Telefono2, string RFC, string Email, string Banco, string NumeroCuenta, string Sucursal, string CLABE, string NumeroReferencia, string Certificado, string Key, string KeyRecibidos, string NoCertificado, int RegimenFiscalId, int TipoFactorId, decimal TasaOCuota, int UsoCFDIId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaEmpresaConCompañia", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
				com.Parameters.AddWithValue("TipoPersonaId", TipoPersonaId);
				com.Parameters.AddWithValue("Nombre", Nombre);
				com.Parameters.AddWithValue("NombreFiscal", NombreFiscal);
				com.Parameters.AddWithValue("RegimenFiscal", RegimenFiscal);
				com.Parameters.AddWithValue("Direccion", Direccion);
				com.Parameters.AddWithValue("Calle", Calle);
				com.Parameters.AddWithValue("NoExterior", NoExterior);
				com.Parameters.AddWithValue("NoInterior", NoInterior);
				com.Parameters.AddWithValue("Colonia", Colonia);
				com.Parameters.AddWithValue("Localidad", Localidad);
				com.Parameters.AddWithValue("Municipio", Municipio);
				com.Parameters.AddWithValue("Estado", Estado);
				com.Parameters.AddWithValue("CP", CP);
				com.Parameters.AddWithValue("Telefono", Telefono);
				com.Parameters.AddWithValue("Telefono2", Telefono2);
				com.Parameters.AddWithValue("RFC", RFC);
				com.Parameters.AddWithValue("Email", Email);
				com.Parameters.AddWithValue("Banco", Banco);
				com.Parameters.AddWithValue("NumeroCuenta", NumeroCuenta);
				com.Parameters.AddWithValue("Sucursal", Sucursal);
				com.Parameters.AddWithValue("CLABE", CLABE);
				com.Parameters.AddWithValue("NumeroReferencia", NumeroReferencia);
				com.Parameters.AddWithValue("CertificadoRuta", Certificado);
				com.Parameters.AddWithValue("KeyRuta", Key);
				com.Parameters.AddWithValue("KeyRutaRecibidos", KeyRecibidos);
				com.Parameters.AddWithValue("NoCertificado", NoCertificado);
				com.Parameters.AddWithValue("RegimenFiscalId", RegimenFiscalId);
				com.Parameters.AddWithValue("TipoFactorId", TipoFactorId);
				com.Parameters.AddWithValue("TasaOCuota", TasaOCuota);
				com.Parameters.AddWithValue("UsoCFDIId", UsoCFDIId);
				SqlParameter parm = new SqlParameter("Id", Id);
				parm.Direction = ParameterDirection.InputOutput;
				com.Parameters.Add(parm);
				con.Open();
				com.ExecuteNonQuery();
				return Convert.ToInt32(com.Parameters["Id"].Value);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int agregaBanco(int EmpresaId, string Clave, string Descripcion, int Prioridad)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaBanco", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Clave", Clave);
				com.Parameters.AddWithValue("Descripcion", Descripcion);
				com.Parameters.AddWithValue("Prioridad", Prioridad);
				SqlParameter parm = new SqlParameter("Id", Id);
				parm.Direction = ParameterDirection.InputOutput;
				com.Parameters.Add(parm);
				con.Open();
				com.ExecuteNonQuery();
				return Convert.ToInt32(com.Parameters["Id"].Value);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int agregaEmpresaISR(int EmpresaId, int Año, int Mes, int TipoRegimenId, decimal OtrosIngresosAcumulables, decimal RepAcumulados2021Anteriores, decimal IngresosCobradosNoAcumulables, decimal IngresosCobrados, decimal PerdidasFiscalesAmortizar, int TasaIsrId, decimal PagosProvisionalesAnteriores, decimal DeduccionesSinCFDI, decimal DeduccionPago, decimal OtrosGastosPagadosNoDeducibles, decimal DeduccionesPagadas, int BaseFechaId, int PorcentajeDeducibleId, decimal NominaDeducible)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEmpresaISRneue]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Año", Año);
				com.Parameters.AddWithValue("Mes", Mes);
				com.Parameters.AddWithValue("TipoRegimenId", TipoRegimenId);
				com.Parameters.AddWithValue("OtrosIngresosAcumulables", OtrosIngresosAcumulables);
				com.Parameters.AddWithValue("RepAcumulados2021Anteriores", RepAcumulados2021Anteriores);
				com.Parameters.AddWithValue("IngresosCobradosNoAcumulables", IngresosCobradosNoAcumulables);
				com.Parameters.AddWithValue("IngresosCobrados", IngresosCobrados);
				com.Parameters.AddWithValue("PerdidasFiscalesAmortizar", PerdidasFiscalesAmortizar);
				com.Parameters.AddWithValue("TasaIsrId", TasaIsrId);
				com.Parameters.AddWithValue("PagosProvisionalesAnteriores", PagosProvisionalesAnteriores);
				com.Parameters.AddWithValue("DeduccionesSinCFDI", DeduccionesSinCFDI);
				com.Parameters.AddWithValue("DeduccionPago", DeduccionPago);
				com.Parameters.AddWithValue("OtrosGastosPagadosNoDeducibles", OtrosGastosPagadosNoDeducibles);
				com.Parameters.AddWithValue("DeduccionesPagadas", DeduccionesPagadas);
				com.Parameters.AddWithValue("BaseFechaId", BaseFechaId);
				com.Parameters.AddWithValue("PorcentajeDeducibleId", PorcentajeDeducibleId);
				com.Parameters.AddWithValue("NominaDeducible", NominaDeducible);
				SqlParameter parm = new SqlParameter("Id", Id);
				parm.Direction = ParameterDirection.InputOutput;
				com.Parameters.Add(parm);
				con.Open();
				com.ExecuteNonQuery();
				return Convert.ToInt32(com.Parameters["Id"].Value);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEmpresa(int EmpresaId, int TipoPersonaId, string Nombre, string NombreFiscal, string RegimenFiscal, string Direccion, string Calle, string NoExterior, string NoInterior, string Colonia, string Localidad, string Municipio, string Estado, string CP, string Telefono, string Telefono2, string RFC, string Email, string Banco, string NumeroCuenta, string Sucursal, string CLABE, string NumeroReferencia, string Certificado, string Key, string KeyRecibidos, string NoCertificado, int RegimenFiscalId, int TipoFactorId, decimal TasaOCuota, int UsoCFDIId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("updActualizaEmpresaBF", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoPersonaId", TipoPersonaId);
				com.Parameters.AddWithValue("Nombre", Nombre);
				com.Parameters.AddWithValue("NombreFiscal", NombreFiscal);
				com.Parameters.AddWithValue("RegimenFiscal", RegimenFiscal);
				com.Parameters.AddWithValue("Direccion", Direccion);
				com.Parameters.AddWithValue("Calle", Calle);
				com.Parameters.AddWithValue("NoExterior", NoExterior);
				com.Parameters.AddWithValue("NoInterior", NoInterior);
				com.Parameters.AddWithValue("Colonia", Colonia);
				com.Parameters.AddWithValue("Localidad", Localidad);
				com.Parameters.AddWithValue("Municipio", Municipio);
				com.Parameters.AddWithValue("Estado", Estado);
				com.Parameters.AddWithValue("CP", CP);
				com.Parameters.AddWithValue("Telefono", Telefono);
				com.Parameters.AddWithValue("Telefono2", Telefono2);
				com.Parameters.AddWithValue("RFC", RFC);
				com.Parameters.AddWithValue("Email", Email);
				com.Parameters.AddWithValue("Banco", Banco);
				com.Parameters.AddWithValue("NumeroCuenta", NumeroCuenta);
				com.Parameters.AddWithValue("Sucursal", Sucursal);
				com.Parameters.AddWithValue("CLABE", CLABE);
				com.Parameters.AddWithValue("NumeroReferencia", NumeroReferencia);
				com.Parameters.AddWithValue("CertificadoRuta", Certificado);
				com.Parameters.AddWithValue("KeyRuta", Key);
				com.Parameters.AddWithValue("KeyRutaRecibidos", KeyRecibidos);
				com.Parameters.AddWithValue("NoCertificado", NoCertificado);
				com.Parameters.AddWithValue("RegimenFiscalId", RegimenFiscalId);
				com.Parameters.AddWithValue("TipoFactorId", TipoFactorId);
				com.Parameters.AddWithValue("TasaOCuota", TasaOCuota);
				com.Parameters.AddWithValue("UsoCFDIId", UsoCFDIId);
				con.Open();
				com.ExecuteNonQuery();
				return EmpresaId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEmpresaCIEC(int EmpresaId, string Certificado)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("updActualizaEmpresaBF_CIEC", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("CertificadoRuta", Certificado);
				con.Open();
				com.ExecuteNonQuery();
				return EmpresaId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEmpresaExcluyeNc(int EmpresaId, bool ExcluyeNC01, bool ExcluyeNC03)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[updActualizaEmpresaExcluyeNc]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("ExcluyeNC01", ExcluyeNC01);
				com.Parameters.AddWithValue("ExcluyeNC03", ExcluyeNC03);
				con.Open();
				com.ExecuteNonQuery();
				return EmpresaId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEmpresaLicencia(int EmpresaId, int LicenciaId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[updActualizaEmpresaLicencia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("LicenciaId", LicenciaId);
				con.Open();
				com.ExecuteNonQuery();
				return EmpresaId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaBanco(int BancoId, string Clave, string Descripcion, int Prioridad)
		{
			try
			{
				com = new SqlCommand("[updActualizaBanco]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("BancoId", BancoId);
				com.Parameters.AddWithValue("Clave", Clave);
				com.Parameters.AddWithValue("Descripcion", Descripcion);
				com.Parameters.AddWithValue("Prioridad", Prioridad);
				con.Open();
				com.ExecuteNonQuery();
				return BancoId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEmpresaISR(int EmpresaId, int Año, int Mes, int TipoRegimenId, decimal OtrosIngresosAcumulables, decimal RepAcumulados2021Anteriores, decimal IngresosCobradosNoAcumulables, decimal IngresosCobrados, decimal PerdidasFiscalesAmortizar, int TasaIsrId, decimal PagosProvisionalesAnteriores, decimal DeduccionesSinCFDI, decimal DeduccionPago, decimal OtrosGastosPagadosNoDeducibles, decimal DeduccionesPagadas, int BaseFechaId, int PorcentajeDeducibleId, decimal NominaDeducible)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[updActualizaEmpresaISRneue]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Año", Año);
				com.Parameters.AddWithValue("Mes", Mes);
				com.Parameters.AddWithValue("TipoRegimenId", TipoRegimenId);
				com.Parameters.AddWithValue("OtrosIngresosAcumulables", OtrosIngresosAcumulables);
				com.Parameters.AddWithValue("RepAcumulados2021Anteriores", RepAcumulados2021Anteriores);
				com.Parameters.AddWithValue("IngresosCobradosNoAcumulables", IngresosCobradosNoAcumulables);
				com.Parameters.AddWithValue("IngresosCobrados", IngresosCobrados);
				com.Parameters.AddWithValue("PerdidasFiscalesAmortizar", PerdidasFiscalesAmortizar);
				com.Parameters.AddWithValue("TasaIsrId", TasaIsrId);
				com.Parameters.AddWithValue("PagosProvisionalesAnteriores", PagosProvisionalesAnteriores);
				com.Parameters.AddWithValue("DeduccionesSinCFDI", DeduccionesSinCFDI);
				com.Parameters.AddWithValue("DeduccionPago", DeduccionPago);
				com.Parameters.AddWithValue("OtrosGastosPagadosNoDeducibles", OtrosGastosPagadosNoDeducibles);
				com.Parameters.AddWithValue("DeduccionesPagadas", DeduccionesPagadas);
				com.Parameters.AddWithValue("BaseFechaId", BaseFechaId);
				com.Parameters.AddWithValue("PorcentajeDeducibleId", PorcentajeDeducibleId);
				com.Parameters.AddWithValue("NominaDeducible", NominaDeducible);
				con.Open();
				com.ExecuteNonQuery();
				return Id;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEstatusEmpresa(int EmpresaId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("updActualizaEstatusEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Estatus", Estatus);
				con.Open();
				com.ExecuteNonQuery();
				return EmpresaId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int actualizaEstatusBanco(int BancoId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("[updActualizaEstatusBanco]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("BancoId", BancoId);
				com.Parameters.AddWithValue("Estatus", Estatus);
				con.Open();
				com.ExecuteNonQuery();
				return BancoId;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public DataTable obtieneTiposMovimientos(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneTiposMovimientos]", con);
				com.CommandType = CommandType.StoredProcedure;
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneTiposMovimientosEgreso(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneTiposMovimientosEgreso]", con);
				com.CommandType = CommandType.StoredProcedure;
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneProductosServicios(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("selProductoServicioTodosPorEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneUnidades(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("selUnidadesTodosPorEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneCatalogoRegimen()
		{
			try
			{
				com = new SqlCommand("selCatalogoRegimenFiscal", con);
				com.CommandType = CommandType.StoredProcedure;
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public DataTable obtieneCatalogoUsoCFDI()
		{
			try
			{
				com = new SqlCommand("selCatalogoUsoCFDI", con);
				com.CommandType = CommandType.StoredProcedure;
				da = new SqlDataAdapter(com);
				dt = new DataTable();
				da.Fill(dt);
				return dt;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int agregaEmpresaProductoServicio(int EmpresaId, int ProductoServicioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaEmpresaProductoServicio", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("ProductoServicioId", ProductoServicioId);
				SqlParameter parm = new SqlParameter("Id", Id);
				parm.Direction = ParameterDirection.InputOutput;
				com.Parameters.Add(parm);
				con.Open();
				com.ExecuteNonQuery();
				return Convert.ToInt32(com.Parameters["Id"].Value);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public void actualizaEstatusEmpresaProductoServicio(int EmpresaId, int ProductoServicioId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("updActualizaEstatusEmpresaProductoServicio", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("ProductoServicioId", ProductoServicioId);
				com.Parameters.AddWithValue("Estatus", Estatus);
				con.Open();
				com.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public void eliminaEmpresaProductoServicio(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("delEmpresaProductoServicio", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				con.Open();
				com.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public int agregaEmpresaUnidad(int EmpresaId, int UnidadId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaEmpresaUnidad", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("UnidadId", UnidadId);
				SqlParameter parm = new SqlParameter("Id", Id);
				parm.Direction = ParameterDirection.InputOutput;
				com.Parameters.Add(parm);
				con.Open();
				com.ExecuteNonQuery();
				return Convert.ToInt32(com.Parameters["Id"].Value);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}

		public void actualizaEstatusEmpresaUnidad(int EmpresaId, int UnidadId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("updActualizaEstatusEmpresaUnidad", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("UnidadId", UnidadId);
				com.Parameters.AddWithValue("Estatus", Estatus);
				con.Open();
				com.ExecuteNonQuery();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				con.Close();
			}
		}
	}
}
