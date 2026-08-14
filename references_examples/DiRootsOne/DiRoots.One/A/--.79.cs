using System;
using System.Collections.Generic;
using System.Threading;
using Autodesk.Revit.DB;

namespace A
{
	// Token: 0x02000130 RID: 304
	internal static class \u0018\u0016
	{
		// Token: 0x06000B87 RID: 2951 RVA: 0x00048A8C File Offset: 0x00046C8C
		public static void \u001F(Document \u001F, View \u000A, \u0020\u0019 \u0007, bool \u001D, CancellationTokenSource \u0004)
		{
			int num = 1;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			bool flag = true;
			List<\u001B\u0005>.Enumerator enumerator = \u0011\u000A\u0004.\u000A(\u0012\u0007\u0004.\u000A(\u0007));
			try
			{
				while (\u0003\u000A\u0004.\u000A(ref enumerator))
				{
					\u001B\u0005 u001F = \u001B\u000A\u0004.\u000A(ref enumerator);
					if (\u0004\u0013\u001D.\u0007(\u0004))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0016.\u001F(Document, View, \u0020\u0019, bool, CancellationTokenSource)).MethodHandle;
						}
						return;
					}
					if (num % 100 == 0)
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
						\u0008\u000B\u0004.\u000A();
					}
					if (flag && \u001D)
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
						num2 += \u0016\u0014\u001D.\u000A(u001F) / 2.0;
						num3 -= \u0005\u0014\u001D.\u000A(u001F) / 2.0;
						flag = false;
					}
					Element u001F2 = \u0018\u0016.\u0007(\u001F, \u000A, \u0007\u0019\u0004.\u0007(u001F), \u001B\u001F\u0007.\u000A(num2, num3, 0.0), \u000E\u0019\u0004.\u000A(u001F));
					double num5 = \u0005\u0014\u001D.\u000A(u001F);
					double num6 = \u0016\u0014\u001D.\u000A(u001F);
					\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u001F2, -1007751L), num5);
					\u0002\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(u001F2, -1007750L), num6);
					\u0018\u0016.\u000A(u001F2, -1007768L, 1.0);
					\u0018\u0016.\u000A(u001F2, -1007767L, 1.0);
					double num7 = num6;
					num2 += num7;
					double num8;
					if (num5 <= num4)
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
						num8 = num4;
					}
					else
					{
						num8 = num5;
					}
					num4 = num8;
					if (num % 250 == 0)
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
						num3 += num4;
						num4 = 0.0;
						num2 = 0.0;
					}
					num++;
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06000B88 RID: 2952 RVA: 0x00048C84 File Offset: 0x00046E84
		private static void \u000A(Element \u001F, BuiltInParameter \u000A, double \u0007)
		{
			Parameter parameter = \u0016\u0018\u0007.\u0007(\u001F, \u000A);
			if (parameter != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0016.\u000A(Element, BuiltInParameter, double)).MethodHandle;
				}
				if (!\u0010\u0014\u0007.\u000A(parameter))
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
					\u0002\u0018\u0007.\u000A(parameter, \u0007);
				}
			}
		}

		// Token: 0x06000B89 RID: 2953 RVA: 0x00048CD0 File Offset: 0x00046ED0
		public static Element \u0007(Document \u001F, View \u000A, string \u0007, XYZ \u001D, double \u0004)
		{
			if (\u0004 <= 0.0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0018\u0016.\u0007(Document, View, string, XYZ, double)).MethodHandle;
				}
				\u0004 = 72.0;
			}
			ImageTypeOptions imageTypeOptions = \u0019\u0019\u0004.\u000A(\u0007, false, 1);
			\u0008\u0013\u0004.\u000A(imageTypeOptions, \u0004);
			Element u001F = \u0004\u0019\u0004.\u000A(\u001F, imageTypeOptions);
			ImagePlacementOptions imagePlacementOptions = \u000E\u0013\u0004.\u000A();
			\u0010\u0013\u0004.\u000A(imagePlacementOptions, \u001D);
			ImageInstance imageInstance = \u000D\u0013\u0004.\u000A(\u001F, \u000A, \u0002\u001E\u000A.\u0007(u001F), imagePlacementOptions);
			\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(imageInstance, -1007752L), 0);
			\u0006\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(imageInstance, -1007705L), 0);
			\u000A\u0018.\u0005(\u0007);
			return imageInstance;
		}
	}
}
