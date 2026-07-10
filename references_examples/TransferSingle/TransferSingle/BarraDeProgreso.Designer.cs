namespace TransferSingleApp
{
	// Token: 0x02000004 RID: 4
	public partial class BarraDeProgreso : global::System.Windows.Forms.Form
	{
		// Token: 0x0600000C RID: 12 RVA: 0x000023A5 File Offset: 0x000005A5
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000023C4 File Offset: 0x000005C4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.BarraDeProgreso));
			this.progreso = new global::System.Windows.Forms.ProgressBar();
			this.cancelarbarra = new global::System.Windows.Forms.Button();
			this.textobarra = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.progreso.Location = new global::System.Drawing.Point(13, 13);
			this.progreso.MarqueeAnimationSpeed = 200;
			this.progreso.Name = "progreso";
			this.progreso.Size = new global::System.Drawing.Size(370, 23);
			this.progreso.Step = 5;
			this.progreso.Style = global::System.Windows.Forms.ProgressBarStyle.Marquee;
			this.progreso.TabIndex = 0;
			this.cancelarbarra.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cancelarbarra.Location = new global::System.Drawing.Point(308, 42);
			this.cancelarbarra.Name = "cancelarbarra";
			this.cancelarbarra.Size = new global::System.Drawing.Size(75, 25);
			this.cancelarbarra.TabIndex = 1;
			this.cancelarbarra.Text = "Cancel";
			this.cancelarbarra.UseVisualStyleBackColor = true;
			this.cancelarbarra.Click += new global::System.EventHandler(this.cancelarbarra_Click);
			this.textobarra.AutoSize = true;
			this.textobarra.Location = new global::System.Drawing.Point(12, 42);
			this.textobarra.Name = "textobarra";
			this.textobarra.Size = new global::System.Drawing.Size(0, 13);
			this.textobarra.TabIndex = 2;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(392, 73);
			base.Controls.Add(this.textobarra);
			base.Controls.Add(this.cancelarbarra);
			base.Controls.Add(this.progreso);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BarraDeProgreso";
			this.Text = "Processing Families";
			base.Load += new global::System.EventHandler(this.BarraDeProgreso_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000D RID: 13
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000E RID: 14
		private global::System.Windows.Forms.Button cancelarbarra;

		// Token: 0x0400000F RID: 15
		public global::System.Windows.Forms.ProgressBar progreso;

		// Token: 0x04000010 RID: 16
		public global::System.Windows.Forms.Label textobarra;
	}
}
