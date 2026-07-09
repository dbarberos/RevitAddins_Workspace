using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TransferSingleApp.Properties;

namespace TransferSingleApp
{
	// Token: 0x0200000C RID: 12
	public partial class FormLoad : Form
	{
		// Token: 0x06000058 RID: 88 RVA: 0x000053E8 File Offset: 0x000035E8
		public FormLoad()
		{
			this.InitializeComponent();
			base.CenterToScreen();
			base.ControlBox = false;
			this.Cancelado = false;
			FormLoad.overwrite = true;
			this.textodir.Text = FormLoad.Directorio;
			this.MinimumSize = new Size(400, 400);
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00002395 File Offset: 0x00000595
		private void FromLoad_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00005440 File Offset: 0x00003640
		private void exit_Click(object sender, EventArgs e)
		{
			this.Cancelado = true;
			base.Hide();
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00005450 File Offset: 0x00003650
		private void selectfolder_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.textodir.Text = folderBrowserDialog.SelectedPath;
				FormLoad.Directorio = this.textodir.Text;
				IList<string> list = new List<string>();
				if (this.includesub.Checked)
				{
					list = Directory.GetFiles(FormLoad.Directorio, "*.rfa", SearchOption.AllDirectories);
				}
				else
				{
					list = Directory.GetFiles(FormLoad.Directorio, "*.rfa", SearchOption.TopDirectoryOnly);
				}
				if (list.Count > 0)
				{
					FormLoad.PopulateTreeView(this.treeView1, list, '\\');
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x000054DB File Offset: 0x000036DB
		private void LoadFam_Click(object sender, EventArgs e)
		{
			if (this.sobrescribe.Checked)
			{
				FormLoad.overwrite = true;
			}
			else
			{
				FormLoad.overwrite = false;
			}
			base.Hide();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00002395 File Offset: 0x00000595
		private void logerror_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00005500 File Offset: 0x00003700
		private static void PopulateTreeView(TreeView treeView, IEnumerable<string> paths, char pathSeparator)
		{
			treeView.Nodes.Clear();
			treeView.BeginUpdate();
			TreeNode treeNode = null;
			foreach (string text in paths)
			{
				string text2 = string.Empty;
				foreach (string text3 in text.Split(new char[]
				{
					pathSeparator
				}))
				{
					text2 = text2 + text3 + pathSeparator.ToString();
					TreeNode[] array2 = treeView.Nodes.Find(text2, true);
					if (array2.Length == 0)
					{
						if (treeNode == null)
						{
							treeNode = treeView.Nodes.Add(text2, text3);
							treeNode.Checked = true;
						}
						else
						{
							treeNode = treeNode.Nodes.Add(text2, text3);
							treeNode.Checked = true;
						}
					}
					else
					{
						treeNode = array2[0];
					}
				}
				treeNode.Tag = text;
			}
			treeView.ExpandAll();
			treeView.EndUpdate();
			treeView.SelectedNode = treeView.Nodes[0];
			treeView.Refresh();
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005614 File Offset: 0x00003814
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

		// Token: 0x06000060 RID: 96 RVA: 0x00005684 File Offset: 0x00003884
		private void CheckChildren(TreeNode rootNode, bool isChecked)
		{
			foreach (object obj in rootNode.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				this.CheckChildren(treeNode, isChecked);
				treeNode.Checked = isChecked;
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000056E8 File Offset: 0x000038E8
		private void famTodo_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005750 File Offset: 0x00003950
		private void famNada_Click(object sender, EventArgs e)
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000057B8 File Offset: 0x000039B8
		private void SeleeccionaTodo()
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = true;
				this.CheckChildren(treeNode, true);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00005820 File Offset: 0x00003A20
		private void SeleccionaNada()
		{
			foreach (object obj in this.treeView1.Nodes)
			{
				TreeNode treeNode = (TreeNode)obj;
				treeNode.Checked = false;
				this.CheckChildren(treeNode, false);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00005888 File Offset: 0x00003A88
		private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
		{
			if (e.Action != TreeViewAction.Unknown && e.Node.Nodes.Count > 0)
			{
				this.CheckAllChildNodes(e.Node, e.Node.Checked);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00002395 File Offset: 0x00000595
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00002395 File Offset: 0x00000595
		private void label1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00002395 File Offset: 0x00000595
		private void pictureBox1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000058BC File Offset: 0x00003ABC
		private void reloadpic_MouseEnter(object sender, EventArgs e)
		{
			this.reloadpic.Image = Resources.Reload_over;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000058CE File Offset: 0x00003ACE
		private void reloadpic_MouseLeave(object sender, EventArgs e)
		{
			this.reloadpic.Image = Resources.Reload;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000058E0 File Offset: 0x00003AE0
		private void reloadpic_Click(object sender, EventArgs e)
		{
			IList<string> list = new List<string>();
			if (this.includesub.Checked)
			{
				list = Directory.GetFiles(FormLoad.Directorio, "*.rfa", SearchOption.AllDirectories);
			}
			else
			{
				list = Directory.GetFiles(FormLoad.Directorio, "*.rfa", SearchOption.TopDirectoryOnly);
			}
			if (list.Count > 0)
			{
				FormLoad.PopulateTreeView(this.treeView1, list, '\\');
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000593B File Offset: 0x00003B3B
		private void ExpandTodos_MouseEnter(object sender, EventArgs e)
		{
			this.ExpandTodos.Image = Resources.ExpTodos_over;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000594D File Offset: 0x00003B4D
		private void ExpandTodos_MouseLeave(object sender, EventArgs e)
		{
			this.ExpandTodos.Image = Resources.ExpTodos;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000595F File Offset: 0x00003B5F
		private void ExpandNinguno_MouseEnter(object sender, EventArgs e)
		{
			this.ExpandNinguno.Image = Resources.ExpNinguno_over;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00005971 File Offset: 0x00003B71
		private void ExpandNinguno_MouseLeave(object sender, EventArgs e)
		{
			this.ExpandNinguno.Image = Resources.ExpNinguno;
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00005983 File Offset: 0x00003B83
		private void filesTodo_MouseEnter(object sender, EventArgs e)
		{
			this.filesTodo.Image = Resources.SelTodos_over;
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00005995 File Offset: 0x00003B95
		private void filesTodo_MouseLeave(object sender, EventArgs e)
		{
			this.filesTodo.Image = Resources.SelTodos;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x000059A7 File Offset: 0x00003BA7
		private void filesNada_MouseEnter(object sender, EventArgs e)
		{
			this.filesNada.Image = Resources.SelNinguno_over;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000059B9 File Offset: 0x00003BB9
		private void filesNada_MouseLeave(object sender, EventArgs e)
		{
			this.filesNada.Image = Resources.SelNinguno;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000059CB File Offset: 0x00003BCB
		private void filesTodo_Click(object sender, EventArgs e)
		{
			this.SeleeccionaTodo();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000059D3 File Offset: 0x00003BD3
		private void filesNada_Click(object sender, EventArgs e)
		{
			this.SeleccionaNada();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000059DB File Offset: 0x00003BDB
		private void ExpandTodos_Click(object sender, EventArgs e)
		{
			this.treeView1.ExpandAll();
		}

		// Token: 0x06000077 RID: 119 RVA: 0x000059E8 File Offset: 0x00003BE8
		private void ExpandNinguno_Click(object sender, EventArgs e)
		{
			this.treeView1.CollapseAll();
		}

		// Token: 0x04000050 RID: 80
		public bool Cancelado;

		// Token: 0x04000051 RID: 81
		public static string Directorio = "C:\\tmp";

		// Token: 0x04000052 RID: 82
		public static bool overwrite = true;
	}
}
