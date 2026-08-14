using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using DiRoots.One.SheetGen.Data;
using DiRoots.Revit.DataCollectors;

namespace DiRoots.One.SheetGen
{
	// Token: 0x020002A7 RID: 679
	public class SheetAndViewCreationHelper
	{
		// Token: 0x06001AD5 RID: 6869 RVA: 0x000AEA34 File Offset: 0x000ACC34
		public SheetAndViewCreationHelper()
		{
			this.\u0007();
		}

		// Token: 0x06001AD6 RID: 6870 RVA: 0x000AEA50 File Offset: 0x000ACC50
		private void \u0007()
		{
			Document document = \u0019\u001F\u0016.\u000A(DocumentAccessProvider.\u0004);
			this.\u001F = document.CollectElements(null);
			this.\u000A = document.CollectElements(null);
		}

		// Token: 0x06001AD7 RID: 6871 RVA: 0x000AEA8C File Offset: 0x000ACC8C
		internal static string \u001D(View \u001F)
		{
			return \u0005\u001E\u000A.\u000A(\u001F);
		}

		// Token: 0x06001AD8 RID: 6872 RVA: 0x000AEAA4 File Offset: 0x000ACCA4
		public ElementId DuplicateViewWithoutSuffix(Document doc, View vi, string name, ViewDuplicateOption DuplicationOption)
		{
			ElementId elementId = \u0012\u0015\u0010.\u001F;
			string u001F = "\\:{}[]|;<>?`~";
			for (int i = 0; i < \u001C\u000F\u0007.\u0007(u001F); i++)
			{
				char c = \u001E\u001E\u0007.\u001D(u001F, i);
				if (Enumerable.Contains<char>(name, c))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetAndViewCreationHelper.DuplicateViewWithoutSuffix(Document, View, string, ViewDuplicateOption)).MethodHandle;
					}
					name = \u001C\u000B\u001D.\u0007(name, \u001E\u000E\u0004.\u000A(ref c), "");
				}
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
			string u000A;
			if (!\u0020\u0006\u0016.\u000A(this, doc, name, \u001C\u001C\u0007.\u0007(vi)))
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
				u000A = name;
			}
			else
			{
				int num = 1;
				while (\u0020\u0006\u0016.\u000A(this, doc, \u0002\u0013\u000A.\u000A(name, " - ", \u000C\u0013\u0007.\u000A(ref num)), \u001C\u001C\u0007.\u0007(vi)))
				{
					num++;
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
				u000A = \u0002\u0013\u000A.\u000A(name, " - ", \u000C\u0013\u0007.\u000A(ref num));
			}
			if (\u0007\u0014\u0005.\u000A(vi, DuplicationOption))
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
				elementId = \u000A\u0013\u0007.\u000A(vi, DuplicationOption);
				\u0011\u0013\u0007.\u000A(\u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(doc, elementId)), u000A);
			}
			return elementId;
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x000AEBD4 File Offset: 0x000ACDD4
		public View DuplicateView(Document doc, View vi, string suffix, ViewDuplicateOption viewDuplicateOption = 2)
		{
			ElementId u000A = \u0012\u0015\u0010.\u001F;
			string text = SheetAndViewCreationHelper.\u001D(vi);
			string u001F = "\\:{}[]|;<>?`~";
			for (int i = 0; i < \u001C\u000F\u0007.\u0007(u001F); i++)
			{
				char c = \u001E\u001E\u0007.\u001D(u001F, i);
				if (Enumerable.Contains<char>(text, c))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetAndViewCreationHelper.DuplicateView(Document, View, string, ViewDuplicateOption)).MethodHandle;
					}
					text = \u001C\u000B\u001D.\u0007(text, \u001E\u000E\u0004.\u000A(ref c), "");
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
			object u001F2 = text;
			char[] array = \u001C\u0007\u000E.\u001F(1);
			array[0] = '-';
			List<string> list = Enumerable.ToList<string>(\u0009\u0007\u001D.\u000A(u001F2, array));
			if (\u0015\u0007\u0019.\u000A(list) > 0)
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
				IEnumerable<string> enumerable = list;
				Func<string, bool> func;
				if ((func = SheetAndViewCreationHelper.<>c.\u000A) == null)
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
					func = (SheetAndViewCreationHelper.<>c.\u000A = new Func<string, bool>(SheetAndViewCreationHelper.<>c.\u001F.\u0018));
				}
				string text2 = Enumerable.FirstOrDefault<string>(enumerable, func);
				if (text2 != null)
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
					int num = \u0009\u0013\u0007.\u000A(list, text2);
					text = "";
					for (int j = 0; j < num; j++)
					{
						text = \u0004\u001E\u000A.\u000A(text, \u0001\u0013\u0007.\u000A(list, j));
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
					object u001F3 = suffix;
					char[] array2 = \u001C\u0007\u000E.\u001F(1);
					array2[0] = ' ';
					suffix = \u0002\u000C\u001D.\u000A(u001F3, array2);
				}
			}
			string u000A2;
			if (!\u0020\u0006\u0016.\u000A(this, doc, \u0004\u001E\u000A.\u000A(text, suffix), \u001C\u001C\u0007.\u0007(vi)))
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
				u000A2 = \u0004\u001E\u000A.\u000A(text, suffix);
			}
			else
			{
				int num2 = 1;
				while (\u0020\u0006\u0016.\u000A(this, doc, \u001E\u0020\u001D.\u000A(text, suffix, " - ", \u000C\u0013\u0007.\u000A(ref num2)), \u001C\u001C\u0007.\u0007(vi)))
				{
					num2++;
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
				u000A2 = \u001E\u0020\u001D.\u000A(text, suffix, " - ", \u000C\u0013\u0007.\u000A(ref num2));
			}
			if (\u0017\u0004\u000E.\u001F(vi) != null)
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
				if (viewDuplicateOption == 1)
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
					viewDuplicateOption = 2;
				}
			}
			if (!\u0007\u0014\u0005.\u000A(vi, viewDuplicateOption))
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
				return null;
			}
			u000A = \u000A\u0013\u0007.\u000A(vi, viewDuplicateOption);
			View view = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(doc, u000A));
			if (view != null)
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
				\u0011\u0013\u0007.\u000A(view, u000A2);
				return view;
			}
			return null;
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x000AEE38 File Offset: 0x000AD038
		public bool IsViewAlreadyUsed(Document doc, View view)
		{
			SheetAndViewCreationHelper.\u000A\u001B u000A_u001B = new SheetAndViewCreationHelper.\u000A\u001B();
			u000A_u001B.\u001F = view;
			this.\u0007();
			List<ElementId> list = \u001C\u0013\u000A.\u000A();
			IEnumerator<ViewSheet> enumerator = \u0014\u0008\u001D.\u000A(this.\u000A);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					IEnumerator<ElementId> enumerator2 = \u000B\u0013\u0007.\u000A(\u0017\u0006\u0016.\u000A(\u0015\u001D\u000E.\u001F(\u0017\u0008\u001D.\u000A(enumerator))));
					try
					{
						while (\u000A\u0017\u000A.\u000A(enumerator2))
						{
							ElementId u000A = \u0016\u0013\u0007.\u000A(enumerator2);
							View view2 = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(doc, u000A));
							if (view2 != null)
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(SheetAndViewCreationHelper.IsViewAlreadyUsed(Document, View)).MethodHandle;
								}
								if (\u001C\u001C\u0007.\u0007(view2) != 5)
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
									if (\u001C\u001C\u0007.\u0007(view2) != 123)
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
										\u0003\u0010\u0007.\u000A(list, u000A);
									}
								}
							}
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
						if (enumerator2 != null)
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
							\u001F\u0017\u000A.\u000A(enumerator2);
						}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return Enumerable.Any<ElementId>(list, new Func<ElementId, bool>(u000A_u001B.\u000A));
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x000AEF84 File Offset: 0x000AD184
		public bool IsViewNameExistInDocument(Document doc, string ViewName, ViewType Type)
		{
			SheetAndViewCreationHelper.\u0007\u001B u0007_u001B = new SheetAndViewCreationHelper.\u0007\u001B();
			u0007_u001B.\u001F = ViewName;
			u0007_u001B.\u000A = Type;
			this.\u0007();
			return Enumerable.Any<View>(this.\u001F, new Func<View, bool>(u0007_u001B.\u0007));
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x000AEFC4 File Offset: 0x000AD1C4
		internal static Element \u0004(Document \u001F, long \u000A)
		{
			return \u0011\u0017\u000A.\u0007(\u001F, \u001E\u0001\u000A.\u000A(\u000A));
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x000AEFE4 File Offset: 0x000AD1E4
		public View3D GetSuitable3DView(Document docActive)
		{
			this.\u0007();
			View u001F = \u0004\u0013\u000A.\u0007(docActive);
			View3D view3D = \u0017\u0004\u000E.\u001F(u001F);
			if (view3D != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetAndViewCreationHelper.GetSuitable3DView(Document)).MethodHandle;
				}
				if (!\u000C\u0009\u001D.\u000A(u001F))
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
					return view3D;
				}
			}
			IEnumerable<View> u001F2 = this.\u001F;
			Func<View, bool> func;
			if ((func = SheetAndViewCreationHelper.<>c.\u0007) == null)
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
				func = (SheetAndViewCreationHelper.<>c.\u0007 = new Func<View, bool>(SheetAndViewCreationHelper.<>c.\u001F.\u0005));
			}
			View3D view3D2 = \u0017\u0004\u000E.\u001F(Enumerable.FirstOrDefault<View>(u001F2, func));
			if (view3D2 != null)
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
				return view3D2;
			}
			IEnumerable<View> u001F3 = this.\u001F;
			Func<View, bool> func2;
			if ((func2 = SheetAndViewCreationHelper.<>c.\u001D) == null)
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
				func2 = (SheetAndViewCreationHelper.<>c.\u001D = new Func<View, bool>(SheetAndViewCreationHelper.<>c.\u001F.\u0016));
			}
			View3D view3D3 = \u0017\u0004\u000E.\u001F(Enumerable.FirstOrDefault<View>(u001F3, func2));
			if (view3D3 != null)
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
				return view3D3;
			}
			return null;
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x000AF0D0 File Offset: 0x000AD2D0
		public static string GetUniqueViewName(ViewType viewType, string viewName, string sheetNumber)
		{
			char[] array = \u001C\u0007\u000E.\u001F(13);
			\u001B\u000B\u001D.\u000A(array, fieldof(\u0001\u001B\u000A.\u0016).FieldHandle);
			char[] u000A = array;
			string text = \u000D\u0008\u000A.\u0004(viewName, u000A);
			string text2 = \u0004\u001E\u000A.\u000A(" - Sheet ", \u0006\u000B\u001D.\u000A(sheetNumber));
			string text3 = text;
			if (text == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SheetAndViewCreationHelper.GetUniqueViewName(ViewType, string, string)).MethodHandle;
				}
				text3 = string.Empty;
			}
			string text4 = text3;
			object u001F = text4;
			char[] array2 = \u001C\u0007\u000E.\u001F(1);
			array2[0] = '-';
			string[] array3 = \u0009\u0007\u001D.\u000A(u001F, array2);
			string[] array4 = array3;
			Predicate<string> match;
			if ((match = SheetAndViewCreationHelper.<>c.\u0004) == null)
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
				match = (SheetAndViewCreationHelper.<>c.\u0004 = new Predicate<string>(SheetAndViewCreationHelper.<>c.\u001F.\u000B));
			}
			int num = Array.FindIndex<string>(array4, match);
			if (num >= 0)
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
				Span<string> span = array3.AsSpan(0, num);
				text4 = \u0014\u0006\u001D.\u000A(\u0013\u0006\u0016.\u000A(ref span));
				object u001F2 = text2;
				char[] array5 = \u001C\u0007\u000E.\u001F(1);
				array5[0] = ' ';
				text2 = \u0002\u000C\u001D.\u000A(u001F2, array5);
			}
			string text5 = \u0004\u001E\u000A.\u000A(text4, text2);
			List<ViewData> list;
			if (\u0014\u0006\u0016.\u000A(\u000E\u0002\u0016.\u0007(Collector.\u0004), viewType, ref list))
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
				if (list != null)
				{
					IEnumerable<ViewData> enumerable = list;
					Func<ViewData, string> func;
					if ((func = SheetAndViewCreationHelper.<>c.\u0019) == null)
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
						func = (SheetAndViewCreationHelper.<>c.\u0019 = new Func<ViewData, string>(SheetAndViewCreationHelper.<>c.\u001F.\u0002));
					}
					return \u000D\u0008\u000A.\u001D(\u0020\u0006\u0019.\u000A(Enumerable.Select<ViewData, string>(enumerable, func)), text5, " - ");
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
			}
			return text5;
		}

		// Token: 0x04000AAD RID: 2733
		private IEnumerable<View> \u001F;

		// Token: 0x04000AAE RID: 2734
		private IEnumerable<ViewSheet> \u000A;

		// Token: 0x02000980 RID: 2432
		[CompilerGenerated]
		private sealed class \u000A\u001B
		{
			// Token: 0x060052FE RID: 21246 RVA: 0x001EBAC0 File Offset: 0x001E9CC0
			internal bool \u000A(ElementId \u001F)
			{
				return \u0011\u0016\u001D.\u000A(\u001F, \u0002\u001E\u000A.\u0007(this.\u001F));
			}

			// Token: 0x040024D4 RID: 9428
			public View \u001F;
		}

		// Token: 0x02000981 RID: 2433
		[CompilerGenerated]
		private sealed class \u0007\u001B
		{
			// Token: 0x06005300 RID: 21248 RVA: 0x001EBAF8 File Offset: 0x001E9CF8
			internal bool \u0007(View \u001F)
			{
				if (\u000D\u0008\u000A.\u000A(SheetAndViewCreationHelper.\u001D(\u001F), this.\u001F, true))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(SheetAndViewCreationHelper.\u0007\u001B.\u0007(View)).MethodHandle;
					}
					return \u001C\u001C\u0007.\u0007(\u001F) == this.\u000A;
				}
				return false;
			}

			// Token: 0x040024D5 RID: 9429
			public string \u001F;

			// Token: 0x040024D6 RID: 9430
			public ViewType \u000A;
		}
	}
}
