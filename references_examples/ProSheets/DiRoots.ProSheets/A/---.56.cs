using System;
using System.Collections;
using System.Collections.Generic;
using ProSheets.Models;

namespace A
{
	// Token: 0x02000135 RID: 309
	internal class \u0016\u0017\u0018 : IComparer, IComparer<SheetInfo>
	{
		// Token: 0x06000F7B RID: 3963 RVA: 0x000580C4 File Offset: 0x000562C4
		public \u0016\u0017\u0018(bool \u000C)
		{
			this.\u000C = \u000C;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x000580E0 File Offset: 0x000562E0
		public int Compare(object x, object y)
		{
			string text = \u001E\u000E\u0018.\u0014(\u0017\u0019\u000F.\u000C(x));
			string text2;
			if ((text2 = text) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0017\u0018.Compare(object, object)).MethodHandle;
				}
				text2 = "";
			}
			text = text2;
			string text3 = \u001E\u000E\u0018.\u0014(\u0017\u0019\u000F.\u000C(y));
			string text4;
			if ((text4 = text3) == null)
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
				text4 = "";
			}
			text3 = text4;
			int num;
			if (!this.\u000C)
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
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u0003\u0017\u0018.\u000C(text, text3);
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x00058160 File Offset: 0x00056360
		public int Compare(SheetInfo x, SheetInfo y)
		{
			string text = \u001E\u000E\u0018.\u0014(x);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0017\u0018.Compare(SheetInfo, SheetInfo)).MethodHandle;
				}
				text2 = "";
			}
			text = text2;
			string text3 = \u001E\u000E\u0018.\u0014(y);
			string text4;
			if ((text4 = text3) == null)
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
				text4 = "";
			}
			text3 = text4;
			int num;
			if (!this.\u000C)
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
				num = -1;
			}
			else
			{
				num = 1;
			}
			return num * \u0003\u0017\u0018.\u000C(text, text3);
		}

		// Token: 0x040006F0 RID: 1776
		private readonly bool \u000C;
	}
}
