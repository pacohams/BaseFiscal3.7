using System;
using System.Data;
using System.Data.SqlClient;

namespace LeeXMLsDatos
{
	public class DatFacturasBKP33 : DatAbstracta
	{
		public DataTable obtieneComprobanteFiscal(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobanteFiscalPorId]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public DataTable obtieneComprobanteFiscalEgreso(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobanteFiscalEgresoPorId]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public DataTable obtieneComprobantesFiscales(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesPorFechasEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesEgresosPorFechasEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscales(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesPorFechasEstatusEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesPorFechaPagoExclusivo(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesPorFechasPagoExclusivoEstatusEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesEgresosPorFechasEstatusEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesEgresosPorFechasPagoExclusivoEstatusEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscales(int EmpresaId, string UUID)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobanteFiscalPorUUIDEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("UUID", UUID);
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

		public DataTable obtieneComprobantesFiscalesEgresos(int EmpresaId, string UUID)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobanteFiscalPorUUIDEmpresaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("UUID", UUID);
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

		public DataTable obtieneComprobantesFiscales(int EmpresaId, int TipoRelacionId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesPorTipoRelacionFechasEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoRelacionId", TipoRelacionId);
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

		public DataTable obtieneComprobantesFiscales(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPorTipoComprobanteEstatusFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesNoPagados(int EmpresaId, int TipoComprobanteId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPorTipoComprobanteNoPagadoEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
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

		public DataTable obtieneComprobantesFiscalesEgresosNoPagados(int EmpresaId, int TipoComprobanteId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesEgresosPorTipoComprobanteNoPagadoEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
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

		public DataTable obtieneComprobantesFiscales(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int MetodoPagoId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPorTipoComprobanteMetodoPagoEstatusFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("MetodoPagoId", MetodoPagoId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesEgresos(int EmpresaId, int TipoRelacionId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesEgresosPorTipoRelacionFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoRelacionId", TipoRelacionId);
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

		public DataTable obtieneComprobantesFiscalesEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesEgresosPorTipoComprobanteEstatusFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId, int MetodoPagoId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesEgresosPorTipoComprobanteMetodoPagoEstatusFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("MetodoPagoId", MetodoPagoId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public DataTable obtieneComprobantesFiscalesPercepciones(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPercepcionesPorFechas]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesPercepcionesPorFechasPago(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPercepcionesPorFechasPago]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesPercepcionesPorFechaDevengada(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPercepcionesPorFechasFin]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesSinRelacionar(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("selObtieneComprobantesFiscalesSinRelacionarPorFechasEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesSinRelacionarEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesSinRelacionarPorFechasEmpresaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesNoDepositados(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesNoDepositadosPorFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesPorDepositar(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPorDepositarPorFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesNominaPorDepositar(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesNominaPorDepositarPorFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesNcDevolucionPorDepositar(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesNcDevolucionesPorDepositarPorFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesEgresosNcDevolucionPorDepositar(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesEgresosNcDevolucionesPorDepositarPorFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneComprobantesFiscalesPorDepositarEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesPorDepositarPorFechasEmpresaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneEstadosDeCuenta(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaPorFechas]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneEstadosDeCuentaEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaPorFechasEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneEstadosDeCuentaDetalle(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorFechas]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
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

		public DataTable obtieneEstadosDeCuentaDetallesPorComprobante(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorComprobanteFiscal]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public DataTable obtieneEstadosDeCuentaDetallesPorComprobanteEgresos(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorComprobanteFiscalEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public DataTable obtieneEstadosDeCuentaDetallesPorTipoComprobante(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorFechasTipoComprobante]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
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

		public DataTable obtieneEstadosDeCuentaDetallesPorTipoComprobanteEgresos(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int TipoComprobanteId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorFechasTipoComprobanteEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
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

		public DataTable obtieneEstadosDeCuentaDetallesPorFacturaRelacionada(int FacturaRelacionadaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorFacturaRelacionada]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
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

		public DataTable obtieneEstadosDeCuentaDetallesPorFacturaRelacionadaEgresos(int FacturaRelacionadaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorFacturaRelacionadaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
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

		public DataTable obtieneEstadoDeCuentaDetalles(int EstadoDeCuentaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorEstadoDeCuenta]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
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

		public DataTable obtieneEstadoDeCuentaDetallesEgresos(int EstadoDeCuentaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneEstadosDeCuentaDetallePorEstadoDeCuentaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
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

		public DataTable obtieneSaldoAFecha(int EmpresaId, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				com = new SqlCommand("[selSaldoAFechaPorClientesEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("ClienteDesdeId", ClienteDesdeId);
				com.Parameters.AddWithValue("ClienteHastaId", ClienteHastaId);
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

		public DataTable obtieneCxCPorClientes(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneCxCPorClientesFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("ClienteDesdeId", ClienteDesdeId);
				com.Parameters.AddWithValue("ClienteHastaId", ClienteHastaId);
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

		public DataTable obtieneCxCMovimientosPorClientes(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int ClienteDesdeId, int ClienteHastaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesCxCPorClientesFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("ClienteDesdeId", ClienteDesdeId);
				com.Parameters.AddWithValue("ClienteHastaId", ClienteHastaId);
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

		public DataTable obtieneSaldoAFechaProveedores(int EmpresaId, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				com = new SqlCommand("[selSaldoAFechaPorProveedoresEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("ProveedorDesdeId", ProveedorDesdeId);
				com.Parameters.AddWithValue("ProveedorHastaId", ProveedorHastaId);
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

		public DataTable obtieneCxPPorProveedores(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneCxPPorProveedoresFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("ProveedorDesdeId", ProveedorDesdeId);
				com.Parameters.AddWithValue("ProveedorHastaId", ProveedorHastaId);
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

		public DataTable obtieneCxPMovimientosPorProveedores(int EmpresaId, DateTime FechaDesde, DateTime FechaHasta, int ProveedorDesdeId, int ProveedorHastaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneComprobantesFiscalesCxPPorProveedoresFechasEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("FechaDesde", FechaDesde);
				com.Parameters.AddWithValue("FechaHasta", FechaHasta);
				com.Parameters.AddWithValue("ProveedorDesdeId", ProveedorDesdeId);
				com.Parameters.AddWithValue("ProveedorHastaId", ProveedorHastaId);
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

		public DataTable obtieneImportesDeclarados(int EmpresaId, DateTime Fecha)
		{
			try
			{
				com = new SqlCommand("[selObtieneImporteDeclarados]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Fecha", Fecha);
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

		public DataTable obtieneImportesDeclaradosEgresos(int EmpresaId, DateTime Fecha)
		{
			try
			{
				com = new SqlCommand("[selObtieneImporteDeclaradosEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Fecha", Fecha);
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

		public int agregaComprobanteFiscal(int EmpresaId, int TipoComprobanteId, int ClienteId, string SerieFactura, string NumeroFactura, DateTime Fecha, decimal IVARetenido, decimal ISRRetenido, decimal IVA, decimal SubTotal, decimal SubTotal0, decimal Total, int MonedaId, int FormaPagoId, int MetodoPagoId, string UUID, string Concepto, int FacturaRelacionadaId, string UUIDRelacionado, int TipoRelacionFacturaId, DateTime FechaPago, string Ruta, byte[] PDF, byte[] XML, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaComprobanteFiscal", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("ClienteId", ClienteId);
				com.Parameters.AddWithValue("SerieFactura", SerieFactura);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("Fecha", Fecha);
				com.Parameters.AddWithValue("IVARetenido", IVARetenido);
				com.Parameters.AddWithValue("ISRRetenido", ISRRetenido);
				com.Parameters.AddWithValue("Subtotal", SubTotal);
				com.Parameters.AddWithValue("Subtotal0", SubTotal0);
				com.Parameters.AddWithValue("IVA", IVA);
				com.Parameters.AddWithValue("Total", Total);
				com.Parameters.AddWithValue("MonedaId", MonedaId);
				com.Parameters.AddWithValue("FormaPagoId", FormaPagoId);
				com.Parameters.AddWithValue("MetodoPagoId", MetodoPagoId);
				com.Parameters.AddWithValue("UUID", UUID);
				com.Parameters.AddWithValue("Concepto", Concepto);
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
				com.Parameters.AddWithValue("UUIDRelacionado", UUIDRelacionado);
				com.Parameters.AddWithValue("TipoRelacionFacturaId", TipoRelacionFacturaId);
				com.Parameters.AddWithValue("FechaPago", FechaPago);
				com.Parameters.AddWithValue("Ruta", Ruta);
				com.Parameters.AddWithValue("PDF", PDF);
				com.Parameters.AddWithValue("XML", XML);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaComprobanteFiscalEgreso(int EmpresaId, int TipoComprobanteId, int ProveedorId, string SerieFactura, string NumeroFactura, DateTime Fecha, decimal IVARetenido, decimal ISRRetenido, decimal IVA, decimal IEPS, decimal SubTotal, decimal SubTotal0, decimal Total, int MonedaId, int FormaPagoId, int MetodoPagoId, string UUID, string Concepto, int FacturaRelacionadaId, string UUIDRelacionado, int TipoRelacionFacturaId, DateTime FechaPago, string Ruta, byte[] PDF, byte[] XML, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaComprobanteFiscalEgresoNeueIeps", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("ProveedorId", ProveedorId);
				com.Parameters.AddWithValue("SerieFactura", SerieFactura);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("Fecha", Fecha);
				com.Parameters.AddWithValue("IVARetenido", IVARetenido);
				com.Parameters.AddWithValue("ISRRetenido", ISRRetenido);
				com.Parameters.AddWithValue("Subtotal", SubTotal);
				com.Parameters.AddWithValue("Subtotal0", SubTotal0);
				com.Parameters.AddWithValue("IVA", IVA);
				com.Parameters.AddWithValue("IEPS", IEPS);
				com.Parameters.AddWithValue("Total", Total);
				com.Parameters.AddWithValue("MonedaId", MonedaId);
				com.Parameters.AddWithValue("FormaPagoId", FormaPagoId);
				com.Parameters.AddWithValue("MetodoPagoId", MetodoPagoId);
				com.Parameters.AddWithValue("UUID", UUID);
				com.Parameters.AddWithValue("Concepto", Concepto);
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
				com.Parameters.AddWithValue("UUIDRelacionado", UUIDRelacionado);
				com.Parameters.AddWithValue("TipoRelacionFacturaId", TipoRelacionFacturaId);
				com.Parameters.AddWithValue("FechaPago", FechaPago);
				com.Parameters.AddWithValue("Ruta", Ruta);
				com.Parameters.AddWithValue("PDF", PDF);
				com.Parameters.AddWithValue("XML", XML);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaComprobanteFiscal(int EmpresaId, int TipoComprobanteId, int ClienteId, string SerieFactura, string NumeroFactura, DateTime Fecha, decimal IVARetenido, decimal ISRRetenido, decimal IVA, decimal IEPS, decimal SubTotal, decimal SubTotal0, decimal TotalPercepciones, decimal TotalDeducciones, decimal Total, int MonedaId, int FormaPagoId, int MetodoPagoId, string UUID, string Concepto, int FacturaRelacionadaId, string UUIDRelacionado, int TipoRelacionFacturaId, DateTime FechaPago, DateTime FechaInicio, DateTime FechaFin, string ClaveEntFed, string TipoRegimen, string Ruta, byte[] PDF, byte[] XML, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaComprobanteFiscalNeueIeps]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("ClienteId", ClienteId);
				com.Parameters.AddWithValue("SerieFactura", SerieFactura);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("Fecha", Fecha);
				com.Parameters.AddWithValue("IVARetenido", IVARetenido);
				com.Parameters.AddWithValue("ISRRetenido", ISRRetenido);
				com.Parameters.AddWithValue("Subtotal", SubTotal);
				com.Parameters.AddWithValue("Subtotal0", SubTotal0);
				com.Parameters.AddWithValue("TotalPercepciones", TotalPercepciones);
				com.Parameters.AddWithValue("TotalDeducciones", TotalDeducciones);
				com.Parameters.AddWithValue("IVA", IVA);
				com.Parameters.AddWithValue("IEPS", IEPS);
				com.Parameters.AddWithValue("Total", Total);
				com.Parameters.AddWithValue("MonedaId", MonedaId);
				com.Parameters.AddWithValue("FormaPagoId", FormaPagoId);
				com.Parameters.AddWithValue("MetodoPagoId", MetodoPagoId);
				com.Parameters.AddWithValue("UUID", UUID);
				com.Parameters.AddWithValue("Concepto", Concepto);
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
				com.Parameters.AddWithValue("UUIDRelacionado", UUIDRelacionado);
				com.Parameters.AddWithValue("TipoRelacionFacturaId", TipoRelacionFacturaId);
				com.Parameters.AddWithValue("FechaPago", FechaPago);
				com.Parameters.AddWithValue("FechaInicio", FechaInicio);
				com.Parameters.AddWithValue("FechaFin", FechaFin);
				com.Parameters.AddWithValue("ClaveEntFed", ClaveEntFed);
				com.Parameters.AddWithValue("TipoRegimen", TipoRegimen);
				com.Parameters.AddWithValue("Ruta", Ruta);
				com.Parameters.AddWithValue("PDF", PDF);
				com.Parameters.AddWithValue("XML", XML);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaComprobanteFiscalPercepcion(int ComprobanteFiscalId, int TipoPercepcionId, string TipoPercepcion, string Concepto, decimal ImporteExento, decimal ImporteGravado, decimal ImporteTotal, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaComprobanteFiscalPercepcion", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("TipoPercepcionId", TipoPercepcionId);
				com.Parameters.AddWithValue("TipoPercepcion", TipoPercepcion);
				com.Parameters.AddWithValue("Concepto", Concepto);
				com.Parameters.AddWithValue("ImporteExento", ImporteExento);
				com.Parameters.AddWithValue("ImporteGravado", ImporteGravado);
				com.Parameters.AddWithValue("ImporteTotal", ImporteTotal);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaComprobanteFiscalDeduccion(int ComprobanteFiscalId, int TipoPercepcionId, string TipoPercepcion, string Concepto, decimal ImporteExento, decimal ImporteGravado, decimal ImporteTotal, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("insAgregaComprobanteFiscalDeduccion", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("TipoDeduccionId", TipoPercepcionId);
				com.Parameters.AddWithValue("TipoDeduccion", TipoPercepcion);
				com.Parameters.AddWithValue("Concepto", Concepto);
				com.Parameters.AddWithValue("ImporteExento", ImporteExento);
				com.Parameters.AddWithValue("ImporteGravado", ImporteGravado);
				com.Parameters.AddWithValue("ImporteTotal", ImporteTotal);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaComprobanteFiscalNoDepositado(int EmpresaId, int ComprobanteFiscalId, DateTime FechaDeposito, decimal Monto, decimal IVARetenido, decimal ISRRetenido, decimal IVA, decimal SubTotal, decimal SubTotal0, decimal Total, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaComprobanteFiscalNoDepositado]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("FechaDeposito", FechaDeposito);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("IVARetenido", IVARetenido);
				com.Parameters.AddWithValue("ISRRetenido", ISRRetenido);
				com.Parameters.AddWithValue("Subtotal", SubTotal);
				com.Parameters.AddWithValue("Subtotal0", SubTotal0);
				com.Parameters.AddWithValue("IVA", IVA);
				com.Parameters.AddWithValue("Total", Total);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaComprobanteFiscalNoDepositadoEgresos(int EmpresaId, int ComprobanteFiscalId, DateTime FechaDeposito, decimal Monto, decimal IVARetenido, decimal ISRRetenido, decimal IVA, decimal SubTotal, decimal SubTotal0, decimal Total, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaComprobanteFiscalNoDepositadoEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("FechaDeposito", FechaDeposito);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("IVARetenido", IVARetenido);
				com.Parameters.AddWithValue("ISRRetenido", ISRRetenido);
				com.Parameters.AddWithValue("Subtotal", SubTotal);
				com.Parameters.AddWithValue("Subtotal0", SubTotal0);
				com.Parameters.AddWithValue("IVA", IVA);
				com.Parameters.AddWithValue("Total", Total);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public void actualizaEstatusComprobanteFiscal(int ComprobanteFiscalId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("updActualizaEstatusComprobanteFiscal", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public void actualizaEstatusComprobanteFiscalEgresos(int ComprobanteFiscalId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("updActualizaEstatusComprobanteFiscalEgresos", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public void actualizaEstatusComprobanteFiscalNoDepositado(int ComprobanteFiscalId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("updActualizaEstatusComprobanteFiscalNoDepositado", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public void actualizaEstatusComprobanteFiscalNoDepositadoEgresos(int ComprobanteFiscalId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("[updActualizaEstatusComprobanteFiscalNoDepositadoEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public void actualizaComprobanteFiscalExcluyeFlujo(int ComprobanteFiscalId, bool ExcluyeFlujo)
		{
			try
			{
				com = new SqlCommand("[updActualizaComprobanteFiscalExcluyeFlujo]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("ExcluyeFlujo", ExcluyeFlujo);
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

		public void actualizaComprobanteFiscalEgresosDeducible(int ComprobanteFiscalId, bool Deducible)
		{
			try
			{
				com = new SqlCommand("[updActualizaComprobanteFiscalEgresosDeducible]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Deducible", Deducible);
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

		public void actualizaComprobanteFiscalTipoRelacion(int ComprobanteFiscalId, int TipoRelacionId)
		{
			try
			{
				com = new SqlCommand("updActualizaComprobanteFiscalTipoRelacion", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("TipoRelacionId", TipoRelacionId);
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

		public void actualizaComprobanteFiscalTipoRelacionEgresos(int ComprobanteFiscalId, int TipoRelacionId)
		{
			try
			{
				com = new SqlCommand("[updActualizaComprobanteFiscalTipoRelacionEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("TipoRelacionId", TipoRelacionId);
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

		public void actualizaComprobanteFiscalPagado(int ComprobanteFiscalId, bool Pagado)
		{
			try
			{
				com = new SqlCommand("updActualizaComprobanteFiscalPagado", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Pagado", Pagado);
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

		public void actualizaComprobanteFiscalPagadoEgresos(int ComprobanteFiscalId, bool Pagado)
		{
			try
			{
				com = new SqlCommand("[updActualizaComprobanteFiscalPagadoEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Pagado", Pagado);
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

		public void actualizaComprobanteFiscalDepositado(int ComprobanteFiscalId, bool Depositado)
		{
			try
			{
				com = new SqlCommand("updActualizaComprobanteFiscalDepositado", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Depositado", Depositado);
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

		public void actualizaComprobanteFiscalDepositadoEgresos(int ComprobanteFiscalId, bool Depositado)
		{
			try
			{
				com = new SqlCommand("[updActualizaComprobanteFiscalDepositadoEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Depositado", Depositado);
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

		public void actualizaEstatusEstadoDeCuenta(int EstadoDeCuentaId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[updActualizaEstatusEstadoDeCuenta]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public void actualizaEstatusEstadoDeCuentaEgresos(int EstadoDeCuentaId, int EstatusId)
		{
			try
			{
				com = new SqlCommand("[updActualizaEstatusEstadoDeCuentaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
				com.Parameters.AddWithValue("EstatusId", EstatusId);
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

		public void actualizaEstatusEstadoDeCuentaCompronantes(int EstadoDeCuentaId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("[updActualizaEstatusEstadoDeCuentaComprobantesPorEstadoDeCuenta]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
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

		public void actualizaEstatusEstadoDeCuentaCompronantesEgresos(int EstadoDeCuentaId, bool Estatus)
		{
			try
			{
				com = new SqlCommand("[updActualizaEstatusEstadoDeCuentaComprobantesPorEstadoDeCuentaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
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

		public int agregaEstadoDeCuenta(int EmpresaId, int BancoId, int TipoComprobanteId, DateTime Fecha, decimal Monto, string Observacion, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEstadoDeCuenta]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("BancoId", BancoId);
				com.Parameters.AddWithValue("TipoMovimientoId", TipoComprobanteId);
				com.Parameters.AddWithValue("Fecha", Fecha);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("Observacion", Observacion);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaEstadoDeCuentaEgresos(int EmpresaId, int BancoId, int TipoComprobanteId, DateTime Fecha, decimal Monto, string Observacion, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEstadoDeCuentaEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("BancoId", BancoId);
				com.Parameters.AddWithValue("TipoMovimientoId", TipoComprobanteId);
				com.Parameters.AddWithValue("Fecha", Fecha);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("Observacion", Observacion);
				com.Parameters.AddWithValue("UsuarioId", UsuarioId);
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

		public int agregaEstadoDeCuentaComprobante(int EstadoDeCuentaId, int ComprobanteFiscalId, int TipoComprobanteId, decimal Monto, string NumeroFactura, string UUID)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEstadoDeCuentaComprobanteNeue]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("UUID", UUID);
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

		public int agregaEstadoDeCuentaComprobanteEgresos(int EstadoDeCuentaId, int ComprobanteFiscalId, int TipoComprobanteId, decimal Monto, string NumeroFactura, string UUID)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEstadoDeCuentaComprobanteEgresosNeue]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("TipoComprobanteId", TipoComprobanteId);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("UUID", UUID);
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

		public int agregaEstadoDeCuentaComprobante(int EstadoDeCuentaId, int ComprobanteFiscalId, decimal Monto, string NumeroFactura, string UUID, int FacturaRelacionadaId, string UUIDRelacionado)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEstadoDeCuentaComprobanteConFacturaRelacion]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("UUID", UUID);
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
				com.Parameters.AddWithValue("UUIDRelacionado", UUIDRelacionado);
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

		public int agregaEstadoDeCuentaComprobanteEgresos(int EstadoDeCuentaId, int ComprobanteFiscalId, decimal Monto, string NumeroFactura, string UUID, int FacturaRelacionadaId, string UUIDRelacionado)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaEstadoDeCuentaComprobanteConFacturaRelacionEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EstadoDeCuentaId", EstadoDeCuentaId);
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Monto", Monto);
				com.Parameters.AddWithValue("NumeroFactura", NumeroFactura);
				com.Parameters.AddWithValue("UUID", UUID);
				com.Parameters.AddWithValue("FacturaRelacionadaId", FacturaRelacionadaId);
				com.Parameters.AddWithValue("UUIDRelacionado", UUIDRelacionado);
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

		public int agregaImporteDeclarado(int EmpresaId, decimal Importe, decimal IVA, DateTime Fecha, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaImporteDeclarados]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Importe", Importe);
				com.Parameters.AddWithValue("Iva", IVA);
				com.Parameters.AddWithValue("Fecha", Fecha);
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

		public int agregaImporteDeclaradoEgresos(int EmpresaId, decimal Importe, decimal IVA, DateTime Fecha, int UsuarioId)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaImporteDeclaradosEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("Importe", Importe);
				com.Parameters.AddWithValue("Iva", IVA);
				com.Parameters.AddWithValue("Fecha", Fecha);
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

		public void verificaComprobanteFiscalPagado(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[updVerificaComprobanteFiscalPagado]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public void verificaComprobanteFiscalPagadoEgresos(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[updVerificaComprobanteFiscalPagadoEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public void verificaComprobanteFiscalDepositado(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[updVerificaComprobanteFiscalDepositado]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public void verificaComprobanteFiscalDepositadoEgresos(int ComprobanteFiscalId)
		{
			try
			{
				com = new SqlCommand("[updVerificaComprobanteFiscalDepositadoEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
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

		public void aumentaPagoComprobanteFiscal(int ComprobanteFiscalId, decimal Pago)
		{
			try
			{
				com = new SqlCommand("updAumentaPagoComprobanteFiscal", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Pago", Pago);
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

		public void aumentaPagoComprobanteFiscalEgresos(int ComprobanteFiscalId, decimal Pago)
		{
			try
			{
				com = new SqlCommand("[updAumentaPagoComprobanteFiscalEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Pago", Pago);
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

		public void aumentaDepositoComprobanteFiscal(int ComprobanteFiscalId, decimal Deposito)
		{
			try
			{
				com = new SqlCommand("updAumentaDepositoComprobanteFiscal", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Deposito", Deposito);
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

		public void aumentaDepositoComprobanteFiscalEgresos(int ComprobanteFiscalId, decimal Deposito)
		{
			try
			{
				com = new SqlCommand("[updAumentaDepositoComprobanteFiscalEgresos]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ComprobanteFiscalId", ComprobanteFiscalId);
				com.Parameters.AddWithValue("Deposito", Deposito);
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
