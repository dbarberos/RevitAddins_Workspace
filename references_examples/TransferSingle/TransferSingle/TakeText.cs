using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000018 RID: 24
	public partial class TakeText : Form
	{
		// Token: 0x060000A7 RID: 167 RVA: 0x00007EF0 File Offset: 0x000060F0
		public TakeText()
		{
			this.InitializeComponent();
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			TakeText.cancelado = true;
			this.texto.Text = TakeText.texto_out;
			base.CenterToScreen();
			base.TopMost = true;
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00007F2F File Offset: 0x0000612F
		private void button1_Click(object sender, EventArgs e)
		{
			TakeText.texto_out = this.texto.Text;
			TakeText.cancelado = false;
			base.Close();
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00007F4D File Offset: 0x0000614D
		private void btCancel_Click(object sender, EventArgs e)
		{
			TakeText.texto_out = this.texto.Text;
			TakeText.cancelado = true;
			base.Close();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00007F6B File Offset: 0x0000616B
		private void TakeText_Load(object sender, EventArgs e)
		{
			this.texto.Focus();
			base.ActiveControl = this.texto;
		}

		// Token: 0x04000089 RID: 137
		public static bool cancelado = true;

		// Token: 0x0400008A RID: 138
		public static string texto_out = "";
	}
}
