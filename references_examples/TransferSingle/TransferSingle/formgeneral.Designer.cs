namespace TransferSingleApp
{
	// Token: 0x0200000B RID: 11
	public partial class formgeneral : global::System.Windows.Forms.Form
	{
		// Token: 0x06000055 RID: 85 RVA: 0x000046EB File Offset: 0x000028EB
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000470C File Offset: 0x0000290C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.formgeneral));
			this.treeView1 = new global::System.Windows.Forms.TreeView();
			this.label1 = new global::System.Windows.Forms.Label();
			this.SaveFam = new global::System.Windows.Forms.Button();
			this.exit = new global::System.Windows.Forms.Button();
			this.tofolders = new global::System.Windows.Forms.CheckBox();
			this.selectfolder = new global::System.Windows.Forms.Button();
			this.textodir = new global::System.Windows.Forms.TextBox();
			this.addcat = new global::System.Windows.Forms.CheckBox();
			this.logerror = new global::System.Windows.Forms.CheckBox();
			this.fija3d = new global::System.Windows.Forms.CheckBox();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.ignorar = new global::System.Windows.Forms.RadioButton();
			this.sobreescribir = new global::System.Windows.Forms.RadioButton();
			this.filesTodo = new global::System.Windows.Forms.PictureBox();
			this.filesNada = new global::System.Windows.Forms.PictureBox();
			this.ExpandNinguno = new global::System.Windows.Forms.PictureBox();
			this.ExpandTodos = new global::System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.filesTodo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.filesNada).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandNinguno).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandTodos).BeginInit();
			base.SuspendLayout();
			this.treeView1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.treeView1.CheckBoxes = true;
			this.treeView1.Location = new global::System.Drawing.Point(10, 30);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new global::System.Drawing.Size(320, 445);
			this.treeView1.TabIndex = 0;
			this.treeView1.AfterCheck += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
			this.treeView1.AfterSelect += new global::System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(8, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(68, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Families";
			this.SaveFam.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.SaveFam.Location = new global::System.Drawing.Point(336, 419);
			this.SaveFam.Name = "SaveFam";
			this.SaveFam.Size = new global::System.Drawing.Size(155, 25);
			this.SaveFam.TabIndex = 8;
			this.SaveFam.Text = "Save Families";
			this.SaveFam.UseVisualStyleBackColor = true;
			this.SaveFam.Click += new global::System.EventHandler(this.ToExcel_Click);
			this.exit.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.exit.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.exit.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.exit.Location = new global::System.Drawing.Point(336, 450);
			this.exit.Name = "exit";
			this.exit.Size = new global::System.Drawing.Size(155, 25);
			this.exit.TabIndex = 9;
			this.exit.Text = "Cancel";
			this.exit.UseVisualStyleBackColor = true;
			this.exit.Click += new global::System.EventHandler(this.exit_Click);
			this.tofolders.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.tofolders.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.tofolders.Location = new global::System.Drawing.Point(336, 30);
			this.tofolders.Name = "tofolders";
			this.tofolders.Size = new global::System.Drawing.Size(144, 30);
			this.tofolders.TabIndex = 10;
			this.tofolders.Text = "Save Files in\r\nSubfolders";
			this.tofolders.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.tofolders.UseVisualStyleBackColor = true;
			this.tofolders.CheckedChanged += new global::System.EventHandler(this.addcat_CheckedChanged);
			this.selectfolder.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.selectfolder.Location = new global::System.Drawing.Point(10, 481);
			this.selectfolder.Name = "selectfolder";
			this.selectfolder.Size = new global::System.Drawing.Size(94, 23);
			this.selectfolder.TabIndex = 12;
			this.selectfolder.Text = "Select Folder";
			this.selectfolder.UseVisualStyleBackColor = true;
			this.selectfolder.Click += new global::System.EventHandler(this.selectfolder_Click);
			this.textodir.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textodir.Location = new global::System.Drawing.Point(110, 483);
			this.textodir.Name = "textodir";
			this.textodir.Size = new global::System.Drawing.Size(220, 20);
			this.textodir.TabIndex = 13;
			this.textodir.TextChanged += new global::System.EventHandler(this.textodir_TextChanged);
			this.addcat.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.addcat.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.addcat.Location = new global::System.Drawing.Point(336, 66);
			this.addcat.Name = "addcat";
			this.addcat.Size = new global::System.Drawing.Size(143, 30);
			this.addcat.TabIndex = 14;
			this.addcat.Text = "Add Category to File Name";
			this.addcat.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.addcat.UseVisualStyleBackColor = true;
			this.logerror.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.logerror.Checked = true;
			this.logerror.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.logerror.Location = new global::System.Drawing.Point(336, 138);
			this.logerror.Name = "logerror";
			this.logerror.Size = new global::System.Drawing.Size(143, 17);
			this.logerror.TabIndex = 15;
			this.logerror.Text = "Log Errors";
			this.logerror.UseVisualStyleBackColor = true;
			this.fija3d.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.fija3d.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.fija3d.Location = new global::System.Drawing.Point(336, 102);
			this.fija3d.Name = "fija3d";
			this.fija3d.Size = new global::System.Drawing.Size(143, 30);
			this.fija3d.TabIndex = 16;
			this.fija3d.Text = "Set Default View\r\nas 3D View";
			this.fija3d.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.fija3d.UseVisualStyleBackColor = true;
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.Controls.Add(this.ignorar);
			this.groupBox1.Controls.Add(this.sobreescribir);
			this.groupBox1.Location = new global::System.Drawing.Point(336, 173);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(155, 86);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "If File Exists";
			this.ignorar.Location = new global::System.Drawing.Point(6, 43);
			this.ignorar.Name = "ignorar";
			this.ignorar.Size = new global::System.Drawing.Size(128, 17);
			this.ignorar.TabIndex = 1;
			this.ignorar.Text = "Ignore";
			this.ignorar.UseVisualStyleBackColor = true;
			this.sobreescribir.Checked = true;
			this.sobreescribir.Location = new global::System.Drawing.Point(6, 20);
			this.sobreescribir.Name = "sobreescribir";
			this.sobreescribir.Size = new global::System.Drawing.Size(128, 17);
			this.sobreescribir.TabIndex = 0;
			this.sobreescribir.TabStop = true;
			this.sobreescribir.Text = "Overwrite";
			this.sobreescribir.UseVisualStyleBackColor = true;
			this.filesTodo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.filesTodo.Image = global::TransferSingleApp.Properties.Resources.SelTodos;
			this.filesTodo.ImageLocation = "";
			this.filesTodo.Location = new global::System.Drawing.Point(292, 11);
			this.filesTodo.Name = "filesTodo";
			this.filesTodo.Size = new global::System.Drawing.Size(16, 16);
			this.filesTodo.TabIndex = 62;
			this.filesTodo.TabStop = false;
			this.filesTodo.Click += new global::System.EventHandler(this.filesTodo_Click);
			this.filesTodo.MouseEnter += new global::System.EventHandler(this.filesTodo_MouseEnter);
			this.filesTodo.MouseLeave += new global::System.EventHandler(this.filesTodo_MouseLeave);
			this.filesNada.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.filesNada.Image = global::TransferSingleApp.Properties.Resources.SelNinguno;
			this.filesNada.Location = new global::System.Drawing.Point(314, 11);
			this.filesNada.Name = "filesNada";
			this.filesNada.Size = new global::System.Drawing.Size(16, 16);
			this.filesNada.TabIndex = 61;
			this.filesNada.TabStop = false;
			this.filesNada.Click += new global::System.EventHandler(this.filesNada_Click);
			this.filesNada.MouseEnter += new global::System.EventHandler(this.filesNada_MouseEnter);
			this.filesNada.MouseLeave += new global::System.EventHandler(this.filesNada_MouseLeave);
			this.ExpandNinguno.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ExpandNinguno.Image = global::TransferSingleApp.Properties.Resources.ExpNinguno;
			this.ExpandNinguno.Location = new global::System.Drawing.Point(270, 11);
			this.ExpandNinguno.Name = "ExpandNinguno";
			this.ExpandNinguno.Size = new global::System.Drawing.Size(16, 16);
			this.ExpandNinguno.TabIndex = 63;
			this.ExpandNinguno.TabStop = false;
			this.ExpandNinguno.Click += new global::System.EventHandler(this.ExpandNinguno_Click);
			this.ExpandNinguno.MouseEnter += new global::System.EventHandler(this.ExpandNinguno_MouseEnter);
			this.ExpandNinguno.MouseLeave += new global::System.EventHandler(this.ExpandNinguno_MouseLeave);
			this.ExpandTodos.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ExpandTodos.Image = global::TransferSingleApp.Properties.Resources.ExpTodos;
			this.ExpandTodos.ImageLocation = "";
			this.ExpandTodos.Location = new global::System.Drawing.Point(248, 11);
			this.ExpandTodos.Name = "ExpandTodos";
			this.ExpandTodos.Size = new global::System.Drawing.Size(16, 16);
			this.ExpandTodos.TabIndex = 64;
			this.ExpandTodos.TabStop = false;
			this.ExpandTodos.Click += new global::System.EventHandler(this.ExpandTodos_Click);
			this.ExpandTodos.MouseEnter += new global::System.EventHandler(this.ExpandTodos_MouseEnter);
			this.ExpandTodos.MouseLeave += new global::System.EventHandler(this.ExpandTodos_MouseLeave);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.exit;
			base.ClientSize = new global::System.Drawing.Size(503, 514);
			base.Controls.Add(this.ExpandTodos);
			base.Controls.Add(this.ExpandNinguno);
			base.Controls.Add(this.filesTodo);
			base.Controls.Add(this.filesNada);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.fija3d);
			base.Controls.Add(this.logerror);
			base.Controls.Add(this.addcat);
			base.Controls.Add(this.textodir);
			base.Controls.Add(this.selectfolder);
			base.Controls.Add(this.tofolders);
			base.Controls.Add(this.exit);
			base.Controls.Add(this.SaveFam);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.treeView1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "formgeneral";
			this.Text = "Mass Save Families";
			base.Load += new global::System.EventHandler(this.form1_Load);
			this.groupBox1.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.filesTodo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.filesNada).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandNinguno).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandTodos).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400003E RID: 62
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Button SaveFam;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.Button exit;

		// Token: 0x04000042 RID: 66
		public global::System.Windows.Forms.TreeView treeView1;

		// Token: 0x04000043 RID: 67
		private global::System.Windows.Forms.Button selectfolder;

		// Token: 0x04000044 RID: 68
		private global::System.Windows.Forms.TextBox textodir;

		// Token: 0x04000045 RID: 69
		public global::System.Windows.Forms.CheckBox tofolders;

		// Token: 0x04000046 RID: 70
		public global::System.Windows.Forms.CheckBox addcat;

		// Token: 0x04000047 RID: 71
		public global::System.Windows.Forms.CheckBox logerror;

		// Token: 0x04000048 RID: 72
		public global::System.Windows.Forms.CheckBox fija3d;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400004A RID: 74
		public global::System.Windows.Forms.RadioButton ignorar;

		// Token: 0x0400004B RID: 75
		public global::System.Windows.Forms.RadioButton sobreescribir;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.PictureBox filesTodo;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.PictureBox filesNada;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.PictureBox ExpandNinguno;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.PictureBox ExpandTodos;
	}
}
