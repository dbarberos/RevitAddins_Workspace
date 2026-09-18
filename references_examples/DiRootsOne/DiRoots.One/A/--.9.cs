using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Autodesk.Revit.DB;
using DiRoots.One.Commons.Enums;
using DiRoots.One.Revit.Extensions;
using DiRoots.RoomPro.Enums;
using DiRoots.RoomPro.Models;
using DiRoots.SpatialElementViews.Enums;

namespace A
{
	// Token: 0x02000063 RID: 99
	internal static class \u0008\u001D
	{
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000464 RID: 1124 RVA: 0x0001ABAC File Offset: 0x00018DAC
		// (set) Token: 0x06000465 RID: 1125 RVA: 0x0001ABC0 File Offset: 0x00018DC0
		internal static List<ViewsReport> Reports { get; set; } = \u000D\u0014\u0007.\u000A();

		// Token: 0x06000466 RID: 1126 RVA: 0x0001ABD4 File Offset: 0x00018DD4
		internal unsafe static View \u000A(this SpatialElement \u001F, Document \u000A, ElementId \u0007, CalloutUserSettings \u001D, out List<ViewsReport> \u0004, Transform \u0019 = null)
		{
			\u0004 = \u000D\u0014\u0007.\u000A();
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u000A);
			double num = \u001A\u0002\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			int u000A = \u001D\u0006\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			ViewTemplate u001F = \u0005\u0013\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			ModelPhase u001F2 = \u0018\u0013\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			int u000A2 = \u000A\u0006\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			CalloutShape calloutShape = (CalloutShape)\u0014\u0002\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			bool flag = \u0020\u0002\u0007.\u000A(\u001F\u000B\u0007.\u000A(\u001D));
			if (\u001A\u0009\u0010.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u000E\u0019\u0007.\u000A(\u001F))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u000A(Document, ElementId, CalloutUserSettings, List<ViewsReport>*, Transform)).MethodHandle;
				}
				u0013_u001D.\u0013(\u0019\u0013\u0007.\u000A(\u001F));
			}
			View view = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u0007));
			ViewFamilyType u001F3 = \u000C\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, \u0004\u0013\u0007.\u000A(view)));
			ViewFamilyType viewFamilyType = Enumerable.FirstOrDefault<ViewFamilyType>(u0013_u001D.\u000F(\u001D\u0013\u0007.\u000A(u001F3)));
			ElementId elementId;
			if (viewFamilyType == null)
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
				elementId = \u0012\u0015\u0010.\u001F;
			}
			else
			{
				elementId = \u0002\u001E\u000A.\u001D(viewFamilyType);
			}
			ElementId u = elementId;
			BoundingBoxXYZ u001F4 = \u0002\u0004\u0007.\u000A(\u001F, view);
			XYZ u001F5 = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F4)), \u001C\u001F\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F4)), \u0003\u000A\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F4)));
			XYZ u001F6 = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F4)), \u001C\u001F\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F4)), \u0003\u000A\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F4)));
			XYZ xyz = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F5) - num, \u001C\u001F\u0007.\u000A(u001F5) - num, \u0003\u000A\u0007.\u000A(u001F5));
			XYZ xyz2 = \u001B\u001F\u0007.\u000A(\u000D\u001F\u0007.\u000A(u001F6) + num, \u001C\u001F\u0007.\u000A(u001F6) + num, \u0003\u000A\u0007.\u000A(u001F6));
			View view2 = \u0011\u001F\u000E.\u001F;
			if (\u0019 != null)
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
				xyz = \u0007\u0013\u0007.\u000A(\u0019, xyz);
				xyz2 = \u0007\u0013\u0007.\u000A(\u0019, xyz2);
			}
			if (flag)
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
				ElementId elementId2 = \u000A\u0013\u0007.\u000A(view, 1);
				view2 = \u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u000A, elementId2));
				\u001F\u0013\u0007.\u000A(\u000A, \u0007, elementId2, xyz, xyz2);
				BoundingBoxXYZ boundingBoxXYZ = \u001E\u0019\u0007.\u000A();
				\u0011\u0019\u0007.\u000A(boundingBoxXYZ, xyz);
				\u001B\u0019\u0007.\u000A(boundingBoxXYZ, xyz2);
				\u0009\u0014\u0007.\u000A(view2, boundingBoxXYZ);
			}
			else
			{
				view2 = \u0001\u0014\u0007.\u000A(\u000A, \u0007, u, xyz, xyz2);
			}
			if (calloutShape != CalloutShape.Rectangle)
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
				if (calloutShape == CalloutShape.AlignedWithRoomBoundary)
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
					bool flag2 = \u0008\u001D.\u0012(view2, \u001F, num, \u0019);
					if (flag && flag2)
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
						ElementId u000A3 = \u0008\u001D.\u0007(\u000A, view, \u0005\u001E\u000A.\u000A(view2));
						flag2 = \u0008\u001D.\u0006(\u000A, u000A3, \u001F, num, \u0019);
					}
					if (!flag2)
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
						object u001F7 = \u0004;
						ViewsReport viewsReport = \u0015\u0014\u0007.\u000A();
						\u000C\u0014\u0007.\u000A(viewsReport, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
						\u0013\u0014\u0007.\u000A(viewsReport, \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(\u001F, -1006900L)));
						\u0017\u0014\u0007.\u000A(viewsReport, \u0014\u0014\u0007.\u000A(\u001F));
						\u0020\u0014\u0007.\u000A(viewsReport, ReportStates.Warning);
						\u0011\u0014\u0007.\u000A(viewsReport, \u001E\u0014\u0007.\u000A());
						\u0008\u0014\u0007.\u000A(viewsReport, \u001B\u0014\u0007.\u000A());
						\u000E\u0014\u0007.\u000A(u001F7, viewsReport);
					}
				}
			}
			\u0019\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(view2, -1005176L), \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(u001F)));
			Parameter u001F8 = \u0016\u0018\u0007.\u0007(view2, -1012102L);
			if (!\u0010\u0014\u0007.\u000A(u001F8))
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
				\u0019\u0018\u0007.\u000A(u001F8, \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(u001F2)));
			}
			Parameter u001F9 = \u0016\u0018\u0007.\u0007(view2, -1011002L);
			if (!\u0010\u0014\u0007.\u000A(u001F9))
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
				\u0006\u0018\u0007.\u000A(u001F9, u000A2);
			}
			\u000B\u0018\u0007.\u000A(view2, u000A);
			\u0008\u001D.\u0018(\u001F, view2, \u001D);
			\u001E\u0018\u0007.\u000A(\u000A);
			return view2;
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0001B010 File Offset: 0x00019210
		private static ElementId \u0007(Document \u001F, View \u000A, string \u0007)
		{
			object u001F = \u0002\u0013\u0007.\u000A(\u000A);
			ElementId result = Constants.InvalidElementId;
			IEnumerator<ElementId> enumerator = \u000B\u0013\u0007.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ElementId elementId = \u0016\u0013\u0007.\u000A(enumerator);
					if (\u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u0011\u0017\u000A.\u0007(\u001F, elementId)), \u0007))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0007(Document, View, string)).MethodHandle;
						}
						result = elementId;
					}
				}
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
			return result;
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0001B0A8 File Offset: 0x000192A8
		internal static IEnumerable<View> \u001D(this SpatialElement \u001F, ViewsCreationHandler \u000A, SectionData \u0007, Document \u001D, SectionAndElevationUserSettings \u0004, bool \u0019 = true)
		{
			List<View> list = Enumerable.ToList<View>(Enumerable.Cast<View>(\u001F.\u0019(\u000A, \u001D, \u0007, \u0019)));
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(list);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					\u0019\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(\u0019\u0010\u0007.\u000A(ref enumerator), -1005176L), \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(\u0006\u0013\u0007.\u000A(\u0007))));
				}
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u001D(ViewsCreationHandler, SectionData, Document, SectionAndElevationUserSettings, bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			\u0008\u001D.\u0005(\u001F, list, \u0004);
			\u001E\u0018\u0007.\u000A(\u001D);
			return list;
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0001B160 File Offset: 0x00019360
		internal unsafe static IEnumerable<View> \u0004(this SpatialElement \u001F, ElementId \u000A, ViewsCreationHandler \u0007, Document \u001D, SectionData \u0004, SectionAndElevationUserSettings \u0019, out List<ViewsReport> \u0018, bool \u0005 = true)
		{
			\u0018 = \u000D\u0014\u0007.\u000A();
			\u0013\u001D u0013_u001D = new \u0013\u001D(\u001D);
			if (\u001A\u0009\u0010.\u001F(\u0011\u0017\u000A.\u0007(\u001D, \u000E\u0019\u0007.\u000A(\u001F))) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(SpatialElement.\u0004(ElementId, ViewsCreationHandler, Document, SectionData, SectionAndElevationUserSettings, List<ViewsReport>*, bool)).MethodHandle;
				}
				u0013_u001D.\u0013(\u0019\u0013\u0007.\u000A(\u001F));
			}
			ElementId u = \u0002\u001E\u000A.\u0007(\u0005\u001F\u000E.\u001F(\u0011\u0017\u000A.\u0007(\u001D, \u000A)));
			List<View> list;
			if (\u000B\u0020\u0007.\u000A(\u0004))
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
				if (!\u0008\u001D.\u0008(\u001D, \u0003\u0013\u0007.\u000A(\u0004)))
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
					if (\u000E\u0004\u0007.\u000A(\u000C\u0004\u0007.\u000A(\u0004)) <= 4)
					{
						list = Enumerable.ToList<View>(Enumerable.Cast<View>(\u001F.\u001D(\u0007, \u001D, \u0004, u, \u001A\u001F\u000E.\u001F)));
						list = \u0008\u001D.\u0019(list, (DiRoots.RoomPro.Enums.SortingDirections)\u0017\u0004\u0007.\u000A(\u0004), \u0014\u0004\u0007.\u000A(\u0004));
						goto IL_1A7;
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
				list = Enumerable.ToList<View>(Enumerable.Cast<View>(\u001F.\u0004(\u0007, \u001D, \u0004, u, \u0005)));
				object u001F = \u0018;
				ViewsReport viewsReport = \u0015\u0014\u0007.\u000A();
				\u000C\u0014\u0007.\u000A(viewsReport, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(\u001F)));
				\u0013\u0014\u0007.\u000A(viewsReport, \u001A\u0014\u0007.\u0007(\u0016\u0018\u0007.\u0007(\u001F, -1006900L)));
				\u0017\u0014\u0007.\u000A(viewsReport, \u0014\u0014\u0007.\u000A(\u001F));
				\u0020\u0014\u0007.\u000A(viewsReport, ReportStates.Warning);
				\u0011\u0014\u0007.\u000A(viewsReport, \u0012\u0013\u0007.\u000A());
				\u0008\u0014\u0007.\u000A(viewsReport, \u000F\u0013\u0007.\u000A());
				\u000E\u0014\u0007.\u000A(u001F, viewsReport);
			}
			else
			{
				list = Enumerable.ToList<View>(Enumerable.Cast<View>(\u001F.\u0004(\u0007, \u001D, \u0004, u, \u0005)));
			}
			IL_1A7:
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(list);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					\u0019\u0018\u0007.\u000A(\u0016\u0018\u0007.\u0007(\u0019\u0010\u0007.\u000A(ref enumerator), -1005176L), \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(\u0006\u0013\u0007.\u000A(\u0004))));
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
			\u0008\u001D.\u0005(\u001F, list, \u0019);
			\u001E\u0018\u0007.\u000A(\u001D);
			return list;
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0001B39C File Offset: 0x0001959C
		private static List<View> \u0019(List<View> \u001F, DiRoots.RoomPro.Enums.SortingDirections \u000A, bool \u0007)
		{
			\u0008\u001D.\u000E\u001D u000E_u001D = new \u0008\u001D.\u000E\u001D();
			u000E_u001D.\u001F = \u001F;
			u000E_u001D.\u000A = \u000A;
			u000E_u001D.\u0007 = \u0007;
			if (u000E_u001D.\u000A >= DiRoots.RoomPro.Enums.SortingDirections.North)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0019(List<View>, DiRoots.RoomPro.Enums.SortingDirections, bool)).MethodHandle;
				}
				if (u000E_u001D.\u000A < (DiRoots.RoomPro.Enums.SortingDirections)\u001B\u0013\u0007.\u000A(u000E_u001D.\u001F))
				{
					List<View> list = \u000E\u0013\u0007.\u000A(u000E_u001D.\u001F);
					\u0010\u0013\u0007.\u000A(list, new Comparison<View>(u000E_u001D.\u001D));
					if (!u000E_u001D.\u0007)
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
						View view = Enumerable.Last<View>(list);
						\u000D\u0013\u0007.\u000A(list, view);
						\u001C\u0013\u0007.\u000A(list, 0, view);
					}
					return list;
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
			throw \u0008\u0013\u0007.\u000A("Index out of range during sorting.");
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0001B45C File Offset: 0x0001965C
		private static void \u0018(SpatialElement \u001F, View \u000A, CalloutUserSettings \u0007)
		{
			Document u = \u000C\u001D.\u0006;
			int num = 0;
			NamingConfigurationSettings u001F = \u0001\u0016\u0007.\u000A(\u0007);
			List<NamingParameter> list = \u001C\u0016\u0007.\u0007(u001F);
			if (!Enumerable.Any<NamingParameter>(list))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0018(SpatialElement, View, CalloutUserSettings)).MethodHandle;
				}
				return;
			}
			StringBuilder u001F2 = \u001A\u0013\u0007.\u000A();
			List<NamingParameter>.Enumerator enumerator = \u0003\u0016\u0007.\u000A(list);
			try
			{
				while (\u0002\u0016\u0007.\u000A(ref enumerator))
				{
					NamingParameter u001F3 = \u0012\u0016\u0007.\u000A(ref enumerator);
					string u000A = "";
					switch (\u000E\u000F\u0007.\u0007(u001F3))
					{
					case 0:
					{
						Parameter parameter = \u0014\u0013\u0007.\u000A(\u001F, \u0020\u0013\u0007.\u0007(u001F3));
						string text;
						if (parameter == null)
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
							text = \u000F\u0015\u0010.\u001F;
						}
						else
						{
							text = \u0017\u0013\u0007.\u0007(parameter);
						}
						u000A = text;
						break;
					}
					case 1:
					{
						Parameter parameter2 = \u0014\u0013\u0007.\u000A(\u0013\u0013\u0007.\u000A(u), \u0020\u0013\u0007.\u0007(u001F3));
						string text2;
						if (parameter2 == null)
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
							text2 = \u000F\u0015\u0010.\u001F;
						}
						else
						{
							text2 = \u0017\u0013\u0007.\u0007(parameter2);
						}
						u000A = text2;
						break;
					}
					case 2:
						u000A = \u0020\u0013\u0007.\u0007(u001F3);
						break;
					}
					\u001E\u0013\u0007.\u000A(u001F2, u000A);
					num++;
					if (\u001E\u0016\u0007.\u0007(u001F))
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
						if (num < \u000A\u000F\u0007.\u000A(list))
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
							\u001E\u0013\u0007.\u000A(u001F2, \u001B\u0016\u0007.\u0007(u001F));
						}
					}
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
				((IDisposable)enumerator).Dispose();
			}
			string text3 = \u001A\u000C\u000A.\u000A(u001F2);
			if (\u001A\u0006\u0007.\u000A(text3))
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
				return;
			}
			\u0011\u0013\u0007.\u000A(\u000A, text3);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0001B61C File Offset: 0x0001981C
		private static void \u0005(SpatialElement \u001F, List<View> \u000A, SectionAndElevationUserSettings \u0007)
		{
			List<NamingParameter> list = \u001C\u0016\u0007.\u0007(\u0015\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u0007)));
			if (!Enumerable.Any<NamingParameter>(list))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0005(SpatialElement, List<View>, SectionAndElevationUserSettings)).MethodHandle;
				}
				return;
			}
			int num = \u0017\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u0007));
			if (num == 0)
			{
				\u0008\u001D.\u0016(\u001F, \u000A, \u0007, list);
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
			if (num != 1)
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
				return;
			}
			\u0008\u001D.\u000B(\u001F, \u000A, \u0007, list);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0001B6A0 File Offset: 0x000198A0
		private static void \u0016(SpatialElement \u001F, List<View> \u000A, SectionAndElevationUserSettings \u0007, List<NamingParameter> \u001D)
		{
			Document u = \u000C\u001D.\u0006;
			NamingConfigurationSettings u001F = \u0015\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u0007));
			int num = \u0015\u0013\u0007.\u000A(\u0011\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u0007)));
			int num2 = 1;
			int num3 = 0;
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(\u000A);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View u001F2 = \u0019\u0010\u0007.\u000A(ref enumerator);
					StringBuilder u001F3 = \u001A\u0013\u0007.\u000A();
					List<NamingParameter>.Enumerator enumerator2 = \u0003\u0016\u0007.\u000A(\u001D);
					try
					{
						while (\u0002\u0016\u0007.\u000A(ref enumerator2))
						{
							NamingParameter u001F4 = \u0012\u0016\u0007.\u000A(ref enumerator2);
							string u000A = "";
							switch (\u000E\u000F\u0007.\u0007(u001F4))
							{
							case 0:
							{
								Parameter parameter = \u0014\u0013\u0007.\u000A(\u001F, \u0020\u0013\u0007.\u0007(u001F4));
								string text;
								if (parameter == null)
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0016(SpatialElement, List<View>, SectionAndElevationUserSettings, List<NamingParameter>)).MethodHandle;
									}
									text = \u000F\u0015\u0010.\u001F;
								}
								else
								{
									text = \u0017\u0013\u0007.\u0007(parameter);
								}
								u000A = text;
								break;
							}
							case 1:
							{
								Parameter parameter2 = \u0014\u0013\u0007.\u000A(\u0013\u0013\u0007.\u000A(u), \u0020\u0013\u0007.\u0007(u001F4));
								string text2;
								if (parameter2 == null)
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
									text2 = \u000F\u0015\u0010.\u001F;
								}
								else
								{
									text2 = \u0017\u0013\u0007.\u0007(parameter2);
								}
								u000A = text2;
								break;
							}
							case 2:
								u000A = \u0020\u0013\u0007.\u0007(u001F4);
								break;
							case 3:
								u000A = \u000C\u0013\u0007.\u000A(ref num);
								num++;
								break;
							}
							\u001E\u0013\u0007.\u000A(u001F3, u000A);
							num3++;
							if (\u001E\u0016\u0007.\u0007(u001F))
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
								if (num3 < \u000A\u000F\u0007.\u000A(\u001D))
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
									\u001E\u0013\u0007.\u000A(u001F3, \u001B\u0016\u0007.\u0007(u001F));
								}
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
						((IDisposable)enumerator2).Dispose();
					}
					if (\u001A\u0006\u0007.\u000A(\u001A\u000C\u000A.\u000A(u001F3)))
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
						return;
					}
					try
					{
						num3 = 0;
						\u0011\u0013\u0007.\u000A(u001F2, \u001A\u000C\u000A.\u000A(u001F3));
					}
					catch (Exception)
					{
						\u0011\u0013\u0007.\u000A(u001F2, \u001A\u000C\u000A.\u000A(\u001E\u0013\u0007.\u000A(u001F3, \u0017\u0006\u0007.\u000A("({0})", num2))));
						num2++;
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
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0001B928 File Offset: 0x00019B28
		private static void \u000B(SpatialElement \u001F, List<View> \u000A, SectionAndElevationUserSettings \u0007, List<NamingParameter> \u001D)
		{
			Document u = \u000C\u001D.\u0006;
			NamingConfigurationSettings u001F = \u0015\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u0007));
			string text = \u0011\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u0007));
			int num = 1;
			int num2 = 0;
			List<View>.Enumerator enumerator = \u0018\u0010\u0007.\u000A(\u000A);
			try
			{
				while (\u0007\u0010\u0007.\u000A(ref enumerator))
				{
					View u001F2 = \u0019\u0010\u0007.\u000A(ref enumerator);
					StringBuilder u001F3 = \u001A\u0013\u0007.\u000A();
					List<NamingParameter>.Enumerator enumerator2 = \u0003\u0016\u0007.\u000A(\u001D);
					try
					{
						while (\u0002\u0016\u0007.\u000A(ref enumerator2))
						{
							NamingParameter u001F4 = \u0012\u0016\u0007.\u000A(ref enumerator2);
							string u000A = "";
							switch (\u000E\u000F\u0007.\u0007(u001F4))
							{
							case 0:
							{
								Parameter parameter = \u0014\u0013\u0007.\u000A(\u001F, \u0020\u0013\u0007.\u0007(u001F4));
								string text2;
								if (parameter == null)
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
										RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u000B(SpatialElement, List<View>, SectionAndElevationUserSettings, List<NamingParameter>)).MethodHandle;
									}
									text2 = \u000F\u0015\u0010.\u001F;
								}
								else
								{
									text2 = \u0017\u0013\u0007.\u0007(parameter);
								}
								u000A = text2;
								break;
							}
							case 1:
							{
								Parameter parameter2 = \u0014\u0013\u0007.\u000A(\u0013\u0013\u0007.\u000A(u), \u0020\u0013\u0007.\u0007(u001F4));
								string text3;
								if (parameter2 == null)
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
									text3 = \u000F\u0015\u0010.\u001F;
								}
								else
								{
									text3 = \u0017\u0013\u0007.\u0007(parameter2);
								}
								u000A = text3;
								break;
							}
							case 2:
								u000A = \u0020\u0013\u0007.\u0007(u001F4);
								break;
							case 3:
								u000A = text;
								text = \u0008\u001D.\u0002(text);
								break;
							}
							\u001E\u0013\u0007.\u000A(u001F3, u000A);
							num2++;
							if (\u001E\u0016\u0007.\u0007(u001F))
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
								if (num2 < \u000A\u000F\u0007.\u000A(\u001D))
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
									\u001E\u0013\u0007.\u000A(u001F3, \u001B\u0016\u0007.\u0007(u001F));
								}
							}
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
					finally
					{
						((IDisposable)enumerator2).Dispose();
					}
					try
					{
						num2 = 0;
						\u0011\u0013\u0007.\u000A(u001F2, \u001A\u000C\u000A.\u000A(u001F3));
					}
					catch (Exception)
					{
						\u0011\u0013\u0007.\u000A(u001F2, \u001A\u000C\u000A.\u000A(\u001E\u0013\u0007.\u000A(u001F3, \u0017\u0006\u0007.\u000A("({0})", num))));
						num++;
					}
				}
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
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0001BB88 File Offset: 0x00019D88
		private static string \u0002(string \u001F)
		{
			List<string> list = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list, "a");
			\u001A\u0008\u0007.\u000A(list, "b");
			\u001A\u0008\u0007.\u000A(list, "c");
			\u001A\u0008\u0007.\u000A(list, "d");
			\u001A\u0008\u0007.\u000A(list, "e");
			\u001A\u0008\u0007.\u000A(list, "f");
			\u001A\u0008\u0007.\u000A(list, "g");
			\u001A\u0008\u0007.\u000A(list, "h");
			\u001A\u0008\u0007.\u000A(list, "i");
			\u001A\u0008\u0007.\u000A(list, "j");
			\u001A\u0008\u0007.\u000A(list, "k");
			\u001A\u0008\u0007.\u000A(list, "l");
			\u001A\u0008\u0007.\u000A(list, "m");
			\u001A\u0008\u0007.\u000A(list, "n");
			\u001A\u0008\u0007.\u000A(list, "o");
			\u001A\u0008\u0007.\u000A(list, "p");
			\u001A\u0008\u0007.\u000A(list, "q");
			\u001A\u0008\u0007.\u000A(list, "r");
			\u001A\u0008\u0007.\u000A(list, "s");
			\u001A\u0008\u0007.\u000A(list, "t");
			\u001A\u0008\u0007.\u000A(list, "u");
			\u001A\u0008\u0007.\u000A(list, "v");
			\u001A\u0008\u0007.\u000A(list, "w");
			\u001A\u0008\u0007.\u000A(list, "x");
			\u001A\u0008\u0007.\u000A(list, "y");
			\u001A\u0008\u0007.\u000A(list, "z");
			\u001A\u0008\u0007.\u000A(list, "aa");
			\u001A\u0008\u0007.\u000A(list, "ab");
			\u001A\u0008\u0007.\u000A(list, "ac");
			\u001A\u0008\u0007.\u000A(list, "ad");
			\u001A\u0008\u0007.\u000A(list, "ae");
			\u001A\u0008\u0007.\u000A(list, "af");
			\u001A\u0008\u0007.\u000A(list, "ag");
			\u001A\u0008\u0007.\u000A(list, "ah");
			\u001A\u0008\u0007.\u000A(list, "ai");
			\u001A\u0008\u0007.\u000A(list, "aj");
			\u001A\u0008\u0007.\u000A(list, "ak");
			\u001A\u0008\u0007.\u000A(list, "al");
			\u001A\u0008\u0007.\u000A(list, "am");
			\u001A\u0008\u0007.\u000A(list, "an");
			\u001A\u0008\u0007.\u000A(list, "ao");
			\u001A\u0008\u0007.\u000A(list, "ap");
			\u001A\u0008\u0007.\u000A(list, "aq");
			\u001A\u0008\u0007.\u000A(list, "ar");
			\u001A\u0008\u0007.\u000A(list, "as");
			\u001A\u0008\u0007.\u000A(list, "at");
			\u001A\u0008\u0007.\u000A(list, "au");
			\u001A\u0008\u0007.\u000A(list, "av");
			\u001A\u0008\u0007.\u000A(list, "aw");
			\u001A\u0008\u0007.\u000A(list, "ax");
			\u001A\u0008\u0007.\u000A(list, "ay");
			\u001A\u0008\u0007.\u000A(list, "az");
			\u001A\u0008\u0007.\u000A(list, "ba");
			\u001A\u0008\u0007.\u000A(list, "bb");
			\u001A\u0008\u0007.\u000A(list, "bc");
			\u001A\u0008\u0007.\u000A(list, "bd");
			\u001A\u0008\u0007.\u000A(list, "be");
			\u001A\u0008\u0007.\u000A(list, "bf");
			\u001A\u0008\u0007.\u000A(list, "bg");
			\u001A\u0008\u0007.\u000A(list, "bh");
			\u001A\u0008\u0007.\u000A(list, "bi");
			\u001A\u0008\u0007.\u000A(list, "bj");
			\u001A\u0008\u0007.\u000A(list, "bk");
			\u001A\u0008\u0007.\u000A(list, "bl");
			\u001A\u0008\u0007.\u000A(list, "bm");
			\u001A\u0008\u0007.\u000A(list, "bn");
			\u001A\u0008\u0007.\u000A(list, "bo");
			\u001A\u0008\u0007.\u000A(list, "bp");
			\u001A\u0008\u0007.\u000A(list, "bq");
			\u001A\u0008\u0007.\u000A(list, "br");
			\u001A\u0008\u0007.\u000A(list, "bs");
			\u001A\u0008\u0007.\u000A(list, "bt");
			\u001A\u0008\u0007.\u000A(list, "bu");
			\u001A\u0008\u0007.\u000A(list, "bv");
			\u001A\u0008\u0007.\u000A(list, "bw");
			\u001A\u0008\u0007.\u000A(list, "bfx");
			\u001A\u0008\u0007.\u000A(list, "by");
			\u001A\u0008\u0007.\u000A(list, "bz");
			List<string> list2 = \u0014\u000D\u0007.\u000A();
			\u001A\u0008\u0007.\u000A(list2, "A");
			\u001A\u0008\u0007.\u000A(list2, "B");
			\u001A\u0008\u0007.\u000A(list2, "C");
			\u001A\u0008\u0007.\u000A(list2, "D");
			\u001A\u0008\u0007.\u000A(list2, "E");
			\u001A\u0008\u0007.\u000A(list2, "F");
			\u001A\u0008\u0007.\u000A(list2, "G");
			\u001A\u0008\u0007.\u000A(list2, "H");
			\u001A\u0008\u0007.\u000A(list2, "I");
			\u001A\u0008\u0007.\u000A(list2, "J");
			\u001A\u0008\u0007.\u000A(list2, "K");
			\u001A\u0008\u0007.\u000A(list2, "L");
			\u001A\u0008\u0007.\u000A(list2, "M");
			\u001A\u0008\u0007.\u000A(list2, "N");
			\u001A\u0008\u0007.\u000A(list2, "O");
			\u001A\u0008\u0007.\u000A(list2, "P");
			\u001A\u0008\u0007.\u000A(list2, "Q");
			\u001A\u0008\u0007.\u000A(list2, "R");
			\u001A\u0008\u0007.\u000A(list2, "S");
			\u001A\u0008\u0007.\u000A(list2, "T");
			\u001A\u0008\u0007.\u000A(list2, "U");
			\u001A\u0008\u0007.\u000A(list2, "V");
			\u001A\u0008\u0007.\u000A(list2, "W");
			\u001A\u0008\u0007.\u000A(list2, "X");
			\u001A\u0008\u0007.\u000A(list2, "Y");
			\u001A\u0008\u0007.\u000A(list2, "Z");
			\u001A\u0008\u0007.\u000A(list2, "AA");
			\u001A\u0008\u0007.\u000A(list2, "AB");
			\u001A\u0008\u0007.\u000A(list2, "AC");
			\u001A\u0008\u0007.\u000A(list2, "AD");
			\u001A\u0008\u0007.\u000A(list2, "AE");
			\u001A\u0008\u0007.\u000A(list2, "AF");
			\u001A\u0008\u0007.\u000A(list2, "AG");
			\u001A\u0008\u0007.\u000A(list2, "AH");
			\u001A\u0008\u0007.\u000A(list2, "AI");
			\u001A\u0008\u0007.\u000A(list2, "AJ");
			\u001A\u0008\u0007.\u000A(list2, "AK");
			\u001A\u0008\u0007.\u000A(list2, "AL");
			\u001A\u0008\u0007.\u000A(list2, "AM");
			\u001A\u0008\u0007.\u000A(list2, "AN");
			\u001A\u0008\u0007.\u000A(list2, "AO");
			\u001A\u0008\u0007.\u000A(list2, "AP");
			\u001A\u0008\u0007.\u000A(list2, "AQ");
			\u001A\u0008\u0007.\u000A(list2, "AR");
			\u001A\u0008\u0007.\u000A(list2, "AS");
			\u001A\u0008\u0007.\u000A(list2, "AT");
			\u001A\u0008\u0007.\u000A(list2, "AU");
			\u001A\u0008\u0007.\u000A(list2, "AV");
			\u001A\u0008\u0007.\u000A(list2, "AW");
			\u001A\u0008\u0007.\u000A(list2, "AX");
			\u001A\u0008\u0007.\u000A(list2, "AY");
			\u001A\u0008\u0007.\u000A(list2, "AZ");
			\u001A\u0008\u0007.\u000A(list2, "BA");
			\u001A\u0008\u0007.\u000A(list2, "BB");
			\u001A\u0008\u0007.\u000A(list2, "BC");
			\u001A\u0008\u0007.\u000A(list2, "BD");
			\u001A\u0008\u0007.\u000A(list2, "BE");
			\u001A\u0008\u0007.\u000A(list2, "BF");
			\u001A\u0008\u0007.\u000A(list2, "BG");
			\u001A\u0008\u0007.\u000A(list2, "BH");
			\u001A\u0008\u0007.\u000A(list2, "BI");
			\u001A\u0008\u0007.\u000A(list2, "BJ");
			\u001A\u0008\u0007.\u000A(list2, "BK");
			\u001A\u0008\u0007.\u000A(list2, "BL");
			\u001A\u0008\u0007.\u000A(list2, "BM");
			\u001A\u0008\u0007.\u000A(list2, "BN");
			\u001A\u0008\u0007.\u000A(list2, "BO");
			\u001A\u0008\u0007.\u000A(list2, "BP");
			\u001A\u0008\u0007.\u000A(list2, "BQ");
			\u001A\u0008\u0007.\u000A(list2, "BR");
			\u001A\u0008\u0007.\u000A(list2, "BS");
			\u001A\u0008\u0007.\u000A(list2, "BT");
			\u001A\u0008\u0007.\u000A(list2, "BU");
			\u001A\u0008\u0007.\u000A(list2, "BV");
			\u001A\u0008\u0007.\u000A(list2, "BW");
			\u001A\u0008\u0007.\u000A(list2, "BX");
			\u001A\u0008\u0007.\u000A(list2, "BY");
			\u001A\u0008\u0007.\u000A(list2, "BZ");
			List<string> list3 = list2;
			List<string> u001F = list;
			if (\u001F\u001A\u0007.\u000A(\u001E\u001E\u0007.\u001D(\u001F, 0)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0002(string)).MethodHandle;
				}
				u001F = list3;
			}
			int num = \u0009\u0013\u0007.\u000A(u001F, \u001F);
			num++;
			return \u0001\u0013\u0007.\u000A(u001F, num);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0001C298 File Offset: 0x0001A498
		private static bool \u0006(Document \u001F, ElementId \u000A, SpatialElement \u0007, double \u001D = 0.0, Transform \u0004 = null)
		{
			List<Line> u001F = \u0008\u001D.\u0010(\u0007, \u0004);
			ViewCropRegionShapeManager u001F2 = \u000A\u001A\u0007.\u000A(\u001F, \u000A);
			CurveLoop u000A = \u0008\u001D.\u000F(u001F, \u001D);
			try
			{
				\u0020\u0018\u0007.\u000A(u001F2, u000A);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0001C2E4 File Offset: 0x0001A4E4
		private static CurveLoop \u000F(List<Line> \u001F, double \u000A)
		{
			return \u0007\u001A\u0007.\u000A(\u0017\u0018\u0007.\u000A(Enumerable.ToList<Curve>(Enumerable.Cast<Curve>(\u001F))), \u000A, \u0007\u0018\u0007.\u000A());
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0001C318 File Offset: 0x0001A518
		private static bool \u0012(View \u001F, SpatialElement \u000A, double \u0007 = 0.0, Transform \u001D = null)
		{
			List<Line> u001F = \u0008\u001D.\u0010(\u000A, \u001D);
			ViewCropRegionShapeManager u001F2 = \u0013\u0018\u0007.\u000A(\u001F);
			try
			{
				CurveLoop u000A = \u0008\u001D.\u000F(u001F, \u0007);
				\u0020\u0018\u0007.\u000A(u001F2, u000A);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0001C364 File Offset: 0x0001A564
		private static List<Solid> \u0003(Element \u001F)
		{
			List<Solid> list = \u0002\u001A\u0007.\u000A();
			Options options = \u000B\u001A\u0007.\u000A();
			\u0016\u001A\u0007.\u000A(options, true);
			IEnumerator<GeometryObject> enumerator = \u0018\u001A\u0007.\u000A(\u0005\u001A\u0007.\u000A(\u001F, options));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					GeometryObject u001F = \u0019\u001A\u0007.\u000A(enumerator);
					Solid solid = \u0014\u001F\u000E.\u001F(u001F);
					if (solid != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0003(Element)).MethodHandle;
						}
						if (\u0004\u001A\u0007.\u000A(solid) > 0.0)
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
							\u001D\u001A\u0007.\u000A(list, solid);
							continue;
						}
					}
					GeometryInstance geometryInstance = \u0013\u001F\u000E.\u001F(u001F);
					if (geometryInstance != null)
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
						\u0008\u001D.\u001C(list, geometryInstance);
					}
				}
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list;
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0001C44C File Offset: 0x0001A64C
		private static void \u001C(List<Solid> \u001F, GeometryInstance \u000A)
		{
			IEnumerator<GeometryObject> enumerator = \u0018\u001A\u0007.\u000A(\u0006\u001A\u0007.\u000A(\u000A));
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					Solid solid = \u0014\u001F\u000E.\u001F(\u0019\u001A\u0007.\u000A(enumerator));
					if (solid != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u001C(List<Solid>, GeometryInstance)).MethodHandle;
						}
						if (\u0004\u001A\u0007.\u000A(solid) > 0.0)
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
							\u001D\u001A\u0007.\u000A(\u001F, solid);
						}
					}
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0001C4F0 File Offset: 0x0001A6F0
		private static PlanarFace \u000D(Solid \u001F)
		{
			IEnumerator u001F = \u000F\u001A\u0007.\u000A(\u0012\u001A\u0007.\u0007(\u001F));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F))
				{
					PlanarFace planarFace = \u0017\u001F\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F));
					if (\u0003\u000A\u0007.\u000A(\u000E\u001F\u0007.\u000A(planarFace)) == 1.0)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u000D(Solid)).MethodHandle;
						}
						return planarFace;
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
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			return null;
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0001C598 File Offset: 0x0001A798
		internal static List<Line> \u0010(Element \u001F, Transform \u000A = null)
		{
			object u001F = \u0008\u001D.\u0003(\u001F);
			Predicate<Solid> u000A;
			if ((u000A = \u0008\u001D.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0010(Element, Transform)).MethodHandle;
				}
				u000A = (\u0008\u001D.<>c.\u000A = new Predicate<Solid>(\u0008\u001D.<>c.\u001F.\u0007));
			}
			return \u0008\u001D.\u000E(\u0008\u001D.\u000D(\u0003\u001A\u0007.\u000A(u001F, u000A)), \u000A);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0001C5F8 File Offset: 0x0001A7F8
		private static List<Line> \u000E(Face \u001F, Transform \u000A)
		{
			\u0008\u001D.\u0010\u001D u0010_u001D = new \u0008\u001D.\u0010\u001D();
			u0010_u001D.\u001F = \u000A;
			List<Line> u001F = \u0003\u001D\u0007.\u000A();
			IEnumerator u001F2 = \u0010\u001A\u0007.\u000A(\u000E\u001A\u0007.\u000A(\u001F));
			try
			{
				while (\u000A\u0017\u000A.\u000A(u001F2))
				{
					IEnumerator u001F3 = \u000D\u001A\u0007.\u000A(\u001E\u001F\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F2)));
					try
					{
						while (\u000A\u0017\u000A.\u000A(u001F3))
						{
							Curve u001F4 = \u001C\u001A\u0007.\u000A(\u0020\u001F\u000E.\u001F(\u0003\u0013\u000A.\u000A(u001F3)));
							if (\u000D\u0009\u0010.\u001F(u001F4) != null)
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u000E(Face, Transform)).MethodHandle;
								}
								\u000B\u0007\u0007.\u000A(u001F, \u000D\u0009\u0010.\u001F(u001F4));
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
						IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F3);
						if (disposable != null)
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
							\u001F\u0017\u000A.\u000A(disposable);
						}
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
				IDisposable disposable = \u000E\u0015\u0010.\u001F(u001F2);
				if (disposable != null)
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
					\u001F\u0017\u000A.\u000A(disposable);
				}
			}
			List<XYZ> list = u001F.\u0007();
			if (u0010_u001D.\u001F != null)
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
				list = Enumerable.ToList<XYZ>(Enumerable.Select<XYZ, XYZ>(list, new Func<XYZ, XYZ>(u0010_u001D.\u000A)));
			}
			return new \u0011\u000A(\u0012\u000A.\u000A(list)).\u0006;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0001C768 File Offset: 0x0001A968
		private static bool \u0008(Document \u001F, ElementId \u000A)
		{
			bool result = false;
			ElevationMarker u001F = \u0004\u0018\u0007.\u000A(\u001F, \u000A, \u001B\u001F\u0007.\u000A(0.0, 0.0, 0.0), 10);
			if (\u0008\u001A\u0007.\u000A(u001F) == 1)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u0008(Document, ElementId)).MethodHandle;
				}
				result = true;
			}
			\u0011\u0001\u000A.\u000A(\u001F, \u0002\u001E\u000A.\u0007(u001F));
			return result;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0001C7D8 File Offset: 0x0001A9D8
		internal static SectionData \u001B(SpatialElement \u001F, SectionAndElevationUserSettings \u000A, Transform \u0007)
		{
			SectionData sectionData = \u0009\u001A\u0007.\u000A();
			\u0001\u001A\u0007.\u000A(sectionData, \u001F.\u0005(\u000C\u001E\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)), 0, \u0007));
			\u000C\u001A\u0007.\u000A(sectionData, \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(\u0015\u001A\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)))));
			\u0013\u001A\u0007.\u000A(sectionData, \u001E\u0001\u000A.\u000A(\u0018\u0018\u0007.\u0007(\u001A\u001A\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)))));
			\u0006\u0017\u0007.\u000A(sectionData, \u000B\u0020\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0009\u0020\u0007.\u000A(sectionData, \u000C\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u000A\u0017\u0007.\u000A(sectionData, \u0015\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0015\u0020\u0007.\u000A(sectionData, \u0013\u0004\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u001D\u0017\u0007.\u000A(sectionData, \u001B\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u001A\u0020\u0007.\u000A(sectionData, \u000E\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0010\u0017\u0007.\u000A(sectionData, \u0008\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0012\u0017\u0007.\u000A(sectionData, \u0006\u0013\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0003\u0017\u0007.\u000A(sectionData, \u0005\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0014\u001A\u0007.\u000A(sectionData, \u0010\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u001C\u0017\u0007.\u000A(sectionData, \u0010\u0018\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u000B\u0017\u0007.\u000A(sectionData, \u0005\u0020\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0005\u0017\u0007.\u000A(sectionData, \u0019\u0020\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0019\u0017\u0007.\u000A(sectionData, \u001D\u0020\u0007.\u000A(\u0019\u001E\u0007.\u000A(\u000A)));
			\u0017\u001A\u0007.\u000A(sectionData, (DiRoots.SpatialElementViews.Enums.SortingDirections)\u0013\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u000A)));
			\u0020\u001A\u0007.\u000A(sectionData, \u000C\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u000A)));
			\u001E\u001A\u0007.\u000A(sectionData, \u000C\u0011\u0007.\u000A(\u001D\u001E\u0007.\u000A(\u000A)) == 0);
			SectionData sectionData2 = sectionData;
			if (\u0008\u0013\u000A.\u000A(\u0005\u0020\u0007.\u000A(sectionData2), \u0011\u001A\u0007.\u000A()))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u001B(SpatialElement, SectionAndElevationUserSettings, Transform)).MethodHandle;
				}
				\u001B\u001A\u0007.\u000A(sectionData2, \u0019\u0020\u0007.\u000A(sectionData2));
			}
			else
			{
				BoundingBoxXYZ u001F = \u0002\u0004\u0007.\u000A(\u001F, \u0011\u001F\u000E.\u001F);
				\u001B\u001A\u0007.\u000A(sectionData2, \u0003\u000A\u0007.\u000A(\u0016\u0004\u0007.\u000A(u001F)) - \u0003\u000A\u0007.\u000A(\u000B\u0004\u0007.\u000A(u001F)) + \u001D\u0020\u0007.\u000A(sectionData2));
			}
			return sectionData2;
		}

		// Token: 0x04000199 RID: 409
		[CompilerGenerated]
		private static List<ViewsReport> \u001F;

		// Token: 0x020007B0 RID: 1968
		[CompilerGenerated]
		private sealed class \u0010\u001D
		{
			// Token: 0x06004C08 RID: 19464 RVA: 0x001DB750 File Offset: 0x001D9950
			internal XYZ \u000A(XYZ \u001F)
			{
				return \u0007\u0013\u0007.\u000A(this.\u001F, \u001F);
			}

			// Token: 0x04001F2C RID: 7980
			public Transform \u001F;
		}

		// Token: 0x020007B1 RID: 1969
		[CompilerGenerated]
		private sealed class \u000E\u001D
		{
			// Token: 0x06004C0A RID: 19466 RVA: 0x001DB780 File Offset: 0x001D9980
			internal int \u001D(View \u001F, View \u000A)
			{
				int u000A = (\u0014\u0001\u000D.\u000A(this.\u001F, \u001F) - (int)this.\u000A + \u001B\u0013\u0007.\u000A(this.\u001F)) % \u001B\u0013\u0007.\u000A(this.\u001F);
				int u000A2 = (\u0014\u0001\u000D.\u000A(this.\u001F, \u000A) - (int)this.\u000A + \u001B\u0013\u0007.\u000A(this.\u001F)) % \u001B\u0013\u0007.\u000A(this.\u001F);
				if (!this.\u0007)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0008\u001D.\u000E\u001D.\u001D(View, View)).MethodHandle;
					}
					return \u001C\u0014\u0007.\u000A(ref u000A2, u000A);
				}
				return \u001C\u0014\u0007.\u000A(ref u000A, u000A2);
			}

			// Token: 0x04001F2D RID: 7981
			public List<View> \u001F;

			// Token: 0x04001F2E RID: 7982
			public DiRoots.RoomPro.Enums.SortingDirections \u000A;

			// Token: 0x04001F2F RID: 7983
			public bool \u0007;
		}
	}
}
