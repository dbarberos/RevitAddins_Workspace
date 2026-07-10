namespace TransferSingleApp
{
	// Token: 0x02000006 RID: 6
	public partial class BarraProgreso : global::System.Windows.Forms.Form
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002AE7 File Offset: 0x00000CE7
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002B08 File Offset: 0x00000D08
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.BarraProgreso));
			this.progressBar1 = new global::System.Windows.Forms.ProgressBar();
			this.btCancel = new global::System.Windows.Forms.Button();
			this.txt = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.progressBar1.Location = new global::System.Drawing.Point(13, 13);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new global::System.Drawing.Size(378, 23);
			this.progressBar1.TabIndex = 0;
			this.btCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btCancel.Location = new global::System.Drawing.Point(316, 42);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 1;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new global::System.EventHandler(this.btCancel_Click);
			this.txt.AutoSize = true;
			this.txt.Location = new global::System.Drawing.Point(13, 42);
			this.txt.Name = "txt";
			this.txt.Size = new global::System.Drawing.Size(107, 13);
			this.txt.TabIndex = 2;
			this.txt.Text = "Processing elements:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(403, 73);
			base.Controls.Add(this.txt);
			base.Controls.Add(this.btCancel);
			base.Controls.Add(this.progressBar1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "BarraProgreso";
			this.Text = "Collecting Standards";
			base.Load += new global::System.EventHandler(this.BarraProgreso_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000017 RID: 23
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.ProgressBar progressBar1;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.Button btCancel;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.Label txt;
	}
}
