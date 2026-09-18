using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x020000A0 RID: 160
	internal class \u0016\u0020\u0018
	{
		// Token: 0x0600096F RID: 2415 RVA: 0x0003A340 File Offset: 0x00038540
		public \u0016\u0020\u0018(UIDocument \u000C)
		{
			this.\u0018 = \u000C;
			IEnumerator<UIView> enumerator = \u0010\u0005\u0003.\u0018(\u0013\u000C\u0014.\u0018(\u000C));
			try
			{
				while (\u001F\u001E\u0018.\u0018(enumerator))
				{
					UIView u000C = \u0007\u0005\u0003.\u0018(enumerator);
					\u0014\u0008\u0014.\u0018(this.\u0014, \u0019\u0005\u0003.\u0018(u000C));
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0020\u0018..ctor(UIDocument)).MethodHandle;
				}
			}
			finally
			{
				if (enumerator != null)
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
					\u0020\u001E\u0018.\u0018(enumerator);
				}
			}
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x0003A3D8 File Offset: 0x000385D8
		public void \u0016(View \u000C)
		{
			this.\u000F();
			\u001F\u0005\u0018.\u0018(this.\u0018, \u000C);
			this.\u0003++;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x0003A408 File Offset: 0x00038608
		public void \u000F()
		{
			if (this.\u0003 > 0)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0020\u0018.\u000F()).MethodHandle;
				}
				if (this.\u0003 % 10 == 0)
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
					this.\u0012();
				}
			}
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0003A44C File Offset: 0x0003864C
		public void \u0012()
		{
			IList<UIView> u000C = \u0013\u000C\u0014.\u0018(this.\u0018);
			if (\u0008\u0005\u0003.\u0018(u000C) > 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u0020\u0018.\u0012()).MethodHandle;
				}
				IEnumerator<UIView> enumerator = \u0010\u0005\u0003.\u0018(u000C);
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						UIView u000C2 = \u0007\u0005\u0003.\u0018(enumerator);
						if (!\u0003\u0008\u0014.\u0018(this.\u0014, \u0019\u0005\u0003.\u0018(u000C2)))
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
							\u0006\u0005\u0003.\u0018(u000C2);
						}
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
			}
		}

		// Token: 0x0400046A RID: 1130
		public static int \u000C;

		// Token: 0x0400046B RID: 1131
		private UIDocument \u0018;

		// Token: 0x0400046C RID: 1132
		private List<ElementId> \u0014 = new List<ElementId>();

		// Token: 0x0400046D RID: 1133
		private int \u0003;
	}
}
