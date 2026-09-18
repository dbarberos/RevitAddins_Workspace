using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Autodesk.Revit.DB;
using DiRoots.One.Revit.Extensions;
using DiRoots.One.SheetLink.Models;

namespace A
{
	// Token: 0x02000243 RID: 579
	internal class \u0015\u001C
	{
		// Token: 0x0600171A RID: 5914 RVA: 0x00096FBC File Offset: 0x000951BC
		public \u0015\u001C()
		{
			\u0009\u0010\u0005.\u000A(this, new List<RevitParameter>());
			\u0001\u0010\u0005.\u000A(this, new List<RevitParameter>());
			\u0015\u0010\u0005.\u000A(this, new Dictionary<long, List<RevitParameter>>());
			\u000C\u0010\u0005.\u000A(this, new List<ParamNameGroupUniqueHandler>());
			\u001A\u0010\u0005.\u000A(this, new Dictionary<string, ParamUniqueHandler>());
		}

		// Token: 0x17000655 RID: 1621
		// (get) Token: 0x0600171B RID: 5915 RVA: 0x00097008 File Offset: 0x00095208
		// (set) Token: 0x0600171C RID: 5916 RVA: 0x0009701C File Offset: 0x0009521C
		public List<RevitParameter> Parameters { get; set; }

		// Token: 0x17000656 RID: 1622
		// (get) Token: 0x0600171D RID: 5917 RVA: 0x00097030 File Offset: 0x00095230
		// (set) Token: 0x0600171E RID: 5918 RVA: 0x00097044 File Offset: 0x00095244
		public List<RevitParameter> ListRevitParameterCache { get; set; }

		// Token: 0x17000657 RID: 1623
		// (get) Token: 0x0600171F RID: 5919 RVA: 0x00097058 File Offset: 0x00095258
		// (set) Token: 0x06001720 RID: 5920 RVA: 0x0009706C File Offset: 0x0009526C
		public Dictionary<long, List<RevitParameter>> RevitParameterCache { get; set; }

		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x00097080 File Offset: 0x00095280
		// (set) Token: 0x06001722 RID: 5922 RVA: 0x00097094 File Offset: 0x00095294
		public List<ParamNameGroupUniqueHandler> ParamNameGroups { get; set; }

		// Token: 0x17000659 RID: 1625
		// (get) Token: 0x06001723 RID: 5923 RVA: 0x000970A8 File Offset: 0x000952A8
		// (set) Token: 0x06001724 RID: 5924 RVA: 0x000970BC File Offset: 0x000952BC
		public Dictionary<string, ParamUniqueHandler> ParamUniqueHandlers { get; set; }

		// Token: 0x1700065A RID: 1626
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x000970D0 File Offset: 0x000952D0
		// (set) Token: 0x06001726 RID: 5926 RVA: 0x000970E4 File Offset: 0x000952E4
		public bool ExportByType { get; set; }

