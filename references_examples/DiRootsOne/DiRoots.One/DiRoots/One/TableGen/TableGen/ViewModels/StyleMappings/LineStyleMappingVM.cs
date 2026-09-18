using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Behaviours;
using DiRoots.One.TGDatabaseLayer.StyleMapping;
using Syncfusion.XlsIO;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000170 RID: 368
	public class LineStyleMappingVM : ModelBase, IRowPropertyBroadcastResolver
	{
		// Token: 0x06000DA6 RID: 3494 RVA: 0x00057D9C File Offset: 0x00055F9C
		public LineStyleMappingVM(LineStyleMapping mapping, ObservableCollection<LineRevitStyleItem> availableStyles, List<LineRevitStyleItem> recommendedStyles)
		{
			this.IR = mapping;
			this.LD = \u0002\u0005.\u0008(\u000D\u0002\u0004.\u0007(this.IR));
			this.AvailableStyles = availableStyles;
			ExcelLineStyleInfo excelLineStyleInfo = \u000D\u0002\u0004.\u0007(mapping);
			byte b;
			if (excelLineStyleInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM..ctor(LineStyleMapping, ObservableCollection<LineRevitStyleItem>, List<LineRevitStyleItem>)).MethodHandle;
				}
				b = 0;
			}
			else
			{
				System.Drawing.Color color = \u0012\u0002\u0004.\u001D(excelLineStyleInfo);
				b = \u0015\u0017\u001D.\u000A(ref color);
			}
			byte u001F = b;
			ExcelLineStyleInfo excelLineStyleInfo2 = \u000D\u0002\u0004.\u0007(mapping);
			byte b2;
			if (excelLineStyleInfo2 == null)
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
				b2 = 0;
			}
			else
			{
				System.Drawing.Color color = \u0012\u0002\u0004.\u001D(excelLineStyleInfo2);
				b2 = \u000C\u0017\u001D.\u000A(ref color);
			}
			byte u000A = b2;
			ExcelLineStyleInfo excelLineStyleInfo3 = \u000D\u0002\u0004.\u0007(mapping);
			byte b3;
			if (excelLineStyleInfo3 == null)
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
				b3 = 0;
			}
			else
			{
				System.Drawing.Color color = \u0012\u0002\u0004.\u001D(excelLineStyleInfo3);
				b3 = \u0013\u0017\u001D.\u000A(ref color);
			}
			byte u = b3;
			System.Windows.Media.Color sd;
			if (\u000D\u0002\u0004.\u0007(mapping) == null)
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
				sd = \u0013\u0012\u0019.\u000A();
			}
			else
			{
				sd = \u0014\u0012\u0019.\u000A(u001F, u000A, u);
			}
			this.SD = sd;
			List<LineRevitStyleItem> f = recommendedStyles;
			if (recommendedStyles == null)
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
				f = new List<LineRevitStyleItem>();
			}
			this.GroupedAvailableStyles = this.OX(f);
			this.GroupedAvailableStylesView = new ListCollectionView(\u0017\u0012\u0019.\u0007(this));
			\u0006\u0008\u0007.\u000A(\u0012\u0008\u0007.\u000A(\u0020\u0012\u0019.\u000A(this)), new PropertyGroupDescription("GroupName"));
		}

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x06000DA7 RID: 3495 RVA: 0x00057EE4 File Offset: 0x000560E4
		public ExcelLineStyleInfo ExcelStyle
		{
			get
			{
				return \u000D\u0002\u0004.\u0007(this.IR);
			}
		}

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06000DA8 RID: 3496 RVA: 0x00057F00 File Offset: 0x00056100
		public bool IsGridlinesRow
		{
			get
			{
				ExcelLineStyleInfo excelLineStyleInfo = \u000D\u0002\u0004.\u0007(this.IR);
				if (excelLineStyleInfo == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.get_IsGridlinesRow()).MethodHandle;
					}
					return false;
				}
				return \u0017\u0001\u001D.\u0007(excelLineStyleInfo);
			}
		}

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00057F3C File Offset: 0x0005613C
		public string PatternDisplay
		{
			get
			{
				string result;
				if (!\u000C\u0012\u0019.\u000A(this))
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.get_PatternDisplay()).MethodHandle;
					}
					ExcelLineStyleInfo excelLineStyleInfo = \u000D\u0002\u0004.\u0007(this.IR);
					string text;
					if (excelLineStyleInfo == null)
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
						text = null;
					}
					else
					{
						text = \u001F\u0020\u0004.\u0007(excelLineStyleInfo);
					}
					if ((result = text) == null)
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
						return string.Empty;
					}
				}
				else
				{
					result = \u001A\u0012\u0019.\u000A();
				}
				return result;
			}
		}

		// Token: 0x170003AF RID: 943
		// (get) Token: 0x06000DAA RID: 3498 RVA: 0x00057FA8 File Offset: 0x000561A8
		public string ColorDisplay
		{
			get
			{
				if (!\u000C\u0012\u0019.\u000A(this))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.get_ColorDisplay()).MethodHandle;
					}
					ExcelLineStyleInfo excelLineStyleInfo = \u000D\u0002\u0004.\u0007(this.IR);
					System.Drawing.Color? u001F;
					if (excelLineStyleInfo == null)
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
						System.Drawing.Color? color;
						\u0009\u0019\u000E.\u001F(ref color);
						u001F = color;
					}
					else
					{
						u001F = new System.Drawing.Color?(\u0012\u0002\u0004.\u001D(excelLineStyleInfo));
					}
					return \u0002\u0005.\u0015(u001F, ", ", "", "");
				}
				return string.Empty;
			}
		}

		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x06000DAB RID: 3499 RVA: 0x00058020 File Offset: 0x00056220
		public System.Windows.Media.Color Color
		{
			get
			{
				return this.SD;
			}
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x06000DAC RID: 3500 RVA: 0x00058034 File Offset: 0x00056234
		// (set) Token: 0x06000DAD RID: 3501 RVA: 0x00058050 File Offset: 0x00056250
		public bool IsNew
		{
			get
			{
				return \u0015\u0012\u0019.\u000A(this.IR);
			}
			set
			{
				\u0018\u0002\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "IsNew");
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06000DAE RID: 3502 RVA: 0x00058074 File Offset: 0x00056274
		// (set) Token: 0x06000DAF RID: 3503 RVA: 0x00058090 File Offset: 0x00056290
		public bool IsNone
		{
			get
			{
				return \u001B\u0002\u0004.\u0007(this.IR);
			}
			set
			{
				\u0006\u001C\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "IsNone");
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06000DB0 RID: 3504 RVA: 0x000580B4 File Offset: 0x000562B4
		// (set) Token: 0x06000DB1 RID: 3505 RVA: 0x000580D0 File Offset: 0x000562D0
		[BroadcastOnMultiSelect]
		public string RevitStyleName
		{
			get
			{
				return \u0010\u0002\u0004.\u0007(this.IR);
			}
			set
			{
				\u001D\u001C\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "RevitStyleName");
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06000DB2 RID: 3506 RVA: 0x000580F4 File Offset: 0x000562F4
		// (set) Token: 0x06000DB3 RID: 3507 RVA: 0x00058110 File Offset: 0x00056310
		public long? RevitStyleElementId
		{
			get
			{
				return \u000B\u0002\u0004.\u000A(this.IR);
			}
			set
			{
				\u0005\u0002\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "RevitStyleElementId");
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x00058134 File Offset: 0x00056334
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x00058148 File Offset: 0x00056348
		[BroadcastOnMultiSelect]
		public LineRevitStyleItem SelectedRevitStyle
		{
			get
			{
				return this.CD;
			}
			set
			{
				this.CD = value;
				if (value != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.set_SelectedRevitStyle(LineRevitStyleItem)).MethodHandle;
					}
					if (\u0019\u0003\u0019.\u0007(value))
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
						\u001D\u0003\u0019.\u0007(this, \u000F\u0015\u0010.\u001F);
						long? u000A;
						\u000B\u0019\u000E.\u001F(ref u000A);
						\u000A\u0003\u0019.\u000A(this, u000A);
						\u0009\u0012\u0019.\u000A(this, false);
						\u0001\u0012\u0019.\u000A(this, true);
					}
					else
					{
						if (\u001F\u0003\u0019.\u0007(value))
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
							\u001D\u0003\u0019.\u0007(this, this.LD);
						}
						else
						{
							\u001D\u0003\u0019.\u0007(this, \u0004\u0003\u0019.\u0007(value));
						}
						\u000A\u0003\u0019.\u000A(this, \u0007\u0003\u0019.\u0007(value));
						\u0009\u0012\u0019.\u000A(this, \u001F\u0003\u0019.\u0007(value));
						\u0001\u0012\u0019.\u000A(this, false);
					}
				}
				\u0007\u0013\u000A.\u000A(this, "SelectedRevitStyle");
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x00058210 File Offset: 0x00056410
		public ObservableCollection<LineRevitStyleItem> AvailableStyles { get; }

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x06000DB7 RID: 3511 RVA: 0x00058224 File Offset: 0x00056424
		public ObservableCollection<LineRevitStyleItem> GroupedAvailableStyles { get; }

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x00058238 File Offset: 0x00056438
		public ListCollectionView GroupedAvailableStylesView { get; }

		// Token: 0x06000DB9 RID: 3513 RVA: 0x0005824C File Offset: 0x0005644C
		public LineStyleMapping GetMapping()
		{
			return this.IR;
		}

		// Token: 0x06000DBA RID: 3514 RVA: 0x00058260 File Offset: 0x00056460
		public bool TryApplyBroadcast(object source, string propertyName)
		{
			LineStyleMappingVM lineStyleMappingVM = \u0003\u0005\u000E.\u001F(source);
			if (lineStyleMappingVM == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.TryApplyBroadcast(object, string)).MethodHandle;
				}
				return false;
			}
			if (\u001D\u0017\u000A.\u000A(propertyName, "SelectedRevitStyle"))
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
				return false;
			}
			LineRevitStyleItem lineRevitStyleItem = this.PX(\u0005\u0003\u0019.\u000A(lineStyleMappingVM));
			if (lineRevitStyleItem != null)
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
				\u0018\u0003\u0019.\u0007(this, lineRevitStyleItem);
			}
			return true;
		}

		// Token: 0x06000DBB RID: 3515 RVA: 0x000582D0 File Offset: 0x000564D0
		internal LineRevitStyleItem PX(LineRevitStyleItem F)
		{
			LineStyleMappingVM.\u0014\u000B u0014_u000B = new LineStyleMappingVM.\u0014\u000B();
			u0014_u000B.\u001F = F;
			if (u0014_u000B.\u001F == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.PX(LineRevitStyleItem)).MethodHandle;
				}
				return null;
			}
			if (\u0019\u0003\u0019.\u0007(u0014_u000B.\u001F))
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
				IEnumerable<LineRevitStyleItem> enumerable = \u0017\u0012\u0019.\u0007(this);
				Func<LineRevitStyleItem, bool> func;
				if ((func = LineStyleMappingVM.<>c.\u000A) == null)
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
					func = (LineStyleMappingVM.<>c.\u000A = new Func<LineRevitStyleItem, bool>(LineStyleMappingVM.<>c.\u001F.\u0003));
				}
				return Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable, func);
			}
			if (\u001F\u0003\u0019.\u0007(u0014_u000B.\u001F))
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
				IEnumerable<LineRevitStyleItem> enumerable2 = \u0017\u0012\u0019.\u0007(this);
				Func<LineRevitStyleItem, bool> func2;
				if ((func2 = LineStyleMappingVM.<>c.\u0007) == null)
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
					func2 = (LineStyleMappingVM.<>c.\u0007 = new Func<LineRevitStyleItem, bool>(LineStyleMappingVM.<>c.\u001F.\u001C));
				}
				return Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable2, func2);
			}
			return Enumerable.FirstOrDefault<LineRevitStyleItem>(\u0017\u0012\u0019.\u0007(this), new Func<LineRevitStyleItem, bool>(u0014_u000B.\u000A));
		}

		// Token: 0x06000DBC RID: 3516 RVA: 0x000583C8 File Offset: 0x000565C8
		private ObservableCollection<LineRevitStyleItem> OX(List<LineRevitStyleItem> F)
		{
			LineStyleMappingVM.\u0013\u000B u0013_u000B = new LineStyleMappingVM.\u0013\u000B();
			ObservableCollection<LineRevitStyleItem> observableCollection = \u000E\u0003\u0019.\u000A();
			IEnumerable<LineRevitStyleItem> enumerable = \u0006\u0003\u0019.\u000A(this);
			Func<LineRevitStyleItem, bool> func;
			if ((func = LineStyleMappingVM.<>c.\u001D) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.OX(List<LineRevitStyleItem>)).MethodHandle;
				}
				func = (LineStyleMappingVM.<>c.\u001D = new Func<LineRevitStyleItem, bool>(LineStyleMappingVM.<>c.\u001F.\u000D));
			}
			LineRevitStyleItem lineRevitStyleItem = Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable, func);
			if (lineRevitStyleItem != null)
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
				\u0016\u0003\u0019.\u000A(observableCollection, \u0012\u0003\u0019.\u000A(lineRevitStyleItem, ""));
			}
			IEnumerable<LineRevitStyleItem> enumerable2 = \u0006\u0003\u0019.\u000A(this);
			Func<LineRevitStyleItem, bool> func2;
			if ((func2 = LineStyleMappingVM.<>c.\u0004) == null)
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
				func2 = (LineStyleMappingVM.<>c.\u0004 = new Func<LineRevitStyleItem, bool>(LineStyleMappingVM.<>c.\u001F.\u0010));
			}
			LineRevitStyleItem lineRevitStyleItem2 = Enumerable.FirstOrDefault<LineRevitStyleItem>(enumerable2, func2);
			if (lineRevitStyleItem2 != null)
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
				LineRevitStyleItem lineRevitStyleItem3 = \u0012\u0003\u0019.\u000A(lineRevitStyleItem2, "");
				\u0010\u0003\u0019.\u000A(lineRevitStyleItem3, this.LD);
				\u0016\u0003\u0019.\u000A(observableCollection, lineRevitStyleItem3);
			}
			Func<LineRevitStyleItem, string> func3;
			if ((func3 = LineStyleMappingVM.<>c.\u0019) == null)
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
				func3 = (LineStyleMappingVM.<>c.\u0019 = new Func<LineRevitStyleItem, string>(LineStyleMappingVM.<>c.\u001F.\u000E));
			}
			\u0014\u0018\u0019.\u000A(Enumerable.Select<LineRevitStyleItem, string>(F, func3), \u001C\u0012\u0004.\u000A());
			List<LineRevitStyleItem>.Enumerator enumerator = \u000D\u0003\u0019.\u000A(F);
			try
			{
				while (\u000F\u0003\u0019.\u000A(ref enumerator))
				{
					LineRevitStyleItem u001F = \u001C\u0003\u0019.\u000A(ref enumerator);
					\u0016\u0003\u0019.\u000A(observableCollection, \u0012\u0003\u0019.\u000A(u001F, \u0003\u0003\u0019.\u000A()));
				}
				for (;;)
				{
					switch (3)
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
			LineStyleMappingVM.\u0013\u000B u0013_u000B2 = u0013_u000B;
			ExcelLineStyleInfo excelLineStyleInfo = \u000D\u0002\u0004.\u0007(this.IR);
			ExcelLineStyle u001F2;
			if (excelLineStyleInfo == null)
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
				u001F2 = ExcelLineStyle.None;
			}
			else
			{
				u001F2 = \u0015\u0002\u0004.\u001D(excelLineStyleInfo);
			}
			u0013_u000B2.\u001F = \u0002\u0005.\u0013(u001F2);
			IEnumerable<LineRevitStyleItem> enumerable3 = \u0006\u0003\u0019.\u000A(this);
			Func<LineRevitStyleItem, bool> func4;
			if ((func4 = LineStyleMappingVM.<>c.\u0018) == null)
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
				func4 = (LineStyleMappingVM.<>c.\u0018 = new Func<LineRevitStyleItem, bool>(LineStyleMappingVM.<>c.\u001F.\u0008));
			}
			IEnumerable<\u0006<LineRevitStyleItem, int, int, double>> enumerable4 = Enumerable.Select<LineRevitStyleItem, \u0006<LineRevitStyleItem, int, int, double>>(Enumerable.Where<LineRevitStyleItem>(enumerable3, func4), new Func<LineRevitStyleItem, \u0006<LineRevitStyleItem, int, int, double>>(u0013_u000B.\u000A));
			Func<\u0006<LineRevitStyleItem, int, int, double>, int> func5;
			if ((func5 = LineStyleMappingVM.<>c.\u0005) == null)
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
				func5 = (LineStyleMappingVM.<>c.\u0005 = new Func<\u0006<LineRevitStyleItem, int, int, double>, int>(LineStyleMappingVM.<>c.\u001F.\u001B));
			}
			IOrderedEnumerable<\u0006<LineRevitStyleItem, int, int, double>> orderedEnumerable = Enumerable.OrderBy<\u0006<LineRevitStyleItem, int, int, double>, int>(enumerable4, func5);
			Func<\u0006<LineRevitStyleItem, int, int, double>, string> func6;
			if ((func6 = LineStyleMappingVM.<>c.\u0016) == null)
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
				func6 = (LineStyleMappingVM.<>c.\u0016 = new Func<\u0006<LineRevitStyleItem, int, int, double>, string>(LineStyleMappingVM.<>c.\u001F.\u0011));
			}
			IOrderedEnumerable<\u0006<LineRevitStyleItem, int, int, double>> orderedEnumerable2 = Enumerable.ThenBy<\u0006<LineRevitStyleItem, int, int, double>, string>(orderedEnumerable, func6, \u001C\u0012\u0004.\u000A());
			Func<\u0006<LineRevitStyleItem, int, int, double>, int> func7;
			if ((func7 = LineStyleMappingVM.<>c.\u000B) == null)
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
				func7 = (LineStyleMappingVM.<>c.\u000B = new Func<\u0006<LineRevitStyleItem, int, int, double>, int>(LineStyleMappingVM.<>c.\u001F.\u001E));
			}
			IOrderedEnumerable<\u0006<LineRevitStyleItem, int, int, double>> orderedEnumerable3 = Enumerable.ThenBy<\u0006<LineRevitStyleItem, int, int, double>, int>(orderedEnumerable2, func7);
			Func<\u0006<LineRevitStyleItem, int, int, double>, double> func8;
			if ((func8 = LineStyleMappingVM.<>c.\u0002) == null)
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
				func8 = (LineStyleMappingVM.<>c.\u0002 = new Func<\u0006<LineRevitStyleItem, int, int, double>, double>(LineStyleMappingVM.<>c.\u001F.\u0020));
			}
			IOrderedEnumerable<\u0006<LineRevitStyleItem, int, int, double>> orderedEnumerable4 = Enumerable.ThenBy<\u0006<LineRevitStyleItem, int, int, double>, double>(orderedEnumerable3, func8);
			Func<\u0006<LineRevitStyleItem, int, int, double>, double> func9;
			if ((func9 = LineStyleMappingVM.<>c.\u0006) == null)
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
				func9 = (LineStyleMappingVM.<>c.\u0006 = new Func<\u0006<LineRevitStyleItem, int, int, double>, double>(LineStyleMappingVM.<>c.\u001F.\u0017));
			}
			IOrderedEnumerable<\u0006<LineRevitStyleItem, int, int, double>> orderedEnumerable5 = Enumerable.ThenBy<\u0006<LineRevitStyleItem, int, int, double>, double>(orderedEnumerable4, func9);
			Func<\u0006<LineRevitStyleItem, int, int, double>, string> func10;
			if ((func10 = LineStyleMappingVM.<>c.\u000F) == null)
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
				func10 = (LineStyleMappingVM.<>c.\u000F = new Func<\u0006<LineRevitStyleItem, int, int, double>, string>(LineStyleMappingVM.<>c.\u001F.\u0014));
			}
			IEnumerable<\u0006<LineRevitStyleItem, int, int, double>> enumerable5 = Enumerable.ThenBy<\u0006<LineRevitStyleItem, int, int, double>, string>(orderedEnumerable5, func10, \u001C\u0012\u0004.\u000A());
			Func<\u0006<LineRevitStyleItem, int, int, double>, LineRevitStyleItem> func11;
			if ((func11 = LineStyleMappingVM.<>c.\u0012) == null)
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
				func11 = (LineStyleMappingVM.<>c.\u0012 = new Func<\u0006<LineRevitStyleItem, int, int, double>, LineRevitStyleItem>(LineStyleMappingVM.<>c.\u001F.\u0013));
			}
			IEnumerator<LineRevitStyleItem> enumerator2 = \u0002\u0003\u0019.\u000A(Enumerable.Select<\u0006<LineRevitStyleItem, int, int, double>, LineRevitStyleItem>(enumerable5, func11));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					LineRevitStyleItem u000A = \u000B\u0003\u0019.\u000A(enumerator2);
					\u0016\u0003\u0019.\u000A(observableCollection, u000A);
				}
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
			finally
			{
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
			return observableCollection;
		}

		// Token: 0x04000567 RID: 1383
		private readonly LineStyleMapping IR;

		// Token: 0x04000568 RID: 1384
		private LineRevitStyleItem CD;

		// Token: 0x04000569 RID: 1385
		private string LD;

		// Token: 0x0400056A RID: 1386
		private System.Windows.Media.Color SD;

		// Token: 0x0400056B RID: 1387
		[CompilerGenerated]
		private readonly ObservableCollection<LineRevitStyleItem> BD;

		// Token: 0x0400056C RID: 1388
		[CompilerGenerated]
		private readonly ObservableCollection<LineRevitStyleItem> UD;

		// Token: 0x0400056D RID: 1389
		[CompilerGenerated]
		private readonly ListCollectionView WD;

		// Token: 0x02000849 RID: 2121
		[CompilerGenerated]
		private sealed class \u0014\u000B
		{
			// Token: 0x06004E6E RID: 20078 RVA: 0x001E0C30 File Offset: 0x001DEE30
			internal bool \u000A(LineRevitStyleItem \u001F)
			{
				long? num = \u0007\u0003\u0019.\u0007(\u001F);
				long? num2 = \u0007\u0003\u0019.\u0007(this.\u001F);
				return \u0012\u001B\u0018.\u000A(ref num) == \u0012\u001B\u0018.\u000A(ref num2) & \u0016\u0002\u0004.\u000A(ref num) == \u0016\u0002\u0004.\u000A(ref num2);
			}

			// Token: 0x0400210F RID: 8463
			public LineRevitStyleItem \u001F;
		}

		// Token: 0x0200084A RID: 2122
		[CompilerGenerated]
		private sealed class \u0013\u000B
		{
			// Token: 0x06004E70 RID: 20080 RVA: 0x001E0C94 File Offset: 0x001DEE94
			internal \u0006<LineRevitStyleItem, int, int, double> \u000A(LineRevitStyleItem \u001F)
			{
				ValueTuple<int, double, double> valueTuple = \u0002\u0005.\u001A(\u0017\u001C\u0019.\u001D(\u001F));
				IReadOnlyList<LinePatternSegmentType> readOnlyList;
				if ((readOnlyList = \u0020\u001C\u0019.\u001D(\u001F)) == null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(LineStyleMappingVM.\u0013\u000B.\u000A(LineRevitStyleItem)).MethodHandle;
					}
					readOnlyList = Array.Empty<LinePatternSegmentType>();
				}
				bool flag = Enumerable.SequenceEqual<LinePatternSegmentType>(readOnlyList, this.\u001F);
				return new \u0006<LineRevitStyleItem, int, int, double>(\u001F, (!flag) ? 1 : 0, valueTuple.Item1, valueTuple.Item2);
			}

			// Token: 0x04002110 RID: 8464
			public IReadOnlyList<LinePatternSegmentType> \u001F;
		}
	}
}
