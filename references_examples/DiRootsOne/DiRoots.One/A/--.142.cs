using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;

namespace A
{
	// Token: 0x02000278 RID: 632
	internal class \u0001\u0010 : ExternalEventInfo
	{
		// Token: 0x06001918 RID: 6424 RVA: 0x000A2C00 File Offset: 0x000A0E00
		public \u0001\u0010()
		{
			\u000D\u0001\u000A.\u0007(this, "SheetLink_DisableTemporaryIsolate");
		}

		// Token: 0x170006EE RID: 1774
		// (get) Token: 0x06001919 RID: 6425 RVA: 0x000A2C20 File Offset: 0x000A0E20
		// (set) Token: 0x0600191A RID: 6426 RVA: 0x000A2C34 File Offset: 0x000A0E34
		public List<ElementId> ElementToIsolate { get; set; }

		// Token: 0x14000025 RID: 37
		// (add) Token: 0x0600191B RID: 6427 RVA: 0x000A2C48 File Offset: 0x000A0E48
		// (remove) Token: 0x0600191C RID: 6428 RVA: 0x000A2C94 File Offset: 0x000A0E94
		public event \u0001\u0010.\u0015\u0010 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u0001\u0010.\u0015\u0010 u0015_u = this.\u001F;
				\u0001\u0010.\u0015\u0010 u0015_u2;
				do
				{
					u0015_u2 = u0015_u;
					\u0001\u0010.\u0015\u0010 value2 = (\u0001\u0010.\u0015\u0010)\u000F\u001E\u000A.\u000A(u0015_u2, value);
					u0015_u = Interlocked.CompareExchange<\u0001\u0010.\u0015\u0010>(ref this.\u001F, value2, u0015_u2);
				}
				while (u0015_u != u0015_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0010.add_\u001F(\u0001\u0010.\u0015\u0010)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u0001\u0010.\u0015\u0010 u0015_u = this.\u001F;
				\u0001\u0010.\u0015\u0010 u0015_u2;
				do
				{
					u0015_u2 = u0015_u;
					\u0001\u0010.\u0015\u0010 value2 = (\u0001\u0010.\u0015\u0010)\u0012\u001E\u000A.\u000A(u0015_u2, value);
					u0015_u = Interlocked.CompareExchange<\u0001\u0010.\u0015\u0010>(ref this.\u001F, value2, u0015_u2);
				}
				while (u0015_u != u0015_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0010.remove_\u001F(\u0001\u0010.\u0015\u0010)).MethodHandle;
				}
			}
		}

		// Token: 0x0600191D RID: 6429 RVA: 0x000A2CE0 File Offset: 0x000A0EE0
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ViewIsolateDisableHandler.cs", "Execute");
			UIDocument u001F = \u0020\u0013\u000A.\u000A(app);
			Document u001F2 = \u0011\u0020\u000A.\u0007(u001F);
			View u001F3 = \u000F\u000B\u0004.\u0007(u001F);
			if (\u001D\u0013\u000A.\u000A(u001F3))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0001\u0010.Execute(UIApplication)).MethodHandle;
				}
				Transaction transaction = \u0013\u0001\u000A.\u000A(u001F2);
				try
				{
					\u0017\u0001\u000A.\u000A(transaction, \u0014\u0001\u000A.\u000A(this));
					\u000D\u0013\u000A.\u000A(u001F3, 2);
					\u001B\u0001\u000A.\u000A(transaction);
				}
				finally
				{
					if (transaction != null)
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
						\u001F\u0017\u000A.\u000A(transaction);
					}
				}
				\u0001\u0010.\u0015\u0010 u001F4 = this.\u001F;
				if (u001F4 == null)
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
				}
				else
				{
					\u001B\u000C\u0005.\u000A(u001F4);
				}
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\ViewIsolateDisableHandler.cs", "Execute");
		}

		// Token: 0x040009F7 RID: 2551
		[CompilerGenerated]
		private List<ElementId> \u0016\u000A;

		// Token: 0x0200094F RID: 2383
		// (Invoke) Token: 0x06005255 RID: 21077
		public delegate void \u0015\u0010();
	}
}
