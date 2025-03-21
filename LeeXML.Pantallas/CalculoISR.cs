using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LeeXML.Properties;
using LeeXMLEntidades;
using LeeXMLNegocio;
using Microsoft.Reporting.WinForms;

namespace LeeXML.Pantallas
{
	public class CalculoISR : FormBase
	{
		private IContainer components = null;

		private FolderBrowserDialog folderBrowserDialog1;

		private BindingSource entFacturaBindingSource;

		private ComboBox cmbEmpresas;

		private TabPage tabPage1;

		private TabControl tcCalculosISR;

		private TabPage tpResicoPF;

		private FlowLayoutPanel flpCalculoIsrMensual;

		private FlowLayoutPanel flowLayoutPanel6;

		private TextBox txtIngresosCobrados;

		private Label label6;

		private FlowLayoutPanel flowLayoutPanel1;

		private TextBox txtPorcentajeTablaMensual;

		private Label label2;

		private FlowLayoutPanel flowLayoutPanel3;

		private TextBox txtISRDeterminado;

		private Label label4;

		private FlowLayoutPanel flowLayoutPanel4;

		private TextBox txtISRRetenido;

		private Label label5;

		private FlowLayoutPanel flowLayoutPanel11;

		private Label label8;

		private Label label1;

		private TextBox textBox1;

		private Panel panel1;

		private Button btnRefrescar;

		private RadioButton rdoPorMesComprobantes;

		private Panel pnlPorMesVentas;

		private ComboBox cmbMesesComprobantes;

		private ComboBox cmbAñoComprobantes;

		private Label label3;

		private TextBox txtCantidadVentas;

		private TabControl tcCalculosGeneral;

		private FlowLayoutPanel flowLayoutPanel7;

		private TextBox txtISRporPagar;

		private FlowLayoutPanel flpPUE;

		private FlowLayoutPanel flpTotalesTodos;

		private ToolStrip toolStrip1;

		private ToolStripLabel toolStripLabel3;

		private ToolStripTextBox tstxtNumPUE;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripLabel toolStripLabel4;

		private ToolStripTextBox tstxtSubtotalPUE;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripLabel toolStripLabel17;

		private ToolStripTextBox tstxtIvaPUE;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripLabel toolStripLabel1;

		private ToolStripTextBox tstxtRetencionesPUE;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripLabel toolStripLabel2;

		private ToolStripTextBox tstxtImportePUE;

		private FlowLayoutPanel flowLayoutPanel16;

		private ToolStrip toolStrip2;

		private ToolStripLabel toolStripLabel5;

		private ToolStripTextBox tstxtNumCP;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripLabel toolStripLabel6;

		private ToolStripTextBox tstxtSubtotalCP;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripLabel toolStripLabel7;

		private ToolStripTextBox tstxtIvaCP;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripLabel toolStripLabel18;

		private ToolStripTextBox tstxtRetencionesCP;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripLabel toolStripLabel8;

		private ToolStripTextBox tstxtImporteCP;

		private FlowLayoutPanel flowLayoutPanel17;

		private ToolStrip toolStrip5;

		private ToolStripLabel toolStripLabel20;

		private ToolStripTextBox tstxtNumEg;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripLabel toolStripLabel21;

		private ToolStripTextBox tstxtSubtotalEg;

		private ToolStripSeparator toolStripSeparator17;

		private ToolStripLabel toolStripLabel22;

		private ToolStripTextBox tstxtIvaEg;

		private ToolStripSeparator toolStripSeparator18;

		private ToolStripLabel toolStripLabel23;

		private ToolStripTextBox tstxtRetencionesEg;

		private ToolStripSeparator toolStripSeparator19;

		private ToolStripLabel toolStripLabel24;

		private ToolStripTextBox tstxtImporteEg;

		private FlowLayoutPanel flowLayoutPanel19;

		private ToolStrip toolStrip3;

		private ToolStripLabel toolStripLabel9;

		private ToolStripTextBox tstxtNumTotal;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripLabel toolStripLabel10;

		private ToolStripTextBox tstxtSubtotalTotal;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripLabel toolStripLabel11;

		private ToolStripTextBox tstxtIvaTotal;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripLabel toolStripLabel19;

		private ToolStripTextBox tstxtRetencionesTotal;

		private ToolStripSeparator toolStripSeparator15;

		private ToolStripLabel toolStripLabel12;

		private ToolStripTextBox tstxtImporteTotal;

		private Label label11;

		private Label lbTituloISRresicoMensual;

		private TabPage tpImpresionISR;

		private TabControl tcCalculosISRimpresion;

		private TabPage tpImpresionCalculoISR;

		private ReportViewer rvCalculoISR;

		private FlowLayoutPanel flowLayoutPanel2;

		private Label lbTituloISRresicoAnual;

		private FlowLayoutPanel flowLayoutPanel5;

		private TextBox txtTotalIngresosAnual;

		private Label label9;

		private FlowLayoutPanel flowLayoutPanel8;

		private TextBox txtPorcentajeTablaAnual;

		private Label label10;

		private FlowLayoutPanel flowLayoutPanel9;

		private TextBox txtISRDeterminadoAnual;

		private Label label12;

		private FlowLayoutPanel flowLayoutPanel10;

		private TextBox txtISRRetenidoAnual;

		private Label label13;

		private FlowLayoutPanel flowLayoutPanel12;

		private TextBox txtISRporPagarAnual;

		private Label lbIsrPorPagarAfavor;

		private FlowLayoutPanel flowLayoutPanel13;

		private FlowLayoutPanel flpEmitidosAnual;

		private Label label16;

		private FlowLayoutPanel flowLayoutPanel15;

		private ToolStrip toolStrip4;

		private ToolStripLabel toolStripLabel13;

		private ToolStripTextBox tstxtNumPUEAnual;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripLabel toolStripLabel14;

		private ToolStripTextBox tstxtSubtotalPUEAnual;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripLabel toolStripLabel15;

		private ToolStripTextBox tstxtIvaPUEAnual;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripLabel toolStripLabel16;

		private ToolStripTextBox tstxtRetencionesPUEAnual;

		private ToolStripSeparator toolStripSeparator20;

		private ToolStripLabel toolStripLabel25;

		private ToolStripTextBox toolStripTextBox1;

		private FlowLayoutPanel flowLayoutPanel18;

		private ToolStrip toolStrip6;

		private ToolStripLabel toolStripLabel26;

		private ToolStripTextBox tstxtNumCPAnual;

		private ToolStripSeparator toolStripSeparator21;

		private ToolStripLabel toolStripLabel27;

		private ToolStripTextBox tstxtSubtotalCPAnual;

		private ToolStripSeparator toolStripSeparator22;

		private ToolStripLabel toolStripLabel28;

		private ToolStripTextBox tstxtIvaCPAnual;

		private ToolStripSeparator toolStripSeparator23;

		private ToolStripLabel toolStripLabel29;

		private ToolStripTextBox tstxtRetencionesCPAnual;

		private ToolStripSeparator toolStripSeparator24;

		private ToolStripLabel toolStripLabel30;

		private ToolStripTextBox toolStripTextBox2;

		private FlowLayoutPanel flowLayoutPanel20;

		private ToolStrip toolStrip7;

		private ToolStripLabel toolStripLabel31;

		private ToolStripTextBox tstxtNumEgAnual;

		private ToolStripSeparator toolStripSeparator25;

		private ToolStripLabel toolStripLabel32;

		private ToolStripTextBox tstxtSubtotalEgAnual;

		private ToolStripSeparator toolStripSeparator26;

		private ToolStripLabel toolStripLabel33;

		private ToolStripTextBox tstxtIvaEgAnual;

		private ToolStripSeparator toolStripSeparator27;

		private ToolStripLabel toolStripLabel34;

		private ToolStripTextBox tstxtRetencionesEgAnual;

		private ToolStripSeparator toolStripSeparator28;

		private ToolStripLabel toolStripLabel35;

		private ToolStripTextBox toolStripTextBox3;

		private FlowLayoutPanel flowLayoutPanel21;

		private ToolStrip toolStrip8;

		private ToolStripLabel toolStripLabel36;

		private ToolStripTextBox tstxtNumTotalAnual;

		private ToolStripSeparator toolStripSeparator29;

		private ToolStripLabel toolStripLabel37;

		private ToolStripTextBox tstxtSubtotalTotalAnual;

		private ToolStripSeparator toolStripSeparator30;

		private ToolStripLabel toolStripLabel38;

		private ToolStripTextBox tstxtIvaTotalAnual;

		private ToolStripSeparator toolStripSeparator31;

		private ToolStripLabel toolStripLabel39;

		private ToolStripTextBox tstxtRetencionesTotalAnual;

		private ToolStripSeparator toolStripSeparator32;

		private ToolStripLabel toolStripLabel40;

		private ToolStripTextBox toolStripTextBox4;

		private TextBox txtPagosProvisionalesCaptura;

		private Label label17;

		private TabPage tabPage4;

		private ReportViewer rvCalculoISRAnual;

		private Panel pnlFlujos;

		private TabPage tpActividadEmpresarial;

		private FlowLayoutPanel flpCalculoIsrAE;

		private Label lbTituloISRae;

		private FlowLayoutPanel flowLayoutPanel23;

		private TextBox txtIngresosCobradosAE;

		private Label label18;

		private FlowLayoutPanel flowLayoutPanel24;

		private TextBox txtIngresosCobradosMesesAnterioresAE;

		private Label label19;

		private FlowLayoutPanel flowLayoutPanel25;

		private TextBox txtIngresosCobradosAcumuladosGuardadoAE;

		private FlowLayoutPanel flowLayoutPanel28;

		private FlowLayoutPanel flpRecibidosMensual;

		private Label label21;

		private FlowLayoutPanel flowLayoutPanel27;

		private ToolStrip toolStrip9;

		private ToolStripLabel toolStripLabel41;

		private ToolStripTextBox tstxtNumPUEe;

		private ToolStripSeparator toolStripSeparator33;

		private ToolStripLabel toolStripLabel42;

		private ToolStripTextBox tstxtSubtotalPUEe;

		private ToolStripSeparator toolStripSeparator34;

		private ToolStripLabel toolStripLabel43;

		private ToolStripTextBox tstxtIvaPUEe;

		private ToolStripSeparator toolStripSeparator35;

		private ToolStripLabel toolStripLabel44;

		private ToolStripTextBox tstxtRetencionesPUEe;

		private ToolStripSeparator toolStripSeparator36;

		private ToolStripLabel toolStripLabel45;

		private ToolStripTextBox tstxtImportePUEe;

		private FlowLayoutPanel flowLayoutPanel29;

		private ToolStrip toolStrip10;

		private ToolStripLabel toolStripLabel46;

		private ToolStripTextBox tstxtNumCPe;

		private ToolStripSeparator toolStripSeparator37;

		private ToolStripLabel toolStripLabel47;

		private ToolStripTextBox tstxtSubtotalCPe;

		private ToolStripSeparator toolStripSeparator38;

		private ToolStripLabel toolStripLabel48;

		private ToolStripTextBox tstxtIvaCPe;

		private ToolStripSeparator toolStripSeparator39;

		private ToolStripLabel toolStripLabel49;

		private ToolStripTextBox tstxtRetencionesCPe;

		private ToolStripSeparator toolStripSeparator40;

		private ToolStripLabel toolStripLabel50;

		private ToolStripTextBox tstxtImporteCPe;

		private FlowLayoutPanel flowLayoutPanel30;

		private ToolStrip toolStrip11;

		private ToolStripLabel toolStripLabel51;

		private ToolStripTextBox tstxtNumEge;

		private ToolStripSeparator toolStripSeparator41;

		private ToolStripLabel toolStripLabel52;

		private ToolStripTextBox tstxtSubtotalEge;

		private ToolStripSeparator toolStripSeparator42;

		private ToolStripLabel toolStripLabel53;

		private ToolStripTextBox tstxtIvaEge;

		private ToolStripSeparator toolStripSeparator43;

		private ToolStripLabel toolStripLabel54;

		private ToolStripTextBox tstxtRetencionesEge;

		private ToolStripSeparator toolStripSeparator44;

		private ToolStripLabel toolStripLabel55;

		private ToolStripTextBox tstxtImporteEge;

		private FlowLayoutPanel flowLayoutPanel31;

		private ToolStrip toolStrip12;

		private ToolStripLabel toolStripLabel56;

		private ToolStripTextBox tstxtNumNDe;

		private ToolStripSeparator toolStripSeparator45;

		private ToolStripLabel toolStripLabel57;

		private ToolStripTextBox tstxtSubtotalNDe;

		private ToolStripSeparator toolStripSeparator46;

		private ToolStripLabel toolStripLabel58;

		private ToolStripTextBox tstxtIvaNDe;

		private ToolStripSeparator toolStripSeparator47;

		private ToolStripLabel toolStripLabel59;

		private ToolStripTextBox tstxtRetencionesNDe;

		private ToolStripSeparator toolStripSeparator48;

		private ToolStripLabel toolStripLabel60;

		private ToolStripTextBox tstxtImporteNDe;

		private FlowLayoutPanel flowLayoutPanel32;

		private ToolStrip toolStrip13;

		private ToolStripLabel toolStripLabel61;

		private ToolStripTextBox tstxtNumTotale;

		private ToolStripSeparator toolStripSeparator49;

		private ToolStripLabel toolStripLabel62;

		private ToolStripTextBox tstxtSubtotalTotale;

		private ToolStripSeparator toolStripSeparator50;

		private ToolStripLabel toolStripLabel63;

		private ToolStripTextBox tstxtIvaTotale;

		private ToolStripSeparator toolStripSeparator51;

		private ToolStripLabel toolStripLabel64;

		private ToolStripTextBox tstxtRetencionesTotale;

		private ToolStripSeparator toolStripSeparator52;

		private ToolStripLabel toolStripLabel65;

		private ToolStripTextBox tstxtImporteTotale;

		private FlowLayoutPanel flowLayoutPanel33;

		private Label label22;

		private FlowLayoutPanel flowLayoutPanel34;

		private TextBox txtDeduccionesPueCP;

		private Label label23;

		private FlowLayoutPanel flpFlujos;

		private DataGridView gvNominas;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;

		private DataGridViewTextBoxColumn TotalPercepciones;

		private DataGridViewTextBoxColumn TotalDeducciones;

		private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;

		private FlowLayoutPanel flowLayoutPanel14;

		private TextBox txtDeduccionesNomina;

		private Label label25;

		private FlowLayoutPanel flowLayoutPanel22;

		private FlowLayoutPanel flowLayoutPanel26;

		private Label label26;

		private FlowLayoutPanel flowLayoutPanel35;

		private TextBox txtTotalPercepcionesExentas;

		private Label label27;

		private FlowLayoutPanel flowLayoutPanel36;

		private TextBox txtTotalPercepcionesGravadas;

		private Label label28;

		private FlowLayoutPanel flowLayoutPanel37;

		private ComboBox cmbPorcentajeDeducible;

		private Label label29;

		private FlowLayoutPanel flowLayoutPanel38;

		private TextBox txtPercepcionesExentas;

		private Label label30;

		private FlowLayoutPanel flowLayoutPanel39;

		private TextBox txtTotalPercepcionesExentasGravadas;

		private Label label31;

		private FlowLayoutPanel flowLayoutPanel40;

		private RadioButton rdoEnBaseFechaDevengada;

		private RadioButton rdoEnBaseFechaPago;

		private RadioButton rdoEnBaseFechaFactura;

		private Label label32;

		private FlowLayoutPanel flowLayoutPanel41;

		private TextBox txtDeduccionesSinCFDI;

		private Label label33;

		private FlowLayoutPanel flowLayoutPanel43;

		private TextBox txtDeduccionesPorPago;

		private Label label35;

		private FlowLayoutPanel flowLayoutPanel42;

		private TextBox txtDeduccionesNominaN;

		private Label label34;

		private FlowLayoutPanel flowLayoutPanel44;

		private TextBox txtDeduccionesPagadas;

		private Label label36;

		private Button btnGuardaDeduccionesAE;

		private TextBox txtDeduccionesPagadasGuardado;

		private Panel pnlCalculoISR;

		private FlowLayoutPanel flowLayoutPanel46;

		private FlowLayoutPanel flowLayoutPanel47;

		private TextBox txtDeduccionesPagadasDelMes;

		private TextBox txtMesDeduccionesPagadas;

		private Label label37;

		private FlowLayoutPanel flowLayoutPanel48;

		private TextBox txtDeduccionesPagadasMesesAnteriores;

		private TextBox txtMesesDeduccionesPagadasMesesAnteriores;

		private Label label38;

		private FlowLayoutPanel flowLayoutPanel49;

		private TextBox txtDeduccionesPagadasAcumuladas;

		private Label label39;

		private FlowLayoutPanel flowLayoutPanel50;

		private FlowLayoutPanel flowLayoutPanel51;

		private TextBox txtPerdidasFiscalesAmortizar;

		private Label label40;

		private FlowLayoutPanel flowLayoutPanel52;

		private FlowLayoutPanel flowLayoutPanel53;

		private TextBox txtPTUpagada;

		private Label label41;

		private FlowLayoutPanel flowLayoutPanel54;

		private FlowLayoutPanel flowLayoutPanel55;

		private TextBox txtBaseISR;

		private Label label42;

		private FlowLayoutPanel flowLayoutPanel56;

		private Label label43;

		private FlowLayoutPanel flowLayoutPanel58;

		private TextBox txtISRcausado;

		private Label label44;

		private FlowLayoutPanel flowLayoutPanel59;

		private TextBox txtISRretenidoAcumulado;

		private Label label45;

		private FlowLayoutPanel flowLayoutPanel60;

		private TextBox txtPagoProvisionalAnteriores;

		private Label label46;

		private FlowLayoutPanel flowLayoutPanel61;

		private TextBox txtISRaCargo;

		private Label label47;

		private FlowLayoutPanel flowLayoutPanel57;

		private TabPage tpResicoPM;

		private FlowLayoutPanel flowLayoutPanel62;

		private Label lbTituloISRresicoPM;

		private FlowLayoutPanel flowLayoutPanel63;

		private TextBox txtIngresosCobradosRPM;

		private Label label49;

		private FlowLayoutPanel flowLayoutPanel64;

		private TextBox txtIngresosCobradosMesesAnterioresRPM;

		private Label label50;

		private FlowLayoutPanel flowLayoutPanel65;

		private TextBox txtIngresosCobradosAcumuladosRPM;

		private Label label51;

		private FlowLayoutPanel flowLayoutPanel66;

		private FlowLayoutPanel flowLayoutPanel67;

		private TextBox txtDeduccionesPagadasDelMesRPM;

		private TextBox txtMesDeduccionesPagadasRPM;

		private Label label52;

		private FlowLayoutPanel flowLayoutPanel68;

		private TextBox txtDeduccionesPagadasMesesAnterioresRPM;

		private TextBox txtMesesDeduccionesPagadasMesesAnterioresRPM;

		private Label label53;

		private FlowLayoutPanel flowLayoutPanel69;

		private TextBox txtDeduccionesPagadasAcumuladasRPM;

		private Label label54;

		private FlowLayoutPanel flowLayoutPanel70;

		private FlowLayoutPanel flowLayoutPanel71;

		private TextBox txtPerdidasFiscalesAmortizarRPM;

		private Label label55;

		private FlowLayoutPanel flowLayoutPanel72;

		private FlowLayoutPanel flowLayoutPanel73;

		private TextBox txtPTUpagadaRPM;

		private Label label56;

		private FlowLayoutPanel flowLayoutPanel74;

		private FlowLayoutPanel flowLayoutPanel75;

		private TextBox txtBaseIsrRPM;

		private Label label57;

		private FlowLayoutPanel flowLayoutPanel76;

		private FlowLayoutPanel flowLayoutPanel77;

		private Label label58;

		private FlowLayoutPanel flowLayoutPanel78;

		private TextBox txtISRcausadoRPM;

		private Label label59;

		private FlowLayoutPanel flowLayoutPanel79;

		private TextBox txtISRretenidoAcumuladoRPM;

		private Label label60;

		private FlowLayoutPanel flowLayoutPanel80;

		private TextBox txtPagoProvisionalAnterioresRPM;

		private Label label61;

		private FlowLayoutPanel flowLayoutPanel81;

		private TextBox txtISRaCargoRPM;

		private Label label62;

		private FlowLayoutPanel flowLayoutPanel82;

		private FlowLayoutPanel flowLayoutPanel83;

		private Label label63;

		private FlowLayoutPanel flowLayoutPanel84;

		private TextBox txtDeduccionesPueCpRPM;

		private Label label64;

		private FlowLayoutPanel flowLayoutPanel85;

		private TextBox txtDeduccionesNominaRPM;

		private Label label65;

		private FlowLayoutPanel flowLayoutPanel86;

		private TextBox txtDeduccionesSinCfdiRPM;

		private Label label66;

		private FlowLayoutPanel flowLayoutPanel87;

		private TextBox txtDeduccionesPorPagoRPM;

		private Label label67;

		private FlowLayoutPanel flowLayoutPanel88;

		private TextBox txtDeduccionesPagadasGuardadoRPM;

		private TextBox txtDeduccionesPagadasRPM;

		private Label label68;

		private Button btnGuardaDeduccionesRPM;

		private FlowLayoutPanel flowLayoutPanel90;

		private FlowLayoutPanel flowLayoutPanel91;

		private Label label69;

		private FlowLayoutPanel flowLayoutPanel92;

		private RadioButton rdoEnBaseFechaDevengadaRPM;

		private RadioButton rdoEnBaseFechaPagoRPM;

		private RadioButton rdoEnBaseFechaFacturaRPM;

		private Label label70;

		private FlowLayoutPanel flowLayoutPanel93;

		private TextBox txtTotalPercepcionesExentasRPM;

		private Label label71;

		private FlowLayoutPanel flowLayoutPanel94;

		private ComboBox cmbPorcentajeDeducibleRPM;

		private Label label72;

		private FlowLayoutPanel flowLayoutPanel95;

		private TextBox txtPercepcionesExentasRPM;

		private Label label73;

		private FlowLayoutPanel flowLayoutPanel96;

		private TextBox txtTotalPercepcionesGravadasRPM;

		private Label label74;

		private FlowLayoutPanel flowLayoutPanel97;

		private TextBox txtTotalPercepcionesExentasGravadasRPM;

		private Label label75;

		private FlowLayoutPanel flowLayoutPanel98;

		private TextBox txtDeduccionesNominaNRPM;

		private Label label76;

		private FlowLayoutPanel flowLayoutPanel99;

		private TextBox txtREPacumuladosEjercicios2021anteriores;

		private Label label77;

		private ComboBox cmbTasaIsrRPM;

		private FlowLayoutPanel flowLayoutPanel100;

		private TextBox txtNominaNoDeducible;

		private Label label78;

		private FlowLayoutPanel flowLayoutPanel101;

		private TextBox txtDeduccionesFiscalesNominaRPM;

		private Label label79;

		private FlowLayoutPanel flowLayoutPanel102;

		private Button btnGuardarIngresosCobrados;

		private TextBox txtIngresosCobradosAcumuladosGuardadoRPM;

		private FlowLayoutPanel flowLayoutPanel89;

		private Button btnExportarISR;

		private FlowLayoutPanel flowLayoutPanel103;

		private FlowLayoutPanel flowLayoutPanel45;

		private TextBox txtOtrosIngresosAcumulablesRPM;

		private Label label7;

		private FlowLayoutPanel flowLayoutPanel104;

		private TextBox txtIngresosCobradosNoAcumulablesRPM;

		private Label label14;

		private FlowLayoutPanel flowLayoutPanel105;

		private TextBox txtOtrosGastosPagadosNoDeduciblesRPM;

		private Label label15;

		private FlowLayoutPanel flowLayoutPanel106;

		private TextBox txtOtrosIngresosAcumulablesAE;

		private Label label48;

		private FlowLayoutPanel flowLayoutPanel107;

		private TextBox txtIngresosCobradosNoAcumulablesAE;

		private Label label80;

		private FlowLayoutPanel flowLayoutPanel108;

		private TextBox txtOtrosGastosPagadosNoDeduciblesAE;

		private Label label81;

		private TextBox txtIngresosCobradosAcumuladosAE;

		private Label label20;

		private TabPage tpRIF;

		private BindingSource entCatalogoGenericoBindingSource;

		private FlowLayoutPanel flowLayoutPanel109;

		private Button btnGuardaDeduccionesRIF;

		private FlowLayoutPanel flowLayoutPanel110;

		private Label lbTituloISRrif;

		private FlowLayoutPanel flowLayoutPanel111;

		private TextBox txtIngresosCobradosRIF;

		private Label label83;

		private FlowLayoutPanel flowLayoutPanel113;

		private TextBox txtOtrosIngresosAcumulablesRIF;

		private Label label85;

		private FlowLayoutPanel flowLayoutPanel114;

		private TextBox txtIngresosCobradosNoAcumulablesRIF;

		private Label label86;

		private FlowLayoutPanel flowLayoutPanel115;

		private TextBox txtIngresosCobradosAcumuladosGuardadoRIF;

		private TextBox txtIngresosCobradosAcumuladosRIF;

		private Label label87;

		private FlowLayoutPanel flowLayoutPanel116;

		private FlowLayoutPanel flowLayoutPanel117;

		private TextBox txtDeduccionesPagadasDelMesRIF;

		private Label label88;

		private FlowLayoutPanel flowLayoutPanel119;

		private TextBox txtGastosMayoresAingresos;

		private Label label90;

		private FlowLayoutPanel flowLayoutPanel120;

		private FlowLayoutPanel flowLayoutPanel121;

		private FlowLayoutPanel flowLayoutPanel123;

		private TextBox txtPTUpagadaRIF;

		private Label label92;

		private FlowLayoutPanel flowLayoutPanel124;

		private FlowLayoutPanel flowLayoutPanel125;

		private TextBox txtUtilidad;

		private Label label93;

		private FlowLayoutPanel flowLayoutPanel126;

		private FlowLayoutPanel flowLayoutPanel127;

		private Label label94;

		private FlowLayoutPanel flowLayoutPanel128;

		private TextBox txtISRcausadoRIF;

		private Label label95;

		private FlowLayoutPanel flowLayoutPanel129;

		private TextBox txtISRretenidoAcumuladoRIF;

		private Label label96;

		private FlowLayoutPanel flowLayoutPanel131;

		private TextBox txtISRaCargoRIF;

		private Label label98;

		private FlowLayoutPanel flowLayoutPanel132;

		private FlowLayoutPanel flowLayoutPanel133;

		private Label label99;

		private FlowLayoutPanel flowLayoutPanel134;

		private TextBox txtDeduccionesPueCpRIF;

		private Label label100;

		private FlowLayoutPanel flowLayoutPanel135;

		private TextBox txtDeduccionesNominaRIF;

		private Label label101;

		private FlowLayoutPanel flowLayoutPanel136;

		private TextBox txtDeduccionesSinCFDiRIF;

		private Label label102;

		private FlowLayoutPanel flowLayoutPanel137;

		private TextBox txtDeduccionesPorPagoRIF;

		private Label label103;

		private FlowLayoutPanel flowLayoutPanel138;

		private TextBox txtOtrosGastosPagadosNoDeduciblesRIF;

		private Label label104;

		private FlowLayoutPanel flowLayoutPanel139;

		private TextBox txtDeduccionesPagadasGuardadoRIF;

		private TextBox txtDeduccionesPagadasRIF;

		private Label label105;

		private FlowLayoutPanel flowLayoutPanel140;

		private FlowLayoutPanel flowLayoutPanel141;

		private Label label106;

		private FlowLayoutPanel flowLayoutPanel142;

		private RadioButton rdoEnBaseFechaDevengadaRIF;

		private RadioButton rdoEnBaseFechaPagoRIF;

		private RadioButton rdoEnBaseFechaFacturaRIF;

		private Label label107;

		private FlowLayoutPanel flowLayoutPanel143;

		private TextBox txtTotalPercepcionesExentasRIF;

		private Label label108;

		private FlowLayoutPanel flowLayoutPanel144;

		private ComboBox cmbPorcentajeDeducibleRIF;

		private Label label109;

		private FlowLayoutPanel flowLayoutPanel145;

		private TextBox txtPercepcionesExentasRIF;

		private Label label110;

		private FlowLayoutPanel flowLayoutPanel146;

		private TextBox txtTotalPercepcionesGravadasRIF;

		private Label label111;

		private FlowLayoutPanel flowLayoutPanel147;

		private TextBox txtDeduccionesNominaNRIF;

		private Label label112;

		private FlowLayoutPanel flowLayoutPanel148;

		private TextBox txtTotalPercepcionesExentasGravadasRIF;

		private Label label113;

		private TextBox txtGastosMayoresAIngresosPeriodosAnteriores;

		private Label label84;

		private FlowLayoutPanel flowLayoutPanel112;

		private ComboBox cmbPorcentajeReduccionRIF;

		private Label label89;

		private FlowLayoutPanel flowLayoutPanel118;

		private TextBox txtIsrReducido;

		private Label label91;

		private FlowLayoutPanel flowLayoutPanel122;

		private TextBox txtIsrPorPagarRIF;

		private Label label97;

		private TabPage tabPage2;

		private FlowLayoutPanel flowLayoutPanel130;

		private Button btnGuardarCalculoAR;

		private FlowLayoutPanel flowLayoutPanel149;

		private Label lbTituloISRar;

		private FlowLayoutPanel flowLayoutPanel150;

		private TextBox txtIngresosCobradosPeriodoAR;

		private Label label114;

		private FlowLayoutPanel flowLayoutPanel151;

		private TextBox txtOtrosIngresosAcumulablesAR;

		private Label label115;

		private FlowLayoutPanel flowLayoutPanel152;

		private TextBox txtIngresosCobradosNoAcumulablesAR;

		private Label label116;

		private FlowLayoutPanel flowLayoutPanel153;

		private TextBox txtIngresosCobradosAcumuladosGuardadoAR;

		private TextBox txtIngresosCobradosAcumuladosAR;

		private Label label117;

		private FlowLayoutPanel flowLayoutPanel154;

		private FlowLayoutPanel flowLayoutPanel155;

		private ComboBox cmbDeduccionOpcionalAR;

		private Label label118;

		private FlowLayoutPanel flowLayoutPanel156;

		private TextBox txtPredialAR;

		private Label label119;

		private FlowLayoutPanel flowLayoutPanel157;

		private FlowLayoutPanel flowLayoutPanel183;

		private TextBox txtTotalDeduccionesPeriodoAR;

		private Label label142;

		private FlowLayoutPanel flowLayoutPanel158;

		private FlowLayoutPanel flowLayoutPanel159;

		private TextBox txtBaseAR;

		private Label label121;

		private FlowLayoutPanel flowLayoutPanel160;

		private FlowLayoutPanel flowLayoutPanel161;

		private Label label122;

		private FlowLayoutPanel flowLayoutPanel162;

		private TextBox txtISRCausadoAR;

		private Label label123;

		private FlowLayoutPanel flowLayoutPanel164;

		private TextBox txtISRRetenidoPeriodoAR;

		private Label label125;

		private FlowLayoutPanel flowLayoutPanel165;

		private TextBox txtISRaCargoAR;

		private Label label126;

		private FlowLayoutPanel flowLayoutPanel166;

		private TextBox txtDeduccionesOpcional;

		private FlowLayoutPanel flpEmpresas;

		private Label label24;

		private Button btnBuscaEmpresa;

		private int PeriocidadId { get; set; }

		private List<EntFactura> ListaComprobantes { get; set; }

		private List<EntFactura> ListaComprobantesAnual { get; set; }

		private List<EntFactura> ListaComprobantesEgresos { get; set; }

		private List<EntCatalogoPercepciones> ListaPercepciones { get; set; }

		private List<EntCatalogoPercepciones> ListaPercepcionesPTU { get; set; }

		private bool DeduccionesPagadasGuardada { get; set; }

		private bool DeduccionesPagadasGuardadaRPM { get; set; }

		private bool DeduccionesPagadasGuardadaRIF { get; set; }

		private bool DeduccionesPagadasGuardadaARR { get; set; }

		public void VerificaEmpresa()
		{
			cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
		}

		public CalculoISR()
		{
			InitializeComponent();
		}

		private void InicializaPantalla()
		{
			PeriocidadId = 1;
			CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
			CargaAñosCmb(cmbAñoComprobantes);
			SeleccionaPeriodoActual(cmbMesesComprobantes, PeriocidadId, new Label());
			cmbAñoComprobantes.SelectedIndex = cmbAñoComprobantes.FindStringExact(DateTime.Today.Year.ToString());
			cmbPorcentajeDeducible.SelectedIndex = 0;
			cmbTasaIsrRPM.SelectedIndex = 0;
			cmbPorcentajeDeducibleRPM.SelectedIndex = 0;
			cmbPorcentajeDeducibleRIF.SelectedIndex = 0;
			cmbPorcentajeReduccionRIF.SelectedIndex = 0;
			cmbDeduccionOpcionalAR.SelectedIndex = 0;
			if (Program.EmpresaSeleccionada.Id == 0)
			{
				MuestraMensajePaginaCompra vMensaje = new MuestraMensajePaginaCompra();
				vMensaje.Text = "SIN LICENCIAS ACTIVAS";
				vMensaje.Mensaje = "LICENCIA(S) VENCIDA(S)";
				vMensaje.ShowDialog();
			}
		}

		private void LeeXMLs_Load(object sender, EventArgs e)
		{
			try
			{
				CargaEmpresas(cmbEmpresas, Program.UsuarioSeleccionado.CompañiaId);
				if (Program.EmpresaSeleccionada == null)
				{
					Program.EmpresaSeleccionada = SeleccionaEmpresa();
				}
				Program.CambiaEmpresa = false;
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
				Program.CambiaEmpresa = true;
				InicializaPantalla();
				tcCalculosGeneral.TabPages.Remove(tpImpresionISR);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CargaComprobantes(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantes = new BusFacturas().ObtieneComprobantesFiscales(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantes.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
		}

		private void FiltraComprobantes(List<EntFactura> ListaComprobantes, bool PUE, bool PPD, bool Complementos, bool Egresos, DateTime FechaDesde, DateTime FechaHasta)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			if (PUE || PPD || Complementos || Egresos)
			{
				lstFiltro = ListaComprobantes.Where((EntFactura P) => ((P.MetodoPagoId == Convert.ToInt16(PUE) || P.MetodoPagoId == 2 * Convert.ToInt16(PPD)) && P.TipoComprobanteId == 1) || P.TipoComprobanteId == 5 * Convert.ToInt16(Complementos) || (P.TipoComprobanteId == 2 * Convert.ToInt16(Egresos) && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList();
			}
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUE.TextBox, tstxtSubtotalPUE.TextBox, tstxtIvaPUE.TextBox, tstxtRetencionesPUE.TextBox, tstxtNumPUE.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde).ToList(), false, tstxtImporteCP.TextBox, tstxtSubtotalCP.TextBox, tstxtIvaCP.TextBox, tstxtRetencionesCP.TextBox, tstxtNumCP.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList(), false, tstxtImporteEg.TextBox, tstxtSubtotalEg.TextBox, tstxtIvaEg.TextBox, tstxtRetencionesEg.TextBox, tstxtNumEg.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUE.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCP.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEg.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUE.TextBox) + ConvierteTextoADecimal(tstxtIvaCP.TextBox) - ConvierteTextoADecimal(tstxtIvaEg.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUE.TextBox) + ConvierteTextoADecimal(tstxtImporteCP.TextBox) - ConvierteTextoADecimal(tstxtImporteEg.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUE.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCP.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEg.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUE.TextBox) + ConvierteTextoADecimal(tstxtNumCP.TextBox) + ConvierteTextoADecimal(tstxtNumEg.TextBox);
			tstxtSubtotalTotal.TextBox.Text = FormatoMoney(subtotal);
			tstxtIvaTotal.TextBox.Text = FormatoMoney(iva);
			tstxtRetencionesTotal.TextBox.Text = FormatoMoney(retenciones);
			tstxtImporteTotal.TextBox.Text = FormatoMoney(total);
			tstxtNumTotal.TextBox.Text = num.ToString();
			txtISRRetenido.Text = FormatoMoney(retenciones);
			txtIngresosCobrados.Text = FormatoMoney(subtotal);
			txtIngresosCobradosAE.Text = FormatoMoney(subtotal);
			txtIngresosCobradosRIF.Text = FormatoMoney(subtotal);
			txtIngresosCobradosPeriodoAR.Text = FormatoMoney(subtotal);
		}

		private void CargaComprobantesEgresos(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta)
		{
			ListaComprobantesEgresos = new BusFacturas().ObtieneComprobantesFiscalesEgresos(Empresa, FechaDesde, FechaHasta, 1);
			ListaComprobantesEgresos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesEgresosPorFechaPagoExclusivo(Empresa, FechaDesde, FechaHasta, 1));
		}

		private void FiltraComprobantesEgresos(List<EntFactura> ListaComprobantes, DateTime FechaDesde, DateTime FechaHasta)
		{
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUEe.TextBox, tstxtSubtotalPUEe.TextBox, tstxtIvaPUEe.TextBox, tstxtRetencionesPUEe.TextBox, tstxtNumPUEe.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde).ToList(), false, tstxtImporteCPe.TextBox, tstxtSubtotalCPe.TextBox, tstxtIvaCPe.TextBox, tstxtRetencionesCPe.TextBox, tstxtNumCPe.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && P.Deducible) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && P.Deducible)).ToList(), false, tstxtImporteEge.TextBox, tstxtSubtotalEge.TextBox, tstxtIvaEge.TextBox, tstxtRetencionesEge.TextBox, tstxtNumEge.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => ((P.TipoComprobanteId == 1 && P.MetodoPagoId == 1) || P.TipoComprobanteId == 5) && !P.Deducible).ToList(), false, tstxtImporteNDe.TextBox, tstxtSubtotalNDe.TextBox, tstxtIvaNDe.TextBox, tstxtRetencionesNDe.TextBox, tstxtNumNDe.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUEe.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCPe.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEge.TextBox) - ConvierteTextoADecimal(tstxtSubtotalNDe.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUEe.TextBox) + ConvierteTextoADecimal(tstxtIvaCPe.TextBox) - ConvierteTextoADecimal(tstxtIvaEge.TextBox) - ConvierteTextoADecimal(tstxtIvaNDe.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUEe.TextBox) + ConvierteTextoADecimal(tstxtImporteCPe.TextBox) - ConvierteTextoADecimal(tstxtImporteEge.TextBox) - ConvierteTextoADecimal(tstxtImporteNDe.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUEe.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCPe.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEge.TextBox) - ConvierteTextoADecimal(tstxtRetencionesNDe.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUEe.TextBox) + ConvierteTextoADecimal(tstxtNumCPe.TextBox) + ConvierteTextoADecimal(tstxtNumEge.TextBox) + ConvierteTextoADecimal(tstxtNumNDe.TextBox);
			tstxtSubtotalTotale.TextBox.Text = FormatoMoney(subtotal);
			txtDeduccionesPueCP.Text = FormatoMoney(subtotal);
			txtDeduccionesPueCpRIF.Text = FormatoMoney(subtotal);
			tstxtIvaTotale.TextBox.Text = FormatoMoney(iva);
			tstxtRetencionesTotale.TextBox.Text = FormatoMoney(retenciones);
			tstxtImporteTotale.TextBox.Text = FormatoMoney(total);
			tstxtNumTotale.TextBox.Text = num.ToString();
		}

		private void CargaPercepciones(EntEmpresa Empresa, DateTime FechaDesde, DateTime FechaHasta, int OpcionFechaId, TextBox TxtTotalPercepcionesExentas, TextBox TxtTotalPercepcionesGravadas)
		{
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			DateTime fechaDesdeAnual = base.FechaDesde(1, periodo.Id);
			ListaPercepcionesPTU = (from P in new BusFacturas().ObtieneComprobantesFiscalesPercepciones(Empresa, fechaDesdeAnual, FechaHasta, OpcionFechaId)
				where P.Clave == "003"
				select P).ToList();
			txtPTUpagada.Text = FormatoMoney(ListaPercepcionesPTU.Sum((EntCatalogoPercepciones P) => P.Excento + P.Gravado));
			txtPTUpagadaRIF.Text = txtPTUpagada.Text;
			ListaPercepciones = (from P in new BusFacturas().ObtieneComprobantesFiscalesPercepciones(Empresa, FechaDesde, FechaHasta, OpcionFechaId)
				where P.Clave != "003"
				select P).ToList();
			TxtTotalPercepcionesExentas.Text = FormatoMoney(ListaPercepciones.Sum((EntCatalogoPercepciones P) => P.Excento));
			TxtTotalPercepcionesGravadas.Text = FormatoMoney(ListaPercepciones.Sum((EntCatalogoPercepciones P) => P.Gravado));
			txtTotalPercepcionesExentasGravadas.Text = FormatoMoney(ConvierteTextoADecimal(TxtTotalPercepcionesExentas) + ConvierteTextoADecimal(TxtTotalPercepcionesGravadas));
			txtTotalPercepcionesExentasRIF.Text = TxtTotalPercepcionesExentas.Text;
			txtTotalPercepcionesGravadasRIF.Text = TxtTotalPercepcionesGravadas.Text;
			txtTotalPercepcionesExentasGravadasRIF.Text = txtTotalPercepcionesExentasGravadas.Text;
		}

		private void CargaComprobantesAnual(EntEmpresa Empresa, int Año)
		{
			DateTime fechaDesdeAnual = FechaDesde(1, Año);
			DateTime fechaHastaAnual = FechaHasta(12, Año);
			ListaComprobantesAnual = new BusFacturas().ObtieneComprobantesFiscales(Empresa, fechaDesdeAnual, fechaHastaAnual, 1);
			ListaComprobantesAnual.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Empresa, fechaDesdeAnual, fechaHastaAnual, 1));
		}

		private void FiltraComprobantesAnual(List<EntFactura> ListaComprobantes, int Año)
		{
			List<EntFactura> lstFiltro = new List<EntFactura>();
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => P.MetodoPagoId == 1 && P.TipoComprobanteId == 1).ToList(), false, tstxtImportePUE.TextBox, tstxtSubtotalPUEAnual.TextBox, tstxtIvaPUEAnual.TextBox, tstxtRetencionesPUEAnual.TextBox, tstxtNumPUEAnual.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde(1, Año)).ToList(), false, tstxtImporteCP.TextBox, tstxtSubtotalCPAnual.TextBox, tstxtIvaCPAnual.TextBox, tstxtRetencionesCPAnual.TextBox, tstxtNumCPAnual.TextBox);
			CalculaSumaTotalFromListaProductosISRretenido(ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).ToList(), false, tstxtImporteEg.TextBox, tstxtSubtotalEgAnual.TextBox, tstxtIvaEgAnual.TextBox, tstxtRetencionesEgAnual.TextBox, tstxtNumEgAnual.TextBox);
			decimal subtotal = ConvierteTextoADecimal(tstxtSubtotalPUEAnual.TextBox) + ConvierteTextoADecimal(tstxtSubtotalCPAnual.TextBox) - ConvierteTextoADecimal(tstxtSubtotalEgAnual.TextBox);
			decimal iva = ConvierteTextoADecimal(tstxtIvaPUEAnual.TextBox) + ConvierteTextoADecimal(tstxtIvaCPAnual.TextBox) - ConvierteTextoADecimal(tstxtIvaEgAnual.TextBox);
			decimal total = ConvierteTextoADecimal(tstxtImportePUE.TextBox) + ConvierteTextoADecimal(tstxtImporteCP.TextBox) - ConvierteTextoADecimal(tstxtImporteEg.TextBox);
			decimal retenciones = ConvierteTextoADecimal(tstxtRetencionesPUEAnual.TextBox) + ConvierteTextoADecimal(tstxtRetencionesCPAnual.TextBox) - ConvierteTextoADecimal(tstxtRetencionesEgAnual.TextBox);
			decimal num = ConvierteTextoADecimal(tstxtNumPUEAnual.TextBox) + ConvierteTextoADecimal(tstxtNumCPAnual.TextBox) + ConvierteTextoADecimal(tstxtNumEgAnual.TextBox);
			tstxtSubtotalTotalAnual.TextBox.Text = FormatoMoney(subtotal);
			txtTotalIngresosAnual.Text = FormatoMoney(subtotal);
			tstxtIvaTotalAnual.TextBox.Text = FormatoMoney(iva);
			tstxtRetencionesTotalAnual.TextBox.Text = FormatoMoney(retenciones);
			txtISRRetenidoAnual.Text = FormatoMoney(retenciones);
			tstxtImporteTotal.TextBox.Text = FormatoMoney(total);
			tstxtNumTotalAnual.TextBox.Text = num.ToString();
		}

		public List<EntEstadoDeCuenta> CalculaISRresico(int Año, decimal TotalIngreso, decimal ISRRetenido, TextBox TextBoxPorcentaje, TextBox TextBoxIsrDeterminado, TextBox TextBoxIsrPorPagar)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			List<EntEstadoDeCuenta> lstCatalogoISR = new BusEmpresas().ObtieneCatalogoISR(1, 1);
			decimal isrDeterminado = default(decimal);
			decimal porcentaje = default(decimal);
			for (int x = 0; x < lstCatalogoISR.Count; x++)
			{
				EntEstadoDeCuenta lista = lstCatalogoISR[x];
				if (TotalIngreso > lista.Total)
				{
					if (x == 4)
					{
						isrDeterminado = TotalIngreso * (lista.IVA / 100m);
						porcentaje = lista.IVA;
						break;
					}
					continue;
				}
				isrDeterminado = TotalIngreso * (lista.IVA / 100m);
				porcentaje = lista.IVA;
				break;
			}
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "INGRESOS COBRADOS DEL MES ",
				Total = TotalIngreso
			});
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "Porcentaje Tabla Mensual".ToUpper(),
				Total = porcentaje
			});
			TextBoxPorcentaje.Text = porcentaje.ToString("0.00");
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(=) ISR DETERMINADO",
				Total = isrDeterminado
			});
			TextBoxIsrDeterminado.Text = FormatoMoney(isrDeterminado);
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(-) ISR RETENIDO",
				Total = Math.Round(ISRRetenido, MidpointRounding.AwayFromZero)
			});
			decimal isrPorPagar = isrDeterminado - ISRRetenido;
			if (isrPorPagar < 0m)
			{
				isrPorPagar = default(decimal);
			}
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = " (=) ISR POR PAGAR",
				Total = isrPorPagar
			});
			TextBoxIsrPorPagar.Text = FormatoMoney(isrPorPagar);
			return lstISR;
		}

		public List<EntEstadoDeCuenta> CalculaISRAnual(decimal TotalIngreso, decimal ISRRetenido, decimal PagosProvisionales, TextBox TextBoxPorcentaje, TextBox TextBoxIsrDeterminado, TextBox TextBoxIsrPorPagar, Label LabelIsrPorPagarAfavor)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			List<EntEstadoDeCuenta> lstCatalogoISR = new BusEmpresas().ObtieneCatalogoISR(1, 2);
			decimal isrDeterminado = default(decimal);
			decimal porcentaje = default(decimal);
			for (int x = 0; x < lstCatalogoISR.Count; x++)
			{
				EntEstadoDeCuenta lista = lstCatalogoISR[x];
				if (TotalIngreso > lista.Total)
				{
					if (x == 4)
					{
						isrDeterminado = TotalIngreso * (lista.IVA / 100m);
						porcentaje = lista.IVA;
						break;
					}
					continue;
				}
				isrDeterminado = TotalIngreso * (lista.IVA / 100m);
				porcentaje = lista.IVA;
				break;
			}
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "INGRESOS COBRADOS EN EL AÑO ",
				Total = TotalIngreso
			});
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "PORCENTAJE TABLA ANUAL",
				Total = porcentaje
			});
			TextBoxPorcentaje.Text = porcentaje.ToString("0.00");
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(=) ISR DETERMINADO",
				Total = isrDeterminado
			});
			TextBoxIsrDeterminado.Text = FormatoMoney(isrDeterminado);
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(-) ISR RETENIDO",
				Total = Math.Round(ISRRetenido, MidpointRounding.AwayFromZero)
			});
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = "(-) PAGOS PROVISIONALES EFECTUADOS:",
				Total = PagosProvisionales
			});
			decimal isrPorPagarAfavor = isrDeterminado - ISRRetenido - PagosProvisionales;
			string porPagarAfavor = "";
			porPagarAfavor = ((!(isrPorPagarAfavor < 0m)) ? "POR PAGAR:" : "A FAVOR:");
			lstISR.Add(new EntEstadoDeCuenta
			{
				Descripcion = " (=) ISR " + porPagarAfavor,
				Total = isrPorPagarAfavor
			});
			LabelIsrPorPagarAfavor.Text = "(=) ISR " + porPagarAfavor;
			TextBoxIsrPorPagar.Text = FormatoMoney(isrPorPagarAfavor);
			return lstISR;
		}

		private void AgregaElementoEnLista(List<EntEstadoDeCuenta> Lista, string Descripcion, decimal Total)
		{
			string totals = "";
			if (Total != 0m)
			{
				totals = FormatoMoney(Total);
			}
			Lista.Add(new EntEstadoDeCuenta
			{
				Fecha = DateTime.Now,
				Descripcion = Descripcion.ToUpper(),
				NumeroFactura = totals
			});
		}

		private void AgregaElementoEnLista(List<EntEstadoDeCuenta> Lista, string Descripcion, string Total)
		{
			Lista.Add(new EntEstadoDeCuenta
			{
				Fecha = DateTime.Now,
				Descripcion = Descripcion.ToUpper(),
				NumeroFactura = Total
			});
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionISRresico(decimal TotalIngreso, string PorcentajeTablaMensual, decimal IsrDeterminado, decimal IsrRetenido, decimal IsrPorPagar, decimal IngresosCobrados, string PorcentajeTablaAnual, decimal IsrDeterminadoAnual, decimal IsrRetenidoAnual, decimal PagosProvisionales, string IsrPorPagarAfavor, decimal IsrPorPagarAnual)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstISR, "CALCULO DE ISR RESICO MENSUAL", "");
			AgregaElementoEnLista(lstISR, "INGRESOS COBRADOS DEL MES: ", TotalIngreso);
			AgregaElementoEnLista(lstISR, "(x) PORCENTAJE DE TABLA MENSUAL: ", PorcentajeTablaMensual);
			AgregaElementoEnLista(lstISR, "(=) ISR DETERMINADO: ", IsrDeterminado);
			AgregaElementoEnLista(lstISR, "(-) ISR RETENIDO: ", IsrRetenido);
			AgregaElementoEnLista(lstISR, "(=) ISR POR PAGAR", IsrPorPagar);
			AgregaElementoEnLista(lstISR, "", "");
			AgregaElementoEnLista(lstISR, " ", "");
			AgregaElementoEnLista(lstISR, "  ", "");
			AgregaElementoEnLista(lstISR, "   ", "");
			AgregaElementoEnLista(lstISR, "CALCULO DE ISR RESICO ANUAL", "");
			AgregaElementoEnLista(lstISR, "INGRESOS COBRADOS EN EL AÑO: ", IngresosCobrados);
			AgregaElementoEnLista(lstISR, "(x) PORCENTAJE DE TABLA ANUAL: ", PorcentajeTablaAnual);
			AgregaElementoEnLista(lstISR, "(=) ISR DETERMINADO:  ", IsrDeterminadoAnual);
			AgregaElementoEnLista(lstISR, "(-) ISR RETENIDO:  ", IsrRetenidoAnual);
			AgregaElementoEnLista(lstISR, "(-) PAGOS PROVISIONALES EFECTUADOS: ", PagosProvisionales);
			AgregaElementoEnLista(lstISR, IsrPorPagarAfavor, IsrPorPagarAnual);
			return lstISR;
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionISRresicoMoral(decimal TotalIngreso, decimal IngresosCobradosMesesAnteriores, decimal OtrosIngresosAcumulables, decimal RepAcumulados2021, decimal IngresosCobradosNoAcumulables, decimal IngresosAcumulados, decimal DeduccionesPagadasMes, decimal DeduccionesPagadasMesesAnteriores, decimal DeduccionesPagadasAcumuladas, decimal PerdidasFiscalesAmortizar, decimal PtuPagada, decimal BaseISR, string TasaISR, decimal IsrCausado, decimal IsrRetenidoAcumulado, decimal PagosProvisionalesAnteriores, decimal IsrCargo)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstISR, "INGRESOS COBRADOS DEL MES: ", TotalIngreso);
			AgregaElementoEnLista(lstISR, "(+) INGRESOS COBRADOS DE MESES ANTERIORES: ", IngresosCobradosMesesAnteriores);
			AgregaElementoEnLista(lstISR, "(+) OTROS INGRESOS ACUMULABLES: ", OtrosIngresosAcumulables);
			AgregaElementoEnLista(lstISR, "(-) REP DE CFDI ACUMULADOS EN EJERCICIO 2021 Y ANTERIORES: ", RepAcumulados2021);
			AgregaElementoEnLista(lstISR, "(-) INGRESOS COBRADOS NO ACUMULABLES: ", IngresosCobradosNoAcumulables);
			AgregaElementoEnLista(lstISR, "(=) INGRESOS COBRADOS ACUMULADOS: ", IngresosAcumulados);
			AgregaElementoEnLista(lstISR, "", 0m);
			AgregaElementoEnLista(lstISR, "DEDUCCIONES PAGADAS DEL MES: ", DeduccionesPagadasMes);
			AgregaElementoEnLista(lstISR, "(+) DEDUCCIONES PAGADAS DE MESES ANTERIORES: ", DeduccionesPagadasMesesAnteriores);
			AgregaElementoEnLista(lstISR, "(=) DEDUCCIONES PAGADAS ACUMULADAS: ", DeduccionesPagadasAcumuladas);
			AgregaElementoEnLista(lstISR, " ", 0m);
			AgregaElementoEnLista(lstISR, "(-) PERDIDAS FISCALES DE AMORTIZAR: ", PerdidasFiscalesAmortizar);
			AgregaElementoEnLista(lstISR, "(-) PTU PAGADA EN EL EJERCICIO: ", PtuPagada);
			AgregaElementoEnLista(lstISR, "(=) BASE PARA ISR: ", BaseISR);
			AgregaElementoEnLista(lstISR, "  ", 0m);
			AgregaElementoEnLista(lstISR, "(x)TASA DE ISR: ", TasaISR);
			AgregaElementoEnLista(lstISR, "ISR CAUSADO: ", IsrCausado);
			AgregaElementoEnLista(lstISR, "(-) ISR RETENIDO ACUMULADO: ", IsrRetenidoAcumulado);
			AgregaElementoEnLista(lstISR, "(-) PAGOS PROVISIONALES ANTERIORES: ", PagosProvisionalesAnteriores);
			AgregaElementoEnLista(lstISR, "(=) ISR A CARGO: ", IsrCargo);
			AgregaElementoEnLista(lstISR, "   ", "");
			return lstISR;
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionISRae(decimal TotalIngreso, decimal IngresosCobradosMesesAnteriores, decimal OtrosIngresosAcumulables, decimal IngresosCobradosNoAcumulables, decimal IngresosAcumulados, string Mes, decimal DeduccionesPagadasMes, string MesesAnteriores, decimal DeduccionesPagadasMesesAnteriores, decimal DeduccionesPagadasAcumuladas, decimal PerdidasFiscalesAmortizar, decimal PtuPagada, decimal BaseISR, decimal IsrCausado, decimal IsrRetenidoAcumulado, decimal PagosProvisionalesAnteriores, decimal IsrCargo)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstISR, "INGRESOS COBRADOS DEL MES: ", TotalIngreso);
			AgregaElementoEnLista(lstISR, "(+) INGRESOS COBRADOS DE MESES ANTERIORES: ", IngresosCobradosMesesAnteriores);
			AgregaElementoEnLista(lstISR, "(+) OTROS INGRESOS ACUMULABLES: ", OtrosIngresosAcumulables);
			AgregaElementoEnLista(lstISR, "(-) INGRESOS COBRADOS NO ACUMULABLES: ", IngresosCobradosNoAcumulables);
			AgregaElementoEnLista(lstISR, "(=) INGRESOS COBRADOS ACUMULADOS: ", IngresosAcumulados);
			AgregaElementoEnLista(lstISR, "", 0m);
			AgregaElementoEnLista(lstISR, "DEDUCCIONES PAGADAS DEL MES: ", FormatoMoney(DeduccionesPagadasMes));
			AgregaElementoEnLista(lstISR, "(+) DEDUCCIONES PAGADAS DE MESES ANTERIORES: ", FormatoMoney(DeduccionesPagadasMesesAnteriores));
			AgregaElementoEnLista(lstISR, "(=) DEDUCCIONES PAGADAS ACUMULADAS: ", DeduccionesPagadasAcumuladas);
			AgregaElementoEnLista(lstISR, " ", 0m);
			AgregaElementoEnLista(lstISR, "(-) PERDIDAS FISCALES DE AMORTIZAR: ", PerdidasFiscalesAmortizar);
			AgregaElementoEnLista(lstISR, "(-) PTU PAGADA EN EL EJERCICIO: ", PtuPagada);
			AgregaElementoEnLista(lstISR, "(=) BASE PARA ISR: ", BaseISR);
			AgregaElementoEnLista(lstISR, "  ", 0m);
			AgregaElementoEnLista(lstISR, "APLICACIÓN DE TARIFA SOBRE LA BASE", "");
			AgregaElementoEnLista(lstISR, "ISR CAUSADO: ", IsrCausado);
			AgregaElementoEnLista(lstISR, "(-) ISR RETENIDO ACUMULADO: ", IsrRetenidoAcumulado);
			AgregaElementoEnLista(lstISR, "(-) PAGOS PROVISIONALES ANTERIORES: ", PagosProvisionalesAnteriores);
			AgregaElementoEnLista(lstISR, "(=) ISR A CARGO: ", IsrCargo);
			AgregaElementoEnLista(lstISR, "   ", "");
			return lstISR;
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionISRrif(decimal TotalIngreso, decimal OtrosIngresosAcumulables, decimal IngresosCobradosNoAcumulables, decimal IngresosAcumulados, decimal DeduccionesPagadasMes, decimal PtuPagada, decimal GastosMayoresAingresos, decimal GastosMayoresAingresosPeriodosAnteriores, decimal BaseISR, decimal IsrCausado, string PorcentajeReduccion, decimal IsrReducido, decimal IsrRetenidoAcumulado, decimal IsrCargo, decimal IsrPorPagar)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstISR, "INGRESOS COBRADOS DEL PERIODO: ", TotalIngreso);
			AgregaElementoEnLista(lstISR, "(+) OTROS INGRESOS ACUMULABLES: ", OtrosIngresosAcumulables);
			AgregaElementoEnLista(lstISR, "(-) INGRESOS COBRADOS NO ACUMULABLES: ", IngresosCobradosNoAcumulables);
			AgregaElementoEnLista(lstISR, "(=) INGRESOS COBRADOS ACUMULADOS: ", IngresosAcumulados);
			AgregaElementoEnLista(lstISR, "", "");
			AgregaElementoEnLista(lstISR, "DEDUCCIONES PAGADAS DEL PERIODO: ", DeduccionesPagadasMes);
			AgregaElementoEnLista(lstISR, "PTU PAGADA EN EL EJERCICIO: ", PtuPagada);
			AgregaElementoEnLista(lstISR, " ", "");
			AgregaElementoEnLista(lstISR, "GASTOS MAYORES A INGRESOS DEL PERIODO: ", GastosMayoresAingresos);
			AgregaElementoEnLista(lstISR, "GASTOS MAYORES A INGRESOS DE PERIODOS ANTERIORES: ", GastosMayoresAingresosPeriodosAnteriores);
			AgregaElementoEnLista(lstISR, "  ", "");
			AgregaElementoEnLista(lstISR, "(=) UTILIDAD: ", BaseISR);
			AgregaElementoEnLista(lstISR, "   ", "");
			AgregaElementoEnLista(lstISR, "APLICACIÓN DE TARIFA SOBRE LA BASE", "");
			AgregaElementoEnLista(lstISR, "ISR CAUSADO: ", IsrCausado);
			AgregaElementoEnLista(lstISR, "(x) PORCENTAJE DE REDUCCIÓN: ", PorcentajeReduccion);
			AgregaElementoEnLista(lstISR, "ISR REDUCIDO: ", IsrReducido);
			AgregaElementoEnLista(lstISR, "ISR A CARGO: ", IsrCargo);
			AgregaElementoEnLista(lstISR, "(-) ISR RETENIDO ACUMULADO: ", IsrRetenidoAcumulado);
			AgregaElementoEnLista(lstISR, "(=) ISR POR PAGAR", IsrPorPagar);
			return lstISR;
		}

		public List<EntEstadoDeCuenta> ObtieneListaImpresionISRarr(decimal TotalIngreso, decimal OtrosIngresosAcumulables, decimal IngresosCobradosNoAcumulables, decimal IngresosAcumulados, decimal DeduccionesOpcional, decimal Predial, decimal TotalDeduccionesPeriodo, decimal BaseISR, decimal IsrCausado, decimal IsrRetenidoAcumulado, decimal IsrCargo)
		{
			List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
			AgregaElementoEnLista(lstISR, "INGRESOS COBRADOS DEL PERIODO: ", TotalIngreso);
			AgregaElementoEnLista(lstISR, "(+) OTROS INGRESOS ACUMULABLES: ", OtrosIngresosAcumulables);
			AgregaElementoEnLista(lstISR, "(-) INGRESOS COBRADOS NO ACUMULABLES: ", IngresosCobradosNoAcumulables);
			AgregaElementoEnLista(lstISR, "(=) INGRESOS COBRADOS ACUMULADOS: ", IngresosAcumulados);
			AgregaElementoEnLista(lstISR, "", "");
			AgregaElementoEnLista(lstISR, "DEDUCCIÓN OPCIONAL (CIEGA 35%): ", DeduccionesOpcional);
			AgregaElementoEnLista(lstISR, "PREDIAL: ", Predial);
			AgregaElementoEnLista(lstISR, "TOTAL DEDUCCIONES DEL PERIODO: ", TotalDeduccionesPeriodo);
			AgregaElementoEnLista(lstISR, " ", "");
			AgregaElementoEnLista(lstISR, "(=) BASE: ", BaseISR);
			AgregaElementoEnLista(lstISR, "   ", "");
			AgregaElementoEnLista(lstISR, "APLICACIÓN DE TARIFA SOBRE LA BASE", "");
			AgregaElementoEnLista(lstISR, "ISR CAUSADO: ", IsrCausado);
			AgregaElementoEnLista(lstISR, "(-) ISR RETENIDO DEL PERIODO: ", IsrRetenidoAcumulado);
			AgregaElementoEnLista(lstISR, "(=) ISR A CARGO: ", IsrCargo);
			return lstISR;
		}

		private void CalcularISRaCargo(decimal BaseParaISR, TextBox TextBoxIsrCausado, TextBox TextBoxIsrAcargo)
		{
			decimal isrRetenidoAcumulado = default(decimal);
			decimal isrAcargo = default(decimal);
			decimal isrCausado = default(decimal);
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mes = ConvierteTextoAInteger(periodo.Clave);
			DateTime fechaDesde = DateTime.Today;
			DateTime fechaHasta = DateTime.Today;
			AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
			DateTime fechaDesdeAnual = FechaDesde(1, periodo.Id);
			List<EntEstadoDeCuenta> lstCatalogoISR = new BusEmpresas().ObtieneCatalogoISR(2, 1, mes, año);
			decimal porcentaje = default(decimal);
			int limite = lstCatalogoISR.Count - 1;
			for (int x = 0; x < lstCatalogoISR.Count; x++)
			{
				EntEstadoDeCuenta lista = lstCatalogoISR[x];
				if (BaseParaISR > lista.Total)
				{
					if (x == limite)
					{
						isrCausado = (BaseParaISR - lista.SubTotal) * (lista.IVA / 100m) + lista.Retenciones;
						porcentaje = lista.IVA;
						break;
					}
					continue;
				}
				isrCausado = (BaseParaISR - lista.SubTotal) * (lista.IVA / 100m) + lista.Retenciones;
				porcentaje = lista.IVA;
				break;
			}
			TextBoxIsrCausado.Text = FormatoMoneySinNegativo(isrCausado);
			List<EntFactura> listaComprobantesISRretenidos = new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, fechaDesdeAnual, fechaHasta, 1);
			listaComprobantesISRretenidos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Program.EmpresaSeleccionada, fechaDesdeAnual, fechaHasta, 1));
			isrRetenidoAcumulado = ObtieneISRretenidoPueCpEgresos(listaComprobantesISRretenidos, fechaDesdeAnual, fechaHasta);
			txtISRretenidoAcumulado.Text = FormatoMoneySinNegativo(isrRetenidoAcumulado);
			isrAcargo = isrCausado - isrRetenidoAcumulado - ConvierteTextoADecimal(txtPagoProvisionalAnteriores);
			TextBoxIsrAcargo.Text = FormatoMoneySinNegativo(isrAcargo);
		}

		private void CalcularISRaCargoRPM(decimal BaseParaISR, TextBox TextBoxIsrCausado, TextBox TextBoxIsrAcargo)
		{
			decimal isrRetenidoAcumulado = default(decimal);
			decimal isrAcargo = default(decimal);
			decimal isrCausado = default(decimal);
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mes = ConvierteTextoAInteger(periodo.Clave);
			DateTime fechaDesde = DateTime.Today;
			DateTime fechaHasta = DateTime.Today;
			AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
			DateTime fechaDesdeAnual = FechaDesde(1, periodo.Id);
			decimal tasaISR = 0.3m;
			isrCausado = Math.Round(BaseParaISR * tasaISR, 2);
			TextBoxIsrCausado.Text = FormatoMoneySinNegativo(isrCausado);
			List<EntFactura> listaComprobantesISRretenidos = new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, fechaDesdeAnual, fechaHasta, 1);
			listaComprobantesISRretenidos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Program.EmpresaSeleccionada, fechaDesdeAnual, fechaHasta, 1));
			isrRetenidoAcumulado = ObtieneISRretenidoPueCpEgresos(listaComprobantesISRretenidos, fechaDesdeAnual, fechaHasta);
			txtISRretenidoAcumuladoRPM.Text = FormatoMoneySinNegativo(isrRetenidoAcumulado);
			isrAcargo = isrCausado - isrRetenidoAcumulado - ConvierteTextoADecimal(txtPagoProvisionalAnterioresRPM);
			TextBoxIsrAcargo.Text = FormatoMoneySinNegativo(isrAcargo);
		}

		private void CalcularISRaCargoRIF(decimal BaseParaISR, TextBox TextBoxIsrCausado, TextBox TextBoxIsrAcargo)
		{
			decimal isrRetenidoAcumulado = default(decimal);
			decimal isrAcargo = default(decimal);
			decimal isrReducido = default(decimal);
			decimal isrCausado = default(decimal);
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mes = ConvierteTextoAInteger(periodo.Clave);
			DateTime fechaDesde = DateTime.Today;
			DateTime fechaHasta = DateTime.Today;
			AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
			if (BaseParaISR > 0m)
			{
				List<EntEstadoDeCuenta> lstCatalogoISR = new BusEmpresas().ObtieneCatalogoISR(3, 2, 1, año);
				decimal porcentaje = default(decimal);
				int limite = lstCatalogoISR.Count - 1;
				for (int x = 0; x < lstCatalogoISR.Count; x++)
				{
					EntEstadoDeCuenta lista = lstCatalogoISR[x];
					if (BaseParaISR > lista.Total)
					{
						if (x == limite)
						{
							isrCausado = (BaseParaISR - lista.SubTotal) * (lista.IVA / 100m) + lista.Retenciones;
							porcentaje = lista.IVA;
							break;
						}
						continue;
					}
					isrCausado = (BaseParaISR - lista.SubTotal) * (lista.IVA / 100m) + lista.Retenciones;
					porcentaje = lista.IVA;
					break;
				}
				TextBoxIsrCausado.Text = FormatoMoneySinNegativo(isrCausado);
				isrReducido = isrCausado * (ConvierteTextoADecimal(cmbPorcentajeReduccionRIF.Text.Replace("%", "")) / 100m);
				txtIsrReducido.Text = FormatoMoney(isrReducido);
				isrAcargo = isrCausado - isrReducido;
				TextBoxIsrAcargo.Text = FormatoMoneySinNegativo(isrAcargo);
				List<EntFactura> listaComprobantesISRretenidos = new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesISRretenidos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				isrRetenidoAcumulado = ObtieneISRretenidoPueCpEgresos(listaComprobantesISRretenidos, fechaDesde, fechaHasta);
				txtISRretenidoAcumuladoRIF.Text = FormatoMoneySinNegativo(isrRetenidoAcumulado);
				txtIsrPorPagarRIF.Text = FormatoMoneySinNegativo(isrAcargo - isrRetenidoAcumulado);
			}
			else
			{
				TextBoxIsrCausado.Text = FormatoMoneySinNegativo(0m);
				txtIsrReducido.Text = FormatoMoneyDecimales4(0m);
				TextBoxIsrAcargo.Text = FormatoMoneySinNegativo(0m);
				txtISRretenidoAcumuladoRIF.Text = FormatoMoneySinNegativo(0m);
				txtIsrPorPagarRIF.Text = FormatoMoneyDecimales4(0m);
			}
		}

		private void CalcularISRaCargoARR(decimal BaseParaISR, TextBox TextBoxIsrCausado, TextBox TextBoxIsrAcargo)
		{
			decimal isrRetenidoAcumulado = default(decimal);
			decimal isrAcargo = default(decimal);
			decimal isrReducido = default(decimal);
			decimal isrCausado = default(decimal);
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mes = ConvierteTextoAInteger(periodo.Clave);
			DateTime fechaDesde = DateTime.Today;
			DateTime fechaHasta = DateTime.Today;
			AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
			if (BaseParaISR > 0m)
			{
				List<EntEstadoDeCuenta> lstCatalogoISR = new BusEmpresas().ObtieneCatalogoISR(2, 1, 1, año);
				decimal porcentaje = default(decimal);
				int limite = lstCatalogoISR.Count - 1;
				for (int x = 0; x < lstCatalogoISR.Count; x++)
				{
					EntEstadoDeCuenta lista = lstCatalogoISR[x];
					if (BaseParaISR > lista.Total)
					{
						if (x == limite)
						{
							isrCausado = (BaseParaISR - lista.SubTotal) * (lista.IVA / 100m) + lista.Retenciones;
							porcentaje = lista.IVA;
							break;
						}
						continue;
					}
					isrCausado = (BaseParaISR - lista.SubTotal) * (lista.IVA / 100m) + lista.Retenciones;
					porcentaje = lista.IVA;
					break;
				}
				TextBoxIsrCausado.Text = FormatoMoneySinNegativo(isrCausado);
				List<EntFactura> listaComprobantesISRretenidos = new BusFacturas().ObtieneComprobantesFiscales(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1);
				listaComprobantesISRretenidos.AddRange(new BusFacturas().ObtieneComprobantesFiscalesPorFechaPagoExclusivo(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, 1));
				isrRetenidoAcumulado = ObtieneISRretenidoPueCpEgresos(listaComprobantesISRretenidos, fechaDesde, fechaHasta);
				txtISRRetenidoPeriodoAR.Text = FormatoMoneySinNegativo(isrRetenidoAcumulado);
				isrAcargo = isrCausado - isrRetenidoAcumulado;
				TextBoxIsrAcargo.Text = FormatoMoneySinNegativo(isrAcargo);
			}
			else
			{
				TextBoxIsrCausado.Text = FormatoMoneySinNegativo(0m);
				txtISRRetenidoPeriodoAR.Text = FormatoMoneySinNegativo(0m);
				TextBoxIsrAcargo.Text = FormatoMoneySinNegativo(0m);
			}
		}

		private decimal ObtieneISRretenidoPueCpEgresos(List<EntFactura> ListaComprobantes, DateTime FechaDesde, DateTime FechaHasta)
		{
			decimal isrRetenidoPue = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 1 && P.MetodoPagoId == 1).Sum((EntFactura P) => P.ISRRetenciones);
			decimal isrRetenidoCP = ListaComprobantes.Where((EntFactura P) => P.TipoComprobanteId == 5 && P.FechaPago >= FechaDesde && P.FechaPago <= FechaHasta).Sum((EntFactura P) => P.ISRRetenciones);
			decimal isrRetenidoEg = ListaComprobantes.Where((EntFactura P) => (P.TipoComprobanteId == 2 && P.TipoRelacionId == 7) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 1 && !Program.EmpresaSeleccionada.ExcluyeNc01 && !P.ExcluyeFlujo) || (P.TipoComprobanteId == 2 && P.TipoRelacionId == 3 && !Program.EmpresaSeleccionada.ExcluyeNc03 && !P.ExcluyeFlujo)).Sum((EntFactura P) => P.ISRRetenciones);
			return isrRetenidoPue + isrRetenidoCP - isrRetenidoEg;
		}

		private void CargaIngresosDeduccionesPagadasAE()
		{
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mesHasta = ConvierteTextoAInteger(periodo.Clave);
			EntEmpresaISR empISR = new BusEmpresas().ObtieneEmpresaISR(Program.EmpresaSeleccionada.Id, 1, año, mesHasta);
			txtMesDeduccionesPagadas.Text = new DateTime(1900, mesHasta, 1).ToString("MMMM").ToUpper();
			if (empISR.Id > 0)
			{
				txtDeduccionesPagadasDelMes.Text = FormatoMoney(empISR.DeduccionesPagadas);
				txtOtrosIngresosAcumulablesAE.Text = FormatoMoney(empISR.OtrosIngresosAcumulables);
				txtIngresosCobradosNoAcumulablesAE.Text = FormatoMoney(empISR.IngresosCobradosNoAcumulables);
				txtIngresosCobradosAcumuladosGuardadoAE.Text = FormatoMoney(empISR.IngresosCobrados);
				txtPerdidasFiscalesAmortizar.Text = FormatoMoney(empISR.PerdidasFiscalesAmortizar);
				txtPagoProvisionalAnteriores.Text = FormatoMoney(empISR.PagosProvisionalesAnteriores);
				txtDeduccionesSinCFDI.Text = FormatoMoney(empISR.DeduccionesSinCFDI);
				txtDeduccionesPorPago.Text = FormatoMoney(empISR.DeduccionPago);
				txtOtrosGastosPagadosNoDeduciblesAE.Text = FormatoMoney(empISR.OtrosGastosPagadosNoDeducibles);
				txtDeduccionesPagadasGuardado.Text = FormatoMoney(empISR.DeduccionesPagadas);
				if (empISR.BaseFechaId == 1)
				{
					rdoEnBaseFechaFactura.Checked = true;
				}
				else if (empISR.BaseFechaId == 2)
				{
					rdoEnBaseFechaPago.Checked = true;
				}
				else if (empISR.BaseFechaId == 3)
				{
					rdoEnBaseFechaDevengada.Checked = true;
				}
				cmbPorcentajeDeducible.SelectedIndex = empISR.PorcentajeDeducibleId - 1;
				DeduccionesPagadasGuardada = true;
			}
			else
			{
				txtDeduccionesPagadasDelMes.Text = FormatoMoney("0");
				txtDeduccionesPagadasGuardado.Text = FormatoMoney("0");
				txtOtrosIngresosAcumulablesAE.Text = FormatoMoney(0m);
				txtIngresosCobradosNoAcumulablesAE.Text = FormatoMoney(0m);
				txtIngresosCobradosAcumuladosGuardadoAE.Text = FormatoMoney(0m);
				txtPerdidasFiscalesAmortizar.Text = FormatoMoney(0m);
				txtPagoProvisionalAnteriores.Text = FormatoMoney(0m);
				txtDeduccionesSinCFDI.Text = FormatoMoney(0m);
				txtDeduccionesPorPago.Text = FormatoMoney(0m);
				txtOtrosGastosPagadosNoDeduciblesAE.Text = FormatoMoney(0m);
				txtDeduccionesPagadas.Text = FormatoMoney(0m);
				cmbPorcentajeDeducible.SelectedIndex = 0;
				DeduccionesPagadasGuardada = false;
			}
			if (mesHasta > 1)
			{
				EntCatalogoGenerico empIsrMesesAnteriores = new BusEmpresas().ObtieneEmpresaISR(Program.EmpresaSeleccionada.Id, 1, año, 1, mesHasta - 1);
				txtMesesDeduccionesPagadasMesesAnteriores.Text = "ENE - " + new DateTime(1, mesHasta - 1, 1).ToString("MMM").ToUpper();
				txtIngresosCobradosMesesAnterioresAE.Text = FormatoMoney(empIsrMesesAnteriores.Descripcion);
				txtDeduccionesPagadasMesesAnteriores.Text = FormatoMoney(empIsrMesesAnteriores.Clave);
			}
			else
			{
				txtMesesDeduccionesPagadasMesesAnteriores.Clear();
				txtIngresosCobradosMesesAnterioresAE.Text = FormatoMoney("0");
				txtDeduccionesPagadasMesesAnteriores.Text = FormatoMoney("0");
			}
			txtDeduccionesPagadasAcumuladas.Text = FormatoMoney(ConvierteTextoADecimal(txtDeduccionesPagadasDelMes) + ConvierteTextoADecimal(txtDeduccionesPagadasMesesAnteriores));
		}

		private void CargaIngresosDeduccionesPagadasRPM()
		{
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mesHasta = ConvierteTextoAInteger(periodo.Clave);
			EntEmpresaISR empISR = new BusEmpresas().ObtieneEmpresaISR(Program.EmpresaSeleccionada.Id, 2, año, mesHasta);
			txtMesDeduccionesPagadasRPM.Text = new DateTime(1900, mesHasta, 1).ToString("MMMM").ToUpper();
			if (empISR.Id > 0)
			{
				txtIngresosCobradosAcumuladosRPM.Text = FormatoMoney(empISR.IngresosCobrados);
				txtIngresosCobradosAcumuladosGuardadoRPM.Text = txtIngresosCobradosAcumuladosRPM.Text;
				txtDeduccionesPagadasDelMesRPM.Text = FormatoMoney(empISR.DeduccionesPagadas);
				txtOtrosIngresosAcumulablesRPM.Text = FormatoMoney(empISR.OtrosIngresosAcumulables);
				txtREPacumuladosEjercicios2021anteriores.Text = FormatoMoney(empISR.RepAcumulados2021Anteriores);
				txtIngresosCobradosNoAcumulablesRPM.Text = FormatoMoney(empISR.IngresosCobradosNoAcumulables);
				txtIngresosCobradosAcumuladosRPM.Text = FormatoMoney(empISR.IngresosCobrados);
				txtPerdidasFiscalesAmortizarRPM.Text = FormatoMoney(empISR.PerdidasFiscalesAmortizar);
				cmbTasaIsrRPM.SelectedIndex = empISR.TasaIsrId - 1;
				txtPagoProvisionalAnterioresRPM.Text = FormatoMoney(empISR.PagosProvisionalesAnteriores);
				txtDeduccionesSinCfdiRPM.Text = FormatoMoney(empISR.DeduccionesSinCFDI);
				txtDeduccionesPorPagoRPM.Text = FormatoMoney(empISR.DeduccionPago);
				txtOtrosGastosPagadosNoDeduciblesRPM.Text = FormatoMoney(empISR.OtrosGastosPagadosNoDeducibles);
				txtDeduccionesPagadasGuardadoRPM.Text = FormatoMoney(empISR.DeduccionesPagadas);
				if (empISR.BaseFechaId == 1)
				{
					rdoEnBaseFechaFacturaRPM.Checked = true;
				}
				else if (empISR.BaseFechaId == 2)
				{
					rdoEnBaseFechaPagoRPM.Checked = true;
				}
				else if (empISR.BaseFechaId == 3)
				{
					rdoEnBaseFechaDevengadaRPM.Checked = true;
				}
				cmbPorcentajeDeducibleRPM.SelectedIndex = empISR.PorcentajeDeducibleId - 1;
				txtNominaNoDeducible.Text = FormatoMoney(empISR.NominaDeducible);
				DeduccionesPagadasGuardadaRPM = true;
			}
			else
			{
				txtIngresosCobradosAcumuladosRPM.Text = FormatoMoney("0");
				txtIngresosCobradosAcumuladosGuardadoRPM.Text = FormatoMoney("0");
				txtDeduccionesPagadasDelMesRPM.Text = FormatoMoney("0");
				txtDeduccionesPagadasGuardadoRPM.Text = FormatoMoney("0");
				txtOtrosIngresosAcumulablesRPM.Text = FormatoMoney(0m);
				txtIngresosCobradosNoAcumulablesRPM.Text = FormatoMoney(0m);
				txtIngresosCobradosAcumuladosRPM.Text = FormatoMoney(0m);
				txtPerdidasFiscalesAmortizarRPM.Text = FormatoMoney(0m);
				txtPagoProvisionalAnterioresRPM.Text = FormatoMoney(0m);
				txtDeduccionesSinCfdiRPM.Text = FormatoMoney(0m);
				txtDeduccionesPorPagoRPM.Text = FormatoMoney(0m);
				txtOtrosGastosPagadosNoDeduciblesRPM.Text = FormatoMoney(0m);
				txtDeduccionesPagadasRPM.Text = FormatoMoney(0m);
				cmbPorcentajeDeducible.SelectedIndex = 0;
				DeduccionesPagadasGuardadaRPM = false;
			}
			if (mesHasta > 1)
			{
				EntCatalogoGenerico empIsrMesesAnteriores = new BusEmpresas().ObtieneEmpresaISR(Program.EmpresaSeleccionada.Id, 2, año, 1, mesHasta - 1);
				txtMesesDeduccionesPagadasMesesAnteriores.Text = "ENE - " + new DateTime(1, mesHasta - 1, 1).ToString("MMM").ToUpper();
				txtIngresosCobradosMesesAnterioresRPM.Text = FormatoMoney(empIsrMesesAnteriores.Descripcion);
				txtDeduccionesPagadasMesesAnterioresRPM.Text = FormatoMoney(empIsrMesesAnteriores.Clave);
			}
			else
			{
				txtMesesDeduccionesPagadasMesesAnteriores.Clear();
				txtIngresosCobradosMesesAnterioresRPM.Text = FormatoMoney("0");
				txtDeduccionesPagadasMesesAnterioresRPM.Text = FormatoMoney("0");
			}
			txtDeduccionesPagadasAcumuladasRPM.Text = FormatoMoney(ConvierteTextoADecimal(txtDeduccionesPagadasDelMesRPM) + ConvierteTextoADecimal(txtDeduccionesPagadasMesesAnterioresRPM));
		}

		private void CargaIngresosDeduccionesPagadasRIF()
		{
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mesHasta = ConvierteTextoAInteger(periodo.Clave);
			EntEmpresaISR empISR = new BusEmpresas().ObtieneEmpresaISR(Program.EmpresaSeleccionada.Id, 3, año, mesHasta);
			if (empISR.Id > 0)
			{
				txtDeduccionesPagadasDelMesRIF.Text = FormatoMoney(empISR.DeduccionesPagadas);
				txtOtrosIngresosAcumulablesRIF.Text = FormatoMoney(empISR.OtrosIngresosAcumulables);
				txtIngresosCobradosNoAcumulablesRIF.Text = FormatoMoney(empISR.IngresosCobradosNoAcumulables);
				txtIngresosCobradosAcumuladosGuardadoRIF.Text = FormatoMoney(empISR.IngresosCobrados);
				txtGastosMayoresAIngresosPeriodosAnteriores.Text = FormatoMoney(empISR.PagosProvisionalesAnteriores);
				txtDeduccionesSinCFDiRIF.Text = FormatoMoney(empISR.DeduccionesSinCFDI);
				txtDeduccionesPorPagoRIF.Text = FormatoMoney(empISR.DeduccionPago);
				txtOtrosGastosPagadosNoDeduciblesRIF.Text = FormatoMoney(empISR.OtrosGastosPagadosNoDeducibles);
				txtDeduccionesPagadasGuardadoRIF.Text = FormatoMoney(empISR.DeduccionesPagadas);
				if (empISR.BaseFechaId == 1)
				{
					rdoEnBaseFechaFactura.Checked = true;
				}
				else if (empISR.BaseFechaId == 2)
				{
					rdoEnBaseFechaPago.Checked = true;
				}
				else if (empISR.BaseFechaId == 3)
				{
					rdoEnBaseFechaDevengada.Checked = true;
				}
				cmbPorcentajeReduccionRIF.SelectedIndex = empISR.TasaIsrId - 1;
				cmbPorcentajeDeducibleRIF.SelectedIndex = empISR.PorcentajeDeducibleId - 1;
				DeduccionesPagadasGuardadaRIF = true;
			}
			else
			{
				txtDeduccionesPagadasDelMesRIF.Text = FormatoMoney("0");
				txtDeduccionesPagadasGuardadoRIF.Text = FormatoMoney("0");
				txtOtrosIngresosAcumulablesRIF.Text = FormatoMoney(0m);
				txtIngresosCobradosNoAcumulablesRIF.Text = FormatoMoney(0m);
				txtIngresosCobradosAcumuladosGuardadoRIF.Text = FormatoMoney(0m);
				txtDeduccionesSinCFDiRIF.Text = FormatoMoney(0m);
				txtDeduccionesPorPagoRIF.Text = FormatoMoney(0m);
				txtOtrosGastosPagadosNoDeduciblesRIF.Text = FormatoMoney(0m);
				txtDeduccionesPagadasRIF.Text = FormatoMoney(0m);
				cmbPorcentajeReduccionRIF.SelectedIndex = 0;
				cmbPorcentajeDeducibleRIF.SelectedIndex = 0;
				DeduccionesPagadasGuardadaRIF = false;
			}
		}

		private void CargaIngresosDeduccionesPagadasARR()
		{
			EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
			int año = periodo.Id;
			int mesHasta = ConvierteTextoAInteger(periodo.Clave);
			EntEmpresaISR empISR = new BusEmpresas().ObtieneEmpresaISR(Program.EmpresaSeleccionada.Id, 4, año, mesHasta);
			if (empISR.Id > 0)
			{
				txtOtrosIngresosAcumulablesAR.Text = FormatoMoney(empISR.OtrosIngresosAcumulables);
				txtIngresosCobradosNoAcumulablesAR.Text = FormatoMoney(empISR.IngresosCobradosNoAcumulables);
				txtIngresosCobradosAcumuladosGuardadoAR.Text = FormatoMoney(empISR.IngresosCobrados);
				cmbDeduccionOpcionalAR.SelectedIndex = empISR.PorcentajeDeducibleId - 1;
				txtPredialAR.Text = FormatoMoney(empISR.PagosProvisionalesAnteriores);
				DeduccionesPagadasGuardadaARR = true;
			}
			else
			{
				txtOtrosIngresosAcumulablesAR.Text = FormatoMoney("0");
				txtIngresosCobradosNoAcumulablesAR.Text = FormatoMoney("0");
				txtIngresosCobradosAcumuladosGuardadoAR.Text = FormatoMoney(0m);
				txtPredialAR.Text = FormatoMoney(0m);
				cmbDeduccionOpcionalAR.SelectedIndex = 0;
				DeduccionesPagadasGuardadaARR = false;
			}
		}

		private void btnRefrescar_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				CargaComprobantes(Program.EmpresaSeleccionada, fechaDesde, fechaHasta);
				FiltraComprobantes(ListaComprobantes, true, false, true, true, fechaDesde, fechaHasta);
				DateTime fechaDesdeAnual = FechaDesde(1, periodo.Id);
				DateTime fechaHastaAnual = FechaHasta(12, periodo.Id);
				if (tcCalculosISR.SelectedIndex == 0)
				{
					CargaComprobantesAnual(Program.EmpresaSeleccionada, periodo.Id);
					FiltraComprobantesAnual(ListaComprobantesAnual, periodo.Id);
					List<EntEstadoDeCuenta> lstISR = CalculaISRresico(periodo.Id, ConvierteTextoADecimal(txtIngresosCobrados), ConvierteTextoADecimal(txtISRRetenido), txtPorcentajeTablaMensual, txtISRDeterminado, txtISRporPagar);
					ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + base.EmpresaSeleccionada.Nombre);
					ReportParameter parmFecha = new ReportParameter("parmFecha", " " + fechaDesdeAnual.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(fechaHastaAnual.Month, fechaHastaAnual.Year).ToString("dd/MMM/yyyy").ToUpper());
					ReportParameter parmTitulo = new ReportParameter("parmTitulo", lbTituloISRresicoMensual.Text);
					rvCalculoISR.LocalReport.SetParameters(parmEmpresa);
					rvCalculoISR.LocalReport.SetParameters(parmFecha);
					rvCalculoISR.LocalReport.SetParameters(parmTitulo);
					rvCalculoISR.LocalReport.DataSources.Clear();
					rvCalculoISR.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstISR));
					rvCalculoISR.RefreshReport();
					CalculaISRAnual(ConvierteTextoADecimal(txtTotalIngresosAnual), ConvierteTextoADecimal(txtISRRetenidoAnual), ConvierteTextoADecimal(txtPagosProvisionalesCaptura), txtPorcentajeTablaAnual, txtISRDeterminadoAnual, txtISRporPagarAnual, lbIsrPorPagarAfavor);
				}
				else if (tcCalculosISR.SelectedIndex > 0)
				{
					txtDeduccionesSinCFDI.Clear();
					txtDeduccionesPorPago.Clear();
					txtREPacumuladosEjercicios2021anteriores.Clear();
					txtPerdidasFiscalesAmortizarRPM.Clear();
					txtPagosProvisionalesCaptura.Clear();
					txtDeduccionesSinCfdiRPM.Clear();
					txtDeduccionesPorPagoRPM.Clear();
					txtNominaNoDeducible.Clear();
					txtDeduccionesSinCFDiRIF.Clear();
					txtDeduccionesPorPagoRIF.Clear();
					txtDeduccionesSinCFDiRIF.Clear();
					txtDeduccionesPorPagoRIF.Clear();
					txtGastosMayoresAIngresosPeriodosAnteriores.Clear();
					CargaComprobantesEgresos(Program.EmpresaSeleccionada, fechaDesde, fechaHasta);
					FiltraComprobantesEgresos(ListaComprobantesEgresos, fechaDesde, fechaHasta);
					int opcionFechaId = 1;
					if (rdoEnBaseFechaPago.Checked)
					{
						opcionFechaId = 2;
					}
					else if (rdoEnBaseFechaDevengada.Checked)
					{
						opcionFechaId = 3;
					}
					CargaPercepciones(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, opcionFechaId, txtTotalPercepcionesExentas, txtTotalPercepcionesGravadas);
					CalcularPercepcionesExentas();
					CargaIngresosDeduccionesPagadasAE();
					CalcularDeduccionesPagadas();
					CargaIngresosDeduccionesPagadasRPM();
					CalcularDeduccionesPagadasRPM();
					CargaIngresosDeduccionesPagadasRIF();
					CalcularDeduccionesPagadasRIF();
					CargaIngresosDeduccionesPagadasARR();
					CalcularIngresosCobradosAcumuladosARR();
					CalcularDeduccionesPagadasARR();
					CalcularIngresosCobradosAcumulados();
					CalcularIngresosCobradosAcumuladosRPM();
					CalcularIngresosCobradosAcumuladosRIF();
					CalcularBaseISR();
					CalcularBaseIsrRPM();
					CalcularBaseIsrRIF();
					CalcularBaseIsrARR();
					CalcularISRaCargo(ConvierteTextoADecimal(txtBaseISR), txtISRcausado, txtISRaCargo);
					CalcularISRaCargoRPM(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
					CalcularISRaCargoRIF(ConvierteTextoADecimal(txtUtilidad), txtISRcausadoRIF, txtISRaCargoRIF);
					CalcularISRaCargoARR(ConvierteTextoADecimal(txtBaseAR), txtISRCausadoAR, txtISRaCargoAR);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void tcPedidosGrids_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (tcCalculosGeneral.SelectedIndex == 0)
				{
					btnRefrescar.PerformClick();
				}
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				if (tcCalculosISR.SelectedIndex == 0)
				{
					List<EntEstadoDeCuenta> lstISR = CalculaISRresico(periodo.Id, ConvierteTextoADecimal(txtIngresosCobrados), ConvierteTextoADecimal(txtISRRetenido), txtPorcentajeTablaMensual, txtISRDeterminado, txtISRporPagar);
					ReportParameter parmEmpresa = new ReportParameter("parmEmpresa", " " + base.EmpresaSeleccionada.Nombre);
					ReportParameter parmFecha = new ReportParameter("parmFecha", " " + fechaDesde.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(fechaHasta.Month, fechaHasta.Year).ToString("dd/MMM/yyyy").ToUpper());
					ReportParameter parmTitulo = new ReportParameter("parmTitulo", lbTituloISRresicoMensual.Text);
					rvCalculoISR.LocalReport.SetParameters(parmEmpresa);
					rvCalculoISR.LocalReport.SetParameters(parmFecha);
					rvCalculoISR.LocalReport.SetParameters(parmTitulo);
					rvCalculoISR.LocalReport.DataSources.Clear();
					rvCalculoISR.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstISR));
					rvCalculoISR.RefreshReport();
					DateTime fechaDesdeAnual = FechaDesde(1, periodo.Id);
					DateTime fechaHastaAnual = FechaHasta(12, periodo.Id);
					List<EntEstadoDeCuenta> lstISRAnual = CalculaISRAnual(ConvierteTextoADecimal(txtTotalIngresosAnual), ConvierteTextoADecimal(txtISRRetenidoAnual), ConvierteTextoADecimal(txtPagosProvisionalesCaptura), txtPorcentajeTablaAnual, txtISRDeterminadoAnual, txtISRporPagarAnual, lbIsrPorPagarAfavor);
					ReportParameter parmFechaAnual = new ReportParameter("parmFecha", " " + fechaDesdeAnual.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(fechaHastaAnual.Month, fechaHastaAnual.Year).ToString("dd/MMM/yyyy").ToUpper());
					parmTitulo = new ReportParameter("parmTitulo", lbTituloISRresicoAnual.Text);
					rvCalculoISRAnual.LocalReport.SetParameters(parmEmpresa);
					rvCalculoISRAnual.LocalReport.SetParameters(parmFechaAnual);
					rvCalculoISRAnual.LocalReport.SetParameters(parmTitulo);
					rvCalculoISRAnual.LocalReport.DataSources.Clear();
					rvCalculoISRAnual.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstISRAnual));
					rvCalculoISRAnual.RefreshReport();
				}
				else if (tcCalculosISR.SelectedIndex != 1 && tcCalculosISR.SelectedIndex == 2)
				{
					List<EntEstadoDeCuenta> lstISR2 = CalculaISRresico(periodo.Id, ConvierteTextoADecimal(txtIngresosCobrados), ConvierteTextoADecimal(txtISRRetenido), txtPorcentajeTablaMensual, txtISRDeterminado, txtISRporPagar);
					ReportParameter parmEmpresa2 = new ReportParameter("parmEmpresa", " " + base.EmpresaSeleccionada.Nombre);
					ReportParameter parmFecha2 = new ReportParameter("parmFecha", " " + fechaDesde.ToString("dd/MMM/yyyy").ToUpper() + " al " + ObtieneFechaUltimoDiaMes(fechaHasta.Month, fechaHasta.Year).ToString("dd/MMM/yyyy").ToUpper());
					ReportParameter parmTitulo2 = new ReportParameter("parmTitulo", lbTituloISRresicoMensual.Text);
					rvCalculoISR.LocalReport.SetParameters(parmEmpresa2);
					rvCalculoISR.LocalReport.SetParameters(parmFecha2);
					rvCalculoISR.LocalReport.SetParameters(parmTitulo2);
					rvCalculoISR.LocalReport.DataSources.Clear();
					rvCalculoISR.LocalReport.DataSources.Add(new ReportDataSource("dsBancos", (IEnumerable)lstISR2));
					rvCalculoISR.RefreshReport();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPagosProvisionalesCaptura_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalculaISRAnual(ConvierteTextoADecimal(txtTotalIngresosAnual), ConvierteTextoADecimal(txtISRRetenidoAnual), ConvierteTextoADecimal(txtPagosProvisionalesCaptura), txtPorcentajeTablaAnual, txtISRDeterminadoAnual, txtISRporPagarAnual, lbIsrPorPagarAfavor);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void cmbEmpresas_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (Program.CambiaEmpresa)
				{
					Program.EmpresaSeleccionada = ObtieneEmpresaFromCmb(cmbEmpresas);
					btnRefrescar.PerformClick();
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPagosProvisionalesCaptura_Leave(object sender, EventArgs e)
		{
			try
			{
				TextBoxDecimalMoney_Leave(sender, e);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void tcCalculosISR_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (tcCalculosISR.SelectedIndex == 0)
				{
					flpEmitidosAnual.Visible = true;
					flpRecibidosMensual.Visible = false;
					gvNominas.Visible = false;
				}
				else
				{
					flpEmitidosAnual.Visible = false;
					flpRecibidosMensual.Visible = true;
					gvNominas.Visible = false;
				}
				if (tcCalculosISR.SelectedTab.Text.ToUpper() == "RIF")
				{
					PeriocidadId = 2;
					CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
					SeleccionaPeriodoActual(cmbMesesComprobantes, PeriocidadId, new Label());
				}
				else if (PeriocidadId != 1)
				{
					PeriocidadId = 1;
					CargaPeriodosCmb(cmbMesesComprobantes, PeriocidadId);
					SeleccionaPeriodoActual(cmbMesesComprobantes, PeriocidadId, new Label());
				}
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void CalcularPercepcionesExentas()
		{
			decimal totalPercepcionesExentas = ConvierteTextoADecimal(txtTotalPercepcionesExentas);
			if (totalPercepcionesExentas > 0m)
			{
				string porcentajeS = cmbPorcentajeDeducible.Text.Remove(cmbPorcentajeDeducible.Text.Length - 1);
				decimal porcentaje = ConvierteTextoADecimal(porcentajeS) / 100m;
				txtPercepcionesExentas.Text = FormatoMoney(totalPercepcionesExentas * porcentaje);
				string porcentajeSrpm = cmbPorcentajeDeducibleRPM.Text.Remove(cmbPorcentajeDeducibleRPM.Text.Length - 1);
				decimal porcentajeRpm = ConvierteTextoADecimal(porcentajeSrpm) / 100m;
				txtPercepcionesExentasRPM.Text = FormatoMoney(totalPercepcionesExentas * porcentajeRpm);
				string porcentajeSrif = cmbPorcentajeDeducibleRIF.Text.Remove(cmbPorcentajeDeducibleRIF.Text.Length - 1);
				decimal porcentajeRif = ConvierteTextoADecimal(porcentajeSrif) / 100m;
				txtPercepcionesExentasRIF.Text = FormatoMoney(totalPercepcionesExentas * porcentajeRif);
			}
			else
			{
				txtPercepcionesExentas.Clear();
				txtPercepcionesExentasRIF.Clear();
			}
			txtDeduccionesNominaN.Text = FormatoMoney(ConvierteTextoADecimal(txtPercepcionesExentas) + ConvierteTextoADecimal(txtTotalPercepcionesGravadas));
			txtDeduccionesNomina.Text = txtDeduccionesNominaN.Text;
			decimal deduccionesNominaNRPM = ConvierteTextoADecimal(txtPercepcionesExentasRPM) + ConvierteTextoADecimal(txtTotalPercepcionesGravadasRPM);
			txtDeduccionesNominaNRPM.Text = FormatoMoney(deduccionesNominaNRPM);
			txtDeduccionesFiscalesNominaRPM.Text = FormatoMoneySinNegativo(deduccionesNominaNRPM - ConvierteTextoADecimal(txtNominaNoDeducible));
			txtDeduccionesNominaRPM.Text = txtDeduccionesFiscalesNominaRPM.Text;
			txtDeduccionesNominaNRIF.Text = FormatoMoney(ConvierteTextoADecimal(txtPercepcionesExentasRIF) + ConvierteTextoADecimal(txtTotalPercepcionesGravadasRIF));
			txtDeduccionesNominaRIF.Text = txtDeduccionesNominaNRIF.Text;
		}

		private void CalcularDeduccionesPagadas()
		{
			decimal deduccionesPueCp = ConvierteTextoADecimal(txtDeduccionesPueCP);
			decimal deduccionesNomina = ConvierteTextoADecimal(txtDeduccionesNomina);
			decimal deduccionesSinCFDI = ConvierteTextoADecimal(txtDeduccionesSinCFDI);
			decimal deduccionesPorPago = ConvierteTextoADecimal(txtDeduccionesPorPago);
			decimal otrosGastosPagadosNoDeducible = ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesAE);
			txtDeduccionesPagadas.Text = FormatoMoney(deduccionesPueCp + deduccionesNomina + deduccionesSinCFDI + deduccionesPorPago - otrosGastosPagadosNoDeducible);
		}

		private void CalcularDeduccionesPagadasRPM()
		{
			decimal deduccionesPueCp = ConvierteTextoADecimal(txtDeduccionesPueCpRPM);
			decimal deduccionesNomina = ConvierteTextoADecimal(txtDeduccionesNominaRPM);
			decimal deduccionesSinCFDI = ConvierteTextoADecimal(txtDeduccionesSinCfdiRPM);
			decimal deduccionesPorPago = ConvierteTextoADecimal(txtDeduccionesPorPagoRPM);
			decimal otrosGastosPagadosNoDeducibles = ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRPM);
			txtDeduccionesPagadasRPM.Text = FormatoMoney(deduccionesPueCp + deduccionesNomina + deduccionesSinCFDI + deduccionesPorPago - otrosGastosPagadosNoDeducibles);
		}

		private void CalcularDeduccionesPagadasRIF()
		{
			decimal deduccionesPueCp = ConvierteTextoADecimal(txtDeduccionesPueCpRIF);
			decimal deduccionesNomina = ConvierteTextoADecimal(txtDeduccionesNominaRIF);
			decimal deduccionesSinCFDI = ConvierteTextoADecimal(txtDeduccionesSinCFDiRIF);
			decimal deduccionesPorPago = ConvierteTextoADecimal(txtDeduccionesPorPagoRIF);
			decimal otrosGastosPagadosNoDeducible = ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRIF);
			txtDeduccionesPagadasRIF.Text = FormatoMoney(deduccionesPueCp + deduccionesNomina + deduccionesSinCFDI + deduccionesPorPago - otrosGastosPagadosNoDeducible);
		}

		private void CalcularDeduccionesPagadasARR()
		{
			decimal ingresosCobradosAcumulados = ConvierteTextoADecimal(txtIngresosCobradosAcumuladosAR);
			decimal porcentajeDeduccionOpcional = ConvierteTextoADecimal(cmbDeduccionOpcionalAR.Text.Replace("%", ""));
			decimal deduccionOpcional = ingresosCobradosAcumulados * (porcentajeDeduccionOpcional / 100m);
			decimal predial = ConvierteTextoADecimal(txtPredialAR);
			txtDeduccionesOpcional.Text = FormatoMoney(deduccionOpcional);
			txtTotalDeduccionesPeriodoAR.Text = FormatoMoney(deduccionOpcional + predial);
		}

		private void CalcularBaseISR()
		{
			decimal ingresosAcumulados = ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoAE);
			decimal deduccionesAcumuladas = ConvierteTextoADecimal(txtDeduccionesPagadasAcumuladas);
			decimal perdidasAmortizar = ConvierteTextoADecimal(txtPerdidasFiscalesAmortizar);
			decimal ptuPagadas = ConvierteTextoADecimal(txtPTUpagada);
			txtBaseISR.Text = FormatoMoneySinNegativo(ingresosAcumulados - deduccionesAcumuladas - perdidasAmortizar - ptuPagadas);
		}

		private void CalcularBaseIsrRPM()
		{
			decimal ingresosAcumulados = ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoRPM);
			decimal deduccionesAcumuladas = ConvierteTextoADecimal(txtDeduccionesPagadasAcumuladasRPM);
			decimal perdidasAmortizar = ConvierteTextoADecimal(txtPerdidasFiscalesAmortizarRPM);
			decimal ptuPagadas = ConvierteTextoADecimal(txtPTUpagadaRPM);
			txtBaseIsrRPM.Text = FormatoMoneySinNegativo(ingresosAcumulados - deduccionesAcumuladas - perdidasAmortizar - ptuPagadas);
		}

		private void CalcularBaseIsrRIF()
		{
			decimal deduccionesPagadasDelMes = ConvierteTextoADecimal(txtDeduccionesPagadasDelMesRIF);
			decimal ingresosAcumulados = ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoRIF);
			decimal ptuPagadas = ConvierteTextoADecimal(txtPTUpagadaRIF);
			decimal gastosMayoresAingresosPeriodosAnteriores = ConvierteTextoADecimal(txtGastosMayoresAIngresosPeriodosAnteriores);
			txtGastosMayoresAingresos.Text = FormatoMoneySinNegativo(deduccionesPagadasDelMes + ptuPagadas - ingresosAcumulados);
			txtUtilidad.Text = FormatoMoneySinNegativo(ingresosAcumulados - deduccionesPagadasDelMes - ptuPagadas - gastosMayoresAingresosPeriodosAnteriores);
		}

		private void CalcularBaseIsrARR()
		{
			decimal totalDeduccionesDelMes = ConvierteTextoADecimal(txtTotalDeduccionesPeriodoAR);
			decimal ingresosAcumulados = ConvierteTextoADecimal(txtIngresosCobradosAcumuladosAR);
			txtBaseAR.Text = FormatoMoneySinNegativo(ingresosAcumulados - totalDeduccionesDelMes);
		}

		private void CalcularIngresosCobradosAcumulados()
		{
			decimal ingresosCobradosMes = ConvierteTextoADecimal(txtIngresosCobrados);
			decimal ingresosCobradosMesesAnteriores = ConvierteTextoADecimal(txtIngresosCobradosMesesAnterioresAE);
			decimal otrosIngresosAcumulables = ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAE);
			decimal ingresosCobradosNoAcumulables = ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAE);
			txtIngresosCobradosAcumuladosAE.Text = FormatoMoneySinNegativo(ingresosCobradosMes + ingresosCobradosMesesAnteriores + otrosIngresosAcumulables - ingresosCobradosNoAcumulables);
		}

		private void CalcularIngresosCobradosAcumuladosRPM()
		{
			decimal ingresosCobradosMes = ConvierteTextoADecimal(txtIngresosCobradosRPM);
			decimal ingresosCobradosMesesAnteriores = ConvierteTextoADecimal(txtIngresosCobradosMesesAnterioresRPM);
			decimal repAcumulados2021anteriores = ConvierteTextoADecimal(txtREPacumuladosEjercicios2021anteriores);
			decimal otrosIngresosAcumulables = ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRPM);
			decimal ingresosCobradosNoAcumulables = ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRPM);
			txtIngresosCobradosAcumuladosRPM.Text = FormatoMoneySinNegativo(ingresosCobradosMes + ingresosCobradosMesesAnteriores + otrosIngresosAcumulables - repAcumulados2021anteriores - ingresosCobradosNoAcumulables);
		}

		private void CalcularIngresosCobradosAcumuladosRIF()
		{
			decimal ingresosCobradosMes = ConvierteTextoADecimal(txtIngresosCobradosRIF);
			decimal otrosIngresosAcumulables = ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRIF);
			decimal ingresosCobradosNoAcumulables = ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRIF);
			txtIngresosCobradosAcumuladosRIF.Text = FormatoMoneySinNegativo(ingresosCobradosMes + otrosIngresosAcumulables - ingresosCobradosNoAcumulables);
		}

		private void CalcularIngresosCobradosAcumuladosARR()
		{
			decimal ingresosCobradosMes = ConvierteTextoADecimal(txtIngresosCobradosPeriodoAR);
			decimal otrosIngresosAcumulables = ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAR);
			decimal ingresosCobradosNoAcumulables = ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAR);
			txtIngresosCobradosAcumuladosAR.Text = FormatoMoneySinNegativo(ingresosCobradosMes + otrosIngresosAcumulables - ingresosCobradosNoAcumulables);
		}

		private void cmbPorcentajeDeducible_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularPercepcionesExentas();
				CalcularDeduccionesPagadas();
				CalcularIngresosCobradosAcumulados();
				CalcularBaseISR();
				CalcularISRaCargo(ConvierteTextoADecimal(txtBaseISR), txtISRcausado, txtISRaCargo);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void rdoEnBaseFechaFactura_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (((RadioButton)sender).Checked)
				{
					EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
					DateTime fechaDesde = DateTime.Today;
					DateTime fechaHasta = DateTime.Today;
					AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
					int opcionFechaId = 1;
					if (rdoEnBaseFechaPago.Checked)
					{
						opcionFechaId = 2;
					}
					else if (rdoEnBaseFechaDevengada.Checked)
					{
						opcionFechaId = 3;
					}
					CargaPercepciones(Program.EmpresaSeleccionada, fechaDesde, fechaHasta, opcionFechaId, txtTotalPercepcionesExentas, txtTotalPercepcionesGravadas);
					CalcularPercepcionesExentas();
					CalcularDeduccionesPagadas();
					CalcularDeduccionesPagadasRPM();
					CalcularIngresosCobradosAcumulados();
					CalcularIngresosCobradosAcumuladosRPM();
					CalcularBaseISR();
					CalcularBaseIsrRPM();
					CalcularISRaCargo(ConvierteTextoADecimal(txtBaseISR), txtISRcausado, txtISRaCargo);
					CalcularISRaCargoRPM(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
				}
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtDeduccionesSinCFDI_Leave(object sender, EventArgs e)
		{
			TextBoxDecimalMoney_Leave(sender, e);
		}

		private void txtDeduccionesSinCFDI_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularDeduccionesPagadas();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPerdidasFiscalesAmortizar_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularBaseISR();
				CalcularISRaCargo(ConvierteTextoADecimal(txtBaseISR), txtISRcausado, txtISRaCargo);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPagoProvisionalAnteriores_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularISRaCargo(ConvierteTextoADecimal(txtBaseISR), txtISRcausado, txtISRaCargo);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtIngresosCobradosAE_TextChanged(object sender, EventArgs e)
		{
			txtIngresosCobradosRPM.Text = txtIngresosCobradosAE.Text;
		}

		private void txtIngresosCobradosMesesAnterioresAE_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtIngresosCobradosAcumuladosAE_TextChanged(object sender, EventArgs e)
		{
		}

		private void txtREPacumuladosEjercicios2021anteriores_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularIngresosCobradosAcumuladosRPM();
				CalcularBaseIsrRPM();
				CalcularISRaCargoRPM(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtMesDeduccionesPagadas_TextChanged(object sender, EventArgs e)
		{
			txtMesDeduccionesPagadasRPM.Text = txtMesDeduccionesPagadas.Text;
		}

		private void txtDeduccionesPagadasDelMes_TextChanged(object sender, EventArgs e)
		{
			txtDeduccionesPagadasDelMesRPM.Text = txtDeduccionesPagadasDelMes.Text;
		}

		private void txtMesesDeduccionesPagadasMesesAnteriores_TextChanged(object sender, EventArgs e)
		{
			txtMesesDeduccionesPagadasMesesAnterioresRPM.Text = txtMesesDeduccionesPagadasMesesAnteriores.Text;
		}

		private void txtDeduccionesPagadasMesesAnteriores_TextChanged(object sender, EventArgs e)
		{
			txtDeduccionesPagadasMesesAnterioresRPM.Text = txtDeduccionesPagadasMesesAnteriores.Text;
		}

		private void txtPTUpagada_TextChanged(object sender, EventArgs e)
		{
			txtPTUpagadaRPM.Text = txtPTUpagada.Text;
		}

		private void txtDeduccionesPueCP_TextChanged(object sender, EventArgs e)
		{
			txtDeduccionesPueCpRPM.Text = txtDeduccionesPueCP.Text;
		}

		private void btnGuardaDeduccionesRPM_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				int tipoRegimenId = 1;
				int baseFechaId = 1;
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				if (rdoEnBaseFechaPagoRPM.Checked)
				{
					baseFechaId = 2;
				}
				else if (rdoEnBaseFechaDevengadaRPM.Checked)
				{
					baseFechaId = 3;
				}
				if (!DeduccionesPagadasGuardadaRPM)
				{
					new BusEmpresas().AgregaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAE), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAE), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoAE), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizar), 0, ConvierteTextoADecimal(txtPagoProvisionalAnteriores), ConvierteTextoADecimal(txtDeduccionesSinCFDI), ConvierteTextoADecimal(txtDeduccionesPorPago), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesAE), ConvierteTextoADecimal(txtDeduccionesPagadas), baseFechaId, cmbPorcentajeDeducible.SelectedIndex + 1, 0m);
					tipoRegimenId = 2;
					new BusEmpresas().AgregaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRPM), ConvierteTextoADecimal(txtREPacumuladosEjercicios2021anteriores), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRPM), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosRPM), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizarRPM), cmbTasaIsrRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtPagoProvisionalAnterioresRPM), ConvierteTextoADecimal(txtDeduccionesSinCfdiRPM), ConvierteTextoADecimal(txtDeduccionesPorPagoRPM), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRPM), ConvierteTextoADecimal(txtDeduccionesPagadasRPM), baseFechaId, cmbPorcentajeDeducibleRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtNominaNoDeducible));
				}
				else
				{
					tipoRegimenId = 1;
					new BusEmpresas().ActualizaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAE), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAE), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoAE), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizar), 0, ConvierteTextoADecimal(txtPagoProvisionalAnteriores), ConvierteTextoADecimal(txtDeduccionesSinCFDI), ConvierteTextoADecimal(txtDeduccionesPorPago), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesAE), ConvierteTextoADecimal(txtDeduccionesPagadas), baseFechaId, cmbPorcentajeDeducible.SelectedIndex + 1, 0m);
					tipoRegimenId = 2;
					new BusEmpresas().ActualizaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRPM), ConvierteTextoADecimal(txtREPacumuladosEjercicios2021anteriores), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRPM), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosRPM), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizarRPM), cmbTasaIsrRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtPagoProvisionalAnterioresRPM), ConvierteTextoADecimal(txtDeduccionesSinCfdiRPM), ConvierteTextoADecimal(txtDeduccionesPorPagoRPM), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRPM), ConvierteTextoADecimal(txtDeduccionesPagadasRPM), baseFechaId, cmbPorcentajeDeducibleRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtNominaNoDeducible));
				}
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnGuardaDeduccionesAE_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				int tipoRegimenId = 1;
				int baseFechaId = 1;
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				if (rdoEnBaseFechaPago.Checked)
				{
					baseFechaId = 2;
				}
				else if (rdoEnBaseFechaDevengada.Checked)
				{
					baseFechaId = 3;
				}
				if (!DeduccionesPagadasGuardada)
				{
					new BusEmpresas().AgregaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAE), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAE), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosAE), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizar), 0, ConvierteTextoADecimal(txtPagoProvisionalAnteriores), ConvierteTextoADecimal(txtDeduccionesSinCFDI), ConvierteTextoADecimal(txtDeduccionesPorPago), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesAE), ConvierteTextoADecimal(txtDeduccionesPagadas), baseFechaId, cmbPorcentajeDeducible.SelectedIndex + 1, 0m);
					tipoRegimenId = 2;
					new BusEmpresas().AgregaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRPM), ConvierteTextoADecimal(txtREPacumuladosEjercicios2021anteriores), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRPM), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosRPM), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizarRPM), cmbTasaIsrRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtPagoProvisionalAnterioresRPM), ConvierteTextoADecimal(txtDeduccionesSinCfdiRPM), ConvierteTextoADecimal(txtDeduccionesPorPagoRPM), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRPM), ConvierteTextoADecimal(txtDeduccionesPagadasRPM), baseFechaId, cmbPorcentajeDeducibleRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtNominaNoDeducible));
				}
				else
				{
					tipoRegimenId = 1;
					new BusEmpresas().ActualizaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAE), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAE), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosAE), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizar), 0, ConvierteTextoADecimal(txtPagoProvisionalAnteriores), ConvierteTextoADecimal(txtDeduccionesSinCFDI), ConvierteTextoADecimal(txtDeduccionesPorPago), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesAE), ConvierteTextoADecimal(txtDeduccionesPagadas), baseFechaId, cmbPorcentajeDeducible.SelectedIndex + 1, 0m);
					tipoRegimenId = 2;
					new BusEmpresas().ActualizaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRPM), ConvierteTextoADecimal(txtREPacumuladosEjercicios2021anteriores), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRPM), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosRPM), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizarRPM), cmbTasaIsrRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtPagoProvisionalAnterioresRPM), ConvierteTextoADecimal(txtDeduccionesSinCfdiRPM), ConvierteTextoADecimal(txtDeduccionesPorPagoRPM), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRPM), ConvierteTextoADecimal(txtDeduccionesPagadasRPM), baseFechaId, cmbPorcentajeDeducibleRPM.SelectedIndex + 1, ConvierteTextoADecimal(txtNominaNoDeducible));
				}
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnGuardaDeduccionesRIF_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				int tipoRegimenId = 1;
				int baseFechaId = 1;
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				if (rdoEnBaseFechaPago.Checked)
				{
					baseFechaId = 2;
				}
				else if (rdoEnBaseFechaDevengada.Checked)
				{
					baseFechaId = 3;
				}
				if (!DeduccionesPagadasGuardadaRIF)
				{
					tipoRegimenId = 3;
					new BusEmpresas().AgregaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRIF), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRIF), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosRIF), 0m, cmbPorcentajeReduccionRIF.SelectedIndex + 1, ConvierteTextoADecimal(txtGastosMayoresAIngresosPeriodosAnteriores), ConvierteTextoADecimal(txtDeduccionesSinCFDiRIF), ConvierteTextoADecimal(txtDeduccionesPorPagoRIF), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRIF), ConvierteTextoADecimal(txtDeduccionesPagadasRIF), baseFechaId, cmbPorcentajeDeducibleRIF.SelectedIndex + 1, 0m);
				}
				else
				{
					tipoRegimenId = 3;
					new BusEmpresas().ActualizaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRIF), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRIF), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosRIF), 0m, cmbPorcentajeReduccionRIF.SelectedIndex + 1, ConvierteTextoADecimal(txtGastosMayoresAIngresosPeriodosAnteriores), ConvierteTextoADecimal(txtDeduccionesSinCFDiRIF), ConvierteTextoADecimal(txtDeduccionesPorPagoRIF), ConvierteTextoADecimal(txtOtrosGastosPagadosNoDeduciblesRIF), ConvierteTextoADecimal(txtDeduccionesPagadasRIF), baseFechaId, cmbPorcentajeDeducibleRIF.SelectedIndex + 1, 0m);
				}
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void txtDeduccionesSinCfdiRPM_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularDeduccionesPagadasRPM();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPerdidasFiscalesAmortizarRPM_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularIngresosCobradosAcumuladosRPM();
				CalcularBaseIsrRPM();
				CalcularISRaCargoRPM(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtISRretenidoAcumulado_TextChanged(object sender, EventArgs e)
		{
			txtISRretenidoAcumuladoRPM.Text = txtISRretenidoAcumulado.Text;
		}

		private void txtPagoProvisionalAnterioresRPM_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularISRaCargoRPM(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbPorcentajeDeducibleRPM_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularPercepcionesExentas();
				CalcularDeduccionesPagadasRPM();
				CalcularIngresosCobradosAcumuladosRPM();
				CalcularBaseIsrRPM();
				CalcularISRaCargoRPM(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtTotalPercepcionesExentas_TextChanged(object sender, EventArgs e)
		{
			txtTotalPercepcionesExentasRPM.Text = txtTotalPercepcionesExentas.Text;
		}

		private void txtPercepcionesExentas_TextChanged(object sender, EventArgs e)
		{
			txtPercepcionesExentasRPM.Text = txtPercepcionesExentas.Text;
		}

		private void txtTotalPercepcionesGravadas_TextChanged(object sender, EventArgs e)
		{
			txtTotalPercepcionesGravadasRPM.Text = txtTotalPercepcionesGravadas.Text;
		}

		private void txtDeduccionesNominaN_TextChanged(object sender, EventArgs e)
		{
			txtDeduccionesNominaNRPM.Text = txtDeduccionesNominaN.Text;
		}

		private void txtTotalPercepcionesExentasGravadas_TextChanged(object sender, EventArgs e)
		{
			txtTotalPercepcionesExentasGravadasRPM.Text = txtTotalPercepcionesExentasGravadas.Text;
		}

		private void txtNominaNoDeducible_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularPercepcionesExentas();
				CalcularDeduccionesPagadasRPM();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnGuardarIngresosCobrados_Click(object sender, EventArgs e)
		{
			try
			{
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnGuardarIngresosCobrados_MouseEnter(object sender, EventArgs e)
		{
			txtIngresosCobradosAcumuladosRPM.BorderStyle = BorderStyle.Fixed3D;
			txtIngresosCobradosAcumuladosRPM.BackColor = Color.Gray;
			txtIngresosCobradosAcumuladosRPM.ForeColor = Color.White;
		}

		private void flowLayoutPanel102_MouseEnter(object sender, EventArgs e)
		{
			txtIngresosCobradosAcumuladosRPM.BorderStyle = BorderStyle.FixedSingle;
			txtIngresosCobradosAcumuladosRPM.BackColor = Color.Silver;
			txtIngresosCobradosAcumuladosRPM.ForeColor = Color.Black;
		}

		private void flowLayoutPanel62_MouseEnter(object sender, EventArgs e)
		{
			txtIngresosCobradosAcumuladosRPM.BorderStyle = BorderStyle.FixedSingle;
			txtIngresosCobradosAcumuladosRPM.BackColor = Color.Silver;
			txtIngresosCobradosAcumuladosRPM.ForeColor = Color.Black;
			txtDeduccionesPagadasRPM.BorderStyle = BorderStyle.FixedSingle;
			txtDeduccionesPagadasRPM.BackColor = Color.Silver;
			txtDeduccionesPagadasRPM.ForeColor = Color.Black;
		}

		private void btnGuardaDeduccionesRPM_MouseEnter(object sender, EventArgs e)
		{
			txtDeduccionesPagadasRPM.BorderStyle = BorderStyle.Fixed3D;
			txtDeduccionesPagadasRPM.BackColor = Color.Gray;
			txtDeduccionesPagadasRPM.ForeColor = Color.White;
		}

		private void flowLayoutPanel89_MouseEnter(object sender, EventArgs e)
		{
			txtDeduccionesPagadasRPM.BorderStyle = BorderStyle.FixedSingle;
			txtDeduccionesPagadasRPM.BackColor = Color.Silver;
			txtDeduccionesPagadasRPM.ForeColor = Color.Black;
		}

		private void rdoEnBaseFechaFacturaRPM_CheckedChanged(object sender, EventArgs e)
		{
			rdoEnBaseFechaFactura.Checked = ((RadioButton)sender).Checked;
		}

		private void rdoEnBaseFechaPagoRPM_CheckedChanged(object sender, EventArgs e)
		{
			rdoEnBaseFechaPago.Checked = ((RadioButton)sender).Checked;
		}

		private void rdoEnBaseFechaDevengadaRPM_CheckedChanged(object sender, EventArgs e)
		{
			rdoEnBaseFechaDevengada.Checked = ((RadioButton)sender).Checked;
		}

		private void btnExportarISR_Click(object sender, EventArgs e)
		{
			try
			{
				List<EntEstadoDeCuenta> lstISR = new List<EntEstadoDeCuenta>();
				string titulo = "";
				DateTime fechaDesde = DateTime.Today;
				DateTime fechaHasta = DateTime.Today;
				AsignaFechaDesdeFechaHastaFromCmbPeriodos(cmbMesesComprobantes, PeriocidadId, ref fechaDesde, ref fechaHasta);
				ImprimeDeclaracion vImprime = new ImprimeDeclaracion(lstISR, titulo, fechaDesde);
				string periodo = fechaDesde.ToString("MMM yyyy").ToUpper();
				if (tcCalculosISR.SelectedIndex == 0)
				{
					lstISR = ObtieneListaImpresionISRresico(ConvierteTextoADecimal(txtIngresosCobrados), txtPorcentajeTablaMensual.Text, ConvierteTextoADecimal(txtISRDeterminado), ConvierteTextoADecimal(txtISRRetenido), ConvierteTextoADecimal(txtISRporPagar), ConvierteTextoADecimal(txtTotalIngresosAnual), txtPorcentajeTablaAnual.Text, ConvierteTextoADecimal(txtISRDeterminadoAnual), ConvierteTextoADecimal(txtISRRetenidoAnual), ConvierteTextoADecimal(txtPagosProvisionalesCaptura), lbIsrPorPagarAfavor.Text, ConvierteTextoADecimal(txtISRporPagarAnual));
					titulo = lbTituloISRresicoMensual.Text.Replace("MENSUAL", "");
				}
				else if (tcCalculosISR.SelectedIndex == 1)
				{
					lstISR = ObtieneListaImpresionISRresicoMoral(ConvierteTextoADecimal(txtIngresosCobradosRPM), ConvierteTextoADecimal(txtIngresosCobradosMesesAnterioresRPM), ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRPM), ConvierteTextoADecimal(txtREPacumuladosEjercicios2021anteriores), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRPM), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoRPM), ConvierteTextoADecimal(txtDeduccionesPagadasDelMesRPM), ConvierteTextoADecimal(txtDeduccionesPagadasMesesAnterioresRPM), ConvierteTextoADecimal(txtDeduccionesPagadasAcumuladasRPM), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizarRPM), ConvierteTextoADecimal(txtPTUpagadaRPM), ConvierteTextoADecimal(txtBaseIsrRPM), cmbTasaIsrRPM.Text, ConvierteTextoADecimal(txtISRcausadoRPM), ConvierteTextoADecimal(txtISRretenidoAcumuladoRPM), ConvierteTextoADecimal(txtPagoProvisionalAnterioresRPM), ConvierteTextoADecimal(txtISRaCargoRPM));
					titulo = lbTituloISRresicoPM.Text;
				}
				else if (tcCalculosISR.SelectedIndex == 2)
				{
					lstISR = ObtieneListaImpresionISRae(ConvierteTextoADecimal(txtIngresosCobradosAE), ConvierteTextoADecimal(txtIngresosCobradosMesesAnterioresAE), ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAE), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAE), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoAE), txtMesDeduccionesPagadas.Text, ConvierteTextoADecimal(txtDeduccionesPagadasDelMes), txtMesesDeduccionesPagadasMesesAnteriores.Text, ConvierteTextoADecimal(txtDeduccionesPagadasMesesAnteriores), ConvierteTextoADecimal(txtDeduccionesPagadasAcumuladas), ConvierteTextoADecimal(txtPerdidasFiscalesAmortizar), ConvierteTextoADecimal(txtPTUpagada), ConvierteTextoADecimal(txtBaseISR), ConvierteTextoADecimal(txtISRcausado), ConvierteTextoADecimal(txtISRretenidoAcumulado), ConvierteTextoADecimal(txtPagoProvisionalAnteriores), ConvierteTextoADecimal(txtISRaCargo));
					titulo = lbTituloISRae.Text;
				}
				else if (tcCalculosISR.SelectedIndex == 3)
				{
					lstISR = ObtieneListaImpresionISRrif(ConvierteTextoADecimal(txtIngresosCobradosRIF), ConvierteTextoADecimal(txtOtrosIngresosAcumulablesRIF), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesRIF), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoRIF), ConvierteTextoADecimal(txtDeduccionesPagadasDelMesRIF), ConvierteTextoADecimal(txtPTUpagada), ConvierteTextoADecimal(txtGastosMayoresAingresos), ConvierteTextoADecimal(txtGastosMayoresAIngresosPeriodosAnteriores), ConvierteTextoADecimal(txtUtilidad), ConvierteTextoADecimal(txtISRcausadoRIF), cmbPorcentajeReduccionRIF.Text, ConvierteTextoADecimal(txtIsrReducido), ConvierteTextoADecimal(txtISRretenidoAcumuladoRIF), ConvierteTextoADecimal(txtISRaCargoRIF), ConvierteTextoADecimal(txtIsrPorPagarRIF));
					titulo = lbTituloISRrif.Text;
					periodo = fechaDesde.ToString("MMM").ToUpper() + "-" + fechaHasta.ToString("MMM").ToUpper();
				}
				else if (tcCalculosISR.SelectedIndex == 4)
				{
					lstISR = ObtieneListaImpresionISRarr(ConvierteTextoADecimal(txtIngresosCobradosPeriodoAR), ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAR), ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAR), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosGuardadoAR), ConvierteTextoADecimal(txtDeduccionesOpcional), ConvierteTextoADecimal(txtPredialAR), ConvierteTextoADecimal(txtTotalDeduccionesPeriodoAR), ConvierteTextoADecimal(txtBaseAR), ConvierteTextoADecimal(txtISRCausadoAR), ConvierteTextoADecimal(txtISRRetenidoPeriodoAR), ConvierteTextoADecimal(txtISRaCargoAR));
					titulo = lbTituloISRar.Text;
				}
				vImprime = new ImprimeDeclaracion(lstISR, titulo, periodo);
				vImprime.Show();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtOtrosIngresosAcumulablesAE_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularIngresosCobradosAcumulados();
				CalcularBaseISR();
				CalcularISRaCargo(ConvierteTextoADecimal(txtBaseIsrRPM), txtISRcausadoRPM, txtISRaCargoRPM);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbPorcentajeDeducibleRIF_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularPercepcionesExentas();
				CalcularDeduccionesPagadasRIF();
				CalcularIngresosCobradosAcumuladosRIF();
				CalcularBaseIsrRIF();
				CalcularISRaCargoRIF(ConvierteTextoADecimal(txtUtilidad), txtISRcausadoRIF, txtISRaCargoRIF);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtDeduccionesSinCFDiRIF_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularDeduccionesPagadasRIF();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtOtrosIngresosAcumulablesRIF_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularIngresosCobradosAcumuladosRIF();
				CalcularBaseIsrRIF();
				CalcularISRaCargoRIF(ConvierteTextoADecimal(txtUtilidad), txtISRcausadoRIF, txtISRaCargoRIF);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtGastosMayoresAIngresosPeriodosAnteriores_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularBaseIsrRIF();
				CalcularISRaCargoRIF(ConvierteTextoADecimal(txtUtilidad), txtISRcausadoRIF, txtISRaCargoRIF);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void cmbPorcentajeReduccionRIF_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularISRaCargoRIF(ConvierteTextoADecimal(txtUtilidad), txtISRcausadoRIF, txtISRaCargoRIF);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtOtrosIngresosAcumulablesAR_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularIngresosCobradosAcumuladosARR();
				CalcularDeduccionesPagadasARR();
				CalcularBaseIsrARR();
				CalcularISRaCargoARR(ConvierteTextoADecimal(txtBaseAR), txtISRCausadoAR, txtISRaCargoAR);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void txtPredialAR_TextChanged(object sender, EventArgs e)
		{
			try
			{
				CalcularDeduccionesPagadasARR();
				CalcularBaseIsrARR();
				CalcularISRaCargoARR(ConvierteTextoADecimal(txtBaseAR), txtISRCausadoAR, txtISRaCargoAR);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
		}

		private void btnGuardarCalculoAR_Click(object sender, EventArgs e)
		{
			try
			{
				SetWaitCursor();
				int tipoRegimenId = 1;
				int baseFechaId = 1;
				EntCatalogoGenerico periodo = ObtieneCatalogoGenericoFromCmb(cmbMesesComprobantes);
				if (rdoEnBaseFechaPago.Checked)
				{
					baseFechaId = 2;
				}
				else if (rdoEnBaseFechaDevengada.Checked)
				{
					baseFechaId = 3;
				}
				if (!DeduccionesPagadasGuardadaARR)
				{
					tipoRegimenId = 4;
					new BusEmpresas().AgregaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAR), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAR), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosAR), 0m, 0, ConvierteTextoADecimal(txtPredialAR), 0m, 0m, 0m, 0m, baseFechaId, cmbDeduccionOpcionalAR.SelectedIndex + 1, 0m);
				}
				else
				{
					tipoRegimenId = 4;
					new BusEmpresas().ActualizaEmpresaISR(Program.EmpresaSeleccionada.Id, periodo.Id, ConvierteTextoAInteger(periodo.Clave), tipoRegimenId, ConvierteTextoADecimal(txtOtrosIngresosAcumulablesAR), 0m, ConvierteTextoADecimal(txtIngresosCobradosNoAcumulablesAR), ConvierteTextoADecimal(txtIngresosCobradosAcumuladosAR), 0m, 0, ConvierteTextoADecimal(txtPredialAR), 0m, 0m, 0m, 0m, baseFechaId, cmbDeduccionOpcionalAR.SelectedIndex + 1, 0m);
				}
				btnRefrescar.PerformClick();
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
			}
		}

		private void btnBuscaEmpresa_Click(object sender, EventArgs e)
		{
			try
			{
				Program.EmpresaSeleccionada = SeleccionaEmpresa();
				cmbEmpresas.SelectedIndex = ((List<EntEmpresa>)cmbEmpresas.DataSource).FindIndex((EntEmpresa P) => P.Id == Program.EmpresaSeleccionada.Id);
			}
			catch (Exception ex)
			{
				MuestraExcepcion(ex);
			}
			finally
			{
				SetDefaultCursor();
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeeXML.Pantallas.CalculoISR));
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.cmbEmpresas = new System.Windows.Forms.ComboBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pnlCalculoISR = new System.Windows.Forms.Panel();
			this.tcCalculosISR = new System.Windows.Forms.TabControl();
			this.tpResicoPF = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbTituloISRresicoAnual = new System.Windows.Forms.Label();
			this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalIngresosAnual = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPorcentajeTablaAnual = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.flowLayoutPanel9 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRDeterminadoAnual = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.flowLayoutPanel10 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRRetenidoAnual = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.flowLayoutPanel12 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPagosProvisionalesCaptura = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.flowLayoutPanel13 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRporPagarAnual = new System.Windows.Forms.TextBox();
			this.lbIsrPorPagarAfavor = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.flpCalculoIsrMensual = new System.Windows.Forms.FlowLayoutPanel();
			this.lbTituloISRresicoMensual = new System.Windows.Forms.Label();
			this.flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobrados = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPorcentajeTablaMensual = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRDeterminado = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRRetenido = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.flowLayoutPanel11 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRporPagar = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
			this.tpResicoPM = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel62 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbTituloISRresicoPM = new System.Windows.Forms.Label();
			this.flowLayoutPanel63 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosRPM = new System.Windows.Forms.TextBox();
			this.label49 = new System.Windows.Forms.Label();
			this.flowLayoutPanel64 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosMesesAnterioresRPM = new System.Windows.Forms.TextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.flowLayoutPanel45 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosIngresosAcumulablesRPM = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.flowLayoutPanel99 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtREPacumuladosEjercicios2021anteriores = new System.Windows.Forms.TextBox();
			this.label77 = new System.Windows.Forms.Label();
			this.flowLayoutPanel104 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosNoAcumulablesRPM = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.flowLayoutPanel65 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosAcumuladosGuardadoRPM = new System.Windows.Forms.TextBox();
			this.txtIngresosCobradosAcumuladosRPM = new System.Windows.Forms.TextBox();
			this.label51 = new System.Windows.Forms.Label();
			this.flowLayoutPanel102 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnGuardarIngresosCobrados = new System.Windows.Forms.Button();
			this.flowLayoutPanel66 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel67 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasDelMesRPM = new System.Windows.Forms.TextBox();
			this.txtMesDeduccionesPagadasRPM = new System.Windows.Forms.TextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.flowLayoutPanel68 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasMesesAnterioresRPM = new System.Windows.Forms.TextBox();
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM = new System.Windows.Forms.TextBox();
			this.label53 = new System.Windows.Forms.Label();
			this.flowLayoutPanel69 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasAcumuladasRPM = new System.Windows.Forms.TextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.flowLayoutPanel70 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel71 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPerdidasFiscalesAmortizarRPM = new System.Windows.Forms.TextBox();
			this.label55 = new System.Windows.Forms.Label();
			this.flowLayoutPanel72 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel73 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPTUpagadaRPM = new System.Windows.Forms.TextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.flowLayoutPanel74 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel75 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtBaseIsrRPM = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.flowLayoutPanel76 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel77 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbTasaIsrRPM = new System.Windows.Forms.ComboBox();
			this.label58 = new System.Windows.Forms.Label();
			this.flowLayoutPanel78 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRcausadoRPM = new System.Windows.Forms.TextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.flowLayoutPanel79 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRretenidoAcumuladoRPM = new System.Windows.Forms.TextBox();
			this.label60 = new System.Windows.Forms.Label();
			this.flowLayoutPanel80 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPagoProvisionalAnterioresRPM = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.flowLayoutPanel81 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRaCargoRPM = new System.Windows.Forms.TextBox();
			this.label62 = new System.Windows.Forms.Label();
			this.flowLayoutPanel82 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel83 = new System.Windows.Forms.FlowLayoutPanel();
			this.label63 = new System.Windows.Forms.Label();
			this.flowLayoutPanel84 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPueCpRPM = new System.Windows.Forms.TextBox();
			this.label64 = new System.Windows.Forms.Label();
			this.flowLayoutPanel85 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesNominaRPM = new System.Windows.Forms.TextBox();
			this.label65 = new System.Windows.Forms.Label();
			this.flowLayoutPanel86 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesSinCfdiRPM = new System.Windows.Forms.TextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.flowLayoutPanel87 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPorPagoRPM = new System.Windows.Forms.TextBox();
			this.label67 = new System.Windows.Forms.Label();
			this.flowLayoutPanel105 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosGastosPagadosNoDeduciblesRPM = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.flowLayoutPanel88 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasGuardadoRPM = new System.Windows.Forms.TextBox();
			this.txtDeduccionesPagadasRPM = new System.Windows.Forms.TextBox();
			this.label68 = new System.Windows.Forms.Label();
			this.flowLayoutPanel90 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel91 = new System.Windows.Forms.FlowLayoutPanel();
			this.label69 = new System.Windows.Forms.Label();
			this.flowLayoutPanel92 = new System.Windows.Forms.FlowLayoutPanel();
			this.rdoEnBaseFechaDevengadaRPM = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaPagoRPM = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaFacturaRPM = new System.Windows.Forms.RadioButton();
			this.label70 = new System.Windows.Forms.Label();
			this.flowLayoutPanel93 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesExentasRPM = new System.Windows.Forms.TextBox();
			this.label71 = new System.Windows.Forms.Label();
			this.flowLayoutPanel94 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbPorcentajeDeducibleRPM = new System.Windows.Forms.ComboBox();
			this.label72 = new System.Windows.Forms.Label();
			this.flowLayoutPanel95 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPercepcionesExentasRPM = new System.Windows.Forms.TextBox();
			this.label73 = new System.Windows.Forms.Label();
			this.flowLayoutPanel96 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesGravadasRPM = new System.Windows.Forms.TextBox();
			this.label74 = new System.Windows.Forms.Label();
			this.flowLayoutPanel98 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesNominaNRPM = new System.Windows.Forms.TextBox();
			this.label76 = new System.Windows.Forms.Label();
			this.flowLayoutPanel100 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtNominaNoDeducible = new System.Windows.Forms.TextBox();
			this.label78 = new System.Windows.Forms.Label();
			this.flowLayoutPanel101 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesFiscalesNominaRPM = new System.Windows.Forms.TextBox();
			this.label79 = new System.Windows.Forms.Label();
			this.flowLayoutPanel97 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesExentasGravadasRPM = new System.Windows.Forms.TextBox();
			this.label75 = new System.Windows.Forms.Label();
			this.flowLayoutPanel89 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnGuardaDeduccionesRPM = new System.Windows.Forms.Button();
			this.tpActividadEmpresarial = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel103 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnGuardaDeduccionesAE = new System.Windows.Forms.Button();
			this.flpCalculoIsrAE = new System.Windows.Forms.FlowLayoutPanel();
			this.lbTituloISRae = new System.Windows.Forms.Label();
			this.flowLayoutPanel23 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosAE = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.flowLayoutPanel24 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosMesesAnterioresAE = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.flowLayoutPanel106 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosIngresosAcumulablesAE = new System.Windows.Forms.TextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.flowLayoutPanel107 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosNoAcumulablesAE = new System.Windows.Forms.TextBox();
			this.label80 = new System.Windows.Forms.Label();
			this.flowLayoutPanel25 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosAcumuladosGuardadoAE = new System.Windows.Forms.TextBox();
			this.txtIngresosCobradosAcumuladosAE = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.flowLayoutPanel46 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel47 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasDelMes = new System.Windows.Forms.TextBox();
			this.txtMesDeduccionesPagadas = new System.Windows.Forms.TextBox();
			this.label37 = new System.Windows.Forms.Label();
			this.flowLayoutPanel48 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasMesesAnteriores = new System.Windows.Forms.TextBox();
			this.txtMesesDeduccionesPagadasMesesAnteriores = new System.Windows.Forms.TextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.flowLayoutPanel49 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasAcumuladas = new System.Windows.Forms.TextBox();
			this.label39 = new System.Windows.Forms.Label();
			this.flowLayoutPanel50 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel51 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPerdidasFiscalesAmortizar = new System.Windows.Forms.TextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.flowLayoutPanel52 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel53 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPTUpagada = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.flowLayoutPanel54 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel55 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtBaseISR = new System.Windows.Forms.TextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.flowLayoutPanel56 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel28 = new System.Windows.Forms.FlowLayoutPanel();
			this.label43 = new System.Windows.Forms.Label();
			this.flowLayoutPanel58 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRcausado = new System.Windows.Forms.TextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.flowLayoutPanel59 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRretenidoAcumulado = new System.Windows.Forms.TextBox();
			this.label45 = new System.Windows.Forms.Label();
			this.flowLayoutPanel60 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPagoProvisionalAnteriores = new System.Windows.Forms.TextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.flowLayoutPanel61 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRaCargo = new System.Windows.Forms.TextBox();
			this.label47 = new System.Windows.Forms.Label();
			this.flowLayoutPanel57 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel33 = new System.Windows.Forms.FlowLayoutPanel();
			this.label22 = new System.Windows.Forms.Label();
			this.flowLayoutPanel34 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPueCP = new System.Windows.Forms.TextBox();
			this.label23 = new System.Windows.Forms.Label();
			this.flowLayoutPanel14 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesNomina = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.flowLayoutPanel41 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesSinCFDI = new System.Windows.Forms.TextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.flowLayoutPanel43 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPorPago = new System.Windows.Forms.TextBox();
			this.label35 = new System.Windows.Forms.Label();
			this.flowLayoutPanel108 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosGastosPagadosNoDeduciblesAE = new System.Windows.Forms.TextBox();
			this.label81 = new System.Windows.Forms.Label();
			this.flowLayoutPanel44 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasGuardado = new System.Windows.Forms.TextBox();
			this.txtDeduccionesPagadas = new System.Windows.Forms.TextBox();
			this.label36 = new System.Windows.Forms.Label();
			this.flowLayoutPanel22 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel26 = new System.Windows.Forms.FlowLayoutPanel();
			this.label26 = new System.Windows.Forms.Label();
			this.flowLayoutPanel40 = new System.Windows.Forms.FlowLayoutPanel();
			this.rdoEnBaseFechaDevengada = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaPago = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaFactura = new System.Windows.Forms.RadioButton();
			this.label32 = new System.Windows.Forms.Label();
			this.flowLayoutPanel35 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesExentas = new System.Windows.Forms.TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.flowLayoutPanel37 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbPorcentajeDeducible = new System.Windows.Forms.ComboBox();
			this.label29 = new System.Windows.Forms.Label();
			this.flowLayoutPanel38 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPercepcionesExentas = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.flowLayoutPanel36 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesGravadas = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.flowLayoutPanel42 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesNominaN = new System.Windows.Forms.TextBox();
			this.label34 = new System.Windows.Forms.Label();
			this.flowLayoutPanel39 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesExentasGravadas = new System.Windows.Forms.TextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.tpRIF = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel109 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnGuardaDeduccionesRIF = new System.Windows.Forms.Button();
			this.flowLayoutPanel110 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbTituloISRrif = new System.Windows.Forms.Label();
			this.flowLayoutPanel111 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosRIF = new System.Windows.Forms.TextBox();
			this.label83 = new System.Windows.Forms.Label();
			this.flowLayoutPanel113 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosIngresosAcumulablesRIF = new System.Windows.Forms.TextBox();
			this.label85 = new System.Windows.Forms.Label();
			this.flowLayoutPanel114 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosNoAcumulablesRIF = new System.Windows.Forms.TextBox();
			this.label86 = new System.Windows.Forms.Label();
			this.flowLayoutPanel115 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosAcumuladosGuardadoRIF = new System.Windows.Forms.TextBox();
			this.txtIngresosCobradosAcumuladosRIF = new System.Windows.Forms.TextBox();
			this.label87 = new System.Windows.Forms.Label();
			this.flowLayoutPanel116 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel117 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasDelMesRIF = new System.Windows.Forms.TextBox();
			this.label88 = new System.Windows.Forms.Label();
			this.flowLayoutPanel123 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPTUpagadaRIF = new System.Windows.Forms.TextBox();
			this.label92 = new System.Windows.Forms.Label();
			this.flowLayoutPanel120 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel119 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtGastosMayoresAingresos = new System.Windows.Forms.TextBox();
			this.label90 = new System.Windows.Forms.Label();
			this.flowLayoutPanel121 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtGastosMayoresAIngresosPeriodosAnteriores = new System.Windows.Forms.TextBox();
			this.label84 = new System.Windows.Forms.Label();
			this.flowLayoutPanel124 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel125 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtUtilidad = new System.Windows.Forms.TextBox();
			this.label93 = new System.Windows.Forms.Label();
			this.flowLayoutPanel126 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel127 = new System.Windows.Forms.FlowLayoutPanel();
			this.label94 = new System.Windows.Forms.Label();
			this.flowLayoutPanel128 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRcausadoRIF = new System.Windows.Forms.TextBox();
			this.label95 = new System.Windows.Forms.Label();
			this.flowLayoutPanel112 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbPorcentajeReduccionRIF = new System.Windows.Forms.ComboBox();
			this.label89 = new System.Windows.Forms.Label();
			this.flowLayoutPanel118 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIsrReducido = new System.Windows.Forms.TextBox();
			this.label91 = new System.Windows.Forms.Label();
			this.flowLayoutPanel131 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRaCargoRIF = new System.Windows.Forms.TextBox();
			this.label98 = new System.Windows.Forms.Label();
			this.flowLayoutPanel129 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRretenidoAcumuladoRIF = new System.Windows.Forms.TextBox();
			this.label96 = new System.Windows.Forms.Label();
			this.flowLayoutPanel122 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIsrPorPagarRIF = new System.Windows.Forms.TextBox();
			this.label97 = new System.Windows.Forms.Label();
			this.flowLayoutPanel132 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel133 = new System.Windows.Forms.FlowLayoutPanel();
			this.label99 = new System.Windows.Forms.Label();
			this.flowLayoutPanel134 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPueCpRIF = new System.Windows.Forms.TextBox();
			this.label100 = new System.Windows.Forms.Label();
			this.flowLayoutPanel135 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesNominaRIF = new System.Windows.Forms.TextBox();
			this.label101 = new System.Windows.Forms.Label();
			this.flowLayoutPanel136 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesSinCFDiRIF = new System.Windows.Forms.TextBox();
			this.label102 = new System.Windows.Forms.Label();
			this.flowLayoutPanel137 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPorPagoRIF = new System.Windows.Forms.TextBox();
			this.label103 = new System.Windows.Forms.Label();
			this.flowLayoutPanel138 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosGastosPagadosNoDeduciblesRIF = new System.Windows.Forms.TextBox();
			this.label104 = new System.Windows.Forms.Label();
			this.flowLayoutPanel139 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesPagadasGuardadoRIF = new System.Windows.Forms.TextBox();
			this.txtDeduccionesPagadasRIF = new System.Windows.Forms.TextBox();
			this.label105 = new System.Windows.Forms.Label();
			this.flowLayoutPanel140 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel141 = new System.Windows.Forms.FlowLayoutPanel();
			this.label106 = new System.Windows.Forms.Label();
			this.flowLayoutPanel142 = new System.Windows.Forms.FlowLayoutPanel();
			this.rdoEnBaseFechaDevengadaRIF = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaPagoRIF = new System.Windows.Forms.RadioButton();
			this.rdoEnBaseFechaFacturaRIF = new System.Windows.Forms.RadioButton();
			this.label107 = new System.Windows.Forms.Label();
			this.flowLayoutPanel143 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesExentasRIF = new System.Windows.Forms.TextBox();
			this.label108 = new System.Windows.Forms.Label();
			this.flowLayoutPanel144 = new System.Windows.Forms.FlowLayoutPanel();
			this.cmbPorcentajeDeducibleRIF = new System.Windows.Forms.ComboBox();
			this.label109 = new System.Windows.Forms.Label();
			this.flowLayoutPanel145 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPercepcionesExentasRIF = new System.Windows.Forms.TextBox();
			this.label110 = new System.Windows.Forms.Label();
			this.flowLayoutPanel146 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesGravadasRIF = new System.Windows.Forms.TextBox();
			this.label111 = new System.Windows.Forms.Label();
			this.flowLayoutPanel147 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesNominaNRIF = new System.Windows.Forms.TextBox();
			this.label112 = new System.Windows.Forms.Label();
			this.flowLayoutPanel148 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalPercepcionesExentasGravadasRIF = new System.Windows.Forms.TextBox();
			this.label113 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.flowLayoutPanel130 = new System.Windows.Forms.FlowLayoutPanel();
			this.btnGuardarCalculoAR = new System.Windows.Forms.Button();
			this.flowLayoutPanel149 = new System.Windows.Forms.FlowLayoutPanel();
			this.lbTituloISRar = new System.Windows.Forms.Label();
			this.flowLayoutPanel150 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosPeriodoAR = new System.Windows.Forms.TextBox();
			this.label114 = new System.Windows.Forms.Label();
			this.flowLayoutPanel151 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtOtrosIngresosAcumulablesAR = new System.Windows.Forms.TextBox();
			this.label115 = new System.Windows.Forms.Label();
			this.flowLayoutPanel152 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosNoAcumulablesAR = new System.Windows.Forms.TextBox();
			this.label116 = new System.Windows.Forms.Label();
			this.flowLayoutPanel153 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtIngresosCobradosAcumuladosGuardadoAR = new System.Windows.Forms.TextBox();
			this.txtIngresosCobradosAcumuladosAR = new System.Windows.Forms.TextBox();
			this.label117 = new System.Windows.Forms.Label();
			this.flowLayoutPanel154 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel155 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtDeduccionesOpcional = new System.Windows.Forms.TextBox();
			this.cmbDeduccionOpcionalAR = new System.Windows.Forms.ComboBox();
			this.label118 = new System.Windows.Forms.Label();
			this.flowLayoutPanel156 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtPredialAR = new System.Windows.Forms.TextBox();
			this.label119 = new System.Windows.Forms.Label();
			this.flowLayoutPanel157 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel183 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtTotalDeduccionesPeriodoAR = new System.Windows.Forms.TextBox();
			this.label142 = new System.Windows.Forms.Label();
			this.flowLayoutPanel158 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel159 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtBaseAR = new System.Windows.Forms.TextBox();
			this.label121 = new System.Windows.Forms.Label();
			this.flowLayoutPanel160 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel161 = new System.Windows.Forms.FlowLayoutPanel();
			this.label122 = new System.Windows.Forms.Label();
			this.flowLayoutPanel162 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRCausadoAR = new System.Windows.Forms.TextBox();
			this.label123 = new System.Windows.Forms.Label();
			this.flowLayoutPanel164 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRRetenidoPeriodoAR = new System.Windows.Forms.TextBox();
			this.label125 = new System.Windows.Forms.Label();
			this.flowLayoutPanel165 = new System.Windows.Forms.FlowLayoutPanel();
			this.txtISRaCargoAR = new System.Windows.Forms.TextBox();
			this.label126 = new System.Windows.Forms.Label();
			this.flowLayoutPanel166 = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlFlujos = new System.Windows.Forms.Panel();
			this.flpFlujos = new System.Windows.Forms.FlowLayoutPanel();
			this.flpPUE = new System.Windows.Forms.FlowLayoutPanel();
			this.label11 = new System.Windows.Forms.Label();
			this.flpTotalesTodos = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel17 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUE = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImportePUE = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel16 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel7 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel18 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCP = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel8 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteCP = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel17 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip5 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel20 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel21 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel22 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel23 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesEg = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel24 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteEg = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel19 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip3 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel9 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel10 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel11 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel19 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotal = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel12 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteTotal = new System.Windows.Forms.ToolStripTextBox();
			this.flpRecibidosMensual = new System.Windows.Forms.FlowLayoutPanel();
			this.label21 = new System.Windows.Forms.Label();
			this.flowLayoutPanel27 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip9 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel41 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel42 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel43 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel44 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUEe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel45 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImportePUEe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel29 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip10 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel46 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator37 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel47 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel48 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator39 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel49 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCPe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator40 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel50 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteCPe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel30 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip11 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel51 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator41 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel52 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator42 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel53 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator43 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel54 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesEge = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator44 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel55 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteEge = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel31 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip12 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel56 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator45 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel57 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator46 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel58 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator47 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel59 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesNDe = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator48 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel60 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteNDe = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel32 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip13 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel61 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator49 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel62 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator50 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel63 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator51 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel64 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotale = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator52 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel65 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtImporteTotale = new System.Windows.Forms.ToolStripTextBox();
			this.flpEmitidosAnual = new System.Windows.Forms.FlowLayoutPanel();
			this.label16 = new System.Windows.Forms.Label();
			this.flowLayoutPanel15 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip4 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel13 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumPUEAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel14 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalPUEAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel15 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaPUEAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel16 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesPUEAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel25 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel18 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip6 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel26 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumCPAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel27 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalCPAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel28 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaCPAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel29 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesCPAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel30 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel20 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip7 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel31 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumEgAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel32 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalEgAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel33 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaEgAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel34 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesEgAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel35 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
			this.flowLayoutPanel21 = new System.Windows.Forms.FlowLayoutPanel();
			this.toolStrip8 = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel36 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtNumTotalAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel37 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtSubtotalTotalAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel38 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtIvaTotalAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel39 = new System.Windows.Forms.ToolStripLabel();
			this.tstxtRetencionesTotalAnual = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel40 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
			this.gvNominas = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalPercepciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TotalDeducciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.entFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnRefrescar = new System.Windows.Forms.Button();
			this.btnExportarISR = new System.Windows.Forms.Button();
			this.rdoPorMesComprobantes = new System.Windows.Forms.RadioButton();
			this.pnlPorMesVentas = new System.Windows.Forms.Panel();
			this.cmbMesesComprobantes = new System.Windows.Forms.ComboBox();
			this.entCatalogoGenericoBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.cmbAñoComprobantes = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCantidadVentas = new System.Windows.Forms.TextBox();
			this.tcCalculosGeneral = new System.Windows.Forms.TabControl();
			this.tpImpresionISR = new System.Windows.Forms.TabPage();
			this.tcCalculosISRimpresion = new System.Windows.Forms.TabControl();
			this.tpImpresionCalculoISR = new System.Windows.Forms.TabPage();
			this.rvCalculoISR = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.rvCalculoISRAnual = new Microsoft.Reporting.WinForms.ReportViewer();
			this.flpEmpresas = new System.Windows.Forms.FlowLayoutPanel();
			this.label24 = new System.Windows.Forms.Label();
			this.btnBuscaEmpresa = new System.Windows.Forms.Button();
			this.tabPage1.SuspendLayout();
			this.pnlCalculoISR.SuspendLayout();
			this.tcCalculosISR.SuspendLayout();
			this.tpResicoPF.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.flowLayoutPanel5.SuspendLayout();
			this.flowLayoutPanel8.SuspendLayout();
			this.flowLayoutPanel9.SuspendLayout();
			this.flowLayoutPanel10.SuspendLayout();
			this.flowLayoutPanel12.SuspendLayout();
			this.flowLayoutPanel13.SuspendLayout();
			this.flpCalculoIsrMensual.SuspendLayout();
			this.flowLayoutPanel6.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel3.SuspendLayout();
			this.flowLayoutPanel4.SuspendLayout();
			this.flowLayoutPanel11.SuspendLayout();
			this.tpResicoPM.SuspendLayout();
			this.flowLayoutPanel62.SuspendLayout();
			this.flowLayoutPanel63.SuspendLayout();
			this.flowLayoutPanel64.SuspendLayout();
			this.flowLayoutPanel45.SuspendLayout();
			this.flowLayoutPanel99.SuspendLayout();
			this.flowLayoutPanel104.SuspendLayout();
			this.flowLayoutPanel65.SuspendLayout();
			this.flowLayoutPanel102.SuspendLayout();
			this.flowLayoutPanel67.SuspendLayout();
			this.flowLayoutPanel68.SuspendLayout();
			this.flowLayoutPanel69.SuspendLayout();
			this.flowLayoutPanel71.SuspendLayout();
			this.flowLayoutPanel73.SuspendLayout();
			this.flowLayoutPanel75.SuspendLayout();
			this.flowLayoutPanel77.SuspendLayout();
			this.flowLayoutPanel78.SuspendLayout();
			this.flowLayoutPanel79.SuspendLayout();
			this.flowLayoutPanel80.SuspendLayout();
			this.flowLayoutPanel81.SuspendLayout();
			this.flowLayoutPanel83.SuspendLayout();
			this.flowLayoutPanel84.SuspendLayout();
			this.flowLayoutPanel85.SuspendLayout();
			this.flowLayoutPanel86.SuspendLayout();
			this.flowLayoutPanel87.SuspendLayout();
			this.flowLayoutPanel105.SuspendLayout();
			this.flowLayoutPanel88.SuspendLayout();
			this.flowLayoutPanel91.SuspendLayout();
			this.flowLayoutPanel92.SuspendLayout();
			this.flowLayoutPanel93.SuspendLayout();
			this.flowLayoutPanel94.SuspendLayout();
			this.flowLayoutPanel95.SuspendLayout();
			this.flowLayoutPanel96.SuspendLayout();
			this.flowLayoutPanel98.SuspendLayout();
			this.flowLayoutPanel100.SuspendLayout();
			this.flowLayoutPanel101.SuspendLayout();
			this.flowLayoutPanel97.SuspendLayout();
			this.flowLayoutPanel89.SuspendLayout();
			this.tpActividadEmpresarial.SuspendLayout();
			this.flowLayoutPanel103.SuspendLayout();
			this.flpCalculoIsrAE.SuspendLayout();
			this.flowLayoutPanel23.SuspendLayout();
			this.flowLayoutPanel24.SuspendLayout();
			this.flowLayoutPanel106.SuspendLayout();
			this.flowLayoutPanel107.SuspendLayout();
			this.flowLayoutPanel25.SuspendLayout();
			this.flowLayoutPanel47.SuspendLayout();
			this.flowLayoutPanel48.SuspendLayout();
			this.flowLayoutPanel49.SuspendLayout();
			this.flowLayoutPanel51.SuspendLayout();
			this.flowLayoutPanel53.SuspendLayout();
			this.flowLayoutPanel55.SuspendLayout();
			this.flowLayoutPanel28.SuspendLayout();
			this.flowLayoutPanel58.SuspendLayout();
			this.flowLayoutPanel59.SuspendLayout();
			this.flowLayoutPanel60.SuspendLayout();
			this.flowLayoutPanel61.SuspendLayout();
			this.flowLayoutPanel33.SuspendLayout();
			this.flowLayoutPanel34.SuspendLayout();
			this.flowLayoutPanel14.SuspendLayout();
			this.flowLayoutPanel41.SuspendLayout();
			this.flowLayoutPanel43.SuspendLayout();
			this.flowLayoutPanel108.SuspendLayout();
			this.flowLayoutPanel44.SuspendLayout();
			this.flowLayoutPanel26.SuspendLayout();
			this.flowLayoutPanel40.SuspendLayout();
			this.flowLayoutPanel35.SuspendLayout();
			this.flowLayoutPanel37.SuspendLayout();
			this.flowLayoutPanel38.SuspendLayout();
			this.flowLayoutPanel36.SuspendLayout();
			this.flowLayoutPanel42.SuspendLayout();
			this.flowLayoutPanel39.SuspendLayout();
			this.tpRIF.SuspendLayout();
			this.flowLayoutPanel109.SuspendLayout();
			this.flowLayoutPanel110.SuspendLayout();
			this.flowLayoutPanel111.SuspendLayout();
			this.flowLayoutPanel113.SuspendLayout();
			this.flowLayoutPanel114.SuspendLayout();
			this.flowLayoutPanel115.SuspendLayout();
			this.flowLayoutPanel117.SuspendLayout();
			this.flowLayoutPanel123.SuspendLayout();
			this.flowLayoutPanel119.SuspendLayout();
			this.flowLayoutPanel121.SuspendLayout();
			this.flowLayoutPanel125.SuspendLayout();
			this.flowLayoutPanel127.SuspendLayout();
			this.flowLayoutPanel128.SuspendLayout();
			this.flowLayoutPanel112.SuspendLayout();
			this.flowLayoutPanel118.SuspendLayout();
			this.flowLayoutPanel131.SuspendLayout();
			this.flowLayoutPanel129.SuspendLayout();
			this.flowLayoutPanel122.SuspendLayout();
			this.flowLayoutPanel133.SuspendLayout();
			this.flowLayoutPanel134.SuspendLayout();
			this.flowLayoutPanel135.SuspendLayout();
			this.flowLayoutPanel136.SuspendLayout();
			this.flowLayoutPanel137.SuspendLayout();
			this.flowLayoutPanel138.SuspendLayout();
			this.flowLayoutPanel139.SuspendLayout();
			this.flowLayoutPanel141.SuspendLayout();
			this.flowLayoutPanel142.SuspendLayout();
			this.flowLayoutPanel143.SuspendLayout();
			this.flowLayoutPanel144.SuspendLayout();
			this.flowLayoutPanel145.SuspendLayout();
			this.flowLayoutPanel146.SuspendLayout();
			this.flowLayoutPanel147.SuspendLayout();
			this.flowLayoutPanel148.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flowLayoutPanel130.SuspendLayout();
			this.flowLayoutPanel149.SuspendLayout();
			this.flowLayoutPanel150.SuspendLayout();
			this.flowLayoutPanel151.SuspendLayout();
			this.flowLayoutPanel152.SuspendLayout();
			this.flowLayoutPanel153.SuspendLayout();
			this.flowLayoutPanel155.SuspendLayout();
			this.flowLayoutPanel156.SuspendLayout();
			this.flowLayoutPanel157.SuspendLayout();
			this.flowLayoutPanel183.SuspendLayout();
			this.flowLayoutPanel159.SuspendLayout();
			this.flowLayoutPanel161.SuspendLayout();
			this.flowLayoutPanel162.SuspendLayout();
			this.flowLayoutPanel164.SuspendLayout();
			this.flowLayoutPanel165.SuspendLayout();
			this.pnlFlujos.SuspendLayout();
			this.flpFlujos.SuspendLayout();
			this.flpPUE.SuspendLayout();
			this.flpTotalesTodos.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.flowLayoutPanel16.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.flowLayoutPanel17.SuspendLayout();
			this.toolStrip5.SuspendLayout();
			this.flowLayoutPanel19.SuspendLayout();
			this.toolStrip3.SuspendLayout();
			this.flpRecibidosMensual.SuspendLayout();
			this.flowLayoutPanel27.SuspendLayout();
			this.toolStrip9.SuspendLayout();
			this.flowLayoutPanel29.SuspendLayout();
			this.toolStrip10.SuspendLayout();
			this.flowLayoutPanel30.SuspendLayout();
			this.toolStrip11.SuspendLayout();
			this.flowLayoutPanel31.SuspendLayout();
			this.toolStrip12.SuspendLayout();
			this.flowLayoutPanel32.SuspendLayout();
			this.toolStrip13.SuspendLayout();
			this.flpEmitidosAnual.SuspendLayout();
			this.flowLayoutPanel15.SuspendLayout();
			this.toolStrip4.SuspendLayout();
			this.flowLayoutPanel18.SuspendLayout();
			this.toolStrip6.SuspendLayout();
			this.flowLayoutPanel20.SuspendLayout();
			this.toolStrip7.SuspendLayout();
			this.flowLayoutPanel21.SuspendLayout();
			this.toolStrip8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.gvNominas).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).BeginInit();
			this.panel1.SuspendLayout();
			this.pnlPorMesVentas.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).BeginInit();
			this.tcCalculosGeneral.SuspendLayout();
			this.tpImpresionISR.SuspendLayout();
			this.tcCalculosISRimpresion.SuspendLayout();
			this.tpImpresionCalculoISR.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.flpEmpresas.SuspendLayout();
			base.SuspendLayout();
			this.cmbEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbEmpresas.DisplayMember = "Descripcion";
			this.cmbEmpresas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEmpresas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbEmpresas.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbEmpresas.FormattingEnabled = true;
			this.cmbEmpresas.Location = new System.Drawing.Point(82, 5);
			this.cmbEmpresas.Name = "cmbEmpresas";
			this.cmbEmpresas.Size = new System.Drawing.Size(410, 24);
			this.cmbEmpresas.TabIndex = 137;
			this.cmbEmpresas.ValueMember = "Id";
			this.cmbEmpresas.SelectedIndexChanged += new System.EventHandler(cmbEmpresas_SelectedIndexChanged);
			this.tabPage1.Controls.Add(this.pnlCalculoISR);
			this.tabPage1.Controls.Add(this.pnlFlujos);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.txtCantidadVentas);
			this.tabPage1.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1060, 480);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Cálculo de ISR";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.pnlCalculoISR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.pnlCalculoISR.AutoScroll = true;
			this.pnlCalculoISR.Controls.Add(this.tcCalculosISR);
			this.pnlCalculoISR.Location = new System.Drawing.Point(6, 67);
			this.pnlCalculoISR.Margin = new System.Windows.Forms.Padding(2);
			this.pnlCalculoISR.Name = "pnlCalculoISR";
			this.pnlCalculoISR.Size = new System.Drawing.Size(670, 406);
			this.pnlCalculoISR.TabIndex = 139;
			this.tcCalculosISR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.tcCalculosISR.Controls.Add(this.tpResicoPF);
			this.tcCalculosISR.Controls.Add(this.tpResicoPM);
			this.tcCalculosISR.Controls.Add(this.tpActividadEmpresarial);
			this.tcCalculosISR.Controls.Add(this.tpRIF);
			this.tcCalculosISR.Controls.Add(this.tabPage2);
			this.tcCalculosISR.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcCalculosISR.Location = new System.Drawing.Point(4, 5);
			this.tcCalculosISR.Name = "tcCalculosISR";
			this.tcCalculosISR.SelectedIndex = 0;
			this.tcCalculosISR.Size = new System.Drawing.Size(666, 398);
			this.tcCalculosISR.TabIndex = 136;
			this.tcCalculosISR.SelectedIndexChanged += new System.EventHandler(tcCalculosISR_SelectedIndexChanged);
			this.tpResicoPF.Controls.Add(this.flowLayoutPanel2);
			this.tpResicoPF.Controls.Add(this.label1);
			this.tpResicoPF.Controls.Add(this.textBox1);
			this.tpResicoPF.Controls.Add(this.flpCalculoIsrMensual);
			this.tpResicoPF.Font = new System.Drawing.Font("Microsoft Tai Le", 7f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tpResicoPF.Location = new System.Drawing.Point(4, 23);
			this.tpResicoPF.Name = "tpResicoPF";
			this.tpResicoPF.Padding = new System.Windows.Forms.Padding(3);
			this.tpResicoPF.Size = new System.Drawing.Size(658, 371);
			this.tpResicoPF.TabIndex = 0;
			this.tpResicoPF.Text = "RESICO - PERSONA FÍSICA";
			this.tpResicoPF.UseVisualStyleBackColor = true;
			this.flowLayoutPanel2.Controls.Add(this.lbTituloISRresicoAnual);
			this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel5);
			this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel8);
			this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel9);
			this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel10);
			this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel12);
			this.flowLayoutPanel2.Controls.Add(this.flowLayoutPanel13);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(2, 225);
			this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(439, 186);
			this.flowLayoutPanel2.TabIndex = 142;
			this.lbTituloISRresicoAnual.AutoSize = true;
			this.lbTituloISRresicoAnual.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbTituloISRresicoAnual.Location = new System.Drawing.Point(2, 0);
			this.lbTituloISRresicoAnual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTituloISRresicoAnual.Name = "lbTituloISRresicoAnual";
			this.lbTituloISRresicoAnual.Size = new System.Drawing.Size(283, 16);
			this.lbTituloISRresicoAnual.TabIndex = 151;
			this.lbTituloISRresicoAnual.Text = "CALCULO DE ISR RESICO PERSONA FÍSICA ANUAL";
			this.flowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel5.Controls.Add(this.txtTotalIngresosAnual);
			this.flowLayoutPanel5.Controls.Add(this.label9);
			this.flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel5.Location = new System.Drawing.Point(2, 18);
			this.flowLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel5.Name = "flowLayoutPanel5";
			this.flowLayoutPanel5.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel5.TabIndex = 0;
			this.txtTotalIngresosAnual.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalIngresosAnual.Location = new System.Drawing.Point(296, 2);
			this.txtTotalIngresosAnual.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalIngresosAnual.Name = "txtTotalIngresosAnual";
			this.txtTotalIngresosAnual.ReadOnly = true;
			this.txtTotalIngresosAnual.Size = new System.Drawing.Size(119, 21);
			this.txtTotalIngresosAnual.TabIndex = 1;
			this.txtTotalIngresosAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(127, 5);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(165, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "INGRESOS COBRADOS EN EL AÑO :";
			this.flowLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel8.Controls.Add(this.txtPorcentajeTablaAnual);
			this.flowLayoutPanel8.Controls.Add(this.label10);
			this.flowLayoutPanel8.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel8.Location = new System.Drawing.Point(2, 46);
			this.flowLayoutPanel8.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel8.Name = "flowLayoutPanel8";
			this.flowLayoutPanel8.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel8.TabIndex = 0;
			this.txtPorcentajeTablaAnual.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPorcentajeTablaAnual.Location = new System.Drawing.Point(296, 2);
			this.txtPorcentajeTablaAnual.Margin = new System.Windows.Forms.Padding(2);
			this.txtPorcentajeTablaAnual.Name = "txtPorcentajeTablaAnual";
			this.txtPorcentajeTablaAnual.ReadOnly = true;
			this.txtPorcentajeTablaAnual.Size = new System.Drawing.Size(119, 21);
			this.txtPorcentajeTablaAnual.TabIndex = 1;
			this.txtPorcentajeTablaAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(130, 5);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(162, 13);
			this.label10.TabIndex = 0;
			this.label10.Text = "(X) PORCENTAJE DE TABLA ANUAL:";
			this.flowLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel9.Controls.Add(this.txtISRDeterminadoAnual);
			this.flowLayoutPanel9.Controls.Add(this.label12);
			this.flowLayoutPanel9.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel9.Location = new System.Drawing.Point(2, 74);
			this.flowLayoutPanel9.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel9.Name = "flowLayoutPanel9";
			this.flowLayoutPanel9.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel9.TabIndex = 1;
			this.txtISRDeterminadoAnual.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRDeterminadoAnual.Location = new System.Drawing.Point(296, 2);
			this.txtISRDeterminadoAnual.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRDeterminadoAnual.Name = "txtISRDeterminadoAnual";
			this.txtISRDeterminadoAnual.ReadOnly = true;
			this.txtISRDeterminadoAnual.Size = new System.Drawing.Size(119, 21);
			this.txtISRDeterminadoAnual.TabIndex = 1;
			this.txtISRDeterminadoAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(182, 5);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(110, 13);
			this.label12.TabIndex = 0;
			this.label12.Text = "(=) ISR DETERMINADO:";
			this.flowLayoutPanel10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel10.Controls.Add(this.txtISRRetenidoAnual);
			this.flowLayoutPanel10.Controls.Add(this.label13);
			this.flowLayoutPanel10.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel10.Location = new System.Drawing.Point(2, 102);
			this.flowLayoutPanel10.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel10.Name = "flowLayoutPanel10";
			this.flowLayoutPanel10.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel10.TabIndex = 2;
			this.txtISRRetenidoAnual.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRRetenidoAnual.Location = new System.Drawing.Point(296, 2);
			this.txtISRRetenidoAnual.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRRetenidoAnual.Name = "txtISRRetenidoAnual";
			this.txtISRRetenidoAnual.ReadOnly = true;
			this.txtISRRetenidoAnual.Size = new System.Drawing.Size(119, 21);
			this.txtISRRetenidoAnual.TabIndex = 1;
			this.txtISRRetenidoAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(207, 5);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(85, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "(-) ISR RETENIDO:";
			this.flowLayoutPanel12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel12.Controls.Add(this.txtPagosProvisionalesCaptura);
			this.flowLayoutPanel12.Controls.Add(this.label17);
			this.flowLayoutPanel12.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel12.Location = new System.Drawing.Point(2, 130);
			this.flowLayoutPanel12.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel12.Name = "flowLayoutPanel12";
			this.flowLayoutPanel12.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel12.TabIndex = 3;
			this.txtPagosProvisionalesCaptura.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPagosProvisionalesCaptura.Location = new System.Drawing.Point(327, 2);
			this.txtPagosProvisionalesCaptura.Margin = new System.Windows.Forms.Padding(2);
			this.txtPagosProvisionalesCaptura.Name = "txtPagosProvisionalesCaptura";
			this.txtPagosProvisionalesCaptura.Size = new System.Drawing.Size(88, 21);
			this.txtPagosProvisionalesCaptura.TabIndex = 3;
			this.txtPagosProvisionalesCaptura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPagosProvisionalesCaptura.TextChanged += new System.EventHandler(txtPagosProvisionalesCaptura_TextChanged);
			this.txtPagosProvisionalesCaptura.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(131, 5);
			this.label17.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(192, 13);
			this.label17.TabIndex = 2;
			this.label17.Text = "(-) PAGOS PROVISIONALES EFECTUADOS:";
			this.flowLayoutPanel13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel13.Controls.Add(this.txtISRporPagarAnual);
			this.flowLayoutPanel13.Controls.Add(this.lbIsrPorPagarAfavor);
			this.flowLayoutPanel13.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel13.Location = new System.Drawing.Point(2, 158);
			this.flowLayoutPanel13.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel13.Name = "flowLayoutPanel13";
			this.flowLayoutPanel13.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel13.TabIndex = 144;
			this.txtISRporPagarAnual.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRporPagarAnual.Location = new System.Drawing.Point(327, 2);
			this.txtISRporPagarAnual.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRporPagarAnual.Name = "txtISRporPagarAnual";
			this.txtISRporPagarAnual.ReadOnly = true;
			this.txtISRporPagarAnual.Size = new System.Drawing.Size(88, 21);
			this.txtISRporPagarAnual.TabIndex = 1;
			this.txtISRporPagarAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.lbIsrPorPagarAfavor.AutoSize = true;
			this.lbIsrPorPagarAfavor.Location = new System.Drawing.Point(227, 5);
			this.lbIsrPorPagarAfavor.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.lbIsrPorPagarAfavor.Name = "lbIsrPorPagarAfavor";
			this.lbIsrPorPagarAfavor.Size = new System.Drawing.Size(96, 13);
			this.lbIsrPorPagarAfavor.TabIndex = 0;
			this.lbIsrPorPagarAfavor.Text = "(=) ISR POR PAGAR:";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(1055, 610);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 128;
			this.label1.Text = "Cantidad:";
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(1103, 606);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(55, 19);
			this.textBox1.TabIndex = 127;
			this.flpCalculoIsrMensual.Controls.Add(this.lbTituloISRresicoMensual);
			this.flpCalculoIsrMensual.Controls.Add(this.flowLayoutPanel6);
			this.flpCalculoIsrMensual.Controls.Add(this.flowLayoutPanel1);
			this.flpCalculoIsrMensual.Controls.Add(this.flowLayoutPanel3);
			this.flpCalculoIsrMensual.Controls.Add(this.flowLayoutPanel4);
			this.flpCalculoIsrMensual.Controls.Add(this.flowLayoutPanel11);
			this.flpCalculoIsrMensual.Controls.Add(this.flowLayoutPanel7);
			this.flpCalculoIsrMensual.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpCalculoIsrMensual.Location = new System.Drawing.Point(2, 5);
			this.flpCalculoIsrMensual.Margin = new System.Windows.Forms.Padding(2);
			this.flpCalculoIsrMensual.Name = "flpCalculoIsrMensual";
			this.flpCalculoIsrMensual.Size = new System.Drawing.Size(439, 186);
			this.flpCalculoIsrMensual.TabIndex = 137;
			this.lbTituloISRresicoMensual.AutoSize = true;
			this.lbTituloISRresicoMensual.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbTituloISRresicoMensual.Location = new System.Drawing.Point(2, 0);
			this.lbTituloISRresicoMensual.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTituloISRresicoMensual.Name = "lbTituloISRresicoMensual";
			this.lbTituloISRresicoMensual.Size = new System.Drawing.Size(299, 16);
			this.lbTituloISRresicoMensual.TabIndex = 151;
			this.lbTituloISRresicoMensual.Text = "CALCULO DE ISR RESICO PERSONA FÍSICA MENSUAL";
			this.flowLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel6.Controls.Add(this.txtIngresosCobrados);
			this.flowLayoutPanel6.Controls.Add(this.label6);
			this.flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel6.Location = new System.Drawing.Point(2, 18);
			this.flowLayoutPanel6.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel6.Name = "flowLayoutPanel6";
			this.flowLayoutPanel6.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel6.TabIndex = 0;
			this.txtIngresosCobrados.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobrados.Location = new System.Drawing.Point(296, 2);
			this.txtIngresosCobrados.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobrados.Name = "txtIngresosCobrados";
			this.txtIngresosCobrados.ReadOnly = true;
			this.txtIngresosCobrados.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobrados.TabIndex = 1;
			this.txtIngresosCobrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(137, 5);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(155, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "INGRESOS COBRADOS DEL MES :";
			this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel1.Controls.Add(this.txtPorcentajeTablaMensual);
			this.flowLayoutPanel1.Controls.Add(this.label2);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 46);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel1.TabIndex = 0;
			this.txtPorcentajeTablaMensual.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPorcentajeTablaMensual.Location = new System.Drawing.Point(296, 2);
			this.txtPorcentajeTablaMensual.Margin = new System.Windows.Forms.Padding(2);
			this.txtPorcentajeTablaMensual.Name = "txtPorcentajeTablaMensual";
			this.txtPorcentajeTablaMensual.ReadOnly = true;
			this.txtPorcentajeTablaMensual.Size = new System.Drawing.Size(119, 21);
			this.txtPorcentajeTablaMensual.TabIndex = 1;
			this.txtPorcentajeTablaMensual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(117, 5);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(175, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "(X) PORCENTAJE DE TABLA MENSUAL:";
			this.flowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel3.Controls.Add(this.txtISRDeterminado);
			this.flowLayoutPanel3.Controls.Add(this.label4);
			this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel3.Location = new System.Drawing.Point(2, 74);
			this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel3.Name = "flowLayoutPanel3";
			this.flowLayoutPanel3.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel3.TabIndex = 1;
			this.txtISRDeterminado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRDeterminado.Location = new System.Drawing.Point(296, 2);
			this.txtISRDeterminado.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRDeterminado.Name = "txtISRDeterminado";
			this.txtISRDeterminado.ReadOnly = true;
			this.txtISRDeterminado.Size = new System.Drawing.Size(119, 21);
			this.txtISRDeterminado.TabIndex = 1;
			this.txtISRDeterminado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(182, 5);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(110, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "(=) ISR DETERMINADO:";
			this.flowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel4.Controls.Add(this.txtISRRetenido);
			this.flowLayoutPanel4.Controls.Add(this.label5);
			this.flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel4.Location = new System.Drawing.Point(2, 102);
			this.flowLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel4.Name = "flowLayoutPanel4";
			this.flowLayoutPanel4.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel4.TabIndex = 2;
			this.txtISRRetenido.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRRetenido.Location = new System.Drawing.Point(296, 2);
			this.txtISRRetenido.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRRetenido.Name = "txtISRRetenido";
			this.txtISRRetenido.ReadOnly = true;
			this.txtISRRetenido.Size = new System.Drawing.Size(119, 21);
			this.txtISRRetenido.TabIndex = 1;
			this.txtISRRetenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(207, 5);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(85, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "(-) ISR RETENIDO:";
			this.flowLayoutPanel11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel11.Controls.Add(this.txtISRporPagar);
			this.flowLayoutPanel11.Controls.Add(this.label8);
			this.flowLayoutPanel11.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel11.Location = new System.Drawing.Point(2, 130);
			this.flowLayoutPanel11.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel11.Name = "flowLayoutPanel11";
			this.flowLayoutPanel11.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel11.TabIndex = 3;
			this.txtISRporPagar.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRporPagar.Location = new System.Drawing.Point(327, 2);
			this.txtISRporPagar.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRporPagar.Name = "txtISRporPagar";
			this.txtISRporPagar.ReadOnly = true;
			this.txtISRporPagar.Size = new System.Drawing.Size(88, 21);
			this.txtISRporPagar.TabIndex = 1;
			this.txtISRporPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(227, 5);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 13);
			this.label8.TabIndex = 0;
			this.label8.Text = "(=) ISR POR PAGAR:";
			this.flowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel7.Location = new System.Drawing.Point(2, 158);
			this.flowLayoutPanel7.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel7.Name = "flowLayoutPanel7";
			this.flowLayoutPanel7.Size = new System.Drawing.Size(417, 24);
			this.flowLayoutPanel7.TabIndex = 144;
			this.tpResicoPM.Controls.Add(this.flowLayoutPanel62);
			this.tpResicoPM.Controls.Add(this.flowLayoutPanel89);
			this.tpResicoPM.Location = new System.Drawing.Point(4, 23);
			this.tpResicoPM.Margin = new System.Windows.Forms.Padding(2);
			this.tpResicoPM.Name = "tpResicoPM";
			this.tpResicoPM.Padding = new System.Windows.Forms.Padding(2);
			this.tpResicoPM.Size = new System.Drawing.Size(658, 371);
			this.tpResicoPM.TabIndex = 2;
			this.tpResicoPM.Text = "RESICO - PERSONA MORAL";
			this.tpResicoPM.UseVisualStyleBackColor = true;
			this.flowLayoutPanel62.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel62.AutoScroll = true;
			this.flowLayoutPanel62.Controls.Add(this.lbTituloISRresicoPM);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel63);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel64);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel45);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel99);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel104);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel65);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel102);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel66);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel67);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel68);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel69);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel70);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel71);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel72);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel73);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel74);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel75);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel76);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel77);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel78);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel79);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel80);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel81);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel82);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel83);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel84);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel85);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel86);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel87);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel105);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel88);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel90);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel91);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel92);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel93);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel94);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel95);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel96);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel98);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel100);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel101);
			this.flowLayoutPanel62.Controls.Add(this.flowLayoutPanel97);
			this.flowLayoutPanel62.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel62.Location = new System.Drawing.Point(4, 2);
			this.flowLayoutPanel62.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel62.Name = "flowLayoutPanel62";
			this.flowLayoutPanel62.Size = new System.Drawing.Size(575, 364);
			this.flowLayoutPanel62.TabIndex = 139;
			this.flowLayoutPanel62.WrapContents = false;
			this.flowLayoutPanel62.MouseEnter += new System.EventHandler(flowLayoutPanel62_MouseEnter);
			this.lbTituloISRresicoPM.AutoSize = true;
			this.lbTituloISRresicoPM.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbTituloISRresicoPM.Location = new System.Drawing.Point(2, 0);
			this.lbTituloISRresicoPM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTituloISRresicoPM.Name = "lbTituloISRresicoPM";
			this.lbTituloISRresicoPM.Size = new System.Drawing.Size(254, 16);
			this.lbTituloISRresicoPM.TabIndex = 151;
			this.lbTituloISRresicoPM.Text = "CÁLCULO DE ISR RESICO - PERSONA MORAL";
			this.flowLayoutPanel63.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel63.Controls.Add(this.txtIngresosCobradosRPM);
			this.flowLayoutPanel63.Controls.Add(this.label49);
			this.flowLayoutPanel63.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel63.Location = new System.Drawing.Point(104, 18);
			this.flowLayoutPanel63.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel63.Name = "flowLayoutPanel63";
			this.flowLayoutPanel63.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel63.TabIndex = 0;
			this.txtIngresosCobradosRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosRPM.Location = new System.Drawing.Point(289, 2);
			this.txtIngresosCobradosRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosRPM.Name = "txtIngresosCobradosRPM";
			this.txtIngresosCobradosRPM.ReadOnly = true;
			this.txtIngresosCobradosRPM.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosRPM.TabIndex = 1;
			this.txtIngresosCobradosRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(109, 5);
			this.label49.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(176, 14);
			this.label49.TabIndex = 0;
			this.label49.Text = "INGRESOS COBRADOS DEL MES :";
			this.flowLayoutPanel64.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel64.Controls.Add(this.txtIngresosCobradosMesesAnterioresRPM);
			this.flowLayoutPanel64.Controls.Add(this.label50);
			this.flowLayoutPanel64.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel64.Location = new System.Drawing.Point(104, 42);
			this.flowLayoutPanel64.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel64.Name = "flowLayoutPanel64";
			this.flowLayoutPanel64.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel64.TabIndex = 0;
			this.txtIngresosCobradosMesesAnterioresRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosMesesAnterioresRPM.Location = new System.Drawing.Point(289, 2);
			this.txtIngresosCobradosMesesAnterioresRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosMesesAnterioresRPM.Name = "txtIngresosCobradosMesesAnterioresRPM";
			this.txtIngresosCobradosMesesAnterioresRPM.ReadOnly = true;
			this.txtIngresosCobradosMesesAnterioresRPM.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosMesesAnterioresRPM.TabIndex = 1;
			this.txtIngresosCobradosMesesAnterioresRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label50.AutoSize = true;
			this.label50.Location = new System.Drawing.Point(21, 5);
			this.label50.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(264, 14);
			this.label50.TabIndex = 0;
			this.label50.Text = "(+) INGRESOS COBRADOS DE MESES ANTERIORES:";
			this.flowLayoutPanel45.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel45.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel45.Controls.Add(this.txtOtrosIngresosAcumulablesRPM);
			this.flowLayoutPanel45.Controls.Add(this.label7);
			this.flowLayoutPanel45.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel45.Location = new System.Drawing.Point(104, 66);
			this.flowLayoutPanel45.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel45.Name = "flowLayoutPanel45";
			this.flowLayoutPanel45.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel45.TabIndex = 140;
			this.txtOtrosIngresosAcumulablesRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosIngresosAcumulablesRPM.Location = new System.Drawing.Point(289, 2);
			this.txtOtrosIngresosAcumulablesRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosIngresosAcumulablesRPM.Name = "txtOtrosIngresosAcumulablesRPM";
			this.txtOtrosIngresosAcumulablesRPM.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosIngresosAcumulablesRPM.TabIndex = 1;
			this.txtOtrosIngresosAcumulablesRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosIngresosAcumulablesRPM.TextChanged += new System.EventHandler(txtREPacumuladosEjercicios2021anteriores_TextChanged);
			this.txtOtrosIngresosAcumulablesRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(87, 5);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(198, 14);
			this.label7.TabIndex = 0;
			this.label7.Text = "(+) OTROS INGRESOS ACUMULABLES:";
			this.flowLayoutPanel99.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel99.Controls.Add(this.txtREPacumuladosEjercicios2021anteriores);
			this.flowLayoutPanel99.Controls.Add(this.label77);
			this.flowLayoutPanel99.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel99.Location = new System.Drawing.Point(39, 90);
			this.flowLayoutPanel99.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel99.Name = "flowLayoutPanel99";
			this.flowLayoutPanel99.Size = new System.Drawing.Size(475, 20);
			this.flowLayoutPanel99.TabIndex = 140;
			this.txtREPacumuladosEjercicios2021anteriores.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtREPacumuladosEjercicios2021anteriores.Location = new System.Drawing.Point(354, 2);
			this.txtREPacumuladosEjercicios2021anteriores.Margin = new System.Windows.Forms.Padding(2);
			this.txtREPacumuladosEjercicios2021anteriores.Name = "txtREPacumuladosEjercicios2021anteriores";
			this.txtREPacumuladosEjercicios2021anteriores.Size = new System.Drawing.Size(119, 21);
			this.txtREPacumuladosEjercicios2021anteriores.TabIndex = 1;
			this.txtREPacumuladosEjercicios2021anteriores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtREPacumuladosEjercicios2021anteriores.TextChanged += new System.EventHandler(txtREPacumuladosEjercicios2021anteriores_TextChanged);
			this.txtREPacumuladosEjercicios2021anteriores.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label77.AutoSize = true;
			this.label77.Location = new System.Drawing.Point(12, 5);
			this.label77.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(338, 14);
			this.label77.TabIndex = 0;
			this.label77.Text = "(-) REP DE CFDI ACUMULADOS EN EJERCICIO 2021 Y ANTERIORES:";
			this.flowLayoutPanel104.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel104.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel104.Controls.Add(this.txtIngresosCobradosNoAcumulablesRPM);
			this.flowLayoutPanel104.Controls.Add(this.label14);
			this.flowLayoutPanel104.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel104.Location = new System.Drawing.Point(104, 114);
			this.flowLayoutPanel104.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel104.Name = "flowLayoutPanel104";
			this.flowLayoutPanel104.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel104.TabIndex = 141;
			this.txtIngresosCobradosNoAcumulablesRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosNoAcumulablesRPM.Location = new System.Drawing.Point(289, 2);
			this.txtIngresosCobradosNoAcumulablesRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosNoAcumulablesRPM.Name = "txtIngresosCobradosNoAcumulablesRPM";
			this.txtIngresosCobradosNoAcumulablesRPM.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosNoAcumulablesRPM.TabIndex = 1;
			this.txtIngresosCobradosNoAcumulablesRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosNoAcumulablesRPM.TextChanged += new System.EventHandler(txtREPacumuladosEjercicios2021anteriores_TextChanged);
			this.txtIngresosCobradosNoAcumulablesRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(47, 5);
			this.label14.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(238, 14);
			this.label14.TabIndex = 0;
			this.label14.Text = "(-) INGRESOS COBRADOS NO ACUMULABLES:";
			this.flowLayoutPanel65.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel65.Controls.Add(this.txtIngresosCobradosAcumuladosGuardadoRPM);
			this.flowLayoutPanel65.Controls.Add(this.txtIngresosCobradosAcumuladosRPM);
			this.flowLayoutPanel65.Controls.Add(this.label51);
			this.flowLayoutPanel65.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel65.Location = new System.Drawing.Point(104, 138);
			this.flowLayoutPanel65.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel65.Name = "flowLayoutPanel65";
			this.flowLayoutPanel65.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel65.TabIndex = 1;
			this.txtIngresosCobradosAcumuladosGuardadoRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosGuardadoRPM.Location = new System.Drawing.Point(321, 2);
			this.txtIngresosCobradosAcumuladosGuardadoRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosGuardadoRPM.Name = "txtIngresosCobradosAcumuladosGuardadoRPM";
			this.txtIngresosCobradosAcumuladosGuardadoRPM.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosGuardadoRPM.Size = new System.Drawing.Size(87, 21);
			this.txtIngresosCobradosAcumuladosGuardadoRPM.TabIndex = 2;
			this.txtIngresosCobradosAcumuladosGuardadoRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosAcumuladosRPM.BackColor = System.Drawing.Color.Silver;
			this.txtIngresosCobradosAcumuladosRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosRPM.Location = new System.Drawing.Point(230, 2);
			this.txtIngresosCobradosAcumuladosRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosRPM.Name = "txtIngresosCobradosAcumuladosRPM";
			this.txtIngresosCobradosAcumuladosRPM.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosRPM.Size = new System.Drawing.Size(87, 21);
			this.txtIngresosCobradosAcumuladosRPM.TabIndex = 1;
			this.txtIngresosCobradosAcumuladosRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(5, 5);
			this.label51.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(221, 14);
			this.label51.TabIndex = 0;
			this.label51.Text = "(=) INGRESOS COBRADOS ACUMULADOS:";
			this.flowLayoutPanel102.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel102.Controls.Add(this.btnGuardarIngresosCobrados);
			this.flowLayoutPanel102.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel102.Location = new System.Drawing.Point(104, 162);
			this.flowLayoutPanel102.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel102.Name = "flowLayoutPanel102";
			this.flowLayoutPanel102.Size = new System.Drawing.Size(410, 52);
			this.flowLayoutPanel102.TabIndex = 168;
			this.flowLayoutPanel102.Visible = false;
			this.flowLayoutPanel102.MouseEnter += new System.EventHandler(flowLayoutPanel102_MouseEnter);
			this.btnGuardarIngresosCobrados.BackColor = System.Drawing.Color.White;
			this.btnGuardarIngresosCobrados.Font = new System.Drawing.Font("Microsoft Tai Le", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnGuardarIngresosCobrados.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnGuardarIngresosCobrados.Location = new System.Drawing.Point(261, 2);
			this.btnGuardarIngresosCobrados.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuardarIngresosCobrados.Name = "btnGuardarIngresosCobrados";
			this.btnGuardarIngresosCobrados.Size = new System.Drawing.Size(147, 57);
			this.btnGuardarIngresosCobrados.TabIndex = 0;
			this.btnGuardarIngresosCobrados.Text = "GUARDAR INGRESOS COBRADOS";
			this.btnGuardarIngresosCobrados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnGuardarIngresosCobrados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnGuardarIngresosCobrados.UseVisualStyleBackColor = false;
			this.btnGuardarIngresosCobrados.Click += new System.EventHandler(btnGuardarIngresosCobrados_Click);
			this.btnGuardarIngresosCobrados.MouseEnter += new System.EventHandler(btnGuardarIngresosCobrados_MouseEnter);
			this.flowLayoutPanel66.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel66.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel66.Location = new System.Drawing.Point(104, 218);
			this.flowLayoutPanel66.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel66.Name = "flowLayoutPanel66";
			this.flowLayoutPanel66.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel66.TabIndex = 145;
			this.flowLayoutPanel67.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel67.Controls.Add(this.txtDeduccionesPagadasDelMesRPM);
			this.flowLayoutPanel67.Controls.Add(this.txtMesDeduccionesPagadasRPM);
			this.flowLayoutPanel67.Controls.Add(this.label52);
			this.flowLayoutPanel67.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel67.Location = new System.Drawing.Point(104, 242);
			this.flowLayoutPanel67.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel67.Name = "flowLayoutPanel67";
			this.flowLayoutPanel67.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel67.TabIndex = 154;
			this.txtDeduccionesPagadasDelMesRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasDelMesRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPagadasDelMesRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasDelMesRPM.Name = "txtDeduccionesPagadasDelMesRPM";
			this.txtDeduccionesPagadasDelMesRPM.ReadOnly = true;
			this.txtDeduccionesPagadasDelMesRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasDelMesRPM.TabIndex = 1;
			this.txtDeduccionesPagadasDelMesRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMesDeduccionesPagadasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtMesDeduccionesPagadasRPM.Location = new System.Drawing.Point(201, 2);
			this.txtMesDeduccionesPagadasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtMesDeduccionesPagadasRPM.Name = "txtMesDeduccionesPagadasRPM";
			this.txtMesDeduccionesPagadasRPM.ReadOnly = true;
			this.txtMesDeduccionesPagadasRPM.Size = new System.Drawing.Size(84, 21);
			this.txtMesDeduccionesPagadasRPM.TabIndex = 2;
			this.txtMesDeduccionesPagadasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(12, 5);
			this.label52.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(185, 14);
			this.label52.TabIndex = 0;
			this.label52.Text = "DEDUCCIONES PAGADAS DEL MES:";
			this.flowLayoutPanel68.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel68.Controls.Add(this.txtDeduccionesPagadasMesesAnterioresRPM);
			this.flowLayoutPanel68.Controls.Add(this.txtMesesDeduccionesPagadasMesesAnterioresRPM);
			this.flowLayoutPanel68.Controls.Add(this.label53);
			this.flowLayoutPanel68.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel68.Location = new System.Drawing.Point(2, 266);
			this.flowLayoutPanel68.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel68.Name = "flowLayoutPanel68";
			this.flowLayoutPanel68.Size = new System.Drawing.Size(512, 20);
			this.flowLayoutPanel68.TabIndex = 155;
			this.txtDeduccionesPagadasMesesAnterioresRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasMesesAnterioresRPM.Location = new System.Drawing.Point(391, 2);
			this.txtDeduccionesPagadasMesesAnterioresRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasMesesAnterioresRPM.Name = "txtDeduccionesPagadasMesesAnterioresRPM";
			this.txtDeduccionesPagadasMesesAnterioresRPM.ReadOnly = true;
			this.txtDeduccionesPagadasMesesAnterioresRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasMesesAnterioresRPM.TabIndex = 1;
			this.txtDeduccionesPagadasMesesAnterioresRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.Location = new System.Drawing.Point(303, 2);
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.Name = "txtMesesDeduccionesPagadasMesesAnterioresRPM";
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.ReadOnly = true;
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.Size = new System.Drawing.Size(84, 21);
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.TabIndex = 2;
			this.txtMesesDeduccionesPagadasMesesAnterioresRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(23, 5);
			this.label53.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(276, 14);
			this.label53.TabIndex = 0;
			this.label53.Text = "(+) DEDUCCIONES PAGADAS DE MESES ANTERIORES:";
			this.flowLayoutPanel69.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel69.Controls.Add(this.txtDeduccionesPagadasAcumuladasRPM);
			this.flowLayoutPanel69.Controls.Add(this.label54);
			this.flowLayoutPanel69.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel69.Location = new System.Drawing.Point(104, 290);
			this.flowLayoutPanel69.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel69.Name = "flowLayoutPanel69";
			this.flowLayoutPanel69.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel69.TabIndex = 168;
			this.txtDeduccionesPagadasAcumuladasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasAcumuladasRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPagadasAcumuladasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasAcumuladasRPM.Name = "txtDeduccionesPagadasAcumuladasRPM";
			this.txtDeduccionesPagadasAcumuladasRPM.ReadOnly = true;
			this.txtDeduccionesPagadasAcumuladasRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasAcumuladasRPM.TabIndex = 3;
			this.txtDeduccionesPagadasAcumuladasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(54, 5);
			this.label54.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(231, 14);
			this.label54.TabIndex = 2;
			this.label54.Text = "(=) DEDUCCIONES PAGADAS ACUMULADAS:";
			this.flowLayoutPanel70.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel70.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel70.Location = new System.Drawing.Point(104, 314);
			this.flowLayoutPanel70.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel70.Name = "flowLayoutPanel70";
			this.flowLayoutPanel70.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel70.TabIndex = 145;
			this.flowLayoutPanel71.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel71.Controls.Add(this.txtPerdidasFiscalesAmortizarRPM);
			this.flowLayoutPanel71.Controls.Add(this.label55);
			this.flowLayoutPanel71.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel71.Location = new System.Drawing.Point(104, 338);
			this.flowLayoutPanel71.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel71.Name = "flowLayoutPanel71";
			this.flowLayoutPanel71.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel71.TabIndex = 145;
			this.txtPerdidasFiscalesAmortizarRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPerdidasFiscalesAmortizarRPM.Location = new System.Drawing.Point(289, 2);
			this.txtPerdidasFiscalesAmortizarRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtPerdidasFiscalesAmortizarRPM.Name = "txtPerdidasFiscalesAmortizarRPM";
			this.txtPerdidasFiscalesAmortizarRPM.Size = new System.Drawing.Size(119, 21);
			this.txtPerdidasFiscalesAmortizarRPM.TabIndex = 1;
			this.txtPerdidasFiscalesAmortizarRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPerdidasFiscalesAmortizarRPM.TextChanged += new System.EventHandler(txtPerdidasFiscalesAmortizarRPM_TextChanged);
			this.txtPerdidasFiscalesAmortizarRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(81, 5);
			this.label55.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(204, 14);
			this.label55.TabIndex = 2;
			this.label55.Text = "(-) PERDIDAS FISCALES DE AMORTIZAR:";
			this.flowLayoutPanel72.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel72.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel72.Location = new System.Drawing.Point(104, 362);
			this.flowLayoutPanel72.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel72.Name = "flowLayoutPanel72";
			this.flowLayoutPanel72.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel72.TabIndex = 145;
			this.flowLayoutPanel73.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel73.Controls.Add(this.txtPTUpagadaRPM);
			this.flowLayoutPanel73.Controls.Add(this.label56);
			this.flowLayoutPanel73.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel73.Location = new System.Drawing.Point(104, 386);
			this.flowLayoutPanel73.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel73.Name = "flowLayoutPanel73";
			this.flowLayoutPanel73.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel73.TabIndex = 145;
			this.txtPTUpagadaRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPTUpagadaRPM.Location = new System.Drawing.Point(289, 2);
			this.txtPTUpagadaRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtPTUpagadaRPM.Name = "txtPTUpagadaRPM";
			this.txtPTUpagadaRPM.ReadOnly = true;
			this.txtPTUpagadaRPM.Size = new System.Drawing.Size(119, 21);
			this.txtPTUpagadaRPM.TabIndex = 3;
			this.txtPTUpagadaRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(111, 5);
			this.label56.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(174, 14);
			this.label56.TabIndex = 4;
			this.label56.Text = "(-) PTU PAGADA EN EL EJERCICIO:";
			this.flowLayoutPanel74.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel74.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel74.Location = new System.Drawing.Point(104, 410);
			this.flowLayoutPanel74.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel74.Name = "flowLayoutPanel74";
			this.flowLayoutPanel74.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel74.TabIndex = 145;
			this.flowLayoutPanel75.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel75.Controls.Add(this.txtBaseIsrRPM);
			this.flowLayoutPanel75.Controls.Add(this.label57);
			this.flowLayoutPanel75.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel75.Location = new System.Drawing.Point(104, 434);
			this.flowLayoutPanel75.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel75.Name = "flowLayoutPanel75";
			this.flowLayoutPanel75.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel75.TabIndex = 145;
			this.txtBaseIsrRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtBaseIsrRPM.Location = new System.Drawing.Point(289, 2);
			this.txtBaseIsrRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtBaseIsrRPM.Name = "txtBaseIsrRPM";
			this.txtBaseIsrRPM.ReadOnly = true;
			this.txtBaseIsrRPM.Size = new System.Drawing.Size(119, 21);
			this.txtBaseIsrRPM.TabIndex = 5;
			this.txtBaseIsrRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(183, 5);
			this.label57.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(102, 14);
			this.label57.TabIndex = 6;
			this.label57.Text = "(=) BASE PARA ISR:";
			this.flowLayoutPanel76.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel76.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel76.Location = new System.Drawing.Point(104, 458);
			this.flowLayoutPanel76.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel76.Name = "flowLayoutPanel76";
			this.flowLayoutPanel76.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel76.TabIndex = 145;
			this.flowLayoutPanel77.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel77.Controls.Add(this.cmbTasaIsrRPM);
			this.flowLayoutPanel77.Controls.Add(this.label58);
			this.flowLayoutPanel77.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel77.Location = new System.Drawing.Point(104, 482);
			this.flowLayoutPanel77.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel77.Name = "flowLayoutPanel77";
			this.flowLayoutPanel77.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel77.TabIndex = 144;
			this.cmbTasaIsrRPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTasaIsrRPM.Enabled = false;
			this.cmbTasaIsrRPM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbTasaIsrRPM.FormattingEnabled = true;
			this.cmbTasaIsrRPM.Items.AddRange(new object[1] { "30%" });
			this.cmbTasaIsrRPM.Location = new System.Drawing.Point(293, 2);
			this.cmbTasaIsrRPM.Margin = new System.Windows.Forms.Padding(2);
			this.cmbTasaIsrRPM.Name = "cmbTasaIsrRPM";
			this.cmbTasaIsrRPM.Size = new System.Drawing.Size(115, 22);
			this.cmbTasaIsrRPM.TabIndex = 2;
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(203, 5);
			this.label58.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(86, 14);
			this.label58.TabIndex = 1;
			this.label58.Text = "(X) TASA DE ISR ";
			this.flowLayoutPanel78.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel78.Controls.Add(this.txtISRcausadoRPM);
			this.flowLayoutPanel78.Controls.Add(this.label59);
			this.flowLayoutPanel78.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel78.Location = new System.Drawing.Point(104, 506);
			this.flowLayoutPanel78.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel78.Name = "flowLayoutPanel78";
			this.flowLayoutPanel78.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel78.TabIndex = 146;
			this.txtISRcausadoRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRcausadoRPM.Location = new System.Drawing.Point(289, 2);
			this.txtISRcausadoRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRcausadoRPM.Name = "txtISRcausadoRPM";
			this.txtISRcausadoRPM.ReadOnly = true;
			this.txtISRcausadoRPM.Size = new System.Drawing.Size(119, 21);
			this.txtISRcausadoRPM.TabIndex = 7;
			this.txtISRcausadoRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(204, 5);
			this.label59.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(81, 14);
			this.label59.TabIndex = 8;
			this.label59.Text = "ISR CAUSADO:";
			this.flowLayoutPanel79.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel79.Controls.Add(this.txtISRretenidoAcumuladoRPM);
			this.flowLayoutPanel79.Controls.Add(this.label60);
			this.flowLayoutPanel79.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel79.Location = new System.Drawing.Point(104, 530);
			this.flowLayoutPanel79.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel79.Name = "flowLayoutPanel79";
			this.flowLayoutPanel79.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel79.TabIndex = 146;
			this.txtISRretenidoAcumuladoRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRretenidoAcumuladoRPM.Location = new System.Drawing.Point(289, 2);
			this.txtISRretenidoAcumuladoRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRretenidoAcumuladoRPM.Name = "txtISRretenidoAcumuladoRPM";
			this.txtISRretenidoAcumuladoRPM.ReadOnly = true;
			this.txtISRretenidoAcumuladoRPM.Size = new System.Drawing.Size(119, 21);
			this.txtISRretenidoAcumuladoRPM.TabIndex = 9;
			this.txtISRretenidoAcumuladoRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(119, 5);
			this.label60.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(166, 14);
			this.label60.TabIndex = 10;
			this.label60.Text = "(-) ISR RETENIDO ACUMULADO:";
			this.flowLayoutPanel80.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel80.Controls.Add(this.txtPagoProvisionalAnterioresRPM);
			this.flowLayoutPanel80.Controls.Add(this.label61);
			this.flowLayoutPanel80.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel80.Location = new System.Drawing.Point(104, 554);
			this.flowLayoutPanel80.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel80.Name = "flowLayoutPanel80";
			this.flowLayoutPanel80.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel80.TabIndex = 146;
			this.txtPagoProvisionalAnterioresRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPagoProvisionalAnterioresRPM.Location = new System.Drawing.Point(289, 2);
			this.txtPagoProvisionalAnterioresRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtPagoProvisionalAnterioresRPM.Name = "txtPagoProvisionalAnterioresRPM";
			this.txtPagoProvisionalAnterioresRPM.Size = new System.Drawing.Size(119, 21);
			this.txtPagoProvisionalAnterioresRPM.TabIndex = 3;
			this.txtPagoProvisionalAnterioresRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPagoProvisionalAnterioresRPM.TextChanged += new System.EventHandler(txtPagoProvisionalAnterioresRPM_TextChanged);
			this.txtPagoProvisionalAnterioresRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(74, 5);
			this.label61.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(211, 14);
			this.label61.TabIndex = 4;
			this.label61.Text = "(-) PAGOS PROVISIONALES ANTERIORES:";
			this.flowLayoutPanel81.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel81.Controls.Add(this.txtISRaCargoRPM);
			this.flowLayoutPanel81.Controls.Add(this.label62);
			this.flowLayoutPanel81.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel81.Location = new System.Drawing.Point(104, 578);
			this.flowLayoutPanel81.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel81.Name = "flowLayoutPanel81";
			this.flowLayoutPanel81.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel81.TabIndex = 146;
			this.txtISRaCargoRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRaCargoRPM.Location = new System.Drawing.Point(289, 2);
			this.txtISRaCargoRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRaCargoRPM.Name = "txtISRaCargoRPM";
			this.txtISRaCargoRPM.ReadOnly = true;
			this.txtISRaCargoRPM.Size = new System.Drawing.Size(119, 21);
			this.txtISRaCargoRPM.TabIndex = 11;
			this.txtISRaCargoRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label62.AutoSize = true;
			this.label62.Location = new System.Drawing.Point(191, 5);
			this.label62.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(94, 14);
			this.label62.TabIndex = 12;
			this.label62.Text = "(=) ISR A CARGO:";
			this.flowLayoutPanel82.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel82.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel82.Location = new System.Drawing.Point(104, 602);
			this.flowLayoutPanel82.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel82.Name = "flowLayoutPanel82";
			this.flowLayoutPanel82.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel82.TabIndex = 145;
			this.flowLayoutPanel83.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel83.BackColor = System.Drawing.Color.MidnightBlue;
			this.flowLayoutPanel83.Controls.Add(this.label63);
			this.flowLayoutPanel83.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel83.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel83.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.flowLayoutPanel83.Location = new System.Drawing.Point(104, 626);
			this.flowLayoutPanel83.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel83.Name = "flowLayoutPanel83";
			this.flowLayoutPanel83.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel83.TabIndex = 152;
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(175, 5);
			this.label63.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(233, 14);
			this.label63.TabIndex = 0;
			this.label63.Text = "INTEGRACIÓN DE DEDUCCIONES PAGADAS";
			this.flowLayoutPanel84.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel84.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel84.Controls.Add(this.txtDeduccionesPueCpRPM);
			this.flowLayoutPanel84.Controls.Add(this.label64);
			this.flowLayoutPanel84.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel84.Location = new System.Drawing.Point(104, 650);
			this.flowLayoutPanel84.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel84.Name = "flowLayoutPanel84";
			this.flowLayoutPanel84.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel84.TabIndex = 153;
			this.txtDeduccionesPueCpRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPueCpRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPueCpRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPueCpRPM.Name = "txtDeduccionesPueCpRPM";
			this.txtDeduccionesPueCpRPM.ReadOnly = true;
			this.txtDeduccionesPueCpRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPueCpRPM.TabIndex = 1;
			this.txtDeduccionesPueCpRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(28, 5);
			this.label64.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(257, 14);
			this.label64.TabIndex = 0;
			this.label64.Text = "DEDUCCIONES SEGÚN CFDI RECIBIDOS PUE/REP:";
			this.flowLayoutPanel85.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel85.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel85.Controls.Add(this.txtDeduccionesNominaRPM);
			this.flowLayoutPanel85.Controls.Add(this.label65);
			this.flowLayoutPanel85.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel85.Location = new System.Drawing.Point(104, 674);
			this.flowLayoutPanel85.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel85.Name = "flowLayoutPanel85";
			this.flowLayoutPanel85.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel85.TabIndex = 154;
			this.txtDeduccionesNominaRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesNominaRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesNominaRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesNominaRPM.Name = "txtDeduccionesNominaRPM";
			this.txtDeduccionesNominaRPM.ReadOnly = true;
			this.txtDeduccionesNominaRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesNominaRPM.TabIndex = 1;
			this.txtDeduccionesNominaRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label65.AutoSize = true;
			this.label65.Location = new System.Drawing.Point(51, 5);
			this.label65.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(234, 14);
			this.label65.TabIndex = 0;
			this.label65.Text = "(+) DEDUCCIONES DE NOMINA SEGÚN CFDI:";
			this.flowLayoutPanel86.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel86.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel86.Controls.Add(this.txtDeduccionesSinCfdiRPM);
			this.flowLayoutPanel86.Controls.Add(this.label66);
			this.flowLayoutPanel86.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel86.Location = new System.Drawing.Point(104, 698);
			this.flowLayoutPanel86.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel86.Name = "flowLayoutPanel86";
			this.flowLayoutPanel86.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel86.TabIndex = 163;
			this.txtDeduccionesSinCfdiRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesSinCfdiRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesSinCfdiRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesSinCfdiRPM.Name = "txtDeduccionesSinCfdiRPM";
			this.txtDeduccionesSinCfdiRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesSinCfdiRPM.TabIndex = 0;
			this.txtDeduccionesSinCfdiRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesSinCfdiRPM.TextChanged += new System.EventHandler(txtDeduccionesSinCfdiRPM_TextChanged);
			this.txtDeduccionesSinCfdiRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(37, 5);
			this.label66.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(248, 14);
			this.label66.TabIndex = 0;
			this.label66.Text = "(+) DEDUCCIONES SIN CFDI (DEPRECIACIONES):";
			this.flowLayoutPanel87.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel87.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel87.Controls.Add(this.txtDeduccionesPorPagoRPM);
			this.flowLayoutPanel87.Controls.Add(this.label67);
			this.flowLayoutPanel87.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel87.Location = new System.Drawing.Point(104, 722);
			this.flowLayoutPanel87.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel87.Name = "flowLayoutPanel87";
			this.flowLayoutPanel87.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel87.TabIndex = 165;
			this.txtDeduccionesPorPagoRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPorPagoRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPorPagoRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPorPagoRPM.Name = "txtDeduccionesPorPagoRPM";
			this.txtDeduccionesPorPagoRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPorPagoRPM.TabIndex = 0;
			this.txtDeduccionesPorPagoRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPorPagoRPM.TextChanged += new System.EventHandler(txtDeduccionesSinCfdiRPM_TextChanged);
			this.txtDeduccionesPorPagoRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(31, 5);
			this.label67.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(254, 14);
			this.label67.TabIndex = 0;
			this.label67.Text = "(+) DEDUCCION POR PAGO DE IMSS/INFONAVIT:";
			this.flowLayoutPanel105.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel105.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel105.Controls.Add(this.txtOtrosGastosPagadosNoDeduciblesRPM);
			this.flowLayoutPanel105.Controls.Add(this.label15);
			this.flowLayoutPanel105.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel105.Location = new System.Drawing.Point(104, 746);
			this.flowLayoutPanel105.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel105.Name = "flowLayoutPanel105";
			this.flowLayoutPanel105.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel105.TabIndex = 166;
			this.txtOtrosGastosPagadosNoDeduciblesRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosGastosPagadosNoDeduciblesRPM.Location = new System.Drawing.Point(289, 2);
			this.txtOtrosGastosPagadosNoDeduciblesRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosGastosPagadosNoDeduciblesRPM.Name = "txtOtrosGastosPagadosNoDeduciblesRPM";
			this.txtOtrosGastosPagadosNoDeduciblesRPM.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosGastosPagadosNoDeduciblesRPM.TabIndex = 0;
			this.txtOtrosGastosPagadosNoDeduciblesRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosGastosPagadosNoDeduciblesRPM.TextChanged += new System.EventHandler(txtDeduccionesSinCfdiRPM_TextChanged);
			this.txtOtrosGastosPagadosNoDeduciblesRPM.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(41, 5);
			this.label15.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(244, 14);
			this.label15.TabIndex = 0;
			this.label15.Text = "(-) OTROS GASTOS PAGADOS NO DEDUCIBLES:";
			this.flowLayoutPanel88.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel88.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel88.Controls.Add(this.txtDeduccionesPagadasGuardadoRPM);
			this.flowLayoutPanel88.Controls.Add(this.txtDeduccionesPagadasRPM);
			this.flowLayoutPanel88.Controls.Add(this.label68);
			this.flowLayoutPanel88.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel88.Location = new System.Drawing.Point(104, 770);
			this.flowLayoutPanel88.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel88.Name = "flowLayoutPanel88";
			this.flowLayoutPanel88.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel88.TabIndex = 166;
			this.txtDeduccionesPagadasGuardadoRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasGuardadoRPM.Location = new System.Drawing.Point(336, 2);
			this.txtDeduccionesPagadasGuardadoRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasGuardadoRPM.Name = "txtDeduccionesPagadasGuardadoRPM";
			this.txtDeduccionesPagadasGuardadoRPM.ReadOnly = true;
			this.txtDeduccionesPagadasGuardadoRPM.Size = new System.Drawing.Size(72, 21);
			this.txtDeduccionesPagadasGuardadoRPM.TabIndex = 2;
			this.txtDeduccionesPagadasGuardadoRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPagadasRPM.BackColor = System.Drawing.Color.Silver;
			this.txtDeduccionesPagadasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasRPM.Location = new System.Drawing.Point(260, 2);
			this.txtDeduccionesPagadasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasRPM.Name = "txtDeduccionesPagadasRPM";
			this.txtDeduccionesPagadasRPM.ReadOnly = true;
			this.txtDeduccionesPagadasRPM.Size = new System.Drawing.Size(72, 21);
			this.txtDeduccionesPagadasRPM.TabIndex = 1;
			this.txtDeduccionesPagadasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label68.AutoSize = true;
			this.label68.Location = new System.Drawing.Point(45, 5);
			this.label68.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(211, 14);
			this.label68.TabIndex = 0;
			this.label68.Text = "(=) DEDUCCIONES PAGADAS EN EL MES:";
			this.flowLayoutPanel90.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel90.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel90.Location = new System.Drawing.Point(104, 794);
			this.flowLayoutPanel90.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel90.Name = "flowLayoutPanel90";
			this.flowLayoutPanel90.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel90.TabIndex = 155;
			this.flowLayoutPanel91.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel91.BackColor = System.Drawing.Color.MidnightBlue;
			this.flowLayoutPanel91.Controls.Add(this.label69);
			this.flowLayoutPanel91.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel91.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel91.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.flowLayoutPanel91.Location = new System.Drawing.Point(104, 818);
			this.flowLayoutPanel91.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel91.Name = "flowLayoutPanel91";
			this.flowLayoutPanel91.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel91.TabIndex = 156;
			this.label69.AutoSize = true;
			this.label69.Location = new System.Drawing.Point(180, 5);
			this.label69.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(228, 14);
			this.label69.TabIndex = 0;
			this.label69.Text = "INTEGRACIÓN DE DEDUCCIONES NÓMINA";
			this.flowLayoutPanel92.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel92.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel92.Controls.Add(this.rdoEnBaseFechaDevengadaRPM);
			this.flowLayoutPanel92.Controls.Add(this.rdoEnBaseFechaPagoRPM);
			this.flowLayoutPanel92.Controls.Add(this.rdoEnBaseFechaFacturaRPM);
			this.flowLayoutPanel92.Controls.Add(this.label70);
			this.flowLayoutPanel92.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel92.Location = new System.Drawing.Point(104, 842);
			this.flowLayoutPanel92.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel92.Name = "flowLayoutPanel92";
			this.flowLayoutPanel92.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel92.TabIndex = 162;
			this.rdoEnBaseFechaDevengadaRPM.AutoSize = true;
			this.rdoEnBaseFechaDevengadaRPM.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaDevengadaRPM.Location = new System.Drawing.Point(291, 3);
			this.rdoEnBaseFechaDevengadaRPM.Name = "rdoEnBaseFechaDevengadaRPM";
			this.rdoEnBaseFechaDevengadaRPM.Size = new System.Drawing.Size(116, 17);
			this.rdoEnBaseFechaDevengadaRPM.TabIndex = 154;
			this.rdoEnBaseFechaDevengadaRPM.Tag = "3";
			this.rdoEnBaseFechaDevengadaRPM.Text = "Fecha Devengada";
			this.rdoEnBaseFechaDevengadaRPM.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaDevengadaRPM.CheckedChanged += new System.EventHandler(rdoEnBaseFechaDevengadaRPM_CheckedChanged);
			this.rdoEnBaseFechaPagoRPM.AutoSize = true;
			this.rdoEnBaseFechaPagoRPM.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaPagoRPM.Location = new System.Drawing.Point(201, 3);
			this.rdoEnBaseFechaPagoRPM.Name = "rdoEnBaseFechaPagoRPM";
			this.rdoEnBaseFechaPagoRPM.Size = new System.Drawing.Size(84, 17);
			this.rdoEnBaseFechaPagoRPM.TabIndex = 152;
			this.rdoEnBaseFechaPagoRPM.Tag = "2";
			this.rdoEnBaseFechaPagoRPM.Text = "Fecha Pago";
			this.rdoEnBaseFechaPagoRPM.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaPagoRPM.CheckedChanged += new System.EventHandler(rdoEnBaseFechaPagoRPM_CheckedChanged);
			this.rdoEnBaseFechaFacturaRPM.AutoSize = true;
			this.rdoEnBaseFechaFacturaRPM.Checked = true;
			this.rdoEnBaseFechaFacturaRPM.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaFacturaRPM.Location = new System.Drawing.Point(99, 3);
			this.rdoEnBaseFechaFacturaRPM.Name = "rdoEnBaseFechaFacturaRPM";
			this.rdoEnBaseFechaFacturaRPM.Size = new System.Drawing.Size(96, 17);
			this.rdoEnBaseFechaFacturaRPM.TabIndex = 155;
			this.rdoEnBaseFechaFacturaRPM.TabStop = true;
			this.rdoEnBaseFechaFacturaRPM.Tag = "1";
			this.rdoEnBaseFechaFacturaRPM.Text = "Fecha Factura";
			this.rdoEnBaseFechaFacturaRPM.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaFacturaRPM.CheckedChanged += new System.EventHandler(rdoEnBaseFechaFacturaRPM_CheckedChanged);
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(35, 5);
			this.label70.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(59, 14);
			this.label70.TabIndex = 153;
			this.label70.Text = "En base a:";
			this.flowLayoutPanel93.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel93.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel93.Controls.Add(this.txtTotalPercepcionesExentasRPM);
			this.flowLayoutPanel93.Controls.Add(this.label71);
			this.flowLayoutPanel93.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel93.Location = new System.Drawing.Point(104, 866);
			this.flowLayoutPanel93.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel93.Name = "flowLayoutPanel93";
			this.flowLayoutPanel93.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel93.TabIndex = 157;
			this.txtTotalPercepcionesExentasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesExentasRPM.Location = new System.Drawing.Point(289, 2);
			this.txtTotalPercepcionesExentasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesExentasRPM.Name = "txtTotalPercepcionesExentasRPM";
			this.txtTotalPercepcionesExentasRPM.ReadOnly = true;
			this.txtTotalPercepcionesExentasRPM.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesExentasRPM.TabIndex = 1;
			this.txtTotalPercepcionesExentasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(61, 5);
			this.label71.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(224, 14);
			this.label71.TabIndex = 0;
			this.label71.Text = "TOTAL PERCEPCIONES EXENTAS EN EL MES:";
			this.flowLayoutPanel94.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel94.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel94.Controls.Add(this.cmbPorcentajeDeducibleRPM);
			this.flowLayoutPanel94.Controls.Add(this.label72);
			this.flowLayoutPanel94.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel94.Location = new System.Drawing.Point(104, 890);
			this.flowLayoutPanel94.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel94.Name = "flowLayoutPanel94";
			this.flowLayoutPanel94.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel94.TabIndex = 159;
			this.cmbPorcentajeDeducibleRPM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPorcentajeDeducibleRPM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbPorcentajeDeducibleRPM.FormattingEnabled = true;
			this.cmbPorcentajeDeducibleRPM.Items.AddRange(new object[3] { "47%", "53%", "100%" });
			this.cmbPorcentajeDeducibleRPM.Location = new System.Drawing.Point(293, 2);
			this.cmbPorcentajeDeducibleRPM.Margin = new System.Windows.Forms.Padding(2);
			this.cmbPorcentajeDeducibleRPM.Name = "cmbPorcentajeDeducibleRPM";
			this.cmbPorcentajeDeducibleRPM.Size = new System.Drawing.Size(115, 22);
			this.cmbPorcentajeDeducibleRPM.TabIndex = 1;
			this.cmbPorcentajeDeducibleRPM.SelectedIndexChanged += new System.EventHandler(cmbPorcentajeDeducibleRPM_SelectedIndexChanged);
			this.label72.AutoSize = true;
			this.label72.Location = new System.Drawing.Point(101, 31);
			this.label72.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(307, 14);
			this.label72.TabIndex = 0;
			this.label72.Text = "(X) PORCENTAJE DEDUCIBLE PARA PERCEPCIONES EXENTOS";
			this.flowLayoutPanel95.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel95.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel95.Controls.Add(this.txtPercepcionesExentasRPM);
			this.flowLayoutPanel95.Controls.Add(this.label73);
			this.flowLayoutPanel95.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel95.Location = new System.Drawing.Point(104, 914);
			this.flowLayoutPanel95.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel95.Name = "flowLayoutPanel95";
			this.flowLayoutPanel95.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel95.TabIndex = 160;
			this.txtPercepcionesExentasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPercepcionesExentasRPM.Location = new System.Drawing.Point(289, 2);
			this.txtPercepcionesExentasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtPercepcionesExentasRPM.Name = "txtPercepcionesExentasRPM";
			this.txtPercepcionesExentasRPM.ReadOnly = true;
			this.txtPercepcionesExentasRPM.Size = new System.Drawing.Size(119, 21);
			this.txtPercepcionesExentasRPM.TabIndex = 1;
			this.txtPercepcionesExentasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label73.AutoSize = true;
			this.label73.Location = new System.Drawing.Point(67, 5);
			this.label73.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(218, 14);
			this.label73.TabIndex = 0;
			this.label73.Text = "(=) PERCEPCIONES EXENTAS DEDUCIBLES:";
			this.flowLayoutPanel96.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel96.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel96.Controls.Add(this.txtTotalPercepcionesGravadasRPM);
			this.flowLayoutPanel96.Controls.Add(this.label74);
			this.flowLayoutPanel96.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel96.Location = new System.Drawing.Point(104, 938);
			this.flowLayoutPanel96.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel96.Name = "flowLayoutPanel96";
			this.flowLayoutPanel96.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel96.TabIndex = 158;
			this.txtTotalPercepcionesGravadasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesGravadasRPM.Location = new System.Drawing.Point(289, 2);
			this.txtTotalPercepcionesGravadasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesGravadasRPM.Name = "txtTotalPercepcionesGravadasRPM";
			this.txtTotalPercepcionesGravadasRPM.ReadOnly = true;
			this.txtTotalPercepcionesGravadasRPM.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesGravadasRPM.TabIndex = 1;
			this.txtTotalPercepcionesGravadasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label74.AutoSize = true;
			this.label74.Location = new System.Drawing.Point(31, 5);
			this.label74.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(254, 14);
			this.label74.TabIndex = 0;
			this.label74.Text = "(+) TOTAL PERCEPCIONES GRAVADAS EN EL MES:";
			this.flowLayoutPanel98.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel98.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel98.Controls.Add(this.txtDeduccionesNominaNRPM);
			this.flowLayoutPanel98.Controls.Add(this.label76);
			this.flowLayoutPanel98.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel98.Location = new System.Drawing.Point(104, 962);
			this.flowLayoutPanel98.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel98.Name = "flowLayoutPanel98";
			this.flowLayoutPanel98.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel98.TabIndex = 164;
			this.txtDeduccionesNominaNRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesNominaNRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesNominaNRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesNominaNRPM.Name = "txtDeduccionesNominaNRPM";
			this.txtDeduccionesNominaNRPM.ReadOnly = true;
			this.txtDeduccionesNominaNRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesNominaNRPM.TabIndex = 1;
			this.txtDeduccionesNominaNRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label76.AutoSize = true;
			this.label76.Location = new System.Drawing.Point(51, 5);
			this.label76.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(234, 14);
			this.label76.TabIndex = 0;
			this.label76.Text = "(=) DEDUCCIONES DE NOMINA SEGÚN CFDI:";
			this.flowLayoutPanel100.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel100.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel100.Controls.Add(this.txtNominaNoDeducible);
			this.flowLayoutPanel100.Controls.Add(this.label78);
			this.flowLayoutPanel100.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel100.Location = new System.Drawing.Point(104, 986);
			this.flowLayoutPanel100.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel100.Name = "flowLayoutPanel100";
			this.flowLayoutPanel100.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel100.TabIndex = 166;
			this.txtNominaNoDeducible.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtNominaNoDeducible.Location = new System.Drawing.Point(289, 2);
			this.txtNominaNoDeducible.Margin = new System.Windows.Forms.Padding(2);
			this.txtNominaNoDeducible.Name = "txtNominaNoDeducible";
			this.txtNominaNoDeducible.Size = new System.Drawing.Size(119, 21);
			this.txtNominaNoDeducible.TabIndex = 0;
			this.txtNominaNoDeducible.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtNominaNoDeducible.TextChanged += new System.EventHandler(txtNominaNoDeducible_TextChanged);
			this.txtNominaNoDeducible.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label78.AutoSize = true;
			this.label78.Location = new System.Drawing.Point(136, 5);
			this.label78.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(149, 14);
			this.label78.TabIndex = 0;
			this.label78.Text = "(-) NOMINA NO DEDUCIBLE:";
			this.flowLayoutPanel101.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel101.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel101.Controls.Add(this.txtDeduccionesFiscalesNominaRPM);
			this.flowLayoutPanel101.Controls.Add(this.label79);
			this.flowLayoutPanel101.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel101.Location = new System.Drawing.Point(104, 1010);
			this.flowLayoutPanel101.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel101.Name = "flowLayoutPanel101";
			this.flowLayoutPanel101.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel101.TabIndex = 162;
			this.txtDeduccionesFiscalesNominaRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesFiscalesNominaRPM.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesFiscalesNominaRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesFiscalesNominaRPM.Name = "txtDeduccionesFiscalesNominaRPM";
			this.txtDeduccionesFiscalesNominaRPM.ReadOnly = true;
			this.txtDeduccionesFiscalesNominaRPM.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesFiscalesNominaRPM.TabIndex = 1;
			this.txtDeduccionesFiscalesNominaRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label79.AutoSize = true;
			this.label79.Location = new System.Drawing.Point(68, 5);
			this.label79.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(217, 14);
			this.label79.TabIndex = 0;
			this.label79.Text = "(=) DEDUCCIONES FISCALES DE NOMINA:";
			this.flowLayoutPanel97.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel97.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel97.Controls.Add(this.txtTotalPercepcionesExentasGravadasRPM);
			this.flowLayoutPanel97.Controls.Add(this.label75);
			this.flowLayoutPanel97.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel97.Location = new System.Drawing.Point(38, 1034);
			this.flowLayoutPanel97.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel97.Name = "flowLayoutPanel97";
			this.flowLayoutPanel97.Size = new System.Drawing.Size(476, 20);
			this.flowLayoutPanel97.TabIndex = 161;
			this.txtTotalPercepcionesExentasGravadasRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesExentasGravadasRPM.Location = new System.Drawing.Point(355, 2);
			this.txtTotalPercepcionesExentasGravadasRPM.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesExentasGravadasRPM.Name = "txtTotalPercepcionesExentasGravadasRPM";
			this.txtTotalPercepcionesExentasGravadasRPM.ReadOnly = true;
			this.txtTotalPercepcionesExentasGravadasRPM.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesExentasGravadasRPM.TabIndex = 1;
			this.txtTotalPercepcionesExentasGravadasRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label75.AutoSize = true;
			this.label75.Location = new System.Drawing.Point(56, 5);
			this.label75.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(295, 14);
			this.label75.TabIndex = 0;
			this.label75.Text = "TOTAL PERCEPCIONES EXENTAS + GRAVADAS EN EL MES:";
			this.flowLayoutPanel89.Controls.Add(this.btnGuardaDeduccionesRPM);
			this.flowLayoutPanel89.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel89.Location = new System.Drawing.Point(581, -2);
			this.flowLayoutPanel89.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel89.Name = "flowLayoutPanel89";
			this.flowLayoutPanel89.Size = new System.Drawing.Size(77, 278);
			this.flowLayoutPanel89.TabIndex = 140;
			this.btnGuardaDeduccionesRPM.BackColor = System.Drawing.Color.White;
			this.btnGuardaDeduccionesRPM.Font = new System.Drawing.Font("Microsoft Tai Le", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnGuardaDeduccionesRPM.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnGuardaDeduccionesRPM.Location = new System.Drawing.Point(2, 2);
			this.btnGuardaDeduccionesRPM.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuardaDeduccionesRPM.Name = "btnGuardaDeduccionesRPM";
			this.btnGuardaDeduccionesRPM.Size = new System.Drawing.Size(75, 63);
			this.btnGuardaDeduccionesRPM.TabIndex = 0;
			this.btnGuardaDeduccionesRPM.Text = "GUARDAR CÁLCULO";
			this.btnGuardaDeduccionesRPM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardaDeduccionesRPM.UseVisualStyleBackColor = false;
			this.btnGuardaDeduccionesRPM.Click += new System.EventHandler(btnGuardaDeduccionesRPM_Click);
			this.btnGuardaDeduccionesRPM.MouseEnter += new System.EventHandler(btnGuardaDeduccionesRPM_MouseEnter);
			this.tpActividadEmpresarial.AutoScroll = true;
			this.tpActividadEmpresarial.Controls.Add(this.flowLayoutPanel103);
			this.tpActividadEmpresarial.Controls.Add(this.flpCalculoIsrAE);
			this.tpActividadEmpresarial.Location = new System.Drawing.Point(4, 23);
			this.tpActividadEmpresarial.Margin = new System.Windows.Forms.Padding(2);
			this.tpActividadEmpresarial.Name = "tpActividadEmpresarial";
			this.tpActividadEmpresarial.Padding = new System.Windows.Forms.Padding(2);
			this.tpActividadEmpresarial.Size = new System.Drawing.Size(658, 371);
			this.tpActividadEmpresarial.TabIndex = 1;
			this.tpActividadEmpresarial.Text = "ACTIVIDAD EMPRESARIAL";
			this.tpActividadEmpresarial.UseVisualStyleBackColor = true;
			this.flowLayoutPanel103.Controls.Add(this.btnGuardaDeduccionesAE);
			this.flowLayoutPanel103.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel103.Location = new System.Drawing.Point(580, -2);
			this.flowLayoutPanel103.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel103.Name = "flowLayoutPanel103";
			this.flowLayoutPanel103.Size = new System.Drawing.Size(77, 278);
			this.flowLayoutPanel103.TabIndex = 141;
			this.btnGuardaDeduccionesAE.BackColor = System.Drawing.Color.White;
			this.btnGuardaDeduccionesAE.Font = new System.Drawing.Font("Microsoft Tai Le", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnGuardaDeduccionesAE.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnGuardaDeduccionesAE.Location = new System.Drawing.Point(2, 2);
			this.btnGuardaDeduccionesAE.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuardaDeduccionesAE.Name = "btnGuardaDeduccionesAE";
			this.btnGuardaDeduccionesAE.Size = new System.Drawing.Size(75, 63);
			this.btnGuardaDeduccionesAE.TabIndex = 0;
			this.btnGuardaDeduccionesAE.Text = "GUARDAR CÁLCULO";
			this.btnGuardaDeduccionesAE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardaDeduccionesAE.UseVisualStyleBackColor = false;
			this.btnGuardaDeduccionesAE.Click += new System.EventHandler(btnGuardaDeduccionesAE_Click);
			this.flpCalculoIsrAE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpCalculoIsrAE.AutoScroll = true;
			this.flpCalculoIsrAE.Controls.Add(this.lbTituloISRae);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel23);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel24);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel106);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel107);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel25);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel46);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel47);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel48);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel49);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel50);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel51);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel52);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel53);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel54);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel55);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel56);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel28);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel58);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel59);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel60);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel61);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel57);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel33);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel34);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel14);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel41);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel43);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel108);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel44);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel22);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel26);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel40);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel35);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel37);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel38);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel36);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel42);
			this.flpCalculoIsrAE.Controls.Add(this.flowLayoutPanel39);
			this.flpCalculoIsrAE.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpCalculoIsrAE.Location = new System.Drawing.Point(0, 2);
			this.flpCalculoIsrAE.Margin = new System.Windows.Forms.Padding(2);
			this.flpCalculoIsrAE.Name = "flpCalculoIsrAE";
			this.flpCalculoIsrAE.Size = new System.Drawing.Size(578, 364);
			this.flpCalculoIsrAE.TabIndex = 0;
			this.flpCalculoIsrAE.WrapContents = false;
			this.lbTituloISRae.AutoSize = true;
			this.lbTituloISRae.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbTituloISRae.Location = new System.Drawing.Point(2, 0);
			this.lbTituloISRae.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTituloISRae.Name = "lbTituloISRae";
			this.lbTituloISRae.Size = new System.Drawing.Size(308, 16);
			this.lbTituloISRae.TabIndex = 151;
			this.lbTituloISRae.Text = "CÁLCULO DE ISR ACTIVIDAD EMPRESARIAL MENSUAL";
			this.flowLayoutPanel23.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel23.Controls.Add(this.txtIngresosCobradosAE);
			this.flowLayoutPanel23.Controls.Add(this.label18);
			this.flowLayoutPanel23.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel23.Location = new System.Drawing.Point(117, 18);
			this.flowLayoutPanel23.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel23.Name = "flowLayoutPanel23";
			this.flowLayoutPanel23.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel23.TabIndex = 0;
			this.txtIngresosCobradosAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAE.Location = new System.Drawing.Point(289, 2);
			this.txtIngresosCobradosAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAE.Name = "txtIngresosCobradosAE";
			this.txtIngresosCobradosAE.ReadOnly = true;
			this.txtIngresosCobradosAE.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosAE.TabIndex = 0;
			this.txtIngresosCobradosAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosAE.TextChanged += new System.EventHandler(txtIngresosCobradosAE_TextChanged);
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(109, 5);
			this.label18.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(176, 14);
			this.label18.TabIndex = 0;
			this.label18.Text = "INGRESOS COBRADOS DEL MES :";
			this.flowLayoutPanel24.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel24.Controls.Add(this.txtIngresosCobradosMesesAnterioresAE);
			this.flowLayoutPanel24.Controls.Add(this.label19);
			this.flowLayoutPanel24.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel24.Location = new System.Drawing.Point(117, 42);
			this.flowLayoutPanel24.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel24.Name = "flowLayoutPanel24";
			this.flowLayoutPanel24.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel24.TabIndex = 0;
			this.txtIngresosCobradosMesesAnterioresAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosMesesAnterioresAE.Location = new System.Drawing.Point(289, 2);
			this.txtIngresosCobradosMesesAnterioresAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosMesesAnterioresAE.Name = "txtIngresosCobradosMesesAnterioresAE";
			this.txtIngresosCobradosMesesAnterioresAE.ReadOnly = true;
			this.txtIngresosCobradosMesesAnterioresAE.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosMesesAnterioresAE.TabIndex = 0;
			this.txtIngresosCobradosMesesAnterioresAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosMesesAnterioresAE.TextChanged += new System.EventHandler(txtIngresosCobradosMesesAnterioresAE_TextChanged);
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(21, 5);
			this.label19.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(264, 14);
			this.label19.TabIndex = 0;
			this.label19.Text = "(+) INGRESOS COBRADOS DE MESES ANTERIORES:";
			this.flowLayoutPanel106.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel106.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel106.Controls.Add(this.txtOtrosIngresosAcumulablesAE);
			this.flowLayoutPanel106.Controls.Add(this.label48);
			this.flowLayoutPanel106.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel106.Location = new System.Drawing.Point(117, 66);
			this.flowLayoutPanel106.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel106.Name = "flowLayoutPanel106";
			this.flowLayoutPanel106.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel106.TabIndex = 141;
			this.txtOtrosIngresosAcumulablesAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosIngresosAcumulablesAE.Location = new System.Drawing.Point(289, 2);
			this.txtOtrosIngresosAcumulablesAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosIngresosAcumulablesAE.Name = "txtOtrosIngresosAcumulablesAE";
			this.txtOtrosIngresosAcumulablesAE.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosIngresosAcumulablesAE.TabIndex = 1;
			this.txtOtrosIngresosAcumulablesAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosIngresosAcumulablesAE.TextChanged += new System.EventHandler(txtOtrosIngresosAcumulablesAE_TextChanged);
			this.txtOtrosIngresosAcumulablesAE.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label48.AutoSize = true;
			this.label48.Location = new System.Drawing.Point(87, 5);
			this.label48.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(198, 14);
			this.label48.TabIndex = 0;
			this.label48.Text = "(+) OTROS INGRESOS ACUMULABLES:";
			this.flowLayoutPanel107.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel107.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel107.Controls.Add(this.txtIngresosCobradosNoAcumulablesAE);
			this.flowLayoutPanel107.Controls.Add(this.label80);
			this.flowLayoutPanel107.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel107.Location = new System.Drawing.Point(117, 90);
			this.flowLayoutPanel107.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel107.Name = "flowLayoutPanel107";
			this.flowLayoutPanel107.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel107.TabIndex = 143;
			this.txtIngresosCobradosNoAcumulablesAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosNoAcumulablesAE.Location = new System.Drawing.Point(289, 2);
			this.txtIngresosCobradosNoAcumulablesAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosNoAcumulablesAE.Name = "txtIngresosCobradosNoAcumulablesAE";
			this.txtIngresosCobradosNoAcumulablesAE.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosNoAcumulablesAE.TabIndex = 1;
			this.txtIngresosCobradosNoAcumulablesAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosNoAcumulablesAE.TextChanged += new System.EventHandler(txtOtrosIngresosAcumulablesAE_TextChanged);
			this.txtIngresosCobradosNoAcumulablesAE.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label80.AutoSize = true;
			this.label80.Location = new System.Drawing.Point(47, 5);
			this.label80.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(238, 14);
			this.label80.TabIndex = 0;
			this.label80.Text = "(-) INGRESOS COBRADOS NO ACUMULABLES:";
			this.flowLayoutPanel25.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel25.Controls.Add(this.txtIngresosCobradosAcumuladosGuardadoAE);
			this.flowLayoutPanel25.Controls.Add(this.txtIngresosCobradosAcumuladosAE);
			this.flowLayoutPanel25.Controls.Add(this.label20);
			this.flowLayoutPanel25.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel25.Location = new System.Drawing.Point(117, 114);
			this.flowLayoutPanel25.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel25.Name = "flowLayoutPanel25";
			this.flowLayoutPanel25.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel25.TabIndex = 1;
			this.txtIngresosCobradosAcumuladosGuardadoAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosGuardadoAE.Location = new System.Drawing.Point(321, 2);
			this.txtIngresosCobradosAcumuladosGuardadoAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosGuardadoAE.Name = "txtIngresosCobradosAcumuladosGuardadoAE";
			this.txtIngresosCobradosAcumuladosGuardadoAE.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosGuardadoAE.Size = new System.Drawing.Size(87, 21);
			this.txtIngresosCobradosAcumuladosGuardadoAE.TabIndex = 0;
			this.txtIngresosCobradosAcumuladosGuardadoAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosAcumuladosGuardadoAE.TextChanged += new System.EventHandler(txtIngresosCobradosAcumuladosAE_TextChanged);
			this.txtIngresosCobradosAcumuladosAE.BackColor = System.Drawing.Color.Silver;
			this.txtIngresosCobradosAcumuladosAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosAE.Location = new System.Drawing.Point(239, 2);
			this.txtIngresosCobradosAcumuladosAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosAE.Name = "txtIngresosCobradosAcumuladosAE";
			this.txtIngresosCobradosAcumuladosAE.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosAE.Size = new System.Drawing.Size(78, 21);
			this.txtIngresosCobradosAcumuladosAE.TabIndex = 2;
			this.txtIngresosCobradosAcumuladosAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(14, 5);
			this.label20.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(221, 14);
			this.label20.TabIndex = 3;
			this.label20.Text = "(=) INGRESOS COBRADOS ACUMULADOS:";
			this.flowLayoutPanel46.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel46.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel46.Location = new System.Drawing.Point(117, 138);
			this.flowLayoutPanel46.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel46.Name = "flowLayoutPanel46";
			this.flowLayoutPanel46.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel46.TabIndex = 145;
			this.flowLayoutPanel47.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel47.Controls.Add(this.txtDeduccionesPagadasDelMes);
			this.flowLayoutPanel47.Controls.Add(this.txtMesDeduccionesPagadas);
			this.flowLayoutPanel47.Controls.Add(this.label37);
			this.flowLayoutPanel47.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel47.Location = new System.Drawing.Point(117, 162);
			this.flowLayoutPanel47.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel47.Name = "flowLayoutPanel47";
			this.flowLayoutPanel47.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel47.TabIndex = 154;
			this.txtDeduccionesPagadasDelMes.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasDelMes.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPagadasDelMes.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasDelMes.Name = "txtDeduccionesPagadasDelMes";
			this.txtDeduccionesPagadasDelMes.ReadOnly = true;
			this.txtDeduccionesPagadasDelMes.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasDelMes.TabIndex = 0;
			this.txtDeduccionesPagadasDelMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPagadasDelMes.TextChanged += new System.EventHandler(txtDeduccionesPagadasDelMes_TextChanged);
			this.txtMesDeduccionesPagadas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtMesDeduccionesPagadas.Location = new System.Drawing.Point(201, 2);
			this.txtMesDeduccionesPagadas.Margin = new System.Windows.Forms.Padding(2);
			this.txtMesDeduccionesPagadas.Name = "txtMesDeduccionesPagadas";
			this.txtMesDeduccionesPagadas.ReadOnly = true;
			this.txtMesDeduccionesPagadas.Size = new System.Drawing.Size(84, 21);
			this.txtMesDeduccionesPagadas.TabIndex = 2;
			this.txtMesDeduccionesPagadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMesDeduccionesPagadas.TextChanged += new System.EventHandler(txtMesDeduccionesPagadas_TextChanged);
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(12, 5);
			this.label37.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(185, 14);
			this.label37.TabIndex = 0;
			this.label37.Text = "DEDUCCIONES PAGADAS DEL MES:";
			this.flowLayoutPanel48.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel48.Controls.Add(this.txtDeduccionesPagadasMesesAnteriores);
			this.flowLayoutPanel48.Controls.Add(this.txtMesesDeduccionesPagadasMesesAnteriores);
			this.flowLayoutPanel48.Controls.Add(this.label38);
			this.flowLayoutPanel48.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel48.Location = new System.Drawing.Point(2, 186);
			this.flowLayoutPanel48.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel48.Name = "flowLayoutPanel48";
			this.flowLayoutPanel48.Size = new System.Drawing.Size(525, 20);
			this.flowLayoutPanel48.TabIndex = 155;
			this.txtDeduccionesPagadasMesesAnteriores.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasMesesAnteriores.Location = new System.Drawing.Point(404, 2);
			this.txtDeduccionesPagadasMesesAnteriores.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasMesesAnteriores.Name = "txtDeduccionesPagadasMesesAnteriores";
			this.txtDeduccionesPagadasMesesAnteriores.ReadOnly = true;
			this.txtDeduccionesPagadasMesesAnteriores.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasMesesAnteriores.TabIndex = 0;
			this.txtDeduccionesPagadasMesesAnteriores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPagadasMesesAnteriores.TextChanged += new System.EventHandler(txtDeduccionesPagadasMesesAnteriores_TextChanged);
			this.txtMesesDeduccionesPagadasMesesAnteriores.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtMesesDeduccionesPagadasMesesAnteriores.Location = new System.Drawing.Point(316, 2);
			this.txtMesesDeduccionesPagadasMesesAnteriores.Margin = new System.Windows.Forms.Padding(2);
			this.txtMesesDeduccionesPagadasMesesAnteriores.Name = "txtMesesDeduccionesPagadasMesesAnteriores";
			this.txtMesesDeduccionesPagadasMesesAnteriores.ReadOnly = true;
			this.txtMesesDeduccionesPagadasMesesAnteriores.Size = new System.Drawing.Size(84, 21);
			this.txtMesesDeduccionesPagadasMesesAnteriores.TabIndex = 2;
			this.txtMesesDeduccionesPagadasMesesAnteriores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtMesesDeduccionesPagadasMesesAnteriores.TextChanged += new System.EventHandler(txtMesesDeduccionesPagadasMesesAnteriores_TextChanged);
			this.label38.AutoSize = true;
			this.label38.Location = new System.Drawing.Point(36, 5);
			this.label38.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(276, 14);
			this.label38.TabIndex = 0;
			this.label38.Text = "(+) DEDUCCIONES PAGADAS DE MESES ANTERIORES:";
			this.flowLayoutPanel49.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel49.Controls.Add(this.txtDeduccionesPagadasAcumuladas);
			this.flowLayoutPanel49.Controls.Add(this.label39);
			this.flowLayoutPanel49.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel49.Location = new System.Drawing.Point(117, 210);
			this.flowLayoutPanel49.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel49.Name = "flowLayoutPanel49";
			this.flowLayoutPanel49.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel49.TabIndex = 168;
			this.txtDeduccionesPagadasAcumuladas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasAcumuladas.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPagadasAcumuladas.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasAcumuladas.Name = "txtDeduccionesPagadasAcumuladas";
			this.txtDeduccionesPagadasAcumuladas.ReadOnly = true;
			this.txtDeduccionesPagadasAcumuladas.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasAcumuladas.TabIndex = 0;
			this.txtDeduccionesPagadasAcumuladas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(54, 5);
			this.label39.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(231, 14);
			this.label39.TabIndex = 2;
			this.label39.Text = "(=) DEDUCCIONES PAGADAS ACUMULADAS:";
			this.flowLayoutPanel50.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel50.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel50.Location = new System.Drawing.Point(117, 234);
			this.flowLayoutPanel50.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel50.Name = "flowLayoutPanel50";
			this.flowLayoutPanel50.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel50.TabIndex = 145;
			this.flowLayoutPanel51.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel51.Controls.Add(this.txtPerdidasFiscalesAmortizar);
			this.flowLayoutPanel51.Controls.Add(this.label40);
			this.flowLayoutPanel51.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel51.Location = new System.Drawing.Point(117, 258);
			this.flowLayoutPanel51.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel51.Name = "flowLayoutPanel51";
			this.flowLayoutPanel51.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel51.TabIndex = 145;
			this.txtPerdidasFiscalesAmortizar.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPerdidasFiscalesAmortizar.Location = new System.Drawing.Point(289, 2);
			this.txtPerdidasFiscalesAmortizar.Margin = new System.Windows.Forms.Padding(2);
			this.txtPerdidasFiscalesAmortizar.Name = "txtPerdidasFiscalesAmortizar";
			this.txtPerdidasFiscalesAmortizar.Size = new System.Drawing.Size(119, 21);
			this.txtPerdidasFiscalesAmortizar.TabIndex = 0;
			this.txtPerdidasFiscalesAmortizar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPerdidasFiscalesAmortizar.TextChanged += new System.EventHandler(txtPerdidasFiscalesAmortizar_TextChanged);
			this.txtPerdidasFiscalesAmortizar.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label40.AutoSize = true;
			this.label40.Location = new System.Drawing.Point(81, 5);
			this.label40.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(204, 14);
			this.label40.TabIndex = 2;
			this.label40.Text = "(-) PERDIDAS FISCALES DE AMORTIZAR:";
			this.flowLayoutPanel52.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel52.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel52.Location = new System.Drawing.Point(117, 282);
			this.flowLayoutPanel52.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel52.Name = "flowLayoutPanel52";
			this.flowLayoutPanel52.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel52.TabIndex = 145;
			this.flowLayoutPanel53.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel53.Controls.Add(this.txtPTUpagada);
			this.flowLayoutPanel53.Controls.Add(this.label41);
			this.flowLayoutPanel53.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel53.Location = new System.Drawing.Point(117, 306);
			this.flowLayoutPanel53.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel53.Name = "flowLayoutPanel53";
			this.flowLayoutPanel53.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel53.TabIndex = 145;
			this.txtPTUpagada.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPTUpagada.Location = new System.Drawing.Point(289, 2);
			this.txtPTUpagada.Margin = new System.Windows.Forms.Padding(2);
			this.txtPTUpagada.Name = "txtPTUpagada";
			this.txtPTUpagada.ReadOnly = true;
			this.txtPTUpagada.Size = new System.Drawing.Size(119, 21);
			this.txtPTUpagada.TabIndex = 0;
			this.txtPTUpagada.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPTUpagada.TextChanged += new System.EventHandler(txtPTUpagada_TextChanged);
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(111, 5);
			this.label41.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(174, 14);
			this.label41.TabIndex = 4;
			this.label41.Text = "(-) PTU PAGADA EN EL EJERCICIO:";
			this.flowLayoutPanel54.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel54.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel54.Location = new System.Drawing.Point(117, 330);
			this.flowLayoutPanel54.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel54.Name = "flowLayoutPanel54";
			this.flowLayoutPanel54.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel54.TabIndex = 145;
			this.flowLayoutPanel55.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel55.Controls.Add(this.txtBaseISR);
			this.flowLayoutPanel55.Controls.Add(this.label42);
			this.flowLayoutPanel55.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel55.Location = new System.Drawing.Point(117, 354);
			this.flowLayoutPanel55.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel55.Name = "flowLayoutPanel55";
			this.flowLayoutPanel55.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel55.TabIndex = 145;
			this.txtBaseISR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtBaseISR.Location = new System.Drawing.Point(289, 2);
			this.txtBaseISR.Margin = new System.Windows.Forms.Padding(2);
			this.txtBaseISR.Name = "txtBaseISR";
			this.txtBaseISR.ReadOnly = true;
			this.txtBaseISR.Size = new System.Drawing.Size(119, 21);
			this.txtBaseISR.TabIndex = 0;
			this.txtBaseISR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label42.AutoSize = true;
			this.label42.Location = new System.Drawing.Point(183, 5);
			this.label42.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(102, 14);
			this.label42.TabIndex = 6;
			this.label42.Text = "(=) BASE PARA ISR:";
			this.flowLayoutPanel56.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel56.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel56.Location = new System.Drawing.Point(117, 378);
			this.flowLayoutPanel56.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel56.Name = "flowLayoutPanel56";
			this.flowLayoutPanel56.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel56.TabIndex = 145;
			this.flowLayoutPanel28.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel28.Controls.Add(this.label43);
			this.flowLayoutPanel28.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel28.Location = new System.Drawing.Point(117, 402);
			this.flowLayoutPanel28.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel28.Name = "flowLayoutPanel28";
			this.flowLayoutPanel28.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel28.TabIndex = 144;
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(202, 5);
			this.label43.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(206, 14);
			this.label43.TabIndex = 0;
			this.label43.Text = "APLICACIÓN DE TARIFA SOBRE LA BASE";
			this.flowLayoutPanel58.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel58.Controls.Add(this.txtISRcausado);
			this.flowLayoutPanel58.Controls.Add(this.label44);
			this.flowLayoutPanel58.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel58.Location = new System.Drawing.Point(117, 426);
			this.flowLayoutPanel58.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel58.Name = "flowLayoutPanel58";
			this.flowLayoutPanel58.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel58.TabIndex = 146;
			this.txtISRcausado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRcausado.Location = new System.Drawing.Point(289, 2);
			this.txtISRcausado.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRcausado.Name = "txtISRcausado";
			this.txtISRcausado.ReadOnly = true;
			this.txtISRcausado.Size = new System.Drawing.Size(119, 21);
			this.txtISRcausado.TabIndex = 0;
			this.txtISRcausado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(204, 5);
			this.label44.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(81, 14);
			this.label44.TabIndex = 8;
			this.label44.Text = "ISR CAUSADO:";
			this.flowLayoutPanel59.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel59.Controls.Add(this.txtISRretenidoAcumulado);
			this.flowLayoutPanel59.Controls.Add(this.label45);
			this.flowLayoutPanel59.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel59.Location = new System.Drawing.Point(117, 450);
			this.flowLayoutPanel59.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel59.Name = "flowLayoutPanel59";
			this.flowLayoutPanel59.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel59.TabIndex = 146;
			this.txtISRretenidoAcumulado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRretenidoAcumulado.Location = new System.Drawing.Point(289, 2);
			this.txtISRretenidoAcumulado.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRretenidoAcumulado.Name = "txtISRretenidoAcumulado";
			this.txtISRretenidoAcumulado.ReadOnly = true;
			this.txtISRretenidoAcumulado.Size = new System.Drawing.Size(119, 21);
			this.txtISRretenidoAcumulado.TabIndex = 0;
			this.txtISRretenidoAcumulado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtISRretenidoAcumulado.TextChanged += new System.EventHandler(txtISRretenidoAcumulado_TextChanged);
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(119, 5);
			this.label45.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(166, 14);
			this.label45.TabIndex = 10;
			this.label45.Text = "(-) ISR RETENIDO ACUMULADO:";
			this.flowLayoutPanel60.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel60.Controls.Add(this.txtPagoProvisionalAnteriores);
			this.flowLayoutPanel60.Controls.Add(this.label46);
			this.flowLayoutPanel60.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel60.Location = new System.Drawing.Point(117, 474);
			this.flowLayoutPanel60.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel60.Name = "flowLayoutPanel60";
			this.flowLayoutPanel60.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel60.TabIndex = 146;
			this.txtPagoProvisionalAnteriores.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPagoProvisionalAnteriores.Location = new System.Drawing.Point(289, 2);
			this.txtPagoProvisionalAnteriores.Margin = new System.Windows.Forms.Padding(2);
			this.txtPagoProvisionalAnteriores.Name = "txtPagoProvisionalAnteriores";
			this.txtPagoProvisionalAnteriores.Size = new System.Drawing.Size(119, 21);
			this.txtPagoProvisionalAnteriores.TabIndex = 0;
			this.txtPagoProvisionalAnteriores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPagoProvisionalAnteriores.TextChanged += new System.EventHandler(txtPagoProvisionalAnteriores_TextChanged);
			this.txtPagoProvisionalAnteriores.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(74, 5);
			this.label46.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(211, 14);
			this.label46.TabIndex = 4;
			this.label46.Text = "(-) PAGOS PROVISIONALES ANTERIORES:";
			this.flowLayoutPanel61.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel61.Controls.Add(this.txtISRaCargo);
			this.flowLayoutPanel61.Controls.Add(this.label47);
			this.flowLayoutPanel61.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel61.Location = new System.Drawing.Point(117, 498);
			this.flowLayoutPanel61.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel61.Name = "flowLayoutPanel61";
			this.flowLayoutPanel61.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel61.TabIndex = 146;
			this.txtISRaCargo.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRaCargo.Location = new System.Drawing.Point(289, 2);
			this.txtISRaCargo.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRaCargo.Name = "txtISRaCargo";
			this.txtISRaCargo.ReadOnly = true;
			this.txtISRaCargo.Size = new System.Drawing.Size(119, 21);
			this.txtISRaCargo.TabIndex = 0;
			this.txtISRaCargo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(191, 5);
			this.label47.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(94, 14);
			this.label47.TabIndex = 12;
			this.label47.Text = "(=) ISR A CARGO:";
			this.flowLayoutPanel57.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel57.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel57.Location = new System.Drawing.Point(117, 522);
			this.flowLayoutPanel57.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel57.Name = "flowLayoutPanel57";
			this.flowLayoutPanel57.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel57.TabIndex = 145;
			this.flowLayoutPanel33.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel33.BackColor = System.Drawing.Color.Navy;
			this.flowLayoutPanel33.Controls.Add(this.label22);
			this.flowLayoutPanel33.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel33.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel33.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.flowLayoutPanel33.Location = new System.Drawing.Point(117, 546);
			this.flowLayoutPanel33.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel33.Name = "flowLayoutPanel33";
			this.flowLayoutPanel33.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel33.TabIndex = 152;
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(175, 5);
			this.label22.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(233, 14);
			this.label22.TabIndex = 0;
			this.label22.Text = "INTEGRACIÓN DE DEDUCCIONES PAGADAS";
			this.flowLayoutPanel34.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel34.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel34.Controls.Add(this.txtDeduccionesPueCP);
			this.flowLayoutPanel34.Controls.Add(this.label23);
			this.flowLayoutPanel34.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel34.Location = new System.Drawing.Point(117, 570);
			this.flowLayoutPanel34.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel34.Name = "flowLayoutPanel34";
			this.flowLayoutPanel34.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel34.TabIndex = 153;
			this.txtDeduccionesPueCP.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPueCP.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPueCP.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPueCP.Name = "txtDeduccionesPueCP";
			this.txtDeduccionesPueCP.ReadOnly = true;
			this.txtDeduccionesPueCP.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPueCP.TabIndex = 0;
			this.txtDeduccionesPueCP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPueCP.TextChanged += new System.EventHandler(txtDeduccionesPueCP_TextChanged);
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(28, 5);
			this.label23.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(257, 14);
			this.label23.TabIndex = 0;
			this.label23.Text = "DEDUCCIONES SEGÚN CFDI RECIBIDOS PUE/REP:";
			this.flowLayoutPanel14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel14.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel14.Controls.Add(this.txtDeduccionesNomina);
			this.flowLayoutPanel14.Controls.Add(this.label25);
			this.flowLayoutPanel14.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel14.Location = new System.Drawing.Point(117, 594);
			this.flowLayoutPanel14.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel14.Name = "flowLayoutPanel14";
			this.flowLayoutPanel14.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel14.TabIndex = 154;
			this.txtDeduccionesNomina.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesNomina.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesNomina.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesNomina.Name = "txtDeduccionesNomina";
			this.txtDeduccionesNomina.ReadOnly = true;
			this.txtDeduccionesNomina.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesNomina.TabIndex = 0;
			this.txtDeduccionesNomina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(51, 5);
			this.label25.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(234, 14);
			this.label25.TabIndex = 0;
			this.label25.Text = "(+) DEDUCCIONES DE NOMINA SEGÚN CFDI:";
			this.flowLayoutPanel41.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel41.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel41.Controls.Add(this.txtDeduccionesSinCFDI);
			this.flowLayoutPanel41.Controls.Add(this.label33);
			this.flowLayoutPanel41.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel41.Location = new System.Drawing.Point(117, 618);
			this.flowLayoutPanel41.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel41.Name = "flowLayoutPanel41";
			this.flowLayoutPanel41.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel41.TabIndex = 163;
			this.txtDeduccionesSinCFDI.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesSinCFDI.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesSinCFDI.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesSinCFDI.Name = "txtDeduccionesSinCFDI";
			this.txtDeduccionesSinCFDI.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesSinCFDI.TabIndex = 0;
			this.txtDeduccionesSinCFDI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesSinCFDI.TextChanged += new System.EventHandler(txtDeduccionesSinCFDI_TextChanged);
			this.txtDeduccionesSinCFDI.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(37, 5);
			this.label33.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(248, 14);
			this.label33.TabIndex = 0;
			this.label33.Text = "(+) DEDUCCIONES SIN CFDI (DEPRECIACIONES):";
			this.flowLayoutPanel43.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel43.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel43.Controls.Add(this.txtDeduccionesPorPago);
			this.flowLayoutPanel43.Controls.Add(this.label35);
			this.flowLayoutPanel43.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel43.Location = new System.Drawing.Point(117, 642);
			this.flowLayoutPanel43.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel43.Name = "flowLayoutPanel43";
			this.flowLayoutPanel43.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel43.TabIndex = 165;
			this.txtDeduccionesPorPago.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPorPago.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesPorPago.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPorPago.Name = "txtDeduccionesPorPago";
			this.txtDeduccionesPorPago.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPorPago.TabIndex = 0;
			this.txtDeduccionesPorPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPorPago.TextChanged += new System.EventHandler(txtDeduccionesSinCFDI_TextChanged);
			this.txtDeduccionesPorPago.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(31, 5);
			this.label35.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(254, 14);
			this.label35.TabIndex = 0;
			this.label35.Text = "(+) DEDUCCION POR PAGO DE IMSS/INFONAVIT:";
			this.flowLayoutPanel108.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel108.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel108.Controls.Add(this.txtOtrosGastosPagadosNoDeduciblesAE);
			this.flowLayoutPanel108.Controls.Add(this.label81);
			this.flowLayoutPanel108.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel108.Location = new System.Drawing.Point(117, 666);
			this.flowLayoutPanel108.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel108.Name = "flowLayoutPanel108";
			this.flowLayoutPanel108.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel108.TabIndex = 170;
			this.txtOtrosGastosPagadosNoDeduciblesAE.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosGastosPagadosNoDeduciblesAE.Location = new System.Drawing.Point(289, 2);
			this.txtOtrosGastosPagadosNoDeduciblesAE.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosGastosPagadosNoDeduciblesAE.Name = "txtOtrosGastosPagadosNoDeduciblesAE";
			this.txtOtrosGastosPagadosNoDeduciblesAE.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosGastosPagadosNoDeduciblesAE.TabIndex = 0;
			this.txtOtrosGastosPagadosNoDeduciblesAE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosGastosPagadosNoDeduciblesAE.TextChanged += new System.EventHandler(txtDeduccionesSinCFDI_TextChanged);
			this.txtOtrosGastosPagadosNoDeduciblesAE.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label81.AutoSize = true;
			this.label81.Location = new System.Drawing.Point(41, 5);
			this.label81.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(244, 14);
			this.label81.TabIndex = 0;
			this.label81.Text = "(-) OTROS GASTOS PAGADOS NO DEDUCIBLES:";
			this.flowLayoutPanel44.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel44.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel44.Controls.Add(this.txtDeduccionesPagadasGuardado);
			this.flowLayoutPanel44.Controls.Add(this.txtDeduccionesPagadas);
			this.flowLayoutPanel44.Controls.Add(this.label36);
			this.flowLayoutPanel44.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel44.Location = new System.Drawing.Point(117, 690);
			this.flowLayoutPanel44.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel44.Name = "flowLayoutPanel44";
			this.flowLayoutPanel44.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel44.TabIndex = 166;
			this.txtDeduccionesPagadasGuardado.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasGuardado.Location = new System.Drawing.Point(336, 2);
			this.txtDeduccionesPagadasGuardado.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasGuardado.Name = "txtDeduccionesPagadasGuardado";
			this.txtDeduccionesPagadasGuardado.ReadOnly = true;
			this.txtDeduccionesPagadasGuardado.Size = new System.Drawing.Size(72, 21);
			this.txtDeduccionesPagadasGuardado.TabIndex = 2;
			this.txtDeduccionesPagadasGuardado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPagadas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadas.Location = new System.Drawing.Point(260, 2);
			this.txtDeduccionesPagadas.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadas.Name = "txtDeduccionesPagadas";
			this.txtDeduccionesPagadas.ReadOnly = true;
			this.txtDeduccionesPagadas.Size = new System.Drawing.Size(72, 21);
			this.txtDeduccionesPagadas.TabIndex = 1;
			this.txtDeduccionesPagadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(45, 5);
			this.label36.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(211, 14);
			this.label36.TabIndex = 0;
			this.label36.Text = "(=) DEDUCCIONES PAGADAS EN EL MES:";
			this.flowLayoutPanel22.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel22.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel22.Location = new System.Drawing.Point(117, 714);
			this.flowLayoutPanel22.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel22.Name = "flowLayoutPanel22";
			this.flowLayoutPanel22.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel22.TabIndex = 155;
			this.flowLayoutPanel26.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel26.BackColor = System.Drawing.Color.Navy;
			this.flowLayoutPanel26.Controls.Add(this.label26);
			this.flowLayoutPanel26.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel26.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel26.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.flowLayoutPanel26.Location = new System.Drawing.Point(117, 738);
			this.flowLayoutPanel26.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel26.Name = "flowLayoutPanel26";
			this.flowLayoutPanel26.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel26.TabIndex = 156;
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(180, 5);
			this.label26.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(228, 14);
			this.label26.TabIndex = 0;
			this.label26.Text = "INTEGRACIÓN DE DEDUCCIONES NOMINA";
			this.flowLayoutPanel40.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel40.Controls.Add(this.rdoEnBaseFechaDevengada);
			this.flowLayoutPanel40.Controls.Add(this.rdoEnBaseFechaPago);
			this.flowLayoutPanel40.Controls.Add(this.rdoEnBaseFechaFactura);
			this.flowLayoutPanel40.Controls.Add(this.label32);
			this.flowLayoutPanel40.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel40.Location = new System.Drawing.Point(117, 762);
			this.flowLayoutPanel40.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel40.Name = "flowLayoutPanel40";
			this.flowLayoutPanel40.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel40.TabIndex = 162;
			this.rdoEnBaseFechaDevengada.AutoSize = true;
			this.rdoEnBaseFechaDevengada.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaDevengada.Location = new System.Drawing.Point(291, 3);
			this.rdoEnBaseFechaDevengada.Name = "rdoEnBaseFechaDevengada";
			this.rdoEnBaseFechaDevengada.Size = new System.Drawing.Size(116, 17);
			this.rdoEnBaseFechaDevengada.TabIndex = 154;
			this.rdoEnBaseFechaDevengada.Tag = "3";
			this.rdoEnBaseFechaDevengada.Text = "Fecha Devengada";
			this.rdoEnBaseFechaDevengada.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaDevengada.CheckedChanged += new System.EventHandler(rdoEnBaseFechaFactura_CheckedChanged);
			this.rdoEnBaseFechaPago.AutoSize = true;
			this.rdoEnBaseFechaPago.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaPago.Location = new System.Drawing.Point(201, 3);
			this.rdoEnBaseFechaPago.Name = "rdoEnBaseFechaPago";
			this.rdoEnBaseFechaPago.Size = new System.Drawing.Size(84, 17);
			this.rdoEnBaseFechaPago.TabIndex = 152;
			this.rdoEnBaseFechaPago.Tag = "2";
			this.rdoEnBaseFechaPago.Text = "Fecha Pago";
			this.rdoEnBaseFechaPago.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaPago.CheckedChanged += new System.EventHandler(rdoEnBaseFechaFactura_CheckedChanged);
			this.rdoEnBaseFechaFactura.AutoSize = true;
			this.rdoEnBaseFechaFactura.Checked = true;
			this.rdoEnBaseFechaFactura.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaFactura.Location = new System.Drawing.Point(99, 3);
			this.rdoEnBaseFechaFactura.Name = "rdoEnBaseFechaFactura";
			this.rdoEnBaseFechaFactura.Size = new System.Drawing.Size(96, 17);
			this.rdoEnBaseFechaFactura.TabIndex = 155;
			this.rdoEnBaseFechaFactura.TabStop = true;
			this.rdoEnBaseFechaFactura.Tag = "1";
			this.rdoEnBaseFechaFactura.Text = "Fecha Factura";
			this.rdoEnBaseFechaFactura.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaFactura.CheckedChanged += new System.EventHandler(rdoEnBaseFechaFactura_CheckedChanged);
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(35, 5);
			this.label32.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(59, 14);
			this.label32.TabIndex = 153;
			this.label32.Text = "En base a:";
			this.flowLayoutPanel35.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel35.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel35.Controls.Add(this.txtTotalPercepcionesExentas);
			this.flowLayoutPanel35.Controls.Add(this.label27);
			this.flowLayoutPanel35.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel35.Location = new System.Drawing.Point(117, 786);
			this.flowLayoutPanel35.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel35.Name = "flowLayoutPanel35";
			this.flowLayoutPanel35.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel35.TabIndex = 157;
			this.txtTotalPercepcionesExentas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesExentas.Location = new System.Drawing.Point(289, 2);
			this.txtTotalPercepcionesExentas.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesExentas.Name = "txtTotalPercepcionesExentas";
			this.txtTotalPercepcionesExentas.ReadOnly = true;
			this.txtTotalPercepcionesExentas.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesExentas.TabIndex = 1;
			this.txtTotalPercepcionesExentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTotalPercepcionesExentas.TextChanged += new System.EventHandler(txtTotalPercepcionesExentas_TextChanged);
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(61, 5);
			this.label27.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(224, 14);
			this.label27.TabIndex = 0;
			this.label27.Text = "TOTAL PERCEPCIONES EXENTAS EN EL MES:";
			this.flowLayoutPanel37.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel37.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel37.Controls.Add(this.cmbPorcentajeDeducible);
			this.flowLayoutPanel37.Controls.Add(this.label29);
			this.flowLayoutPanel37.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel37.Location = new System.Drawing.Point(117, 810);
			this.flowLayoutPanel37.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel37.Name = "flowLayoutPanel37";
			this.flowLayoutPanel37.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel37.TabIndex = 159;
			this.cmbPorcentajeDeducible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPorcentajeDeducible.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbPorcentajeDeducible.FormattingEnabled = true;
			this.cmbPorcentajeDeducible.Items.AddRange(new object[3] { "47%", "53%", "100%" });
			this.cmbPorcentajeDeducible.Location = new System.Drawing.Point(293, 2);
			this.cmbPorcentajeDeducible.Margin = new System.Windows.Forms.Padding(2);
			this.cmbPorcentajeDeducible.Name = "cmbPorcentajeDeducible";
			this.cmbPorcentajeDeducible.Size = new System.Drawing.Size(115, 22);
			this.cmbPorcentajeDeducible.TabIndex = 1;
			this.cmbPorcentajeDeducible.SelectedIndexChanged += new System.EventHandler(cmbPorcentajeDeducible_SelectedIndexChanged);
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(101, 31);
			this.label29.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(307, 14);
			this.label29.TabIndex = 0;
			this.label29.Text = "(X) PORCENTAJE DEDUCIBLE PARA PERCEPCIONES EXENTOS";
			this.flowLayoutPanel38.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel38.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel38.Controls.Add(this.txtPercepcionesExentas);
			this.flowLayoutPanel38.Controls.Add(this.label30);
			this.flowLayoutPanel38.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel38.Location = new System.Drawing.Point(117, 834);
			this.flowLayoutPanel38.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel38.Name = "flowLayoutPanel38";
			this.flowLayoutPanel38.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel38.TabIndex = 160;
			this.txtPercepcionesExentas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPercepcionesExentas.Location = new System.Drawing.Point(289, 2);
			this.txtPercepcionesExentas.Margin = new System.Windows.Forms.Padding(2);
			this.txtPercepcionesExentas.Name = "txtPercepcionesExentas";
			this.txtPercepcionesExentas.ReadOnly = true;
			this.txtPercepcionesExentas.Size = new System.Drawing.Size(119, 21);
			this.txtPercepcionesExentas.TabIndex = 1;
			this.txtPercepcionesExentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPercepcionesExentas.TextChanged += new System.EventHandler(txtPercepcionesExentas_TextChanged);
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(67, 5);
			this.label30.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(218, 14);
			this.label30.TabIndex = 0;
			this.label30.Text = "(=) PERCEPCIONES EXENTAS DEDUCIBLES:";
			this.flowLayoutPanel36.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel36.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel36.Controls.Add(this.txtTotalPercepcionesGravadas);
			this.flowLayoutPanel36.Controls.Add(this.label28);
			this.flowLayoutPanel36.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel36.Location = new System.Drawing.Point(117, 858);
			this.flowLayoutPanel36.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel36.Name = "flowLayoutPanel36";
			this.flowLayoutPanel36.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel36.TabIndex = 158;
			this.txtTotalPercepcionesGravadas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesGravadas.Location = new System.Drawing.Point(289, 2);
			this.txtTotalPercepcionesGravadas.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesGravadas.Name = "txtTotalPercepcionesGravadas";
			this.txtTotalPercepcionesGravadas.ReadOnly = true;
			this.txtTotalPercepcionesGravadas.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesGravadas.TabIndex = 1;
			this.txtTotalPercepcionesGravadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTotalPercepcionesGravadas.TextChanged += new System.EventHandler(txtTotalPercepcionesGravadas_TextChanged);
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(31, 5);
			this.label28.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(254, 14);
			this.label28.TabIndex = 0;
			this.label28.Text = "(+) TOTAL PERCEPCIONES GRAVADAS EN EL MES:";
			this.flowLayoutPanel42.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel42.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel42.Controls.Add(this.txtDeduccionesNominaN);
			this.flowLayoutPanel42.Controls.Add(this.label34);
			this.flowLayoutPanel42.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel42.Location = new System.Drawing.Point(117, 882);
			this.flowLayoutPanel42.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel42.Name = "flowLayoutPanel42";
			this.flowLayoutPanel42.Size = new System.Drawing.Size(410, 20);
			this.flowLayoutPanel42.TabIndex = 164;
			this.txtDeduccionesNominaN.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesNominaN.Location = new System.Drawing.Point(289, 2);
			this.txtDeduccionesNominaN.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesNominaN.Name = "txtDeduccionesNominaN";
			this.txtDeduccionesNominaN.ReadOnly = true;
			this.txtDeduccionesNominaN.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesNominaN.TabIndex = 1;
			this.txtDeduccionesNominaN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesNominaN.TextChanged += new System.EventHandler(txtDeduccionesNominaN_TextChanged);
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(51, 5);
			this.label34.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(234, 14);
			this.label34.TabIndex = 0;
			this.label34.Text = "(=) DEDUCCIONES DE NOMINA SEGÚN CFDI:";
			this.flowLayoutPanel39.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel39.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel39.Controls.Add(this.txtTotalPercepcionesExentasGravadas);
			this.flowLayoutPanel39.Controls.Add(this.label31);
			this.flowLayoutPanel39.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel39.Location = new System.Drawing.Point(35, 906);
			this.flowLayoutPanel39.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel39.Name = "flowLayoutPanel39";
			this.flowLayoutPanel39.Size = new System.Drawing.Size(492, 20);
			this.flowLayoutPanel39.TabIndex = 161;
			this.txtTotalPercepcionesExentasGravadas.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesExentasGravadas.Location = new System.Drawing.Point(371, 2);
			this.txtTotalPercepcionesExentasGravadas.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesExentasGravadas.Name = "txtTotalPercepcionesExentasGravadas";
			this.txtTotalPercepcionesExentasGravadas.ReadOnly = true;
			this.txtTotalPercepcionesExentasGravadas.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesExentasGravadas.TabIndex = 1;
			this.txtTotalPercepcionesExentasGravadas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtTotalPercepcionesExentasGravadas.TextChanged += new System.EventHandler(txtTotalPercepcionesExentasGravadas_TextChanged);
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(72, 5);
			this.label31.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(295, 14);
			this.label31.TabIndex = 0;
			this.label31.Text = "TOTAL PERCEPCIONES EXENTAS + GRAVADAS EN EL MES:";
			this.tpRIF.Controls.Add(this.flowLayoutPanel109);
			this.tpRIF.Controls.Add(this.flowLayoutPanel110);
			this.tpRIF.Location = new System.Drawing.Point(4, 23);
			this.tpRIF.Margin = new System.Windows.Forms.Padding(2);
			this.tpRIF.Name = "tpRIF";
			this.tpRIF.Padding = new System.Windows.Forms.Padding(2);
			this.tpRIF.Size = new System.Drawing.Size(658, 371);
			this.tpRIF.TabIndex = 3;
			this.tpRIF.Text = "RIF";
			this.tpRIF.UseVisualStyleBackColor = true;
			this.flowLayoutPanel109.Controls.Add(this.btnGuardaDeduccionesRIF);
			this.flowLayoutPanel109.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel109.Location = new System.Drawing.Point(582, 1);
			this.flowLayoutPanel109.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel109.Name = "flowLayoutPanel109";
			this.flowLayoutPanel109.Size = new System.Drawing.Size(77, 278);
			this.flowLayoutPanel109.TabIndex = 143;
			this.btnGuardaDeduccionesRIF.BackColor = System.Drawing.Color.White;
			this.btnGuardaDeduccionesRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnGuardaDeduccionesRIF.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnGuardaDeduccionesRIF.Location = new System.Drawing.Point(2, 2);
			this.btnGuardaDeduccionesRIF.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuardaDeduccionesRIF.Name = "btnGuardaDeduccionesRIF";
			this.btnGuardaDeduccionesRIF.Size = new System.Drawing.Size(75, 63);
			this.btnGuardaDeduccionesRIF.TabIndex = 0;
			this.btnGuardaDeduccionesRIF.Text = "GUARDAR CÁLCULO";
			this.btnGuardaDeduccionesRIF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardaDeduccionesRIF.UseVisualStyleBackColor = false;
			this.btnGuardaDeduccionesRIF.Click += new System.EventHandler(btnGuardaDeduccionesRIF_Click);
			this.flowLayoutPanel110.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel110.AutoScroll = true;
			this.flowLayoutPanel110.Controls.Add(this.lbTituloISRrif);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel111);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel113);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel114);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel115);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel116);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel117);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel123);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel120);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel119);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel121);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel124);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel125);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel126);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel127);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel128);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel112);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel118);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel131);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel129);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel122);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel132);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel133);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel134);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel135);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel136);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel137);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel138);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel139);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel140);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel141);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel142);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel143);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel144);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel145);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel146);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel147);
			this.flowLayoutPanel110.Controls.Add(this.flowLayoutPanel148);
			this.flowLayoutPanel110.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel110.Location = new System.Drawing.Point(2, 4);
			this.flowLayoutPanel110.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel110.Name = "flowLayoutPanel110";
			this.flowLayoutPanel110.Size = new System.Drawing.Size(578, 364);
			this.flowLayoutPanel110.TabIndex = 0;
			this.flowLayoutPanel110.WrapContents = false;
			this.lbTituloISRrif.AutoSize = true;
			this.lbTituloISRrif.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbTituloISRrif.Location = new System.Drawing.Point(2, 0);
			this.lbTituloISRrif.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTituloISRrif.Name = "lbTituloISRrif";
			this.lbTituloISRrif.Size = new System.Drawing.Size(316, 16);
			this.lbTituloISRrif.TabIndex = 151;
			this.lbTituloISRrif.Text = "CÁLCULO DE ISR RÉGIMEN DE INCORPORACIÓN FISCAL";
			this.flowLayoutPanel111.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel111.Controls.Add(this.txtIngresosCobradosRIF);
			this.flowLayoutPanel111.Controls.Add(this.label83);
			this.flowLayoutPanel111.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel111.Location = new System.Drawing.Point(46, 18);
			this.flowLayoutPanel111.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel111.Name = "flowLayoutPanel111";
			this.flowLayoutPanel111.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel111.TabIndex = 0;
			this.txtIngresosCobradosRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosRIF.Location = new System.Drawing.Point(327, 2);
			this.txtIngresosCobradosRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosRIF.Name = "txtIngresosCobradosRIF";
			this.txtIngresosCobradosRIF.ReadOnly = true;
			this.txtIngresosCobradosRIF.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosRIF.TabIndex = 0;
			this.txtIngresosCobradosRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label83.AutoSize = true;
			this.label83.Location = new System.Drawing.Point(121, 5);
			this.label83.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(202, 14);
			this.label83.TabIndex = 0;
			this.label83.Text = "INGRESOS COBRADOS DEL PERIODO :";
			this.flowLayoutPanel113.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel113.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel113.Controls.Add(this.txtOtrosIngresosAcumulablesRIF);
			this.flowLayoutPanel113.Controls.Add(this.label85);
			this.flowLayoutPanel113.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel113.Location = new System.Drawing.Point(46, 42);
			this.flowLayoutPanel113.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel113.Name = "flowLayoutPanel113";
			this.flowLayoutPanel113.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel113.TabIndex = 141;
			this.txtOtrosIngresosAcumulablesRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosIngresosAcumulablesRIF.Location = new System.Drawing.Point(327, 2);
			this.txtOtrosIngresosAcumulablesRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosIngresosAcumulablesRIF.Name = "txtOtrosIngresosAcumulablesRIF";
			this.txtOtrosIngresosAcumulablesRIF.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosIngresosAcumulablesRIF.TabIndex = 0;
			this.txtOtrosIngresosAcumulablesRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosIngresosAcumulablesRIF.TextChanged += new System.EventHandler(txtOtrosIngresosAcumulablesRIF_TextChanged);
			this.txtOtrosIngresosAcumulablesRIF.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label85.AutoSize = true;
			this.label85.Location = new System.Drawing.Point(125, 5);
			this.label85.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(198, 14);
			this.label85.TabIndex = 0;
			this.label85.Text = "(+) OTROS INGRESOS ACUMULABLES:";
			this.flowLayoutPanel114.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel114.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel114.Controls.Add(this.txtIngresosCobradosNoAcumulablesRIF);
			this.flowLayoutPanel114.Controls.Add(this.label86);
			this.flowLayoutPanel114.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel114.Location = new System.Drawing.Point(46, 66);
			this.flowLayoutPanel114.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel114.Name = "flowLayoutPanel114";
			this.flowLayoutPanel114.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel114.TabIndex = 143;
			this.txtIngresosCobradosNoAcumulablesRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosNoAcumulablesRIF.Location = new System.Drawing.Point(327, 2);
			this.txtIngresosCobradosNoAcumulablesRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosNoAcumulablesRIF.Name = "txtIngresosCobradosNoAcumulablesRIF";
			this.txtIngresosCobradosNoAcumulablesRIF.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosNoAcumulablesRIF.TabIndex = 0;
			this.txtIngresosCobradosNoAcumulablesRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosNoAcumulablesRIF.TextChanged += new System.EventHandler(txtOtrosIngresosAcumulablesRIF_TextChanged);
			this.txtIngresosCobradosNoAcumulablesRIF.Leave += new System.EventHandler(txtDeduccionesSinCFDI_Leave);
			this.label86.AutoSize = true;
			this.label86.Location = new System.Drawing.Point(85, 5);
			this.label86.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(238, 14);
			this.label86.TabIndex = 0;
			this.label86.Text = "(-) INGRESOS COBRADOS NO ACUMULABLES:";
			this.flowLayoutPanel115.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel115.Controls.Add(this.txtIngresosCobradosAcumuladosGuardadoRIF);
			this.flowLayoutPanel115.Controls.Add(this.txtIngresosCobradosAcumuladosRIF);
			this.flowLayoutPanel115.Controls.Add(this.label87);
			this.flowLayoutPanel115.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel115.Location = new System.Drawing.Point(46, 90);
			this.flowLayoutPanel115.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel115.Name = "flowLayoutPanel115";
			this.flowLayoutPanel115.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel115.TabIndex = 1;
			this.txtIngresosCobradosAcumuladosGuardadoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosGuardadoRIF.Location = new System.Drawing.Point(359, 2);
			this.txtIngresosCobradosAcumuladosGuardadoRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosGuardadoRIF.Name = "txtIngresosCobradosAcumuladosGuardadoRIF";
			this.txtIngresosCobradosAcumuladosGuardadoRIF.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosGuardadoRIF.Size = new System.Drawing.Size(87, 21);
			this.txtIngresosCobradosAcumuladosGuardadoRIF.TabIndex = 0;
			this.txtIngresosCobradosAcumuladosGuardadoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosAcumuladosRIF.BackColor = System.Drawing.Color.Silver;
			this.txtIngresosCobradosAcumuladosRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosRIF.Location = new System.Drawing.Point(277, 2);
			this.txtIngresosCobradosAcumuladosRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosRIF.Name = "txtIngresosCobradosAcumuladosRIF";
			this.txtIngresosCobradosAcumuladosRIF.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosRIF.Size = new System.Drawing.Size(78, 21);
			this.txtIngresosCobradosAcumuladosRIF.TabIndex = 2;
			this.txtIngresosCobradosAcumuladosRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label87.AutoSize = true;
			this.label87.Location = new System.Drawing.Point(52, 5);
			this.label87.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(221, 14);
			this.label87.TabIndex = 3;
			this.label87.Text = "(=) INGRESOS COBRADOS ACUMULADOS:";
			this.flowLayoutPanel116.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel116.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel116.Location = new System.Drawing.Point(46, 114);
			this.flowLayoutPanel116.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel116.Name = "flowLayoutPanel116";
			this.flowLayoutPanel116.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel116.TabIndex = 145;
			this.flowLayoutPanel117.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel117.Controls.Add(this.txtDeduccionesPagadasDelMesRIF);
			this.flowLayoutPanel117.Controls.Add(this.label88);
			this.flowLayoutPanel117.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel117.Location = new System.Drawing.Point(46, 138);
			this.flowLayoutPanel117.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel117.Name = "flowLayoutPanel117";
			this.flowLayoutPanel117.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel117.TabIndex = 154;
			this.txtDeduccionesPagadasDelMesRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasDelMesRIF.Location = new System.Drawing.Point(327, 2);
			this.txtDeduccionesPagadasDelMesRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasDelMesRIF.Name = "txtDeduccionesPagadasDelMesRIF";
			this.txtDeduccionesPagadasDelMesRIF.ReadOnly = true;
			this.txtDeduccionesPagadasDelMesRIF.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPagadasDelMesRIF.TabIndex = 0;
			this.txtDeduccionesPagadasDelMesRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label88.AutoSize = true;
			this.label88.Location = new System.Drawing.Point(112, 5);
			this.label88.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(211, 14);
			this.label88.TabIndex = 0;
			this.label88.Text = "DEDUCCIONES PAGADAS DEL PERIODO:";
			this.flowLayoutPanel123.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel123.Controls.Add(this.txtPTUpagadaRIF);
			this.flowLayoutPanel123.Controls.Add(this.label92);
			this.flowLayoutPanel123.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel123.Location = new System.Drawing.Point(46, 163);
			this.flowLayoutPanel123.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel123.Name = "flowLayoutPanel123";
			this.flowLayoutPanel123.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel123.TabIndex = 145;
			this.txtPTUpagadaRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPTUpagadaRIF.Location = new System.Drawing.Point(327, 2);
			this.txtPTUpagadaRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtPTUpagadaRIF.Name = "txtPTUpagadaRIF";
			this.txtPTUpagadaRIF.ReadOnly = true;
			this.txtPTUpagadaRIF.Size = new System.Drawing.Size(119, 21);
			this.txtPTUpagadaRIF.TabIndex = 0;
			this.txtPTUpagadaRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label92.AutoSize = true;
			this.label92.Location = new System.Drawing.Point(162, 5);
			this.label92.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label92.Name = "label92";
			this.label92.Size = new System.Drawing.Size(161, 14);
			this.label92.TabIndex = 4;
			this.label92.Text = "PTU PAGADA EN EL EJERCICIO:";
			this.flowLayoutPanel120.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel120.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel120.Location = new System.Drawing.Point(46, 188);
			this.flowLayoutPanel120.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel120.Name = "flowLayoutPanel120";
			this.flowLayoutPanel120.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel120.TabIndex = 145;
			this.flowLayoutPanel119.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel119.Controls.Add(this.txtGastosMayoresAingresos);
			this.flowLayoutPanel119.Controls.Add(this.label90);
			this.flowLayoutPanel119.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel119.Location = new System.Drawing.Point(46, 213);
			this.flowLayoutPanel119.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel119.Name = "flowLayoutPanel119";
			this.flowLayoutPanel119.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel119.TabIndex = 168;
			this.txtGastosMayoresAingresos.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtGastosMayoresAingresos.Location = new System.Drawing.Point(327, 2);
			this.txtGastosMayoresAingresos.Margin = new System.Windows.Forms.Padding(2);
			this.txtGastosMayoresAingresos.Name = "txtGastosMayoresAingresos";
			this.txtGastosMayoresAingresos.ReadOnly = true;
			this.txtGastosMayoresAingresos.Size = new System.Drawing.Size(119, 21);
			this.txtGastosMayoresAingresos.TabIndex = 0;
			this.txtGastosMayoresAingresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label90.AutoSize = true;
			this.label90.Location = new System.Drawing.Point(80, 5);
			this.label90.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(243, 14);
			this.label90.TabIndex = 2;
			this.label90.Text = "GASTOS MAYORES A INGRESOS DEL PERIODO:";
			this.flowLayoutPanel121.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel121.Controls.Add(this.txtGastosMayoresAIngresosPeriodosAnteriores);
			this.flowLayoutPanel121.Controls.Add(this.label84);
			this.flowLayoutPanel121.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel121.Location = new System.Drawing.Point(46, 238);
			this.flowLayoutPanel121.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel121.Name = "flowLayoutPanel121";
			this.flowLayoutPanel121.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel121.TabIndex = 145;
			this.txtGastosMayoresAIngresosPeriodosAnteriores.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtGastosMayoresAIngresosPeriodosAnteriores.Location = new System.Drawing.Point(327, 2);
			this.txtGastosMayoresAIngresosPeriodosAnteriores.Margin = new System.Windows.Forms.Padding(2);
			this.txtGastosMayoresAIngresosPeriodosAnteriores.Name = "txtGastosMayoresAIngresosPeriodosAnteriores";
			this.txtGastosMayoresAIngresosPeriodosAnteriores.Size = new System.Drawing.Size(119, 21);
			this.txtGastosMayoresAIngresosPeriodosAnteriores.TabIndex = 0;
			this.txtGastosMayoresAIngresosPeriodosAnteriores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtGastosMayoresAIngresosPeriodosAnteriores.TextChanged += new System.EventHandler(txtGastosMayoresAIngresosPeriodosAnteriores_TextChanged);
			this.txtGastosMayoresAIngresosPeriodosAnteriores.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label84.AutoSize = true;
			this.label84.Location = new System.Drawing.Point(12, 5);
			this.label84.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(311, 14);
			this.label84.TabIndex = 4;
			this.label84.Text = "GASTOS MAYORES A INGRESOS DE PERIODOS ANTERIORES:";
			this.flowLayoutPanel124.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel124.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel124.Location = new System.Drawing.Point(46, 263);
			this.flowLayoutPanel124.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel124.Name = "flowLayoutPanel124";
			this.flowLayoutPanel124.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel124.TabIndex = 145;
			this.flowLayoutPanel125.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel125.Controls.Add(this.txtUtilidad);
			this.flowLayoutPanel125.Controls.Add(this.label93);
			this.flowLayoutPanel125.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel125.Location = new System.Drawing.Point(46, 287);
			this.flowLayoutPanel125.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel125.Name = "flowLayoutPanel125";
			this.flowLayoutPanel125.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel125.TabIndex = 145;
			this.txtUtilidad.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtUtilidad.Location = new System.Drawing.Point(327, 2);
			this.txtUtilidad.Margin = new System.Windows.Forms.Padding(2);
			this.txtUtilidad.Name = "txtUtilidad";
			this.txtUtilidad.ReadOnly = true;
			this.txtUtilidad.Size = new System.Drawing.Size(119, 21);
			this.txtUtilidad.TabIndex = 0;
			this.txtUtilidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label93.AutoSize = true;
			this.label93.Location = new System.Drawing.Point(249, 5);
			this.label93.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label93.Name = "label93";
			this.label93.Size = new System.Drawing.Size(74, 14);
			this.label93.TabIndex = 6;
			this.label93.Text = "(=) UTILIDAD:";
			this.flowLayoutPanel126.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel126.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel126.Location = new System.Drawing.Point(46, 312);
			this.flowLayoutPanel126.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel126.Name = "flowLayoutPanel126";
			this.flowLayoutPanel126.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel126.TabIndex = 145;
			this.flowLayoutPanel127.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel127.Controls.Add(this.label94);
			this.flowLayoutPanel127.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel127.Location = new System.Drawing.Point(46, 336);
			this.flowLayoutPanel127.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel127.Name = "flowLayoutPanel127";
			this.flowLayoutPanel127.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel127.TabIndex = 144;
			this.label94.AutoSize = true;
			this.label94.Location = new System.Drawing.Point(240, 5);
			this.label94.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label94.Name = "label94";
			this.label94.Size = new System.Drawing.Size(206, 14);
			this.label94.TabIndex = 0;
			this.label94.Text = "APLICACIÓN DE TARIFA SOBRE LA BASE";
			this.flowLayoutPanel128.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel128.Controls.Add(this.txtISRcausadoRIF);
			this.flowLayoutPanel128.Controls.Add(this.label95);
			this.flowLayoutPanel128.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel128.Location = new System.Drawing.Point(46, 360);
			this.flowLayoutPanel128.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel128.Name = "flowLayoutPanel128";
			this.flowLayoutPanel128.Size = new System.Drawing.Size(448, 21);
			this.flowLayoutPanel128.TabIndex = 146;
			this.txtISRcausadoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRcausadoRIF.Location = new System.Drawing.Point(327, 2);
			this.txtISRcausadoRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRcausadoRIF.Name = "txtISRcausadoRIF";
			this.txtISRcausadoRIF.ReadOnly = true;
			this.txtISRcausadoRIF.Size = new System.Drawing.Size(119, 21);
			this.txtISRcausadoRIF.TabIndex = 0;
			this.txtISRcausadoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label95.AutoSize = true;
			this.label95.Location = new System.Drawing.Point(242, 5);
			this.label95.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label95.Name = "label95";
			this.label95.Size = new System.Drawing.Size(81, 14);
			this.label95.TabIndex = 8;
			this.label95.Text = "ISR CAUSADO:";
			this.flowLayoutPanel112.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel112.Controls.Add(this.cmbPorcentajeReduccionRIF);
			this.flowLayoutPanel112.Controls.Add(this.label89);
			this.flowLayoutPanel112.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel112.Location = new System.Drawing.Point(46, 385);
			this.flowLayoutPanel112.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel112.Name = "flowLayoutPanel112";
			this.flowLayoutPanel112.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel112.TabIndex = 146;
			this.cmbPorcentajeReduccionRIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPorcentajeReduccionRIF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbPorcentajeReduccionRIF.FormattingEnabled = true;
			this.cmbPorcentajeReduccionRIF.Items.AddRange(new object[11]
			{
				"100%", "90%", "80%", "70%", "60%", "50%", "40%", "30%", "20%", "10%",
				"-SIN REDUCCIÓN-"
			});
			this.cmbPorcentajeReduccionRIF.Location = new System.Drawing.Point(358, 2);
			this.cmbPorcentajeReduccionRIF.Margin = new System.Windows.Forms.Padding(2);
			this.cmbPorcentajeReduccionRIF.Name = "cmbPorcentajeReduccionRIF";
			this.cmbPorcentajeReduccionRIF.Size = new System.Drawing.Size(88, 22);
			this.cmbPorcentajeReduccionRIF.TabIndex = 0;
			this.cmbPorcentajeReduccionRIF.SelectedIndexChanged += new System.EventHandler(cmbPorcentajeReduccionRIF_SelectedIndexChanged);
			this.label89.AutoSize = true;
			this.label89.Location = new System.Drawing.Point(181, 5);
			this.label89.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(173, 14);
			this.label89.TabIndex = 5;
			this.label89.Text = "(X) PORCENTAJE DE REDUCCION:";
			this.flowLayoutPanel118.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel118.Controls.Add(this.txtIsrReducido);
			this.flowLayoutPanel118.Controls.Add(this.label91);
			this.flowLayoutPanel118.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel118.Location = new System.Drawing.Point(46, 409);
			this.flowLayoutPanel118.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel118.Name = "flowLayoutPanel118";
			this.flowLayoutPanel118.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel118.TabIndex = 147;
			this.txtIsrReducido.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIsrReducido.Location = new System.Drawing.Point(327, 2);
			this.txtIsrReducido.Margin = new System.Windows.Forms.Padding(2);
			this.txtIsrReducido.Name = "txtIsrReducido";
			this.txtIsrReducido.ReadOnly = true;
			this.txtIsrReducido.Size = new System.Drawing.Size(119, 21);
			this.txtIsrReducido.TabIndex = 0;
			this.txtIsrReducido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(238, 5);
			this.label91.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(85, 14);
			this.label91.TabIndex = 12;
			this.label91.Text = "ISR REDUCIDO:";
			this.flowLayoutPanel131.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel131.Controls.Add(this.txtISRaCargoRIF);
			this.flowLayoutPanel131.Controls.Add(this.label98);
			this.flowLayoutPanel131.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel131.Location = new System.Drawing.Point(46, 433);
			this.flowLayoutPanel131.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel131.Name = "flowLayoutPanel131";
			this.flowLayoutPanel131.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel131.TabIndex = 146;
			this.txtISRaCargoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRaCargoRIF.Location = new System.Drawing.Point(327, 2);
			this.txtISRaCargoRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRaCargoRIF.Name = "txtISRaCargoRIF";
			this.txtISRaCargoRIF.ReadOnly = true;
			this.txtISRaCargoRIF.Size = new System.Drawing.Size(119, 21);
			this.txtISRaCargoRIF.TabIndex = 0;
			this.txtISRaCargoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label98.AutoSize = true;
			this.label98.Location = new System.Drawing.Point(246, 5);
			this.label98.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label98.Name = "label98";
			this.label98.Size = new System.Drawing.Size(77, 14);
			this.label98.TabIndex = 12;
			this.label98.Text = "ISR A CARGO:";
			this.flowLayoutPanel129.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel129.Controls.Add(this.txtISRretenidoAcumuladoRIF);
			this.flowLayoutPanel129.Controls.Add(this.label96);
			this.flowLayoutPanel129.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel129.Location = new System.Drawing.Point(46, 457);
			this.flowLayoutPanel129.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel129.Name = "flowLayoutPanel129";
			this.flowLayoutPanel129.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel129.TabIndex = 146;
			this.txtISRretenidoAcumuladoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRretenidoAcumuladoRIF.Location = new System.Drawing.Point(327, 2);
			this.txtISRretenidoAcumuladoRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRretenidoAcumuladoRIF.Name = "txtISRretenidoAcumuladoRIF";
			this.txtISRretenidoAcumuladoRIF.ReadOnly = true;
			this.txtISRretenidoAcumuladoRIF.Size = new System.Drawing.Size(119, 21);
			this.txtISRretenidoAcumuladoRIF.TabIndex = 0;
			this.txtISRretenidoAcumuladoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label96.AutoSize = true;
			this.label96.Location = new System.Drawing.Point(157, 5);
			this.label96.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label96.Name = "label96";
			this.label96.Size = new System.Drawing.Size(166, 14);
			this.label96.TabIndex = 10;
			this.label96.Text = "(-) ISR RETENIDO ACUMULADO:";
			this.flowLayoutPanel122.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel122.Controls.Add(this.txtIsrPorPagarRIF);
			this.flowLayoutPanel122.Controls.Add(this.label97);
			this.flowLayoutPanel122.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel122.Location = new System.Drawing.Point(46, 481);
			this.flowLayoutPanel122.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel122.Name = "flowLayoutPanel122";
			this.flowLayoutPanel122.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel122.TabIndex = 147;
			this.txtIsrPorPagarRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIsrPorPagarRIF.Location = new System.Drawing.Point(327, 2);
			this.txtIsrPorPagarRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtIsrPorPagarRIF.Name = "txtIsrPorPagarRIF";
			this.txtIsrPorPagarRIF.ReadOnly = true;
			this.txtIsrPorPagarRIF.Size = new System.Drawing.Size(119, 21);
			this.txtIsrPorPagarRIF.TabIndex = 0;
			this.txtIsrPorPagarRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label97.AutoSize = true;
			this.label97.Location = new System.Drawing.Point(217, 5);
			this.label97.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label97.Name = "label97";
			this.label97.Size = new System.Drawing.Size(106, 14);
			this.label97.TabIndex = 10;
			this.label97.Text = "(=) ISR POR PAGAR:";
			this.flowLayoutPanel132.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel132.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel132.Location = new System.Drawing.Point(46, 505);
			this.flowLayoutPanel132.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel132.Name = "flowLayoutPanel132";
			this.flowLayoutPanel132.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel132.TabIndex = 145;
			this.flowLayoutPanel133.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel133.BackColor = System.Drawing.Color.Navy;
			this.flowLayoutPanel133.Controls.Add(this.label99);
			this.flowLayoutPanel133.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel133.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel133.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.flowLayoutPanel133.Location = new System.Drawing.Point(46, 529);
			this.flowLayoutPanel133.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel133.Name = "flowLayoutPanel133";
			this.flowLayoutPanel133.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel133.TabIndex = 152;
			this.label99.AutoSize = true;
			this.label99.Location = new System.Drawing.Point(213, 5);
			this.label99.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label99.Name = "label99";
			this.label99.Size = new System.Drawing.Size(233, 14);
			this.label99.TabIndex = 0;
			this.label99.Text = "INTEGRACIÓN DE DEDUCCIONES PAGADAS";
			this.flowLayoutPanel134.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel134.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel134.Controls.Add(this.txtDeduccionesPueCpRIF);
			this.flowLayoutPanel134.Controls.Add(this.label100);
			this.flowLayoutPanel134.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel134.Location = new System.Drawing.Point(46, 553);
			this.flowLayoutPanel134.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel134.Name = "flowLayoutPanel134";
			this.flowLayoutPanel134.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel134.TabIndex = 153;
			this.txtDeduccionesPueCpRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPueCpRIF.Location = new System.Drawing.Point(327, 2);
			this.txtDeduccionesPueCpRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPueCpRIF.Name = "txtDeduccionesPueCpRIF";
			this.txtDeduccionesPueCpRIF.ReadOnly = true;
			this.txtDeduccionesPueCpRIF.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPueCpRIF.TabIndex = 0;
			this.txtDeduccionesPueCpRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label100.AutoSize = true;
			this.label100.Location = new System.Drawing.Point(66, 5);
			this.label100.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(257, 14);
			this.label100.TabIndex = 0;
			this.label100.Text = "DEDUCCIONES SEGÚN CFDI RECIBIDOS PUE/REP:";
			this.flowLayoutPanel135.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel135.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel135.Controls.Add(this.txtDeduccionesNominaRIF);
			this.flowLayoutPanel135.Controls.Add(this.label101);
			this.flowLayoutPanel135.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel135.Location = new System.Drawing.Point(46, 577);
			this.flowLayoutPanel135.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel135.Name = "flowLayoutPanel135";
			this.flowLayoutPanel135.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel135.TabIndex = 154;
			this.txtDeduccionesNominaRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesNominaRIF.Location = new System.Drawing.Point(327, 2);
			this.txtDeduccionesNominaRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesNominaRIF.Name = "txtDeduccionesNominaRIF";
			this.txtDeduccionesNominaRIF.ReadOnly = true;
			this.txtDeduccionesNominaRIF.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesNominaRIF.TabIndex = 0;
			this.txtDeduccionesNominaRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label101.AutoSize = true;
			this.label101.Location = new System.Drawing.Point(89, 5);
			this.label101.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label101.Name = "label101";
			this.label101.Size = new System.Drawing.Size(234, 14);
			this.label101.TabIndex = 0;
			this.label101.Text = "(+) DEDUCCIONES DE NOMINA SEGÚN CFDI:";
			this.flowLayoutPanel136.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel136.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel136.Controls.Add(this.txtDeduccionesSinCFDiRIF);
			this.flowLayoutPanel136.Controls.Add(this.label102);
			this.flowLayoutPanel136.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel136.Location = new System.Drawing.Point(46, 601);
			this.flowLayoutPanel136.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel136.Name = "flowLayoutPanel136";
			this.flowLayoutPanel136.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel136.TabIndex = 163;
			this.txtDeduccionesSinCFDiRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesSinCFDiRIF.Location = new System.Drawing.Point(327, 2);
			this.txtDeduccionesSinCFDiRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesSinCFDiRIF.Name = "txtDeduccionesSinCFDiRIF";
			this.txtDeduccionesSinCFDiRIF.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesSinCFDiRIF.TabIndex = 0;
			this.txtDeduccionesSinCFDiRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesSinCFDiRIF.TextChanged += new System.EventHandler(txtDeduccionesSinCFDiRIF_TextChanged);
			this.txtDeduccionesSinCFDiRIF.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label102.AutoSize = true;
			this.label102.Location = new System.Drawing.Point(75, 5);
			this.label102.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label102.Name = "label102";
			this.label102.Size = new System.Drawing.Size(248, 14);
			this.label102.TabIndex = 0;
			this.label102.Text = "(+) DEDUCCIONES SIN CFDI (DEPRECIACIONES):";
			this.flowLayoutPanel137.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel137.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel137.Controls.Add(this.txtDeduccionesPorPagoRIF);
			this.flowLayoutPanel137.Controls.Add(this.label103);
			this.flowLayoutPanel137.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel137.Location = new System.Drawing.Point(46, 625);
			this.flowLayoutPanel137.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel137.Name = "flowLayoutPanel137";
			this.flowLayoutPanel137.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel137.TabIndex = 165;
			this.txtDeduccionesPorPagoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPorPagoRIF.Location = new System.Drawing.Point(327, 2);
			this.txtDeduccionesPorPagoRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPorPagoRIF.Name = "txtDeduccionesPorPagoRIF";
			this.txtDeduccionesPorPagoRIF.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesPorPagoRIF.TabIndex = 0;
			this.txtDeduccionesPorPagoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPorPagoRIF.TextChanged += new System.EventHandler(txtDeduccionesSinCFDiRIF_TextChanged);
			this.txtDeduccionesPorPagoRIF.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label103.AutoSize = true;
			this.label103.Location = new System.Drawing.Point(69, 5);
			this.label103.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label103.Name = "label103";
			this.label103.Size = new System.Drawing.Size(254, 14);
			this.label103.TabIndex = 0;
			this.label103.Text = "(+) DEDUCCION POR PAGO DE IMSS/INFONAVIT:";
			this.flowLayoutPanel138.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel138.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel138.Controls.Add(this.txtOtrosGastosPagadosNoDeduciblesRIF);
			this.flowLayoutPanel138.Controls.Add(this.label104);
			this.flowLayoutPanel138.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel138.Location = new System.Drawing.Point(46, 649);
			this.flowLayoutPanel138.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel138.Name = "flowLayoutPanel138";
			this.flowLayoutPanel138.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel138.TabIndex = 170;
			this.txtOtrosGastosPagadosNoDeduciblesRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosGastosPagadosNoDeduciblesRIF.Location = new System.Drawing.Point(327, 2);
			this.txtOtrosGastosPagadosNoDeduciblesRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosGastosPagadosNoDeduciblesRIF.Name = "txtOtrosGastosPagadosNoDeduciblesRIF";
			this.txtOtrosGastosPagadosNoDeduciblesRIF.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosGastosPagadosNoDeduciblesRIF.TabIndex = 0;
			this.txtOtrosGastosPagadosNoDeduciblesRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosGastosPagadosNoDeduciblesRIF.TextChanged += new System.EventHandler(txtDeduccionesSinCFDiRIF_TextChanged);
			this.txtOtrosGastosPagadosNoDeduciblesRIF.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label104.AutoSize = true;
			this.label104.Location = new System.Drawing.Point(79, 5);
			this.label104.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label104.Name = "label104";
			this.label104.Size = new System.Drawing.Size(244, 14);
			this.label104.TabIndex = 0;
			this.label104.Text = "(-) OTROS GASTOS PAGADOS NO DEDUCIBLES:";
			this.flowLayoutPanel139.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel139.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel139.Controls.Add(this.txtDeduccionesPagadasGuardadoRIF);
			this.flowLayoutPanel139.Controls.Add(this.txtDeduccionesPagadasRIF);
			this.flowLayoutPanel139.Controls.Add(this.label105);
			this.flowLayoutPanel139.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel139.Location = new System.Drawing.Point(46, 673);
			this.flowLayoutPanel139.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel139.Name = "flowLayoutPanel139";
			this.flowLayoutPanel139.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel139.TabIndex = 166;
			this.txtDeduccionesPagadasGuardadoRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasGuardadoRIF.Location = new System.Drawing.Point(374, 2);
			this.txtDeduccionesPagadasGuardadoRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasGuardadoRIF.Name = "txtDeduccionesPagadasGuardadoRIF";
			this.txtDeduccionesPagadasGuardadoRIF.ReadOnly = true;
			this.txtDeduccionesPagadasGuardadoRIF.Size = new System.Drawing.Size(72, 21);
			this.txtDeduccionesPagadasGuardadoRIF.TabIndex = 2;
			this.txtDeduccionesPagadasGuardadoRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtDeduccionesPagadasRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesPagadasRIF.Location = new System.Drawing.Point(298, 2);
			this.txtDeduccionesPagadasRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesPagadasRIF.Name = "txtDeduccionesPagadasRIF";
			this.txtDeduccionesPagadasRIF.ReadOnly = true;
			this.txtDeduccionesPagadasRIF.Size = new System.Drawing.Size(72, 21);
			this.txtDeduccionesPagadasRIF.TabIndex = 1;
			this.txtDeduccionesPagadasRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label105.AutoSize = true;
			this.label105.Location = new System.Drawing.Point(83, 5);
			this.label105.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label105.Name = "label105";
			this.label105.Size = new System.Drawing.Size(211, 14);
			this.label105.TabIndex = 0;
			this.label105.Text = "(=) DEDUCCIONES PAGADAS EN EL MES:";
			this.flowLayoutPanel140.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel140.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel140.Location = new System.Drawing.Point(46, 697);
			this.flowLayoutPanel140.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel140.Name = "flowLayoutPanel140";
			this.flowLayoutPanel140.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel140.TabIndex = 155;
			this.flowLayoutPanel141.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel141.BackColor = System.Drawing.Color.Navy;
			this.flowLayoutPanel141.Controls.Add(this.label106);
			this.flowLayoutPanel141.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel141.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.flowLayoutPanel141.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.flowLayoutPanel141.Location = new System.Drawing.Point(46, 721);
			this.flowLayoutPanel141.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel141.Name = "flowLayoutPanel141";
			this.flowLayoutPanel141.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel141.TabIndex = 156;
			this.label106.AutoSize = true;
			this.label106.Location = new System.Drawing.Point(218, 5);
			this.label106.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label106.Name = "label106";
			this.label106.Size = new System.Drawing.Size(228, 14);
			this.label106.TabIndex = 0;
			this.label106.Text = "INTEGRACIÓN DE DEDUCCIONES NOMINA";
			this.flowLayoutPanel142.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel142.Controls.Add(this.rdoEnBaseFechaDevengadaRIF);
			this.flowLayoutPanel142.Controls.Add(this.rdoEnBaseFechaPagoRIF);
			this.flowLayoutPanel142.Controls.Add(this.rdoEnBaseFechaFacturaRIF);
			this.flowLayoutPanel142.Controls.Add(this.label107);
			this.flowLayoutPanel142.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel142.Location = new System.Drawing.Point(46, 745);
			this.flowLayoutPanel142.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel142.Name = "flowLayoutPanel142";
			this.flowLayoutPanel142.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel142.TabIndex = 162;
			this.rdoEnBaseFechaDevengadaRIF.AutoSize = true;
			this.rdoEnBaseFechaDevengadaRIF.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaDevengadaRIF.Location = new System.Drawing.Point(329, 3);
			this.rdoEnBaseFechaDevengadaRIF.Name = "rdoEnBaseFechaDevengadaRIF";
			this.rdoEnBaseFechaDevengadaRIF.Size = new System.Drawing.Size(116, 17);
			this.rdoEnBaseFechaDevengadaRIF.TabIndex = 154;
			this.rdoEnBaseFechaDevengadaRIF.Tag = "3";
			this.rdoEnBaseFechaDevengadaRIF.Text = "Fecha Devengada";
			this.rdoEnBaseFechaDevengadaRIF.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaDevengadaRIF.CheckedChanged += new System.EventHandler(rdoEnBaseFechaDevengadaRPM_CheckedChanged);
			this.rdoEnBaseFechaPagoRIF.AutoSize = true;
			this.rdoEnBaseFechaPagoRIF.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaPagoRIF.Location = new System.Drawing.Point(239, 3);
			this.rdoEnBaseFechaPagoRIF.Name = "rdoEnBaseFechaPagoRIF";
			this.rdoEnBaseFechaPagoRIF.Size = new System.Drawing.Size(84, 17);
			this.rdoEnBaseFechaPagoRIF.TabIndex = 152;
			this.rdoEnBaseFechaPagoRIF.Tag = "2";
			this.rdoEnBaseFechaPagoRIF.Text = "Fecha Pago";
			this.rdoEnBaseFechaPagoRIF.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaPagoRIF.CheckedChanged += new System.EventHandler(rdoEnBaseFechaPagoRPM_CheckedChanged);
			this.rdoEnBaseFechaFacturaRIF.AutoSize = true;
			this.rdoEnBaseFechaFacturaRIF.Checked = true;
			this.rdoEnBaseFechaFacturaRIF.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.rdoEnBaseFechaFacturaRIF.Location = new System.Drawing.Point(137, 3);
			this.rdoEnBaseFechaFacturaRIF.Name = "rdoEnBaseFechaFacturaRIF";
			this.rdoEnBaseFechaFacturaRIF.Size = new System.Drawing.Size(96, 17);
			this.rdoEnBaseFechaFacturaRIF.TabIndex = 155;
			this.rdoEnBaseFechaFacturaRIF.TabStop = true;
			this.rdoEnBaseFechaFacturaRIF.Tag = "1";
			this.rdoEnBaseFechaFacturaRIF.Text = "Fecha Factura";
			this.rdoEnBaseFechaFacturaRIF.UseVisualStyleBackColor = true;
			this.rdoEnBaseFechaFacturaRIF.CheckedChanged += new System.EventHandler(rdoEnBaseFechaFacturaRPM_CheckedChanged);
			this.label107.AutoSize = true;
			this.label107.Location = new System.Drawing.Point(73, 5);
			this.label107.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label107.Name = "label107";
			this.label107.Size = new System.Drawing.Size(59, 14);
			this.label107.TabIndex = 153;
			this.label107.Text = "En base a:";
			this.flowLayoutPanel143.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel143.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel143.Controls.Add(this.txtTotalPercepcionesExentasRIF);
			this.flowLayoutPanel143.Controls.Add(this.label108);
			this.flowLayoutPanel143.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel143.Location = new System.Drawing.Point(46, 769);
			this.flowLayoutPanel143.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel143.Name = "flowLayoutPanel143";
			this.flowLayoutPanel143.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel143.TabIndex = 157;
			this.txtTotalPercepcionesExentasRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesExentasRIF.Location = new System.Drawing.Point(327, 2);
			this.txtTotalPercepcionesExentasRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesExentasRIF.Name = "txtTotalPercepcionesExentasRIF";
			this.txtTotalPercepcionesExentasRIF.ReadOnly = true;
			this.txtTotalPercepcionesExentasRIF.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesExentasRIF.TabIndex = 1;
			this.txtTotalPercepcionesExentasRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label108.AutoSize = true;
			this.label108.Location = new System.Drawing.Point(99, 5);
			this.label108.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label108.Name = "label108";
			this.label108.Size = new System.Drawing.Size(224, 14);
			this.label108.TabIndex = 0;
			this.label108.Text = "TOTAL PERCEPCIONES EXENTAS EN EL MES:";
			this.flowLayoutPanel144.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel144.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel144.Controls.Add(this.cmbPorcentajeDeducibleRIF);
			this.flowLayoutPanel144.Controls.Add(this.label109);
			this.flowLayoutPanel144.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel144.Location = new System.Drawing.Point(46, 793);
			this.flowLayoutPanel144.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel144.Name = "flowLayoutPanel144";
			this.flowLayoutPanel144.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel144.TabIndex = 159;
			this.cmbPorcentajeDeducibleRIF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPorcentajeDeducibleRIF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbPorcentajeDeducibleRIF.FormattingEnabled = true;
			this.cmbPorcentajeDeducibleRIF.Items.AddRange(new object[3] { "47%", "53%", "100%" });
			this.cmbPorcentajeDeducibleRIF.Location = new System.Drawing.Point(331, 2);
			this.cmbPorcentajeDeducibleRIF.Margin = new System.Windows.Forms.Padding(2);
			this.cmbPorcentajeDeducibleRIF.Name = "cmbPorcentajeDeducibleRIF";
			this.cmbPorcentajeDeducibleRIF.Size = new System.Drawing.Size(115, 22);
			this.cmbPorcentajeDeducibleRIF.TabIndex = 1;
			this.cmbPorcentajeDeducibleRIF.SelectedIndexChanged += new System.EventHandler(cmbPorcentajeDeducibleRIF_SelectedIndexChanged);
			this.label109.AutoSize = true;
			this.label109.Location = new System.Drawing.Point(20, 5);
			this.label109.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label109.Name = "label109";
			this.label109.Size = new System.Drawing.Size(307, 14);
			this.label109.TabIndex = 0;
			this.label109.Text = "(X) PORCENTAJE DEDUCIBLE PARA PERCEPCIONES EXENTOS";
			this.flowLayoutPanel145.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel145.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel145.Controls.Add(this.txtPercepcionesExentasRIF);
			this.flowLayoutPanel145.Controls.Add(this.label110);
			this.flowLayoutPanel145.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel145.Location = new System.Drawing.Point(46, 817);
			this.flowLayoutPanel145.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel145.Name = "flowLayoutPanel145";
			this.flowLayoutPanel145.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel145.TabIndex = 160;
			this.txtPercepcionesExentasRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPercepcionesExentasRIF.Location = new System.Drawing.Point(327, 2);
			this.txtPercepcionesExentasRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtPercepcionesExentasRIF.Name = "txtPercepcionesExentasRIF";
			this.txtPercepcionesExentasRIF.ReadOnly = true;
			this.txtPercepcionesExentasRIF.Size = new System.Drawing.Size(119, 21);
			this.txtPercepcionesExentasRIF.TabIndex = 1;
			this.txtPercepcionesExentasRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label110.AutoSize = true;
			this.label110.Location = new System.Drawing.Point(105, 5);
			this.label110.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label110.Name = "label110";
			this.label110.Size = new System.Drawing.Size(218, 14);
			this.label110.TabIndex = 0;
			this.label110.Text = "(=) PERCEPCIONES EXENTAS DEDUCIBLES:";
			this.flowLayoutPanel146.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel146.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel146.Controls.Add(this.txtTotalPercepcionesGravadasRIF);
			this.flowLayoutPanel146.Controls.Add(this.label111);
			this.flowLayoutPanel146.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel146.Location = new System.Drawing.Point(46, 841);
			this.flowLayoutPanel146.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel146.Name = "flowLayoutPanel146";
			this.flowLayoutPanel146.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel146.TabIndex = 158;
			this.txtTotalPercepcionesGravadasRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesGravadasRIF.Location = new System.Drawing.Point(327, 2);
			this.txtTotalPercepcionesGravadasRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesGravadasRIF.Name = "txtTotalPercepcionesGravadasRIF";
			this.txtTotalPercepcionesGravadasRIF.ReadOnly = true;
			this.txtTotalPercepcionesGravadasRIF.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesGravadasRIF.TabIndex = 1;
			this.txtTotalPercepcionesGravadasRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label111.AutoSize = true;
			this.label111.Location = new System.Drawing.Point(69, 5);
			this.label111.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label111.Name = "label111";
			this.label111.Size = new System.Drawing.Size(254, 14);
			this.label111.TabIndex = 0;
			this.label111.Text = "(+) TOTAL PERCEPCIONES GRAVADAS EN EL MES:";
			this.flowLayoutPanel147.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel147.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel147.Controls.Add(this.txtDeduccionesNominaNRIF);
			this.flowLayoutPanel147.Controls.Add(this.label112);
			this.flowLayoutPanel147.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel147.Location = new System.Drawing.Point(46, 865);
			this.flowLayoutPanel147.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel147.Name = "flowLayoutPanel147";
			this.flowLayoutPanel147.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel147.TabIndex = 164;
			this.txtDeduccionesNominaNRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesNominaNRIF.Location = new System.Drawing.Point(327, 2);
			this.txtDeduccionesNominaNRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesNominaNRIF.Name = "txtDeduccionesNominaNRIF";
			this.txtDeduccionesNominaNRIF.ReadOnly = true;
			this.txtDeduccionesNominaNRIF.Size = new System.Drawing.Size(119, 21);
			this.txtDeduccionesNominaNRIF.TabIndex = 1;
			this.txtDeduccionesNominaNRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label112.AutoSize = true;
			this.label112.Location = new System.Drawing.Point(89, 5);
			this.label112.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label112.Name = "label112";
			this.label112.Size = new System.Drawing.Size(234, 14);
			this.label112.TabIndex = 0;
			this.label112.Text = "(=) DEDUCCIONES DE NOMINA SEGÚN CFDI:";
			this.flowLayoutPanel148.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel148.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			this.flowLayoutPanel148.Controls.Add(this.txtTotalPercepcionesExentasGravadasRIF);
			this.flowLayoutPanel148.Controls.Add(this.label113);
			this.flowLayoutPanel148.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel148.Location = new System.Drawing.Point(2, 889);
			this.flowLayoutPanel148.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel148.Name = "flowLayoutPanel148";
			this.flowLayoutPanel148.Size = new System.Drawing.Size(492, 20);
			this.flowLayoutPanel148.TabIndex = 161;
			this.txtTotalPercepcionesExentasGravadasRIF.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalPercepcionesExentasGravadasRIF.Location = new System.Drawing.Point(371, 2);
			this.txtTotalPercepcionesExentasGravadasRIF.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalPercepcionesExentasGravadasRIF.Name = "txtTotalPercepcionesExentasGravadasRIF";
			this.txtTotalPercepcionesExentasGravadasRIF.ReadOnly = true;
			this.txtTotalPercepcionesExentasGravadasRIF.Size = new System.Drawing.Size(119, 21);
			this.txtTotalPercepcionesExentasGravadasRIF.TabIndex = 1;
			this.txtTotalPercepcionesExentasGravadasRIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label113.AutoSize = true;
			this.label113.Location = new System.Drawing.Point(72, 5);
			this.label113.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label113.Name = "label113";
			this.label113.Size = new System.Drawing.Size(295, 14);
			this.label113.TabIndex = 0;
			this.label113.Text = "TOTAL PERCEPCIONES EXENTAS + GRAVADAS EN EL MES:";
			this.tabPage2.Controls.Add(this.flowLayoutPanel130);
			this.tabPage2.Controls.Add(this.flowLayoutPanel149);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(658, 371);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Text = "ARRENDAMIENTO";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.flowLayoutPanel130.Controls.Add(this.btnGuardarCalculoAR);
			this.flowLayoutPanel130.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel130.Location = new System.Drawing.Point(582, 2);
			this.flowLayoutPanel130.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel130.Name = "flowLayoutPanel130";
			this.flowLayoutPanel130.Size = new System.Drawing.Size(77, 278);
			this.flowLayoutPanel130.TabIndex = 147;
			this.btnGuardarCalculoAR.BackColor = System.Drawing.Color.White;
			this.btnGuardarCalculoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 6f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnGuardarCalculoAR.Image = LeeXML.Properties.Resources.Aceptar;
			this.btnGuardarCalculoAR.Location = new System.Drawing.Point(2, 2);
			this.btnGuardarCalculoAR.Margin = new System.Windows.Forms.Padding(2);
			this.btnGuardarCalculoAR.Name = "btnGuardarCalculoAR";
			this.btnGuardarCalculoAR.Size = new System.Drawing.Size(75, 63);
			this.btnGuardarCalculoAR.TabIndex = 0;
			this.btnGuardarCalculoAR.Text = "GUARDAR CÁLCULO";
			this.btnGuardarCalculoAR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnGuardarCalculoAR.UseVisualStyleBackColor = false;
			this.btnGuardarCalculoAR.Click += new System.EventHandler(btnGuardarCalculoAR_Click);
			this.flowLayoutPanel149.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel149.AutoScroll = true;
			this.flowLayoutPanel149.Controls.Add(this.lbTituloISRar);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel150);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel151);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel152);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel153);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel154);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel155);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel156);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel157);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel158);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel159);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel160);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel161);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel162);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel164);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel165);
			this.flowLayoutPanel149.Controls.Add(this.flowLayoutPanel166);
			this.flowLayoutPanel149.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flowLayoutPanel149.Location = new System.Drawing.Point(2, 4);
			this.flowLayoutPanel149.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel149.Name = "flowLayoutPanel149";
			this.flowLayoutPanel149.Size = new System.Drawing.Size(578, 364);
			this.flowLayoutPanel149.TabIndex = 146;
			this.flowLayoutPanel149.WrapContents = false;
			this.lbTituloISRar.AutoSize = true;
			this.lbTituloISRar.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.lbTituloISRar.Location = new System.Drawing.Point(2, 0);
			this.lbTituloISRar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lbTituloISRar.Name = "lbTituloISRar";
			this.lbTituloISRar.Size = new System.Drawing.Size(205, 16);
			this.lbTituloISRar.TabIndex = 151;
			this.lbTituloISRar.Text = "CÁLCULO DE ISR ARRENDAMIENTO";
			this.flowLayoutPanel150.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel150.Controls.Add(this.txtIngresosCobradosPeriodoAR);
			this.flowLayoutPanel150.Controls.Add(this.label114);
			this.flowLayoutPanel150.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel150.Location = new System.Drawing.Point(2, 18);
			this.flowLayoutPanel150.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel150.Name = "flowLayoutPanel150";
			this.flowLayoutPanel150.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel150.TabIndex = 0;
			this.txtIngresosCobradosPeriodoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosPeriodoAR.Location = new System.Drawing.Point(327, 2);
			this.txtIngresosCobradosPeriodoAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosPeriodoAR.Name = "txtIngresosCobradosPeriodoAR";
			this.txtIngresosCobradosPeriodoAR.ReadOnly = true;
			this.txtIngresosCobradosPeriodoAR.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosPeriodoAR.TabIndex = 0;
			this.txtIngresosCobradosPeriodoAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label114.AutoSize = true;
			this.label114.Location = new System.Drawing.Point(121, 5);
			this.label114.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label114.Name = "label114";
			this.label114.Size = new System.Drawing.Size(202, 14);
			this.label114.TabIndex = 0;
			this.label114.Text = "INGRESOS COBRADOS DEL PERIODO :";
			this.flowLayoutPanel151.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel151.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel151.Controls.Add(this.txtOtrosIngresosAcumulablesAR);
			this.flowLayoutPanel151.Controls.Add(this.label115);
			this.flowLayoutPanel151.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel151.Location = new System.Drawing.Point(2, 42);
			this.flowLayoutPanel151.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel151.Name = "flowLayoutPanel151";
			this.flowLayoutPanel151.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel151.TabIndex = 141;
			this.txtOtrosIngresosAcumulablesAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtOtrosIngresosAcumulablesAR.Location = new System.Drawing.Point(327, 2);
			this.txtOtrosIngresosAcumulablesAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtOtrosIngresosAcumulablesAR.Name = "txtOtrosIngresosAcumulablesAR";
			this.txtOtrosIngresosAcumulablesAR.Size = new System.Drawing.Size(119, 21);
			this.txtOtrosIngresosAcumulablesAR.TabIndex = 0;
			this.txtOtrosIngresosAcumulablesAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOtrosIngresosAcumulablesAR.TextChanged += new System.EventHandler(txtOtrosIngresosAcumulablesAR_TextChanged);
			this.txtOtrosIngresosAcumulablesAR.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label115.AutoSize = true;
			this.label115.Location = new System.Drawing.Point(125, 5);
			this.label115.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label115.Name = "label115";
			this.label115.Size = new System.Drawing.Size(198, 14);
			this.label115.TabIndex = 0;
			this.label115.Text = "(+) OTROS INGRESOS ACUMULABLES:";
			this.flowLayoutPanel152.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel152.BackColor = System.Drawing.Color.White;
			this.flowLayoutPanel152.Controls.Add(this.txtIngresosCobradosNoAcumulablesAR);
			this.flowLayoutPanel152.Controls.Add(this.label116);
			this.flowLayoutPanel152.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel152.Location = new System.Drawing.Point(2, 66);
			this.flowLayoutPanel152.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel152.Name = "flowLayoutPanel152";
			this.flowLayoutPanel152.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel152.TabIndex = 143;
			this.txtIngresosCobradosNoAcumulablesAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosNoAcumulablesAR.Location = new System.Drawing.Point(327, 2);
			this.txtIngresosCobradosNoAcumulablesAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosNoAcumulablesAR.Name = "txtIngresosCobradosNoAcumulablesAR";
			this.txtIngresosCobradosNoAcumulablesAR.Size = new System.Drawing.Size(119, 21);
			this.txtIngresosCobradosNoAcumulablesAR.TabIndex = 0;
			this.txtIngresosCobradosNoAcumulablesAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosNoAcumulablesAR.TextChanged += new System.EventHandler(txtOtrosIngresosAcumulablesAR_TextChanged);
			this.txtIngresosCobradosNoAcumulablesAR.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label116.AutoSize = true;
			this.label116.Location = new System.Drawing.Point(85, 5);
			this.label116.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label116.Name = "label116";
			this.label116.Size = new System.Drawing.Size(238, 14);
			this.label116.TabIndex = 0;
			this.label116.Text = "(-) INGRESOS COBRADOS NO ACUMULABLES:";
			this.flowLayoutPanel153.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel153.Controls.Add(this.txtIngresosCobradosAcumuladosGuardadoAR);
			this.flowLayoutPanel153.Controls.Add(this.txtIngresosCobradosAcumuladosAR);
			this.flowLayoutPanel153.Controls.Add(this.label117);
			this.flowLayoutPanel153.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel153.Location = new System.Drawing.Point(2, 90);
			this.flowLayoutPanel153.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel153.Name = "flowLayoutPanel153";
			this.flowLayoutPanel153.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel153.TabIndex = 1;
			this.txtIngresosCobradosAcumuladosGuardadoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosGuardadoAR.Location = new System.Drawing.Point(359, 2);
			this.txtIngresosCobradosAcumuladosGuardadoAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosGuardadoAR.Name = "txtIngresosCobradosAcumuladosGuardadoAR";
			this.txtIngresosCobradosAcumuladosGuardadoAR.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosGuardadoAR.Size = new System.Drawing.Size(87, 21);
			this.txtIngresosCobradosAcumuladosGuardadoAR.TabIndex = 0;
			this.txtIngresosCobradosAcumuladosGuardadoAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtIngresosCobradosAcumuladosAR.BackColor = System.Drawing.Color.Silver;
			this.txtIngresosCobradosAcumuladosAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtIngresosCobradosAcumuladosAR.Location = new System.Drawing.Point(277, 2);
			this.txtIngresosCobradosAcumuladosAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtIngresosCobradosAcumuladosAR.Name = "txtIngresosCobradosAcumuladosAR";
			this.txtIngresosCobradosAcumuladosAR.ReadOnly = true;
			this.txtIngresosCobradosAcumuladosAR.Size = new System.Drawing.Size(78, 21);
			this.txtIngresosCobradosAcumuladosAR.TabIndex = 2;
			this.txtIngresosCobradosAcumuladosAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label117.AutoSize = true;
			this.label117.Location = new System.Drawing.Point(52, 5);
			this.label117.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label117.Name = "label117";
			this.label117.Size = new System.Drawing.Size(221, 14);
			this.label117.TabIndex = 3;
			this.label117.Text = "(=) INGRESOS COBRADOS ACUMULADOS:";
			this.flowLayoutPanel154.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel154.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel154.Location = new System.Drawing.Point(2, 114);
			this.flowLayoutPanel154.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel154.Name = "flowLayoutPanel154";
			this.flowLayoutPanel154.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel154.TabIndex = 145;
			this.flowLayoutPanel155.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel155.Controls.Add(this.txtDeduccionesOpcional);
			this.flowLayoutPanel155.Controls.Add(this.cmbDeduccionOpcionalAR);
			this.flowLayoutPanel155.Controls.Add(this.label118);
			this.flowLayoutPanel155.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel155.Location = new System.Drawing.Point(2, 138);
			this.flowLayoutPanel155.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel155.Name = "flowLayoutPanel155";
			this.flowLayoutPanel155.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel155.TabIndex = 154;
			this.txtDeduccionesOpcional.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtDeduccionesOpcional.Location = new System.Drawing.Point(359, 2);
			this.txtDeduccionesOpcional.Margin = new System.Windows.Forms.Padding(2);
			this.txtDeduccionesOpcional.Name = "txtDeduccionesOpcional";
			this.txtDeduccionesOpcional.ReadOnly = true;
			this.txtDeduccionesOpcional.Size = new System.Drawing.Size(87, 21);
			this.txtDeduccionesOpcional.TabIndex = 2;
			this.txtDeduccionesOpcional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.cmbDeduccionOpcionalAR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDeduccionOpcionalAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbDeduccionOpcionalAR.FormattingEnabled = true;
			this.cmbDeduccionOpcionalAR.Items.AddRange(new object[1] { "35%" });
			this.cmbDeduccionOpcionalAR.Location = new System.Drawing.Point(304, 2);
			this.cmbDeduccionOpcionalAR.Margin = new System.Windows.Forms.Padding(2);
			this.cmbDeduccionOpcionalAR.Name = "cmbDeduccionOpcionalAR";
			this.cmbDeduccionOpcionalAR.Size = new System.Drawing.Size(51, 22);
			this.cmbDeduccionOpcionalAR.TabIndex = 1;
			this.label118.AutoSize = true;
			this.label118.Location = new System.Drawing.Point(105, 5);
			this.label118.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label118.Name = "label118";
			this.label118.Size = new System.Drawing.Size(195, 14);
			this.label118.TabIndex = 0;
			this.label118.Text = "DEDUCCIÓN OPCIONAL (CIEGA 35%):";
			this.flowLayoutPanel156.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel156.Controls.Add(this.txtPredialAR);
			this.flowLayoutPanel156.Controls.Add(this.label119);
			this.flowLayoutPanel156.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel156.Location = new System.Drawing.Point(2, 162);
			this.flowLayoutPanel156.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel156.Name = "flowLayoutPanel156";
			this.flowLayoutPanel156.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel156.TabIndex = 145;
			this.txtPredialAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtPredialAR.Location = new System.Drawing.Point(327, 2);
			this.txtPredialAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtPredialAR.Name = "txtPredialAR";
			this.txtPredialAR.Size = new System.Drawing.Size(119, 21);
			this.txtPredialAR.TabIndex = 1;
			this.txtPredialAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPredialAR.TextChanged += new System.EventHandler(txtPredialAR_TextChanged);
			this.txtPredialAR.Leave += new System.EventHandler(txtPagosProvisionalesCaptura_Leave);
			this.label119.AutoSize = true;
			this.label119.Location = new System.Drawing.Point(271, 5);
			this.label119.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label119.Name = "label119";
			this.label119.Size = new System.Drawing.Size(52, 14);
			this.label119.TabIndex = 4;
			this.label119.Text = "PREDIAL:";
			this.flowLayoutPanel157.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel157.Controls.Add(this.flowLayoutPanel183);
			this.flowLayoutPanel157.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel157.Location = new System.Drawing.Point(2, 186);
			this.flowLayoutPanel157.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel157.Name = "flowLayoutPanel157";
			this.flowLayoutPanel157.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel157.TabIndex = 145;
			this.flowLayoutPanel183.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel183.Controls.Add(this.txtTotalDeduccionesPeriodoAR);
			this.flowLayoutPanel183.Controls.Add(this.label142);
			this.flowLayoutPanel183.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel183.Location = new System.Drawing.Point(-2, 2);
			this.flowLayoutPanel183.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel183.Name = "flowLayoutPanel183";
			this.flowLayoutPanel183.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel183.TabIndex = 169;
			this.txtTotalDeduccionesPeriodoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtTotalDeduccionesPeriodoAR.Location = new System.Drawing.Point(327, 2);
			this.txtTotalDeduccionesPeriodoAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtTotalDeduccionesPeriodoAR.Name = "txtTotalDeduccionesPeriodoAR";
			this.txtTotalDeduccionesPeriodoAR.ReadOnly = true;
			this.txtTotalDeduccionesPeriodoAR.Size = new System.Drawing.Size(119, 21);
			this.txtTotalDeduccionesPeriodoAR.TabIndex = 0;
			this.txtTotalDeduccionesPeriodoAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label142.AutoSize = true;
			this.label142.Location = new System.Drawing.Point(130, 5);
			this.label142.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label142.Name = "label142";
			this.label142.Size = new System.Drawing.Size(193, 14);
			this.label142.TabIndex = 2;
			this.label142.Text = "TOTAL DEDUCCIONES DEL PERIODO:";
			this.flowLayoutPanel158.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel158.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel158.Location = new System.Drawing.Point(2, 210);
			this.flowLayoutPanel158.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel158.Name = "flowLayoutPanel158";
			this.flowLayoutPanel158.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel158.TabIndex = 145;
			this.flowLayoutPanel159.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel159.Controls.Add(this.txtBaseAR);
			this.flowLayoutPanel159.Controls.Add(this.label121);
			this.flowLayoutPanel159.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel159.Location = new System.Drawing.Point(2, 234);
			this.flowLayoutPanel159.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel159.Name = "flowLayoutPanel159";
			this.flowLayoutPanel159.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel159.TabIndex = 145;
			this.txtBaseAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtBaseAR.Location = new System.Drawing.Point(327, 2);
			this.txtBaseAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtBaseAR.Name = "txtBaseAR";
			this.txtBaseAR.ReadOnly = true;
			this.txtBaseAR.Size = new System.Drawing.Size(119, 21);
			this.txtBaseAR.TabIndex = 0;
			this.txtBaseAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label121.AutoSize = true;
			this.label121.Location = new System.Drawing.Point(270, 5);
			this.label121.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label121.Name = "label121";
			this.label121.Size = new System.Drawing.Size(53, 14);
			this.label121.TabIndex = 6;
			this.label121.Text = "(=) BASE:";
			this.flowLayoutPanel160.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel160.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel160.Location = new System.Drawing.Point(2, 258);
			this.flowLayoutPanel160.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel160.Name = "flowLayoutPanel160";
			this.flowLayoutPanel160.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel160.TabIndex = 145;
			this.flowLayoutPanel161.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel161.Controls.Add(this.label122);
			this.flowLayoutPanel161.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel161.Location = new System.Drawing.Point(2, 282);
			this.flowLayoutPanel161.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel161.Name = "flowLayoutPanel161";
			this.flowLayoutPanel161.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel161.TabIndex = 144;
			this.label122.AutoSize = true;
			this.label122.Location = new System.Drawing.Point(240, 5);
			this.label122.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label122.Name = "label122";
			this.label122.Size = new System.Drawing.Size(206, 14);
			this.label122.TabIndex = 0;
			this.label122.Text = "APLICACIÓN DE TARIFA SOBRE LA BASE";
			this.flowLayoutPanel162.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel162.Controls.Add(this.txtISRCausadoAR);
			this.flowLayoutPanel162.Controls.Add(this.label123);
			this.flowLayoutPanel162.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel162.Location = new System.Drawing.Point(2, 306);
			this.flowLayoutPanel162.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel162.Name = "flowLayoutPanel162";
			this.flowLayoutPanel162.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel162.TabIndex = 146;
			this.txtISRCausadoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRCausadoAR.Location = new System.Drawing.Point(327, 2);
			this.txtISRCausadoAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRCausadoAR.Name = "txtISRCausadoAR";
			this.txtISRCausadoAR.ReadOnly = true;
			this.txtISRCausadoAR.Size = new System.Drawing.Size(119, 21);
			this.txtISRCausadoAR.TabIndex = 0;
			this.txtISRCausadoAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label123.AutoSize = true;
			this.label123.Location = new System.Drawing.Point(242, 5);
			this.label123.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label123.Name = "label123";
			this.label123.Size = new System.Drawing.Size(81, 14);
			this.label123.TabIndex = 8;
			this.label123.Text = "ISR CAUSADO:";
			this.flowLayoutPanel164.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel164.Controls.Add(this.txtISRRetenidoPeriodoAR);
			this.flowLayoutPanel164.Controls.Add(this.label125);
			this.flowLayoutPanel164.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel164.Location = new System.Drawing.Point(2, 330);
			this.flowLayoutPanel164.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel164.Name = "flowLayoutPanel164";
			this.flowLayoutPanel164.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel164.TabIndex = 146;
			this.txtISRRetenidoPeriodoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRRetenidoPeriodoAR.Location = new System.Drawing.Point(327, 2);
			this.txtISRRetenidoPeriodoAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRRetenidoPeriodoAR.Name = "txtISRRetenidoPeriodoAR";
			this.txtISRRetenidoPeriodoAR.ReadOnly = true;
			this.txtISRRetenidoPeriodoAR.Size = new System.Drawing.Size(119, 21);
			this.txtISRRetenidoPeriodoAR.TabIndex = 0;
			this.txtISRRetenidoPeriodoAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label125.AutoSize = true;
			this.label125.Location = new System.Drawing.Point(156, 5);
			this.label125.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label125.Name = "label125";
			this.label125.Size = new System.Drawing.Size(167, 14);
			this.label125.TabIndex = 10;
			this.label125.Text = "(-) ISR RETENIDO DEL PERIODO:";
			this.flowLayoutPanel165.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel165.Controls.Add(this.txtISRaCargoAR);
			this.flowLayoutPanel165.Controls.Add(this.label126);
			this.flowLayoutPanel165.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel165.Location = new System.Drawing.Point(2, 354);
			this.flowLayoutPanel165.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel165.Name = "flowLayoutPanel165";
			this.flowLayoutPanel165.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel165.TabIndex = 146;
			this.txtISRaCargoAR.Font = new System.Drawing.Font("Microsoft Tai Le", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtISRaCargoAR.Location = new System.Drawing.Point(327, 2);
			this.txtISRaCargoAR.Margin = new System.Windows.Forms.Padding(2);
			this.txtISRaCargoAR.Name = "txtISRaCargoAR";
			this.txtISRaCargoAR.ReadOnly = true;
			this.txtISRaCargoAR.Size = new System.Drawing.Size(119, 21);
			this.txtISRaCargoAR.TabIndex = 0;
			this.txtISRaCargoAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.label126.AutoSize = true;
			this.label126.Location = new System.Drawing.Point(229, 5);
			this.label126.Margin = new System.Windows.Forms.Padding(2, 5, 2, 0);
			this.label126.Name = "label126";
			this.label126.Size = new System.Drawing.Size(94, 14);
			this.label126.TabIndex = 12;
			this.label126.Text = "(=) ISR A CARGO:";
			this.flowLayoutPanel166.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel166.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel166.Location = new System.Drawing.Point(2, 378);
			this.flowLayoutPanel166.Margin = new System.Windows.Forms.Padding(2);
			this.flowLayoutPanel166.Name = "flowLayoutPanel166";
			this.flowLayoutPanel166.Size = new System.Drawing.Size(448, 20);
			this.flowLayoutPanel166.TabIndex = 145;
			this.pnlFlujos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.pnlFlujos.Controls.Add(this.flpFlujos);
			this.pnlFlujos.Location = new System.Drawing.Point(681, 87);
			this.pnlFlujos.Margin = new System.Windows.Forms.Padding(2);
			this.pnlFlujos.Name = "pnlFlujos";
			this.pnlFlujos.Size = new System.Drawing.Size(344, 381);
			this.pnlFlujos.TabIndex = 137;
			this.flpFlujos.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpFlujos.Controls.Add(this.flpPUE);
			this.flpFlujos.Controls.Add(this.flpRecibidosMensual);
			this.flpFlujos.Controls.Add(this.flpEmitidosAnual);
			this.flpFlujos.Controls.Add(this.gvNominas);
			this.flpFlujos.Location = new System.Drawing.Point(2, 3);
			this.flpFlujos.Margin = new System.Windows.Forms.Padding(2);
			this.flpFlujos.Name = "flpFlujos";
			this.flpFlujos.Size = new System.Drawing.Size(344, 375);
			this.flpFlujos.TabIndex = 146;
			this.flpPUE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpPUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpPUE.Controls.Add(this.label11);
			this.flpPUE.Controls.Add(this.flpTotalesTodos);
			this.flpPUE.Controls.Add(this.flowLayoutPanel16);
			this.flpPUE.Controls.Add(this.flowLayoutPanel17);
			this.flpPUE.Controls.Add(this.flowLayoutPanel19);
			this.flpPUE.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpPUE.Location = new System.Drawing.Point(1, 1);
			this.flpPUE.Margin = new System.Windows.Forms.Padding(1);
			this.flpPUE.Name = "flpPUE";
			this.flpPUE.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpPUE.Size = new System.Drawing.Size(579, 130);
			this.flpPUE.TabIndex = 141;
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new System.Drawing.Point(2, 1);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(135, 16);
			this.label11.TabIndex = 140;
			this.label11.Text = "Flujo CFDI's EMITIDOS ";
			this.flpTotalesTodos.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flpTotalesTodos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpTotalesTodos.Controls.Add(this.toolStrip1);
			this.flpTotalesTodos.Location = new System.Drawing.Point(1, 18);
			this.flpTotalesTodos.Margin = new System.Windows.Forms.Padding(1);
			this.flpTotalesTodos.Name = "flpTotalesTodos";
			this.flpTotalesTodos.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpTotalesTodos.Size = new System.Drawing.Size(768, 24);
			this.flpTotalesTodos.TabIndex = 135;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel3, this.tstxtNumPUE, this.toolStripSeparator4, this.toolStripLabel4, this.tstxtSubtotalPUE, this.toolStripSeparator1, this.toolStripLabel17, this.tstxtIvaPUE, this.toolStripSeparator2, this.toolStripLabel1,
				this.tstxtRetencionesPUE, this.toolStripSeparator13, this.toolStripLabel2, this.tstxtImportePUE
			});
			this.toolStrip1.Location = new System.Drawing.Point(0, 1);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip1.Size = new System.Drawing.Size(533, 21);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel3.Text = "           PUE:";
			this.tstxtNumPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUE.Name = "tstxtNumPUE";
			this.tstxtNumPUE.ReadOnly = true;
			this.tstxtNumPUE.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel4.Text = "SubTotal:";
			this.tstxtSubtotalPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUE.Name = "tstxtSubtotalPUE";
			this.tstxtSubtotalPUE.ReadOnly = true;
			this.tstxtSubtotalPUE.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel17.Name = "toolStripLabel17";
			this.toolStripLabel17.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel17.Text = "I.V.A:";
			this.tstxtIvaPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUE.Name = "tstxtIvaPUE";
			this.tstxtIvaPUE.ReadOnly = true;
			this.tstxtIvaPUE.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel1.Text = "ISR Retenido:";
			this.tstxtRetencionesPUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUE.Name = "tstxtRetencionesPUE";
			this.tstxtRetencionesPUE.ReadOnly = true;
			this.tstxtRetencionesPUE.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesPUE.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator13.Name = "toolStripSeparator13";
			this.toolStripSeparator13.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel2.Text = "Total:";
			this.toolStripLabel2.Visible = false;
			this.tstxtImportePUE.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImportePUE.Name = "tstxtImportePUE";
			this.tstxtImportePUE.ReadOnly = true;
			this.tstxtImportePUE.Size = new System.Drawing.Size(39, 21);
			this.tstxtImportePUE.Visible = false;
			this.flowLayoutPanel16.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel16.Controls.Add(this.toolStrip2);
			this.flowLayoutPanel16.Location = new System.Drawing.Point(1, 44);
			this.flowLayoutPanel16.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel16.Name = "flowLayoutPanel16";
			this.flowLayoutPanel16.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel16.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel16.TabIndex = 136;
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel5, this.tstxtNumCP, this.toolStripSeparator3, this.toolStripLabel6, this.tstxtSubtotalCP, this.toolStripSeparator5, this.toolStripLabel7, this.tstxtIvaCP, this.toolStripSeparator6, this.toolStripLabel18,
				this.tstxtRetencionesCP, this.toolStripSeparator14, this.toolStripLabel8, this.tstxtImporteCP
			});
			this.toolStrip2.Location = new System.Drawing.Point(0, 1);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip2.Size = new System.Drawing.Size(533, 21);
			this.toolStrip2.TabIndex = 2;
			this.toolStrip2.Text = "toolStrip2";
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel5.Text = "             CP:";
			this.tstxtNumCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumCP.Name = "tstxtNumCP";
			this.tstxtNumCP.ReadOnly = true;
			this.tstxtNumCP.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel6.Name = "toolStripLabel6";
			this.toolStripLabel6.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel6.Text = "SubTotal:";
			this.tstxtSubtotalCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalCP.Name = "tstxtSubtotalCP";
			this.tstxtSubtotalCP.ReadOnly = true;
			this.tstxtSubtotalCP.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel7.Name = "toolStripLabel7";
			this.toolStripLabel7.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel7.Text = "I.V.A:";
			this.tstxtIvaCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaCP.Name = "tstxtIvaCP";
			this.tstxtIvaCP.ReadOnly = true;
			this.tstxtIvaCP.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel18.Name = "toolStripLabel18";
			this.toolStripLabel18.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel18.Text = "ISR Retenido:";
			this.tstxtRetencionesCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCP.Name = "tstxtRetencionesCP";
			this.tstxtRetencionesCP.ReadOnly = true;
			this.tstxtRetencionesCP.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesCP.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator14.Name = "toolStripSeparator14";
			this.toolStripSeparator14.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel8.Name = "toolStripLabel8";
			this.toolStripLabel8.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel8.Text = "Total:";
			this.toolStripLabel8.Visible = false;
			this.tstxtImporteCP.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporteCP.Name = "tstxtImporteCP";
			this.tstxtImporteCP.ReadOnly = true;
			this.tstxtImporteCP.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteCP.Visible = false;
			this.flowLayoutPanel17.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel17.Controls.Add(this.toolStrip5);
			this.flowLayoutPanel17.Location = new System.Drawing.Point(1, 70);
			this.flowLayoutPanel17.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel17.Name = "flowLayoutPanel17";
			this.flowLayoutPanel17.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel17.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel17.TabIndex = 138;
			this.toolStrip5.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel20, this.tstxtNumEg, this.toolStripSeparator16, this.toolStripLabel21, this.tstxtSubtotalEg, this.toolStripSeparator17, this.toolStripLabel22, this.tstxtIvaEg, this.toolStripSeparator18, this.toolStripLabel23,
				this.tstxtRetencionesEg, this.toolStripSeparator19, this.toolStripLabel24, this.tstxtImporteEg
			});
			this.toolStrip5.Location = new System.Drawing.Point(0, 1);
			this.toolStrip5.Name = "toolStrip5";
			this.toolStrip5.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip5.Size = new System.Drawing.Size(533, 21);
			this.toolStrip5.TabIndex = 2;
			this.toolStrip5.Text = "toolStrip5";
			this.toolStripLabel20.Name = "toolStripLabel20";
			this.toolStripLabel20.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel20.Text = "  - Egresos:";
			this.tstxtNumEg.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumEg.Name = "tstxtNumEg";
			this.tstxtNumEg.ReadOnly = true;
			this.tstxtNumEg.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator16.Name = "toolStripSeparator16";
			this.toolStripSeparator16.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel21.Name = "toolStripLabel21";
			this.toolStripLabel21.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel21.Text = "SubTotal:";
			this.tstxtSubtotalEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEg.Name = "tstxtSubtotalEg";
			this.tstxtSubtotalEg.ReadOnly = true;
			this.tstxtSubtotalEg.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator17.Name = "toolStripSeparator17";
			this.toolStripSeparator17.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel22.Name = "toolStripLabel22";
			this.toolStripLabel22.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel22.Text = "I.V.A:";
			this.tstxtIvaEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEg.Name = "tstxtIvaEg";
			this.tstxtIvaEg.ReadOnly = true;
			this.tstxtIvaEg.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator18.Name = "toolStripSeparator18";
			this.toolStripSeparator18.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel23.Name = "toolStripLabel23";
			this.toolStripLabel23.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel23.Text = "ISR Retenido:";
			this.tstxtRetencionesEg.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesEg.Name = "tstxtRetencionesEg";
			this.tstxtRetencionesEg.ReadOnly = true;
			this.tstxtRetencionesEg.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesEg.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator19.Name = "toolStripSeparator19";
			this.toolStripSeparator19.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel24.Name = "toolStripLabel24";
			this.toolStripLabel24.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel24.Text = "Total:";
			this.toolStripLabel24.Visible = false;
			this.tstxtImporteEg.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteEg.Name = "tstxtImporteEg";
			this.tstxtImporteEg.ReadOnly = true;
			this.tstxtImporteEg.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteEg.Visible = false;
			this.flowLayoutPanel19.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel19.Controls.Add(this.toolStrip3);
			this.flowLayoutPanel19.Location = new System.Drawing.Point(1, 96);
			this.flowLayoutPanel19.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel19.Name = "flowLayoutPanel19";
			this.flowLayoutPanel19.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel19.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel19.TabIndex = 137;
			this.toolStrip3.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel9, this.tstxtNumTotal, this.toolStripSeparator7, this.toolStripLabel10, this.tstxtSubtotalTotal, this.toolStripSeparator8, this.toolStripLabel11, this.tstxtIvaTotal, this.toolStripSeparator9, this.toolStripLabel19,
				this.tstxtRetencionesTotal, this.toolStripSeparator15, this.toolStripLabel12, this.tstxtImporteTotal
			});
			this.toolStrip3.Location = new System.Drawing.Point(0, 1);
			this.toolStrip3.Name = "toolStrip3";
			this.toolStrip3.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip3.Size = new System.Drawing.Size(533, 21);
			this.toolStrip3.TabIndex = 2;
			this.toolStrip3.Text = "toolStrip3";
			this.toolStripLabel9.Name = "toolStripLabel9";
			this.toolStripLabel9.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel9.Text = "Total Flujo:";
			this.tstxtNumTotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumTotal.Name = "tstxtNumTotal";
			this.tstxtNumTotal.ReadOnly = true;
			this.tstxtNumTotal.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel10.Name = "toolStripLabel10";
			this.toolStripLabel10.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel10.Text = "SubTotal:";
			this.tstxtSubtotalTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotal.Name = "tstxtSubtotalTotal";
			this.tstxtSubtotalTotal.ReadOnly = true;
			this.tstxtSubtotalTotal.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel11.Name = "toolStripLabel11";
			this.toolStripLabel11.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel11.Text = "I.V.A:";
			this.tstxtIvaTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotal.Name = "tstxtIvaTotal";
			this.tstxtIvaTotal.ReadOnly = true;
			this.tstxtIvaTotal.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel19.Name = "toolStripLabel19";
			this.toolStripLabel19.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel19.Text = "ISR Retenido:";
			this.tstxtRetencionesTotal.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotal.Name = "tstxtRetencionesTotal";
			this.tstxtRetencionesTotal.ReadOnly = true;
			this.tstxtRetencionesTotal.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesTotal.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator15.Name = "toolStripSeparator15";
			this.toolStripSeparator15.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel12.Name = "toolStripLabel12";
			this.toolStripLabel12.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel12.Text = "Total:";
			this.toolStripLabel12.Visible = false;
			this.tstxtImporteTotal.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteTotal.Name = "tstxtImporteTotal";
			this.tstxtImporteTotal.ReadOnly = true;
			this.tstxtImporteTotal.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteTotal.Visible = false;
			this.flpRecibidosMensual.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpRecibidosMensual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpRecibidosMensual.Controls.Add(this.label21);
			this.flpRecibidosMensual.Controls.Add(this.flowLayoutPanel27);
			this.flpRecibidosMensual.Controls.Add(this.flowLayoutPanel29);
			this.flpRecibidosMensual.Controls.Add(this.flowLayoutPanel30);
			this.flpRecibidosMensual.Controls.Add(this.flowLayoutPanel31);
			this.flpRecibidosMensual.Controls.Add(this.flowLayoutPanel32);
			this.flpRecibidosMensual.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpRecibidosMensual.Location = new System.Drawing.Point(1, 133);
			this.flpRecibidosMensual.Margin = new System.Windows.Forms.Padding(1);
			this.flpRecibidosMensual.Name = "flpRecibidosMensual";
			this.flpRecibidosMensual.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpRecibidosMensual.Size = new System.Drawing.Size(580, 164);
			this.flpRecibidosMensual.TabIndex = 145;
			this.flpRecibidosMensual.Visible = false;
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label21.Location = new System.Drawing.Point(2, 1);
			this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(140, 16);
			this.label21.TabIndex = 141;
			this.label21.Text = "Flujo CFDI's RECIBIDOS ";
			this.flowLayoutPanel27.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel27.Controls.Add(this.toolStrip9);
			this.flowLayoutPanel27.Location = new System.Drawing.Point(1, 18);
			this.flowLayoutPanel27.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel27.Name = "flowLayoutPanel27";
			this.flowLayoutPanel27.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel27.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel27.TabIndex = 135;
			this.toolStrip9.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel41, this.tstxtNumPUEe, this.toolStripSeparator33, this.toolStripLabel42, this.tstxtSubtotalPUEe, this.toolStripSeparator34, this.toolStripLabel43, this.tstxtIvaPUEe, this.toolStripSeparator35, this.toolStripLabel44,
				this.tstxtRetencionesPUEe, this.toolStripSeparator36, this.toolStripLabel45, this.tstxtImportePUEe
			});
			this.toolStrip9.Location = new System.Drawing.Point(0, 1);
			this.toolStrip9.Name = "toolStrip9";
			this.toolStrip9.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip9.Size = new System.Drawing.Size(557, 21);
			this.toolStrip9.TabIndex = 2;
			this.toolStrip9.Text = "toolStrip9";
			this.toolStripLabel41.Name = "toolStripLabel41";
			this.toolStripLabel41.Size = new System.Drawing.Size(88, 18);
			this.toolStripLabel41.Text = "                   PUE:";
			this.tstxtNumPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUEe.Name = "tstxtNumPUEe";
			this.tstxtNumPUEe.ReadOnly = true;
			this.tstxtNumPUEe.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator33.Name = "toolStripSeparator33";
			this.toolStripSeparator33.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel42.Name = "toolStripLabel42";
			this.toolStripLabel42.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel42.Text = "SubTotal:";
			this.tstxtSubtotalPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUEe.Name = "tstxtSubtotalPUEe";
			this.tstxtSubtotalPUEe.ReadOnly = true;
			this.tstxtSubtotalPUEe.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator34.Name = "toolStripSeparator34";
			this.toolStripSeparator34.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel43.Name = "toolStripLabel43";
			this.toolStripLabel43.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel43.Text = "I.V.A:";
			this.tstxtIvaPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUEe.Name = "tstxtIvaPUEe";
			this.tstxtIvaPUEe.ReadOnly = true;
			this.tstxtIvaPUEe.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator35.Name = "toolStripSeparator35";
			this.toolStripSeparator35.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel44.Name = "toolStripLabel44";
			this.toolStripLabel44.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel44.Text = "ISR Retenido:";
			this.tstxtRetencionesPUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUEe.Name = "tstxtRetencionesPUEe";
			this.tstxtRetencionesPUEe.ReadOnly = true;
			this.tstxtRetencionesPUEe.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesPUEe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator36.Name = "toolStripSeparator36";
			this.toolStripSeparator36.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel45.Name = "toolStripLabel45";
			this.toolStripLabel45.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel45.Text = "Total:";
			this.toolStripLabel45.Visible = false;
			this.tstxtImportePUEe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImportePUEe.Name = "tstxtImportePUEe";
			this.tstxtImportePUEe.ReadOnly = true;
			this.tstxtImportePUEe.Size = new System.Drawing.Size(39, 21);
			this.tstxtImportePUEe.Visible = false;
			this.flowLayoutPanel29.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel29.Controls.Add(this.toolStrip10);
			this.flowLayoutPanel29.Location = new System.Drawing.Point(1, 44);
			this.flowLayoutPanel29.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel29.Name = "flowLayoutPanel29";
			this.flowLayoutPanel29.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel29.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel29.TabIndex = 136;
			this.toolStrip10.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel46, this.tstxtNumCPe, this.toolStripSeparator37, this.toolStripLabel47, this.tstxtSubtotalCPe, this.toolStripSeparator38, this.toolStripLabel48, this.tstxtIvaCPe, this.toolStripSeparator39, this.toolStripLabel49,
				this.tstxtRetencionesCPe, this.toolStripSeparator40, this.toolStripLabel50, this.tstxtImporteCPe
			});
			this.toolStrip10.Location = new System.Drawing.Point(0, 1);
			this.toolStrip10.Name = "toolStrip10";
			this.toolStrip10.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip10.Size = new System.Drawing.Size(557, 21);
			this.toolStrip10.TabIndex = 2;
			this.toolStrip10.Text = "toolStrip10";
			this.toolStripLabel46.Name = "toolStripLabel46";
			this.toolStripLabel46.Size = new System.Drawing.Size(88, 18);
			this.toolStripLabel46.Text = "                     CP:";
			this.tstxtNumCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumCPe.Name = "tstxtNumCPe";
			this.tstxtNumCPe.ReadOnly = true;
			this.tstxtNumCPe.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator37.Name = "toolStripSeparator37";
			this.toolStripSeparator37.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel47.Name = "toolStripLabel47";
			this.toolStripLabel47.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel47.Text = "SubTotal:";
			this.tstxtSubtotalCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalCPe.Name = "tstxtSubtotalCPe";
			this.tstxtSubtotalCPe.ReadOnly = true;
			this.tstxtSubtotalCPe.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator38.Name = "toolStripSeparator38";
			this.toolStripSeparator38.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel48.Name = "toolStripLabel48";
			this.toolStripLabel48.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel48.Text = "I.V.A:";
			this.tstxtIvaCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaCPe.Name = "tstxtIvaCPe";
			this.tstxtIvaCPe.ReadOnly = true;
			this.tstxtIvaCPe.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator39.Name = "toolStripSeparator39";
			this.toolStripSeparator39.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel49.Name = "toolStripLabel49";
			this.toolStripLabel49.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel49.Text = "ISR Retenido:";
			this.tstxtRetencionesCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCPe.Name = "tstxtRetencionesCPe";
			this.tstxtRetencionesCPe.ReadOnly = true;
			this.tstxtRetencionesCPe.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesCPe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator40.Name = "toolStripSeparator40";
			this.toolStripSeparator40.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel50.Name = "toolStripLabel50";
			this.toolStripLabel50.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel50.Text = "Total:";
			this.toolStripLabel50.Visible = false;
			this.tstxtImporteCPe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtImporteCPe.Name = "tstxtImporteCPe";
			this.tstxtImporteCPe.ReadOnly = true;
			this.tstxtImporteCPe.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteCPe.Visible = false;
			this.flowLayoutPanel30.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel30.Controls.Add(this.toolStrip11);
			this.flowLayoutPanel30.Location = new System.Drawing.Point(1, 70);
			this.flowLayoutPanel30.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel30.Name = "flowLayoutPanel30";
			this.flowLayoutPanel30.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel30.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel30.TabIndex = 138;
			this.toolStrip11.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel51, this.tstxtNumEge, this.toolStripSeparator41, this.toolStripLabel52, this.tstxtSubtotalEge, this.toolStripSeparator42, this.toolStripLabel53, this.tstxtIvaEge, this.toolStripSeparator43, this.toolStripLabel54,
				this.tstxtRetencionesEge, this.toolStripSeparator44, this.toolStripLabel55, this.tstxtImporteEge
			});
			this.toolStrip11.Location = new System.Drawing.Point(0, 1);
			this.toolStrip11.Name = "toolStrip11";
			this.toolStrip11.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip11.Size = new System.Drawing.Size(557, 21);
			this.toolStrip11.TabIndex = 2;
			this.toolStrip11.Text = "toolStrip11";
			this.toolStripLabel51.Name = "toolStripLabel51";
			this.toolStripLabel51.Size = new System.Drawing.Size(88, 18);
			this.toolStripLabel51.Text = "          - Egresos:";
			this.tstxtNumEge.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumEge.Name = "tstxtNumEge";
			this.tstxtNumEge.ReadOnly = true;
			this.tstxtNumEge.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator41.Name = "toolStripSeparator41";
			this.toolStripSeparator41.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel52.Name = "toolStripLabel52";
			this.toolStripLabel52.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel52.Text = "SubTotal:";
			this.tstxtSubtotalEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEge.Name = "tstxtSubtotalEge";
			this.tstxtSubtotalEge.ReadOnly = true;
			this.tstxtSubtotalEge.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator42.Name = "toolStripSeparator42";
			this.toolStripSeparator42.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel53.Name = "toolStripLabel53";
			this.toolStripLabel53.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel53.Text = "I.V.A:";
			this.tstxtIvaEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEge.Name = "tstxtIvaEge";
			this.tstxtIvaEge.ReadOnly = true;
			this.tstxtIvaEge.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator43.Name = "toolStripSeparator43";
			this.toolStripSeparator43.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel54.Name = "toolStripLabel54";
			this.toolStripLabel54.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel54.Text = "ISR Retenido:";
			this.tstxtRetencionesEge.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesEge.Name = "tstxtRetencionesEge";
			this.tstxtRetencionesEge.ReadOnly = true;
			this.tstxtRetencionesEge.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesEge.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator44.Name = "toolStripSeparator44";
			this.toolStripSeparator44.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel55.Name = "toolStripLabel55";
			this.toolStripLabel55.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel55.Text = "Total:";
			this.toolStripLabel55.Visible = false;
			this.tstxtImporteEge.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteEge.Name = "tstxtImporteEge";
			this.tstxtImporteEge.ReadOnly = true;
			this.tstxtImporteEge.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteEge.Visible = false;
			this.flowLayoutPanel31.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel31.Controls.Add(this.toolStrip12);
			this.flowLayoutPanel31.Location = new System.Drawing.Point(1, 96);
			this.flowLayoutPanel31.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel31.Name = "flowLayoutPanel31";
			this.flowLayoutPanel31.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel31.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel31.TabIndex = 139;
			this.toolStrip12.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel56, this.tstxtNumNDe, this.toolStripSeparator45, this.toolStripLabel57, this.tstxtSubtotalNDe, this.toolStripSeparator46, this.toolStripLabel58, this.tstxtIvaNDe, this.toolStripSeparator47, this.toolStripLabel59,
				this.tstxtRetencionesNDe, this.toolStripSeparator48, this.toolStripLabel60, this.tstxtImporteNDe
			});
			this.toolStrip12.Location = new System.Drawing.Point(0, 1);
			this.toolStrip12.Name = "toolStrip12";
			this.toolStrip12.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip12.Size = new System.Drawing.Size(559, 21);
			this.toolStrip12.TabIndex = 2;
			this.toolStrip12.Text = "toolStrip12";
			this.toolStripLabel56.Name = "toolStripLabel56";
			this.toolStripLabel56.Size = new System.Drawing.Size(90, 18);
			this.toolStripLabel56.Text = "- No Deducible:";
			this.tstxtNumNDe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumNDe.Name = "tstxtNumNDe";
			this.tstxtNumNDe.ReadOnly = true;
			this.tstxtNumNDe.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator45.Name = "toolStripSeparator45";
			this.toolStripSeparator45.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel57.Name = "toolStripLabel57";
			this.toolStripLabel57.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel57.Text = "SubTotal:";
			this.tstxtSubtotalNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalNDe.Name = "tstxtSubtotalNDe";
			this.tstxtSubtotalNDe.ReadOnly = true;
			this.tstxtSubtotalNDe.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator46.Name = "toolStripSeparator46";
			this.toolStripSeparator46.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel58.Name = "toolStripLabel58";
			this.toolStripLabel58.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel58.Text = "I.V.A:";
			this.tstxtIvaNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaNDe.Name = "tstxtIvaNDe";
			this.tstxtIvaNDe.ReadOnly = true;
			this.tstxtIvaNDe.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator47.Name = "toolStripSeparator47";
			this.toolStripSeparator47.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel59.Name = "toolStripLabel59";
			this.toolStripLabel59.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel59.Text = "ISR Retenido:";
			this.tstxtRetencionesNDe.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesNDe.Name = "tstxtRetencionesNDe";
			this.tstxtRetencionesNDe.ReadOnly = true;
			this.tstxtRetencionesNDe.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesNDe.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator48.Name = "toolStripSeparator48";
			this.toolStripSeparator48.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel60.Name = "toolStripLabel60";
			this.toolStripLabel60.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel60.Text = "Total:";
			this.toolStripLabel60.Visible = false;
			this.tstxtImporteNDe.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteNDe.Name = "tstxtImporteNDe";
			this.tstxtImporteNDe.ReadOnly = true;
			this.tstxtImporteNDe.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteNDe.Visible = false;
			this.flowLayoutPanel32.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel32.Controls.Add(this.toolStrip13);
			this.flowLayoutPanel32.Location = new System.Drawing.Point(1, 122);
			this.flowLayoutPanel32.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel32.Name = "flowLayoutPanel32";
			this.flowLayoutPanel32.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel32.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel32.TabIndex = 137;
			this.toolStrip13.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip13.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel61, this.tstxtNumTotale, this.toolStripSeparator49, this.toolStripLabel62, this.tstxtSubtotalTotale, this.toolStripSeparator50, this.toolStripLabel63, this.tstxtIvaTotale, this.toolStripSeparator51, this.toolStripLabel64,
				this.tstxtRetencionesTotale, this.toolStripSeparator52, this.toolStripLabel65, this.tstxtImporteTotale
			});
			this.toolStrip13.Location = new System.Drawing.Point(0, 1);
			this.toolStrip13.Name = "toolStrip13";
			this.toolStrip13.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip13.Size = new System.Drawing.Size(557, 21);
			this.toolStrip13.TabIndex = 2;
			this.toolStrip13.Text = "toolStrip13";
			this.toolStripLabel61.Name = "toolStripLabel61";
			this.toolStripLabel61.Size = new System.Drawing.Size(88, 18);
			this.toolStripLabel61.Text = "        Total Flujo:";
			this.tstxtNumTotale.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumTotale.Name = "tstxtNumTotale";
			this.tstxtNumTotale.ReadOnly = true;
			this.tstxtNumTotale.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator49.Name = "toolStripSeparator49";
			this.toolStripSeparator49.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel62.Name = "toolStripLabel62";
			this.toolStripLabel62.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel62.Text = "SubTotal:";
			this.tstxtSubtotalTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotale.Name = "tstxtSubtotalTotale";
			this.tstxtSubtotalTotale.ReadOnly = true;
			this.tstxtSubtotalTotale.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator50.Name = "toolStripSeparator50";
			this.toolStripSeparator50.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel63.Name = "toolStripLabel63";
			this.toolStripLabel63.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel63.Text = "I.V.A:";
			this.tstxtIvaTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotale.Name = "tstxtIvaTotale";
			this.tstxtIvaTotale.ReadOnly = true;
			this.tstxtIvaTotale.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator51.Name = "toolStripSeparator51";
			this.toolStripSeparator51.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel64.Name = "toolStripLabel64";
			this.toolStripLabel64.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel64.Text = "ISR Retenido:";
			this.tstxtRetencionesTotale.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotale.Name = "tstxtRetencionesTotale";
			this.tstxtRetencionesTotale.ReadOnly = true;
			this.tstxtRetencionesTotale.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesTotale.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator52.Name = "toolStripSeparator52";
			this.toolStripSeparator52.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel65.Name = "toolStripLabel65";
			this.toolStripLabel65.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel65.Text = "Total:";
			this.toolStripLabel65.Visible = false;
			this.tstxtImporteTotale.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtImporteTotale.Name = "tstxtImporteTotale";
			this.tstxtImporteTotale.ReadOnly = true;
			this.tstxtImporteTotale.Size = new System.Drawing.Size(39, 21);
			this.tstxtImporteTotale.Visible = false;
			this.flpEmitidosAnual.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.flpEmitidosAnual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flpEmitidosAnual.Controls.Add(this.label16);
			this.flpEmitidosAnual.Controls.Add(this.flowLayoutPanel15);
			this.flpEmitidosAnual.Controls.Add(this.flowLayoutPanel18);
			this.flpEmitidosAnual.Controls.Add(this.flowLayoutPanel20);
			this.flpEmitidosAnual.Controls.Add(this.flowLayoutPanel21);
			this.flpEmitidosAnual.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.flpEmitidosAnual.Location = new System.Drawing.Point(1, 299);
			this.flpEmitidosAnual.Margin = new System.Windows.Forms.Padding(1);
			this.flpEmitidosAnual.Name = "flpEmitidosAnual";
			this.flpEmitidosAnual.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flpEmitidosAnual.Size = new System.Drawing.Size(579, 130);
			this.flpEmitidosAnual.TabIndex = 144;
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new System.Drawing.Point(2, 1);
			this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(175, 16);
			this.label16.TabIndex = 140;
			this.label16.Text = "Flujo CFDI's EMITIDOS ANUAL";
			this.flowLayoutPanel15.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel15.Controls.Add(this.toolStrip4);
			this.flowLayoutPanel15.Location = new System.Drawing.Point(1, 18);
			this.flowLayoutPanel15.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel15.Name = "flowLayoutPanel15";
			this.flowLayoutPanel15.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel15.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel15.TabIndex = 135;
			this.toolStrip4.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel13, this.tstxtNumPUEAnual, this.toolStripSeparator10, this.toolStripLabel14, this.tstxtSubtotalPUEAnual, this.toolStripSeparator11, this.toolStripLabel15, this.tstxtIvaPUEAnual, this.toolStripSeparator12, this.toolStripLabel16,
				this.tstxtRetencionesPUEAnual, this.toolStripSeparator20, this.toolStripLabel25, this.toolStripTextBox1
			});
			this.toolStrip4.Location = new System.Drawing.Point(0, 1);
			this.toolStrip4.Name = "toolStrip4";
			this.toolStrip4.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip4.Size = new System.Drawing.Size(533, 21);
			this.toolStrip4.TabIndex = 2;
			this.toolStrip4.Text = "toolStrip4";
			this.toolStripLabel13.Name = "toolStripLabel13";
			this.toolStripLabel13.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel13.Text = "           PUE:";
			this.tstxtNumPUEAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumPUEAnual.Name = "tstxtNumPUEAnual";
			this.tstxtNumPUEAnual.ReadOnly = true;
			this.tstxtNumPUEAnual.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumPUEAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel14.Name = "toolStripLabel14";
			this.toolStripLabel14.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel14.Text = "SubTotal:";
			this.tstxtSubtotalPUEAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalPUEAnual.Name = "tstxtSubtotalPUEAnual";
			this.tstxtSubtotalPUEAnual.ReadOnly = true;
			this.tstxtSubtotalPUEAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalPUEAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel15.Name = "toolStripLabel15";
			this.toolStripLabel15.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel15.Text = "I.V.A:";
			this.tstxtIvaPUEAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaPUEAnual.Name = "tstxtIvaPUEAnual";
			this.tstxtIvaPUEAnual.ReadOnly = true;
			this.tstxtIvaPUEAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaPUEAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator12.Name = "toolStripSeparator12";
			this.toolStripSeparator12.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel16.Name = "toolStripLabel16";
			this.toolStripLabel16.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel16.Text = "ISR Retenido:";
			this.tstxtRetencionesPUEAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesPUEAnual.Name = "tstxtRetencionesPUEAnual";
			this.tstxtRetencionesPUEAnual.ReadOnly = true;
			this.tstxtRetencionesPUEAnual.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesPUEAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator20.Name = "toolStripSeparator20";
			this.toolStripSeparator20.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel25.Name = "toolStripLabel25";
			this.toolStripLabel25.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel25.Text = "Total:";
			this.toolStripLabel25.Visible = false;
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.ReadOnly = true;
			this.toolStripTextBox1.Size = new System.Drawing.Size(39, 21);
			this.toolStripTextBox1.Visible = false;
			this.flowLayoutPanel18.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel18.Controls.Add(this.toolStrip6);
			this.flowLayoutPanel18.Location = new System.Drawing.Point(1, 44);
			this.flowLayoutPanel18.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel18.Name = "flowLayoutPanel18";
			this.flowLayoutPanel18.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel18.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel18.TabIndex = 136;
			this.toolStrip6.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel26, this.tstxtNumCPAnual, this.toolStripSeparator21, this.toolStripLabel27, this.tstxtSubtotalCPAnual, this.toolStripSeparator22, this.toolStripLabel28, this.tstxtIvaCPAnual, this.toolStripSeparator23, this.toolStripLabel29,
				this.tstxtRetencionesCPAnual, this.toolStripSeparator24, this.toolStripLabel30, this.toolStripTextBox2
			});
			this.toolStrip6.Location = new System.Drawing.Point(0, 1);
			this.toolStrip6.Name = "toolStrip6";
			this.toolStrip6.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip6.Size = new System.Drawing.Size(533, 21);
			this.toolStrip6.TabIndex = 2;
			this.toolStrip6.Text = "toolStrip6";
			this.toolStripLabel26.Name = "toolStripLabel26";
			this.toolStripLabel26.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel26.Text = "             CP:";
			this.tstxtNumCPAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumCPAnual.Name = "tstxtNumCPAnual";
			this.tstxtNumCPAnual.ReadOnly = true;
			this.tstxtNumCPAnual.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumCPAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator21.Name = "toolStripSeparator21";
			this.toolStripSeparator21.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel27.Name = "toolStripLabel27";
			this.toolStripLabel27.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel27.Text = "SubTotal:";
			this.tstxtSubtotalCPAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtSubtotalCPAnual.Name = "tstxtSubtotalCPAnual";
			this.tstxtSubtotalCPAnual.ReadOnly = true;
			this.tstxtSubtotalCPAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalCPAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator22.Name = "toolStripSeparator22";
			this.toolStripSeparator22.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel28.Name = "toolStripLabel28";
			this.toolStripLabel28.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel28.Text = "I.V.A:";
			this.tstxtIvaCPAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtIvaCPAnual.Name = "tstxtIvaCPAnual";
			this.tstxtIvaCPAnual.ReadOnly = true;
			this.tstxtIvaCPAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaCPAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator23.Name = "toolStripSeparator23";
			this.toolStripSeparator23.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel29.Name = "toolStripLabel29";
			this.toolStripLabel29.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel29.Text = "ISR Retenido:";
			this.tstxtRetencionesCPAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesCPAnual.Name = "tstxtRetencionesCPAnual";
			this.tstxtRetencionesCPAnual.ReadOnly = true;
			this.tstxtRetencionesCPAnual.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesCPAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator24.Name = "toolStripSeparator24";
			this.toolStripSeparator24.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel30.Name = "toolStripLabel30";
			this.toolStripLabel30.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel30.Text = "Total:";
			this.toolStripLabel30.Visible = false;
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(39, 21);
			this.toolStripTextBox2.Visible = false;
			this.flowLayoutPanel20.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel20.Controls.Add(this.toolStrip7);
			this.flowLayoutPanel20.Location = new System.Drawing.Point(1, 70);
			this.flowLayoutPanel20.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel20.Name = "flowLayoutPanel20";
			this.flowLayoutPanel20.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel20.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel20.TabIndex = 138;
			this.toolStrip7.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel31, this.tstxtNumEgAnual, this.toolStripSeparator25, this.toolStripLabel32, this.tstxtSubtotalEgAnual, this.toolStripSeparator26, this.toolStripLabel33, this.tstxtIvaEgAnual, this.toolStripSeparator27, this.toolStripLabel34,
				this.tstxtRetencionesEgAnual, this.toolStripSeparator28, this.toolStripLabel35, this.toolStripTextBox3
			});
			this.toolStrip7.Location = new System.Drawing.Point(0, 1);
			this.toolStrip7.Name = "toolStrip7";
			this.toolStrip7.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip7.Size = new System.Drawing.Size(533, 21);
			this.toolStrip7.TabIndex = 2;
			this.toolStrip7.Text = "toolStrip7";
			this.toolStripLabel31.Name = "toolStripLabel31";
			this.toolStripLabel31.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel31.Text = "  - Egresos:";
			this.tstxtNumEgAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumEgAnual.Name = "tstxtNumEgAnual";
			this.tstxtNumEgAnual.ReadOnly = true;
			this.tstxtNumEgAnual.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumEgAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator25.Name = "toolStripSeparator25";
			this.toolStripSeparator25.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel32.Name = "toolStripLabel32";
			this.toolStripLabel32.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel32.Text = "SubTotal:";
			this.tstxtSubtotalEgAnual.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalEgAnual.Name = "tstxtSubtotalEgAnual";
			this.tstxtSubtotalEgAnual.ReadOnly = true;
			this.tstxtSubtotalEgAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalEgAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator26.Name = "toolStripSeparator26";
			this.toolStripSeparator26.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel33.Name = "toolStripLabel33";
			this.toolStripLabel33.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel33.Text = "I.V.A:";
			this.tstxtIvaEgAnual.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaEgAnual.Name = "tstxtIvaEgAnual";
			this.tstxtIvaEgAnual.ReadOnly = true;
			this.tstxtIvaEgAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaEgAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator27.Name = "toolStripSeparator27";
			this.toolStripSeparator27.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel34.Name = "toolStripLabel34";
			this.toolStripLabel34.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel34.Text = "ISR Retenido:";
			this.tstxtRetencionesEgAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesEgAnual.Name = "tstxtRetencionesEgAnual";
			this.tstxtRetencionesEgAnual.ReadOnly = true;
			this.tstxtRetencionesEgAnual.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesEgAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator28.Name = "toolStripSeparator28";
			this.toolStripSeparator28.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel35.Name = "toolStripLabel35";
			this.toolStripLabel35.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel35.Text = "Total:";
			this.toolStripLabel35.Visible = false;
			this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.toolStripTextBox3.Name = "toolStripTextBox3";
			this.toolStripTextBox3.ReadOnly = true;
			this.toolStripTextBox3.Size = new System.Drawing.Size(39, 21);
			this.toolStripTextBox3.Visible = false;
			this.flowLayoutPanel21.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.flowLayoutPanel21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.flowLayoutPanel21.Controls.Add(this.toolStrip8);
			this.flowLayoutPanel21.Location = new System.Drawing.Point(1, 96);
			this.flowLayoutPanel21.Margin = new System.Windows.Forms.Padding(1);
			this.flowLayoutPanel21.Name = "flowLayoutPanel21";
			this.flowLayoutPanel21.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.flowLayoutPanel21.Size = new System.Drawing.Size(768, 24);
			this.flowLayoutPanel21.TabIndex = 137;
			this.toolStrip8.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
			{
				this.toolStripLabel36, this.tstxtNumTotalAnual, this.toolStripSeparator29, this.toolStripLabel37, this.tstxtSubtotalTotalAnual, this.toolStripSeparator30, this.toolStripLabel38, this.tstxtIvaTotalAnual, this.toolStripSeparator31, this.toolStripLabel39,
				this.tstxtRetencionesTotalAnual, this.toolStripSeparator32, this.toolStripLabel40, this.toolStripTextBox4
			});
			this.toolStrip8.Location = new System.Drawing.Point(0, 1);
			this.toolStrip8.Name = "toolStrip8";
			this.toolStrip8.Padding = new System.Windows.Forms.Padding(0);
			this.toolStrip8.Size = new System.Drawing.Size(533, 21);
			this.toolStrip8.TabIndex = 2;
			this.toolStrip8.Text = "toolStrip8";
			this.toolStripLabel36.Name = "toolStripLabel36";
			this.toolStripLabel36.Size = new System.Drawing.Size(64, 18);
			this.toolStripLabel36.Text = "Total Flujo:";
			this.tstxtNumTotalAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtNumTotalAnual.Name = "tstxtNumTotalAnual";
			this.tstxtNumTotalAnual.ReadOnly = true;
			this.tstxtNumTotalAnual.Size = new System.Drawing.Size(36, 21);
			this.tstxtNumTotalAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator29.Name = "toolStripSeparator29";
			this.toolStripSeparator29.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel37.Name = "toolStripLabel37";
			this.toolStripLabel37.Size = new System.Drawing.Size(55, 18);
			this.toolStripLabel37.Text = "SubTotal:";
			this.tstxtSubtotalTotalAnual.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtSubtotalTotalAnual.Name = "tstxtSubtotalTotalAnual";
			this.tstxtSubtotalTotalAnual.ReadOnly = true;
			this.tstxtSubtotalTotalAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtSubtotalTotalAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator30.Name = "toolStripSeparator30";
			this.toolStripSeparator30.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel38.Name = "toolStripLabel38";
			this.toolStripLabel38.Size = new System.Drawing.Size(34, 18);
			this.toolStripLabel38.Text = "I.V.A:";
			this.tstxtIvaTotalAnual.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.tstxtIvaTotalAnual.Name = "tstxtIvaTotalAnual";
			this.tstxtIvaTotalAnual.ReadOnly = true;
			this.tstxtIvaTotalAnual.Size = new System.Drawing.Size(82, 21);
			this.tstxtIvaTotalAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator31.Name = "toolStripSeparator31";
			this.toolStripSeparator31.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel39.Name = "toolStripLabel39";
			this.toolStripLabel39.Size = new System.Drawing.Size(76, 18);
			this.toolStripLabel39.Text = "ISR Retenido:";
			this.tstxtRetencionesTotalAnual.Font = new System.Drawing.Font("Segoe UI", 9f);
			this.tstxtRetencionesTotalAnual.Name = "tstxtRetencionesTotalAnual";
			this.tstxtRetencionesTotalAnual.ReadOnly = true;
			this.tstxtRetencionesTotalAnual.Size = new System.Drawing.Size(61, 21);
			this.tstxtRetencionesTotalAnual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolStripSeparator32.Name = "toolStripSeparator32";
			this.toolStripSeparator32.Size = new System.Drawing.Size(6, 21);
			this.toolStripLabel40.Name = "toolStripLabel40";
			this.toolStripLabel40.Size = new System.Drawing.Size(35, 18);
			this.toolStripLabel40.Text = "Total:";
			this.toolStripLabel40.Visible = false;
			this.toolStripTextBox4.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
			this.toolStripTextBox4.Name = "toolStripTextBox4";
			this.toolStripTextBox4.ReadOnly = true;
			this.toolStripTextBox4.Size = new System.Drawing.Size(39, 21);
			this.toolStripTextBox4.Visible = false;
			this.gvNominas.AllowUserToAddRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64);
			this.gvNominas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.gvNominas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.gvNominas.AutoGenerateColumns = false;
			this.gvNominas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.gvNominas.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.gvNominas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.gvNominas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvNominas.Columns.AddRange(this.dataGridViewTextBoxColumn31, this.dataGridViewTextBoxColumn32, this.dataGridViewTextBoxColumn33, this.dataGridViewTextBoxColumn34, this.dataGridViewTextBoxColumn35, this.dataGridViewTextBoxColumn39, this.TotalPercepciones, this.TotalDeducciones, this.dataGridViewTextBoxColumn40);
			this.gvNominas.DataSource = this.entFacturaBindingSource;
			this.gvNominas.Location = new System.Drawing.Point(3, 433);
			this.gvNominas.Name = "gvNominas";
			this.gvNominas.ReadOnly = true;
			this.gvNominas.RowHeadersVisible = false;
			this.gvNominas.RowHeadersWidth = 51;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
			this.gvNominas.RowsDefaultCellStyle = dataGridViewCellStyle7;
			this.gvNominas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.gvNominas.Size = new System.Drawing.Size(574, 160);
			this.gvNominas.TabIndex = 146;
			this.gvNominas.Visible = false;
			this.dataGridViewTextBoxColumn31.DataPropertyName = "RFC";
			this.dataGridViewTextBoxColumn31.FillWeight = 150f;
			this.dataGridViewTextBoxColumn31.HeaderText = "RFC";
			this.dataGridViewTextBoxColumn31.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
			this.dataGridViewTextBoxColumn31.ReadOnly = true;
			this.dataGridViewTextBoxColumn32.DataPropertyName = "Nombre";
			this.dataGridViewTextBoxColumn32.FillWeight = 250f;
			this.dataGridViewTextBoxColumn32.HeaderText = "Nombre";
			this.dataGridViewTextBoxColumn32.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
			this.dataGridViewTextBoxColumn32.ReadOnly = true;
			this.dataGridViewTextBoxColumn33.DataPropertyName = "UUID";
			this.dataGridViewTextBoxColumn33.FillWeight = 200f;
			this.dataGridViewTextBoxColumn33.HeaderText = "UUID";
			this.dataGridViewTextBoxColumn33.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
			this.dataGridViewTextBoxColumn33.ReadOnly = true;
			this.dataGridViewTextBoxColumn34.DataPropertyName = "Folio";
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			this.dataGridViewTextBoxColumn34.DefaultCellStyle = dataGridViewCellStyle8;
			this.dataGridViewTextBoxColumn34.HeaderText = "Folio";
			this.dataGridViewTextBoxColumn34.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
			this.dataGridViewTextBoxColumn34.ReadOnly = true;
			this.dataGridViewTextBoxColumn35.DataPropertyName = "SubTotal";
			dataGridViewCellStyle9.Format = "c4";
			this.dataGridViewTextBoxColumn35.DefaultCellStyle = dataGridViewCellStyle9;
			this.dataGridViewTextBoxColumn35.HeaderText = "SubTotal";
			this.dataGridViewTextBoxColumn35.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
			this.dataGridViewTextBoxColumn35.ReadOnly = true;
			this.dataGridViewTextBoxColumn35.Visible = false;
			this.dataGridViewTextBoxColumn39.DataPropertyName = "Total";
			dataGridViewCellStyle10.Format = "c4";
			this.dataGridViewTextBoxColumn39.DefaultCellStyle = dataGridViewCellStyle10;
			this.dataGridViewTextBoxColumn39.HeaderText = "Total";
			this.dataGridViewTextBoxColumn39.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
			this.dataGridViewTextBoxColumn39.ReadOnly = true;
			this.TotalPercepciones.DataPropertyName = "TotalPercepciones";
			dataGridViewCellStyle11.Format = "c2";
			this.TotalPercepciones.DefaultCellStyle = dataGridViewCellStyle11;
			this.TotalPercepciones.HeaderText = "Total Percepciones";
			this.TotalPercepciones.MinimumWidth = 6;
			this.TotalPercepciones.Name = "TotalPercepciones";
			this.TotalPercepciones.ReadOnly = true;
			this.TotalDeducciones.DataPropertyName = "TotalDeducciones";
			dataGridViewCellStyle12.Format = "c2";
			this.TotalDeducciones.DefaultCellStyle = dataGridViewCellStyle12;
			this.TotalDeducciones.HeaderText = "Total Deducciones";
			this.TotalDeducciones.MinimumWidth = 6;
			this.TotalDeducciones.Name = "TotalDeducciones";
			this.TotalDeducciones.ReadOnly = true;
			this.dataGridViewTextBoxColumn40.DataPropertyName = "Fecha";
			this.dataGridViewTextBoxColumn40.HeaderText = "Fecha";
			this.dataGridViewTextBoxColumn40.MinimumWidth = 6;
			this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
			this.dataGridViewTextBoxColumn40.ReadOnly = true;
			this.entFacturaBindingSource.DataSource = typeof(LeeXMLEntidades.EntFactura);
			this.panel1.Controls.Add(this.btnRefrescar);
			this.panel1.Controls.Add(this.btnExportarISR);
			this.panel1.Controls.Add(this.rdoPorMesComprobantes);
			this.panel1.Controls.Add(this.pnlPorMesVentas);
			this.panel1.Location = new System.Drawing.Point(6, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(538, 58);
			this.panel1.TabIndex = 135;
			this.btnRefrescar.BackColor = System.Drawing.Color.White;
			this.btnRefrescar.BackgroundImage = LeeXML.Properties.Resources.RefrescarChico;
			this.btnRefrescar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefrescar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRefrescar.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnRefrescar.Location = new System.Drawing.Point(331, 0);
			this.btnRefrescar.Name = "btnRefrescar";
			this.btnRefrescar.Size = new System.Drawing.Size(68, 57);
			this.btnRefrescar.TabIndex = 132;
			this.btnRefrescar.Text = "Refrescar";
			this.btnRefrescar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnRefrescar.UseVisualStyleBackColor = false;
			this.btnRefrescar.Click += new System.EventHandler(btnRefrescar_Click);
			this.btnExportarISR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnExportarISR.BackColor = System.Drawing.Color.White;
			this.btnExportarISR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnExportarISR.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExportarISR.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnExportarISR.Image = LeeXML.Properties.Resources.ExportaPapel;
			this.btnExportarISR.Location = new System.Drawing.Point(412, 0);
			this.btnExportarISR.Name = "btnExportarISR";
			this.btnExportarISR.Size = new System.Drawing.Size(70, 57);
			this.btnExportarISR.TabIndex = 131;
			this.btnExportarISR.Text = "Exportar";
			this.btnExportarISR.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.btnExportarISR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.btnExportarISR.UseVisualStyleBackColor = false;
			this.btnExportarISR.Click += new System.EventHandler(btnExportarISR_Click);
			this.rdoPorMesComprobantes.AutoSize = true;
			this.rdoPorMesComprobantes.Checked = true;
			this.rdoPorMesComprobantes.Location = new System.Drawing.Point(62, 23);
			this.rdoPorMesComprobantes.Name = "rdoPorMesComprobantes";
			this.rdoPorMesComprobantes.Size = new System.Drawing.Size(61, 17);
			this.rdoPorMesComprobantes.TabIndex = 44;
			this.rdoPorMesComprobantes.TabStop = true;
			this.rdoPorMesComprobantes.Text = "Periodo:";
			this.rdoPorMesComprobantes.UseVisualStyleBackColor = true;
			this.pnlPorMesVentas.Controls.Add(this.cmbMesesComprobantes);
			this.pnlPorMesVentas.Controls.Add(this.cmbAñoComprobantes);
			this.pnlPorMesVentas.Location = new System.Drawing.Point(119, 12);
			this.pnlPorMesVentas.Name = "pnlPorMesVentas";
			this.pnlPorMesVentas.Size = new System.Drawing.Size(202, 34);
			this.pnlPorMesVentas.TabIndex = 41;
			this.cmbMesesComprobantes.DataSource = this.entCatalogoGenericoBindingSource;
			this.cmbMesesComprobantes.DisplayMember = "Descripcion";
			this.cmbMesesComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMesesComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbMesesComprobantes.Font = new System.Drawing.Font("Microsoft Tai Le", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbMesesComprobantes.FormattingEnabled = true;
			this.cmbMesesComprobantes.Location = new System.Drawing.Point(6, 6);
			this.cmbMesesComprobantes.Name = "cmbMesesComprobantes";
			this.cmbMesesComprobantes.Size = new System.Drawing.Size(190, 24);
			this.cmbMesesComprobantes.TabIndex = 19;
			this.cmbMesesComprobantes.ValueMember = "Id";
			this.entCatalogoGenericoBindingSource.DataSource = typeof(LeeXMLEntidades.EntCatalogoGenerico);
			this.cmbAñoComprobantes.DisplayMember = "Descripcion";
			this.cmbAñoComprobantes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAñoComprobantes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.cmbAñoComprobantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmbAñoComprobantes.FormattingEnabled = true;
			this.cmbAñoComprobantes.Location = new System.Drawing.Point(120, 7);
			this.cmbAñoComprobantes.Name = "cmbAñoComprobantes";
			this.cmbAñoComprobantes.Size = new System.Drawing.Size(77, 24);
			this.cmbAñoComprobantes.TabIndex = 20;
			this.cmbAñoComprobantes.ValueMember = "Descripcion";
			this.cmbAñoComprobantes.Visible = false;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(1055, 610);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 128;
			this.label3.Text = "Cantidad:";
			this.txtCantidadVentas.Enabled = false;
			this.txtCantidadVentas.Location = new System.Drawing.Point(1103, 606);
			this.txtCantidadVentas.Name = "txtCantidadVentas";
			this.txtCantidadVentas.Size = new System.Drawing.Size(55, 19);
			this.txtCantidadVentas.TabIndex = 127;
			this.tcCalculosGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCalculosGeneral.Controls.Add(this.tabPage1);
			this.tcCalculosGeneral.Controls.Add(this.tpImpresionISR);
			this.tcCalculosGeneral.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.tcCalculosGeneral.Location = new System.Drawing.Point(12, 24);
			this.tcCalculosGeneral.Name = "tcCalculosGeneral";
			this.tcCalculosGeneral.SelectedIndex = 0;
			this.tcCalculosGeneral.Size = new System.Drawing.Size(1068, 507);
			this.tcCalculosGeneral.TabIndex = 129;
			this.tcCalculosGeneral.SelectedIndexChanged += new System.EventHandler(tcPedidosGrids_SelectedIndexChanged);
			this.tpImpresionISR.Controls.Add(this.tcCalculosISRimpresion);
			this.tpImpresionISR.Location = new System.Drawing.Point(4, 23);
			this.tpImpresionISR.Margin = new System.Windows.Forms.Padding(2);
			this.tpImpresionISR.Name = "tpImpresionISR";
			this.tpImpresionISR.Padding = new System.Windows.Forms.Padding(2);
			this.tpImpresionISR.Size = new System.Drawing.Size(1060, 480);
			this.tpImpresionISR.TabIndex = 1;
			this.tpImpresionISR.Text = "Impresión";
			this.tpImpresionISR.UseVisualStyleBackColor = true;
			this.tcCalculosISRimpresion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tcCalculosISRimpresion.Controls.Add(this.tpImpresionCalculoISR);
			this.tcCalculosISRimpresion.Controls.Add(this.tabPage4);
			this.tcCalculosISRimpresion.Location = new System.Drawing.Point(0, 3);
			this.tcCalculosISRimpresion.Margin = new System.Windows.Forms.Padding(2);
			this.tcCalculosISRimpresion.Name = "tcCalculosISRimpresion";
			this.tcCalculosISRimpresion.SelectedIndex = 0;
			this.tcCalculosISRimpresion.Size = new System.Drawing.Size(924, 546);
			this.tcCalculosISRimpresion.TabIndex = 140;
			this.tpImpresionCalculoISR.Controls.Add(this.rvCalculoISR);
			this.tpImpresionCalculoISR.Location = new System.Drawing.Point(4, 23);
			this.tpImpresionCalculoISR.Margin = new System.Windows.Forms.Padding(2);
			this.tpImpresionCalculoISR.Name = "tpImpresionCalculoISR";
			this.tpImpresionCalculoISR.Padding = new System.Windows.Forms.Padding(2);
			this.tpImpresionCalculoISR.Size = new System.Drawing.Size(916, 519);
			this.tpImpresionCalculoISR.TabIndex = 2;
			this.tpImpresionCalculoISR.Text = "Cálculo de ISR MENSUAL";
			this.tpImpresionCalculoISR.UseVisualStyleBackColor = true;
			this.rvCalculoISR.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvCalculoISR.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptDeclaracionISR.rdlc";
			this.rvCalculoISR.Location = new System.Drawing.Point(1, 2);
			this.rvCalculoISR.Margin = new System.Windows.Forms.Padding(2);
			this.rvCalculoISR.Name = "rvCalculoISR";
			this.rvCalculoISR.ServerReport.BearerToken = null;
			this.rvCalculoISR.Size = new System.Drawing.Size(1147, 635);
			this.rvCalculoISR.TabIndex = 2;
			this.tabPage4.Controls.Add(this.rvCalculoISRAnual);
			this.tabPage4.Location = new System.Drawing.Point(4, 23);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage4.Size = new System.Drawing.Size(916, 519);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Cálculo de ISR ANUAL";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.rvCalculoISRAnual.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.rvCalculoISRAnual.LocalReport.ReportEmbeddedResource = "LeeXML.Reportes.rptDeclaracionISR.rdlc";
			this.rvCalculoISRAnual.Location = new System.Drawing.Point(1, 2);
			this.rvCalculoISRAnual.Margin = new System.Windows.Forms.Padding(2);
			this.rvCalculoISRAnual.Name = "rvCalculoISRAnual";
			this.rvCalculoISRAnual.ServerReport.BearerToken = null;
			this.rvCalculoISRAnual.Size = new System.Drawing.Size(688, 516);
			this.rvCalculoISRAnual.TabIndex = 3;
			this.flpEmpresas.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.flpEmpresas.Controls.Add(this.label24);
			this.flpEmpresas.Controls.Add(this.cmbEmpresas);
			this.flpEmpresas.Controls.Add(this.btnBuscaEmpresa);
			this.flpEmpresas.Location = new System.Drawing.Point(273, 7);
			this.flpEmpresas.Name = "flpEmpresas";
			this.flpEmpresas.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.flpEmpresas.Size = new System.Drawing.Size(555, 33);
			this.flpEmpresas.TabIndex = 140;
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new System.Drawing.Point(3, 2);
			this.label24.Name = "label24";
			this.label24.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.label24.Size = new System.Drawing.Size(73, 27);
			this.label24.TabIndex = 136;
			this.label24.Text = "Empresa:";
			this.btnBuscaEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnBuscaEmpresa.BackColor = System.Drawing.Color.White;
			this.btnBuscaEmpresa.BackgroundImage = (System.Drawing.Image)resources.GetObject("btnBuscaEmpresa.BackgroundImage");
			this.btnBuscaEmpresa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.btnBuscaEmpresa.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBuscaEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.btnBuscaEmpresa.Location = new System.Drawing.Point(498, 5);
			this.btnBuscaEmpresa.Name = "btnBuscaEmpresa";
			this.btnBuscaEmpresa.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
			this.btnBuscaEmpresa.Size = new System.Drawing.Size(35, 25);
			this.btnBuscaEmpresa.TabIndex = 139;
			this.btnBuscaEmpresa.UseVisualStyleBackColor = false;
			this.btnBuscaEmpresa.Click += new System.EventHandler(btnBuscaEmpresa_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			base.ClientSize = new System.Drawing.Size(1037, 541);
			base.Controls.Add(this.flpEmpresas);
			base.Controls.Add(this.tcCalculosGeneral);
			base.Name = "CalculoISR";
			this.Text = "Cálculo ISR";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.Load += new System.EventHandler(LeeXMLs_Load);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.pnlCalculoISR.ResumeLayout(false);
			this.tcCalculosISR.ResumeLayout(false);
			this.tpResicoPF.ResumeLayout(false);
			this.tpResicoPF.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.flowLayoutPanel5.ResumeLayout(false);
			this.flowLayoutPanel5.PerformLayout();
			this.flowLayoutPanel8.ResumeLayout(false);
			this.flowLayoutPanel8.PerformLayout();
			this.flowLayoutPanel9.ResumeLayout(false);
			this.flowLayoutPanel9.PerformLayout();
			this.flowLayoutPanel10.ResumeLayout(false);
			this.flowLayoutPanel10.PerformLayout();
			this.flowLayoutPanel12.ResumeLayout(false);
			this.flowLayoutPanel12.PerformLayout();
			this.flowLayoutPanel13.ResumeLayout(false);
			this.flowLayoutPanel13.PerformLayout();
			this.flpCalculoIsrMensual.ResumeLayout(false);
			this.flpCalculoIsrMensual.PerformLayout();
			this.flowLayoutPanel6.ResumeLayout(false);
			this.flowLayoutPanel6.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel3.ResumeLayout(false);
			this.flowLayoutPanel3.PerformLayout();
			this.flowLayoutPanel4.ResumeLayout(false);
			this.flowLayoutPanel4.PerformLayout();
			this.flowLayoutPanel11.ResumeLayout(false);
			this.flowLayoutPanel11.PerformLayout();
			this.tpResicoPM.ResumeLayout(false);
			this.flowLayoutPanel62.ResumeLayout(false);
			this.flowLayoutPanel62.PerformLayout();
			this.flowLayoutPanel63.ResumeLayout(false);
			this.flowLayoutPanel63.PerformLayout();
			this.flowLayoutPanel64.ResumeLayout(false);
			this.flowLayoutPanel64.PerformLayout();
			this.flowLayoutPanel45.ResumeLayout(false);
			this.flowLayoutPanel45.PerformLayout();
			this.flowLayoutPanel99.ResumeLayout(false);
			this.flowLayoutPanel99.PerformLayout();
			this.flowLayoutPanel104.ResumeLayout(false);
			this.flowLayoutPanel104.PerformLayout();
			this.flowLayoutPanel65.ResumeLayout(false);
			this.flowLayoutPanel65.PerformLayout();
			this.flowLayoutPanel102.ResumeLayout(false);
			this.flowLayoutPanel67.ResumeLayout(false);
			this.flowLayoutPanel67.PerformLayout();
			this.flowLayoutPanel68.ResumeLayout(false);
			this.flowLayoutPanel68.PerformLayout();
			this.flowLayoutPanel69.ResumeLayout(false);
			this.flowLayoutPanel69.PerformLayout();
			this.flowLayoutPanel71.ResumeLayout(false);
			this.flowLayoutPanel71.PerformLayout();
			this.flowLayoutPanel73.ResumeLayout(false);
			this.flowLayoutPanel73.PerformLayout();
			this.flowLayoutPanel75.ResumeLayout(false);
			this.flowLayoutPanel75.PerformLayout();
			this.flowLayoutPanel77.ResumeLayout(false);
			this.flowLayoutPanel77.PerformLayout();
			this.flowLayoutPanel78.ResumeLayout(false);
			this.flowLayoutPanel78.PerformLayout();
			this.flowLayoutPanel79.ResumeLayout(false);
			this.flowLayoutPanel79.PerformLayout();
			this.flowLayoutPanel80.ResumeLayout(false);
			this.flowLayoutPanel80.PerformLayout();
			this.flowLayoutPanel81.ResumeLayout(false);
			this.flowLayoutPanel81.PerformLayout();
			this.flowLayoutPanel83.ResumeLayout(false);
			this.flowLayoutPanel83.PerformLayout();
			this.flowLayoutPanel84.ResumeLayout(false);
			this.flowLayoutPanel84.PerformLayout();
			this.flowLayoutPanel85.ResumeLayout(false);
			this.flowLayoutPanel85.PerformLayout();
			this.flowLayoutPanel86.ResumeLayout(false);
			this.flowLayoutPanel86.PerformLayout();
			this.flowLayoutPanel87.ResumeLayout(false);
			this.flowLayoutPanel87.PerformLayout();
			this.flowLayoutPanel105.ResumeLayout(false);
			this.flowLayoutPanel105.PerformLayout();
			this.flowLayoutPanel88.ResumeLayout(false);
			this.flowLayoutPanel88.PerformLayout();
			this.flowLayoutPanel91.ResumeLayout(false);
			this.flowLayoutPanel91.PerformLayout();
			this.flowLayoutPanel92.ResumeLayout(false);
			this.flowLayoutPanel92.PerformLayout();
			this.flowLayoutPanel93.ResumeLayout(false);
			this.flowLayoutPanel93.PerformLayout();
			this.flowLayoutPanel94.ResumeLayout(false);
			this.flowLayoutPanel94.PerformLayout();
			this.flowLayoutPanel95.ResumeLayout(false);
			this.flowLayoutPanel95.PerformLayout();
			this.flowLayoutPanel96.ResumeLayout(false);
			this.flowLayoutPanel96.PerformLayout();
			this.flowLayoutPanel98.ResumeLayout(false);
			this.flowLayoutPanel98.PerformLayout();
			this.flowLayoutPanel100.ResumeLayout(false);
			this.flowLayoutPanel100.PerformLayout();
			this.flowLayoutPanel101.ResumeLayout(false);
			this.flowLayoutPanel101.PerformLayout();
			this.flowLayoutPanel97.ResumeLayout(false);
			this.flowLayoutPanel97.PerformLayout();
			this.flowLayoutPanel89.ResumeLayout(false);
			this.tpActividadEmpresarial.ResumeLayout(false);
			this.flowLayoutPanel103.ResumeLayout(false);
			this.flpCalculoIsrAE.ResumeLayout(false);
			this.flpCalculoIsrAE.PerformLayout();
			this.flowLayoutPanel23.ResumeLayout(false);
			this.flowLayoutPanel23.PerformLayout();
			this.flowLayoutPanel24.ResumeLayout(false);
			this.flowLayoutPanel24.PerformLayout();
			this.flowLayoutPanel106.ResumeLayout(false);
			this.flowLayoutPanel106.PerformLayout();
			this.flowLayoutPanel107.ResumeLayout(false);
			this.flowLayoutPanel107.PerformLayout();
			this.flowLayoutPanel25.ResumeLayout(false);
			this.flowLayoutPanel25.PerformLayout();
			this.flowLayoutPanel47.ResumeLayout(false);
			this.flowLayoutPanel47.PerformLayout();
			this.flowLayoutPanel48.ResumeLayout(false);
			this.flowLayoutPanel48.PerformLayout();
			this.flowLayoutPanel49.ResumeLayout(false);
			this.flowLayoutPanel49.PerformLayout();
			this.flowLayoutPanel51.ResumeLayout(false);
			this.flowLayoutPanel51.PerformLayout();
			this.flowLayoutPanel53.ResumeLayout(false);
			this.flowLayoutPanel53.PerformLayout();
			this.flowLayoutPanel55.ResumeLayout(false);
			this.flowLayoutPanel55.PerformLayout();
			this.flowLayoutPanel28.ResumeLayout(false);
			this.flowLayoutPanel28.PerformLayout();
			this.flowLayoutPanel58.ResumeLayout(false);
			this.flowLayoutPanel58.PerformLayout();
			this.flowLayoutPanel59.ResumeLayout(false);
			this.flowLayoutPanel59.PerformLayout();
			this.flowLayoutPanel60.ResumeLayout(false);
			this.flowLayoutPanel60.PerformLayout();
			this.flowLayoutPanel61.ResumeLayout(false);
			this.flowLayoutPanel61.PerformLayout();
			this.flowLayoutPanel33.ResumeLayout(false);
			this.flowLayoutPanel33.PerformLayout();
			this.flowLayoutPanel34.ResumeLayout(false);
			this.flowLayoutPanel34.PerformLayout();
			this.flowLayoutPanel14.ResumeLayout(false);
			this.flowLayoutPanel14.PerformLayout();
			this.flowLayoutPanel41.ResumeLayout(false);
			this.flowLayoutPanel41.PerformLayout();
			this.flowLayoutPanel43.ResumeLayout(false);
			this.flowLayoutPanel43.PerformLayout();
			this.flowLayoutPanel108.ResumeLayout(false);
			this.flowLayoutPanel108.PerformLayout();
			this.flowLayoutPanel44.ResumeLayout(false);
			this.flowLayoutPanel44.PerformLayout();
			this.flowLayoutPanel26.ResumeLayout(false);
			this.flowLayoutPanel26.PerformLayout();
			this.flowLayoutPanel40.ResumeLayout(false);
			this.flowLayoutPanel40.PerformLayout();
			this.flowLayoutPanel35.ResumeLayout(false);
			this.flowLayoutPanel35.PerformLayout();
			this.flowLayoutPanel37.ResumeLayout(false);
			this.flowLayoutPanel37.PerformLayout();
			this.flowLayoutPanel38.ResumeLayout(false);
			this.flowLayoutPanel38.PerformLayout();
			this.flowLayoutPanel36.ResumeLayout(false);
			this.flowLayoutPanel36.PerformLayout();
			this.flowLayoutPanel42.ResumeLayout(false);
			this.flowLayoutPanel42.PerformLayout();
			this.flowLayoutPanel39.ResumeLayout(false);
			this.flowLayoutPanel39.PerformLayout();
			this.tpRIF.ResumeLayout(false);
			this.flowLayoutPanel109.ResumeLayout(false);
			this.flowLayoutPanel110.ResumeLayout(false);
			this.flowLayoutPanel110.PerformLayout();
			this.flowLayoutPanel111.ResumeLayout(false);
			this.flowLayoutPanel111.PerformLayout();
			this.flowLayoutPanel113.ResumeLayout(false);
			this.flowLayoutPanel113.PerformLayout();
			this.flowLayoutPanel114.ResumeLayout(false);
			this.flowLayoutPanel114.PerformLayout();
			this.flowLayoutPanel115.ResumeLayout(false);
			this.flowLayoutPanel115.PerformLayout();
			this.flowLayoutPanel117.ResumeLayout(false);
			this.flowLayoutPanel117.PerformLayout();
			this.flowLayoutPanel123.ResumeLayout(false);
			this.flowLayoutPanel123.PerformLayout();
			this.flowLayoutPanel119.ResumeLayout(false);
			this.flowLayoutPanel119.PerformLayout();
			this.flowLayoutPanel121.ResumeLayout(false);
			this.flowLayoutPanel121.PerformLayout();
			this.flowLayoutPanel125.ResumeLayout(false);
			this.flowLayoutPanel125.PerformLayout();
			this.flowLayoutPanel127.ResumeLayout(false);
			this.flowLayoutPanel127.PerformLayout();
			this.flowLayoutPanel128.ResumeLayout(false);
			this.flowLayoutPanel128.PerformLayout();
			this.flowLayoutPanel112.ResumeLayout(false);
			this.flowLayoutPanel112.PerformLayout();
			this.flowLayoutPanel118.ResumeLayout(false);
			this.flowLayoutPanel118.PerformLayout();
			this.flowLayoutPanel131.ResumeLayout(false);
			this.flowLayoutPanel131.PerformLayout();
			this.flowLayoutPanel129.ResumeLayout(false);
			this.flowLayoutPanel129.PerformLayout();
			this.flowLayoutPanel122.ResumeLayout(false);
			this.flowLayoutPanel122.PerformLayout();
			this.flowLayoutPanel133.ResumeLayout(false);
			this.flowLayoutPanel133.PerformLayout();
			this.flowLayoutPanel134.ResumeLayout(false);
			this.flowLayoutPanel134.PerformLayout();
			this.flowLayoutPanel135.ResumeLayout(false);
			this.flowLayoutPanel135.PerformLayout();
			this.flowLayoutPanel136.ResumeLayout(false);
			this.flowLayoutPanel136.PerformLayout();
			this.flowLayoutPanel137.ResumeLayout(false);
			this.flowLayoutPanel137.PerformLayout();
			this.flowLayoutPanel138.ResumeLayout(false);
			this.flowLayoutPanel138.PerformLayout();
			this.flowLayoutPanel139.ResumeLayout(false);
			this.flowLayoutPanel139.PerformLayout();
			this.flowLayoutPanel141.ResumeLayout(false);
			this.flowLayoutPanel141.PerformLayout();
			this.flowLayoutPanel142.ResumeLayout(false);
			this.flowLayoutPanel142.PerformLayout();
			this.flowLayoutPanel143.ResumeLayout(false);
			this.flowLayoutPanel143.PerformLayout();
			this.flowLayoutPanel144.ResumeLayout(false);
			this.flowLayoutPanel144.PerformLayout();
			this.flowLayoutPanel145.ResumeLayout(false);
			this.flowLayoutPanel145.PerformLayout();
			this.flowLayoutPanel146.ResumeLayout(false);
			this.flowLayoutPanel146.PerformLayout();
			this.flowLayoutPanel147.ResumeLayout(false);
			this.flowLayoutPanel147.PerformLayout();
			this.flowLayoutPanel148.ResumeLayout(false);
			this.flowLayoutPanel148.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.flowLayoutPanel130.ResumeLayout(false);
			this.flowLayoutPanel149.ResumeLayout(false);
			this.flowLayoutPanel149.PerformLayout();
			this.flowLayoutPanel150.ResumeLayout(false);
			this.flowLayoutPanel150.PerformLayout();
			this.flowLayoutPanel151.ResumeLayout(false);
			this.flowLayoutPanel151.PerformLayout();
			this.flowLayoutPanel152.ResumeLayout(false);
			this.flowLayoutPanel152.PerformLayout();
			this.flowLayoutPanel153.ResumeLayout(false);
			this.flowLayoutPanel153.PerformLayout();
			this.flowLayoutPanel155.ResumeLayout(false);
			this.flowLayoutPanel155.PerformLayout();
			this.flowLayoutPanel156.ResumeLayout(false);
			this.flowLayoutPanel156.PerformLayout();
			this.flowLayoutPanel157.ResumeLayout(false);
			this.flowLayoutPanel183.ResumeLayout(false);
			this.flowLayoutPanel183.PerformLayout();
			this.flowLayoutPanel159.ResumeLayout(false);
			this.flowLayoutPanel159.PerformLayout();
			this.flowLayoutPanel161.ResumeLayout(false);
			this.flowLayoutPanel161.PerformLayout();
			this.flowLayoutPanel162.ResumeLayout(false);
			this.flowLayoutPanel162.PerformLayout();
			this.flowLayoutPanel164.ResumeLayout(false);
			this.flowLayoutPanel164.PerformLayout();
			this.flowLayoutPanel165.ResumeLayout(false);
			this.flowLayoutPanel165.PerformLayout();
			this.pnlFlujos.ResumeLayout(false);
			this.flpFlujos.ResumeLayout(false);
			this.flpPUE.ResumeLayout(false);
			this.flpPUE.PerformLayout();
			this.flpTotalesTodos.ResumeLayout(false);
			this.flpTotalesTodos.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.flowLayoutPanel16.ResumeLayout(false);
			this.flowLayoutPanel16.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.flowLayoutPanel17.ResumeLayout(false);
			this.flowLayoutPanel17.PerformLayout();
			this.toolStrip5.ResumeLayout(false);
			this.toolStrip5.PerformLayout();
			this.flowLayoutPanel19.ResumeLayout(false);
			this.flowLayoutPanel19.PerformLayout();
			this.toolStrip3.ResumeLayout(false);
			this.toolStrip3.PerformLayout();
			this.flpRecibidosMensual.ResumeLayout(false);
			this.flpRecibidosMensual.PerformLayout();
			this.flowLayoutPanel27.ResumeLayout(false);
			this.flowLayoutPanel27.PerformLayout();
			this.toolStrip9.ResumeLayout(false);
			this.toolStrip9.PerformLayout();
			this.flowLayoutPanel29.ResumeLayout(false);
			this.flowLayoutPanel29.PerformLayout();
			this.toolStrip10.ResumeLayout(false);
			this.toolStrip10.PerformLayout();
			this.flowLayoutPanel30.ResumeLayout(false);
			this.flowLayoutPanel30.PerformLayout();
			this.toolStrip11.ResumeLayout(false);
			this.toolStrip11.PerformLayout();
			this.flowLayoutPanel31.ResumeLayout(false);
			this.flowLayoutPanel31.PerformLayout();
			this.toolStrip12.ResumeLayout(false);
			this.toolStrip12.PerformLayout();
			this.flowLayoutPanel32.ResumeLayout(false);
			this.flowLayoutPanel32.PerformLayout();
			this.toolStrip13.ResumeLayout(false);
			this.toolStrip13.PerformLayout();
			this.flpEmitidosAnual.ResumeLayout(false);
			this.flpEmitidosAnual.PerformLayout();
			this.flowLayoutPanel15.ResumeLayout(false);
			this.flowLayoutPanel15.PerformLayout();
			this.toolStrip4.ResumeLayout(false);
			this.toolStrip4.PerformLayout();
			this.flowLayoutPanel18.ResumeLayout(false);
			this.flowLayoutPanel18.PerformLayout();
			this.toolStrip6.ResumeLayout(false);
			this.toolStrip6.PerformLayout();
			this.flowLayoutPanel20.ResumeLayout(false);
			this.flowLayoutPanel20.PerformLayout();
			this.toolStrip7.ResumeLayout(false);
			this.toolStrip7.PerformLayout();
			this.flowLayoutPanel21.ResumeLayout(false);
			this.flowLayoutPanel21.PerformLayout();
			this.toolStrip8.ResumeLayout(false);
			this.toolStrip8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.gvNominas).EndInit();
			((System.ComponentModel.ISupportInitialize)this.entFacturaBindingSource).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.pnlPorMesVentas.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.entCatalogoGenericoBindingSource).EndInit();
			this.tcCalculosGeneral.ResumeLayout(false);
			this.tpImpresionISR.ResumeLayout(false);
			this.tcCalculosISRimpresion.ResumeLayout(false);
			this.tpImpresionCalculoISR.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.flpEmpresas.ResumeLayout(false);
			this.flpEmpresas.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
