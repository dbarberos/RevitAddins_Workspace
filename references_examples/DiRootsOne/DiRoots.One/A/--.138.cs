using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000272 RID: 626
	internal class \u001E\u0010 : ExternalEventInfo
	{
		// Token: 0x14000023 RID: 35
		// (add) Token: 0x060018F9 RID: 6393 RVA: 0x000A1FA4 File Offset: 0x000A01A4
		// (remove) Token: 0x060018FA RID: 6394 RVA: 0x000A1FF0 File Offset: 0x000A01F0
		public event \u001E\u0010.\u0011\u0010 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u001E\u0010.\u0011\u0010 u0011_u = this.\u001F;
				\u001E\u0010.\u0011\u0010 u0011_u2;
				do
				{
					u0011_u2 = u0011_u;
					\u001E\u0010.\u0011\u0010 value2 = (\u001E\u0010.\u0011\u0010)\u000F\u001E\u000A.\u000A(u0011_u2, value);
					u0011_u = Interlocked.CompareExchange<\u001E\u0010.\u0011\u0010>(ref this.\u001F, value2, u0011_u2);
				}
				while (u0011_u != u0011_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0010.add_\u001F(\u001E\u0010.\u0011\u0010)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u001E\u0010.\u0011\u0010 u0011_u = this.\u001F;
				\u001E\u0010.\u0011\u0010 u0011_u2;
				do
				{
					u0011_u2 = u0011_u;
					\u001E\u0010.\u0011\u0010 value2 = (\u001E\u0010.\u0011\u0010)\u0012\u001E\u000A.\u000A(u0011_u2, value);
					u0011_u = Interlocked.CompareExchange<\u001E\u0010.\u0011\u0010>(ref this.\u001F, value2, u0011_u2);
				}
				while (u0011_u != u0011_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0010.remove_\u001F(\u001E\u0010.\u0011\u0010)).MethodHandle;
				}
			}
		}

		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x060018FB RID: 6395 RVA: 0x000A203C File Offset: 0x000A023C
		// (set) Token: 0x060018FC RID: 6396 RVA: 0x000A2050 File Offset: 0x000A0250
		public string FilePath { get; set; }

		// Token: 0x060018FD RID: 6397 RVA: 0x000A2064 File Offset: 0x000A0264
		public override void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DropDownValuesEvent.cs", "Execute");
			try
			{
				DropDownparamInfo.\u0005(true);
				\u001E\u0010.\u0011\u0010 u001F = this.\u001F;
				if (u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001E\u0010.Execute(UIApplication)).MethodHandle;
					}
				}
				else
				{
					object[] array = \u0004\u0015\u0010.\u001F(1);
					array[0] = \u0005\u000C\u0005.\u000A(this);
					\u0010\u001F\u0018.\u000A(u001F, array);
				}
			}
			catch (Exception u000A)
			{
				\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DropDownValuesEvent.cs", "Execute");
				\u000D\u0014\u0004.\u000A(\u001B\u0016\u0018.\u000A(), u000A, true);
			}
			\u000F\u0012\u0007.\u000A(\u0010\u0011\u000A.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Core\\ExternalEvents\\DropDownValuesEvent.cs", "Execute");
		}

		// Token: 0x040009ED RID: 2541
		[CompilerGenerated]
		private string \u001F\u000A;

		// Token: 0x0200094C RID: 2380
		// (Invoke) Token: 0x0600524D RID: 21069
		public delegate void \u0011\u0010(string filePath);
	}
}
