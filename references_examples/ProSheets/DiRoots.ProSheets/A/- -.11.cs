using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x020000C9 RID: 201
	internal class \u0005\u0020\u0018 : IExternalEventHandler
	{
		// Token: 0x1400001B RID: 27
		// (add) Token: 0x06000B19 RID: 2841 RVA: 0x00041AB0 File Offset: 0x0003FCB0
		// (remove) Token: 0x06000B1A RID: 2842 RVA: 0x00041B00 File Offset: 0x0003FD00
		public event EventHandler<Exception> \u0014
		{
			[CompilerGenerated]
			add
			{
				EventHandler<Exception> eventHandler = this.\u0014;
				EventHandler<Exception> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<Exception> value2 = \u0009\u0010\u000F.\u000C(\u001C\u0019\u0018.\u0018(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler<Exception>>(ref this.\u0014, value2, eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0020\u0018.add_\u0014(EventHandler<Exception>)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				EventHandler<Exception> eventHandler = this.\u0014;
				EventHandler<Exception> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<Exception> value2 = \u0009\u0010\u000F.\u000C(\u0013\u0019\u0018.\u0018(eventHandler2, value));
					eventHandler = Interlocked.CompareExchange<EventHandler<Exception>>(ref this.\u0014, value2, eventHandler2);
				}
				while (eventHandler != eventHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0020\u0018.remove_\u0014(EventHandler<Exception>)).MethodHandle;
				}
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06000B1B RID: 2843 RVA: 0x00041B50 File Offset: 0x0003FD50
		// (set) Token: 0x06000B1C RID: 2844 RVA: 0x00041B64 File Offset: 0x0003FD64
		public static \u0005\u0020\u0018 Instance { get; private set; }

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06000B1D RID: 2845 RVA: 0x00041B78 File Offset: 0x0003FD78
		// (set) Token: 0x06000B1E RID: 2846 RVA: 0x00041B8C File Offset: 0x0003FD8C
		public string Name { get; set; } = "Generic External Event";

		// Token: 0x06000B1F RID: 2847 RVA: 0x00041BA0 File Offset: 0x0003FDA0
		public void Execute(UIApplication app)
		{
			Exception u000C = \u001C\u0010\u000F.\u000C;
			List<Action>.Enumerator enumerator = \u0006\u001C\u0016.\u0018(this.\u0018);
			try
			{
				while (\u0007\u001C\u0016.\u0018(ref enumerator))
				{
					Action action = \u0010\u001C\u0016.\u0018(ref enumerator);
					try
					{
						if (action != null)
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0020\u0018.Execute(UIApplication)).MethodHandle;
							}
							\u000D\u0005\u0003.\u0018(action);
						}
					}
					catch (Exception)
					{
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
				((IDisposable)enumerator).Dispose();
			}
			EventHandler<Exception> u = this.\u0014;
			if (u == null)
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
			}
			else
			{
				\u0019\u001C\u0016.\u0018(u, this, u000C);
			}
			this.\u0014 = \u0013\u0010\u000F.\u000C;
			\u000B\u001C\u0016.\u0018(this.\u0018);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x00041C64 File Offset: 0x0003FE64
		public static void \u000F(Action \u000C)
		{
			if (\u001B\u001C\u0016.\u0018() != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0020\u0018.\u000F(Action)).MethodHandle;
				}
				if (\u0005\u0020\u0018.\u000C != null)
				{
					\u0001\u001C\u0016.\u0018(\u001B\u001C\u0016.\u0018().\u0018, \u000C);
					if (!\u0008\u001C\u0016.\u0018(\u0005\u0020\u0018.\u000C))
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
						\u001A\u0014\u0014.\u0018(\u0005\u0020\u0018.\u000C);
					}
					return;
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
			throw \u0005\u001C\u0016.\u0018("Event must be created in external command or application context");
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00041CE4 File Offset: 0x0003FEE4
		public string GetName()
		{
			return \u000E\u001C\u0016.\u0018(this);
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x00041CFC File Offset: 0x0003FEFC
		public static void \u0012()
		{
			if (\u001B\u001C\u0016.\u0018() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0005\u0020\u0018.\u0012()).MethodHandle;
				}
				\u000C\u0013\u0016.\u0018(new \u0005\u0020\u0018());
				\u0005\u0020\u0018.\u000C = \u000A\u001E\u0014.\u0018(\u001B\u001C\u0016.\u0018());
			}
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x00041D44 File Offset: 0x0003FF44
		public void \u000D()
		{
			\u000B\u001C\u0016.\u0018(this.\u0018);
		}

		// Token: 0x0400053F RID: 1343
		private static ExternalEvent \u000C;

		// Token: 0x04000540 RID: 1344
		private readonly List<Action> \u0018 = new List<Action>();

		// Token: 0x04000542 RID: 1346
		[CompilerGenerated]
		private static \u0005\u0020\u0018 \u0003;

		// Token: 0x04000543 RID: 1347
		[CompilerGenerated]
		private string \u0016;
	}
}
