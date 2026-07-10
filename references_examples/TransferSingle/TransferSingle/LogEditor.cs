using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Autodesk.Revit.UI;

namespace TransferSingleApp
{
	// Token: 0x0200000D RID: 13
	public partial class LogEditor : Form
	{
		// Token: 0x0600007B RID: 123 RVA: 0x0000668C File Offset: 0x0000488C
		public LogEditor()
		{
			this.InitializeComponent();
			base.CenterToScreen();
			base.TopMost = true;
			this.MinimumSize = new Size(200, 200);
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00002395 File Offset: 0x00000595
		private void LogEditor_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00003338 File Offset: 0x00001538
		private void btOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000066C7 File Offset: 0x000048C7
		public void PonTexto()
		{
			this.txtLog.Text = string.Join(Environment.NewLine, this.ContenidoLog);
		}

		// Token: 0x0600007F RID: 127 RVA: 0x000066E4 File Offset: 0x000048E4
		private void btSalvaLog_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Archivos TXT (*.txt)|*.txt|Todos Los Archivos (*.*)|*.*";
			saveFileDialog.Title = "Salva Log";
			saveFileDialog.ShowDialog();
			if (saveFileDialog.FileName != "")
			{
				StreamWriter streamWriter = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write), Encoding.UTF8);
				foreach (string value in this.ContenidoLog)
				{
					streamWriter.WriteLine(value);
				}
				streamWriter.Close();
				TaskDialog.Show("File Saved", "Text from Log Saved to File.");
			}
		}

		// Token: 0x04000064 RID: 100
		public IList<string> ContenidoLog = new List<string>();
	}
}
