using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using DiRoots.One.OneFilter;
using SelectionsManager.Commands;
using SelectionsManager.UI.Pages;

namespace A
{
	// Token: 0x0200002A RID: 42
	internal class \u001D\u000A
	{
		// Token: 0x06000167 RID: 359 RVA: 0x00007D30 File Offset: 0x00005F30
		public \u001D\u000A(UIControlledApplication \u001F)
		{
			this.\u001F = \u001F;
			FieldInfo fieldInfo = \u001A\u0013\u000A.\u000A(\u0003\u0011\u000A.\u0007(this.\u001F), "m_uiapplication", BindingFlags.Instance | BindingFlags.NonPublic);
			object u001F;
			if (fieldInfo == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A..ctor(UIControlledApplication)).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u0013\u0013\u000A.\u000A(fieldInfo, this.\u001F);
			}
			\u0014\u0013\u000A.\u000A(this, \u0020\u0015\u0010.\u001F(u001F));
			\u001E\u0013\u000A.\u000A(this, \u0020\u0013\u000A.\u000A(\u0017\u0013\u000A.\u0007(this)));
			this.\u001D = new MonitorOnIdlingCommand();
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00007DBC File Offset: 0x00005FBC
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00007DD0 File Offset: 0x00005FD0
		public static \u001D\u000A CurrentHandler { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00007DE4 File Offset: 0x00005FE4
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00007DF8 File Offset: 0x00005FF8
		public static Command OneFilterCommand { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600016C RID: 364 RVA: 0x00007E0C File Offset: 0x0000600C
		// (set) Token: 0x0600016D RID: 365 RVA: 0x00007E20 File Offset: 0x00006020
		public Document CurrentDocument { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600016E RID: 366 RVA: 0x00007E34 File Offset: 0x00006034
		// (set) Token: 0x0600016F RID: 367 RVA: 0x00007E48 File Offset: 0x00006048
		public UIDocument CurrentUIDocument { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000170 RID: 368 RVA: 0x00007E5C File Offset: 0x0000605C
		// (set) Token: 0x06000171 RID: 369 RVA: 0x00007E70 File Offset: 0x00006070
		public UIApplication CurrentUIApplication { get; set; }

		// Token: 0x06000172 RID: 370 RVA: 0x00007E84 File Offset: 0x00006084
		public bool \u000B()
		{
			DockablePane u = this.\u0007;
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A.\u000B()).MethodHandle;
				}
				return false;
			}
			return \u000C\u0013\u000A.\u0007(u);
		}

		// Token: 0x06000173 RID: 371 RVA: 0x00007EB8 File Offset: 0x000060B8
		public void \u0002()
		{
			DockablePane u = this.\u0007;
			bool flag;
			if (u == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A.\u0002()).MethodHandle;
				}
				flag = false;
			}
			else
			{
				flag = \u000C\u0013\u000A.\u0007(u);
			}
			if (flag)
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
				MainPage u000A = this.\u000A;
				if (u000A == null)
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
					return;
				}
				\u0015\u0013\u000A.\u000A(u000A);
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x00007F14 File Offset: 0x00006114
		public void \u0006()
		{
			\u0009\u0013\u000A.\u000A(\u001F\u001A\u000A.\u000A(this.\u001F), new EventHandler<DocumentOpenedEventArgs>(this.\u001C));
			\u0001\u0013\u000A.\u000A(this.\u001F, new EventHandler<ViewActivatedEventArgs>(this.\u000F));
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00007F58 File Offset: 0x00006158
		private void \u000F(object \u001F, ViewActivatedEventArgs \u000A)
		{
			if (\u0016\u001A\u000A.\u000A(this) != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A.\u000F(object, ViewActivatedEventArgs)).MethodHandle;
				}
				DockablePane u = this.\u0007;
				bool flag;
				if (u == null)
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
					flag = false;
				}
				else
				{
					flag = \u000C\u0013\u000A.\u0007(u);
				}
				if (flag)
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
					if (\u000B\u001A\u000A.\u0007(\u0016\u001A\u000A.\u000A(this)))
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
						if (!\u001D\u0017\u000A.\u000A(\u0005\u001A\u000A.\u0007(\u0019\u001A\u000A.\u000A(\u000A)), \u0005\u001A\u000A.\u0007(\u0016\u001A\u000A.\u000A(this))))
						{
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
					\u0018\u001A\u000A.\u000A(this, \u0019\u001A\u000A.\u000A(\u000A));
					\u001E\u0013\u000A.\u000A(this, \u0004\u001A\u000A.\u000A(\u0019\u001A\u000A.\u000A(\u000A)));
					\u001D\u001A\u000A.\u0007(this.\u000A, \u000D\u0014\u000A.\u001D(this));
					if (!\u0007\u001A\u000A.\u000A(this.\u001D))
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
						\u000A\u001A\u000A.\u0007(this.\u001D, this.\u000A);
					}
				}
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x00008060 File Offset: 0x00006260
		private void \u0012(object \u001F, DockableFrameVisibilityChangedEventArgs \u000A)
		{
			UIApplication u001F = \u001E\u0015\u0010.\u001F(\u001F);
			if (this.\u0007 == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A.\u0012(object, DockableFrameVisibilityChangedEventArgs)).MethodHandle;
				}
				DockablePaneId u000A = \u000F\u001A\u000A.\u000A(\u0012\u001A\u000A.\u000A());
				this.\u0007 = \u0006\u001A\u000A.\u0007(u001F, u000A);
			}
			if (!\u000C\u0013\u000A.\u001D(this.\u0007))
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
				if (!\u0007\u001A\u000A.\u000A(this.\u001D))
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
					\u000A\u001A\u000A.\u0007(this.\u001D, this.\u000A);
				}
				\u001E\u0013\u000A.\u000A(this, \u0020\u0013\u000A.\u000A(u001F));
				\u001D\u001A\u000A.\u0007(this.\u000A, \u000D\u0014\u000A.\u001D(this));
				return;
			}
			if (\u0007\u001A\u000A.\u000A(this.\u001D))
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
				if (\u000C\u0013\u000A.\u001D(this.\u0007))
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
					\u0002\u001A\u000A.\u0007(this.\u001D);
				}
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x00008154 File Offset: 0x00006354
		public void \u0003(UIApplication \u001F = null)
		{
			try
			{
				RegisterSelectionsManagerCommand registerSelectionsManagerCommand = \u0010\u001A\u000A.\u000A();
				UIApplication u001F = \u001F;
				if (\u001F == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A.\u0003(UIApplication)).MethodHandle;
					}
					u001F = \u0017\u0013\u000A.\u0007(this);
				}
				registerSelectionsManagerCommand.\u0012(u001F);
				this.\u000A = \u000D\u001A\u000A.\u000A();
				\u001C\u001A\u000A.\u000A();
			}
			catch (Exception u001F2)
			{
				\u0005\u0013\u000A.\u000A(\u0003\u001A\u000A.\u000A(u001F2), 250.0);
			}
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000081CC File Offset: 0x000063CC
		private void \u001C(object \u001F, DocumentOpenedEventArgs \u000A)
		{
			\u0018\u001A\u000A.\u000A(this, \u0019\u001A\u000A.\u000A(\u000A));
			\u001E\u0013\u000A.\u000A(this, \u0020\u0013\u000A.\u000A(\u0017\u0013\u000A.\u0007(this)));
			if (\u000D\u0014\u000A.\u001D(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u001D\u000A.\u001C(object, DocumentOpenedEventArgs)).MethodHandle;
				}
				return;
			}
			if (this.\u0007 == null)
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
				DockablePaneId u000A = \u000F\u001A\u000A.\u000A(\u0012\u001A\u000A.\u000A());
				this.\u0007 = \u0006\u001A\u000A.\u001D(\u001B\u001A\u000A.\u000A(\u0011\u0015\u0010.\u001F(\u001F)), u000A);
				\u0008\u001A\u000A.\u000A(this.\u0007);
				\u0002\u001A\u000A.\u0007(this.\u001D);
				\u000E\u001A\u000A.\u000A(this.\u001F, new EventHandler<DockableFrameVisibilityChangedEventArgs>(this.\u0012));
			}
			if (\u000C\u0013\u000A.\u001D(this.\u0007))
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
				MainPage u000A2 = this.\u000A;
				if (u000A2 == null)
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
					\u001D\u001A\u000A.\u001D(u000A2, \u000D\u0014\u000A.\u001D(this));
				}
				if (!\u0007\u001A\u000A.\u000A(this.\u001D))
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
					\u000A\u001A\u000A.\u0007(this.\u001D, this.\u000A);
				}
			}
		}

		// Token: 0x04000094 RID: 148
		private readonly UIControlledApplication \u001F;

		// Token: 0x04000095 RID: 149
		private MainPage \u000A;

		// Token: 0x04000096 RID: 150
		private DockablePane \u0007;

		// Token: 0x04000097 RID: 151
		private readonly MonitorOnIdlingCommand \u001D;

		// Token: 0x04000098 RID: 152
		[CompilerGenerated]
		private static \u001D\u000A \u0004;

		// Token: 0x04000099 RID: 153
		[CompilerGenerated]
		private static Command \u0019;

		// Token: 0x0400009A RID: 154
		[CompilerGenerated]
		private Document \u0018;

		// Token: 0x0400009B RID: 155
		[CompilerGenerated]
		private UIDocument \u0005;

		// Token: 0x0400009C RID: 156
		[CompilerGenerated]
		private UIApplication \u0016;
	}
}
