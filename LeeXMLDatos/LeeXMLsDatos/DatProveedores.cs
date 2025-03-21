using System;
using System.Data;
using System.Data.SqlClient;

namespace LeeXMLsDatos
{
	public class DatProveedores : DatAbstracta
	{
		public DataTable obtieneProveedor(int ProveedorId)
		{
			try
			{
				com = new SqlCommand("selObtieneProveedor", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ProveedorId", ProveedorId);
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

		public DataTable obtieneProveedores(int EmpresaId, string RFC)
		{
			try
			{
				com = new SqlCommand("selObtieneProveedoresPorRFCEmpresa", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("RFC", RFC);
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

		public DataTable obtieneClientes(int EmpresaId)
		{
			try
			{
				com = new SqlCommand("selObtieneClientesPorEmpresa", con);
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

		public int agregaProveedor(int EmpresaId, int TipoPersonaId, string Nombre, string NombreFiscal, string Direccion, string Calle, string NoExterior, string NoInterior, string Colonia, string Localidad, string Municipio, string Estado, string CP, string Telefono, string Telefono2, string Celular, string RFC, string Email, string Email2, string Email3, string Banco, string NumeroCuenta, string Sucursal, string CLABE, string NumeroReferencia, int FormaPagoId, DateTime FechaRegistro)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[insAgregaProveedor]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("EmpresaId", EmpresaId);
				com.Parameters.AddWithValue("TipoPersonaId", TipoPersonaId);
				com.Parameters.AddWithValue("Nombre", Nombre);
				com.Parameters.AddWithValue("NombreFiscal", NombreFiscal);
				com.Parameters.AddWithValue("Direccion", Direccion);
				com.Parameters.AddWithValue("CP", CP);
				com.Parameters.AddWithValue("Telefono", Telefono);
				com.Parameters.AddWithValue("Telefono2", Telefono2);
				com.Parameters.AddWithValue("Celular", Celular);
				com.Parameters.AddWithValue("RFC", RFC);
				com.Parameters.AddWithValue("Email", Email);
				com.Parameters.AddWithValue("Email2", Email2);
				com.Parameters.AddWithValue("Email3", Email3);
				com.Parameters.AddWithValue("Banco", Banco);
				com.Parameters.AddWithValue("NumeroCuenta", NumeroCuenta);
				com.Parameters.AddWithValue("Sucursal", Sucursal);
				com.Parameters.AddWithValue("CLABE", CLABE);
				com.Parameters.AddWithValue("NumeroReferencia", NumeroReferencia);
				com.Parameters.AddWithValue("FormaPagoId", FormaPagoId);
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

		public int actualizaProveedorBFX(int ProveedorId, string CLABE, string NumeroReferencia)
		{
			try
			{
				int Id = 0;
				com = new SqlCommand("[updActualizaProveedorBFX]", con);
				com.CommandType = CommandType.StoredProcedure;
				com.Parameters.AddWithValue("ProveedorId", ProveedorId);
				com.Parameters.AddWithValue("CLABE", CLABE);
				com.Parameters.AddWithValue("NumeroReferencia", NumeroReferencia);
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
	}
}
