using System;
using System.Data;
using System.Data.SqlClient;

namespace LeeXMLsDatos
{
	public class DatUsuarios : DatAbstracta
	{
		public DataTable obtieneUsuarios()
		{
			try
			{
				com = new SqlCommand("selObtieneUsuarios", con);
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

		public DataTable obtieneUsuario(string Usuario, string Contraseña)
		{
			try
			{
				com = new SqlCommand("selObtieneUsuario", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("Usuario", Usuario);
				com.Parameters.AddWithValue("Contraseña", Contraseña);
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

		public DataTable obtieneLicenciasActivas(int CompañiaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneLicenciasPorCompañia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
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

		public DataTable obtieneLicenciasTodas(int CompañiaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneLicenciasTodasPorCompañia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
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

		public DataTable obtieneLicenciasDescargaMasivaActivas(int CompañiaId)
		{
			try
			{
				com = new SqlCommand("[selObtieneDescargaMasivaPorCompañia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
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

		public DataTable verificaCompañiaActiva(int CompañiaId)
		{
			try
			{
				com = new SqlCommand("[VerificaCompañiaActiva]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
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

		public DataTable verificaLicencia(int CompañiaId, string Key)
		{
			try
			{
				com = new SqlCommand("[VerificaLicencia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
				com.Parameters.AddWithValue("Key", Key);
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

		public DataTable verificaLicenciaEmpresa(int CompañiaId, int EmpresId, string Key)
		{
			try
			{
				com = new SqlCommand("[VerificaLicenciaEmpresa]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("CompañiaId", CompañiaId);
				com.Parameters.AddWithValue("EmpresId", EmpresId);
				com.Parameters.AddWithValue("Key", Key);
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

		public DataTable verificaVigenciaLicencia(int LicenciaId)
		{
			try
			{
				com = new SqlCommand("[VerificaVigenciaLicencia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("LicenciaId", LicenciaId);
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

		public DataTable verificaVigenciaLicenciaCompañia(string Usuario, string Contraseña)
		{
			try
			{
				com = new SqlCommand("[VerificaVigenciaCompañia]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("Usuario", Usuario);
				com.Parameters.AddWithValue("Contraseña", Contraseña);
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
	}
}
