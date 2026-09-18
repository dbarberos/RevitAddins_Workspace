using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.RoomPro.Filters;
using DiRoots.RoomPro.Models;
using DiRoots.RoomPro.ViewModels;

namespace A
{
	// Token: 0x020000A2 RID: 162
	internal class \u0012\u0004 : ExternalEventInfo
	{
		// Token: 0x06000698 RID: 1688 RVA: 0x00025BE4 File Offset: 0x00023DE4
		public \u0012\u0004(QuickViewsViewModel \u001F)
		{
			this.\u001C = \u001F;
		}

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x06000699 RID: 1689 RVA: 0x00025C00 File Offset: 0x00023E00
		// (remove) Token: 0x0600069A RID: 1690 RVA: 0x00025C4C File Offset: 0x00023E4C
		public event \u0012\u0004.\u0006\u0004 \u001F
		{
			[CompilerGenerated]
			add
			{
				\u0012\u0004.\u0006\u0004 u0006_u = this.\u001F;
				\u0012\u0004.\u0006\u0004 u0006_u2;
				do
				{
					u0006_u2 = u0006_u;
					\u0012\u0004.\u0006\u0004 value2 = (\u0012\u0004.\u0006\u0004)\u000F\u001E\u000A.\u000A(u0006_u2, value);
					u0006_u = Interlocked.CompareExchange<\u0012\u0004.\u0006\u0004>(ref this.\u001F, value2, u0006_u2);
				}
				while (u0006_u != u0006_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0004.add_\u001F(\u0012\u0004.\u0006\u0004)).MethodHandle;
				}
			}
			[CompilerGenerated]
			remove
			{
				\u0012\u0004.\u0006\u0004 u0006_u = this.\u001F;
				\u0012\u0004.\u0006\u0004 u0006_u2;
				do
				{
					u0006_u2 = u0006_u;
					\u0012\u0004.\u0006\u0004 value2 = (\u0012\u0004.\u0006\u0004)\u0012\u001E\u000A.\u000A(u0006_u2, value);
					u0006_u = Interlocked.CompareExchange<\u0012\u0004.\u0006\u0004>(ref this.\u001F, value2, u0006_u2);
				}
				while (u0006_u != u0006_u2);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0004.remove_\u001F(\u0012\u0004.\u0006\u0004)).MethodHandle;
				}
			}
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00025C98 File Offset: 0x00023E98
		public override void Execute(UIApplication app)
		{
			UIDocument u001F = \u0020\u0013\u000A.\u000A(app);
			Document u001F2 = \u0011\u0020\u000A.\u0007(u001F);
			SpatialElementSelectionFilter<SpatialElement> spatialElementSelectionFilter = \u001B\u0005\u001D.\u000A(u001F2);
			\u0008\u0005\u001D.\u000A(spatialElementSelectionFilter, \u0013\u001C\u0007.\u001D(this.\u001C));
			SpatialElementSelectionFilter<SpatialElement> spatialElementSelectionFilter2 = spatialElementSelectionFilter;
			\u0019\u0005\u001D.\u0007(\u0019\u000A\u001D.\u000A(), WindowState.Minimized);
			List<SpatialElement> list = \u000E\u0005\u001D.\u000A();
			IList<Reference> u001F3 = \u0010\u0005\u001D.\u000A();
			try
			{
				u001F3 = \u001C\u0005\u001D.\u000A(\u0010\u001E\u000A.\u0007(u001F), 2, spatialElementSelectionFilter2, \u000D\u0005\u001D.\u000A());
			}
			catch (OperationCanceledException u000A)
			{
				\u000D\u0011\u000A.\u0007(\u001E\u000A\u0007.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\QuickViews\\Core\\ExternalEvents\\GettingRomAndSpaces.cs", "Execute");
			}
			IEnumerator<Reference> enumerator = \u0003\u0005\u001D.\u000A(u001F3);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Reference reference = \u0012\u0005\u001D.\u000A(enumerator);
					RevitLinkInstance revitLinkInstance = \u000E\u0007\u000E.\u001F(\u001A\u0004\u001D.\u000A(u001F2, reference));
					if (revitLinkInstance != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0012\u0004.Execute(UIApplication)).MethodHandle;
						}
						\u000F\u0005\u001D.\u000A(spatialElementSelectionFilter2, \u000E\u0009\u0007.\u000A(revitLinkInstance));
						SpatialElement u000A2 = \u001E\u0007\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u0006\u0005\u001D.\u000A(spatialElementSelectionFilter2), \u0013\u0004\u001D.\u000A(reference)));
						\u0002\u0005\u001D.\u000A(list, u000A2);
					}
					else
					{
						SpatialElement u000A3 = \u001E\u0007\u000E.\u001F(\u001A\u0004\u001D.\u000A(u001F2, reference));
						\u0002\u0005\u001D.\u000A(list, u000A3);
					}
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
			finally
			{
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			IEnumerable<SpatialElement> enumerable = list;
			Func<SpatialElement, long> func;
			if ((func = \u0012\u0004.<>c.\u000A) == null)
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
				func = (\u0012\u0004.<>c.\u000A = new Func<SpatialElement, long>(\u0012\u0004.<>c.\u001F.\u001D));
			}
			IEnumerator<long> enumerator2 = \u000B\u0005\u001D.\u000A(Enumerable.Select<SpatialElement, long>(enumerable, func));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator2))
				{
					\u0012\u0004.\u000F\u0004 u000F_u = new \u0012\u0004.\u000F\u0004();
					u000F_u.\u001F = \u0016\u0005\u001D.\u000A(enumerator2);
					IEnumerable<ModelSpatialElement> enumerable2 = Enumerable.Cast<ModelSpatialElement>(\u0005\u000E\u0007.\u000A(\u0013\u0003\u0007.\u001D(this.\u001C)));
					Func<ModelSpatialElement, bool> func2;
					if ((func2 = \u0012\u0004.<>c.\u0007) == null)
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
						func2 = (\u0012\u0004.<>c.\u0007 = new Func<ModelSpatialElement, bool>(\u0012\u0004.<>c.\u001F.\u0004));
					}
					\u0005\u0005\u001D.\u000A(Enumerable.First<ModelSpatialElement>(Enumerable.Where<ModelSpatialElement>(enumerable2, func2), new Func<ModelSpatialElement, bool>(u000F_u.\u000A)), true);
				}
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
			finally
			{
				if (enumerator2 != null)
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
					\u001F\u0017\u000A.\u000A(enumerator2);
				}
			}
			\u0012\u0004.\u0006\u0004 u001F4 = this.\u001F;
			if (u001F4 == null)
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
			}
			else
			{
				\u0018\u0005\u001D.\u000A(u001F4);
			}
			\u0019\u0005\u001D.\u0007(\u0019\u000A\u001D.\u000A(), WindowState.Normal);
		}

		// Token: 0x0400029E RID: 670
		private readonly QuickViewsViewModel \u001C;

		// Token: 0x020007C7 RID: 1991
		// (Invoke) Token: 0x06004C9B RID: 19611
		public delegate void \u0006\u0004();

		// Token: 0x020007C9 RID: 1993
		[CompilerGenerated]
		private sealed class \u000F\u0004
		{
			// Token: 0x06004CA3 RID: 19619 RVA: 0x001DC938 File Offset: 0x001DAB38
			internal bool \u000A(ModelSpatialElement \u001F)
			{
				return \u0018\u0018\u0007.\u0007(\u001F) == this.\u001F;
			}

			// Token: 0x04001FA7 RID: 8103
			public long \u001F;
		}
	}
}
