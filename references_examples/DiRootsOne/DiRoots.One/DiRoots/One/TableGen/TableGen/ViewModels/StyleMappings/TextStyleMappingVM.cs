using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Media;
using A;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.UI.Behaviours;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x02000179 RID: 377
	public class TextStyleMappingVM : ModelBase, IRowPropertyBroadcastResolver
	{
		// Token: 0x06000E15 RID: 3605 RVA: 0x0005A04C File Offset: 0x0005824C
		public TextStyleMappingVM(TextStyleMapping mapping, ObservableCollection<TextRevitStyleItem> availableStyles, List<TextRevitStyleItem> recommendedStyles)
		{
			this.IR = mapping;
			this.AvailableStyles = availableStyles;
			this.CH = \u0011\u0006\u0004.\u0007(mapping);
			this.LD = \u0002\u0005.\u001B(\u0002\u000D\u0004.\u001D(this.IR));
			ExcelTextStyleInfo excelTextStyleInfo = \u0002\u000D\u0004.\u001D(mapping);
			byte b;
			if (excelTextStyleInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM..ctor(TextStyleMapping, ObservableCollection<TextRevitStyleItem>, List<TextRevitStyleItem>)).MethodHandle;
				}
				b = 0;
			}
			else
			{
				System.Drawing.Color color = \u0005\u001D\u0004.\u001D(excelTextStyleInfo);
				b = \u0015\u0017\u001D.\u000A(ref color);
			}
			byte u001F = b;
			ExcelTextStyleInfo excelTextStyleInfo2 = \u0002\u000D\u0004.\u001D(mapping);
			byte b2;
			if (excelTextStyleInfo2 == null)
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
				b2 = 0;
			}
			else
			{
				System.Drawing.Color color = \u0005\u001D\u0004.\u001D(excelTextStyleInfo2);
				b2 = \u000C\u0017\u001D.\u000A(ref color);
			}
			byte u000A = b2;
			ExcelTextStyleInfo excelTextStyleInfo3 = \u0002\u000D\u0004.\u001D(mapping);
			byte b3;
			if (excelTextStyleInfo3 == null)
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
				b3 = 0;
			}
			else
			{
				System.Drawing.Color color = \u0005\u001D\u0004.\u001D(excelTextStyleInfo3);
				b3 = \u0013\u0017\u001D.\u000A(ref color);
			}
			byte u = b3;
			System.Windows.Media.Color sd;
			if (\u0002\u000D\u0004.\u001D(mapping) == null)
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
				sd = \u0013\u0012\u0019.\u000A();
			}
			else
			{
				sd = \u0014\u0012\u0019.\u000A(u001F, u000A, u);
			}
			this.SD = sd;
			List<TextRevitStyleItem> f = recommendedStyles;
			if (recommendedStyles == null)
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
				f = new List<TextRevitStyleItem>();
			}
			this.GroupedAvailableStyles = this.OX(f);
			this.GroupedAvailableStylesView = new ListCollectionView(\u0017\u000D\u0019.\u0007(this));
			\u0006\u0008\u0007.\u000A(\u0012\u0008\u0007.\u000A(\u0020\u000D\u0019.\u000A(this)), new PropertyGroupDescription("GroupName"));
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000E16 RID: 3606 RVA: 0x0005A1A0 File Offset: 0x000583A0
		public ExcelTextStyleInfo ExcelStyle
		{
			get
			{
				return \u0002\u000D\u0004.\u001D(this.IR);
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000E17 RID: 3607 RVA: 0x0005A1BC File Offset: 0x000583BC
		public string FontName
		{
			get
			{
				ExcelTextStyleInfo excelTextStyleInfo = \u0002\u000D\u0004.\u001D(this.IR);
				string text;
				if (excelTextStyleInfo == null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.get_FontName()).MethodHandle;
					}
					text = null;
				}
				else
				{
					text = \u0016\u001D\u0004.\u001D(excelTextStyleInfo);
				}
				string result;
				if ((result = text) == null)
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
					result = string.Empty;
				}
				return result;
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x06000E18 RID: 3608 RVA: 0x0005A20C File Offset: 0x0005840C
		public string ColorDisplay
		{
			get
			{
				ExcelTextStyleInfo excelTextStyleInfo = \u0002\u000D\u0004.\u001D(this.IR);
				System.Drawing.Color? u001F;
				if (excelTextStyleInfo == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.get_ColorDisplay()).MethodHandle;
					}
					System.Drawing.Color? color;
					\u0009\u0019\u000E.\u001F(ref color);
					u001F = color;
				}
				else
				{
					u001F = new System.Drawing.Color?(\u0005\u001D\u0004.\u001D(excelTextStyleInfo));
				}
				return \u0002\u0005.\u0015(u001F, ", ", "", "");
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x06000E19 RID: 3609 RVA: 0x0005A26C File Offset: 0x0005846C
		public string BoldItalicDisplay
		{
			get
			{
				ExcelTextStyleInfo excelTextStyleInfo = \u0002\u000D\u0004.\u001D(this.IR);
				bool flag;
				if (excelTextStyleInfo == null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.get_BoldItalicDisplay()).MethodHandle;
					}
					flag = false;
				}
				else
				{
					flag = \u0018\u001D\u0004.\u001D(excelTextStyleInfo);
				}
				bool flag2 = flag;
				ExcelTextStyleInfo excelTextStyleInfo2 = \u0002\u000D\u0004.\u001D(this.IR);
				bool flag3;
				if (excelTextStyleInfo2 == null)
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
					flag3 = false;
				}
				else
				{
					flag3 = \u0019\u001D\u0004.\u001D(excelTextStyleInfo2);
				}
				bool flag4 = flag3;
				if (flag2 && flag4)
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
					return \u0002\u0013\u000A.\u000A(\u0013\u000D\u0019.\u000A(), ", ", \u0014\u000D\u0019.\u000A());
				}
				if (flag2)
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
					return \u0013\u000D\u0019.\u000A();
				}
				if (flag4)
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
					return \u0014\u000D\u0019.\u000A();
				}
				return string.Empty;
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x06000E1A RID: 3610 RVA: 0x0005A328 File Offset: 0x00058528
		public System.Windows.Media.Color Color
		{
			get
			{
				return this.SD;
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x06000E1B RID: 3611 RVA: 0x0005A33C File Offset: 0x0005853C
		public double SizeInPt
		{
			get
			{
				ExcelTextStyleInfo excelTextStyleInfo = \u0002\u000D\u0004.\u001D(this.IR);
				if (excelTextStyleInfo == null)
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
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.get_SizeInPt()).MethodHandle;
					}
					return 0.0;
				}
				return \u001B\u0006\u0004.\u001D(excelTextStyleInfo);
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000E1C RID: 3612 RVA: 0x0005A380 File Offset: 0x00058580
		// (set) Token: 0x06000E1D RID: 3613 RVA: 0x0005A39C File Offset: 0x0005859C
		public bool IsNew
		{
			get
			{
				return \u001A\u000D\u0019.\u000A(this.IR);
			}
			set
			{
				\u0003\u0006\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "IsNew");
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x06000E1E RID: 3614 RVA: 0x0005A3C0 File Offset: 0x000585C0
		// (set) Token: 0x06000E1F RID: 3615 RVA: 0x0005A3DC File Offset: 0x000585DC
		[BroadcastOnMultiSelect]
		public string RevitTextStyleName
		{
			get
			{
				return \u000E\u0006\u0004.\u0007(this.IR);
			}
			set
			{
				\u0008\u001C\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "RevitTextStyleName");
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x06000E20 RID: 3616 RVA: 0x0005A400 File Offset: 0x00058600
		// (set) Token: 0x06000E21 RID: 3617 RVA: 0x0005A41C File Offset: 0x0005861C
		public string RevitTextStyleElementId
		{
			get
			{
				return \u000D\u0006\u0004.\u000A(this.IR);
			}
			set
			{
				\u001C\u0006\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "RevitTextStyleElementId");
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x06000E22 RID: 3618 RVA: 0x0005A440 File Offset: 0x00058640
		// (set) Token: 0x06000E23 RID: 3619 RVA: 0x0005A454 File Offset: 0x00058654
		[BroadcastOnMultiSelect]
		public double ScheduleFontSize
		{
			get
			{
				return this.CH;
			}
			set
			{
				this.CH = value;
				\u000E\u001C\u0004.\u000A(this.IR, value);
				\u0007\u0013\u000A.\u000A(this, "ScheduleFontSize");
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x06000E24 RID: 3620 RVA: 0x0005A480 File Offset: 0x00058680
		// (set) Token: 0x06000E25 RID: 3621 RVA: 0x0005A494 File Offset: 0x00058694
		[BroadcastOnMultiSelect]
		public TextRevitStyleItem SelectedRevitStyle
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
						switch (5)
						{
						case 0:
							continue;
						}
						break;
					}
					if (!true)
					{
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.set_SelectedRevitStyle(TextRevitStyleItem)).MethodHandle;
					}
					if (\u001F\u0003\u0019.\u0007(value))
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
						\u0001\u000D\u0019.\u0007(this, this.LD);
					}
					else
					{
						\u0001\u000D\u0019.\u0007(this, \u0004\u0003\u0019.\u0007(value));
					}
					\u0015\u000D\u0019.\u000A(this, \u000A\u000D\u0019.\u001D(value));
					\u000C\u000D\u0019.\u000A(this, \u001F\u0003\u0019.\u0007(value));
				}
				\u0007\u0013\u000A.\u000A(this, "SelectedRevitStyle");
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x06000E26 RID: 3622 RVA: 0x0005A518 File Offset: 0x00058718
		public ObservableCollection<TextRevitStyleItem> AvailableStyles { get; }

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000E27 RID: 3623 RVA: 0x0005A52C File Offset: 0x0005872C
		public ObservableCollection<TextRevitStyleItem> GroupedAvailableStyles { get; }

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06000E28 RID: 3624 RVA: 0x0005A540 File Offset: 0x00058740
		public ListCollectionView GroupedAvailableStylesView { get; }

		// Token: 0x06000E29 RID: 3625 RVA: 0x0005A554 File Offset: 0x00058754
		public TextStyleMapping GetMapping()
		{
			return this.IR;
		}

		// Token: 0x06000E2A RID: 3626 RVA: 0x0005A568 File Offset: 0x00058768
		public bool TryApplyBroadcast(object source, string propertyName)
		{
			TextStyleMappingVM textStyleMappingVM = \u000E\u0005\u000E.\u001F(source);
			if (textStyleMappingVM == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.TryApplyBroadcast(object, string)).MethodHandle;
				}
				return false;
			}
			if (\u001D\u0017\u000A.\u000A(propertyName, "SelectedRevitStyle"))
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
				return false;
			}
			TextRevitStyleItem textRevitStyleItem = this.PX(\u001F\u0010\u0019.\u000A(textStyleMappingVM));
			if (textRevitStyleItem != null)
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
				\u0009\u000D\u0019.\u0007(this, textRevitStyleItem);
			}
			return true;
		}

		// Token: 0x06000E2B RID: 3627 RVA: 0x0005A5D8 File Offset: 0x000587D8
		internal TextRevitStyleItem PX(TextRevitStyleItem F)
		{
			TextStyleMappingVM.\u0015\u000B u0015_u000B = new TextStyleMappingVM.\u0015\u000B();
			u0015_u000B.\u001F = F;
			if (u0015_u000B.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.PX(TextRevitStyleItem)).MethodHandle;
				}
				return null;
			}
			if (\u001F\u0003\u0019.\u0007(u0015_u000B.\u001F))
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
				IEnumerable<TextRevitStyleItem> enumerable = \u0017\u000D\u0019.\u0007(this);
				Func<TextRevitStyleItem, bool> func;
				if ((func = TextStyleMappingVM.<>c.\u000A) == null)
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
					func = (TextStyleMappingVM.<>c.\u000A = new Func<TextRevitStyleItem, bool>(TextStyleMappingVM.<>c.\u001F.\u0012));
				}
				return Enumerable.FirstOrDefault<TextRevitStyleItem>(enumerable, func);
			}
			return Enumerable.FirstOrDefault<TextRevitStyleItem>(\u0017\u000D\u0019.\u0007(this), new Func<TextRevitStyleItem, bool>(u0015_u000B.\u000A));
		}

		// Token: 0x06000E2C RID: 3628 RVA: 0x0005A67C File Offset: 0x0005887C
		private ObservableCollection<TextRevitStyleItem> OX(List<TextRevitStyleItem> F)
		{
			ObservableCollection<TextRevitStyleItem> observableCollection = \u000B\u0010\u0019.\u000A();
			IEnumerable<TextRevitStyleItem> enumerable = \u0004\u0010\u0019.\u000A(this);
			Func<TextRevitStyleItem, bool> func;
			if ((func = TextStyleMappingVM.<>c.\u0007) == null)
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStyleMappingVM.OX(List<TextRevitStyleItem>)).MethodHandle;
				}
				func = (TextStyleMappingVM.<>c.\u0007 = new Func<TextRevitStyleItem, bool>(TextStyleMappingVM.<>c.\u001F.\u0003));
			}
			TextRevitStyleItem textRevitStyleItem = Enumerable.FirstOrDefault<TextRevitStyleItem>(enumerable, func);
			if (textRevitStyleItem != null)
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
				TextRevitStyleItem textRevitStyleItem2 = \u0018\u0010\u0019.\u000A(textRevitStyleItem, "");
				\u0010\u0003\u0019.\u000A(textRevitStyleItem2, this.LD);
				\u000A\u0010\u0019.\u000A(observableCollection, textRevitStyleItem2);
			}
			Func<TextRevitStyleItem, string> func2;
			if ((func2 = TextStyleMappingVM.<>c.\u001D) == null)
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
				func2 = (TextStyleMappingVM.<>c.\u001D = new Func<TextRevitStyleItem, string>(TextStyleMappingVM.<>c.\u001F.\u001C));
			}
			\u0014\u0018\u0019.\u000A(Enumerable.Select<TextRevitStyleItem, string>(F, func2), \u001C\u0012\u0004.\u000A());
			List<TextRevitStyleItem>.Enumerator enumerator = \u0016\u0010\u0019.\u000A(F);
			try
			{
				while (\u0019\u0010\u0019.\u000A(ref enumerator))
				{
					TextRevitStyleItem u001F = \u0005\u0010\u0019.\u000A(ref enumerator);
					\u000A\u0010\u0019.\u000A(observableCollection, \u0018\u0010\u0019.\u000A(u001F, \u0003\u0003\u0019.\u000A()));
				}
				for (;;)
				{
					switch (6)
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
			IEnumerable<TextRevitStyleItem> enumerable2 = \u0004\u0010\u0019.\u000A(this);
			Func<TextRevitStyleItem, bool> func3;
			if ((func3 = TextStyleMappingVM.<>c.\u0004) == null)
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
				func3 = (TextStyleMappingVM.<>c.\u0004 = new Func<TextRevitStyleItem, bool>(TextStyleMappingVM.<>c.\u001F.\u000D));
			}
			IEnumerable<TextRevitStyleItem> enumerable3 = Enumerable.Where<TextRevitStyleItem>(enumerable2, func3);
			Func<TextRevitStyleItem, \u0012<TextRevitStyleItem, int, double, int>> func4;
			if ((func4 = TextStyleMappingVM.<>c.\u0019) == null)
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
				func4 = (TextStyleMappingVM.<>c.\u0019 = new Func<TextRevitStyleItem, \u0012<TextRevitStyleItem, int, double, int>>(TextStyleMappingVM.<>c.\u001F.\u0010));
			}
			IEnumerable<\u0012<TextRevitStyleItem, int, double, int>> enumerable4 = Enumerable.Select<TextRevitStyleItem, \u0012<TextRevitStyleItem, int, double, int>>(enumerable3, func4);
			Func<\u0012<TextRevitStyleItem, int, double, int>, string> func5;
			if ((func5 = TextStyleMappingVM.<>c.\u0018) == null)
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
				func5 = (TextStyleMappingVM.<>c.\u0018 = new Func<\u0012<TextRevitStyleItem, int, double, int>, string>(TextStyleMappingVM.<>c.\u001F.\u000E));
			}
			IOrderedEnumerable<\u0012<TextRevitStyleItem, int, double, int>> orderedEnumerable = Enumerable.OrderBy<\u0012<TextRevitStyleItem, int, double, int>, string>(enumerable4, func5, \u001C\u0012\u0004.\u000A());
			Func<\u0012<TextRevitStyleItem, int, double, int>, int> func6;
			if ((func6 = TextStyleMappingVM.<>c.\u0005) == null)
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
				func6 = (TextStyleMappingVM.<>c.\u0005 = new Func<\u0012<TextRevitStyleItem, int, double, int>, int>(TextStyleMappingVM.<>c.\u001F.\u0008));
			}
			IOrderedEnumerable<\u0012<TextRevitStyleItem, int, double, int>> orderedEnumerable2 = Enumerable.ThenBy<\u0012<TextRevitStyleItem, int, double, int>, int>(orderedEnumerable, func6);
			Func<\u0012<TextRevitStyleItem, int, double, int>, double> func7;
			if ((func7 = TextStyleMappingVM.<>c.\u0016) == null)
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
				func7 = (TextStyleMappingVM.<>c.\u0016 = new Func<\u0012<TextRevitStyleItem, int, double, int>, double>(TextStyleMappingVM.<>c.\u001F.\u001B));
			}
			IOrderedEnumerable<\u0012<TextRevitStyleItem, int, double, int>> orderedEnumerable3 = Enumerable.ThenBy<\u0012<TextRevitStyleItem, int, double, int>, double>(orderedEnumerable2, func7);
			Func<\u0012<TextRevitStyleItem, int, double, int>, double> func8;
			if ((func8 = TextStyleMappingVM.<>c.\u000B) == null)
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
				func8 = (TextStyleMappingVM.<>c.\u000B = new Func<\u0012<TextRevitStyleItem, int, double, int>, double>(TextStyleMappingVM.<>c.\u001F.\u0011));
			}
			IOrderedEnumerable<\u0012<TextRevitStyleItem, int, double, int>> orderedEnumerable4 = Enumerable.ThenBy<\u0012<TextRevitStyleItem, int, double, int>, double>(orderedEnumerable3, func8);
			Func<\u0012<TextRevitStyleItem, int, double, int>, int> func9;
			if ((func9 = TextStyleMappingVM.<>c.\u0002) == null)
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
				func9 = (TextStyleMappingVM.<>c.\u0002 = new Func<\u0012<TextRevitStyleItem, int, double, int>, int>(TextStyleMappingVM.<>c.\u001F.\u001E));
			}
			IOrderedEnumerable<\u0012<TextRevitStyleItem, int, double, int>> orderedEnumerable5 = Enumerable.ThenBy<\u0012<TextRevitStyleItem, int, double, int>, int>(orderedEnumerable4, func9);
			Func<\u0012<TextRevitStyleItem, int, double, int>, string> func10;
			if ((func10 = TextStyleMappingVM.<>c.\u0006) == null)
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
				func10 = (TextStyleMappingVM.<>c.\u0006 = new Func<\u0012<TextRevitStyleItem, int, double, int>, string>(TextStyleMappingVM.<>c.\u001F.\u0020));
			}
			IEnumerable<\u0012<TextRevitStyleItem, int, double, int>> enumerable5 = Enumerable.ThenBy<\u0012<TextRevitStyleItem, int, double, int>, string>(orderedEnumerable5, func10, \u001C\u0012\u0004.\u000A());
			Func<\u0012<TextRevitStyleItem, int, double, int>, TextRevitStyleItem> func11;
			if ((func11 = TextStyleMappingVM.<>c.\u000F) == null)
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
				func11 = (TextStyleMappingVM.<>c.\u000F = new Func<\u0012<TextRevitStyleItem, int, double, int>, TextRevitStyleItem>(TextStyleMappingVM.<>c.\u001F.\u0017));
			}
			IEnumerator<TextRevitStyleItem> enumerator2 = \u001D\u0010\u0019.\u000A(Enumerable.Select<\u0012<TextRevitStyleItem, int, double, int>, TextRevitStyleItem>(enumerable5, func11));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					TextRevitStyleItem u000A = \u0007\u0010\u0019.\u000A(enumerator2);
					\u000A\u0010\u0019.\u000A(observableCollection, u000A);
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
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
			return observableCollection;
		}

		// Token: 0x04000591 RID: 1425
		private readonly TextStyleMapping IR;

		// Token: 0x04000592 RID: 1426
		private TextRevitStyleItem CD;

		// Token: 0x04000593 RID: 1427
		private double CH;

		// Token: 0x04000594 RID: 1428
		private string LD;

		// Token: 0x04000595 RID: 1429
		private System.Windows.Media.Color SD;

		// Token: 0x04000596 RID: 1430
		[CompilerGenerated]
		private readonly ObservableCollection<TextRevitStyleItem> BD;

		// Token: 0x04000597 RID: 1431
		[CompilerGenerated]
		private readonly ObservableCollection<TextRevitStyleItem> UD;

		// Token: 0x04000598 RID: 1432
		[CompilerGenerated]
		private readonly ListCollectionView WD;

		// Token: 0x0200084F RID: 2127
		[CompilerGenerated]
		private sealed class \u0015\u000B
		{
			// Token: 0x06004E92 RID: 20114 RVA: 0x001E1140 File Offset: 0x001DF340
			internal bool \u000A(TextRevitStyleItem \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000A\u000D\u0019.\u001D(\u001F), \u000A\u000D\u0019.\u001D(this.\u001F));
			}

			// Token: 0x0400212E RID: 8494
			public TextRevitStyleItem \u001F;
		}
	}
}
