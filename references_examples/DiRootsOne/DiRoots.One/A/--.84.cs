using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.TGDatabaseLayer;

namespace A
{
	// Token: 0x02000136 RID: 310
	internal static class \u0003\u0016
	{
		// Token: 0x06000B9E RID: 2974 RVA: 0x00049BD4 File Offset: 0x00047DD4
		internal static bool \u001F(Document \u001F, SelectedExcel \u000A)
		{
			\u0003\u0016.\u0012\u0016 u0012_u = new \u0003\u0016.\u0012\u0016();
			u0012_u.\u000A = \u000A;
			u0012_u.\u001F = \u000D\u001B\u001D.\u0007(\u0006\u0020\u001D.\u0007(u0012_u.\u000A));
			List<View> u001F = Enumerable.ToList<View>(Enumerable.Where<View>(\u0015\u0018.\u001D(\u001F, u0012_u.\u001F), new Func<View, bool>(u0012_u.\u0007)));
			if (\u0001\u0016\u0004.\u0007(u0012_u.\u000A) == UpdateStates.ToAdd)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0016.\u001F(Document, SelectedExcel)).MethodHandle;
				}
				if (\u001B\u0013\u0007.\u000A(u001F) > 0)
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
					return true;
				}
			}
			else
			{
				if (\u0001\u0016\u0004.\u0007(u0012_u.\u000A) != UpdateStates.Modified)
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
					if (\u0001\u0016\u0004.\u0007(u0012_u.\u000A) != UpdateStates.Recreate)
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
						if (\u0001\u0016\u0004.\u0007(u0012_u.\u000A) != UpdateStates.Updated)
						{
							return false;
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
				}
				if (\u001B\u0013\u0007.\u000A(u001F) > 0)
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
					if (\u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u0015\u001A\u0004.\u000A(u001F, 0))) != \u0009\u0005\u0004.\u000A(u0012_u.\u000A))
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
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x02000816 RID: 2070
		[CompilerGenerated]
		private sealed class \u0012\u0016
		{
			// Token: 0x06004DAC RID: 19884 RVA: 0x001DEBB8 File Offset: 0x001DCDB8
			internal bool \u0007(View \u001F)
			{
				if (\u001C\u001C\u0007.\u0007(\u001F) == this.\u001F)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0003\u0016.\u0012\u0016.\u0007(View)).MethodHandle;
					}
					return \u0008\u0013\u000A.\u000A(\u0003\u000B\u001D.\u0007(\u0005\u001E\u000A.\u000A(\u001F)), \u0014\u0005\u0004.\u0007(this.\u000A));
				}
				return false;
			}

			// Token: 0x04002065 RID: 8293
			public ViewType \u001F;

			// Token: 0x04002066 RID: 8294
			public SelectedExcel \u000A;
		}
	}
}
