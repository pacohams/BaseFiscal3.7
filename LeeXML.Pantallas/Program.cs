using System;
using System.Windows.Forms;
using LeeXMLEntidades;

namespace LeeXML.Pantallas
{
	internal static class Program
	{
		public static int SoftwareId = 1;

		public static string Version = "3.7";

		public static EntUsuario UsuarioSeleccionado { get; set; }

		public static EntEmpresa EmpresaSeleccionada { get; set; }

		public static bool CambiaEmpresa { get; set; }

		public static int TipoRevisionId { get; set; }

		public static int AñoInicio => UsuarioSeleccionado.AñoInicial;

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Inicio());
		}
	}
}
