using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using A;
using DiRoots.One.Commons;
using DiRoots.One.SheetLink.Models;
using DiRoots.One.SheetLink.ViewModels;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.XlsIO;

namespace DiRoots.One.SheetLink.UI.Controls
{
	// Token: 0x0200022C RID: 556
	public class PreviewTabControl : UserControl, IComponentConnector
	{
		// Token: 0x060015C7 RID: 5575 RVA: 0x0008D36C File Offset: 0x0008B56C
		public PreviewTabControl()
		{
			this.F = new PreviewViewModel();
			\u0017\u001A\u000A.\u0007(this, this.F);
			\u0017\u0005\u0005.\u000A(this);
			\u0020\u0005\u0005.\u000A(this.R, new WorksheetAddedEventHandler(this.SpreadsheetControl_WorksheetAdded));
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x0008D3B4 File Offset: 0x0008B5B4
		public void Initialize(ControlExcelBase controlExel, Window window, ProgressModel progressModel)
		{
			\u000B\u001F\u0005.\u001D(this.F, this.R);
			\u0005\u001F\u0005.\u001D(this.F, controlExel, window, progressModel);
			this.C();
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x0008D3E8 File Offset: 0x0008B5E8
		private void SpreadsheetControl_WorksheetAdded(object sender, WorksheetAddedEventArgs args)
		{
			this.C();
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x0008D3FC File Offset: 0x0008B5FC
		public void OpenFile(string filePath, Window window, ProgressModel progressModel)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\UserControls\\PreviewTabControl.xaml.cs", "OpenFile");
			\u000B\u001F\u0005.\u001D(this.F, this.R);
			\u0016\u001F\u0005.\u001D(this.F, filePath, window, progressModel);
			this.C();
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\UserControls\\PreviewTabControl.xaml.cs", "OpenFile");
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x0008D45C File Offset: 0x0008B65C
		private void C()
		{
			SfSpreadsheet r = this.R;
			bool flag;
			if (r == null)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewTabControl.C()).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				flag = (\u0013\u0002\u0018.\u001D(r) != null);
			}
			if (!flag)
			{
				for (;;)
				{
					switch (3)
					{
					case 0:
						continue;
					}
					break;
				}
				return;
			}
			Dictionary<string, SpreadsheetGrid>.ValueCollection.Enumerator enumerator = \u0015\u0005\u0005.\u000A(\u0001\u0005\u0005.\u000A(\u0013\u0002\u0018.\u0007(this.R)));
			try
			{
				while (\u0014\u0005\u0005.\u000A(ref enumerator))
				{
					SpreadsheetGrid u001F = \u000C\u0005\u0005.\u000A(ref enumerator);
					if (\u0010\u000F\u000E.\u001F(\u001A\u0005\u0005.\u000A(u001F)) == null)
					{
						for (;;)
						{
							switch (6)
							{
							case 0:
								continue;
							}
							break;
						}
						\u0013\u0005\u0005.\u000A(u001F, new \u001C\u001C(u001F));
					}
				}
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x060015CC RID: 5580 RVA: 0x0008D524 File Offset: 0x0008B724
		public void RefreshView()
		{
			try
			{
				SfSpreadsheet r = this.R;
				if (r == null)
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewTabControl.RefreshView()).MethodHandle;
					}
				}
				else
				{
					SpreadsheetGrid spreadsheetGrid = \u0002\u0009\u0018.\u001D(r);
					if (spreadsheetGrid == null)
					{
						for (;;)
						{
							switch (2)
							{
							case 0:
								continue;
							}
							break;
						}
					}
					else
					{
						\u0009\u0005\u0005.\u000A(spreadsheetGrid, false);
					}
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\UserControls\\PreviewTabControl.xaml.cs", "RefreshView");
			}
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x0008D59C File Offset: 0x0008B79C
		public void CustomDispose()
		{
			\u000A\u0016\u0005.\u000A(this.R, new WorksheetAddedEventHandler(this.SpreadsheetControl_WorksheetAdded));
			\u001F\u0016\u0005.\u000A(this.F);
		}

		// Token: 0x060015CE RID: 5582 RVA: 0x0008D5CC File Offset: 0x0008B7CC
		private void spreadsheetControl_KeyUp(object sender, KeyEventArgs e)
		{
			if (!\u0006\u0016\u0005.\u000A(this.R))
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewTabControl.spreadsheetControl_KeyUp(object, KeyEventArgs)).MethodHandle;
				}
				return;
			}
			if (\u001A\u001A\u0019.\u000A(e) == Key.Return)
			{
				for (;;)
				{
					switch (2)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!\u0002\u0016\u0005.\u000A(Key.LeftCtrl))
				{
					for (;;)
					{
						switch (2)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!\u0002\u0016\u0005.\u000A(Key.RightCtrl))
					{
						return;
					}
					for (;;)
					{
						switch (7)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				try
				{
					SpreadsheetCurrentCell spreadsheetCurrentCell = \u0019\u001F\u0005.\u000A(\u0002\u0009\u0018.\u0007(this.R));
					if (\u0018\u001F\u0005.\u000A(spreadsheetCurrentCell))
					{
						for (;;)
						{
							switch (4)
							{
							case 0:
								continue;
							}
							break;
						}
						\u000B\u0016\u0005.\u000A(spreadsheetCurrentCell, true);
					}
					if (spreadsheetCurrentCell != null)
					{
						for (;;)
						{
							switch (3)
							{
							case 0:
								continue;
							}
							break;
						}
						object u000A = \u0018\u0016\u0005.\u000A(\u0002\u0009\u0018.\u0007(this.R), \u0016\u0016\u0005.\u000A(spreadsheetCurrentCell), \u0005\u0016\u0005.\u000A(spreadsheetCurrentCell));
						List<GridRangeInfo>.Enumerator enumerator = \u0007\u001F\u0005.\u000A(\u001D\u001F\u0005.\u000A(\u0002\u0009\u0018.\u0007(this.R)));
						try
						{
							while (\u0001\u0009\u0018.\u000A(ref enumerator))
							{
								GridRangeInfo gridRangeInfo = \u000A\u001F\u0005.\u000A(ref enumerator);
								string u000A2 = \u0019\u0016\u0005.\u000A(gridRangeInfo, \u0002\u0009\u0018.\u0007(this.R));
								IRange[] array = \u0017\u0014\u001D.\u000A(\u0004\u0016\u0005.\u000A(\u0010\u0014\u001D.\u000A(\u0015\u0009\u0018.\u000A(this.R)), u000A2));
								for (int i = 0; i < (int)\u0018\u0004\u000E.\u001F(array); i++)
								{
									IRange u001F = array[i];
									if (!\u001D\u0016\u0005.\u000A(\u001F\u0014\u001D.\u000A(u001F)))
									{
										for (;;)
										{
											switch (7)
											{
											case 0:
												continue;
											}
											break;
										}
										\u0001\u001E\u0018.\u000A(u001F, u000A);
									}
								}
								for (;;)
								{
									switch (5)
									{
									case 0:
										continue;
									}
									break;
								}
								\u0007\u0016\u0005.\u000A(\u0002\u0009\u0018.\u0007(this.R), gridRangeInfo, false);
							}
							for (;;)
							{
								switch (7)
								{
								case 0:
									continue;
								}
								break;
							}
						}
						finally
						{
							((IDisposable)enumerator).Dispose();
						}
					}
				}
				catch (Exception u000A3)
				{
					\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A3, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink\\UI\\UserControls\\PreviewTabControl.xaml.cs", "spreadsheetControl_KeyUp");
				}
			}
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x0008D7EC File Offset: 0x0008B9EC
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		public void InitializeComponent()
		{
			if (this.D)
			{
				for (;;)
				{
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewTabControl.InitializeComponent()).MethodHandle;
				}
				return;
			}
			this.D = true;
			Uri u000A = \u0008\u000C\u000A.\u000A("/DiRoots.One;V2.8.0.0;component/sheetlink/sheetlink/ui/usercontrols/previewtabcontrol.xaml", UriKind.Relative);
			\u000E\u000C\u000A.\u000A(this, u000A);
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x0008D834 File Offset: 0x0008BA34
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "10.0.6.0")]
		void IComponentConnector.H(int F, object R)
		{
			if (F == 1)
			{
				for (;;)
				{
					switch (5)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewTabControl.H(int, object)).MethodHandle;
				}
				this.R = \u000D\u000F\u000E.\u001F(R);
				\u000A\u000C\u0019.\u000A(this.R, new KeyEventHandler(this.spreadsheetControl_KeyUp));
				return;
			}
			this.D = true;
		}

		// Token: 0x0400089F RID: 2207
		private readonly PreviewViewModel F;

		// Token: 0x040008A0 RID: 2208
		internal SfSpreadsheet R;

		// Token: 0x040008A1 RID: 2209
		private bool D;
	}
}
