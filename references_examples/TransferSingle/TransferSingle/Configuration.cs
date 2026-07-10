using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TransferSingleApp
{
	// Token: 0x02000008 RID: 8
	public partial class Configuration : Form
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00003304 File Offset: 0x00001504
		public Configuration()
		{
			this.InitializeComponent();
			this.LeeConfiguracionTab();
			this.MinimumSize = new Size(300, 245);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003338 File Offset: 0x00001538
		private void Cancel_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003340 File Offset: 0x00001540
		public void LeeConfiguracionTab()
		{
			this.config = SaveXMLConfigTab.Lee_Configuracion_de_XML();
			this.sw_TabJOTools.Checked = this.config.cf_sw_TabJOTools;
			this.sw_TabRevit.Checked = this.config.cf_sw_TabRevit;
			this.sw_TabOtro.Checked = this.config.cf_sw_TabOtro;
			this.TabOtro.Text = this.config.cf_TabOtro;
			this.ch_HideMessages.Checked = this.config.cf_HideMessages;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000033C8 File Offset: 0x000015C8
		public void SalvaConfiguracionTab()
		{
			this.config.cf_sw_TabJOTools = this.sw_TabJOTools.Checked;
			this.config.cf_sw_TabRevit = this.sw_TabRevit.Checked;
			this.config.cf_sw_TabOtro = this.sw_TabOtro.Checked;
			this.config.cf_TabOtro = this.TabOtro.Text;
			this.config.cf_HideMessages = this.ch_HideMessages.Checked;
			SaveXMLConfigTab.Salva_config(this.config);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003450 File Offset: 0x00001650
		private void Save_Click(object sender, EventArgs e)
		{
			string @object = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			bool flag = false;
			if (this.sw_TabJOTools.Checked)
			{
				flag = true;
			}
			if (this.sw_TabRevit.Checked)
			{
				flag = true;
			}
			if (this.sw_TabOtro.Checked)
			{
				if (!this.TabOtro.Text.All(new Func<char, bool>(@object.Contains<char>)))
				{
					MessageBox.Show("No special characters on the tab name are allowed!");
					flag = false;
				}
				else if (this.TabOtro.Text == "")
				{
					MessageBox.Show("You should name target Tab");
					flag = false;
				}
				else
				{
					flag = true;
				}
			}
			if (flag)
			{
				this.SalvaConfiguracionTab();
				base.Close();
			}
		}

		// Token: 0x04000022 RID: 34
		public ConfiguracionTab config = new ConfiguracionTab();
	}
}
