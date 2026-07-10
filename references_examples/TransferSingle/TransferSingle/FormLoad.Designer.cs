namespace TransferSingleApp
{
	// Token: 0x0200000C RID: 12
	public partial class FormLoad : global::System.Windows.Forms.Form
	{
		// Token: 0x06000078 RID: 120 RVA: 0x000059F5 File Offset: 0x00003BF5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00005A14 File Offset: 0x00003C14
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.FormLoad));
			this.textodir = new global::System.Windows.Forms.TextBox();
			this.selectfolder = new global::System.Windows.Forms.Button();
			this.includesub = new global::System.Windows.Forms.CheckBox();
			this.exit = new global::System.Windows.Forms.Button();
			this.LoadFam = new global::System.Windows.Forms.Button();
			this.logerror = new global::System.Windows.Forms.CheckBox();
			this.siexiste = new global::System.Windows.Forms.GroupBox();
			this.ignoar = new global::System.Windows.Forms.RadioButton();
			this.sobrescribe = new global::System.Windows.Forms.RadioButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.treeView1 = new global::System.Windows.Forms.TreeView();
			this.reloadpic = new global::System.Windows.Forms.PictureBox();
			this.filesTodo = new global::System.Windows.Forms.PictureBox();
			this.filesNada = new global::System.Windows.Forms.PictureBox();
			this.ExpandNinguno = new global::System.Windows.Forms.PictureBox();
			this.ExpandTodos = new global::System.Windows.Forms.PictureBox();
			this.siexiste.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.reloadpic).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.filesTodo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.filesNada).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandNinguno).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandTodos).BeginInit();
			base.SuspendLayout();
			this.textodir.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textodir.Location = new global::System.Drawing.Point(103, 396);
			this.textodir.Name = "textodir";
			this.textodir.Size = new global::System.Drawing.Size(163, 20);
			this.textodir.TabIndex = 15;
			this.selectfolder.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.selectfolder.Location = new global::System.Drawing.Point(12, 394);
			this.selectfolder.Name = "selectfolder";
			this.selectfolder.Size = new global::System.Drawing.Size(85, 23);
			this.selectfolder.TabIndex = 14;
			this.selectfolder.Text = "Select Folder";
			this.selectfolder.UseVisualStyleBackColor = true;
			this.selectfolder.Click += new global::System.EventHandler(this.selectfolder_Click);
			this.includesub.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.includesub.Checked = true;
			this.includesub.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.includesub.Location = new global::System.Drawing.Point(294, 29);
			this.includesub.Name = "includesub";
			this.includesub.Size = new global::System.Drawing.Size(150, 17);
			this.includesub.TabIndex = 16;
			this.includesub.Text = "Include Subfolders";
			this.includesub.UseVisualStyleBackColor = true;
			this.exit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.exit.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.exit.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.exit.Location = new global::System.Drawing.Point(294, 363);
			this.exit.Name = "exit";
			this.exit.Size = new global::System.Drawing.Size(156, 25);
			this.exit.TabIndex = 18;
			this.exit.Text = "Cancel";
			this.exit.UseVisualStyleBackColor = true;
			this.exit.Click += new global::System.EventHandler(this.exit_Click);
			this.LoadFam.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.LoadFam.Location = new global::System.Drawing.Point(294, 332);
			this.LoadFam.Name = "LoadFam";
			this.LoadFam.Size = new global::System.Drawing.Size(156, 25);
			this.LoadFam.TabIndex = 17;
			this.LoadFam.Text = "Load Families";
			this.LoadFam.UseVisualStyleBackColor = true;
			this.LoadFam.Click += new global::System.EventHandler(this.LoadFam_Click);
			this.logerror.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.logerror.Checked = true;
			this.logerror.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.logerror.Location = new global::System.Drawing.Point(294, 52);
			this.logerror.Name = "logerror";
			this.logerror.Size = new global::System.Drawing.Size(150, 17);
			this.logerror.TabIndex = 19;
			this.logerror.Text = "Log Errors";
			this.logerror.UseVisualStyleBackColor = true;
			this.logerror.CheckedChanged += new global::System.EventHandler(this.logerror_CheckedChanged);
			this.siexiste.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.siexiste.Controls.Add(this.ignoar);
			this.siexiste.Controls.Add(this.sobrescribe);
			this.siexiste.Location = new global::System.Drawing.Point(294, 85);
			this.siexiste.Name = "siexiste";
			this.siexiste.Size = new global::System.Drawing.Size(156, 73);
			this.siexiste.TabIndex = 20;
			this.siexiste.TabStop = false;
			this.siexiste.Text = "If Already Exists";
			this.ignoar.Location = new global::System.Drawing.Point(6, 42);
			this.ignoar.Name = "ignoar";
			this.ignoar.Size = new global::System.Drawing.Size(144, 17);
			this.ignoar.TabIndex = 1;
			this.ignoar.Text = "Ignore";
			this.ignoar.UseVisualStyleBackColor = true;
			this.sobrescribe.Checked = true;
			this.sobrescribe.Location = new global::System.Drawing.Point(6, 19);
			this.sobrescribe.Name = "sobrescribe";
			this.sobrescribe.Size = new global::System.Drawing.Size(144, 17);
			this.sobrescribe.TabIndex = 0;
			this.sobrescribe.TabStop = true;
			this.sobrescribe.Text = "Overwrite";
			this.sobrescribe.UseVisualStyleBackColor = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(78, 17);
			this.label1.TabIndex = 22;
			this.label1.Text = "Files";
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.treeView1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.treeView1.CheckBoxes = true;
			this.treeView1.Location = new global::System.Drawing.Point(12, 29);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new global::System.Drawing.Size(276, 359);
			this.treeView1.TabIndex = 21;
			this.treeView1.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
			this.reloadpic.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.reloadpic.Image = global::TransferSingleApp.Properties.Resources.Reload;
			this.reloadpic.ImageLocation = "";
			this.reloadpic.Location = new global::System.Drawing.Point(272, 399);
			this.reloadpic.Name = "reloadpic";
			this.reloadpic.Size = new global::System.Drawing.Size(16, 16);
			this.reloadpic.TabIndex = 61;
			this.reloadpic.TabStop = false;
			this.reloadpic.Click += new global::System.EventHandler(this.reloadpic_Click);
			this.reloadpic.MouseEnter += new global::System.EventHandler(this.reloadpic_MouseEnter);
			this.reloadpic.MouseLeave += new global::System.EventHandler(this.reloadpic_MouseLeave);
			this.filesTodo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.filesTodo.Image = global::TransferSingleApp.Properties.Resources.SelTodos;
			this.filesTodo.ImageLocation = "";
			this.filesTodo.Location = new global::System.Drawing.Point(250, 10);
			this.filesTodo.Name = "filesTodo";
			this.filesTodo.Size = new global::System.Drawing.Size(16, 16);
			this.filesTodo.TabIndex = 58;
			this.filesTodo.TabStop = false;
			this.filesTodo.Click += new global::System.EventHandler(this.filesTodo_Click);
			this.filesTodo.MouseEnter += new global::System.EventHandler(this.filesTodo_MouseEnter);
			this.filesTodo.MouseLeave += new global::System.EventHandler(this.filesTodo_MouseLeave);
			this.filesNada.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.filesNada.Image = global::TransferSingleApp.Properties.Resources.SelNinguno;
			this.filesNada.Location = new global::System.Drawing.Point(272, 10);
			this.filesNada.Name = "filesNada";
			this.filesNada.Size = new global::System.Drawing.Size(16, 16);
			this.filesNada.TabIndex = 57;
			this.filesNada.TabStop = false;
			this.filesNada.Click += new global::System.EventHandler(this.filesNada_Click);
			this.filesNada.MouseEnter += new global::System.EventHandler(this.filesNada_MouseEnter);
			this.filesNada.MouseLeave += new global::System.EventHandler(this.filesNada_MouseLeave);
			this.ExpandNinguno.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ExpandNinguno.Image = global::TransferSingleApp.Properties.Resources.ExpNinguno;
			this.ExpandNinguno.Location = new global::System.Drawing.Point(228, 10);
			this.ExpandNinguno.Name = "ExpandNinguno";
			this.ExpandNinguno.Size = new global::System.Drawing.Size(16, 16);
			this.ExpandNinguno.TabIndex = 59;
			this.ExpandNinguno.TabStop = false;
			this.ExpandNinguno.Click += new global::System.EventHandler(this.ExpandNinguno_Click);
			this.ExpandNinguno.MouseEnter += new global::System.EventHandler(this.ExpandNinguno_MouseEnter);
			this.ExpandNinguno.MouseLeave += new global::System.EventHandler(this.ExpandNinguno_MouseLeave);
			this.ExpandTodos.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ExpandTodos.Image = global::TransferSingleApp.Properties.Resources.ExpTodos;
			this.ExpandTodos.ImageLocation = "";
			this.ExpandTodos.Location = new global::System.Drawing.Point(206, 10);
			this.ExpandTodos.Name = "ExpandTodos";
			this.ExpandTodos.Size = new global::System.Drawing.Size(16, 16);
			this.ExpandTodos.TabIndex = 60;
			this.ExpandTodos.TabStop = false;
			this.ExpandTodos.Click += new global::System.EventHandler(this.ExpandTodos_Click);
			this.ExpandTodos.MouseEnter += new global::System.EventHandler(this.ExpandTodos_MouseEnter);
			this.ExpandTodos.MouseLeave += new global::System.EventHandler(this.ExpandTodos_MouseLeave);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(460, 429);
			base.Controls.Add(this.reloadpic);
			base.Controls.Add(this.ExpandTodos);
			base.Controls.Add(this.ExpandNinguno);
			base.Controls.Add(this.filesTodo);
			base.Controls.Add(this.filesNada);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.treeView1);
			base.Controls.Add(this.siexiste);
			base.Controls.Add(this.logerror);
			base.Controls.Add(this.exit);
			base.Controls.Add(this.LoadFam);
			base.Controls.Add(this.includesub);
			base.Controls.Add(this.textodir);
			base.Controls.Add(this.selectfolder);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "FormLoad";
			this.Text = "Mass Load Families";
			base.Load += new global::System.EventHandler(this.FromLoad_Load);
			this.siexiste.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.reloadpic).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.filesTodo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.filesNada).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandNinguno).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandTodos).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000053 RID: 83
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.TextBox textodir;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.Button selectfolder;

		// Token: 0x04000056 RID: 86
		public global::System.Windows.Forms.CheckBox includesub;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Button exit;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.Button LoadFam;

		// Token: 0x04000059 RID: 89
		public global::System.Windows.Forms.CheckBox logerror;

		// Token: 0x0400005A RID: 90
		private global::System.Windows.Forms.GroupBox siexiste;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.RadioButton ignoar;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.RadioButton sobrescribe;

		// Token: 0x0400005D RID: 93
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400005E RID: 94
		public global::System.Windows.Forms.TreeView treeView1;

		// Token: 0x0400005F RID: 95
		private global::System.Windows.Forms.PictureBox filesTodo;

		// Token: 0x04000060 RID: 96
		private global::System.Windows.Forms.PictureBox filesNada;

		// Token: 0x04000061 RID: 97
		private global::System.Windows.Forms.PictureBox reloadpic;

		// Token: 0x04000062 RID: 98
		private global::System.Windows.Forms.PictureBox ExpandNinguno;

		// Token: 0x04000063 RID: 99
		private global::System.Windows.Forms.PictureBox ExpandTodos;
	}
}
