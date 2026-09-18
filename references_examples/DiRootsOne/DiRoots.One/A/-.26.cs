using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Events;

namespace A
{
	// Token: 0x0200002C RID: 44
	internal class \u0019\u000A
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x06000185 RID: 389 RVA: 0x00008690 File Offset: 0x00006890
		// (remove) Token: 0x06000186 RID: 390 RVA: 0x000086E0 File Offset: 0x000068E0
		public event EventHandler \u001F
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.\u001F;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.\u001F, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u000A.add_\u001F(EventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.\u001F;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.\u001F, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u000A.remove_\u001F(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000187 RID: 391 RVA: 0x00008730 File Offset: 0x00006930
		// (set) Token: 0x06000188 RID: 392 RVA: 0x00008744 File Offset: 0x00006944
		public List<ElementId> SelectedElementIds { get; set; }

		// Token: 0x06000189 RID: 393 RVA: 0x00008758 File Offset: 0x00006958
		public void \u0007(object \u001F, ViewActivatedEventArgs \u000A)
		{
			this.\u0004();
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000876C File Offset: 0x0000696C
		internal void \u001D()
		{
			if (this.\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u000A.\u001D()).MethodHandle;
				}
				Delegate[] array = \u001C\u001E\u000A.\u000A(this.\u001F);
				for (int i = 0; i < (int)\u000B\u0015\u0010.\u001F(array); i++)
				{
					Delegate u001F = array[i];
					this.\u001F -= \u0017\u0015\u0010.\u001F(u001F);
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
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000087D4 File Offset: 0x000069D4
		private void \u0004()
		{
			EventHandler u001F = this.\u001F;
			if (u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0019\u000A.\u0004()).MethodHandle;
				}
				return;
			}
			\u001E\u001A\u000A.\u000A(u001F, this, \u0020\u001A\u000A.\u000A());
		}

		// Token: 0x040000A1 RID: 161
		[CompilerGenerated]
		private List<ElementId> \u000A;
	}
}
