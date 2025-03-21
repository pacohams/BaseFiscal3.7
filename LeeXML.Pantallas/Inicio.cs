using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;

namespace LeeXML.Pantallas
{
	public class Inicio : Form
	{
		private enum TipoRevision
		{
			INGRESOS = 1,
			EGRESOS
		}

		private enum TipoLicencias
		{
			PRUEBA = 1,
			ANUAL1,
			ANUAL5,
			ANUAL10,
			ANUAL50,
			ANUAL100
		}

		private IContainer components = null;

		private ToolStrip tsIngresos;

		private ToolStripButton tsbInicio;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripButton tsImportarIngresos;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripButton toolStripButton9;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripButton toolStripButton4;

		private ToolStripButton toolStripButton3;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripButton tsbEstadoDeCuenta;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripButton tsbPapelDeTrabajo;

		private ToolStripDropDownButton toolStripButton6;

		private ToolStripMenuItem empresasToolStripMenuItem;

		private ToolStripButton toolStripButton8;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripButton tsbCatalogoClientes;

		private ToolStripButton tsbObservaciones;

		private ToolStrip tsEgresos;

		private ToolStripButton tsbInicioRecibidos;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripButton tsImportarEgresos;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripButton tsReportesEgresos;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripDropDownButton toolStripDropDownButton1;

		private ToolStripMenuItem tsEmpresasEgresos;

		private ToolStripButton tsFlujoEgresos;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripButton tsEstadoDeCuentaEgresos;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripButton tsbPapelTrabajoEgresos;

		private ToolStripButton tsCxPEgresos;

		private ToolStripButton tsbObservacionesEgresos;

		private ToolStripSeparator toolStripSeparator15;

		private ToolStripButton tsbCatalogoProveedores;

		private ToolStrip tsTipoRevision;

		private ToolStripDropDownButton tsbTipoRevisionGeneral;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripMenuItem iNGRESOSToolStripMenuItem;

		private ToolStripMenuItem eGRESOSToolStripMenuItem;

		private ToolStripButton tsbCalculoIVA;

		private ToolStripButton tsbCalculoISR;

		private ToolStripButton tsbAdquiereTuLicencia;

		private ToolStripLabel tslDiasExpiracion;

		private ToolStripButton tsbIndicadoresFiscales;

		private ToolStripButton tsbInformacionPreccargadaSAT;

		private ToolStripSeparator toolStripSeparator17;

		private ToolStripDropDownButton tsbSeleccionaTipoEmitidos;

		private ToolStripSeparator toolStripSeparator20;

		private ToolStripMenuItem tsmVerRecibidosEmitidos;

		private ToolStripSeparator toolStripSeparator21;

		private ToolStripDropDownButton tsbSeleccionaTipoRecibidos;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripMenuItem tsmVerEmitidosRecibidos;

		private ToolStripSeparator toolStripSeparator19;

		private ToolStripDropDownButton tsbConfiguracion;

		private ToolStripMenuItem tsbEmpresas;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripMenuItem tsmAyuda;

		private ToolStripMenuItem tsmManualUsuario;

		private ToolStripButton tsbDIOT;

		private string PaginaDescarga { get; set; }

		public Inicio()
		{
			InitializeComponent();
		}

		private Form BuscaForma(string titulo)
		{
			Form[] mdiChildren = base.MdiChildren;
			foreach (Form v in mdiChildren)
			{
				if (v.Text == titulo)
				{
					return v;
				}
			}
			return null;
		}

		private void CierraFormas()
		{
			Form[] mdiChildren = base.MdiChildren;
			foreach (Form v in mdiChildren)
			{
				if (!(v.Text == new CalculoIVA().Text) && !(v.Text == new CalculoISR().Text) && !(v.Text == new IndicadoresFiscales().Text) && !(v.Text == new InformacionPrecargadaSAT().Text))
				{
					v.Close();
				}
			}
		}

