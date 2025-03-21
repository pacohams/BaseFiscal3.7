using System;
using System.Collections.Generic;
using System.Data;
using LeeXMLEntidades;
using LeeXMLsDatos;

namespace LeeXMLNegocio
{
	public class BusProveedores : BusAbstracta
	{
		public EntCliente ObtieneProveedor(int ProveedorId)
		{
			try
			{
				EntCliente c = new EntCliente();
				dt = new DatProveedores().obtieneProveedor(ProveedorId);
				foreach (DataRow r in dt.Rows)
				{
					c.Id = Convert.ToInt32(r["PROV_ID"]);
					c.TipoPersonaId = Convert.ToInt32(r["PROV_TIPOPERSONAID"]);
					c.Nombre = r["PROV_NOMBRE"].ToString();
					c.NombreFiscal = r["PROV_NOMBREFISCAL"].ToString();
					c.CLABE = r["PROV_CLABE"].ToString();
					c.NumeroReferencia = r["PROV_NUMEROREFERENCIA"].ToString();
					c.Estatus = Convert.ToBoolean(r["PROV_ESTATUS"]);
				}
				return c;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCliente> ObtieneProveedores(int EmpresaId, string RFC)
		{
			try
			{
				List<EntCliente> lst = new List<EntCliente>();
				dt = new DatProveedores().obtieneProveedores(EmpresaId, RFC);
				foreach (DataRow r in dt.Rows)
				{
					EntCliente c = new EntCliente();
					c.Id = Convert.ToInt32(r["PROV_ID"]);
					c.TipoPersonaId = Convert.ToInt32(r["PROV_TIPOPERSONAID"]);
					c.Nombre = r["PROV_NOMBRE"].ToString();
					c.NombreFiscal = r["PROV_NOMBREFISCAL"].ToString();
					c.Direccion = r["PROV_DIRECCION"].ToString();
					c.CP = r["PROV_CP"].ToString();
					c.Telefono = r["PROV_TELEFONO"].ToString();
					c.Telefono2 = r["PROV_TELEFONO2"].ToString();
					c.Celular = r["PROV_CELULAR"].ToString();
					c.RFC = r["PROV_RFC"].ToString();
					c.Email = r["PROV_EMAIL"].ToString();
					c.Banco = r["PROV_BANCO"].ToString();
					c.NumeroCuenta = r["PROV_NUMEROCUENTA"].ToString();
					c.Sucursal = r["PROV_SUCURSAL"].ToString();
					c.CLABE = r["PROV_CLABE"].ToString();
					c.NumeroReferencia = r["PROV_NUMEROREFERENCIA"].ToString();
					c.Fecha = Convert.ToDateTime(r["PROV_FECHAREGISTRO"]);
					c.Estatus = Convert.ToBoolean(r["PROV_ESTATUS"]);
					lst.Add(c);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<EntCliente> ObtieneClientes(int EmpresaId)
		{
			try
			{
				List<EntCliente> lst = new List<EntCliente>();
				dt = new DatClientes().obtieneClientes(EmpresaId);
				foreach (DataRow r in dt.Rows)
				{
					EntCliente c = new EntCliente();
					c.Id = Convert.ToInt32(r["CLI_ID"]);
					c.TipoPersonaId = Convert.ToInt32(r["CLI_TIPOPERSONAID"]);
					c.Nombre = r["CLI_NOMBRE"].ToString();
					c.NombreFiscal = r["CLI_NOMBREFISCAL"].ToString();
					c.Direccion = r["CLI_DIRECCION"].ToString();
					c.Calle = r["CLI_CALLE"].ToString();
					c.NoExterior = r["CLI_NOEXTERIOR"].ToString();
					c.NoInterior = r["CLI_NOINTERIOR"].ToString();
					c.Colonia = r["CLI_COLONIA"].ToString();
					c.Localidad = r["CLI_LOCALIDAD"].ToString();
					c.Municipio = r["CLI_MUNICIPIO"].ToString();
					c.Estado = r["CLI_ESTADO"].ToString();
					c.CP = r["CLI_CP"].ToString();
					c.Telefono = r["CLI_TELEFONO"].ToString();
					c.Telefono2 = r["CLI_TELEFONO2"].ToString();
					c.Celular = r["CLI_CELULAR"].ToString();
					c.RFC = r["CLI_RFC"].ToString();
					c.Email = r["CLI_EMAIL"].ToString();
					c.Banco = r["CLI_BANCO"].ToString();
					c.NumeroCuenta = r["CLI_NUMEROCUENTA"].ToString();
					c.Sucursal = r["CLI_SUCURSAL"].ToString();
					c.CLABE = r["CLI_CLABE"].ToString();
					c.NumeroReferencia = r["CLI_NUMEROREFERENCIA"].ToString();
					c.Fecha = Convert.ToDateTime(r["CLI_FECHAREGISTRO"]);
					c.Estatus = Convert.ToBoolean(r["CLI_ESTATUS"]);
					lst.Add(c);
				}
				return lst;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int AgregaProveedor(EntCliente cliente)
		{
			try
			{
				return new DatProveedores().agregaProveedor(cliente.EmpresaId, cliente.TipoPersonaId, cliente.Nombre, cliente.NombreFiscal, cliente.Direccion, cliente.Calle, cliente.NoExterior, cliente.NoInterior, cliente.Colonia, cliente.Localidad, cliente.Municipio, cliente.Estado, cliente.CP, cliente.Telefono, cliente.Telefono2, cliente.Celular, cliente.RFC, cliente.Email, cliente.Email2, cliente.Email3, cliente.Banco, cliente.NumeroCuenta, cliente.Sucursal, cliente.CLABE, cliente.NumeroReferencia, cliente.FormaPagoId, cliente.Fecha);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public int ActualizaProveedor(EntCliente cliente)
		{
			try
			{
				return new DatProveedores().actualizaProveedorBFX(cliente.Id, cliente.CLABE, cliente.NumeroReferencia);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
