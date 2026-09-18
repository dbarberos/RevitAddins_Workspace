using System;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace A
{
	// Token: 0x020000A1 RID: 161
	internal class \u0002\u0004 : IExternalEventHandler
	{
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000686 RID: 1670 RVA: 0x00025864 File Offset: 0x00023A64
		// (set) Token: 0x06000687 RID: 1671 RVA: 0x00025878 File Offset: 0x00023A78
		internal static ExternalEvent HandlerEvent { get; set; }

		// Token: 0x170001BE RID: 446
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0002588C File Offset: 0x00023A8C
		// (set) Token: 0x06000689 RID: 1673 RVA: 0x000258A0 File Offset: 0x00023AA0
		internal static \u0002\u0004 HandlerInstance { get; set; }

		// Token: 0x170001BF RID: 447
		// (get) Token: 0x0600068A RID: 1674 RVA: 0x000258B4 File Offset: 0x00023AB4
		// (set) Token: 0x0600068B RID: 1675 RVA: 0x000258C8 File Offset: 0x00023AC8
		public Document Doc { get; set; }

		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x000258DC File Offset: 0x00023ADC
		// (set) Token: 0x0600068D RID: 1677 RVA: 0x000258F0 File Offset: 0x00023AF0
		public Action Action { get; set; }

		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x00025904 File Offset: 0x00023B04
		// (set) Token: 0x0600068F RID: 1679 RVA: 0x00025918 File Offset: 0x00023B18
		public bool RollBack { get; set; }

		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x0002592C File Offset: 0x00023B2C
		// (set) Token: 0x06000691 RID: 1681 RVA: 0x00025940 File Offset: 0x00023B40
		public Action TaskFinished { get; set; }

		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x00025954 File Offset: 0x00023B54
		// (set) Token: 0x06000693 RID: 1683 RVA: 0x00025968 File Offset: 0x00023B68
		public string TransactionName { get; set; }

		// Token: 0x06000694 RID: 1684 RVA: 0x0002597C File Offset: 0x00023B7C
		public void Execute(UIApplication app)
		{
			\u0011\u0003\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\ExternalEventTransaction.cs", "Execute");
			if (\u0013\u0018\u001D.\u000A(this) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0004.Execute(UIApplication)).MethodHandle;
				}
				return;
			}
			if (\u000C\u0018\u001D.\u000A(this) == null)
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
				\u0015\u0018\u001D.\u0007(this, \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app)));
			}
			Transaction transaction = \u001D\u0014\u0007.\u000A(\u000C\u0018\u001D.\u000A(this), \u001A\u0018\u001D.\u000A(this));
			try
			{
				\u0007\u0014\u0007.\u000A(transaction);
				try
				{
					\u001B\u0015\u0007.\u000A(\u0013\u0018\u001D.\u000A(this));
				}
				catch (Exception ex)
				{
					\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), ex, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\ExternalEventTransaction.cs", "Execute");
					TaskDialog u001F = \u0017\u0018\u001D.\u000A(\u0014\u0018\u001D.\u000A());
					\u0020\u0018\u001D.\u000A(u001F, \u0003\u001A\u000A.\u000A(ex));
					\u0011\u0018\u001D.\u000A(u001F, \u001E\u0018\u001D.\u000A(ex));
					\u001B\u0018\u001D.\u000A(u001F);
					\u001F\u0014\u0007.\u000A(transaction);
					\u0010\u0018\u001D.\u0007(this, \u001A\u001F\u000E.\u001F);
					return;
				}
				if (\u0008\u0018\u001D.\u000A(this))
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
					\u001F\u0014\u0007.\u000A(transaction);
				}
				else
				{
					\u001B\u0001\u000A.\u000A(transaction);
					Action action = \u000E\u0018\u001D.\u000A(this);
					if (action == null)
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
					}
					else
					{
						\u001B\u0015\u0007.\u000A(action);
					}
				}
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
			\u000F\u0012\u0007.\u000A(\u001E\u000A\u0007.\u000A(), "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\ExternalEventTransaction.cs", "Execute");
			\u0010\u0018\u001D.\u0007(this, \u001A\u001F\u000E.\u001F);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00025B10 File Offset: 0x00023D10
		internal static void \u0005(Action \u001F, string \u000A, bool \u0007 = false, Document \u001D = null)
		{
			if (\u001D != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0004.\u0005(Action, string, bool, Document)).MethodHandle;
				}
				\u0015\u0018\u001D.\u001D(\u0009\u0018\u001D.\u000A(), \u001D);
			}
			if (\u000A != null)
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
				\u000A\u0005\u001D.\u000A(\u0009\u0018\u001D.\u000A(), \u000A);
			}
			\u001F\u0005\u001D.\u000A(\u0009\u0018\u001D.\u000A(), \u0007);
			\u0010\u0018\u001D.\u001D(\u0009\u0018\u001D.\u000A(), \u001F);
			\u0011\u001E\u000A.\u000A(\u0001\u0018\u001D.\u000A());
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00025B84 File Offset: 0x00023D84
		public string GetName()
		{
			return \u001A\u0018\u001D.\u000A(this);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00025B9C File Offset: 0x00023D9C
		internal static void \u0016()
		{
			if (\u0009\u0018\u001D.\u000A() == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0002\u0004.\u0016()).MethodHandle;
				}
				\u0004\u0005\u001D.\u000A(new \u0002\u0004());
				\u0007\u0005\u001D.\u000A(\u001D\u0005\u001D.\u000A(\u0009\u0018\u001D.\u000A()));
			}
		}

		// Token: 0x04000297 RID: 663
		[CompilerGenerated]
		private static ExternalEvent \u001F;

		// Token: 0x04000298 RID: 664
		[CompilerGenerated]
		private static \u0002\u0004 \u000A;

		// Token: 0x04000299 RID: 665
		[CompilerGenerated]
		private Document \u0007;

		// Token: 0x0400029A RID: 666
		[CompilerGenerated]
		private Action \u001D;

		// Token: 0x0400029B RID: 667
		[CompilerGenerated]
		private bool \u0004;

		// Token: 0x0400029C RID: 668
		[CompilerGenerated]
		private Action \u0019;

		// Token: 0x0400029D RID: 669
		[CompilerGenerated]
		private string \u0018;
	}
}
