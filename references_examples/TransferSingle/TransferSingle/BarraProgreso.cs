using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000006 RID: 6
	public partial class BarraProgreso : Form
	{
		// Token: 0x06000014 RID: 20 RVA: 0x000028EC File Offset: 0x00000AEC
		public BarraProgreso(int Max)
		{
			this.InitializeComponent();
			this.progressBar1.Minimum = 0;
			this.progressBar1.Maximum = Max;
			this.progressBar1.Step = 1;
			base.CenterToScreen();
			base.ControlBox = false;
			base.TopMost = true;
			this.cancelado = false;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002395 File Offset: 0x00000595
		private void BarraProgreso_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002944 File Offset: 0x00000B44
		public void Paso()
		{
			this.progressBar1.PerformStep();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002954 File Offset: 0x00000B54
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
			if (actual <= this.progressBar1.Maximum)
			{
				this.progressBar1.Value = this.progressBar1.Value + 1;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002ADE File Offset: 0x00000CDE
		private void btCancel_Click(object sender, EventArgs e)
		{
			this.cancelado = true;
		}

		// Token: 0x04000016 RID: 22
		public bool cancelado;
	}
}
