using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TransferSingleApp.Properties;

namespace TransferSingleApp
{
	// Token: 0x0200000B RID: 11
	public partial class formgeneral : Form
	{
		// Token: 0x06000038 RID: 56 RVA: 0x000042A8 File Offset: 0x000024A8
		public formgeneral()
		{
			this.InitializeComponent();
			base.CenterToScreen();
			base.ControlBox = false;
			this.MinimumSize = new Size(400, 450);
			this.Cancelado = false;
			this.textodir.Text = formgeneral.Directorio;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002395 File Offset: 0x00000595
		private void label2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002395 File Offset: 0x00000595
		private void form1_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000042FA File Offset: 0x000024FA
		private void exit_Click(object sender, EventArgs e)
		{
			this.Cancelado = true;
			base.Hide();
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000430C File Offset: 0x0000250C
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach (object obj in treeNode.Nodes)
			{
				TreeNode treeNode2 = (TreeNode)obj;
				treeNode2.Checked = nodeChecked;
				if (treeNode2.Nodes.Count > 0)
				{
					this.CheckAllChildNodes(treeNode2, nodeChecked);
				}
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000437C File Offset: 0x0000257C
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000043E0 File Offset: 0x000025E0
		private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown && e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00004414 File Offset: 0x00002614
		private void SeleccionaTodo()
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000447C File Offset: 0x0000267C
		private void DeseleccionaTodo()
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000044E4 File Offset: 0x000026E4
		private void famTodo_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x0000454C File Offset: 0x0000274C
		private void famNada_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000045B4 File Offset: 0x000027B4
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.treeView1.SelectedNode.Tag != null)
			{
				object tag = this.treeView1.SelectedNode.Tag;
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000045D9 File Offset: 0x000027D9
		private void ToExcel_Click(object sender, EventArgs e)
		{
			formgeneral.Directorio = this.textodir.Text;
			base.Hide();
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00002395 File Offset: 0x00000595
		private void addcat_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000045F4 File Offset: 0x000027F4
		private void selectfolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.textodir.Text = folderBrowserDialog.SelectedPath;
				formgeneral.Directorio = this.textodir.Text;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00002395 File Offset: 0x00000595
		private void addcat_CheckedChanged_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00004631 File Offset: 0x00002831
		private void ExpandTodos_MouseEnter(object sender, EventArgs e)
		{
			this.ExpandTodos.Image = Resources.ExpTodos_over;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00004643 File Offset: 0x00002843
		private void ExpandTodos_MouseLeave(object sender, EventArgs e)
		{
			this.ExpandTodos.Image = Resources.ExpTodos;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00004655 File Offset: 0x00002855
		private void ExpandNinguno_MouseEnter(object sender, EventArgs e)
		{
			this.ExpandNinguno.Image = Resources.ExpNinguno_over;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00004667 File Offset: 0x00002867
		private void ExpandNinguno_MouseLeave(object sender, EventArgs e)
		{
			this.ExpandNinguno.Image = Resources.ExpNinguno;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00004679 File Offset: 0x00002879
		private void filesTodo_MouseEnter(object sender, EventArgs e)
		{
			this.filesTodo.Image = Resources.SelTodos_over;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000468B File Offset: 0x0000288B
		private void filesTodo_MouseLeave(object sender, EventArgs e)
		{
			this.filesTodo.Image = Resources.SelTodos;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000469D File Offset: 0x0000289D
		private void filesNada_MouseEnter(object sender, EventArgs e)
		{
			this.filesNada.Image = Resources.SelNinguno_over;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000046AF File Offset: 0x000028AF
		private void filesNada_MouseLeave(object sender, EventArgs e)
		{
			this.filesNada.Image = Resources.SelNinguno;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000046C1 File Offset: 0x000028C1
		private void filesTodo_Click(object sender, EventArgs e)
		{
			this.SeleccionaTodo();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000046C9 File Offset: 0x000028C9
		private void filesNada_Click(object sender, EventArgs e)
		{
			this.DeseleccionaTodo();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002395 File Offset: 0x00000595
		private void textodir_TextChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000046D1 File Offset: 0x000028D1
		private void ExpandTodos_Click(object sender, EventArgs e)
		{
			this.treeView1.ExpandAll();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000046DE File Offset: 0x000028DE
		private void ExpandNinguno_Click(object sender, EventArgs e)
		{
			this.treeView1.CollapseAll();
		}

		// Token: 0x0400003C RID: 60
		public static string Directorio = "C:\\tmp";

		// Token: 0x0400003D RID: 61
		public bool Cancelado;
	}
}
