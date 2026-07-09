namespace TransferSingleApp
{
	// Token: 0x02000018 RID: 24
	public partial class TakeText : global::System.Windows.Forms.Form
	{
		// Token: 0x060000AB RID: 171 RVA: 0x00007F85 File Offset: 0x00006185
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00007FA4 File Offset: 0x000061A4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.TakeText));
			this.button1 = new global::System.Windows.Forms.Button();
			this.btCancel = new global::System.Windows.Forms.Button();
			this.texto = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Location = new global::System.Drawing.Point(162, 12);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.btCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btCancel.Location = new global::System.Drawing.Point(243, 12);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 4;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new global::System.EventHandler(this.btCancel_Click);
			this.texto.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.texto.Location = new global::System.Drawing.Point(12, 13);
			this.texto.Name = "texto";
			this.texto.Size = new global::System.Drawing.Size(144, 20);
			this.texto.TabIndex = 6;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(330, 43);
			base.Controls.Add(this.texto);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.btCancel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "TakeText";
			this.Text = "Type Text";
			base.Load += new global::System.EventHandler(this.TakeText_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400008B RID: 139
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Button button1;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.Button btCancel;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.TextBox texto;
	}
}
