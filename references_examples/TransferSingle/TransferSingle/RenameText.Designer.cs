namespace TransferSingleApp
{
	// Token: 0x0200000A RID: 10
	public partial class RenameText : global::System.Windows.Forms.Form
	{
		// Token: 0x06000035 RID: 53 RVA: 0x00003DC8 File Offset: 0x00001FC8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00003DE8 File Offset: 0x00001FE8
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.RenameText));
			this.button1 = new global::System.Windows.Forms.Button();
			this.btCancel = new global::System.Windows.Forms.Button();
			this.textofind = new global::System.Windows.Forms.TextBox();
			this.textoreplace = new global::System.Windows.Forms.TextBox();
			this.Find = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.chk_Regex = new global::System.Windows.Forms.CheckBox();
			base.SuspendLayout();
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.Location = new global::System.Drawing.Point(198, 85);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(75, 23);
			this.button1.TabIndex = 5;
			this.button1.Text = "Ok";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.btCancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btCancel.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btCancel.Location = new global::System.Drawing.Point(279, 85);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new global::System.Drawing.Size(75, 23);
			this.btCancel.TabIndex = 4;
			this.btCancel.Text = "Cancel";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new global::System.EventHandler(this.btCancel_Click);
			this.textofind.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textofind.Location = new global::System.Drawing.Point(72, 15);
			this.textofind.Name = "textofind";
			this.textofind.Size = new global::System.Drawing.Size(282, 20);
			this.textofind.TabIndex = 6;
			this.textofind.TextChanged += new global::System.EventHandler(this.texto_TextChanged);
			this.textoreplace.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textoreplace.Location = new global::System.Drawing.Point(72, 43);
			this.textoreplace.Name = "textoreplace";
			this.textoreplace.Size = new global::System.Drawing.Size(282, 20);
			this.textoreplace.TabIndex = 7;
			this.Find.AutoSize = true;
			this.Find.Location = new global::System.Drawing.Point(12, 18);
			this.Find.Name = "Find";
			this.Find.Size = new global::System.Drawing.Size(30, 13);
			this.Find.TabIndex = 8;
			this.Find.Text = "Find:";
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 46);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(50, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Replace:";
			this.chk_Regex.AutoSize = true;
			this.chk_Regex.Location = new global::System.Drawing.Point(72, 69);
			this.chk_Regex.Name = "chk_Regex";
			this.chk_Regex.Size = new global::System.Drawing.Size(79, 17);
			this.chk_Regex.TabIndex = 11;
			this.chk_Regex.Text = "Use Regex";
			this.chk_Regex.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(366, 120);
			base.Controls.Add(this.chk_Regex);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.Find);
			base.Controls.Add(this.textoreplace);
			base.Controls.Add(this.textofind);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.btCancel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "RenameText";
			this.Text = "Find and Replace";
			base.Load += new global::System.EventHandler(this.RenameText_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000034 RID: 52
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000035 RID: 53
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.Button btCancel;

		// Token: 0x04000037 RID: 55
		private global::System.Windows.Forms.TextBox textofind;

		// Token: 0x04000038 RID: 56
		private global::System.Windows.Forms.TextBox textoreplace;

		// Token: 0x04000039 RID: 57
		private global::System.Windows.Forms.Label Find;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.CheckBox chk_Regex;
	}
}
