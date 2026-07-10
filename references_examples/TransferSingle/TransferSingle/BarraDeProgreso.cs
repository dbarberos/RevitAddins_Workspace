using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000004 RID: 4
	public partial class BarraDeProgreso : Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002374 File Offset: 0x00000574
		public BarraDeProgreso()
		{
			this.InitializeComponent();
			base.CenterToScreen();
			base.ControlBox = false;
			BarraDeProgreso.cancelado = false;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002395 File Offset: 0x00000595
		private void BarraDeProgreso_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002397 File Offset: 0x00000597
		private void cancelarbarra_Click(object sender, EventArgs e)
		{
			BarraDeProgreso.cancelado = true;
			base.Hide();
		}

		// Token: 0x0400000C RID: 12
		public static bool cancelado;
	}
}
