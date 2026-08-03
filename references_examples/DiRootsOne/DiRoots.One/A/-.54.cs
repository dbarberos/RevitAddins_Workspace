using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.TGDatabaseLayer.StyleMapping;

namespace A
{
	// Token: 0x020000F3 RID: 243
	internal static class \u0009\u0018
	{
		// Token: 0x060008DD RID: 2269 RVA: 0x0003C104 File Offset: 0x0003A304
		internal static void \u000A()
		{
			\u000F\u0006\u0004.\u000A(\u0009\u0018.\u001F);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0003C11C File Offset: 0x0003A31C
		internal unsafe static ElementId \u0007(ExcelTextStyleInfo \u001F, double \u000A, StyleMappingDto \u0007, Document \u001D, List<\u0015\u0005> \u0004, out bool \u0019)
		{
			\u0019 = true;
			if (\u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0018.\u0007(ExcelTextStyleInfo, double, StyleMappingDto, Document, List<\u0015\u0005>, bool*)).MethodHandle;
				}
				return \u0008\u0018.\u0007(\u000A, false, false, false, "Arial", \u001D);
			}
			int u000A = \u001B\u0013\u000A.\u000A(\u001F);
			ValueTuple<ElementId, bool> valueTuple;
			if (\u0008\u0006\u0004.\u000A(\u0009\u0018.\u001F, u000A, ref valueTuple))
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
				\u0019 = valueTuple.Item2;
				return valueTuple.Item1;
			}
			TextStyleMapping textStyleMapping;
			if (\u0007 == null)
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
				textStyleMapping = \u0006\u0019\u000E.\u001F;
			}
			else
			{
				textStyleMapping = \u0007.\u0004(\u001F);
			}
			TextStyleMapping textStyleMapping2 = textStyleMapping;
			string u000A2;
			string u;
			if (textStyleMapping2 != null)
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
				u000A2 = \u000E\u0006\u0004.\u0007(textStyleMapping2);
				u = \u000D\u0006\u0004.\u000A(textStyleMapping2);
				\u0019 = false;
			}
			else
			{
				u000A2 = \u0002\u0005.\u001B(\u001F);
				u = \u000F\u0015\u0010.\u001F;
			}
			bool flag = false;
			TextNoteType textNoteType = \u0009\u0018.\u0004(\u001D, u000A2, u);
			if (textNoteType == null)
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
				textNoteType = \u0009\u0018.\u0019(\u001D, u000A2, \u001F);
				flag = true;
			}
			if (textNoteType != null)
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
				if (\u0004 != null)
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
					\u0002\u0002\u0004.\u000A(\u0004, new \u0015\u0005(\u0010\u0006\u0004.\u000A(), u000A2, flag));
				}
				if (textStyleMapping2 != null)
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
					if (!flag)
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
						if (!\u001A\u0006\u0007.\u000A(\u000D\u0006\u0004.\u000A(textStyleMapping2)))
						{
							goto IL_15B;
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
					\u001C\u0006\u0004.\u000A(textStyleMapping2, \u0012\u0010\u0007.\u000A(textNoteType));
					IL_15B:
					\u0003\u0006\u0004.\u000A(textStyleMapping2, false);
				}
				\u0012\u0006\u0004.\u000A(\u0009\u0018.\u001F, u000A, new ValueTuple<ElementId, bool>(\u0002\u001E\u000A.\u0007(textNoteType), \u0019));
				return \u0002\u001E\u000A.\u0007(textNoteType);
			}
			return \u0008\u0018.\u0007(\u000A, false, false, false, "Arial", \u001D);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x0003C2C4 File Offset: 0x0003A4C4
		internal static double \u001D(ExcelTextStyleInfo \u001F, StyleMappingDto \u000A, Document \u0007)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0018.\u001D(ExcelTextStyleInfo, StyleMappingDto, Document)).MethodHandle;
				}
				if (\u000A != null)
				{
					TextStyleMapping textStyleMapping = \u000A.\u0004(\u001F);
					double num;
					if (textStyleMapping != null)
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
						if (\u0011\u0006\u0004.\u0007(textStyleMapping) > 0.0)
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
							num = \u0011\u0006\u0004.\u0007(textStyleMapping);
							goto IL_7C;
						}
					}
					num = \u0002\u0018.\u0005(\u001B\u0006\u0004.\u0007(\u001F));
					IL_7C:
					return num * 12.0 * 96.0;
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
			return 0.0;
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x0003C364 File Offset: 0x0003A564
		private static TextNoteType \u0004(Document \u001F, string \u000A, string \u0007)
		{
			IEnumerable<TextNoteType> elements = \u001F.GetElements<TextNoteType>();
			IEnumerator<TextNoteType> enumerator;
			if (!\u001A\u0006\u0007.\u000A(\u0007))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0018.\u0004(Document, string, string)).MethodHandle;
				}
				enumerator = \u001B\u0018\u0004.\u000A(elements);
				try
				{
					while (\u000A\u0017\u000A.\u000A(enumerator))
					{
						TextNoteType textNoteType = \u0008\u0018\u0004.\u000A(enumerator);
						if (\u000D\u001F\u001D.\u000A(\u0012\u0010\u0007.\u000A(textNoteType), \u0007))
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
							return textNoteType;
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
							switch (7)
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
			enumerator = \u001B\u0018\u0004.\u000A(elements);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					TextNoteType textNoteType2 = \u0008\u0018\u0004.\u000A(enumerator);
					if (\u000D\u0008\u000A.\u000A(\u0005\u001E\u000A.\u000A(textNoteType2), \u000A, true))
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
						return textNoteType2;
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
			return null;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0003C47C File Offset: 0x0003A67C
		private static TextNoteType \u0019(Document \u001F, string \u000A, ExcelTextStyleInfo \u0007)
		{
			double u000A = \u0002\u0018.\u0016(\u0002\u0018.\u0005(\u001B\u0006\u0004.\u0007(\u0007)));
			IEnumerator<TextNoteType> enumerator = \u001B\u0018\u0004.\u000A(\u001F.GetElements<TextNoteType>());
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					TextNoteType u001F = \u0008\u0018\u0004.\u000A(enumerator);
					try
					{
						TextNoteType textNoteType = \u001F\u0019\u000E.\u001F(\u001E\u0009\u001D.\u000A(u001F, \u000A));
						if (textNoteType != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0009\u0018.\u0019(Document, string, ExcelTextStyleInfo)).MethodHandle;
							}
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1150213L), 0);
							\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006327L), 1.0);
							\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006501L), 0.00666666666667);
							\u0016\u0018\u001D.\u0007(\u0016\u0018\u0007.\u0007(textNoteType, -1006300L), \u0016\u001D\u0004.\u0007(\u0007));
							\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006301L), u000A);
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006314L), 1);
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006311L), (\u0018\u001D\u0004.\u0007(\u0007) > false) ? 1 : 0);
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006312L), (\u0019\u001D\u0004.\u0007(\u0007) > false) ? 1 : 0);
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006313L), (\u001D\u001D\u0004.\u0007(\u0007) > false) ? 1 : 0);
							int u000A2 = \u0005\u001D\u0004.\u0007(\u0007).\u0007();
							\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(textNoteType, -1006304L), u000A2);
							return textNoteType;
						}
					}
					catch
					{
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
			}
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return null;
		}

		// Token: 0x04000362 RID: 866
		private static readonly Dictionary<int, ValueTuple<ElementId, bool>> \u001F = \u0006\u0006\u0004.\u000A();
	}
}
