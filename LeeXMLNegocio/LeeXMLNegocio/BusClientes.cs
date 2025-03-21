using System;
using System.Collections.Generic;
using System.Data;
using LeeXMLEntidades;
using LeeXMLsDatos;

namespace LeeXMLNegocio
{
	public class BusClientes : BusAbstracta
	{
		public List<EntCliente> ObtieneClientes(int EmpresaId, string RFC)
		{
			try
			{
				List<EntCliente> lst = new List<EntCliente>();
				dt = new DatClientes().obtieneClientes(EmpresaId, RFC);
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

		public int AgregaCliente(EntCliente cliente)
		{
			try
			{
				return new DatClientes().agregaCliente(cliente.EmpresaId, cliente.TipoPersonaId, cliente.Nombre, cliente.NombreFiscal, cliente.Direccion, cliente.Calle, cliente.NoExterior, cliente.NoInterior, cliente.Colonia, cliente.Localidad, cliente.Municipio, cliente.Estado, cliente.CP, cliente.Telefono, cliente.Telefono2, cliente.Celular, cliente.RFC, cliente.Email, cliente.Email2, cliente.Email3, cliente.Banco, cliente.NumeroCuenta, cliente.Sucursal, cliente.CLABE, cliente.NumeroReferencia, cliente.FormaPagoId, cliente.Fecha);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
