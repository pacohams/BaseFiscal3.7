using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LeeXMLsDatos
{
	public abstract class DatAbstracta
	{
		public SqlConnection con;

		public SqlCommand com;

		public SqlDataAdapter da;

		public DataTable dt;

		public int cantidadRenglones;

		public DatAbstracta()
		{
			string cadena = ConfigurationManager.ConnectionStrings["SQLTiimComprobantes"].ToString();
			cadena = "Data Source=tiimserver.database.windows.net;Initial Catalog=FacturacionAzure;User ID=tiim;password =Zoeserv10";
			con = new SqlConnection(cadena);
		}
	}
}