		// Token: 0x1700065B RID: 1627
		// (get) Token: 0x06001727 RID: 5927 RVA: 0x000970F8 File Offset: 0x000952F8
		private static List<long> \u0016
		{
			get
			{
				if (\u0015\u001C.\u0018 == null)
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
						RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.get_\u0016()).MethodHandle;
					}
					List<long> list = \u001F\u001B\u0019.\u000A();
					\u0001\u000E\u0019.\u000A(list, -1150351L);
					\u0001\u000E\u0019.\u000A(list, -1139999L);
					\u0001\u000E\u0019.\u000A(list, -1012109L);
					\u0001\u000E\u0019.\u000A(list, -1002051L);
					\u0001\u000E\u0019.\u000A(list, -1001336L);
					\u0001\u000E\u0019.\u000A(list, -1139998L);
					\u0001\u000E\u0019.\u000A(list, -1012106L);
					\u0001\u000E\u0019.\u000A(list, -1002052L);
					\u0001\u000E\u0019.\u000A(list, -1002003L);
					\u0001\u000E\u0019.\u000A(list, -1150333L);
					\u0001\u000E\u0019.\u000A(list, -1150329L);
					\u0001\u000E\u0019.\u000A(list, -1150327L);
					\u0001\u000E\u0019.\u000A(list, -1140097L);
					\u0001\u000E\u0019.\u000A(list, -1139997L);
					\u0001\u000E\u0019.\u000A(list, -1002050L);
					\u0015\u001C.\u0018 = list;
				}
				return \u0015\u001C.\u0018;
			}
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x000971E8 File Offset: 0x000953E8
		internal static Dictionary<long, List<Parameter>> \u000B(Element \u001F, bool \u000A, bool \u0007 = false)
		{
			IEnumerable<Parameter> enumerable = \u0015\u001C.\u0002(\u001F, \u000A, \u0007);
			Func<Parameter, long> func;
			if ((func = \u0015\u001C.<>c.\u000A) == null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u000B(Element, bool, bool)).MethodHandle;
				}
				func = (\u0015\u001C.<>c.\u000A = new Func<Parameter, long>(\u0015\u001C.<>c.\u001F.\u0003));
			}
			IEnumerable<IGrouping<long, Parameter>> enumerable2 = Enumerable.GroupBy<Parameter, long>(enumerable, func);
			Func<IGrouping<long, Parameter>, long> func2;
			if ((func2 = \u0015\u001C.<>c.\u0007) == null)
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
				func2 = (\u0015\u001C.<>c.\u0007 = new Func<IGrouping<long, Parameter>, long>(\u0015\u001C.<>c.\u001F.\u001C));
			}
			Func<IGrouping<long, Parameter>, List<Parameter>> func3;
			if ((func3 = \u0015\u001C.<>c.\u001D) == null)
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
				func3 = (\u0015\u001C.<>c.\u001D = new Func<IGrouping<long, Parameter>, List<Parameter>>(\u0015\u001C.<>c.\u001F.\u000D));
			}
			return Enumerable.ToDictionary<IGrouping<long, Parameter>, long, List<Parameter>>(enumerable2, func2, func3);
		}

		// Token: 0x06001729 RID: 5929 RVA: 0x00097294 File Offset: 0x00095494
		internal static List<Parameter> \u0002(Element \u001F, bool \u000A, bool \u0007 = false)
		{
			List<Parameter> list = \u001C\u0007\u001D.\u000A();
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0002(Element, bool, bool)).MethodHandle;
				}
				if (!\u000A)
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
					\u000D\u0007\u001D.\u000A(list, \u0003\u0007\u001D.\u000A(\u001F, false));
					list = Enumerable.ToList<Parameter>(Enumerable.Distinct<Parameter>(list, new \u000F\u000E()));
				}
				else
				{
					ElementId elementId = \u0004\u0013\u0007.\u000A(\u001F);
					if (\u000B\u001E\u000A.\u000A(elementId) > 0L)
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
						List<Parameter> list2 = \u0003\u0007\u001D.\u000A(\u0011\u0017\u000A.\u0007(\u0008\u0019\u0007.\u000A(\u001F), elementId), false);
						list2 = Enumerable.ToList<Parameter>(Enumerable.Distinct<Parameter>(list2, new \u000F\u000E()));
						list2 = \u0015\u001C.\u000F(list2, \u0007);
						\u000D\u0007\u001D.\u000A(list, list2);
					}
				}
			}
			list = \u0015\u001C.\u0006(list, \u0007);
			IEnumerable<Parameter> enumerable = list;
			Func<Parameter, long> func;
			if ((func = \u0015\u001C.<>c.\u0004) == null)
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
				func = (\u0015\u001C.<>c.\u0004 = new Func<Parameter, long>(\u0015\u001C.<>c.\u001F.\u0010));
			}
			return Enumerable.ToList<Parameter>(Enumerable.OrderBy<Parameter, long>(enumerable, func));
		}

		// Token: 0x0600172A RID: 5930 RVA: 0x00097398 File Offset: 0x00095598
		private static List<Parameter> \u0006(List<Parameter> \u001F, bool \u000A)
		{
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0006(List<Parameter>, bool)).MethodHandle;
				}
				return \u001F;
			}
			List<\u000A\u000D>.Enumerator enumerator = \u001D\u000E\u0005.\u000A(\u000A\u000D.\u0004());
			try
			{
				while (\u001F\u000E\u0005.\u000A(ref enumerator))
				{
					\u0015\u001C.\u0020\u001C u0020_u001C = new \u0015\u001C.\u0020\u001C();
					u0020_u001C.\u001F = \u0007\u000E\u0005.\u000A(ref enumerator);
					if (Enumerable.Count<Parameter>(\u001F, new Func<Parameter, bool>(u0020_u001C.\u000A)) > 1)
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
						if (\u001B\u000A\u001D.\u000A(\u000A\u000E\u0005.\u000A(u0020_u001C.\u001F)) > 0)
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
							\u001F = Enumerable.ToList<Parameter>(Enumerable.Where<Parameter>(\u001F, new Func<Parameter, bool>(u0020_u001C.\u0007)));
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
				((IDisposable)enumerator).Dispose();
			}
			IEnumerable<Parameter> enumerable = \u001F;
			Func<Parameter, bool> func;
			if ((func = \u0015\u001C.<>c.\u0019) == null)
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
				func = (\u0015\u001C.<>c.\u0019 = new Func<Parameter, bool>(\u0015\u001C.<>c.\u001F.\u000E));
			}
			\u001F = Enumerable.ToList<Parameter>(Enumerable.Where<Parameter>(enumerable, func));
			return \u001F;
		}

		// Token: 0x0600172B RID: 5931 RVA: 0x000974BC File Offset: 0x000956BC
		private static List<Parameter> \u000F(List<Parameter> \u001F, bool \u000A)
		{
			if (\u000A)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u000F(List<Parameter>, bool)).MethodHandle;
				}
				return \u001F;
			}
			List<\u000A\u000D>.Enumerator enumerator = \u001D\u000E\u0005.\u000A(\u000A\u000D.\u0004());
			try
			{
				while (\u001F\u000E\u0005.\u000A(ref enumerator))
				{
					\u0015\u001C.\u0017\u001C u0017_u001C = new \u0015\u001C.\u0017\u001C();
					u0017_u001C.\u001F = \u0007\u000E\u0005.\u000A(ref enumerator);
					if (\u0004\u000E\u0005.\u000A(u0017_u001C.\u001F))
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
						\u001F = Enumerable.ToList<Parameter>(Enumerable.Where<Parameter>(\u001F, new Func<Parameter, bool>(u0017_u001C.\u000A)));
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
				((IDisposable)enumerator).Dispose();
			}
			return \u001F;
		}

		// Token: 0x0600172C RID: 5932 RVA: 0x00097578 File Offset: 0x00095778
		public void \u0012(RevitParameter \u001F, List<long> \u000A)
		{
			\u0015\u001C.\u0014\u001C u0014_u001C = new \u0015\u001C.\u0014\u001C();
			u0014_u001C.\u001F = \u000A;
			if (\u0003\u0020\u0018.\u000A(\u0012\u0020\u0018.\u001D(this), \u000F\u0020\u0018.\u0007(\u001F)))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0012(RevitParameter, List<long>)).MethodHandle;
				}
				IEnumerable<KeyValuePair<long, List<long>>> enumerable = Enumerable.Where<KeyValuePair<long, List<long>>>(\u0002\u0020\u0018.\u000A(\u0006\u0020\u0018.\u000A(\u0012\u0020\u0018.\u001D(this), \u000F\u0020\u0018.\u0007(\u001F))), new Func<KeyValuePair<long, List<long>>, bool>(u0014_u001C.\u000A));
				Func<KeyValuePair<long, List<long>>, IEnumerable<long>> func;
				if ((func = \u0015\u001C.<>c.\u0018) == null)
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
					func = (\u0015\u001C.<>c.\u0018 = new Func<KeyValuePair<long, List<long>>, IEnumerable<long>>(\u0015\u001C.<>c.\u001F.\u0008));
				}
				List<long> u000A = Enumerable.ToList<long>(Enumerable.SelectMany<KeyValuePair<long, List<long>>, long>(enumerable, func));
				\u000B\u0020\u0018.\u000A(\u001F, u000A);
				return;
			}
			\u000B\u0020\u0018.\u000A(\u001F, \u001F\u001B\u0019.\u000A());
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x00097640 File Offset: 0x00095840
		public List<Element> \u0005(CategoryCollection \u001F, List<long> \u000A, List<long> \u0007)
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u0017\u000D.\u001A(\u001F, false));
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element element = \u0015\u0010\u0007.\u000A(ref enumerator);
					if (\u001A\u0008\u0019.\u000A(\u000A, \u000B\u001E\u000A.\u000A(\u0002\u001E\u000A.\u0007(element))))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0005(CategoryCollection, List<long>, List<long>)).MethodHandle;
						}
						\u000C\u0017\u0019.\u000A(list, element);
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
			this.\u0005(\u001F, list, \u0007);
			return list;
		}

		// Token: 0x0600172E RID: 5934 RVA: 0x000976E4 File Offset: 0x000958E4
		public List<Element> \u0005(CategoryCollection \u001F, List<string> \u000A, List<long> \u0007)
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u0017\u000D.\u001A(\u001F, false));
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element element = \u0015\u0010\u0007.\u000A(ref enumerator);
					Parameter u001F = \u0016\u0018\u0007.\u0007(element, -1140104L);
					try
					{
						if (\u001F\u0020\u001D.\u000A(\u000A, \u001A\u0014\u0007.\u0007(u001F)))
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
								RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0005(CategoryCollection, List<string>, List<long>)).MethodHandle;
							}
							\u000C\u0017\u0019.\u000A(list, element);
						}
					}
					catch (Exception u000A)
					{
						\u000D\u0011\u000A.\u0007(\u0010\u0011\u000A.\u000A(), u000A, "Y:\\DiRoots.Deploy\\DiRoots.One.822e9f7b-b732-48af-b8bc-5cbad1baaa4a\\src\\DiRoots.One\\SheetLink\\SheetLink.Core\\Models\\Parameter\\Collector\\ParameterCollector.cs", "FillParameterManagerList");
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
				((IDisposable)enumerator).Dispose();
			}
			\u0019\u000E\u0005.\u000A(\u0007, 0, -1140104L);
			this.\u0005(\u001F, list, \u0007);
			return list;
		}

		// Token: 0x0600172F RID: 5935 RVA: 0x000977C8 File Offset: 0x000959C8
		private void \u0005(CategoryCollection \u001F, List<Element> \u000A, List<long> \u0007)
		{
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u000A);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element u001F = \u0015\u0010\u0007.\u000A(ref enumerator);
					List<Parameter> list = \u0015\u001C.\u0002(u001F, false, false);
					List<Parameter> u001F2 = \u001C\u0007\u001D.\u000A();
					List<long>.Enumerator enumerator2 = \u0015\u0013\u0018.\u000A(\u0007);
					try
					{
						while (\u0017\u0013\u0018.\u000A(ref enumerator2))
						{
							\u0015\u001C.\u0013\u001C u0013_u001C = new \u0015\u001C.\u0013\u001C();
							u0013_u001C.\u001F = (int)\u000C\u0013\u0018.\u000A(ref enumerator2);
							Parameter parameter = Enumerable.FirstOrDefault<Parameter>(list, new Func<Parameter, bool>(u0013_u001C.\u000A));
							if (parameter != null)
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
									RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0005(CategoryCollection, List<Element>, List<long>)).MethodHandle;
								}
								\u0003\u0006\u0005.\u000A(u001F2, parameter);
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
						((IDisposable)enumerator2).Dispose();
					}
					this.\u0003(u001F2, \u001F, false);
					list = \u0015\u001C.\u0002(u001F, true, false);
					u001F2 = \u001C\u0007\u001D.\u000A();
					enumerator2 = \u0015\u0013\u0018.\u000A(\u0007);
					try
					{
						while (\u0017\u0013\u0018.\u000A(ref enumerator2))
						{
							\u0015\u001C.\u001A\u001C u001A_u001C = new \u0015\u001C.\u001A\u001C();
							u001A_u001C.\u001F = (int)\u000C\u0013\u0018.\u000A(ref enumerator2);
							Parameter parameter2 = Enumerable.FirstOrDefault<Parameter>(list, new Func<Parameter, bool>(u001A_u001C.\u000A));
							if (parameter2 != null)
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
								\u0003\u0006\u0005.\u000A(u001F2, parameter2);
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
						((IDisposable)enumerator2).Dispose();
					}
					this.\u0003(u001F2, \u001F, true);
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
		}

		// Token: 0x06001730 RID: 5936 RVA: 0x00097990 File Offset: 0x00095B90
		public void \u0005(CategoryCollection \u001F)
		{
			List<Element> list = \u0016\u0016\u0004.\u000A();
			List<Element> list2 = \u0017\u000D.\u001A(\u001F, false);
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(list2);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element u000A = \u0015\u0010\u0007.\u000A(ref enumerator);
					\u000C\u0017\u0019.\u000A(list, u000A);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0005(CategoryCollection)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			this.\u0005(\u001F, list);
			\u0011\u0017\u0019.\u0007(\u001F, list2);
		}

		// Token: 0x06001731 RID: 5937 RVA: 0x00097A18 File Offset: 0x00095C18
		private void \u0005(CategoryCollection \u001F, List<Element> \u000A)
		{
			List<Element>.Enumerator enumerator = \u0001\u0010\u0007.\u000A(\u000A);
			try
			{
				while (\u000C\u0010\u0007.\u000A(ref enumerator))
				{
					Element u001F = \u0015\u0010\u0007.\u000A(ref enumerator);
					List<Parameter> u001F2 = \u0015\u001C.\u0002(u001F, false, false);
					this.\u0003(u001F2, \u001F, false);
					u001F2 = \u0015\u001C.\u0002(u001F, true, false);
					this.\u0003(u001F2, \u001F, true);
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
				if (!true)
				{
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0005(CategoryCollection, List<Element>)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		// Token: 0x06001732 RID: 5938 RVA: 0x00097AA0 File Offset: 0x00095CA0
		public virtual void \u0005(CategoryCollection \u001F, Document \u000A)
		{
			if (RevitParameter.CO(this, \u001F))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0005(CategoryCollection, Document)).MethodHandle;
				}
				return;
			}
			if (\u0014\u0012\u0005.\u001D(\u001F) == null)
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
				Element u001F = \u0017\u000D.\u001F\u000A(\u0013\u000E\u0018.\u0007(\u001F));
				this.\u0003(\u0015\u001C.\u0002(u001F, false, false), \u001F, false);
				this.\u0003(\u0015\u001C.\u0002(u001F, true, false), \u001F, true);
				return;
			}
			if (\u0013\u000E\u0018.\u0007(\u001F) != -2000279L)
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
				if (\u0013\u000E\u0018.\u0007(\u001F) != -2003100L)
				{
					goto IL_1BC;
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
			IEnumerable<View> enumerable = Enumerable.ToList<View>(Enumerable.Cast<View>(\u0008\u0013\u0019.\u000A(\u001F)));
			Func<View, ViewType> func;
			if ((func = \u0015\u001C.<>c.\u0005) == null)
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
				func = (\u0015\u001C.<>c.\u0005 = new Func<View, ViewType>(\u0015\u001C.<>c.\u001F.\u001B));
			}
			IEnumerable<IGrouping<ViewType, View>> enumerable2 = Enumerable.GroupBy<View, ViewType>(enumerable, func);
			Func<IGrouping<ViewType, View>, ViewType> func2;
			if ((func2 = \u0015\u001C.<>c.\u0016) == null)
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
				func2 = (\u0015\u001C.<>c.\u0016 = new Func<IGrouping<ViewType, View>, ViewType>(\u0015\u001C.<>c.\u001F.\u0011));
			}
			Func<IGrouping<ViewType, View>, List<View>> func3;
			if ((func3 = \u0015\u001C.<>c.\u000B) == null)
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
				func3 = (\u0015\u001C.<>c.\u000B = new Func<IGrouping<ViewType, View>, List<View>>(\u0015\u001C.<>c.\u001F.\u001E));
			}
			Dictionary<ViewType, List<View>>.Enumerator enumerator = \u0003\u000E\u0005.\u000A(Enumerable.ToDictionary<IGrouping<ViewType, View>, ViewType, List<View>>(enumerable2, func2, func3));
			try
			{
				while (\u0006\u000E\u0005.\u000A(ref enumerator))
				{
					KeyValuePair<ViewType, List<View>> keyValuePair = \u0012\u000E\u0005.\u000A(ref enumerator);
					Element element = Enumerable.FirstOrDefault<View>(\u000F\u000E\u0005.\u000A(ref keyValuePair));
					if (element != null)
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
						this.\u0003(\u0015\u001C.\u0002(element, false, false), \u001F, false);
						this.\u0003(\u0015\u001C.\u0002(element, true, false), \u001F, true);
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
				return;
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			IL_1BC:
			IEnumerable<Element> enumerable3 = \u0008\u0013\u0019.\u000A(\u001F);
			Func<Element, ElementId> func4;
			if ((func4 = \u0015\u001C.<>c.\u0002) == null)
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
				func4 = (\u0015\u001C.<>c.\u0002 = new Func<Element, ElementId>(\u0015\u001C.<>c.\u001F.\u0020));
			}
			IEnumerable<IGrouping<ElementId, Element>> enumerable4 = Enumerable.GroupBy<Element, ElementId>(enumerable3, func4);
			Func<IGrouping<ElementId, Element>, ElementId> func5;
			if ((func5 = \u0015\u001C.<>c.\u0006) == null)
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
				func5 = (\u0015\u001C.<>c.\u0006 = new Func<IGrouping<ElementId, Element>, ElementId>(\u0015\u001C.<>c.\u001F.\u0017));
			}
			Func<IGrouping<ElementId, Element>, List<Element>> func6;
			if ((func6 = \u0015\u001C.<>c.\u000F) == null)
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
				func6 = (\u0015\u001C.<>c.\u000F = new Func<IGrouping<ElementId, Element>, List<Element>>(\u0015\u001C.<>c.\u001F.\u0014));
			}
			Dictionary<ElementId, List<Element>>.Enumerator enumerator2 = \u0002\u000E\u0005.\u000A(Enumerable.ToDictionary<IGrouping<ElementId, Element>, ElementId, List<Element>>(enumerable4, func5, func6));
			try
			{
				while (\u0018\u000E\u0005.\u000A(ref enumerator2))
				{
					KeyValuePair<ElementId, List<Element>> keyValuePair2 = \u000B\u000E\u0005.\u000A(ref enumerator2);
					IEnumerable<Element> enumerable5 = \u0005\u000E\u0005.\u000A(ref keyValuePair2);
					Func<Element, string> func7;
					if ((func7 = \u0015\u001C.<>c.\u0012) == null)
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
						func7 = (\u0015\u001C.<>c.\u0012 = new Func<Element, string>(\u0015\u001C.<>c.\u001F.\u0013));
					}
					List<string> list = Enumerable.ToList<string>(Enumerable.Select<Element, string>(enumerable5, func7));
					if (\u0011\u0016\u001D.\u000A(\u0016\u000E\u0005.\u000A(ref keyValuePair2), Constants.InvalidElementId))
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
						List<string> list2 = \u0014\u000D\u0007.\u000A();
						\u001A\u0008\u0007.\u000A(list2, Enumerable.First<string>(list));
						list = list2;
					}
					else
					{
						list = Enumerable.ToList<string>(Enumerable.Distinct<string>(list));
					}
					Element element2 = \u0007\u000B\u000E.\u001F;
					for (int i = 0; i < \u0015\u0007\u0019.\u000A(list); i++)
					{
						\u0015\u001C.\u000C\u001C u000C_u001C = new \u0015\u001C.\u000C\u001C();
						u000C_u001C.\u001F = \u0001\u0013\u0007.\u000A(list, i);
						if (i % 20 == 0)
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
							\u0008\u000B\u0004.\u000A();
						}
						element2 = Enumerable.FirstOrDefault<Element>(\u0005\u000E\u0005.\u000A(ref keyValuePair2), new Func<Element, bool>(u000C_u001C.\u000A));
						if (element2 != null)
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
							this.\u0003(\u0015\u001C.\u0002(element2, false, false), \u001F, false);
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
					if (element2 != null)
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
						this.\u0003(\u0015\u001C.\u0002(element2, true, false), \u001F, true);
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
				((IDisposable)enumerator2).Dispose();
			}
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x00097EBC File Offset: 0x000960BC
		public void \u0003(List<Parameter> \u001F, CategoryCollection \u000A, bool \u0007)
		{
			List<RevitParameter> list = \u000D\u000E\u0018.\u000A();
			List<Parameter>.Enumerator enumerator = \u0003\u0007\u0005.\u000A(\u001F);
			try
			{
				while (\u0006\u0007\u0005.\u000A(ref enumerator))
				{
					RevitParameter u000A = \u000F\u0007\u0005.\u000A(\u0012\u0007\u0005.\u000A(ref enumerator), \u0013\u000E\u0018.\u0007(\u000A), \u0007);
					\u0017\u0010\u0018.\u000A(list, u000A);
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u0003(List<Parameter>, CategoryCollection, bool)).MethodHandle;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			ParamNameGroupUniqueHandler.\u0018(this, list);
			ParamUniqueHandler.\u001D(this, list, \u000A);
			this.\u001C(list, \u000A);
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x00097F54 File Offset: 0x00096154
		protected void \u001C(List<RevitParameter> \u001F, CategoryCollection \u000A)
		{
			List<RevitParameter>.Enumerator enumerator = \u0013\u000D\u0018.\u000A(\u001F);
			try
			{
				while (\u0011\u000D\u0018.\u000A(ref enumerator))
				{
					RevitParameter revitParameter = \u0014\u000D\u0018.\u000A(ref enumerator);
					if (!Enumerable.Contains<RevitParameter>(\u001B\u0014\u0019.\u001D(this), revitParameter, new \u0012\u000E()))
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
							RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u001C(List<RevitParameter>, CategoryCollection)).MethodHandle;
						}
						\u0017\u0010\u0018.\u000A(\u001B\u0014\u0019.\u001D(this), revitParameter);
					}
					RevitParameter.FO(this, revitParameter, \u000A);
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

		// Token: 0x06001735 RID: 5941 RVA: 0x00097FEC File Offset: 0x000961EC
		internal static bool \u000D(Parameter \u001F)
		{
			if (\u001F != null)
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u000D(Parameter)).MethodHandle;
				}
				if (!\u0010\u0014\u0007.\u000A(\u001F))
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
					if (!\u000D\u0008\u000A.\u000A(\u001E\u001F\u001D.\u000A(\u0020\u001F\u001D.\u0007(\u001F)), "Element ID", true))
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
						if (\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) < 0L)
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
							return \u001A\u0008\u0019.\u000A(\u0015\u001C.\u0016, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)));
						}
						return false;
					}
				}
				return true;
			}
			return false;
		}

		// Token: 0x06001736 RID: 5942 RVA: 0x00098090 File Offset: 0x00096290
		internal static bool \u000D(Parameter \u001F, string \u000A)
		{
			bool result = false;
			if (\u000D\u0008\u000A.\u000A(\u000A, "Element ID", true))
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
					RuntimeMethodHandle runtimeMethodHandle = methodof(\u0015\u001C.\u000D(Parameter, string)).MethodHandle;
				}
				result = true;
			}
			else if (\u001F != null)
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
				if (!\u0010\u0014\u0007.\u000A(\u001F))
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
					if (\u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) >= 0L)
					{
						return result;
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
					if (!\u001A\u0008\u0019.\u000A(\u0015\u001C.\u0016, \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F))))
					{
						return result;
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
				result = true;
			}
			return result;
		}

		// Token: 0x0400091F RID: 2335
		[CompilerGenerated]
		private List<RevitParameter> \u001F;

		// Token: 0x04000920 RID: 2336
		[CompilerGenerated]
		private List<RevitParameter> \u000A;

		// Token: 0x04000921 RID: 2337
		[CompilerGenerated]
		private Dictionary<long, List<RevitParameter>> \u0007;

		// Token: 0x04000922 RID: 2338
		[CompilerGenerated]
		private List<ParamNameGroupUniqueHandler> \u001D;

		// Token: 0x04000923 RID: 2339
		[CompilerGenerated]
		private Dictionary<string, ParamUniqueHandler> \u0004;

		// Token: 0x04000924 RID: 2340
		[CompilerGenerated]
		private bool \u0019;

		// Token: 0x04000925 RID: 2341
		private static List<long> \u0018;

		// Token: 0x02000913 RID: 2323
		[CompilerGenerated]
		private sealed class \u0020\u001C
		{
			// Token: 0x060051A2 RID: 20898 RVA: 0x001E907C File Offset: 0x001E727C
			internal bool \u000A(Parameter \u001F)
			{
				return \u001A\u0008\u0019.\u000A(\u0001\u0008\u0005.\u000A(this.\u001F), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)));
			}

			// Token: 0x060051A3 RID: 20899 RVA: 0x001E90AC File Offset: 0x001E72AC
			internal bool \u0007(Parameter \u001F)
			{
				return !\u001A\u0008\u0019.\u000A(\u000A\u000E\u0005.\u000A(this.\u001F), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)));
			}

			// Token: 0x040023D7 RID: 9175
			public \u000A\u000D \u001F;
		}

		// Token: 0x02000914 RID: 2324
		[CompilerGenerated]
		private sealed class \u0017\u001C
		{
			// Token: 0x060051A5 RID: 20901 RVA: 0x001E90F4 File Offset: 0x001E72F4
			internal bool \u000A(Parameter \u001F)
			{
				return !\u001A\u0008\u0019.\u000A(\u0001\u0008\u0005.\u000A(this.\u001F), \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)));
			}

			// Token: 0x040023D8 RID: 9176
			public \u000A\u000D \u001F;
		}

		// Token: 0x02000915 RID: 2325
		[CompilerGenerated]
		private sealed class \u0014\u001C
		{
			// Token: 0x060051A7 RID: 20903 RVA: 0x001E913C File Offset: 0x001E733C
			internal bool \u000A(KeyValuePair<long, List<long>> \u001F)
			{
				return \u001A\u0008\u0019.\u000A(this.\u001F, \u0003\u0016\u0010.\u000A(ref \u001F));
			}

			// Token: 0x040023D9 RID: 9177
			public List<long> \u001F;
		}

		// Token: 0x02000916 RID: 2326
		[CompilerGenerated]
		private sealed class \u0013\u001C
		{
			// Token: 0x060051A9 RID: 20905 RVA: 0x001E9174 File Offset: 0x001E7374
			internal bool \u000A(Parameter \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) == (long)this.\u001F;
			}

			// Token: 0x040023DA RID: 9178
			public int \u001F;
		}

		// Token: 0x02000917 RID: 2327
		[CompilerGenerated]
		private sealed class \u001A\u001C
		{
			// Token: 0x060051AB RID: 20907 RVA: 0x001E91B0 File Offset: 0x001E73B0
			internal bool \u000A(Parameter \u001F)
			{
				return \u000B\u001E\u000A.\u000A(\u0014\u001F\u001D.\u0007(\u001F)) == (long)this.\u001F;
			}

			// Token: 0x040023DB RID: 9179
			public int \u001F;
		}

		// Token: 0x02000918 RID: 2328
		[CompilerGenerated]
		private sealed class \u000C\u001C
		{
			// Token: 0x060051AD RID: 20909 RVA: 0x001E91EC File Offset: 0x001E73EC
			internal bool \u000A(Element \u001F)
			{
				return \u0008\u0013\u000A.\u000A(\u0005\u001E\u000A.\u000A(\u001F), this.\u001F);
			}

			// Token: 0x040023DC RID: 9180
			public string \u001F;
		}
	}
}
