using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

namespace A
{
	// Token: 0x0200002B RID: 43
	internal class \u0004\u000A
	{
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600017A RID: 378 RVA: 0x00008300 File Offset: 0x00006500
		// (remove) Token: 0x0600017B RID: 379 RVA: 0x00008350 File Offset: 0x00006550
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
					switch (4)
					{
					case 0:
						continue;
					}
					break;
				}
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.add_\u001F(EventHandler)).MethodHandle;
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.remove_\u001F(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600017C RID: 380 RVA: 0x000083A0 File Offset: 0x000065A0
		// (remove) Token: 0x0600017D RID: 381 RVA: 0x000083F0 File Offset: 0x000065F0
		public event EventHandler \u000A
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.\u000A;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.\u000A, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.add_\u000A(EventHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.\u000A;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = \u0017\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.\u000A, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.remove_\u000A(EventHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600017E RID: 382 RVA: 0x00008440 File Offset: 0x00006640
		// (set) Token: 0x0600017F RID: 383 RVA: 0x00008454 File Offset: 0x00006654
		public List<ElementId> SelectedElementIds { get; set; }

		// Token: 0x06000180 RID: 384 RVA: 0x00008468 File Offset: 0x00006668
		public void \u001D(object \u001F, IdlingEventArgs \u000A)
		{
			try
			{
				if (\u0020\u0013\u000A.\u000A(\u0017\u0013\u000A.\u001D(\u0010\u0014\u000A.\u000A())) == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.\u001D(object, IdlingEventArgs)).MethodHandle;
					}
				}
				else
				{
					UIDocument uidocument = \u000D\u0014\u000A.\u0007(\u0010\u0014\u000A.\u000A());
					IEnumerable<ElementId> enumerable;
					if (uidocument == null)
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
						enumerable = \u0014\u0015\u0010.\u001F;
					}
					else
					{
						IEnumerable<ElementId> enumerable2 = \u001C\u0014\u000A.\u000A(\u0010\u001E\u000A.\u001D(uidocument));
						Func<ElementId, bool> func;
						if ((func = \u0004\u000A.<>c.\u000A) == null)
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
							func = (\u0004\u000A.<>c.\u000A = new Func<ElementId, bool>(\u0004\u000A.<>c.\u001F.\u0007));
						}
						enumerable = Enumerable.Where<ElementId>(enumerable2, func);
					}
					IEnumerable<ElementId> enumerable3 = enumerable;
					if (enumerable3 != null)
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
						if (Enumerable.Any<ElementId>(enumerable3))
						{
							this.\u0019();
							goto IL_BE;
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
					}
					this.\u0018();
					IL_BE:;
				}
			}
			catch (Exception)
			{
				\u0002\u001A\u000A.\u0007(\u0011\u001A\u000A.\u000A());
			}
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00008554 File Offset: 0x00006754
		internal void \u0004()
		{
			if (this.\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.\u0004()).MethodHandle;
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
			if (this.\u000A != null)
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
				Delegate[] array = \u001C\u001E\u000A.\u000A(this.\u000A);
				for (int i = 0; i < (int)\u000B\u0015\u0010.\u001F(array); i++)
				{
					Delegate u001F2 = array[i];
					this.\u001F -= \u0017\u0015\u0010.\u001F(u001F2);
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

		// Token: 0x06000182 RID: 386 RVA: 0x0000860C File Offset: 0x0000680C
		private void \u0019()
		{
			EventHandler u001F = this.\u001F;
			if (u001F == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.\u0019()).MethodHandle;
				}
				return;
			}
			\u001E\u001A\u000A.\u000A(u001F, this, \u0020\u001A\u000A.\u000A());
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00008644 File Offset: 0x00006844
		private void \u0018()
		{
			EventHandler u000A = this.\u000A;
			if (u000A == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0004\u000A.\u0018()).MethodHandle;
				}
				return;
			}
			\u001E\u001A\u000A.\u000A(u000A, this, \u0020\u001A\u000A.\u000A());
		}

		// Token: 0x0400009F RID: 159
		[CompilerGenerated]
		private List<ElementId> \u0007;
	}
}
