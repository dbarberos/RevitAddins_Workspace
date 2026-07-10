using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x0200000A RID: 10
	public partial class RenameText : Form
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public RenameText()
		{
			this.InitializeComponent();
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.TopMost = true;
			RenameText.cancelado = true;
			this.textofind.Text = RenameText.textofind_out;
			this.textoreplace.Text = RenameText.textoreplace_out;
			this.chk_Regex.Checked = RenameText.usaregex;
			base.CenterToScreen();
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003D32 File Offset: 0x00001F32
		private void button1_Click(object sender, EventArgs e)
		{
			RenameText.textofind_out = this.textofind.Text;
			RenameText.textoreplace_out = this.textoreplace.Text;
			RenameText.cancelado = false;
			RenameText.usaregex = this.chk_Regex.Checked;
			base.Close();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00003D70 File Offset: 0x00001F70
		private void btCancel_Click(object sender, EventArgs e)
		{
			RenameText.textofind_out = this.textofind.Text;
			RenameText.textoreplace_out = this.textoreplace.Text;
			RenameText.cancelado = true;
			RenameText.usaregex = this.chk_Regex.Checked;
			base.Close();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003DAE File Offset: 0x00001FAE
		private void RenameText_Load(object sender, EventArgs e)
		{
			this.textofind.Focus();
			base.ActiveControl = this.textofind;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002395 File Offset: 0x00000595
		private void texto_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x04000030 RID: 48
		public static bool usaregex = false;

		// Token: 0x04000031 RID: 49
		public static bool cancelado = true;

		// Token: 0x04000032 RID: 50
		public static string textofind_out = "";

		// Token: 0x04000033 RID: 51
		public static string textoreplace_out = "";
	}
}
