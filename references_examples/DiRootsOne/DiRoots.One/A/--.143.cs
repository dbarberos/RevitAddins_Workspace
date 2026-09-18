using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;

namespace A
{
	// Token: 0x02000279 RID: 633
	internal class \u001F\u000E : ExternalEventInfo
	{
		// Token: 0x0600191E RID: 6430 RVA: 0x000A2DBC File Offset: 0x000A0FBC
		public \u001F\u000E()
		{
			\u000D\u0001\u000A.\u0007(this, "SheetLink_IsolateView");
		}

		// Token: 0x14000026 RID: 38
		// (add) Token: 0x0600191F RID: 6431 RVA: 0x000A2DDC File Offset: 0x000A0FDC
		// (remove) Token: 0x06001920 RID: 6432 RVA: 0x000A2E28 File Offset: 0x000A1028
		public event \u001F\u000E.\u0009\u0010 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u001F\u000E.\u0009\u0010 u0009_u = this.\u001F;
				\u001F\u000E.\u0009\u0010 u0009_u2;
				do
				{
					u0009_u2 = u0009_u;
					\u001F\u000E.\u0009\u0010 value2 = (\u001F\u000E.\u0009\u0010)\u000F\u001E\u000A.\u000A(u0009_u2, value);
					u0009_u = Interlocked.CompareExchange<\u001F\u000E.\u0009\u0010>(ref this.\u001F, value2, u0009_u2);
				}
				while (u0009_u != u0009_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000E.add_\u001F(\u001F\u000E.\u0009\u0010)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u001F\u000E.\u0009\u0010 u0009_u = this.\u001F;
				\u001F\u000E.\u0009\u0010 u0009_u2;
				do
				{
					u0009_u2 = u0009_u;
					\u001F\u000E.\u0009\u0010 value2 = (\u001F\u000E.\u0009\u0010)\u0012\u001E\u000A.\u000A(u0009_u2, value);
					u0009_u = Interlocked.CompareExchange<\u001F\u000E.\u0009\u0010>(ref this.\u001F, value2, u0009_u2);
				}
				while (u0009_u != u0009_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000E.remove_\u001F(\u001F\u000E.\u0009\u0010)).MethodHandle;
				}
			}
		}

		// Token: 0x170006EF RID: 1775
		// (get) Token: 0x06001921 RID: 6433 RVA: 0x000A2E74 File Offset: 0x000A1074
		// (set) Token: 0x06001922 RID: 6434 RVA: 0x000A2E88 File Offset: 0x000A1088
		public List<ElementId> Elements { get; set; }

		// Token: 0x06001923 RID: 6435 RVA: 0x000A2E9C File Offset: 0x000A109C
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ViewIsolateHandler.cs", "Execute");
			UIDocument u001F = \u0020\u0013\u000A.\u000A(app);
			Document u001F2 = \u0011\u0020\u000A.\u0007(u001F);
			View u001F3 = \u000F\u000B\u0004.\u0007(u001F);
			Transaction transaction = \u0013\u0001\u000A.\u000A(u001F2);
			try
			{
				\u0017\u0001\u000A.\u000A(transaction, \u0014\u0001\u000A.\u000A(this));
				\u0020\u000C\u0005.\u000A(u001F3, \u0017\u000C\u0005.\u000A(this));
				\u001E\u000C\u0005.\u000A(u001F);
				\u001B\u0001\u000A.\u000A(transaction);
			}
			finally
			{
				if (transaction != null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001F\u000E.Execute(UIApplication)).MethodHandle;
					}
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
			\u001F\u000E.\u0009\u0010 u001F4 = this.\u001F;
			if (u001F4 == null)
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
			}
			else
			{
				\u0011\u000C\u0005.\u000A(u001F4);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ViewIsolateHandler.cs", "Execute");
		}

		// Token: 0x040009FA RID: 2554
		[CompilerGenerated]
		private List<ElementId> \u000B\u000A;

		// Token: 0x02000950 RID: 2384
		// (Invoke) Token: 0x06005259 RID: 21081
		public delegate void \u0009\u0010();
	}
}
