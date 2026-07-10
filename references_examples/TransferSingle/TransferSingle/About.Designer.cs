namespace TransferSingleApp
{
	// Token: 0x02000009 RID: 9
	public partial class About : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00003B18 File Offset: 0x00001D18
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00003B38 File Offset: 0x00001D38
		private void InitializeComponent()
		{
			this.button1 = new global::System.Windows.Forms.Button();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.button1.Location = new global::System.Drawing.Point(197, 59);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(192, 39);
			this.label1.TabIndex = 1;
			this.label1.Text = "TransferSingle by Juan Osborne\r\nhttp://www.juanosborne.com/\r\nContact me at juanosborne@gmail.com";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 94);
			base.ControlBox = false;
			base.Controls.Add(this.label1);
			base.Controls.Add(this.button1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "About";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About TransferSingle";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400002D RID: 45
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400002E RID: 46
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400002F RID: 47
		private global::System.Windows.Forms.Label label1;
	}
}
