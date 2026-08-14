using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x02000139 RID: 313
	internal static class \u000F\u0017\u0018
	{
		// Token: 0x06000FA3 RID: 4003 RVA: 0x00058840 File Offset: 0x00056A40
		internal static string \u000C(this UIDocument \u000C)
		{
			return \u0017\u0005\u0018.\u0014(\u000C).\u000C();
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x0005885C File Offset: 0x00056A5C
		internal static string \u000C(this Document \u000C)
		{
			string text = string.Empty;
			try
			{
				text = \u0004\u0006\u0014.\u0018(\u0008\u0002\u0018.\u0018(\u000C));
				if (\u001F\u001A\u0018.\u0018(text))
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(Document.\u000C()).MethodHandle;
					}
					text = \u0004\u0006\u0014.\u0018(\u0006\u0004\u0018.\u0018(\u000C));
				}
			}
			catch (Exception)
			{
			}
			char[] array = \u0008\u001A\u0018.\u0018();
			for (int i = 0; i < (int)\u0018\u000B\u000F.\u000C(array); i++)
			{
				char c = array[i];
				text = \u0010\u000B\u0014.\u0018(text, \u0006\u000B\u0014.\u0018(ref c), "");
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
			return text;
		}
	}
}
