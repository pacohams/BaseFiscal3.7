using System;
using System.Collections.Generic;
using System.Data;
using LeeXMLEntidades;
using LeeXMLsDatos;

namespace LeeXMLNegocio
{
	public class BusUsuarios : BusAbstracta
	{
		public List<EntUsuario> ObtieneUsuarios()
		{
			try
			{
				List<EntUsuario> lst = new List<EntUsuario>();
				dt = new DatUsuarios().obtieneUsuarios();
				foreach (DataRow r in dt.Rows)
				{
					EntUsuario c = new EntUsuario();
					c.Id = Convert.ToInt32(r["USU_ID"]);
					c.Usuario = r["USU_USUARIO"].ToString();
					c.Contraseña = r["USU_CONTRASEÑA"].ToString();
					c.CompañiaId = Convert.ToInt32(r["USU_COMPAÑIAID"]);
					c.LimiteEmpresas = Convert.ToInt32(r["COM_LIMITEEMPRESAS"]);
					c.TipoUsuarioId = Convert.ToInt32(r["USU_TIPOUSUARIOID"]);
					c.Administrador = Convert.ToBoolean(r["USU_ADMINISTRADOR"]);
					lst.Add(c);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntUsuario ObtieneUsuario(string Usuario, string Contraseña)
		{
			try
			{
				EntUsuario c = new EntUsuario();
				dt = new DatUsuarios().obtieneUsuario(Usuario, Contraseña);
				foreach (DataRow r in dt.Rows)
				{
					c.Id = Convert.ToInt32(r["USU_ID"]);
					c.Usuario = r["USU_USUARIO"].ToString();
					c.Contraseña = r["USU_CONTRASEÑA"].ToString();
					c.CompañiaId = Convert.ToInt32(r["USU_COMPAÑIAID"]);
					c.LimiteEmpresas = Convert.ToInt32(r["COM_LIMITEEMPRESAS"]);
					c.FechaActivacion = Convert.ToDateTime(r["COM_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["COM_FECHACADUCA"]);
					c.LicenciaId = Convert.ToInt32(r["COM_LICENCIAGENERADAID"]);
					c.LicenciaSerial = r["COM_ULTIMOSERIALGENERADO"].ToString();
					c.TipoUsuarioId = Convert.ToInt32(r["USU_TIPOUSUARIOID"]);
					c.Administrador = Convert.ToBoolean(r["USU_ADMINISTRADOR"]);
					c.AñoInicial = Convert.ToInt32(r["USU_AÑOINICIAL"]);
				}
				return c;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntUsuario> ObtieneLicenciasActivas(int CompañiaId)
		{
			try
			{
				List<EntUsuario> lst = new List<EntUsuario>();
				dt = new DatUsuarios().obtieneLicenciasActivas(CompañiaId);
				foreach (DataRow r in dt.Rows)
				{
					EntUsuario c = new EntUsuario();
					c.CompañiaId = CompañiaId;
					c.LicenciaId = Convert.ToInt32(r["LICGEN_ID"]);
					c.LicenciaSerial = r["LICGEN_KEY"].ToString();
					c.Descripcion = r["TIPLIC_DESCRIPCION"].ToString() + " | " + c.LicenciaSerial;
					c.LimiteEmpresas = Convert.ToInt32(r["TIPLIC_LIMITEEMPRESAS"]);
					c.Activaciones = Convert.ToInt32(r["LICGEN_ACTIVACIONES"]);
					c.Fecha = Convert.ToDateTime(r["FECHAACTUAL"]);
					c.FechaActivacion = Convert.ToDateTime(r["LICGEN_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["LICGEN_FECHACADUCA"]);
					c.Activado = Convert.ToBoolean(r["COM_ACTIVADO"]);
					c.Caducado = Convert.ToBoolean(r["COM_CADUCADO"]);
					lst.Add(c);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntUsuario> ObtieneLicenciasTodas(int CompañiaId)
		{
			try
			{
				List<EntUsuario> lst = new List<EntUsuario>();
				dt = new DatUsuarios().obtieneLicenciasTodas(CompañiaId);
				foreach (DataRow r in dt.Rows)
				{
					EntUsuario c = new EntUsuario();
					c.CompañiaId = CompañiaId;
					c.LicenciaId = Convert.ToInt32(r["LICGEN_ID"]);
					c.LicenciaSerial = r["LICGEN_KEY"].ToString();
					c.Descripcion = r["TIPLIC_DESCRIPCION"].ToString() + " | " + c.LicenciaSerial;
					c.LimiteEmpresas = Convert.ToInt32(r["TIPLIC_LIMITEEMPRESAS"]);
					c.Activaciones = Convert.ToInt32(r["LICGEN_ACTIVACIONES"]);
					c.Fecha = Convert.ToDateTime(r["FECHAACTUAL"]);
					c.FechaActivacion = Convert.ToDateTime(r["LICGEN_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["LICGEN_FECHACADUCA"]);
					c.Activado = Convert.ToBoolean(r["COM_ACTIVADO"]);
					c.Caducado = Convert.ToBoolean(r["COM_CADUCADO"]);
					lst.Add(c);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntUsuario> ObtieneLicenciasDescargaMasivaActivas(int CompañiaId)
		{
			try
			{
				List<EntUsuario> lst = new List<EntUsuario>();
				dt = new DatUsuarios().obtieneLicenciasDescargaMasivaActivas(CompañiaId);
				foreach (DataRow r in dt.Rows)
				{
					EntUsuario c = new EntUsuario();
					c.Id = Convert.ToInt32(r["COMDES_ID"]);
					c.CompañiaId = Convert.ToInt32(r["COMDES_COMPAÑIAID"]);
					c.FechaActivacion = Convert.ToDateTime(r["COMDES_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["COMDES_FECHACADUCA"]);
					lst.Add(c);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool VerificaCompañiaActiva(int CompañiaId)
		{
			try
			{
				EntUsuario c = new EntUsuario();
				dt = new DatUsuarios().verificaCompañiaActiva(CompañiaId);
				foreach (DataRow r in dt.Rows)
				{
					c.CompañiaId = CompañiaId;
					c.LimiteEmpresas = Convert.ToInt32(r["COM_LIMITEEMPRESAS"]);
					c.FechaActivacion = Convert.ToDateTime(r["COM_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["COM_FECHACADUCA"]);
					c.LicenciaId = Convert.ToInt32(r["COM_LICENCIAGENERADAID"]);
					c.LicenciaSerial = r["COM_ULTIMOSERIALGENERADO"].ToString();
					c.Activado = Convert.ToBoolean(r["COM_ACTIVADO"]);
					c.Caducado = Convert.ToBoolean(r["COM_CADUCADO"]);
				}
				return c.Activado;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntUsuario VerificaVigenciaLicenciaCompañia(string Usuario, string Contraseña)
		{
			try
			{
				EntUsuario c = new EntUsuario();
				dt = new DatUsuarios().verificaVigenciaLicenciaCompañia(Usuario, Contraseña);
				foreach (DataRow r in dt.Rows)
				{
					c.Usuario = Usuario;
					c.Contraseña = Contraseña;
					c.CompañiaId = Convert.ToInt32(r["COM_ID"]);
					c.TipoLicenciaId = Convert.ToInt32(r["COM_TIPOLICENCIAID"]);
					c.LimiteEmpresas = Convert.ToInt32(r["COM_LIMITEEMPRESAS"]);
					c.LicenciaId = Convert.ToInt32(r["COM_LICENCIAGENERADAID"]);
					c.LicenciaSerial = r["COM_ULTIMOSERIALGENERADO"].ToString();
					c.FechaActivacion = Convert.ToDateTime(r["COM_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["COM_FECHACADUCA"]);
					c.Fecha = Convert.ToDateTime(r["FECHAACTUAL"]);
					c.Activado = Convert.ToBoolean(r["COM_ACTIVADO"]);
					c.Caducado = Convert.ToBoolean(r["COM_CADUCADO"]);
				}
				return c;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntUsuario VerificaLicencia(int CompañiaId, string Key)
		{
			try
			{
				EntUsuario c = new EntUsuario();
				dt = new DatUsuarios().verificaLicencia(CompañiaId, Key);
				foreach (DataRow r in dt.Rows)
				{
					c.CompañiaId = CompañiaId;
					c.Id = Convert.ToInt32(r["LICGEN_ID"]);
					c.TipoLicenciaId = Convert.ToInt32(r["LICGEN_TIPOLICENCIAID"]);
					c.Estatus = Convert.ToBoolean(r["LICGEN_ESTATUS"]);
				}
				return c;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public EntUsuario VerificaLicenciaEmpresa(int CompañiaId, int EmpresaId, string Key)
		{
			try
			{
				EntUsuario c = new EntUsuario();
				dt = new DatUsuarios().verificaLicenciaEmpresa(CompañiaId, EmpresaId, Key);
				foreach (DataRow r in dt.Rows)
				{
					c.CompañiaId = CompañiaId;
					c.Id = Convert.ToInt32(r["LICGEN_ID"]);
					c.TipoLicenciaId = Convert.ToInt32(r["LICGEN_TIPOLICENCIAID"]);
					c.FechaActivacion = Convert.ToDateTime(r["LICGEN_FECHAACTIVACION"]);
					c.FechaLimite = Convert.ToDateTime(r["LICGEN_FECHACADUCA"]);
					c.EstatusId = Convert.ToInt32(r["LICGEN_ESTATUS"]);
				}
				return c;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public bool VerificaVigenciaLicencia(int LicenciaId)
		{
			try
			{
				EntUsuario c = new EntUsuario();
				c.Caducado = true;
				dt = new DatUsuarios().verificaVigenciaLicencia(LicenciaId);
				foreach (DataRow r in dt.Rows)
				{
					c.Id = Convert.ToInt32(r["LICGEN_ID"]);
					c.TipoLicenciaId = Convert.ToInt32(r["LICGEN_TIPOLICENCIAID"]);
					c.Fecha = Convert.ToDateTime(r["LICGEN_FECHAACTIVACION"]);
					c.EstatusId = Convert.ToInt32(r["LICGEN_ESTATUS"]);
					c.Caducado = false;
				}
				return c.Caducado;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
