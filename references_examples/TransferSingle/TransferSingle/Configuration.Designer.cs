namespace TransferSingleApp
{
	// Token: 0x02000008 RID: 8
	public partial class Configuration : global::System.Windows.Forms.Form
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000034F4 File Offset: 0x000016F4
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00003514 File Offset: 0x00001714
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.Configuration));
			this.Save = new global::System.Windows.Forms.Button();
			this.Cancel = new global::System.Windows.Forms.Button();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.TabOtro = new global::System.Windows.Forms.TextBox();
			this.sw_TabOtro = new global::System.Windows.Forms.RadioButton();
			this.sw_TabRevit = new global::System.Windows.Forms.RadioButton();
			this.sw_TabJOTools = new global::System.Windows.Forms.RadioButton();
			this.label1 = new global::System.Windows.Forms.Label();
			this.ch_HideMessages = new global::System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.Save.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.Save.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Save.Location = new global::System.Drawing.Point(116, 196);
			this.Save.Name = "Save";
			this.Save.Size = new global::System.Drawing.Size(75, 23);
			this.Save.TabIndex = 0;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Click += new global::System.EventHandler(this.Save_Click);
			this.Cancel.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.Cancel.Location = new global::System.Drawing.Point(197, 196);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new global::System.Drawing.Size(75, 23);
			this.Cancel.TabIndex = 1;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new global::System.EventHandler(this.Cancel_Click);
			this.groupBox1.Controls.Add(this.TabOtro);
			this.groupBox1.Controls.Add(this.sw_TabOtro);
			this.groupBox1.Controls.Add(this.sw_TabRevit);
			this.groupBox1.Controls.Add(this.sw_TabJOTools);
			this.groupBox1.Location = new global::System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(259, 120);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tab Options (*)";
			this.TabOtro.Location = new global::System.Drawing.Point(25, 89);
			this.TabOtro.MaxLength = 25;
			this.TabOtro.Name = "TabOtro";
			this.TabOtro.Size = new global::System.Drawing.Size(228, 20);
			this.TabOtro.TabIndex = 3;
			this.sw_TabOtro.AutoSize = true;
			this.sw_TabOtro.Location = new global::System.Drawing.Point(6, 65);
			this.sw_TabOtro.Name = "sw_TabOtro";
			this.sw_TabOtro.Size = new global::System.Drawing.Size(123, 17);
			this.sw_TabOtro.TabIndex = 2;
			this.sw_TabOtro.Text = "Place on tab named:";
			this.sw_TabOtro.UseVisualStyleBackColor = true;
			this.sw_TabRevit.AutoSize = true;
			this.sw_TabRevit.Location = new global::System.Drawing.Point(6, 42);
			this.sw_TabRevit.Name = "sw_TabRevit";
			this.sw_TabRevit.Size = new global::System.Drawing.Size(148, 17);
			this.sw_TabRevit.TabIndex = 1;
			this.sw_TabRevit.Text = "Place on Revit default tab";
			this.sw_TabRevit.UseVisualStyleBackColor = true;
			this.sw_TabJOTools.AutoSize = true;
			this.sw_TabJOTools.Checked = true;
			this.sw_TabJOTools.Location = new global::System.Drawing.Point(6, 19);
			this.sw_TabJOTools.Name = "sw_TabJOTools";
			this.sw_TabJOTools.Size = new global::System.Drawing.Size(168, 17);
			this.sw_TabJOTools.TabIndex = 0;
			this.sw_TabJOTools.TabStop = true;
			this.sw_TabJOTools.Text = "Place on JOTools tab (default)";
			this.sw_TabJOTools.UseVisualStyleBackColor = true;
			this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(10, 168);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(257, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "(*) You you must restart Revit to apply these changes";
			this.ch_HideMessages.AutoSize = true;
			this.ch_HideMessages.Location = new global::System.Drawing.Point(13, 140);
			this.ch_HideMessages.Name = "ch_HideMessages";
			this.ch_HideMessages.Size = new global::System.Drawing.Size(210, 17);
			this.ch_HideMessages.TabIndex = 4;
			this.ch_HideMessages.Text = "Hide messages when editing standards";
			this.ch_HideMessages.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 231);
			base.ControlBox = false;
			base.Controls.Add(this.ch_HideMessages);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.Cancel);
			base.Controls.Add(this.Save);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Configuration";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TransferSingle Config";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000023 RID: 35
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000024 RID: 36
		private global::System.Windows.Forms.Button Save;

		// Token: 0x04000025 RID: 37
		private global::System.Windows.Forms.Button Cancel;

		// Token: 0x04000026 RID: 38
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x04000027 RID: 39
		private global::System.Windows.Forms.TextBox TabOtro;

		// Token: 0x04000028 RID: 40
		private global::System.Windows.Forms.RadioButton sw_TabOtro;

		// Token: 0x04000029 RID: 41
		private global::System.Windows.Forms.RadioButton sw_TabRevit;

		// Token: 0x0400002A RID: 42
		private global::System.Windows.Forms.RadioButton sw_TabJOTools;

		// Token: 0x0400002B RID: 43
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400002C RID: 44
		private global::System.Windows.Forms.CheckBox ch_HideMessages;
	}
}
