using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000005 RID: 5
	public partial class BarraDeProgresoLineal : Form
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000261E File Offset: 0x0000081E
		public BarraDeProgresoLineal()
		{
			this.InitializeComponent();
			base.CenterToScreen();
			base.ControlBox = false;
			this.cancelado = false;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002395 File Offset: 0x00000595
		private void BarraDeProgresoLineal_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002640 File Offset: 0x00000840
		private void cancelarbarra_Click(object sender, EventArgs e)
		{
			this.cancelado = true;
			base.Hide();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000264F File Offset: 0x0000084F
		public void FijaBarra(int min, int max)
		{
			this.progreso.Minimum = min;
			this.progreso.Maximum = max;
			this.progreso.Step = 1;
		}

		// Token: 0x04000011 RID: 17
		public bool cancelado;
	}
}
