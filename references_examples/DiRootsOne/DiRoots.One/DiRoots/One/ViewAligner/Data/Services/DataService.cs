using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using A;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DiRoots.One.Commons.Models;
using DiRoots.One.Commons.TreeGrid;
using DiRoots.One.ViewAligner.Data.Models;
using DiRoots.One.ViewAligner.Interfaces;
using DiRoots.Revit.DataCollectors;

namespace DiRoots.One.ViewAligner.Data.Services
{
	// Token: 0x020000D1 RID: 209
	public class DataService : IDataService
	{
		// Token: 0x060007EA RID: 2026 RVA: 0x0002D830 File Offset: 0x0002BA30
		public DataService(DocumentContext context, IProjectBrowserServiceForSheets projectBrowserService)
		{
			this.\u001F = context;
			this.\u000A = projectBrowserService;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x0002D854 File Offset: 0x0002BA54
		public List<ViewInfo> GetSheets()
		{
			DataService.\u001C\u0019 u001C_u = new DataService.\u001C\u0019();
			u001C_u.\u001F = \u0016\u0010\u001D.\u000A(this.\u001F);
			object u001F = u001C_u.\u001F.CollectElements(null);
			List<ViewInfo> list = \u0013\u0008\u001D.\u000A();
			IEnumerator<ViewSheet> enumerator = \u0014\u0008\u001D.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					DataService.\u000D\u0019 u000D_u = new DataService.\u000D\u0019();
					u000D_u.\u000A = u001C_u;
					u000D_u.\u001F = \u0017\u0008\u001D.\u000A(enumerator);
					ViewInfo viewInfo = \u000E\u0019.\u001F(u000D_u.\u001F);
					\u001E\u0008\u001D.\u000A(viewInfo, \u0020\u0008\u001D.\u000A(u000D_u.\u001F));
					List<ViewInfo> list2 = Enumerable.ToList<ViewInfo>(Enumerable.Select<Viewport, ViewInfo>(\u0011\u0008\u001D.\u000A(u000D_u.\u001F), new Func<Viewport, ViewInfo>(u000D_u.\u0007)));
					List<ViewInfo> u000A = Enumerable.ToList<ViewInfo>(Enumerable.Select<ScheduleSheetInstance, ViewInfo>(\u001B\u0008\u001D.\u000A(u000D_u.\u001F), new Func<ScheduleSheetInstance, ViewInfo>(u000D_u.\u001D)));
					\u0008\u0008\u001D.\u000A(list2, u000A);
					object u001F2 = list2;
					Func<ViewInfo, string> u001F3;
					if ((u001F3 = DataService.<>c.\u000A) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DataService.GetSheets()).MethodHandle;
						}
						u001F3 = (DataService.<>c.\u000A = new Func<ViewInfo, string>(DataService.<>c.\u001F.\u0004));
					}
					\u0003\u0008\u001D.\u000A(u001F2, \u001C\u0008\u001D.\u000A(u001F3, true));
					\u000E\u0008\u001D.\u000A(viewInfo, list2);
					if (\u0010\u0008\u001D.\u000A(\u0015\u0012\u001D.\u0007(viewInfo)) > 0)
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
						\u000D\u0008\u001D.\u000A(list, viewInfo);
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
			object u001F4 = list;
			Func<ViewInfo, string> u001F5;
			if ((u001F5 = DataService.<>c.\u0007) == null)
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
				u001F5 = (DataService.<>c.\u0007 = new Func<ViewInfo, string>(DataService.<>c.\u001F.\u0019));
			}
			\u0003\u0008\u001D.\u000A(u001F4, \u001C\u0008\u001D.\u000A(u001F5, true));
			return list;
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0002DA28 File Offset: 0x0002BC28
		public List<ViewInfo> GetSheetsByBrowserOrganization(List<ViewInfo> views)
		{
			IEnumerable<ViewSheet> u000A = \u0016\u0010\u001D.\u000A(this.\u001F).CollectElements(null);
			List<ViewInfo> list = \u0007\u001B\u001D.\u000A(\u001D\u001B\u001D.\u000A(\u0004\u001B\u001D.\u000A(this.\u000A, u000A)));
			List<ViewInfo>.Enumerator enumerator = \u000A\u001B\u001D.\u000A(Enumerable.ToList<ViewInfo>(Enumerable.Cast<ViewInfo>(\u0017\u0003\u001D.\u000A(Enumerable.Cast<ITreeItem>(list)))));
			try
			{
				while (\u001A\u0008\u001D.\u000A(ref enumerator))
				{
					DataService.\u0010\u0019 u0010_u = new DataService.\u0010\u0019();
					u0010_u.\u001F = \u001F\u001B\u001D.\u000A(ref enumerator);
					ViewInfo viewInfo = \u0009\u0008\u001D.\u000A(views, new Predicate<ViewInfo>(u0010_u.\u000A));
					if (viewInfo != null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DataService.GetSheetsByBrowserOrganization(List<ViewInfo>)).MethodHandle;
						}
						\u000E\u0008\u001D.\u000A(u0010_u.\u001F, \u0015\u0012\u001D.\u0007(viewInfo));
					}
					else if (\u0001\u0008\u001D.\u000A(list, u0010_u.\u001F))
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
						\u000C\u0008\u001D.\u000A(list, u0010_u.\u001F);
					}
					else
					{
						ViewInfo viewInfo2 = \u001B\u001D\u000E.\u001F(\u0015\u0008\u001D.\u000A(u0010_u.\u001F));
						if (viewInfo2 != null)
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
							\u000C\u0008\u001D.\u000A(list, viewInfo2);
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
				((IDisposable)enumerator).Dispose();
			}
			return list;
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0002DB80 File Offset: 0x0002BD80
		public List<ViewSetInfo> GetViewSets()
		{
			object u001F = \u0016\u0010\u001D.\u000A(this.\u001F).CollectElements(null);
			List<ViewSetInfo> list = \u001C\u001B\u001D.\u000A();
			ViewSetInfo viewSetInfo = \u0002\u001B\u001D.\u000A();
			\u000B\u001B\u001D.\u000A(viewSetInfo, -1L);
			\u0016\u001B\u001D.\u000A(viewSetInfo, \u001E\u0012\u001D.\u000A());
			\u0012\u001B\u001D.\u000A(viewSetInfo, new bool?(false));
			\u0003\u001B\u001D.\u000A(viewSetInfo, true);
			\u0019\u001B\u001D.\u000A(list, viewSetInfo);
			ViewSetInfo viewSetInfo2 = \u0002\u001B\u001D.\u000A();
			\u000B\u001B\u001D.\u000A(viewSetInfo2, -2L);
			\u0016\u001B\u001D.\u000A(viewSetInfo2, \u001B\u0012\u001D.\u000A());
			\u0012\u001B\u001D.\u000A(viewSetInfo2, new bool?(false));
			\u0019\u001B\u001D.\u000A(list, viewSetInfo2);
			List<ViewSetInfo> list2 = list;
			IEnumerator<ViewSheetSet> enumerator = \u000F\u001B\u001D.\u000A(u001F);
			try
			{
				while (\u000A\u0017\u000A.\u000A(enumerator))
				{
					ViewSheetSet u001F2 = \u0006\u001B\u001D.\u000A(enumerator);
					ViewSetInfo viewSetInfo3 = \u0002\u001B\u001D.\u000A();
					\u000B\u001B\u001D.\u000A(viewSetInfo3, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(u001F2)));
					\u0016\u001B\u001D.\u000A(viewSetInfo3, \u0005\u001E\u000A.\u000A(u001F2));
					IEnumerable<View> enumerable = Enumerable.Cast<View>(\u0005\u001B\u001D.\u000A(u001F2));
					Func<View, long> func;
					if ((func = DataService.<>c.\u001D) == null)
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(DataService.GetViewSets()).MethodHandle;
						}
						func = (DataService.<>c.\u001D = new Func<View, long>(DataService.<>c.\u001F.\u0018));
					}
					\u0018\u001B\u001D.\u000A(viewSetInfo3, Enumerable.ToList<long>(Enumerable.Select<View, long>(enumerable, func)));
					ViewSetInfo u000A = viewSetInfo3;
					\u0019\u001B\u001D.\u000A(list2, u000A);
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
				if (enumerator != null)
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
					\u001F\u0017\u000A.\u000A(enumerator);
				}
			}
			return list2;
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x0002DCEC File Offset: 0x0002BEEC
		public bool IsSimilarViews(ViewInfo source, ViewInfo target)
		{
			bool flag;
			if (source == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataService.IsSimilarViews(ViewInfo, ViewInfo)).MethodHandle;
				}
				flag = (null != null);
			}
			else
			{
				flag = (\u0010\u001B\u001D.\u001D(source) != null);
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
				bool flag2;
				if (target == null)
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
					flag2 = (null != null);
				}
				else
				{
					flag2 = (\u0010\u001B\u001D.\u001D(target) != null);
				}
				if (!flag2)
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
					int num = \u000D\u001B\u001D.\u0007(\u0010\u001B\u001D.\u0007(source));
					int num2 = \u000D\u001B\u001D.\u0007(\u0010\u001B\u001D.\u0007(target));
					bool flag3 = \u0018\u0019.\u000A(num);
					bool flag4 = \u0018\u0019.\u000A(num2);
					if (flag3 && flag4)
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
						return true;
					}
					bool flag5 = \u0018\u0019.\u0007(num);
					bool flag6 = \u0018\u0019.\u0007(num2);
					if (flag5 && flag6)
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
						return \u000A\u0008\u001D.\u0007(source) == \u000A\u0008\u001D.\u0007(target);
					}
					if (num == num2)
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
						return \u000A\u0008\u001D.\u0007(source) == \u000A\u0008\u001D.\u0007(target);
					}
					return false;
				}
			}
			return false;
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x0002DDE4 File Offset: 0x0002BFE4
		public long GetActiveSheetViewId()
		{
			UIDocument uidocument = \u0008\u001B\u001D.\u0007(this.\u001F);
			object u001F;
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataService.GetActiveSheetViewId()).MethodHandle;
				}
				u001F = null;
			}
			else
			{
				u001F = \u000E\u001B\u001D.\u000A(uidocument);
			}
			ViewSheet viewSheet = \u0015\u001D\u000E.\u001F(u001F);
			if (viewSheet != null)
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
				return \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(viewSheet));
			}
			return -1L;
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x0002DE48 File Offset: 0x0002C048
		public string GetSectionBoxName(long viewId)
		{
			string text = string.Empty;
			Element element = \u0011\u0017\u000A.\u0007(\u0016\u0010\u001D.\u000A(this.\u001F), \u001E\u0001\u000A.\u000A(viewId));
			if (element != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(DataService.GetSectionBoxName(long)).MethodHandle;
				}
				Parameter parameter = \u0016\u0018\u0007.\u0007(element, -1012202L);
				ElementId elementId;
				if (parameter == null)
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
					elementId = \u0012\u0015\u0010.\u001F;
				}
				else
				{
					elementId = \u001E\u001B\u001D.\u0007(parameter);
				}
				ElementId elementId2 = elementId;
				if (\u001B\u001B\u001D.\u000A(elementId2, \u0012\u0015\u0010.\u001F))
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
					if (\u001B\u001B\u001D.\u000A(elementId2, \u0011\u001B\u001D.\u000A()))
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
						Element element2 = \u0011\u0017\u000A.\u0007(\u0016\u0010\u001D.\u000A(this.\u001F), elementId2);
						string text2;
						if (element2 == null)
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
							text2 = \u000F\u0015\u0010.\u001F;
						}
						else
						{
							text2 = \u0005\u001E\u000A.\u000A(element2);
						}
						text = text2;
					}
				}
			}
			string result;
			if ((result = text) == null)
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
				result = string.Empty;
			}
			return result;
		}

		// Token: 0x04000329 RID: 809
		private readonly DocumentContext \u001F;

		// Token: 0x0400032A RID: 810
		private readonly IProjectBrowserServiceForSheets \u000A;

		// Token: 0x020007E3 RID: 2019
		[CompilerGenerated]
		private sealed class \u001C\u0019
		{
			// Token: 0x04001FF0 RID: 8176
			public Document \u001F;
		}

		// Token: 0x020007E4 RID: 2020
		[CompilerGenerated]
		private sealed class \u000D\u0019
		{
			// Token: 0x06004D00 RID: 19712 RVA: 0x001DD5B8 File Offset: 0x001DB7B8
			internal ViewInfo \u0007(Viewport \u001F)
			{
				ViewInfo viewInfo = \u000E\u0019.\u001F(this.\u000A.\u001F, \u001F);
				\u001E\u0008\u001D.\u000A(viewInfo, \u0020\u0008\u001D.\u000A(this.\u001F));
				return viewInfo;
			}

			// Token: 0x06004D01 RID: 19713 RVA: 0x001DD5EC File Offset: 0x001DB7EC
			internal ViewInfo \u001D(ScheduleSheetInstance \u001F)
			{
				ViewInfo viewInfo = \u000E\u0019.\u001F(this.\u000A.\u001F, \u001F);
				\u001E\u0008\u001D.\u000A(viewInfo, \u0020\u0008\u001D.\u000A(this.\u001F));
				return viewInfo;
			}

			// Token: 0x04001FF1 RID: 8177
			public ViewSheet \u001F;

			// Token: 0x04001FF2 RID: 8178
			public DataService.\u001C\u0019 \u000A;
		}

		// Token: 0x020007E5 RID: 2021
		[CompilerGenerated]
		private sealed class \u0010\u0019
		{
			// Token: 0x06004D03 RID: 19715 RVA: 0x001DD634 File Offset: 0x001DB834
			internal bool \u000A(ViewInfo \u001F)
			{
				return \u0019\u0003\u001D.\u0007(\u001F) == \u0019\u0003\u001D.\u0007(this.\u001F);
			}

			// Token: 0x04001FF3 RID: 8179
			public ViewInfo \u001F;
		}
	}
}
