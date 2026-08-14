using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using DiRoots.One.Commons.Interfaces;
using ProSheets.Helpers;

namespace A
{
	// Token: 0x020000E1 RID: 225
	internal static class \u0008\u001F\u0018
	{
		// Token: 0x06000B82 RID: 2946 RVA: 0x00046298 File Offset: 0x00044498
		public static void \u000C(object \u000C, FailuresProcessingEventArgs \u0018)
		{
			if (!\u0018\u0015\u0014.\u0018())
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001F\u0018.\u000C(object, FailuresProcessingEventArgs)).MethodHandle;
				}
				return;
			}
			try
			{
				FailuresAccessor u000C = \u0002\u0011\u0016.\u0018(\u0018);
				object u000C2 = \u001B\u000D\u0016.\u0018(u000C);
				bool flag = false;
				StringBuilder u000C3 = \u0005\u0017\u0018.\u0018();
				IEnumerator<FailureMessageAccessor> enumerator = \u0006\u000D\u0016.\u0018(u000C2);
				try
				{
					while (\u001F\u001E\u0018.\u0018(enumerator))
					{
						FailureMessageAccessor failureMessageAccessor = \u0010\u000D\u0016.\u0018(enumerator);
						FailureDefinitionId u = \u0019\u000D\u0016.\u0018(failureMessageAccessor);
						if (\u0007\u000D\u0016.\u0018(failureMessageAccessor) == 1)
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
							\u001D\u000D\u0016.\u0018(u000C, failureMessageAccessor);
						}
						else
						{
							string u2 = \u001E\u0011\u0016.\u0018(failureMessageAccessor);
							\u0015\u001B\u0003.\u0018(u000C3, \u001A\u001E\u0018.\u0018("{0} Id:{1}", u2, u));
							flag = true;
						}
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
				finally
				{
					if (enumerator != null)
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
						\u0020\u001E\u0018.\u0018(enumerator);
					}
				}
				if (flag)
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
					\u001F\u0011\u0016.\u0018(\u0018, 2);
					FailureHandlingOptions failureHandlingOptions = \u0017\u0011\u0016.\u0018(u000C);
					\u0015\u0011\u0016.\u0018(failureHandlingOptions, true);
					\u0011\u0011\u0016.\u0018(u000C, failureHandlingOptions);
					\u0008\u0017\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), \u0001\u0017\u0018.\u0018(u000C3), "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\ControlledApplicationFailuresHandler.cs", "FailuresProcessor");
					\u001F\u0011\u0016.\u0018(\u0018, 2);
				}
				else
				{
					\u001F\u0011\u0016.\u0018(\u0018, 0);
				}
			}
			catch (Exception u3)
			{
				\u001E\u001E\u0018.\u0018(IocContainer.GetService<ICustomLogger>(), u3, "Y:\\DiRoots.Deploy\\DiRoots.1ce01fbd-8e5e-48ce-b81d-eb92a74a125a\\src\\ProSheets\\Exporters\\ControlledApplicationFailuresHandler.cs", "FailuresProcessor");
			}
		}
	}
}
