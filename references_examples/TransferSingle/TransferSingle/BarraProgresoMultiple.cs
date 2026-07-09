using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000007 RID: 7
	public partial class BarraProgresoMultiple : Form
	{
		// Token: 0x0600001B RID: 27 RVA: 0x00002D40 File Offset: 0x00000F40
		public BarraProgresoMultiple(int Max, int MaxMain)
		{
			this.InitializeComponent();
			this.progressBar1.Minimum = 0;
			this.progressBar1.Maximum = Max;
			this.progressBar1.Step = 1;
			this.progressMain.Minimum = 0;
			this.progressMain.Maximum = MaxMain;
			this.progressMain.Step = 1;
			base.CenterToScreen();
			base.ControlBox = false;
			base.TopMost = true;
			this.cancelado = false;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002395 File Offset: 0x00000595
		private void BarraProgreso_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002DBC File Offset: 0x00000FBC
		public void Paso()
		{
			this.progressBar1.PerformStep();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002DCC File Offset: 0x00000FCC
		public void FijaTexto(int caso, int validos, int actual)
		{
			if (actual <= this.progressBar1.Maximum)
			{
				this.progressBar1.Value = actual;
				this.progressBar1.Value = this.progressBar1.Value - 1;
			}
			else
			{
				this.progressBar1.Value = this.progressBar1.Maximum;
				this.progressBar1.Value = this.progressBar1.Value - 1;
				this.progressBar1.Value = this.progressBar1.Maximum;
			}
			this.progressMain.Value = this.progressMain.Value - 1;
			if (caso == 0)
			{
				this.txt.Text = string.Concat(new string[]
				{
					"Processing Elements: ",
					this.progressBar1.Value.ToString(),
					" of ",
					this.progressBar1.Maximum.ToString(),
					" (",
					validos.ToString(),
					" valids)"
				});
			}
			if (caso == 1)
			{
				this.txt.Text = string.Concat(new string[]
				{
					"Transferring Standards: ",
					this.progressBar1.Value.ToString(),
					" of ",
					this.progressBar1.Maximum.ToString(),
					" (",
					validos.ToString(),
					" errors)"
				});
			}
			this.progressMain.Value = this.progressMain.Value + 1;
			if (actual <= this.progressBar1.Maximum)
			{
				this.progressBar1.Value = this.progressBar1.Value + 1;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002F86 File Offset: 0x00001186
		public void SoloTexto(string texto)
		{
			this.txt.Text = texto;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002F94 File Offset: 0x00001194
		public void IniciaBarraInferior(int num)
		{
			this.progressBar1.Maximum = num;
			this.progressBar1.Value = 0;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002FAE File Offset: 0x000011AE
		public void FijaTextoSuperior(string texto)
		{
			this.txtMain.Text = "Processing Standard: " + texto;
			this.progressMain.Value = this.progressMain.Value + 1;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002FDE File Offset: 0x000011DE
		private void btCancel_Click(object sender, EventArgs e)
		{
			this.cancelado = true;
		}

		// Token: 0x0400001B RID: 27
		public bool cancelado;
	}
}
