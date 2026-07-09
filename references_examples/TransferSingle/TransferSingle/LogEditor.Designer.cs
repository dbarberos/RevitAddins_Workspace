namespace TransferSingleApp
{
	// Token: 0x0200000D RID: 13
	public partial class LogEditor : global::System.Windows.Forms.Form
	{
		// Token: 0x06000080 RID: 128 RVA: 0x00006794 File Offset: 0x00004994
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000081 RID: 129 RVA: 0x000067B4 File Offset: 0x000049B4
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.LogEditor));
			this.btOK = new global::System.Windows.Forms.Button();
			this.btSalvaLog = new global::System.Windows.Forms.Button();
			this.txtLog = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.btOK.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btOK.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btOK.Location = new global::System.Drawing.Point(328, 458);
			this.btOK.Name = "btOK";
			this.btOK.Size = new global::System.Drawing.Size(75, 23);
			this.btOK.TabIndex = 4;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new global::System.EventHandler(this.btOK_Click);
			this.btSalvaLog.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btSalvaLog.Location = new global::System.Drawing.Point(328, 429);
			this.btSalvaLog.Name = "btSalvaLog";
			this.btSalvaLog.Size = new global::System.Drawing.Size(75, 23);
			this.btSalvaLog.TabIndex = 3;
			this.btSalvaLog.Text = "Save Log";
			this.btSalvaLog.UseVisualStyleBackColor = true;
			this.btSalvaLog.Click += new global::System.EventHandler(this.btSalvaLog_Click);
			this.txtLog.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.txtLog.Font = new global::System.Drawing.Font("Courier New", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtLog.Location = new global::System.Drawing.Point(12, 12);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.ScrollBars = global::System.Windows.Forms.ScrollBars.Both;
			this.txtLog.Size = new global::System.Drawing.Size(391, 402);
			this.txtLog.TabIndex = 5;
			this.txtLog.Text = "Log File\r\nContent";
			this.txtLog.WordWrap = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(415, 493);
			base.Controls.Add(this.txtLog);
			base.Controls.Add(this.btOK);
			base.Controls.Add(this.btSalvaLog);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "LogEditor";
			this.Text = "Log Editor";
			base.Load += new global::System.EventHandler(this.LogEditor_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000065 RID: 101
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000066 RID: 102
		private global::System.Windows.Forms.Button btOK;

		// Token: 0x04000067 RID: 103
		private global::System.Windows.Forms.Button btSalvaLog;

		// Token: 0x04000068 RID: 104
		private global::System.Windows.Forms.TextBox txtLog;
	}
}
