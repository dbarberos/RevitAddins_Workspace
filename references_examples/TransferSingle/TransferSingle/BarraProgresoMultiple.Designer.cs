namespace TransferSingleApp
{
	// Token: 0x02000007 RID: 7
	public partial class BarraProgresoMultiple : global::System.Windows.Forms.Form
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00002FE7 File Offset: 0x000011E7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003008 File Offset: 0x00001208
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.BarraProgresoMultiple));
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.btCancel = new global::System.Windows.Forms.Button();
			this.txt = new global::System.Windows.Forms.Label();
			this.progressMain = new global::System.Windows.Forms.ProgressBar();
			this.txtMain = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.progressBar1.Location = new global::System.Drawing.Point(12, 60);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(378, 23);
			this.progressBar1.TabIndex = 0;
			this.btCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btCancel.Location = new global::System.Drawing.Point(315, 89);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new global::System.EventHandler(this.btCancel_Click);
			this.txt.Location = new global::System.Drawing.Point(12, 89);
			this.txt.Name = "txt";
			this.txt.Size = new global::System.Drawing.Size(297, 13);
			this.txt.TabIndex = 2;
			this.txt.Text = "Processing elements:";
			this.progressMain.Location = new global::System.Drawing.Point(13, 12);
			this.progressMain.Name = "progressMain";
			this.progressMain.Size = new global::System.Drawing.Size(378, 23);
			this.progressMain.TabIndex = 3;
			this.txtMain.Location = new global::System.Drawing.Point(12, 38);
			this.txtMain.Name = "txtMain";
			this.txtMain.Size = new global::System.Drawing.Size(378, 13);
			this.txtMain.TabIndex = 4;
			this.txtMain.Text = "Processing elements:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(403, 120);
			base.Controls.Add(this.txtMain);
			base.Controls.Add(this.progressMain);
			base.Controls.Add(this.txt);
			base.Controls.Add(this.btCancel);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "BarraProgresoMultiple";
			this.Text = "Collecting Standards";
			base.Load += new global::System.EventHandler(this.BarraProgreso_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x0400001C RID: 28
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.Button btCancel;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Label txt;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.ProgressBar progressMain;

		// Token: 0x04000021 RID: 33
		private global::System.Windows.Forms.Label txtMain;
	}
}
