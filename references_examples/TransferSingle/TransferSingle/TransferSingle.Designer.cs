namespace TransferSingleApp
{
	// Token: 0x02000019 RID: 25
	public partial class TransferSingle : global::System.Windows.Forms.Form
	{
		// Token: 0x0600012E RID: 302 RVA: 0x000112BC File Offset: 0x0000F4BC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x000112DC File Offset: 0x0000F4DC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::TransferSingleApp.TransferSingle));
			this.tlElementos = new global::BrightIdeasSoftware.TreeListView();
			this.Arbol = new global::BrightIdeasSoftware.OLVColumn();
			this.Numero = new global::BrightIdeasSoftware.OLVColumn();
			this.Cuenta = new global::BrightIdeasSoftware.OLVColumn();
			this.bt_Transfer = new global::System.Windows.Forms.Button();
			this.txtSelection = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pOrigen = new global::System.Windows.Forms.ComboBox();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.foArchivos = new global::BrightIdeasSoftware.FastObjectListView();
			this.Files = new global::BrightIdeasSoftware.OLVColumn();
			this.btVerLog = new global::System.Windows.Forms.Button();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label7 = new global::System.Windows.Forms.Label();
			this.rbAsk = new global::System.Windows.Forms.RadioButton();
			this.chk_AcceptAll = new global::System.Windows.Forms.CheckBox();
			this.rbCancel = new global::System.Windows.Forms.RadioButton();
			this.rbOverride = new global::System.Windows.Forms.RadioButton();
			this.chk_SheetWithViews = new global::System.Windows.Forms.CheckBox();
			this.chk_ViewElements = new global::System.Windows.Forms.CheckBox();
			this.chk_Callout = new global::System.Windows.Forms.CheckBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.clipId = new global::System.Windows.Forms.PictureBox();
			this.clip = new global::System.Windows.Forms.PictureBox();
			this.aboutToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.configureToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new global::System.Windows.Forms.MenuStrip();
			this.configuracion = new global::System.Windows.Forms.PictureBox();
			this.ExpandTodos = new global::System.Windows.Forms.PictureBox();
			this.ExpandNinguno = new global::System.Windows.Forms.PictureBox();
			this.vistasTodo = new global::System.Windows.Forms.PictureBox();
			this.vistasNada = new global::System.Windows.Forms.PictureBox();
			this.menuElements = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.deleteToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.findAndReplaceToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.addPrefixToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.chekedElemensToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.addSufixToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedElementsToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.changeCaseToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.uPPERCASEToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedElementsToolStripMenuItem1 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.lowerCaseToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedElementsToolStripMenuItem2 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.properCaseToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedElementsToolStripMenuItem3 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem4 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.namesToClipboardToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedElementsToolStripMenuItem4 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem5 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.idsToClipboardToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkedElementsToolStripMenuItem5 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.selectedElementsToolStripMenuItem6 = new global::System.Windows.Forms.ToolStripMenuItem();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.button3 = new global::System.Windows.Forms.Button();
			this.button2 = new global::System.Windows.Forms.Button();
			this.button1 = new global::System.Windows.Forms.Button();
			this.bt_AddSuffix = new global::System.Windows.Forms.Button();
			this.bt_AddPrefix = new global::System.Windows.Forms.Button();
			this.bt_FindReplace = new global::System.Windows.Forms.Button();
			this.bt_Delete = new global::System.Windows.Forms.Button();
			this.label6 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.Search = new global::System.Windows.Forms.Button();
			this.textBusca = new global::System.Windows.Forms.TextBox();
			this.chk_Links = new global::System.Windows.Forms.CheckBox();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label5 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.chk_GetTransformShared = new global::System.Windows.Forms.RadioButton();
			this.chk_GetTransformLink = new global::System.Windows.Forms.RadioButton();
			this.chk_GetTransformNone = new global::System.Windows.Forms.RadioButton();
			this.label8 = new global::System.Windows.Forms.Label();
			this.tlElementos.BeginInit();
			this.foArchivos.BeginInit();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.clipId).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.clip).BeginInit();
			this.menuStrip1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.configuracion).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandTodos).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandNinguno).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.vistasTodo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.vistasNada).BeginInit();
			this.menuElements.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			base.SuspendLayout();
			this.tlElementos.AllColumns.Add(this.Arbol);
			this.tlElementos.AllColumns.Add(this.Numero);
			this.tlElementos.AllColumns.Add(this.Cuenta);
			this.tlElementos.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.tlElementos.CellEditActivation = 2;
			this.tlElementos.CellEditUseWholeCell = false;
			this.tlElementos.CheckBoxes = true;
			this.tlElementos.CheckedAspectName = "Checked";
			this.tlElementos.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.Arbol,
				this.Numero,
				this.Cuenta
			});
			this.tlElementos.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.tlElementos.HideSelection = false;
			this.tlElementos.Location = new global::System.Drawing.Point(12, 81);
			this.tlElementos.Name = "tlElementos";
			this.tlElementos.ShowGroups = false;
			this.tlElementos.ShowImagesOnSubItems = true;
			this.tlElementos.Size = new global::System.Drawing.Size(386, 386);
			this.tlElementos.Sorting = global::System.Windows.Forms.SortOrder.Ascending;
			this.tlElementos.TabIndex = 0;
			this.tlElementos.UseCellFormatEvents = true;
			this.tlElementos.UseCompatibleStateImageBehavior = false;
			this.tlElementos.View = global::System.Windows.Forms.View.Details;
			this.tlElementos.VirtualMode = true;
			this.tlElementos.CellEditFinishing += new global::BrightIdeasSoftware.CellEditEventHandler(this.tlElementos_CellEditFinishing);
			this.tlElementos.CellEditStarting += new global::BrightIdeasSoftware.CellEditEventHandler(this.tlElementos_CellEditStarting);
			this.tlElementos.CellRightClick += new global::System.EventHandler<global::BrightIdeasSoftware.CellRightClickEventArgs>(this.tlElementos_CellRightClick);
			this.tlElementos.FormatCell += new global::System.EventHandler<global::BrightIdeasSoftware.FormatCellEventArgs>(this.tlElementos_FormatCell);
			this.tlElementos.ItemsChanged += new global::System.EventHandler<global::BrightIdeasSoftware.ItemsChangedEventArgs>(this.tlElementos_ItemsChanged);
			this.tlElementos.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.tlElementos_ItemCheck_1);
			this.tlElementos.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.tlElementos_ItemChecked);
			this.tlElementos.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.tlElementos_MouseUp);
			this.Arbol.AspectName = "Descripcion";
			this.Arbol.CellEditUseWholeCell = new bool?(true);
			this.Arbol.FillsFreeSpace = true;
			this.Arbol.Text = "Elements";
			this.Arbol.Width = 260;
			this.Numero.AspectName = "SheetNumber";
			this.Numero.IsEditable = false;
			this.Numero.Text = "Num";
			this.Cuenta.AspectName = "Num";
			this.Cuenta.IsEditable = false;
			this.Cuenta.Text = "Count";
			this.bt_Transfer.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.bt_Transfer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bt_Transfer.Location = new global::System.Drawing.Point(404, 660);
			this.bt_Transfer.Name = "bt_Transfer";
			this.bt_Transfer.Size = new global::System.Drawing.Size(137, 35);
			this.bt_Transfer.TabIndex = 1;
			this.bt_Transfer.Text = "Transfer Single";
			this.bt_Transfer.UseVisualStyleBackColor = true;
			this.bt_Transfer.Click += new global::System.EventHandler(this.bt_Filtra_Click);
			this.txtSelection.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtSelection.Location = new global::System.Drawing.Point(7, 22);
			this.txtSelection.Name = "txtSelection";
			this.txtSelection.Size = new global::System.Drawing.Size(106, 18);
			this.txtSelection.TabIndex = 60;
			this.txtSelection.Text = "0";
			this.txtSelection.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.txtSelection.Click += new global::System.EventHandler(this.txtSelection_Click);
			this.label1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label1.Location = new global::System.Drawing.Point(12, 500);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(206, 16);
			this.label1.TabIndex = 61;
			this.label1.Text = "To:";
			this.label1.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.label1.Click += new global::System.EventHandler(this.label1_Click);
			this.pOrigen.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.pOrigen.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.pOrigen.FormattingEnabled = true;
			this.pOrigen.Location = new global::System.Drawing.Point(12, 23);
			this.pOrigen.Name = "pOrigen";
			this.pOrigen.Size = new global::System.Drawing.Size(386, 21);
			this.pOrigen.TabIndex = 64;
			this.pOrigen.SelectedIndexChanged += new global::System.EventHandler(this.pOrigen_SelectedIndexChanged);
			this.pOrigen.MouseWheel += new global::System.Windows.Forms.MouseEventHandler(this.pOrigen_MouseWheel);
			this.label2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label2.Location = new global::System.Drawing.Point(12, 4);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(206, 16);
			this.label2.TabIndex = 63;
			this.label2.Text = "From:";
			this.label2.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Location = new global::System.Drawing.Point(3, 1);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(109, 20);
			this.label3.TabIndex = 66;
			this.label3.Text = "Elements Selected:";
			this.label3.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.foArchivos.AllColumns.Add(this.Files);
			this.foArchivos.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.foArchivos.CellEditActivation = 2;
			this.foArchivos.CellEditUseWholeCell = false;
			this.foArchivos.CheckBoxes = true;
			this.foArchivos.CheckedAspectName = "Checked";
			this.foArchivos.Columns.AddRange(new global::System.Windows.Forms.ColumnHeader[]
			{
				this.Files
			});
			this.foArchivos.HeaderStyle = global::System.Windows.Forms.ColumnHeaderStyle.None;
			this.foArchivos.HideSelection = false;
			this.foArchivos.Location = new global::System.Drawing.Point(12, 489);
			this.foArchivos.Name = "foArchivos";
			this.foArchivos.ShowGroups = false;
			this.foArchivos.ShowImagesOnSubItems = true;
			this.foArchivos.Size = new global::System.Drawing.Size(386, 162);
			this.foArchivos.TabIndex = 67;
			this.foArchivos.UseCompatibleStateImageBehavior = false;
			this.foArchivos.UseHotItem = true;
			this.foArchivos.UseTranslucentHotItem = true;
			this.foArchivos.UseTranslucentSelection = true;
			this.foArchivos.View = global::System.Windows.Forms.View.Details;
			this.foArchivos.VirtualMode = true;
			this.foArchivos.ItemCheck += new global::System.Windows.Forms.ItemCheckEventHandler(this.foArchivos_ItemCheck);
			this.foArchivos.ItemChecked += new global::System.Windows.Forms.ItemCheckedEventHandler(this.foArchivos_ItemChecked);
			this.foArchivos.Click += new global::System.EventHandler(this.foArchivos_Click);
			this.Files.AspectName = "Nombre";
			this.Files.FillsFreeSpace = true;
			this.Files.Text = "Project File Name";
			this.Files.Width = 120;
			this.btVerLog.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.btVerLog.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btVerLog.Location = new global::System.Drawing.Point(547, 660);
			this.btVerLog.Name = "btVerLog";
			this.btVerLog.Size = new global::System.Drawing.Size(43, 35);
			this.btVerLog.TabIndex = 68;
			this.btVerLog.Text = "View Log";
			this.btVerLog.UseVisualStyleBackColor = true;
			this.btVerLog.Click += new global::System.EventHandler(this.btVerLog_Click);
			this.label4.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label4.Location = new global::System.Drawing.Point(12, 59);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(206, 16);
			this.label4.TabIndex = 69;
			this.label4.Text = "What:";
			this.label4.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.panel1.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel1.BackColor = global::System.Drawing.SystemColors.ControlLight;
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.rbAsk);
			this.panel1.Controls.Add(this.chk_AcceptAll);
			this.panel1.Controls.Add(this.rbCancel);
			this.panel1.Controls.Add(this.rbOverride);
			this.panel1.Location = new global::System.Drawing.Point(404, 489);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(186, 76);
			this.panel1.TabIndex = 70;
			this.panel1.Tag = "Options";
			this.label7.BackColor = global::System.Drawing.Color.Transparent;
			this.label7.Location = new global::System.Drawing.Point(3, 5);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(109, 20);
			this.label7.TabIndex = 79;
			this.label7.Text = "On Duplicates:";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.rbAsk.AutoSize = true;
			this.rbAsk.BackColor = global::System.Drawing.Color.Transparent;
			this.rbAsk.Location = new global::System.Drawing.Point(111, 27);
			this.rbAsk.Name = "rbAsk";
			this.rbAsk.Size = new global::System.Drawing.Size(68, 17);
			this.rbAsk.TabIndex = 2;
			this.rbAsk.Text = "Ask User";
			this.rbAsk.UseVisualStyleBackColor = false;
			this.chk_AcceptAll.AutoSize = true;
			this.chk_AcceptAll.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_AcceptAll.Location = new global::System.Drawing.Point(10, 50);
			this.chk_AcceptAll.Name = "chk_AcceptAll";
			this.chk_AcceptAll.Size = new global::System.Drawing.Size(126, 17);
			this.chk_AcceptAll.TabIndex = 73;
			this.chk_AcceptAll.Text = "Accept on all Dialogs";
			this.chk_AcceptAll.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_AcceptAll.UseVisualStyleBackColor = true;
			this.rbCancel.AutoSize = true;
			this.rbCancel.BackColor = global::System.Drawing.Color.Transparent;
			this.rbCancel.Location = new global::System.Drawing.Point(55, 27);
			this.rbCancel.Name = "rbCancel";
			this.rbCancel.Size = new global::System.Drawing.Size(50, 17);
			this.rbCancel.TabIndex = 1;
			this.rbCancel.Text = "Abort";
			this.rbCancel.UseVisualStyleBackColor = false;
			this.rbOverride.AutoSize = true;
			this.rbOverride.BackColor = global::System.Drawing.Color.Transparent;
			this.rbOverride.Checked = true;
			this.rbOverride.Location = new global::System.Drawing.Point(10, 27);
			this.rbOverride.Name = "rbOverride";
			this.rbOverride.Size = new global::System.Drawing.Size(39, 17);
			this.rbOverride.TabIndex = 0;
			this.rbOverride.TabStop = true;
			this.rbOverride.Text = "Ok";
			this.rbOverride.UseVisualStyleBackColor = false;
			this.chk_SheetWithViews.AutoSize = true;
			this.chk_SheetWithViews.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_SheetWithViews.Location = new global::System.Drawing.Point(10, 7);
			this.chk_SheetWithViews.Name = "chk_SheetWithViews";
			this.chk_SheetWithViews.Size = new global::System.Drawing.Size(149, 17);
			this.chk_SheetWithViews.TabIndex = 72;
			this.chk_SheetWithViews.Text = "Transfer Sheet with Views";
			this.chk_SheetWithViews.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_SheetWithViews.UseVisualStyleBackColor = true;
			this.chk_ViewElements.AutoSize = true;
			this.chk_ViewElements.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_ViewElements.Location = new global::System.Drawing.Point(10, 52);
			this.chk_ViewElements.Name = "chk_ViewElements";
			this.chk_ViewElements.Size = new global::System.Drawing.Size(137, 17);
			this.chk_ViewElements.TabIndex = 1;
			this.chk_ViewElements.Text = "Transfer View Elements";
			this.chk_ViewElements.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_ViewElements.UseVisualStyleBackColor = true;
			this.chk_Callout.AutoSize = true;
			this.chk_Callout.CheckAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_Callout.Location = new global::System.Drawing.Point(10, 30);
			this.chk_Callout.Name = "chk_Callout";
			this.chk_Callout.Size = new global::System.Drawing.Size(148, 17);
			this.chk_Callout.TabIndex = 0;
			this.chk_Callout.Text = "Transfer Callouts of Views";
			this.chk_Callout.TextAlign = global::System.Drawing.ContentAlignment.TopLeft;
			this.chk_Callout.UseVisualStyleBackColor = true;
			this.chk_Callout.CheckedChanged += new global::System.EventHandler(this.checkBox1_CheckedChanged);
			this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel2.BackColor = global::System.Drawing.SystemColors.ControlLight;
			this.panel2.Controls.Add(this.clipId);
			this.panel2.Controls.Add(this.clip);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.txtSelection);
			this.panel2.Location = new global::System.Drawing.Point(404, 418);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(186, 49);
			this.panel2.TabIndex = 71;
			this.clipId.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.clipId.Image = global::TransferSingleApp.Properties.Resources.Id;
			this.clipId.Location = new global::System.Drawing.Point(165, 26);
			this.clipId.Name = "clipId";
			this.clipId.Size = new global::System.Drawing.Size(16, 16);
			this.clipId.TabIndex = 78;
			this.clipId.TabStop = false;
			this.clipId.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.ClipId_MouseClick);
			this.clipId.MouseEnter += new global::System.EventHandler(this.ClipId_MouseEnter);
			this.clipId.MouseLeave += new global::System.EventHandler(this.ClipId_MouseLeave);
			this.clipId.MouseHover += new global::System.EventHandler(this.clipId_MouseHover);
			this.clip.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.clip.Image = global::TransferSingleApp.Properties.Resources.Clip;
			this.clip.Location = new global::System.Drawing.Point(165, 5);
			this.clip.Name = "clip";
			this.clip.Size = new global::System.Drawing.Size(16, 16);
			this.clip.TabIndex = 76;
			this.clip.TabStop = false;
			this.clip.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.clip_MouseClick);
			this.clip.MouseEnter += new global::System.EventHandler(this.clip_MouseEnter);
			this.clip.MouseLeave += new global::System.EventHandler(this.clip_MouseLeave);
			this.clip.MouseHover += new global::System.EventHandler(this.clip_MouseHover);
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.configureToolStripMenuItem,
				this.aboutToolStripMenuItem1
			});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new global::System.Drawing.Size(45, 19);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.TextAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.configureToolStripMenuItem.Image = global::TransferSingleApp.Properties.Resources.Config_Over;
			this.configureToolStripMenuItem.Name = "configureToolStripMenuItem";
			this.configureToolStripMenuItem.Size = new global::System.Drawing.Size(127, 22);
			this.configureToolStripMenuItem.Text = "Configure";
			this.configureToolStripMenuItem.Click += new global::System.EventHandler(this.Configuracion_ClickMenu);
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new global::System.Drawing.Size(127, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new global::System.EventHandler(this.About_ClickMenu);
			this.menuStrip1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.menuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.aboutToolStripMenuItem
			});
			this.menuStrip1.Location = new global::System.Drawing.Point(544, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new global::System.Drawing.Size(58, 704);
			this.menuStrip1.TabIndex = 74;
			this.menuStrip1.Text = "menuStrip1";
			this.configuracion.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.configuracion.Image = global::TransferSingleApp.Properties.Resources.Config;
			this.configuracion.Location = new global::System.Drawing.Point(574, 81);
			this.configuracion.Name = "configuracion";
			this.configuracion.Size = new global::System.Drawing.Size(16, 16);
			this.configuracion.TabIndex = 75;
			this.configuracion.TabStop = false;
			this.configuracion.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.Configuracion_MouseClick);
			this.configuracion.MouseEnter += new global::System.EventHandler(this.Configuracion_MouseEnter);
			this.configuracion.MouseLeave += new global::System.EventHandler(this.Configuracion_MouseLeave);
			this.ExpandTodos.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ExpandTodos.Image = global::TransferSingleApp.Properties.Resources.ExpTodos;
			this.ExpandTodos.ImageLocation = "";
			this.ExpandTodos.Location = new global::System.Drawing.Point(404, 81);
			this.ExpandTodos.Name = "ExpandTodos";
			this.ExpandTodos.Size = new global::System.Drawing.Size(16, 16);
			this.ExpandTodos.TabIndex = 56;
			this.ExpandTodos.TabStop = false;
			this.ExpandTodos.Click += new global::System.EventHandler(this.ExpandTodos_Click);
			this.ExpandTodos.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.ExpandTodos_MouseClick);
			this.ExpandTodos.MouseEnter += new global::System.EventHandler(this.ExpandTodos_MouseEnter);
			this.ExpandTodos.MouseLeave += new global::System.EventHandler(this.ExpandTodos_MouseLeave);
			this.ExpandNinguno.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.ExpandNinguno.Image = global::TransferSingleApp.Properties.Resources.ExpNinguno;
			this.ExpandNinguno.Location = new global::System.Drawing.Point(426, 81);
			this.ExpandNinguno.Name = "ExpandNinguno";
			this.ExpandNinguno.Size = new global::System.Drawing.Size(16, 16);
			this.ExpandNinguno.TabIndex = 55;
			this.ExpandNinguno.TabStop = false;
			this.ExpandNinguno.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.ExpandNinguno_MouseClick);
			this.ExpandNinguno.MouseEnter += new global::System.EventHandler(this.ExpandNinguno_MouseEnter);
			this.ExpandNinguno.MouseLeave += new global::System.EventHandler(this.ExpandNinguno_MouseLeave);
			this.vistasTodo.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.vistasTodo.Image = global::TransferSingleApp.Properties.Resources.SelTodos;
			this.vistasTodo.ImageLocation = "";
			this.vistasTodo.Location = new global::System.Drawing.Point(448, 81);
			this.vistasTodo.Name = "vistasTodo";
			this.vistasTodo.Size = new global::System.Drawing.Size(16, 16);
			this.vistasTodo.TabIndex = 54;
			this.vistasTodo.TabStop = false;
			this.vistasTodo.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.vistasTodo_MouseClick);
			this.vistasTodo.MouseEnter += new global::System.EventHandler(this.vistasTodo_MouseEnter);
			this.vistasTodo.MouseLeave += new global::System.EventHandler(this.vistasTodo_MouseLeave);
			this.vistasNada.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.vistasNada.Image = global::TransferSingleApp.Properties.Resources.SelNinguno;
			this.vistasNada.Location = new global::System.Drawing.Point(470, 81);
			this.vistasNada.Name = "vistasNada";
			this.vistasNada.Size = new global::System.Drawing.Size(16, 16);
			this.vistasNada.TabIndex = 53;
			this.vistasNada.TabStop = false;
			this.vistasNada.MouseClick += new global::System.Windows.Forms.MouseEventHandler(this.vistasNada_MouseClick);
			this.vistasNada.MouseEnter += new global::System.EventHandler(this.vistasNada_MouseEnter);
			this.vistasNada.MouseLeave += new global::System.EventHandler(this.vistasNada_MouseLeave);
			this.menuElements.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.deleteToolStripMenuItem,
				this.findAndReplaceToolStripMenuItem,
				this.addPrefixToolStripMenuItem,
				this.addSufixToolStripMenuItem,
				this.changeCaseToolStripMenuItem,
				this.namesToClipboardToolStripMenuItem,
				this.idsToClipboardToolStripMenuItem
			});
			this.menuElements.Name = "menuElements";
			this.menuElements.Size = new global::System.Drawing.Size(181, 158);
			this.deleteToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedToolStripMenuItem,
				this.selectedToolStripMenuItem
			});
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.checkedToolStripMenuItem.Name = "checkedToolStripMenuItem";
			this.checkedToolStripMenuItem.Size = new global::System.Drawing.Size(171, 22);
			this.checkedToolStripMenuItem.Text = "Checked Elements";
			this.checkedToolStripMenuItem.Click += new global::System.EventHandler(this.DeletecheckedToolStripMenuItem_Click);
			this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
			this.selectedToolStripMenuItem.Size = new global::System.Drawing.Size(171, 22);
			this.selectedToolStripMenuItem.Text = "Selected Elements";
			this.selectedToolStripMenuItem.Click += new global::System.EventHandler(this.deleteselectedToolStripMenuItem_Click);
			this.findAndReplaceToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedToolStripMenuItem1,
				this.selectedToolStripMenuItem1
			});
			this.findAndReplaceToolStripMenuItem.Name = "findAndReplaceToolStripMenuItem";
			this.findAndReplaceToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.findAndReplaceToolStripMenuItem.Text = "Find and Replace";
			this.checkedToolStripMenuItem1.Name = "checkedToolStripMenuItem1";
			this.checkedToolStripMenuItem1.Size = new global::System.Drawing.Size(171, 22);
			this.checkedToolStripMenuItem1.Text = "Checked Elements";
			this.checkedToolStripMenuItem1.Click += new global::System.EventHandler(this.FindAndReplacecheckedToolStripMenuItem1_Click);
			this.selectedToolStripMenuItem1.Name = "selectedToolStripMenuItem1";
			this.selectedToolStripMenuItem1.Size = new global::System.Drawing.Size(171, 22);
			this.selectedToolStripMenuItem1.Text = "Selected Elements";
			this.selectedToolStripMenuItem1.Click += new global::System.EventHandler(this.FindselectedToolStripMenuItem1_Click);
			this.addPrefixToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.chekedElemensToolStripMenuItem,
				this.selectedElementsToolStripMenuItem
			});
			this.addPrefixToolStripMenuItem.Name = "addPrefixToolStripMenuItem";
			this.addPrefixToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.addPrefixToolStripMenuItem.Text = "Add Prefix";
			this.chekedElemensToolStripMenuItem.Name = "chekedElemensToolStripMenuItem";
			this.chekedElemensToolStripMenuItem.Size = new global::System.Drawing.Size(169, 22);
			this.chekedElemensToolStripMenuItem.Text = "Checked Elemens";
			this.chekedElemensToolStripMenuItem.Click += new global::System.EventHandler(this.AddPrefixchekedElemensToolStripMenuItem_Click);
			this.selectedElementsToolStripMenuItem.Name = "selectedElementsToolStripMenuItem";
			this.selectedElementsToolStripMenuItem.Size = new global::System.Drawing.Size(169, 22);
			this.selectedElementsToolStripMenuItem.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem.Click += new global::System.EventHandler(this.AddPrefixselectedElementsToolStripMenuItem_Click);
			this.addSufixToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedElementsToolStripMenuItem,
				this.selectedElementsToolStripMenuItem1
			});
			this.addSufixToolStripMenuItem.Name = "addSufixToolStripMenuItem";
			this.addSufixToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.addSufixToolStripMenuItem.Text = "Add Suffix";
			this.checkedElementsToolStripMenuItem.Name = "checkedElementsToolStripMenuItem";
			this.checkedElementsToolStripMenuItem.Size = new global::System.Drawing.Size(171, 22);
			this.checkedElementsToolStripMenuItem.Text = "Checked Elements";
			this.checkedElementsToolStripMenuItem.Click += new global::System.EventHandler(this.AddSuffixcheckedElementsToolStripMenuItem_Click);
			this.selectedElementsToolStripMenuItem1.Name = "selectedElementsToolStripMenuItem1";
			this.selectedElementsToolStripMenuItem1.Size = new global::System.Drawing.Size(171, 22);
			this.selectedElementsToolStripMenuItem1.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem1.Click += new global::System.EventHandler(this.AddSuffixselectedElementsToolStripMenuItem1_Click);
			this.changeCaseToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.uPPERCASEToolStripMenuItem,
				this.lowerCaseToolStripMenuItem,
				this.properCaseToolStripMenuItem
			});
			this.changeCaseToolStripMenuItem.Name = "changeCaseToolStripMenuItem";
			this.changeCaseToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.changeCaseToolStripMenuItem.Text = "Change Case";
			this.uPPERCASEToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedElementsToolStripMenuItem1,
				this.selectedElementsToolStripMenuItem2
			});
			this.uPPERCASEToolStripMenuItem.Name = "uPPERCASEToolStripMenuItem";
			this.uPPERCASEToolStripMenuItem.Size = new global::System.Drawing.Size(140, 22);
			this.uPPERCASEToolStripMenuItem.Text = "UPPER CASE";
			this.checkedElementsToolStripMenuItem1.Name = "checkedElementsToolStripMenuItem1";
			this.checkedElementsToolStripMenuItem1.Size = new global::System.Drawing.Size(171, 22);
			this.checkedElementsToolStripMenuItem1.Text = "Checked Elements";
			this.checkedElementsToolStripMenuItem1.Click += new global::System.EventHandler(this.UppercheckedElementsToolStripMenuItem1_Click);
			this.selectedElementsToolStripMenuItem2.Name = "selectedElementsToolStripMenuItem2";
			this.selectedElementsToolStripMenuItem2.Size = new global::System.Drawing.Size(171, 22);
			this.selectedElementsToolStripMenuItem2.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem2.Click += new global::System.EventHandler(this.UpperselectedElementsToolStripMenuItem2_Click);
			this.lowerCaseToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedElementsToolStripMenuItem2,
				this.selectedElementsToolStripMenuItem3
			});
			this.lowerCaseToolStripMenuItem.Name = "lowerCaseToolStripMenuItem";
			this.lowerCaseToolStripMenuItem.Size = new global::System.Drawing.Size(140, 22);
			this.lowerCaseToolStripMenuItem.Text = "lower case";
			this.checkedElementsToolStripMenuItem2.Name = "checkedElementsToolStripMenuItem2";
			this.checkedElementsToolStripMenuItem2.Size = new global::System.Drawing.Size(171, 22);
			this.checkedElementsToolStripMenuItem2.Text = "Checked Elements";
			this.checkedElementsToolStripMenuItem2.Click += new global::System.EventHandler(this.lowercasecheckedElementsToolStripMenuItem2_Click);
			this.selectedElementsToolStripMenuItem3.Name = "selectedElementsToolStripMenuItem3";
			this.selectedElementsToolStripMenuItem3.Size = new global::System.Drawing.Size(171, 22);
			this.selectedElementsToolStripMenuItem3.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem3.Click += new global::System.EventHandler(this.lowecaseselectedElementsToolStripMenuItem3_Click);
			this.properCaseToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedElementsToolStripMenuItem3,
				this.selectedElementsToolStripMenuItem4
			});
			this.properCaseToolStripMenuItem.Name = "properCaseToolStripMenuItem";
			this.properCaseToolStripMenuItem.Size = new global::System.Drawing.Size(140, 22);
			this.properCaseToolStripMenuItem.Text = "Proper Case";
			this.checkedElementsToolStripMenuItem3.Name = "checkedElementsToolStripMenuItem3";
			this.checkedElementsToolStripMenuItem3.Size = new global::System.Drawing.Size(171, 22);
			this.checkedElementsToolStripMenuItem3.Text = "Checked Elements";
			this.checkedElementsToolStripMenuItem3.Click += new global::System.EventHandler(this.propercasecheckedElementsToolStripMenuItem3_Click);
			this.selectedElementsToolStripMenuItem4.Name = "selectedElementsToolStripMenuItem4";
			this.selectedElementsToolStripMenuItem4.Size = new global::System.Drawing.Size(171, 22);
			this.selectedElementsToolStripMenuItem4.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem4.Click += new global::System.EventHandler(this.propercaseselectedElementsToolStripMenuItem4_Click);
			this.namesToClipboardToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedElementsToolStripMenuItem4,
				this.selectedElementsToolStripMenuItem5
			});
			this.namesToClipboardToolStripMenuItem.Name = "namesToClipboardToolStripMenuItem";
			this.namesToClipboardToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.namesToClipboardToolStripMenuItem.Text = "Names to Clipboard";
			this.checkedElementsToolStripMenuItem4.Name = "checkedElementsToolStripMenuItem4";
			this.checkedElementsToolStripMenuItem4.Size = new global::System.Drawing.Size(171, 22);
			this.checkedElementsToolStripMenuItem4.Text = "Checked Elements";
			this.checkedElementsToolStripMenuItem4.Click += new global::System.EventHandler(this.NamescheckedElementsToolStripMenuItem4_Click);
			this.selectedElementsToolStripMenuItem5.Name = "selectedElementsToolStripMenuItem5";
			this.selectedElementsToolStripMenuItem5.Size = new global::System.Drawing.Size(171, 22);
			this.selectedElementsToolStripMenuItem5.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem5.Click += new global::System.EventHandler(this.NamesselectedElementsToolStripMenuItem5_Click);
			this.idsToClipboardToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.checkedElementsToolStripMenuItem5,
				this.selectedElementsToolStripMenuItem6
			});
			this.idsToClipboardToolStripMenuItem.Name = "idsToClipboardToolStripMenuItem";
			this.idsToClipboardToolStripMenuItem.Size = new global::System.Drawing.Size(180, 22);
			this.idsToClipboardToolStripMenuItem.Text = "IDs to Clipboard";
			this.checkedElementsToolStripMenuItem5.Name = "checkedElementsToolStripMenuItem5";
			this.checkedElementsToolStripMenuItem5.Size = new global::System.Drawing.Size(171, 22);
			this.checkedElementsToolStripMenuItem5.Text = "Checked Elements";
			this.checkedElementsToolStripMenuItem5.Click += new global::System.EventHandler(this.IDscheckedElementsToolStripMenuItem5_Click);
			this.selectedElementsToolStripMenuItem6.Name = "selectedElementsToolStripMenuItem6";
			this.selectedElementsToolStripMenuItem6.Size = new global::System.Drawing.Size(171, 22);
			this.selectedElementsToolStripMenuItem6.Text = "Selected Elements";
			this.selectedElementsToolStripMenuItem6.Click += new global::System.EventHandler(this.IDsselectedElementsToolStripMenuItem6_Click);
			this.panel3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel3.BackColor = global::System.Drawing.SystemColors.ControlLight;
			this.panel3.Controls.Add(this.button3);
			this.panel3.Controls.Add(this.button2);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Controls.Add(this.bt_AddSuffix);
			this.panel3.Controls.Add(this.bt_AddPrefix);
			this.panel3.Controls.Add(this.bt_FindReplace);
			this.panel3.Controls.Add(this.bt_Delete);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Location = new global::System.Drawing.Point(404, 178);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(186, 231);
			this.panel3.TabIndex = 76;
			this.button3.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.button3.Location = new global::System.Drawing.Point(6, 192);
			this.button3.Name = "button3";
			this.button3.Size = new global::System.Drawing.Size(175, 22);
			this.button3.TabIndex = 85;
			this.button3.Text = "Proper Case";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new global::System.EventHandler(this.button3_Click);
			this.button2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.button2.Location = new global::System.Drawing.Point(6, 164);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(175, 22);
			this.button2.TabIndex = 84;
			this.button2.Text = "lower Case";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.button1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.button1.Location = new global::System.Drawing.Point(6, 136);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(175, 22);
			this.button1.TabIndex = 83;
			this.button1.Text = "UPPER Case";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click_1);
			this.bt_AddSuffix.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.bt_AddSuffix.Location = new global::System.Drawing.Point(6, 108);
			this.bt_AddSuffix.Name = "bt_AddSuffix";
			this.bt_AddSuffix.Size = new global::System.Drawing.Size(175, 22);
			this.bt_AddSuffix.TabIndex = 82;
			this.bt_AddSuffix.Text = "Add Suffix";
			this.bt_AddSuffix.UseVisualStyleBackColor = true;
			this.bt_AddSuffix.Click += new global::System.EventHandler(this.bt_AddSuffix_Click);
			this.bt_AddPrefix.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.bt_AddPrefix.Location = new global::System.Drawing.Point(6, 80);
			this.bt_AddPrefix.Name = "bt_AddPrefix";
			this.bt_AddPrefix.Size = new global::System.Drawing.Size(175, 22);
			this.bt_AddPrefix.TabIndex = 81;
			this.bt_AddPrefix.Text = "Add Prefix";
			this.bt_AddPrefix.UseVisualStyleBackColor = true;
			this.bt_AddPrefix.Click += new global::System.EventHandler(this.bt_AddPrefix_Click);
			this.bt_FindReplace.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.bt_FindReplace.Location = new global::System.Drawing.Point(6, 52);
			this.bt_FindReplace.Name = "bt_FindReplace";
			this.bt_FindReplace.Size = new global::System.Drawing.Size(175, 22);
			this.bt_FindReplace.TabIndex = 80;
			this.bt_FindReplace.Text = "Find and Replace";
			this.bt_FindReplace.UseVisualStyleBackColor = true;
			this.bt_FindReplace.Click += new global::System.EventHandler(this.bt_FindReplace_Click);
			this.bt_Delete.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.bt_Delete.Location = new global::System.Drawing.Point(6, 24);
			this.bt_Delete.Name = "bt_Delete";
			this.bt_Delete.Size = new global::System.Drawing.Size(175, 22);
			this.bt_Delete.TabIndex = 77;
			this.bt_Delete.Text = "Delete";
			this.bt_Delete.UseVisualStyleBackColor = true;
			this.bt_Delete.Click += new global::System.EventHandler(this.bt_Delete_Click);
			this.label6.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label6.BackColor = global::System.Drawing.Color.Transparent;
			this.label6.Location = new global::System.Drawing.Point(3, 1);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(164, 20);
			this.label6.TabIndex = 79;
			this.label6.Text = "Manage Checked:";
			this.label6.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.panel5.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel5.BackColor = global::System.Drawing.SystemColors.ControlLight;
			this.panel5.Controls.Add(this.Search);
			this.panel5.Controls.Add(this.textBusca);
			this.panel5.Location = new global::System.Drawing.Point(404, 99);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(186, 69);
			this.panel5.TabIndex = 78;
			this.Search.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.Search.Location = new global::System.Drawing.Point(6, 35);
			this.Search.Name = "Search";
			this.Search.Size = new global::System.Drawing.Size(175, 23);
			this.Search.TabIndex = 68;
			this.Search.Text = "Search Next";
			this.Search.UseVisualStyleBackColor = true;
			this.Search.Click += new global::System.EventHandler(this.Search_Click);
			this.textBusca.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.textBusca.Location = new global::System.Drawing.Point(6, 9);
			this.textBusca.Name = "textBusca";
			this.textBusca.Size = new global::System.Drawing.Size(175, 20);
			this.textBusca.TabIndex = 67;
			this.chk_Links.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.chk_Links.Location = new global::System.Drawing.Point(10, 5);
			this.chk_Links.Name = "chk_Links";
			this.chk_Links.Size = new global::System.Drawing.Size(171, 17);
			this.chk_Links.TabIndex = 79;
			this.chk_Links.Text = "Include Links as Source";
			this.chk_Links.UseVisualStyleBackColor = true;
			this.chk_Links.CheckedChanged += new global::System.EventHandler(this.chk_Links_CheckedChanged);
			this.panel4.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel4.BackColor = global::System.Drawing.SystemColors.ControlLight;
			this.panel4.Controls.Add(this.chk_SheetWithViews);
			this.panel4.Controls.Add(this.chk_ViewElements);
			this.panel4.Controls.Add(this.chk_Callout);
			this.panel4.Location = new global::System.Drawing.Point(404, 571);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(186, 80);
			this.panel4.TabIndex = 79;
			this.label5.Anchor = (global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.label5.Location = new global::System.Drawing.Point(12, 470);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(206, 16);
			this.label5.TabIndex = 80;
			this.label5.Text = "To:";
			this.label5.TextAlign = global::System.Drawing.ContentAlignment.BottomLeft;
			this.panel6.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.panel6.BackColor = global::System.Drawing.SystemColors.ControlLight;
			this.panel6.Controls.Add(this.chk_GetTransformShared);
			this.panel6.Controls.Add(this.chk_GetTransformLink);
			this.panel6.Controls.Add(this.chk_GetTransformNone);
			this.panel6.Controls.Add(this.chk_Links);
			this.panel6.Location = new global::System.Drawing.Point(404, 23);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(186, 49);
			this.panel6.TabIndex = 79;
			this.chk_GetTransformShared.AutoSize = true;
			this.chk_GetTransformShared.Location = new global::System.Drawing.Point(115, 24);
			this.chk_GetTransformShared.Name = "chk_GetTransformShared";
			this.chk_GetTransformShared.Size = new global::System.Drawing.Size(59, 17);
			this.chk_GetTransformShared.TabIndex = 84;
			this.chk_GetTransformShared.TabStop = true;
			this.chk_GetTransformShared.Text = "Shared";
			this.chk_GetTransformShared.UseVisualStyleBackColor = true;
			this.chk_GetTransformLink.AutoSize = true;
			this.chk_GetTransformLink.Location = new global::System.Drawing.Point(66, 24);
			this.chk_GetTransformLink.Name = "chk_GetTransformLink";
			this.chk_GetTransformLink.Size = new global::System.Drawing.Size(45, 17);
			this.chk_GetTransformLink.TabIndex = 83;
			this.chk_GetTransformLink.TabStop = true;
			this.chk_GetTransformLink.Text = "Link";
			this.chk_GetTransformLink.UseVisualStyleBackColor = true;
			this.chk_GetTransformNone.AutoSize = true;
			this.chk_GetTransformNone.Location = new global::System.Drawing.Point(10, 24);
			this.chk_GetTransformNone.Name = "chk_GetTransformNone";
			this.chk_GetTransformNone.Size = new global::System.Drawing.Size(51, 17);
			this.chk_GetTransformNone.TabIndex = 82;
			this.chk_GetTransformNone.TabStop = true;
			this.chk_GetTransformNone.Text = "None";
			this.chk_GetTransformNone.UseVisualStyleBackColor = true;
			this.label8.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.label8.Location = new global::System.Drawing.Point(284, 48);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(114, 16);
			this.label8.TabIndex = 81;
			this.label8.Text = "Transform By:";
			this.label8.TextAlign = global::System.Drawing.ContentAlignment.BottomRight;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(602, 704);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.panel6);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel5);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.configuracion);
			base.Controls.Add(this.panel2);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.btVerLog);
			base.Controls.Add(this.foArchivos);
			base.Controls.Add(this.pOrigen);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ExpandTodos);
			base.Controls.Add(this.ExpandNinguno);
			base.Controls.Add(this.vistasTodo);
			base.Controls.Add(this.vistasNada);
			base.Controls.Add(this.bt_Transfer);
			base.Controls.Add(this.tlElementos);
			base.Controls.Add(this.menuStrip1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "TransferSingle";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "TransferSingle v";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.TransferSingle_FormClosing);
			base.Load += new global::System.EventHandler(this.TransferSingle_Load);
			this.tlElementos.EndInit();
			this.foArchivos.EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.clipId).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.clip).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.configuracion).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandTodos).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.ExpandNinguno).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.vistasTodo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.vistasNada).EndInit();
			this.menuElements.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400009D RID: 157
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400009E RID: 158
		private global::BrightIdeasSoftware.TreeListView tlElementos;

		// Token: 0x0400009F RID: 159
		private global::BrightIdeasSoftware.OLVColumn Arbol;

		// Token: 0x040000A0 RID: 160
		private global::BrightIdeasSoftware.OLVColumn Cuenta;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Button bt_Transfer;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.PictureBox ExpandTodos;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.PictureBox ExpandNinguno;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.PictureBox vistasTodo;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.PictureBox vistasNada;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Label txtSelection;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.ComboBox pOrigen;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000AB RID: 171
		private global::BrightIdeasSoftware.FastObjectListView foArchivos;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Button btVerLog;

		// Token: 0x040000AD RID: 173
		private global::BrightIdeasSoftware.OLVColumn Files;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.RadioButton rbAsk;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.RadioButton rbCancel;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.RadioButton rbOverride;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.PictureBox configuracion;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.PictureBox clip;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.ToolStripMenuItem configureToolStripMenuItem;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.MenuStrip menuStrip1;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.PictureBox clipId;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.ContextMenuStrip menuElements;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.ToolStripMenuItem checkedToolStripMenuItem;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.ToolStripMenuItem findAndReplaceToolStripMenuItem;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.ToolStripMenuItem checkedToolStripMenuItem1;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem1;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.ToolStripMenuItem addPrefixToolStripMenuItem;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.ToolStripMenuItem chekedElemensToolStripMenuItem;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.ToolStripMenuItem addSufixToolStripMenuItem;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.ToolStripMenuItem checkedElementsToolStripMenuItem;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem1;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.ToolStripMenuItem changeCaseToolStripMenuItem;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.ToolStripMenuItem uPPERCASEToolStripMenuItem;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.ToolStripMenuItem checkedElementsToolStripMenuItem1;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem2;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.ToolStripMenuItem lowerCaseToolStripMenuItem;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.ToolStripMenuItem checkedElementsToolStripMenuItem2;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem3;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.ToolStripMenuItem properCaseToolStripMenuItem;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.ToolStripMenuItem checkedElementsToolStripMenuItem3;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem4;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.ToolStripMenuItem namesToClipboardToolStripMenuItem;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.ToolStripMenuItem checkedElementsToolStripMenuItem4;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem5;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.ToolStripMenuItem idsToClipboardToolStripMenuItem;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.ToolStripMenuItem checkedElementsToolStripMenuItem5;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.ToolStripMenuItem selectedElementsToolStripMenuItem6;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Label label6;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.Button bt_Delete;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Button bt_FindReplace;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Button button3;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.Button button2;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.Button button1;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Button bt_AddSuffix;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Button bt_AddPrefix;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.CheckBox chk_Callout;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Button Search;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.TextBox textBusca;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.CheckBox chk_ViewElements;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.CheckBox chk_SheetWithViews;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.CheckBox chk_Links;

		// Token: 0x040000E8 RID: 232
		private global::BrightIdeasSoftware.OLVColumn Numero;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.CheckBox chk_AcceptAll;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.Label label7;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.Label label5;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.RadioButton chk_GetTransformShared;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.RadioButton chk_GetTransformLink;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.RadioButton chk_GetTransformNone;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.Label label8;
	}
}
