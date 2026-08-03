using System;
using System.Collections.Generic;
using System.Linq;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Core;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace ProSheets.RVTExternalEventHandler
{
	// Token: 0x020000BD RID: 189
	public class DeleteElementExternalEvent : ExternalEventInfo
	{
		// Token: 0x06000A98 RID: 2712 RVA: 0x000404BC File Offset: 0x0003E6BC
		public DeleteElementExternalEvent(List<long> ids)
		{
			Func<long, ElementId> func;
			if ((func = DeleteElementExternalEvent.<>c.\u0018) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DeleteElementExternalEvent..ctor(List<long>)).MethodHandle;
				}
				func = (DeleteElementExternalEvent.<>c.\u0018 = new Func<long, ElementId>(DeleteElementExternalEvent.<>c.\u000C.\u0014));
			}
			this.\u0011 = Enumerable.ToList<ElementId>(Enumerable.Select<long, ElementId>(ids, func));
		}

		// Token: 0x06000A99 RID: 2713 RVA: 0x00040518 File Offset: 0x0003E718
		public override void Execute(UIApplication app)
		{
			try
			{
				Document u000C = \u0017\u0005\u0018.\u0014(\u001F\u001F\u0014.\u0018(app));
				Transaction transaction = \u001F\u000C\u0016.\u0018(u000C, "ProSheets_DeleteViewSet");
				try
				{
					FailureHandlingOptions failureHandlingOptions = \u0012\u0007\u0014.\u0018(transaction);
					FailurePreproccessor failurePreproccessor = \u000A\u000D\u0016.\u0018();
					\u0009\u000D\u0016.\u0018(failurePreproccessor, "ProSheets_CreateViewSet");
					FailurePreproccessor u = failurePreproccessor;
					\u000F\u0007\u0014.\u0018(failureHandlingOptions, u);
					\u0016\u0007\u0014.\u0018(transaction, failureHandlingOptions);
					try
					{
						\u0020\u000C\u0016.\u0018(transaction);
						\u000F\u000C\u0016.\u0018(u000C, this.\u0011);
						\u0009\u0007\u0014.\u0018(transaction);
					}
					catch (Exception u2)
					{
						\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u2, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RVTExternalEventHandler\\DeleteElementExternalEvent.cs", "Execute");
						\u0020\u000D\u0016.\u0018(transaction);
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
						if (!true)
						{
							RuntimeMethodHandle runtimeMethodHandle = methodof(DeleteElementExternalEvent.Execute(UIApplication)).MethodHandle;
						}
						\u0020\u001E\u0018.\u0018(transaction);
					}
				}
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\RVTExternalEventHandler\\DeleteElementExternalEvent.cs", "Execute");
			}
		}

		// Token: 0x04000500 RID: 1280
		private List<ElementId> \u0011;
	}
}
