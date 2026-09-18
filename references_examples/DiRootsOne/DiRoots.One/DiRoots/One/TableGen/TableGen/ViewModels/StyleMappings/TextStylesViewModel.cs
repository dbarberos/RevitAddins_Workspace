using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Interfaces;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace DiRoots.One.TableGen.TableGen.ViewModels.StyleMappings
{
	// Token: 0x0200017A RID: 378
	public class TextStylesViewModel : StylesViewModelBase<TextStyleMappingVM>
	{
		// Token: 0x06000E2D RID: 3629 RVA: 0x0005A9C0 File Offset: 0x00058BC0
		public TextStylesViewModel(Document doc, List<TextStyleMapping> styleMappings, Action onReadFromFiles, Action onMarkDataChanged) : base(doc, onReadFromFiles, onMarkDataChanged)
		{
			\u0008\u000D\u0019.\u001D(this, styleMappings);
			this.AvailableTextStyles = this.VP();
			this.TextStyleMappingVMs = new ObservableCollection<TextStyleMappingVM>();
			\u0006\u0010\u0019.\u000A(this, \u0011\u0009\u000A.\u000A(\u000F\u0010\u0019.\u000A(this)));
			\u0005\u0008\u0007.\u000A(\u0002\u0010\u0019.\u000A(this), new Predicate<object>(this.XP));
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06000E2E RID: 3630 RVA: 0x0005AA28 File Offset: 0x00058C28
		// (set) Token: 0x06000E2F RID: 3631 RVA: 0x0005AA3C File Offset: 0x00058C3C
		public List<TextStyleMapping> StyleMappings { get; set; }

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06000E30 RID: 3632 RVA: 0x0005AA50 File Offset: 0x00058C50
		public ObservableCollection<TextStyleMappingVM> TextStyleMappingVMs { get; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06000E31 RID: 3633 RVA: 0x0005AA64 File Offset: 0x00058C64
		public ObservableCollection<TextRevitStyleItem> AvailableTextStyles { get; }

		// Token: 0x06000E32 RID: 3634 RVA: 0x0005AA78 File Offset: 0x00058C78
		public void UpdateMappingVMs()
		{
			\u000E\u0010\u0019.\u000A(this, \u000F\u0010\u0019.\u000A(this));
			\u0010\u0010\u0019.\u000A(\u000F\u0010\u0019.\u000A(this));
			List<TextStyleMapping>.Enumerator enumerator = \u000F\u000D\u0004.\u000A(\u000D\u0010\u0019.\u000A(this));
			try
			{
				while (\u0016\u000D\u0004.\u000A(ref enumerator))
				{
					TextStyleMapping u001F = \u0006\u000D\u0004.\u000A(ref enumerator);
					List<TextRevitStyleItem> u = this.ZP(\u0002\u000D\u0004.\u001D(u001F));
					TextStyleMappingVM textStyleMappingVM = \u0003\u0010\u0019.\u000A(u001F, \u001C\u0010\u0019.\u000A(this), u);
					this.MP(textStyleMappingVM);
					\u0017\u0003\u0019.\u000A(textStyleMappingVM, new PropertyChangedEventHandler(base.StyleVm_PropertyChanged));
					\u0012\u0010\u0019.\u000A(\u000F\u0010\u0019.\u000A(this), textStyleMappingVM);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.UpdateMappingVMs()).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0007\u0013\u000A.\u000A(this, "StylesView");
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x0005AB50 File Offset: 0x00058D50
		private void MP(TextStyleMappingVM F)
		{
			TextStylesViewModel.\u0001\u000B u0001_u000B = new TextStylesViewModel.\u0001\u000B();
			u0001_u000B.\u001F = F;
			string u000A = \u001B\u0010\u0019.\u000A(u0001_u000B.\u001F);
			if (\u0011\u0010\u0019.\u000A(u0001_u000B.\u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.MP(TextStyleMappingVM)).MethodHandle;
				}
				object u001F = u0001_u000B.\u001F;
				IEnumerable<TextRevitStyleItem> enumerable = \u0017\u000D\u0019.\u001D(u0001_u000B.\u001F);
				Func<TextRevitStyleItem, bool> func;
				if ((func = TextStylesViewModel.<>c.\u000A) == null)
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
					func = (TextStylesViewModel.<>c.\u000A = new Func<TextRevitStyleItem, bool>(TextStylesViewModel.<>c.\u001F.\u0004));
				}
				\u0009\u000D\u0019.\u001D(u001F, Enumerable.FirstOrDefault<TextRevitStyleItem>(enumerable, func));
				if (!\u001B\u0003\u0004.\u000A(\u001B\u0010\u0019.\u000A(u0001_u000B.\u001F), u000A, StringComparison.Ordinal))
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
					\u0001\u000D\u0019.\u001D(u0001_u000B.\u001F, u000A);
					return;
				}
			}
			else
			{
				if (!\u001A\u0006\u0007.\u000A(\u0008\u0010\u0019.\u000A(u0001_u000B.\u001F)))
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
					TextRevitStyleItem textRevitStyleItem = Enumerable.FirstOrDefault<TextRevitStyleItem>(\u0017\u000D\u0019.\u001D(u0001_u000B.\u001F), new Func<TextRevitStyleItem, bool>(u0001_u000B.\u000A));
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
						\u0009\u000D\u0019.\u001D(u0001_u000B.\u001F, textRevitStyleItem);
						return;
					}
				}
				TextRevitStyleItem textRevitStyleItem2 = Enumerable.FirstOrDefault<TextRevitStyleItem>(\u0017\u000D\u0019.\u001D(u0001_u000B.\u001F), new Func<TextRevitStyleItem, bool>(u0001_u000B.\u0007));
				object u001F2 = u0001_u000B.\u001F;
				TextRevitStyleItem u000A2;
				if ((u000A2 = textRevitStyleItem2) == null)
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
					IEnumerable<TextRevitStyleItem> enumerable2 = \u0017\u000D\u0019.\u001D(u0001_u000B.\u001F);
					Func<TextRevitStyleItem, bool> func2;
					if ((func2 = TextStylesViewModel.<>c.\u0007) == null)
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
						func2 = (TextStylesViewModel.<>c.\u0007 = new Func<TextRevitStyleItem, bool>(TextStylesViewModel.<>c.\u001F.\u0019));
					}
					u000A2 = Enumerable.FirstOrDefault<TextRevitStyleItem>(enumerable2, func2);
				}
				\u0009\u000D\u0019.\u001D(u001F2, u000A2);
			}
		}

		// Token: 0x06000E34 RID: 3636 RVA: 0x0005ACEC File Offset: 0x00058EEC
		private ObservableCollection<TextRevitStyleItem> VP()
		{
			ObservableCollection<TextRevitStyleItem> observableCollection = \u000B\u0010\u0019.\u000A();
			object u001F = observableCollection;
			TextRevitStyleItem textRevitStyleItem = \u0007\u000D\u0019.\u000A();
			\u0010\u0003\u0019.\u000A(textRevitStyleItem, \u001C\u001C\u0019.\u000A());
			\u000B\u001C\u0019.\u000A(textRevitStyleItem, true);
			\u0016\u001C\u0019.\u000A(textRevitStyleItem, "");
			\u0001\u001C\u0019.\u000A(textRevitStyleItem, "");
			\u000A\u0010\u0019.\u000A(u001F, textRevitStyleItem);
			try
			{
				IEnumerator<TextNoteType> enumerator = \u001B\u0018\u0004.\u000A(this._doc.GetElements<TextNoteType>());
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						TextNoteType u001F2 = \u0008\u0018\u0004.\u000A(enumerator);
						Parameter parameter = \u0016\u0018\u0007.\u0007(u001F2, -1006300L);
						string text;
						if (parameter == null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.VP()).MethodHandle;
							}
							text = null;
						}
						else
						{
							text = \u001A\u0014\u0007.\u001D(parameter);
						}
						string text2;
						if ((text2 = text) == null)
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
							text2 = "";
						}
						string u000A = text2;
						Parameter parameter2 = \u0016\u0018\u0007.\u0007(u001F2, -1006301L);
						double num;
						if (parameter2 == null)
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
							num = 0.0;
						}
						else
						{
							num = \u0020\u0010\u0019.\u0007(parameter2);
						}
						double u000A2 = num;
						Parameter parameter3 = \u0016\u0018\u0007.\u0007(u001F2, -1006311L);
						int num2;
						if (parameter3 == null)
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
							num2 = 0;
						}
						else
						{
							num2 = \u001E\u0010\u0019.\u001D(parameter3);
						}
						bool u000A3 = num2 == 1;
						Parameter parameter4 = \u0016\u0018\u0007.\u0007(u001F2, -1006312L);
						int num3;
						if (parameter4 == null)
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
							num3 = 0;
						}
						else
						{
							num3 = \u001E\u0010\u0019.\u001D(parameter4);
						}
						bool u000A4 = num3 == 1;
						Parameter parameter5 = \u0016\u0018\u0007.\u0007(u001F2, -1006304L);
						Color u000A5 = \u0013\u0012\u0019.\u000A();
						if (parameter5 != null)
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
							int num4 = \u001E\u0010\u0019.\u0007(parameter5);
							byte u001F3 = (byte)(num4 & 255);
							byte u000A6 = (byte)(num4 >> 8 & 255);
							byte u = (byte)(num4 >> 16 & 255);
							u000A5 = \u0014\u0012\u0019.\u000A(u001F3, u000A6, u);
						}
						object u001F4 = observableCollection;
						TextRevitStyleItem textRevitStyleItem2 = \u0007\u000D\u0019.\u000A();
						\u0010\u0003\u0019.\u000A(textRevitStyleItem2, \u0005\u001E\u000A.\u000A(u001F2));
						\u0002\u001C\u0019.\u000A(textRevitStyleItem2, new long?(\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2))));
						\u001F\u000D\u0019.\u000A(textRevitStyleItem2, \u0012\u0010\u0007.\u000A(u001F2));
						\u000B\u001C\u0019.\u000A(textRevitStyleItem2, false);
						\u0001\u001C\u0019.\u000A(textRevitStyleItem2, u000A);
						\u0016\u001C\u0019.\u000A(textRevitStyleItem2, u000A);
						\u0005\u001C\u0019.\u000A(textRevitStyleItem2, u000A2);
						\u000C\u001C\u0019.\u000A(textRevitStyleItem2, u000A3);
						\u0013\u001C\u0019.\u000A(textRevitStyleItem2, u000A4);
						\u001D\u001C\u0019.\u000A(textRevitStyleItem2, u000A5);
						\u000A\u0010\u0019.\u000A(u001F4, textRevitStyleItem2);
					}
					for (;;)
					{
						switch (1)
						{
						case 0:
							continue;
						}
						break;
					}
				}
				finally
				{
					if (enumerator != null)
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
						\u001F\u0017\u000A.\u000A(enumerator);
					}
				}
			}
			catch (Exception u000A7)
			{
				\u000F\u000E\u001D.\u000A(\u0007\u0018.\u0007<ICustomLogger>(), u000A7, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\TableGen\\TableGen\\ViewModels\\StyleMappings\\TextStylesViewModel.cs", "BuildAvailableTextStyles");
			}
			return observableCollection;
		}

		// Token: 0x06000E35 RID: 3637 RVA: 0x0005AF80 File Offset: 0x00059180
		internal List<TextRevitStyleItem> ZP(ExcelTextStyleInfo F)
		{
			TextStylesViewModel.\u0009\u000B u0009_u000B = new TextStylesViewModel.\u0009\u000B();
			u0009_u000B.\u001F = F;
			if (u0009_u000B.\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.ZP(ExcelTextStyleInfo)).MethodHandle;
				}
				return \u0017\u0010\u0019.\u000A();
			}
			u0009_u000B.\u000A = \u0002\u0018.\u0016(\u0002\u0018.\u0005(\u001B\u0006\u0004.\u0007(u0009_u000B.\u001F)));
			return Enumerable.ToList<TextRevitStyleItem>(Enumerable.Take<TextRevitStyleItem>(Enumerable.OrderBy<TextRevitStyleItem, double>(Enumerable.Where<TextRevitStyleItem>(\u001C\u0010\u0019.\u000A(this), new Func<TextRevitStyleItem, bool>(u0009_u000B.\u0007)), new Func<TextRevitStyleItem, double>(u0009_u000B.\u001D)), 5));
		}

		// Token: 0x06000E36 RID: 3638 RVA: 0x0005B01C File Offset: 0x0005921C
		private bool XP(object F)
		{
			if (\u0010\u0010\u001D.\u000A(this._searchText))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.XP(object)).MethodHandle;
				}
				return true;
			}
			TextStyleMappingVM textStyleMappingVM = \u000E\u0005\u000E.\u001F(F);
			if (textStyleMappingVM != null)
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
				string u000A = \u000D\u0003\u0004.\u001D(this._searchText);
				if (!\u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(\u001A\u0010\u0019.\u000A(textStyleMappingVM)), u000A))
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
					if (!\u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(\u0013\u0010\u0019.\u000A(textStyleMappingVM)), u000A))
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
						if (!\u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(\u0014\u0010\u0019.\u000A(textStyleMappingVM)), u000A))
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
							string u001F;
							if ((u001F = \u001B\u0010\u0019.\u000A(textStyleMappingVM)) == null)
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
								u001F = "";
							}
							return \u000F\u000C\u001D.\u0007(\u000D\u0003\u0004.\u001D(u001F), u000A);
						}
					}
				}
				return true;
			}
			return true;
		}

		// Token: 0x06000E37 RID: 3639 RVA: 0x0005B110 File Offset: 0x00059310
		public List<TextStyleMapping> GetStyleMappings()
		{
			IEnumerable<TextStyleMappingVM> enumerable = \u000F\u0010\u0019.\u000A(this);
			Func<TextStyleMappingVM, TextStyleMapping> func;
			if ((func = TextStylesViewModel.<>c.\u001D) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.GetStyleMappings()).MethodHandle;
				}
				func = (TextStylesViewModel.<>c.\u001D = new Func<TextStyleMappingVM, TextStyleMapping>(TextStylesViewModel.<>c.\u001F.\u0018));
			}
			return Enumerable.ToList<TextStyleMapping>(Enumerable.Select<TextStyleMappingVM, TextStyleMapping>(enumerable, func));
		}

		// Token: 0x04000599 RID: 1433
		[CompilerGenerated]
		private List<TextStyleMapping> KD;

		// Token: 0x0400059A RID: 1434
		[CompilerGenerated]
		private readonly ObservableCollection<TextStyleMappingVM> LH;

		// Token: 0x0400059B RID: 1435
		[CompilerGenerated]
		private readonly ObservableCollection<TextRevitStyleItem> SH;

		// Token: 0x02000851 RID: 2129
		[CompilerGenerated]
		private sealed class \u0001\u000B
		{
			// Token: 0x06004E99 RID: 20121 RVA: 0x001E11F8 File Offset: 0x001DF3F8
			internal bool \u000A(TextRevitStyleItem \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u000A\u000D\u0019.\u001D(\u001F), \u0008\u0010\u0019.\u000A(this.\u001F));
			}

			// Token: 0x06004E9A RID: 20122 RVA: 0x001E1224 File Offset: 0x001DF424
			internal bool \u0007(TextRevitStyleItem \u001F)
			{
				if (\u0008\u0013\u000A.\u000A(\u0004\u0003\u0019.\u0007(\u001F), \u001B\u0010\u0019.\u000A(this.\u001F)))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.\u0001\u000B.\u0007(TextRevitStyleItem)).MethodHandle;
					}
					return !\u001F\u0003\u0019.\u0007(\u001F);
				}
				return false;
			}

			// Token: 0x04002133 RID: 8499
			public TextStyleMappingVM \u001F;
		}

		// Token: 0x02000852 RID: 2130
		[CompilerGenerated]
		private sealed class \u0009\u000B
		{
			// Token: 0x06004E9C RID: 20124 RVA: 0x001E1284 File Offset: 0x001DF484
			internal bool \u0007(TextRevitStyleItem \u001F)
			{
				if (!\u001F\u0003\u0019.\u0007(\u001F))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(TextStylesViewModel.\u0009\u000B.\u0007(TextRevitStyleItem)).MethodHandle;
					}
					return \u001B\u0003\u0004.\u000A(\u0009\u001C\u0019.\u001D(\u001F), \u0016\u001D\u0004.\u0007(this.\u001F), StringComparison.OrdinalIgnoreCase);
				}
				return false;
			}

			// Token: 0x06004E9D RID: 20125 RVA: 0x001E12D0 File Offset: 0x001DF4D0
			internal double \u001D(TextRevitStyleItem \u001F)
			{
				return \u0008\u001F\u0007.\u000A(\u0014\u001C\u0019.\u001D(\u001F) - this.\u000A);
			}

			// Token: 0x04002134 RID: 8500
			public ExcelTextStyleInfo \u001F;

			// Token: 0x04002135 RID: 8501
			public double \u000A;
		}
	}
}
