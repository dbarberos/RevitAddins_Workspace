using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000009 RID: 9
	public partial class About : Form
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00003B0A File Offset: 0x00001D0A
		public About()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003338 File Offset: 0x00001538
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
