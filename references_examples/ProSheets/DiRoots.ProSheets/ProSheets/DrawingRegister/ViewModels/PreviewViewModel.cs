using System;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using A;
using DiRoots.One.Commons.ViewModels;
using ProSheets.Extensions;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.Spreadsheet.Helpers;
using Syncfusion.XlsIO;

namespace ProSheets.DrawingRegister.ViewModels
{
	// Token: 0x0200010B RID: 267
	public class PreviewViewModel : ViewModelBase
	{
		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000D4C RID: 3404 RVA: 0x0004E82C File Offset: 0x0004CA2C
		// (set) Token: 0x06000D4D RID: 3405 RVA: 0x0004E840 File Offset: 0x0004CA40
		public SfSpreadsheet SfSpreadsheet { get; set; }

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000D4E RID: 3406 RVA: 0x0004E854 File Offset: 0x0004CA54
		// (set) Token: 0x06000D4F RID: 3407 RVA: 0x0004E868 File Offset: 0x0004CA68
		public bool IsEditable
		{
			get
			{
				return this.\u0002\u0016;
			}
			set
			{
				this.\u0002\u0016 = value;
				\u0011\u0010\u0018.\u0018(this, "IsEditable");
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000D50 RID: 3408 RVA: 0x0004E888 File Offset: 0x0004CA88
		// (set) Token: 0x06000D51 RID: 3409 RVA: 0x0004E89C File Offset: 0x0004CA9C
		public string FilePath { get; set; }

		// Token: 0x06000D52 RID: 3410 RVA: 0x0004E8B0 File Offset: 0x0004CAB0
		public void Open()
		{
			\u0020\u001B\u0016.\u0018(this, \u001F\u001B\u0016.\u0018());
			if (!\u000C\u001A\u0018.\u0018(\u0009\u001B\u0016.\u0018(this)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.Open()).MethodHandle;
				}
				\u001E\u001E\u0014.\u0018(\u0002\u0002\u0016.\u0018(), \u000D\u001E\u0018.\u0018("File not found: ", \u0009\u001B\u0016.\u0018(this)), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\DrawingRegister\\ViewModels\\PreviewViewModel.cs", "Open");
				return;
			}
			SfSpreadsheet q = \u0008\u000B\u0016.\u0018().Q;
			\u000A\u001B\u0016.\u0018(q, new WorkbookLoadedEventHandler(this.\u0004\u0009));
			\u0013\u001B\u0016.\u0018(q, \u0009\u001B\u0016.\u0018(this));
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x0004E944 File Offset: 0x0004CB44
		private void \u0004\u0009(object \u000C, WorkbookLoadedEventArgs \u0018)
		{
			SfSpreadsheet sfSpreadsheet = \u000A\u0006\u000F.\u000C(\u000C);
			if (sfSpreadsheet == null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.\u0004\u0009(object, WorkbookLoadedEventArgs)).MethodHandle;
				}
				return;
			}
			\u0011\u001B\u0016.\u0018(this, sfSpreadsheet);
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x0004E978 File Offset: 0x0004CB78
		[BindableMethod("CheckSfSpreadsheetEditable")]
		public void CheckSfSpreadsheetEditable(SfSpreadsheet sfSpreadsheet)
		{
			if (sfSpreadsheet == null)
			{
				for (;;)
				{
					switch (1)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.CheckSfSpreadsheetEditable(SfSpreadsheet)).MethodHandle;
				}
				return;
			}
			IWorksheet u000C = \u000C\u0020\u0016.\u0018(\u0018\u0020\u0016.\u0018(\u0003\u0019\u0016.\u0018(sfSpreadsheet)), 0);
			\u0004\u001B\u0016.\u0018(\u0017\u001B\u0016.\u0018(sfSpreadsheet), new MouseButtonEventHandler(this.\u001A\u0009));
			if (\u0014\u0019\u0016.\u0018(u000C))
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
				\u0018\u0019\u0016.\u0018(u000C, "DiRoots_DR");
			}
			if (!\u0002\u001B\u0016.\u0018(this))
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
				\u001E\u001B\u0016.\u0018(u000C, "DiRoots_DR", ExcelSheetProtection.None);
				\u0015\u001B\u0016.\u0018(\u0017\u001B\u0016.\u0018(sfSpreadsheet), new MouseButtonEventHandler(this.\u001A\u0009));
			}
		}

		// Token: 0x06000D55 RID: 3413 RVA: 0x0004EA28 File Offset: 0x0004CC28
		private bool \u001D\u0009(DependencyObject \u000C)
		{
			while (\u000C != null)
			{
				if (\u0009\u0006\u000F.\u000C(\u000C) != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.\u001D\u0009(DependencyObject)).MethodHandle;
					}
					return true;
				}
				\u000C = \u0016\u001C\u0014.\u0018(\u000C);
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
			return false;
		}

		// Token: 0x06000D56 RID: 3414 RVA: 0x0004EA70 File Offset: 0x0004CC70
		private void \u001A\u0009(object \u000C, MouseButtonEventArgs \u0018)
		{
			DependencyObject u000C = \u0013\u0006\u000F.\u000C(\u000F\u0012\u0014.\u0018(\u0018));
			if (!this.\u001D\u0009(u000C))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(PreviewViewModel.\u001A\u0009(object, MouseButtonEventArgs)).MethodHandle;
				}
				\u001D\u000B\u0018.\u0018(\u0018, true);
			}
		}

		// Token: 0x06000D57 RID: 3415 RVA: 0x0004EAB4 File Offset: 0x0004CCB4
		public void Clear()
		{
			\u0008\u0015\u0018.\u0015();
		}

		// Token: 0x040005F8 RID: 1528
		private bool \u0002\u0016;

		// Token: 0x040005F9 RID: 1529
		[CompilerGenerated]
		private SfSpreadsheet \u0004\u0016;

		// Token: 0x040005FA RID: 1530
		[CompilerGenerated]
		private string \u0005\u0014;
	}
}