		private void VerificaVigenciaLicencia()
		{
			string PaginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
			Program.UsuarioSeleccionado = new BusUsuarios().VerificaVigenciaLicenciaCompañia(Program.UsuarioSeleccionado.Usuario, Program.UsuarioSeleccionado.Contraseña);
			if (Program.UsuarioSeleccionado.Caducado)
			{
				tsbCalculoIVA.Visible = false;
				tsbCalculoISR.Visible = false;
				if (MessageBox.Show("SU LICENCIA HA CADUCADO\n¿DESEA REENOVARLA?", "LICENCIA CADUCADA", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
				{
					Process.Start(PaginaDescarga);
				}
			}
		}

		private void Inicio_Load(object sender, EventArgs e)
		{
			try
			{
				PaginaDescarga = new BusEmpresas().ObtienePaginasDescarga().First().Descripcion;
				bool validaLicencia = false;
				tsIngresos.Visible = false;
				tsEgresos.Visible = false;
				ContraseñaLogin vInicioSesion = new ContraseñaLogin();
				if (vInicioSesion.ShowDialog() == DialogResult.OK)
				{
					Program.UsuarioSeleccionado = vInicioSesion.UsuarioLogin;
					Menu a = (Menu)BuscaForma(new Menu().Titulo);
					if (a == null)
					{
						a = new Menu();
						a.MdiParent = this;
						a.Show();
					}
					else
					{
						a.BringToFront();
					}
					bool versionActualizada = false;
					foreach (EntCatalogoGenerico c in new BusEmpresas().ObtieneUltimaVersion(Program.SoftwareId))
					{
						string ultimaVersion = c.Clave;
						if (Program.Version == ultimaVersion)
						{
							versionActualizada = true;
						}
					}
					if (!versionActualizada)
					{
						MuestraMensajePaginaDescarga vMensaje = new MuestraMensajePaginaDescarga();
						vMensaje.Text = "DESCARGA ÚLTIMA VERSIÓN";
						vMensaje.Mensaje = "SE ENCUENTRA UNA NUEVA ACTUALIZACIÓN DE 'BASE FISCAL XML' \n                                DISPONIBLE PARA DESCARGA.";
						vMensaje.ShowDialog();
					}
					Text = Text + " - VERSIÓN " + Program.Version;
				}
				else
				{
					Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
		}

		private void toolStripButton5_Click(object sender, EventArgs e)
		{
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			try
			{
				Cargando ca = (Cargando)BuscaForma(new Cargando().Titulo);
				if (ca != null)
				{
					MessageBox.Show("IMPORTANDO ARCHIVOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				LeeXMLs a = (LeeXMLs)BuscaForma(new LeeXMLs().Titulo);
				if (a == null)
				{
					a = new LeeXMLs();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton9_Click(object sender, EventArgs e)
		{
			try
			{
				Reportes a = (Reportes)BuscaForma(new Reportes().Titulo);
				if (a == null)
				{
					a = new Reportes();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton3_Click_1(object sender, EventArgs e)
		{
			try
			{
				AnalisisComprobantes a = (AnalisisComprobantes)BuscaForma(new AnalisisComprobantes().Titulo);
				if (a == null)
				{
					a = new AnalisisComprobantes();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton5_Click_1(object sender, EventArgs e)
		{
			try
			{
				EstadoDeCuenta a = (EstadoDeCuenta)BuscaForma(new EstadoDeCuenta().Titulo);
				if (a == null)
				{
					a = new EstadoDeCuenta();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton6_Click(object sender, EventArgs e)
		{
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
		}

		private void toolStripButton7_Click(object sender, EventArgs e)
		{
			try
			{
				PapelTrabajo a = (PapelTrabajo)BuscaForma(new PapelTrabajo().Titulo);
				if (a == null)
				{
					a = new PapelTrabajo();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Empresas a = (Empresas)BuscaForma(new Empresas().Titulo);
				if (a == null)
				{
					a = new Empresas();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton8_Click(object sender, EventArgs e)
		{
			try
			{
				CxC a = (CxC)BuscaForma(new CxC().Titulo);
				if (a == null)
				{
					a = new CxC();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void toolStripButton10_Click(object sender, EventArgs e)
		{
			try
			{
				CatalogoClientes a = (CatalogoClientes)BuscaForma(new CatalogoClientes().Titulo);
				if (a == null)
				{
					a = new CatalogoClientes();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbObservaciones_Click(object sender, EventArgs e)
		{
			try
			{
				Observaciones a = (Observaciones)BuscaForma(new Observaciones().Titulo);
				if (a == null)
				{
					a = new Observaciones();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void iNGRESOSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				CierraFormas();
				tsIngresos.Visible = true;
				tsEgresos.Visible = false;
				tsbTipoRevisionGeneral.Visible = false;
				Program.TipoRevisionId = 1;
				Menu a = new Menu();
				a.MdiParent = this;
				a.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void eGRESOSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				CierraFormas();
				tsIngresos.Visible = false;
				tsEgresos.Visible = true;
				tsbTipoRevisionGeneral.Visible = false;
				Program.TipoRevisionId = 2;
				Menu a = new Menu();
				a.MdiParent = this;
				a.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsImportarEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				Cargando ca = (Cargando)BuscaForma(new Cargando().Titulo);
				if (ca != null)
				{
					MessageBox.Show("IMPORTANDO ARCHIVOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				LeeXMLsEgresos a = (LeeXMLsEgresos)BuscaForma(new LeeXMLsEgresos().Titulo);
				if (a == null)
				{
					a = new LeeXMLsEgresos();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsReportesEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				ReportesEgresos a = (ReportesEgresos)BuscaForma(new ReportesEgresos().Titulo);
				if (a == null)
				{
					a = new ReportesEgresos();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsFlujoEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				AnalisisComprobantesEgresos a = (AnalisisComprobantesEgresos)BuscaForma(new AnalisisComprobantesEgresos().Titulo);
				if (a == null)
				{
					a = new AnalisisComprobantesEgresos();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsCxPEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				CxP a = (CxP)BuscaForma(new CxP().Titulo);
				if (a == null)
				{
					a = new CxP();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsEstadoDeCuentaEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				EstadoDeCuentaEgresos a = (EstadoDeCuentaEgresos)BuscaForma(new EstadoDeCuentaEgresos().Titulo);
				if (a == null)
				{
					a = new EstadoDeCuentaEgresos();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsEmpresasEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				Empresas a = (Empresas)BuscaForma(new Empresas().Titulo);
				if (a == null)
				{
					a = new Empresas();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbCalculoIVA_Click(object sender, EventArgs e)
		{
			try
			{
				CalculoIVA a = (CalculoIVA)BuscaForma(new CalculoIVA().Titulo);
				if (a == null)
				{
					a = new CalculoIVA();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbCalculoISR_Click(object sender, EventArgs e)
		{
			try
			{
				CalculoISR a = (CalculoISR)BuscaForma(new CalculoISR().Titulo);
				if (a == null)
				{
					a = new CalculoISR();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbPapelTrabajoEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				PapelTrabajoEgresos a = (PapelTrabajoEgresos)BuscaForma(new PapelTrabajoEgresos().Titulo);
				if (a == null)
				{
					a = new PapelTrabajoEgresos();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbObservacionesEgresos_Click(object sender, EventArgs e)
		{
			try
			{
				ObservacionesEgresos a = (ObservacionesEgresos)BuscaForma(new ObservacionesEgresos().Titulo);
				if (a == null)
				{
					a = new ObservacionesEgresos();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbCatalogoProveedores_Click(object sender, EventArgs e)
		{
		}

		private void tsbInicio_Click(object sender, EventArgs e)
		{
			Menu a = (Menu)BuscaForma(new Menu().Titulo);
			if (a == null)
			{
				a = new Menu();
				a.MdiParent = this;
				a.Show();
			}
			else
			{
				a.BringToFront();
			}
		}

		private void tsbInicioRecibidos_Click(object sender, EventArgs e)
		{
			Menu a = (Menu)BuscaForma(new Menu().Titulo);
			if (a == null)
			{
				a = new Menu();
				a.MdiParent = this;
				a.Show();
			}
			else
			{
				a.BringToFront();
			}
		}

		private void tsbAdquiereTuLicencia_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start(PaginaDescarga);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsmAyuda_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("https://www.youtube.com/channel/UCpYrGlfg79N-0uFuDrpjNWA/featured");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsmManualUsuario_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("https://tienda.elconta.com/bfxmanualdeuso");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbIndicadoresFiscales_Click(object sender, EventArgs e)
		{
			try
			{
				IndicadoresFiscales a = (IndicadoresFiscales)BuscaForma(new IndicadoresFiscales().Titulo);
				if (a == null)
				{
					a = new IndicadoresFiscales();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbInformacionPreccargadaSAT_Click(object sender, EventArgs e)
		{
			try
			{
				InformacionPrecargadaSAT a = (InformacionPrecargadaSAT)BuscaForma(new InformacionPrecargadaSAT().Titulo);
				if (a == null)
				{
					a = new InformacionPrecargadaSAT();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsmVerEmitidosRecibidos_Click(object sender, EventArgs e)
		{
			try
			{
				CierraFormas();
				tsIngresos.Visible = true;
				tsEgresos.Visible = false;
				Program.TipoRevisionId = 1;
				tsbTipoRevisionGeneral.Image = Resources.emitidos_cfdi_descargar;
				tsbTipoRevisionGeneral.Text = "CFDI EMITIDOS";
				Menu a = new Menu();
				a.MdiParent = this;
				a.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsmVerRecibidosEmitidos_Click(object sender, EventArgs e)
		{
			try
			{
				CierraFormas();
				tsIngresos.Visible = false;
				tsEgresos.Visible = true;
				Program.TipoRevisionId = 2;
				tsbTipoRevisionGeneral.Image = Resources.recibidos_cfdi_descargar;
				tsbTipoRevisionGeneral.Text = "CFDI RECIBIDOS";
				Menu a = new Menu();
				a.MdiParent = this;
				a.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbEmpresas_Click(object sender, EventArgs e)
		{
			try
			{
				Empresas a = (Empresas)BuscaForma(new Empresas().Titulo);
				if (a == null)
				{
					a = new Empresas();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void tsbDIOT_Click(object sender, EventArgs e)
		{
			try
			{
				DIOT a = (DIOT)BuscaForma(new DIOT().Titulo);
				if (a == null)
				{
					a = new DIOT();
					a.MdiParent = this;
					a.Show();
				}
				else
				{
					a.VerificaEmpresa();
					a.BringToFront();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.Inicio));
			this.tsIngresos = new System.Windows.Forms.ToolStrip();
			this.tsbSeleccionaTipoEmitidos = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmVerRecibidosEmitidos = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbInicio = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsImportarIngresos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButton6 = new System.Windows.Forms.ToolStripDropDownButton();
			this.empresasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCatalogoClientes = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbObservaciones = new System.Windows.Forms.ToolStripButton();
			this.tsbPapelDeTrabajo = new System.Windows.Forms.ToolStripButton();
			this.tsbEstadoDeCuenta = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsEgresos = new System.Windows.Forms.ToolStrip();
			this.tsbSeleccionaTipoRecibidos = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmVerEmitidosRecibidos = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbInicioRecibidos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.tsImportarEgresos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.tsReportesEgresos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsEmpresasEgresos = new System.Windows.Forms.ToolStripMenuItem();
			this.tsFlujoEgresos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.tsCxPEgresos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbObservacionesEgresos = new System.Windows.Forms.ToolStripButton();
			this.tsbPapelTrabajoEgresos = new System.Windows.Forms.ToolStripButton();
			this.tsEstadoDeCuentaEgresos = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCatalogoProveedores = new System.Windows.Forms.ToolStripButton();
			this.tsTipoRevision = new System.Windows.Forms.ToolStrip();
			this.tsbTipoRevisionGeneral = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.iNGRESOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.eGRESOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCalculoIVA = new System.Windows.Forms.ToolStripButton();
			this.tsbCalculoISR = new System.Windows.Forms.ToolStripButton();
			this.tsbConfiguracion = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsbEmpresas = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.tsmAyuda = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmManualUsuario = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAdquiereTuLicencia = new System.Windows.Forms.ToolStripButton();
			this.tslDiasExpiracion = new System.Windows.Forms.ToolStripLabel();
			this.tsbIndicadoresFiscales = new System.Windows.Forms.ToolStripButton();
			this.tsbInformacionPreccargadaSAT = new System.Windows.Forms.ToolStripButton();
			this.tsbDIOT = new System.Windows.Forms.ToolStripButton();
			this.tsIngresos.SuspendLayout();
			this.tsEgresos.SuspendLayout();
			this.tsTipoRevision.SuspendLayout();
			base.SuspendLayout();
			this.tsIngresos.AutoSize = false;
			this.tsIngresos.BackColor = System.Drawing.Color.White;
			this.tsIngresos.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.tsIngresos.Items.AddRange(new System.Windows.Forms.ToolStripItem[19]
			{
				this.tsbSeleccionaTipoEmitidos, this.tsbInicio, this.toolStripSeparator3, this.tsImportarIngresos, this.toolStripSeparator1, this.toolStripButton4, this.toolStripSeparator4, this.toolStripButton9, this.toolStripSeparator2, this.toolStripButton6,
				this.toolStripButton3, this.toolStripButton8, this.toolStripSeparator5, this.tsbCatalogoClientes, this.toolStripSeparator7, this.tsbObservaciones, this.tsbPapelDeTrabajo, this.tsbEstadoDeCuenta, this.toolStripSeparator6
			});
			this.tsIngresos.Location = new System.Drawing.Point(0, 0);
			this.tsIngresos.Name = "tsIngresos";
			this.tsIngresos.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.tsIngresos.Size = new System.Drawing.Size(2260, 78);
			this.tsIngresos.TabIndex = 1;
			this.tsIngresos.Text = "toolStrip1";
			this.tsbSeleccionaTipoEmitidos.BackColor = System.Drawing.Color.White;
			this.tsbSeleccionaTipoEmitidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripSeparator20, this.tsmVerRecibidosEmitidos, this.toolStripSeparator21 });
			this.tsbSeleccionaTipoEmitidos.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
			this.tsbSeleccionaTipoEmitidos.Image = LeeXML.Properties.Resources.emitidos_cfdi_descargar;
			this.tsbSeleccionaTipoEmitidos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSeleccionaTipoEmitidos.Name = "tsbSeleccionaTipoEmitidos";
			this.tsbSeleccionaTipoEmitidos.Size = new System.Drawing.Size(247, 73);
			this.tsbSeleccionaTipoEmitidos.Text = "CFDI EMITIDOS";
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(371, 6);
			this.tsmVerRecibidosEmitidos.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
			this.tsmVerRecibidosEmitidos.Image = LeeXML.Properties.Resources.recibidos_cfdi_descargar;
			this.tsmVerRecibidosEmitidos.Name = "tsmVerRecibidosEmitidos";
			this.tsmVerRecibidosEmitidos.Size = new System.Drawing.Size(374, 40);
			this.tsmVerRecibidosEmitidos.Text = "VER -CFDI RECIBIDOS-";
			this.tsmVerRecibidosEmitidos.Click += new System.EventHandler(tsmVerRecibidosEmitidos_Click);
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(371, 6);
			this.tsbInicio.BackColor = System.Drawing.Color.White;
			this.tsbInicio.Font = new System.Drawing.Font("Segoe UI", 15f);
			this.tsbInicio.Image = LeeXML.Properties.Resources.inicio__1_;
			this.tsbInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInicio.Name = "tsbInicio";
			this.tsbInicio.Size = new System.Drawing.Size(133, 73);
			this.tsbInicio.Text = "Inicio";
			this.tsbInicio.Visible = false;
			this.tsbInicio.Click += new System.EventHandler(tsbInicio_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 78);
			this.tsImportarIngresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsImportarIngresos.Image = LeeXML.Properties.Resources.importar_xml;
			this.tsImportarIngresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsImportarIngresos.Name = "tsImportarIngresos";
			this.tsImportarIngresos.Size = new System.Drawing.Size(138, 73);
			this.tsImportarIngresos.Text = "Importar ";
			this.tsImportarIngresos.Click += new System.EventHandler(toolStripButton2_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 78);
			this.toolStripButton4.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(116, 73);
			this.toolStripButton4.Text = "Facturación";
			this.toolStripButton4.Visible = false;
			this.toolStripButton4.Click += new System.EventHandler(toolStripButton4_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 78);
			this.toolStripSeparator4.Visible = false;
			this.toolStripButton9.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.toolStripButton9.Image = LeeXML.Properties.Resources.reportes__1_;
			this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton9.Name = "toolStripButton9";
			this.toolStripButton9.Size = new System.Drawing.Size(133, 73);
			this.toolStripButton9.Text = "Reportes";
			this.toolStripButton9.Click += new System.EventHandler(toolStripButton9_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 78);
			this.toolStripSeparator2.Visible = false;
			this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.empresasToolStripMenuItem });
			this.toolStripButton6.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.toolStripButton6.Image = LeeXML.Properties.Resources.configuracion;
			this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton6.Name = "toolStripButton6";
			this.toolStripButton6.Size = new System.Drawing.Size(193, 73);
			this.toolStripButton6.Text = "Configuración";
			this.toolStripButton6.Visible = false;
			this.toolStripButton6.Click += new System.EventHandler(toolStripButton6_Click);
			this.empresasToolStripMenuItem.Image = LeeXML.Properties.Resources.Briefcase;
			this.empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
			this.empresasToolStripMenuItem.Size = new System.Drawing.Size(196, 36);
			this.empresasToolStripMenuItem.Text = "Empresas";
			this.empresasToolStripMenuItem.Click += new System.EventHandler(empresasToolStripMenuItem_Click);
			this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.toolStripButton3.Image = LeeXML.Properties.Resources.flujo;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(99, 73);
			this.toolStripButton3.Text = "Flujo";
			this.toolStripButton3.Click += new System.EventHandler(toolStripButton3_Click_1);
			this.toolStripButton8.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.toolStripButton8.Image = LeeXML.Properties.Resources.cxp;
			this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton8.Name = "toolStripButton8";
			this.toolStripButton8.Size = new System.Drawing.Size(89, 73);
			this.toolStripButton8.Text = "CxC";
			this.toolStripButton8.Click += new System.EventHandler(toolStripButton8_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 78);
			this.tsbCatalogoClientes.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbCatalogoClientes.Image = LeeXML.Properties.Resources.clientes;
			this.tsbCatalogoClientes.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCatalogoClientes.Name = "tsbCatalogoClientes";
			this.tsbCatalogoClientes.Size = new System.Drawing.Size(209, 73);
			this.tsbCatalogoClientes.Text = "Catálogo Clientes";
			this.tsbCatalogoClientes.Click += new System.EventHandler(toolStripButton10_Click);
			this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 78);
			this.tsbObservaciones.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbObservaciones.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbObservaciones.Image = LeeXML.Properties.Resources.observaciones;
			this.tsbObservaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbObservaciones.Name = "tsbObservaciones";
			this.tsbObservaciones.Size = new System.Drawing.Size(183, 73);
			this.tsbObservaciones.Text = "Observaciones";
			this.tsbObservaciones.Click += new System.EventHandler(tsbObservaciones_Click);
			this.tsbPapelDeTrabajo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbPapelDeTrabajo.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbPapelDeTrabajo.Image = LeeXML.Properties.Resources.papel_de_trabajo;
			this.tsbPapelDeTrabajo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPapelDeTrabajo.Name = "tsbPapelDeTrabajo";
			this.tsbPapelDeTrabajo.Size = new System.Drawing.Size(199, 73);
			this.tsbPapelDeTrabajo.Text = "Papel de Trabajo";
			this.tsbPapelDeTrabajo.Click += new System.EventHandler(toolStripButton7_Click);
			this.tsbEstadoDeCuenta.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbEstadoDeCuenta.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbEstadoDeCuenta.Image = LeeXML.Properties.Resources.cxc__1_;
			this.tsbEstadoDeCuenta.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEstadoDeCuenta.Name = "tsbEstadoDeCuenta";
			this.tsbEstadoDeCuenta.Size = new System.Drawing.Size(208, 73);
			this.tsbEstadoDeCuenta.Text = "Estado de Cuenta";
			this.tsbEstadoDeCuenta.Click += new System.EventHandler(toolStripButton5_Click_1);
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 78);
			this.tsEgresos.AutoSize = false;
			this.tsEgresos.ImageScalingSize = new System.Drawing.Size(40, 40);
			this.tsEgresos.Items.AddRange(new System.Windows.Forms.ToolStripItem[18]
			{
				this.tsbSeleccionaTipoRecibidos, this.tsbInicioRecibidos, this.toolStripSeparator9, this.tsImportarEgresos, this.toolStripSeparator10, this.toolStripSeparator11, this.tsReportesEgresos, this.toolStripSeparator12, this.toolStripDropDownButton1, this.tsFlujoEgresos,
				this.toolStripSeparator13, this.tsCxPEgresos, this.toolStripSeparator14, this.tsbObservacionesEgresos, this.tsbPapelTrabajoEgresos, this.tsEstadoDeCuentaEgresos, this.toolStripSeparator15, this.tsbCatalogoProveedores
			});
			this.tsEgresos.Location = new System.Drawing.Point(0, 78);
			this.tsEgresos.Name = "tsEgresos";
			this.tsEgresos.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.tsEgresos.Size = new System.Drawing.Size(2260, 78);
			this.tsEgresos.TabIndex = 5;
			this.tsEgresos.Text = "tsEgresos";
			this.tsbSeleccionaTipoRecibidos.BackColor = System.Drawing.Color.White;
			this.tsbSeleccionaTipoRecibidos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripSeparator18, this.tsmVerEmitidosRecibidos, this.toolStripSeparator19 });
			this.tsbSeleccionaTipoRecibidos.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
			this.tsbSeleccionaTipoRecibidos.Image = LeeXML.Properties.Resources.recibidos_cfdi_descargar;
			this.tsbSeleccionaTipoRecibidos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSeleccionaTipoRecibidos.Name = "tsbSeleccionaTipoRecibidos";
			this.tsbSeleccionaTipoRecibidos.Size = new System.Drawing.Size(256, 73);
			this.tsbSeleccionaTipoRecibidos.Text = "CFDI RECIBIDOS";
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(362, 6);
			this.tsmVerEmitidosRecibidos.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
			this.tsmVerEmitidosRecibidos.Image = LeeXML.Properties.Resources.emitidos_cfdi_descargar;
			this.tsmVerEmitidosRecibidos.Name = "tsmVerEmitidosRecibidos";
			this.tsmVerEmitidosRecibidos.Size = new System.Drawing.Size(365, 40);
			this.tsmVerEmitidosRecibidos.Text = "VER -CFDI EMITIDOS-";
			this.tsmVerEmitidosRecibidos.Click += new System.EventHandler(tsmVerEmitidosRecibidos_Click);
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(362, 6);
			this.tsbInicioRecibidos.Font = new System.Drawing.Font("Segoe UI", 15f);
			this.tsbInicioRecibidos.Image = LeeXML.Properties.Resources.inicio__1_;
			this.tsbInicioRecibidos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInicioRecibidos.Name = "tsbInicioRecibidos";
			this.tsbInicioRecibidos.Size = new System.Drawing.Size(133, 73);
			this.tsbInicioRecibidos.Text = "Inicio";
			this.tsbInicioRecibidos.Visible = false;
			this.tsbInicioRecibidos.Click += new System.EventHandler(tsbInicioRecibidos_Click);
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 78);
			this.tsImportarEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsImportarEgresos.Image = LeeXML.Properties.Resources.importar_xml;
			this.tsImportarEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsImportarEgresos.Name = "tsImportarEgresos";
			this.tsImportarEgresos.Size = new System.Drawing.Size(138, 73);
			this.tsImportarEgresos.Text = "Importar ";
			this.tsImportarEgresos.Click += new System.EventHandler(tsImportarEgresos_Click);
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 78);
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 78);
			this.toolStripSeparator11.Visible = false;
			this.tsReportesEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsReportesEgresos.Image = LeeXML.Properties.Resources.reportes__1_;
			this.tsReportesEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsReportesEgresos.Name = "tsReportesEgresos";
			this.tsReportesEgresos.Size = new System.Drawing.Size(133, 73);
			this.tsReportesEgresos.Text = "Reportes";
			this.tsReportesEgresos.Click += new System.EventHandler(tsReportesEgresos_Click);
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 78);
			this.toolStripSeparator12.Visible = false;
			this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.tsEmpresasEgresos });
			this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.toolStripDropDownButton1.Image = LeeXML.Properties.Resources.configuracion;
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(193, 73);
			this.toolStripDropDownButton1.Text = "Configuración";
			this.toolStripDropDownButton1.Visible = false;
			this.tsEmpresasEgresos.Image = LeeXML.Properties.Resources.Briefcase;
			this.tsEmpresasEgresos.Name = "tsEmpresasEgresos";
			this.tsEmpresasEgresos.Size = new System.Drawing.Size(196, 36);
			this.tsEmpresasEgresos.Text = "Empresas";
			this.tsEmpresasEgresos.Click += new System.EventHandler(tsEmpresasEgresos_Click);
			this.tsFlujoEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsFlujoEgresos.Image = LeeXML.Properties.Resources.flujo;
			this.tsFlujoEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsFlujoEgresos.Name = "tsFlujoEgresos";
			this.tsFlujoEgresos.Size = new System.Drawing.Size(99, 73);
			this.tsFlujoEgresos.Text = "Flujo";
			this.tsFlujoEgresos.Click += new System.EventHandler(tsFlujoEgresos_Click);
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 78);
			this.tsCxPEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsCxPEgresos.Image = LeeXML.Properties.Resources.cxp;
			this.tsCxPEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsCxPEgresos.Name = "tsCxPEgresos";
			this.tsCxPEgresos.Size = new System.Drawing.Size(88, 73);
			this.tsCxPEgresos.Text = "CxP";
			this.tsCxPEgresos.Click += new System.EventHandler(tsCxPEgresos_Click);
			this.toolStripSeparator14.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 78);
			this.tsbObservacionesEgresos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbObservacionesEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbObservacionesEgresos.Image = LeeXML.Properties.Resources.observaciones;
			this.tsbObservacionesEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbObservacionesEgresos.Name = "tsbObservacionesEgresos";
			this.tsbObservacionesEgresos.Size = new System.Drawing.Size(183, 73);
			this.tsbObservacionesEgresos.Text = "Observaciones";
			this.tsbObservacionesEgresos.Click += new System.EventHandler(tsbObservacionesEgresos_Click);
			this.tsbPapelTrabajoEgresos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbPapelTrabajoEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbPapelTrabajoEgresos.Image = LeeXML.Properties.Resources.papel_de_trabajo;
			this.tsbPapelTrabajoEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPapelTrabajoEgresos.Name = "tsbPapelTrabajoEgresos";
			this.tsbPapelTrabajoEgresos.Size = new System.Drawing.Size(199, 73);
			this.tsbPapelTrabajoEgresos.Text = "Papel de Trabajo";
			this.tsbPapelTrabajoEgresos.Click += new System.EventHandler(tsbPapelTrabajoEgresos_Click);
			this.tsEstadoDeCuentaEgresos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsEstadoDeCuentaEgresos.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsEstadoDeCuentaEgresos.Image = LeeXML.Properties.Resources.cxc__1_;
			this.tsEstadoDeCuentaEgresos.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsEstadoDeCuentaEgresos.Name = "tsEstadoDeCuentaEgresos";
			this.tsEstadoDeCuentaEgresos.Size = new System.Drawing.Size(208, 73);
			this.tsEstadoDeCuentaEgresos.Text = "Estado de Cuenta";
			this.tsEstadoDeCuentaEgresos.Click += new System.EventHandler(tsEstadoDeCuentaEgresos_Click);
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 78);
			this.tsbCatalogoProveedores.Font = new System.Drawing.Font("Segoe UI", 10f);
			this.tsbCatalogoProveedores.Image = LeeXML.Properties.Resources.clientes;
			this.tsbCatalogoProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCatalogoProveedores.Name = "tsbCatalogoProveedores";
			this.tsbCatalogoProveedores.Size = new System.Drawing.Size(250, 73);
			this.tsbCatalogoProveedores.Text = "Catálogo Proveedores";
			this.tsbCatalogoProveedores.Visible = false;
			this.tsbCatalogoProveedores.Click += new System.EventHandler(tsbCatalogoProveedores_Click);
			this.tsTipoRevision.AutoSize = false;
			this.tsTipoRevision.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.tsTipoRevision.Items.AddRange(new System.Windows.Forms.ToolStripItem[10] { this.tsbTipoRevisionGeneral, this.toolStripSeparator17, this.tsbCalculoIVA, this.tsbCalculoISR, this.tsbConfiguracion, this.tsbAdquiereTuLicencia, this.tslDiasExpiracion, this.tsbIndicadoresFiscales, this.tsbInformacionPreccargadaSAT, this.tsbDIOT });
			this.tsTipoRevision.Location = new System.Drawing.Point(0, 156);
			this.tsTipoRevision.Name = "tsTipoRevision";
			this.tsTipoRevision.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.tsTipoRevision.Size = new System.Drawing.Size(2260, 89);
			this.tsTipoRevision.TabIndex = 6;
			this.tsTipoRevision.Text = "toolStrip2";
			this.tsbTipoRevisionGeneral.BackColor = System.Drawing.Color.White;
			this.tsbTipoRevisionGeneral.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { this.toolStripSeparator8, this.iNGRESOSToolStripMenuItem, this.eGRESOSToolStripMenuItem });
			this.tsbTipoRevisionGeneral.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
			this.tsbTipoRevisionGeneral.Image = LeeXML.Properties.Resources.emitidos_cfdi_descargar;
			this.tsbTipoRevisionGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbTipoRevisionGeneral.Name = "tsbTipoRevisionGeneral";
			this.tsbTipoRevisionGeneral.Size = new System.Drawing.Size(336, 84);
			this.tsbTipoRevisionGeneral.Text = "Ver -Emitidos/Recibidos-";
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(335, 6);
			this.iNGRESOSToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15f);
			this.iNGRESOSToolStripMenuItem.Image = LeeXML.Properties.Resources.emitidos_cfdi_descargar;
			this.iNGRESOSToolStripMenuItem.Name = "iNGRESOSToolStripMenuItem";
			this.iNGRESOSToolStripMenuItem.Size = new System.Drawing.Size(338, 50);
			this.iNGRESOSToolStripMenuItem.Text = "CFDI EMITIDOS";
			this.iNGRESOSToolStripMenuItem.Click += new System.EventHandler(iNGRESOSToolStripMenuItem_Click);
			this.eGRESOSToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 15f);
			this.eGRESOSToolStripMenuItem.Image = LeeXML.Properties.Resources.recibidos_cfdi_descargar;
			this.eGRESOSToolStripMenuItem.Name = "eGRESOSToolStripMenuItem";
			this.eGRESOSToolStripMenuItem.Size = new System.Drawing.Size(338, 50);
			this.eGRESOSToolStripMenuItem.Text = "CFDI RECIBIDOS";
			this.eGRESOSToolStripMenuItem.Click += new System.EventHandler(eGRESOSToolStripMenuItem_Click);
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 89);
			this.tsbCalculoIVA.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
			this.tsbCalculoIVA.Image = LeeXML.Properties.Resources.calculo_iva;
			this.tsbCalculoIVA.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbCalculoIVA.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCalculoIVA.Name = "tsbCalculoIVA";
			this.tsbCalculoIVA.Size = new System.Drawing.Size(212, 84);
			this.tsbCalculoIVA.Text = "Cálculo de IVA";
			this.tsbCalculoIVA.Click += new System.EventHandler(tsbCalculoIVA_Click);
			this.tsbCalculoISR.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
			this.tsbCalculoISR.Image = LeeXML.Properties.Resources.calculo_isr;
			this.tsbCalculoISR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbCalculoISR.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCalculoISR.Name = "tsbCalculoISR";
			this.tsbCalculoISR.Size = new System.Drawing.Size(210, 84);
			this.tsbCalculoISR.Text = "Cálculo de ISR";
			this.tsbCalculoISR.Click += new System.EventHandler(tsbCalculoISR_Click);
			this.tsbConfiguracion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbConfiguracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.tsbEmpresas, this.toolStripSeparator16, this.tsmAyuda, this.tsmManualUsuario });
			this.tsbConfiguracion.Font = new System.Drawing.Font("Segoe UI", 12f);
			this.tsbConfiguracion.Image = LeeXML.Properties.Resources.configuracion;
			this.tsbConfiguracion.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbConfiguracion.Name = "tsbConfiguracion";
			this.tsbConfiguracion.Size = new System.Drawing.Size(202, 84);
			this.tsbConfiguracion.Text = "Configuración";
			this.tsbEmpresas.Font = new System.Drawing.Font("Segoe UI", 16f);
			this.tsbEmpresas.Image = LeeXML.Properties.Resources.Briefcase;
			this.tsbEmpresas.Name = "tsbEmpresas";
			this.tsbEmpresas.Size = new System.Drawing.Size(433, 54);
			this.tsbEmpresas.Text = "Empresas";
			this.tsbEmpresas.Click += new System.EventHandler(tsbEmpresas_Click);
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(430, 6);
			this.tsmAyuda.Font = new System.Drawing.Font("Segoe UI", 15f);
			this.tsmAyuda.Image = LeeXML.Properties.Resources.Questions;
			this.tsmAyuda.Name = "tsmAyuda";
			this.tsmAyuda.Size = new System.Drawing.Size(433, 54);
			this.tsmAyuda.Text = "TUTORIALES DE AYUDA";
			this.tsmAyuda.Click += new System.EventHandler(tsmAyuda_Click);
			this.tsmManualUsuario.Font = new System.Drawing.Font("Segoe UI", 15f);
			this.tsmManualUsuario.Image = LeeXML.Properties.Resources.Paper;
			this.tsmManualUsuario.Name = "tsmManualUsuario";
			this.tsmManualUsuario.Size = new System.Drawing.Size(433, 54);
			this.tsmManualUsuario.Text = "MANUAL DE USUARIO";
			this.tsmManualUsuario.Click += new System.EventHandler(tsmManualUsuario_Click);
			this.tsbAdquiereTuLicencia.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tsbAdquiereTuLicencia.BackColor = System.Drawing.SystemColors.Control;
			this.tsbAdquiereTuLicencia.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline);
			this.tsbAdquiereTuLicencia.Image = LeeXML.Properties.Resources.LOGO_BASEFISCAL;
			this.tsbAdquiereTuLicencia.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdquiereTuLicencia.Name = "tsbAdquiereTuLicencia";
			this.tsbAdquiereTuLicencia.Size = new System.Drawing.Size(305, 84);
			this.tsbAdquiereTuLicencia.Text = "¡ADQUIERE TU LICENCIA AQUÍ!";
			this.tsbAdquiereTuLicencia.Click += new System.EventHandler(tsbAdquiereTuLicencia_Click);
			this.tslDiasExpiracion.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.tslDiasExpiracion.Font = new System.Drawing.Font("Segoe UI", 6f);
			this.tslDiasExpiracion.Name = "tslDiasExpiracion";
			this.tslDiasExpiracion.Size = new System.Drawing.Size(226, 84);
			this.tslDiasExpiracion.Text = "DÍAS PARA EXPIRACIÓN DE LICENCIA       ";
			this.tslDiasExpiracion.Visible = false;
			this.tsbIndicadoresFiscales.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
			this.tsbIndicadoresFiscales.Image = LeeXML.Properties.Resources.GRAFICACALCULO_SINFONDO;
			this.tsbIndicadoresFiscales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbIndicadoresFiscales.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbIndicadoresFiscales.Name = "tsbIndicadoresFiscales";
			this.tsbIndicadoresFiscales.Size = new System.Drawing.Size(251, 84);
			this.tsbIndicadoresFiscales.Text = "Indicadores Fiscales";
			this.tsbIndicadoresFiscales.Click += new System.EventHandler(tsbIndicadoresFiscales_Click);
			this.tsbInformacionPreccargadaSAT.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
			this.tsbInformacionPreccargadaSAT.Image = LeeXML.Properties.Resources.SAT;
			this.tsbInformacionPreccargadaSAT.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.tsbInformacionPreccargadaSAT.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInformacionPreccargadaSAT.Name = "tsbInformacionPreccargadaSAT";
			this.tsbInformacionPreccargadaSAT.Size = new System.Drawing.Size(325, 84);
			this.tsbInformacionPreccargadaSAT.Text = "Información Precargada SAT";
			this.tsbInformacionPreccargadaSAT.Click += new System.EventHandler(tsbInformacionPreccargadaSAT_Click);
			this.tsbDIOT.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tsbDIOT.Image = LeeXML.Properties.Resources.FONDO_boton_TXT;
			this.tsbDIOT.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDIOT.Name = "tsbDIOT";
			this.tsbDIOT.Size = new System.Drawing.Size(136, 84);
			this.tsbDIOT.Text = "¡DIOT 2025!";
			this.tsbDIOT.Click += new System.EventHandler(tsbDIOT_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(2260, 775);
			base.Controls.Add(this.tsTipoRevision);
			base.Controls.Add(this.tsEgresos);
			base.Controls.Add(this.tsIngresos);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			base.Name = "Inicio";
			this.Text = "Base Fiscal XML";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(Inicio_Load);
			this.tsIngresos.ResumeLayout(false);
			this.tsIngresos.PerformLayout();
			this.tsEgresos.ResumeLayout(false);
			this.tsEgresos.PerformLayout();
			this.tsTipoRevision.ResumeLayout(false);
			this.tsTipoRevision.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
