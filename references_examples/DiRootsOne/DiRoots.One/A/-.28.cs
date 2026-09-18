using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using SelectionsManager.ViewModels.Base;
using SelectionsManager.ViewModels.Interfaces;

namespace A
{
	// Token: 0x02000039 RID: 57
	internal class \u0016\u000A : ExternalEventInfo
	{
		// Token: 0x060001D9 RID: 473 RVA: 0x00009B0C File Offset: 0x00007D0C
		public \u0016\u000A()
		{
			\u000D\u0001\u000A.\u0007(this, "OneFilter_DeleteSelection");
		}

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x060001DA RID: 474 RVA: 0x00009B2C File Offset: 0x00007D2C
		// (remove) Token: 0x060001DB RID: 475 RVA: 0x00009B7C File Offset: 0x00007D7C
		public event DeleteFinishedHandler \u001F
		{
			[CompilerGenerated]
			add
			{
				DeleteFinishedHandler deleteFinishedHandler = this.\u001F;
				DeleteFinishedHandler deleteFinishedHandler2;
				do
				{
					deleteFinishedHandler2 = deleteFinishedHandler;
					DeleteFinishedHandler value2 = \u0016\u0015\u0010.\u001F(\u000F\u001E\u000A.\u000A(deleteFinishedHandler2, value));
					deleteFinishedHandler = Interlocked.CompareExchange<DeleteFinishedHandler>(ref this.\u001F, value2, deleteFinishedHandler2);
				}
				while (deleteFinishedHandler != deleteFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000A.add_\u001F(DeleteFinishedHandler)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				DeleteFinishedHandler deleteFinishedHandler = this.\u001F;
				DeleteFinishedHandler deleteFinishedHandler2;
				do
				{
					deleteFinishedHandler2 = deleteFinishedHandler;
					DeleteFinishedHandler value2 = \u0016\u0015\u0010.\u001F(\u0012\u001E\u000A.\u000A(deleteFinishedHandler2, value));
					deleteFinishedHandler = Interlocked.CompareExchange<DeleteFinishedHandler>(ref this.\u001F, value2, deleteFinishedHandler2);
				}
				while (deleteFinishedHandler != deleteFinishedHandler2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000A.remove_\u001F(DeleteFinishedHandler)).MethodHandle;
				}
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00009BCC File Offset: 0x00007DCC
		// (set) Token: 0x060001DD RID: 477 RVA: 0x00009BE0 File Offset: 0x00007DE0
		public ISelectionItem CurrentSelectionViewModel { get; set; }

		// Token: 0x060001DE RID: 478 RVA: 0x00009BF4 File Offset: 0x00007DF4
		public override void Execute(UIApplication app)
		{
			Document u001F = \u0011\u0020\u000A.\u0007(\u0020\u0013\u000A.\u000A(app));
			Transaction transaction = \u0013\u0001\u000A.\u000A(u001F);
			try
			{
				\u0017\u0001\u000A.\u000A(transaction, \u0014\u0001\u000A.\u000A(this));
				\u0011\u0001\u000A.\u000A(u001F, \u001E\u0001\u000A.\u000A(\u0020\u0001\u000A.\u000A(\u000E\u0001\u000A.\u000A(this))));
				\u001B\u0001\u000A.\u000A(transaction);
				if (\u0008\u0001\u000A.\u000A(transaction) == 3)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0016\u000A.Execute(UIApplication)).MethodHandle;
					}
					DeleteFinishedHandler u001F2 = this.\u001F;
					if (u001F2 == null)
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
					}
					else
					{
						\u0010\u0001\u000A.\u000A(u001F2, \u000E\u0001\u000A.\u000A(this));
					}
				}
			}
			finally
			{
				if (transaction != null)
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
					\u001F\u0017\u000A.\u000A(transaction);
				}
			}
		}

		// Token: 0x040000C2 RID: 194
		[CompilerGenerated]
		private ISelectionItem \u000A;
	}
}
