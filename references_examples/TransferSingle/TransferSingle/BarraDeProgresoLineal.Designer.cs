namespace TransferSingleApp
{
	// Token: 0x02000005 RID: 5
	public partial class BarraDeProgresoLineal : global::System.Windows.Forms.Form
	{
		// Token: 0x06000012 RID: 18 RVA: 0x00002675 File Offset: 0x00000875
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002694 File Offset: 0x00000894
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.BarraDeProgresoLineal));
			this.cancelarbarra = new global::System.Windows.Forms.Button();
			this.progreso = new global::System.Windows.Forms.ProgressBar();
			this.textobarra = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.cancelarbarra.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cancelarbarra.Location = new global::System.Drawing.Point(309, 41);
			this.cancelarbarra.Name = "cancelarbarra";
			this.cancelarbarra.Size = new global::System.Drawing.Size(75, 25);
			this.cancelarbarra.TabIndex = 3;
			this.cancelarbarra.Text = "Cancel";
			this.cancelarbarra.UseVisualStyleBackColor = true;
			this.cancelarbarra.Click += new global::System.EventHandler(this.cancelarbarra_Click);
			this.progreso.Location = new global::System.Drawing.Point(12, 12);
			this.progreso.MarqueeAnimationSpeed = 200;
			this.progreso.Name = "progreso";
			this.progreso.Size = new global::System.Drawing.Size(372, 23);
			this.progreso.Step = 1;
			this.progreso.Style = global::System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progreso.TabIndex = 2;
			this.textobarra.AutoSize = true;
			this.textobarra.Location = new global::System.Drawing.Point(9, 41);
			this.textobarra.Name = "textobarra";
			this.textobarra.Size = new global::System.Drawing.Size(73, 13);
			this.textobarra.TabIndex = 4;
			this.textobarra.Text = "Procesando...";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(396, 71);
			base.Controls.Add(this.textobarra);
			base.Controls.Add(this.cancelarbarra);
			base.Controls.Add(this.progreso);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "BarraDeProgresoLineal";
			this.Text = "Processing Families";
			base.Load += new global::System.EventHandler(this.BarraDeProgresoLineal_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000012 RID: 18
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000013 RID: 19
		private global::System.Windows.Forms.Button cancelarbarra;

		// Token: 0x04000014 RID: 20
		public global::System.Windows.Forms.ProgressBar progreso;

		// Token: 0x04000015 RID: 21
		public global::System.Windows.Forms.Label textobarra;
	}
}
